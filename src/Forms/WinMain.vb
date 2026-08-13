Imports System.Collections.Specialized
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
        NsLabel3.Value1 = title
        NsLabel3.Value2 = Space(1) & message
        cooldownTimer.Start()

        If My.Settings.ShowTrayNotifications AndAlso notifIcon.Visible Then
            notifIcon.ShowBalloonTip(3000, "Typhon PC Booster", title & Space(1) & message, ToolTipIcon.Info)
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
        Dim gpuName As String = _func.GetGPUName()
        Dim ramSize As String = _func.GetTotalRAM()

        ' Uppercase computer name in brackets
        NsGroupBox1.Title = "[" & Environment.MachineName.ToUpper() & "]"

        ' Subtitle: OS, CPU, GPU (if any), RAM without indicators
        Dim subTitleParts As New List(Of String)()
        If Not String.IsNullOrEmpty(osName) Then subTitleParts.Add(osName)
        If Not String.IsNullOrEmpty(infoProcessor) Then subTitleParts.Add(infoProcessor)
        If Not String.IsNullOrEmpty(gpuName) Then subTitleParts.Add(gpuName)
        If Not String.IsNullOrEmpty(ramSize) Then subTitleParts.Add(ramSize)

        NsGroupBox1.SubTitle = String.Join(vbNewLine, subTitleParts.ToArray())
        RichTextBox1.Text = _func.GetSpecs

        realTimer.Enabled = True

        My.Settings.Reload()

        If My.Settings.IgnoreProcessList IsNot Nothing Then
            ProcessIgnoreList = My.Settings.IgnoreProcessList
        End If

        NsOnOffBox1.Checked = My.Settings.AutoFreeRAM

        Dim isAutostartRegistryEnabled As Boolean = IsBootAutostartEnabled()
        If My.Settings.AutoStartOnBoot <> isAutostartRegistryEnabled Then
            My.Settings.AutoStartOnBoot = isAutostartRegistryEnabled
            My.Settings.Save()
        End If
        NsOnOffBox2.Checked = My.Settings.AutoStartOnBoot
        NsOnOffBox3.Checked = My.Settings.MinimizeToTray
        NsOnOffBox4.Checked = My.Settings.CloseToTray
        NsOnOffBox5.Checked = My.Settings.ShowTrayNotifications
        NsOnOffBox6.Checked = My.Settings.StartMinimizedOnBoot

        If Me.Icon IsNot Nothing Then
            notifIcon.Icon = Me.Icon
        End If

        If Environment.GetCommandLineArgs().Contains("/minimized", StringComparer.OrdinalIgnoreCase) OrElse (My.Settings.StartMinimizedOnBoot AndAlso isAutostartRegistryEnabled) Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            notifIcon.Visible = True
        End If

        init = False
    End Sub

    ''' <summary>
    ''' Form load event handler.
    ''' </summary>
    Private Sub WinMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadStuff()
    End Sub

    ''' <summary>
    ''' Timer tick event handler updating active process counts and RAM usage indicators in real-time.
    ''' Triggers automatic memory optimization if AutoFreeRAM is enabled.
    ''' </summary>
    Private Sub realTimer_Tick(sender As System.Object, e As System.EventArgs) Handles realTimer.Tick
        NsLabel1.Value2 = Space(1) & _proc.GetTotalProcesses
        NsLabel2.Value2 = Space(1) & _proc.GetRAMUsage
        NsProgressBar1.Value = _proc.GetRAMPercentage

        If My.Settings.AutoFreeRAM Then
            autoFreeCounter += 1
            Dim intervalSec As Integer = Math.Max(1, My.Settings.AutoFreeRAMInterval) * 60
            If autoFreeCounter >= intervalSec Then
                autoFreeCounter = 0
                Dim currentRAMPct As Integer = _proc.GetRAMPercentage()
                If currentRAMPct >= My.Settings.AutoFreeRAMThreshold Then
                    Dim res As proc.FreeMemoryResult = _proc.FreeProcesses()
                    If res.ReleasedBytes > 0 Then
                        ShowNotification("AutoRAM:", "Freed " & cleaner.FormatBytes(res.ReleasedBytes) & " (" & currentRAMPct & "% RAM)")
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Click event handler triggering memory working set release for all processes.
    ''' </summary>
    Private Sub NsButton1_Click(sender As System.Object, e As System.EventArgs) Handles NsButton1.Click
        Dim res As proc.FreeMemoryResult = _proc.FreeProcesses()
        If res.ReleasedBytes > 0 Then
            ShowNotification("~X:", "Freed " & cleaner.FormatBytes(res.ReleasedBytes) & " from " & res.ProcessCount & " processes")
        Else
            ShowNotification("~X:", "Memory released from " & res.ProcessCount & " processes")
        End If
    End Sub

    ''' <summary>
    ''' Timer tick event handler clearing status notification text after cooldown.
    ''' </summary>
    Private Sub cooldownTimer_Tick(sender As System.Object, e As System.EventArgs) Handles cooldownTimer.Tick
        NsLabel3.Value1 = ""
        NsLabel3.Value2 = ""
        cooldownTimer.Stop()
    End Sub

    ''' <summary>
    ''' Click event handler opening the WinKill process manager window.
    ''' </summary>
    Private Sub NsButton2_Click(sender As System.Object, e As System.EventArgs) Handles NsButton2.Click
        WinKill.Show()
        ShowNotification("~X:", "Scanned for killable processes")
    End Sub

    ''' <summary>
    ''' Click event handler opening the WinExceptions window.
    ''' </summary>
    Private Sub NsButton3_Click(sender As System.Object, e As System.EventArgs) Handles NsButton3.Click
        Dim frm As New WinExceptions()
        frm.ShowDialog()
    End Sub

    Private peakRAMPct As Integer = 0

    ''' <summary>
    ''' Timer tick event handler updating the RAM, CPU, and GPU usage chart visualization with smooth 60-point rolling window.
    ''' </summary>
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles graphTimer.Tick
        Dim ramPct As Integer = CInt(Val(_proc.GetRAMPercentage()))
        Dim cpuPct As Integer = _proc.GetCPUPercentage()
        Dim gpuPct As Integer = _proc.GetGPUPercentage()

        If ramPct > peakRAMPct Then peakRAMPct = ramPct

        Dim s1 As System.Windows.Forms.DataVisualization.Charting.Series = Chart1.Series("Series1")
        Dim s2 As System.Windows.Forms.DataVisualization.Charting.Series = Chart1.Series("Series2")
        Dim s3 As System.Windows.Forms.DataVisualization.Charting.Series = Chart1.Series("Series3")

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

        NsLabel7.Value1 = "RAM:"
        NsLabel7.Value2 = Space(1) & ramPct & "% | CPU: " & cpuPct & "% | GPU: " & gpuPct & "% | Peak RAM: " & peakRAMPct & "%"
    End Sub

    Private Sub NsTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NsTabControl1.SelectedIndexChanged
        If NsTabControl1.SelectedTab Is TabPage3 Then
            NsTabControl1.SelectedTab = TabPage1
            Using dlg As New WinCleaner()
                dlg.ShowDialog(Me)
            End Using
        End If
    End Sub

    ''' <summary>
    ''' Toggle switch event handler saving Auto-Free RAM user setting.
    ''' </summary>
    Private Sub NsOnOffBox1_CheckedChanged(sender As System.Object) Handles NsOnOffBox1.CheckedChanged
        My.Settings.AutoFreeRAM = NsOnOffBox1.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' Configures or removes Windows CurrentUser Run registry key for application boot autostart.
    ''' </summary>
    ''' <param name="enable">True to add autostart key; False to remove it.</param>
    Private Sub SetBootAutostart(enable As Boolean)
        Try
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
        Catch ex As Exception
            ' Ignore registry write permissions error
        End Try
    End Sub

    ''' <summary>
    ''' Checks whether the Windows CurrentUser Run registry key exists for Typhon autostart.
    ''' </summary>
    Private Function IsBootAutostartEnabled() As Boolean
        Try
            Using runKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", False)
                If runKey IsNot Nothing Then
                    Return (runKey.GetValue("Typhon") IsNot Nothing)
                End If
            End Using
        Catch ex As Exception
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Toggle switch event handler saving Auto-Start on Boot user setting and updating Windows startup registry.
    ''' </summary>
    Private Sub NsOnOffBox2_CheckedChanged(sender As System.Object) Handles NsOnOffBox2.CheckedChanged
        My.Settings.AutoStartOnBoot = NsOnOffBox2.Checked
        SetBootAutostart(NsOnOffBox2.Checked)
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' Toggle switch event handler saving Minimize to System Tray user setting.
    ''' </summary>
    Private Sub NsOnOffBox3_CheckedChanged(sender As System.Object) Handles NsOnOffBox3.CheckedChanged
        My.Settings.MinimizeToTray = NsOnOffBox3.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    Private Sub NsOnOffBox4_CheckedChanged(sender As System.Object) Handles NsOnOffBox4.CheckedChanged
        My.Settings.CloseToTray = NsOnOffBox4.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    Private Sub NsOnOffBox5_CheckedChanged(sender As System.Object) Handles NsOnOffBox5.CheckedChanged
        My.Settings.ShowTrayNotifications = NsOnOffBox5.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub

    Private Sub NsOnOffBox6_CheckedChanged(sender As System.Object) Handles NsOnOffBox6.CheckedChanged
        My.Settings.StartMinimizedOnBoot = NsOnOffBox6.Checked
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
            notifIcon.Visible = True
            ShowNotification("Tray:", "Typhon minimized to system tray")
        End If
    End Sub

    ''' <summary>
    ''' Hides application to system tray when minimized if MinimizeToTray setting is enabled.
    ''' </summary>
    Private Sub WinMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If My.Settings.MinimizeToTray AndAlso Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            notifIcon.Visible = True
        End If
    End Sub

    Private Sub notifIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles notifIcon.MouseDoubleClick
        RestoreFromTray()
    End Sub

    Private Sub OpenTyphonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTyphonToolStripMenuItem.Click
        RestoreFromTray()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        notifIcon.Visible = False
        Application.Exit()
    End Sub

    Private Sub RestoreFromTray()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        notifIcon.Visible = False
    End Sub
End Class