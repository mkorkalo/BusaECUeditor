<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8boostfuel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8boostfuel))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.C_boostfuel_activation = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.L_boostfuelver = New System.Windows.Forms.Label
        Me.D_boostfuel = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.LED_BOOST = New LxControl.LxLedControl
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.D_duty = New System.Windows.Forms.DataGridView
        Me.L_solenoid_control = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.C_solenoidcontrol = New System.Windows.Forms.CheckBox
        Me.D_solenoidcontrol = New System.Windows.Forms.GroupBox
        Me.C_bleed = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.G_boosttable = New System.Windows.Forms.GroupBox
        Me.B_Apply_Map = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.T_overboost = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.C_fueladd = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.K8boostfuelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.D_boostfuel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_BOOST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_duty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.D_solenoidcontrol.SuspendLayout()
        Me.G_boosttable.SuspendLayout()
        CType(Me.K8boostfuelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C_boostfuel_activation
        '
        Me.C_boostfuel_activation.AutoSize = True
        Me.C_boostfuel_activation.Location = New System.Drawing.Point(132, 22)
        Me.C_boostfuel_activation.Name = "C_boostfuel_activation"
        Me.C_boostfuel_activation.Size = New System.Drawing.Size(75, 17)
        Me.C_boostfuel_activation.TabIndex = 1
        Me.C_boostfuel_activation.Text = "Not active"
        Me.C_boostfuel_activation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Boostfuel activation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(495, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Module  v           ready for testing"
        '
        'L_boostfuelver
        '
        Me.L_boostfuelver.AutoSize = True
        Me.L_boostfuelver.Location = New System.Drawing.Point(546, 39)
        Me.L_boostfuelver.Name = "L_boostfuelver"
        Me.L_boostfuelver.Size = New System.Drawing.Size(25, 13)
        Me.L_boostfuelver.TabIndex = 42
        Me.L_boostfuelver.Text = "000"
        '
        'D_boostfuel
        '
        Me.D_boostfuel.AllowUserToAddRows = False
        Me.D_boostfuel.AllowUserToDeleteRows = False
        Me.D_boostfuel.BackgroundColor = System.Drawing.SystemColors.Control
        Me.D_boostfuel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_boostfuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_boostfuel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_boostfuel.Location = New System.Drawing.Point(6, 17)
        Me.D_boostfuel.Name = "D_boostfuel"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.D_boostfuel.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.D_boostfuel.Size = New System.Drawing.Size(624, 267)
        Me.D_boostfuel.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(398, 15)
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
        Me.LED_BOOST.Location = New System.Drawing.Point(233, 10)
        Me.LED_BOOST.Name = "LED_BOOST"
        Me.LED_BOOST.Size = New System.Drawing.Size(120, 55)
        Me.LED_BOOST.TabIndex = 73
        Me.LED_BOOST.Text = "-"
        Me.LED_BOOST.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_BOOST.TotalCharCount = 4
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'D_duty
        '
        Me.D_duty.AllowUserToAddRows = False
        Me.D_duty.AllowUserToDeleteRows = False
        Me.D_duty.BackgroundColor = System.Drawing.SystemColors.Control
        Me.D_duty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_duty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_duty.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_duty.Location = New System.Drawing.Point(8, 46)
        Me.D_duty.Name = "D_duty"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.D_duty.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.D_duty.Size = New System.Drawing.Size(622, 156)
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
        Me.Label4.Location = New System.Drawing.Point(19, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Solenoid control"
        '
        'C_solenoidcontrol
        '
        Me.C_solenoidcontrol.AutoSize = True
        Me.C_solenoidcontrol.Location = New System.Drawing.Point(132, 38)
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
        Me.D_solenoidcontrol.Location = New System.Drawing.Point(12, 448)
        Me.D_solenoidcontrol.Name = "D_solenoidcontrol"
        Me.D_solenoidcontrol.Size = New System.Drawing.Size(663, 219)
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
        Me.G_boosttable.Controls.Add(Me.B_Apply_Map)
        Me.G_boosttable.Controls.Add(Me.D_boostfuel)
        Me.G_boosttable.Location = New System.Drawing.Point(13, 117)
        Me.G_boosttable.Name = "G_boosttable"
        Me.G_boosttable.Size = New System.Drawing.Size(662, 325)
        Me.G_boosttable.TabIndex = 81
        Me.G_boosttable.TabStop = False
        Me.G_boosttable.Text = "Fuel% to add per rpm/boost area"
        '
        'B_Apply_Map
        '
        Me.B_Apply_Map.Location = New System.Drawing.Point(574, 298)
        Me.B_Apply_Map.Name = "B_Apply_Map"
        Me.B_Apply_Map.Size = New System.Drawing.Size(82, 21)
        Me.B_Apply_Map.TabIndex = 87
        Me.B_Apply_Map.Text = "Apply Map"
        Me.B_Apply_Map.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 92)
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
        Me.T_overboost.Location = New System.Drawing.Point(132, 81)
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
        Me.Label7.Location = New System.Drawing.Point(19, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Fuelling type"
        '
        'C_fueladd
        '
        Me.C_fueladd.AutoSize = True
        Me.C_fueladd.Location = New System.Drawing.Point(132, 55)
        Me.C_fueladd.Name = "C_fueladd"
        Me.C_fueladd.Size = New System.Drawing.Size(116, 17)
        Me.C_fueladd.TabIndex = 85
        Me.C_fueladd.Text = "Adding to fuelpulse"
        Me.C_fueladd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(587, 460)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 22)
        Me.Button1.TabIndex = 86
        Me.Button1.Text = "Help"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'K8boostfuelBindingSource
        '
        Me.K8boostfuelBindingSource.DataSource = GetType(BusaECUeditor.K8boostfuel)
        '
        'K8boostfuel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 655)
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
        Me.Controls.Add(Me.C_boostfuel_activation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8boostfuel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa K8- Boostfuel module"
        CType(Me.D_boostfuel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_BOOST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_duty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.D_solenoidcontrol.ResumeLayout(False)
        Me.D_solenoidcontrol.PerformLayout()
        Me.G_boosttable.ResumeLayout(False)
        CType(Me.K8boostfuelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_boostfuel_activation As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L_boostfuelver As System.Windows.Forms.Label
    Friend WithEvents D_boostfuel As System.Windows.Forms.DataGridView
    Friend WithEvents K8boostfuelBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LED_BOOST As LxControl.LxLedControl
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
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
    Friend WithEvents B_Apply_Map As System.Windows.Forms.Button

End Class
