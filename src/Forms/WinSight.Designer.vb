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
        Me.NsTheme1 = New Typhon.NSTheme()
        Me.NsControlButton3 = New Typhon.NSControlButton()
        Me.NsControlButton1 = New Typhon.NSControlButton()
        Me.NsControlButton2 = New Typhon.NSControlButton()
        Me.cboDrives = New Typhon.NSComboBox()
        Me.btnScan = New Typhon.NSButton()
        Me.lblPath = New Typhon.NSLabel()
        Me.lblCapacity = New Typhon.NSLabel()
        Me.LensProgressBar = New Typhon.NSProgressBar()
        Me.SplitMain = New System.Windows.Forms.SplitContainer()
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
        Me.TreemapCanvas = New Typhon.Controls.SpaceLensTreemap()
        Me.lblHoverInfo = New Typhon.NSLabel()
        Me.btnOpenExplorer = New Typhon.NSButton()
        Me.NsTheme1.SuspendLayout()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMain.Panel1.SuspendLayout()
        Me.SplitMain.Panel2.SuspendLayout()
        Me.SplitMain.SuspendLayout()
        Me.ctxTreemap.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New Typhon.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsControlButton3)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.NsControlButton2)
        Me.NsTheme1.Controls.Add(Me.cboDrives)
        Me.NsTheme1.Controls.Add(Me.btnScan)
        Me.NsTheme1.Controls.Add(Me.lblPath)
        Me.NsTheme1.Controls.Add(Me.lblCapacity)
        Me.NsTheme1.Controls.Add(Me.LensProgressBar)
        Me.NsTheme1.Controls.Add(Me.SplitMain)
        Me.NsTheme1.Controls.Add(Me.lblHoverInfo)
        Me.NsTheme1.Controls.Add(Me.btnOpenExplorer)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(960, 680)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Typhon Sight - Storage Visualizer"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsControlButton3
        '
        Me.NsControlButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton3.ControlButton = Typhon.NSControlButton.Button.Minimize
        Me.NsControlButton3.Location = New System.Drawing.Point(899, 4)
        Me.NsControlButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton3.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.Name = "NsControlButton3"
        Me.NsControlButton3.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton3.TabIndex = 0
        Me.NsControlButton3.Text = "NsControlButton3"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(935, 4)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'NsControlButton2
        '
        Me.NsControlButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton2.ControlButton = Typhon.NSControlButton.Button.MaximizeRestore
        Me.NsControlButton2.Location = New System.Drawing.Point(917, 4)
        Me.NsControlButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton2.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.Name = "NsControlButton2"
        Me.NsControlButton2.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.TabIndex = 1
        Me.NsControlButton2.Text = "NsControlButton2"
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
        Me.cboDrives.Size = New System.Drawing.Size(306, 21)
        Me.cboDrives.TabIndex = 2
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(324, 37)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(100, 23)
        Me.btnScan.TabIndex = 3
        Me.btnScan.Text = "Start Sight"
        '
        'lblPath
        '
        Me.lblPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPath.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPath.Location = New System.Drawing.Point(430, 37)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(518, 23)
        Me.lblPath.TabIndex = 5
        Me.lblPath.Text = "Current Path"
        Me.lblPath.Value1 = "Path: "
        Me.lblPath.Value2 = " -"
        '
        'lblCapacity
        '
        Me.lblCapacity.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity.Location = New System.Drawing.Point(14, 65)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(460, 15)
        Me.lblCapacity.TabIndex = 7
        Me.lblCapacity.Text = "Capacity"
        Me.lblCapacity.Value1 = "Drive Usage: "
        Me.lblCapacity.Value2 = " -"
        '
        'LensProgressBar
        '
        Me.LensProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LensProgressBar.Location = New System.Drawing.Point(12, 82)
        Me.LensProgressBar.Maximum = 100
        Me.LensProgressBar.Minimum = 0
        Me.LensProgressBar.Name = "LensProgressBar"
        Me.LensProgressBar.Size = New System.Drawing.Size(936, 10)
        Me.LensProgressBar.TabIndex = 8
        Me.LensProgressBar.Text = "NsProgressBar1"
        Me.LensProgressBar.Value = 0
        '
        'SplitMain
        '
        Me.SplitMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitMain.Location = New System.Drawing.Point(12, 98)
        Me.SplitMain.Name = "SplitMain"
        '
        'SplitMain.Panel1
        '
        Me.SplitMain.Panel1.Controls.Add(Me.lvFiles)
        '
        'SplitMain.Panel2
        '
        Me.SplitMain.Panel2.Controls.Add(Me.TreemapCanvas)
        Me.SplitMain.Size = New System.Drawing.Size(936, 538)
        Me.SplitMain.SplitterDistance = 480
        Me.SplitMain.SplitterWidth = 5
        Me.SplitMain.TabIndex = 9
        '
        'lvFiles
        '
        Me.lvFiles.CheckBoxes = False
        Me.lvFiles.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.lvFiles.ContextMenuStrip = Me.ctxTreemap
        Me.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvFiles.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lvFiles.Location = New System.Drawing.Point(0, 0)
        Me.lvFiles.MultiSelect = False
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(480, 538)
        Me.lvFiles.TabIndex = 0
        Me.lvFiles.Text = "lvFiles"
        '
        'ctxTreemap
        '
        Me.ctxTreemap.ForeColor = System.Drawing.Color.White
        Me.ctxTreemap.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsOpenFile, Me.tsAddToExceptions, Me.tsSearchGoogle, Me.tsCheckVirusTotal, Me.tsSeparator1, Me.tsOpenInExplorer, Me.tsCopyPath, Me.tsSeparator2, Me.tsDeleteFile})
        Me.ctxTreemap.Name = "ctxTreemap"
        Me.ctxTreemap.Size = New System.Drawing.Size(225, 170)
        '
        'tsOpenFile
        '
        Me.tsOpenFile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsOpenFile.Name = "tsOpenFile"
        Me.tsOpenFile.Size = New System.Drawing.Size(224, 22)
        Me.tsOpenFile.Text = "Open {filename}"
        '
        'tsAddToExceptions
        '
        Me.tsAddToExceptions.Name = "tsAddToExceptions"
        Me.tsAddToExceptions.Size = New System.Drawing.Size(224, 22)
        Me.tsAddToExceptions.Text = "Add to Exception: {filename}"
        '
        'tsSearchGoogle
        '
        Me.tsSearchGoogle.Name = "tsSearchGoogle"
        Me.tsSearchGoogle.Size = New System.Drawing.Size(224, 22)
        Me.tsSearchGoogle.Text = "Search in Google: {filename}"
        '
        'tsCheckVirusTotal
        '
        Me.tsCheckVirusTotal.Name = "tsCheckVirusTotal"
        Me.tsCheckVirusTotal.Size = New System.Drawing.Size(224, 22)
        Me.tsCheckVirusTotal.Text = "Check VirusTotal: {filename}"
        '
        'tsSeparator1
        '
        Me.tsSeparator1.Name = "tsSeparator1"
        Me.tsSeparator1.Size = New System.Drawing.Size(221, 6)
        '
        'tsOpenInExplorer
        '
        Me.tsOpenInExplorer.Name = "tsOpenInExplorer"
        Me.tsOpenInExplorer.Size = New System.Drawing.Size(224, 22)
        Me.tsOpenInExplorer.Text = "Open in Explorer"
        '
        'tsCopyPath
        '
        Me.tsCopyPath.Name = "tsCopyPath"
        Me.tsCopyPath.Size = New System.Drawing.Size(224, 22)
        Me.tsCopyPath.Text = "Copy Full Path"
        '
        'tsSeparator2
        '
        Me.tsSeparator2.Name = "tsSeparator2"
        Me.tsSeparator2.Size = New System.Drawing.Size(221, 6)
        '
        'tsDeleteFile
        '
        Me.tsDeleteFile.Name = "tsDeleteFile"
        Me.tsDeleteFile.Size = New System.Drawing.Size(224, 22)
        Me.tsDeleteFile.Text = "Delete (Recycle Bin)"
        '
        'TreemapCanvas
        '
        Me.TreemapCanvas.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.TreemapCanvas.ContextMenuStrip = Me.ctxTreemap
        Me.TreemapCanvas.CurrentNode = Nothing
        Me.TreemapCanvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreemapCanvas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreemapCanvas.Location = New System.Drawing.Point(0, 0)
        Me.TreemapCanvas.Name = "TreemapCanvas"
        Me.TreemapCanvas.RootNode = Nothing
        Me.TreemapCanvas.SelectedNode = Nothing
        Me.TreemapCanvas.Size = New System.Drawing.Size(451, 538)
        Me.TreemapCanvas.TabIndex = 0
        Me.TreemapCanvas.Text = "TreemapCanvas"
        '
        'lblHoverInfo
        '
        Me.lblHoverInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHoverInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoverInfo.Location = New System.Drawing.Point(12, 644)
        Me.lblHoverInfo.Name = "lblHoverInfo"
        Me.lblHoverInfo.Size = New System.Drawing.Size(800, 23)
        Me.lblHoverInfo.TabIndex = 10
        Me.lblHoverInfo.Text = "Target"
        Me.lblHoverInfo.Value1 = "Selected: "
        Me.lblHoverInfo.Value2 = " Hover or click a block/item to inspect."
        '
        'btnOpenExplorer
        '
        Me.btnOpenExplorer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenExplorer.Location = New System.Drawing.Point(818, 644)
        Me.btnOpenExplorer.Name = "btnOpenExplorer"
        Me.btnOpenExplorer.Size = New System.Drawing.Size(130, 23)
        Me.btnOpenExplorer.TabIndex = 11
        Me.btnOpenExplorer.Text = "Open in Explorer"
        '
        'WinSight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 680)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinSight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sight"
        Me.NsTheme1.ResumeLayout(False)
        Me.SplitMain.Panel1.ResumeLayout(False)
        Me.SplitMain.Panel2.ResumeLayout(False)
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMain.ResumeLayout(False)
        Me.ctxTreemap.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents NsControlButton2 As Typhon.NSControlButton
    Friend WithEvents cboDrives As Typhon.NSComboBox
    Friend WithEvents btnScan As Typhon.NSButton
    Friend WithEvents lblPath As Typhon.NSLabel
    Friend WithEvents lblCapacity As Typhon.NSLabel
    Friend WithEvents LensProgressBar As Typhon.NSProgressBar
    Friend WithEvents SplitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lvFiles As Typhon.NSListView
    Friend WithEvents TreemapCanvas As Typhon.Controls.SpaceLensTreemap
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
    Friend WithEvents NsControlButton3 As NSControlButton
End Class
