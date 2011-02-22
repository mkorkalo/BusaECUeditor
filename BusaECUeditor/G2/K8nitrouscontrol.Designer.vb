<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8nitrouscontrol
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8nitrouscontrol))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.C_nitrouscontrol_activation = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.L_nitrouscontrolver = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.K8nitrouscontrolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.D_fuel_nitrouscontrol = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.R_nitrous_on = New System.Windows.Forms.RadioButton
        Me.L_solenoid_status = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.G_gencontrol = New System.Windows.Forms.GroupBox
        Me.C_DSMSELECTED = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.C_buttonactive = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.C_wetkit = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.L_TPS = New System.Windows.Forms.Label
        Me.C_RUNHZ = New System.Windows.Forms.ComboBox
        Me.C_RPM_HIGH = New System.Windows.Forms.ComboBox
        Me.C_RPM_LOW = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Linklabel_program_homepage = New System.Windows.Forms.LinkLabel
        CType(Me.K8nitrouscontrolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D_fuel_nitrouscontrol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.G_gencontrol.SuspendLayout()
        Me.SuspendLayout()
        '
        'C_nitrouscontrol_activation
        '
        Me.C_nitrouscontrol_activation.AutoSize = True
        Me.C_nitrouscontrol_activation.Location = New System.Drawing.Point(145, 36)
        Me.C_nitrouscontrol_activation.Name = "C_nitrouscontrol_activation"
        Me.C_nitrouscontrol_activation.Size = New System.Drawing.Size(75, 17)
        Me.C_nitrouscontrol_activation.TabIndex = 1
        Me.C_nitrouscontrol_activation.Text = "Not active"
        Me.C_nitrouscontrol_activation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nitrouscontrol activation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(352, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Module  v           ready for testing"
        '
        'L_nitrouscontrolver
        '
        Me.L_nitrouscontrolver.AutoSize = True
        Me.L_nitrouscontrolver.Location = New System.Drawing.Point(407, 37)
        Me.L_nitrouscontrolver.Name = "L_nitrouscontrolver"
        Me.L_nitrouscontrolver.Size = New System.Drawing.Size(25, 13)
        Me.L_nitrouscontrolver.TabIndex = 42
        Me.L_nitrouscontrolver.Text = "000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(295, 24)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Gen2 ECU Nitrous control module"
       '
        'D_fuel_nitrouscontrol
        '
        Me.D_fuel_nitrouscontrol.AllowUserToAddRows = False
        Me.D_fuel_nitrouscontrol.AllowUserToDeleteRows = False
        Me.D_fuel_nitrouscontrol.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.D_fuel_nitrouscontrol.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_fuel_nitrouscontrol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_fuel_nitrouscontrol.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_fuel_nitrouscontrol.Location = New System.Drawing.Point(6, 19)
        Me.D_fuel_nitrouscontrol.Name = "D_fuel_nitrouscontrol"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.D_fuel_nitrouscontrol.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.D_fuel_nitrouscontrol.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.D_fuel_nitrouscontrol.Size = New System.Drawing.Size(374, 124)
        Me.D_fuel_nitrouscontrol.TabIndex = 76
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.D_fuel_nitrouscontrol)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 243)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 153)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gear based nitrous and fuel control settings"
        '
        'R_nitrous_on
        '
        Me.R_nitrous_on.AutoSize = True
        Me.R_nitrous_on.Location = New System.Drawing.Point(491, 53)
        Me.R_nitrous_on.Name = "R_nitrous_on"
        Me.R_nitrous_on.Size = New System.Drawing.Size(14, 13)
        Me.R_nitrous_on.TabIndex = 78
        Me.R_nitrous_on.TabStop = True
        Me.R_nitrous_on.UseVisualStyleBackColor = True
        '
        'L_solenoid_status
        '
        Me.L_solenoid_status.AutoSize = True
        Me.L_solenoid_status.Location = New System.Drawing.Point(352, 53)
        Me.L_solenoid_status.Name = "L_solenoid_status"
        Me.L_solenoid_status.Size = New System.Drawing.Size(111, 13)
        Me.L_solenoid_status.TabIndex = 79
        Me.L_solenoid_status.Text = "DSM activation status"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(443, 355)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 29)
        Me.Button1.TabIndex = 80
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Nitrous on RPM"
        '
        'G_gencontrol
        '
        Me.G_gencontrol.Controls.Add(Me.C_DSMSELECTED)
        Me.G_gencontrol.Controls.Add(Me.Label12)
        Me.G_gencontrol.Controls.Add(Me.C_buttonactive)
        Me.G_gencontrol.Controls.Add(Me.Label11)
        Me.G_gencontrol.Controls.Add(Me.C_wetkit)
        Me.G_gencontrol.Controls.Add(Me.Label10)
        Me.G_gencontrol.Controls.Add(Me.L_TPS)
        Me.G_gencontrol.Controls.Add(Me.C_RUNHZ)
        Me.G_gencontrol.Controls.Add(Me.C_RPM_HIGH)
        Me.G_gencontrol.Controls.Add(Me.C_RPM_LOW)
        Me.G_gencontrol.Controls.Add(Me.Label7)
        Me.G_gencontrol.Controls.Add(Me.Label6)
        Me.G_gencontrol.Controls.Add(Me.Label5)
        Me.G_gencontrol.Controls.Add(Me.Label4)
        Me.G_gencontrol.Location = New System.Drawing.Point(12, 84)
        Me.G_gencontrol.Name = "G_gencontrol"
        Me.G_gencontrol.Size = New System.Drawing.Size(420, 153)
        Me.G_gencontrol.TabIndex = 82
        Me.G_gencontrol.TabStop = False
        Me.G_gencontrol.Text = "General nitrous controller information"
        '
        'C_DSMSELECTED
        '
        Me.C_DSMSELECTED.AutoSize = True
        Me.C_DSMSELECTED.Location = New System.Drawing.Point(309, 99)
        Me.C_DSMSELECTED.Name = "C_DSMSELECTED"
        Me.C_DSMSELECTED.Size = New System.Drawing.Size(78, 17)
        Me.C_DSMSELECTED.TabIndex = 95
        Me.C_DSMSELECTED.Text = "DSM lower"
        Me.C_DSMSELECTED.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(215, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "DSM button"
        '
        'C_buttonactive
        '
        Me.C_buttonactive.AutoSize = True
        Me.C_buttonactive.Location = New System.Drawing.Point(309, 76)
        Me.C_buttonactive.Name = "C_buttonactive"
        Me.C_buttonactive.Size = New System.Drawing.Size(75, 17)
        Me.C_buttonactive.TabIndex = 93
        Me.C_buttonactive.Text = "Not active"
        Me.C_buttonactive.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(215, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Activation type"
        '
        'C_wetkit
        '
        Me.C_wetkit.AutoSize = True
        Me.C_wetkit.Location = New System.Drawing.Point(309, 53)
        Me.C_wetkit.Name = "C_wetkit"
        Me.C_wetkit.Size = New System.Drawing.Size(75, 17)
        Me.C_wetkit.TabIndex = 85
        Me.C_wetkit.Text = "Not active"
        Me.C_wetkit.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(214, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Wet type pulsing"
        '
        'L_TPS
        '
        Me.L_TPS.AutoSize = True
        Me.L_TPS.Location = New System.Drawing.Point(152, 81)
        Me.L_TPS.Name = "L_TPS"
        Me.L_TPS.Size = New System.Drawing.Size(28, 13)
        Me.L_TPS.TabIndex = 88
        Me.L_TPS.Text = "TPS"
        '
        'C_RUNHZ
        '
        Me.C_RUNHZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_RUNHZ.FormattingEnabled = True
        Me.C_RUNHZ.Location = New System.Drawing.Point(307, 19)
        Me.C_RUNHZ.Name = "C_RUNHZ"
        Me.C_RUNHZ.Size = New System.Drawing.Size(75, 21)
        Me.C_RUNHZ.TabIndex = 87
        '
        'C_RPM_HIGH
        '
        Me.C_RPM_HIGH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_RPM_HIGH.FormattingEnabled = True
        Me.C_RPM_HIGH.Location = New System.Drawing.Point(105, 46)
        Me.C_RPM_HIGH.Name = "C_RPM_HIGH"
        Me.C_RPM_HIGH.Size = New System.Drawing.Size(75, 21)
        Me.C_RPM_HIGH.TabIndex = 86
        '
        'C_RPM_LOW
        '
        Me.C_RPM_LOW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_RPM_LOW.FormattingEnabled = True
        Me.C_RPM_LOW.Location = New System.Drawing.Point(105, 19)
        Me.C_RPM_LOW.Name = "C_RPM_LOW"
        Me.C_RPM_LOW.Size = New System.Drawing.Size(75, 21)
        Me.C_RPM_LOW.TabIndex = 85
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(214, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Solenoid duty Hz"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Nitrous on TPS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Nitrous off RPM"
        '
        'Linklabel_program_homepage
        '
        Me.Linklabel_program_homepage.ActiveLinkColor = System.Drawing.Color.DimGray
        Me.Linklabel_program_homepage.AutoSize = True
        Me.Linklabel_program_homepage.LinkColor = System.Drawing.Color.Black
        Me.Linklabel_program_homepage.Location = New System.Drawing.Point(9, 425)
        Me.Linklabel_program_homepage.Name = "Linklabel_program_homepage"
        Me.Linklabel_program_homepage.Size = New System.Drawing.Size(215, 13)
        Me.Linklabel_program_homepage.TabIndex = 84
        Me.Linklabel_program_homepage.TabStop = True
        Me.Linklabel_program_homepage.Text = "Click here to visit: http//www.ecueditor.com"
        '
        'K8nitrouscontrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 473)
        Me.Controls.Add(Me.Linklabel_program_homepage)
        Me.Controls.Add(Me.G_gencontrol)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.L_solenoid_status)
        Me.Controls.Add(Me.R_nitrous_on)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.L_nitrouscontrolver)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_nitrouscontrol_activation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8nitrouscontrol"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa ECUeditor K8- Nitrous control"
        CType(Me.K8nitrouscontrolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D_fuel_nitrouscontrol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.G_gencontrol.ResumeLayout(False)
        Me.G_gencontrol.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_nitrouscontrol_activation As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L_nitrouscontrolver As System.Windows.Forms.Label
    Friend WithEvents K8nitrouscontrolBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents D_fuel_nitrouscontrol As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents R_nitrous_on As System.Windows.Forms.RadioButton
    Friend WithEvents L_solenoid_status As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents G_gencontrol As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents C_RPM_LOW As System.Windows.Forms.ComboBox
    Friend WithEvents L_TPS As System.Windows.Forms.Label
    Friend WithEvents C_RUNHZ As System.Windows.Forms.ComboBox
    Friend WithEvents C_RPM_HIGH As System.Windows.Forms.ComboBox
    Friend WithEvents Linklabel_program_homepage As System.Windows.Forms.LinkLabel
    Friend WithEvents C_wetkit As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents C_buttonactive As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents C_DSMSELECTED As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
