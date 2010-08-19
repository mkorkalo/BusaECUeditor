<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8EngineDataFilter
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
        Me.C_FilterCLT80 = New System.Windows.Forms.CheckBox
        Me.C_GearNeutral = New System.Windows.Forms.CheckBox
        Me.C_FilterClutchIn = New System.Windows.Forms.CheckBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'C_FilterCLT80
        '
        Me.C_FilterCLT80.AutoSize = True
        Me.C_FilterCLT80.Location = New System.Drawing.Point(12, 12)
        Me.C_FilterCLT80.Name = "C_FilterCLT80"
        Me.C_FilterCLT80.Size = New System.Drawing.Size(265, 17)
        Me.C_FilterCLT80.TabIndex = 0
        Me.C_FilterCLT80.Text = "Filter out Data Before Coolant Temp Reaches 80'C"
        Me.C_FilterCLT80.UseVisualStyleBackColor = True
        '
        'C_GearNeutral
        '
        Me.C_GearNeutral.AutoSize = True
        Me.C_GearNeutral.Location = New System.Drawing.Point(12, 35)
        Me.C_GearNeutral.Name = "C_GearNeutral"
        Me.C_GearNeutral.Size = New System.Drawing.Size(166, 17)
        Me.C_GearNeutral.TabIndex = 1
        Me.C_GearNeutral.Text = "Filter out Gear in Neutral Data"
        Me.C_GearNeutral.UseVisualStyleBackColor = True
        '
        'C_FilterClutchIn
        '
        Me.C_FilterClutchIn.AutoSize = True
        Me.C_FilterClutchIn.Location = New System.Drawing.Point(13, 59)
        Me.C_FilterClutchIn.Name = "C_FilterClutchIn"
        Me.C_FilterClutchIn.Size = New System.Drawing.Size(137, 17)
        Me.C_FilterClutchIn.TabIndex = 2
        Me.C_FilterClutchIn.Text = "Filter out Clutch In Data"
        Me.C_FilterClutchIn.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(320, 8)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(320, 38)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'K8EngineDataFilter
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 83)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.C_FilterClutchIn)
        Me.Controls.Add(Me.C_GearNeutral)
        Me.Controls.Add(Me.C_FilterCLT80)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8EngineDataFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "K8 Engine Data Logging Filter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_FilterCLT80 As System.Windows.Forms.CheckBox
    Friend WithEvents C_GearNeutral As System.Windows.Forms.CheckBox
    Friend WithEvents C_FilterClutchIn As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
