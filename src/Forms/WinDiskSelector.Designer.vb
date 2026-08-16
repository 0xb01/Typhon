<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinDiskSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinDiskSelector))
        Me.NsTheme1 = New Typhon.NSTheme()
        Me.NsControlButton1 = New Typhon.NSControlButton()
        Me.lstDrives = New Typhon.NSListView()
        Me.btnScanNow = New Typhon.NSButton()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New Typhon.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.lstDrives)
        Me.NsTheme1.Controls.Add(Me.btnScanNow)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsTheme1.Image = Nothing
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = True
        Me.NsTheme1.Size = New System.Drawing.Size(400, 300)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Disk Selector"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(375, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'lstDrives
        '
        Me.lstDrives.CheckBoxes = False
        Me.lstDrives.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.lstDrives.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lstDrives.Location = New System.Drawing.Point(15, 45)
        Me.lstDrives.MultiSelect = True
        Me.lstDrives.Name = "lstDrives"
        Me.lstDrives.Size = New System.Drawing.Size(370, 195)
        Me.lstDrives.TabIndex = 1
        '
        'btnScanNow
        '
        Me.btnScanNow.Location = New System.Drawing.Point(140, 255)
        Me.btnScanNow.Name = "btnScanNow"
        Me.btnScanNow.Size = New System.Drawing.Size(120, 28)
        Me.btnScanNow.TabIndex = 2
        Me.btnScanNow.Text = "Scan Now"
        '
        'WinDiskSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinDiskSelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Disk Selector"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents lstDrives As Typhon.NSListView
    Friend WithEvents btnScanNow As Typhon.NSButton

End Class
