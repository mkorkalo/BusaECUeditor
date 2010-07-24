<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8gaugetools
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
        Me.C_tools_activation = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'C_tools_activation
        '
        Me.C_tools_activation.AutoSize = True
        Me.C_tools_activation.Location = New System.Drawing.Point(31, 26)
        Me.C_tools_activation.Name = "C_tools_activation"
        Me.C_tools_activation.Size = New System.Drawing.Size(129, 17)
        Me.C_tools_activation.TabIndex = 0
        Me.C_tools_activation.Text = "Normal gauges active"
        Me.C_tools_activation.UseVisualStyleBackColor = True
        '
        'K8gaugetools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.C_tools_activation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8gaugetools"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ecueditor.com K8 gaugetools"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_tools_activation As System.Windows.Forms.CheckBox

End Class
