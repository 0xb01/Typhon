Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

''' <summary>
''' Ultra-compact, draggable floating in-game performance overlay displaying real-time telemetry.
''' </summary>
Public Class WinHUD

    Private _proc As New proc()

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub WinHUD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenBounds As Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Location = New Point(screenBounds.Right - Me.Width - 15, screenBounds.Top + 15)
        UpdateTelemetry()
    End Sub

    Private Sub WinHUD_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, lblTitle.MouseDown, lblStatus.MouseDown, lblStats.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub timerHUD_Tick(sender As Object, e As EventArgs) Handles timerHUD.Tick
        UpdateTelemetry()
    End Sub

    Private Sub UpdateTelemetry()
        Try
            Dim cpuVal As Integer = _proc.GetCPUPercentage()
            Dim gpuVal As Integer = _proc.GetGPUPercentage()
            Dim ramVal As String = _proc.GetRAMPercentage()
            Dim timerVal As Double = proc.GetCurrentTimerResolution()

            lblStats.Text = String.Format("CPU {0}%  GPU {1}%  RAM {2}%  {3:0.#}ms", cpuVal, gpuVal, ramVal, timerVal)

            If gaming.IsBoostActive Then
                lblStatus.Text = "● BOOSTED"
                lblStatus.ForeColor = Color.FromArgb(80, 240, 140) ' Green
            Else
                lblStatus.Text = "● STANDBY"
                lblStatus.ForeColor = Color.FromArgb(135, 195, 250) ' Blue
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        Using p As New Pen(Color.FromArgb(60, 60, 60))
            g.DrawRectangle(p, 0, 0, Width - 1, Height - 1)
        End Using
        Using pAccent As New Pen(Color.FromArgb(80, 200, 255), 2)
            g.DrawLine(pAccent, 0, 1, Width, 1)
        End Using
    End Sub

End Class
