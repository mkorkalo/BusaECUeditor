<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8Limiters
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8Limiters))
        Me.C_gearlimiter = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RPM = New System.Windows.Forms.ComboBox
        Me.Hardcut = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.SuspendLayout()
        '
        'C_gearlimiter
        '
        Me.C_gearlimiter.AutoSize = True
        Me.C_gearlimiter.Location = New System.Drawing.Point(142, 66)
        Me.C_gearlimiter.Name = "C_gearlimiter"
        Me.C_gearlimiter.Size = New System.Drawing.Size(15, 14)
        Me.C_gearlimiter.TabIndex = 19
        Me.C_gearlimiter.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Fuel gear limiter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "RPM limiter"
        '
        'RPM
        '
        Me.RPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RPM.Enabled = False
        Me.RPM.FormattingEnabled = True
        Me.RPM.Location = New System.Drawing.Point(142, 25)
        Me.RPM.Name = "RPM"
        Me.RPM.Size = New System.Drawing.Size(84, 21)
        Me.RPM.TabIndex = 16
        '
        'Hardcut
        '
        Me.Hardcut.AutoSize = True
        Me.Hardcut.Location = New System.Drawing.Point(142, 86)
        Me.Hardcut.Name = "Hardcut"
        Me.Hardcut.Size = New System.Drawing.Size(15, 14)
        Me.Hardcut.TabIndex = 21
        Me.Hardcut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Fuel soft or Hardcut"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(364, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Note: When gear limiters are removed then also top speed limiter is removed"
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'K8Limiters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 144)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Hardcut)
        Me.Controls.Add(Me.C_gearlimiter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RPM)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8Limiters"
        Me.Text = "Hayabusa ECUeditor Limiters K8-"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_gearlimiter As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RPM As System.Windows.Forms.ComboBox
    Friend WithEvents Hardcut As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
End Class
