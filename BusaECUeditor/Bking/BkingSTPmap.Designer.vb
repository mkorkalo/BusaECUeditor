<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BKingSTPMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BKingSTPMap))
        Me.STPMapGrid = New System.Windows.Forms.DataGridView
        Me.T_TPSIAP = New System.Windows.Forms.TextBox
        Me.T_RPM = New System.Windows.Forms.TextBox
        Me.T_change = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.L_MS = New System.Windows.Forms.Label
        Me.L_mode = New System.Windows.Forms.Label
        Me.L_gear = New System.Windows.Forms.Label
        Me.L_STPMAP = New System.Windows.Forms.Label
        CType(Me.STPMapGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'STPMapGrid
        '
        Me.STPMapGrid.AllowUserToAddRows = False
        Me.STPMapGrid.AllowUserToDeleteRows = False
        Me.STPMapGrid.AllowUserToResizeColumns = False
        Me.STPMapGrid.AllowUserToResizeRows = False
        Me.STPMapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.STPMapGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.STPMapGrid.Location = New System.Drawing.Point(3, 64)
        Me.STPMapGrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.STPMapGrid.Name = "STPMapGrid"
        Me.STPMapGrid.ReadOnly = True
        Me.STPMapGrid.RowHeadersWidth = 500
        Me.STPMapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.STPMapGrid.ShowEditingIcon = False
        Me.STPMapGrid.ShowRowErrors = False
        Me.STPMapGrid.Size = New System.Drawing.Size(441, 483)
        Me.STPMapGrid.TabIndex = 0
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Gear"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Mode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "MS"
        '
        'L_MS
        '
        Me.L_MS.AutoSize = True
        Me.L_MS.Location = New System.Drawing.Point(184, 14)
        Me.L_MS.Name = "L_MS"
        Me.L_MS.Size = New System.Drawing.Size(22, 13)
        Me.L_MS.TabIndex = 24
        Me.L_MS.Text = "n/a"
        '
        'L_mode
        '
        Me.L_mode.AutoSize = True
        Me.L_mode.Location = New System.Drawing.Point(114, 14)
        Me.L_mode.Name = "L_mode"
        Me.L_mode.Size = New System.Drawing.Size(22, 13)
        Me.L_mode.TabIndex = 25
        Me.L_mode.Text = "n/a"
        '
        'L_gear
        '
        Me.L_gear.AutoSize = True
        Me.L_gear.Location = New System.Drawing.Point(41, 14)
        Me.L_gear.Name = "L_gear"
        Me.L_gear.Size = New System.Drawing.Size(22, 13)
        Me.L_gear.TabIndex = 26
        Me.L_gear.Text = "n/a"
        '
        'L_STPMAP
        '
        Me.L_STPMAP.AutoSize = True
        Me.L_STPMAP.Location = New System.Drawing.Point(407, 14)
        Me.L_STPMAP.Name = "L_STPMAP"
        Me.L_STPMAP.Size = New System.Drawing.Size(22, 13)
        Me.L_STPMAP.TabIndex = 27
        Me.L_STPMAP.Text = "n/a"
        '
        'BKingSTPMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 549)
        Me.Controls.Add(Me.L_STPMAP)
        Me.Controls.Add(Me.L_gear)
        Me.Controls.Add(Me.L_mode)
        Me.Controls.Add(Me.L_MS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_change)
        Me.Controls.Add(Me.T_TPSIAP)
        Me.Controls.Add(Me.T_RPM)
        Me.Controls.Add(Me.STPMapGrid)
        Me.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BKingSTPMap"
        Me.Text = "ECUeditor STP maps"
        CType(Me.STPMapGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents STPMapGrid As System.Windows.Forms.DataGridView
    Friend WithEvents T_TPSIAP As System.Windows.Forms.TextBox
    Friend WithEvents T_RPM As System.Windows.Forms.TextBox
    Friend WithEvents T_change As System.Windows.Forms.TextBox
    Friend WithEvents L_gear As System.Windows.Forms.Label
    Friend WithEvents L_mode As System.Windows.Forms.Label
    Friend WithEvents L_MS As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents L_STPMAP As System.Windows.Forms.Label
End Class
