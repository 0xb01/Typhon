using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Typhon.Lite.Services;

public record MemoryInfo(
    ulong TotalBytes,
    ulong AvailableBytes,
    ulong UsedBytes,
    uint LoadPercentage,
    int ProcessCount
)
{
    public double TotalGB => TotalBytes / (1024.0 * 1024.0 * 1024.0);
    public double UsedGB => UsedBytes / (1024.0 * 1024.0 * 1024.0);
    public double AvailableGB => AvailableBytes / (1024.0 * 1024.0 * 1024.0);
}

public record FreeMemoryResult(
    int TrimmedProcesses,
    long FreedBytes,
    TimeSpan Elapsed
)
{
    public double FreedMB => FreedBytes / (1024.0 * 1024.0);
    public double FreedGB => FreedBytes / (1024.0 * 1024.0 * 1024.0);

    public string FormatFreed()
    {
        if (FreedBytes >= 1024L * 1024L * 1024L)
            return $"{FreedGB:F2} GB";
        if (FreedBytes >= 1024L * 1024L)
            return $"{FreedMB:F0} MB";
        return $"{Math.Max(0, FreedBytes / 1024):N0} KB";
    }
}

public static class MemoryOptimizer
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private class MEMORYSTATUSEX
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public ulong ullTotalPhys;
        public ulong ullAvailPhys;
        public ulong ullTotalPageFile;
        public ulong ullAvailPageFile;
        public ulong ullTotalVirtual;
        public ulong ullAvailVirtual;
        public ulong ullAvailExtendedVirtual;

        public MEMORYSTATUSEX()
        {
            dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct LUID
    {
        public uint LowPart;
        public int HighPart;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct LUID_AND_ATTRIBUTES
    {
        public LUID Luid;
        public uint Attributes;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct TOKEN_PRIVILEGES
    {
        public uint PrivilegeCount;
        public LUID_AND_ATTRIBUTES Privilege;
    }

    private const uint TOKEN_ADJUST_PRIVILEGES = 0x20;
    private const uint TOKEN_QUERY = 0x8;
    private const uint SE_PRIVILEGE_ENABLED = 0x2;

    private const int SystemMemoryListInformation = 80;
    private const int MemoryPurgeStandbyList = 4;

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetProcessWorkingSetSize(IntPtr hProcess, IntPtr dwMinimumWorkingSetSize, IntPtr dwMaximumWorkingSetSize);

    [DllImport("psapi.dll", SetLastError = true)]
    private static extern bool EmptyWorkingSet(IntPtr hProcess);

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool LookupPrivilegeValue(string? lpSystemName, string lpName, out LUID lpLuid);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool AdjustTokenPrivileges(
        IntPtr TokenHandle,
        bool DisableAllPrivileges,
        ref TOKEN_PRIVILEGES NewState,
        uint BufferLength,
        IntPtr PreviousState,
        IntPtr ReturnLength);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hObject);

    [DllImport("ntdll.dll", SetLastError = true)]
    private static extern int NtSetSystemInformation(
        int SystemInformationClass,
        IntPtr SystemInformation,
        int SystemInformationLength);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

    // Critical processes and IDE/developer tools that must NEVER be trimmed to avoid freezing
    private static readonly HashSet<string> ExcludedProcesses = new(StringComparer.OrdinalIgnoreCase)
    {
        // Visual Studio and developer toolchain (prevents IDE hard page fault lockup)
        "devenv",
        "vbcscompiler",
        "msbuild",
        "vshost32",
        "vshost",
        "perfwatson2",
        "dotnet",
        "code",
        "rider64",
        "idea64",
        "studio64",
        "git",

        // Windows Shell and core services
        "explorer",
        "dwm",
        "csrss",
        "smss",
        "lsass",
        "services",
        "svchost",
        "winlogon",
        "wininit",
        "fontdrvhost",
        "audiodg",
        "taskhostw",
        "sihost",
        "ctfmon",
        "searchhost",
        "startmenuexperiencehost",
        "shellexperiencehost",
        "system",
        "idle"
    };

    public static MemoryInfo GetMemoryInfo()
    {
        var mem = new MEMORYSTATUSEX();
        if (GlobalMemoryStatusEx(mem))
        {
            ulong total = mem.ullTotalPhys;
            ulong avail = mem.ullAvailPhys;
            ulong used = total > avail ? total - avail : 0;
            int procCount = 0;
            try
            {
                procCount = Process.GetProcesses().Length;
            }
            catch
            {
            }

            return new MemoryInfo(total, avail, used, mem.dwMemoryLoad, procCount);
        }

        return new MemoryInfo(0, 0, 0, 0, 0);
    }

    public static bool EnablePrivilege(string privilegeName)
    {
        try
        {
            if (OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out IntPtr hToken))
            {
                try
                {
                    if (LookupPrivilegeValue(null, privilegeName, out LUID luid))
                    {
                        var tp = new TOKEN_PRIVILEGES
                        {
                            PrivilegeCount = 1,
                            Privilege = new LUID_AND_ATTRIBUTES
                            {
                                Luid = luid,
                                Attributes = SE_PRIVILEGE_ENABLED
                            }
                        };
                        return AdjustTokenPrivileges(hToken, false, ref tp, (uint)Marshal.SizeOf(tp), IntPtr.Zero, IntPtr.Zero);
                    }
                }
                finally
                {
                    CloseHandle(hToken);
                }
            }
        }
        catch
        {
        }
        return false;
    }

    /// <summary>
    /// Purges Windows Standby Cache to free inactive cached memory without touching active working sets.
    /// Note: Does NOT call MemoryEmptyWorkingSets (command 2), which forces active apps to page-fault and freeze.
    /// </summary>
    public static void PurgeStandbyMemory()
    {
        try
        {
            EnablePrivilege("SeProfileSingleProcessPrivilege");
            EnablePrivilege("SeIncreaseQuotaPrivilege");

            IntPtr pCommand = Marshal.AllocHGlobal(4);
            try
            {
                // Purge Standby List Cache only (safe, frees gigabytes without freezing running apps)
                Marshal.WriteInt32(pCommand, MemoryPurgeStandbyList);
                NtSetSystemInformation(SystemMemoryListInformation, pCommand, 4);
            }
            finally
            {
                Marshal.FreeHGlobal(pCommand);
            }
        }
        catch
        {
        }
    }

    public static FreeMemoryResult FreeMemory()
    {
        var sw = Stopwatch.StartNew();
        MemoryInfo before = GetMemoryInfo();

        int trimmedCount = 0;
        IntPtr minusOne = new IntPtr(-1);
        int selfPid = Environment.ProcessId;

        // Detect active foreground window to avoid freezing what the user is actively using
        uint foregroundPid = 0;
        try
        {
            IntPtr fgHwnd = GetForegroundWindow();
            if (fgHwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(fgHwnd, out foregroundPid);
            }
        }
        catch
        {
        }

        Process[] processes;
        try
        {
            processes = Process.GetProcesses();
        }
        catch
        {
            processes = Array.Empty<Process>();
        }

        foreach (Process proc in processes)
        {
            try
            {
                // 1. Skip self
                if (proc.Id == selfPid) continue;

                // 2. Skip active foreground application (prevents UI freeze on active work)
                if (foregroundPid > 0 && proc.Id == (int)foregroundPid) continue;

                // 3. Skip Visual Studio / IDE / compiler / critical processes
                string name = proc.ProcessName;
                if (ExcludedProcesses.Contains(name) ||
                    name.StartsWith("ServiceHub", StringComparison.OrdinalIgnoreCase) ||
                    name.StartsWith("Microsoft.ServiceHub", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // 4. Safely trim memory for background processes
                bool trimmed = false;
                try
                {
                    if (SetProcessWorkingSetSize(proc.Handle, minusOne, minusOne))
                        trimmed = true;
                }
                catch
                {
                    try
                    {
                        if (EmptyWorkingSet(proc.Handle))
                            trimmed = true;
                    }
                    catch
                    {
                    }
                }

                if (trimmed)
                    trimmedCount++;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    proc.Dispose();
                }
                catch
                {
                }
            }
        }

        // Purge Windows Standby List Cache (frees standby memory without flushing active working sets)
        PurgeStandbyMemory();

        System.Threading.Thread.Sleep(40);

        MemoryInfo after = GetMemoryInfo();
        long freedBytes = 0;
        if (after.AvailableBytes > before.AvailableBytes)
        {
            freedBytes = (long)(after.AvailableBytes - before.AvailableBytes);
        }

        sw.Stop();
        return new FreeMemoryResult(trimmedCount, freedBytes, sw.Elapsed);
    }

    public static Task<FreeMemoryResult> FreeMemoryAsync()
    {
        return Task.Run(FreeMemory);
    }
}
