Imports System.Collections.Specialized
Imports System.Threading.Tasks
Imports Microsoft.Win32

''' <summary>
''' Main application window handling system monitoring, RAM optimization, junk file cleaning, and settings.
''' </summary>
Public Class WinMain

    Private _proc As proc = New proc()
    Private _func As func = New func()

    Dim cycles As Integer = 300
    Dim init As Boolean = True
    Dim autoFreeCounter As Integer = 0
    Private _deviceChangeTimer As System.Windows.Forms.Timer = Nothing
    Private _isSpecsLoading As Boolean = False
    Private _isFreeingMemory As Boolean = False

    ''' <summary>
    ''' Collection of process executable names excluded from process termination operations.
    ''' </summary>
    Public ProcessIgnoreList As New StringCollection()

    ''' <summary>
    ''' Displays a status notification message on the UI with automatic cooldown timer.
    ''' </summary>
    ''' <param name="title">Prefix title tag.</param>
    ''' <param name="message">Notification description text.</param>
    Public Sub ShowNotification(title As String, message As String)
        lblStatusMessage.Value1 = title
        lblStatusMessage.Value2 = Space(1) & message
        timerNotificationCooldown.Start()

        If notifTrayIcon.Visible Then
            notifTrayIcon.ShowBalloonTip(3000, "Typhon PC Booster", title & Space(1) & message, ToolTipIcon.Info)
        End If
    End Sub

    ''' <summary>
    ''' Initializes application controls, queries system hardware specs, and loads user settings.
    ''' </summary>
    Sub LoadStuff()
        ShowNotification("~X:", "Loading system information...")

        Dim infoProcessor As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor\0", "ProcessorNameString", Nothing)
        If infoProcessor IsNot Nothing Then infoProcessor = infoProcessor.Trim()

        Dim osName As String = _func.GetOS()
        Dim ramSize As String = _func.GetTotalRAM()

        ' Uppercase computer name in brackets
        gbRAMOverview.Title = "[" & Environment.MachineName.ToUpper() & "]"

        ' Subtitle: OS, CPU, RAM without waiting for WMI GPU query
        Dim subTitleParts As New List(Of String)()
        If Not String.IsNullOrEmpty(osName) Then subTitleParts.Add(osName)
        If Not String.IsNullOrEmpty(infoProcessor) Then subTitleParts.Add(infoProcessor)
        If Not String.IsNullOrEmpty(ramSize) Then subTitleParts.Add(ramSize)

        gbRAMOverview.SubTitle = String.Join(vbNewLine, subTitleParts.ToArray())

        ' Asynchronously resolve GPU name in background to prevent startup freeze
        Task.Run(Sub()
                     Dim gpuName As String = _func.GetGPUName()
                     If Not String.IsNullOrEmpty(gpuName) AndAlso Not Me.IsDisposed AndAlso Me.IsHandleCreated Then
                         Me.BeginInvoke(Sub()
                                            If Not Me.IsDisposed Then
                                                Dim updatedParts As New List(Of String)()
                                                If Not String.IsNullOrEmpty(osName) Then updatedParts.Add(osName)
                                                If Not String.IsNullOrEmpty(infoProcessor) Then updatedParts.Add(infoProcessor)
                                                updatedParts.Add(gpuName)
                                                If Not String.IsNullOrEmpty(ramSize) Then updatedParts.Add(ramSize)
                                                gbRAMOverview.SubTitle = String.Join(vbNewLine, updatedParts.ToArray())
                                            End If
                                        End Sub)
                     End If
                 End Sub)

        ' Dynamic version from assembly build properties: v<Major>.<Minor>-<Build>
        Dim ver As Version = My.Application.Info.Version
        lblAboutAppVersion.Text = "v" & ver.Major & "." & ver.Minor & "-" & ver.Build

        RefreshSpecsList()

        timerRealtimeRAM.Enabled = True

        My.Settings.Reload()

        If My.Settings.IgnoreProcessList IsNot Nothing AndAlso My.Settings.IgnoreProcessList.Count > 0 Then
            ProcessIgnoreList = My.Settings.IgnoreProcessList
        Else
            ProcessIgnoreList = GetDefaultIgnoreList()
            My.Settings.IgnoreProcessList = ProcessIgnoreList
            My.Settings.Save()
        End If

        If My.Settings.AutoFreeRAMMode >= 0 AndAlso My.Settings.AutoFreeRAMMode < cboAutoFreeRAM.Items.Count Then
            cboAutoFreeRAM.SelectedIndex = My.Settings.AutoFreeRAMMode
        Else
            cboAutoFreeRAM.SelectedIndex = 0
        End If

        If My.Settings.AutoStartOnBoot Then
            SetBootAutostart(True)
        End If
        toggleAutoStartOnBoot.Checked = My.Settings.AutoStartOnBoot
        toggleMinimizeToTray.Checked = My.Settings.MinimizeToTray
        toggleCloseToTray.Checked = My.Settings.CloseToTray
        toggleStartMinimizedOnBoot.Checked = My.Settings.StartMinimizedOnBoot

        If Me.Icon IsNot Nothing Then
            notifTrayIcon.Icon = Me.Icon
        End If

        If Environment.GetCommandLineArgs().Contains("/minimized", StringComparer.OrdinalIgnoreCase) OrElse (My.Settings.StartMinimizedOnBoot AndAlso My.Settings.AutoStartOnBoot) Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            notifTrayIcon.Visible = True
        End If

        init = False
    End Sub

    ''' <summary>
    ''' Returns default protection whitelist executables.
    ''' </summary>
    Public Shared Function GetDefaultIgnoreList() As StringCollection
        Dim col As New StringCollection()
        Dim defaults() As String = {
            "chrome.exe", "msedge.exe", "firefox.exe", "brave.exe", "opera.exe",
            "devenv.exe", "Code.exe", "idea64.exe", "eclipse.exe",
            "sqlservr.exe", "mysqld.exe", "postgres.exe",
            "onedrive.exe", "dropbox.exe", "googledrivefs.exe",
            "MsMpEng.exe", "NisSrv.exe", "SecurityHealthService.exe"
        }
        col.AddRange(defaults)
        Return col
    End Function

    ''' <summary>
    ''' Form load event handler.
    ''' </summary>
    Private Sub WinMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadStuff()
    End Sub

    ''' <summary>
    ''' Timer tick event handler updating active process counts and RAM usage indicators in real-time.
    ''' Triggers automatic memory optimization based on dropdown selection.
    ''' </summary>
    Private Sub timerRealtimeRAM_Tick(sender As System.Object, e As System.EventArgs) Handles timerRealtimeRAM.Tick
        lblProcessCount.Value2 = Space(1) & _proc.GetTotalProcesses
        lblRAMUsage.Value2 = Space(1) & _proc.GetRAMUsage
        pbRAMUsage.Value = _proc.GetRAMPercentage

        Dim mode As Integer = My.Settings.AutoFreeRAMMode
        If mode > 0 Then
            autoFreeCounter += 1
            Select Case mode
                Case 1 ' Every 1 minute
                    If autoFreeCounter >= 60 Then
                        autoFreeCounter = 0
                        Task.Run(Sub() _proc.FreeProcesses())
                    End If

                Case 2 ' Every 5 minutes
                    If autoFreeCounter >= 300 Then
                        autoFreeCounter = 0
                        Task.Run(Sub() _proc.FreeProcesses())
                    End If

                Case 3 ' Every 10 minutes
                    If autoFreeCounter >= 600 Then
                        autoFreeCounter = 0
                        Task.Run(Sub() _proc.FreeProcesses())
                    End If

                Case 4 ' When reaching 80% RAM
                    Dim currentRAMPct As Integer = _proc.GetRAMPercentage()
                    If currentRAMPct >= 80 AndAlso autoFreeCounter >= 30 Then
                        autoFreeCounter = 0
                        Task.Run(Sub() _proc.FreeProcesses())
                    End If
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Click event handler triggering memory working set release for all processes asynchronously.
    ''' </summary>
    Private Async Sub btnFreeRAM_Click(sender As System.Object, e As System.EventArgs) Handles btnFreeRAM.Click
        If _isFreeingMemory Then Return
        _isFreeingMemory = True
        btnFreeRAM.Enabled = False
        ShowNotification("RAM:", "Optimizing system memory...")

        Dim res As proc.FreeMemoryResult = Await _proc.FreeProcessesAsync()

        If res.ReleasedBytes > 1024L * 512L Then
            ShowNotification("RAM:", "Released " & cleaner.FormatBytes(res.ReleasedBytes) & " across " & res.ProcessCount & " processes")
        Else
            ShowNotification("RAM:", "Trimmed working sets for " & res.ProcessCount & " processes")
        End If

        btnFreeRAM.Enabled = True
        _isFreeingMemory = False
    End Sub

    ''' <summary>
    ''' Timer tick event handler clearing status notification text after cooldown.
    ''' </summary>
    Private Sub timerNotificationCooldown_Tick(sender As System.Object, e As System.EventArgs) Handles timerNotificationCooldown.Tick
        lblStatusMessage.Value1 = ""
        lblStatusMessage.Value2 = ""
        timerNotificationCooldown.Stop()
    End Sub

    ''' <summary>
    ''' Click event handler opening the WinKill process manager window.
    ''' </summary>
    Private Sub btnProcesses_Click(sender As System.Object, e As System.EventArgs) Handles btnProcesses.Click
        Using dlg As New WinKill()
            dlg.ShowDialog(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Click event handler opening the WinExceptions window.
    ''' </summary>
    Private Sub btnManageExceptions_Click(sender As System.Object, e As System.EventArgs) Handles btnManageExceptions.Click
        Using frm As New WinExceptions()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private peakRAMPct As Integer = 0

    ''' <summary>
    ''' Timer tick event handler updating the RAM, CPU, and GPU usage chart visualization with smooth 60-point rolling window.
    ''' </summary>
    Private Sub timerGraph_Tick(sender As System.Object, e As System.EventArgs) Handles timerGraph.Tick
        Dim ramPct As Integer = CInt(Val(_proc.GetRAMPercentage()))
        Dim cpuPct As Integer = _proc.GetCPUPercentage()
        Dim gpuPct As Integer = _proc.GetGPUPercentage()

        If ramPct > peakRAMPct Then peakRAMPct = ramPct

        Dim s1 As System.Windows.Forms.DataVisualization.Charting.Series = chartPerformance.Series("Series1")
        Dim s2 As System.Windows.Forms.DataVisualization.Charting.Series = chartPerformance.Series("Series2")
        Dim s3 As System.Windows.Forms.DataVisualization.Charting.Series = chartPerformance.Series("Series3")

        s1.Points.Add(ramPct)
        s2.Points.Add(cpuPct)
        s3.Points.Add(gpuPct)

        While s1.Points.Count > 60
            s1.Points.RemoveAt(0)
        End While

        While s2.Points.Count > 60
            s2.Points.RemoveAt(0)
        End While

        While s3.Points.Count > 60
            s3.Points.RemoveAt(0)
        End While

        lblLivePerformanceStats.Value2 = " RAM: " & ramPct & "% | Peak: " & peakRAMPct & "% | CPU: " & cpuPct & "% | GPU: " & gpuPct & "%"
    End Sub

    Private _isSwitchingTab As Boolean = False

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        If _isSwitchingTab Then Return
        _isSwitchingTab = True
        Try
            If tabMain.SelectedTab Is tabCleaner Then
                tabMain.SelectedTab = tabOverview
                Using dlg As New WinCleaner()
                    dlg.ShowDialog(Me)
                End Using
            ElseIf tabMain.SelectedTab Is tabSpaceLens Then
                tabMain.SelectedTab = tabOverview
                Using dlg As New WinSight()
                    dlg.ShowDialog(Me)
                End Using
            ElseIf tabMain.SelectedTab Is tabSpecs Then
                RefreshSpecsList()
            End If
        Finally
            _isSwitchingTab = False
        End Try
    End Sub

    ''' <summary>
    ''' Dropdown selection change event handler saving Auto-Free RAM mode setting.
    ''' </summary>
    Private Sub cboAutoFreeRAM_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAutoFreeRAM.SelectedIndexChanged
        My.Settings.AutoFreeRAMMode = cboAutoFreeRAM.SelectedIndex
        autoFreeCounter = 0
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' Configures or removes Windows boot autostart via Registry Run Key and Scheduled Task (for elevated execution).
    ''' </summary>
    ''' <param name="enable">True to add autostart; False to remove it.</param>
    Private Sub SetBootAutostart(enable As Boolean)
        Try
            ' 1. Set HKCU Registry Run Key
            Using runKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                If runKey IsNot Nothing Then
                    If enable Then
                        Dim execPath As String = """" & Application.ExecutablePath & """"
                        runKey.SetValue("Typhon", execPath)
                    Else
                        If runKey.GetValue("Typhon") IsNot Nothing Then
                            runKey.DeleteValue("Typhon", False)
                        End If
                    End If
                End If
            End Using

            ' 2. Manage Scheduled Task for elevated startup (since requireAdministrator apps are blocked by Windows in HKCU Run at logon)
            Dim execExe As String = Application.ExecutablePath
            If enable Then
                Dim psi As New ProcessStartInfo()
                psi.FileName = "schtasks.exe"
                psi.Arguments = "/Create /TN ""TyphonAutoStart"" /TR """"" & execExe & """ /minimized"" /SC ONLOGON /RL HIGHEST /F"
                psi.UseShellExecute = False
                psi.CreateNoWindow = True
                Using p As Process = Process.Start(psi)
                    p.WaitForExit()
                End Using
            Else
                Dim psi As New ProcessStartInfo()
                psi.FileName = "schtasks.exe"
                psi.Arguments = "/Delete /TN ""TyphonAutoStart"" /F"
                psi.UseShellExecute = False
                psi.CreateNoWindow = True
                Using p As Process = Process.Start(psi)
                    p.WaitForExit()
                End Using
            End If
        Catch ex As Exception
            ' Ignore registry / task scheduler write permission errors
        End Try
    End Sub

    ''' <summary>
    ''' Checks whether Windows autostart is enabled via Registry key or Scheduled Task.
    ''' </summary>
    Private Function IsBootAutostartEnabled() As Boolean
        Try
            Using runKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", False)
                If runKey IsNot Nothing AndAlso runKey.GetValue("Typhon") IsNot Nothing Then
                    Return True
                End If
            End Using

            Dim psi As New ProcessStartInfo()
            psi.FileName = "schtasks.exe"
            psi.Arguments = "/Query /TN ""TyphonAutoStart"""
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            psi.RedirectStandardOutput = True
            Using p As Process = Process.Start(psi)
                p.WaitForExit()
                If p.ExitCode = 0 Then Return True
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Toggle switch event handler saving Auto-Start on Boot user setting and updating Windows startup registry and scheduled task.
    ''' </summary>
    Private Sub toggleAutoStartOnBoot_CheckedChanged(sender As System.Object) Handles toggleAutoStartOnBoot.CheckedChanged
        My.Settings.AutoStartOnBoot = toggleAutoStartOnBoot.Checked
        SetBootAutostart(toggleAutoStartOnBoot.Checked)
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' Toggle switch event handler saving Minimize to System Tray user setting.
    ''' </summary>
    Private Sub toggleMinimizeToTray_CheckedChanged(sender As System.Object) Handles toggleMinimizeToTray.CheckedChanged
        My.Settings.MinimizeToTray = toggleMinimizeToTray.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    Private Sub toggleCloseToTray_CheckedChanged(sender As System.Object) Handles toggleCloseToTray.CheckedChanged
        My.Settings.CloseToTray = toggleCloseToTray.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    Private Sub toggleStartMinimizedOnBoot_CheckedChanged(sender As System.Object) Handles toggleStartMinimizedOnBoot.CheckedChanged
        My.Settings.StartMinimizedOnBoot = toggleStartMinimizedOnBoot.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' Intercepts user form closing to minimize application to tray if CloseToTray is enabled.
    ''' </summary>
    Private Sub WinMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing AndAlso My.Settings.CloseToTray Then
            e.Cancel = True
            Me.Hide()
            notifTrayIcon.Visible = True
            ShowNotification("Tray:", "Typhon minimized to system tray")
        End If
    End Sub

    ''' <summary>
    ''' Hides application to system tray when minimized if MinimizeToTray setting is enabled.
    ''' </summary>
    Private Sub WinMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If My.Settings.MinimizeToTray AndAlso Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            notifTrayIcon.Visible = True
        End If
    End Sub

    Private Sub notifTrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles notifTrayIcon.MouseDoubleClick
        RestoreFromTray()
    End Sub

    Private Sub menuOpenTyphon_Click(sender As Object, e As EventArgs) Handles menuOpenTyphon.Click
        RestoreFromTray()
    End Sub

    Private Sub menuExitTyphon_Click(sender As Object, e As EventArgs) Handles menuExitTyphon.Click
        notifTrayIcon.Visible = False
        Application.Exit()
    End Sub

    Private Sub RestoreFromTray()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        notifTrayIcon.Visible = False
    End Sub

    ''' <summary>
    ''' Re-queries system specifications and hardware peripherals and updates lvSystemSpecs asynchronously.
    ''' </summary>
    Public Sub RefreshSpecsList(Optional force As Boolean = False)
        If _isSpecsLoading Then Return
        _isSpecsLoading = True

        lvSystemSpecs.Columns = New NSListView.NSListViewColumnHeader() {
            New NSListView.NSListViewColumnHeader() With {.Text = "Component", .Width = 110},
            New NSListView.NSListViewColumnHeader() With {.Text = "Details", .Width = 500}
        }

        If force Then _func.ClearSpecsCache()

        Task.Run(Sub()
                     Dim specList As List(Of func.SpecItem) = _func.GetStructuredSpecs()
                     Dim specItems As New List(Of NSListView.NSListViewItem)()

                     For Each s As func.SpecItem In specList
                         Dim item As New NSListView.NSListViewItem() With {.Text = s.Category, .Tag = s}
                         item.SubItems.Add(New NSListView.NSListViewSubItem() With {.Text = s.Value})
                         specItems.Add(item)
                     Next

                     If Not Me.IsDisposed AndAlso Me.IsHandleCreated Then
                         Me.BeginInvoke(Sub()
                                            If Not Me.IsDisposed Then
                                                lvSystemSpecs.Items = specItems.ToArray()
                                                _isSpecsLoading = False
                                            End If
                                        End Sub)
                     Else
                         _isSpecsLoading = False
                     End If
                 End Sub)
    End Sub

    Private Sub OnDeviceChangeDebounced()
        If _deviceChangeTimer Is Nothing Then
            _deviceChangeTimer = New System.Windows.Forms.Timer()
            _deviceChangeTimer.Interval = 500
            AddHandler _deviceChangeTimer.Tick, Sub(s, e)
                                                    _deviceChangeTimer.Stop()
                                                    RefreshSpecsList(True)
                                                End Sub
        End If
        _deviceChangeTimer.Stop()
        _deviceChangeTimer.Start()
    End Sub

    ''' <summary>
    ''' Handles hardware device plug/unplug events to auto-refresh peripherals and drive lists in real time.
    ''' </summary>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_DEVICECHANGE As Integer = &H219
        If m.Msg = WM_DEVICECHANGE Then
            OnDeviceChangeDebounced()
        End If
        MyBase.WndProc(m)
    End Sub

    ''' <summary>
    ''' Mouse down event handler opening selected storage drive in Windows Explorer.
    ''' </summary>
    Private Sub lvSystemSpecs_MouseDown(sender As Object, e As MouseEventArgs) Handles lvSystemSpecs.MouseDown
        If lvSystemSpecs.SelectedItems IsNot Nothing AndAlso lvSystemSpecs.SelectedItems.Length > 0 Then
            Dim selectedItem As NSListView.NSListViewItem = lvSystemSpecs.SelectedItems(0)
            If TypeOf selectedItem.Tag Is func.SpecItem Then
                Dim spec As func.SpecItem = DirectCast(selectedItem.Tag, func.SpecItem)
                If Not String.IsNullOrEmpty(spec.DrivePath) Then
                    Try
                        Process.Start("explorer.exe", spec.DrivePath)
                        ShowNotification("Explorer:", "Opened drive " & spec.DrivePath)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Copy system hardware specifications to clipboard.
    ''' </summary>
    Private Sub btnCopySpecs_Click(sender As System.Object, e As System.EventArgs) Handles btnCopySpecs.Click
        Try
            Clipboard.SetText(_func.GetFormattedSpecsText())
            ShowNotification("Specs:", "Copied hardware specs to clipboard")
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Opens PC Game Benchmark website in default browser populated with user PC specs.
    ''' </summary>
    Private Sub btnCheckGameBenchmark_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckGameBenchmark.Click
        Try
            Dim url As String = _func.GetGameBenchmarkUrl()
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            ShowNotification("Benchmark:", "Opening PC Game Benchmark in browser")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnControlClose_Click(sender As Object, e As EventArgs) Handles btnControlClose.Click
        If My.Settings.CloseToTray Then
            Me.Hide()
            notifTrayIcon.Visible = True
            ShowNotification("Tray:", "Typhon minimized to system tray")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnControlMinimize_Click(sender As Object, e As EventArgs) Handles btnControlMinimize.Click
        If My.Settings.MinimizeToTray Then
            Me.Hide()
            notifTrayIcon.Visible = True
        Else
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub
End Class