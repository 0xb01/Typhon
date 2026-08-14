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
        Me.NsTheme1 = New Typhon.NSTheme()
        Me.NsControlButton1 = New Typhon.NSControlButton()
        Me.NsLabelStatus = New Typhon.NSLabel()
        Me.CleanerProgressBar = New Typhon.NSProgressBar()
        Me.NsListView1 = New Typhon.NSListView()
        Me.ctxListView = New Typhon.NSContextMenu()
        Me.tsCopyPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsOpenFileLocation = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSearchGoogle = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSearchVirusTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.NsGroupBoxOptions = New Typhon.NSGroupBox()
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
        Me.NsTheme1.SuspendLayout()
        Me.ctxListView.SuspendLayout()
        Me.NsGroupBoxOptions.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New Typhon.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.NsLabelStatus)
        Me.NsTheme1.Controls.Add(Me.CleanerProgressBar)
        Me.NsTheme1.Controls.Add(Me.NsListView1)
        Me.NsTheme1.Controls.Add(Me.NsGroupBoxOptions)
        Me.NsTheme1.Controls.Add(Me.btnScan)
        Me.NsTheme1.Controls.Add(Me.btnClean)
        Me.NsTheme1.Controls.Add(Me.btnClose)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Padding = New System.Windows.Forms.Padding(0, 28, 0, 0)
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(720, 548)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "System Cleaner"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(694, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'NsLabelStatus
        '
        Me.NsLabelStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabelStatus.Location = New System.Drawing.Point(15, 38)
        Me.NsLabelStatus.Name = "NsLabelStatus"
        Me.NsLabelStatus.Size = New System.Drawing.Size(690, 23)
        Me.NsLabelStatus.TabIndex = 1
        Me.NsLabelStatus.Text = "NsLabelStatus"
        Me.NsLabelStatus.Value1 = "Status:"
        Me.NsLabelStatus.Value2 = " Ready to scan system"
        '
        'CleanerProgressBar
        '
        Me.CleanerProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CleanerProgressBar.Location = New System.Drawing.Point(219, 515)
        Me.CleanerProgressBar.Maximum = 100
        Me.CleanerProgressBar.Minimum = 0
        Me.CleanerProgressBar.Name = "CleanerProgressBar"
        Me.CleanerProgressBar.Size = New System.Drawing.Size(385, 18)
        Me.CleanerProgressBar.TabIndex = 2
        Me.CleanerProgressBar.Value = 0
        Me.CleanerProgressBar.Visible = False
        '
        'NsListView1
        '
        Me.NsListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsListView1.CheckBoxes = False
        Me.NsListView1.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.NsListView1.ContextMenuStrip = Me.ctxListView
        Me.NsListView1.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.NsListView1.Location = New System.Drawing.Point(15, 67)
        Me.NsListView1.MultiSelect = True
        Me.NsListView1.Name = "NsListView1"
        Me.NsListView1.Size = New System.Drawing.Size(500, 437)
        Me.NsListView1.TabIndex = 3
        '
        'ctxListView
        '
        Me.ctxListView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ctxListView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsCopyPath, Me.tsOpenFileLocation, Me.tsSearchGoogle, Me.tsSearchVirusTotal})
        Me.ctxListView.Name = "ctxListView"
        Me.ctxListView.Size = New System.Drawing.Size(174, 92)
        '
        'tsCopyPath
        '
        Me.tsCopyPath.Name = "tsCopyPath"
        Me.tsCopyPath.Size = New System.Drawing.Size(173, 22)
        Me.tsCopyPath.Text = "Copy Path"
        '
        'tsOpenFileLocation
        '
        Me.tsOpenFileLocation.Name = "tsOpenFileLocation"
        Me.tsOpenFileLocation.Size = New System.Drawing.Size(173, 22)
        Me.tsOpenFileLocation.Text = "Open File Location"
        '
        'tsSearchGoogle
        '
        Me.tsSearchGoogle.Name = "tsSearchGoogle"
        Me.tsSearchGoogle.Size = New System.Drawing.Size(173, 22)
        Me.tsSearchGoogle.Text = "Search in Google"
        '
        'tsSearchVirusTotal
        '
        Me.tsSearchVirusTotal.Name = "tsSearchVirusTotal"
        Me.tsSearchVirusTotal.Size = New System.Drawing.Size(173, 22)
        Me.tsSearchVirusTotal.Text = "Search in VirusTotal"
        '
        'NsGroupBoxOptions
        '
        Me.NsGroupBoxOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsGroupBoxOptions.Controls.Add(Me.pnlOptions)
        Me.NsGroupBoxOptions.DrawSeperator = False
        Me.NsGroupBoxOptions.Location = New System.Drawing.Point(521, 67)
        Me.NsGroupBoxOptions.Name = "NsGroupBoxOptions"
        Me.NsGroupBoxOptions.Size = New System.Drawing.Size(184, 437)
        Me.NsGroupBoxOptions.SubTitle = ""
        Me.NsGroupBoxOptions.TabIndex = 4
        Me.NsGroupBoxOptions.Title = "Cleaner Options"
        '
        'pnlOptions
        '
        Me.pnlOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOptions.AutoScroll = True
        Me.pnlOptions.BackColor = System.Drawing.Color.Transparent
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
        Me.pnlOptions.Location = New System.Drawing.Point(0, 25)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(184, 412)
        Me.pnlOptions.TabIndex = 0
        '
        'chkTemp
        '
        Me.chkTemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkTemp.Checked = True
        Me.chkTemp.Location = New System.Drawing.Point(10, 3)
        Me.chkTemp.Name = "chkTemp"
        Me.chkTemp.Size = New System.Drawing.Size(169, 22)
        Me.chkTemp.TabIndex = 0
        Me.chkTemp.Text = "Temporary Files"
        '
        'chkRecycle
        '
        Me.chkRecycle.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkRecycle.Checked = True
        Me.chkRecycle.Location = New System.Drawing.Point(10, 30)
        Me.chkRecycle.Name = "chkRecycle"
        Me.chkRecycle.Size = New System.Drawing.Size(169, 22)
        Me.chkRecycle.TabIndex = 1
        Me.chkRecycle.Text = "Recycle Bin"
        '
        'chkIncompat
        '
        Me.chkIncompat.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkIncompat.Checked = True
        Me.chkIncompat.Location = New System.Drawing.Point(10, 55)
        Me.chkIncompat.Name = "chkIncompat"
        Me.chkIncompat.Size = New System.Drawing.Size(169, 22)
        Me.chkIncompat.TabIndex = 2
        Me.chkIncompat.Text = "Incompatible Files"
        '
        'chkThumb
        '
        Me.chkThumb.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkThumb.Checked = True
        Me.chkThumb.Location = New System.Drawing.Point(10, 80)
        Me.chkThumb.Name = "chkThumb"
        Me.chkThumb.Size = New System.Drawing.Size(169, 22)
        Me.chkThumb.TabIndex = 3
        Me.chkThumb.Text = "Thumbnail Caches"
        '
        'chkGames
        '
        Me.chkGames.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkGames.Checked = False
        Me.chkGames.Location = New System.Drawing.Point(10, 105)
        Me.chkGames.Name = "chkGames"
        Me.chkGames.Size = New System.Drawing.Size(169, 22)
        Me.chkGames.TabIndex = 4
        Me.chkGames.Text = "Game Caches"
        '
        'chkFolderCfg
        '
        Me.chkFolderCfg.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkFolderCfg.Checked = False
        Me.chkFolderCfg.Location = New System.Drawing.Point(10, 130)
        Me.chkFolderCfg.Name = "chkFolderCfg"
        Me.chkFolderCfg.Size = New System.Drawing.Size(169, 22)
        Me.chkFolderCfg.TabIndex = 5
        Me.chkFolderCfg.Text = "Folder Config Files"
        '
        'chkCookies
        '
        Me.chkCookies.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkCookies.Checked = False
        Me.chkCookies.Location = New System.Drawing.Point(10, 155)
        Me.chkCookies.Name = "chkCookies"
        Me.chkCookies.Size = New System.Drawing.Size(169, 22)
        Me.chkCookies.TabIndex = 6
        Me.chkCookies.Text = "Internet Cookies"
        '
        'chkCache
        '
        Me.chkCache.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkCache.Checked = True
        Me.chkCache.Location = New System.Drawing.Point(10, 180)
        Me.chkCache.Name = "chkCache"
        Me.chkCache.Size = New System.Drawing.Size(169, 22)
        Me.chkCache.TabIndex = 7
        Me.chkCache.Text = "Internet Cache"
        '
        'chkHistory
        '
        Me.chkHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkHistory.Checked = True
        Me.chkHistory.Location = New System.Drawing.Point(10, 205)
        Me.chkHistory.Name = "chkHistory"
        Me.chkHistory.Size = New System.Drawing.Size(169, 22)
        Me.chkHistory.TabIndex = 8
        Me.chkHistory.Text = "Internet History"
        '
        'chkLogs
        '
        Me.chkLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkLogs.Checked = True
        Me.chkLogs.Location = New System.Drawing.Point(10, 230)
        Me.chkLogs.Name = "chkLogs"
        Me.chkLogs.Size = New System.Drawing.Size(169, 22)
        Me.chkLogs.TabIndex = 9
        Me.chkLogs.Text = "Windows Logs"
        '
        'chkDumps
        '
        Me.chkDumps.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkDumps.Checked = True
        Me.chkDumps.Location = New System.Drawing.Point(10, 255)
        Me.chkDumps.Name = "chkDumps"
        Me.chkDumps.Size = New System.Drawing.Size(169, 22)
        Me.chkDumps.TabIndex = 10
        Me.chkDumps.Text = "Memory Dumps"
        '
        'chkRecent
        '
        Me.chkRecent.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkRecent.Checked = True
        Me.chkRecent.Location = New System.Drawing.Point(10, 280)
        Me.chkRecent.Name = "chkRecent"
        Me.chkRecent.Size = New System.Drawing.Size(169, 22)
        Me.chkRecent.TabIndex = 11
        Me.chkRecent.Text = "Recent Files"
        '
        'chkAppCache
        '
        Me.chkAppCache.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkAppCache.Checked = False
        Me.chkAppCache.Location = New System.Drawing.Point(10, 305)
        Me.chkAppCache.Name = "chkAppCache"
        Me.chkAppCache.Size = New System.Drawing.Size(169, 22)
        Me.chkAppCache.TabIndex = 12
        Me.chkAppCache.Text = "Application Caches"
        '
        'chkWinUpdate
        '
        Me.chkWinUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkWinUpdate.Checked = True
        Me.chkWinUpdate.Location = New System.Drawing.Point(10, 330)
        Me.chkWinUpdate.Name = "chkWinUpdate"
        Me.chkWinUpdate.Size = New System.Drawing.Size(169, 22)
        Me.chkWinUpdate.TabIndex = 13
        Me.chkWinUpdate.Text = "Windows Update Cache"
        '
        'chkDriverCache
        '
        Me.chkDriverCache.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkDriverCache.Checked = False
        Me.chkDriverCache.Location = New System.Drawing.Point(10, 355)
        Me.chkDriverCache.Name = "chkDriverCache"
        Me.chkDriverCache.Size = New System.Drawing.Size(169, 22)
        Me.chkDriverCache.TabIndex = 14
        Me.chkDriverCache.Text = "GPU Driver Cache"
        '
        'chkPkgCache
        '
        Me.chkPkgCache.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.chkPkgCache.Checked = False
        Me.chkPkgCache.Location = New System.Drawing.Point(10, 380)
        Me.chkPkgCache.Name = "chkPkgCache"
        Me.chkPkgCache.Size = New System.Drawing.Size(169, 22)
        Me.chkPkgCache.TabIndex = 15
        Me.chkPkgCache.Text = "Dev Package Caches"
        '
        'btnScan
        '
        Me.btnScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnScan.Location = New System.Drawing.Point(15, 510)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(95, 26)
        Me.btnScan.TabIndex = 5
        Me.btnScan.Text = "Scan"
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Enabled = False
        Me.btnClean.Location = New System.Drawing.Point(118, 510)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(95, 26)
        Me.btnClean.TabIndex = 6
        Me.btnClean.Text = "Clean"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(610, 510)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 26)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        '
        'WinCleaner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 548)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WinCleaner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Cleaner"
        Me.NsTheme1.ResumeLayout(False)
        Me.ctxListView.ResumeLayout(False)
        Me.NsGroupBoxOptions.ResumeLayout(False)
        Me.pnlOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents NsLabelStatus As Typhon.NSLabel
    Friend WithEvents CleanerProgressBar As Typhon.NSProgressBar
    Friend WithEvents NsListView1 As Typhon.NSListView
    Friend WithEvents ctxListView As Typhon.NSContextMenu
    Friend WithEvents tsCopyPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsOpenFileLocation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSearchGoogle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSearchVirusTotal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NsGroupBoxOptions As Typhon.NSGroupBox
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
