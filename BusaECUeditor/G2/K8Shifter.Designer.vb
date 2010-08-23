<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8shifter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8shifter))
        Me.C_shifter_activation = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.T_12000 = New System.Windows.Forms.TextBox
        Me.T_11000 = New System.Windows.Forms.TextBox
        Me.T_10000 = New System.Windows.Forms.TextBox
        Me.T_9000 = New System.Windows.Forms.TextBox
        Me.T_8000 = New System.Windows.Forms.TextBox
        Me.T_7000 = New System.Windows.Forms.TextBox
        Me.T_6000 = New System.Windows.Forms.TextBox
        Me.T_5000 = New System.Windows.Forms.TextBox
        Me.T_4000 = New System.Windows.Forms.TextBox
        Me.T_3000 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.C_killtime = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RPM456 = New System.Windows.Forms.ComboBox
        Me.RPM3 = New System.Windows.Forms.ComboBox
        Me.RPM2 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.RPM1 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.C_DSMactivation = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.C_igncut = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.C_Fuelcut = New System.Windows.Forms.CheckBox
        Me.L_killcountdelay = New System.Windows.Forms.Label
        Me.L_minkillactive = New System.Windows.Forms.Label
        Me.T_killcountdelay = New System.Windows.Forms.TextBox
        Me.T_minkillactive = New System.Windows.Forms.TextBox
        Me.L_shifterver = New System.Windows.Forms.Label
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C_shifter_activation
        '
        Me.C_shifter_activation.AutoSize = True
        Me.C_shifter_activation.Location = New System.Drawing.Point(132, 22)
        Me.C_shifter_activation.Name = "C_shifter_activation"
        Me.C_shifter_activation.Size = New System.Drawing.Size(106, 17)
        Me.C_shifter_activation.TabIndex = 1
        Me.C_shifter_activation.Text = "Shifter not active"
        Me.C_shifter_activation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Shifter activation"
        '
        'T_12000
        '
        Me.T_12000.Location = New System.Drawing.Point(265, 35)
        Me.T_12000.Name = "T_12000"
        Me.T_12000.Size = New System.Drawing.Size(35, 20)
        Me.T_12000.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.T_12000, "gear1 killtime")
        '
        'T_11000
        '
        Me.T_11000.Location = New System.Drawing.Point(306, 35)
        Me.T_11000.Name = "T_11000"
        Me.T_11000.Size = New System.Drawing.Size(35, 20)
        Me.T_11000.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.T_11000, "gear2 killtime")
        '
        'T_10000
        '
        Me.T_10000.Location = New System.Drawing.Point(347, 35)
        Me.T_10000.Name = "T_10000"
        Me.T_10000.Size = New System.Drawing.Size(35, 20)
        Me.T_10000.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.T_10000, "gear3 killtime")
        '
        'T_9000
        '
        Me.T_9000.Location = New System.Drawing.Point(388, 35)
        Me.T_9000.Name = "T_9000"
        Me.T_9000.Size = New System.Drawing.Size(35, 20)
        Me.T_9000.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.T_9000, "gear4 killtime")
        '
        'T_8000
        '
        Me.T_8000.Location = New System.Drawing.Point(429, 35)
        Me.T_8000.Name = "T_8000"
        Me.T_8000.Size = New System.Drawing.Size(35, 20)
        Me.T_8000.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.T_8000, "gear5 killtime")
        '
        'T_7000
        '
        Me.T_7000.Location = New System.Drawing.Point(470, 35)
        Me.T_7000.Name = "T_7000"
        Me.T_7000.Size = New System.Drawing.Size(35, 20)
        Me.T_7000.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.T_7000, "gear6 killtime, i.e. killtime if gear based on GPS sensor is not detected")
        '
        'T_6000
        '
        Me.T_6000.Location = New System.Drawing.Point(330, 548)
        Me.T_6000.Name = "T_6000"
        Me.T_6000.Size = New System.Drawing.Size(35, 20)
        Me.T_6000.TabIndex = 10
        '
        'T_5000
        '
        Me.T_5000.Location = New System.Drawing.Point(371, 548)
        Me.T_5000.Name = "T_5000"
        Me.T_5000.Size = New System.Drawing.Size(35, 20)
        Me.T_5000.TabIndex = 11
        '
        'T_4000
        '
        Me.T_4000.Location = New System.Drawing.Point(412, 548)
        Me.T_4000.Name = "T_4000"
        Me.T_4000.Size = New System.Drawing.Size(35, 20)
        Me.T_4000.TabIndex = 12
        '
        'T_3000
        '
        Me.T_3000.Location = New System.Drawing.Point(453, 548)
        Me.T_3000.Name = "T_3000"
        Me.T_3000.Size = New System.Drawing.Size(35, 20)
        Me.T_3000.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Kill time (~ms)"
        '
        'C_killtime
        '
        Me.C_killtime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_killtime.FormattingEnabled = True
        Me.C_killtime.Location = New System.Drawing.Point(121, 32)
        Me.C_killtime.MaxDropDownItems = 12
        Me.C_killtime.Name = "C_killtime"
        Me.C_killtime.Size = New System.Drawing.Size(85, 21)
        Me.C_killtime.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.C_killtime, "Set killtime for all gears")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(349, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Shifter module  v         ready for testing"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RPM456)
        Me.GroupBox2.Controls.Add(Me.RPM3)
        Me.GroupBox2.Controls.Add(Me.RPM2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.RPM1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.C_DSMactivation)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.C_igncut)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.C_Fuelcut)
        Me.GroupBox2.Controls.Add(Me.L_killcountdelay)
        Me.GroupBox2.Controls.Add(Me.L_minkillactive)
        Me.GroupBox2.Controls.Add(Me.T_killcountdelay)
        Me.GroupBox2.Controls.Add(Me.T_minkillactive)
        Me.GroupBox2.Controls.Add(Me.C_killtime)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.T_7000)
        Me.GroupBox2.Controls.Add(Me.T_8000)
        Me.GroupBox2.Controls.Add(Me.T_9000)
        Me.GroupBox2.Controls.Add(Me.T_10000)
        Me.GroupBox2.Controls.Add(Me.T_11000)
        Me.GroupBox2.Controls.Add(Me.T_12000)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(524, 191)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shifter settings"
        '
        'RPM456
        '
        Me.RPM456.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RPM456.Enabled = False
        Me.RPM456.FormattingEnabled = True
        Me.RPM456.Location = New System.Drawing.Point(440, 158)
        Me.RPM456.Name = "RPM456"
        Me.RPM456.Size = New System.Drawing.Size(68, 21)
        Me.RPM456.TabIndex = 56
        Me.ToolTip1.SetToolTip(Me.RPM456, "Gear456 autoshift RPM or minimum RPM after which shift can be activated")
        '
        'RPM3
        '
        Me.RPM3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RPM3.Enabled = False
        Me.RPM3.FormattingEnabled = True
        Me.RPM3.Location = New System.Drawing.Point(366, 158)
        Me.RPM3.Name = "RPM3"
        Me.RPM3.Size = New System.Drawing.Size(68, 21)
        Me.RPM3.TabIndex = 55
        Me.ToolTip1.SetToolTip(Me.RPM3, "Gear3 autoshift RPM or minimum RPM after which shift can be activated")
        '
        'RPM2
        '
        Me.RPM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RPM2.Enabled = False
        Me.RPM2.FormattingEnabled = True
        Me.RPM2.Location = New System.Drawing.Point(290, 158)
        Me.RPM2.Name = "RPM2"
        Me.RPM2.Size = New System.Drawing.Size(68, 21)
        Me.RPM2.TabIndex = 54
        Me.ToolTip1.SetToolTip(Me.RPM2, "Gear2 autoshift RPM or minimum RPM after which shift can be activated")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Activation mode"
        '
        'RPM1
        '
        Me.RPM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RPM1.Enabled = False
        Me.RPM1.FormattingEnabled = True
        Me.RPM1.Location = New System.Drawing.Point(212, 158)
        Me.RPM1.Name = "RPM1"
        Me.RPM1.Size = New System.Drawing.Size(68, 21)
        Me.RPM1.TabIndex = 52
        Me.ToolTip1.SetToolTip(Me.RPM1, "Gear1 autoshift RPM or minimum RPM after which shift can be activated")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 158)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 13)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Minimum / autoshift RPM"
        '
        'C_DSMactivation
        '
        Me.C_DSMactivation.AutoSize = True
        Me.C_DSMactivation.Location = New System.Drawing.Point(123, 132)
        Me.C_DSMactivation.Name = "C_DSMactivation"
        Me.C_DSMactivation.Size = New System.Drawing.Size(157, 17)
        Me.C_DSMactivation.TabIndex = 50
        Me.C_DSMactivation.Text = "DSM2 activated shift active"
        Me.ToolTip1.SetToolTip(Me.C_DSMactivation, "Shift kill activation method. Usually a shifter swicht in gear lever is used. Alt" & _
                "ernatively the DSM button activation can be used.")
        Me.C_DSMactivation.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(470, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Err killtime"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(428, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Gear5"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(387, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Gear4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(346, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Gear3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(305, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Gear2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(264, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Gear1"
        '
        'C_igncut
        '
        Me.C_igncut.AutoSize = True
        Me.C_igncut.Location = New System.Drawing.Point(123, 98)
        Me.C_igncut.Name = "C_igncut"
        Me.C_igncut.Size = New System.Drawing.Size(88, 17)
        Me.C_igncut.TabIndex = 43
        Me.C_igncut.Text = "Igncut active"
        Me.ToolTip1.SetToolTip(Me.C_igncut, "Shift kills also ignition, use this for faster more ""abrubt"" shift kill")
        Me.C_igncut.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Kill type"
        '
        'C_Fuelcut
        '
        Me.C_Fuelcut.AutoSize = True
        Me.C_Fuelcut.Location = New System.Drawing.Point(123, 75)
        Me.C_Fuelcut.Name = "C_Fuelcut"
        Me.C_Fuelcut.Size = New System.Drawing.Size(93, 17)
        Me.C_Fuelcut.TabIndex = 41
        Me.C_Fuelcut.Text = "Fuelcut active"
        Me.ToolTip1.SetToolTip(Me.C_Fuelcut, "Shift kills fuelcut, this should be always active")
        Me.C_Fuelcut.UseVisualStyleBackColor = True
        '
        'L_killcountdelay
        '
        Me.L_killcountdelay.AutoSize = True
        Me.L_killcountdelay.Location = New System.Drawing.Point(413, 79)
        Me.L_killcountdelay.Name = "L_killcountdelay"
        Me.L_killcountdelay.Size = New System.Drawing.Size(51, 13)
        Me.L_killcountdelay.TabIndex = 40
        Me.L_killcountdelay.Text = "Next shift"
        '
        'L_minkillactive
        '
        Me.L_minkillactive.AutoSize = True
        Me.L_minkillactive.Location = New System.Drawing.Point(314, 79)
        Me.L_minkillactive.Name = "L_minkillactive"
        Me.L_minkillactive.Size = New System.Drawing.Size(54, 13)
        Me.L_minkillactive.TabIndex = 39
        Me.L_minkillactive.Text = "Activation"
        '
        'T_killcountdelay
        '
        Me.T_killcountdelay.Location = New System.Drawing.Point(470, 76)
        Me.T_killcountdelay.Name = "T_killcountdelay"
        Me.T_killcountdelay.Size = New System.Drawing.Size(35, 20)
        Me.T_killcountdelay.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.T_killcountdelay, "Delay (in engine rounds) how long the program will wait until next shift is allow" & _
                "ed to avoid too fast consequent shifts")
        '
        'T_minkillactive
        '
        Me.T_minkillactive.Location = New System.Drawing.Point(373, 76)
        Me.T_minkillactive.Name = "T_minkillactive"
        Me.T_minkillactive.Size = New System.Drawing.Size(35, 20)
        Me.T_minkillactive.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.T_minkillactive, "How many engine rounds the shift activation switch needs to be depressed before k" & _
                "ill is activated")
        '
        'L_shifterver
        '
        Me.L_shifterver.AutoSize = True
        Me.L_shifterver.Location = New System.Drawing.Point(430, 22)
        Me.L_shifterver.Name = "L_shifterver"
        Me.L_shifterver.Size = New System.Drawing.Size(25, 13)
        Me.L_shifterver.TabIndex = 42
        Me.L_shifterver.Text = "000"
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 242)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(522, 339)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 43
        Me.PictureBox1.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'K8shifter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 587)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.L_shifterver)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_shifter_activation)
        Me.Controls.Add(Me.T_5000)
        Me.Controls.Add(Me.T_6000)
        Me.Controls.Add(Me.T_4000)
        Me.Controls.Add(Me.T_3000)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8shifter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa K8- Shiftkill module (fuelcut and ignitioncut)"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_shifter_activation As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_12000 As System.Windows.Forms.TextBox
    Friend WithEvents T_11000 As System.Windows.Forms.TextBox
    Friend WithEvents T_10000 As System.Windows.Forms.TextBox
    Friend WithEvents T_9000 As System.Windows.Forms.TextBox
    Friend WithEvents T_8000 As System.Windows.Forms.TextBox
    Friend WithEvents T_7000 As System.Windows.Forms.TextBox
    Friend WithEvents T_6000 As System.Windows.Forms.TextBox
    Friend WithEvents T_5000 As System.Windows.Forms.TextBox
    Friend WithEvents T_4000 As System.Windows.Forms.TextBox
    Friend WithEvents T_3000 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents C_killtime As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents T_killcountdelay As System.Windows.Forms.TextBox
    Friend WithEvents T_minkillactive As System.Windows.Forms.TextBox
    Friend WithEvents L_killcountdelay As System.Windows.Forms.Label
    Friend WithEvents L_minkillactive As System.Windows.Forms.Label
    Friend WithEvents L_shifterver As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents C_Fuelcut As System.Windows.Forms.CheckBox
    Friend WithEvents C_igncut As System.Windows.Forms.CheckBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents C_DSMactivation As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RPM1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RPM456 As System.Windows.Forms.ComboBox
    Friend WithEvents RPM3 As System.Windows.Forms.ComboBox
    Friend WithEvents RPM2 As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
