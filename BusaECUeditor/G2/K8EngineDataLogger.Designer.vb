﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8EngineDataLogger
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
        Me.components = New System.ComponentModel.Container
        Me.NUD_LogRate = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.B_ClearCommsLog = New System.Windows.Forms.Button
        Me.C_ShowCommsMessages = New System.Windows.Forms.CheckBox
        Me.T_CommsLog = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.B_StopLogging = New System.Windows.Forms.Button
        Me.B_StartLogging = New System.Windows.Forms.Button
        Me.L_FileName = New System.Windows.Forms.Label
        Me.B_CreateLogFile = New System.Windows.Forms.Button
        Me.L_Status = New System.Windows.Forms.Label
        Me.B_Connect_Datastream = New System.Windows.Forms.Button
        Me.ComboBox_SerialPort = New System.Windows.Forms.ComboBox
        Me.L_CommStatusColour = New System.Windows.Forms.Label
        Me.NUD_DataRate = New System.Windows.Forms.NumericUpDown
        Me.B_ResetComms = New System.Windows.Forms.Button
        Me.L_AFR = New System.Windows.Forms.Label
        Me.B_ViewDataLog = New System.Windows.Forms.Button
        Me.L_BasicData = New System.Windows.Forms.Label
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Timer_UpdateGUI = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.C_WidebandO2Sensor = New System.Windows.Forms.CheckBox
        CType(Me.NUD_LogRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_DataRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NUD_LogRate
        '
        Me.NUD_LogRate.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUD_LogRate.Location = New System.Drawing.Point(620, 34)
        Me.NUD_LogRate.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_LogRate.Name = "NUD_LogRate"
        Me.NUD_LogRate.Size = New System.Drawing.Size(57, 20)
        Me.NUD_LogRate.TabIndex = 60
        Me.NUD_LogRate.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(566, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Log Rate:"
        '
        'B_ClearCommsLog
        '
        Me.B_ClearCommsLog.Location = New System.Drawing.Point(140, 88)
        Me.B_ClearCommsLog.Name = "B_ClearCommsLog"
        Me.B_ClearCommsLog.Size = New System.Drawing.Size(75, 24)
        Me.B_ClearCommsLog.TabIndex = 45
        Me.B_ClearCommsLog.Text = "Clear"
        Me.B_ClearCommsLog.UseVisualStyleBackColor = True
        '
        'C_ShowCommsMessages
        '
        Me.C_ShowCommsMessages.AutoSize = True
        Me.C_ShowCommsMessages.Checked = True
        Me.C_ShowCommsMessages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.C_ShowCommsMessages.Location = New System.Drawing.Point(2, 93)
        Me.C_ShowCommsMessages.Name = "C_ShowCommsMessages"
        Me.C_ShowCommsMessages.Size = New System.Drawing.Size(141, 17)
        Me.C_ShowCommsMessages.TabIndex = 44
        Me.C_ShowCommsMessages.Text = "Show Comms Messages"
        Me.C_ShowCommsMessages.UseVisualStyleBackColor = True
        '
        'T_CommsLog
        '
        Me.T_CommsLog.Location = New System.Drawing.Point(-1, 116)
        Me.T_CommsLog.Multiline = True
        Me.T_CommsLog.Name = "T_CommsLog"
        Me.T_CommsLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.T_CommsLog.Size = New System.Drawing.Size(678, 305)
        Me.T_CommsLog.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(445, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Data Rate"
        '
        'B_StopLogging
        '
        Me.B_StopLogging.Enabled = False
        Me.B_StopLogging.Location = New System.Drawing.Point(105, 32)
        Me.B_StopLogging.Name = "B_StopLogging"
        Me.B_StopLogging.Size = New System.Drawing.Size(97, 23)
        Me.B_StopLogging.TabIndex = 41
        Me.B_StopLogging.Text = "Stop Logging"
        Me.B_StopLogging.UseVisualStyleBackColor = True
        '
        'B_StartLogging
        '
        Me.B_StartLogging.Enabled = False
        Me.B_StartLogging.Location = New System.Drawing.Point(2, 32)
        Me.B_StartLogging.Name = "B_StartLogging"
        Me.B_StartLogging.Size = New System.Drawing.Size(97, 23)
        Me.B_StartLogging.TabIndex = 40
        Me.B_StartLogging.Text = "Start Logging"
        Me.B_StartLogging.UseVisualStyleBackColor = True
        '
        'L_FileName
        '
        Me.L_FileName.AutoSize = True
        Me.L_FileName.Location = New System.Drawing.Point(207, 8)
        Me.L_FileName.Name = "L_FileName"
        Me.L_FileName.Size = New System.Drawing.Size(10, 13)
        Me.L_FileName.TabIndex = 39
        Me.L_FileName.Text = "-"
        '
        'B_CreateLogFile
        '
        Me.B_CreateLogFile.Location = New System.Drawing.Point(2, 3)
        Me.B_CreateLogFile.Name = "B_CreateLogFile"
        Me.B_CreateLogFile.Size = New System.Drawing.Size(97, 23)
        Me.B_CreateLogFile.TabIndex = 38
        Me.B_CreateLogFile.Text = "Create Log File"
        Me.B_CreateLogFile.UseVisualStyleBackColor = True
        '
        'L_Status
        '
        Me.L_Status.AutoSize = True
        Me.L_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Status.Location = New System.Drawing.Point(4, 58)
        Me.L_Status.Name = "L_Status"
        Me.L_Status.Size = New System.Drawing.Size(16, 24)
        Me.L_Status.TabIndex = 37
        Me.L_Status.Text = "-"
        '
        'B_Connect_Datastream
        '
        Me.B_Connect_Datastream.Location = New System.Drawing.Point(605, 58)
        Me.B_Connect_Datastream.Name = "B_Connect_Datastream"
        Me.B_Connect_Datastream.Size = New System.Drawing.Size(75, 23)
        Me.B_Connect_Datastream.TabIndex = 36
        Me.B_Connect_Datastream.Text = "Connect"
        Me.B_Connect_Datastream.UseVisualStyleBackColor = True
        '
        'ComboBox_SerialPort
        '
        Me.ComboBox_SerialPort.FormattingEnabled = True
        Me.ComboBox_SerialPort.Location = New System.Drawing.Point(605, 5)
        Me.ComboBox_SerialPort.Name = "ComboBox_SerialPort"
        Me.ComboBox_SerialPort.Size = New System.Drawing.Size(75, 21)
        Me.ComboBox_SerialPort.TabIndex = 35
        '
        'L_CommStatusColour
        '
        Me.L_CommStatusColour.AutoSize = True
        Me.L_CommStatusColour.Font = New System.Drawing.Font("Wingdings", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.L_CommStatusColour.Location = New System.Drawing.Point(614, 72)
        Me.L_CommStatusColour.Name = "L_CommStatusColour"
        Me.L_CommStatusColour.Size = New System.Drawing.Size(59, 53)
        Me.L_CommStatusColour.TabIndex = 47
        Me.L_CommStatusColour.Text = "l"
        '
        'NUD_DataRate
        '
        Me.NUD_DataRate.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUD_DataRate.Location = New System.Drawing.Point(507, 34)
        Me.NUD_DataRate.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.NUD_DataRate.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NUD_DataRate.Name = "NUD_DataRate"
        Me.NUD_DataRate.Size = New System.Drawing.Size(57, 20)
        Me.NUD_DataRate.TabIndex = 58
        Me.NUD_DataRate.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'B_ResetComms
        '
        Me.B_ResetComms.Location = New System.Drawing.Point(522, 58)
        Me.B_ResetComms.Name = "B_ResetComms"
        Me.B_ResetComms.Size = New System.Drawing.Size(75, 23)
        Me.B_ResetComms.TabIndex = 50
        Me.B_ResetComms.Text = "Reset"
        Me.B_ResetComms.UseVisualStyleBackColor = True
        '
        'L_AFR
        '
        Me.L_AFR.AutoSize = True
        Me.L_AFR.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_AFR.Location = New System.Drawing.Point(231, 37)
        Me.L_AFR.Name = "L_AFR"
        Me.L_AFR.Size = New System.Drawing.Size(21, 29)
        Me.L_AFR.TabIndex = 49
        Me.L_AFR.Text = "-"
        '
        'B_ViewDataLog
        '
        Me.B_ViewDataLog.Location = New System.Drawing.Point(105, 3)
        Me.B_ViewDataLog.Name = "B_ViewDataLog"
        Me.B_ViewDataLog.Size = New System.Drawing.Size(96, 23)
        Me.B_ViewDataLog.TabIndex = 48
        Me.B_ViewDataLog.Text = "View Data Log"
        Me.B_ViewDataLog.UseVisualStyleBackColor = True
        '
        'L_BasicData
        '
        Me.L_BasicData.AutoSize = True
        Me.L_BasicData.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_BasicData.Location = New System.Drawing.Point(231, 88)
        Me.L_BasicData.Name = "L_BasicData"
        Me.L_BasicData.Size = New System.Drawing.Size(19, 25)
        Me.L_BasicData.TabIndex = 46
        Me.L_BasicData.Text = "-"
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 7812
        Me.SerialPort1.ParityReplace = CType(0, Byte)
        Me.SerialPort1.PortName = "COM5"
        Me.SerialPort1.ReadBufferSize = 32
        Me.SerialPort1.WriteBufferSize = 32
        Me.SerialPort1.WriteTimeout = 100
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer_UpdateGUI
        '
        Me.Timer_UpdateGUI.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Interval = 150
        '
        'C_WidebandO2Sensor
        '
        Me.C_WidebandO2Sensor.AutoSize = True
        Me.C_WidebandO2Sensor.Location = New System.Drawing.Point(492, 93)
        Me.C_WidebandO2Sensor.Name = "C_WidebandO2Sensor"
        Me.C_WidebandO2Sensor.Size = New System.Drawing.Size(128, 17)
        Me.C_WidebandO2Sensor.TabIndex = 61
        Me.C_WidebandO2Sensor.Text = "Wideband O2 Sensor"
        Me.C_WidebandO2Sensor.UseVisualStyleBackColor = True
        '
        'K8EngineDataLogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 429)
        Me.Controls.Add(Me.C_WidebandO2Sensor)
        Me.Controls.Add(Me.NUD_LogRate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.B_ClearCommsLog)
        Me.Controls.Add(Me.C_ShowCommsMessages)
        Me.Controls.Add(Me.T_CommsLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.B_StopLogging)
        Me.Controls.Add(Me.B_StartLogging)
        Me.Controls.Add(Me.L_FileName)
        Me.Controls.Add(Me.B_CreateLogFile)
        Me.Controls.Add(Me.L_Status)
        Me.Controls.Add(Me.B_Connect_Datastream)
        Me.Controls.Add(Me.ComboBox_SerialPort)
        Me.Controls.Add(Me.L_CommStatusColour)
        Me.Controls.Add(Me.NUD_DataRate)
        Me.Controls.Add(Me.B_ResetComms)
        Me.Controls.Add(Me.L_AFR)
        Me.Controls.Add(Me.B_ViewDataLog)
        Me.Controls.Add(Me.L_BasicData)
        Me.Name = "K8EngineDataLogger"
        Me.Text = "K8EnginDataLogger"
        CType(Me.NUD_LogRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_DataRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NUD_LogRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents B_ClearCommsLog As System.Windows.Forms.Button
    Friend WithEvents C_ShowCommsMessages As System.Windows.Forms.CheckBox
    Friend WithEvents T_CommsLog As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents B_StopLogging As System.Windows.Forms.Button
    Friend WithEvents B_StartLogging As System.Windows.Forms.Button
    Friend WithEvents L_FileName As System.Windows.Forms.Label
    Friend WithEvents B_CreateLogFile As System.Windows.Forms.Button
    Friend WithEvents L_Status As System.Windows.Forms.Label
    Friend WithEvents B_Connect_Datastream As System.Windows.Forms.Button
    Friend WithEvents ComboBox_SerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents L_CommStatusColour As System.Windows.Forms.Label
    Friend WithEvents NUD_DataRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents B_ResetComms As System.Windows.Forms.Button
    Friend WithEvents L_AFR As System.Windows.Forms.Label
    Friend WithEvents B_ViewDataLog As System.Windows.Forms.Button
    Friend WithEvents L_BasicData As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer_UpdateGUI As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents C_WidebandO2Sensor As System.Windows.Forms.CheckBox
End Class
