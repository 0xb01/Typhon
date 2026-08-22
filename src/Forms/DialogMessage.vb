Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Themed dark modal confirmation and message dialog matching the Typhon NSTheme interface with full Windows Form Designer integration.
''' </summary>
Public Class DialogMessage

    ''' <summary>
    ''' Displays a dark themed message box with the specified owner, message, title, and buttons.
    ''' </summary>
    Public Overloads Shared Function Show(owner As IWin32Window, message As String, Optional title As String = "Confirm", Optional buttons As MessageBoxButtons = MessageBoxButtons.YesNo) As DialogResult
        Using dlg As New DialogMessage(message, title, buttons)
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

    Private _buttons As MessageBoxButtons

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(message As String, title As String, buttons As MessageBoxButtons)
        Me.New()
        _buttons = buttons
        themeContainer.Text = title
        Me.Text = title
        lblMessage.Text = message

        If buttons = MessageBoxButtons.YesNo Then
            btnPrimary.Text = "Yes"
            btnPrimary.Visible = True
            btnPrimary.Location = New Point(125, 118)

            btnSecondary.Text = "No"
            btnSecondary.Visible = True
            btnSecondary.Location = New Point(230, 118)
        ElseIf buttons = MessageBoxButtons.OKCancel Then
            btnPrimary.Text = "OK"
            btnPrimary.Visible = True
            btnPrimary.Location = New Point(125, 118)

            btnSecondary.Text = "Cancel"
            btnSecondary.Visible = True
            btnSecondary.Location = New Point(230, 118)
        Else
            btnPrimary.Visible = False
            btnSecondary.Text = "OK"
            btnSecondary.Visible = True
            btnSecondary.Location = New Point(230, 118)
        End If
    End Sub

    Private Sub btnPrimary_Click(sender As Object, e As EventArgs) Handles btnPrimary.Click
        If _buttons = MessageBoxButtons.YesNo Then
            Me.DialogResult = DialogResult.Yes
        Else
            Me.DialogResult = DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub btnSecondary_Click(sender As Object, e As EventArgs) Handles btnSecondary.Click
        If _buttons = MessageBoxButtons.YesNo Then
            Me.DialogResult = DialogResult.No
        ElseIf _buttons = MessageBoxButtons.OKCancel Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me.DialogResult = DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub btnControlClose_Click(sender As Object, e As EventArgs) Handles btnControlClose.Click
        If _buttons = MessageBoxButtons.YesNo Then
            Me.DialogResult = DialogResult.No
        ElseIf _buttons = MessageBoxButtons.OKCancel Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me.DialogResult = DialogResult.OK
        End If
        Me.Close()
    End Sub

End Class
