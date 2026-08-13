<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinOptions
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
        Me.btnSave = New Typhon.NSButton()
        Me.NsTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NsTheme1
        '
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Controls.Add(Me.chkTemp)
        Me.NsTheme1.Controls.Add(Me.chkRecycle)
        Me.NsTheme1.Controls.Add(Me.chkIncompat)
        Me.NsTheme1.Controls.Add(Me.chkThumb)
        Me.NsTheme1.Controls.Add(Me.chkGames)
        Me.NsTheme1.Controls.Add(Me.chkFolderCfg)
        Me.NsTheme1.Controls.Add(Me.chkCookies)
        Me.NsTheme1.Controls.Add(Me.chkCache)
        Me.NsTheme1.Controls.Add(Me.chkHistory)
        Me.NsTheme1.Controls.Add(Me.chkLogs)
        Me.NsTheme1.Controls.Add(Me.chkDumps)
        Me.NsTheme1.Controls.Add(Me.chkRecent)
        Me.NsTheme1.Controls.Add(Me.chkAppCache)
        Me.NsTheme1.Controls.Add(Me.chkWinUpdate)
        Me.NsTheme1.Controls.Add(Me.chkDriverCache)
        Me.NsTheme1.Controls.Add(Me.chkPkgCache)
        Me.NsTheme1.Controls.Add(Me.btnSave)
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.Size = New System.Drawing.Size(380, 390)
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Cleaner Options"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(355, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'chkTemp
        '
        Me.chkTemp.Checked = True
        Me.chkTemp.Location = New System.Drawing.Point(20, 45)
        Me.chkTemp.Name = "chkTemp"
        Me.chkTemp.Size = New System.Drawing.Size(160, 23)
        Me.chkTemp.TabIndex = 1
        Me.chkTemp.Text = "Temporary Files"
        '
        'chkRecycle
        '
        Me.chkRecycle.Checked = True
        Me.chkRecycle.Location = New System.Drawing.Point(20, 75)
        Me.chkRecycle.Name = "chkRecycle"
        Me.chkRecycle.Size = New System.Drawing.Size(160, 23)
        Me.chkRecycle.TabIndex = 2
        Me.chkRecycle.Text = "Recycle Bin"
        '
        'chkIncompat
        '
        Me.chkIncompat.Checked = True
        Me.chkIncompat.Location = New System.Drawing.Point(20, 105)
        Me.chkIncompat.Name = "chkIncompat"
        Me.chkIncompat.Size = New System.Drawing.Size(160, 23)
        Me.chkIncompat.TabIndex = 3
        Me.chkIncompat.Text = "Incompatible Files"
        '
        'chkThumb
        '
        Me.chkThumb.Checked = True
        Me.chkThumb.Location = New System.Drawing.Point(20, 135)
        Me.chkThumb.Name = "chkThumb"
        Me.chkThumb.Size = New System.Drawing.Size(160, 23)
        Me.chkThumb.TabIndex = 4
        Me.chkThumb.Text = "Thumbnail Caches"
        '
        'chkGames
        '
        Me.chkGames.Checked = False
        Me.chkGames.Location = New System.Drawing.Point(20, 165)
        Me.chkGames.Name = "chkGames"
        Me.chkGames.Size = New System.Drawing.Size(160, 23)
        Me.chkGames.TabIndex = 5
        Me.chkGames.Text = "Game Caches"
        '
        'chkFolderCfg
        '
        Me.chkFolderCfg.Checked = False
        Me.chkFolderCfg.Location = New System.Drawing.Point(20, 195)
        Me.chkFolderCfg.Name = "chkFolderCfg"
        Me.chkFolderCfg.Size = New System.Drawing.Size(160, 23)
        Me.chkFolderCfg.TabIndex = 6
        Me.chkFolderCfg.Text = "Folder Config Files"
        '
        'chkCookies
        '
        Me.chkCookies.Checked = False
        Me.chkCookies.Location = New System.Drawing.Point(20, 225)
        Me.chkCookies.Name = "chkCookies"
        Me.chkCookies.Size = New System.Drawing.Size(160, 23)
        Me.chkCookies.TabIndex = 7
        Me.chkCookies.Text = "Internet Cookies"
        '
        'chkCache
        '
        Me.chkCache.Checked = True
        Me.chkCache.Location = New System.Drawing.Point(195, 45)
        Me.chkCache.Name = "chkCache"
        Me.chkCache.Size = New System.Drawing.Size(165, 23)
        Me.chkCache.TabIndex = 8
        Me.chkCache.Text = "Internet Cache"
        '
        'chkHistory
        '
        Me.chkHistory.Checked = True
        Me.chkHistory.Location = New System.Drawing.Point(195, 75)
        Me.chkHistory.Name = "chkHistory"
        Me.chkHistory.Size = New System.Drawing.Size(165, 23)
        Me.chkHistory.TabIndex = 9
        Me.chkHistory.Text = "Internet History"
        '
        'chkLogs
        '
        Me.chkLogs.Checked = True
        Me.chkLogs.Location = New System.Drawing.Point(195, 105)
        Me.chkLogs.Name = "chkLogs"
        Me.chkLogs.Size = New System.Drawing.Size(165, 23)
        Me.chkLogs.TabIndex = 10
        Me.chkLogs.Text = "Windows Logs"
        '
        'chkDumps
        '
        Me.chkDumps.Checked = True
        Me.chkDumps.Location = New System.Drawing.Point(195, 135)
        Me.chkDumps.Name = "chkDumps"
        Me.chkDumps.Size = New System.Drawing.Size(165, 23)
        Me.chkDumps.TabIndex = 11
        Me.chkDumps.Text = "Memory Dumps"
        '
        'chkRecent
        '
        Me.chkRecent.Checked = True
        Me.chkRecent.Location = New System.Drawing.Point(195, 165)
        Me.chkRecent.Name = "chkRecent"
        Me.chkRecent.Size = New System.Drawing.Size(165, 23)
        Me.chkRecent.TabIndex = 12
        Me.chkRecent.Text = "Recent Files"
        '
        'chkAppCache
        '
        Me.chkAppCache.Checked = False
        Me.chkAppCache.Location = New System.Drawing.Point(195, 195)
        Me.chkAppCache.Name = "chkAppCache"
        Me.chkAppCache.Size = New System.Drawing.Size(165, 23)
        Me.chkAppCache.TabIndex = 13
        Me.chkAppCache.Text = "Application Caches"
        '
        'chkWinUpdate
        '
        Me.chkWinUpdate.Checked = True
        Me.chkWinUpdate.Location = New System.Drawing.Point(20, 255)
        Me.chkWinUpdate.Name = "chkWinUpdate"
        Me.chkWinUpdate.Size = New System.Drawing.Size(160, 23)
        Me.chkWinUpdate.TabIndex = 14
        Me.chkWinUpdate.Text = "Windows Update Cache"
        '
        'chkDriverCache
        '
        Me.chkDriverCache.Checked = False
        Me.chkDriverCache.Location = New System.Drawing.Point(195, 225)
        Me.chkDriverCache.Name = "chkDriverCache"
        Me.chkDriverCache.Size = New System.Drawing.Size(165, 23)
        Me.chkDriverCache.TabIndex = 15
        Me.chkDriverCache.Text = "GPU Driver Cache"
        '
        'chkPkgCache
        '
        Me.chkPkgCache.Checked = False
        Me.chkPkgCache.Location = New System.Drawing.Point(195, 255)
        Me.chkPkgCache.Name = "chkPkgCache"
        Me.chkPkgCache.Size = New System.Drawing.Size(165, 23)
        Me.chkPkgCache.TabIndex = 16
        Me.chkPkgCache.Text = "Dev Package Caches"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(130, 345)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 28)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save Settings"
        '
        'WinOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 390)
        Me.ControlBox = False
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WinOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cleaner Options"
        Me.NsTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
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
    Friend WithEvents btnSave As Typhon.NSButton

End Class
