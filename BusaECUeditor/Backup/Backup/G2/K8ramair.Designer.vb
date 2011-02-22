<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8ramair
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.OK_Button = New System.Windows.Forms.Button
        Me.D_ramair = New System.Windows.Forms.DataGridView
        CType(Me.D_ramair, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(669, 235)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'D_ramair
        '
        Me.D_ramair.AllowUserToAddRows = False
        Me.D_ramair.AllowUserToDeleteRows = False
        Me.D_ramair.BackgRoundColor = System.Drawing.SystemColors.Control
        Me.D_ramair.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.D_ramair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D_ramair.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.D_ramair.Location = New System.Drawing.Point(12, 12)
        Me.D_ramair.Name = "D_ramair"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.D_ramair.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.D_ramair.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.D_ramair.Size = New System.Drawing.Size(733, 193)
        Me.D_ramair.TabIndex = 75
        '
        'K8ramair
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 270)
        Me.Controls.Add(Me.D_ramair)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8ramair"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ramair settings"
        CType(Me.D_ramair, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents D_ramair As System.Windows.Forms.DataGridView

End Class
