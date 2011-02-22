<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gixxersteeringdampenermap
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gixxersteeringdampenermap))
        Me.SDmapgrid = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.SDmapgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SDmapgrid
        '
        Me.SDmapgrid.AllowUserToAddRows = False
        Me.SDmapgrid.AllowUserToDeleteRows = False
        Me.SDmapgrid.AllowUserToResizeColumns = False
        Me.SDmapgrid.AllowUserToResizeRows = False
        Me.SDmapgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.SDmapgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.SDmapgrid.Location = New System.Drawing.Point(8, 12)
        Me.SDmapgrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.SDmapgrid.Name = "SDmapgrid"
        Me.SDmapgrid.ReadOnly = True
        Me.SDmapgrid.RowHeadersWidth = 500
        Me.SDmapgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.SDmapgrid.ShowEditingIcon = False
        Me.SDmapgrid.ShowRowErrors = False
        Me.SDmapgrid.Size = New System.Drawing.Size(589, 53)
        Me.SDmapgrid.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(358, 39)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CAUTION: Modifying steering dampener response may lead to unexpected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "steering re" & _
            "sponse. Like with any ecu modification, use the settings with" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "caution and total" & _
            "ly at your own risk." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Gixxersteeringdampenermap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 126)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SDmapgrid)
        Me.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Gixxersteeringdampenermap"
        Me.Text = "ecueditor.com Gixxer steering dampener map"
        CType(Me.SDmapgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SDmapgrid As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
