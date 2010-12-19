<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8dragtools
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8dragtools))
        Me.C_dragtools_activation = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.L_dragtoolsver = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.K8dragtoolsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Linklabel_program_homepage = New System.Windows.Forms.LinkLabel
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.K8dragtoolsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C_dragtools_activation
        '
        Me.C_dragtools_activation.AutoSize = True
        Me.C_dragtools_activation.Location = New System.Drawing.Point(145, 36)
        Me.C_dragtools_activation.Name = "C_dragtools_activation"
        Me.C_dragtools_activation.Size = New System.Drawing.Size(75, 17)
        Me.C_dragtools_activation.TabIndex = 1
        Me.C_dragtools_activation.Text = "Not active"
        Me.C_dragtools_activation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Dragtools activation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(352, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Module  v           ready for testing"
        '
        'L_dragtoolsver
        '
        Me.L_dragtoolsver.AutoSize = True
        Me.L_dragtoolsver.Location = New System.Drawing.Point(407, 37)
        Me.L_dragtoolsver.Name = "L_dragtoolsver"
        Me.L_dragtoolsver.Size = New System.Drawing.Size(25, 13)
        Me.L_dragtoolsver.TabIndex = 42
        Me.L_dragtoolsver.Text = "000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(305, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 24)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Gen2 Dragtools module"
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(437, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 29)
        Me.Button1.TabIndex = 80
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Linklabel_program_homepage
        '
        Me.Linklabel_program_homepage.ActiveLinkColor = System.Drawing.Color.DimGray
        Me.Linklabel_program_homepage.AutoSize = True
        Me.Linklabel_program_homepage.LinkColor = System.Drawing.Color.Black
        Me.Linklabel_program_homepage.Location = New System.Drawing.Point(9, 425)
        Me.Linklabel_program_homepage.Name = "Linklabel_program_homepage"
        Me.Linklabel_program_homepage.Size = New System.Drawing.Size(215, 13)
        Me.Linklabel_program_homepage.TabIndex = 84
        Me.Linklabel_program_homepage.TabStop = True
        Me.Linklabel_program_homepage.Text = "Click here to visit: http//www.ecueditor.com"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(14, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(497, 24)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "This is just for development purposes, not yet functional !!!!"
        '
        'K8dragtools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 473)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Linklabel_program_homepage)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.L_dragtoolsver)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C_dragtools_activation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8dragtools"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa ECUeditor K8- Dragracing tools module"
        CType(Me.K8dragtoolsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C_dragtools_activation As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L_dragtoolsver As System.Windows.Forms.Label
    Friend WithEvents K8dragtoolsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Linklabel_program_homepage As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
