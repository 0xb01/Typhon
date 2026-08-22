Imports System.Drawing
Imports System.Threading.Tasks

''' <summary>
''' Process killer form featuring collapsible process family grouping, RAM usage sorting, exception management, and selective termination.
''' </summary>
Public Class WinKill

    Private _proc As proc = New proc()
    Private _groups As New List(Of proc.ProcessGroupItem)()
    Private _sortColumn As Integer = 1 ' Default sort by RAM (Column 1)
    Private _sortAscending As Boolean = False ' Default descending (heaviest RAM first)

    Private _isKilling As Boolean = False
    Private _cancelRequested As Boolean = False
    Private _hasCompleted As Boolean = False

    ''' <summary>
    ''' Form load event handler populating listview with collapsible process groups and resetting form state.
    ''' </summary>
    Private Sub WinKill_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        _isKilling = False
        _cancelRequested = False
        _hasCompleted = False
        btnAction.Text = "Terminate"
        lblDescription.Text = "Select background and child processes to terminate to recover system resources." & vbCrLf & vbCrLf & "Please save any unsaved work before proceeding."
        _groups = _proc.GetKillableProcessGroups(WinMain.ProcessIgnoreList)
        RenderListView()
    End Sub

    ''' <summary>
    ''' Re-renders the listview items based on current process groups, expansion states, exception flags, and sorting preferences.
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
        Dim exemptCount As Integer = 0

        For Each grp As proc.ProcessGroupItem In _groups
            totalProcesses += grp.InstanceCount
            totalBytes += grp.TotalBytes
            If grp.IsIgnored OrElse grp.IsSelf Then exemptCount += grp.InstanceCount

            ' Group Parent Item
            Dim expandPrefix As String = If(grp.InstanceCount > 1, If(grp.IsExpanded, "[-] ", "[+] "), "    ")
            Dim parentText As String = expandPrefix & grp.ProcessName & If(grp.InstanceCount > 1, " (" & grp.InstanceCount & ")", "")
            Dim parentIcon As Image = If(grp.Instances.Count > 0, proc.GetProcessIcon(grp.Instances(0).FullPath), proc.DefaultProcessIcon)

            Dim parentLvi As New NSListView.NSListViewItem() With {
                .Text = parentText,
                .Checked = grp.Checked,
                .Icon = parentIcon,
                .Tag = grp
            }

            If grp.IsSelf Then
                parentLvi.TextColor = Color.FromArgb(80, 200, 255) ' Bright Cyan (Typhon / Protected)
            ElseIf grp.IsIgnored Then
                parentLvi.TextColor = Color.FromArgb(135, 195, 250) ' Soft Ice Blue (Exceptions / Ignored)
            End If

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

                    If inst.IsSelf Then
                        childLvi.TextColor = Color.FromArgb(80, 200, 255)
                    ElseIf inst.IsIgnored Then
                        childLvi.TextColor = Color.FromArgb(135, 195, 250)
                    End If

                    childLvi.SubItems.Add(New NSListView.NSListViewSubItem() With {.Text = cleaner.FormatBytes(inst.MemoryBytes)})
                    itemList.Add(childLvi)
                Next
            End If
        Next

        lvProcesses.Items = itemList.ToArray()

        If Not _isKilling AndAlso Not _hasCompleted Then
            lblSummary.Value1 = "Summary:"
            lblSummary.Value2 = Space(1) & totalProcesses & " processes (" & cleaner.FormatBytes(totalBytes) & ")" & If(exemptCount > 0, " | " & exemptCount & " exempt", "")
        End If
    End Sub

    ''' <summary>
    ''' Column click handler toggling sort direction by Process Name or RAM footprint.
    ''' </summary>
    Private Sub lvProcesses_ColumnClick(sender As Object, columnIndex As Integer) Handles lvProcesses.ColumnClick
        If _isKilling Then Return
        If _sortColumn = columnIndex Then
            _sortAscending = Not _sortAscending
        Else
            _sortColumn = columnIndex
            _sortAscending = True
        End If
        RenderListView()
    End Sub

    ''' <summary>
    ''' Handles expansion toggling and checkbox state synchronization with Typhon protection.
    ''' </summary>
    Private Sub lvProcesses_MouseDown(sender As Object, e As MouseEventArgs) Handles lvProcesses.MouseDown
        If _isKilling Then Return
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If lvProcesses.SelectedItems IsNot Nothing AndAlso lvProcesses.SelectedItems.Length > 0 Then
                Dim selectedItem As NSListView.NSListViewItem = lvProcesses.SelectedItems(0)

                If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                    Dim grp As proc.ProcessGroupItem = DirectCast(selectedItem.Tag, proc.ProcessGroupItem)
                    If e.X <= 24 Then
                        If grp.IsSelf Then
                            ' Typhon is strictly unkillable/protected
                            grp.Checked = False
                            selectedItem.Checked = False
                            RenderListView()
                            Return
                        End If

                        grp.Checked = selectedItem.Checked
                        For Each inst As proc.ProcessInstanceItem In grp.Instances
                            If Not inst.IsSelf Then
                                inst.Checked = grp.Checked
                            End If
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
                    If inst.IsSelf Then
                        inst.Checked = False
                        selectedItem.Checked = False
                        RenderListView()
                        Return
                    End If

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
    ''' Click event handler initiating confirmation dialog and asynchronous process termination.
    ''' </summary>
    Private Async Sub btnAction_Click(sender As System.Object, e As System.EventArgs) Handles btnAction.Click
        If _hasCompleted Then
            Me.Close()
            Return
        End If

        If _isKilling Then
            _cancelRequested = True
            lblDescription.Text = "Cancelling..."
            Return
        End If

        ' Collect checked instances (strictly excluding Typhon / IsSelf)
        Dim targets As New List(Of proc.ProcessInstanceItem)()
        For Each grp As proc.ProcessGroupItem In _groups
            If grp.IsSelf Then Continue For
            For Each inst As proc.ProcessInstanceItem In grp.Instances
                If inst.Checked AndAlso Not inst.IsSelf AndAlso Not inst.ProcessName.Equals("Typhon.exe", StringComparison.OrdinalIgnoreCase) Then
                    targets.Add(inst)
                End If
            Next
        Next

        If targets.Count = 0 Then
            DialogMessage.Show(Me, "No processes selected to terminate.", "Notice", MessageBoxButtons.OK)
            Return
        End If

        Dim confirmMsg As String = "Are you sure you want to terminate " & targets.Count & " selected process(es)?" & vbCrLf & vbCrLf & "Any unsaved data in these processes will be lost."
        If DialogMessage.Show(Me, confirmMsg, "Confirm Termination", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            Return
        End If

        _isKilling = True
        _cancelRequested = False
        _hasCompleted = False
        btnAction.Text = "Cancel"

        Dim killedCount As Integer = 0
        Dim failedCount As Integer = 0
        Dim totalChecked As Integer = targets.Count

        For Each inst As proc.ProcessInstanceItem In targets
            If _cancelRequested Then Exit For

            lblDescription.Text = "Terminating: " & inst.ProcessName & " (" & inst.ProcessId & ")"
            Dim pid As Integer = inst.ProcessId

            Dim success As Boolean = Await Task.Run(Function()
                                                        Try
                                                            Dim p As Process = Process.GetProcessById(pid)
                                                            Dim res As Boolean = proc.SafeKillProcess(p)
                                                            p.Dispose()
                                                            Return res
                                                        Catch ex As Exception
                                                            Return False
                                                        End Try
                                                    End Function)

            If success Then
                killedCount += 1
                Dim parentGrp As proc.ProcessGroupItem = _groups.Find(Function(g) g.Instances.Contains(inst))
                If parentGrp IsNot Nothing Then
                    parentGrp.Instances.Remove(inst)
                    If parentGrp.Instances.Count = 0 Then
                        _groups.Remove(parentGrp)
                    End If
                End If
                RenderListView()
            Else
                failedCount += 1
            End If

            If _cancelRequested Then Exit For
            Await Task.Delay(25)
        Next

        _isKilling = False
        _hasCompleted = True

        If _cancelRequested Then
            lblDescription.Text = "Cancelled"
        Else
            lblDescription.Text = "Completed"
        End If

        lblSummary.Value1 = "Summary:"
        lblSummary.Value2 = Space(1) & "Terminated " & killedCount & " of " & totalChecked & " process" & If(totalChecked = 1, "", "es") & If(failedCount > 0, " (" & failedCount & " locked/in-use)", "")

        btnAction.Text = "Close"
    End Sub

    ''' <summary>
    ''' Context menu handler selecting all non-ignored and non-self process groups and instances.
    ''' </summary>
    Private Sub menuSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles menuSelectAll.Click
        If _isKilling Then Return
        For Each grp As proc.ProcessGroupItem In _groups
            If Not grp.IsIgnored AndAlso Not grp.IsSelf Then
                grp.Checked = True
                For Each inst As proc.ProcessInstanceItem In grp.Instances
                    If Not inst.IsIgnored AndAlso Not inst.IsSelf Then
                        inst.Checked = True
                    End If
                Next
            End If
        Next
        RenderListView()
    End Sub

    ''' <summary>
    ''' Context menu handler deselecting all process groups and instances.
    ''' </summary>
    Private Sub menuDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles menuDeselectAll.Click
        If _isKilling Then Return
        For Each grp As proc.ProcessGroupItem In _groups
            grp.Checked = False
            For Each inst As proc.ProcessInstanceItem In grp.Instances
                inst.Checked = False
            Next
        Next
        RenderListView()
    End Sub

    ''' <summary>
    ''' Dynamic context menu opening handler configuring exception toggle text and Typhon protection state.
    ''' </summary>
    Private Sub ctxProcessMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxProcessMenu.Opening
        If _isKilling Then
            e.Cancel = True
            Return
        End If

        If lvProcesses.SelectedItems IsNot Nothing AndAlso lvProcesses.SelectedItems.Length > 0 Then
            Dim selectedItem As NSListView.NSListViewItem = lvProcesses.SelectedItems(0)
            Dim isSelf As Boolean = False
            Dim isIgnored As Boolean = False

            If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                Dim grp As proc.ProcessGroupItem = DirectCast(selectedItem.Tag, proc.ProcessGroupItem)
                isSelf = grp.IsSelf
                isIgnored = grp.IsIgnored
            ElseIf TypeOf selectedItem.Tag Is proc.ProcessInstanceItem Then
                Dim inst = DirectCast(selectedItem.Tag, proc.ProcessInstanceItem)
                isSelf = inst.IsSelf
                isIgnored = inst.IsIgnored
            End If

            If isSelf Then
                menuToggleException.Text = "Protected (Typhon)"
                menuToggleException.Enabled = False
            ElseIf isIgnored Then
                menuToggleException.Text = "Remove from Exceptions"
                menuToggleException.Enabled = True
            Else
                menuToggleException.Text = "Add to Exceptions"
                menuToggleException.Enabled = True
            End If
        Else
            menuToggleException.Text = "Add to Exceptions"
            menuToggleException.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Context menu handler toggling exception ignore status for selected process executable.
    ''' </summary>
    Private Sub menuToggleException_Click(sender As System.Object, e As System.EventArgs) Handles menuToggleException.Click
        If _isKilling Then Return
        If lvProcesses.SelectedItems IsNot Nothing AndAlso lvProcesses.SelectedItems.Length > 0 Then
            For Each selectedItem As NSListView.NSListViewItem In lvProcesses.SelectedItems
                Dim procName As String = ""
                Dim isSelf As Boolean = False
                Dim isIgnored As Boolean = False

                If TypeOf selectedItem.Tag Is proc.ProcessGroupItem Then
                    Dim grp As proc.ProcessGroupItem = DirectCast(selectedItem.Tag, proc.ProcessGroupItem)
                    procName = grp.ProcessName
                    isSelf = grp.IsSelf
                    isIgnored = grp.IsIgnored
                ElseIf TypeOf selectedItem.Tag Is proc.ProcessInstanceItem Then
                    Dim inst As proc.ProcessInstanceItem = DirectCast(selectedItem.Tag, proc.ProcessInstanceItem)
                    procName = inst.ProcessName
                    isSelf = inst.IsSelf
                    isIgnored = inst.IsIgnored
                End If

                If isSelf OrElse String.IsNullOrEmpty(procName) Then Continue For

                If isIgnored Then
                    ' Remove from ignore list
                    Dim toRemove As New List(Of String)()
                    Dim targetCol As New Specialized.StringCollection() From {procName}
                    For Each item As String In WinMain.ProcessIgnoreList
                        If proc.IsProcessIgnored(item, targetCol) Then
                            toRemove.Add(item)
                        End If
                    Next
                    For Each item In toRemove
                        WinMain.ProcessIgnoreList.Remove(item)
                    Next
                Else
                    ' Add to ignore list
                    If Not proc.IsProcessIgnored(procName, WinMain.ProcessIgnoreList) Then
                        WinMain.ProcessIgnoreList.Add(procName)
                    End If
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
    Private Sub btnControlClose_Click(sender As System.Object, e As System.EventArgs) Handles btnControlClose.Click
        If _isKilling Then
            _cancelRequested = True
        End If
        My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub WinKill_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _isKilling Then
            _cancelRequested = True
        End If
    End Sub

    Private Sub menuSearchGoogle_Click(sender As Object, e As EventArgs) Handles menuSearchGoogle.Click
        If _isKilling Then Return
        If lvProcesses.SelectedItems IsNot Nothing AndAlso lvProcesses.SelectedItems.Length > 0 Then
            For Each selectedItem As NSListView.NSListViewItem In lvProcesses.SelectedItems
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

    Private Sub menuSearchVirusTotal_Click(sender As Object, e As EventArgs) Handles menuSearchVirusTotal.Click
        If _isKilling Then Return
        If lvProcesses.SelectedItems IsNot Nothing AndAlso lvProcesses.SelectedItems.Length > 0 Then
            For Each selectedItem As NSListView.NSListViewItem In lvProcesses.SelectedItems
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