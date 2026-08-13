Imports System.IO
Imports Typhon.NSListView

''' <summary>
''' Dedicated System Cleaner window providing split UI with scan results list view, 
''' real-time category options selection, drive selection, and junk file cleaning.
''' </summary>
Public Class WinCleaner

    Private ScannedCleanItems As New List(Of cleaner.CleanItem)()
    Private IsScanning As Boolean = False
    Private CancelScanRequested As Boolean = False
    Private TargetDrives As List(Of String) = Nothing

    Private Sub WinCleaner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Owner IsNot Nothing AndAlso Owner.Icon IsNot Nothing Then
                Me.Icon = Owner.Icon
            End If
        Catch ex As Exception
        End Try

        If NsListView1.Columns.Length = 0 Then
            NsListView1.AddColumn("Filename", 130)
            NsListView1.AddColumn("Size", 75)
            NsListView1.AddColumn("Category", 100)
            NsListView1.AddColumn("Path", 250)
        End If

        If TargetDrives Is Nothing OrElse TargetDrives.Count = 0 Then
            TargetDrives = GetSystemDrives()
        End If

        LoadCleanerOptions()

        AddHandler chkTemp.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkRecycle.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkIncompat.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkThumb.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkGames.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkFolderCfg.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkCookies.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkCache.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkHistory.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkLogs.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkDumps.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkRecent.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkAppCache.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkWinUpdate.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkDriverCache.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
        AddHandler chkPkgCache.CheckedChanged, AddressOf OptionCheckbox_CheckedChanged
    End Sub

    Private Function GetSystemDrives() As List(Of String)
        Dim drives As New List(Of String)()
        Try
            For Each drv As DriveInfo In DriveInfo.GetDrives()
                If drv.IsReady Then
                    drives.Add(drv.Name)
                End If
            Next
        Catch ex As Exception
        End Try
        If drives.Count = 0 Then drives.Add("C:\")
        Return drives
    End Function

    Private IsLoadingOptions As Boolean = False

    Private Sub LoadCleanerOptions()
        IsLoadingOptions = True
        Try
            Dim config As Dictionary(Of String, Boolean) = cleaner.LoadConfig()

            If config.ContainsKey("Temporary Files") Then chkTemp.Checked = config("Temporary Files")
            If config.ContainsKey("Recycle Bin") Then chkRecycle.Checked = config("Recycle Bin")
            If config.ContainsKey("Incompatible Files") Then chkIncompat.Checked = config("Incompatible Files")
            If config.ContainsKey("Thumbnail Caches") Then chkThumb.Checked = config("Thumbnail Caches")
            If config.ContainsKey("Game Caches") Then chkGames.Checked = config("Game Caches")
            If config.ContainsKey("Folder Config Files") Then chkFolderCfg.Checked = config("Folder Config Files")
            If config.ContainsKey("Internet Cookies") Then chkCookies.Checked = config("Internet Cookies")
            If config.ContainsKey("Internet Cache") Then chkCache.Checked = config("Internet Cache")
            If config.ContainsKey("Internet History") Then chkHistory.Checked = config("Internet History")
            If config.ContainsKey("Windows Logs") Then chkLogs.Checked = config("Windows Logs")
            If config.ContainsKey("Memory Dumps") Then chkDumps.Checked = config("Memory Dumps")
            If config.ContainsKey("Recent Files") Then chkRecent.Checked = config("Recent Files")
            If config.ContainsKey("Application Caches") Then chkAppCache.Checked = config("Application Caches")
            If config.ContainsKey("Windows Update Cache") Then chkWinUpdate.Checked = config("Windows Update Cache")
            If config.ContainsKey("GPU Driver Cache") Then chkDriverCache.Checked = config("GPU Driver Cache")
            If config.ContainsKey("Dev Package Caches") Then chkPkgCache.Checked = config("Dev Package Caches")
        Finally
            IsLoadingOptions = False
        End Try
    End Sub

    Private Sub SaveCleanerOptions()
        Dim config As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)
        config("Temporary Files") = chkTemp.Checked
        config("Recycle Bin") = chkRecycle.Checked
        config("Incompatible Files") = chkIncompat.Checked
        config("Thumbnail Caches") = chkThumb.Checked
        config("Game Caches") = chkGames.Checked
        config("Folder Config Files") = chkFolderCfg.Checked
        config("Internet Cookies") = chkCookies.Checked
        config("Internet Cache") = chkCache.Checked
        config("Internet History") = chkHistory.Checked
        config("Windows Logs") = chkLogs.Checked
        config("Memory Dumps") = chkDumps.Checked
        config("Recent Files") = chkRecent.Checked
        config("Application Caches") = chkAppCache.Checked
        config("Windows Update Cache") = chkWinUpdate.Checked
        config("GPU Driver Cache") = chkDriverCache.Checked
        config("Dev Package Caches") = chkPkgCache.Checked

        cleaner.SaveConfig(config)
    End Sub

    Private Sub OptionCheckbox_CheckedChanged(sender As Object)
        If Not IsLoadingOptions Then
            SaveCleanerOptions()
        End If
    End Sub

    Private Sub btnSelectDrives_Click(sender As Object, e As EventArgs)
        Using dlg As New WinDiskSelector()
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                TargetDrives = dlg.SelectedDrives
                Dim drivesStr As String = String.Join(", ", TargetDrives.Select(Function(d) d.TrimEnd("\"c)).ToArray())
                NsLabelStatus.Value1 = "Drives:"
                NsLabelStatus.Value2 = " Selected (" & drivesStr & ")"
            End If
        End Using
    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        If IsScanning Then
            CancelScanRequested = True
            btnScan.Enabled = False
            NsLabelStatus.Value1 = "Status:"
            NsLabelStatus.Value2 = " Cancelling scan..."
            Return
        End If

        ' Instantly reset UI state before prompting disk selector
        NsListView1.Clear()
        CleanerProgressBar.Value = 0
        CleanerProgressBar.Visible = False
        NsLabelStatus.Value1 = "Status:"
        NsLabelStatus.Value2 = " Select target drives to scan..."
        btnClean.Enabled = False
        ScannedCleanItems.Clear()
        Application.DoEvents()

        Using selector As New WinDiskSelector()
            If selector.ShowDialog(Me) <> DialogResult.OK Then
                NsLabelStatus.Value1 = "Status:"
                NsLabelStatus.Value2 = " Ready to scan system"
                Return
            End If
            TargetDrives = selector.SelectedDrives
        End Using

        If TargetDrives Is Nothing OrElse TargetDrives.Count = 0 Then
            NsLabelStatus.Value1 = "Status:"
            NsLabelStatus.Value2 = " Ready to scan system"
            Return
        End If

        SaveCleanerOptions()

        IsScanning = True
        CancelScanRequested = False
        btnScan.Text = "Cancel"

        CleanerProgressBar.Value = 0
        CleanerProgressBar.Visible = True

        NsLabelStatus.Value1 = "Scanning:"
        NsLabelStatus.Value2 = " Starting scan..."
        Application.DoEvents()

        Dim enabledCategories As Dictionary(Of String, Boolean) = cleaner.LoadConfig()
        Dim accumulatedBytes As Long = 0
        Dim scannedFilesCount As Integer = 0
        Dim realtimeBatch As New List(Of NSListViewItem)()

        ScannedCleanItems = cleaner.ScanDetailedFiles(TargetDrives, enabledCategories,
                                                       Sub(current, total, status)
                                                           Dim pct As Integer = CInt((current / CDbl(total)) * 100)
                                                           CleanerProgressBar.Value = Math.Min(100, Math.Max(0, pct))
                                                           NsLabelStatus.Value1 = "Scanning:"
                                                           NsLabelStatus.Value2 = " " & status
                                                           Application.DoEvents()
                                                       End Sub,
                                                       Sub(item)
                                                           accumulatedBytes += item.ByteSize
                                                           scannedFilesCount += 1

                                                           Dim subItemsList As New List(Of NSListViewSubItem)()
                                                           subItemsList.Add(New NSListViewSubItem With {.Text = item.FormattedSize})
                                                           subItemsList.Add(New NSListViewSubItem With {.Text = item.CategoryName})
                                                           subItemsList.Add(New NSListViewSubItem With {.Text = item.FilePath})

                                                           Dim nsItem As New NSListViewItem With {
                                                               .Text = item.FileName,
                                                               .SubItems = subItemsList,
                                                               .Tag = item.ByteSize
                                                           }

                                                           realtimeBatch.Add(nsItem)

                                                           If realtimeBatch.Count >= 25 Then
                                                               NsListView1.AddItems(realtimeBatch)
                                                               realtimeBatch.Clear()
                                                               Application.DoEvents()
                                                           End If
                                                       End Sub,
                                                       Function() CancelScanRequested)

        If realtimeBatch.Count > 0 Then
            NsListView1.AddItems(realtimeBatch)
            realtimeBatch.Clear()
        End If

        IsScanning = False
        btnScan.Text = "Scan"
        btnScan.Enabled = True
        CleanerProgressBar.Visible = False

        Dim finalFormattedSize As String = cleaner.FormatBytes(accumulatedBytes)
        If CancelScanRequested Then
            NsLabelStatus.Value1 = "Status:"
            NsLabelStatus.Value2 = " Scan cancelled (" & ScannedCleanItems.Count & " files, " & finalFormattedSize & ")"
            btnClean.Enabled = False
        Else
            CleanerProgressBar.Value = 100
            NsLabelStatus.Value1 = "Scan Complete:"
            NsLabelStatus.Value2 = " Found " & ScannedCleanItems.Count & " files (" & finalFormattedSize & ")"
            btnClean.Enabled = (NsListView1.Items.Length > 0)
        End If
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        If ScannedCleanItems.Count = 0 Then Return

        btnScan.Enabled = False
        btnClean.Enabled = False
        CleanerProgressBar.Value = 0
        CleanerProgressBar.Visible = True

        Application.DoEvents()

        ' Build lookup mapping file paths to NSListViewItem objects for live removal
        Dim itemMap As New Dictionary(Of String, NSListViewItem)(StringComparer.OrdinalIgnoreCase)
        If NsListView1.Items IsNot Nothing Then
            For Each nsItem As NSListViewItem In NsListView1.Items
                If nsItem.SubItems IsNot Nothing AndAlso nsItem.SubItems.Count >= 3 Then
                    Dim pathStr As String = nsItem.SubItems(2).Text
                    If Not String.IsNullOrEmpty(pathStr) AndAlso Not itemMap.ContainsKey(pathStr) Then
                        itemMap(pathStr) = nsItem
                    End If
                End If
            Next
        End If

        Dim removeBatch As New List(Of NSListViewItem)()

        Dim cleanedCount As Integer = cleaner.CleanDetailedFiles(ScannedCleanItems,
            Sub(current, total, status)
                Dim pct As Integer = CInt((current / CDbl(total)) * 100)
                CleanerProgressBar.Value = Math.Min(100, Math.Max(0, pct))
                NsLabelStatus.Value1 = "Cleaning:"
                NsLabelStatus.Value2 = " " & status
                Application.DoEvents()
            End Sub,
            Sub(item, wasCleaned)
                If wasCleaned AndAlso itemMap.ContainsKey(item.FilePath) Then
                    Dim nsItem As NSListViewItem = itemMap(item.FilePath)
                    removeBatch.Add(nsItem)
                    If removeBatch.Count >= 5 Then
                        NsListView1.RemoveItems(removeBatch.ToArray())
                        removeBatch.Clear()
                        Application.DoEvents()
                    End If
                End If
            End Sub)

        If removeBatch.Count > 0 Then
            NsListView1.RemoveItems(removeBatch.ToArray())
            removeBatch.Clear()
        End If

        CleanerProgressBar.Value = 100
        CleanerProgressBar.Visible = False

        Dim totalCount As Integer = ScannedCleanItems.Count
        NsLabelStatus.Value1 = "Clean Complete:"
        If cleanedCount >= totalCount Then
            NsLabelStatus.Value2 = " Cleaned " & cleanedCount & " files"
            NsListView1.Clear()
            ScannedCleanItems.Clear()
        Else
            NsLabelStatus.Value2 = " Cleaned " & cleanedCount & " of " & totalCount & " files (" & (totalCount - cleanedCount) & " locked/in-use)"
        End If

        btnScan.Enabled = True
        btnClean.Enabled = (NsListView1.Items.Length > 0)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub NsControlButton1_Click(sender As Object, e As EventArgs) Handles NsControlButton1.Click
        Me.Close()
    End Sub

    Private Sub ctxListView_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxListView.Opening
        If NsListView1.SelectedItems.Length = 0 Then
            e.Cancel = True
            Return
        End If

        If NsListView1.SelectedItems.Length = 1 Then
            Dim fileName As String = NsListView1.SelectedItems(0).Text
            tsSearchGoogle.Text = "Search '" & fileName & "' in Google"
        Else
            tsSearchGoogle.Text = "Search selected files in Google"
        End If
    End Sub

    Private Sub tsCopyPath_Click(sender As Object, e As EventArgs) Handles tsCopyPath.Click
        If NsListView1.SelectedItems.Length = 0 Then Return
        Dim paths As New List(Of String)()
        For Each item As NSListViewItem In NsListView1.SelectedItems
            Dim filePath As String = If(item.SubItems.Count >= 3, item.SubItems(2).Text, item.Text)
            If Not String.IsNullOrEmpty(filePath) Then paths.Add(filePath)
        Next
        If paths.Count > 0 Then
            Clipboard.SetText(String.Join(vbNewLine, paths.ToArray()))
        End If
    End Sub

    Private Sub tsOpenFileLocation_Click(sender As Object, e As EventArgs) Handles tsOpenFileLocation.Click
        If NsListView1.SelectedItems.Length = 0 Then Return
        For Each item As NSListViewItem In NsListView1.SelectedItems
            Dim filePath As String = If(item.SubItems.Count >= 3, item.SubItems(2).Text, item.Text)
            If File.Exists(filePath) Then
                Process.Start("explorer.exe", "/select,""" & filePath & """")
            ElseIf Directory.Exists(Path.GetDirectoryName(filePath)) Then
                Process.Start("explorer.exe", """" & Path.GetDirectoryName(filePath) & """")
            End If
        Next
    End Sub

    Private Sub tsSearchGoogle_Click(sender As Object, e As EventArgs) Handles tsSearchGoogle.Click
        If NsListView1.SelectedItems.Length = 0 Then Return
        For Each item As NSListViewItem In NsListView1.SelectedItems
            Dim fileName As String = item.Text
            If Not String.IsNullOrEmpty(fileName) Then
                Dim url As String = "https://www.google.com/search?q=" & Uri.EscapeDataString(fileName)
                Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            End If
        Next
    End Sub
End Class
