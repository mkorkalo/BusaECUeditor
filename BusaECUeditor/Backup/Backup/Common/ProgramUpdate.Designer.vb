<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgramUpdate
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
        Me.WebUpdate = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'WebUpdate
        '
        Me.WebUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebUpdate.Location = New System.Drawing.Point(0, 0)
        Me.WebUpdate.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebUpdate.Name = "WebUpdate"
        Me.WebUpdate.Size = New System.Drawing.Size(766, 412)
        Me.WebUpdate.TabIndex = 0
        Me.WebUpdate.Url = New System.Uri("http://macmadigan.no-ip.com/public/ecu/ecueditor/ecueditor.htm", System.UriKind.Absolute)
        '
        'updatebox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 412)
        Me.Controls.Add(Me.WebUpdate)
        Me.Name = "updatebox"
        Me.Text = "Program Updates"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebUpdate As System.Windows.Forms.WebBrowser
End Class
