<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcceptTerms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcceptTerms))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.B_No = New System.Windows.Forms.Button
        Me.B_Yes = New System.Windows.Forms.Button
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.B_No, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.B_Yes, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(343, 398)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'B_No
        '
        Me.B_No.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.B_No.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.B_No.Location = New System.Drawing.Point(76, 3)
        Me.B_No.Name = "B_No"
        Me.B_No.Size = New System.Drawing.Size(67, 23)
        Me.B_No.TabIndex = 1
        Me.B_No.Text = "No"
        '
        'B_Yes
        '
        Me.B_Yes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.B_Yes.Location = New System.Drawing.Point(3, 3)
        Me.B_Yes.Name = "B_Yes"
        Me.B_Yes.Size = New System.Drawing.Size(67, 23)
        Me.B_Yes.TabIndex = 0
        Me.B_Yes.Text = "YES"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(25, 23)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(411, 260)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'AcceptTerms
        '
        Me.AcceptButton = Me.B_Yes
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.B_No
        Me.ClientSize = New System.Drawing.Size(501, 439)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AcceptTerms"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Do you accept the terms and conditions for using this program ?"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents B_Yes As System.Windows.Forms.Button
    Friend WithEvents B_No As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

End Class
