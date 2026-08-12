Imports System
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Collections.Specialized
Imports System.Collections.Generic

''' <summary>
''' Provides process management, memory optimization, and native Win32 P/Invoke functions.
''' </summary>
Public Class proc

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function QueryFullProcessImageName( _
        ByVal hProcess As IntPtr, _
        ByVal dwFlags As UInteger, _
        ByVal lpExeName As StringBuilder, _
        ByRef lpdwSize As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function OpenProcess( _
        ByVal dwDesiredAccess As UInteger, _
        ByVal bInheritHandle As Boolean, _
        ByVal dwProcessId As UInteger) As IntPtr
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function CloseHandle(ByVal hObject As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function GetSystemTimes( _
        ByRef lpIdleTime As System.Runtime.InteropServices.ComTypes.FILETIME, _
        ByRef lpKernelTime As System.Runtime.InteropServices.ComTypes.FILETIME, _
        ByRef lpUserTime As System.Runtime.InteropServices.ComTypes.FILETIME) As Boolean
    End Function

    Private Shared _prevIdleTime As Long = 0
    Private Shared _prevKernelTime As Long = 0
    Private Shared _prevUserTime As Long = 0

    Private Shared Function FileTimeToLong(ft As System.Runtime.InteropServices.ComTypes.FILETIME) As Long
        Dim high As Long = CLng(ft.dwHighDateTime)
        If high < 0 Then high += 4294967296L
        Dim low As Long = CLng(ft.dwLowDateTime)
        If low < 0 Then low += 4294967296L
        Return (high * 4294967296L) + low
    End Function

    Private Shared _cpuCounter As PerformanceCounter = Nothing
    Private Shared _cpuCounterInitialized As Boolean = False

    ''' <summary>
    ''' Fast CPU usage percentage tracker using PerformanceCounter with Win32 P/Invoke fallback.
    ''' </summary>
    Public Function GetCPUPercentage() As Integer
        Try
            If Not _cpuCounterInitialized Then
                _cpuCounterInitialized = True
                _cpuCounter = New PerformanceCounter("Processor", "% Processor Time", "_Total")
                _cpuCounter.NextValue()
            End If

            If _cpuCounter IsNot Nothing Then
                Dim val As Single = _cpuCounter.NextValue()
                Return Math.Min(100, Math.Max(0, CInt(val)))
            End If
        Catch ex As Exception
        End Try

        Try
            Dim idleTime, kernelTime, userTime As System.Runtime.InteropServices.ComTypes.FILETIME
            If GetSystemTimes(idleTime, kernelTime, userTime) Then
                Dim idle As Long = FileTimeToLong(idleTime)
                Dim kernel As Long = FileTimeToLong(kernelTime)
                Dim user As Long = FileTimeToLong(userTime)

                If _prevIdleTime = 0 Then
                    _prevIdleTime = idle
                    _prevKernelTime = kernel
                    _prevUserTime = user
                    Return 0
                End If

                Dim diffIdle As Long = idle - _prevIdleTime
                Dim diffKernel As Long = kernel - _prevKernelTime
                Dim diffUser As Long = user - _prevUserTime

                _prevIdleTime = idle
                _prevKernelTime = kernel
                _prevUserTime = user

                Dim totalSys As Long = diffKernel + diffUser
                If totalSys > 0 Then
                    Dim busySys As Long = (diffKernel - diffIdle) + diffUser
                    If busySys < 0 Then busySys = 0
                    Dim cpuUsage As Double = (busySys / CDbl(totalSys)) * 100.0
                    Return Math.Min(100, Math.Max(0, CInt(cpuUsage)))
                End If
            End If
        Catch ex As Exception
        End Try
        Return 0
    End Function

    Private Shared _gpuCounters As New List(Of PerformanceCounter)()
    Private Shared _gpuCounterInitialized As Boolean = False

    ''' <summary>
    ''' Performance counter GPU usage percentage tracker (Windows 10 / 11).
    ''' Sums utilization across active 3D GPU engine instances.
    ''' </summary>
    Public Function GetGPUPercentage() As Integer
        Try
            If Not _gpuCounterInitialized Then
                _gpuCounterInitialized = True
                If PerformanceCounterCategory.Exists("GPU Engine") Then
                    Dim cat As New PerformanceCounterCategory("GPU Engine")
                    Dim instanceNames() As String = cat.GetInstanceNames()
                    For Each inst As String In instanceNames
                        If inst.EndsWith("engtype_3D", StringComparison.OrdinalIgnoreCase) OrElse inst.Contains("3D") Then
                            Try
                                Dim pc As New PerformanceCounter("GPU Engine", "Utilization Percentage", inst)
                                pc.NextValue()
                                _gpuCounters.Add(pc)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            End If

            If _gpuCounters.Count > 0 Then
                Dim totalGPU As Double = 0
                For Each pc As PerformanceCounter In _gpuCounters
                    Try
                        totalGPU += pc.NextValue()
                    Catch ex As Exception
                    End Try
                Next
                Return Math.Min(100, Math.Max(0, CInt(totalGPU)))
            End If
        Catch ex As Exception
        End Try

        Return 0
    End Function

    Private Const PROCESS_QUERY_LIMITED_INFORMATION As UInteger = &H1000

    ''' <summary>
    ''' Queries MS-DOS device names mapped to physical drive paths.
    ''' </summary>
    <DllImport("kernel32.dll", EntryPoint:="QueryDosDevice")> _
    Shared Function DosDevice( _
        ByVal name As String, _
        ByVal path As StringBuilder, _
        ByVal length As UInteger) As UInteger
    End Function

    ''' <summary>
    ''' Retrieves the full device file path for the specified process handle.
    ''' </summary>
    <DllImport("psapi.dll", EntryPoint:="GetProcessImageFileName")> _
    Shared Function ProcessFileName( _
        ByVal handle As IntPtr, _
        ByVal name As StringBuilder, _
        ByVal size As UInteger) As UInteger
    End Function

    ''' <summary>
    ''' Sets minimum and maximum working set sizes for a process. Passing (-1, -1) forces memory trimming.
    ''' </summary>
    <DllImport("kernel32.dll", EntryPoint:="SetProcessWorkingSetSize")> _
    Shared Function SetWorkingSet( _
        ByVal handle As IntPtr, _
        ByVal minimum As IntPtr, _
        ByVal maximum As IntPtr) As Boolean
    End Function

    Private Shared _cachedDosMap As Dictionary(Of String, String) = Nothing
    Private Shared Function GetDosDeviceMap() As Dictionary(Of String, String)
        If _cachedDosMap IsNot Nothing Then Return _cachedDosMap

        Dim map As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each drv As String In Environment.GetLogicalDrives()
            Dim dosDeviceBuf As New StringBuilder(512)
            If DosDevice(drv.Substring(0, 2), dosDeviceBuf, 512) > 0 Then
                map(drv.Substring(0, 2)) = dosDeviceBuf.ToString()
            End If
        Next
        _cachedDosMap = map
        Return map
    End Function

    ''' <summary>
    ''' Resolves the full file system path for a target process by querying Win32 image APIs with fallback to DOS device mapping.
    ''' </summary>
    Private Function ProcessHandle(ByVal procItem As Process) As String
        If procItem Is Nothing Then Return String.Empty

        Try
            Dim hProc As IntPtr = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, False, CUInt(procItem.Id))
            If Not hProc = IntPtr.Zero Then
                Try
                    Dim capacity As UInteger = 1024
                    Dim sb As New StringBuilder(CInt(capacity))
                    If QueryFullProcessImageName(hProc, 0, sb, capacity) Then
                        Return sb.ToString().ToLower()
                    End If
                Finally
                    CloseHandle(hProc)
                End Try
            End If
        Catch ex As Exception
        End Try

        ' Fallback to legacy GetProcessImageFileName + DosDevice lookup if QueryFullProcessImageName fails
        Try
            Dim handle As IntPtr = procItem.Handle
            Dim rawName As New StringBuilder(512)
            If ProcessFileName(handle, rawName, 512) > 0 Then
                Dim procStr As String = rawName.ToString()
                Dim dosMap As Dictionary(Of String, String) = GetDosDeviceMap()
                For Each kvp In dosMap
                    If procStr.StartsWith(kvp.Value, StringComparison.OrdinalIgnoreCase) Then
                        Return Path.GetFullPath(kvp.Key & procStr.Remove(0, kvp.Value.Length)).ToLower()
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        Return String.Empty
    End Function

    ''' <summary>
    ''' Gets the total number of running system processes.
    ''' </summary>
    Function GetTotalProcesses() As Integer
        Dim procs() As Process = Process.GetProcesses()
        Dim count As Integer = procs.Length
        For Each p As Process In procs
            p.Dispose()
        Next
        Return count
    End Function

    ''' <summary>
    ''' Formats current system RAM usage in gigabytes and percentage string.
    ''' </summary>
    Function GetRAMUsage() As String
        Dim currentRAM As ULong = My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory
        Dim ramUsage As Double = currentRAM / (1024.0 * 1024.0 * 1024.0)
        Return (ramUsage.ToString("N1") & Space(1) & "GB" & Space(1) & "(" & GetRAMPercentage() & "%)")
    End Function

    ''' <summary>
    ''' Calculates current system physical memory usage as a percentage.
    ''' </summary>
    Function GetRAMPercentage() As String
        Dim maxRAM As ULong = My.Computer.Info.TotalPhysicalMemory
        If maxRAM = 0UL Then Return "0"
        Dim currentRAM As ULong = My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory
        Dim ramPercent As Double = (currentRAM / CDbl(maxRAM)) * 100.0
        Return ramPercent.ToString("N0")
    End Function

    ''' <summary>
    ''' Forces memory working set trimming on all accessible processes to release unallocated RAM.
    ''' </summary>
    Function FreeProcesses() As Integer
        Dim processSize As Integer = 0
        Dim minusOne As New IntPtr(-1)
        Dim procs() As Process = Process.GetProcesses()
        For Each procItem As Process In procs
            Try
                If SetWorkingSet(procItem.Handle, minusOne, minusOne) Then
                    processSize += 1
                End If
            Catch ex As Exception
                ' Protected or system process handle access error
            Finally
                procItem.Dispose()
            End Try
        Next
        Return processSize
    End Function

    ''' <summary>
    ''' Internal helper returning list of active non-system killable background processes.
    ''' </summary>
    Private Function GetKillableProcessItems(Optional ignoreList As StringCollection = Nothing) As List(Of Process)
        Dim result As New List(Of Process)()
        Dim exclusions As String() = {Environment.SystemDirectory.ToLower(), Path.GetDirectoryName(Environment.SystemDirectory).ToLower()}

        Dim currentProcess As Process = Process.GetCurrentProcess()
        Dim selfPath As String = ProcessHandle(currentProcess)
        currentProcess.Dispose()

        Dim procs() As Process = Process.GetProcesses()
        For Each procItem As Process In procs
            Try
                Dim targetPath As String = ProcessHandle(procItem)
                If Not String.IsNullOrEmpty(targetPath) AndAlso Not targetPath.Equals(selfPath, StringComparison.OrdinalIgnoreCase) Then
                    Dim dirName As String = Path.GetDirectoryName(targetPath)
                    If Not String.IsNullOrEmpty(dirName) AndAlso Array.IndexOf(exclusions, dirName.ToLower()) = -1 Then
                        Dim fileName As String = Path.GetFileName(targetPath)
                        If ignoreList Is Nothing OrElse Not ignoreList.Contains(fileName) Then
                            result.Add(procItem)
                            Continue For
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try

            procItem.Dispose()
        Next

        Return result
    End Function

    ''' <summary>
    ''' Scans active processes and returns executable file names eligible to be safely terminated.
    ''' </summary>
    Function GetKillableProcesses(Optional ignoreList As StringCollection = Nothing) As String()
        Dim processNames As New List(Of String)()
        Dim items As List(Of Process) = GetKillableProcessItems(ignoreList)
        For Each p As Process In items
            Try
                Dim targetPath As String = ProcessHandle(p)
                Dim fileName As String = Path.GetFileName(targetPath)
                If Not String.IsNullOrEmpty(fileName) AndAlso Not processNames.Contains(fileName) Then
                    processNames.Add(fileName)
                End If
            Catch ex As Exception
            Finally
                p.Dispose()
            End Try
        Next
        Return processNames.ToArray()
    End Function

    ''' <summary>
    ''' Terminates all non-system killable background processes excluding items in the ignore list.
    ''' </summary>
    Function KillProcesses(Optional ignoreList As StringCollection = Nothing) As Integer
        Dim killedCount As Integer = 0
        Dim items As List(Of Process) = GetKillableProcessItems(ignoreList)
        For Each p As Process In items
            Try
                p.Kill()
                killedCount += 1
            Catch ex As Exception
            Finally
                p.Dispose()
            End Try
        Next
        Return killedCount
    End Function
End Class
