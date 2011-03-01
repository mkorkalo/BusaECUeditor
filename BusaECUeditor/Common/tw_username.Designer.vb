<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tw_username
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
        Me.t_username = New System.Windows.Forms.TextBox()
        Me.B_save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter your username:"
        '
        't_username
        '
        Me.t_username.Location = New System.Drawing.Point(152, 35)
        Me.t_username.Name = "t_username"
        Me.t_username.Size = New System.Drawing.Size(115, 20)
        Me.t_username.TabIndex = 1
        '
        'B_save
        '
        Me.B_save.Location = New System.Drawing.Point(194, 76)
        Me.B_save.Name = "B_save"
        Me.B_save.Size = New System.Drawing.Size(73, 25)
        Me.B_save.TabIndex = 2
        Me.B_save.Text = "Save"
        Me.B_save.UseVisualStyleBackColor = True
        '
        'tw_username
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 113)
        Me.Controls.Add(Me.B_save)
        Me.Controls.Add(Me.t_username)
        Me.Controls.Add(Me.Label1)
        Me.Name = "tw_username"
        Me.Text = "Enter you username"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents t_username As System.Windows.Forms.TextBox
    Friend WithEvents B_save As System.Windows.Forms.Button
End Class
