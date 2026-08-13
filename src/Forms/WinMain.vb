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
    End Sub

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

        If NsListView1.Columns.Length = 0 Then
            NsListView1.AddColumn("Filename", 120)
            NsListView1.AddColumn("Size", 60)
            NsListView1.AddColumn("Type", 100)
            NsListView1.AddColumn("Path", 300)
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
            If autoFreeCounter >= 60 Then
                _proc.FreeProcesses()
                autoFreeCounter = 0
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
    ''' Timer tick event handler updating the multi-series memory, CPU, and GPU usage chart visualization with smooth 60-point rolling window.
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

    Private ScannedCleanItems As New List(Of cleaner.CleanItem)()
    Private IsScanning As Boolean = False
    Private CancelScanRequested As Boolean = False

    ''' <summary>
    ''' Opens Options window allowing user to toggle and save 13 target clean categories in clean_state.config.
    ''' </summary>
    Private Sub NsButton6_Click(sender As Object, e As EventArgs) Handles NsButton6.Click
        Using dlg As New WinOptions()
            dlg.ShowDialog(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Click event handler toggling Scan / Cancel. Opens Disk Selector window to choose drives,
    ''' then scans configured categories from clean_state.config across selected drives.
    ''' </summary>
    Private Sub NsButton4_Click(sender As System.Object, e As System.EventArgs) Handles NsButton4.Click
        If IsScanning Then
            CancelScanRequested = True
            NsButton4.Text = "Scan"
            ShowNotification("~X:", "Cancelling scan...")
            Return
        End If

        Dim targetDrives As List(Of String) = Nothing
        Using selector As New WinDiskSelector()
            If selector.ShowDialog(Me) <> DialogResult.OK Then
                Return
            End If
            targetDrives = selector.SelectedDrives
        End Using

        If targetDrives Is Nothing OrElse targetDrives.Count = 0 Then Return

        Dim enabledCategories As Dictionary(Of String, Boolean) = cleaner.LoadConfig()

        IsScanning = True
        CancelScanRequested = False

        NsButton4.Text = "Cancel"
        NsButton4.Enabled = True

        NsButton5.Visible = False
        CleanerProgressBar.Value = 0
        CleanerProgressBar.Visible = True

        Label1.Visible = False
        NsLabel8.Visible = True
        NsLabel8.Value1 = "Scanning:"
        NsLabel8.Value2 = " Starting..."
        NsListView1.Visible = True
        NsListView1.Clear()

        Application.DoEvents()

        Dim accumulatedBytes As Long = 0
        Dim scannedFilesCount As Integer = 0
        Dim realtimeBatch As New List(Of NSListView.NSListViewItem)()

        ScannedCleanItems = cleaner.ScanDetailedFiles(targetDrives, enabledCategories,
                                                       Sub(current, total, status)
                                                           Dim pct As Integer = CInt((current / CDbl(total)) * 100)
                                                           CleanerProgressBar.Value = Math.Min(100, Math.Max(0, pct))
                                                           NsLabel8.Value1 = "Scanning:"
                                                           NsLabel8.Value2 = " " & status
                                                           ShowNotification("~X:", "Scanned " & scannedFilesCount & " files (" & cleaner.FormatBytes(accumulatedBytes) & ")")
                                                           Application.DoEvents()
                                                       End Sub,
                                                       Sub(item)
                                                           accumulatedBytes += item.ByteSize
                                                           scannedFilesCount += 1

                                                           Dim subItemsList As New List(Of NSListView.NSListViewSubItem)()
                                                           subItemsList.Add(New NSListView.NSListViewSubItem With {.Text = item.FormattedSize})
                                                           subItemsList.Add(New NSListView.NSListViewSubItem With {.Text = item.CategoryName})
                                                           subItemsList.Add(New NSListView.NSListViewSubItem With {.Text = item.FilePath})

                                                           Dim nsItem As New NSListView.NSListViewItem With {
                                                               .Text = item.FileName,
                                                               .SubItems = subItemsList
                                                           }

                                                           realtimeBatch.Add(nsItem)

                                                           If realtimeBatch.Count >= 25 Then
                                                               NsListView1.AddItems(realtimeBatch)
                                                               realtimeBatch.Clear()
                                                               ShowNotification("~X:", "Scanned " & scannedFilesCount & " files (" & cleaner.FormatBytes(accumulatedBytes) & ")")
                                                               Application.DoEvents()
                                                           End If
                                                       End Sub,
                                                       Function() CancelScanRequested)

        If realtimeBatch.Count > 0 Then
            NsListView1.AddItems(realtimeBatch)
            realtimeBatch.Clear()
        End If

        IsScanning = False
        NsButton4.Text = "Scan"
        CleanerProgressBar.Visible = False

        Dim finalFormattedSize As String = cleaner.FormatBytes(accumulatedBytes)
        If CancelScanRequested Then
            NsLabel8.Value1 = "Status:"
            NsLabel8.Value2 = " Scan cancelled"
            ShowNotification("~X:", "Scan cancelled: Found " & ScannedCleanItems.Count & " files (" & finalFormattedSize & ")")
            NsButton5.Visible = False
        Else
            CleanerProgressBar.Value = 100
            NsLabel8.Value1 = "Status:"
            NsLabel8.Value2 = " Scan complete"
            NsButton5.Visible = (NsListView1.Items.Length > 0)
            NsButton5.Enabled = (NsListView1.Items.Length > 0)
            ShowNotification("~X:", "Scan complete: Found " & ScannedCleanItems.Count & " files (" & finalFormattedSize & ")")
        End If
    End Sub

    ''' <summary>
    ''' Click event handler removing all scanned detailed items across 9 categories and emptying Windows Recycle Bin.
    ''' Updates progress bar and clears NSListView upon completion.
    ''' </summary>
    Private Sub NsButton5_Click(sender As System.Object, e As System.EventArgs) Handles NsButton5.Click
        If ScannedCleanItems.Count = 0 Then Return

        NsButton4.Enabled = False
        NsButton5.Enabled = False
        CleanerProgressBar.Value = 0
        CleanerProgressBar.Visible = True

        Application.DoEvents()

        Dim cleanedCount As Integer = cleaner.CleanDetailedFiles(ScannedCleanItems, Sub(current, total, status)
                                                                                          Dim pct As Integer = CInt((current / CDbl(total)) * 100)
                                                                                          CleanerProgressBar.Value = Math.Min(100, Math.Max(0, pct))
                                                                                          ShowNotification("~X:", status)
                                                                                          Application.DoEvents()
                                                                                      End Sub)

        NsListView1.Clear()
        ScannedCleanItems.Clear()

        CleanerProgressBar.Value = 100
        CleanerProgressBar.Visible = False

        ShowNotification("~X:", "Cleaned " & cleanedCount & " items & emptied Recycle Bin")

        NsButton4.Enabled = True
        NsButton5.Visible = False
        NsButton5.Enabled = False
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
                        runKey.SetValue("Typhon", Application.ExecutablePath)
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
    ''' Toggle switch event handler saving Auto-Start on Boot user setting and updating Windows startup registry.
    ''' </summary>
    Private Sub NsOnOffBox2_CheckedChanged(sender As System.Object) Handles NsOnOffBox2.CheckedChanged
        My.Settings.AutoStartOnBoot = NsOnOffBox2.Checked
        SetBootAutostart(NsOnOffBox2.Checked)
        If init = False Then
            My.Settings.Save()
        End If
    End Sub
End Class