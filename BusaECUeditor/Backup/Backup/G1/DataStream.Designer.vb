<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Datastream
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
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.C_SerialPort = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.B_DataStreamOn = New System.Windows.Forms.Button
        Me.B_Logging = New System.Windows.Forms.Button
        Me.TrackBar_Datalog = New System.Windows.Forms.TrackBar
        Me.C_Uservar1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LED_RPM = New LxControl.LxLedControl
        Me.LED_IGN = New LxControl.LxLedControl
        Me.LED_CLT = New LxControl.LxLedControl
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.LED_TPS = New LxControl.LxLedControl
        Me.LED_IAP = New LxControl.LxLedControl
        Me.LED_FUEL = New LxControl.LxLedControl
        Me.LED_USR1 = New LxControl.LxLedControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.T_MapSelected = New System.Windows.Forms.TextBox
        Me.R_OxySensor = New System.Windows.Forms.RadioButton
        Me.B_LC1On = New System.Windows.Forms.Button
        Me.RPMGauge = New BusaECUeditor.ldGuage.ldGuage
        CType(Me.TrackBar_Datalog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_RPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_IGN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_CLT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_TPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_IAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_FUEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_USR1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(43, 370)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(451, 20)
        Me.TextBox2.TabIndex = 24
        '
        'C_SerialPort
        '
        Me.C_SerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_SerialPort.FormattingEnabled = True
        Me.C_SerialPort.Location = New System.Drawing.Point(310, 33)
        Me.C_SerialPort.Name = "C_SerialPort"
        Me.C_SerialPort.Size = New System.Drawing.Size(84, 21)
        Me.C_SerialPort.TabIndex = 22
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.TextBox1.Location = New System.Drawing.Point(43, 342)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(309, 22)
        Me.TextBox1.TabIndex = 20
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
        Me.Timer2.Interval = 200
        '
        'B_DataStreamOn
        '
        Me.B_DataStreamOn.Location = New System.Drawing.Point(310, 5)
        Me.B_DataStreamOn.Name = "B_DataStreamOn"
        Me.B_DataStreamOn.Size = New System.Drawing.Size(84, 22)
        Me.B_DataStreamOn.TabIndex = 28
        Me.B_DataStreamOn.Text = "Data ON"
        Me.B_DataStreamOn.UseVisualStyleBackColor = True
        '
        'B_Logging
        '
        Me.B_Logging.Location = New System.Drawing.Point(311, 270)
        Me.B_Logging.Name = "B_Logging"
        Me.B_Logging.Size = New System.Drawing.Size(83, 24)
        Me.B_Logging.TabIndex = 38
        Me.B_Logging.Text = "Logging ON"
        Me.B_Logging.UseVisualStyleBackColor = True
        '
        'TrackBar_Datalog
        '
        Me.TrackBar_Datalog.Location = New System.Drawing.Point(13, 270)
        Me.TrackBar_Datalog.Name = "TrackBar_Datalog"
        Me.TrackBar_Datalog.Size = New System.Drawing.Size(285, 45)
        Me.TrackBar_Datalog.TabIndex = 39
        '
        'C_Uservar1
        '
        Me.C_Uservar1.BackColor = System.Drawing.SystemColors.Control
        Me.C_Uservar1.FormattingEnabled = True
        Me.C_Uservar1.Location = New System.Drawing.Point(233, 231)
        Me.C_Uservar1.Name = "C_Uservar1"
        Me.C_Uservar1.Size = New System.Drawing.Size(103, 21)
        Me.C_Uservar1.TabIndex = 42
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "RPM"
        '
        'LED_RPM
        '
        Me.LED_RPM.BackColor = System.Drawing.Color.Transparent
        Me.LED_RPM.BackColor_1 = System.Drawing.Color.Black
        Me.LED_RPM.BackColor_2 = System.Drawing.Color.Black
        Me.LED_RPM.BevelRate = 0.5!
        Me.LED_RPM.BorderColor = System.Drawing.Color.Black
        Me.LED_RPM.FadedColor = System.Drawing.Color.Black
        Me.LED_RPM.ForeColor = System.Drawing.Color.White
        Me.LED_RPM.HighlightOpaque = CType(50, Byte)
        Me.LED_RPM.Location = New System.Drawing.Point(94, 175)
        Me.LED_RPM.Name = "LED_RPM"
        Me.LED_RPM.Size = New System.Drawing.Size(117, 23)
        Me.LED_RPM.TabIndex = 58
        Me.LED_RPM.Text = "-"
        Me.LED_RPM.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_RPM.TotalCharCount = 6
        '
        'LED_IGN
        '
        Me.LED_IGN.BackColor = System.Drawing.Color.Transparent
        Me.LED_IGN.BackColor_1 = System.Drawing.Color.Black
        Me.LED_IGN.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_IGN.BevelRate = 0.5!
        Me.LED_IGN.FadedColor = System.Drawing.Color.Black
        Me.LED_IGN.ForeColor = System.Drawing.Color.White
        Me.LED_IGN.HighlightOpaque = CType(50, Byte)
        Me.LED_IGN.Location = New System.Drawing.Point(342, 200)
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
        Me.LED_CLT.BackColor_1 = System.Drawing.Color.Black
        Me.LED_CLT.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_CLT.BevelRate = 0.5!
        Me.LED_CLT.FadedColor = System.Drawing.Color.Black
        Me.LED_CLT.ForeColor = System.Drawing.Color.White
        Me.LED_CLT.HighlightOpaque = CType(50, Byte)
        Me.LED_CLT.Location = New System.Drawing.Point(342, 84)
        Me.LED_CLT.Name = "LED_CLT"
        Me.LED_CLT.Size = New System.Drawing.Size(52, 23)
        Me.LED_CLT.TabIndex = 60
        Me.LED_CLT.Text = "-"
        Me.LED_CLT.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_CLT.TotalCharCount = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(299, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 13)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "CLT"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(287, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "IGN deg"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(297, 123)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "TPS %"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(295, 153)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "IAP diff"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(285, 181)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "FUEL pw"
        '
        'LED_TPS
        '
        Me.LED_TPS.BackColor = System.Drawing.Color.Transparent
        Me.LED_TPS.BackColor_1 = System.Drawing.Color.Black
        Me.LED_TPS.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_TPS.BevelRate = 0.5!
        Me.LED_TPS.FadedColor = System.Drawing.Color.Black
        Me.LED_TPS.ForeColor = System.Drawing.Color.White
        Me.LED_TPS.HighlightOpaque = CType(50, Byte)
        Me.LED_TPS.Location = New System.Drawing.Point(342, 113)
        Me.LED_TPS.Name = "LED_TPS"
        Me.LED_TPS.Size = New System.Drawing.Size(52, 23)
        Me.LED_TPS.TabIndex = 67
        Me.LED_TPS.Text = "-"
        Me.LED_TPS.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_TPS.TotalCharCount = 4
        '
        'LED_IAP
        '
        Me.LED_IAP.BackColor = System.Drawing.Color.Transparent
        Me.LED_IAP.BackColor_1 = System.Drawing.Color.Black
        Me.LED_IAP.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_IAP.BevelRate = 0.5!
        Me.LED_IAP.FadedColor = System.Drawing.Color.Black
        Me.LED_IAP.ForeColor = System.Drawing.Color.White
        Me.LED_IAP.HighlightOpaque = CType(50, Byte)
        Me.LED_IAP.Location = New System.Drawing.Point(342, 142)
        Me.LED_IAP.Name = "LED_IAP"
        Me.LED_IAP.Size = New System.Drawing.Size(52, 23)
        Me.LED_IAP.TabIndex = 68
        Me.LED_IAP.Text = "-"
        Me.LED_IAP.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_IAP.TotalCharCount = 4
        '
        'LED_FUEL
        '
        Me.LED_FUEL.BackColor = System.Drawing.Color.Transparent
        Me.LED_FUEL.BackColor_1 = System.Drawing.Color.Black
        Me.LED_FUEL.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_FUEL.BevelRate = 0.5!
        Me.LED_FUEL.FadedColor = System.Drawing.Color.Black
        Me.LED_FUEL.ForeColor = System.Drawing.Color.White
        Me.LED_FUEL.HighlightOpaque = CType(50, Byte)
        Me.LED_FUEL.Location = New System.Drawing.Point(342, 171)
        Me.LED_FUEL.Name = "LED_FUEL"
        Me.LED_FUEL.Size = New System.Drawing.Size(52, 23)
        Me.LED_FUEL.TabIndex = 69
        Me.LED_FUEL.Text = "-"
        Me.LED_FUEL.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_FUEL.TotalCharCount = 4
        '
        'LED_USR1
        '
        Me.LED_USR1.BackColor = System.Drawing.Color.Transparent
        Me.LED_USR1.BackColor_1 = System.Drawing.Color.Black
        Me.LED_USR1.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_USR1.BevelRate = 0.5!
        Me.LED_USR1.FadedColor = System.Drawing.Color.Black
        Me.LED_USR1.ForeColor = System.Drawing.Color.White
        Me.LED_USR1.HighlightOpaque = CType(50, Byte)
        Me.LED_USR1.Location = New System.Drawing.Point(342, 229)
        Me.LED_USR1.Name = "LED_USR1"
        Me.LED_USR1.Size = New System.Drawing.Size(52, 23)
        Me.LED_USR1.TabIndex = 71
        Me.LED_USR1.Text = "-"
        Me.LED_USR1.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_USR1.TotalCharCount = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(305, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Map:"
        '
        'T_MapSelected
        '
        Me.T_MapSelected.Location = New System.Drawing.Point(348, 58)
        Me.T_MapSelected.Name = "T_MapSelected"
        Me.T_MapSelected.Size = New System.Drawing.Size(46, 20)
        Me.T_MapSelected.TabIndex = 73
        '
        'R_OxySensor
        '
        Me.R_OxySensor.AutoSize = True
        Me.R_OxySensor.Location = New System.Drawing.Point(22, 235)
        Me.R_OxySensor.Name = "R_OxySensor"
        Me.R_OxySensor.Size = New System.Drawing.Size(109, 17)
        Me.R_OxySensor.TabIndex = 74
        Me.R_OxySensor.TabStop = True
        Me.R_OxySensor.Text = "Oxy sensor active"
        Me.R_OxySensor.UseVisualStyleBackColor = True
        '
        'B_LC1On
        '
        Me.B_LC1On.Location = New System.Drawing.Point(311, 301)
        Me.B_LC1On.Name = "B_LC1On"
        Me.B_LC1On.Size = New System.Drawing.Size(83, 24)
        Me.B_LC1On.TabIndex = 75
        Me.B_LC1On.Text = "LC-1 ON"
        Me.B_LC1On.UseVisualStyleBackColor = True
        '
        'RPMGauge
        '
        Me.RPMGauge.BackColor = System.Drawing.Color.Black
        Me.RPMGauge.Deflection = 0.0!
        Me.RPMGauge.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RPMGauge.ForeColor = System.Drawing.Color.White
        Me.RPMGauge.Location = New System.Drawing.Point(47, 12)
        Me.RPMGauge.Name = "RPMGauge"
        Me.RPMGauge.Needle_Color = System.Drawing.Color.Orange
        Me.RPMGauge.Range = 14000.0!
        Me.RPMGauge.RedZone = 10000.0!
        Me.RPMGauge.RedZone_Color = System.Drawing.Color.Red
        Me.RPMGauge.Size = New System.Drawing.Size(224, 208)
        Me.RPMGauge.TabIndex = 50
        Me.RPMGauge.Text = "RPM"
        '
        'Datastream
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 331)
        Me.Controls.Add(Me.B_LC1On)
        Me.Controls.Add(Me.R_OxySensor)
        Me.Controls.Add(Me.T_MapSelected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LED_USR1)
        Me.Controls.Add(Me.LED_FUEL)
        Me.Controls.Add(Me.LED_IAP)
        Me.Controls.Add(Me.LED_TPS)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LED_CLT)
        Me.Controls.Add(Me.LED_IGN)
        Me.Controls.Add(Me.LED_RPM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RPMGauge)
        Me.Controls.Add(Me.C_Uservar1)
        Me.Controls.Add(Me.TrackBar_Datalog)
        Me.Controls.Add(Me.B_Logging)
        Me.Controls.Add(Me.B_DataStreamOn)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.C_SerialPort)
        Me.Controls.Add(Me.TextBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Datastream"
        Me.ShowIcon = False
        Me.Text = "Hayabusa Engine Datastream Monitor K2-K7"
        CType(Me.TrackBar_Datalog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_RPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_IGN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_CLT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_TPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_IAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_FUEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_USR1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents C_SerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents B_DataStreamOn As System.Windows.Forms.Button
    Friend WithEvents B_Logging As System.Windows.Forms.Button
    Friend WithEvents TrackBar_Datalog As System.Windows.Forms.TrackBar
    Friend WithEvents C_Uservar1 As System.Windows.Forms.ComboBox
    Friend WithEvents RPMGauge As BusaECUeditor.ldGuage.ldGuage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LED_RPM As LxControl.LxLedControl
    Friend WithEvents LED_IGN As LxControl.LxLedControl
    Friend WithEvents LED_CLT As LxControl.LxLedControl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LED_TPS As LxControl.LxLedControl
    Friend WithEvents LED_IAP As LxControl.LxLedControl
    Friend WithEvents LED_FUEL As LxControl.LxLedControl
    Friend WithEvents LED_USR1 As LxControl.LxLedControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_MapSelected As System.Windows.Forms.TextBox
    Friend WithEvents R_OxySensor As System.Windows.Forms.RadioButton
    Friend WithEvents B_LC1On As System.Windows.Forms.Button
End Class
