<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinMain
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinMain))
        Me.realTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cooldownTimer = New System.Windows.Forms.Timer(Me.components)
        Me.graphTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NsTheme1 = New Typhon.NSTheme()
        Me.NsTabControl1 = New Typhon.NSTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.NsGroupBox1 = New Typhon.NSGroupBox()
        Me.NsProgressBar1 = New Typhon.NSProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NsLabel2 = New Typhon.NSLabel()
        Me.NsLabel1 = New Typhon.NSLabel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.NsLabel7 = New Typhon.NSLabel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.NsLabel11 = New Typhon.NSLabel()
        Me.NsOnOffBox6 = New Typhon.NSOnOffBox()
        Me.NsLabel10 = New Typhon.NSLabel()
        Me.NsOnOffBox5 = New Typhon.NSOnOffBox()
        Me.NsLabel9 = New Typhon.NSLabel()
        Me.NsOnOffBox4 = New Typhon.NSOnOffBox()
        Me.NsLabel12 = New Typhon.NSLabel()
        Me.NsOnOffBox3 = New Typhon.NSOnOffBox()
        Me.NsLabel6 = New Typhon.NSLabel()
        Me.NsOnOffBox2 = New Typhon.NSOnOffBox()
        Me.NsLabel5 = New Typhon.NSLabel()
        Me.NsButton3 = New Typhon.NSButton()
        Me.NsLabel4 = New Typhon.NSLabel()
        Me.NsOnOffBox1 = New Typhon.NSOnOffBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.NsButton2 = New Typhon.NSButton()
        Me.NsLabel3 = New Typhon.NSLabel()
        Me.NsButton1 = New Typhon.NSButton()
        Me.NsControlButton2 = New Typhon.NSControlButton()
        Me.NsControlButton1 = New Typhon.NSControlButton()
        Me.notifIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NsContextMenu1 = New Typhon.NSContextMenu()
        Me.OpenTyphonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NsTheme1.SuspendLayout()
        Me.NsTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.NsGroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.NsContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'realTimer
        '
        '
        'cooldownTimer
        '
        Me.cooldownTimer.Interval = 5000
        '
        'graphTimer
        '
        Me.graphTimer.Enabled = True
        Me.graphTimer.Interval = 1000
        '
        'NsTheme1
        '
        Me.NsTheme1.AccentOffset = 42
        Me.NsTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.NsTheme1.Colors = New Typhon.Bloom(-1) {}
        Me.NsTheme1.Controls.Add(Me.NsTabControl1)
        Me.NsTheme1.Controls.Add(Me.NsButton2)
        Me.NsTheme1.Controls.Add(Me.NsLabel3)
        Me.NsTheme1.Controls.Add(Me.NsButton1)
        Me.NsTheme1.Controls.Add(Me.NsControlButton2)
        Me.NsTheme1.Controls.Add(Me.NsControlButton1)
        Me.NsTheme1.Customization = ""
        Me.NsTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NsTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.NsTheme1.Image = Global.Typhon.My.Resources.Resources.typhon
        Me.NsTheme1.Location = New System.Drawing.Point(0, 0)
        Me.NsTheme1.Movable = True
        Me.NsTheme1.Name = "NsTheme1"
        Me.NsTheme1.NoRounding = False
        Me.NsTheme1.Sizable = False
        Me.NsTheme1.Size = New System.Drawing.Size(500, 300)
        Me.NsTheme1.SmartBounds = True
        Me.NsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.NsTheme1.TabIndex = 0
        Me.NsTheme1.Text = "Typhon: PC Booster"
        Me.NsTheme1.TransparencyKey = System.Drawing.Color.Empty
        Me.NsTheme1.Transparent = False
        '
        'NsTabControl1
        '
        Me.NsTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.NsTabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsTabControl1.Controls.Add(Me.TabPage1)
        Me.NsTabControl1.Controls.Add(Me.TabPage4)
        Me.NsTabControl1.Controls.Add(Me.TabPage3)
        Me.NsTabControl1.Controls.Add(Me.TabPage2)
        Me.NsTabControl1.Controls.Add(Me.TabPage6)
        Me.NsTabControl1.Controls.Add(Me.TabPage5)
        Me.NsTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.NsTabControl1.ItemSize = New System.Drawing.Size(28, 115)
        Me.NsTabControl1.Location = New System.Drawing.Point(12, 40)
        Me.NsTabControl1.Multiline = True
        Me.NsTabControl1.Name = "NsTabControl1"
        Me.NsTabControl1.SelectedIndex = 0
        Me.NsTabControl1.Size = New System.Drawing.Size(476, 219)
        Me.NsTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.NsTabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.NsGroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(119, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(353, 211)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Boost"
        '
        'NsGroupBox1
        '
        Me.NsGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsGroupBox1.Controls.Add(Me.NsProgressBar1)
        Me.NsGroupBox1.Controls.Add(Me.PictureBox1)
        Me.NsGroupBox1.Controls.Add(Me.NsLabel2)
        Me.NsGroupBox1.Controls.Add(Me.NsLabel1)
        Me.NsGroupBox1.DrawSeperator = False
        Me.NsGroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.NsGroupBox1.Name = "NsGroupBox1"
        Me.NsGroupBox1.Size = New System.Drawing.Size(341, 199)
        Me.NsGroupBox1.SubTitle = "-"
        Me.NsGroupBox1.TabIndex = 2
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = "[-]"
        '
        'NsProgressBar1
        '
        Me.NsProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsProgressBar1.Location = New System.Drawing.Point(3, 183)
        Me.NsProgressBar1.Maximum = 100
        Me.NsProgressBar1.Minimum = 0
        Me.NsProgressBar1.Name = "NsProgressBar1"
        Me.NsProgressBar1.Size = New System.Drawing.Size(335, 10)
        Me.NsProgressBar1.TabIndex = 3
        Me.NsProgressBar1.Text = "NsProgressBar1"
        Me.NsProgressBar1.Value = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox1.Image = Global.Typhon.My.Resources.Resources.typhon
        Me.PictureBox1.Location = New System.Drawing.Point(199, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(139, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'NsLabel2
        '
        Me.NsLabel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel2.Location = New System.Drawing.Point(3, 157)
        Me.NsLabel2.Name = "NsLabel2"
        Me.NsLabel2.Size = New System.Drawing.Size(335, 23)
        Me.NsLabel2.TabIndex = 4
        Me.NsLabel2.Text = "NsLabel2"
        Me.NsLabel2.Value1 = "Memory Usage:"
        Me.NsLabel2.Value2 = "-"
        '
        'NsLabel1
        '
        Me.NsLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel1.Location = New System.Drawing.Point(3, 138)
        Me.NsLabel1.Name = "NsLabel1"
        Me.NsLabel1.Size = New System.Drawing.Size(190, 23)
        Me.NsLabel1.TabIndex = 3
        Me.NsLabel1.Text = "NsLabel1"
        Me.NsLabel1.Value1 = "Processes:"
        Me.NsLabel1.Value2 = ""
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.NsLabel7)
        Me.TabPage4.Controls.Add(Me.Chart1)
        Me.TabPage4.Location = New System.Drawing.Point(119, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(353, 211)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Graph"
        '
        'NsLabel7
        '
        Me.NsLabel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsLabel7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel7.Location = New System.Drawing.Point(6, 6)
        Me.NsLabel7.Name = "NsLabel7"
        Me.NsLabel7.Size = New System.Drawing.Size(339, 23)
        Me.NsLabel7.TabIndex = 11
        Me.NsLabel7.Text = "Graph Information"
        Me.NsLabel7.Value1 = "Graph"
        Me.NsLabel7.Value2 = "Information"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        ChartArea1.AxisX.IsMarginVisible = False
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        ChartArea1.AxisY.Interval = 25.0R
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea1.AxisY.LabelStyle.Format = "{0}%"
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        ChartArea1.AxisY.Maximum = 100.0R
        ChartArea1.AxisY.Minimum = 0R
        ChartArea1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Far
        Legend1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.ForeColor = System.Drawing.Color.White
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(6, 34)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(229, Byte), Integer))
        Series1.Legend = "Legend1"
        Series1.LegendText = "RAM"
        Series1.MarkerBorderColor = System.Drawing.Color.Transparent
        Series1.MarkerColor = System.Drawing.Color.White
        Series1.Name = "Series1"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.Legend = "Legend1"
        Series2.LegendText = "CPU"
        Series2.MarkerBorderColor = System.Drawing.Color.Transparent
        Series2.MarkerColor = System.Drawing.Color.White
        Series2.Name = "Series2"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(51, Byte), Integer))
        Series3.Legend = "Legend1"
        Series3.LegendText = "GPU"
        Series3.MarkerBorderColor = System.Drawing.Color.Transparent
        Series3.MarkerColor = System.Drawing.Color.White
        Series3.Name = "Series3"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(339, 171)
        Me.Chart1.TabIndex = 2
        Me.Chart1.Text = "Chart1"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage3.Location = New System.Drawing.Point(119, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(353, 211)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cleaner"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.NsLabel11)
        Me.TabPage2.Controls.Add(Me.NsOnOffBox6)
        Me.TabPage2.Controls.Add(Me.NsLabel10)
        Me.TabPage2.Controls.Add(Me.NsOnOffBox5)
        Me.TabPage2.Controls.Add(Me.NsLabel9)
        Me.TabPage2.Controls.Add(Me.NsOnOffBox4)
        Me.TabPage2.Controls.Add(Me.NsLabel12)
        Me.TabPage2.Controls.Add(Me.NsOnOffBox3)
        Me.TabPage2.Controls.Add(Me.NsLabel6)
        Me.TabPage2.Controls.Add(Me.NsOnOffBox2)
        Me.TabPage2.Controls.Add(Me.NsLabel5)
        Me.TabPage2.Controls.Add(Me.NsButton3)
        Me.TabPage2.Controls.Add(Me.NsLabel4)
        Me.TabPage2.Controls.Add(Me.NsOnOffBox1)
        Me.TabPage2.Location = New System.Drawing.Point(119, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(353, 211)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'NsLabel11
        '
        Me.NsLabel11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel11.Location = New System.Drawing.Point(6, 141)
        Me.NsLabel11.Name = "NsLabel11"
        Me.NsLabel11.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel11.TabIndex = 17
        Me.NsLabel11.Text = "NsLabel11"
        Me.NsLabel11.Value1 = "Start Minimized"
        Me.NsLabel11.Value2 = " on Boot"
        '
        'NsOnOffBox6
        '
        Me.NsOnOffBox6.Checked = False
        Me.NsOnOffBox6.Location = New System.Drawing.Point(288, 141)
        Me.NsOnOffBox6.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox6.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox6.Name = "NsOnOffBox6"
        Me.NsOnOffBox6.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox6.TabIndex = 18
        Me.NsOnOffBox6.Text = "NsOnOffBox6"
        '
        'NsLabel10
        '
        Me.NsLabel10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel10.Location = New System.Drawing.Point(6, 114)
        Me.NsLabel10.Name = "NsLabel10"
        Me.NsLabel10.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel10.TabIndex = 15
        Me.NsLabel10.Text = "NsLabel10"
        Me.NsLabel10.Value1 = "Show Tray "
        Me.NsLabel10.Value2 = "Notifications"
        '
        'NsOnOffBox5
        '
        Me.NsOnOffBox5.Checked = False
        Me.NsOnOffBox5.Location = New System.Drawing.Point(288, 114)
        Me.NsOnOffBox5.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox5.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox5.Name = "NsOnOffBox5"
        Me.NsOnOffBox5.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox5.TabIndex = 16
        Me.NsOnOffBox5.Text = "NsOnOffBox5"
        '
        'NsLabel9
        '
        Me.NsLabel9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel9.Location = New System.Drawing.Point(6, 87)
        Me.NsLabel9.Name = "NsLabel9"
        Me.NsLabel9.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel9.TabIndex = 13
        Me.NsLabel9.Text = "NsLabel9"
        Me.NsLabel9.Value1 = "[X] "
        Me.NsLabel9.Value2 = "Minimize to System Tray"
        '
        'NsOnOffBox4
        '
        Me.NsOnOffBox4.Checked = False
        Me.NsOnOffBox4.Location = New System.Drawing.Point(288, 87)
        Me.NsOnOffBox4.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox4.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox4.Name = "NsOnOffBox4"
        Me.NsOnOffBox4.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox4.TabIndex = 14
        Me.NsOnOffBox4.Text = "NsOnOffBox4"
        '
        'NsLabel12
        '
        Me.NsLabel12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel12.Location = New System.Drawing.Point(6, 60)
        Me.NsLabel12.Name = "NsLabel12"
        Me.NsLabel12.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel12.TabIndex = 19
        Me.NsLabel12.Text = "NsLabel12"
        Me.NsLabel12.Value1 = "Minimize to "
        Me.NsLabel12.Value2 = "System Tray"
        '
        'NsOnOffBox3
        '
        Me.NsOnOffBox3.Checked = False
        Me.NsOnOffBox3.Location = New System.Drawing.Point(288, 60)
        Me.NsOnOffBox3.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox3.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox3.Name = "NsOnOffBox3"
        Me.NsOnOffBox3.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox3.TabIndex = 12
        Me.NsOnOffBox3.Text = "NsOnOffBox3"
        '
        'NsLabel6
        '
        Me.NsLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel6.Location = New System.Drawing.Point(6, 34)
        Me.NsLabel6.Name = "NsLabel6"
        Me.NsLabel6.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel6.TabIndex = 10
        Me.NsLabel6.Text = "NsLabel6"
        Me.NsLabel6.Value1 = "Autostart on"
        Me.NsLabel6.Value2 = "PC Boot"
        '
        'NsOnOffBox2
        '
        Me.NsOnOffBox2.Checked = False
        Me.NsOnOffBox2.Location = New System.Drawing.Point(288, 33)
        Me.NsOnOffBox2.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox2.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox2.Name = "NsOnOffBox2"
        Me.NsOnOffBox2.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox2.TabIndex = 9
        Me.NsOnOffBox2.Text = "NsOnOffBox2"
        '
        'NsLabel5
        '
        Me.NsLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel5.Location = New System.Drawing.Point(4, 182)
        Me.NsLabel5.Name = "NsLabel5"
        Me.NsLabel5.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel5.TabIndex = 8
        Me.NsLabel5.Text = "NsLabel5"
        Me.NsLabel5.Value1 = "Manage "
        Me.NsLabel5.Value2 = "Process Exceptions"
        '
        'NsButton3
        '
        Me.NsButton3.Location = New System.Drawing.Point(269, 182)
        Me.NsButton3.Name = "NsButton3"
        Me.NsButton3.Size = New System.Drawing.Size(75, 23)
        Me.NsButton3.TabIndex = 7
        Me.NsButton3.Text = "Open"
        '
        'NsLabel4
        '
        Me.NsLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel4.Location = New System.Drawing.Point(6, 7)
        Me.NsLabel4.Name = "NsLabel4"
        Me.NsLabel4.Size = New System.Drawing.Size(198, 23)
        Me.NsLabel4.TabIndex = 7
        Me.NsLabel4.Text = "NsLabel4"
        Me.NsLabel4.Value1 = "Auto "
        Me.NsLabel4.Value2 = "FreeRAM();"
        '
        'NsOnOffBox1
        '
        Me.NsOnOffBox1.Checked = False
        Me.NsOnOffBox1.Location = New System.Drawing.Point(288, 7)
        Me.NsOnOffBox1.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox1.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox1.Name = "NsOnOffBox1"
        Me.NsOnOffBox1.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox1.TabIndex = 7
        Me.NsOnOffBox1.Text = "NsOnOffBox1"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.RichTextBox1)
        Me.TabPage6.Location = New System.Drawing.Point(119, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(353, 211)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "PC Specs"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.ForeColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(339, 199)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage5.Location = New System.Drawing.Point(119, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(353, 211)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "About"
        '
        'NsButton2
        '
        Me.NsButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsButton2.Location = New System.Drawing.Point(388, 265)
        Me.NsButton2.Name = "NsButton2"
        Me.NsButton2.Size = New System.Drawing.Size(100, 23)
        Me.NsButton2.TabIndex = 5
        Me.NsButton2.Text = "KillProcesses();"
        '
        'NsLabel3
        '
        Me.NsLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsLabel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel3.Location = New System.Drawing.Point(4, 265)
        Me.NsLabel3.Name = "NsLabel3"
        Me.NsLabel3.Size = New System.Drawing.Size(272, 23)
        Me.NsLabel3.TabIndex = 4
        Me.NsLabel3.Text = "NsLabel3"
        Me.NsLabel3.Value1 = ""
        Me.NsLabel3.Value2 = ""
        '
        'NsButton1
        '
        Me.NsButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsButton1.Location = New System.Drawing.Point(282, 265)
        Me.NsButton1.Name = "NsButton1"
        Me.NsButton1.Size = New System.Drawing.Size(100, 23)
        Me.NsButton1.TabIndex = 3
        Me.NsButton1.Text = "FreeRAM();"
        '
        'NsControlButton2
        '
        Me.NsControlButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton2.ControlButton = Typhon.NSControlButton.Button.Minimize
        Me.NsControlButton2.Location = New System.Drawing.Point(458, 5)
        Me.NsControlButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton2.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.Name = "NsControlButton2"
        Me.NsControlButton2.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton2.TabIndex = 1
        Me.NsControlButton2.Text = "NsControlButton2"
        '
        'NsControlButton1
        '
        Me.NsControlButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsControlButton1.ControlButton = Typhon.NSControlButton.Button.Close
        Me.NsControlButton1.Location = New System.Drawing.Point(476, 5)
        Me.NsControlButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.NsControlButton1.MaximumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.MinimumSize = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.Name = "NsControlButton1"
        Me.NsControlButton1.Size = New System.Drawing.Size(18, 20)
        Me.NsControlButton1.TabIndex = 0
        Me.NsControlButton1.Text = "NsControlButton1"
        '
        'notifIcon
        '
        Me.notifIcon.ContextMenuStrip = Me.NsContextMenu1
        Me.notifIcon.Text = "Typhon PC Booster"
        '
        'NsContextMenu1
        '
        Me.NsContextMenu1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.NsContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTyphonToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.NsContextMenu1.Name = "NsContextMenu1"
        Me.NsContextMenu1.Size = New System.Drawing.Size(147, 48)
        '
        'OpenTyphonToolStripMenuItem
        '
        Me.OpenTyphonToolStripMenuItem.Image = Global.Typhon.My.Resources.Resources.typhon_ico
        Me.OpenTyphonToolStripMenuItem.Name = "OpenTyphonToolStripMenuItem"
        Me.OpenTyphonToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenTyphonToolStripMenuItem.Text = "Open Typhon"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.Typhon.My.Resources.Resources.icons8_poison_18
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'WinMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.NsTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Typhon: PC Booster"
        Me.NsTheme1.ResumeLayout(False)
        Me.NsTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.NsGroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.NsContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents NsControlButton2 As Typhon.NSControlButton
    Friend WithEvents NsGroupBox1 As Typhon.NSGroupBox
    Friend WithEvents NsLabel1 As Typhon.NSLabel
    Friend WithEvents realTimer As System.Windows.Forms.Timer
    Friend WithEvents NsLabel2 As Typhon.NSLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents NsProgressBar1 As Typhon.NSProgressBar
    Friend WithEvents NsButton1 As Typhon.NSButton
    Friend WithEvents NsLabel3 As Typhon.NSLabel
    Friend WithEvents cooldownTimer As System.Windows.Forms.Timer
    Friend WithEvents NsButton2 As Typhon.NSButton
    Friend WithEvents notifIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents NsContextMenu1 As Typhon.NSContextMenu
    Friend WithEvents OpenTyphonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NsTabControl1 As Typhon.NSTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents NsOnOffBox1 As Typhon.NSOnOffBox
    Friend WithEvents NsLabel4 As Typhon.NSLabel
    Friend WithEvents NsButton3 As Typhon.NSButton
    Friend WithEvents NsLabel5 As Typhon.NSLabel
    Friend WithEvents NsLabel6 As Typhon.NSLabel
    Friend WithEvents NsOnOffBox2 As Typhon.NSOnOffBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents graphTimer As System.Windows.Forms.Timer
    Friend WithEvents NsLabel7 As Typhon.NSLabel
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents NsOnOffBox3 As Typhon.NSOnOffBox
    Friend WithEvents NsOnOffBox4 As Typhon.NSOnOffBox
    Friend WithEvents NsOnOffBox5 As Typhon.NSOnOffBox
    Friend WithEvents NsOnOffBox6 As Typhon.NSOnOffBox
    Friend WithEvents NsLabel9 As Typhon.NSLabel
    Friend WithEvents NsLabel10 As Typhon.NSLabel
    Friend WithEvents NsLabel11 As Typhon.NSLabel
    Friend WithEvents NsLabel12 As Typhon.NSLabel

End Class
