Imports System.Collections.Specialized

''' <summary>
''' Main application window handling system monitoring, RAM optimization, junk file cleaning, and settings.
''' </summary>
Public Class WinMain

    Private _proc As proc = New proc()
    Private _func As func = New func()

    Dim cycles As Integer = 300
    Dim init As Boolean = True

    ''' <summary>
    ''' Collection of process executable names excluded from process termination operations.
    ''' </summary>
    Public ProcessIgnoreList As New StringCollection()

    ''' <summary>
    ''' Initializes application controls, queries system hardware specs, and loads user settings.
    ''' </summary>
    Sub LoadStuff()
        Dim infoProcessor As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor\0", "ProcessorNameString", Nothing)

        NsGroupBox1.Title = "[" & _func.GetPCName & "]"
        NsGroupBox1.SubTitle = _func.GetOS & vbNewLine & infoProcessor
        RichTextBox1.Text = _func.GetSpecs

        realTimer.Enabled = True

        My.Settings.Reload()

        If My.Settings.IgnoreProcessList IsNot Nothing Then
            ProcessIgnoreList = My.Settings.IgnoreProcessList
        End If

        NsOnOffBox1.Checked = My.Settings.AutoFreeRAM
        NsOnOffBox2.Checked = My.Settings.AutoStartOnBoot

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
    ''' </summary>
    Private Sub realTimer_Tick(sender As System.Object, e As System.EventArgs) Handles realTimer.Tick
        NsLabel1.Value2 = Space(1) & _proc.GetTotalProcesses
        NsLabel2.Value2 = Space(1) & _proc.GetRAMUsage
        NsLabel7.Value2 = Space(1) & _proc.GetRAMUsage
        NsProgressBar1.Value = _proc.GetRAMPercentage
    End Sub

    ''' <summary>
    ''' Click event handler triggering memory working set release for all processes.
    ''' </summary>
    Private Sub NsButton1_Click(sender As System.Object, e As System.EventArgs) Handles NsButton1.Click
        NsLabel3.Value1 = "~X:"
        NsLabel3.Value2 = Space(1) & "Memory released from " & _proc.FreeProcesses & " processes"
        cooldownTimer.Start()
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

        NsLabel3.Value1 = "~X:"
        NsLabel3.Value2 = Space(1) & "Scanned for killable processes"
        cooldownTimer.Start()
    End Sub

    ''' <summary>
    ''' Timer tick event handler updating the memory usage chart visualization.
    ''' </summary>
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles graphTimer.Tick
        If cycles = 300 Then
            Chart1.Series("Series1").Points.Clear()
            cycles = 0
        End If
        Chart1.Series("Series1").Points.Add(_proc.GetRAMPercentage)
        cycles += 1
    End Sub

    ''' <summary>
    ''' Helper function safely scanning files in a directory matching search pattern and populating listbox.
    ''' </summary>
    ''' <param name="dirPath">Target directory path.</param>
    ''' <param name="searchPattern">File search pattern (e.g. *.tmp).</param>
    Private Sub ScanDirFiles(dirPath As String, searchPattern As String)
        Try
            If IO.Directory.Exists(dirPath) Then
                For Each filePath As String In IO.Directory.GetFiles(dirPath, searchPattern)
                    ListBox1.Items.Add(filePath)
                Next
            End If
        Catch ex As Exception
            ' Ignore access denied or locked directory errors for individual scan paths
        End Try
    End Sub

    ''' <summary>
    ''' Click event handler scanning system locations for temporary and log files.
    ''' </summary>
    Private Sub NsButton4_Click(sender As System.Object, e As System.EventArgs) Handles NsButton4.Click
        Label1.Visible = False
        ListBox1.Visible = True
        ListBox1.Items.Clear()

        ScanDirFiles("C:\Windows", "*.log")
        ScanDirFiles(IO.Path.GetTempPath(), "*.tmp")
        ScanDirFiles("C:\Windows\Prefetch", "*.pf")
        ScanDirFiles("C:\Windows\Prefetch", "*.log")
        ScanDirFiles("C:\Windows\Installer\$PatchCache$\Managed", "*.*")
        ScanDirFiles("C:\$Recycle.Bin", "*.*")

        NsButton5.Enabled = (ListBox1.Items.Count > 0)
    End Sub

    ''' <summary>
    ''' Click event handler deleting scanned temporary and log files.
    ''' </summary>
    Private Sub NsButton5_Click(sender As System.Object, e As System.EventArgs) Handles NsButton5.Click
        For Each item As String In ListBox1.Items
            Try
                If IO.File.Exists(item) Then
                    IO.File.Delete(item)
                End If
            Catch ex As Exception
                ' Ignore locked or protected files
            End Try
        Next
        NsButton4_Click(sender, e)
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
    ''' Toggle switch event handler saving Auto-Start on Boot user setting.
    ''' </summary>
    Private Sub NsOnOffBox2_CheckedChanged(sender As System.Object) Handles NsOnOffBox2.CheckedChanged
        My.Settings.AutoStartOnBoot = NsOnOffBox2.Checked
        If init = False Then
            My.Settings.Save()
        End If
    End Sub
End Class