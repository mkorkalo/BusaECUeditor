<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advsettings
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Advsettings))
        Me.B_Close = New System.Windows.Forms.Button
        Me.C_solenoid_on = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Solenoid_TPS = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.C_solenoid_off = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.C_Gearing = New System.Windows.Forms.ComboBox
        Me.IAT_disable = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.C_injectorsize = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.C_Accel = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CLTMin = New System.Windows.Forms.Label
        Me.RPMHigh = New System.Windows.Forms.Label
        Me.RPMLow = New System.Windows.Forms.Label
        Me.TPSHigh = New System.Windows.Forms.Label
        Me.TPSLow = New System.Windows.Forms.Label
        Me.IAPHigh = New System.Windows.Forms.Label
        Me.IAPLow = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.IAP_range = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.C_fuelconsumption = New System.Windows.Forms.ComboBox
        Me.LLL = New System.Windows.Forms.GroupBox
        Me.C_IAPTPSswitchingpoint = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.C_antitheft = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.C_cranking = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.C_yoshbox = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.C_dwell = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.LLL.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.SuspendLayout()
        '
        'B_Close
        '
        Me.B_Close.Location = New System.Drawing.Point(458, 442)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(82, 24)
        Me.B_Close.TabIndex = 0
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'C_solenoid_on
        '
        Me.C_solenoid_on.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_solenoid_on.FormattingEnabled = True
        Me.C_solenoid_on.Location = New System.Drawing.Point(150, 19)
        Me.C_solenoid_on.Name = "C_solenoid_on"
        Me.C_solenoid_on.Size = New System.Drawing.Size(88, 21)
        Me.C_solenoid_on.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Solenoid_TPS)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.C_solenoid_off)
        Me.GroupBox1.Controls.Add(Me.C_solenoid_on)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reprogram IAC to Nitrous or Shift light Control"
        Me.ToolTip1.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        '
        'Solenoid_TPS
        '
        Me.Solenoid_TPS.AutoSize = True
        Me.Solenoid_TPS.Location = New System.Drawing.Point(150, 73)
        Me.Solenoid_TPS.Name = "Solenoid_TPS"
        Me.Solenoid_TPS.Size = New System.Drawing.Size(59, 17)
        Me.Solenoid_TPS.TabIndex = 4
        Me.Solenoid_TPS.Text = "Normal"
        Me.Solenoid_TPS.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Solenoid activation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Solenoid off RPM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Solenoid on RPM"
        '
        'C_solenoid_off
        '
        Me.C_solenoid_off.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_solenoid_off.FormattingEnabled = True
        Me.C_solenoid_off.Location = New System.Drawing.Point(150, 46)
        Me.C_solenoid_off.Name = "C_solenoid_off"
        Me.C_solenoid_off.Size = New System.Drawing.Size(88, 21)
        Me.C_solenoid_off.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.C_Gearing)
        Me.GroupBox2.Controls.Add(Me.IAT_disable)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(277, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(261, 79)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dyno settings"
        Me.ToolTip1.SetToolTip(Me.GroupBox2, resources.GetString("GroupBox2.ToolTip"))
        '
        'C_Gearing
        '
        Me.C_Gearing.DropDownHeight = 120
        Me.C_Gearing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_Gearing.FormattingEnabled = True
        Me.C_Gearing.IntegralHeight = False
        Me.C_Gearing.Location = New System.Drawing.Point(148, 46)
        Me.C_Gearing.Name = "C_Gearing"
        Me.C_Gearing.Size = New System.Drawing.Size(100, 21)
        Me.C_Gearing.TabIndex = 0
        '
        'IAT_disable
        '
        Me.IAT_disable.AutoSize = True
        Me.IAT_disable.Location = New System.Drawing.Point(146, 19)
        Me.IAT_disable.Name = "IAT_disable"
        Me.IAT_disable.Size = New System.Drawing.Size(77, 17)
        Me.IAT_disable.TabIndex = 3
        Me.IAT_disable.Text = "IAT normal"
        Me.IAT_disable.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 13)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Gearing/Dynomode"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "IAT disable for dyno"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.C_injectorsize)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(246, 66)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fuel pressure/injector size compensation"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fuel pressure algorithm not 1:1 to pressure"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(8, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Fuel pressure setting %"
        '
        'C_injectorsize
        '
        Me.C_injectorsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_injectorsize.FormattingEnabled = True
        Me.C_injectorsize.Location = New System.Drawing.Point(150, 19)
        Me.C_injectorsize.Name = "C_injectorsize"
        Me.C_injectorsize.Size = New System.Drawing.Size(90, 21)
        Me.C_injectorsize.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.C_Accel)
        Me.GroupBox4.Location = New System.Drawing.Point(279, 97)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(261, 56)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "TPS/Acceleration enrichment"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Response  %"
        '
        'C_Accel
        '
        Me.C_Accel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_Accel.FormattingEnabled = True
        Me.C_Accel.Location = New System.Drawing.Point(146, 22)
        Me.C_Accel.Name = "C_Accel"
        Me.C_Accel.Size = New System.Drawing.Size(100, 21)
        Me.C_Accel.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CLTMin)
        Me.GroupBox5.Controls.Add(Me.RPMHigh)
        Me.GroupBox5.Controls.Add(Me.RPMLow)
        Me.GroupBox5.Controls.Add(Me.TPSHigh)
        Me.GroupBox5.Controls.Add(Me.TPSLow)
        Me.GroupBox5.Controls.Add(Me.IAPHigh)
        Me.GroupBox5.Controls.Add(Me.IAPLow)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 261)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(246, 63)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Oxy sensor settings"
        '
        'CLTMin
        '
        Me.CLTMin.AutoSize = True
        Me.CLTMin.Location = New System.Drawing.Point(157, 40)
        Me.CLTMin.Name = "CLTMin"
        Me.CLTMin.Size = New System.Drawing.Size(24, 13)
        Me.CLTMin.TabIndex = 10
        Me.CLTMin.Text = "IAP"
        '
        'RPMHigh
        '
        Me.RPMHigh.AutoSize = True
        Me.RPMHigh.Location = New System.Drawing.Point(197, 16)
        Me.RPMHigh.Name = "RPMHigh"
        Me.RPMHigh.Size = New System.Drawing.Size(29, 13)
        Me.RPMHigh.TabIndex = 9
        Me.RPMHigh.Text = "High"
        '
        'RPMLow
        '
        Me.RPMLow.AutoSize = True
        Me.RPMLow.Location = New System.Drawing.Point(157, 16)
        Me.RPMLow.Name = "RPMLow"
        Me.RPMLow.Size = New System.Drawing.Size(27, 13)
        Me.RPMLow.TabIndex = 8
        Me.RPMLow.Text = "Low"
        '
        'TPSHigh
        '
        Me.TPSHigh.AutoSize = True
        Me.TPSHigh.Location = New System.Drawing.Point(71, 40)
        Me.TPSHigh.Name = "TPSHigh"
        Me.TPSHigh.Size = New System.Drawing.Size(29, 13)
        Me.TPSHigh.TabIndex = 7
        Me.TPSHigh.Text = "High"
        '
        'TPSLow
        '
        Me.TPSLow.AutoSize = True
        Me.TPSLow.Location = New System.Drawing.Point(38, 40)
        Me.TPSLow.Name = "TPSLow"
        Me.TPSLow.Size = New System.Drawing.Size(27, 13)
        Me.TPSLow.TabIndex = 6
        Me.TPSLow.Text = "Low"
        '
        'IAPHigh
        '
        Me.IAPHigh.AutoSize = True
        Me.IAPHigh.Location = New System.Drawing.Point(71, 16)
        Me.IAPHigh.Name = "IAPHigh"
        Me.IAPHigh.Size = New System.Drawing.Size(29, 13)
        Me.IAPHigh.TabIndex = 5
        Me.IAPHigh.Text = "High"
        '
        'IAPLow
        '
        Me.IAPLow.AutoSize = True
        Me.IAPLow.Location = New System.Drawing.Point(38, 16)
        Me.IAPLow.Name = "IAPLow"
        Me.IAPLow.Size = New System.Drawing.Size(27, 13)
        Me.IAPLow.TabIndex = 4
        Me.IAPLow.Text = "Low"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(119, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "CLT"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(119, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "RPM"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "TPS"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "IAP"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.IAP_range)
        Me.GroupBox6.Location = New System.Drawing.Point(279, 159)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(261, 43)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "IAP fault tolerance extension for Turbos"
        Me.ToolTip1.SetToolTip(Me.GroupBox6, "IAP sensor may show C22 fault code when Turbo bikes applied with Boost." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This s" & _
                "etting raises the upper voltage limit of IAP sensor and removes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the fault codes" & _
                " caused by boost.")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "IAP sensor range"
        '
        'IAP_range
        '
        Me.IAP_range.AutoSize = True
        Me.IAP_range.Location = New System.Drawing.Point(146, 19)
        Me.IAP_range.Name = "IAP_range"
        Me.IAP_range.Size = New System.Drawing.Size(107, 17)
        Me.IAP_range.TabIndex = 0
        Me.IAP_range.Text = "IAP range normal"
        Me.IAP_range.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.C_fuelconsumption)
        Me.GroupBox7.Location = New System.Drawing.Point(15, 190)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(246, 65)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Fuel consumption gauge compensation"
        Me.ToolTip1.SetToolTip(Me.GroupBox7, "If you have changed the injector size or are running e.g." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "secondary injectors yo" & _
                "u can set the fuel consumption" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "setting here.")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(158, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Algorithm assumed 1:1 to gauge"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.Location = New System.Drawing.Point(8, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Fuel consumption setting %"
        '
        'C_fuelconsumption
        '
        Me.C_fuelconsumption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_fuelconsumption.FormattingEnabled = True
        Me.C_fuelconsumption.Location = New System.Drawing.Point(150, 19)
        Me.C_fuelconsumption.Name = "C_fuelconsumption"
        Me.C_fuelconsumption.Size = New System.Drawing.Size(90, 21)
        Me.C_fuelconsumption.TabIndex = 0
        '
        'LLL
        '
        Me.LLL.Controls.Add(Me.C_IAPTPSswitchingpoint)
        Me.LLL.Controls.Add(Me.Label21)
        Me.LLL.Location = New System.Drawing.Point(279, 209)
        Me.LLL.Name = "LLL"
        Me.LLL.Size = New System.Drawing.Size(261, 54)
        Me.LLL.TabIndex = 8
        Me.LLL.TabStop = False
        Me.LLL.Text = "IAP/TPS switching point"
        Me.ToolTip1.SetToolTip(Me.LLL, resources.GetString("LLL.ToolTip"))
        '
        'C_IAPTPSswitchingpoint
        '
        Me.C_IAPTPSswitchingpoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_IAPTPSswitchingpoint.FormattingEnabled = True
        Me.C_IAPTPSswitchingpoint.Location = New System.Drawing.Point(146, 22)
        Me.C_IAPTPSswitchingpoint.Name = "C_IAPTPSswitchingpoint"
        Me.C_IAPTPSswitchingpoint.Size = New System.Drawing.Size(100, 21)
        Me.C_IAPTPSswitchingpoint.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Switch at TPS%"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.C_antitheft)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Location = New System.Drawing.Point(280, 270)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(260, 34)
        Me.GroupBox8.TabIndex = 9
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Ignition lock compatibility"
        Me.ToolTip1.SetToolTip(Me.GroupBox8, "Set lock compatible if running US ecu in EU bike or vice versa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "if you are gettin" & _
                "g error code C42.")
        '
        'C_antitheft
        '
        Me.C_antitheft.AutoSize = True
        Me.C_antitheft.Location = New System.Drawing.Point(146, 15)
        Me.C_antitheft.Name = "C_antitheft"
        Me.C_antitheft.Size = New System.Drawing.Size(84, 17)
        Me.C_antitheft.TabIndex = 4
        Me.C_antitheft.Text = "Lock normal"
        Me.C_antitheft.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Set lock compatibilty"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.C_cranking)
        Me.GroupBox9.Controls.Add(Me.Label8)
        Me.GroupBox9.Location = New System.Drawing.Point(279, 310)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(261, 39)
        Me.GroupBox9.TabIndex = 10
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Enable big block low rpm cranking"
        Me.ToolTip1.SetToolTip(Me.GroupBox9, "Set Lower RPM to enable 250rpm cranking low limit. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RPM Normal limit is 312rpm w" & _
                "hich may be too high for" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "some big block higher compression engines.")
        '
        'C_cranking
        '
        Me.C_cranking.AutoSize = True
        Me.C_cranking.Location = New System.Drawing.Point(147, 16)
        Me.C_cranking.Name = "C_cranking"
        Me.C_cranking.Size = New System.Drawing.Size(84, 17)
        Me.C_cranking.TabIndex = 5
        Me.C_cranking.Text = "RPM normal"
        Me.C_cranking.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Set cranking RPM"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.C_yoshbox)
        Me.GroupBox10.Controls.Add(Me.Label13)
        Me.GroupBox10.Location = New System.Drawing.Point(15, 330)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(246, 53)
        Me.GroupBox10.TabIndex = 11
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Yoshbox settings"
        '
        'C_yoshbox
        '
        Me.C_yoshbox.AutoSize = True
        Me.C_yoshbox.Location = New System.Drawing.Point(150, 25)
        Me.C_yoshbox.Name = "C_yoshbox"
        Me.C_yoshbox.Size = New System.Drawing.Size(59, 17)
        Me.C_yoshbox.TabIndex = 7
        Me.C_yoshbox.Text = "Normal"
        Me.C_yoshbox.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Yoshbox compensation"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.C_dwell)
        Me.GroupBox11.Controls.Add(Me.Label18)
        Me.GroupBox11.Location = New System.Drawing.Point(15, 389)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(246, 54)
        Me.GroupBox11.TabIndex = 9
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Ignition Dwell"
        Me.ToolTip1.SetToolTip(Me.GroupBox11, resources.GetString("GroupBox11.ToolTip"))
        '
        'C_dwell
        '
        Me.C_dwell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_dwell.FormattingEnabled = True
        Me.C_dwell.Location = New System.Drawing.Point(150, 25)
        Me.C_dwell.Name = "C_dwell"
        Me.C_dwell.Size = New System.Drawing.Size(88, 21)
        Me.C_dwell.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Dwell time %"
        '
        'Advsettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 478)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.LLL)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.B_Close)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Advsettings"
        Me.Text = "ECUeditor Advanced settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.LLL.ResumeLayout(False)
        Me.LLL.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents C_solenoid_on As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C_solenoid_off As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents IAT_disable As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents C_injectorsize As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents C_Accel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CLTMin As System.Windows.Forms.Label
    Friend WithEvents RPMHigh As System.Windows.Forms.Label
    Friend WithEvents RPMLow As System.Windows.Forms.Label
    Friend WithEvents TPSHigh As System.Windows.Forms.Label
    Friend WithEvents TPSLow As System.Windows.Forms.Label
    Friend WithEvents IAPHigh As System.Windows.Forms.Label
    Friend WithEvents IAPLow As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents IAP_range As System.Windows.Forms.CheckBox
    Friend WithEvents Solenoid_TPS As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents C_fuelconsumption As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents C_Gearing As System.Windows.Forms.ComboBox
    Friend WithEvents LLL As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents C_IAPTPSswitchingpoint As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents C_antitheft As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents C_cranking As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents C_yoshbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents C_dwell As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
