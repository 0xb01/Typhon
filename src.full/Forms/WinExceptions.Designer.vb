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
        Me.themeContainer = New Typhon.NSTheme()
        Me.btnControlClose = New Typhon.NSControlButton()
        Me.lvExceptions = New Typhon.NSListView()
        Me.ctxExceptionsMenu = New Typhon.NSContextMenu()
        Me.menuRemoveException = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuSearchGoogle = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSearchVirusTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboRunningProcesses = New Typhon.NSComboBox()
        Me.txtCustomExecutable = New Typhon.NSTextBox()
        Me.btnAddException = New Typhon.NSButton()
        Me.btnRemoveException = New Typhon.NSButton()
        Me.themeContainer.SuspendLayout()
        Me.ctxExceptionsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'themeContainer
        '
        Me.themeContainer.AccentOffset = 42
        Me.themeContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.themeContainer.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.themeContainer.Colors = New Typhon.Bloom(-1) {}
        Me.themeContainer.Controls.Add(Me.btnControlClose)
        Me.themeContainer.Controls.Add(Me.lvExceptions)
        Me.themeContainer.Controls.Add(Me.cboRunningProcesses)
        Me.themeContainer.Controls.Add(Me.txtCustomExecutable)
        Me.themeContainer.Controls.Add(Me.btnAddException)
        Me.themeContainer.Controls.Add(Me.btnRemoveException)
        Me.themeContainer.Customization = ""
        Me.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.themeContainer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.themeContainer.Image = Nothing
        Me.themeContainer.Location = New System.Drawing.Point(0, 0)
        Me.themeContainer.Movable = True
        Me.themeContainer.Name = "themeContainer"
        Me.themeContainer.NoRounding = False
        Me.themeContainer.Sizable = False
        Me.themeContainer.Size = New System.Drawing.Size(340, 395)
        Me.themeContainer.SmartBounds = True
        Me.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.themeContainer.TabIndex = 0
        Me.themeContainer.Text = "Process Exceptions"
        Me.themeContainer.TransparencyKey = System.Drawing.Color.Empty
        Me.themeContainer.Transparent = False
        '
        'btnControlClose
        '
        Me.btnControlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlClose.ControlButton = Typhon.NSControlButton.Button.Close
        Me.btnControlClose.Location = New System.Drawing.Point(315, 5)
        Me.btnControlClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.Name = "btnControlClose"
        Me.btnControlClose.Size = New System.Drawing.Size(18, 20)
        Me.btnControlClose.TabIndex = 0
        Me.btnControlClose.Text = "btnControlClose"
        '
        'lvExceptions
        '
        Me.lvExceptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvExceptions.CheckBoxes = False
        NsListViewColumnHeader1.Text = "Executable Name"
        NsListViewColumnHeader1.Width = 290
        Me.lvExceptions.Columns = New Typhon.NSListView.NSListViewColumnHeader() {NsListViewColumnHeader1}
        Me.lvExceptions.ContextMenuStrip = Me.ctxExceptionsMenu
        Me.lvExceptions.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lvExceptions.Location = New System.Drawing.Point(12, 40)
        Me.lvExceptions.MultiSelect = True
        Me.lvExceptions.Name = "lvExceptions"
        Me.lvExceptions.Size = New System.Drawing.Size(316, 265)
        Me.lvExceptions.TabIndex = 1
        Me.lvExceptions.Text = "lvExceptions"
        '
        'ctxExceptionsMenu
        '
        Me.ctxExceptionsMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ctxExceptionsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRemoveException, Me.ToolStripSeparator1, Me.menuSearchGoogle, Me.menuSearchVirusTotal})
        Me.ctxExceptionsMenu.Name = "ctxExceptionsMenu"
        Me.ctxExceptionsMenu.Size = New System.Drawing.Size(178, 76)
        '
        'menuRemoveException
        '
        Me.menuRemoveException.Name = "menuRemoveException"
        Me.menuRemoveException.Size = New System.Drawing.Size(177, 22)
        Me.menuRemoveException.Text = "Remove: {filename}"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
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
        'cboRunningProcesses
        '
        Me.cboRunningProcesses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRunningProcesses.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cboRunningProcesses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboRunningProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRunningProcesses.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboRunningProcesses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cboRunningProcesses.FormattingEnabled = True
        Me.cboRunningProcesses.Location = New System.Drawing.Point(12, 318)
        Me.cboRunningProcesses.Name = "cboRunningProcesses"
        Me.cboRunningProcesses.Size = New System.Drawing.Size(160, 21)
        Me.cboRunningProcesses.TabIndex = 2
        '
        'txtCustomExecutable
        '
        Me.txtCustomExecutable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomExecutable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomExecutable.Location = New System.Drawing.Point(12, 350)
        Me.txtCustomExecutable.MaxLength = 32767
        Me.txtCustomExecutable.Multiline = False
        Me.txtCustomExecutable.Name = "txtCustomExecutable"
        Me.txtCustomExecutable.ReadOnly = False
        Me.txtCustomExecutable.Size = New System.Drawing.Size(160, 23)
        Me.txtCustomExecutable.TabIndex = 3
        Me.txtCustomExecutable.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCustomExecutable.UseSystemPasswordChar = False
        Me.txtCustomExecutable.Watermark = "e.g. game.exe"
        '
        'btnAddException
        '
        Me.btnAddException.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddException.Location = New System.Drawing.Point(180, 318)
        Me.btnAddException.Name = "btnAddException"
        Me.btnAddException.Size = New System.Drawing.Size(70, 55)
        Me.btnAddException.TabIndex = 4
        Me.btnAddException.Text = "Add"
        '
        'btnRemoveException
        '
        Me.btnRemoveException.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveException.Location = New System.Drawing.Point(258, 318)
        Me.btnRemoveException.Name = "btnRemoveException"
        Me.btnRemoveException.Size = New System.Drawing.Size(70, 55)
        Me.btnRemoveException.TabIndex = 5
        Me.btnRemoveException.Text = "Remove"
        '
        'WinExceptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 395)
        Me.Controls.Add(Me.themeContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinExceptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Process Exceptions"
        Me.themeContainer.ResumeLayout(False)
        Me.ctxExceptionsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents themeContainer As Typhon.NSTheme
    Friend WithEvents btnControlClose As Typhon.NSControlButton
    Friend WithEvents lvExceptions As Typhon.NSListView
    Friend WithEvents cboRunningProcesses As Typhon.NSComboBox
    Friend WithEvents txtCustomExecutable As Typhon.NSTextBox
    Friend WithEvents btnAddException As Typhon.NSButton
    Friend WithEvents btnRemoveException As Typhon.NSButton
    Friend WithEvents ctxExceptionsMenu As Typhon.NSContextMenu
    Friend WithEvents menuRemoveException As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuSearchGoogle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSearchVirusTotal As System.Windows.Forms.ToolStripMenuItem
End Class
