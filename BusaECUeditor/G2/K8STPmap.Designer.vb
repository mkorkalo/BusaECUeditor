<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8STPmap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8STPmap))
        Me.STPmapgrid = New System.Windows.Forms.DataGridView
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.T_TPSIAP = New System.Windows.Forms.TextBox
        Me.T_RPM = New System.Windows.Forms.TextBox
        Me.T_change = New System.Windows.Forms.TextBox
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.L_MS = New System.Windows.Forms.Label
        Me.L_mode = New System.Windows.Forms.Label
        Me.L_gear = New System.Windows.Forms.Label
        Me.L_STPMAP = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LED_GEAR = New LxControl.LxLedControl
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        CType(Me.STPmapgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_GEAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'STPmapgrid
        '
        Me.STPmapgrid.AllowUserToAddRows = False
        Me.STPmapgrid.AllowUserToDeleteRows = False
        Me.STPmapgrid.AllowUserToResizeColumns = False
        Me.STPmapgrid.AllowUserToResizeRows = False
        Me.STPmapgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.STPmapgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.STPmapgrid.Location = New System.Drawing.Point(3, 30)
        Me.STPmapgrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.STPmapgrid.Name = "STPmapgrid"
        Me.STPmapgrid.ReadOnly = True
        Me.STPmapgrid.RowHeadersWidth = 500
        Me.STPmapgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.STPmapgrid.ShowEditingIcon = False
        Me.STPmapgrid.ShowRowErrors = False
        Me.STPmapgrid.Size = New System.Drawing.Size(408, 413)
        Me.STPmapgrid.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(427, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Gear"
        '
        'LED_GEAR
        '
        Me.LED_GEAR.BackColor = System.Drawing.Color.Transparent
        Me.LED_GEAR.BackColor_1 = System.Drawing.Color.Transparent
        Me.LED_GEAR.BackColor_2 = System.Drawing.Color.Transparent
        Me.LED_GEAR.BevelRate = 0.5!
        Me.LED_GEAR.FadedColor = System.Drawing.Color.Transparent
        Me.LED_GEAR.ForeColor = System.Drawing.Color.Black
        Me.LED_GEAR.HighlightOpaque = CType(50, Byte)
        Me.LED_GEAR.Location = New System.Drawing.Point(465, 70)
        Me.LED_GEAR.Name = "LED_GEAR"
        Me.LED_GEAR.Size = New System.Drawing.Size(51, 42)
        Me.LED_GEAR.TabIndex = 96
        Me.LED_GEAR.Text = "E"
        Me.LED_GEAR.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_GEAR.TotalCharCount = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(433, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 73)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "("
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(513, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 73)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = ")"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(430, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 24)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "Select gear NT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(430, 186)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(114, 24)
        Me.Button2.TabIndex = 101
        Me.Button2.Text = "Select gear 1"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(430, 216)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 24)
        Me.Button3.TabIndex = 102
        Me.Button3.Text = "Select gear 2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(430, 246)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 24)
        Me.Button4.TabIndex = 103
        Me.Button4.Text = "Select gear 3"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(430, 276)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(114, 24)
        Me.Button5.TabIndex = 104
        Me.Button5.Text = "Select gear 4"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(430, 306)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(114, 24)
        Me.Button6.TabIndex = 105
        Me.Button6.Text = "Select gear 5"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(429, 336)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 24)
        Me.Button7.TabIndex = 106
        Me.Button7.Text = "Select gear 6"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(430, 389)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(114, 24)
        Me.Button8.TabIndex = 107
        Me.Button8.Text = "Select STP opening"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(430, 419)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(114, 24)
        Me.Button9.TabIndex = 108
        Me.Button9.Text = "Select STP fuel"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'K8STPmap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 452)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LED_GEAR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
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
        Me.Controls.Add(Me.STPmapgrid)
        Me.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8STPmap"
        Me.Text = "ECUeditor STP maps"
        CType(Me.STPmapgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_GEAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents STPmapgrid As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents T_TPSIAP As System.Windows.Forms.TextBox
    Friend WithEvents T_RPM As System.Windows.Forms.TextBox
    Friend WithEvents T_change As System.Windows.Forms.TextBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents L_gear As System.Windows.Forms.Label
    Friend WithEvents L_mode As System.Windows.Forms.Label
    Friend WithEvents L_MS As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents L_STPMAP As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LED_GEAR As LxControl.LxLedControl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
