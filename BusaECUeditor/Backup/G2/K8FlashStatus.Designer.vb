<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8FlashStatus
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
        Me.Progressbar_Flashstatus = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.fmode = New System.Windows.Forms.Label
        Me.L_elapsedtime = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Progressbar_Flashstatus
        '
        Me.Progressbar_Flashstatus.BackColor = System.Drawing.Color.Yellow
        Me.Progressbar_Flashstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Progressbar_Flashstatus.Location = New System.Drawing.Point(18, 58)
        Me.Progressbar_Flashstatus.MarqueeAnimationSpeed = 50
        Me.Progressbar_Flashstatus.Name = "Progressbar_Flashstatus"
        Me.Progressbar_Flashstatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Progressbar_Flashstatus.Size = New System.Drawing.Size(419, 25)
        Me.Progressbar_Flashstatus.Step = 1
        Me.Progressbar_Flashstatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Progressbar_Flashstatus.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Flashmode"
        '
        'fmode
        '
        Me.fmode.AutoSize = True
        Me.fmode.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fmode.ForeColor = System.Drawing.Color.Black
        Me.fmode.Location = New System.Drawing.Point(125, 20)
        Me.fmode.Name = "fmode"
        Me.fmode.Size = New System.Drawing.Size(70, 22)
        Me.fmode.TabIndex = 2
        Me.fmode.Text = "Normal"
        '
        'L_elapsedtime
        '
        Me.L_elapsedtime.AutoSize = True
        Me.L_elapsedtime.Location = New System.Drawing.Point(22, 99)
        Me.L_elapsedtime.Name = "L_elapsedtime"
        Me.L_elapsedtime.Size = New System.Drawing.Size(67, 13)
        Me.L_elapsedtime.TabIndex = 3
        Me.L_elapsedtime.Text = "Elapsed time"
        '
        'K8FlashStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 127)
        Me.ControlBox = False
        Me.Controls.Add(Me.L_elapsedtime)
        Me.Controls.Add(Me.fmode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Progressbar_Flashstatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8FlashStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "K8 Flashing Status"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Progressbar_Flashstatus As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fmode As System.Windows.Forms.Label
    Friend WithEvents L_elapsedtime As System.Windows.Forms.Label

End Class
