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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinMain))
        Me.timerRealtimeRAM = New System.Windows.Forms.Timer()
        Me.timerNotificationCooldown = New System.Windows.Forms.Timer()
        Me.timerGraph = New System.Windows.Forms.Timer()
        Me.themeContainer = New Typhon.NSTheme()
        Me.tabMain = New Typhon.NSTabControl()
        Me.tabOverview = New System.Windows.Forms.TabPage()
        Me.gbRAMOverview = New Typhon.NSGroupBox()
        Me.pbRAMUsage = New Typhon.NSProgressBar()
        Me.picMemoryIcon = New System.Windows.Forms.PictureBox()
        Me.lblRAMUsage = New Typhon.NSLabel()
        Me.lblProcessCount = New Typhon.NSLabel()
        Me.tabPerformance = New System.Windows.Forms.TabPage()
        Me.lblLivePerformanceStats = New Typhon.NSLabel()
        Me.chartPerformance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabCleaner = New System.Windows.Forms.TabPage()
        Me.tabSpaceLens = New System.Windows.Forms.TabPage()
        Me.tabGameBoost = New System.Windows.Forms.TabPage()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.gbAutomationSettings = New Typhon.NSGroupBox()
        Me.lblAutoOptimizeRAM = New Typhon.NSLabel()
        Me.cboAutoFreeRAM = New Typhon.NSComboBox()
        Me.lblAutoStartOnBoot = New Typhon.NSLabel()
        Me.toggleAutoStartOnBoot = New Typhon.NSOnOffBox()
        Me.lblStartMinimizedOnBoot = New Typhon.NSLabel()
        Me.toggleStartMinimizedOnBoot = New Typhon.NSOnOffBox()
        Me.lblMinimizeToTray = New Typhon.NSLabel()
        Me.toggleMinimizeToTray = New Typhon.NSOnOffBox()
        Me.lblCloseToTray = New Typhon.NSLabel()
        Me.toggleCloseToTray = New Typhon.NSOnOffBox()
        Me.lblExceptionsManager = New Typhon.NSLabel()
        Me.btnManageExceptions = New Typhon.NSButton()
        Me.tabSpecs = New System.Windows.Forms.TabPage()
        Me.lvSystemSpecs = New Typhon.NSListView()
        Me.btnCheckGameBenchmark = New Typhon.NSButton()
        Me.btnCopySpecs = New Typhon.NSButton()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.lblAboutAppDescription = New System.Windows.Forms.Label()
        Me.lblAboutAppVersion = New System.Windows.Forms.Label()
        Me.picAppLogo = New System.Windows.Forms.PictureBox()
        Me.btnProcesses = New Typhon.NSButton()
        Me.lblStatusMessage = New Typhon.NSLabel()
        Me.btnFreeRAM = New Typhon.NSButton()
        Me.btnControlMinimize = New Typhon.NSControlButton()
        Me.btnControlClose = New Typhon.NSControlButton()
        Me.notifTrayIcon = New System.Windows.Forms.NotifyIcon()
        Me.ctxTrayMenu = New Typhon.NSContextMenu()
        Me.menuOpenTyphon = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExitTyphon = New System.Windows.Forms.ToolStripMenuItem()
        Me.themeContainer.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabOverview.SuspendLayout()
        Me.gbRAMOverview.SuspendLayout()
        CType(Me.picMemoryIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPerformance.SuspendLayout()
        CType(Me.chartPerformance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSettings.SuspendLayout()
        Me.gbAutomationSettings.SuspendLayout()
        Me.tabSpecs.SuspendLayout()
        Me.tabAbout.SuspendLayout()
        CType(Me.picAppLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxTrayMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'timerRealtimeRAM
        '
        Me.timerRealtimeRAM.Interval = 1000
        '
        'timerNotificationCooldown
        '
        Me.timerNotificationCooldown.Interval = 5000
        '
        'timerGraph
        '
        Me.timerGraph.Enabled = True
        Me.timerGraph.Interval = 1000
        '
        'themeContainer
        '
        Me.themeContainer.AccentOffset = 42
        Me.themeContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.themeContainer.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.themeContainer.Colors = New Typhon.Bloom(-1) {}
        Me.themeContainer.Controls.Add(Me.tabMain)
        Me.themeContainer.Controls.Add(Me.btnProcesses)
        Me.themeContainer.Controls.Add(Me.lblStatusMessage)
        Me.themeContainer.Controls.Add(Me.btnFreeRAM)
        Me.themeContainer.Controls.Add(Me.btnControlMinimize)
        Me.themeContainer.Controls.Add(Me.btnControlClose)
        Me.themeContainer.Customization = ""
        Me.themeContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.themeContainer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.themeContainer.Image = Global.Typhon.My.Resources.Resources.typhon
        Me.themeContainer.Location = New System.Drawing.Point(0, 0)
        Me.themeContainer.Movable = True
        Me.themeContainer.Name = "themeContainer"
        Me.themeContainer.NoRounding = False
        Me.themeContainer.Sizable = False
        Me.themeContainer.Size = New System.Drawing.Size(500, 321)
        Me.themeContainer.SmartBounds = True
        Me.themeContainer.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.themeContainer.TabIndex = 0
        Me.themeContainer.Text = "Typhon: PC Booster"
        Me.themeContainer.TransparencyKey = System.Drawing.Color.Empty
        Me.themeContainer.Transparent = False
        '
        'tabMain
        '
        Me.tabMain.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.tabOverview)
        Me.tabMain.Controls.Add(Me.tabPerformance)
        Me.tabMain.Controls.Add(Me.tabCleaner)
        Me.tabMain.Controls.Add(Me.tabSpaceLens)
        Me.tabMain.Controls.Add(Me.tabGameBoost)
        Me.tabMain.Controls.Add(Me.tabSettings)
        Me.tabMain.Controls.Add(Me.tabSpecs)
        Me.tabMain.Controls.Add(Me.tabAbout)
        Me.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabMain.ItemSize = New System.Drawing.Size(28, 115)
        Me.tabMain.Location = New System.Drawing.Point(12, 40)
        Me.tabMain.Multiline = True
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(476, 240)
        Me.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMain.TabIndex = 6
        '
        'tabOverview
        '
        Me.tabOverview.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabOverview.Controls.Add(Me.gbRAMOverview)
        Me.tabOverview.Location = New System.Drawing.Point(119, 4)
        Me.tabOverview.Name = "tabOverview"
        Me.tabOverview.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOverview.Size = New System.Drawing.Size(353, 232)
        Me.tabOverview.TabIndex = 0
        Me.tabOverview.Text = "Boost"
        '
        'gbRAMOverview
        '
        Me.gbRAMOverview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRAMOverview.Controls.Add(Me.pbRAMUsage)
        Me.gbRAMOverview.Controls.Add(Me.picMemoryIcon)
        Me.gbRAMOverview.Controls.Add(Me.lblRAMUsage)
        Me.gbRAMOverview.Controls.Add(Me.lblProcessCount)
        Me.gbRAMOverview.DrawSeperator = False
        Me.gbRAMOverview.Location = New System.Drawing.Point(6, 6)
        Me.gbRAMOverview.Name = "gbRAMOverview"
        Me.gbRAMOverview.Size = New System.Drawing.Size(341, 220)
        Me.gbRAMOverview.SubTitle = "-"
        Me.gbRAMOverview.TabIndex = 2
        Me.gbRAMOverview.Text = "gbRAMOverview"
        Me.gbRAMOverview.Title = "[-]"
        '
        'pbRAMUsage
        '
        Me.pbRAMUsage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRAMUsage.Location = New System.Drawing.Point(3, 204)
        Me.pbRAMUsage.Maximum = 100
        Me.pbRAMUsage.Minimum = 0
        Me.pbRAMUsage.Name = "pbRAMUsage"
        Me.pbRAMUsage.Size = New System.Drawing.Size(335, 10)
        Me.pbRAMUsage.TabIndex = 3
        Me.pbRAMUsage.Text = "pbRAMUsage"
        Me.pbRAMUsage.Value = 0
        '
        'picMemoryIcon
        '
        Me.picMemoryIcon.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picMemoryIcon.Image = Global.Typhon.My.Resources.Resources.typhon
        Me.picMemoryIcon.Location = New System.Drawing.Point(199, 76)
        Me.picMemoryIcon.Name = "picMemoryIcon"
        Me.picMemoryIcon.Size = New System.Drawing.Size(139, 70)
        Me.picMemoryIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMemoryIcon.TabIndex = 3
        Me.picMemoryIcon.TabStop = False
        '
        'lblRAMUsage
        '
        Me.lblRAMUsage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRAMUsage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRAMUsage.Location = New System.Drawing.Point(3, 178)
        Me.lblRAMUsage.Name = "lblRAMUsage"
        Me.lblRAMUsage.Size = New System.Drawing.Size(335, 23)
        Me.lblRAMUsage.TabIndex = 4
        Me.lblRAMUsage.Text = "lblRAMUsage"
        Me.lblRAMUsage.Value1 = "Memory Usage:"
        Me.lblRAMUsage.Value2 = "-"
        '
        'lblProcessCount
        '
        Me.lblProcessCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProcessCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessCount.Location = New System.Drawing.Point(3, 159)
        Me.lblProcessCount.Name = "lblProcessCount"
        Me.lblProcessCount.Size = New System.Drawing.Size(190, 23)
        Me.lblProcessCount.TabIndex = 3
        Me.lblProcessCount.Text = "lblProcessCount"
        Me.lblProcessCount.Value1 = "Active Processes:"
        Me.lblProcessCount.Value2 = "-"
        '
        'tabPerformance
        '
        Me.tabPerformance.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabPerformance.Controls.Add(Me.lblLivePerformanceStats)
        Me.tabPerformance.Controls.Add(Me.chartPerformance)
        Me.tabPerformance.Location = New System.Drawing.Point(119, 4)
        Me.tabPerformance.Name = "tabPerformance"
        Me.tabPerformance.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPerformance.Size = New System.Drawing.Size(353, 232)
        Me.tabPerformance.TabIndex = 3
        Me.tabPerformance.Text = "Graph"
        '
        'lblLivePerformanceStats
        '
        Me.lblLivePerformanceStats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLivePerformanceStats.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLivePerformanceStats.Location = New System.Drawing.Point(6, 6)
        Me.lblLivePerformanceStats.Name = "lblLivePerformanceStats"
        Me.lblLivePerformanceStats.Size = New System.Drawing.Size(339, 23)
        Me.lblLivePerformanceStats.TabIndex = 11
        Me.lblLivePerformanceStats.Text = "Info:"
        Me.lblLivePerformanceStats.Value1 = "Info:"
        Me.lblLivePerformanceStats.Value2 = "-"
        '
        'chartPerformance
        '
        Me.chartPerformance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chartPerformance.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
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
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 86.0!
        ChartArea1.Position.Width = 99.0!
        ChartArea1.Position.Y = 13.0!
        Me.chartPerformance.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Far
        Legend1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.ForeColor = System.Drawing.Color.White
        Legend1.Name = "Legend1"
        Me.chartPerformance.Legends.Add(Legend1)
        Me.chartPerformance.Location = New System.Drawing.Point(3, 30)
        Me.chartPerformance.Name = "chartPerformance"
        Me.chartPerformance.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(229, Byte), Integer))
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(229, Byte), Integer))
        Series1.Legend = "Legend1"
        Series1.LegendText = "RAM"
        Series1.MarkerBorderColor = System.Drawing.Color.Transparent
        Series1.MarkerColor = System.Drawing.Color.White
        Series1.Name = "Series1"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.BorderWidth = 2
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.Legend = "Legend1"
        Series2.LegendText = "CPU"
        Series2.MarkerBorderColor = System.Drawing.Color.Transparent
        Series2.MarkerColor = System.Drawing.Color.White
        Series2.Name = "Series2"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(51, Byte), Integer))
        Series3.BorderWidth = 2
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series3.Color = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(51, Byte), Integer))
        Series3.Legend = "Legend1"
        Series3.LegendText = "GPU"
        Series3.MarkerBorderColor = System.Drawing.Color.Transparent
        Series3.MarkerColor = System.Drawing.Color.White
        Series3.Name = "Series3"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.chartPerformance.Series.Add(Series1)
        Me.chartPerformance.Series.Add(Series2)
        Me.chartPerformance.Series.Add(Series3)
        Me.chartPerformance.Size = New System.Drawing.Size(347, 198)
        Me.chartPerformance.TabIndex = 2
        Me.chartPerformance.Text = "chartPerformance"
        '
        'tabCleaner
        '
        Me.tabCleaner.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabCleaner.Location = New System.Drawing.Point(119, 4)
        Me.tabCleaner.Name = "tabCleaner"
        Me.tabCleaner.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCleaner.Size = New System.Drawing.Size(353, 232)
        Me.tabCleaner.TabIndex = 2
        Me.tabCleaner.Text = "Cleaner"
        '
        'tabSpaceLens
        '
        Me.tabSpaceLens.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabSpaceLens.Location = New System.Drawing.Point(119, 4)
        Me.tabSpaceLens.Name = "tabSpaceLens"
        Me.tabSpaceLens.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSpaceLens.Size = New System.Drawing.Size(353, 232)
        Me.tabSpaceLens.TabIndex = 6
        Me.tabSpaceLens.Text = "Sight"
        '
        'tabGameBoost
        '
        Me.tabGameBoost.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabGameBoost.Location = New System.Drawing.Point(119, 4)
        Me.tabGameBoost.Name = "tabGameBoost"
        Me.tabGameBoost.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGameBoost.Size = New System.Drawing.Size(353, 232)
        Me.tabGameBoost.TabIndex = 7
        Me.tabGameBoost.Text = "Gaming"
        '
        'tabSettings
        '
        Me.tabSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabSettings.Controls.Add(Me.gbAutomationSettings)
        Me.tabSettings.Location = New System.Drawing.Point(119, 4)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(353, 232)
        Me.tabSettings.TabIndex = 1
        Me.tabSettings.Text = "Settings"
        '
        'gbAutomationSettings
        '
        Me.gbAutomationSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAutomationSettings.Controls.Add(Me.lblAutoOptimizeRAM)
        Me.gbAutomationSettings.Controls.Add(Me.cboAutoFreeRAM)
        Me.gbAutomationSettings.Controls.Add(Me.lblAutoStartOnBoot)
        Me.gbAutomationSettings.Controls.Add(Me.toggleAutoStartOnBoot)
        Me.gbAutomationSettings.Controls.Add(Me.lblStartMinimizedOnBoot)
        Me.gbAutomationSettings.Controls.Add(Me.toggleStartMinimizedOnBoot)
        Me.gbAutomationSettings.Controls.Add(Me.lblMinimizeToTray)
        Me.gbAutomationSettings.Controls.Add(Me.toggleMinimizeToTray)
        Me.gbAutomationSettings.Controls.Add(Me.lblCloseToTray)
        Me.gbAutomationSettings.Controls.Add(Me.toggleCloseToTray)
        Me.gbAutomationSettings.Controls.Add(Me.lblExceptionsManager)
        Me.gbAutomationSettings.Controls.Add(Me.btnManageExceptions)
        Me.gbAutomationSettings.DrawSeperator = True
        Me.gbAutomationSettings.Location = New System.Drawing.Point(6, 4)
        Me.gbAutomationSettings.Name = "gbAutomationSettings"
        Me.gbAutomationSettings.Size = New System.Drawing.Size(341, 225)
        Me.gbAutomationSettings.SubTitle = "System boot, memory, and tray behaviors"
        Me.gbAutomationSettings.TabIndex = 0
        Me.gbAutomationSettings.Title = "Settings & Preferences"
        '
        'lblAutoOptimizeRAM
        '
        Me.lblAutoOptimizeRAM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoOptimizeRAM.Location = New System.Drawing.Point(10, 46)
        Me.lblAutoOptimizeRAM.Name = "lblAutoOptimizeRAM"
        Me.lblAutoOptimizeRAM.Size = New System.Drawing.Size(120, 20)
        Me.lblAutoOptimizeRAM.TabIndex = 1
        Me.lblAutoOptimizeRAM.Text = "lblAutoOptimizeRAM"
        Me.lblAutoOptimizeRAM.Value1 = "Auto "
        Me.lblAutoOptimizeRAM.Value2 = "Optimize RAM"
        '
        'cboAutoFreeRAM
        '
        Me.cboAutoFreeRAM.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.cboAutoFreeRAM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboAutoFreeRAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutoFreeRAM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.cboAutoFreeRAM.FormattingEnabled = True
        Me.cboAutoFreeRAM.Items.AddRange(New Object() {"Disabled", "Every 1 minute", "Every 5 minutes", "Every 10 minutes", "When reaching 80% RAM"})
        Me.cboAutoFreeRAM.Location = New System.Drawing.Point(135, 45)
        Me.cboAutoFreeRAM.Name = "cboAutoFreeRAM"
        Me.cboAutoFreeRAM.Size = New System.Drawing.Size(196, 21)
        Me.cboAutoFreeRAM.TabIndex = 2
        '
        'lblAutoStartOnBoot
        '
        Me.lblAutoStartOnBoot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoStartOnBoot.Location = New System.Drawing.Point(10, 75)
        Me.lblAutoStartOnBoot.Name = "lblAutoStartOnBoot"
        Me.lblAutoStartOnBoot.Size = New System.Drawing.Size(250, 20)
        Me.lblAutoStartOnBoot.TabIndex = 3
        Me.lblAutoStartOnBoot.Text = "lblAutoStartOnBoot"
        Me.lblAutoStartOnBoot.Value1 = "Autostart on "
        Me.lblAutoStartOnBoot.Value2 = "PC Boot"
        '
        'toggleAutoStartOnBoot
        '
        Me.toggleAutoStartOnBoot.Checked = False
        Me.toggleAutoStartOnBoot.Location = New System.Drawing.Point(275, 73)
        Me.toggleAutoStartOnBoot.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleAutoStartOnBoot.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleAutoStartOnBoot.Name = "toggleAutoStartOnBoot"
        Me.toggleAutoStartOnBoot.Size = New System.Drawing.Size(56, 24)
        Me.toggleAutoStartOnBoot.TabIndex = 4
        Me.toggleAutoStartOnBoot.Text = "toggleAutoStartOnBoot"
        '
        'lblStartMinimizedOnBoot
        '
        Me.lblStartMinimizedOnBoot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartMinimizedOnBoot.Location = New System.Drawing.Point(10, 103)
        Me.lblStartMinimizedOnBoot.Name = "lblStartMinimizedOnBoot"
        Me.lblStartMinimizedOnBoot.Size = New System.Drawing.Size(250, 20)
        Me.lblStartMinimizedOnBoot.TabIndex = 5
        Me.lblStartMinimizedOnBoot.Text = "lblStartMinimizedOnBoot"
        Me.lblStartMinimizedOnBoot.Value1 = "Start Minimized "
        Me.lblStartMinimizedOnBoot.Value2 = " on Boot"
        '
        'toggleStartMinimizedOnBoot
        '
        Me.toggleStartMinimizedOnBoot.Checked = False
        Me.toggleStartMinimizedOnBoot.Location = New System.Drawing.Point(275, 101)
        Me.toggleStartMinimizedOnBoot.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleStartMinimizedOnBoot.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleStartMinimizedOnBoot.Name = "toggleStartMinimizedOnBoot"
        Me.toggleStartMinimizedOnBoot.Size = New System.Drawing.Size(56, 24)
        Me.toggleStartMinimizedOnBoot.TabIndex = 6
        Me.toggleStartMinimizedOnBoot.Text = "toggleStartMinimizedOnBoot"
        '
        'lblMinimizeToTray
        '
        Me.lblMinimizeToTray.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinimizeToTray.Location = New System.Drawing.Point(10, 131)
        Me.lblMinimizeToTray.Name = "lblMinimizeToTray"
        Me.lblMinimizeToTray.Size = New System.Drawing.Size(250, 20)
        Me.lblMinimizeToTray.TabIndex = 7
        Me.lblMinimizeToTray.Text = "lblMinimizeToTray"
        Me.lblMinimizeToTray.Value1 = "Minimize Window "
        Me.lblMinimizeToTray.Value2 = "to System Tray"
        '
        'toggleMinimizeToTray
        '
        Me.toggleMinimizeToTray.Checked = False
        Me.toggleMinimizeToTray.Location = New System.Drawing.Point(275, 129)
        Me.toggleMinimizeToTray.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleMinimizeToTray.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleMinimizeToTray.Name = "toggleMinimizeToTray"
        Me.toggleMinimizeToTray.Size = New System.Drawing.Size(56, 24)
        Me.toggleMinimizeToTray.TabIndex = 8
        Me.toggleMinimizeToTray.Text = "toggleMinimizeToTray"
        '
        'lblCloseToTray
        '
        Me.lblCloseToTray.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCloseToTray.Location = New System.Drawing.Point(10, 159)
        Me.lblCloseToTray.Name = "lblCloseToTray"
        Me.lblCloseToTray.Size = New System.Drawing.Size(250, 20)
        Me.lblCloseToTray.TabIndex = 9
        Me.lblCloseToTray.Text = "lblCloseToTray"
        Me.lblCloseToTray.Value1 = "Close [X] Button "
        Me.lblCloseToTray.Value2 = " to System Tray"
        '
        'toggleCloseToTray
        '
        Me.toggleCloseToTray.Checked = False
        Me.toggleCloseToTray.Location = New System.Drawing.Point(275, 157)
        Me.toggleCloseToTray.MaximumSize = New System.Drawing.Size(56, 24)
        Me.toggleCloseToTray.MinimumSize = New System.Drawing.Size(56, 24)
        Me.toggleCloseToTray.Name = "toggleCloseToTray"
        Me.toggleCloseToTray.Size = New System.Drawing.Size(56, 24)
        Me.toggleCloseToTray.TabIndex = 10
        Me.toggleCloseToTray.Text = "toggleCloseToTray"
        '
        'lblExceptionsManager
        '
        Me.lblExceptionsManager.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExceptionsManager.Location = New System.Drawing.Point(10, 188)
        Me.lblExceptionsManager.Name = "lblExceptionsManager"
        Me.lblExceptionsManager.Size = New System.Drawing.Size(250, 20)
        Me.lblExceptionsManager.TabIndex = 13
        Me.lblExceptionsManager.Text = "lblExceptionsManager"
        Me.lblExceptionsManager.Value1 = "Manage "
        Me.lblExceptionsManager.Value2 = "Process Exceptions"
        '
        'btnManageExceptions
        '
        Me.btnManageExceptions.Location = New System.Drawing.Point(275, 187)
        Me.btnManageExceptions.Name = "btnManageExceptions"
        Me.btnManageExceptions.Size = New System.Drawing.Size(56, 22)
        Me.btnManageExceptions.TabIndex = 14
        Me.btnManageExceptions.Text = "Open"
        '
        'tabSpecs
        '
        Me.tabSpecs.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabSpecs.Controls.Add(Me.lvSystemSpecs)
        Me.tabSpecs.Controls.Add(Me.btnCheckGameBenchmark)
        Me.tabSpecs.Controls.Add(Me.btnCopySpecs)
        Me.tabSpecs.Location = New System.Drawing.Point(119, 4)
        Me.tabSpecs.Name = "tabSpecs"
        Me.tabSpecs.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSpecs.Size = New System.Drawing.Size(353, 232)
        Me.tabSpecs.TabIndex = 5
        Me.tabSpecs.Text = "PC Specs"
        '
        'lvSystemSpecs
        '
        Me.lvSystemSpecs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSystemSpecs.CheckBoxes = False
        Me.lvSystemSpecs.Columns = New Typhon.NSListView.NSListViewColumnHeader(-1) {}
        Me.lvSystemSpecs.Items = New Typhon.NSListView.NSListViewItem(-1) {}
        Me.lvSystemSpecs.Location = New System.Drawing.Point(4, 4)
        Me.lvSystemSpecs.MultiSelect = True
        Me.lvSystemSpecs.Name = "lvSystemSpecs"
        Me.lvSystemSpecs.Size = New System.Drawing.Size(345, 192)
        Me.lvSystemSpecs.TabIndex = 0
        Me.lvSystemSpecs.Text = "lvSystemSpecs"
        '
        'btnCheckGameBenchmark
        '
        Me.btnCheckGameBenchmark.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckGameBenchmark.Location = New System.Drawing.Point(143, 201)
        Me.btnCheckGameBenchmark.Name = "btnCheckGameBenchmark"
        Me.btnCheckGameBenchmark.Size = New System.Drawing.Size(100, 24)
        Me.btnCheckGameBenchmark.TabIndex = 2
        Me.btnCheckGameBenchmark.Text = "Game Check"
        '
        'btnCopySpecs
        '
        Me.btnCopySpecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopySpecs.Location = New System.Drawing.Point(249, 201)
        Me.btnCopySpecs.Name = "btnCopySpecs"
        Me.btnCopySpecs.Size = New System.Drawing.Size(100, 24)
        Me.btnCopySpecs.TabIndex = 1
        Me.btnCopySpecs.Text = "Copy Specs"
        '
        'tabAbout
        '
        Me.tabAbout.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.tabAbout.Controls.Add(Me.lblAboutAppDescription)
        Me.tabAbout.Controls.Add(Me.lblAboutAppVersion)
        Me.tabAbout.Controls.Add(Me.picAppLogo)
        Me.tabAbout.Location = New System.Drawing.Point(119, 4)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAbout.Size = New System.Drawing.Size(353, 232)
        Me.tabAbout.TabIndex = 4
        Me.tabAbout.Text = "About"
        '
        'lblAboutAppDescription
        '
        Me.lblAboutAppDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboutAppDescription.ForeColor = System.Drawing.Color.LightGray
        Me.lblAboutAppDescription.Location = New System.Drawing.Point(12, 101)
        Me.lblAboutAppDescription.Name = "lblAboutAppDescription"
        Me.lblAboutAppDescription.Size = New System.Drawing.Size(329, 126)
        Me.lblAboutAppDescription.TabIndex = 6
        Me.lblAboutAppDescription.Text = resources.GetString("Label2.Text")
        Me.lblAboutAppDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAboutAppVersion
        '
        Me.lblAboutAppVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboutAppVersion.ForeColor = System.Drawing.Color.White
        Me.lblAboutAppVersion.Location = New System.Drawing.Point(109, 82)
        Me.lblAboutAppVersion.Name = "lblAboutAppVersion"
        Me.lblAboutAppVersion.Size = New System.Drawing.Size(142, 13)
        Me.lblAboutAppVersion.TabIndex = 5
        Me.lblAboutAppVersion.Text = "v1.0-0"
        Me.lblAboutAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picAppLogo
        '
        Me.picAppLogo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picAppLogo.Image = Global.Typhon.My.Resources.Resources.typhon
        Me.picAppLogo.Location = New System.Drawing.Point(112, 9)
        Me.picAppLogo.Name = "picAppLogo"
        Me.picAppLogo.Size = New System.Drawing.Size(139, 70)
        Me.picAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAppLogo.TabIndex = 4
        Me.picAppLogo.TabStop = False
        '
        'btnProcesses
        '
        Me.btnProcesses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcesses.Location = New System.Drawing.Point(388, 286)
        Me.btnProcesses.Name = "btnProcesses"
        Me.btnProcesses.Size = New System.Drawing.Size(100, 23)
        Me.btnProcesses.TabIndex = 5
        Me.btnProcesses.Text = "Processes"
        '
        'lblStatusMessage
        '
        Me.lblStatusMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusMessage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusMessage.Location = New System.Drawing.Point(4, 286)
        Me.lblStatusMessage.Name = "lblStatusMessage"
        Me.lblStatusMessage.Size = New System.Drawing.Size(272, 23)
        Me.lblStatusMessage.TabIndex = 4
        Me.lblStatusMessage.Text = "lblStatusMessage"
        Me.lblStatusMessage.Value1 = ""
        Me.lblStatusMessage.Value2 = ""
        '
        'btnFreeRAM
        '
        Me.btnFreeRAM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFreeRAM.Location = New System.Drawing.Point(282, 286)
        Me.btnFreeRAM.Name = "btnFreeRAM"
        Me.btnFreeRAM.Size = New System.Drawing.Size(100, 23)
        Me.btnFreeRAM.TabIndex = 3
        Me.btnFreeRAM.Text = "Free RAM"
        '
        'btnControlMinimize
        '
        Me.btnControlMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlMinimize.ControlButton = Typhon.NSControlButton.Button.Minimize
        Me.btnControlMinimize.Location = New System.Drawing.Point(458, 5)
        Me.btnControlMinimize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlMinimize.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.Name = "btnControlMinimize"
        Me.btnControlMinimize.Size = New System.Drawing.Size(18, 20)
        Me.btnControlMinimize.TabIndex = 1
        Me.btnControlMinimize.Text = "btnControlMinimize"
        '
        'btnControlClose
        '
        Me.btnControlClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlClose.ControlButton = Typhon.NSControlButton.Button.Close
        Me.btnControlClose.Location = New System.Drawing.Point(476, 5)
        Me.btnControlClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnControlClose.MaximumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.MinimumSize = New System.Drawing.Size(18, 20)
        Me.btnControlClose.Name = "btnControlClose"
        Me.btnControlClose.Size = New System.Drawing.Size(18, 20)
        Me.btnControlClose.TabIndex = 0
        Me.btnControlClose.Text = "btnControlClose"
        '
        'notifTrayIcon
        '
        Me.notifTrayIcon.ContextMenuStrip = Me.ctxTrayMenu
        Me.notifTrayIcon.Text = "Typhon PC Booster"
        '
        'ctxTrayMenu
        '
        Me.ctxTrayMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ctxTrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuOpenTyphon, Me.menuExitTyphon})
        Me.ctxTrayMenu.Name = "ctxTrayMenu"
        Me.ctxTrayMenu.Size = New System.Drawing.Size(147, 48)
        '
        'menuOpenTyphon
        '
        Me.menuOpenTyphon.Image = Global.Typhon.My.Resources.Resources.typhon_ico
        Me.menuOpenTyphon.Name = "menuOpenTyphon"
        Me.menuOpenTyphon.Size = New System.Drawing.Size(146, 22)
        Me.menuOpenTyphon.Text = "Open Typhon"
        '
        'menuExitTyphon
        '
        Me.menuExitTyphon.Image = Global.Typhon.My.Resources.Resources.icons8_poison_18
        Me.menuExitTyphon.Name = "menuExitTyphon"
        Me.menuExitTyphon.Size = New System.Drawing.Size(146, 22)
        Me.menuExitTyphon.Text = "Exit"
        '
        'WinMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.themeContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WinMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Typhon: PC Booster"
        Me.themeContainer.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabOverview.ResumeLayout(False)
        Me.gbRAMOverview.ResumeLayout(False)
        CType(Me.picMemoryIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPerformance.ResumeLayout(False)
        CType(Me.chartPerformance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSettings.ResumeLayout(False)
        Me.gbAutomationSettings.ResumeLayout(False)
        Me.tabSpecs.ResumeLayout(False)
        Me.tabAbout.ResumeLayout(False)
        CType(Me.picAppLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxTrayMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents themeContainer As Typhon.NSTheme
    Friend WithEvents btnControlClose As Typhon.NSControlButton
    Friend WithEvents btnControlMinimize As Typhon.NSControlButton
    Friend WithEvents gbRAMOverview As Typhon.NSGroupBox
    Friend WithEvents gbAutomationSettings As Typhon.NSGroupBox
    Friend WithEvents lblProcessCount As Typhon.NSLabel
    Friend WithEvents timerRealtimeRAM As System.Windows.Forms.Timer
    Friend WithEvents lblRAMUsage As Typhon.NSLabel
    Friend WithEvents picMemoryIcon As System.Windows.Forms.PictureBox
    Friend WithEvents pbRAMUsage As Typhon.NSProgressBar
    Friend WithEvents btnFreeRAM As Typhon.NSButton
    Friend WithEvents lblStatusMessage As Typhon.NSLabel
    Friend WithEvents timerNotificationCooldown As System.Windows.Forms.Timer
    Friend WithEvents btnProcesses As Typhon.NSButton
    Friend WithEvents notifTrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ctxTrayMenu As Typhon.NSContextMenu
    Friend WithEvents menuOpenTyphon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExitTyphon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabMain As Typhon.NSTabControl
    Friend WithEvents tabOverview As System.Windows.Forms.TabPage
    Friend WithEvents tabSettings As System.Windows.Forms.TabPage
    Friend WithEvents cboAutoFreeRAM As Typhon.NSComboBox
    Friend WithEvents lblAutoOptimizeRAM As Typhon.NSLabel
    Friend WithEvents btnManageExceptions As Typhon.NSButton
    Friend WithEvents lblExceptionsManager As Typhon.NSLabel
    Friend WithEvents lblAutoStartOnBoot As Typhon.NSLabel
    Friend WithEvents toggleAutoStartOnBoot As Typhon.NSOnOffBox
    Friend WithEvents tabCleaner As System.Windows.Forms.TabPage
    Friend WithEvents tabSpaceLens As System.Windows.Forms.TabPage
    Friend WithEvents tabGameBoost As System.Windows.Forms.TabPage
    Friend WithEvents tabPerformance As System.Windows.Forms.TabPage
    Friend WithEvents chartPerformance As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents timerGraph As System.Windows.Forms.Timer
    Friend WithEvents lblLivePerformanceStats As Typhon.NSLabel
    Friend WithEvents tabAbout As System.Windows.Forms.TabPage
    Friend WithEvents tabSpecs As System.Windows.Forms.TabPage
    Friend WithEvents lvSystemSpecs As Typhon.NSListView
    Friend WithEvents btnCopySpecs As Typhon.NSButton
    Friend WithEvents btnCheckGameBenchmark As Typhon.NSButton
    Friend WithEvents toggleMinimizeToTray As Typhon.NSOnOffBox
    Friend WithEvents toggleCloseToTray As Typhon.NSOnOffBox
    Friend WithEvents toggleStartMinimizedOnBoot As Typhon.NSOnOffBox
    Friend WithEvents lblCloseToTray As Typhon.NSLabel
    Friend WithEvents lblStartMinimizedOnBoot As Typhon.NSLabel
    Friend WithEvents lblMinimizeToTray As Typhon.NSLabel
    Friend WithEvents picAppLogo As PictureBox
    Friend WithEvents lblAboutAppVersion As Label
    Friend WithEvents lblAboutAppDescription As Label
End Class
