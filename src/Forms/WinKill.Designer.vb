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
        Me.NsTheme1 = New Typhon.NSTheme()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NsLabel1 = New Typhon.NSLabel()
        Me.NsButton1 = New Typhon.NSButton()
        Me.NsListView1 = New Typhon.NSListView()
        Me.NsContextMenu1 = New Typhon.NSContextMenu()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeselectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToIgnoreListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchGoogleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchVirusTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NsControlButton1 = New Typhon.NSControlButton()
        Me.NsTheme1.SuspendLayout()
        Me.NsContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New Typhon.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.Label1)
        Me.NsTheme1.Controls.Add(Me.NsLabel1)
        Me.NsTheme1.Controls.Add(Me.NsButton1)
        Me.NsTheme1.Controls.Add(Me.NsListView1)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(300, 400)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Process Killer"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 86)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Killable parent and child processes have been listed, these processes will be kil" &
    "led to improve performance." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please save any important documents before procee" &
    "ding!"
        '
        'NsLabel1
        '
        Me.NsLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NsLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel1.Location = New System.Drawing.Point(3, 337)
        Me.NsLabel1.Name = "NsLabel1"
        Me.NsLabel1.Size = New System.Drawing.Size(269, 23)
        Me.NsLabel1.TabIndex = 3
        Me.NsLabel1.Text = "NsLabel1"
        Me.NsLabel1.Value1 = "Summary:"
        Me.NsLabel1.Value2 = " 0 processes (0 MB)"
        '
        'NsButton1
        '
        Me.NsButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsButton1.Location = New System.Drawing.Point(188, 365)
        Me.NsButton1.Name = "NsButton1"
        Me.NsButton1.Size = New System.Drawing.Size(100, 23)
        Me.NsButton1.TabIndex = 2
        Me.NsButton1.Text = "Kill();"
        '
        'NsListView1
        '
        Me.NsListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsListView1.CheckBoxes = True
        NsListViewColumnHeader1.Text = "Process Name"
        NsListViewColumnHeader1.Width = 170
        NsListViewColumnHeader2.Text = "RAM"
        NsListViewColumnHeader2.Width = 80
        Me.NsListView1.Columns = New Typhon.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1, NsListViewColumnHeader2}
        Me.NsListView1.ContextMenuStrip = Me.NsContextMenu1
        Me.NsListView1.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.NsListView1.Location = New System.Drawing.Point(12, 128)
        Me.NsListView1.MultiSelect = True
        Me.NsListView1.Name = "NsListView1"
        Me.NsListView1.Size = New System.Drawing.Size(276, 206)
        Me.NsListView1.TabIndex = 1
        Me.NsListView1.Text = "NsListView1"
        '
        'NsContextMenu1
        '
        Me.NsContextMenu1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.NsContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.DeselectAllToolStripMenuItem, Me.AddToIgnoreListToolStripMenuItem, Me.SearchGoogleToolStripMenuItem, Me.SearchVirusTotalToolStripMenuItem})
        Me.NsContextMenu1.Name = "NsContextMenu1"
        Me.NsContextMenu1.Size = New System.Drawing.Size(178, 114)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'DeselectAllToolStripMenuItem
        '
        Me.DeselectAllToolStripMenuItem.Name = "DeselectAllToolStripMenuItem"
        Me.DeselectAllToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.DeselectAllToolStripMenuItem.Text = "Deselect All"
        '
        'AddToIgnoreListToolStripMenuItem
        '
        Me.AddToIgnoreListToolStripMenuItem.Name = "AddToIgnoreListToolStripMenuItem"
        Me.AddToIgnoreListToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.AddToIgnoreListToolStripMenuItem.Text = "Add to Exceptions"
        '
        'SearchGoogleToolStripMenuItem
        '
        Me.SearchGoogleToolStripMenuItem.Name = "SearchGoogleToolStripMenuItem"
        Me.SearchGoogleToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SearchGoogleToolStripMenuItem.Text = "Search in Google"
        '
        'SearchVirusTotalToolStripMenuItem
        '
        Me.SearchVirusTotalToolStripMenuItem.Name = "SearchVirusTotalToolStripMenuItem"
        Me.SearchVirusTotalToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SearchVirusTotalToolStripMenuItem.Text = "Search in VirusTotal"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(277, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'WinKill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 400)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinKill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process Killer"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents NsLabel1 As Typhon.NSLabel
    Friend WithEvents NsButton1 As Typhon.NSButton
    Friend WithEvents NsListView1 As Typhon.NSListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NsContextMenu1 As Typhon.NSContextMenu
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeselectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToIgnoreListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchGoogleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchVirusTotalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
