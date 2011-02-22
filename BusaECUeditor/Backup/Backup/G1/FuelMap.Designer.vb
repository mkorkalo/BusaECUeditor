<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FuelMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FuelMap))
        Me.FuelMapGrid = New System.Windows.Forms.DataGridView
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.B_TPS = New System.Windows.Forms.Button
        Me.B_IAP = New System.Windows.Forms.Button
        Me.B_Close = New System.Windows.Forms.Button
        Me.T_RPM = New System.Windows.Forms.TextBox
        Me.T_TPSIAP = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.B_MSTP = New System.Windows.Forms.Button
        Me.B_Unify = New System.Windows.Forms.Button
        Me.T_valdiff = New System.Windows.Forms.TextBox
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
        Me.FuelMapGrid.Size = New System.Drawing.Size(792, 675)
        Me.FuelMapGrid.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
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
        'B_Close
        '
        Me.B_Close.Location = New System.Drawing.Point(692, 2)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(102, 23)
        Me.B_Close.TabIndex = 3
        Me.B_Close.Text = "Close"
        Me.B_Close.UseVisualStyleBackColor = True
        '
        'T_RPM
        '
        Me.T_RPM.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_RPM.Enabled = False
        Me.T_RPM.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_RPM.Location = New System.Drawing.Point(370, 2)
        Me.T_RPM.Name = "T_RPM"
        Me.T_RPM.Size = New System.Drawing.Size(88, 29)
        Me.T_RPM.TabIndex = 8
        Me.T_RPM.WordWrap = False
        '
        'T_TPSIAP
        '
        Me.T_TPSIAP.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_TPSIAP.Enabled = False
        Me.T_TPSIAP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_TPSIAP.Location = New System.Drawing.Point(464, 2)
        Me.T_TPSIAP.Name = "T_TPSIAP"
        Me.T_TPSIAP.Size = New System.Drawing.Size(131, 29)
        Me.T_TPSIAP.TabIndex = 9
        Me.T_TPSIAP.WordWrap = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 22)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Editing"
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
        'B_Unify
        '
        Me.B_Unify.Location = New System.Drawing.Point(260, 2)
        Me.B_Unify.Name = "B_Unify"
        Me.B_Unify.Size = New System.Drawing.Size(22, 23)
        Me.B_Unify.TabIndex = 12
        Me.B_Unify.Text = "U"
        Me.B_Unify.UseVisualStyleBackColor = True
        '
        'T_valdiff
        '
        Me.T_valdiff.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_valdiff.Enabled = False
        Me.T_valdiff.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_valdiff.Location = New System.Drawing.Point(601, 3)
        Me.T_valdiff.Name = "T_valdiff"
        Me.T_valdiff.Size = New System.Drawing.Size(42, 29)
        Me.T_valdiff.TabIndex = 13
        Me.T_valdiff.WordWrap = False
        '
        'FuelMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 711)
        Me.Controls.Add(Me.T_valdiff)
        Me.Controls.Add(Me.B_Unify)
        Me.Controls.Add(Me.B_MSTP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_TPSIAP)
        Me.Controls.Add(Me.T_RPM)
        Me.Controls.Add(Me.B_Close)
        Me.Controls.Add(Me.B_IAP)
        Me.Controls.Add(Me.B_TPS)
        Me.Controls.Add(Me.FuelMapGrid)
        Me.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FuelMap"
        Me.Text = "ECUeditor Fuelmap"
        CType(Me.FuelMapGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FuelMapGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents B_TPS As System.Windows.Forms.Button
    Friend WithEvents B_IAP As System.Windows.Forms.Button
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents T_RPM As System.Windows.Forms.TextBox
    Friend WithEvents T_TPSIAP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_MSTP As System.Windows.Forms.Button
    Friend WithEvents B_Unify As System.Windows.Forms.Button
    Friend WithEvents T_valdiff As System.Windows.Forms.TextBox
End Class
