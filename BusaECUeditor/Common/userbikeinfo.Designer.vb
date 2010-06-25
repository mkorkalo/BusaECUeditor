<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class userbikeinfo
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.T_webpage = New System.Windows.Forms.TextBox
        Me.C_RWHP = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.T_comments = New System.Windows.Forms.TextBox
        Me.C_head = New System.Windows.Forms.ComboBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.C_cams = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.C_injectors = New System.Windows.Forms.ComboBox
        Me.T_email = New System.Windows.Forms.TextBox
        Me.C_exhaust = New System.Windows.Forms.ComboBox
        Me.C_engine = New System.Windows.Forms.ComboBox
        Me.C_fuelpressure = New System.Windows.Forms.ComboBox
        Me.C_compression = New System.Windows.Forms.ComboBox
        Me.C_type = New System.Windows.Forms.ComboBox
        Me.C_model = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.B_Close = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.T_webpage)
        Me.GroupBox3.Controls.Add(Me.C_RWHP)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.T_comments)
        Me.GroupBox3.Controls.Add(Me.C_head)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.C_cams)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.C_injectors)
        Me.GroupBox3.Controls.Add(Me.T_email)
        Me.GroupBox3.Controls.Add(Me.C_exhaust)
        Me.GroupBox3.Controls.Add(Me.C_engine)
        Me.GroupBox3.Controls.Add(Me.C_fuelpressure)
        Me.GroupBox3.Controls.Add(Me.C_compression)
        Me.GroupBox3.Controls.Add(Me.C_type)
        Me.GroupBox3.Controls.Add(Me.C_model)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(516, 382)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Owner and bike info"
        '
        'T_webpage
        '
        Me.T_webpage.Location = New System.Drawing.Point(124, 91)
        Me.T_webpage.Name = "T_webpage"
        Me.T_webpage.Size = New System.Drawing.Size(378, 20)
        Me.T_webpage.TabIndex = 60
        '
        'C_RWHP
        '
        Me.C_RWHP.FormattingEnabled = True
        Me.C_RWHP.Items.AddRange(New Object() {"Stock (155)", "Piped (160-170)", "170-190", "190-210", "220-240", "240-270", "270-300", "330+"})
        Me.C_RWHP.Location = New System.Drawing.Point(70, 266)
        Me.C_RWHP.Name = "C_RWHP"
        Me.C_RWHP.Size = New System.Drawing.Size(150, 21)
        Me.C_RWHP.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Web page"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "RWHP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "This information is only used for map sharing"
        '
        'T_comments
        '
        Me.T_comments.Location = New System.Drawing.Point(124, 117)
        Me.T_comments.Multiline = True
        Me.T_comments.Name = "T_comments"
        Me.T_comments.Size = New System.Drawing.Size(378, 105)
        Me.T_comments.TabIndex = 56
        '
        'C_head
        '
        Me.C_head.FormattingEnabled = True
        Me.C_head.Items.AddRange(New Object() {"Stock", "Mildly ported", "Race ported", "Extreme"})
        Me.C_head.Location = New System.Drawing.Point(350, 293)
        Me.C_head.Name = "C_head"
        Me.C_head.Size = New System.Drawing.Size(152, 21)
        Me.C_head.TabIndex = 53
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(10, 68)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 13)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Owners email"
        '
        'C_cams
        '
        Me.C_cams.FormattingEnabled = True
        Me.C_cams.Items.AddRange(New Object() {"Stock", "Mild", "Race", "Outlaw"})
        Me.C_cams.Location = New System.Drawing.Point(70, 320)
        Me.C_cams.Name = "C_cams"
        Me.C_cams.Size = New System.Drawing.Size(150, 21)
        Me.C_cams.TabIndex = 52
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(11, 120)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 13)
        Me.Label27.TabIndex = 43
        Me.Label27.Text = "Comments"
        '
        'C_injectors
        '
        Me.C_injectors.FormattingEnabled = True
        Me.C_injectors.Items.AddRange(New Object() {"Stock (250cc)", "300cc", "350cc", "400cc", "450cc", "500cc", "550cc or more"})
        Me.C_injectors.Location = New System.Drawing.Point(70, 347)
        Me.C_injectors.Name = "C_injectors"
        Me.C_injectors.Size = New System.Drawing.Size(150, 21)
        Me.C_injectors.TabIndex = 51
        '
        'T_email
        '
        Me.T_email.Location = New System.Drawing.Point(124, 65)
        Me.T_email.Name = "T_email"
        Me.T_email.Size = New System.Drawing.Size(378, 20)
        Me.T_email.TabIndex = 55
        '
        'C_exhaust
        '
        Me.C_exhaust.FormattingEnabled = True
        Me.C_exhaust.Items.AddRange(New Object() {"Stock", "Slipons", "Full exhaust", "Full race exhaust", "Sidewinder", "Other"})
        Me.C_exhaust.Location = New System.Drawing.Point(70, 293)
        Me.C_exhaust.Name = "C_exhaust"
        Me.C_exhaust.Size = New System.Drawing.Size(150, 21)
        Me.C_exhaust.TabIndex = 50
        '
        'C_engine
        '
        Me.C_engine.FormattingEnabled = True
        Me.C_engine.Items.AddRange(New Object() {"Stock (1298)", "1397", "1441", "1500", "1700 or more"})
        Me.C_engine.Location = New System.Drawing.Point(70, 239)
        Me.C_engine.Name = "C_engine"
        Me.C_engine.Size = New System.Drawing.Size(150, 21)
        Me.C_engine.TabIndex = 49
        '
        'C_fuelpressure
        '
        Me.C_fuelpressure.FormattingEnabled = True
        Me.C_fuelpressure.Items.AddRange(New Object() {"Stock (2.8bar/41psi)", "3bar / 44psi", "3.5bar / 51psi", "4bar / 58psi", "4.5bar / 65psi", "5bar / 72psi or more"})
        Me.C_fuelpressure.Location = New System.Drawing.Point(350, 347)
        Me.C_fuelpressure.Name = "C_fuelpressure"
        Me.C_fuelpressure.Size = New System.Drawing.Size(152, 21)
        Me.C_fuelpressure.TabIndex = 48
        '
        'C_compression
        '
        Me.C_compression.FormattingEnabled = True
        Me.C_compression.Items.AddRange(New Object() {"Stock", "12:1", "13:1", "14:1", "15:1", "16:1 or greater"})
        Me.C_compression.Location = New System.Drawing.Point(350, 320)
        Me.C_compression.Name = "C_compression"
        Me.C_compression.Size = New System.Drawing.Size(152, 21)
        Me.C_compression.TabIndex = 47
        '
        'C_type
        '
        Me.C_type.FormattingEnabled = True
        Me.C_type.Items.AddRange(New Object() {"All motor", "All motor with Nitrous", "Turbo"})
        Me.C_type.Location = New System.Drawing.Point(350, 266)
        Me.C_type.Name = "C_type"
        Me.C_type.Size = New System.Drawing.Size(152, 21)
        Me.C_type.TabIndex = 46
        '
        'C_model
        '
        Me.C_model.FormattingEnabled = True
        Me.C_model.Items.AddRange(New Object() {"K2", "K3", "K4", "K5", "K6", "K7", "K1 with 32bit ECU", "Y  with 32bit ECU", "X  with 32bit ECU"})
        Me.C_model.Location = New System.Drawing.Point(350, 239)
        Me.C_model.Name = "C_model"
        Me.C_model.Size = New System.Drawing.Size(152, 21)
        Me.C_model.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(277, 350)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Fuel pressure"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 350)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Injectors"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 323)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(33, 13)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Cams"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(277, 323)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "Compression"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(277, 296)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 13)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "Head"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(277, 266)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Type"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 296)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 13)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = "Exhaust"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(277, 242)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(36, 13)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Model"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(10, 242)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Engine"
        '
        'B_Close
        '
        Me.B_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.B_Close.Location = New System.Drawing.Point(552, 347)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(90, 47)
        Me.B_Close.TabIndex = 37
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'userbikeinfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "userbikeinfo"
        Me.Text = "Bike and user info"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents C_head As System.Windows.Forms.ComboBox
    Friend WithEvents C_cams As System.Windows.Forms.ComboBox
    Friend WithEvents C_injectors As System.Windows.Forms.ComboBox
    Friend WithEvents C_exhaust As System.Windows.Forms.ComboBox
    Friend WithEvents C_engine As System.Windows.Forms.ComboBox
    Friend WithEvents C_fuelpressure As System.Windows.Forms.ComboBox
    Friend WithEvents C_compression As System.Windows.Forms.ComboBox
    Friend WithEvents C_type As System.Windows.Forms.ComboBox
    Friend WithEvents C_model As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents T_comments As System.Windows.Forms.TextBox
    Friend WithEvents T_email As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C_RWHP As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_webpage As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
