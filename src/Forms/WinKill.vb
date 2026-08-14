''' <summary>
''' Process killer form featuring collapsible process family grouping, RAM usage sorting, and selective process termination.
''' </summary>
Public Class WinKill

    Private _proc As proc = New proc()
    Private _groups As New List(Of proc.ProcessGroupItem)()
    Private _sortColumn As Integer = 1 ' Default sort by RAM (Column 1)
    Private _sortAscending As Boolean = False ' Default descending (heaviest RAM first)

    ''' <summary>
    ''' Form load event handler populating listview with collapsible process groups.
    ''' </summary>
    Private Sub WinKill_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        _groups = _proc.GetKillableProcessGroups(WinMain.ProcessIgnoreList)
        RenderListView()
    End Sub

    ''' <summary>
    ''' Re-renders the listview items based on current process groups, expansion states, and sorting preferences.
    ''' </summary>
    Private Sub RenderListView()
        ' Sort process groups based on active column
        If _sortColumn = 0 Then
            If _sortAscending Then
                _groups.Sort(Function(a, b) String.Compare(a.ProcessName, b.ProcessName, StringComparison.OrdinalIgnoreCase))
            Else
                _groups.Sort(Function(a, b) String.Compare(b.ProcessName, a.ProcessName, StringComparison.OrdinalIgnoreCase))
            End If
        Else
            If _sortAscending Then
                _groups.Sort(Function(a, b) a.TotalBytes.CompareTo(b.TotalBytes))
            Else
                _groups.Sort(Function(a, b) b.TotalBytes.CompareTo(a.TotalBytes))
            End If
        End If

        Dim itemList As New List(Of NSListView.NSListViewItem)()
        Dim totalProcesses As Integer = 0
        Dim totalBytes As Long = 0L

        For Each grp As proc.ProcessGroupItem In _groups
            totalProcesses += grp.InstanceCount
            totalBytes += grp.TotalBytes

            ' Group Parent Item
            Dim prefix As String = If(grp.InstanceCount > 1, If(grp.IsExpanded, "[-] ", "[+] "), "    ")
            Dim parentText As String = prefix & grp.ProcessName & If(grp.InstanceCount > 1, " (" & grp.InstanceCount & ")", "")
            Dim parentIcon As Image = If(grp.Instances.Count > 0, proc.GetProcessIcon(grp.Instances(0).FullPath), Nothing)
            Dim parentLvi As New NSListView.NSListViewItem() With {
                .Text = parentText,
                .Checked = grp.Checked,
                .Icon = parentIcon,
                .Tag = grp
            }
            parentLvi.SubItems.Add(New NSListView.NSListViewSubItem() With {.Text = cleaner.FormatBytes(grp.TotalBytes)})
            itemList.Add(parentLvi)

            ' Child Items if Group is Expanded
            If grp.IsExpanded AndAlso grp.InstanceCount > 1 Then
                For Each inst As proc.ProcessInstanceItem In grp.Instances
                    Dim childText As String = "    ├─ PID " & inst.ProcessId
                    Dim childIcon As Image = proc.GetProcessIcon(inst.FullPath)
                    Dim childLvi As New NSListView.NSListViewItem() With {
                        .Text = childText,
                        .Checked = inst.Checked,
                        .Icon = childIcon,
                        .Tag = inst
                    }
                    childLvi.SubItems.Add(New NSListView.NSListViewSubItem() With {.Text = cleaner.FormatBytes(inst.MemoryBytes)})
                    itemList.Add(childLvi)
                Next
            End If
        Next

        NsListView1.Items = itemList.ToArray()
        NsLabel1.Value1 = "Summary:"
        NsLabel1.Value2 = Space(1) & totalProcesses & " processes (" & cleaner.FormatBytes(totalBytes) & " total)"
    End Sub

    ''' <summary>
    ''' Column click handler toggling sort direction by Process Name or RAM footprint.
    ''' </summary>
    Private Sub NsListView1_ColumnClick(sender As Object, columnIndex As Integer) Handles NsListView1.ColumnClick
        If _sortColumn = columnIndex Then
            _sortAscending = Not _sortAscending
        Else
            _sortColumn = columnIndex
            _sortAscending = True
        End If
        RenderListView()
    End Sub

    ''' <summary>
    ''' Handles expansion toggling and checkbox state synchronization for the clicked process item.
    ''' </summary>
    Private Sub NsListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles NsListView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If NsListView1.SelectedItems IsNot Nothing AndAlso NsListView1.SelectedItems.Length > 0 Then
                Dim selectedItem As NSListView.NSListViewItem = NsListView1.SelectedItems(0)

                If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                    Dim grp As proc.ProcessGroupItem = DirectCast(selectedItem.Tag, proc.ProcessGroupItem)
                    If e.X <= 24 Then
                        grp.Checked = selectedItem.Checked
                        For Each inst As proc.ProcessInstanceItem In grp.Instances
                            inst.Checked = grp.Checked
                        Next
                        RenderListView()
                    Else
                        ' Toggle expansion when group header is clicked
                        If grp.InstanceCount > 1 Then
                            grp.IsExpanded = Not grp.IsExpanded
                            RenderListView()
                        End If
                    End If
                ElseIf TypeOf selectedItem.Tag Is proc.ProcessInstanceItem Then
                    Dim inst As proc.ProcessInstanceItem = DirectCast(selectedItem.Tag, proc.ProcessInstanceItem)
                    inst.Checked = selectedItem.Checked
                    Dim parentGrp As proc.ProcessGroupItem = _groups.Find(Function(g) g.ProcessName.Equals(inst.ProcessName, StringComparison.OrdinalIgnoreCase))
                    If parentGrp IsNot Nothing Then
                        parentGrp.Checked = parentGrp.Instances.Exists(Function(i) i.Checked)
                    End If
                    RenderListView()
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Click event handler terminating checked processes.
    ''' </summary>
    Private Sub NsButton1_Click(sender As System.Object, e As System.EventArgs) Handles NsButton1.Click
        Dim pidsToKill As New List(Of Integer)()

        For Each grp As proc.ProcessGroupItem In _groups
            For Each inst As proc.ProcessInstanceItem In grp.Instances
                If inst.Checked Then
                    pidsToKill.Add(inst.ProcessId)
                End If
            Next
        Next

        Dim killedCount As Integer = 0
        For Each pid As Integer In pidsToKill
            Try
                Dim p As Process = Process.GetProcessById(pid)
                proc.SafeKillProcess(p)
                killedCount += 1
            Catch ex As Exception
            End Try
        Next

        Me.Close()
    End Sub

    ''' <summary>
    ''' Context menu handler selecting all process groups and instances.
    ''' </summary>
    Private Sub SelectAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        For Each grp As proc.ProcessGroupItem In _groups
            grp.Checked = True
            For Each inst As proc.ProcessInstanceItem In grp.Instances
                inst.Checked = True
            Next
        Next
        RenderListView()
    End Sub

    ''' <summary>
    ''' Context menu handler deselecting all process groups and instances.
    ''' </summary>
    Private Sub DeselectAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeselectAllToolStripMenuItem.Click
        For Each grp As proc.ProcessGroupItem In _groups
            grp.Checked = False
            For Each inst As proc.ProcessInstanceItem In grp.Instances
                inst.Checked = False
            Next
        Next
        RenderListView()
    End Sub

    ''' <summary>
    ''' Context menu handler adding selected process executable to ignore list.
    ''' </summary>
    Private Sub AddToIgnoreListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToIgnoreListToolStripMenuItem.Click
        If NsListView1.SelectedItems IsNot Nothing AndAlso NsListView1.SelectedItems.Length > 0 Then
            For Each selectedItem As NSListView.NSListViewItem In NsListView1.SelectedItems
                Dim procName As String = ""
                If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                    procName = DirectCast(selectedItem.Tag, proc.ProcessGroupItem).ProcessName
                ElseIf TypeOf selectedItem.Tag Is proc.ProcessInstanceItem Then
                    procName = DirectCast(selectedItem.Tag, proc.ProcessInstanceItem).ProcessName
                End If

                If Not String.IsNullOrEmpty(procName) AndAlso Not WinMain.ProcessIgnoreList.Contains(procName) Then
                    WinMain.ProcessIgnoreList.Add(procName)
                End If
            Next

            My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
            My.Settings.Save()

            _groups = _proc.GetKillableProcessGroups(WinMain.ProcessIgnoreList)
            RenderListView()
        End If
    End Sub

    ''' <summary>
    ''' Control button click handler saving current process ignore list settings to application configuration.
    ''' </summary>
    Private Sub NsControlButton1_Click(sender As System.Object, e As System.EventArgs) Handles NsControlButton1.Click
        My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub SearchGoogleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchGoogleToolStripMenuItem.Click
        If NsListView1.SelectedItems IsNot Nothing AndAlso NsListView1.SelectedItems.Length > 0 Then
            For Each selectedItem As NSListView.NSListViewItem In NsListView1.SelectedItems
                Dim procName As String = ""
                If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                    procName = DirectCast(selectedItem.Tag, proc.ProcessGroupItem).ProcessName
                ElseIf TypeOf selectedItem.Tag Is proc.ProcessInstanceItem Then
                    procName = DirectCast(selectedItem.Tag, proc.ProcessInstanceItem).ProcessName
                Else
                    procName = selectedItem.Text
                End If

                If Not String.IsNullOrEmpty(procName) Then
                    Dim url As String = "https://www.google.com/search?q=" & Uri.EscapeDataString(procName)
                    Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
                End If
            Next
        End If
    End Sub

    Private Sub SearchVirusTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchVirusTotalToolStripMenuItem.Click
        If NsListView1.SelectedItems IsNot Nothing AndAlso NsListView1.SelectedItems.Length > 0 Then
            For Each selectedItem As NSListView.NSListViewItem In NsListView1.SelectedItems
                Dim procName As String = ""
                If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                    procName = DirectCast(selectedItem.Tag, proc.ProcessGroupItem).ProcessName
                ElseIf TypeOf selectedItem.Tag Is proc.ProcessInstanceItem Then
                    procName = DirectCast(selectedItem.Tag, proc.ProcessInstanceItem).ProcessName
                Else
                    procName = selectedItem.Text
                End If

                If Not String.IsNullOrEmpty(procName) Then
                    Dim url As String = "https://www.virustotal.com/gui/search/" & Uri.EscapeDataString(procName)
                    Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
                End If
            Next
        End If
    End Sub
End Class