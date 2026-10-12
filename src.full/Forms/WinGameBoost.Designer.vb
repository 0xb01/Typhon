<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinGameBoost
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.themeContainer = New Typhon.NSTheme()
        Me.tabGaming = New Typhon.NSTabControl()
        Me.tabDashboard = New System.Windows.Forms.TabPage()
        Me.btnMasterBoost = New Typhon.NSButton()
        Me.lblBoostStatus = New Typhon.NSLabel()
        Me.gbSystemTweaks = New Typhon.NSGroupBox()
        Me.lblTweakTimer = New Typhon.NSLabel()
        Me.toggleHighResTimer = New Typhon.NSOnOffBox()
        Me.lblTweakPower = New Typhon.NSLabel()
        Me.toggleUltimatePower = New Typhon.NSOnOffBox()
        Me.lblTweakNetwork = New Typhon.NSLabel()
        Me.toggleTcpNoDelay = New Typhon.NSOnOffBox()
        Me.lblTweakDVR = New Typhon.NSLabel()
        Me.toggleGameDVR = New Typhon.NSOnOffBox()
        Me.btnPurgeStandby = New Typhon.NSButton()
        Me.btnFlushDNS = New Typhon.NSButton()
        Me.btnTrimSSD = New Typhon.NSButton()
        Me.btnToggleHUD = New Typhon.NSButton()
        Me.tabLibrary = New System.Windows.Forms.TabPage()
        Me.lvGames = New Typhon.NSListView()
        Me.btnBoostAndLaunch = New Typhon.NSButton()
        Me.btnRefreshGames = New Typhon.NSButton()
        Me.btnAddCustomGame = New Typhon.NSButton()
        Me.lblLibraryStatus = New Typhon.NSLabel()
        Me.btnControlMinimize = New Typhon.NSControlButton()
        Me.btnControlClose = New Typhon.NSControlButton()
        Me.themeContainer.SuspendLayout()
        Me.tabGaming.SuspendLayout()
        Me.tabDashboard.SuspendLayout()
        Me.gbSystemTweaks.SuspendLayout()
        Me.tabLibrary.SuspendLayout()
        Me.SuspendLayout()
        '
        'themeContainer
        '
        Me.themeContainer.AccentOffset = 42
        Me.themeContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.themeContainer.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.themeContainer.Colors = New Typhon.Bloom(-1) {}
        Me.themeContainer.Controls.Add(Me.tabGaming)
        Me.themeContainer.Controls.Add(Me.btnControlMinimize)
        Me.themeContainer.Controls.Add(Me.btnControlClose)
        Me.themeContainer.Customization = ""
        Me.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.themeContainer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.themeContainer.Image = Nothing
        Me.themeContainer.Location = New System.Drawing.Point(0, 0)
        Me.themeContainer.Movable = True
        Me.themeContainer.Name = "themeContainer"
        Me.themeContainer.NoRounding = False
        Me.themeContainer.Sizable = False
        Me.themeContainer.Size = New System.Drawing.Size(520, 335)
        Me.themeContainer.SmartBounds = True
        Me.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.themeContainer.TabIndex = 0
        Me.themeContainer.Text = "Typhon: Game Booster"
        Me.themeContainer.TransparencyKey = System.Drawing.Color.Empty
        Me.themeContainer.Transparent = False
        '
        'tabGaming
        '
        Me.tabGaming.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tabGaming.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabGaming.Controls.Add(Me.tabDashboard)
        Me.tabGaming.Controls.Add(Me.tabLibrary)
        Me.tabGaming.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabGaming.ItemSize = New System.Drawing.Size(26, 95)
        Me.tabGaming.Location = New System.Drawing.Point(12, 40)
        Me.tabGaming.Name = "tabGaming"
        Me.tabGaming.SelectedIndex = 0
        Me.tabGaming.Size = New System.Drawing.Size(496, 283)
        Me.tabGaming.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabGaming.TabIndex = 1
        '
        'tabDashboard
        '
        Me.tabDashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabDashboard.Controls.Add(Me.btnMasterBoost)
        Me.tabDashboard.Controls.Add(Me.lblBoostStatus)
        Me.tabDashboard.Controls.Add(Me.gbSystemTweaks)
        Me.tabDashboard.Controls.Add(Me.btnPurgeStandby)
        Me.tabDashboard.Controls.Add(Me.btnFlushDNS)
        Me.tabDashboard.Controls.Add(Me.btnTrimSSD)
        Me.tabDashboard.Controls.Add(Me.btnToggleHUD)
        Me.tabDashboard.Location = New System.Drawing.Point(99, 4)
        Me.tabDashboard.Name = "tabDashboard"
        Me.tabDashboard.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDashboard.Size = New System.Drawing.Size(393, 275)
        Me.tabDashboard.TabIndex = 0
        Me.tabDashboard.Text = "Booster"
        '
        'btnMasterBoost
        '
        Me.btnMasterBoost.Location = New System.Drawing.Point(6, 6)
        Me.btnMasterBoost.Name = "btnMasterBoost"
        Me.btnMasterBoost.Size = New System.Drawing.Size(155, 30)
        Me.btnMasterBoost.TabIndex = 0
        Me.btnMasterBoost.Text = "⚡ BOOST SYSTEM"
        '
        'lblBoostStatus
        '
        Me.lblBoostStatus.Font = New System.Drawing.Font("Verdana", 7.5!)
        Me.lblBoostStatus.Location = New System.Drawing.Point(167, 6)
        Me.lblBoostStatus.Name = "lblBoostStatus"
        Me.lblBoostStatus.Size = New System.Drawing.Size(220, 30)
        Me.lblBoostStatus.TabIndex = 1
        Me.lblBoostStatus.Value1 = "Status:"
        Me.lblBoostStatus.Value2 = " Ready to optimize"
        '
        'gbSystemTweaks
        '
        Me.gbSystemTweaks.Controls.Add(Me.lblTweakTimer)
        Me.gbSystemTweaks.Controls.Add(Me.toggleHighResTimer)
        Me.gbSystemTweaks.Controls.Add(Me.lblTweakPower)
        Me.gbSystemTweaks.Controls.Add(Me.toggleUltimatePower)
        Me.gbSystemTweaks.Controls.Add(Me.lblTweakNetwork)
        Me.gbSystemTweaks.Controls.Add(Me.toggleTcpNoDelay)
        Me.gbSystemTweaks.Controls.Add(Me.lblTweakDVR)
        Me.gbSystemTweaks.Controls.Add(Me.toggleGameDVR)
        Me.gbSystemTweaks.DrawSeperator = False
        Me.gbSystemTweaks.Location = New System.Drawing.Point(6, 40)
        Me.gbSystemTweaks.Name = "gbSystemTweaks"
        Me.gbSystemTweaks.Size = New System.Drawing.Size(381, 195)
        Me.gbSystemTweaks.SubTitle = ""
        Me.gbSystemTweaks.TabIndex = 2
        Me.gbSystemTweaks.Title = "Gaming Tweaks"
        '
        'lblTweakTimer
        '
        Me.lblTweakTimer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblTweakTimer.Location = New System.Drawing.Point(8, 28)
        Me.lblTweakTimer.Name = "lblTweakTimer"
        Me.lblTweakTimer.Size = New System.Drawing.Size(300, 23)
        Me.lblTweakTimer.TabIndex = 0
        Me.lblTweakTimer.Value1 = "0.5ms Timer Res:"
        Me.lblTweakTimer.Value2 = " Ultra-low input latency"
        '
        'toggleHighResTimer
        '
        Me.toggleHighResTimer.Checked = True
        Me.toggleHighResTimer.Location = New System.Drawing.Point(318, 27)
        Me.toggleHighResTimer.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleHighResTimer.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleHighResTimer.Name = "toggleHighResTimer"
        Me.toggleHighResTimer.Size = New System.Drawing.Size(56, 24)
        Me.toggleHighResTimer.TabIndex = 1
        '
        'lblTweakPower
        '
        Me.lblTweakPower.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblTweakPower.Location = New System.Drawing.Point(8, 68)
        Me.lblTweakPower.Name = "lblTweakPower"
        Me.lblTweakPower.Size = New System.Drawing.Size(300, 23)
        Me.lblTweakPower.TabIndex = 2
        Me.lblTweakPower.Value1 = "Ultimate Power Plan:"
        Me.lblTweakPower.Value2 = " Lock max CPU frequencies"
        '
        'toggleUltimatePower
        '
        Me.toggleUltimatePower.Checked = True
        Me.toggleUltimatePower.Location = New System.Drawing.Point(318, 67)
        Me.toggleUltimatePower.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleUltimatePower.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleUltimatePower.Name = "toggleUltimatePower"
        Me.toggleUltimatePower.Size = New System.Drawing.Size(56, 24)
        Me.toggleUltimatePower.TabIndex = 3
        '
        'lblTweakNetwork
        '
        Me.lblTweakNetwork.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblTweakNetwork.Location = New System.Drawing.Point(8, 108)
        Me.lblTweakNetwork.Name = "lblTweakNetwork"
        Me.lblTweakNetwork.Size = New System.Drawing.Size(300, 23)
        Me.lblTweakNetwork.TabIndex = 4
        Me.lblTweakNetwork.Value1 = "TCP NoDelay:"
        Me.lblTweakNetwork.Value2 = " Disable packet buffering"
        '
        'toggleTcpNoDelay
        '
        Me.toggleTcpNoDelay.Checked = False
        Me.toggleTcpNoDelay.Location = New System.Drawing.Point(318, 107)
        Me.toggleTcpNoDelay.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleTcpNoDelay.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleTcpNoDelay.Name = "toggleTcpNoDelay"
        Me.toggleTcpNoDelay.Size = New System.Drawing.Size(56, 24)
        Me.toggleTcpNoDelay.TabIndex = 5
        '
        'lblTweakDVR
        '
        Me.lblTweakDVR.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblTweakDVR.Location = New System.Drawing.Point(8, 148)
        Me.lblTweakDVR.Name = "lblTweakDVR"
        Me.lblTweakDVR.Size = New System.Drawing.Size(300, 23)
        Me.lblTweakDVR.TabIndex = 6
        Me.lblTweakDVR.Value1 = "Disable Game DVR:"
        Me.lblTweakDVR.Value2 = " Stop background capture"
        '
        'toggleGameDVR
        '
        Me.toggleGameDVR.Checked = False
        Me.toggleGameDVR.Location = New System.Drawing.Point(318, 147)
        Me.toggleGameDVR.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleGameDVR.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleGameDVR.Name = "toggleGameDVR"
        Me.toggleGameDVR.Size = New System.Drawing.Size(56, 24)
        Me.toggleGameDVR.TabIndex = 7
        '
        'btnPurgeStandby
        '
        Me.btnPurgeStandby.Location = New System.Drawing.Point(6, 242)
        Me.btnPurgeStandby.Name = "btnPurgeStandby"
        Me.btnPurgeStandby.Size = New System.Drawing.Size(88, 25)
        Me.btnPurgeStandby.TabIndex = 3
        Me.btnPurgeStandby.Text = "⚡ Standby"
        '
        'btnFlushDNS
        '
        Me.btnFlushDNS.Location = New System.Drawing.Point(100, 242)
        Me.btnFlushDNS.Name = "btnFlushDNS"
        Me.btnFlushDNS.Size = New System.Drawing.Size(88, 25)
        Me.btnFlushDNS.TabIndex = 4
        Me.btnFlushDNS.Text = "🌐 DNS"
        '
        'btnTrimSSD
        '
        Me.btnTrimSSD.Location = New System.Drawing.Point(194, 242)
        Me.btnTrimSSD.Name = "btnTrimSSD"
        Me.btnTrimSSD.Size = New System.Drawing.Size(88, 25)
        Me.btnTrimSSD.TabIndex = 5
        Me.btnTrimSSD.Text = "💽 TRIM"
        '
        'btnToggleHUD
        '
        Me.btnToggleHUD.Location = New System.Drawing.Point(288, 242)
        Me.btnToggleHUD.Name = "btnToggleHUD"
        Me.btnToggleHUD.Size = New System.Drawing.Size(99, 25)
        Me.btnToggleHUD.TabIndex = 6
        Me.btnToggleHUD.Text = "📊 Mini HUD"
        '
        'tabLibrary
        '
        Me.tabLibrary.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabLibrary.Controls.Add(Me.lvGames)
        Me.tabLibrary.Controls.Add(Me.btnBoostAndLaunch)
        Me.tabLibrary.Controls.Add(Me.btnRefreshGames)
        Me.tabLibrary.Controls.Add(Me.btnAddCustomGame)
        Me.tabLibrary.Controls.Add(Me.lblLibraryStatus)
        Me.tabLibrary.Location = New System.Drawing.Point(99, 4)
        Me.tabLibrary.Name = "tabLibrary"
        Me.tabLibrary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLibrary.Size = New System.Drawing.Size(393, 275)
        Me.tabLibrary.TabIndex = 1
        Me.tabLibrary.Text = "Library"
        '
        'lvGames
        '
        Me.lvGames.Location = New System.Drawing.Point(6, 6)
        Me.lvGames.Name = "lvGames"
        Me.lvGames.Size = New System.Drawing.Size(381, 202)
        Me.lvGames.TabIndex = 0
        Me.lvGames.Text = "lvGames"
        '
        'btnBoostAndLaunch
        '
        Me.btnBoostAndLaunch.Location = New System.Drawing.Point(6, 214)
        Me.btnBoostAndLaunch.Name = "btnBoostAndLaunch"
        Me.btnBoostAndLaunch.Size = New System.Drawing.Size(150, 26)
        Me.btnBoostAndLaunch.TabIndex = 1
        Me.btnBoostAndLaunch.Text = "🚀 Boost & Launch"
        '
        'btnRefreshGames
        '
        Me.btnRefreshGames.Location = New System.Drawing.Point(162, 214)
        Me.btnRefreshGames.Name = "btnRefreshGames"
        Me.btnRefreshGames.Size = New System.Drawing.Size(100, 26)
        Me.btnRefreshGames.TabIndex = 2
        Me.btnRefreshGames.Text = "🔄 Refresh"
        '
        'btnAddCustomGame
        '
        Me.btnAddCustomGame.Location = New System.Drawing.Point(268, 214)
        Me.btnAddCustomGame.Name = "btnAddCustomGame"
        Me.btnAddCustomGame.Size = New System.Drawing.Size(119, 26)
        Me.btnAddCustomGame.TabIndex = 3
        Me.btnAddCustomGame.Text = "+ Add Game"
        '
        'lblLibraryStatus
        '
        Me.lblLibraryStatus.Font = New System.Drawing.Font("Verdana", 7.5!)
        Me.lblLibraryStatus.Location = New System.Drawing.Point(6, 246)
        Me.lblLibraryStatus.Name = "lblLibraryStatus"
        Me.lblLibraryStatus.Size = New System.Drawing.Size(381, 20)
        Me.lblLibraryStatus.TabIndex = 4
        Me.lblLibraryStatus.Value1 = "Games:"
        Me.lblLibraryStatus.Value2 = " Ready"
        '
        'btnControlMinimize
        '
        Me.btnControlMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlMinimize.ControlButton = Typhon.NSControlButton.Button.Minimize
        Me.btnControlMinimize.Location = New System.Drawing.Point(470, 4)
        Me.btnControlMinimize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlMinimize.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.Name = "btnControlMinimize"
        Me.btnControlMinimize.Size = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.TabIndex = 2
        Me.btnControlMinimize.Text = "btnControlMinimize"
        '
        'btnControlClose
        '
        Me.btnControlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlClose.ControlButton = Typhon.NSControlButton.Button.Close
        Me.btnControlClose.Location = New System.Drawing.Point(494, 4)
        Me.btnControlClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.Name = "btnControlClose"
        Me.btnControlClose.Size = New System.Drawing.Size(18, 20)
        Me.btnControlClose.TabIndex = 0
        Me.btnControlClose.Text = "btnControlClose"
        '
        'WinGameBoost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(520, 335)
        Me.Controls.Add(Me.themeContainer)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WinGameBoost"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Typhon: Game Booster"
        Me.themeContainer.ResumeLayout(False)
        Me.tabGaming.ResumeLayout(False)
        Me.tabDashboard.ResumeLayout(False)
        Me.gbSystemTweaks.ResumeLayout(False)
        Me.tabLibrary.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents themeContainer As Typhon.NSTheme
    Friend WithEvents btnControlMinimize As Typhon.NSControlButton
    Friend WithEvents btnControlClose As Typhon.NSControlButton
    Friend WithEvents tabGaming As Typhon.NSTabControl
    Friend WithEvents tabDashboard As System.Windows.Forms.TabPage
    Friend WithEvents btnMasterBoost As Typhon.NSButton
    Friend WithEvents lblBoostStatus As Typhon.NSLabel
    Friend WithEvents gbSystemTweaks As Typhon.NSGroupBox
    Friend WithEvents lblTweakTimer As Typhon.NSLabel
    Friend WithEvents toggleHighResTimer As Typhon.NSOnOffBox
    Friend WithEvents lblTweakPower As Typhon.NSLabel
    Friend WithEvents toggleUltimatePower As Typhon.NSOnOffBox
    Friend WithEvents lblTweakNetwork As Typhon.NSLabel
    Friend WithEvents toggleTcpNoDelay As Typhon.NSOnOffBox
    Friend WithEvents lblTweakDVR As Typhon.NSLabel
    Friend WithEvents toggleGameDVR As Typhon.NSOnOffBox
    Friend WithEvents btnPurgeStandby As Typhon.NSButton
    Friend WithEvents btnFlushDNS As Typhon.NSButton
    Friend WithEvents btnTrimSSD As Typhon.NSButton
    Friend WithEvents btnToggleHUD As Typhon.NSButton
    Friend WithEvents tabLibrary As System.Windows.Forms.TabPage
    Friend WithEvents lvGames As Typhon.NSListView
    Friend WithEvents btnBoostAndLaunch As Typhon.NSButton
    Friend WithEvents btnRefreshGames As Typhon.NSButton
    Friend WithEvents btnAddCustomGame As Typhon.NSButton
    Friend WithEvents lblLibraryStatus As Typhon.NSLabel
End Class
