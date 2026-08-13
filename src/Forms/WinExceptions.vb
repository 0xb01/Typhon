''' <summary>
''' Process exceptions window displaying excluded processes with ability to add or remove entries.
''' </summary>
Public Class WinExceptions

    ''' <summary>
    ''' Form load event handler populating listview with saved process exceptions.
    ''' </summary>
    Private Sub WinExceptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshExceptionsList()
    End Sub

    ''' <summary>
    ''' Populates NSListView with current process ignore list items.
    ''' </summary>
    Private Sub RefreshExceptionsList()
        Dim itemList As New List(Of NSListView.NSListViewItem)()

        If WinMain.ProcessIgnoreList IsNot Nothing Then
            For Each exeName As String In WinMain.ProcessIgnoreList
                If Not String.IsNullOrEmpty(exeName) Then
                    Dim lvi As New NSListView.NSListViewItem() With {
                        .Text = exeName
                    }
                    itemList.Add(lvi)
                End If
            Next
        End If

        NsListView1.Items = itemList.ToArray()
    End Sub

    ''' <summary>
    ''' Removes selected process exception(s) from ignore list and persists settings.
    ''' </summary>
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If NsListView1.SelectedItems IsNot Nothing AndAlso NsListView1.SelectedItems.Length > 0 Then
            For Each item As NSListView.NSListViewItem In NsListView1.SelectedItems
                Dim exeName As String = item.Text
                If WinMain.ProcessIgnoreList.Contains(exeName) Then
                    WinMain.ProcessIgnoreList.Remove(exeName)
                End If
            Next

            My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
            My.Settings.Save()
            RefreshExceptionsList()
        End If
    End Sub

    ''' <summary>
    ''' Adds typed executable name to exceptions list.
    ''' </summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim exeName As String = txtExeName.Text.Trim()
        If Not String.IsNullOrEmpty(exeName) Then
            If Not exeName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
                exeName &= ".exe"
            End If

            If Not WinMain.ProcessIgnoreList.Contains(exeName) Then
                WinMain.ProcessIgnoreList.Add(exeName)
                My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
                My.Settings.Save()
                txtExeName.Text = ""
                RefreshExceptionsList()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Close button event handler.
    ''' </summary>
    Private Sub NsControlButton1_Click(sender As Object, e As EventArgs) Handles NsControlButton1.Click
        Me.Close()
    End Sub

End Class
