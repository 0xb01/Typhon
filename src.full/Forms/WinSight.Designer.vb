<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinSight
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinSight))
        Me.themeContainer = New Typhon.NSTheme()
        Me.btnControlMinimize = New Typhon.NSControlButton()
        Me.btnControlClose = New Typhon.NSControlButton()
        Me.btnControlMaximize = New Typhon.NSControlButton()
        Me.cboDrives = New Typhon.NSComboBox()
        Me.btnScan = New Typhon.NSButton()
        Me.lblPath = New Typhon.NSLabel()
        Me.pbScanProgress = New Typhon.NSProgressBar()
        Me.splitStorageViews = New System.Windows.Forms.SplitContainer()
        Me.lvFiles = New Typhon.NSListView()
        Me.ctxTreemap = New Typhon.NSContextMenu()
        Me.tsOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAddToExceptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSearchGoogle = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCheckVirusTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsOpenInExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCopyPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDeleteFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.treemapSpaceLens = New Typhon.Controls.SpaceLensTreemap()
        Me.lblHoverInfo = New Typhon.NSLabel()
        Me.btnOpenExplorer = New Typhon.NSButton()
        Me.themeContainer.SuspendLayout()
        CType(Me.splitStorageViews, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitStorageViews.Panel1.SuspendLayout()
        Me.splitStorageViews.Panel2.SuspendLayout()
        Me.splitStorageViews.SuspendLayout()
        Me.ctxTreemap.SuspendLayout()
        Me.SuspendLayout()
        '
        'themeContainer
        '
        Me.themeContainer.AccentOffset = 42
        Me.themeContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.themeContainer.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.themeContainer.Colors = New Typhon.Bloom(-1) {}
        Me.themeContainer.Controls.Add(Me.btnControlMinimize)
        Me.themeContainer.Controls.Add(Me.btnControlClose)
        Me.themeContainer.Controls.Add(Me.btnControlMaximize)
        Me.themeContainer.Controls.Add(Me.cboDrives)
        Me.themeContainer.Controls.Add(Me.btnScan)
        Me.themeContainer.Controls.Add(Me.lblPath)
        Me.themeContainer.Controls.Add(Me.pbScanProgress)
        Me.themeContainer.Controls.Add(Me.splitStorageViews)
        Me.themeContainer.Controls.Add(Me.lblHoverInfo)
        Me.themeContainer.Controls.Add(Me.btnOpenExplorer)
        Me.themeContainer.Customization = ""
        Me.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.themeContainer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.themeContainer.Image = Nothing
        Me.themeContainer.Location = New System.Drawing.Point(0, 0)
        Me.themeContainer.Movable = True
        Me.themeContainer.Name = "themeContainer"
        Me.themeContainer.NoRounding = False
        Me.themeContainer.Sizable = True
        Me.themeContainer.Size = New System.Drawing.Size(960, 680)
        Me.themeContainer.SmartBounds = True
        Me.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.themeContainer.TabIndex = 0
        Me.themeContainer.Text = "Sight"
        Me.themeContainer.TransparencyKey = System.Drawing.Color.Empty
        Me.themeContainer.Transparent = False
        '
        'btnControlMinimize
        '
        Me.btnControlMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlMinimize.ControlButton = Typhon.NSControlButton.Button.Minimize
        Me.btnControlMinimize.Location = New System.Drawing.Point(899, 4)
        Me.btnControlMinimize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlMinimize.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.Name = "btnControlMinimize"
        Me.btnControlMinimize.Size = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.TabIndex = 0
        Me.btnControlMinimize.Text = "btnControlMinimize"
        '
        'btnControlClose
        '
        Me.btnControlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlClose.ControlButton = Typhon.NSControlButton.Button.Close
        Me.btnControlClose.Location = New System.Drawing.Point(937, 4)
        Me.btnControlClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.Name = "btnControlClose"
        Me.btnControlClose.Size = New System.Drawing.Size(18, 20)
        Me.btnControlClose.TabIndex = 0
        Me.btnControlClose.Text = "btnControlClose"
        '
        'btnControlMaximize
        '
        Me.btnControlMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlMaximize.ControlButton = Typhon.NSControlButton.Button.MaximizeRestore
        Me.btnControlMaximize.Location = New System.Drawing.Point(918, 4)
        Me.btnControlMaximize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlMaximize.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMaximize.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMaximize.Name = "btnControlMaximize"
        Me.btnControlMaximize.Size = New System.Drawing.Size(18, 20)
        Me.btnControlMaximize.TabIndex = 1
        Me.btnControlMaximize.Text = "btnControlMaximize"
        '
        'cboDrives
        '
        Me.cboDrives.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cboDrives.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDrives.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cboDrives.FormattingEnabled = True
        Me.cboDrives.Location = New System.Drawing.Point(12, 38)
        Me.cboDrives.Name = "cboDrives"
        Me.cboDrives.Size = New System.Drawing.Size(206, 21)
        Me.cboDrives.TabIndex = 2
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(224, 37)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(90, 23)
        Me.btnScan.TabIndex = 3
        Me.btnScan.Text = "Start Sight"
        '
        'lblPath
        '
        Me.lblPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPath.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.Location = New System.Drawing.Point(320, 37)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(510, 23)
        Me.lblPath.TabIndex = 4
        Me.lblPath.Text = "lblPath"
        Me.lblPath.Value1 = "Path:"
        Me.lblPath.Value2 = " Select Drive"
        '
        'pbScanProgress
        '
        Me.pbScanProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbScanProgress.Location = New System.Drawing.Point(12, 65)
        Me.pbScanProgress.Maximum = 100
        Me.pbScanProgress.Minimum = 0
        Me.pbScanProgress.Name = "pbScanProgress"
        Me.pbScanProgress.Size = New System.Drawing.Size(936, 12)
        Me.pbScanProgress.TabIndex = 6
        Me.pbScanProgress.Text = "pbScanProgress"
        Me.pbScanProgress.Value = 0
        '
        'splitStorageViews
        '
        Me.splitStorageViews.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitStorageViews.Location = New System.Drawing.Point(12, 83)
        Me.splitStorageViews.Name = "splitStorageViews"
        Me.splitStorageViews.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitStorageViews.Panel1
        '
        Me.splitStorageViews.Panel1.Controls.Add(Me.lvFiles)
        '
        'splitStorageViews.Panel2
        '
        Me.splitStorageViews.Panel2.Controls.Add(Me.treemapSpaceLens)
        Me.splitStorageViews.Size = New System.Drawing.Size(936, 560)
        Me.splitStorageViews.SplitterDistance = 220
        Me.splitStorageViews.TabIndex = 7
        '
        'lvFiles
        '
        Me.lvFiles.CheckBoxes = False
        Me.lvFiles.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.lvFiles.ContextMenuStrip = Me.ctxTreemap
        Me.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvFiles.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lvFiles.Location = New System.Drawing.Point(0, 0)
        Me.lvFiles.MultiSelect = True
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(936, 220)
        Me.lvFiles.TabIndex = 0
        Me.lvFiles.Text = "lvFiles"
        '
        'ctxTreemap
        '
        Me.ctxTreemap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ctxTreemap.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsOpenFile, Me.tsAddToExceptions, Me.tsSearchGoogle, Me.tsCheckVirusTotal, Me.tsSeparator1, Me.tsOpenInExplorer, Me.tsCopyPath, Me.tsSeparator2, Me.tsDeleteFile})
        Me.ctxTreemap.Name = "ctxTreemap"
        Me.ctxTreemap.Size = New System.Drawing.Size(178, 170)
        '
        'tsOpenFile
        '
        Me.tsOpenFile.Name = "tsOpenFile"
        Me.tsOpenFile.Size = New System.Drawing.Size(177, 22)
        Me.tsOpenFile.Text = "Open File"
        '
        'tsAddToExceptions
        '
        Me.tsAddToExceptions.Name = "tsAddToExceptions"
        Me.tsAddToExceptions.Size = New System.Drawing.Size(177, 22)
        Me.tsAddToExceptions.Text = "Add to Exceptions"
        '
        'tsSearchGoogle
        '
        Me.tsSearchGoogle.Name = "tsSearchGoogle"
        Me.tsSearchGoogle.Size = New System.Drawing.Size(177, 22)
        Me.tsSearchGoogle.Text = "Search in Google"
        '
        'tsCheckVirusTotal
        '
        Me.tsCheckVirusTotal.Name = "tsCheckVirusTotal"
        Me.tsCheckVirusTotal.Size = New System.Drawing.Size(177, 22)
        Me.tsCheckVirusTotal.Text = "Check in VirusTotal"
        '
        'tsSeparator1
        '
        Me.tsSeparator1.Name = "tsSeparator1"
        Me.tsSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'tsOpenInExplorer
        '
        Me.tsOpenInExplorer.Name = "tsOpenInExplorer"
        Me.tsOpenInExplorer.Size = New System.Drawing.Size(177, 22)
        Me.tsOpenInExplorer.Text = "Open in Explorer"
        '
        'tsCopyPath
        '
        Me.tsCopyPath.Name = "tsCopyPath"
        Me.tsCopyPath.Size = New System.Drawing.Size(177, 22)
        Me.tsCopyPath.Text = "Copy Path"
        '
        'tsSeparator2
        '
        Me.tsSeparator2.Name = "tsSeparator2"
        Me.tsSeparator2.Size = New System.Drawing.Size(174, 6)
        '
        'tsDeleteFile
        '
        Me.tsDeleteFile.Name = "tsDeleteFile"
        Me.tsDeleteFile.Size = New System.Drawing.Size(177, 22)
        Me.tsDeleteFile.Text = "Delete Permanently"
        '
        'treemapSpaceLens
        '
        Me.treemapSpaceLens.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.treemapSpaceLens.ContextMenuStrip = Me.ctxTreemap
        Me.treemapSpaceLens.CurrentNode = Nothing
        Me.treemapSpaceLens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treemapSpaceLens.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.treemapSpaceLens.Location = New System.Drawing.Point(0, 0)
        Me.treemapSpaceLens.Name = "treemapSpaceLens"
        Me.treemapSpaceLens.RootNode = Nothing
        Me.treemapSpaceLens.SelectedNode = Nothing
        Me.treemapSpaceLens.Size = New System.Drawing.Size(936, 336)
        Me.treemapSpaceLens.TabIndex = 0
        Me.treemapSpaceLens.Text = "treemapSpaceLens"
        '
        'lblHoverInfo
        '
        Me.lblHoverInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHoverInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoverInfo.Location = New System.Drawing.Point(12, 649)
        Me.lblHoverInfo.Name = "lblHoverInfo"
        Me.lblHoverInfo.Size = New System.Drawing.Size(936, 23)
        Me.lblHoverInfo.TabIndex = 8
        Me.lblHoverInfo.Text = "lblHoverInfo"
        Me.lblHoverInfo.Value1 = "Hover:"
        Me.lblHoverInfo.Value2 = " Ready"
        '
        'btnOpenExplorer
        '
        Me.btnOpenExplorer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenExplorer.Location = New System.Drawing.Point(836, 37)
        Me.btnOpenExplorer.Name = "btnOpenExplorer"
        Me.btnOpenExplorer.Size = New System.Drawing.Size(112, 23)
        Me.btnOpenExplorer.TabIndex = 9
        Me.btnOpenExplorer.Text = "Open in Explorer"
        '
        'WinSight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 680)
        Me.Controls.Add(Me.themeContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinSight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sight"
        Me.themeContainer.ResumeLayout(False)
        Me.splitStorageViews.Panel1.ResumeLayout(False)
        Me.splitStorageViews.Panel2.ResumeLayout(False)
        CType(Me.splitStorageViews, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitStorageViews.ResumeLayout(False)
        Me.ctxTreemap.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents themeContainer As Typhon.NSTheme
    Friend WithEvents btnControlClose As Typhon.NSControlButton
    Friend WithEvents btnControlMaximize As Typhon.NSControlButton
    Friend WithEvents btnControlMinimize As Typhon.NSControlButton
    Friend WithEvents cboDrives As Typhon.NSComboBox
    Friend WithEvents btnScan As Typhon.NSButton
    Friend WithEvents lblPath As Typhon.NSLabel
    Friend WithEvents pbScanProgress As Typhon.NSProgressBar
    Friend WithEvents splitStorageViews As System.Windows.Forms.SplitContainer
    Friend WithEvents lvFiles As Typhon.NSListView
    Friend WithEvents treemapSpaceLens As Typhon.Controls.SpaceLensTreemap
    Friend WithEvents lblHoverInfo As Typhon.NSLabel
    Friend WithEvents btnOpenExplorer As Typhon.NSButton
    Friend WithEvents ctxTreemap As Typhon.NSContextMenu
    Friend WithEvents tsOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAddToExceptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSearchGoogle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCheckVirusTotal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsOpenInExplorer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCopyPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDeleteFile As System.Windows.Forms.ToolStripMenuItem
End Class
