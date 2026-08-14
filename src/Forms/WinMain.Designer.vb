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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
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
        Me.NsGroupBox2 = New Typhon.NSGroupBox()
        Me.NsLabel4 = New Typhon.NSLabel()
        Me.NsComboBox1 = New Typhon.NSComboBox()
        Me.NsLabel6 = New Typhon.NSLabel()
        Me.NsOnOffBox2 = New Typhon.NSOnOffBox()
        Me.NsLabel11 = New Typhon.NSLabel()
        Me.NsOnOffBox6 = New Typhon.NSOnOffBox()
        Me.NsLabel12 = New Typhon.NSLabel()
        Me.NsOnOffBox3 = New Typhon.NSOnOffBox()
        Me.NsLabel9 = New Typhon.NSLabel()
        Me.NsOnOffBox4 = New Typhon.NSOnOffBox()
        Me.NsLabel5 = New Typhon.NSLabel()
        Me.NsButton3 = New Typhon.NSButton()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.NsListView2 = New Typhon.NSListView()
        Me.NsButton5 = New Typhon.NSButton()
        Me.NsButton4 = New Typhon.NSButton()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
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
        Me.NsGroupBox2.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NsContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'realTimer
        '
        Me.realTimer.Interval = 1000
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
        Me.NsTheme1.Size = New System.Drawing.Size(500, 321)
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
        Me.NsTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.NsTabControl1.Size = New System.Drawing.Size(476, 240)
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
        Me.TabPage1.Size = New System.Drawing.Size(353, 232)
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
        Me.NsGroupBox1.Size = New System.Drawing.Size(341, 220)
        Me.NsGroupBox1.SubTitle = "-"
        Me.NsGroupBox1.TabIndex = 2
        Me.NsGroupBox1.Text = "NsGroupBox1"
        Me.NsGroupBox1.Title = "[-]"
        '
        'NsProgressBar1
        '
        Me.NsProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsProgressBar1.Location = New System.Drawing.Point(3, 204)
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
        Me.PictureBox1.Location = New System.Drawing.Point(199, 76)
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
        Me.NsLabel2.Location = New System.Drawing.Point(3, 178)
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
        Me.NsLabel1.Location = New System.Drawing.Point(3, 159)
        Me.NsLabel1.Name = "NsLabel1"
        Me.NsLabel1.Size = New System.Drawing.Size(190, 23)
        Me.NsLabel1.TabIndex = 3
        Me.NsLabel1.Text = "NsLabel1"
        Me.NsLabel1.Value1 = "Active Processes:"
        Me.NsLabel1.Value2 = "-"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.NsLabel7)
        Me.TabPage4.Controls.Add(Me.Chart1)
        Me.TabPage4.Location = New System.Drawing.Point(119, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(353, 232)
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
        Me.NsLabel7.Text = "Info:"
        Me.NsLabel7.Value1 = "Info:"
        Me.NsLabel7.Value2 = "-"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        ChartArea2.AxisX.IsMarginVisible = False
        ChartArea2.AxisX.LabelStyle.Enabled = False
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        ChartArea2.AxisY.Interval = 25.0R
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White
        ChartArea2.AxisY.LabelStyle.Format = "{0}%"
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        ChartArea2.AxisY.Maximum = 100.0R
        ChartArea2.AxisY.Minimum = 0R
        ChartArea2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        ChartArea2.Name = "ChartArea1"
        ChartArea2.Position.Auto = False
        ChartArea2.Position.Height = 86.0!
        ChartArea2.Position.Width = 99.0!
        ChartArea2.Position.Y = 13.0!
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Alignment = System.Drawing.StringAlignment.Far
        Legend2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend2.ForeColor = System.Drawing.Color.White
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(3, 30)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(229, Byte), Integer))
        Series4.BorderWidth = 2
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series4.Color = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(229, Byte), Integer))
        Series4.Legend = "Legend1"
        Series4.LegendText = "RAM"
        Series4.MarkerBorderColor = System.Drawing.Color.Transparent
        Series4.MarkerColor = System.Drawing.Color.White
        Series4.Name = "Series1"
        Series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))
        Series5.BorderWidth = 2
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series5.Color = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))
        Series5.Legend = "Legend1"
        Series5.LegendText = "CPU"
        Series5.MarkerBorderColor = System.Drawing.Color.Transparent
        Series5.MarkerColor = System.Drawing.Color.White
        Series5.Name = "Series2"
        Series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(51, Byte), Integer))
        Series6.BorderWidth = 2
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series6.Color = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(51, Byte), Integer))
        Series6.Legend = "Legend1"
        Series6.LegendText = "GPU"
        Series6.MarkerBorderColor = System.Drawing.Color.Transparent
        Series6.MarkerColor = System.Drawing.Color.White
        Series6.Name = "Series3"
        Series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Series.Add(Series6)
        Me.Chart1.Size = New System.Drawing.Size(347, 198)
        Me.Chart1.TabIndex = 2
        Me.Chart1.Text = "Chart1"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage3.Location = New System.Drawing.Point(119, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(353, 232)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cleaner"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.NsGroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(119, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(353, 232)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'NsGroupBox2
        '
        Me.NsGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsGroupBox2.Controls.Add(Me.NsLabel4)
        Me.NsGroupBox2.Controls.Add(Me.NsComboBox1)
        Me.NsGroupBox2.Controls.Add(Me.NsLabel6)
        Me.NsGroupBox2.Controls.Add(Me.NsOnOffBox2)
        Me.NsGroupBox2.Controls.Add(Me.NsLabel11)
        Me.NsGroupBox2.Controls.Add(Me.NsOnOffBox6)
        Me.NsGroupBox2.Controls.Add(Me.NsLabel12)
        Me.NsGroupBox2.Controls.Add(Me.NsOnOffBox3)
        Me.NsGroupBox2.Controls.Add(Me.NsLabel9)
        Me.NsGroupBox2.Controls.Add(Me.NsOnOffBox4)
        Me.NsGroupBox2.Controls.Add(Me.NsLabel5)
        Me.NsGroupBox2.Controls.Add(Me.NsButton3)
        Me.NsGroupBox2.DrawSeperator = True
        Me.NsGroupBox2.Location = New System.Drawing.Point(6, 4)
        Me.NsGroupBox2.Name = "NsGroupBox2"
        Me.NsGroupBox2.Size = New System.Drawing.Size(341, 225)
        Me.NsGroupBox2.SubTitle = "System boot, memory, and tray behaviors"
        Me.NsGroupBox2.TabIndex = 0
        Me.NsGroupBox2.Title = "Settings & Preferences"
        '
        'NsLabel4
        '
        Me.NsLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel4.Location = New System.Drawing.Point(10, 46)
        Me.NsLabel4.Name = "NsLabel4"
        Me.NsLabel4.Size = New System.Drawing.Size(120, 20)
        Me.NsLabel4.TabIndex = 1
        Me.NsLabel4.Text = "NsLabel4"
        Me.NsLabel4.Value1 = "Auto "
        Me.NsLabel4.Value2 = "FreeRAM();"
        '
        'NsComboBox1
        '
        Me.NsComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NsComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.NsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NsComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.NsComboBox1.FormattingEnabled = True
        Me.NsComboBox1.Items.AddRange(New Object() {"Disabled", "Every 1 minute", "Every 5 minutes", "Every 10 minutes", "When reaching 80% RAM"})
        Me.NsComboBox1.Location = New System.Drawing.Point(135, 45)
        Me.NsComboBox1.Name = "NsComboBox1"
        Me.NsComboBox1.Size = New System.Drawing.Size(196, 21)
        Me.NsComboBox1.TabIndex = 2
        '
        'NsLabel6
        '
        Me.NsLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel6.Location = New System.Drawing.Point(10, 75)
        Me.NsLabel6.Name = "NsLabel6"
        Me.NsLabel6.Size = New System.Drawing.Size(250, 20)
        Me.NsLabel6.TabIndex = 3
        Me.NsLabel6.Text = "NsLabel6"
        Me.NsLabel6.Value1 = "Autostart on "
        Me.NsLabel6.Value2 = "PC Boot"
        '
        'NsOnOffBox2
        '
        Me.NsOnOffBox2.Checked = False
        Me.NsOnOffBox2.Location = New System.Drawing.Point(275, 73)
        Me.NsOnOffBox2.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox2.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox2.Name = "NsOnOffBox2"
        Me.NsOnOffBox2.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox2.TabIndex = 4
        Me.NsOnOffBox2.Text = "NsOnOffBox2"
        '
        'NsLabel11
        '
        Me.NsLabel11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel11.Location = New System.Drawing.Point(10, 103)
        Me.NsLabel11.Name = "NsLabel11"
        Me.NsLabel11.Size = New System.Drawing.Size(250, 20)
        Me.NsLabel11.TabIndex = 5
        Me.NsLabel11.Text = "NsLabel11"
        Me.NsLabel11.Value1 = "Start Minimized "
        Me.NsLabel11.Value2 = " on Boot"
        '
        'NsOnOffBox6
        '
        Me.NsOnOffBox6.Checked = False
        Me.NsOnOffBox6.Location = New System.Drawing.Point(275, 101)
        Me.NsOnOffBox6.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox6.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox6.Name = "NsOnOffBox6"
        Me.NsOnOffBox6.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox6.TabIndex = 6
        Me.NsOnOffBox6.Text = "NsOnOffBox6"
        '
        'NsLabel12
        '
        Me.NsLabel12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel12.Location = New System.Drawing.Point(10, 131)
        Me.NsLabel12.Name = "NsLabel12"
        Me.NsLabel12.Size = New System.Drawing.Size(250, 20)
        Me.NsLabel12.TabIndex = 7
        Me.NsLabel12.Text = "NsLabel12"
        Me.NsLabel12.Value1 = "Minimize Window "
        Me.NsLabel12.Value2 = "to System Tray"
        '
        'NsOnOffBox3
        '
        Me.NsOnOffBox3.Checked = False
        Me.NsOnOffBox3.Location = New System.Drawing.Point(275, 129)
        Me.NsOnOffBox3.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox3.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox3.Name = "NsOnOffBox3"
        Me.NsOnOffBox3.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox3.TabIndex = 8
        Me.NsOnOffBox3.Text = "NsOnOffBox3"
        '
        'NsLabel9
        '
        Me.NsLabel9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel9.Location = New System.Drawing.Point(10, 159)
        Me.NsLabel9.Name = "NsLabel9"
        Me.NsLabel9.Size = New System.Drawing.Size(250, 20)
        Me.NsLabel9.TabIndex = 9
        Me.NsLabel9.Text = "NsLabel9"
        Me.NsLabel9.Value1 = "Close [X] Button "
        Me.NsLabel9.Value2 = " to System Tray"
        '
        'NsOnOffBox4
        '
        Me.NsOnOffBox4.Checked = False
        Me.NsOnOffBox4.Location = New System.Drawing.Point(275, 157)
        Me.NsOnOffBox4.MaximumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox4.MinimumSize = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox4.Name = "NsOnOffBox4"
        Me.NsOnOffBox4.Size = New System.Drawing.Size(56, 24)
        Me.NsOnOffBox4.TabIndex = 10
        Me.NsOnOffBox4.Text = "NsOnOffBox4"
        '
        'NsLabel5
        '
        Me.NsLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NsLabel5.Location = New System.Drawing.Point(10, 188)
        Me.NsLabel5.Name = "NsLabel5"
        Me.NsLabel5.Size = New System.Drawing.Size(250, 20)
        Me.NsLabel5.TabIndex = 13
        Me.NsLabel5.Text = "NsLabel5"
        Me.NsLabel5.Value1 = "Manage "
        Me.NsLabel5.Value2 = "Process Exceptions"
        '
        'NsButton3
        '
        Me.NsButton3.Location = New System.Drawing.Point(275, 187)
        Me.NsButton3.Name = "NsButton3"
        Me.NsButton3.Size = New System.Drawing.Size(56, 22)
        Me.NsButton3.TabIndex = 14
        Me.NsButton3.Text = "Open"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.NsListView2)
        Me.TabPage6.Controls.Add(Me.NsButton5)
        Me.TabPage6.Controls.Add(Me.NsButton4)
        Me.TabPage6.Location = New System.Drawing.Point(119, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(353, 232)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "PC Specs"
        '
        'NsListView2
        '
        Me.NsListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsListView2.CheckBoxes = False
        Me.NsListView2.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.NsListView2.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.NsListView2.Location = New System.Drawing.Point(4, 4)
        Me.NsListView2.MultiSelect = True
        Me.NsListView2.Name = "NsListView2"
        Me.NsListView2.Size = New System.Drawing.Size(345, 192)
        Me.NsListView2.TabIndex = 0
        Me.NsListView2.Text = "NsListView2"
        '
        'NsButton5
        '
        Me.NsButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsButton5.Location = New System.Drawing.Point(143, 201)
        Me.NsButton5.Name = "NsButton5"
        Me.NsButton5.Size = New System.Drawing.Size(100, 24)
        Me.NsButton5.TabIndex = 2
        Me.NsButton5.Text = "Game Check"
        '
        'NsButton4
        '
        Me.NsButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsButton4.Location = New System.Drawing.Point(249, 201)
        Me.NsButton4.Name = "NsButton4"
        Me.NsButton4.Size = New System.Drawing.Size(100, 24)
        Me.NsButton4.TabIndex = 1
        Me.NsButton4.Text = "Copy Specs"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.Label2)
        Me.TabPage5.Controls.Add(Me.Label1)
        Me.TabPage5.Controls.Add(Me.PictureBox2)
        Me.TabPage5.Location = New System.Drawing.Point(119, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(353, 232)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "About"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.Location = New System.Drawing.Point(12, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(329, 109)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(109, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "v1.0-0"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox2.Image = Global.Typhon.My.Resources.Resources.typhon
        Me.PictureBox2.Location = New System.Drawing.Point(112, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(139, 70)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'NsButton2
        '
        Me.NsButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NsButton2.Location = New System.Drawing.Point(388, 286)
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
        Me.NsLabel3.Location = New System.Drawing.Point(4, 286)
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
        Me.NsButton1.Location = New System.Drawing.Point(282, 286)
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
        Me.ClientSize = New System.Drawing.Size(500, 321)
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
        Me.NsGroupBox2.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NsContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NsTheme1 As Typhon.NSTheme
    Friend WithEvents NsControlButton1 As Typhon.NSControlButton
    Friend WithEvents NsControlButton2 As Typhon.NSControlButton
    Friend WithEvents NsGroupBox1 As Typhon.NSGroupBox
    Friend WithEvents NsGroupBox2 As Typhon.NSGroupBox
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
    Friend WithEvents NsComboBox1 As Typhon.NSComboBox
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
    Friend WithEvents NsListView2 As Typhon.NSListView
    Friend WithEvents NsButton4 As Typhon.NSButton
    Friend WithEvents NsButton5 As Typhon.NSButton
    Friend WithEvents NsOnOffBox3 As Typhon.NSOnOffBox
    Friend WithEvents NsOnOffBox4 As Typhon.NSOnOffBox
    Friend WithEvents NsOnOffBox6 As Typhon.NSOnOffBox
    Friend WithEvents NsLabel9 As Typhon.NSLabel
    Friend WithEvents NsLabel11 As Typhon.NSLabel
    Friend WithEvents NsLabel12 As Typhon.NSLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
