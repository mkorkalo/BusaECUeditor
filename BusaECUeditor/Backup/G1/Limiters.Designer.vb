<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Limiters
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Limiters))
        Me.C_TopSpeedLimiter = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.C_RPM = New System.Windows.Forms.ComboBox
        Me.C_Hardcut = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.B_Close = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'C_TopSpeedLimiter
        '
        Me.C_TopSpeedLimiter.AutoSize = True
        Me.C_TopSpeedLimiter.Location = New System.Drawing.Point(116, 57)
        Me.C_TopSpeedLimiter.Name = "C_TopSpeedLimiter"
        Me.C_TopSpeedLimiter.Size = New System.Drawing.Size(15, 14)
        Me.C_TopSpeedLimiter.TabIndex = 19
        Me.C_TopSpeedLimiter.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Top speed limiter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "RPM limiter"
        '
        'C_RPM
        '
        Me.C_RPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_RPM.Enabled = False
        Me.C_RPM.FormattingEnabled = True
        Me.C_RPM.Location = New System.Drawing.Point(116, 18)
        Me.C_RPM.Name = "C_RPM"
        Me.C_RPM.Size = New System.Drawing.Size(121, 21)
        Me.C_RPM.TabIndex = 16
        '
        'C_Hardcut
        '
        Me.C_Hardcut.AutoSize = True
        Me.C_Hardcut.Location = New System.Drawing.Point(116, 89)
        Me.C_Hardcut.Name = "C_Hardcut"
        Me.C_Hardcut.Size = New System.Drawing.Size(15, 14)
        Me.C_Hardcut.TabIndex = 21
        Me.C_Hardcut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Softcut or Hardcut"
        '
        'B_Close
        '
        Me.B_Close.Location = New System.Drawing.Point(294, 90)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(92, 26)
        Me.B_Close.TabIndex = 23
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'Limiters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 126)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_Hardcut)
        Me.Controls.Add(Me.C_TopSpeedLimiter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.C_RPM)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Limiters"
        Me.Text = "ECUeditor Limiters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_TopSpeedLimiter As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents C_RPM As System.Windows.Forms.ComboBox
    Friend WithEvents C_Hardcut As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_Close As System.Windows.Forms.Button
End Class
