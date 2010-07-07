<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8enginedatalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartPen1 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen2 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen3 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen4 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen5 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen6 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen7 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen8 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen9 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen10 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen11 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Dim ChartPen12 As SpPerfChart.ChartPen = New SpPerfChart.ChartPen
        Me.P_RPM = New SpPerfChart.PerfChart
        Me.OK_Button = New System.Windows.Forms.Button
        Me.P_TPS = New SpPerfChart.PerfChart
        Me.P_AFR = New SpPerfChart.PerfChart
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.L_datalog = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.L_record = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.B_Clear = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'P_RPM
        '
        Me.P_RPM.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.P_RPM.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.P_RPM.ForeColor = System.Drawing.Color.White
        Me.P_RPM.Location = New System.Drawing.Point(23, 27)
        Me.P_RPM.Name = "P_RPM"
        Me.P_RPM.PerfChartStyle.AntiAliasing = True
        ChartPen1.Color = System.Drawing.Color.Black
        ChartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen1.Width = 1.0!
        Me.P_RPM.PerfChartStyle.AvgLinePen = ChartPen1
        Me.P_RPM.PerfChartStyle.BackgRoundColorBottom = System.Drawing.Color.Gray
        Me.P_RPM.PerfChartStyle.BackgRoundColorTop = System.Drawing.Color.Gray
        ChartPen2.Color = System.Drawing.Color.White
        ChartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen2.Width = 1.0!
        Me.P_RPM.PerfChartStyle.ChartLinePen = ChartPen2
        ChartPen3.Color = System.Drawing.Color.Black
        ChartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen3.Width = 1.0!
        Me.P_RPM.PerfChartStyle.HorizontalGridPen = ChartPen3
        Me.P_RPM.PerfChartStyle.ShowAverageLine = True
        Me.P_RPM.PerfChartStyle.ShowHorizontalGridLines = True
        Me.P_RPM.PerfChartStyle.ShowVerticalGridLines = True
        ChartPen4.Color = System.Drawing.Color.Black
        ChartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen4.Width = 1.0!
        Me.P_RPM.PerfChartStyle.VerticalGridPen = ChartPen4
        Me.P_RPM.ScaleMode = SpPerfChart.ScaleMode.Relative
        Me.P_RPM.Size = New System.Drawing.Size(225, 103)
        Me.P_RPM.TabIndex = 1
        Me.P_RPM.TimerInterval = 1000
        Me.P_RPM.TimerMode = SpPerfChart.TimerMode.Disabled
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(360, 406)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'P_TPS
        '
        Me.P_TPS.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.P_TPS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.P_TPS.ForeColor = System.Drawing.Color.White
        Me.P_TPS.Location = New System.Drawing.Point(23, 153)
        Me.P_TPS.Name = "P_TPS"
        Me.P_TPS.PerfChartStyle.AntiAliasing = True
        ChartPen5.Color = System.Drawing.Color.Black
        ChartPen5.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen5.Width = 1.0!
        Me.P_TPS.PerfChartStyle.AvgLinePen = ChartPen5
        Me.P_TPS.PerfChartStyle.BackgRoundColorBottom = System.Drawing.Color.Gray
        Me.P_TPS.PerfChartStyle.BackgRoundColorTop = System.Drawing.Color.Gray
        ChartPen6.Color = System.Drawing.Color.White
        ChartPen6.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen6.Width = 1.0!
        Me.P_TPS.PerfChartStyle.ChartLinePen = ChartPen6
        ChartPen7.Color = System.Drawing.Color.Black
        ChartPen7.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen7.Width = 1.0!
        Me.P_TPS.PerfChartStyle.HorizontalGridPen = ChartPen7
        Me.P_TPS.PerfChartStyle.ShowAverageLine = True
        Me.P_TPS.PerfChartStyle.ShowHorizontalGridLines = True
        Me.P_TPS.PerfChartStyle.ShowVerticalGridLines = True
        ChartPen8.Color = System.Drawing.Color.Black
        ChartPen8.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen8.Width = 1.0!
        Me.P_TPS.PerfChartStyle.VerticalGridPen = ChartPen8
        Me.P_TPS.ScaleMode = SpPerfChart.ScaleMode.Relative
        Me.P_TPS.Size = New System.Drawing.Size(225, 103)
        Me.P_TPS.TabIndex = 2
        Me.P_TPS.TimerInterval = 1000
        Me.P_TPS.TimerMode = SpPerfChart.TimerMode.Disabled
        '
        'P_AFR
        '
        Me.P_AFR.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.P_AFR.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.P_AFR.ForeColor = System.Drawing.Color.White
        Me.P_AFR.Location = New System.Drawing.Point(23, 283)
        Me.P_AFR.Name = "P_AFR"
        Me.P_AFR.PerfChartStyle.AntiAliasing = True
        ChartPen9.Color = System.Drawing.Color.Black
        ChartPen9.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen9.Width = 1.0!
        Me.P_AFR.PerfChartStyle.AvgLinePen = ChartPen9
        Me.P_AFR.PerfChartStyle.BackgRoundColorBottom = System.Drawing.Color.Gray
        Me.P_AFR.PerfChartStyle.BackgRoundColorTop = System.Drawing.Color.Gray
        ChartPen10.Color = System.Drawing.Color.White
        ChartPen10.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen10.Width = 1.0!
        Me.P_AFR.PerfChartStyle.ChartLinePen = ChartPen10
        ChartPen11.Color = System.Drawing.Color.Black
        ChartPen11.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen11.Width = 1.0!
        Me.P_AFR.PerfChartStyle.HorizontalGridPen = ChartPen11
        Me.P_AFR.PerfChartStyle.ShowAverageLine = True
        Me.P_AFR.PerfChartStyle.ShowHorizontalGridLines = True
        Me.P_AFR.PerfChartStyle.ShowVerticalGridLines = True
        ChartPen12.Color = System.Drawing.Color.Black
        ChartPen12.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartPen12.Width = 1.0!
        Me.P_AFR.PerfChartStyle.VerticalGridPen = ChartPen12
        Me.P_AFR.ScaleMode = SpPerfChart.ScaleMode.Relative
        Me.P_AFR.Size = New System.Drawing.Size(225, 100)
        Me.P_AFR.TabIndex = 3
        Me.P_AFR.TimerInterval = 1000
        Me.P_AFR.TimerMode = SpPerfChart.TimerMode.Disabled
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "RPM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "TPS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "AFR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 412)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "This display is under development"
        '
        'L_datalog
        '
        Me.L_datalog.FormattingEnabled = True
        Me.L_datalog.Location = New System.Drawing.Point(259, 41)
        Me.L_datalog.Name = "L_datalog"
        Me.L_datalog.Size = New System.Drawing.Size(171, 342)
        Me.L_datalog.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "RPM"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(293, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "TPS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(327, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "IAP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(357, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "AFR"
        '
        'L_record
        '
        Me.L_record.AutoSize = True
        Me.L_record.Font = New System.Drawing.Font("Wingdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.L_record.ForeColor = System.Drawing.Color.Firebrick
        Me.L_record.Location = New System.Drawing.Point(406, 3)
        Me.L_record.Name = "L_record"
        Me.L_record.Size = New System.Drawing.Size(26, 23)
        Me.L_record.TabIndex = 103
        Me.L_record.Text = "l"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(310, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Active > 1500RPM"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(391, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Boost"
        '
        'B_Clear
        '
        Me.B_Clear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.B_Clear.Location = New System.Drawing.Point(284, 406)
        Me.B_Clear.Name = "B_Clear"
        Me.B_Clear.Size = New System.Drawing.Size(67, 23)
        Me.B_Clear.TabIndex = 106
        Me.B_Clear.Text = "Clear"
        '
        'K8enginedatalog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 441)
        Me.Controls.Add(Me.B_Clear)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.L_record)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.L_datalog)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.P_AFR)
        Me.Controls.Add(Me.P_TPS)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.P_RPM)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8enginedatalog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hayabusa Ecueditor2 - Engine Datalog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents P_RPM As SpPerfChart.PerfChart
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents P_TPS As SpPerfChart.PerfChart
    Friend WithEvents P_AFR As SpPerfChart.PerfChart
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L_datalog As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents L_record As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents B_Clear As System.Windows.Forms.Button

End Class
