Imports System
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports Typhon.NSListView

''' <summary>
''' Compact Game Booster window providing 1-click game optimization, tweaks, game library, and mini HUD.
''' </summary>
Public Class WinGameBoost

    Private _games As New List(Of gaming.GameItem)()
    Private _hudForm As WinHUD = Nothing
    Private _isLoadingGames As Boolean = False

    Private Sub WinGameBoost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Owner IsNot Nothing AndAlso Owner.Icon IsNot Nothing Then
                Me.Icon = Owner.Icon
            End If
        Catch ex As Exception
        End Try

        InitListViewColumns()
        LoadTweakSettings()
        UpdateBoostStatus()
        RefreshGameLibraryAsync()
    End Sub

    Private Sub InitListViewColumns()
        If lvGames.Columns.Length = 0 Then
            lvGames.AddColumn("Game Title", 160)
            lvGames.AddColumn("Platform", 65)
            lvGames.AddColumn("Executable", 150)
        End If
    End Sub

    Private Sub LoadTweakSettings()
        toggleTcpNoDelay.Checked = gaming.IsTcpNoDelayEnabled() AndAlso gaming.IsNetworkThrottlingDisabled()
        toggleGameDVR.Checked = gaming.IsGameDVRDisabled()
        toggleHighResTimer.Checked = (proc.GetCurrentTimerResolution() <= 1.0)
        toggleUltimatePower.Checked = True
    End Sub

    Private Sub UpdateBoostStatus()
        If gaming.IsBoostActive Then
            btnMasterBoost.Text = "⚡ BOOST ACTIVE"
            lblBoostStatus.Value1 = "Boost:"
            lblBoostStatus.Value2 = " 0.5ms Timer, Ultimate Plan, Standby Purged"
        Else
            btnMasterBoost.Text = "⚡ BOOST SYSTEM"
            lblBoostStatus.Value1 = "Status:"
            lblBoostStatus.Value2 = " Ready to optimize system"
        End If
    End Sub

    Private Sub RefreshGameLibraryAsync()
        If _isLoadingGames Then Return
        _isLoadingGames = True
        lblLibraryStatus.Value1 = "Library:"
        lblLibraryStatus.Value2 = " Scanning Steam, Epic, GOG..."
        lvGames.Clear()

        Task.Run(Sub()
                     Dim scanned = gaming.ScanAllGames()
                     If Not Me.IsDisposed AndAlso Me.IsHandleCreated Then
                         Me.BeginInvoke(Sub()
                                            If Not Me.IsDisposed Then
                                                _games = scanned
                                                PopulateGameList(_games)
                                                lblLibraryStatus.Value1 = "Library:"
                                                lblLibraryStatus.Value2 = " Found " & _games.Count & " installed game(s)"
                                                _isLoadingGames = False
                                            End If
                                        End Sub)
                     Else
                         _isLoadingGames = False
                     End If
                 End Sub)
    End Sub

    Private Sub PopulateGameList(gamesList As List(Of gaming.GameItem))
        lvGames.Clear()
        Dim itemsBatch As New List(Of NSListViewItem)()

        For Each gameEntry As gaming.GameItem In gamesList
            Dim itm As New NSListViewItem With {
                .Text = gameEntry.Name,
                .Icon = gameEntry.Icon,
                .Tag = gameEntry
            }
            itm.SubItems.Add(New NSListViewSubItem With {.Text = gameEntry.LauncherType})
            itm.SubItems.Add(New NSListViewSubItem With {.Text = If(Not String.IsNullOrEmpty(gameEntry.ExecutablePath), Path.GetFileName(gameEntry.ExecutablePath), gameEntry.LaunchCommand)})
            itemsBatch.Add(itm)
        Next

        lvGames.AddItems(itemsBatch)
    End Sub

    Private Sub btnMasterBoost_Click(sender As Object, e As EventArgs) Handles btnMasterBoost.Click
        If gaming.IsBoostActive Then
            gaming.DisengageGameBoost()
            UpdateBoostStatus()
        Else
            Dim report = gaming.EngageGameBoost(Nothing, WinMain.ProcessIgnoreList)
            UpdateBoostStatus()
            Dim freedStr = cleaner.FormatBytes(report.StandbyFreedBytes + report.ProcessTrimmedBytes)
            lblBoostStatus.Value1 = "Active:"
            lblBoostStatus.Value2 = " Freed " & freedStr & " | " & report.ThrottledProcessesCount & " apps throttled"
        End If
    End Sub

    Private Sub toggleHighResTimer_CheckedChanged(sender As Object) Handles toggleHighResTimer.CheckedChanged
        proc.SetHighResolutionTimer(toggleHighResTimer.Checked)
    End Sub

    Private Sub toggleUltimatePower_CheckedChanged(sender As Object) Handles toggleUltimatePower.CheckedChanged
        If toggleUltimatePower.Checked Then
            gaming.ActivateUltimatePowerPlan()
        End If
    End Sub

    Private Sub toggleTcpNoDelay_CheckedChanged(sender As Object) Handles toggleTcpNoDelay.CheckedChanged
        gaming.SetTcpNoDelay(toggleTcpNoDelay.Checked)
        gaming.SetNetworkThrottlingDisabled(toggleTcpNoDelay.Checked)
    End Sub

    Private Sub toggleGameDVR_CheckedChanged(sender As Object) Handles toggleGameDVR.CheckedChanged
        gaming.SetGameDVR(Not toggleGameDVR.Checked)
    End Sub

    Private Sub btnPurgeStandby_Click(sender As Object, e As EventArgs) Handles btnPurgeStandby.Click
        Dim freedBytes = proc.PurgeStandbyList()
        Dim freedStr = cleaner.FormatBytes(freedBytes)
        lblBoostStatus.Value1 = "Standby:"
        lblBoostStatus.Value2 = " Released " & freedStr & " cache memory"
    End Sub

    Private Sub btnFlushDNS_Click(sender As Object, e As EventArgs) Handles btnFlushDNS.Click
        gaming.FlushDns()
        lblBoostStatus.Value1 = "DNS:"
        lblBoostStatus.Value2 = " Cache flushed successfully"
    End Sub

    Private Async Sub btnTrimSSD_Click(sender As Object, e As EventArgs) Handles btnTrimSSD.Click
        btnTrimSSD.Enabled = False
        lblBoostStatus.Value1 = "SSD TRIM:"
        lblBoostStatus.Value2 = " Optimizing..."
        Dim ok = Await gaming.RunTrimAsync(Nothing)
        btnTrimSSD.Enabled = True
        lblBoostStatus.Value1 = "SSD TRIM:"
        lblBoostStatus.Value2 = If(ok, " Complete", " Done")
    End Sub

    Private Sub btnToggleHUD_Click(sender As Object, e As EventArgs) Handles btnToggleHUD.Click
        If _hudForm Is Nothing OrElse _hudForm.IsDisposed Then
            _hudForm = New WinHUD()
            _hudForm.Show()
        Else
            If _hudForm.Visible Then
                _hudForm.Hide()
            Else
                _hudForm.Show()
                _hudForm.BringToFront()
            End If
        End If
    End Sub

    Private Sub btnBoostAndLaunch_Click(sender As Object, e As EventArgs) Handles btnBoostAndLaunch.Click, lvGames.DoubleClick
        If lvGames.SelectedItems.Length = 0 Then Return
        Dim game = TryCast(lvGames.SelectedItems(0).Tag, gaming.GameItem)
        If game IsNot Nothing Then
            lblLibraryStatus.Value1 = "Launching:"
            lblLibraryStatus.Value2 = " " & game.Name & "..."
            gaming.LaunchGameWithBoost(game, WinMain.ProcessIgnoreList)
            UpdateBoostStatus()
            lblLibraryStatus.Value1 = "Running:"
            lblLibraryStatus.Value2 = " " & game.Name & " (High Priority + 0.5ms)"
        End If
    End Sub

    Private Sub btnRefreshGames_Click(sender As Object, e As EventArgs) Handles btnRefreshGames.Click
        RefreshGameLibraryAsync()
    End Sub

    Private Sub btnAddCustomGame_Click(sender As Object, e As EventArgs) Handles btnAddCustomGame.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Game Executable (*.exe)|*.exe|All Files (*.*)|*.*"
            ofd.Title = "Select Game Executable"
            If ofd.ShowDialog(Me) = DialogResult.OK Then
                Dim exePath = ofd.FileName
                Dim gameName = Path.GetFileNameWithoutExtension(exePath)
                Dim gItem As New gaming.GameItem() With {
                    .Name = gameName,
                    .ExecutablePath = exePath,
                    .LauncherType = "Custom",
                    .InstallDir = Path.GetDirectoryName(exePath),
                    .LaunchCommand = exePath,
                    .Icon = proc.GetProcessIcon(exePath)
                }
                _games.Add(gItem)
                PopulateGameList(_games)
                lblLibraryStatus.Value1 = "Added:"
                lblLibraryStatus.Value2 = " " & gameName
            End If
        End Using
    End Sub

    Private Sub btnControlClose_Click(sender As Object, e As EventArgs) Handles btnControlClose.Click
        Me.Close()
    End Sub

    Private Sub btnControlMinimize_Click(sender As Object, e As EventArgs) Handles btnControlMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

End Class
