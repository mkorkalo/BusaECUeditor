<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8enginedatalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.L_datalog = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.L_record = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.B_Clear = New System.Windows.Forms.Button
        Me.LED_RPM = New LxControl.LxLedControl
        Me.LED_TPS = New LxControl.LxLedControl
        Me.LED_IAP = New LxControl.LxLedControl
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.B_rerun = New System.Windows.Forms.Button
        CType(Me.LED_RPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_TPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_IAP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(423, 423)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 428)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "This display is under development"
        '
        'L_datalog
        '
        Me.L_datalog.FormattingEnabled = True
        Me.L_datalog.Location = New System.Drawing.Point(324, 43)
        Me.L_datalog.Name = "L_datalog"
        Me.L_datalog.Size = New System.Drawing.Size(171, 355)
        Me.L_datalog.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(321, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "RPM"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(358, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "TPS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(392, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "IAP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(422, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "AFR"
        '
        'L_record
        '
        Me.L_record.AutoSize = True
        Me.L_record.Font = New System.Drawing.Font("Wingdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.L_record.ForeColor = System.Drawing.Color.Firebrick
        Me.L_record.Location = New System.Drawing.Point(469, 5)
        Me.L_record.Name = "L_record"
        Me.L_record.Size = New System.Drawing.Size(26, 23)
        Me.L_record.TabIndex = 103
        Me.L_record.Text = "l"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(373, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Active > 1500RPM"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(456, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Boost"
        '
        'B_Clear
        '
        Me.B_Clear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.B_Clear.Location = New System.Drawing.Point(349, 423)
        Me.B_Clear.Name = "B_Clear"
        Me.B_Clear.Size = New System.Drawing.Size(67, 23)
        Me.B_Clear.TabIndex = 106
        Me.B_Clear.Text = "Clear"
        '
        'LED_RPM
        '
        Me.LED_RPM.BackColor = System.Drawing.Color.Transparent
        Me.LED_RPM.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_RPM.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_RPM.BevelRate = 0.5!
        Me.LED_RPM.FadedColor = System.Drawing.Color.Transparent
        Me.LED_RPM.ForeColor = System.Drawing.Color.Black
        Me.LED_RPM.HighlightOpaque = CType(50, Byte)
        Me.LED_RPM.Location = New System.Drawing.Point(97, 19)
        Me.LED_RPM.Name = "LED_RPM"
        Me.LED_RPM.Size = New System.Drawing.Size(129, 61)
        Me.LED_RPM.TabIndex = 107
        Me.LED_RPM.Text = "-"
        Me.LED_RPM.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_RPM.TotalCharCount = 4
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
        Me.LED_TPS.Location = New System.Drawing.Point(97, 86)
        Me.LED_TPS.Name = "LED_TPS"
        Me.LED_TPS.Size = New System.Drawing.Size(129, 61)
        Me.LED_TPS.TabIndex = 108
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
        Me.LED_IAP.Location = New System.Drawing.Point(97, 153)
        Me.LED_IAP.Name = "LED_IAP"
        Me.LED_IAP.Size = New System.Drawing.Size(129, 61)
        Me.LED_IAP.TabIndex = 109
        Me.LED_IAP.Text = "-"
        Me.LED_IAP.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_IAP.TotalCharCount = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 24)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "RPM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 24)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "TPS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 24)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "IAP"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.LED_IAP)
        Me.GroupBox1.Controls.Add(Me.LED_TPS)
        Me.GroupBox1.Controls.Add(Me.LED_RPM)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 215)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Logged data"
        '
        'B_rerun
        '
        Me.B_rerun.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.B_rerun.Location = New System.Drawing.Point(246, 423)
        Me.B_rerun.Name = "B_rerun"
        Me.B_rerun.Size = New System.Drawing.Size(97, 23)
        Me.B_rerun.TabIndex = 116
        Me.B_rerun.Text = "Stop logging"
        '
        'K8enginedatalog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 475)
        Me.Controls.Add(Me.B_rerun)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.B_Clear)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.L_record)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.L_datalog)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8enginedatalog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa Ecueditor2 - Engine Datalog"
        CType(Me.LED_RPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_TPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_IAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L_datalog As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents L_record As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents B_Clear As System.Windows.Forms.Button
    Friend WithEvents LED_RPM As LxControl.LxLedControl
    Friend WithEvents LED_TPS As LxControl.LxLedControl
    Friend WithEvents LED_IAP As LxControl.LxLedControl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents B_rerun As System.Windows.Forms.Button

End Class
