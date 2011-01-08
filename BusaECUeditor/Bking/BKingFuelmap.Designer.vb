<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BKingFuelMap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BKingFuelMap))
        Me.FuelMapGrid = New System.Windows.Forms.DataGridView
        Me.B_TPS = New System.Windows.Forms.Button
        Me.B_IAP = New System.Windows.Forms.Button
        Me.B_MSTP = New System.Windows.Forms.Button
        Me.B_Apply_MAP = New System.Windows.Forms.Button
        Me.T_TPSIAP = New System.Windows.Forms.TextBox
        Me.T_RPM = New System.Windows.Forms.TextBox
        Me.T_change = New System.Windows.Forms.TextBox
        Me.L_modeabc = New System.Windows.Forms.Label
        CType(Me.FuelMapGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FuelMapGrid
        '
        Me.FuelMapGrid.AllowUserToAddRows = False
        Me.FuelMapGrid.AllowUserToDeleteRows = False
        Me.FuelMapGrid.AllowUserToResizeColumns = False
        Me.FuelMapGrid.AllowUserToResizeRows = False
        Me.FuelMapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FuelMapGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.FuelMapGrid.Location = New System.Drawing.Point(3, 31)
        Me.FuelMapGrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FuelMapGrid.Name = "FuelMapGrid"
        Me.FuelMapGrid.ReadOnly = True
        Me.FuelMapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.FuelMapGrid.ShowEditingIcon = False
        Me.FuelMapGrid.ShowRowErrors = False
        Me.FuelMapGrid.Size = New System.Drawing.Size(792, 675)
        Me.FuelMapGrid.TabIndex = 0
        '
        'B_TPS
        '
        Me.B_TPS.Location = New System.Drawing.Point(3, 2)
        Me.B_TPS.Name = "B_TPS"
        Me.B_TPS.Size = New System.Drawing.Size(82, 23)
        Me.B_TPS.TabIndex = 1
        Me.B_TPS.Text = "TPS fuelmap"
        Me.B_TPS.UseVisualStyleBackColor = True
        '
        'B_IAP
        '
        Me.B_IAP.Location = New System.Drawing.Point(91, 2)
        Me.B_IAP.Name = "B_IAP"
        Me.B_IAP.Size = New System.Drawing.Size(80, 23)
        Me.B_IAP.TabIndex = 2
        Me.B_IAP.Text = "IAP fuelmap"
        Me.B_IAP.UseVisualStyleBackColor = True
        '
        'B_MSTP
        '
        Me.B_MSTP.Location = New System.Drawing.Point(177, 2)
        Me.B_MSTP.Name = "B_MSTP"
        Me.B_MSTP.Size = New System.Drawing.Size(80, 23)
        Me.B_MSTP.TabIndex = 11
        Me.B_MSTP.Text = "MS fuelmap"
        Me.B_MSTP.UseVisualStyleBackColor = True
        '
        'B_Apply_MAP
        '
        Me.B_Apply_MAP.Location = New System.Drawing.Point(263, 2)
        Me.B_Apply_MAP.Name = "B_Apply_MAP"
        Me.B_Apply_MAP.Size = New System.Drawing.Size(78, 23)
        Me.B_Apply_MAP.TabIndex = 12
        Me.B_Apply_MAP.Text = "Apply map"
        Me.B_Apply_MAP.UseVisualStyleBackColor = True
        '
        'T_TPSIAP
        '
        Me.T_TPSIAP.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_TPSIAP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_TPSIAP.Enabled = False
        Me.T_TPSIAP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_TPSIAP.Location = New System.Drawing.Point(570, 2)
        Me.T_TPSIAP.Name = "T_TPSIAP"
        Me.T_TPSIAP.Size = New System.Drawing.Size(116, 19)
        Me.T_TPSIAP.TabIndex = 19
        Me.T_TPSIAP.WordWrap = False
        '
        'T_RPM
        '
        Me.T_RPM.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_RPM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RPM.Enabled = False
        Me.T_RPM.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_RPM.Location = New System.Drawing.Point(471, 2)
        Me.T_RPM.Name = "T_RPM"
        Me.T_RPM.Size = New System.Drawing.Size(93, 19)
        Me.T_RPM.TabIndex = 18
        Me.T_RPM.WordWrap = False
        '
        'T_change
        '
        Me.T_change.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_change.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_change.Enabled = False
        Me.T_change.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_change.Location = New System.Drawing.Point(373, 2)
        Me.T_change.Name = "T_change"
        Me.T_change.Size = New System.Drawing.Size(92, 19)
        Me.T_change.TabIndex = 20
        Me.T_change.WordWrap = False
        '
        'L_modeabc
        '
        Me.L_modeabc.AutoSize = True
        Me.L_modeabc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_modeabc.Location = New System.Drawing.Point(745, 1)
        Me.L_modeabc.Name = "L_modeabc"
        Me.L_modeabc.Size = New System.Drawing.Size(50, 18)
        Me.L_modeabc.TabIndex = 21
        Me.L_modeabc.Text = "A/B/C"
        '
        'BKingFuelMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 711)
        Me.Controls.Add(Me.L_modeabc)
        Me.Controls.Add(Me.T_change)
        Me.Controls.Add(Me.T_TPSIAP)
        Me.Controls.Add(Me.T_RPM)
        Me.Controls.Add(Me.B_Apply_MAP)
        Me.Controls.Add(Me.B_MSTP)
        Me.Controls.Add(Me.B_IAP)
        Me.Controls.Add(Me.B_TPS)
        Me.Controls.Add(Me.FuelMapGrid)
        Me.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BKingFuelMap"
        Me.Text = "ECUeditor Fuelmap"
        CType(Me.FuelMapGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FuelMapGrid As System.Windows.Forms.DataGridView
    Friend WithEvents B_TPS As System.Windows.Forms.Button
    Friend WithEvents B_IAP As System.Windows.Forms.Button
    Friend WithEvents B_MSTP As System.Windows.Forms.Button
    Friend WithEvents B_Apply_MAP As System.Windows.Forms.Button
    Friend WithEvents T_TPSIAP As System.Windows.Forms.TextBox
    Friend WithEvents T_RPM As System.Windows.Forms.TextBox
    Friend WithEvents T_change As System.Windows.Forms.TextBox
    Friend WithEvents L_modeabc As System.Windows.Forms.Label
End Class
