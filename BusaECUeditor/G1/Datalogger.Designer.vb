<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Datalogger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Datalogger))
        Me.AxEChartCtl1 = New AxECHARTCONTROLLib.AxEChartCtl
        Me.AxEChartCtl2 = New AxECHARTCONTROLLib.AxEChartCtl
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.L_capleft = New System.Windows.Forms.Label
        CType(Me.AxEChartCtl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxEChartCtl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxEChartCtl1
        '
        Me.AxEChartCtl1.Enabled = True
        Me.AxEChartCtl1.Location = New System.Drawing.Point(15, 25)
        Me.AxEChartCtl1.Name = "AxEChartCtl1"
        Me.AxEChartCtl1.OcxState = CType(resources.GetObject("AxEChartCtl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxEChartCtl1.Size = New System.Drawing.Size(366, 88)
        Me.AxEChartCtl1.TabIndex = 1
        '
        'AxEChartCtl2
        '
        Me.AxEChartCtl2.Enabled = True
        Me.AxEChartCtl2.Location = New System.Drawing.Point(15, 142)
        Me.AxEChartCtl2.Name = "AxEChartCtl2"
        Me.AxEChartCtl2.OcxState = CType(resources.GetObject("AxEChartCtl2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxEChartCtl2.Size = New System.Drawing.Size(366, 90)
        Me.AxEChartCtl2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "RPM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "TPS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Datalog memory capacity used:"
        '
        'L_capleft
        '
        Me.L_capleft.AutoSize = True
        Me.L_capleft.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_capleft.Location = New System.Drawing.Point(327, 254)
        Me.L_capleft.Name = "L_capleft"
        Me.L_capleft.Size = New System.Drawing.Size(54, 20)
        Me.L_capleft.TabIndex = 63
        Me.L_capleft.Text = "100%"
        '
        'Datalogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 296)
        Me.Controls.Add(Me.L_capleft)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AxEChartCtl2)
        Me.Controls.Add(Me.AxEChartCtl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Datalogger"
        Me.Text = "ECUeditor Datalogger"
        CType(Me.AxEChartCtl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxEChartCtl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxEChartCtl1 As AxECHARTCONTROLLib.AxEChartCtl
    Friend WithEvents AxEChartCtl2 As AxECHARTCONTROLLib.AxEChartCtl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents L_capleft As System.Windows.Forms.Label
End Class
