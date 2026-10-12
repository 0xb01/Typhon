Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Windows.Forms

''' <summary>
''' Disk Selector dialog enumerating available system drives using custom NSListView and letting user choose target disks.
''' </summary>
Public Class WinDiskSelector

    ''' <summary>
    ''' Gets or sets the list of selected drive root paths (e.g. C:\, D:\).
    ''' </summary>
    Public Property SelectedDrives As New List(Of String)()

    Private Shared Function FormatBytes(bytes As Long) As String
        Dim sizes() As String = {"B", "KB", "MB", "GB", "TB"}
        Dim dblBytes As Double = CDbl(bytes)
        Dim i As Integer = 0
        While dblBytes >= 1024.0 AndAlso i < sizes.Length - 1
            dblBytes /= 1024.0
            i += 1
        End While
        Return dblBytes.ToString("F1") & " " & sizes(i)
    End Function

    Private Sub WinDiskSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvDrives.Clear()

        lvDrives.CheckBoxes = True
        lvDrives.AddColumn("Drive", 140)
        lvDrives.AddColumn("Format", 70)
        lvDrives.AddColumn("Free / Total Space", 145)

        Dim driveItems As New List(Of NSListView.NSListViewItem)()

        For Each drv As DriveInfo In DriveInfo.GetDrives()
            Try
                If drv.IsReady Then
                    Dim label As String = If(String.IsNullOrEmpty(drv.VolumeLabel), drv.DriveType.ToString(), drv.VolumeLabel)
                    Dim title As String = label & " (" & drv.Name.TrimEnd("\"c) & ")"
                    Dim fmt As String = drv.DriveFormat
                    Dim spaceInfo As String = FormatBytes(drv.AvailableFreeSpace) & " / " & FormatBytes(drv.TotalSize)

                    Dim subItemsList As New List(Of NSListView.NSListViewSubItem)()
                    subItemsList.Add(New NSListView.NSListViewSubItem With {.Text = fmt})
                    subItemsList.Add(New NSListView.NSListViewSubItem With {.Text = spaceInfo})

                    Dim item As New NSListView.NSListViewItem With {
                        .Text = title,
                        .SubItems = subItemsList,
                        .Tag = drv.Name,
                        .Checked = (drv.DriveType = DriveType.Fixed)
                    }

                    driveItems.Add(item)
                End If
            Catch ex As Exception
                ' Skip unready drives
            End Try
        Next

        If driveItems.Count > 0 Then
            lvDrives.AddItems(driveItems)
        End If
    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        SelectedDrives.Clear()

        If lvDrives.CheckedItems IsNot Nothing AndAlso lvDrives.CheckedItems.Count > 0 Then
            For Each item As NSListView.NSListViewItem In lvDrives.CheckedItems
                If item.Tag IsNot Nothing Then
                    SelectedDrives.Add(item.Tag.ToString())
                End If
            Next
        ElseIf lvDrives.SelectedItems IsNot Nothing AndAlso lvDrives.SelectedItems.Count > 0 Then
            For Each item As NSListView.NSListViewItem In lvDrives.SelectedItems
                If item.Tag IsNot Nothing Then
                    SelectedDrives.Add(item.Tag.ToString())
                End If
            Next
        End If

        ' Default to all drives if none explicitly checked/selected
        If SelectedDrives.Count = 0 AndAlso lvDrives.Items IsNot Nothing Then
            For Each item As NSListView.NSListViewItem In lvDrives.Items
                If item.Tag IsNot Nothing Then
                    SelectedDrives.Add(item.Tag.ToString())
                End If
            Next
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnControlClose_Click(sender As Object, e As EventArgs) Handles btnControlClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
