<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8Advsettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8Advsettings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.R_Normal = New System.Windows.Forms.RadioButton()
        Me.R_Flash = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.C_ECU = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C_HOX = New System.Windows.Forms.CheckBox()
        Me.R_IAT_normal = New System.Windows.Forms.RadioButton()
        Me.R_IAT_dynomode = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.C_ICS = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.C_coil_fi_disable = New System.Windows.Forms.CheckBox()
        Me.C_coolingfan = New System.Windows.Forms.CheckBox()
        Me.C_secondaries = New System.Windows.Forms.CheckBox()
        Me.C_IAPTPS = New System.Windows.Forms.ComboBox()
        Me.C_ramairmode = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.C_warmup = New System.Windows.Forms.CheckBox()
        Me.B_ramairadjust = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.C_PAIR = New System.Windows.Forms.CheckBox()
        Me.B_boostfuel = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.B_dragtools = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.C_secsize = New System.Windows.Forms.ComboBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.B_WRITE = New System.Windows.Forms.Button()
        Me.T_hexvaluehi = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_hexaddr = New System.Windows.Forms.TextBox()
        Me.C_COV = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.C_BkingGauges = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.C_fan = New System.Windows.Forms.ComboBox()
        Me.C_TOS = New System.Windows.Forms.CheckBox()
        Me.C_FastBaudRate = New System.Windows.Forms.CheckBox()
        Me.C_DatalogO2Sensor = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C_ABCmode = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.C_pair_voltage = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.R_Normal)
        Me.GroupBox1.Controls.Add(Me.R_Flash)
        Me.GroupBox1.Location = New System.Drawing.Point(332, 522)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(148, 67)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Flashing dynomode"
        Me.ToolTip1.SetToolTip(Me.GroupBox1, "Set flashing mode to flash the full maps area(normal) or just the main maps(fast)" & _
                ".")
        '
        'R_Normal
        '
        Me.R_Normal.AutoSize = True
        Me.R_Normal.Location = New System.Drawing.Point(6, 42)
        Me.R_Normal.Name = "R_Normal"
        Me.R_Normal.Size = New System.Drawing.Size(58, 17)
        Me.R_Normal.TabIndex = 1
        Me.R_Normal.TabStop = True
        Me.R_Normal.Text = "Normal"
        Me.ToolTip1.SetToolTip(Me.R_Normal, resources.GetString("R_Normal.ToolTip"))
        Me.R_Normal.UseVisualStyleBackColor = True
        '
        'R_Flash
        '
        Me.R_Flash.AutoSize = True
        Me.R_Flash.Location = New System.Drawing.Point(6, 19)
        Me.R_Flash.Name = "R_Flash"
        Me.R_Flash.Size = New System.Drawing.Size(45, 17)
        Me.R_Flash.TabIndex = 0
        Me.R_Flash.TabStop = True
        Me.R_Flash.Text = "Fast"
        Me.ToolTip1.SetToolTip(Me.R_Flash, resources.GetString("R_Flash.ToolTip"))
        Me.R_Flash.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.C_ECU)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(155, 50)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ECU mode"
        Me.ToolTip1.SetToolTip(Me.GroupBox3, "Set flashing mode to flash the full maps area(normal) or just the main maps(fast)" & _
                ".")
        '
        'C_ECU
        '
        Me.C_ECU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_ECU.FormattingEnabled = True
        Me.C_ECU.Location = New System.Drawing.Point(60, 19)
        Me.C_ECU.Name = "C_ECU"
        Me.C_ECU.Size = New System.Drawing.Size(81, 21)
        Me.C_ECU.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.C_ECU, resources.GetString("C_ECU.ToolTip"))
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ECU"
        '
        'C_HOX
        '
        Me.C_HOX.AutoSize = True
        Me.C_HOX.Location = New System.Drawing.Point(6, 70)
        Me.C_HOX.Name = "C_HOX"
        Me.C_HOX.Size = New System.Drawing.Size(115, 17)
        Me.C_HOX.TabIndex = 2
        Me.C_HOX.Text = "HOX sensor on/off"
        Me.ToolTip1.SetToolTip(Me.C_HOX, resources.GetString("C_HOX.ToolTip"))
        Me.C_HOX.UseVisualStyleBackColor = True
        '
        'R_IAT_normal
        '
        Me.R_IAT_normal.AutoSize = True
        Me.R_IAT_normal.Location = New System.Drawing.Point(6, 42)
        Me.R_IAT_normal.Name = "R_IAT_normal"
        Me.R_IAT_normal.Size = New System.Drawing.Size(76, 17)
        Me.R_IAT_normal.TabIndex = 1
        Me.R_IAT_normal.TabStop = True
        Me.R_IAT_normal.Text = "IAT normal"
        Me.ToolTip1.SetToolTip(Me.R_IAT_normal, "What is IAT dynomode normal ?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This feature will set your Intake Air Temperature " & _
                "sensor back to normal operating state. See IAT dynomode for more information." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.R_IAT_normal.UseVisualStyleBackColor = True
        '
        'R_IAT_dynomode
        '
        Me.R_IAT_dynomode.AutoSize = True
        Me.R_IAT_dynomode.Location = New System.Drawing.Point(6, 19)
        Me.R_IAT_dynomode.Name = "R_IAT_dynomode"
        Me.R_IAT_dynomode.Size = New System.Drawing.Size(116, 17)
        Me.R_IAT_dynomode.TabIndex = 0
        Me.R_IAT_dynomode.TabStop = True
        Me.R_IAT_dynomode.Text = "IAT dynomode 20C"
        Me.ToolTip1.SetToolTip(Me.R_IAT_dynomode, resources.GetString("R_IAT_dynomode.ToolTip"))
        Me.R_IAT_dynomode.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(110, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Inj Bal map editing"
        Me.ToolTip1.SetToolTip(Me.Button3, resources.GetString("Button3.ToolTip"))
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(110, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "STP map editing"
        Me.ToolTip1.SetToolTip(Me.Button1, resources.GetString("Button1.ToolTip"))
        Me.Button1.UseVisualStyleBackColor = True
        '
        'C_ICS
        '
        Me.C_ICS.AutoSize = True
        Me.C_ICS.Location = New System.Drawing.Point(7, 17)
        Me.C_ICS.Name = "C_ICS"
        Me.C_ICS.Size = New System.Drawing.Size(111, 17)
        Me.C_ICS.TabIndex = 4
        Me.C_ICS.Text = "ISC disable on/off"
        Me.ToolTip1.SetToolTip(Me.C_ICS, resources.GetString("C_ICS.ToolTip"))
        Me.C_ICS.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(110, 105)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Ignition Dwell"
        Me.ToolTip1.SetToolTip(Me.Button4, resources.GetString("Button4.ToolTip"))
        Me.Button4.UseVisualStyleBackColor = True
        '
        'C_coil_fi_disable
        '
        Me.C_coil_fi_disable.AutoSize = True
        Me.C_coil_fi_disable.Location = New System.Drawing.Point(171, 17)
        Me.C_coil_fi_disable.Name = "C_coil_fi_disable"
        Me.C_coil_fi_disable.Size = New System.Drawing.Size(155, 17)
        Me.C_coil_fi_disable.TabIndex = 6
        Me.C_coil_fi_disable.Text = "Coil FI disabled for NLR sim"
        Me.ToolTip1.SetToolTip(Me.C_coil_fi_disable, resources.GetString("C_coil_fi_disable.ToolTip"))
        Me.C_coil_fi_disable.UseVisualStyleBackColor = True
        '
        'C_coolingfan
        '
        Me.C_coolingfan.AutoSize = True
        Me.C_coolingfan.Location = New System.Drawing.Point(171, 40)
        Me.C_coolingfan.Name = "C_coolingfan"
        Me.C_coolingfan.Size = New System.Drawing.Size(113, 17)
        Me.C_coolingfan.TabIndex = 7
        Me.C_coolingfan.Text = "Cooling fan normal"
        Me.ToolTip1.SetToolTip(Me.C_coolingfan, "With this setting you can disable the FI code from a missing cooling fan relay - " & _
                "only for race purposes.")
        Me.C_coolingfan.UseVisualStyleBackColor = True
        '
        'C_secondaries
        '
        Me.C_secondaries.AutoSize = True
        Me.C_secondaries.Location = New System.Drawing.Point(171, 63)
        Me.C_secondaries.Name = "C_secondaries"
        Me.C_secondaries.Size = New System.Drawing.Size(131, 17)
        Me.C_secondaries.TabIndex = 8
        Me.C_secondaries.Text = "Secondaries FI normal"
        Me.ToolTip1.SetToolTip(Me.C_secondaries, "With this setting you can disable the FI code from missing secondaries - only for" & _
                " race purposes.")
        Me.C_secondaries.UseVisualStyleBackColor = True
        '
        'C_IAPTPS
        '
        Me.C_IAPTPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_IAPTPS.FormattingEnabled = True
        Me.C_IAPTPS.Location = New System.Drawing.Point(62, 59)
        Me.C_IAPTPS.Name = "C_IAPTPS"
        Me.C_IAPTPS.Size = New System.Drawing.Size(73, 21)
        Me.C_IAPTPS.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.C_IAPTPS, resources.GetString("C_IAPTPS.ToolTip"))
        '
        'C_ramairmode
        '
        Me.C_ramairmode.AutoSize = True
        Me.C_ramairmode.Location = New System.Drawing.Point(6, 145)
        Me.C_ramairmode.Name = "C_ramairmode"
        Me.C_ramairmode.Size = New System.Drawing.Size(88, 17)
        Me.C_ramairmode.TabIndex = 2
        Me.C_ramairmode.Text = "Ramair mode"
        Me.ToolTip1.SetToolTip(Me.C_ramairmode, resources.GetString("C_ramairmode.ToolTip"))
        Me.C_ramairmode.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(111, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 23)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Activate MIL"
        Me.ToolTip1.SetToolTip(Me.Button5, resources.GetString("Button5.ToolTip"))
        Me.Button5.UseVisualStyleBackColor = True
        '
        'C_warmup
        '
        Me.C_warmup.AutoSize = True
        Me.C_warmup.Location = New System.Drawing.Point(6, 168)
        Me.C_warmup.Name = "C_warmup"
        Me.C_warmup.Size = New System.Drawing.Size(97, 17)
        Me.C_warmup.TabIndex = 4
        Me.C_warmup.Text = "95C thermostat"
        Me.ToolTip1.SetToolTip(Me.C_warmup, resources.GetString("C_warmup.ToolTip"))
        Me.C_warmup.UseVisualStyleBackColor = True
        '
        'B_ramairadjust
        '
        Me.B_ramairadjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_ramairadjust.Location = New System.Drawing.Point(110, 49)
        Me.B_ramairadjust.Name = "B_ramairadjust"
        Me.B_ramairadjust.Size = New System.Drawing.Size(79, 22)
        Me.B_ramairadjust.TabIndex = 2
        Me.B_ramairadjust.Text = "Ramair map"
        Me.B_ramairadjust.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.C_pair_voltage)
        Me.GroupBox6.Controls.Add(Me.C_warmup)
        Me.GroupBox6.Controls.Add(Me.C_PAIR)
        Me.GroupBox6.Controls.Add(Me.C_ramairmode)
        Me.GroupBox6.Controls.Add(Me.C_HOX)
        Me.GroupBox6.Controls.Add(Me.R_IAT_normal)
        Me.GroupBox6.Controls.Add(Me.R_IAT_dynomode)
        Me.GroupBox6.Location = New System.Drawing.Point(17, 71)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(154, 219)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Dynomode settings"
        '
        'C_PAIR
        '
        Me.C_PAIR.AutoSize = True
        Me.C_PAIR.Location = New System.Drawing.Point(6, 98)
        Me.C_PAIR.Name = "C_PAIR"
        Me.C_PAIR.Size = New System.Drawing.Size(83, 17)
        Me.C_PAIR.TabIndex = 3
        Me.C_PAIR.Text = "PAIR on/off"
        Me.ToolTip1.SetToolTip(Me.C_PAIR, "This setting allows you to activate/disable the pair functionality.  Disabling th" & _
                "e pair is needed if:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1) Pair is removed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2) Pair connector is used as a nitrous" & _
                " controller or as a boost controller" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.C_PAIR.UseVisualStyleBackColor = True
        '
        'B_boostfuel
        '
        Me.B_boostfuel.Location = New System.Drawing.Point(111, 18)
        Me.B_boostfuel.Name = "B_boostfuel"
        Me.B_boostfuel.Size = New System.Drawing.Size(81, 22)
        Me.B_boostfuel.TabIndex = 39
        Me.B_boostfuel.Text = "Boostfuel"
        Me.B_boostfuel.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.B_dragtools)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.B_boostfuel)
        Me.GroupBox5.Location = New System.Drawing.Point(179, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(213, 103)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Powertools"
        '
        'B_dragtools
        '
        Me.B_dragtools.Location = New System.Drawing.Point(111, 75)
        Me.B_dragtools.Name = "B_dragtools"
        Me.B_dragtools.Size = New System.Drawing.Size(81, 22)
        Me.B_dragtools.TabIndex = 44
        Me.B_dragtools.Text = "Dragtools"
        Me.B_dragtools.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Set power delivery "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Adjust turbo fuelling"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Set nitrous fuelling"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(111, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 22)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "Nitrouscontrol"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Secondaries size"
        '
        'C_secsize
        '
        Me.C_secsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_secsize.Enabled = False
        Me.C_secsize.FormattingEnabled = True
        Me.C_secsize.Location = New System.Drawing.Point(99, 39)
        Me.C_secsize.Name = "C_secsize"
        Me.C_secsize.Size = New System.Drawing.Size(81, 21)
        Me.C_secsize.TabIndex = 10
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.B_WRITE)
        Me.GroupBox8.Controls.Add(Me.T_hexvaluehi)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.T_hexaddr)
        Me.GroupBox8.Location = New System.Drawing.Point(17, 451)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(376, 65)
        Me.GroupBox8.TabIndex = 42
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Setbyte"
        '
        'B_WRITE
        '
        Me.B_WRITE.Location = New System.Drawing.Point(273, 31)
        Me.B_WRITE.Name = "B_WRITE"
        Me.B_WRITE.Size = New System.Drawing.Size(82, 23)
        Me.B_WRITE.TabIndex = 4
        Me.B_WRITE.Text = "Write"
        Me.B_WRITE.UseVisualStyleBackColor = True
        '
        'T_hexvaluehi
        '
        Me.T_hexvaluehi.Location = New System.Drawing.Point(182, 34)
        Me.T_hexvaluehi.Name = "T_hexvaluehi"
        Me.T_hexvaluehi.Size = New System.Drawing.Size(46, 20)
        Me.T_hexvaluehi.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(180, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Value (hex)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Address (hex)"
        '
        'T_hexaddr
        '
        Me.T_hexaddr.Location = New System.Drawing.Point(5, 34)
        Me.T_hexaddr.Name = "T_hexaddr"
        Me.T_hexaddr.Size = New System.Drawing.Size(129, 20)
        Me.T_hexaddr.TabIndex = 0
        '
        'C_COV
        '
        Me.C_COV.AutoSize = True
        Me.C_COV.Location = New System.Drawing.Point(7, 19)
        Me.C_COV.Name = "C_COV"
        Me.C_COV.Size = New System.Drawing.Size(80, 17)
        Me.C_COV.TabIndex = 3
        Me.C_COV.Text = "COV on/off"
        Me.C_COV.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Button4)
        Me.GroupBox9.Controls.Add(Me.Label11)
        Me.GroupBox9.Controls.Add(Me.Button3)
        Me.GroupBox9.Controls.Add(Me.Label10)
        Me.GroupBox9.Controls.Add(Me.B_ramairadjust)
        Me.GroupBox9.Controls.Add(Me.Label9)
        Me.GroupBox9.Controls.Add(Me.Button1)
        Me.GroupBox9.Controls.Add(Me.Label7)
        Me.GroupBox9.Location = New System.Drawing.Point(179, 115)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(214, 131)
        Me.GroupBox9.TabIndex = 44
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Misc maps"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Dwell map"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Inj Bal map editing"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Ramair editing"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "STP map editing"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.C_COV)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.C_secsize)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 522)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(295, 114)
        Me.GroupBox4.TabIndex = 45
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Just for testing"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.C_BkingGauges)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.C_fan)
        Me.GroupBox7.Controls.Add(Me.C_TOS)
        Me.GroupBox7.Controls.Add(Me.C_FastBaudRate)
        Me.GroupBox7.Controls.Add(Me.C_DatalogO2Sensor)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.C_IAPTPS)
        Me.GroupBox7.Controls.Add(Me.C_secondaries)
        Me.GroupBox7.Controls.Add(Me.C_coolingfan)
        Me.GroupBox7.Controls.Add(Me.C_ABCmode)
        Me.GroupBox7.Controls.Add(Me.C_coil_fi_disable)
        Me.GroupBox7.Controls.Add(Me.C_ICS)
        Me.GroupBox7.Location = New System.Drawing.Point(16, 290)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(374, 169)
        Me.GroupBox7.TabIndex = 46
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Misc settings"
        '
        'C_BkingGauges
        '
        Me.C_BkingGauges.AutoSize = True
        Me.C_BkingGauges.Location = New System.Drawing.Point(171, 82)
        Me.C_BkingGauges.Name = "C_BkingGauges"
        Me.C_BkingGauges.Size = New System.Drawing.Size(97, 17)
        Me.C_BkingGauges.TabIndex = 105
        Me.C_BkingGauges.Text = "B-King Gauges"
        Me.C_BkingGauges.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "FAN temp"
        '
        'C_fan
        '
        Me.C_fan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_fan.FormattingEnabled = True
        Me.C_fan.Location = New System.Drawing.Point(62, 84)
        Me.C_fan.Name = "C_fan"
        Me.C_fan.Size = New System.Drawing.Size(73, 21)
        Me.C_fan.TabIndex = 103
        '
        'C_TOS
        '
        Me.C_TOS.AutoSize = True
        Me.C_TOS.Location = New System.Drawing.Point(7, 108)
        Me.C_TOS.Name = "C_TOS"
        Me.C_TOS.Size = New System.Drawing.Size(128, 17)
        Me.C_TOS.TabIndex = 51
        Me.C_TOS.Text = "TOS acitive/deactive"
        Me.C_TOS.UseVisualStyleBackColor = True
        '
        'C_FastBaudRate
        '
        Me.C_FastBaudRate.AutoSize = True
        Me.C_FastBaudRate.Location = New System.Drawing.Point(172, 124)
        Me.C_FastBaudRate.Name = "C_FastBaudRate"
        Me.C_FastBaudRate.Size = New System.Drawing.Size(100, 17)
        Me.C_FastBaudRate.TabIndex = 49
        Me.C_FastBaudRate.Text = "Fast Baud Rate"
        Me.C_FastBaudRate.UseVisualStyleBackColor = True
        '
        'C_DatalogO2Sensor
        '
        Me.C_DatalogO2Sensor.AutoSize = True
        Me.C_DatalogO2Sensor.Location = New System.Drawing.Point(171, 103)
        Me.C_DatalogO2Sensor.Name = "C_DatalogO2Sensor"
        Me.C_DatalogO2Sensor.Size = New System.Drawing.Size(128, 17)
        Me.C_DatalogO2Sensor.TabIndex = 48
        Me.C_DatalogO2Sensor.Text = "Wideband O2 Sensor"
        Me.C_DatalogO2Sensor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "IAP/TPS"
        '
        'C_ABCmode
        '
        Me.C_ABCmode.AutoSize = True
        Me.C_ABCmode.Location = New System.Drawing.Point(7, 40)
        Me.C_ABCmode.Name = "C_ABCmode"
        Me.C_ABCmode.Size = New System.Drawing.Size(94, 17)
        Me.C_ABCmode.TabIndex = 5
        Me.C_ABCmode.Text = "ABC fixed to A"
        Me.C_ABCmode.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Location = New System.Drawing.Point(179, 249)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 41)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gaugemode"
        '
        'C_pair_voltage
        '
        Me.C_pair_voltage.AutoSize = True
        Me.C_pair_voltage.Location = New System.Drawing.Point(6, 117)
        Me.C_pair_voltage.Name = "C_pair_voltage"
        Me.C_pair_voltage.Size = New System.Drawing.Size(121, 17)
        Me.C_pair_voltage.TabIndex = 106
        Me.C_pair_voltage.Text = "PAIR voltage on/off"
        Me.ToolTip1.SetToolTip(Me.C_pair_voltage, "This setting allows you to set pair voltage permanently on to close the pair valv" & _
                "e" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fully for e.g. dyno sessions. This setting to work the PAIR setting must be s" & _
                "et to normal.")
        Me.C_pair_voltage.UseVisualStyleBackColor = True
        '
        'K8Advsettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 570)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8Advsettings"
        Me.Text = "ECUeditor Advanced settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents R_Normal As System.Windows.Forms.RadioButton
    Friend WithEvents R_Flash As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents C_ECU As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents R_IAT_normal As System.Windows.Forms.RadioButton
    Friend WithEvents R_IAT_dynomode As System.Windows.Forms.RadioButton
    Friend WithEvents B_boostfuel As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents T_hexvaluehi As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_hexaddr As System.Windows.Forms.TextBox
    Friend WithEvents B_WRITE As System.Windows.Forms.Button
    Friend WithEvents C_HOX As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents C_secsize As System.Windows.Forms.ComboBox
    Friend WithEvents C_COV As System.Windows.Forms.CheckBox
    Friend WithEvents C_PAIR As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents B_ramairadjust As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents C_ICS As System.Windows.Forms.CheckBox
    Friend WithEvents C_ABCmode As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents C_coil_fi_disable As System.Windows.Forms.CheckBox
    Friend WithEvents C_coolingfan As System.Windows.Forms.CheckBox
    Friend WithEvents C_secondaries As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents C_IAPTPS As System.Windows.Forms.ComboBox
    Friend WithEvents C_ramairmode As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents C_DatalogO2Sensor As System.Windows.Forms.CheckBox
    Friend WithEvents C_warmup As System.Windows.Forms.CheckBox
    Friend WithEvents C_FastBaudRate As System.Windows.Forms.CheckBox
    Friend WithEvents B_dragtools As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents C_TOS As System.Windows.Forms.CheckBox
    Friend WithEvents C_fan As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents C_BkingGauges As System.Windows.Forms.CheckBox
    Friend WithEvents C_pair_voltage As System.Windows.Forms.CheckBox
End Class
