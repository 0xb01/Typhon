Imports System.Threading.Tasks

''' <summary>
''' Process exceptions window displaying excluded processes with ability to add or remove entries.
''' </summary>
Public Class WinExceptions

    ''' <summary>
    ''' Form load event handler populating listview with saved process exceptions.
    ''' </summary>
    Private Async Sub WinExceptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Instant render with known exceptions
        RefreshExceptionsList(False)

        ' Async background load for icons and running process list
        Await Task.Run(Sub()
                           PopulateRunningProcesses()
                       End Sub)

        If Me.IsDisposed OrElse Not Me.IsHandleCreated Then Return
        RefreshExceptionsList(True)
    End Sub

    ''' <summary>
    ''' Populates cboRunningProcesses with running non-critical system process executable names.
    ''' </summary>
    Private Sub PopulateRunningProcesses()
        Dim processNames As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        Try
            Dim procs = Process.GetProcesses()
            For Each p In procs
                Try
                    Dim exeName As String = ""
                    Try
                        exeName = p.MainModule.ModuleName
                    Catch
                        exeName = p.ProcessName
                        If Not exeName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
                            exeName &= ".exe"
                        End If
                    End Try

                    If Not String.IsNullOrEmpty(exeName) AndAlso Not processNames.Contains(exeName) Then
                        processNames.Add(exeName)
                    End If
                Catch
                Finally
                    p.Dispose()
                End Try
            Next

            Dim sortedList = processNames.OrderBy(Function(s) s, StringComparer.OrdinalIgnoreCase).ToList()
            If Me.IsHandleCreated AndAlso Not Me.IsDisposed Then
                Me.BeginInvoke(Sub()
                                   cboRunningProcesses.Items.Clear()
                                   For Each procName As String In sortedList
                                       cboRunningProcesses.Items.Add(procName)
                                   Next
                               End Sub)
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Populates NSListView with current process ignore list items.
    ''' </summary>
    Private Sub RefreshExceptionsList(Optional loadIcons As Boolean = True)
        Dim itemList As New List(Of NSListView.NSListViewItem)()

        If WinMain.ProcessIgnoreList IsNot Nothing Then
            For Each exeName As String In WinMain.ProcessIgnoreList
                If Not String.IsNullOrEmpty(exeName) Then
                    Dim lvi As New NSListView.NSListViewItem() With {
                        .Text = exeName,
                        .Icon = If(loadIcons, proc.GetExeIcon(exeName), Nothing)
                    }
                    itemList.Add(lvi)
                End If
            Next
        End If

        lvExceptions.Items = itemList.ToArray()
    End Sub

    ''' <summary>
    ''' Removes selected process exception(s) from ignore list and persists settings.
    ''' </summary>
    Private Sub btnRemoveException_Click(sender As Object, e As EventArgs) Handles btnRemoveException.Click
        If lvExceptions.SelectedItems IsNot Nothing AndAlso lvExceptions.SelectedItems.Length > 0 Then
            For Each item As NSListView.NSListViewItem In lvExceptions.SelectedItems
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
    ''' Adds chosen executable from dropdown or typed in custom textbox to exceptions list.
    ''' </summary>
    Private Sub btnAddException_Click(sender As Object, e As EventArgs) Handles btnAddException.Click
        Dim exeName As String = txtCustomExecutable.Text.Trim()
        If String.IsNullOrEmpty(exeName) AndAlso cboRunningProcesses.SelectedItem IsNot Nothing Then
            exeName = cboRunningProcesses.SelectedItem.ToString().Trim()
        End If

        If Not String.IsNullOrEmpty(exeName) Then
            If Not exeName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
                exeName &= ".exe"
            End If

            If Not WinMain.ProcessIgnoreList.Contains(exeName) Then
                WinMain.ProcessIgnoreList.Add(exeName)
                My.Settings.IgnoreProcessList = WinMain.ProcessIgnoreList
                My.Settings.Save()
                txtCustomExecutable.Text = ""
                cboRunningProcesses.SelectedIndex = -1
                RefreshExceptionsList()
            End If
        End If
    End Sub

    ''' <summary>
    ''' When a process is selected in the combobox, populate the custom textbox for editing.
    ''' </summary>
    Private Sub cboRunningProcesses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRunningProcesses.SelectedIndexChanged
        If cboRunningProcesses.SelectedItem IsNot Nothing Then
            txtCustomExecutable.Text = cboRunningProcesses.SelectedItem.ToString()
        End If
    End Sub

    ''' <summary>
    ''' Close button event handler.
    ''' </summary>
    Private Sub btnControlClose_Click(sender As Object, e As EventArgs) Handles btnControlClose.Click
        Me.Close()
    End Sub

    Private Sub ctxExceptionsMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxExceptionsMenu.Opening
        If lvExceptions.SelectedItems IsNot Nothing AndAlso lvExceptions.SelectedItems.Length > 0 Then
            Dim selectedExe As String = lvExceptions.SelectedItems(0).Text
            menuRemoveException.Visible = True
            menuRemoveException.Text = "Remove: " & selectedExe
            ToolStripSeparator1.Visible = True
            menuSearchGoogle.Text = "Search in Google: " & selectedExe
            menuSearchVirusTotal.Text = "Search in VirusTotal: " & selectedExe
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub menuRemoveException_Click(sender As Object, e As EventArgs) Handles menuRemoveException.Click
        btnRemoveException_Click(sender, e)
    End Sub

    Private Sub menuSearchGoogle_Click(sender As Object, e As EventArgs) Handles menuSearchGoogle.Click
        If lvExceptions.SelectedItems IsNot Nothing AndAlso lvExceptions.SelectedItems.Length > 0 Then
            For Each item As NSListView.NSListViewItem In lvExceptions.SelectedItems
                Dim exeName As String = item.Text
                If Not String.IsNullOrEmpty(exeName) Then
                    Dim url As String = "https://www.google.com/search?q=" & Uri.EscapeDataString(exeName)
                    Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
                End If
            Next
        End If
    End Sub

    Private Sub menuSearchVirusTotal_Click(sender As Object, e As EventArgs) Handles menuSearchVirusTotal.Click
        If lvExceptions.SelectedItems IsNot Nothing AndAlso lvExceptions.SelectedItems.Length > 0 Then
            For Each item As NSListView.NSListViewItem In lvExceptions.SelectedItems
                Dim exeName As String = item.Text
                If Not String.IsNullOrEmpty(exeName) Then
                    Dim url As String = "https://www.virustotal.com/gui/search/" & Uri.EscapeDataString(exeName)
                    Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
                End If
            Next
        End If
    End Sub

End Class
