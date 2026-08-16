Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports Typhon.Helpers
Imports Typhon.NSListView

''' <summary>
''' Interactive Typhon Sight disk visualizer window with synchronized NSListView and Treemap.
''' </summary>
Public Class WinSight

    Private _cts As CancellationTokenSource
    Private _isScanning As Boolean = False
    Private _currentSelectedNode As SpaceNode = Nothing
    Private _isSyncingSelection As Boolean = False

    Private Sub WinSight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Owner IsNot Nothing AndAlso Owner.Icon IsNot Nothing Then
                Me.Icon = Owner.Icon
            End If
        Catch ex As Exception
        End Try

        If lvFiles.Columns.Length = 0 Then
            lvFiles.AddColumn("Name", 320)
            lvFiles.AddColumn("Size", 100)
            lvFiles.AddColumn("Type", 110)
            lvFiles.AddColumn("% of Folder", 90)
            lvFiles.AddColumn("Path", 340)
        End If

        LoadDrives()

        AddHandler TreemapCanvas.NodeHovered, AddressOf OnNodeHovered
        AddHandler TreemapCanvas.NodeSelected, AddressOf OnTreemapNodeSelected
        AddHandler TreemapCanvas.NodeDoubleClicked, AddressOf OnTreemapNodeDoubleClicked

        AddHandler lvFiles.MouseDown, AddressOf OnListViewMouseDown
        AddHandler lvFiles.DoubleClick, AddressOf OnListViewDoubleClick
        AddHandler ctxTreemap.Opening, AddressOf OnContextMenuOpening
    End Sub

    Private Sub OnContextMenuOpening(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target Is Nothing Then
            e.Cancel = True
            Return
        End If

        ' Only show file-specific options for files (not directories)
        If Not target.IsDirectory Then
            tsOpenFile.Visible = True
            tsOpenFile.Text = "Open " & target.Name

            tsAddToExceptions.Visible = True
            tsAddToExceptions.Text = "Add to Exception: " & target.Name

            tsSearchGoogle.Visible = True
            tsCheckVirusTotal.Visible = True
            tsSeparator1.Visible = True
            tsSearchGoogle.Text = "Search in Google: " & target.Name
            tsCheckVirusTotal.Text = "Check VirusTotal: " & target.Name
        Else
            tsOpenFile.Visible = False
            tsAddToExceptions.Visible = False
            tsSearchGoogle.Visible = False
            tsCheckVirusTotal.Visible = False
            tsSeparator1.Visible = False
        End If
    End Sub

    Private Sub tsAddToExceptions_Click(sender As Object, e As EventArgs) Handles tsAddToExceptions.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target IsNot Nothing AndAlso Not target.IsDirectory Then
            Dim exeName As String = target.Name.Trim()
            If Not exeName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
                exeName &= ".exe"
            End If

            If WinMain.ProcessIgnoreList Is Nothing Then
                WinMain.ProcessIgnoreList = New Collections.Specialized.StringCollection()
            End If

            If Not WinMain.ProcessIgnoreList.Contains(exeName) Then
                WinMain.ProcessIgnoreList.Add(exeName)
                My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
                My.Settings.Save()
                lblHoverInfo.Value2 = String.Format(" Added '{0}' to process kill exceptions.", exeName)
            Else
                lblHoverInfo.Value2 = String.Format(" '{0}' is already in process kill exceptions.", exeName)
            End If
        End If
    End Sub

    Private Sub tsOpenFile_Click(sender As Object, e As EventArgs) Handles tsOpenFile.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target IsNot Nothing AndAlso Not target.IsDirectory AndAlso File.Exists(target.FullPath) Then
            Try
                Process.Start(New ProcessStartInfo(target.FullPath) With {.UseShellExecute = True})
            Catch ex As Exception
                MessageBox.Show("Could not open file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub tsSearchGoogle_Click(sender As Object, e As EventArgs) Handles tsSearchGoogle.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target IsNot Nothing AndAlso Not target.IsDirectory Then
            Try
                Dim query As String = Uri.EscapeDataString(target.Name)
                Process.Start(New ProcessStartInfo("https://www.google.com/search?q=" & query) With {.UseShellExecute = True})
            Catch ex As Exception
                MessageBox.Show("Could not open browser: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub tsCheckVirusTotal_Click(sender As Object, e As EventArgs) Handles tsCheckVirusTotal.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target IsNot Nothing AndAlso Not target.IsDirectory Then
            Try
                ' If file is under 32MB, calculate SHA256 hash for instant exact report lookup; otherwise search filename
                Dim hashHex As String = ""
                If File.Exists(target.FullPath) AndAlso target.Size > 0 AndAlso target.Size <= (32L * 1024 * 1024) Then
                    Using sha256 = System.Security.Cryptography.SHA256.Create()
                        Using stream = File.OpenRead(target.FullPath)
                            Dim hashBytes = sha256.ComputeHash(stream)
                            hashHex = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant()
                        End Using
                    End Using
                End If

                Dim url As String
                If Not String.IsNullOrEmpty(hashHex) Then
                    url = "https://www.virustotal.com/gui/file/" & hashHex
                Else
                    url = "https://www.virustotal.com/gui/search/" & Uri.EscapeDataString(target.Name)
                End If

                Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
            Catch ex As Exception
                ' Fallback to filename search if file hash fails (e.g. file locked)
                Try
                    Dim url = "https://www.virustotal.com/gui/search/" & Uri.EscapeDataString(target.Name)
                    Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
                Catch
                    MessageBox.Show("Could not open VirusTotal: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Try
        End If
    End Sub

    Private Sub LoadDrives()
        cboDrives.Items.Clear()
        ' Add folder picker item at top
        cboDrives.Items.Add(New DriveItem With {.Path = "BROWSE_FOLDER", .DisplayName = "[+] Scan A Folder...", .Drive = Nothing})

        Try
            For Each d As DriveInfo In DriveInfo.GetDrives()
                If d.IsReady Then
                    Dim totalGB As Double = d.TotalSize / (1024.0 ^ 3)
                    Dim freeGB As Double = d.TotalFreeSpace / (1024.0 ^ 3)
                    Dim volLabel As String = d.VolumeLabel
                    If String.IsNullOrWhiteSpace(volLabel) Then
                        volLabel = "Local Disk"
                    End If
                    Dim label As String = String.Format("{0} [{1}] ({2:0.#} GB free / {3:0.#} GB)", d.Name.TrimEnd("\"c), volLabel, freeGB, totalGB)
                    cboDrives.Items.Add(New DriveItem With {.Path = d.RootDirectory.FullName, .DisplayName = label, .Drive = d})
                End If
            Next
            If cboDrives.Items.Count > 1 Then
                cboDrives.SelectedIndex = 1
            ElseIf cboDrives.Items.Count > 0 Then
                cboDrives.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Class DriveItem
        Public Property Path As String
        Public Property DisplayName As String
        Public Property Drive As DriveInfo
        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class

    Private _previousSelectedIndex As Integer = 1

    Private Sub cboDrives_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDrives.SelectedIndexChanged
        Dim item As DriveItem = TryCast(cboDrives.SelectedItem, DriveItem)
        If item Is Nothing Then Return

        If item.Path = "BROWSE_FOLDER" Then
            Using fbd As New FolderBrowserDialog()
                fbd.Description = "Select folder to analyze with Typhon Sight:"
                fbd.ShowNewFolderButton = False
                If fbd.ShowDialog(Me) = DialogResult.OK Then
                    Dim customItem As New DriveItem With {.Path = fbd.SelectedPath, .DisplayName = "[Folder] " & fbd.SelectedPath, .Drive = Nothing}
                    cboDrives.Items.Insert(1, customItem)
                    cboDrives.SelectedItem = customItem
                    _previousSelectedIndex = cboDrives.SelectedIndex
                    lblCapacity.Value2 = "Custom Directory: " & fbd.SelectedPath
                    Return
                Else
                    ' Revert to previous item if canceled
                    If _previousSelectedIndex >= 0 AndAlso _previousSelectedIndex < cboDrives.Items.Count Then
                        cboDrives.SelectedIndex = _previousSelectedIndex
                    End If
                    Return
                End If
            End Using
        End If

        _previousSelectedIndex = cboDrives.SelectedIndex
        If item.Drive IsNot Nothing Then
            Dim d = item.Drive
            Dim usedGB As Double = (d.TotalSize - d.TotalFreeSpace) / (1024.0 ^ 3)
            Dim totalGB As Double = d.TotalSize / (1024.0 ^ 3)
            Dim pct As Integer = CInt(Math.Round((usedGB / totalGB) * 100.0))
            lblCapacity.Value2 = String.Format("{0:0.#} GB used of {1:0.#} GB ({2}%) - Format: {3}", usedGB, totalGB, pct, d.DriveFormat)
        Else
            lblCapacity.Value2 = "Custom Directory: " & item.Path
        End If
    End Sub

    Private Async Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        If _isScanning Then
            If _cts IsNot Nothing Then
                _cts.Cancel()
            End If
            btnScan.Text = "Canceling..."
            btnScan.Enabled = False
            Return
        End If

        Dim targetPath As String = ""
        Dim item As DriveItem = TryCast(cboDrives.SelectedItem, DriveItem)
        If item IsNot Nothing AndAlso item.Path <> "BROWSE_FOLDER" Then
            targetPath = item.Path
        ElseIf cboDrives.Text.Length > 0 AndAlso cboDrives.Text <> "[+] Scan A Folder..." Then
            targetPath = cboDrives.Text
        End If

        If String.IsNullOrEmpty(targetPath) OrElse Not Directory.Exists(targetPath) Then
            MessageBox.Show("Please select a valid drive or folder to scan.", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        _isScanning = True
        btnScan.Text = "Stop Sight"
        cboDrives.Enabled = False
        LensProgressBar.Value = 1
        lblPath.Value2 = targetPath
        lblHoverInfo.Value2 = " Scanning files and calculating sizes..."
        lvFiles.Clear()

        _cts = New CancellationTokenSource()
        Dim token As CancellationToken = _cts.Token

        Dim scanner As New DiskTreeScanner()
        AddHandler scanner.ProgressChanged, Sub(p As ScanProgress)
                                                If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
                                                Me.BeginInvoke(Sub()
                                                                   lblHoverInfo.Value1 = "Scanning:"
                                                                   lblHoverInfo.Value2 = String.Format(" {0:N0} files, {1:N0} folders ({2}) - {3}", p.FilesScanned, p.FoldersScanned, SpaceNode.FormatBytes(p.TotalBytes), p.CurrentPath)
                                                                   LensProgressBar.Value = Math.Max(1, Math.Min(100, p.EstimatedPercent))
                                                               End Sub)
                                            End Sub

        Try
            Dim resultRoot As SpaceNode = Await Task.Run(Function() scanner.ScanDirectory(targetPath, token), token)

            TreemapCanvas.RootNode = resultRoot
            LensProgressBar.Value = 100
            PopulateListView(resultRoot)
            UpdatePathLabel()
            lblHoverInfo.Value1 = "Status:"
            lblHoverInfo.Value2 = String.Format(" Scan complete. {0:N0} items total ({1}).", resultRoot.Children.Count, resultRoot.FormattedSize)
        Catch ex As OperationCanceledException
            lblHoverInfo.Value2 = " Scan canceled by user."
            LensProgressBar.Value = 0
        Catch ex As Exception
            MessageBox.Show("Error scanning folder: " & ex.Message, "Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblHoverInfo.Value2 = " Scan failed: " & ex.Message
            LensProgressBar.Value = 0
        Finally
            _isScanning = False
            btnScan.Text = "Start Sight"
            btnScan.Enabled = True
            cboDrives.Enabled = True
            If _cts IsNot Nothing Then
                _cts.Dispose()
                _cts = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Populates NSListView with children of the given SpaceNode directory.
    ''' Adds "../" at the very top if a parent directory exists.
    ''' </summary>
    Private Sub PopulateListView(parentNode As SpaceNode)
        lvFiles.Clear()
        If parentNode Is Nothing Then Return

        Dim listItems As New List(Of NSListViewItem)()

        ' Add "../" entry if there is a parent directory
        If parentNode.Parent IsNot Nothing Then
            Dim upItm As New NSListViewItem()
            upItm.Text = "../"
            upItm.Tag = "PARENT_DIRECTORY"
            upItm.Icon = GetNodeIcon(parentNode.Parent)
            upItm.SubItems.Add(New NSListViewSubItem() With {.Text = "-"})
            upItm.SubItems.Add(New NSListViewSubItem() With {.Text = "Parent Folder"})
            upItm.SubItems.Add(New NSListViewSubItem() With {.Text = "-"})
            upItm.SubItems.Add(New NSListViewSubItem() With {.Text = parentNode.Parent.FullPath})
            listItems.Add(upItm)
        End If

        If parentNode.Children.Count > 0 Then
            Dim totalFolderSize As Double = Math.Max(1, parentNode.Size)

            ' Default sort: Alphabetical by Name (Folders first, then files)
            Dim sortedChildren = parentNode.Children.OrderByDescending(Function(c) c.IsDirectory).ThenBy(Function(c) c.Name, StringComparer.OrdinalIgnoreCase).ToList()

            For Each child In sortedChildren
                Dim pct As Double = (CDbl(child.Size) / totalFolderSize) * 100.0
                Dim typeStr As String = If(child.IsDirectory, "Folder (" & child.Children.Count & " items)", If(Path.GetExtension(child.Name).ToUpper(), "File"))
                If String.IsNullOrEmpty(typeStr) Then typeStr = "File"

                Dim nodeColor As Color = Global.Typhon.Controls.SpaceLensTreemap.GetNodeColor(child)
                Dim itemIcon As Image = GetNodeIcon(child)

                Dim itm As New NSListViewItem()
                itm.Text = child.Name
                itm.Tag = child
                itm.Icon = itemIcon
                itm.TextColor = nodeColor
                itm.SubItems.Add(New NSListViewSubItem() With {.Text = child.FormattedSize, .TextColor = nodeColor})
                itm.SubItems.Add(New NSListViewSubItem() With {.Text = typeStr, .TextColor = nodeColor})
                itm.SubItems.Add(New NSListViewSubItem() With {.Text = String.Format("{0:0.#}%", pct), .TextColor = nodeColor})
                itm.SubItems.Add(New NSListViewSubItem() With {.Text = child.FullPath, .TextColor = nodeColor})

                listItems.Add(itm)
            Next
        End If

        lvFiles.AddItems(listItems)
    End Sub

    Private Sub OnNodeHovered(node As SpaceNode)
        If node IsNot Nothing Then
            Dim typeStr As String = If(node.IsDirectory, "Folder (" & node.Children.Count & " items)", "File")
            lblHoverInfo.Value2 = String.Format(" {0} [{1}] - {2} ({3})", node.Name, typeStr, node.FormattedSize, node.FullPath)
        ElseIf _currentSelectedNode IsNot Nothing Then
            lblHoverInfo.Value2 = String.Format(" {0} ({1}) - {2}", _currentSelectedNode.Name, _currentSelectedNode.FormattedSize, _currentSelectedNode.FullPath)
        End If
    End Sub

    Private Sub OnTreemapNodeSelected(node As SpaceNode)
        _currentSelectedNode = node
        If node IsNot Nothing Then
            lblHoverInfo.Value1 = "Selected:"
            lblHoverInfo.Value2 = String.Format(" {0} ({1}) - {2}", node.Name, node.FormattedSize, node.FullPath)

            ' Sync selection with NSListView
            If Not _isSyncingSelection Then
                _isSyncingSelection = True
                For Each itm In lvFiles.Items
                    If Object.ReferenceEquals(itm.Tag, node) Then
                        lvFiles.SelectItem(itm)
                        Exit For
                    End If
                Next
                _isSyncingSelection = False
            End If
        End If
    End Sub

    Private Sub OnTreemapNodeDoubleClicked(node As SpaceNode)
        PopulateListView(TreemapCanvas.CurrentNode)
        UpdatePathLabel()
    End Sub

    Private Sub OnListViewMouseDown(sender As Object, e As MouseEventArgs)
        If _isSyncingSelection Then Return
        If lvFiles.SelectedItems.Length > 0 Then
            Dim selectedItm = lvFiles.SelectedItems(0)
            If Equals(selectedItm.Tag, "PARENT_DIRECTORY") Then
                _currentSelectedNode = Nothing
                lblHoverInfo.Value2 = " Parent Directory [../]"
                TreemapCanvas.SelectedNode = Nothing
                Return
            End If

            Dim node = TryCast(selectedItm.Tag, SpaceNode)
            If node IsNot Nothing Then
                _currentSelectedNode = node
                lblHoverInfo.Value1 = "Selected:"
                lblHoverInfo.Value2 = String.Format(" {0} ({1}) - {2}", node.Name, node.FormattedSize, node.FullPath)

                _isSyncingSelection = True
                TreemapCanvas.SelectedNode = node
                _isSyncingSelection = False
            End If
        End If
    End Sub

    Private Sub OnListViewDoubleClick(sender As Object, e As EventArgs)
        If lvFiles.SelectedItems.Length > 0 Then
            Dim selectedItm = lvFiles.SelectedItems(0)

            ' Handle "../" navigation
            If Equals(selectedItm.Tag, "PARENT_DIRECTORY") Then
                If TreemapCanvas.NavigateUp() Then
                    PopulateListView(TreemapCanvas.CurrentNode)
                    UpdatePathLabel()
                End If
                Return
            End If

            Dim node = TryCast(selectedItm.Tag, SpaceNode)
            If node IsNot Nothing AndAlso node.IsDirectory Then
                ' Drill into folder
                TreemapCanvas.CurrentNode = node
                PopulateListView(node)
                UpdatePathLabel()
            ElseIf node IsNot Nothing Then
                ' Open/launch file directly with default handler
                OpenFileDirectly(node.FullPath)
            End If
        End If
    End Sub

    Private Sub OpenFileDirectly(filePath As String)
        Try
            If File.Exists(filePath) Then
                Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
            ElseIf Directory.Exists(filePath) Then
                Process.Start("explorer.exe", """" & filePath & """")
            End If
        Catch ex As Exception
            MessageBox.Show("Could not open file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdatePathLabel()
        If TreemapCanvas.CurrentNode IsNot Nothing Then
            lblPath.Value2 = TreemapCanvas.CurrentNode.FullPath & " (" & TreemapCanvas.CurrentNode.FormattedSize & ")"
        End If
    End Sub

    Private Sub btnOpenExplorer_Click(sender As Object, e As EventArgs) Handles btnOpenExplorer.Click
        Dim target As SpaceNode = If(_currentSelectedNode, TreemapCanvas.CurrentNode)
        If target IsNot Nothing AndAlso Not String.IsNullOrEmpty(target.FullPath) Then
            OpenInExplorer(target.FullPath, Not target.IsDirectory)
        End If
    End Sub

    Private Sub tsOpenInExplorer_Click(sender As Object, e As EventArgs) Handles tsOpenInExplorer.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target IsNot Nothing AndAlso Not String.IsNullOrEmpty(target.FullPath) Then
            OpenInExplorer(target.FullPath, Not target.IsDirectory)
        End If
    End Sub

    Private Sub tsCopyPath_Click(sender As Object, e As EventArgs) Handles tsCopyPath.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target IsNot Nothing AndAlso Not String.IsNullOrEmpty(target.FullPath) Then
            Try
                Clipboard.SetText(target.FullPath)
            Catch
            End Try
        End If
    End Sub

    Private Sub tsDeleteFile_Click(sender As Object, e As EventArgs) Handles tsDeleteFile.Click
        Dim target As SpaceNode = GetCurrentActionTarget()
        If target Is Nothing Then Return

        Dim prompt As String = String.Format("Are you sure you want to delete {0}?" & vbNewLine & "{1} ({2})", If(target.IsDirectory, "folder", "file"), target.FullPath, target.FormattedSize)
        If MessageBox.Show(prompt, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                If target.IsDirectory Then
                    Directory.Delete(target.FullPath, True)
                Else
                    File.Delete(target.FullPath)
                End If

                If target.Parent IsNot Nothing Then
                    target.Parent.Children.Remove(target)
                    target.Parent.Size -= target.Size
                    TreemapCanvas.RecalculateLayout()
                    TreemapCanvas.Invalidate()
                    PopulateListView(target.Parent)
                End If
                lblHoverInfo.Value1 = "Deleted:"
                lblHoverInfo.Value2 = $" {target.FullPath}"
            Catch ex As Exception
                MessageBox.Show("Failed to delete: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function GetCurrentActionTarget() As SpaceNode
        If TreemapCanvas.HoveredNode IsNot Nothing Then
            Return TreemapCanvas.HoveredNode
        End If
        If lvFiles.SelectedItems.Length > 0 Then
            Return TryCast(lvFiles.SelectedItems(0).Tag, SpaceNode)
        End If
        Return _currentSelectedNode
    End Function

    Private Sub OpenInExplorer(path As String, isFile As Boolean)
        Try
            If isFile AndAlso File.Exists(path) Then
                Process.Start("explorer.exe", "/select,""" & path & """")
            ElseIf Directory.Exists(path) Then
                Process.Start("explorer.exe", """" & path & """")
            End If
        Catch ex As Exception
            MessageBox.Show("Could not open path: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Shared _nodeIconCache As New Dictionary(Of String, Image)(StringComparer.OrdinalIgnoreCase)
    Private Shared _folderIcon As Image = Nothing

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)>
    Private Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=260)>
        Public szDisplayName As String
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure

    <System.Runtime.InteropServices.DllImport("shell32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As UInteger, ByVal uFlags As UInteger) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean
    End Function

    Private Const SHGFI_ICON As UInteger = &H100
    Private Const SHGFI_SMALLICON As UInteger = &H1
    Private Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10
    Private Const FILE_ATTRIBUTE_DIRECTORY As UInteger = &H10
    Private Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80

    Private Shared Function GetNodeIcon(node As SpaceNode) As Image
        If node Is Nothing Then Return Nothing

        If node.IsDirectory Then
            If _folderIcon IsNot Nothing Then Return _folderIcon

            Dim shinfo As New SHFILEINFO()
            Dim res As IntPtr = SHGetFileInfo("dummy", FILE_ATTRIBUTE_DIRECTORY, shinfo, CUInt(System.Runtime.InteropServices.Marshal.SizeOf(shinfo)), SHGFI_ICON Or SHGFI_SMALLICON Or SHGFI_USEFILEATTRIBUTES)
            If res <> IntPtr.Zero AndAlso shinfo.hIcon <> IntPtr.Zero Then
                Using ico = Icon.FromHandle(shinfo.hIcon)
                    _folderIcon = CType(ico.ToBitmap().Clone(), Image)
                End Using
                DestroyIcon(shinfo.hIcon)
                Return _folderIcon
            End If
            Return Nothing
        Else
            Dim ext As String = Path.GetExtension(node.Name).ToLowerInvariant()
            If String.IsNullOrEmpty(ext) Then ext = ".unknown"

            If _nodeIconCache.ContainsKey(ext) Then
                Return _nodeIconCache(ext)
            End If

            ' For common binary executable/dll files with custom icons, try reading actual file icon if accessible
            If (ext = ".exe" OrElse ext = ".ico") AndAlso File.Exists(node.FullPath) Then
                Dim img As Image = proc.GetProcessIcon(node.FullPath)
                If img IsNot Nothing Then
                    Return img
                End If
            End If

            ' Shell extension association icon
            Dim shinfo As New SHFILEINFO()
            Dim res As IntPtr = SHGetFileInfo(ext, FILE_ATTRIBUTE_NORMAL, shinfo, CUInt(System.Runtime.InteropServices.Marshal.SizeOf(shinfo)), SHGFI_ICON Or SHGFI_SMALLICON Or SHGFI_USEFILEATTRIBUTES)
            If res <> IntPtr.Zero AndAlso shinfo.hIcon <> IntPtr.Zero Then
                Dim bmp As Image = Nothing
                Using ico = Icon.FromHandle(shinfo.hIcon)
                    bmp = CType(ico.ToBitmap().Clone(), Image)
                End Using
                DestroyIcon(shinfo.hIcon)
                _nodeIconCache(ext) = bmp
                Return bmp
            End If

            _nodeIconCache(ext) = Nothing
            Return Nothing
        End If
    End Function

End Class
