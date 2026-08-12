''' <summary>
''' Process killer form enabling process scanning, termination, and process exclusion management.
''' </summary>
Public Class WinKill

    Private _proc As proc = New proc()

    ''' <summary>
    ''' Form load event handler populating listbox with non-ignored killable processes.
    ''' </summary>
    Private Sub WinKill_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim processes() As String = _proc.GetKillableProcesses(WinMain.ProcessIgnoreList)
        ListBox1.Items.Clear()
        For Each procName As String In processes
            ListBox1.Items.Add(procName)
        Next
    End Sub

    ''' <summary>
    ''' Click event handler terminating displayed killable background processes.
    ''' </summary>
    Private Sub NsButton1_Click(sender As System.Object, e As System.EventArgs) Handles NsButton1.Click
        WinMain.NsLabel3.Value1 = "~X:"
        WinMain.NsLabel3.Value2 = Space(1) & "Killed " & _proc.KillProcesses(WinMain.ProcessIgnoreList) & " processes"
        WinMain.cooldownTimer.Start()

        Me.Close()
    End Sub

    ''' <summary>
    ''' Context menu item click handler adding the selected process executable to the ignore list.
    ''' </summary>
    Private Sub AddToIgnoreListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToIgnoreListToolStripMenuItem.Click
        If ListBox1.SelectedItem IsNot Nothing Then
            Dim selectedValue As String = ListBox1.SelectedItem.ToString()
            If Not WinMain.ProcessIgnoreList.Contains(selectedValue) Then
                WinMain.ProcessIgnoreList.Add(selectedValue)
            End If

            For i As Integer = ListBox1.Items.Count - 1 To 0 Step -1
                Dim currentItem As String = ListBox1.Items(i).ToString()
                If currentItem = selectedValue Then
                    ListBox1.Items.RemoveAt(i)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Control button click handler saving current process ignore list settings to application configuration.
    ''' </summary>
    Private Sub NsControlButton1_Click(sender As System.Object, e As System.EventArgs) Handles NsControlButton1.Click
        My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
        My.Settings.Save()
    End Sub
End Class