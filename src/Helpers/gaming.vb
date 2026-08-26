Imports System
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports Microsoft.Win32

''' <summary>
''' Provides comprehensive gaming optimizations, power plan management, low-latency network tweaks,
''' game library discovery, timer resolution control, and real-time game booster engine.
''' </summary>
Public Class gaming

#Region " Power Plan Management "

    <DllImport("powrprof.dll")> _
    Private Shared Function PowerGetActiveScheme(ByVal UserRootPowerKey As IntPtr, ByRef ActivePolicyGuid As IntPtr) As UInteger
    End Function

    <DllImport("powrprof.dll")> _
    Private Shared Function PowerSetActiveScheme(ByVal UserRootPowerKey As IntPtr, ByRef SchemeGuid As Guid) As UInteger
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function LocalFree(ByVal hMem As IntPtr) As IntPtr
    End Function

    Public Shared ReadOnly GUID_ULTIMATE_PERFORMANCE As New Guid("e9a42b02-d5df-448d-aa00-03f14749eb61")
    Public Shared ReadOnly GUID_HIGH_PERFORMANCE As New Guid("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c")
    Public Shared ReadOnly GUID_BALANCED As New Guid("381b4222-f694-41f0-9685-ff5bb260df2e")
    Public Shared ReadOnly GUID_POWER_SAVER As New Guid("a1841308-3541-4fab-bc81-f71556f20b4a")

    Private Shared _previousPowerPlanGuid As Guid = Guid.Empty

    ''' <summary>
    ''' Retrieves the currently active Windows Power Scheme GUID.
    ''' </summary>
    Public Shared Function GetActivePowerSchemeGuid() As Guid
        Dim pGuid As IntPtr = IntPtr.Zero
        Try
            If PowerGetActiveScheme(IntPtr.Zero, pGuid) = 0 AndAlso pGuid <> IntPtr.Zero Then
                Dim res As Guid = CType(Marshal.PtrToStructure(pGuid, GetType(Guid)), Guid)
                Return res
            End If
        Catch ex As Exception
        Finally
            If pGuid <> IntPtr.Zero Then LocalFree(pGuid)
        End Try
        Return GUID_BALANCED
    End Function

    ''' <summary>
    ''' Activates the specified power scheme GUID.
    ''' </summary>
    Public Shared Function SetActivePowerScheme(schemeGuid As Guid) As Boolean
        Try
            If PowerSetActiveScheme(IntPtr.Zero, schemeGuid) = 0 Then
                Return True
            End If
        Catch ex As Exception
        End Try

        ' Fallback via powercfg command
        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "powercfg.exe"
            psi.Arguments = "-setactive " & schemeGuid.ToString()
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            Using p As Process = Process.Start(psi)
                p.WaitForExit(1000)
                Return (p.ExitCode = 0)
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Unlocks and duplicates the hidden Ultimate Performance power plan if missing.
    ''' </summary>
    Public Shared Function EnsureUltimatePerformancePlan() As Guid
        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "powercfg.exe"
            psi.Arguments = "-duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61"
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            psi.RedirectStandardOutput = True
            Using p As Process = Process.Start(psi)
                Dim output As String = p.StandardOutput.ReadToEnd()
                p.WaitForExit(1500)
                If Not String.IsNullOrEmpty(output) AndAlso output.Contains("GUID:") Then
                    Dim idx As Integer = output.IndexOf("GUID:") + 5
                    Dim guidPart As String = output.Substring(idx).Trim().Split(" "c)(0).Trim()
                    Dim resGuid As Guid
                    If Guid.TryParse(guidPart, resGuid) Then
                        Return resGuid
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
        Return GUID_ULTIMATE_PERFORMANCE
    End Function

    ''' <summary>
    ''' Switches system to Ultimate Performance (or High Performance) power plan, saving current plan for restore.
    ''' </summary>
    Public Shared Function ActivateUltimatePowerPlan() As Boolean
        _previousPowerPlanGuid = GetActivePowerSchemeGuid()
        Dim ultGuid As Guid = EnsureUltimatePerformancePlan()
        If SetActivePowerScheme(ultGuid) Then Return True
        Return SetActivePowerScheme(GUID_HIGH_PERFORMANCE)
    End Function

    ''' <summary>
    ''' Restores the power plan that was active before game boost was enabled.
    ''' </summary>
    Public Shared Function RestorePreviousPowerPlan() As Boolean
        If _previousPowerPlanGuid <> Guid.Empty Then
            Dim res As Boolean = SetActivePowerScheme(_previousPowerPlanGuid)
            _previousPowerPlanGuid = Guid.Empty
            Return res
        End If
        Return SetActivePowerScheme(GUID_BALANCED)
    End Function

    ''' <summary>
    ''' Gets the friendly name of the active power plan.
    ''' </summary>
    Public Shared Function GetActivePowerSchemeName() As String
        Dim currentGuid As Guid = GetActivePowerSchemeGuid()
        If currentGuid.Equals(GUID_ULTIMATE_PERFORMANCE) Then Return "Ultimate Performance"
        If currentGuid.Equals(GUID_HIGH_PERFORMANCE) Then Return "High Performance"
        If currentGuid.Equals(GUID_BALANCED) Then Return "Balanced"
        If currentGuid.Equals(GUID_POWER_SAVER) Then Return "Power Saver"
        Return "Custom Performance"
    End Function

#End Region

#Region " Low-Latency Network & Ping Tweaks "

    ''' <summary>
    ''' Configures TCP NoDelay and Ack Frequency across active network adapters to eliminate packet buffering latency.
    ''' </summary>
    Public Shared Function SetTcpNoDelay(enable As Boolean) As Integer
        Dim count As Integer = 0
        Try
            Dim basePath As String = "SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces"
            Using baseKey As RegistryKey = Registry.LocalMachine.OpenSubKey(basePath, True)
                If baseKey IsNot Nothing Then
                    For Each subKeyName As String In baseKey.GetSubKeyNames()
                        Using ifaceKey As RegistryKey = baseKey.OpenSubKey(subKeyName, True)
                            If ifaceKey IsNot Nothing Then
                                ' Only apply to valid network interfaces with IP configurations
                                If ifaceKey.GetValue("IPAddress") IsNot Nothing OrElse ifaceKey.GetValue("DhcpIPAddress") IsNot Nothing Then
                                    If enable Then
                                        ifaceKey.SetValue("TcpAckFrequency", 1, RegistryValueKind.DWord)
                                        ifaceKey.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord)
                                        ifaceKey.SetValue("TcpDelAckTicks", 0, RegistryValueKind.DWord)
                                    Else
                                        ifaceKey.DeleteValue("TcpAckFrequency", False)
                                        ifaceKey.DeleteValue("TCPNoDelay", False)
                                        ifaceKey.DeleteValue("TcpDelAckTicks", False)
                                    End If
                                    count += 1
                                End If
                            End If
                        End Using
                    Next
                End If
            End Using
        Catch ex As Exception
        End Try
        Return count
    End Function

    ''' <summary>
    ''' Checks whether TCP NoDelay latency optimization is currently enabled on system network interfaces.
    ''' </summary>
    Public Shared Function IsTcpNoDelayEnabled() As Boolean
        Try
            Dim basePath As String = "SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces"
            Using baseKey As RegistryKey = Registry.LocalMachine.OpenSubKey(basePath, False)
                If baseKey IsNot Nothing Then
                    For Each subKeyName As String In baseKey.GetSubKeyNames()
                        Using ifaceKey As RegistryKey = baseKey.OpenSubKey(subKeyName, False)
                            If ifaceKey IsNot Nothing Then
                                Dim noDelayVal = ifaceKey.GetValue("TCPNoDelay")
                                If noDelayVal IsNot Nothing AndAlso CInt(noDelayVal) = 1 Then
                                    Return True
                                End If
                            End If
                        End Using
                    Next
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Disables Windows network throttling index to prevent throughput caps under network load.
    ''' </summary>
    Public Shared Function SetNetworkThrottlingDisabled(disableThrottling As Boolean) As Boolean
        Try
            Dim path As String = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile"
            Using key As RegistryKey = Registry.LocalMachine.OpenSubKey(path, True)
                If key IsNot Nothing Then
                    If disableThrottling Then
                        key.SetValue("NetworkThrottlingIndex", -1, RegistryValueKind.DWord)
                        key.SetValue("SystemResponsiveness", 0, RegistryValueKind.DWord)
                    Else
                        key.SetValue("NetworkThrottlingIndex", 10, RegistryValueKind.DWord)
                        key.SetValue("SystemResponsiveness", 20, RegistryValueKind.DWord)
                    End If
                    Return True
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Checks if Windows multimedia network throttling is disabled.
    ''' </summary>
    Public Shared Function IsNetworkThrottlingDisabled() As Boolean
        Try
            Dim path As String = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile"
            Using key As RegistryKey = Registry.LocalMachine.OpenSubKey(path, False)
                If key IsNot Nothing Then
                    Dim val = key.GetValue("NetworkThrottlingIndex")
                    If val IsNot Nothing AndAlso (CLng(val) = -1L OrElse CLng(val) = 4294967295L) Then
                        Return True
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Flushes Windows DNS resolver cache to eliminate stale gaming server routing.
    ''' </summary>
    Public Shared Function FlushDns() As Boolean
        Try
            Dim psi As New ProcessStartInfo("ipconfig.exe", "/flushdns")
            psi.CreateNoWindow = True
            psi.UseShellExecute = False
            Using p As Process = Process.Start(psi)
                p.WaitForExit(2000)
                Return (p.ExitCode = 0)
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region " Windows Gaming Tweaks "

    ''' <summary>
    ''' Disables background Xbox Game DVR and Game Bar background recording to reclaim GPU and CPU overhead.
    ''' </summary>
    Public Shared Function SetGameDVR(enableGameDVR As Boolean) As Boolean
        Try
            ' 1. AppCaptureEnabled
            Using key1 As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\GameDVR")
                If key1 IsNot Nothing Then
                    key1.SetValue("AppCaptureEnabled", If(enableGameDVR, 1, 0), RegistryValueKind.DWord)
                End If
            End Using

            ' 2. GameDVR_Enabled
            Using key2 As RegistryKey = Registry.CurrentUser.CreateSubKey("System\GameConfigStore")
                If key2 IsNot Nothing Then
                    key2.SetValue("GameDVR_Enabled", If(enableGameDVR, 1, 0), RegistryValueKind.DWord)
                    key2.SetValue("GameDVR_FSEBehaviorMode", If(enableGameDVR, 0, 2), RegistryValueKind.DWord)
                    key2.SetValue("GameDVR_HonorUserFSEBehaviorMode", If(enableGameDVR, 0, 1), RegistryValueKind.DWord)
                End If
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Checks if Game DVR background capture is disabled.
    ''' </summary>
    Public Shared Function IsGameDVRDisabled() As Boolean
        Try
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\GameDVR", False)
                If key IsNot Nothing Then
                    Dim val = key.GetValue("AppCaptureEnabled")
                    If val IsNot Nothing AndAlso CInt(val) = 0 Then Return True
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Sets Windows Visual Effects mode to Best Performance for minimal DWM compositor overhead.
    ''' </summary>
    Public Shared Function SetVisualEffectsPerformance(performanceMode As Boolean) As Boolean
        Try
            Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects")
                If key IsNot Nothing Then
                    key.SetValue("VisualFXSetting", If(performanceMode, 2, 1), RegistryValueKind.DWord)
                    Return True
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Checks whether Hardware-Accelerated GPU Scheduling (HAGS) is supported and active.
    ''' </summary>
    Public Shared Function GetHAGSStatus() As Boolean
        Try
            Using key As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\GraphicsDrivers", False)
                If key IsNot Nothing Then
                    Dim val = key.GetValue("HwSchMode")
                    If val IsNot Nothing AndAlso CInt(val) = 2 Then Return True
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Configures Hardware-Accelerated GPU Scheduling (requires system restart to take effect).
    ''' </summary>
    Public Shared Function SetHAGS(enable As Boolean) As Boolean
        Try
            Using key As RegistryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\CurrentControlSet\Control\GraphicsDrivers")
                If key IsNot Nothing Then
                    key.SetValue("HwSchMode", If(enable, 2, 1), RegistryValueKind.DWord)
                    Return True
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

#End Region

#Region " SSD TRIM Optimizer "

    ''' <summary>
    ''' Runs Windows SSD TRIM and optimization asynchronously across specified drive volumes.
    ''' </summary>
    Public Shared Function RunTrimAsync(drives As List(Of String)) As Task(Of Boolean)
        Return Task.Run(Function()
                            Try
                                If drives Is Nothing OrElse drives.Count = 0 Then
                                    drives = New List(Of String) From {"C:"}
                                End If

                                For Each drv In drives
                                    Dim driveLetter As String = drv.TrimEnd("\"c).TrimEnd("/"c)
                                    Dim psi As New ProcessStartInfo()
                                    psi.FileName = "defrag.exe"
                                    psi.Arguments = driveLetter & " /L /O /U"
                                    psi.CreateNoWindow = True
                                    psi.UseShellExecute = False
                                    Using p As Process = Process.Start(psi)
                                        p.WaitForExit(30000)
                                    End Using
                                Next
                                Return True
                            Catch ex As Exception
                                Return False
                            End Try
                        End Function)
    End Function

#End Region

#Region " Game Scanner & Library "

    ''' <summary>
    ''' Represents an installed game discovered on the local system.
    ''' </summary>
    Public Class GameItem
        Property Name As String = ""
        Property ExecutablePath As String = ""
        Property LauncherType As String = "" ' Steam, Epic, GOG, Custom
        Property AppId As String = ""
        Property InstallDir As String = ""
        Property LaunchCommand As String = ""
        Property Icon As Image = Nothing

        Public ReadOnly Property DisplayName As String
            Get
                Return Name
            End Get
        End Property
    End Class

    ''' <summary>
    ''' Scans installed Steam games across all configured Steam library folders.
    ''' </summary>
    Public Shared Function GetSteamGames() As List(Of GameItem)
        Dim list As New List(Of GameItem)()
        Try
            Dim steamPath As String = ""
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Valve\Steam", False)
                If key IsNot Nothing Then
                    steamPath = TryCast(key.GetValue("SteamPath"), String)
                End If
            End Using

            If String.IsNullOrEmpty(steamPath) Then
                Using key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Valve\Steam", False)
                    If key IsNot Nothing Then
                        steamPath = TryCast(key.GetValue("InstallPath"), String)
                    End If
                End Using
            End If

            If String.IsNullOrEmpty(steamPath) OrElse Not Directory.Exists(steamPath) Then
                Return list
            End If

            Dim libraryFolders As New List(Of String) From {steamPath}
            Dim vdfPath As String = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf")

            If File.Exists(vdfPath) Then
                Dim lines() As String = File.ReadAllLines(vdfPath)
                For Each line As String In lines
                    Dim trimmed As String = line.Trim()
                    If trimmed.Contains("""path""") Then
                        Dim parts = trimmed.Split(New String() {"""path"""}, StringSplitOptions.None)
                        If parts.Length > 1 Then
                            Dim pth As String = parts(1).Replace("""", "").Trim().Replace("\\", "\")
                            If Directory.Exists(pth) AndAlso Not libraryFolders.Contains(pth) Then
                                libraryFolders.Add(pth)
                            End If
                        End If
                    End If
                Next
            End If

            For Each libFolder In libraryFolders
                Dim steamAppsDir As String = Path.Combine(libFolder, "steamapps")
                If Directory.Exists(steamAppsDir) Then
                    For Each manifestFile As String In Directory.GetFiles(steamAppsDir, "appmanifest_*.acf")
                        Try
                            Dim mLines() As String = File.ReadAllLines(manifestFile)
                            Dim appid As String = ""
                            Dim name As String = ""
                            Dim installdir As String = ""

                            For Each mLine In mLines
                                Dim tLine = mLine.Trim()
                                If tLine.StartsWith("""appid""", StringComparison.OrdinalIgnoreCase) Then
                                    appid = ExtractVdfValue(tLine)
                                ElseIf tLine.StartsWith("""name""", StringComparison.OrdinalIgnoreCase) Then
                                    name = ExtractVdfValue(tLine)
                                ElseIf tLine.StartsWith("""installdir""", StringComparison.OrdinalIgnoreCase) Then
                                    installdir = ExtractVdfValue(tLine)
                                End If
                            Next

                            ' Exclude Steamworks Common Redistributables or empty names
                            If Not String.IsNullOrEmpty(name) AndAlso Not name.Contains("Steamworks Common") AndAlso Not String.IsNullOrEmpty(appid) Then
                                Dim commonDir As String = Path.Combine(steamAppsDir, "common", installdir)
                                Dim primaryExe As String = FindPrimaryExecutable(commonDir)

                                Dim gItem As New GameItem() With {
                                    .Name = name,
                                    .AppId = appid,
                                    .InstallDir = commonDir,
                                    .ExecutablePath = primaryExe,
                                    .LauncherType = "Steam",
                                    .LaunchCommand = "steam://run/" & appid
                                }

                                If Not String.IsNullOrEmpty(primaryExe) AndAlso File.Exists(primaryExe) Then
                                    gItem.Icon = proc.GetProcessIcon(primaryExe)
                                Else
                                    gItem.Icon = proc.DefaultProcessIcon
                                End If

                                list.Add(gItem)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                End If
            Next
        Catch ex As Exception
        End Try

        Return list
    End Function

    Private Shared Function ExtractVdfValue(line As String) As String
        Dim quoteIndices As New List(Of Integer)()
        For i As Integer = 0 To line.Length - 1
            If line(i) = """"c Then quoteIndices.Add(i)
        Next
        If quoteIndices.Count >= 4 Then
            Return line.Substring(quoteIndices(2) + 1, quoteIndices(3) - quoteIndices(2) - 1)
        End If
        Return ""
    End Function

    ''' <summary>
    ''' Scans installed Epic Games from launcher manifests.
    ''' </summary>
    Public Shared Function GetEpicGames() As List(Of GameItem)
        Dim list As New List(Of GameItem)()
        Try
            Dim manifestsDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\EpicGamesLauncher\Data\Manifests")
            If Directory.Exists(manifestsDir) Then
                For Each itemFile In Directory.GetFiles(manifestsDir, "*.item")
                    Try
                        Dim text As String = File.ReadAllText(itemFile)
                        Dim displayName As String = ExtractJsonValue(text, "DisplayName")
                        Dim installLocation As String = ExtractJsonValue(text, "InstallLocation")
                        Dim launchExe As String = ExtractJsonValue(text, "LaunchExecutable")
                        Dim appName As String = ExtractJsonValue(text, "AppName")

                        If Not String.IsNullOrEmpty(displayName) AndAlso Not String.IsNullOrEmpty(installLocation) Then
                            Dim fullExe As String = Path.Combine(installLocation, launchExe)
                            Dim gItem As New GameItem() With {
                                .Name = displayName,
                                .AppId = appName,
                                .InstallDir = installLocation,
                                .ExecutablePath = fullExe,
                                .LauncherType = "Epic",
                                .LaunchCommand = "com.epicgames.launcher://apps/" & appName & "?action=launch&silent=true"
                            }

                            If File.Exists(fullExe) Then
                                gItem.Icon = proc.GetProcessIcon(fullExe)
                            Else
                                gItem.Icon = proc.DefaultProcessIcon
                            End If

                            list.Add(gItem)
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
        Catch ex As Exception
        End Try
        Return list
    End Function

    Private Shared Function ExtractJsonValue(json As String, key As String) As String
        Dim searchKey As String = """" & key & """"
        Dim idx As Integer = json.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase)
        If idx = -1 Then Return ""
        Dim colonIdx As Integer = json.IndexOf(":"c, idx + searchKey.Length)
        If colonIdx = -1 Then Return ""
        Dim firstQuote As Integer = json.IndexOf(""""c, colonIdx + 1)
        If firstQuote = -1 Then Return ""
        Dim secondQuote As Integer = json.IndexOf(""""c, firstQuote + 1)
        If secondQuote = -1 Then Return ""
        Return json.Substring(firstQuote + 1, secondQuote - firstQuote - 1).Replace("\\", "\")
    End Function

    ''' <summary>
    ''' Scans installed GOG Galaxy games from system registry.
    ''' </summary>
    Public Shared Function GetGOGGames() As List(Of GameItem)
        Dim list As New List(Of GameItem)()
        Try
            Dim regPaths() As String = {"SOFTWARE\WOW6432Node\GOG.com\Games", "SOFTWARE\GOG.com\Games"}
            For Each regPath In regPaths
                Using baseKey As RegistryKey = Registry.LocalMachine.OpenSubKey(regPath, False)
                    If baseKey IsNot Nothing Then
                        For Each subKeyName In baseKey.GetSubKeyNames()
                            Using gameKey As RegistryKey = baseKey.OpenSubKey(subKeyName, False)
                                If gameKey IsNot Nothing Then
                                    Dim gameName As String = TryCast(gameKey.GetValue("gameName"), String)
                                    Dim exePath As String = TryCast(gameKey.GetValue("exe"), String)
                                    Dim pathStr As String = TryCast(gameKey.GetValue("path"), String)
                                    Dim gameId As String = TryCast(gameKey.GetValue("gameID"), String)

                                    If Not String.IsNullOrEmpty(gameName) Then
                                        Dim fullExe As String = exePath
                                        If Not File.Exists(fullExe) AndAlso Not String.IsNullOrEmpty(pathStr) Then
                                            fullExe = Path.Combine(pathStr, Path.GetFileName(exePath))
                                        End If

                                        Dim gItem As New GameItem() With {
                                            .Name = gameName,
                                            .AppId = gameId,
                                            .InstallDir = pathStr,
                                            .ExecutablePath = fullExe,
                                            .LauncherType = "GOG",
                                            .LaunchCommand = If(File.Exists(fullExe), fullExe, "")
                                        }

                                        If File.Exists(fullExe) Then
                                            gItem.Icon = proc.GetProcessIcon(fullExe)
                                        Else
                                            gItem.Icon = proc.DefaultProcessIcon
                                        End If

                                        list.Add(gItem)
                                    End If
                                End If
                            End Using
                        Next
                    End If
                End Using
            Next
        Catch ex As Exception
        End Try
        Return list
    End Function

    ''' <summary>
    ''' Finds primary executable in a game directory by searching for largest executable.
    ''' </summary>
    Private Shared Function FindPrimaryExecutable(dirPath As String) As String
        If Not Directory.Exists(dirPath) Then Return ""
        Try
            Dim exes() As String = Directory.GetFiles(dirPath, "*.exe", SearchOption.TopDirectoryOnly)
            If exes.Length = 0 Then
                exes = Directory.GetFiles(dirPath, "*.exe", SearchOption.AllDirectories)
            End If

            Dim largestExe As String = ""
            Dim largestSize As Long = 0

            For Each exe In exes
                Dim fName As String = Path.GetFileName(exe).ToLowerInvariant()
                ' Filter out installer/uninstaller/crash reporter binaries
                If fName.Contains("uninstall") OrElse fName.Contains("setup") OrElse fName.Contains("crash") OrElse fName.Contains("update") OrElse fName.Contains("vcredist") Then
                    Continue For
                End If

                Dim len As Long = cleaner.GetFileSizeFast(exe)
                If len > largestSize Then
                    largestSize = len
                    largestExe = exe
                End If
            Next

            Return largestExe
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Aggregates all installed games across Steam, Epic Games, GOG, and custom additions.
    ''' </summary>
    Public Shared Function ScanAllGames() As List(Of GameItem)
        Dim allGames As New List(Of GameItem)()
        Dim seenNames As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For Each steamGame As GameItem In GetSteamGames()
            If Not seenNames.Contains(steamGame.Name) Then
                seenNames.Add(steamGame.Name)
                allGames.Add(steamGame)
            End If
        Next

        For Each epicGame As GameItem In GetEpicGames()
            If Not seenNames.Contains(epicGame.Name) Then
                seenNames.Add(epicGame.Name)
                allGames.Add(epicGame)
            End If
        Next

        For Each gogGame As GameItem In GetGOGGames()
            If Not seenNames.Contains(gogGame.Name) Then
                seenNames.Add(gogGame.Name)
                allGames.Add(gogGame)
            End If
        Next

        allGames.Sort(Function(a, b) String.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase))
        Return allGames
    End Function

#End Region

#Region " Game Booster Engine "

    Public Class BoostReport
        Property StandbyFreedBytes As Long = 0L
        Property ProcessTrimmedBytes As Long = 0L
        Property TimerResolutionMs As Double = 15.6
        Property PowerPlanName As String = "Balanced"
        Property ThrottledProcessesCount As Integer = 0
        Property TargetGameName As String = ""
        Property GamePrioritySet As Boolean = False
    End Class

    Private Shared _isBoostActive As Boolean = False
    Private Shared _activeGameProcess As Process = Nothing

    Public Shared ReadOnly Property IsBoostActive As Boolean
        Get
            Return _isBoostActive
        End Get
    End Property

    Public Shared ReadOnly Property ActiveGameProcess As Process
        Get
            Return _activeGameProcess
        End Get
    End Property

    ''' <summary>
    ''' Engages comprehensive Game Boost: Standby purge, 0.5ms timer, Ultimate power plan, background throttling, and target game priority.
    ''' </summary>
    Public Shared Function EngageGameBoost(Optional targetProcess As Process = Nothing, Optional ignoreList As StringCollection = Nothing) As BoostReport
        Dim report As New BoostReport()

        ' 1. Purge Standby Memory & Trim Working Sets
        Dim memRes As proc.FreeMemoryResult = (New proc()).FreeProcesses()
        report.StandbyFreedBytes = memRes.StandbyPurgedBytes
        report.ProcessTrimmedBytes = memRes.ReleasedBytes

        ' 2. Enable 0.5ms High Resolution Timer
        report.TimerResolutionMs = proc.SetHighResolutionTimer(True)

        ' 3. Activate Ultimate Performance Power Plan
        ActivateUltimatePowerPlan()
        report.PowerPlanName = GetActivePowerSchemeName()

        ' 4. Throttle non-essential background processes
        report.ThrottledProcessesCount = proc.ThrottleBackgroundProcesses(ignoreList)

        ' 5. Elevate target game process if specified
        If targetProcess IsNot Nothing AndAlso Not targetProcess.HasExited Then
            _activeGameProcess = targetProcess
            report.TargetGameName = targetProcess.ProcessName
            Try
                targetProcess.PriorityClass = ProcessPriorityClass.High
                proc.SetProcessIoPriority(targetProcess.Id, 3) ' High I/O
                proc.SetProcessAffinity(targetProcess.Id, proc.GetPerformanceAffinityMask())
                report.GamePrioritySet = True
            Catch ex As Exception
            End Try
        End If

        _isBoostActive = True
        Return report
    End Function

    ''' <summary>
    ''' Disengages Game Boost, restores balanced power plan, default timer resolution, and unthrottles background processes.
    ''' </summary>
    Public Shared Function DisengageGameBoost() As Boolean
        ' 1. Restore Power Plan
        RestorePreviousPowerPlan()

        ' 2. Restore Timer Resolution
        proc.SetHighResolutionTimer(False)

        ' 3. Restore Background Processes
        proc.RestoreBackgroundProcesses()

        ' 4. Reset Target Game
        _activeGameProcess = Nothing
        _isBoostActive = False
        Return True
    End Function

    ''' <summary>
    ''' Launches an installed game with full real-time game boost applied.
    ''' </summary>
    Public Shared Function LaunchGameWithBoost(game As GameItem, Optional ignoreList As StringCollection = Nothing) As BoostReport
        Dim targetProc As Process = Nothing

        Try
            If Not String.IsNullOrEmpty(game.LaunchCommand) AndAlso (game.LaunchCommand.StartsWith("steam://") OrElse game.LaunchCommand.StartsWith("com.epicgames")) Then
                Process.Start(New ProcessStartInfo(game.LaunchCommand) With {.UseShellExecute = True})
            ElseIf Not String.IsNullOrEmpty(game.ExecutablePath) AndAlso File.Exists(game.ExecutablePath) Then
                Dim psi As New ProcessStartInfo(game.ExecutablePath)
                psi.WorkingDirectory = Path.GetDirectoryName(game.ExecutablePath)
                psi.UseShellExecute = True
                targetProc = Process.Start(psi)
            End If
        Catch ex As Exception
        End Try

        Return EngageGameBoost(targetProc, ignoreList)
    End Function

#End Region

End Class
