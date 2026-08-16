<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinExceptions
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
        Dim NsListViewColumnHeader1 As Typhon.NSListView.NSListViewColumnHeader = New Typhon.NSListView.NSListViewColumnHeader()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinExceptions))
        Me.NsTheme1 = New Typhon.NSTheme()
        Me.NsControlButton1 = New Typhon.NSControlButton()
        Me.NsListView1 = New Typhon.NSListView()
        Me.NsContextMenu1 = New Typhon.NSContextMenu()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SearchGoogleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchVirusTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboProcesses = New Typhon.NSComboBox()
        Me.txtCustomExe = New Typhon.NSTextBox()
        Me.btnAdd = New Typhon.NSButton()
        Me.btnRemove = New Typhon.NSButton()
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
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.NsListView1)
        Me.NsTheme1.Controls.Add(Me.cboProcesses)
        Me.NsTheme1.Controls.Add(Me.txtCustomExe)
        Me.NsTheme1.Controls.Add(Me.btnAdd)
        Me.NsTheme1.Controls.Add(Me.btnRemove)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(340, 395)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Process Exceptions"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(315, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'NsListView1
        '
        Me.NsListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsListView1.CheckBoxes = False
        NsListViewColumnHeader1.Text = "Executable Name"
        NsListViewColumnHeader1.Width = 290
        Me.NsListView1.Columns = New Typhon.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1}
        Me.NsListView1.ContextMenuStrip = Me.NsContextMenu1
        Me.NsListView1.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.NsListView1.Location = New System.Drawing.Point(12, 40)
        Me.NsListView1.MultiSelect = True
        Me.NsListView1.Name = "NsListView1"
        Me.NsListView1.Size = New System.Drawing.Size(316, 265)
        Me.NsListView1.TabIndex = 1
        Me.NsListView1.Text = "NsListView1"
        '
        'NsContextMenu1
        '
        Me.NsContextMenu1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.NsContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem, Me.ToolStripSeparator1, Me.SearchGoogleToolStripMenuItem, Me.SearchVirusTotalToolStripMenuItem})
        Me.NsContextMenu1.Name = "NsContextMenu1"
        Me.NsContextMenu1.Size = New System.Drawing.Size(185, 76)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove: {filename}"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(181, 6)
        '
        'SearchGoogleToolStripMenuItem
        '
        Me.SearchGoogleToolStripMenuItem.Name = "SearchGoogleToolStripMenuItem"
        Me.SearchGoogleToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SearchGoogleToolStripMenuItem.Text = "Search in Google"
        '
        'SearchVirusTotalToolStripMenuItem
        '
        Me.SearchVirusTotalToolStripMenuItem.Name = "SearchVirusTotalToolStripMenuItem"
        Me.SearchVirusTotalToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SearchVirusTotalToolStripMenuItem.Text = "Search in VirusTotal"
        '
        'cboProcesses
        '
        Me.cboProcesses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProcesses.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cboProcesses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcesses.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboProcesses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cboProcesses.FormattingEnabled = True
        Me.cboProcesses.Location = New System.Drawing.Point(12, 318)
        Me.cboProcesses.Name = "cboProcesses"
        Me.cboProcesses.Size = New System.Drawing.Size(160, 21)
        Me.cboProcesses.TabIndex = 2
        '
        'txtCustomExe
        '
        Me.txtCustomExe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomExe.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomExe.Location = New System.Drawing.Point(12, 350)
        Me.txtCustomExe.MaxLength = 32767
        Me.txtCustomExe.Multiline = False
        Me.txtCustomExe.Name = "txtCustomExe"
        Me.txtCustomExe.ReadOnly = False
        Me.txtCustomExe.Size = New System.Drawing.Size(160, 23)
        Me.txtCustomExe.TabIndex = 3
        Me.txtCustomExe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCustomExe.UseSystemPasswordChar = False
        Me.txtCustomExe.Watermark = "e.g. game.exe"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(180, 318)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(70, 55)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(258, 318)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(70, 55)
        Me.btnRemove.TabIndex = 5
        Me.btnRemove.Text = "Remove"
        '
        'WinExceptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 395)
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinExceptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Process Exceptions"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents NsListView1 As Typhon.NSListView
    Friend WithEvents cboProcesses As Typhon.NSComboBox
    Friend WithEvents txtCustomExe As Typhon.NSTextBox
    Friend WithEvents btnAdd As Typhon.NSButton
    Friend WithEvents btnRemove As Typhon.NSButton
    Friend WithEvents NsContextMenu1 As Typhon.NSContextMenu
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SearchGoogleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchVirusTotalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
