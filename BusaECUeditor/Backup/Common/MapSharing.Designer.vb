<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapSharing
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
        Me.B_Close = New System.Windows.Forms.Button
        Me.Webmapsaring = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'B_Close
        '
        Me.B_Close.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.B_Close.Location = New System.Drawing.Point(906, 420)
        Me.B_Close.Name = "B_Close"
        Me.B_Close.Size = New System.Drawing.Size(67, 23)
        Me.B_Close.TabIndex = 0
        Me.B_Close.Text = "Close"
        '
        'Webmapsaring
        '
        Me.Webmapsaring.Location = New System.Drawing.Point(8, 8)
        Me.Webmapsaring.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Webmapsaring.Name = "Webmapsaring"
        Me.Webmapsaring.Size = New System.Drawing.Size(965, 411)
        Me.Webmapsaring.TabIndex = 1
        Me.Webmapsaring.Url = New System.Uri("http://groups.yahoo.com/group/ECUeditor", System.UriKind.Absolute)
        '
        'mapsharing
        '
        Me.AcceptButton = Me.B_Close
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 455)
        Me.Controls.Add(Me.Webmapsaring)
        Me.Controls.Add(Me.B_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mapsharing"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ECUeditor map sharing"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents B_Close As System.Windows.Forms.Button
    Friend WithEvents Webmapsaring As System.Windows.Forms.WebBrowser

End Class
