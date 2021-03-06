﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.C_BoostPressureSensor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NUD_MaxTimeOffset = New System.Windows.Forms.NumericUpDown()
        Me.L_MaxTimeOffset = New System.Windows.Forms.Label()
        Me.NUD_HeaderPipeLength = New System.Windows.Forms.NumericUpDown()
        Me.L_HeaderPipeLength = New System.Windows.Forms.Label()
        Me.NUD_HeaderPipeDiameter = New System.Windows.Forms.NumericUpDown()
        Me.L_HeaderPipeDiameter = New System.Windows.Forms.Label()
        Me.NUD_MaxEngineRPM = New System.Windows.Forms.NumericUpDown()
        Me.L_MaxEngineRPM = New System.Windows.Forms.Label()
        Me.NUD_EngineCapacity = New System.Windows.Forms.NumericUpDown()
        Me.L_EngineCapacity = New System.Windows.Forms.Label()
        Me.R_ExhaustGasVelocityOffset2 = New System.Windows.Forms.RadioButton()
        Me.R_ExhaustGasVelocityOffset1 = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NUD_AutoTuneMapSmoothingStrength = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NUD_AutoTuneTimeWindow = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NUD_AFRStdDev = New System.Windows.Forms.NumericUpDown()
        Me.NUD_ExhaustGasVelocityOffset = New System.Windows.Forms.NumericUpDown()
        Me.L_AutoTuneStrength = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_AutoTuneStrength = New System.Windows.Forms.TrackBar()
        Me.B_Cancel = New System.Windows.Forms.Button()
        Me.B_Ok = New System.Windows.Forms.Button()
        Me.C_BoostTPSFilterEnabled = New System.Windows.Forms.CheckBox()
        Me.NUD_BoostTPSFilterValue = New System.Windows.Forms.NumericUpDown()
        CType(Me.NUD_AutoTuneMinAvgAFR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMaxAvgAFR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMaxPercentageFuelMapChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMinNumberLoggedValuesInCell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.NUD_MaxTimeOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_HeaderPipeLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_HeaderPipeDiameter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_MaxEngineRPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_EngineCapacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMapSmoothingStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneTimeWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AFRStdDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_ExhaustGasVelocityOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TB_AutoTuneStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_BoostTPSFilterValue, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label5.Size = New System.Drawing.Size(527, 50)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(7, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 62)
        Me.Panel1.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.NUD_BoostTPSFilterValue)
        Me.Panel2.Controls.Add(Me.C_BoostTPSFilterEnabled)
        Me.Panel2.Controls.Add(Me.C_BoostPressureSensor)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.NUD_MaxTimeOffset)
        Me.Panel2.Controls.Add(Me.L_MaxTimeOffset)
        Me.Panel2.Controls.Add(Me.NUD_HeaderPipeLength)
        Me.Panel2.Controls.Add(Me.L_HeaderPipeLength)
        Me.Panel2.Controls.Add(Me.NUD_HeaderPipeDiameter)
        Me.Panel2.Controls.Add(Me.L_HeaderPipeDiameter)
        Me.Panel2.Controls.Add(Me.NUD_MaxEngineRPM)
        Me.Panel2.Controls.Add(Me.L_MaxEngineRPM)
        Me.Panel2.Controls.Add(Me.NUD_EngineCapacity)
        Me.Panel2.Controls.Add(Me.L_EngineCapacity)
        Me.Panel2.Controls.Add(Me.R_ExhaustGasVelocityOffset2)
        Me.Panel2.Controls.Add(Me.R_ExhaustGasVelocityOffset1)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMapSmoothingStrength)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneTimeWindow)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.NUD_AFRStdDev)
        Me.Panel2.Controls.Add(Me.NUD_ExhaustGasVelocityOffset)
        Me.Panel2.Controls.Add(Me.L_AutoTuneStrength)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TB_AutoTuneStrength)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMinAvgAFR)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMinNumberLoggedValuesInCell)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMaxAvgAFR)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMaxPercentageFuelMapChange)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(7, 77)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(631, 301)
        Me.Panel2.TabIndex = 10
        '
        'C_BoostPressureSensor
        '
        Me.C_BoostPressureSensor.FormattingEnabled = True
        Me.C_BoostPressureSensor.Location = New System.Drawing.Point(210, 183)
        Me.C_BoostPressureSensor.Name = "C_BoostPressureSensor"
        Me.C_BoostPressureSensor.Size = New System.Drawing.Size(90, 21)
        Me.C_BoostPressureSensor.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Boost Pressure Sensor"
        '
        'NUD_MaxTimeOffset
        '
        Me.NUD_MaxTimeOffset.Location = New System.Drawing.Point(555, 58)
        Me.NUD_MaxTimeOffset.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NUD_MaxTimeOffset.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NUD_MaxTimeOffset.Name = "NUD_MaxTimeOffset"
        Me.NUD_MaxTimeOffset.Size = New System.Drawing.Size(60, 20)
        Me.NUD_MaxTimeOffset.TabIndex = 34
        Me.NUD_MaxTimeOffset.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'L_MaxTimeOffset
        '
        Me.L_MaxTimeOffset.AutoSize = True
        Me.L_MaxTimeOffset.Location = New System.Drawing.Point(372, 60)
        Me.L_MaxTimeOffset.Name = "L_MaxTimeOffset"
        Me.L_MaxTimeOffset.Size = New System.Drawing.Size(106, 13)
        Me.L_MaxTimeOffset.TabIndex = 33
        Me.L_MaxTimeOffset.Text = "Max Time Offset (ms)"
        '
        'NUD_HeaderPipeLength
        '
        Me.NUD_HeaderPipeLength.Location = New System.Drawing.Point(555, 158)
        Me.NUD_HeaderPipeLength.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NUD_HeaderPipeLength.Minimum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NUD_HeaderPipeLength.Name = "NUD_HeaderPipeLength"
        Me.NUD_HeaderPipeLength.Size = New System.Drawing.Size(60, 20)
        Me.NUD_HeaderPipeLength.TabIndex = 32
        Me.NUD_HeaderPipeLength.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'L_HeaderPipeLength
        '
        Me.L_HeaderPipeLength.AutoSize = True
        Me.L_HeaderPipeLength.Location = New System.Drawing.Point(372, 158)
        Me.L_HeaderPipeLength.Name = "L_HeaderPipeLength"
        Me.L_HeaderPipeLength.Size = New System.Drawing.Size(127, 13)
        Me.L_HeaderPipeLength.TabIndex = 31
        Me.L_HeaderPipeLength.Text = "Header Pipe Length (mm)"
        '
        'NUD_HeaderPipeDiameter
        '
        Me.NUD_HeaderPipeDiameter.DecimalPlaces = 1
        Me.NUD_HeaderPipeDiameter.Location = New System.Drawing.Point(555, 132)
        Me.NUD_HeaderPipeDiameter.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NUD_HeaderPipeDiameter.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NUD_HeaderPipeDiameter.Name = "NUD_HeaderPipeDiameter"
        Me.NUD_HeaderPipeDiameter.Size = New System.Drawing.Size(60, 20)
        Me.NUD_HeaderPipeDiameter.TabIndex = 30
        Me.NUD_HeaderPipeDiameter.Value = New Decimal(New Integer() {378, 0, 0, 65536})
        '
        'L_HeaderPipeDiameter
        '
        Me.L_HeaderPipeDiameter.AutoSize = True
        Me.L_HeaderPipeDiameter.Location = New System.Drawing.Point(372, 132)
        Me.L_HeaderPipeDiameter.Name = "L_HeaderPipeDiameter"
        Me.L_HeaderPipeDiameter.Size = New System.Drawing.Size(136, 13)
        Me.L_HeaderPipeDiameter.TabIndex = 29
        Me.L_HeaderPipeDiameter.Text = "Header Pipe Diameter (mm)"
        '
        'NUD_MaxEngineRPM
        '
        Me.NUD_MaxEngineRPM.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NUD_MaxEngineRPM.Location = New System.Drawing.Point(555, 108)
        Me.NUD_MaxEngineRPM.Maximum = New Decimal(New Integer() {18000, 0, 0, 0})
        Me.NUD_MaxEngineRPM.Minimum = New Decimal(New Integer() {8000, 0, 0, 0})
        Me.NUD_MaxEngineRPM.Name = "NUD_MaxEngineRPM"
        Me.NUD_MaxEngineRPM.Size = New System.Drawing.Size(60, 20)
        Me.NUD_MaxEngineRPM.TabIndex = 28
        Me.NUD_MaxEngineRPM.Value = New Decimal(New Integer() {11000, 0, 0, 0})
        '
        'L_MaxEngineRPM
        '
        Me.L_MaxEngineRPM.AutoSize = True
        Me.L_MaxEngineRPM.Location = New System.Drawing.Point(372, 108)
        Me.L_MaxEngineRPM.Name = "L_MaxEngineRPM"
        Me.L_MaxEngineRPM.Size = New System.Drawing.Size(90, 13)
        Me.L_MaxEngineRPM.TabIndex = 27
        Me.L_MaxEngineRPM.Text = "Max Engine RPM"
        '
        'NUD_EngineCapacity
        '
        Me.NUD_EngineCapacity.Location = New System.Drawing.Point(555, 84)
        Me.NUD_EngineCapacity.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NUD_EngineCapacity.Minimum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NUD_EngineCapacity.Name = "NUD_EngineCapacity"
        Me.NUD_EngineCapacity.Size = New System.Drawing.Size(60, 20)
        Me.NUD_EngineCapacity.TabIndex = 26
        Me.NUD_EngineCapacity.Value = New Decimal(New Integer() {1340, 0, 0, 0})
        '
        'L_EngineCapacity
        '
        Me.L_EngineCapacity.AutoSize = True
        Me.L_EngineCapacity.Location = New System.Drawing.Point(372, 84)
        Me.L_EngineCapacity.Name = "L_EngineCapacity"
        Me.L_EngineCapacity.Size = New System.Drawing.Size(105, 13)
        Me.L_EngineCapacity.TabIndex = 25
        Me.L_EngineCapacity.Text = "Engine Capacity (cc)"
        '
        'R_ExhaustGasVelocityOffset2
        '
        Me.R_ExhaustGasVelocityOffset2.AutoSize = True
        Me.R_ExhaustGasVelocityOffset2.Location = New System.Drawing.Point(356, 37)
        Me.R_ExhaustGasVelocityOffset2.Name = "R_ExhaustGasVelocityOffset2"
        Me.R_ExhaustGasVelocityOffset2.Size = New System.Drawing.Size(188, 17)
        Me.R_ExhaustGasVelocityOffset2.TabIndex = 24
        Me.R_ExhaustGasVelocityOffset2.TabStop = True
        Me.R_ExhaustGasVelocityOffset2.Text = "Exhaust Gas Velocity Offset (Time)"
        Me.R_ExhaustGasVelocityOffset2.UseVisualStyleBackColor = True
        '
        'R_ExhaustGasVelocityOffset1
        '
        Me.R_ExhaustGasVelocityOffset1.AutoSize = True
        Me.R_ExhaustGasVelocityOffset1.Location = New System.Drawing.Point(356, 12)
        Me.R_ExhaustGasVelocityOffset1.Name = "R_ExhaustGasVelocityOffset1"
        Me.R_ExhaustGasVelocityOffset1.Size = New System.Drawing.Size(189, 17)
        Me.R_ExhaustGasVelocityOffset1.TabIndex = 23
        Me.R_ExhaustGasVelocityOffset1.TabStop = True
        Me.R_ExhaustGasVelocityOffset1.Text = "Exhaust Gas Velocity Offset (RPM)"
        Me.R_ExhaustGasVelocityOffset1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Map Smoothing Strength ( 0 - 19 )"
        '
        'NUD_AutoTuneMapSmoothingStrength
        '
        Me.NUD_AutoTuneMapSmoothingStrength.Location = New System.Drawing.Point(241, 106)
        Me.NUD_AutoTuneMapSmoothingStrength.Maximum = New Decimal(New Integer() {19, 0, 0, 0})
        Me.NUD_AutoTuneMapSmoothingStrength.Name = "NUD_AutoTuneMapSmoothingStrength"
        Me.NUD_AutoTuneMapSmoothingStrength.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMapSmoothingStrength.TabIndex = 21
        Me.NUD_AutoTuneMapSmoothingStrength.Value = New Decimal(New Integer() {19, 0, 0, 0})
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
        'NUD_ExhaustGasVelocityOffset
        '
        Me.NUD_ExhaustGasVelocityOffset.Location = New System.Drawing.Point(555, 12)
        Me.NUD_ExhaustGasVelocityOffset.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.NUD_ExhaustGasVelocityOffset.Name = "NUD_ExhaustGasVelocityOffset"
        Me.NUD_ExhaustGasVelocityOffset.Size = New System.Drawing.Size(60, 20)
        Me.NUD_ExhaustGasVelocityOffset.TabIndex = 14
        Me.NUD_ExhaustGasVelocityOffset.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'L_AutoTuneStrength
        '
        Me.L_AutoTuneStrength.AutoSize = True
        Me.L_AutoTuneStrength.Location = New System.Drawing.Point(372, 266)
        Me.L_AutoTuneStrength.Name = "L_AutoTuneStrength"
        Me.L_AutoTuneStrength.Size = New System.Drawing.Size(10, 13)
        Me.L_AutoTuneStrength.TabIndex = 12
        Me.L_AutoTuneStrength.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Auto Tune Strength"
        '
        'TB_AutoTuneStrength
        '
        Me.TB_AutoTuneStrength.Location = New System.Drawing.Point(186, 266)
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
        Me.B_Cancel.Location = New System.Drawing.Point(563, 38)
        Me.B_Cancel.Name = "B_Cancel"
        Me.B_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.B_Cancel.TabIndex = 9
        Me.B_Cancel.Text = "Cancel"
        Me.B_Cancel.UseVisualStyleBackColor = True
        '
        'B_Ok
        '
        Me.B_Ok.Location = New System.Drawing.Point(563, 9)
        Me.B_Ok.Name = "B_Ok"
        Me.B_Ok.Size = New System.Drawing.Size(75, 23)
        Me.B_Ok.TabIndex = 8
        Me.B_Ok.Text = "OK"
        Me.B_Ok.UseVisualStyleBackColor = True
        '
        'C_BoostTPSFilterEnabled
        '
        Me.C_BoostTPSFilterEnabled.AutoSize = True
        Me.C_BoostTPSFilterEnabled.Location = New System.Drawing.Point(21, 212)
        Me.C_BoostTPSFilterEnabled.Name = "C_BoostTPSFilterEnabled"
        Me.C_BoostTPSFilterEnabled.Size = New System.Drawing.Size(102, 17)
        Me.C_BoostTPSFilterEnabled.TabIndex = 37
        Me.C_BoostTPSFilterEnabled.Text = "TPS Boost Filter"
        Me.C_BoostTPSFilterEnabled.UseVisualStyleBackColor = True
        '
        'NUD_BoostTPSFilterValue
        '
        Me.NUD_BoostTPSFilterValue.DecimalPlaces = 1
        Me.NUD_BoostTPSFilterValue.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NUD_BoostTPSFilterValue.Location = New System.Drawing.Point(241, 211)
        Me.NUD_BoostTPSFilterValue.Minimum = New Decimal(New Integer() {5, 0, 0, -2147483648})
        Me.NUD_BoostTPSFilterValue.Name = "NUD_BoostTPSFilterValue"
        Me.NUD_BoostTPSFilterValue.Size = New System.Drawing.Size(60, 20)
        Me.NUD_BoostTPSFilterValue.TabIndex = 38
        '
        'K8AutoTuneSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 381)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.B_Ok)
        Me.Controls.Add(Me.B_Cancel)
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
        CType(Me.NUD_MaxTimeOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_HeaderPipeLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_HeaderPipeDiameter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_MaxEngineRPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_EngineCapacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMapSmoothingStrength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneTimeWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AFRStdDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_ExhaustGasVelocityOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TB_AutoTuneStrength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_BoostTPSFilterValue, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents NUD_ExhaustGasVelocityOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_AFRStdDev As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneTimeWindow As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneMapSmoothingStrength As System.Windows.Forms.NumericUpDown
    Friend WithEvents R_ExhaustGasVelocityOffset2 As System.Windows.Forms.RadioButton
    Friend WithEvents R_ExhaustGasVelocityOffset1 As System.Windows.Forms.RadioButton
    Friend WithEvents NUD_EngineCapacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents L_EngineCapacity As System.Windows.Forms.Label
    Friend WithEvents NUD_MaxEngineRPM As System.Windows.Forms.NumericUpDown
    Friend WithEvents L_MaxEngineRPM As System.Windows.Forms.Label
    Friend WithEvents NUD_HeaderPipeDiameter As System.Windows.Forms.NumericUpDown
    Friend WithEvents L_HeaderPipeDiameter As System.Windows.Forms.Label
    Friend WithEvents L_HeaderPipeLength As System.Windows.Forms.Label
    Friend WithEvents NUD_HeaderPipeLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents L_MaxTimeOffset As System.Windows.Forms.Label
    Friend WithEvents NUD_MaxTimeOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents C_BoostPressureSensor As System.Windows.Forms.ComboBox
    Friend WithEvents C_BoostTPSFilterEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents NUD_BoostTPSFilterValue As System.Windows.Forms.NumericUpDown
End Class
