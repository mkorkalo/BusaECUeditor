<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BKingIgnitionMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BKingIgnitionMap))
        Me.T_TPSIAP = New System.Windows.Forms.TextBox
        Me.T_RPM = New System.Windows.Forms.TextBox
        Me.IgnitionMapGrid = New System.Windows.Forms.DataGridView
        Me.B_MS0 = New System.Windows.Forms.Button
        Me.B_MS1 = New System.Windows.Forms.Button
        Me.T_DEG = New System.Windows.Forms.TextBox
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.IgnitionMapGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'T_TPSIAP
        '
        Me.T_TPSIAP.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_TPSIAP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_TPSIAP.Enabled = False
        Me.T_TPSIAP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_TPSIAP.Location = New System.Drawing.Point(495, 16)
        Me.T_TPSIAP.Name = "T_TPSIAP"
        Me.T_TPSIAP.Size = New System.Drawing.Size(136, 22)
        Me.T_TPSIAP.TabIndex = 17
        Me.T_TPSIAP.WordWrap = False
        '
        'T_RPM
        '
        Me.T_RPM.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_RPM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_RPM.Enabled = False
        Me.T_RPM.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_RPM.Location = New System.Drawing.Point(355, 16)
        Me.T_RPM.Name = "T_RPM"
        Me.T_RPM.Size = New System.Drawing.Size(134, 22)
        Me.T_RPM.TabIndex = 16
        Me.T_RPM.WordWrap = False
        '
        'IgnitionMapGrid
        '
        Me.IgnitionMapGrid.AllowUserToAddRows = False
        Me.IgnitionMapGrid.AllowUserToDeleteRows = False
        Me.IgnitionMapGrid.AllowUserToResizeColumns = False
        Me.IgnitionMapGrid.AllowUserToResizeRows = False
        Me.IgnitionMapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IgnitionMapGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.IgnitionMapGrid.Location = New System.Drawing.Point(11, 51)
        Me.IgnitionMapGrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.IgnitionMapGrid.Name = "IgnitionMapGrid"
        Me.IgnitionMapGrid.ReadOnly = True
        Me.IgnitionMapGrid.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.IgnitionMapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.IgnitionMapGrid.Size = New System.Drawing.Size(654, 563)
        Me.IgnitionMapGrid.TabIndex = 12
        '
        'B_MS0
        '
        Me.B_MS0.Location = New System.Drawing.Point(12, 14)
        Me.B_MS0.Name = "B_MS0"
        Me.B_MS0.Size = New System.Drawing.Size(80, 23)
        Me.B_MS0.TabIndex = 18
        Me.B_MS0.Text = "TPS MS0"
        Me.B_MS0.UseVisualStyleBackColor = True
        '
        'B_MS1
        '
        Me.B_MS1.Location = New System.Drawing.Point(98, 14)
        Me.B_MS1.Name = "B_MS1"
        Me.B_MS1.Size = New System.Drawing.Size(80, 23)
        Me.B_MS1.TabIndex = 19
        Me.B_MS1.Text = "TPS MS1"
        Me.B_MS1.UseVisualStyleBackColor = True
        '
        'T_DEG
        '
        Me.T_DEG.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_DEG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T_DEG.Enabled = False
        Me.T_DEG.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_DEG.Location = New System.Drawing.Point(206, 16)
        Me.T_DEG.Name = "T_DEG"
        Me.T_DEG.Size = New System.Drawing.Size(134, 22)
        Me.T_DEG.TabIndex = 20
        Me.T_DEG.WordWrap = False
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(390, 634)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Note: press 'c' to copy this map to ms01 or unify cylinders"
        '
        'BKingIgnitionMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 656)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_DEG)
        Me.Controls.Add(Me.B_MS1)
        Me.Controls.Add(Me.B_MS0)
        Me.Controls.Add(Me.T_TPSIAP)
        Me.Controls.Add(Me.T_RPM)
        Me.Controls.Add(Me.IgnitionMapGrid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BKingIgnitionMap"
        Me.Text = "ECUeditor.com BKing Ignitionmap"
        CType(Me.IgnitionMapGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T_TPSIAP As System.Windows.Forms.TextBox
    Friend WithEvents T_RPM As System.Windows.Forms.TextBox
    Friend WithEvents IgnitionMapGrid As System.Windows.Forms.DataGridView
    Friend WithEvents B_MS0 As System.Windows.Forms.Button
    Friend WithEvents B_MS1 As System.Windows.Forms.Button
    Friend WithEvents T_DEG As System.Windows.Forms.TextBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
