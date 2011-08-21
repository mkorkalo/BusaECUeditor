<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8BoostFuelExtended
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.C_BoostfuelActivation = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.L_boostfuelver = New System.Windows.Forms.Label()
        Me.D_BoostFuel = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LED_BOOST = New LxControl.LxLedControl()
        Me.D_duty = New System.Windows.Forms.DataGridView()
        Me.L_solenoid_control = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.C_solenoidcontrol = New System.Windows.Forms.CheckBox()
        Me.D_solenoidcontrol = New System.Windows.Forms.GroupBox()
        Me.C_bleed = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.G_boosttable = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_overboost = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.C_fueladd = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NUD_SensorVoltage1 = New System.Windows.Forms.NumericUpDown()
        Me.C_SensorType = New System.Windows.Forms.ComboBox()
        Me.NUD_SensorPressure1 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NUD_SensorPressure2 = New System.Windows.Forms.NumericUpDown()
        Me.NUD_SensorVoltage2 = New System.Windows.Forms.NumericUpDown()
        Me.B_ApplySensorValues = New System.Windows.Forms.Button()
        Me.C_BoostPressureDisplay = New System.Windows.Forms.ComboBox()
        Me.G_BoostIgnitionRetard = New System.Windows.Forms.GroupBox()
        Me.D_BoostIgnitionRetard = New System.Windows.Forms.DataGridView()
        Me.K8boostfuelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.D_BoostFuel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_BOOST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_duty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.D_solenoidcontrol.SuspendLayout()
        Me.G_boosttable.SuspendLayout()
        CType(Me.NUD_SensorVoltage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_SensorPressure1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_SensorPressure2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_SensorVoltage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.G_BoostIgnitionRetard.SuspendLayout()
        CType(Me.D_BoostIgnitionRetard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.K8boostfuelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C_BoostfuelActivation
        '
        Me.C_BoostfuelActivation.AutoSize = True
        Me.C_BoostfuelActivation.Location = New System.Drawing.Point(131, 10)
        Me.C_BoostfuelActivation.Name = "C_BoostfuelActivation"
        Me.C_BoostfuelActivation.Size = New System.Drawing.Size(75, 17)
        Me.C_BoostfuelActivation.TabIndex = 1
        Me.C_BoostfuelActivation.Text = "Not active"
        Me.C_BoostfuelActivation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Boostfuel activation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(754, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Module  v           ready for testing"
        '
        'L_boostfuelver
        '
        Me.L_boostfuelver.AutoSize = True
        Me.L_boostfuelver.Location = New System.Drawing.Point(805, 30)
        Me.L_boostfuelver.Name = "L_boostfuelver"
        Me.L_boostfuelver.Size = New System.Drawing.Size(25, 13)
        Me.L_boostfuelver.TabIndex = 42
        Me.L_boostfuelver.Text = "000"
        '
        'D_BoostFuel
        '
        Me.D_BoostFuel.AllowUserToAddRows = False
        Me.D_BoostFuel.AllowUserToDeleteRows = False
        Me.D_BoostFuel.BackgroundColor = System.Drawing.SystemColors.Control
        Me.D_BoostFuel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_BoostFuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_BoostFuel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_BoostFuel.Location = New System.Drawing.Point(6, 17)
        Me.D_BoostFuel.Name = "D_BoostFuel"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.D_BoostFuel.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.D_BoostFuel.Size = New System.Drawing.Size(924, 383)
        Me.D_BoostFuel.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(701, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(259, 24)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Gen2 Turbo mapping support"
        '
        'LED_BOOST
        '
        Me.LED_BOOST.BackColor = System.Drawing.Color.Transparent
        Me.LED_BOOST.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_BOOST.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_BOOST.BevelRate = 0.5!
        Me.LED_BOOST.FadedColor = System.Drawing.Color.Transparent
        Me.LED_BOOST.ForeColor = System.Drawing.Color.Black
        Me.LED_BOOST.HighlightOpaque = CType(50, Byte)
        Me.LED_BOOST.Location = New System.Drawing.Point(770, 43)
        Me.LED_BOOST.Name = "LED_BOOST"
        Me.LED_BOOST.Size = New System.Drawing.Size(120, 55)
        Me.LED_BOOST.TabIndex = 73
        Me.LED_BOOST.Text = "-"
        Me.LED_BOOST.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_BOOST.TotalCharCount = 4
        '
        'D_duty
        '
        Me.D_duty.AllowUserToAddRows = False
        Me.D_duty.AllowUserToDeleteRows = False
        Me.D_duty.BackgroundColor = System.Drawing.SystemColors.Control
        Me.D_duty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_duty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_duty.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_duty.Location = New System.Drawing.Point(8, 35)
        Me.D_duty.Name = "D_duty"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.D_duty.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.D_duty.Size = New System.Drawing.Size(622, 125)
        Me.D_duty.TabIndex = 74
        '
        'L_solenoid_control
        '
        Me.L_solenoid_control.AutoSize = True
        Me.L_solenoid_control.Location = New System.Drawing.Point(6, 16)
        Me.L_solenoid_control.Name = "L_solenoid_control"
        Me.L_solenoid_control.Size = New System.Drawing.Size(84, 13)
        Me.L_solenoid_control.TabIndex = 75
        Me.L_solenoid_control.Text = "Solenoid Control"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Solenoid control"
        '
        'C_solenoidcontrol
        '
        Me.C_solenoidcontrol.AutoSize = True
        Me.C_solenoidcontrol.Location = New System.Drawing.Point(131, 26)
        Me.C_solenoidcontrol.Name = "C_solenoidcontrol"
        Me.C_solenoidcontrol.Size = New System.Drawing.Size(75, 17)
        Me.C_solenoidcontrol.TabIndex = 78
        Me.C_solenoidcontrol.Text = "Not active"
        Me.C_solenoidcontrol.UseVisualStyleBackColor = True
        '
        'D_solenoidcontrol
        '
        Me.D_solenoidcontrol.Controls.Add(Me.C_bleed)
        Me.D_solenoidcontrol.Controls.Add(Me.Label5)
        Me.D_solenoidcontrol.Controls.Add(Me.D_duty)
        Me.D_solenoidcontrol.Controls.Add(Me.L_solenoid_control)
        Me.D_solenoidcontrol.Location = New System.Drawing.Point(12, 568)
        Me.D_solenoidcontrol.Name = "D_solenoidcontrol"
        Me.D_solenoidcontrol.Size = New System.Drawing.Size(663, 168)
        Me.D_solenoidcontrol.TabIndex = 80
        Me.D_solenoidcontrol.TabStop = False
        Me.D_solenoidcontrol.Text = "Solenoid control"
        '
        'C_bleed
        '
        Me.C_bleed.AutoSize = True
        Me.C_bleed.Location = New System.Drawing.Point(464, 16)
        Me.C_bleed.Name = "C_bleed"
        Me.C_bleed.Size = New System.Drawing.Size(53, 17)
        Me.C_bleed.TabIndex = 80
        Me.C_bleed.Text = "Bleed"
        Me.C_bleed.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(387, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Solenoid type"
        '
        'G_boosttable
        '
        Me.G_boosttable.Controls.Add(Me.D_BoostFuel)
        Me.G_boosttable.Location = New System.Drawing.Point(7, 81)
        Me.G_boosttable.Name = "G_boosttable"
        Me.G_boosttable.Size = New System.Drawing.Size(942, 406)
        Me.G_boosttable.TabIndex = 81
        Me.G_boosttable.TabStop = False
        Me.G_boosttable.Text = "Fuel% to add per rpm/boost area"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(147, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Overboost limit"
        '
        'T_overboost
        '
        Me.T_overboost.BackColor = System.Drawing.Color.LightGray
        Me.T_overboost.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_overboost.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.T_overboost.Location = New System.Drawing.Point(256, 53)
        Me.T_overboost.Name = "T_overboost"
        Me.T_overboost.ReadOnly = True
        Me.T_overboost.Size = New System.Drawing.Size(48, 29)
        Me.T_overboost.TabIndex = 83
        Me.ToolTip1.SetToolTip(Me.T_overboost, "Sets the hardlimit for fuel and ignitioncut based on boost. Use + and - keys to a" & _
                "djust. Requires shifter module being active.")
        Me.T_overboost.WordWrap = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Fuelling type"
        '
        'C_fueladd
        '
        Me.C_fueladd.AutoSize = True
        Me.C_fueladd.Location = New System.Drawing.Point(131, 43)
        Me.C_fueladd.Name = "C_fueladd"
        Me.C_fueladd.Size = New System.Drawing.Size(116, 17)
        Me.C_fueladd.TabIndex = 85
        Me.C_fueladd.Text = "Adding to fuelpulse"
        Me.C_fueladd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(867, 584)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 22)
        Me.Button1.TabIndex = 86
        Me.Button1.Text = "Help"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NUD_SensorVoltage1
        '
        Me.NUD_SensorVoltage1.DecimalPlaces = 1
        Me.NUD_SensorVoltage1.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUD_SensorVoltage1.Location = New System.Drawing.Point(410, 8)
        Me.NUD_SensorVoltage1.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUD_SensorVoltage1.Name = "NUD_SensorVoltage1"
        Me.NUD_SensorVoltage1.Size = New System.Drawing.Size(46, 20)
        Me.NUD_SensorVoltage1.TabIndex = 87
        '
        'C_SensorType
        '
        Me.C_SensorType.FormattingEnabled = True
        Me.C_SensorType.Items.AddRange(New Object() {"GM 3 Bar", "SSI 5 Bar", "Other"})
        Me.C_SensorType.Location = New System.Drawing.Point(323, 8)
        Me.C_SensorType.Name = "C_SensorType"
        Me.C_SensorType.Size = New System.Drawing.Size(81, 21)
        Me.C_SensorType.TabIndex = 88
        '
        'NUD_SensorPressure1
        '
        Me.NUD_SensorPressure1.DecimalPlaces = 1
        Me.NUD_SensorPressure1.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUD_SensorPressure1.Location = New System.Drawing.Point(483, 8)
        Me.NUD_SensorPressure1.Maximum = New Decimal(New Integer() {800, 0, 0, 0})
        Me.NUD_SensorPressure1.Name = "NUD_SensorPressure1"
        Me.NUD_SensorPressure1.Size = New System.Drawing.Size(56, 20)
        Me.NUD_SensorPressure1.TabIndex = 89
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(459, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "v ="
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(538, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "kPa"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(538, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "kPa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(459, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "v ="
        '
        'NUD_SensorPressure2
        '
        Me.NUD_SensorPressure2.DecimalPlaces = 1
        Me.NUD_SensorPressure2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUD_SensorPressure2.Location = New System.Drawing.Point(483, 37)
        Me.NUD_SensorPressure2.Maximum = New Decimal(New Integer() {800, 0, 0, 0})
        Me.NUD_SensorPressure2.Name = "NUD_SensorPressure2"
        Me.NUD_SensorPressure2.Size = New System.Drawing.Size(56, 20)
        Me.NUD_SensorPressure2.TabIndex = 93
        '
        'NUD_SensorVoltage2
        '
        Me.NUD_SensorVoltage2.DecimalPlaces = 1
        Me.NUD_SensorVoltage2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUD_SensorVoltage2.Location = New System.Drawing.Point(410, 37)
        Me.NUD_SensorVoltage2.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUD_SensorVoltage2.Name = "NUD_SensorVoltage2"
        Me.NUD_SensorVoltage2.Size = New System.Drawing.Size(46, 20)
        Me.NUD_SensorVoltage2.TabIndex = 92
        '
        'B_ApplySensorValues
        '
        Me.B_ApplySensorValues.Location = New System.Drawing.Point(567, 34)
        Me.B_ApplySensorValues.Name = "B_ApplySensorValues"
        Me.B_ApplySensorValues.Size = New System.Drawing.Size(75, 23)
        Me.B_ApplySensorValues.TabIndex = 96
        Me.B_ApplySensorValues.Text = "Apply"
        Me.B_ApplySensorValues.UseVisualStyleBackColor = True
        '
        'C_BoostPressureDisplay
        '
        Me.C_BoostPressureDisplay.FormattingEnabled = True
        Me.C_BoostPressureDisplay.Items.AddRange(New Object() {"PSI", "kPa"})
        Me.C_BoostPressureDisplay.Location = New System.Drawing.Point(256, 8)
        Me.C_BoostPressureDisplay.Name = "C_BoostPressureDisplay"
        Me.C_BoostPressureDisplay.Size = New System.Drawing.Size(60, 21)
        Me.C_BoostPressureDisplay.TabIndex = 97
        '
        'G_BoostIgnitionRetard
        '
        Me.G_BoostIgnitionRetard.Controls.Add(Me.D_BoostIgnitionRetard)
        Me.G_BoostIgnitionRetard.Location = New System.Drawing.Point(6, 489)
        Me.G_BoostIgnitionRetard.Name = "G_BoostIgnitionRetard"
        Me.G_BoostIgnitionRetard.Size = New System.Drawing.Size(943, 61)
        Me.G_BoostIgnitionRetard.TabIndex = 98
        Me.G_BoostIgnitionRetard.TabStop = False
        Me.G_BoostIgnitionRetard.Text = "Boost Ignition Retard"
        '
        'D_BoostIgnitionRetard
        '
        Me.D_BoostIgnitionRetard.AllowUserToAddRows = False
        Me.D_BoostIgnitionRetard.AllowUserToDeleteRows = False
        Me.D_BoostIgnitionRetard.BackgroundColor = System.Drawing.SystemColors.Control
        Me.D_BoostIgnitionRetard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_BoostIgnitionRetard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_BoostIgnitionRetard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_BoostIgnitionRetard.Location = New System.Drawing.Point(7, 16)
        Me.D_BoostIgnitionRetard.Name = "D_BoostIgnitionRetard"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.D_BoostIgnitionRetard.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.D_BoostIgnitionRetard.Size = New System.Drawing.Size(930, 57)
        Me.D_BoostIgnitionRetard.TabIndex = 0
        '
        'K8boostfuelBindingSource
        '
        Me.K8boostfuelBindingSource.DataSource = GetType(ecueditor_25.K8BoostFuelExtended)
        '
        'K8BoostFuelExtended
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 742)
        Me.Controls.Add(Me.G_BoostIgnitionRetard)
        Me.Controls.Add(Me.C_BoostPressureDisplay)
        Me.Controls.Add(Me.B_ApplySensorValues)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.NUD_SensorVoltage2)
        Me.Controls.Add(Me.NUD_SensorPressure2)
        Me.Controls.Add(Me.NUD_SensorPressure1)
        Me.Controls.Add(Me.C_SensorType)
        Me.Controls.Add(Me.NUD_SensorVoltage1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C_fueladd)
        Me.Controls.Add(Me.T_overboost)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.G_boosttable)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.C_solenoidcontrol)
        Me.Controls.Add(Me.D_solenoidcontrol)
        Me.Controls.Add(Me.LED_BOOST)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.L_boostfuelver)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_BoostfuelActivation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8BoostFuelExtended"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa K8- Extended Boostfuel module"
        CType(Me.D_BoostFuel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_BOOST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_duty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.D_solenoidcontrol.ResumeLayout(False)
        Me.D_solenoidcontrol.PerformLayout()
        Me.G_boosttable.ResumeLayout(False)
        CType(Me.NUD_SensorVoltage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_SensorPressure1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_SensorPressure2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_SensorVoltage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.G_BoostIgnitionRetard.ResumeLayout(False)
        CType(Me.D_BoostIgnitionRetard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.K8boostfuelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_BoostfuelActivation As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L_boostfuelver As System.Windows.Forms.Label
    Friend WithEvents D_BoostFuel As System.Windows.Forms.DataGridView
    Friend WithEvents K8boostfuelBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LED_BOOST As LxControl.LxLedControl
    Friend WithEvents L_solenoid_control As System.Windows.Forms.Label
    Friend WithEvents D_duty As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents C_solenoidcontrol As System.Windows.Forms.CheckBox
    Friend WithEvents D_solenoidcontrol As System.Windows.Forms.GroupBox
    Friend WithEvents G_boosttable As System.Windows.Forms.GroupBox
    Friend WithEvents C_bleed As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T_overboost As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents C_fueladd As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NUD_SensorVoltage1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents C_SensorType As System.Windows.Forms.ComboBox
    Friend WithEvents NUD_SensorPressure1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NUD_SensorPressure2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_SensorVoltage2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents B_ApplySensorValues As System.Windows.Forms.Button
    Friend WithEvents C_BoostPressureDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents G_BoostIgnitionRetard As System.Windows.Forms.GroupBox
    Friend WithEvents D_BoostIgnitionRetard As System.Windows.Forms.DataGridView

End Class
