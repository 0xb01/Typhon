Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Themed dark modal confirmation and message dialog matching the Typhon NSTheme interface with full Windows Form Designer integration.
''' </summary>
Public Class DarkMessageBox

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

    Private _buttons As MessageBoxButtons

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(message As String, title As String, buttons As MessageBoxButtons)
        Me.New()
        _buttons = buttons
        NsTheme1.Text = title
        Me.Text = title
        lblMessage.Text = message

        If buttons = MessageBoxButtons.YesNo Then
            btnOption1.Text = "Yes();"
            btnOption1.Visible = True
            btnOption1.Location = New Point(125, 118)

            btnOption2.Text = "No();"
            btnOption2.Visible = True
            btnOption2.Location = New Point(230, 118)
        ElseIf buttons = MessageBoxButtons.OKCancel Then
            btnOption1.Text = "OK();"
            btnOption1.Visible = True
            btnOption1.Location = New Point(125, 118)

            btnOption2.Text = "Cancel();"
            btnOption2.Visible = True
            btnOption2.Location = New Point(230, 118)
        Else
            btnOption1.Visible = False
            btnOption2.Text = "OK();"
            btnOption2.Visible = True
            btnOption2.Location = New Point(230, 118)
        End If
    End Sub

    Private Sub btnOption1_Click(sender As Object, e As EventArgs) Handles btnOption1.Click
        If _buttons = MessageBoxButtons.YesNo Then
            Me.DialogResult = DialogResult.Yes
        Else
            Me.DialogResult = DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub btnOption2_Click(sender As Object, e As EventArgs) Handles btnOption2.Click
        If _buttons = MessageBoxButtons.YesNo Then
            Me.DialogResult = DialogResult.No
        ElseIf _buttons = MessageBoxButtons.OKCancel Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me.DialogResult = DialogResult.OK
        End If
        Me.Close()
    End Sub

    Private Sub NsControlButton1_Click(sender As Object, e As EventArgs) Handles NsControlButton1.Click
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
