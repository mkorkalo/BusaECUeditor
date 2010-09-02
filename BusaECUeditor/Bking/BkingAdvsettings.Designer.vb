<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BKingAdvSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BKingAdvSettings))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.B_WRITE = New System.Windows.Forms.Button
        Me.T_hexvaluehi = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.T_hexaddr = New System.Windows.Forms.TextBox
        Me.C_HOX = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.C_DatalogO2Sensor = New System.Windows.Forms.CheckBox
        Me.C_EXC = New System.Windows.Forms.CheckBox
        Me.C_EVAP = New System.Windows.Forms.CheckBox
        Me.C_PAIR = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.B_Inj_Bal_Map = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.B_STP_Map = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.C_FastBaudRate = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.B_WRITE)
        Me.GroupBox8.Controls.Add(Me.T_hexvaluehi)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.T_hexaddr)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(364, 65)
        Me.GroupBox8.TabIndex = 42
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Setbyte"
        '
        'B_WRITE
        '
        Me.B_WRITE.Location = New System.Drawing.Point(254, 31)
        Me.B_WRITE.Name = "B_WRITE"
        Me.B_WRITE.Size = New System.Drawing.Size(82, 23)
        Me.B_WRITE.TabIndex = 4
        Me.B_WRITE.Text = "Write"
        Me.B_WRITE.UseVisualStyleBackColor = True
        '
        'T_hexvaluehi
        '
        Me.T_hexvaluehi.Location = New System.Drawing.Point(174, 34)
        Me.T_hexvaluehi.Name = "T_hexvaluehi"
        Me.T_hexvaluehi.Size = New System.Drawing.Size(46, 20)
        Me.T_hexvaluehi.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Value (hex)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Address (hex)"
        '
        'T_hexaddr
        '
        Me.T_hexaddr.Location = New System.Drawing.Point(17, 34)
        Me.T_hexaddr.Name = "T_hexaddr"
        Me.T_hexaddr.Size = New System.Drawing.Size(129, 20)
        Me.T_hexaddr.TabIndex = 0
        '
        'C_HOX
        '
        Me.C_HOX.AutoSize = True
        Me.C_HOX.Location = New System.Drawing.Point(17, 26)
        Me.C_HOX.Name = "C_HOX"
        Me.C_HOX.Size = New System.Drawing.Size(110, 17)
        Me.C_HOX.TabIndex = 43
        Me.C_HOX.Text = "Oxy sensor on/off"
        Me.C_HOX.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.C_DatalogO2Sensor)
        Me.GroupBox1.Controls.Add(Me.C_EXC)
        Me.GroupBox1.Controls.Add(Me.C_FastBaudRate)
        Me.GroupBox1.Controls.Add(Me.C_EVAP)
        Me.GroupBox1.Controls.Add(Me.C_PAIR)
        Me.GroupBox1.Controls.Add(Me.C_HOX)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 157)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Misc Settings"
        '
        'C_DatalogO2Sensor
        '
        Me.C_DatalogO2Sensor.AutoSize = True
        Me.C_DatalogO2Sensor.Location = New System.Drawing.Point(17, 114)
        Me.C_DatalogO2Sensor.Name = "C_DatalogO2Sensor"
        Me.C_DatalogO2Sensor.Size = New System.Drawing.Size(116, 17)
        Me.C_DatalogO2Sensor.TabIndex = 47
        Me.C_DatalogO2Sensor.Text = "Datalog O2 Sensor"
        Me.C_DatalogO2Sensor.UseVisualStyleBackColor = True
        '
        'C_EXC
        '
        Me.C_EXC.AutoSize = True
        Me.C_EXC.Location = New System.Drawing.Point(17, 94)
        Me.C_EXC.Name = "C_EXC"
        Me.C_EXC.Size = New System.Drawing.Size(79, 17)
        Me.C_EXC.TabIndex = 46
        Me.C_EXC.Text = "EXC on/off"
        Me.C_EXC.UseVisualStyleBackColor = True
        '
        'C_EVAP
        '
        Me.C_EVAP.AutoSize = True
        Me.C_EVAP.Location = New System.Drawing.Point(17, 71)
        Me.C_EVAP.Name = "C_EVAP"
        Me.C_EVAP.Size = New System.Drawing.Size(83, 17)
        Me.C_EVAP.TabIndex = 45
        Me.C_EVAP.Text = "Evap on/off"
        Me.C_EVAP.UseVisualStyleBackColor = True
        '
        'C_PAIR
        '
        Me.C_PAIR.AutoSize = True
        Me.C_PAIR.Location = New System.Drawing.Point(17, 49)
        Me.C_PAIR.Name = "C_PAIR"
        Me.C_PAIR.Size = New System.Drawing.Size(76, 17)
        Me.C_PAIR.TabIndex = 44
        Me.C_PAIR.Text = "Pair on/off"
        Me.C_PAIR.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(266, 262)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "LCK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label1)
        Me.GroupBox9.Controls.Add(Me.B_Inj_Bal_Map)
        Me.GroupBox9.Controls.Add(Me.Label10)
        Me.GroupBox9.Controls.Add(Me.B_STP_Map)
        Me.GroupBox9.Controls.Add(Me.Label7)
        Me.GroupBox9.Location = New System.Drawing.Point(193, 12)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(214, 148)
        Me.GroupBox9.TabIndex = 45
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Misc maps"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Misc maps untested"
        '
        'B_Inj_Bal_Map
        '
        Me.B_Inj_Bal_Map.Location = New System.Drawing.Point(111, 62)
        Me.B_Inj_Bal_Map.Name = "B_Inj_Bal_Map"
        Me.B_Inj_Bal_Map.Size = New System.Drawing.Size(80, 23)
        Me.B_Inj_Bal_Map.TabIndex = 4
        Me.B_Inj_Bal_Map.Text = "Inj Bal map editing"
        Me.B_Inj_Bal_Map.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Inj Bal map editing"
        '
        'B_STP_Map
        '
        Me.B_STP_Map.Location = New System.Drawing.Point(111, 28)
        Me.B_STP_Map.Name = "B_STP_Map"
        Me.B_STP_Map.Size = New System.Drawing.Size(80, 23)
        Me.B_STP_Map.TabIndex = 1
        Me.B_STP_Map.Text = "STP map editing"
        Me.B_STP_Map.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "STP map editing"
        '
        'C_FastBaudRate
        '
        Me.C_FastBaudRate.AutoSize = True
        Me.C_FastBaudRate.Location = New System.Drawing.Point(17, 133)
        Me.C_FastBaudRate.Name = "C_FastBaudRate"
        Me.C_FastBaudRate.Size = New System.Drawing.Size(100, 17)
        Me.C_FastBaudRate.TabIndex = 46
        Me.C_FastBaudRate.Text = "Fast Baud Rate"
        Me.C_FastBaudRate.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(37, 290)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 23)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Reset Blocks"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(186, 290)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 48
        Me.Button3.Text = "Set TPS"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BKingAdvSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 176)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BKingAdvSettings"
        Me.Text = "ECUeditor Bking Advanced settings"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents T_hexvaluehi As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_hexaddr As System.Windows.Forms.TextBox
    Friend WithEvents B_WRITE As System.Windows.Forms.Button
    Friend WithEvents C_HOX As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents C_EVAP As System.Windows.Forms.CheckBox
    Friend WithEvents C_PAIR As System.Windows.Forms.CheckBox
    Friend WithEvents C_EXC As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents B_Inj_Bal_Map As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents B_STP_Map As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C_DatalogO2Sensor As System.Windows.Forms.CheckBox
    Friend WithEvents C_FastBaudRate As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
