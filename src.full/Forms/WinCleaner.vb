Imports System.IO
Imports Typhon.NSListView

''' <summary>
''' Dedicated System Cleaner window providing split UI with scan results list view, 
''' real-time category options selection, drive selection, and junk file cleaning.
''' </summary>
Public Class WinCleaner

    Private ScannedCleanItems As New List(Of cleaner.CleanItem)()
    Private IsScanning As Boolean = False
    Private IsCleaning As Boolean = False
    Private CancelScanRequested As Boolean = False
    Private TargetDrives As List(Of String) = Nothing

    Private Sub WinCleaner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Owner IsNot Nothing AndAlso Owner.Icon IsNot Nothing Then
                Me.Icon = Owner.Icon
            End If
        Catch ex As Exception
        End Try

        If lvCleanItems.Columns.Length = 0 Then
            lvCleanItems.AddColumn("Filename", 130)
            lvCleanItems.AddColumn("Size", 75)
            lvCleanItems.AddColumn("Category", 100)
            lvCleanItems.AddColumn("Path", 250)
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
        If IsLoadingOptions Then Return
        SaveCleanerOptions()
    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        If IsScanning Then
            CancelScanRequested = True
            btnScan.Text = "Cancelling..."
            btnScan.Enabled = False
            Return
        End If
        If IsCleaning Then Return

        lvCleanItems.Clear()
        lblStatus.Value1 = "Scanning:"
        lblStatus.Value2 = " Select target drives to scan..."
        btnClean.Enabled = False
        ScannedCleanItems.Clear()
        Application.DoEvents()

        Using selector As New WinDiskSelector()
            If selector.ShowDialog(Me) <> DialogResult.OK Then
                lblStatus.Value1 = "Status:"
                lblStatus.Value2 = " Ready to scan system"
                Return
            End If
            TargetDrives = selector.SelectedDrives
        End Using

        If TargetDrives Is Nothing OrElse TargetDrives.Count = 0 Then
            lblStatus.Value1 = "Status:"
            lblStatus.Value2 = " Ready to scan system"
            Return
        End If

        SaveCleanerOptions()

        IsScanning = True
        CancelScanRequested = False
        btnScan.Text = "Cancel"

        pbCleaningProgress.Value = 0
        pbCleaningProgress.Visible = True

        lblStatus.Value1 = "Scanning:"
        lblStatus.Value2 = " Starting scan..."
        Application.DoEvents()

        Dim enabledCategories As Dictionary(Of String, Boolean) = cleaner.LoadConfig()
        Dim accumulatedBytes As Long = 0
        Dim scannedFilesCount As Integer = 0
        Dim realtimeBatch As New List(Of NSListViewItem)()

        ScannedCleanItems = cleaner.ScanDetailedFiles(TargetDrives, enabledCategories,
                                                       Sub(current, total, status)
                                                           Dim pct As Integer = CInt((current / CDbl(total)) * 100)
                                                           pbCleaningProgress.Value = Math.Min(100, Math.Max(0, pct))
                                                           lblStatus.Value1 = "Scanning:"
                                                           lblStatus.Value2 = " " & status
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
                                                               lvCleanItems.AddItems(realtimeBatch)
                                                               realtimeBatch.Clear()
                                                               Application.DoEvents()
                                                           End If
                                                       End Sub,
                                                       Function() CancelScanRequested)

        If realtimeBatch.Count > 0 Then
            lvCleanItems.AddItems(realtimeBatch)
            realtimeBatch.Clear()
        End If

        IsScanning = False
        btnScan.Text = "Scan"
        btnScan.Enabled = True
        pbCleaningProgress.Visible = False

        Dim finalFormattedSize As String = cleaner.FormatBytes(accumulatedBytes)
        If CancelScanRequested Then
            lblStatus.Value1 = "Status:"
            lblStatus.Value2 = " Scan cancelled (" & ScannedCleanItems.Count & " files, " & finalFormattedSize & ")"
            btnClean.Enabled = False
        Else
            pbCleaningProgress.Value = 100
            lblStatus.Value1 = "Scan Complete:"
            lblStatus.Value2 = " Found " & ScannedCleanItems.Count & " files (" & finalFormattedSize & ")"
            btnClean.Enabled = (lvCleanItems.Items.Length > 0)
        End If
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        If IsScanning OrElse IsCleaning Then Return
        If ScannedCleanItems.Count = 0 Then Return

        IsCleaning = True
        btnScan.Enabled = False
        btnClean.Enabled = False
        pbCleaningProgress.Value = 0
        pbCleaningProgress.Visible = True

        Try
            Application.DoEvents()

            ' Build lookup mapping file paths to NSListViewItem objects for live removal
            Dim itemMap As New Dictionary(Of String, NSListViewItem)(StringComparer.OrdinalIgnoreCase)
            If lvCleanItems.Items IsNot Nothing Then
                For Each nsItem As NSListViewItem In lvCleanItems.Items
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
                    pbCleaningProgress.Value = Math.Min(100, Math.Max(0, pct))
                    lblStatus.Value1 = "Cleaning:"
                    lblStatus.Value2 = " " & status
                    Application.DoEvents()
                End Sub,
                Sub(item, wasCleaned)
                    If wasCleaned AndAlso itemMap.ContainsKey(item.FilePath) Then
                        Dim nsItem As NSListViewItem = itemMap(item.FilePath)
                        removeBatch.Add(nsItem)
                        If removeBatch.Count >= 5 Then
                            lvCleanItems.RemoveItems(removeBatch.ToArray())
                            removeBatch.Clear()
                            Application.DoEvents()
                        End If
                    End If
                End Sub)

            If removeBatch.Count > 0 Then
                lvCleanItems.RemoveItems(removeBatch.ToArray())
                removeBatch.Clear()
            End If

            pbCleaningProgress.Value = 100
            pbCleaningProgress.Visible = False

            Dim totalCount As Integer = ScannedCleanItems.Count
            lblStatus.Value1 = "Clean Complete:"
            If cleanedCount >= totalCount Then
                lblStatus.Value2 = " Cleaned " & cleanedCount & " files"
                lvCleanItems.Clear()
                ScannedCleanItems.Clear()
            Else
                lblStatus.Value2 = " Cleaned " & cleanedCount & " of " & totalCount & " files (" & (totalCount - cleanedCount) & " in-use)"
            End If
        Finally
            IsCleaning = False
            btnScan.Enabled = True
            btnClean.Enabled = (lvCleanItems.Items.Length > 0)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnControlClose_Click(sender As Object, e As EventArgs) Handles btnControlClose.Click
        Me.Close()
    End Sub

    Private Sub ctxListView_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxListView.Opening
        If lvCleanItems.SelectedItems.Length = 0 Then
            e.Cancel = True
            Return
        End If

        If lvCleanItems.SelectedItems.Length = 1 Then
            Dim fileName As String = lvCleanItems.SelectedItems(0).Text
            tsSearchGoogle.Text = "Search '" & fileName & "' in Google"
        Else
            tsSearchGoogle.Text = "Search selected files in Google"
        End If
    End Sub

    Private Sub tsCopyPath_Click(sender As Object, e As EventArgs) Handles tsCopyPath.Click
        If lvCleanItems.SelectedItems.Length = 0 Then Return
        Dim paths As New List(Of String)()
        For Each item As NSListViewItem In lvCleanItems.SelectedItems
            Dim filePath As String = If(item.SubItems.Count >= 3, item.SubItems(2).Text, item.Text)
            If Not String.IsNullOrEmpty(filePath) Then paths.Add(filePath)
        Next
        If paths.Count > 0 Then
            Clipboard.SetText(String.Join(vbNewLine, paths.ToArray()))
        End If
    End Sub

    Private Sub tsOpenFileLocation_Click(sender As Object, e As EventArgs) Handles tsOpenFileLocation.Click
        If lvCleanItems.SelectedItems.Length = 0 Then Return
        For Each item As NSListViewItem In lvCleanItems.SelectedItems
            Dim filePath As String = If(item.SubItems.Count >= 3, item.SubItems(2).Text, item.Text)
            If File.Exists(filePath) Then
                Process.Start("explorer.exe", "/select,""" & filePath & """")
            ElseIf Directory.Exists(Path.GetDirectoryName(filePath)) Then
                Process.Start("explorer.exe", """" & Path.GetDirectoryName(filePath) & """")
            End If
        Next
    End Sub

    Private Sub tsSearchGoogle_Click(sender As Object, e As EventArgs) Handles tsSearchGoogle.Click
        If lvCleanItems.SelectedItems.Length = 0 Then Return
        For Each item As NSListViewItem In lvCleanItems.SelectedItems
            Dim fileName As String = item.Text
            If Not String.IsNullOrEmpty(fileName) Then
                Dim url As String = "https://www.google.com/search?q=" & Uri.EscapeDataString(fileName)
                Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            End If
        Next
    End Sub

    Private Sub tsSearchVirusTotal_Click(sender As Object, e As EventArgs) Handles tsSearchVirusTotal.Click
        If lvCleanItems.SelectedItems.Length = 0 Then Return
        For Each item As NSListViewItem In lvCleanItems.SelectedItems
            Dim fileName As String = item.Text
            If Not String.IsNullOrEmpty(fileName) Then
                Dim url = "https://www.virustotal.com/gui/search/" & Uri.EscapeDataString(fileName)
                Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            End If
        Next
    End Sub
End Class
