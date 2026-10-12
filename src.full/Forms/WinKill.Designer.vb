<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinKill
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim NsListViewColumnHeader1 As Typhon.NSListView.NSListViewColumnHeader = New Typhon.NSListView.NSListViewColumnHeader()
        Dim NsListViewColumnHeader2 As Typhon.NSListView.NSListViewColumnHeader = New Typhon.NSListView.NSListViewColumnHeader()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinKill))
        Me.themeContainer = New Typhon.NSTheme()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblSummary = New Typhon.NSLabel()
        Me.btnAction = New Typhon.NSButton()
        Me.lvProcesses = New Typhon.NSListView()
        Me.ctxProcessMenu = New Typhon.NSContextMenu()
        Me.menuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuToggleException = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSearchGoogle = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSearchVirusTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnControlClose = New Typhon.NSControlButton()
        Me.themeContainer.SuspendLayout()
        Me.ctxProcessMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'themeContainer
        '
        Me.themeContainer.AccentOffset = 42
        Me.themeContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.themeContainer.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.themeContainer.Colors = New Typhon.Bloom(-1) {}
        Me.themeContainer.Controls.Add(Me.lblDescription)
        Me.themeContainer.Controls.Add(Me.lblSummary)
        Me.themeContainer.Controls.Add(Me.btnAction)
        Me.themeContainer.Controls.Add(Me.lvProcesses)
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
        Me.themeContainer.Size = New System.Drawing.Size(300, 400)
        Me.themeContainer.SmartBounds = True
        Me.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.themeContainer.TabIndex = 0
        Me.themeContainer.Text = "Process Killer"
        Me.themeContainer.TransparencyKey = System.Drawing.Color.Empty
        Me.themeContainer.Transparent = False
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Location = New System.Drawing.Point(12, 39)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(276, 86)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Select background and child processes to terminate to recover system resources." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please save any unsaved work before proceeding."
        '
        'lblSummary
        '
        Me.lblSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSummary.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.Location = New System.Drawing.Point(3, 337)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(269, 23)
        Me.lblSummary.TabIndex = 3
        Me.lblSummary.Text = "lblSummary"
        Me.lblSummary.Value1 = "Summary:"
        Me.lblSummary.Value2 = " 0 processes (0 MB)"
        '
        'btnAction
        '
        Me.btnAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAction.Location = New System.Drawing.Point(188, 365)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(100, 23)
        Me.btnAction.TabIndex = 2
        Me.btnAction.Text = "Terminate"
        '
        'lvProcesses
        '
        Me.lvProcesses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProcesses.CheckBoxes = True
        NsListViewColumnHeader1.Text = "Process Name"
        NsListViewColumnHeader1.Width = 170
        NsListViewColumnHeader2.Text = "RAM"
        NsListViewColumnHeader2.Width = 80
        Me.lvProcesses.Columns = New Typhon.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1, NsListViewColumnHeader2}
        Me.lvProcesses.ContextMenuStrip = Me.ctxProcessMenu
        Me.lvProcesses.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lvProcesses.Location = New System.Drawing.Point(12, 128)
        Me.lvProcesses.MultiSelect = True
        Me.lvProcesses.Name = "lvProcesses"
        Me.lvProcesses.Size = New System.Drawing.Size(276, 206)
        Me.lvProcesses.TabIndex = 1
        Me.lvProcesses.Text = "lvProcesses"
        '
        'ctxProcessMenu
        '
        Me.ctxProcessMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ctxProcessMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSelectAll, Me.menuDeselectAll, Me.menuToggleException, Me.menuSearchGoogle, Me.menuSearchVirusTotal})
        Me.ctxProcessMenu.Name = "ctxProcessMenu"
        Me.ctxProcessMenu.Size = New System.Drawing.Size(178, 114)
        '
        'menuSelectAll
        '
        Me.menuSelectAll.Name = "menuSelectAll"
        Me.menuSelectAll.Size = New System.Drawing.Size(177, 22)
        Me.menuSelectAll.Text = "Select All"
        '
        'menuDeselectAll
        '
        Me.menuDeselectAll.Name = "menuDeselectAll"
        Me.menuDeselectAll.Size = New System.Drawing.Size(177, 22)
        Me.menuDeselectAll.Text = "Deselect All"
        '
        'menuToggleException
        '
        Me.menuToggleException.Name = "menuToggleException"
        Me.menuToggleException.Size = New System.Drawing.Size(177, 22)
        Me.menuToggleException.Text = "Add to Exceptions"
        '
        'menuSearchGoogle
        '
        Me.menuSearchGoogle.Name = "menuSearchGoogle"
        Me.menuSearchGoogle.Size = New System.Drawing.Size(177, 22)
        Me.menuSearchGoogle.Text = "Search in Google"
        '
        'menuSearchVirusTotal
        '
        Me.menuSearchVirusTotal.Name = "menuSearchVirusTotal"
        Me.menuSearchVirusTotal.Size = New System.Drawing.Size(177, 22)
        Me.menuSearchVirusTotal.Text = "Search in VirusTotal"
        '
        'btnControlClose
        '
        Me.btnControlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlClose.ControlButton = Typhon.NSControlButton.Button.Close
        Me.btnControlClose.Location = New System.Drawing.Point(277, 5)
        Me.btnControlClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.Name = "btnControlClose"
        Me.btnControlClose.Size = New System.Drawing.Size(18, 20)
        Me.btnControlClose.TabIndex = 0
        Me.btnControlClose.Text = "btnControlClose"
        '
        'WinKill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 400)
        Me.Controls.Add(Me.themeContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinKill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process Killer"
        Me.themeContainer.ResumeLayout(False)
        Me.ctxProcessMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents themeContainer As Typhon.NSTheme
    Friend WithEvents btnControlClose As Typhon.NSControlButton
    Friend WithEvents lblSummary As Typhon.NSLabel
    Friend WithEvents btnAction As Typhon.NSButton
    Friend WithEvents lvProcesses As Typhon.NSListView
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents ctxProcessMenu As Typhon.NSContextMenu
    Friend WithEvents menuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuToggleException As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSearchGoogle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSearchVirusTotal As System.Windows.Forms.ToolStripMenuItem
End Class
