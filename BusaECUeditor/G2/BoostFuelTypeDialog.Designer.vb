<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoostFuelTypeDialog
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
        Me.B_Extended = New System.Windows.Forms.Button()
        Me.B_Legacy = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please choose from either Legacy or Extended Boost Fuel Modules"
        '
        'B_Extended
        '
        Me.B_Extended.Location = New System.Drawing.Point(77, 48)
        Me.B_Extended.Name = "B_Extended"
        Me.B_Extended.Size = New System.Drawing.Size(75, 23)
        Me.B_Extended.TabIndex = 1
        Me.B_Extended.Text = "Extended"
        Me.B_Extended.UseVisualStyleBackColor = True
        '
        'B_Legacy
        '
        Me.B_Legacy.Location = New System.Drawing.Point(171, 48)
        Me.B_Legacy.Name = "B_Legacy"
        Me.B_Legacy.Size = New System.Drawing.Size(75, 23)
        Me.B_Legacy.TabIndex = 2
        Me.B_Legacy.Text = "Legacy"
        Me.B_Legacy.UseVisualStyleBackColor = True
        '
        'BoostFuelTypeDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 94)
        Me.Controls.Add(Me.B_Legacy)
        Me.Controls.Add(Me.B_Extended)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BoostFuelTypeDialog"
        Me.Text = "Boost Fuel Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_Extended As System.Windows.Forms.Button
    Friend WithEvents B_Legacy As System.Windows.Forms.Button
End Class
