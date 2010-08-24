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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NUD_FilterAFRGreaterThan = New System.Windows.Forms.NumericUpDown
        Me.NUD_FilterAFRLessThan = New System.Windows.Forms.NumericUpDown
        CType(Me.NUD_FilterAFRGreaterThan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_FilterAFRLessThan, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Filter out AFR Values >"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Filter out AFR Values <"
        '
        'NUD_FilterAFRGreaterThan
        '
        Me.NUD_FilterAFRGreaterThan.DecimalPlaces = 1
        Me.NUD_FilterAFRGreaterThan.Location = New System.Drawing.Point(129, 100)
        Me.NUD_FilterAFRGreaterThan.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_FilterAFRGreaterThan.Minimum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.NUD_FilterAFRGreaterThan.Name = "NUD_FilterAFRGreaterThan"
        Me.NUD_FilterAFRGreaterThan.Size = New System.Drawing.Size(49, 20)
        Me.NUD_FilterAFRGreaterThan.TabIndex = 7
        Me.NUD_FilterAFRGreaterThan.Value = New Decimal(New Integer() {22, 0, 0, 0})
        '
        'NUD_FilterAFRLessThan
        '
        Me.NUD_FilterAFRLessThan.DecimalPlaces = 1
        Me.NUD_FilterAFRLessThan.Location = New System.Drawing.Point(129, 77)
        Me.NUD_FilterAFRLessThan.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NUD_FilterAFRLessThan.Name = "NUD_FilterAFRLessThan"
        Me.NUD_FilterAFRLessThan.Size = New System.Drawing.Size(49, 20)
        Me.NUD_FilterAFRLessThan.TabIndex = 8
        Me.NUD_FilterAFRLessThan.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'K8EngineDataFilter
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 128)
        Me.Controls.Add(Me.NUD_FilterAFRLessThan)
        Me.Controls.Add(Me.NUD_FilterAFRGreaterThan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
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
        CType(Me.NUD_FilterAFRGreaterThan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_FilterAFRLessThan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_FilterCLT80 As System.Windows.Forms.CheckBox
    Friend WithEvents C_GearNeutral As System.Windows.Forms.CheckBox
    Friend WithEvents C_FilterClutchIn As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NUD_FilterAFRGreaterThan As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_FilterAFRLessThan As System.Windows.Forms.NumericUpDown
End Class
