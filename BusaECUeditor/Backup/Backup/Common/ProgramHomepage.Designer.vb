<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgramHomepage
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
        Dim WebBrowser1 As System.Windows.Forms.WebBrowser
        WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        WebBrowser1.AllowWebBrowserDrop = False
        WebBrowser1.CausesValidation = False
        WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        WebBrowser1.IsWebBrowserContextMenuEnabled = False
        WebBrowser1.Location = New System.Drawing.Point(0, 0)
        WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        WebBrowser1.Name = "WebBrowser1"
        WebBrowser1.Size = New System.Drawing.Size(781, 809)
        WebBrowser1.TabIndex = 0
        WebBrowser1.Tag = "BusaEcueditor"
        WebBrowser1.Url = New System.Uri("http://www.ecueditor.com", System.UriKind.Absolute)
        '
        'ProgramHomepage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 809)
        Me.Controls.Add(WebBrowser1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProgramHomepage"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Program homepage"
        Me.ResumeLayout(False)

    End Sub

End Class
