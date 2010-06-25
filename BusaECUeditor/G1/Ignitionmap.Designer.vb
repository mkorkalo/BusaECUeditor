<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ignitionmap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ignitionmap))
        Me.B_MSIGN = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.T_TPSIAP = New System.Windows.Forms.TextBox
        Me.T_RPM = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.B_IGN = New System.Windows.Forms.Button
        Me.Ignitionmapgrid = New System.Windows.Forms.DataGridView
        Me.T_valdiff = New System.Windows.Forms.TextBox
        Me.B_unify = New System.Windows.Forms.Button
        CType(Me.Ignitionmapgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_MSIGN
        '
        Me.B_MSIGN.Location = New System.Drawing.Point(99, 22)
        Me.B_MSIGN.Name = "B_MSIGN"
        Me.B_MSIGN.Size = New System.Drawing.Size(80, 23)
        Me.B_MSIGN.TabIndex = 19
        Me.B_MSIGN.Text = "MS ignmap"
        Me.B_MSIGN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(206, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 22)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Editing"
        '
        'T_TPSIAP
        '
        Me.T_TPSIAP.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_TPSIAP.Enabled = False
        Me.T_TPSIAP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_TPSIAP.Location = New System.Drawing.Point(420, 16)
        Me.T_TPSIAP.Name = "T_TPSIAP"
        Me.T_TPSIAP.Size = New System.Drawing.Size(136, 29)
        Me.T_TPSIAP.TabIndex = 17
        Me.T_TPSIAP.WordWrap = False
        '
        'T_RPM
        '
        Me.T_RPM.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_RPM.Enabled = False
        Me.T_RPM.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_RPM.Location = New System.Drawing.Point(280, 16)
        Me.T_RPM.Name = "T_RPM"
        Me.T_RPM.Size = New System.Drawing.Size(134, 29)
        Me.T_RPM.TabIndex = 16
        Me.T_RPM.WordWrap = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(637, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'B_IGN
        '
        Me.B_IGN.Location = New System.Drawing.Point(11, 22)
        Me.B_IGN.Name = "B_IGN"
        Me.B_IGN.Size = New System.Drawing.Size(82, 23)
        Me.B_IGN.TabIndex = 13
        Me.B_IGN.Text = "Ignitionmap"
        Me.B_IGN.UseVisualStyleBackColor = True
        '
        'Ignitionmapgrid
        '
        Me.Ignitionmapgrid.AllowUserToAddRows = False
        Me.Ignitionmapgrid.AllowUserToDeleteRows = False
        Me.Ignitionmapgrid.AllowUserToResizeColumns = False
        Me.Ignitionmapgrid.AllowUserToResizeRows = False
        Me.Ignitionmapgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Ignitionmapgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Ignitionmapgrid.Location = New System.Drawing.Point(11, 51)
        Me.Ignitionmapgrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Ignitionmapgrid.Name = "Ignitionmapgrid"
        Me.Ignitionmapgrid.ReadOnly = True
        Me.Ignitionmapgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Ignitionmapgrid.Size = New System.Drawing.Size(731, 593)
        Me.Ignitionmapgrid.TabIndex = 12
        '
        'T_valdiff
        '
        Me.T_valdiff.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.T_valdiff.Enabled = False
        Me.T_valdiff.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.T_valdiff.Location = New System.Drawing.Point(562, 16)
        Me.T_valdiff.Name = "T_valdiff"
        Me.T_valdiff.Size = New System.Drawing.Size(64, 29)
        Me.T_valdiff.TabIndex = 20
        Me.T_valdiff.WordWrap = False
        '
        'B_unify
        '
        Me.B_unify.Location = New System.Drawing.Point(185, 23)
        Me.B_unify.Name = "B_unify"
        Me.B_unify.Size = New System.Drawing.Size(22, 23)
        Me.B_unify.TabIndex = 21
        Me.B_unify.Text = "U"
        Me.B_unify.UseVisualStyleBackColor = True
        '
        'Ignitionmap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 656)
        Me.Controls.Add(Me.B_unify)
        Me.Controls.Add(Me.T_valdiff)
        Me.Controls.Add(Me.B_MSIGN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_TPSIAP)
        Me.Controls.Add(Me.T_RPM)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.B_IGN)
        Me.Controls.Add(Me.Ignitionmapgrid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Ignitionmap"
        Me.Text = "ECUeditor Ignitionmap"
        CType(Me.Ignitionmapgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents B_MSIGN As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T_TPSIAP As System.Windows.Forms.TextBox
    Friend WithEvents T_RPM As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents B_IGN As System.Windows.Forms.Button
    Friend WithEvents Ignitionmapgrid As System.Windows.Forms.DataGridView
    Friend WithEvents T_valdiff As System.Windows.Forms.TextBox
    Friend WithEvents B_unify As System.Windows.Forms.Button
End Class
