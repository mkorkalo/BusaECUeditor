<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Verifyinprogress
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
        Me.ProgressBar_verify = New System.Windows.Forms.ProgressBar
        Me.L_txt = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ProgressBar_verify
        '
        Me.ProgressBar_verify.Location = New System.Drawing.Point(19, 30)
        Me.ProgressBar_verify.Name = "ProgressBar_verify"
        Me.ProgressBar_verify.Size = New System.Drawing.Size(394, 24)
        Me.ProgressBar_verify.Step = 1
        Me.ProgressBar_verify.TabIndex = 0
        '
        'L_txt
        '
        Me.L_txt.AutoSize = True
        Me.L_txt.Location = New System.Drawing.Point(20, 6)
        Me.L_txt.Name = "L_txt"
        Me.L_txt.Size = New System.Drawing.Size(30, 13)
        Me.L_txt.TabIndex = 1
        Me.L_txt.Text = "L_txt"
        '
        'Verifyinprogress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 73)
        Me.Controls.Add(Me.L_txt)
        Me.Controls.Add(Me.ProgressBar_verify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Verifyinprogress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Verifyinprogress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar_verify As System.Windows.Forms.ProgressBar
    Friend WithEvents L_txt As System.Windows.Forms.Label

End Class
