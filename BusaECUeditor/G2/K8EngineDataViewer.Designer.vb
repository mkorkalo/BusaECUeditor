<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8EngineDataViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8EngineDataViewer))
        Me.LV_ValueDetails = New System.Windows.Forms.ListView()
        Me.Column1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Column2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.L_MinTPS = New System.Windows.Forms.Label()
        Me.N_MinTPS = New System.Windows.Forms.NumericUpDown()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LB_Values = New System.Windows.Forms.ListBox()
        Me.G_FuelMap = New System.Windows.Forms.DataGridView()
        Me.B_LoadDataFile = New System.Windows.Forms.Button()
        Me.L_FileName = New System.Windows.Forms.Label()
        Me.C_WidebandO2Sensor = New System.Windows.Forms.CheckBox()
        Me.B_DataFilters = New System.Windows.Forms.Button()
        Me.R_LoggedAFR = New System.Windows.Forms.RadioButton()
        Me.R_TargetAFR = New System.Windows.Forms.RadioButton()
        Me.R_PercentageMapChange = New System.Windows.Forms.RadioButton()
        Me.B_AutoTuneSettings = New System.Windows.Forms.Button()
        Me.B_LoadTargetAFR = New System.Windows.Forms.Button()
        Me.B_SaveTargetAFR = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.R_AutoTunedMap = New System.Windows.Forms.RadioButton()
        Me.R_DataCount = New System.Windows.Forms.RadioButton()
        Me.R_TPSRPM = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.R_BOOSTRPM = New System.Windows.Forms.RadioButton()
        Me.R_IAPRPM = New System.Windows.Forms.RadioButton()
        Me.B_AutoTune = New System.Windows.Forms.Button()
        Me.L_AvgTPS = New System.Windows.Forms.Label()
        Me.L_CellInfo = New System.Windows.Forms.Label()
        Me.L_CellStats = New System.Windows.Forms.Label()
        CType(Me.N_MinTPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G_FuelMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LV_ValueDetails
        '
        Me.LV_ValueDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Column1, Me.Column2})
        Me.LV_ValueDetails.Location = New System.Drawing.Point(897, 321)
        Me.LV_ValueDetails.Name = "LV_ValueDetails"
        Me.LV_ValueDetails.Size = New System.Drawing.Size(200, 388)
        Me.LV_ValueDetails.TabIndex = 21
        Me.LV_ValueDetails.UseCompatibleStateImageBehavior = False
        Me.LV_ValueDetails.View = System.Windows.Forms.View.Details
        '
        'Column1
        '
        Me.Column1.Text = "Name"
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.Text = "Value"
        Me.Column2.Width = 90
        '
        'L_MinTPS
        '
        Me.L_MinTPS.AutoSize = True
        Me.L_MinTPS.Location = New System.Drawing.Point(376, 57)
        Me.L_MinTPS.Name = "L_MinTPS"
        Me.L_MinTPS.Size = New System.Drawing.Size(37, 13)
        Me.L_MinTPS.TabIndex = 20
        Me.L_MinTPS.Text = "TPS >"
        Me.L_MinTPS.Visible = False
        '
        'N_MinTPS
        '
        Me.N_MinTPS.Location = New System.Drawing.Point(419, 55)
        Me.N_MinTPS.Name = "N_MinTPS"
        Me.N_MinTPS.Size = New System.Drawing.Size(52, 20)
        Me.N_MinTPS.TabIndex = 19
        Me.N_MinTPS.Value = New Decimal(New Integer() {11, 0, 0, 0})
        Me.N_MinTPS.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LB_Values
        '
        Me.LB_Values.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LB_Values.FormattingEnabled = True
        Me.LB_Values.Location = New System.Drawing.Point(897, 72)
        Me.LB_Values.Name = "LB_Values"
        Me.LB_Values.Size = New System.Drawing.Size(200, 251)
        Me.LB_Values.TabIndex = 15
        '
        'G_FuelMap
        '
        Me.G_FuelMap.AllowUserToAddRows = False
        Me.G_FuelMap.AllowUserToDeleteRows = False
        Me.G_FuelMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.G_FuelMap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.G_FuelMap.Location = New System.Drawing.Point(5, 78)
        Me.G_FuelMap.Name = "G_FuelMap"
        Me.G_FuelMap.Size = New System.Drawing.Size(886, 632)
        Me.G_FuelMap.TabIndex = 14
        '
        'B_LoadDataFile
        '
        Me.B_LoadDataFile.Location = New System.Drawing.Point(5, 4)
        Me.B_LoadDataFile.Name = "B_LoadDataFile"
        Me.B_LoadDataFile.Size = New System.Drawing.Size(99, 23)
        Me.B_LoadDataFile.TabIndex = 13
        Me.B_LoadDataFile.Text = "Load Data File"
        Me.B_LoadDataFile.UseVisualStyleBackColor = True
        '
        'L_FileName
        '
        Me.L_FileName.AutoSize = True
        Me.L_FileName.Location = New System.Drawing.Point(110, 9)
        Me.L_FileName.Name = "L_FileName"
        Me.L_FileName.Size = New System.Drawing.Size(10, 13)
        Me.L_FileName.TabIndex = 22
        Me.L_FileName.Text = "-"
        '
        'C_WidebandO2Sensor
        '
        Me.C_WidebandO2Sensor.AutoSize = True
        Me.C_WidebandO2Sensor.Location = New System.Drawing.Point(539, 58)
        Me.C_WidebandO2Sensor.Name = "C_WidebandO2Sensor"
        Me.C_WidebandO2Sensor.Size = New System.Drawing.Size(128, 17)
        Me.C_WidebandO2Sensor.TabIndex = 24
        Me.C_WidebandO2Sensor.Text = "Wideband O2 Sensor"
        Me.C_WidebandO2Sensor.UseVisualStyleBackColor = True
        '
        'B_DataFilters
        '
        Me.B_DataFilters.Location = New System.Drawing.Point(674, 54)
        Me.B_DataFilters.Name = "B_DataFilters"
        Me.B_DataFilters.Size = New System.Drawing.Size(101, 23)
        Me.B_DataFilters.TabIndex = 25
        Me.B_DataFilters.Text = "Data Filters"
        Me.B_DataFilters.UseVisualStyleBackColor = True
        '
        'R_LoggedAFR
        '
        Me.R_LoggedAFR.AutoSize = True
        Me.R_LoggedAFR.Checked = True
        Me.R_LoggedAFR.Location = New System.Drawing.Point(6, 9)
        Me.R_LoggedAFR.Name = "R_LoggedAFR"
        Me.R_LoggedAFR.Size = New System.Drawing.Size(85, 17)
        Me.R_LoggedAFR.TabIndex = 26
        Me.R_LoggedAFR.TabStop = True
        Me.R_LoggedAFR.Text = "Logged AFR"
        Me.R_LoggedAFR.UseVisualStyleBackColor = True
        '
        'R_TargetAFR
        '
        Me.R_TargetAFR.AutoSize = True
        Me.R_TargetAFR.Location = New System.Drawing.Point(182, 9)
        Me.R_TargetAFR.Name = "R_TargetAFR"
        Me.R_TargetAFR.Size = New System.Drawing.Size(80, 17)
        Me.R_TargetAFR.TabIndex = 27
        Me.R_TargetAFR.Text = "Target AFR"
        Me.R_TargetAFR.UseVisualStyleBackColor = True
        '
        'R_PercentageMapChange
        '
        Me.R_PercentageMapChange.AutoSize = True
        Me.R_PercentageMapChange.Location = New System.Drawing.Point(268, 9)
        Me.R_PercentageMapChange.Name = "R_PercentageMapChange"
        Me.R_PercentageMapChange.Size = New System.Drawing.Size(97, 17)
        Me.R_PercentageMapChange.TabIndex = 28
        Me.R_PercentageMapChange.Text = "% Map Change"
        Me.R_PercentageMapChange.UseVisualStyleBackColor = True
        '
        'B_AutoTuneSettings
        '
        Me.B_AutoTuneSettings.Location = New System.Drawing.Point(777, 54)
        Me.B_AutoTuneSettings.Name = "B_AutoTuneSettings"
        Me.B_AutoTuneSettings.Size = New System.Drawing.Size(114, 23)
        Me.B_AutoTuneSettings.TabIndex = 29
        Me.B_AutoTuneSettings.Text = "Auto Tune Settings"
        Me.B_AutoTuneSettings.UseVisualStyleBackColor = True
        '
        'B_LoadTargetAFR
        '
        Me.B_LoadTargetAFR.Location = New System.Drawing.Point(674, 32)
        Me.B_LoadTargetAFR.Name = "B_LoadTargetAFR"
        Me.B_LoadTargetAFR.Size = New System.Drawing.Size(101, 23)
        Me.B_LoadTargetAFR.TabIndex = 30
        Me.B_LoadTargetAFR.Text = "Load Target AFR"
        Me.B_LoadTargetAFR.UseVisualStyleBackColor = True
        Me.B_LoadTargetAFR.Visible = False
        '
        'B_SaveTargetAFR
        '
        Me.B_SaveTargetAFR.Location = New System.Drawing.Point(777, 32)
        Me.B_SaveTargetAFR.Name = "B_SaveTargetAFR"
        Me.B_SaveTargetAFR.Size = New System.Drawing.Size(114, 23)
        Me.B_SaveTargetAFR.TabIndex = 31
        Me.B_SaveTargetAFR.Text = "Save Target AFR"
        Me.B_SaveTargetAFR.UseVisualStyleBackColor = True
        Me.B_SaveTargetAFR.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.R_AutoTunedMap)
        Me.GroupBox1.Controls.Add(Me.R_DataCount)
        Me.GroupBox1.Controls.Add(Me.R_LoggedAFR)
        Me.GroupBox1.Controls.Add(Me.R_TargetAFR)
        Me.GroupBox1.Controls.Add(Me.R_PercentageMapChange)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(483, 28)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'R_AutoTunedMap
        '
        Me.R_AutoTunedMap.AutoSize = True
        Me.R_AutoTunedMap.Location = New System.Drawing.Point(369, 9)
        Me.R_AutoTunedMap.Name = "R_AutoTunedMap"
        Me.R_AutoTunedMap.Size = New System.Drawing.Size(105, 17)
        Me.R_AutoTunedMap.TabIndex = 30
        Me.R_AutoTunedMap.Text = "Auto Tuned Map"
        Me.R_AutoTunedMap.UseVisualStyleBackColor = True
        '
        'R_DataCount
        '
        Me.R_DataCount.AutoSize = True
        Me.R_DataCount.Location = New System.Drawing.Point(97, 9)
        Me.R_DataCount.Name = "R_DataCount"
        Me.R_DataCount.Size = New System.Drawing.Size(79, 17)
        Me.R_DataCount.TabIndex = 29
        Me.R_DataCount.TabStop = True
        Me.R_DataCount.Text = "Data Count"
        Me.R_DataCount.UseVisualStyleBackColor = True
        '
        'R_TPSRPM
        '
        Me.R_TPSRPM.AutoSize = True
        Me.R_TPSRPM.Checked = True
        Me.R_TPSRPM.Location = New System.Drawing.Point(6, 9)
        Me.R_TPSRPM.Name = "R_TPSRPM"
        Me.R_TPSRPM.Size = New System.Drawing.Size(75, 17)
        Me.R_TPSRPM.TabIndex = 33
        Me.R_TPSRPM.TabStop = True
        Me.R_TPSRPM.Text = "TPS/RPM"
        Me.R_TPSRPM.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.R_BOOSTRPM)
        Me.GroupBox2.Controls.Add(Me.R_IAPRPM)
        Me.GroupBox2.Controls.Add(Me.R_TPSRPM)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 28)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        '
        'R_BOOSTRPM
        '
        Me.R_BOOSTRPM.AutoSize = True
        Me.R_BOOSTRPM.Location = New System.Drawing.Point(183, 8)
        Me.R_BOOSTRPM.Name = "R_BOOSTRPM"
        Me.R_BOOSTRPM.Size = New System.Drawing.Size(81, 17)
        Me.R_BOOSTRPM.TabIndex = 35
        Me.R_BOOSTRPM.Text = "Boost/RPM"
        Me.R_BOOSTRPM.UseVisualStyleBackColor = True
        '
        'R_IAPRPM
        '
        Me.R_IAPRPM.AutoSize = True
        Me.R_IAPRPM.Location = New System.Drawing.Point(97, 8)
        Me.R_IAPRPM.Name = "R_IAPRPM"
        Me.R_IAPRPM.Size = New System.Drawing.Size(71, 17)
        Me.R_IAPRPM.TabIndex = 34
        Me.R_IAPRPM.Text = "IAP/RPM"
        Me.R_IAPRPM.UseVisualStyleBackColor = True
        '
        'B_AutoTune
        '
        Me.B_AutoTune.Location = New System.Drawing.Point(492, 32)
        Me.B_AutoTune.Name = "B_AutoTune"
        Me.B_AutoTune.Size = New System.Drawing.Size(75, 23)
        Me.B_AutoTune.TabIndex = 36
        Me.B_AutoTune.Text = "Auto Tune"
        Me.B_AutoTune.UseVisualStyleBackColor = True
        Me.B_AutoTune.Visible = False
        '
        'L_AvgTPS
        '
        Me.L_AvgTPS.AutoSize = True
        Me.L_AvgTPS.Location = New System.Drawing.Point(898, 34)
        Me.L_AvgTPS.Name = "L_AvgTPS"
        Me.L_AvgTPS.Size = New System.Drawing.Size(10, 13)
        Me.L_AvgTPS.TabIndex = 37
        Me.L_AvgTPS.Text = "-"
        '
        'L_CellInfo
        '
        Me.L_CellInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_CellInfo.Location = New System.Drawing.Point(379, 4)
        Me.L_CellInfo.Name = "L_CellInfo"
        Me.L_CellInfo.Size = New System.Drawing.Size(718, 26)
        Me.L_CellInfo.TabIndex = 39
        Me.L_CellInfo.Text = "-"
        Me.L_CellInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'L_CellStats
        '
        Me.L_CellStats.AutoSize = True
        Me.L_CellStats.Location = New System.Drawing.Point(898, 51)
        Me.L_CellStats.Name = "L_CellStats"
        Me.L_CellStats.Size = New System.Drawing.Size(10, 13)
        Me.L_CellStats.TabIndex = 40
        Me.L_CellStats.Text = "-"
        '
        'K8EngineDataViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 717)
        Me.Controls.Add(Me.L_CellStats)
        Me.Controls.Add(Me.L_AvgTPS)
        Me.Controls.Add(Me.B_AutoTune)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.B_SaveTargetAFR)
        Me.Controls.Add(Me.B_LoadTargetAFR)
        Me.Controls.Add(Me.B_AutoTuneSettings)
        Me.Controls.Add(Me.B_DataFilters)
        Me.Controls.Add(Me.C_WidebandO2Sensor)
        Me.Controls.Add(Me.L_FileName)
        Me.Controls.Add(Me.LV_ValueDetails)
        Me.Controls.Add(Me.L_MinTPS)
        Me.Controls.Add(Me.N_MinTPS)
        Me.Controls.Add(Me.LB_Values)
        Me.Controls.Add(Me.G_FuelMap)
        Me.Controls.Add(Me.B_LoadDataFile)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.L_CellInfo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "K8EngineDataViewer"
        Me.Text = "Engine Data Viewer"
        CType(Me.N_MinTPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G_FuelMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LV_ValueDetails As System.Windows.Forms.ListView
    Friend WithEvents Column1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Column2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents L_MinTPS As System.Windows.Forms.Label
    Friend WithEvents N_MinTPS As System.Windows.Forms.NumericUpDown
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LB_Values As System.Windows.Forms.ListBox
    Friend WithEvents G_FuelMap As System.Windows.Forms.DataGridView
    Friend WithEvents B_LoadDataFile As System.Windows.Forms.Button
    Friend WithEvents L_FileName As System.Windows.Forms.Label
    Friend WithEvents C_WidebandO2Sensor As System.Windows.Forms.CheckBox
    Friend WithEvents B_DataFilters As System.Windows.Forms.Button
    Friend WithEvents R_LoggedAFR As System.Windows.Forms.RadioButton
    Friend WithEvents R_TargetAFR As System.Windows.Forms.RadioButton
    Friend WithEvents R_PercentageMapChange As System.Windows.Forms.RadioButton
    Friend WithEvents B_AutoTuneSettings As System.Windows.Forms.Button
    Friend WithEvents B_LoadTargetAFR As System.Windows.Forms.Button
    Friend WithEvents B_SaveTargetAFR As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents R_TPSRPM As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents R_IAPRPM As System.Windows.Forms.RadioButton
    Friend WithEvents R_BOOSTRPM As System.Windows.Forms.RadioButton
    Friend WithEvents B_AutoTune As System.Windows.Forms.Button
    Friend WithEvents L_AvgTPS As System.Windows.Forms.Label
    Friend WithEvents R_DataCount As System.Windows.Forms.RadioButton
    Friend WithEvents L_CellInfo As System.Windows.Forms.Label
    Friend WithEvents L_CellStats As System.Windows.Forms.Label
    Friend WithEvents R_AutoTunedMap As System.Windows.Forms.RadioButton
End Class
