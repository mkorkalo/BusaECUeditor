<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogBoxCfg
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudLogStartDelay = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkEngineRunning = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudCoolantTemp = New System.Windows.Forms.NumericUpDown()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.nudLogStartDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCoolantTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(22, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Log Start Delay (sec)"
        '
        'nudLogStartDelay
        '
        Me.nudLogStartDelay.Enabled = False
        Me.nudLogStartDelay.Location = New System.Drawing.Point(239, 8)
        Me.nudLogStartDelay.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudLogStartDelay.Name = "nudLogStartDelay"
        Me.nudLogStartDelay.Size = New System.Drawing.Size(88, 20)
        Me.nudLogStartDelay.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(22, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Engine must be running for Logging to Start"
        '
        'chkEngineRunning
        '
        Me.chkEngineRunning.AutoSize = True
        Me.chkEngineRunning.Enabled = False
        Me.chkEngineRunning.Location = New System.Drawing.Point(239, 37)
        Me.chkEngineRunning.Name = "chkEngineRunning"
        Me.chkEngineRunning.Size = New System.Drawing.Size(15, 14)
        Me.chkEngineRunning.TabIndex = 3
        Me.chkEngineRunning.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(23, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Coolant Temperature > for logging to start"
        '
        'nudCoolantTemp
        '
        Me.nudCoolantTemp.Enabled = False
        Me.nudCoolantTemp.Location = New System.Drawing.Point(239, 62)
        Me.nudCoolantTemp.Name = "nudCoolantTemp"
        Me.nudCoolantTemp.Size = New System.Drawing.Size(88, 20)
        Me.nudCoolantTemp.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(91, 93)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(172, 93)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LogBoxCfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 123)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.nudCoolantTemp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkEngineRunning)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudLogStartDelay)
        Me.Controls.Add(Me.Label1)
        Me.Name = "LogBoxCfg"
        Me.Text = "Log Box Configuration"
        CType(Me.nudLogStartDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCoolantTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudLogStartDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkEngineRunning As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudCoolantTemp As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
