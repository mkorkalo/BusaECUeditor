<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerifyInProgress
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
        Me.ProgressBar_Verify = New System.Windows.Forms.ProgressBar
        Me.L_Txt = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ProgressBar_Verify
        '
        Me.ProgressBar_Verify.Location = New System.Drawing.Point(19, 30)
        Me.ProgressBar_Verify.Name = "ProgressBar_Verify"
        Me.ProgressBar_Verify.Size = New System.Drawing.Size(394, 24)
        Me.ProgressBar_Verify.Step = 1
        Me.ProgressBar_Verify.TabIndex = 0
        '
        'L_Txt
        '
        Me.L_Txt.AutoSize = True
        Me.L_Txt.Location = New System.Drawing.Point(20, 6)
        Me.L_Txt.Name = "L_Txt"
        Me.L_Txt.Size = New System.Drawing.Size(30, 13)
        Me.L_Txt.TabIndex = 1
        Me.L_Txt.Text = "L_txt"
        '
        'Verifyinprogress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 73)
        Me.Controls.Add(Me.L_Txt)
        Me.Controls.Add(Me.ProgressBar_Verify)
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
    Friend WithEvents ProgressBar_Verify As System.Windows.Forms.ProgressBar
    Friend WithEvents L_Txt As System.Windows.Forms.Label

End Class
