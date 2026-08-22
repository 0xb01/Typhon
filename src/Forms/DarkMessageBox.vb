Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Themed dark modal confirmation and message dialog matching the Typhon NSTheme interface.
''' </summary>
Public Class DarkMessageBox
    Inherits Form

    ''' <summary>
    ''' Displays a dark themed message box with the specified owner, message, title, and buttons.
    ''' </summary>
    Public Overloads Shared Function Show(owner As IWin32Window, message As String, Optional title As String = "Confirm", Optional buttons As MessageBoxButtons = MessageBoxButtons.YesNo) As DialogResult
        Using dlg As New DarkMessageBox(message, title, buttons)
            If owner IsNot Nothing Then
                Return dlg.ShowDialog(owner)
            Else
                Return dlg.ShowDialog()
            End If
        End Using
    End Function

    ''' <summary>
    ''' Displays a dark themed message box with the specified message, title, and buttons.
    ''' </summary>
    Public Overloads Shared Function Show(message As String, Optional title As String = "Confirm", Optional buttons As MessageBoxButtons = MessageBoxButtons.YesNo) As DialogResult
        Return Show(Nothing, message, title, buttons)
    End Function

    Public Sub New(message As String, title As String, buttons As MessageBoxButtons)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(340, 160)
        Me.ShowInTaskbar = False
        Me.DoubleBuffered = True

        Dim theme As New NSTheme() With {
            .Text = title,
            .Dock = DockStyle.Fill,
            .StartPosition = FormStartPosition.CenterParent,
            .Sizable = False,
            .Movable = True
        }

        Dim closeBtn As New NSControlButton() With {
            .ControlButton = NSControlButton.Button.Close,
            .Location = New Point(317, 5),
            .Size = New Size(18, 20)
        }
        AddHandler closeBtn.Click, Sub(s, e)
                                       Me.DialogResult = If(buttons = MessageBoxButtons.YesNo, DialogResult.No, DialogResult.Cancel)
                                       Me.Close()
                                   End Sub
        theme.Controls.Add(closeBtn)

        Dim lblMsg As New Label() With {
            .Text = message,
            .ForeColor = Color.White,
            .Font = New Font("Verdana", 8.25!, FontStyle.Regular),
            .Location = New Point(16, 38),
            .Size = New Size(308, 70),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        theme.Controls.Add(lblMsg)

        If buttons = MessageBoxButtons.YesNo Then
            Dim btnYes As New NSButton() With {
                .Text = "Yes();",
                .Location = New Point(125, 118),
                .Size = New Size(95, 26)
            }
            AddHandler btnYes.Click, Sub(s, e)
                                         Me.DialogResult = DialogResult.Yes
                                         Me.Close()
                                     End Sub
            theme.Controls.Add(btnYes)

            Dim btnNo As New NSButton() With {
                .Text = "No();",
                .Location = New Point(230, 118),
                .Size = New Size(95, 26)
            }
            AddHandler btnNo.Click, Sub(s, e)
                                        Me.DialogResult = DialogResult.No
                                        Me.Close()
                                    End Sub
            theme.Controls.Add(btnNo)
        ElseIf buttons = MessageBoxButtons.OKCancel Then
            Dim btnOk As New NSButton() With {
                .Text = "OK();",
                .Location = New Point(125, 118),
                .Size = New Size(95, 26)
            }
            AddHandler btnOk.Click, Sub(s, e)
                                        Me.DialogResult = DialogResult.OK
                                        Me.Close()
                                    End Sub
            theme.Controls.Add(btnOk)

            Dim btnCancel As New NSButton() With {
                .Text = "Cancel();",
                .Location = New Point(230, 118),
                .Size = New Size(95, 26)
            }
            AddHandler btnCancel.Click, Sub(s, e)
                                            Me.DialogResult = DialogResult.Cancel
                                            Me.Close()
                                        End Sub
            theme.Controls.Add(btnCancel)
        Else
            Dim btnOk As New NSButton() With {
                .Text = "OK();",
                .Location = New Point(230, 118),
                .Size = New Size(95, 26)
            }
            AddHandler btnOk.Click, Sub(s, e)
                                        Me.DialogResult = DialogResult.OK
                                        Me.Close()
                                    End Sub
            theme.Controls.Add(btnOk)
        End If

        Me.Controls.Add(theme)
    End Sub

End Class
