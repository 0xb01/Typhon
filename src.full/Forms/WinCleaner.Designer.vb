<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinCleaner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinCleaner))
        Me.themeContainer = New Typhon.NSTheme()
        Me.btnControlClose = New Typhon.NSControlButton()
        Me.lblStatus = New Typhon.NSLabel()
        Me.pbCleaningProgress = New Typhon.NSProgressBar()
        Me.lvCleanItems = New Typhon.NSListView()
        Me.ctxListView = New Typhon.NSContextMenu()
        Me.tsCopyPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsOpenFileLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSearchGoogle = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSearchVirusTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbCleanerOptions = New Typhon.NSGroupBox()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.chkTemp = New Typhon.NSCheckBox()
        Me.chkRecycle = New Typhon.NSCheckBox()
        Me.chkIncompat = New Typhon.NSCheckBox()
        Me.chkThumb = New Typhon.NSCheckBox()
        Me.chkGames = New Typhon.NSCheckBox()
        Me.chkFolderCfg = New Typhon.NSCheckBox()
        Me.chkCookies = New Typhon.NSCheckBox()
        Me.chkCache = New Typhon.NSCheckBox()
        Me.chkHistory = New Typhon.NSCheckBox()
        Me.chkLogs = New Typhon.NSCheckBox()
        Me.chkDumps = New Typhon.NSCheckBox()
        Me.chkRecent = New Typhon.NSCheckBox()
        Me.chkAppCache = New Typhon.NSCheckBox()
        Me.chkWinUpdate = New Typhon.NSCheckBox()
        Me.chkDriverCache = New Typhon.NSCheckBox()
        Me.chkPkgCache = New Typhon.NSCheckBox()
        Me.btnScan = New Typhon.NSButton()
        Me.btnClean = New Typhon.NSButton()
        Me.btnClose = New Typhon.NSButton()
        Me.themeContainer.SuspendLayout()
        Me.ctxListView.SuspendLayout()
        Me.gbCleanerOptions.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'themeContainer
        '
        Me.themeContainer.AccentOffset = 42
        Me.themeContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.themeContainer.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.themeContainer.Colors = New Typhon.Bloom(-1) {}
        Me.themeContainer.Controls.Add(Me.btnControlClose)
        Me.themeContainer.Controls.Add(Me.lblStatus)
        Me.themeContainer.Controls.Add(Me.pbCleaningProgress)
        Me.themeContainer.Controls.Add(Me.lvCleanItems)
        Me.themeContainer.Controls.Add(Me.gbCleanerOptions)
        Me.themeContainer.Controls.Add(Me.btnScan)
        Me.themeContainer.Controls.Add(Me.btnClean)
        Me.themeContainer.Controls.Add(Me.btnClose)
        Me.themeContainer.Customization = ""
        Me.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.themeContainer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.themeContainer.Image = Nothing
        Me.themeContainer.Location = New System.Drawing.Point(0, 0)
        Me.themeContainer.Movable = True
        Me.themeContainer.Name = "themeContainer"
        Me.themeContainer.NoRounding = False
        Me.themeContainer.Padding = New System.Windows.Forms.Padding(0, 28, 0, 0)
        Me.themeContainer.Sizable = False
        Me.themeContainer.Size = New System.Drawing.Size(720, 548)
        Me.themeContainer.SmartBounds = True
        Me.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.themeContainer.TabIndex = 0
        Me.themeContainer.Text = "System Cleaner"
        Me.themeContainer.TransparencyKey = System.Drawing.Color.Empty
        Me.themeContainer.Transparent = False
        '
        'btnControlClose
        '
        Me.btnControlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlClose.ControlButton = Typhon.NSControlButton.Button.Close
        Me.btnControlClose.Location = New System.Drawing.Point(694, 5)
        Me.btnControlClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.Name = "btnControlClose"
        Me.btnControlClose.Size = New System.Drawing.Size(18, 20)
        Me.btnControlClose.TabIndex = 0
        Me.btnControlClose.Text = "btnControlClose"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(15, 38)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(690, 23)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.Value1 = "Status:"
        Me.lblStatus.Value2 = " Ready to scan system"
        '
        'pbCleaningProgress
        '
        Me.pbCleaningProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCleaningProgress.Location = New System.Drawing.Point(219, 515)
        Me.pbCleaningProgress.Maximum = 100
        Me.pbCleaningProgress.Minimum = 0
        Me.pbCleaningProgress.Name = "pbCleaningProgress"
        Me.pbCleaningProgress.Size = New System.Drawing.Size(385, 18)
        Me.pbCleaningProgress.TabIndex = 2
        Me.pbCleaningProgress.Value = 0
        Me.pbCleaningProgress.Visible = False
        '
        'lvCleanItems
        '
        Me.lvCleanItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCleanItems.CheckBoxes = False
        Me.lvCleanItems.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.lvCleanItems.ContextMenuStrip = Me.ctxListView
        Me.lvCleanItems.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lvCleanItems.Location = New System.Drawing.Point(15, 67)
        Me.lvCleanItems.MultiSelect = True
        Me.lvCleanItems.Name = "lvCleanItems"
        Me.lvCleanItems.Size = New System.Drawing.Size(500, 437)
        Me.lvCleanItems.TabIndex = 3
        Me.lvCleanItems.Text = "lvCleanItems"
        '
        'ctxListView
        '
        Me.ctxListView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ctxListView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsCopyPath, Me.tsOpenFileLocation, Me.tsSearchGoogle, Me.tsSearchVirusTotal})
        Me.ctxListView.Name = "ctxListView"
        Me.ctxListView.Size = New System.Drawing.Size(178, 92)
        '
        'tsCopyPath
        '
        Me.tsCopyPath.Name = "tsCopyPath"
        Me.tsCopyPath.Size = New System.Drawing.Size(177, 22)
        Me.tsCopyPath.Text = "Copy Path"
        '
        'tsOpenFileLocation
        '
        Me.tsOpenFileLocation.Name = "tsOpenFileLocation"
        Me.tsOpenFileLocation.Size = New System.Drawing.Size(177, 22)
        Me.tsOpenFileLocation.Text = "Open File Location"
        '
        'tsSearchGoogle
        '
        Me.tsSearchGoogle.Name = "tsSearchGoogle"
        Me.tsSearchGoogle.Size = New System.Drawing.Size(177, 22)
        Me.tsSearchGoogle.Text = "Search in Google"
        '
        'tsSearchVirusTotal
        '
        Me.tsSearchVirusTotal.Name = "tsSearchVirusTotal"
        Me.tsSearchVirusTotal.Size = New System.Drawing.Size(177, 22)
        Me.tsSearchVirusTotal.Text = "Search in VirusTotal"
        '
        'gbCleanerOptions
        '
        Me.gbCleanerOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCleanerOptions.Controls.Add(Me.pnlOptions)
        Me.gbCleanerOptions.DrawSeperator = False
        Me.gbCleanerOptions.Location = New System.Drawing.Point(525, 67)
        Me.gbCleanerOptions.Name = "gbCleanerOptions"
        Me.gbCleanerOptions.Size = New System.Drawing.Size(180, 437)
        Me.gbCleanerOptions.SubTitle = ""
        Me.gbCleanerOptions.TabIndex = 4
        Me.gbCleanerOptions.Text = "Options"
        Me.gbCleanerOptions.Title = "Clean Targets"
        '
        'pnlOptions
        '
        Me.pnlOptions.AutoScroll = True
        Me.pnlOptions.Controls.Add(Me.chkTemp)
        Me.pnlOptions.Controls.Add(Me.chkRecycle)
        Me.pnlOptions.Controls.Add(Me.chkIncompat)
        Me.pnlOptions.Controls.Add(Me.chkThumb)
        Me.pnlOptions.Controls.Add(Me.chkGames)
        Me.pnlOptions.Controls.Add(Me.chkFolderCfg)
        Me.pnlOptions.Controls.Add(Me.chkCookies)
        Me.pnlOptions.Controls.Add(Me.chkCache)
        Me.pnlOptions.Controls.Add(Me.chkHistory)
        Me.pnlOptions.Controls.Add(Me.chkLogs)
        Me.pnlOptions.Controls.Add(Me.chkDumps)
        Me.pnlOptions.Controls.Add(Me.chkRecent)
        Me.pnlOptions.Controls.Add(Me.chkAppCache)
        Me.pnlOptions.Controls.Add(Me.chkWinUpdate)
        Me.pnlOptions.Controls.Add(Me.chkDriverCache)
        Me.pnlOptions.Controls.Add(Me.chkPkgCache)
        Me.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOptions.Location = New System.Drawing.Point(0, 0)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Padding = New System.Windows.Forms.Padding(4, 25, 4, 4)
        Me.pnlOptions.Size = New System.Drawing.Size(180, 437)
        Me.pnlOptions.TabIndex = 0
        '
        'chkTemp
        '
        Me.chkTemp.Checked = False
        Me.chkTemp.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkTemp.Location = New System.Drawing.Point(4, 370)
        Me.chkTemp.Name = "chkTemp"
        Me.chkTemp.Size = New System.Drawing.Size(172, 23)
        Me.chkTemp.TabIndex = 0
        Me.chkTemp.Text = "Temporary Files"
        '
        'chkRecycle
        '
        Me.chkRecycle.Checked = False
        Me.chkRecycle.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkRecycle.Location = New System.Drawing.Point(4, 347)
        Me.chkRecycle.Name = "chkRecycle"
        Me.chkRecycle.Size = New System.Drawing.Size(172, 23)
        Me.chkRecycle.TabIndex = 1
        Me.chkRecycle.Text = "Recycle Bin"
        '
        'chkIncompat
        '
        Me.chkIncompat.Checked = False
        Me.chkIncompat.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkIncompat.Location = New System.Drawing.Point(4, 324)
        Me.chkIncompat.Name = "chkIncompat"
        Me.chkIncompat.Size = New System.Drawing.Size(172, 23)
        Me.chkIncompat.TabIndex = 2
        Me.chkIncompat.Text = "Incompatible Files"
        '
        'chkThumb
        '
        Me.chkThumb.Checked = False
        Me.chkThumb.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkThumb.Location = New System.Drawing.Point(4, 301)
        Me.chkThumb.Name = "chkThumb"
        Me.chkThumb.Size = New System.Drawing.Size(172, 23)
        Me.chkThumb.TabIndex = 3
        Me.chkThumb.Text = "Thumbnail Caches"
        '
        'chkGames
        '
        Me.chkGames.Checked = False
        Me.chkGames.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkGames.Location = New System.Drawing.Point(4, 278)
        Me.chkGames.Name = "chkGames"
        Me.chkGames.Size = New System.Drawing.Size(172, 23)
        Me.chkGames.TabIndex = 4
        Me.chkGames.Text = "Game Caches"
        '
        'chkFolderCfg
        '
        Me.chkFolderCfg.Checked = False
        Me.chkFolderCfg.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkFolderCfg.Location = New System.Drawing.Point(4, 255)
        Me.chkFolderCfg.Name = "chkFolderCfg"
        Me.chkFolderCfg.Size = New System.Drawing.Size(172, 23)
        Me.chkFolderCfg.TabIndex = 5
        Me.chkFolderCfg.Text = "Folder Config Files"
        '
        'chkCookies
        '
        Me.chkCookies.Checked = False
        Me.chkCookies.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkCookies.Location = New System.Drawing.Point(4, 232)
        Me.chkCookies.Name = "chkCookies"
        Me.chkCookies.Size = New System.Drawing.Size(172, 23)
        Me.chkCookies.TabIndex = 6
        Me.chkCookies.Text = "Internet Cookies"
        '
        'chkCache
        '
        Me.chkCache.Checked = False
        Me.chkCache.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkCache.Location = New System.Drawing.Point(4, 209)
        Me.chkCache.Name = "chkCache"
        Me.chkCache.Size = New System.Drawing.Size(172, 23)
        Me.chkCache.TabIndex = 7
        Me.chkCache.Text = "Internet Cache"
        '
        'chkHistory
        '
        Me.chkHistory.Checked = False
        Me.chkHistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkHistory.Location = New System.Drawing.Point(4, 186)
        Me.chkHistory.Name = "chkHistory"
        Me.chkHistory.Size = New System.Drawing.Size(172, 23)
        Me.chkHistory.TabIndex = 8
        Me.chkHistory.Text = "Internet History"
        '
        'chkLogs
        '
        Me.chkLogs.Checked = False
        Me.chkLogs.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkLogs.Location = New System.Drawing.Point(4, 163)
        Me.chkLogs.Name = "chkLogs"
        Me.chkLogs.Size = New System.Drawing.Size(172, 23)
        Me.chkLogs.TabIndex = 9
        Me.chkLogs.Text = "Windows Logs"
        '
        'chkDumps
        '
        Me.chkDumps.Checked = False
        Me.chkDumps.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkDumps.Location = New System.Drawing.Point(4, 140)
        Me.chkDumps.Name = "chkDumps"
        Me.chkDumps.Size = New System.Drawing.Size(172, 23)
        Me.chkDumps.TabIndex = 10
        Me.chkDumps.Text = "Memory Dumps"
        '
        'chkRecent
        '
        Me.chkRecent.Checked = False
        Me.chkRecent.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkRecent.Location = New System.Drawing.Point(4, 117)
        Me.chkRecent.Name = "chkRecent"
        Me.chkRecent.Size = New System.Drawing.Size(172, 23)
        Me.chkRecent.TabIndex = 11
        Me.chkRecent.Text = "Recent Files"
        '
        'chkAppCache
        '
        Me.chkAppCache.Checked = False
        Me.chkAppCache.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkAppCache.Location = New System.Drawing.Point(4, 94)
        Me.chkAppCache.Name = "chkAppCache"
        Me.chkAppCache.Size = New System.Drawing.Size(172, 23)
        Me.chkAppCache.TabIndex = 12
        Me.chkAppCache.Text = "Application Caches"
        '
        'chkWinUpdate
        '
        Me.chkWinUpdate.Checked = False
        Me.chkWinUpdate.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkWinUpdate.Location = New System.Drawing.Point(4, 71)
        Me.chkWinUpdate.Name = "chkWinUpdate"
        Me.chkWinUpdate.Size = New System.Drawing.Size(172, 23)
        Me.chkWinUpdate.TabIndex = 13
        Me.chkWinUpdate.Text = "Windows Update Cache"
        '
        'chkDriverCache
        '
        Me.chkDriverCache.Checked = False
        Me.chkDriverCache.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkDriverCache.Location = New System.Drawing.Point(4, 48)
        Me.chkDriverCache.Name = "chkDriverCache"
        Me.chkDriverCache.Size = New System.Drawing.Size(172, 23)
        Me.chkDriverCache.TabIndex = 14
        Me.chkDriverCache.Text = "GPU Driver Cache"
        '
        'chkPkgCache
        '
        Me.chkPkgCache.Checked = False
        Me.chkPkgCache.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkPkgCache.Location = New System.Drawing.Point(4, 25)
        Me.chkPkgCache.Name = "chkPkgCache"
        Me.chkPkgCache.Size = New System.Drawing.Size(172, 23)
        Me.chkPkgCache.TabIndex = 15
        Me.chkPkgCache.Text = "Dev Package Caches"
        '
        'btnScan
        '
        Me.btnScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnScan.Location = New System.Drawing.Point(15, 512)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(95, 24)
        Me.btnScan.TabIndex = 5
        Me.btnScan.Text = "Scan"
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Enabled = False
        Me.btnClean.Location = New System.Drawing.Point(116, 512)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(95, 24)
        Me.btnClean.TabIndex = 6
        Me.btnClean.Text = "Clean"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(610, 512)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 24)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        '
        'WinCleaner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 548)
        Me.Controls.Add(Me.themeContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinCleaner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Cleaner"
        Me.themeContainer.ResumeLayout(False)
        Me.ctxListView.ResumeLayout(False)
        Me.gbCleanerOptions.ResumeLayout(False)
        Me.pnlOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents themeContainer As Typhon.NSTheme
    Friend WithEvents btnControlClose As Typhon.NSControlButton
    Friend WithEvents lblStatus As Typhon.NSLabel
    Friend WithEvents pbCleaningProgress As Typhon.NSProgressBar
    Friend WithEvents lvCleanItems As Typhon.NSListView
    Friend WithEvents ctxListView As Typhon.NSContextMenu
    Friend WithEvents tsCopyPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsOpenFileLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSearchGoogle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSearchVirusTotal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbCleanerOptions As Typhon.NSGroupBox
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents chkTemp As Typhon.NSCheckBox
    Friend WithEvents chkRecycle As Typhon.NSCheckBox
    Friend WithEvents chkIncompat As Typhon.NSCheckBox
    Friend WithEvents chkThumb As Typhon.NSCheckBox
    Friend WithEvents chkGames As Typhon.NSCheckBox
    Friend WithEvents chkFolderCfg As Typhon.NSCheckBox
    Friend WithEvents chkCookies As Typhon.NSCheckBox
    Friend WithEvents chkCache As Typhon.NSCheckBox
    Friend WithEvents chkHistory As Typhon.NSCheckBox
    Friend WithEvents chkLogs As Typhon.NSCheckBox
    Friend WithEvents chkDumps As Typhon.NSCheckBox
    Friend WithEvents chkRecent As Typhon.NSCheckBox
    Friend WithEvents chkAppCache As Typhon.NSCheckBox
    Friend WithEvents chkWinUpdate As Typhon.NSCheckBox
    Friend WithEvents chkDriverCache As Typhon.NSCheckBox
    Friend WithEvents chkPkgCache As Typhon.NSCheckBox
    Friend WithEvents btnScan As Typhon.NSButton
    Friend WithEvents btnClean As Typhon.NSButton
    Friend WithEvents btnClose As Typhon.NSButton
End Class
