<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8AutoTuneSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8AutoTuneSettings))
        Me.NUD_AutoTuneMinAvgAFR = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NUD_AutoTuneMaxAvgAFR = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NUD_AutoTuneMaxPercentageFuelMapChange = New System.Windows.Forms.NumericUpDown()
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NUD_AutoTuneMapSmoothingStrength = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NUD_AutoTuneTimeWindow = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NUD_AFRStdDev = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NUD_ExhaustGasVelocityOffset = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.L_AutoTuneStrength = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_AutoTuneStrength = New System.Windows.Forms.TrackBar()
        Me.B_Cancel = New System.Windows.Forms.Button()
        Me.B_Ok = New System.Windows.Forms.Button()
        CType(Me.NUD_AutoTuneMinAvgAFR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMaxAvgAFR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMaxPercentageFuelMapChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMinNumberLoggedValuesInCell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.NUD_AutoTuneMapSmoothingStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneTimeWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AFRStdDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_ExhaustGasVelocityOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TB_AutoTuneStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NUD_AutoTuneMinAvgAFR
        '
        Me.NUD_AutoTuneMinAvgAFR.DecimalPlaces = 1
        Me.NUD_AutoTuneMinAvgAFR.Location = New System.Drawing.Point(241, 10)
        Me.NUD_AutoTuneMinAvgAFR.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.NUD_AutoTuneMinAvgAFR.Name = "NUD_AutoTuneMinAvgAFR"
        Me.NUD_AutoTuneMinAvgAFR.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMinAvgAFR.TabIndex = 0
        Me.NUD_AutoTuneMinAvgAFR.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Minimum Avg AFR Value"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Maximum Avg AFR Value"
        '
        'NUD_AutoTuneMaxAvgAFR
        '
        Me.NUD_AutoTuneMaxAvgAFR.DecimalPlaces = 1
        Me.NUD_AutoTuneMaxAvgAFR.Location = New System.Drawing.Point(241, 34)
        Me.NUD_AutoTuneMaxAvgAFR.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_AutoTuneMaxAvgAFR.Minimum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NUD_AutoTuneMaxAvgAFR.Name = "NUD_AutoTuneMaxAvgAFR"
        Me.NUD_AutoTuneMaxAvgAFR.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMaxAvgAFR.TabIndex = 3
        Me.NUD_AutoTuneMaxAvgAFR.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Max % Change in Fuel Map"
        '
        'NUD_AutoTuneMaxPercentageFuelMapChange
        '
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.Location = New System.Drawing.Point(241, 132)
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.Name = "NUD_AutoTuneMaxPercentageFuelMapChange"
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.TabIndex = 5
        '
        'NUD_AutoTuneMinNumberLoggedValuesInCell
        '
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.Location = New System.Drawing.Point(241, 157)
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.Name = "NUD_AutoTuneMinNumberLoggedValuesInCell"
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Min Number of Logged AFR Values In Cell"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(349, 74)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(7, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 94)
        Me.Panel1.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMapSmoothingStrength)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneTimeWindow)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.NUD_AFRStdDev)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.NUD_ExhaustGasVelocityOffset)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.L_AutoTuneStrength)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TB_AutoTuneStrength)
        Me.Panel2.Controls.Add(Me.B_Cancel)
        Me.Panel2.Controls.Add(Me.B_Ok)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMinAvgAFR)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMinNumberLoggedValuesInCell)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMaxAvgAFR)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMaxPercentageFuelMapChange)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(7, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(404, 255)
        Me.Panel2.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Map Smoothing Strength"
        '
        'NUD_AutoTuneMapSmoothingStrength
        '
        Me.NUD_AutoTuneMapSmoothingStrength.Location = New System.Drawing.Point(241, 106)
        Me.NUD_AutoTuneMapSmoothingStrength.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NUD_AutoTuneMapSmoothingStrength.Name = "NUD_AutoTuneMapSmoothingStrength"
        Me.NUD_AutoTuneMapSmoothingStrength.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMapSmoothingStrength.TabIndex = 21
        Me.NUD_AutoTuneMapSmoothingStrength.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(310, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "ms"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Time Window"
        '
        'NUD_AutoTuneTimeWindow
        '
        Me.NUD_AutoTuneTimeWindow.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NUD_AutoTuneTimeWindow.Location = New System.Drawing.Point(240, 82)
        Me.NUD_AutoTuneTimeWindow.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NUD_AutoTuneTimeWindow.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUD_AutoTuneTimeWindow.Name = "NUD_AutoTuneTimeWindow"
        Me.NUD_AutoTuneTimeWindow.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneTimeWindow.TabIndex = 18
        Me.NUD_AutoTuneTimeWindow.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Cell AFR Std Dev"
        '
        'NUD_AFRStdDev
        '
        Me.NUD_AFRStdDev.DecimalPlaces = 1
        Me.NUD_AFRStdDev.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUD_AFRStdDev.Location = New System.Drawing.Point(241, 58)
        Me.NUD_AFRStdDev.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUD_AFRStdDev.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NUD_AFRStdDev.Name = "NUD_AFRStdDev"
        Me.NUD_AFRStdDev.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AFRStdDev.TabIndex = 16
        Me.NUD_AFRStdDev.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(310, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "rpm"
        '
        'NUD_ExhaustGasVelocityOffset
        '
        Me.NUD_ExhaustGasVelocityOffset.Location = New System.Drawing.Point(241, 183)
        Me.NUD_ExhaustGasVelocityOffset.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.NUD_ExhaustGasVelocityOffset.Name = "NUD_ExhaustGasVelocityOffset"
        Me.NUD_ExhaustGasVelocityOffset.Size = New System.Drawing.Size(60, 20)
        Me.NUD_ExhaustGasVelocityOffset.TabIndex = 14
        Me.NUD_ExhaustGasVelocityOffset.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Exhaust Gas Velocity Offset"
        '
        'L_AutoTuneStrength
        '
        Me.L_AutoTuneStrength.AutoSize = True
        Me.L_AutoTuneStrength.Location = New System.Drawing.Point(319, 211)
        Me.L_AutoTuneStrength.Name = "L_AutoTuneStrength"
        Me.L_AutoTuneStrength.Size = New System.Drawing.Size(10, 13)
        Me.L_AutoTuneStrength.TabIndex = 12
        Me.L_AutoTuneStrength.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Auto Tune Strength"
        '
        'TB_AutoTuneStrength
        '
        Me.TB_AutoTuneStrength.Location = New System.Drawing.Point(124, 211)
        Me.TB_AutoTuneStrength.Maximum = 120
        Me.TB_AutoTuneStrength.Minimum = 40
        Me.TB_AutoTuneStrength.Name = "TB_AutoTuneStrength"
        Me.TB_AutoTuneStrength.Size = New System.Drawing.Size(177, 45)
        Me.TB_AutoTuneStrength.TabIndex = 10
        Me.TB_AutoTuneStrength.TickFrequency = 10
        Me.TB_AutoTuneStrength.Value = 40
        '
        'B_Cancel
        '
        Me.B_Cancel.Location = New System.Drawing.Point(322, 37)
        Me.B_Cancel.Name = "B_Cancel"
        Me.B_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.B_Cancel.TabIndex = 9
        Me.B_Cancel.Text = "Cancel"
        Me.B_Cancel.UseVisualStyleBackColor = True
        '
        'B_Ok
        '
        Me.B_Ok.Location = New System.Drawing.Point(322, 10)
        Me.B_Ok.Name = "B_Ok"
        Me.B_Ok.Size = New System.Drawing.Size(75, 23)
        Me.B_Ok.TabIndex = 8
        Me.B_Ok.Text = "OK"
        Me.B_Ok.UseVisualStyleBackColor = True
        '
        'K8AutoTuneSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 373)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8AutoTuneSettings"
        Me.ShowInTaskbar = False
        Me.Text = "K8 Auto Tune Settings"
        CType(Me.NUD_AutoTuneMinAvgAFR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMaxAvgAFR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMaxPercentageFuelMapChange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMinNumberLoggedValuesInCell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NUD_AutoTuneMapSmoothingStrength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneTimeWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AFRStdDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_ExhaustGasVelocityOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TB_AutoTuneStrength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NUD_AutoTuneMinAvgAFR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneMaxAvgAFR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneMaxPercentageFuelMapChange As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_AutoTuneMinNumberLoggedValuesInCell As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents B_Cancel As System.Windows.Forms.Button
    Friend WithEvents B_Ok As System.Windows.Forms.Button
    Friend WithEvents TB_AutoTuneStrength As System.Windows.Forms.TrackBar
    Friend WithEvents L_AutoTuneStrength As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NUD_ExhaustGasVelocityOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NUD_AFRStdDev As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneTimeWindow As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneMapSmoothingStrength As System.Windows.Forms.NumericUpDown
End Class
