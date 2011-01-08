<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8Datastream
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8Datastream))
        Me.ComboBox_Serialport = New System.Windows.Forms.ComboBox
        Me.T_datacomm = New System.Windows.Forms.TextBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.LED_RPM = New LxControl.LxLedControl
        Me.LED_IGN = New LxControl.LxLedControl
        Me.LED_CLT = New LxControl.LxLedControl
        Me.L_CLT = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.LED_TPS = New LxControl.LxLedControl
        Me.LED_IAP = New LxControl.LxLedControl
        Me.B_Clear_DTC = New System.Windows.Forms.Button
        Me.B_Connect_Datastream = New System.Windows.Forms.Button
        Me.L_MS = New System.Windows.Forms.Label
        Me.L_Clutch = New System.Windows.Forms.Label
        Me.L_NT = New System.Windows.Forms.Label
        Me.LED_HO2 = New LxControl.LxLedControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.AquaGauge1 = New AquaControls.AquaGauge
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LED_IAPabs = New LxControl.LxLedControl
        Me.LED_SAPabs = New LxControl.LxLedControl
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LED_IAT = New LxControl.LxLedControl
        Me.L_IAT = New System.Windows.Forms.Label
        Me.LED_FUEL = New LxControl.LxLedControl
        Me.Label10 = New System.Windows.Forms.Label
        Me.LED_BATT = New LxControl.LxLedControl
        Me.LED_GEAR = New LxControl.LxLedControl
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.A_CLT = New AGauge.AGauge
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.L_modeC = New System.Windows.Forms.Label
        Me.L_modeB = New System.Windows.Forms.Label
        Me.L_modeA = New System.Windows.Forms.Label
        Me.L_CLThigh = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.LED_TIME = New LxControl.LxLedControl
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.L_msg = New System.Windows.Forms.Label
        Me.L_PAIR = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.B_Enginedatalog = New System.Windows.Forms.Button
        Me.L_comms = New System.Windows.Forms.Label
        Me.T_2180 = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.pwrpm = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.L_ramair = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.L_seccyl4 = New System.Windows.Forms.Label
        Me.L_seccyl3 = New System.Windows.Forms.Label
        Me.L_seccyl2 = New System.Windows.Forms.Label
        Me.L_seccyl1 = New System.Windows.Forms.Label
        Me.L_pricyl4 = New System.Windows.Forms.Label
        Me.L_pricyl3 = New System.Windows.Forms.Label
        Me.L_pricyl2 = New System.Windows.Forms.Label
        Me.L_pricyl1 = New System.Windows.Forms.Label
        Me.L_Secondaries = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.L_primaries = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.L_basefuel = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.T_21C0 = New System.Windows.Forms.TextBox
        Me.B_stop_engine = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.T_2108 = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.L_STP = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.LED_DUTY = New LxControl.LxLedControl
        Me.L_cov4 = New System.Windows.Forms.Label
        Me.L_cov3 = New System.Windows.Forms.Label
        Me.L_cov2 = New System.Windows.Forms.Label
        Me.L_cov1 = New System.Windows.Forms.Label
        Me.L_covabc = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.L_sec = New System.Windows.Forms.Label
        Me.L_prim = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.L_performanceindex = New System.Windows.Forms.Label
        Me.L_perftext = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.C_debug = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.B_ICS = New System.Windows.Forms.Button
        Me.B_PAIR_ON = New System.Windows.Forms.Button
        Me.B_PAIR_OFF = New System.Windows.Forms.Button
        Me.B_FANOFF = New System.Windows.Forms.Button
        Me.B_FANON = New System.Windows.Forms.Button
        Me.L_ho2raw = New System.Windows.Forms.Label
        CType(Me.LED_RPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_IGN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_CLT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_TPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_IAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_HO2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.LED_IAPabs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_SAPabs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_IAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_FUEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_BATT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_GEAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.LED_TIME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.LED_DUTY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_Serialport
        '
        Me.ComboBox_Serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Serialport.FormattingEnabled = True
        Me.ComboBox_Serialport.Location = New System.Drawing.Point(82, 25)
        Me.ComboBox_Serialport.Name = "ComboBox_Serialport"
        Me.ComboBox_Serialport.Size = New System.Drawing.Size(61, 21)
        Me.ComboBox_Serialport.TabIndex = 22
        '
        'T_datacomm
        '
        Me.T_datacomm.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.T_datacomm.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_datacomm.Location = New System.Drawing.Point(17, 564)
        Me.T_datacomm.Multiline = True
        Me.T_datacomm.Name = "T_datacomm"
        Me.T_datacomm.Size = New System.Drawing.Size(347, 65)
        Me.T_datacomm.TabIndex = 20
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 7812
        Me.SerialPort1.ParityReplace = CType(0, Byte)
        Me.SerialPort1.PortName = "COM4"
        Me.SerialPort1.ReadBufferSize = 32
        Me.SerialPort1.ReadTimeout = 100
        Me.SerialPort1.ReceivedBytesThreshold = 32
        Me.SerialPort1.WriteBufferSize = 32
        Me.SerialPort1.WriteTimeout = 100
        '
        'Timer2
        '
        Me.Timer2.Interval = 150
        '
        'LED_RPM
        '
        Me.LED_RPM.BackColor = System.Drawing.Color.Transparent
        Me.LED_RPM.BackColor_1 = System.Drawing.Color.DimGray
        Me.LED_RPM.BackColor_2 = System.Drawing.Color.Black
        Me.LED_RPM.BevelRate = 0.5!
        Me.LED_RPM.FadedColor = System.Drawing.Color.Transparent
        Me.LED_RPM.ForeColor = System.Drawing.Color.Black
        Me.LED_RPM.HighlightOpaque = CType(50, Byte)
        Me.LED_RPM.Location = New System.Drawing.Point(127, 288)
        Me.LED_RPM.Name = "LED_RPM"
        Me.LED_RPM.Size = New System.Drawing.Size(121, 41)
        Me.LED_RPM.TabIndex = 58
        Me.LED_RPM.Text = "-"
        Me.LED_RPM.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_RPM.TotalCharCount = 6
        '
        'LED_IGN
        '
        Me.LED_IGN.BackColor = System.Drawing.Color.Transparent
        Me.LED_IGN.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_IGN.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_IGN.BevelRate = 0.5!
        Me.LED_IGN.FadedColor = System.Drawing.Color.Transparent
        Me.LED_IGN.ForeColor = System.Drawing.Color.Black
        Me.LED_IGN.HighlightOpaque = CType(50, Byte)
        Me.LED_IGN.Location = New System.Drawing.Point(91, 123)
        Me.LED_IGN.Name = "LED_IGN"
        Me.LED_IGN.Size = New System.Drawing.Size(52, 23)
        Me.LED_IGN.TabIndex = 59
        Me.LED_IGN.Text = "-"
        Me.LED_IGN.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_IGN.TotalCharCount = 4
        '
        'LED_CLT
        '
        Me.LED_CLT.BackColor = System.Drawing.Color.Transparent
        Me.LED_CLT.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_CLT.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_CLT.BevelRate = 0.5!
        Me.LED_CLT.FadedColor = System.Drawing.Color.Transparent
        Me.LED_CLT.ForeColor = System.Drawing.Color.Black
        Me.LED_CLT.HighlightOpaque = CType(50, Byte)
        Me.LED_CLT.Location = New System.Drawing.Point(90, 212)
        Me.LED_CLT.Name = "LED_CLT"
        Me.LED_CLT.Size = New System.Drawing.Size(52, 23)
        Me.LED_CLT.TabIndex = 60
        Me.LED_CLT.Text = "-"
        Me.LED_CLT.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_CLT.TotalCharCount = 4
        '
        'L_CLT
        '
        Me.L_CLT.AutoSize = True
        Me.L_CLT.Location = New System.Drawing.Point(43, 222)
        Me.L_CLT.Name = "L_CLT"
        Me.L_CLT.Size = New System.Drawing.Size(37, 13)
        Me.L_CLT.TabIndex = 61
        Me.L_CLT.Text = "CLT X"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(34, 133)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "IGN deg"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(39, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "IAP diff"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(30, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "FUEL pw"
        '
        'LED_TPS
        '
        Me.LED_TPS.BackColor = System.Drawing.Color.Transparent
        Me.LED_TPS.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_TPS.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_TPS.BevelRate = 0.5!
        Me.LED_TPS.FadedColor = System.Drawing.Color.Transparent
        Me.LED_TPS.ForeColor = System.Drawing.Color.Black
        Me.LED_TPS.HighlightOpaque = CType(50, Byte)
        Me.LED_TPS.Location = New System.Drawing.Point(16, 43)
        Me.LED_TPS.Name = "LED_TPS"
        Me.LED_TPS.Size = New System.Drawing.Size(120, 55)
        Me.LED_TPS.TabIndex = 67
        Me.LED_TPS.Text = "-"
        Me.LED_TPS.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_TPS.TotalCharCount = 4
        '
        'LED_IAP
        '
        Me.LED_IAP.BackColor = System.Drawing.Color.Transparent
        Me.LED_IAP.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_IAP.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_IAP.BevelRate = 0.5!
        Me.LED_IAP.FadedColor = System.Drawing.Color.Transparent
        Me.LED_IAP.ForeColor = System.Drawing.Color.Black
        Me.LED_IAP.HighlightOpaque = CType(50, Byte)
        Me.LED_IAP.Location = New System.Drawing.Point(91, 64)
        Me.LED_IAP.Name = "LED_IAP"
        Me.LED_IAP.Size = New System.Drawing.Size(52, 23)
        Me.LED_IAP.TabIndex = 68
        Me.LED_IAP.Text = "-"
        Me.LED_IAP.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_IAP.TotalCharCount = 4
        '
        'B_Clear_DTC
        '
        Me.B_Clear_DTC.Location = New System.Drawing.Point(291, 488)
        Me.B_Clear_DTC.Name = "B_Clear_DTC"
        Me.B_Clear_DTC.Size = New System.Drawing.Size(86, 28)
        Me.B_Clear_DTC.TabIndex = 78
        Me.B_Clear_DTC.Text = "Clear DTC"
        Me.B_Clear_DTC.UseVisualStyleBackColor = True
        '
        'B_Connect_Datastream
        '
        Me.B_Connect_Datastream.Location = New System.Drawing.Point(81, 54)
        Me.B_Connect_Datastream.Name = "B_Connect_Datastream"
        Me.B_Connect_Datastream.Size = New System.Drawing.Size(61, 27)
        Me.B_Connect_Datastream.TabIndex = 76
        Me.B_Connect_Datastream.Text = "Connect"
        Me.B_Connect_Datastream.UseVisualStyleBackColor = True
        '
        'L_MS
        '
        Me.L_MS.AutoSize = True
        Me.L_MS.Location = New System.Drawing.Point(70, 19)
        Me.L_MS.Name = "L_MS"
        Me.L_MS.Size = New System.Drawing.Size(23, 13)
        Me.L_MS.TabIndex = 80
        Me.L_MS.Text = "MS"
        '
        'L_Clutch
        '
        Me.L_Clutch.AutoSize = True
        Me.L_Clutch.Location = New System.Drawing.Point(13, 40)
        Me.L_Clutch.Name = "L_Clutch"
        Me.L_Clutch.Size = New System.Drawing.Size(37, 13)
        Me.L_Clutch.TabIndex = 81
        Me.L_Clutch.Text = "Clutch"
        '
        'L_NT
        '
        Me.L_NT.AutoSize = True
        Me.L_NT.Location = New System.Drawing.Point(9, 17)
        Me.L_NT.Name = "L_NT"
        Me.L_NT.Size = New System.Drawing.Size(41, 13)
        Me.L_NT.TabIndex = 82
        Me.L_NT.Text = "Neutral"
        '
        'LED_HO2
        '
        Me.LED_HO2.BackColor = System.Drawing.Color.Transparent
        Me.LED_HO2.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_HO2.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_HO2.BevelRate = 0.5!
        Me.LED_HO2.FadedColor = System.Drawing.Color.Transparent
        Me.LED_HO2.ForeColor = System.Drawing.Color.Black
        Me.LED_HO2.HighlightOpaque = CType(50, Byte)
        Me.LED_HO2.Location = New System.Drawing.Point(91, 152)
        Me.LED_HO2.Name = "LED_HO2"
        Me.LED_HO2.Size = New System.Drawing.Size(52, 23)
        Me.LED_HO2.TabIndex = 85
        Me.LED_HO2.Text = "-"
        Me.LED_HO2.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_HO2.TotalCharCount = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "AFR"
        '
        'AquaGauge1
        '
        Me.AquaGauge1.BackColor = System.Drawing.Color.Transparent
        Me.AquaGauge1.DialColor = System.Drawing.Color.Black
        Me.AquaGauge1.DialText = Nothing
        Me.AquaGauge1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.AquaGauge1.Glossiness = 11.36364!
        Me.AquaGauge1.Location = New System.Drawing.Point(5, 4)
        Me.AquaGauge1.MaxValue = 13.0!
        Me.AquaGauge1.MinValue = 0.0!
        Me.AquaGauge1.Name = "AquaGauge1"
        Me.AquaGauge1.NoOfDivisions = 13
        Me.AquaGauge1.NoOfSubDivisions = 1
        Me.AquaGauge1.RecommendedValue = 12.0!
        Me.AquaGauge1.Size = New System.Drawing.Size(357, 357)
        Me.AquaGauge1.TabIndex = 87
        Me.AquaGauge1.ThresholdPercent = 0.0!
        Me.AquaGauge1.Value = 0.0!
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(286, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 22)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "11"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(275, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 22)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "12"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(248, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 22)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "13"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LED_IAPabs)
        Me.GroupBox2.Controls.Add(Me.LED_SAPabs)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.LED_IAT)
        Me.GroupBox2.Controls.Add(Me.L_IAT)
        Me.GroupBox2.Controls.Add(Me.LED_FUEL)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.LED_BATT)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LED_HO2)
        Me.GroupBox2.Controls.Add(Me.LED_IAP)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.L_CLT)
        Me.GroupBox2.Controls.Add(Me.LED_CLT)
        Me.GroupBox2.Controls.Add(Me.LED_IGN)
        Me.GroupBox2.Location = New System.Drawing.Point(570, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 273)
        Me.GroupBox2.TabIndex = 97
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Engine data values"
        '
        'LED_IAPabs
        '
        Me.LED_IAPabs.BackColor = System.Drawing.Color.Transparent
        Me.LED_IAPabs.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_IAPabs.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_IAPabs.BevelRate = 0.5!
        Me.LED_IAPabs.FadedColor = System.Drawing.Color.Transparent
        Me.LED_IAPabs.ForeColor = System.Drawing.Color.Black
        Me.LED_IAPabs.HighlightOpaque = CType(50, Byte)
        Me.LED_IAPabs.Location = New System.Drawing.Point(91, 36)
        Me.LED_IAPabs.Name = "LED_IAPabs"
        Me.LED_IAPabs.Size = New System.Drawing.Size(52, 23)
        Me.LED_IAPabs.TabIndex = 97
        Me.LED_IAPabs.Text = "-"
        Me.LED_IAPabs.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_IAPabs.TotalCharCount = 4
        '
        'LED_SAPabs
        '
        Me.LED_SAPabs.BackColor = System.Drawing.Color.Transparent
        Me.LED_SAPabs.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_SAPabs.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_SAPabs.BevelRate = 0.5!
        Me.LED_SAPabs.FadedColor = System.Drawing.Color.Transparent
        Me.LED_SAPabs.ForeColor = System.Drawing.Color.Black
        Me.LED_SAPabs.HighlightOpaque = CType(50, Byte)
        Me.LED_SAPabs.Location = New System.Drawing.Point(90, 11)
        Me.LED_SAPabs.Name = "LED_SAPabs"
        Me.LED_SAPabs.Size = New System.Drawing.Size(52, 23)
        Me.LED_SAPabs.TabIndex = 96
        Me.LED_SAPabs.Text = "-"
        Me.LED_SAPabs.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_SAPabs.TotalCharCount = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(33, 46)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "IAP kPa"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "SAP kPa"
        '
        'LED_IAT
        '
        Me.LED_IAT.BackColor = System.Drawing.Color.Transparent
        Me.LED_IAT.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_IAT.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_IAT.BevelRate = 0.5!
        Me.LED_IAT.FadedColor = System.Drawing.Color.Transparent
        Me.LED_IAT.ForeColor = System.Drawing.Color.Black
        Me.LED_IAT.HighlightOpaque = CType(50, Byte)
        Me.LED_IAT.Location = New System.Drawing.Point(91, 241)
        Me.LED_IAT.Name = "LED_IAT"
        Me.LED_IAT.Size = New System.Drawing.Size(52, 23)
        Me.LED_IAT.TabIndex = 93
        Me.LED_IAT.Text = "-"
        Me.LED_IAT.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_IAT.TotalCharCount = 4
        '
        'L_IAT
        '
        Me.L_IAT.AutoSize = True
        Me.L_IAT.Location = New System.Drawing.Point(45, 251)
        Me.L_IAT.Name = "L_IAT"
        Me.L_IAT.Size = New System.Drawing.Size(34, 13)
        Me.L_IAT.TabIndex = 92
        Me.L_IAT.Text = "IAT X"
        '
        'LED_FUEL
        '
        Me.LED_FUEL.BackColor = System.Drawing.Color.Transparent
        Me.LED_FUEL.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_FUEL.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_FUEL.BevelRate = 0.5!
        Me.LED_FUEL.FadedColor = System.Drawing.Color.Transparent
        Me.LED_FUEL.ForeColor = System.Drawing.Color.Black
        Me.LED_FUEL.HighlightOpaque = CType(50, Byte)
        Me.LED_FUEL.Location = New System.Drawing.Point(91, 94)
        Me.LED_FUEL.Name = "LED_FUEL"
        Me.LED_FUEL.Size = New System.Drawing.Size(52, 23)
        Me.LED_FUEL.TabIndex = 91
        Me.LED_FUEL.Text = "-"
        Me.LED_FUEL.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_FUEL.TotalCharCount = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "INJ Volt"
        '
        'LED_BATT
        '
        Me.LED_BATT.BackColor = System.Drawing.Color.Transparent
        Me.LED_BATT.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_BATT.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_BATT.BevelRate = 0.5!
        Me.LED_BATT.FadedColor = System.Drawing.Color.Transparent
        Me.LED_BATT.ForeColor = System.Drawing.Color.Black
        Me.LED_BATT.HighlightOpaque = CType(50, Byte)
        Me.LED_BATT.Location = New System.Drawing.Point(91, 183)
        Me.LED_BATT.Name = "LED_BATT"
        Me.LED_BATT.Size = New System.Drawing.Size(52, 23)
        Me.LED_BATT.TabIndex = 87
        Me.LED_BATT.Text = "-"
        Me.LED_BATT.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_BATT.TotalCharCount = 4
        '
        'LED_GEAR
        '
        Me.LED_GEAR.BackColor = System.Drawing.Color.Transparent
        Me.LED_GEAR.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_GEAR.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_GEAR.BevelRate = 0.5!
        Me.LED_GEAR.FadedColor = System.Drawing.Color.Transparent
        Me.LED_GEAR.ForeColor = System.Drawing.Color.Black
        Me.LED_GEAR.HighlightOpaque = CType(50, Byte)
        Me.LED_GEAR.Location = New System.Drawing.Point(53, 302)
        Me.LED_GEAR.Name = "LED_GEAR"
        Me.LED_GEAR.Size = New System.Drawing.Size(49, 42)
        Me.LED_GEAR.TabIndex = 91
        Me.LED_GEAR.Text = "E"
        Me.LED_GEAR.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_GEAR.TotalCharCount = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(99, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 73)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = ")"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(19, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 73)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "("
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(13, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Gear"
        '
        'A_CLT
        '
        Me.A_CLT.BackColor = System.Drawing.Color.Silver
        Me.A_CLT.BaseArcColor = System.Drawing.Color.Gray
        Me.A_CLT.BaseArcRadius = 70
        Me.A_CLT.BaseArcStart = 140
        Me.A_CLT.BaseArcSweep = 70
        Me.A_CLT.BaseArcWidth = 3
        Me.A_CLT.Cap_Idx = CType(1, Byte)
        Me.A_CLT.CapColors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black}
        Me.A_CLT.CapPosition = New System.Drawing.Point(10, 10)
        Me.A_CLT.CapsPosition = New System.Drawing.Point() {New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10), New System.Drawing.Point(10, 10)}
        Me.A_CLT.CapsText = New String() {"", "", "", "", ""}
        Me.A_CLT.CapText = ""
        Me.A_CLT.Center = New System.Drawing.Point(100, 100)
        Me.A_CLT.Location = New System.Drawing.Point(8, 88)
        Me.A_CLT.MaxValue = 120.0!
        Me.A_CLT.MinValue = 75.0!
        Me.A_CLT.Name = "A_CLT"
        Me.A_CLT.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Red
        Me.A_CLT.NeedleColor2 = System.Drawing.Color.Black
        Me.A_CLT.NeedleRadius = 65
        Me.A_CLT.NeedleType = 0
        Me.A_CLT.NeedleWidth = 2
        Me.A_CLT.Range_Idx = CType(0, Byte)
        Me.A_CLT.RangeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.A_CLT.RangeEnabled = True
        Me.A_CLT.RangeEndValue = 122.0!
        Me.A_CLT.RangeInnerRadius = 60
        Me.A_CLT.RangeOuterRadius = 70
        Me.A_CLT.RangesColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.Control}
        Me.A_CLT.RangesEnabled = New Boolean() {True, True, False, False, False}
        Me.A_CLT.RangesEndValue = New Single() {122.0!, 400.0!, 0.0!, 0.0!, 0.0!}
        Me.A_CLT.RangesInnerRadius = New Integer() {60, 70, 70, 70, 70}
        Me.A_CLT.RangesOuterRadius = New Integer() {70, 80, 80, 80, 80}
        Me.A_CLT.RangesStartValue = New Single() {110.0!, 300.0!, 0.0!, 0.0!, 0.0!}
        Me.A_CLT.RangeStartValue = 110.0!
        Me.A_CLT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.A_CLT.ScaleLinesInterColor = System.Drawing.Color.Black
        Me.A_CLT.ScaleLinesInterInnerRadius = 56
        Me.A_CLT.ScaleLinesInterOuterRadius = 60
        Me.A_CLT.ScaleLinesInterWidth = 1
        Me.A_CLT.ScaleLinesMajorColor = System.Drawing.Color.Transparent
        Me.A_CLT.ScaleLinesMajorInnerRadius = 50
        Me.A_CLT.ScaleLinesMajorOuterRadius = 80
        Me.A_CLT.ScaleLinesMajorStepValue = 115.0!
        Me.A_CLT.ScaleLinesMajorWidth = 1
        Me.A_CLT.ScaleLinesMinorColor = System.Drawing.Color.Transparent
        Me.A_CLT.ScaleLinesMinorInnerRadius = 75
        Me.A_CLT.ScaleLinesMinorNumOf = 32
        Me.A_CLT.ScaleLinesMinorOuterRadius = 56
        Me.A_CLT.ScaleLinesMinorWidth = 1
        Me.A_CLT.ScaleNumbersColor = System.Drawing.Color.Transparent
        Me.A_CLT.ScaleNumbersFormat = Nothing
        Me.A_CLT.ScaleNumbersRadius = 90
        Me.A_CLT.ScaleNumbersRotation = 1
        Me.A_CLT.ScaleNumbersStartScaleLine = 0
        Me.A_CLT.ScaleNumbersStepScaleLines = 1
        Me.A_CLT.Size = New System.Drawing.Size(146, 157)
        Me.A_CLT.TabIndex = 93
        Me.A_CLT.Text = "AGauge1"
        Me.A_CLT.Value = 100.0!
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(50, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 20)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "H"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(51, 225)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 20)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "C"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.L_modeC)
        Me.GroupBox4.Controls.Add(Me.L_modeB)
        Me.GroupBox4.Controls.Add(Me.L_modeA)
        Me.GroupBox4.Controls.Add(Me.L_CLThigh)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.LED_TPS)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.LED_GEAR)
        Me.GroupBox4.Controls.Add(Me.LED_TIME)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.A_CLT)
        Me.GroupBox4.Location = New System.Drawing.Point(396, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 381)
        Me.GroupBox4.TabIndex = 99
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Gauges"
        '
        'L_modeC
        '
        Me.L_modeC.AutoSize = True
        Me.L_modeC.BackColor = System.Drawing.Color.Transparent
        Me.L_modeC.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_modeC.ForeColor = System.Drawing.Color.DimGray
        Me.L_modeC.Location = New System.Drawing.Point(130, 328)
        Me.L_modeC.Name = "L_modeC"
        Me.L_modeC.Size = New System.Drawing.Size(24, 25)
        Me.L_modeC.TabIndex = 104
        Me.L_modeC.Text = "C"
        Me.L_modeC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'L_modeB
        '
        Me.L_modeB.AutoSize = True
        Me.L_modeB.BackColor = System.Drawing.Color.Transparent
        Me.L_modeB.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_modeB.ForeColor = System.Drawing.Color.DimGray
        Me.L_modeB.Location = New System.Drawing.Point(130, 309)
        Me.L_modeB.Name = "L_modeB"
        Me.L_modeB.Size = New System.Drawing.Size(24, 25)
        Me.L_modeB.TabIndex = 103
        Me.L_modeB.Text = "B"
        Me.L_modeB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'L_modeA
        '
        Me.L_modeA.AutoSize = True
        Me.L_modeA.BackColor = System.Drawing.Color.Transparent
        Me.L_modeA.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_modeA.ForeColor = System.Drawing.Color.DimGray
        Me.L_modeA.Location = New System.Drawing.Point(130, 288)
        Me.L_modeA.Name = "L_modeA"
        Me.L_modeA.Size = New System.Drawing.Size(25, 25)
        Me.L_modeA.TabIndex = 102
        Me.L_modeA.Text = "A"
        Me.L_modeA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'L_CLThigh
        '
        Me.L_CLThigh.AutoSize = True
        Me.L_CLThigh.Font = New System.Drawing.Font("Wingdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.L_CLThigh.ForeColor = System.Drawing.Color.Firebrick
        Me.L_CLThigh.Location = New System.Drawing.Point(97, 218)
        Me.L_CLThigh.Name = "L_CLThigh"
        Me.L_CLThigh.Size = New System.Drawing.Size(26, 23)
        Me.L_CLThigh.TabIndex = 101
        Me.L_CLThigh.Text = "l"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(13, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 100
        Me.Label14.Text = "TPS%"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Gray
        Me.Label17.Location = New System.Drawing.Point(13, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Temperature"
        '
        'LED_TIME
        '
        Me.LED_TIME.BackColor = System.Drawing.Color.Transparent
        Me.LED_TIME.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_TIME.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_TIME.BevelRate = 0.5!
        Me.LED_TIME.FadedColor = System.Drawing.Color.Transparent
        Me.LED_TIME.ForeColor = System.Drawing.Color.Black
        Me.LED_TIME.HighlightOpaque = CType(50, Byte)
        Me.LED_TIME.Location = New System.Drawing.Point(54, 274)
        Me.LED_TIME.Name = "LED_TIME"
        Me.LED_TIME.Size = New System.Drawing.Size(56, 22)
        Me.LED_TIME.TabIndex = 98
        Me.LED_TIME.Text = "00 00"
        Me.LED_TIME.TextAlignment = LxControl.LxLedControl.Alignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.LED_RPM)
        Me.GroupBox5.Controls.Add(Me.AquaGauge1)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(365, 381)
        Me.GroupBox5.TabIndex = 100
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Rpm"
        '
        'ListBox1
        '
        Me.ListBox1.AllowDrop = True
        Me.ListBox1.BackColor = System.Drawing.Color.Silver
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(4, 15)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListBox1.Size = New System.Drawing.Size(317, 80)
        Me.ListBox1.TabIndex = 103
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.L_msg)
        Me.GroupBox6.Controls.Add(Me.ListBox1)
        Me.GroupBox6.Location = New System.Drawing.Point(396, 395)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(327, 121)
        Me.GroupBox6.TabIndex = 101
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Active FI / DTC Errorcodes and Tuning aid messages"
        '
        'L_msg
        '
        Me.L_msg.AutoSize = True
        Me.L_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_msg.Location = New System.Drawing.Point(5, 98)
        Me.L_msg.Name = "L_msg"
        Me.L_msg.Size = New System.Drawing.Size(34, 16)
        Me.L_msg.TabIndex = 106
        Me.L_msg.Text = "Msg"
        '
        'L_PAIR
        '
        Me.L_PAIR.AutoSize = True
        Me.L_PAIR.Location = New System.Drawing.Point(70, 40)
        Me.L_PAIR.Name = "L_PAIR"
        Me.L_PAIR.Size = New System.Drawing.Size(25, 13)
        Me.L_PAIR.TabIndex = 104
        Me.L_PAIR.Text = "Pair"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.B_Enginedatalog)
        Me.GroupBox1.Controls.Add(Me.L_comms)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Serialport)
        Me.GroupBox1.Controls.Add(Me.B_Connect_Datastream)
        Me.GroupBox1.Location = New System.Drawing.Point(570, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 99)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Communication"
        '
        'B_Enginedatalog
        '
        Me.B_Enginedatalog.Location = New System.Drawing.Point(14, 54)
        Me.B_Enginedatalog.Name = "B_Enginedatalog"
        Me.B_Enginedatalog.Size = New System.Drawing.Size(61, 27)
        Me.B_Enginedatalog.TabIndex = 106
        Me.B_Enginedatalog.Text = "Log a run"
        Me.B_Enginedatalog.UseVisualStyleBackColor = True
        '
        'L_comms
        '
        Me.L_comms.AutoSize = True
        Me.L_comms.Font = New System.Drawing.Font("Wingdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.L_comms.ForeColor = System.Drawing.Color.Firebrick
        Me.L_comms.Location = New System.Drawing.Point(29, 25)
        Me.L_comms.Name = "L_comms"
        Me.L_comms.Size = New System.Drawing.Size(26, 23)
        Me.L_comms.TabIndex = 102
        Me.L_comms.Text = "l"
        '
        'T_2180
        '
        Me.T_2180.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.T_2180.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_2180.Location = New System.Drawing.Point(376, 635)
        Me.T_2180.Multiline = True
        Me.T_2180.Name = "T_2180"
        Me.T_2180.Size = New System.Drawing.Size(347, 127)
        Me.T_2180.TabIndex = 109
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pwrpm)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.L_ramair)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.L_seccyl4)
        Me.GroupBox3.Controls.Add(Me.L_seccyl3)
        Me.GroupBox3.Controls.Add(Me.L_seccyl2)
        Me.GroupBox3.Controls.Add(Me.L_seccyl1)
        Me.GroupBox3.Controls.Add(Me.L_pricyl4)
        Me.GroupBox3.Controls.Add(Me.L_pricyl3)
        Me.GroupBox3.Controls.Add(Me.L_pricyl2)
        Me.GroupBox3.Controls.Add(Me.L_pricyl1)
        Me.GroupBox3.Controls.Add(Me.L_Secondaries)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.L_primaries)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.L_basefuel)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Location = New System.Drawing.Point(745, 396)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(323, 120)
        Me.GroupBox3.TabIndex = 110
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ECU info - only for desktop testing (not valid info for tuning)"
        '
        'pwrpm
        '
        Me.pwrpm.AutoSize = True
        Me.pwrpm.Location = New System.Drawing.Point(87, 70)
        Me.pwrpm.Name = "pwrpm"
        Me.pwrpm.Size = New System.Drawing.Size(43, 13)
        Me.pwrpm.TabIndex = 18
        Me.pwrpm.Text = "pw/rpm"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 13)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "pw/rpm"
        '
        'L_ramair
        '
        Me.L_ramair.AutoSize = True
        Me.L_ramair.Location = New System.Drawing.Point(87, 92)
        Me.L_ramair.Name = "L_ramair"
        Me.L_ramair.Size = New System.Drawing.Size(29, 13)
        Me.L_ramair.TabIndex = 16
        Me.L_ramair.Text = "Ram"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Ramair"
        '
        'L_seccyl4
        '
        Me.L_seccyl4.AutoSize = True
        Me.L_seccyl4.Location = New System.Drawing.Point(196, 39)
        Me.L_seccyl4.Name = "L_seccyl4"
        Me.L_seccyl4.Size = New System.Drawing.Size(21, 13)
        Me.L_seccyl4.TabIndex = 13
        Me.L_seccyl4.Text = "Cyl"
        '
        'L_seccyl3
        '
        Me.L_seccyl3.AutoSize = True
        Me.L_seccyl3.Location = New System.Drawing.Point(169, 39)
        Me.L_seccyl3.Name = "L_seccyl3"
        Me.L_seccyl3.Size = New System.Drawing.Size(21, 13)
        Me.L_seccyl3.TabIndex = 12
        Me.L_seccyl3.Text = "Cyl"
        '
        'L_seccyl2
        '
        Me.L_seccyl2.AutoSize = True
        Me.L_seccyl2.Location = New System.Drawing.Point(142, 39)
        Me.L_seccyl2.Name = "L_seccyl2"
        Me.L_seccyl2.Size = New System.Drawing.Size(21, 13)
        Me.L_seccyl2.TabIndex = 11
        Me.L_seccyl2.Text = "Cyl"
        '
        'L_seccyl1
        '
        Me.L_seccyl1.AutoSize = True
        Me.L_seccyl1.Location = New System.Drawing.Point(115, 39)
        Me.L_seccyl1.Name = "L_seccyl1"
        Me.L_seccyl1.Size = New System.Drawing.Size(21, 13)
        Me.L_seccyl1.TabIndex = 10
        Me.L_seccyl1.Text = "Cyl"
        '
        'L_pricyl4
        '
        Me.L_pricyl4.AutoSize = True
        Me.L_pricyl4.Location = New System.Drawing.Point(196, 16)
        Me.L_pricyl4.Name = "L_pricyl4"
        Me.L_pricyl4.Size = New System.Drawing.Size(21, 13)
        Me.L_pricyl4.TabIndex = 9
        Me.L_pricyl4.Text = "Cyl"
        '
        'L_pricyl3
        '
        Me.L_pricyl3.AutoSize = True
        Me.L_pricyl3.Location = New System.Drawing.Point(169, 16)
        Me.L_pricyl3.Name = "L_pricyl3"
        Me.L_pricyl3.Size = New System.Drawing.Size(21, 13)
        Me.L_pricyl3.TabIndex = 8
        Me.L_pricyl3.Text = "Cyl"
        '
        'L_pricyl2
        '
        Me.L_pricyl2.AutoSize = True
        Me.L_pricyl2.Location = New System.Drawing.Point(142, 16)
        Me.L_pricyl2.Name = "L_pricyl2"
        Me.L_pricyl2.Size = New System.Drawing.Size(21, 13)
        Me.L_pricyl2.TabIndex = 7
        Me.L_pricyl2.Text = "Cyl"
        '
        'L_pricyl1
        '
        Me.L_pricyl1.AutoSize = True
        Me.L_pricyl1.Location = New System.Drawing.Point(115, 16)
        Me.L_pricyl1.Name = "L_pricyl1"
        Me.L_pricyl1.Size = New System.Drawing.Size(21, 13)
        Me.L_pricyl1.TabIndex = 6
        Me.L_pricyl1.Text = "Cyl"
        '
        'L_Secondaries
        '
        Me.L_Secondaries.AutoSize = True
        Me.L_Secondaries.Location = New System.Drawing.Point(78, 39)
        Me.L_Secondaries.Name = "L_Secondaries"
        Me.L_Secondaries.Size = New System.Drawing.Size(26, 13)
        Me.L_Secondaries.TabIndex = 5
        Me.L_Secondaries.Text = "Sec"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 39)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Secondaries"
        '
        'L_primaries
        '
        Me.L_primaries.AutoSize = True
        Me.L_primaries.Location = New System.Drawing.Point(78, 16)
        Me.L_primaries.Name = "L_primaries"
        Me.L_primaries.Size = New System.Drawing.Size(19, 13)
        Me.L_primaries.TabIndex = 3
        Me.L_primaries.Text = "Pri"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Primaries"
        '
        'L_basefuel
        '
        Me.L_basefuel.AutoSize = True
        Me.L_basefuel.Location = New System.Drawing.Point(205, 92)
        Me.L_basefuel.Name = "L_basefuel"
        Me.L_basefuel.Size = New System.Drawing.Size(25, 13)
        Me.L_basefuel.TabIndex = 1
        Me.L_basefuel.Text = "Bas"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(142, 92)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Basefuel"
        '
        'T_21C0
        '
        Me.T_21C0.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.T_21C0.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_21C0.Location = New System.Drawing.Point(17, 635)
        Me.T_21C0.Multiline = True
        Me.T_21C0.Name = "T_21C0"
        Me.T_21C0.Size = New System.Drawing.Size(347, 127)
        Me.T_21C0.TabIndex = 111
         '
        'B_stop_engine
        '
        Me.B_stop_engine.Location = New System.Drawing.Point(12, 488)
        Me.B_stop_engine.Name = "B_stop_engine"
        Me.B_stop_engine.Size = New System.Drawing.Size(157, 28)
        Me.B_stop_engine.TabIndex = 112
        Me.B_stop_engine.Text = "Stop Engine / Reset comms"
        Me.B_stop_engine.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(21, 532)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 113
        '
        'T_2108
        '
        Me.T_2108.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.T_2108.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_2108.Location = New System.Drawing.Point(376, 564)
        Me.T_2108.Multiline = True
        Me.T_2108.Name = "T_2108"
        Me.T_2108.Size = New System.Drawing.Size(347, 65)
        Me.T_2108.TabIndex = 114
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.L_STP)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Controls.Add(Me.Label32)
        Me.GroupBox7.Controls.Add(Me.LED_DUTY)
        Me.GroupBox7.Controls.Add(Me.L_PAIR)
        Me.GroupBox7.Controls.Add(Me.L_NT)
        Me.GroupBox7.Controls.Add(Me.L_MS)
        Me.GroupBox7.Controls.Add(Me.L_Clutch)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 395)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(367, 87)
        Me.GroupBox7.TabIndex = 115
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Misc information"
        '
        'L_STP
        '
        Me.L_STP.AutoSize = True
        Me.L_STP.Location = New System.Drawing.Point(70, 61)
        Me.L_STP.Name = "L_STP"
        Me.L_STP.Size = New System.Drawing.Size(36, 13)
        Me.L_STP.TabIndex = 107
        Me.L_STP.Text = "STP%"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(13, 61)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(28, 13)
        Me.Label33.TabIndex = 106
        Me.Label33.Text = "STP"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Gray
        Me.Label32.Location = New System.Drawing.Point(238, 17)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(34, 13)
        Me.Label32.TabIndex = 105
        Me.Label32.Text = "Inj %"
        '
        'LED_DUTY
        '
        Me.LED_DUTY.BackColor = System.Drawing.Color.Transparent
        Me.LED_DUTY.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_DUTY.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_DUTY.BevelRate = 0.5!
        Me.LED_DUTY.FadedColor = System.Drawing.Color.Transparent
        Me.LED_DUTY.ForeColor = System.Drawing.Color.Black
        Me.LED_DUTY.HighlightOpaque = CType(50, Byte)
        Me.LED_DUTY.Location = New System.Drawing.Point(241, 19)
        Me.LED_DUTY.Name = "LED_DUTY"
        Me.LED_DUTY.Size = New System.Drawing.Size(109, 55)
        Me.LED_DUTY.TabIndex = 105
        Me.LED_DUTY.Text = "-"
        Me.LED_DUTY.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_DUTY.TotalCharCount = 4
        '
        'L_cov4
        '
        Me.L_cov4.AutoSize = True
        Me.L_cov4.Location = New System.Drawing.Point(275, 811)
        Me.L_cov4.Name = "L_cov4"
        Me.L_cov4.Size = New System.Drawing.Size(24, 13)
        Me.L_cov4.TabIndex = 111
        Me.L_cov4.Text = "n/a"
        '
        'L_cov3
        '
        Me.L_cov3.AutoSize = True
        Me.L_cov3.Location = New System.Drawing.Point(275, 798)
        Me.L_cov3.Name = "L_cov3"
        Me.L_cov3.Size = New System.Drawing.Size(24, 13)
        Me.L_cov3.TabIndex = 110
        Me.L_cov3.Text = "n/a"
        '
        'L_cov2
        '
        Me.L_cov2.AutoSize = True
        Me.L_cov2.Location = New System.Drawing.Point(275, 785)
        Me.L_cov2.Name = "L_cov2"
        Me.L_cov2.Size = New System.Drawing.Size(24, 13)
        Me.L_cov2.TabIndex = 109
        Me.L_cov2.Text = "n/a"
        '
        'L_cov1
        '
        Me.L_cov1.AutoSize = True
        Me.L_cov1.Location = New System.Drawing.Point(275, 772)
        Me.L_cov1.Name = "L_cov1"
        Me.L_cov1.Size = New System.Drawing.Size(24, 13)
        Me.L_cov1.TabIndex = 108
        Me.L_cov1.Text = "n/a"
        '
        'L_covabc
        '
        Me.L_covabc.AutoSize = True
        Me.L_covabc.Location = New System.Drawing.Point(193, 772)
        Me.L_covabc.Name = "L_covabc"
        Me.L_covabc.Size = New System.Drawing.Size(24, 13)
        Me.L_covabc.TabIndex = 107
        Me.L_covabc.Text = "n/a"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(223, 811)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 13)
        Me.Label30.TabIndex = 106
        Me.Label30.Text = "COV cyl4"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(223, 798)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 13)
        Me.Label29.TabIndex = 105
        Me.Label29.Text = "COV cyl3"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(223, 785)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(51, 13)
        Me.Label28.TabIndex = 104
        Me.Label28.Text = "COV cyl2"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(223, 772)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 13)
        Me.Label27.TabIndex = 103
        Me.Label27.Text = "COV cyl1"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(136, 772)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 102
        Me.Label26.Text = "COV ABC"
        '
        'L_sec
        '
        Me.L_sec.AutoSize = True
        Me.L_sec.Location = New System.Drawing.Point(79, 785)
        Me.L_sec.Name = "L_sec"
        Me.L_sec.Size = New System.Drawing.Size(24, 13)
        Me.L_sec.TabIndex = 101
        Me.L_sec.Text = "n/a"
        '
        'L_prim
        '
        Me.L_prim.AutoSize = True
        Me.L_prim.Location = New System.Drawing.Point(79, 772)
        Me.L_prim.Name = "L_prim"
        Me.L_prim.Size = New System.Drawing.Size(24, 13)
        Me.L_prim.TabIndex = 100
        Me.L_prim.Text = "n/a"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(36, 785)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 13)
        Me.Label25.TabIndex = 99
        Me.Label25.Text = "Sec %"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(35, 772)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 13)
        Me.Label24.TabIndex = 98
        Me.Label24.Text = "Prim %"
        '
        'L_performanceindex
        '
        Me.L_performanceindex.AutoSize = True
        Me.L_performanceindex.Location = New System.Drawing.Point(658, 519)
        Me.L_performanceindex.Name = "L_performanceindex"
        Me.L_performanceindex.Size = New System.Drawing.Size(24, 13)
        Me.L_performanceindex.TabIndex = 112
        Me.L_performanceindex.Text = "n/a"
        Me.L_performanceindex.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'L_perftext
        '
        Me.L_perftext.AutoSize = True
        Me.L_perftext.Location = New System.Drawing.Point(685, 519)
        Me.L_perftext.Name = "L_perftext"
        Me.L_perftext.Size = New System.Drawing.Size(38, 13)
        Me.L_perftext.TabIndex = 112
        Me.L_perftext.Text = "100ms"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(678, 519)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(12, 13)
        Me.Label31.TabIndex = 116
        Me.Label31.Text = "/"
        '
        'C_debug
        '
        Me.C_debug.Location = New System.Drawing.Point(173, 488)
        Me.C_debug.Name = "C_debug"
        Me.C_debug.Size = New System.Drawing.Size(112, 28)
        Me.C_debug.TabIndex = 117
        Me.C_debug.Text = "Debug mode"
        Me.ToolTip1.SetToolTip(Me.C_debug, "Toggle error code checking at high rpm on of. Normally error codes are read only " & _
                "rpm < 2000")
        Me.C_debug.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'B_ICS
        '
        Me.B_ICS.Location = New System.Drawing.Point(291, 520)
        Me.B_ICS.Name = "B_ICS"
        Me.B_ICS.Size = New System.Drawing.Size(86, 22)
        Me.B_ICS.TabIndex = 121
        Me.B_ICS.Text = "Reset ICS"
        Me.ToolTip1.SetToolTip(Me.B_ICS, resources.GetString("B_ICS.ToolTip"))
        Me.B_ICS.UseVisualStyleBackColor = True
        '
        'B_PAIR_ON
        '
        Me.B_PAIR_ON.Location = New System.Drawing.Point(12, 519)
        Me.B_PAIR_ON.Name = "B_PAIR_ON"
        Me.B_PAIR_ON.Size = New System.Drawing.Size(61, 23)
        Me.B_PAIR_ON.TabIndex = 119
        Me.B_PAIR_ON.Text = "Pair ON"
        Me.ToolTip1.SetToolTip(Me.B_PAIR_ON, "Turns pair on")
        Me.B_PAIR_ON.UseVisualStyleBackColor = True
        '
        'B_PAIR_OFF
        '
        Me.B_PAIR_OFF.Location = New System.Drawing.Point(69, 519)
        Me.B_PAIR_OFF.Name = "B_PAIR_OFF"
        Me.B_PAIR_OFF.Size = New System.Drawing.Size(60, 23)
        Me.B_PAIR_OFF.TabIndex = 120
        Me.B_PAIR_OFF.Text = "Pair OFF"
        Me.ToolTip1.SetToolTip(Me.B_PAIR_OFF, "Turns pair off")
        Me.B_PAIR_OFF.UseVisualStyleBackColor = True
        '
        'B_FANOFF
        '
        Me.B_FANOFF.Location = New System.Drawing.Point(191, 519)
        Me.B_FANOFF.Name = "B_FANOFF"
        Me.B_FANOFF.Size = New System.Drawing.Size(60, 23)
        Me.B_FANOFF.TabIndex = 125
        Me.B_FANOFF.Text = "FAN OFF"
        Me.ToolTip1.SetToolTip(Me.B_FANOFF, "Turns FAN off")
        Me.B_FANOFF.UseVisualStyleBackColor = True
        '
        'B_FANON
        '
        Me.B_FANON.Location = New System.Drawing.Point(139, 519)
        Me.B_FANON.Name = "B_FANON"
        Me.B_FANON.Size = New System.Drawing.Size(55, 23)
        Me.B_FANON.TabIndex = 124
        Me.B_FANON.Text = "FAN ON"
        Me.ToolTip1.SetToolTip(Me.B_FANON, "Turns Fan on")
        Me.B_FANON.UseVisualStyleBackColor = True
        '
        'L_ho2raw
        '
        Me.L_ho2raw.AutoSize = True
        Me.L_ho2raw.Location = New System.Drawing.Point(383, 772)
        Me.L_ho2raw.Name = "L_ho2raw"
        Me.L_ho2raw.Size = New System.Drawing.Size(24, 13)
        Me.L_ho2raw.TabIndex = 118
        Me.L_ho2raw.Text = "n/a"
        '
        'K8Datastream
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(731, 543)
        Me.Controls.Add(Me.B_FANOFF)
        Me.Controls.Add(Me.B_FANON)
        Me.Controls.Add(Me.B_ICS)
        Me.Controls.Add(Me.B_PAIR_OFF)
        Me.Controls.Add(Me.B_PAIR_ON)
        Me.Controls.Add(Me.L_ho2raw)
        Me.Controls.Add(Me.C_debug)
        Me.Controls.Add(Me.B_Clear_DTC)
        Me.Controls.Add(Me.L_cov4)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.L_cov3)
        Me.Controls.Add(Me.L_perftext)
        Me.Controls.Add(Me.L_cov2)
        Me.Controls.Add(Me.L_performanceindex)
        Me.Controls.Add(Me.L_cov1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.L_covabc)
        Me.Controls.Add(Me.T_2108)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.B_stop_engine)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.T_21C0)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.T_2180)
        Me.Controls.Add(Me.L_sec)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.L_prim)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.T_datacomm)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8Datastream"
        Me.ShowIcon = False
        Me.Text = "Hayabusa ECUeditor.com Engine Datastream Monitor K8-"
        CType(Me.LED_RPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_IGN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_CLT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_TPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_IAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_HO2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.LED_IAPabs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_SAPabs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_IAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_FUEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_BATT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_GEAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.LED_TIME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.LED_DUTY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox_Serialport As System.Windows.Forms.ComboBox
    Friend WithEvents T_datacomm As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents LED_RPM As LxControl.LxLedControl
    Friend WithEvents LED_IGN As LxControl.LxLedControl
    Friend WithEvents LED_CLT As LxControl.LxLedControl
    Friend WithEvents L_CLT As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LED_TPS As LxControl.LxLedControl
    Friend WithEvents LED_IAP As LxControl.LxLedControl
    Friend WithEvents B_Clear_DTC As System.Windows.Forms.Button
    Friend WithEvents B_Connect_Datastream As System.Windows.Forms.Button
    Friend WithEvents L_MS As System.Windows.Forms.Label
    Friend WithEvents L_Clutch As System.Windows.Forms.Label
    Friend WithEvents L_NT As System.Windows.Forms.Label
    Friend WithEvents LED_HO2 As LxControl.LxLedControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AquaGauge1 As AquaControls.AquaGauge
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LED_GEAR As LxControl.LxLedControl
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents A_CLT As AGauge.AGauge
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LED_TIME As LxControl.LxLedControl
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LED_BATT As LxControl.LxLedControl
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LED_FUEL As LxControl.LxLedControl
    Friend WithEvents LED_IAT As LxControl.LxLedControl
    Friend WithEvents L_IAT As System.Windows.Forms.Label
    Friend WithEvents LED_IAPabs As LxControl.LxLedControl
    Friend WithEvents LED_SAPabs As LxControl.LxLedControl
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents L_CLThigh As System.Windows.Forms.Label
    Friend WithEvents L_comms As System.Windows.Forms.Label
    Friend WithEvents B_Enginedatalog As System.Windows.Forms.Button
    Friend WithEvents T_2180 As System.Windows.Forms.TextBox
    Friend WithEvents L_modeC As System.Windows.Forms.Label
    Friend WithEvents L_modeB As System.Windows.Forms.Label
    Friend WithEvents L_modeA As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents L_basefuel As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents L_primaries As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents L_Secondaries As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents T_21C0 As System.Windows.Forms.TextBox
    Friend WithEvents L_pricyl4 As System.Windows.Forms.Label
    Friend WithEvents L_pricyl3 As System.Windows.Forms.Label
    Friend WithEvents L_pricyl2 As System.Windows.Forms.Label
    Friend WithEvents L_pricyl1 As System.Windows.Forms.Label
    Friend WithEvents L_seccyl4 As System.Windows.Forms.Label
    Friend WithEvents L_seccyl3 As System.Windows.Forms.Label
    Friend WithEvents L_seccyl2 As System.Windows.Forms.Label
    Friend WithEvents L_seccyl1 As System.Windows.Forms.Label
    Friend WithEvents L_ramair As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pwrpm As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
     Friend WithEvents B_stop_engine As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents T_2108 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents L_sec As System.Windows.Forms.Label
    Friend WithEvents L_prim As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents L_cov4 As System.Windows.Forms.Label
    Friend WithEvents L_cov3 As System.Windows.Forms.Label
    Friend WithEvents L_cov2 As System.Windows.Forms.Label
    Friend WithEvents L_cov1 As System.Windows.Forms.Label
    Friend WithEvents L_covabc As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents L_PAIR As System.Windows.Forms.Label
    Friend WithEvents L_performanceindex As System.Windows.Forms.Label
    Friend WithEvents L_perftext As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents LED_DUTY As LxControl.LxLedControl
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents L_msg As System.Windows.Forms.Label
    Friend WithEvents L_STP As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents C_debug As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents L_ho2raw As System.Windows.Forms.Label
    Friend WithEvents B_PAIR_ON As System.Windows.Forms.Button
    Friend WithEvents B_PAIR_OFF As System.Windows.Forms.Button
    Friend WithEvents B_ICS As System.Windows.Forms.Button
    Friend WithEvents B_FANOFF As System.Windows.Forms.Button
    Friend WithEvents B_FANON As System.Windows.Forms.Button
End Class
