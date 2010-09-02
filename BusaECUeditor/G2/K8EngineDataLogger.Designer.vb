<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8EngineDataLogger))
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
        Me.L_Ov = New System.Windows.Forms.Label
        Me.NUD_Widband0v = New System.Windows.Forms.NumericUpDown
        Me.NUD_Widband5v = New System.Windows.Forms.NumericUpDown
        Me.L_5V = New System.Windows.Forms.Label
        CType(Me.NUD_DataRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_Widband0v, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_Widband5v, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'B_ClearCommsLog
        '
        Me.B_ClearCommsLog.Location = New System.Drawing.Point(140, 116)
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
        Me.C_ShowCommsMessages.Location = New System.Drawing.Point(2, 121)
        Me.C_ShowCommsMessages.Name = "C_ShowCommsMessages"
        Me.C_ShowCommsMessages.Size = New System.Drawing.Size(141, 17)
        Me.C_ShowCommsMessages.TabIndex = 44
        Me.C_ShowCommsMessages.Text = "Show Comms Messages"
        Me.C_ShowCommsMessages.UseVisualStyleBackColor = True
        '
        'T_CommsLog
        '
        Me.T_CommsLog.Location = New System.Drawing.Point(-1, 144)
        Me.T_CommsLog.Multiline = True
        Me.T_CommsLog.Name = "T_CommsLog"
        Me.T_CommsLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.T_CommsLog.Size = New System.Drawing.Size(741, 277)
        Me.T_CommsLog.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(621, 37)
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
        Me.L_Status.Location = New System.Drawing.Point(4, 60)
        Me.L_Status.Name = "L_Status"
        Me.L_Status.Size = New System.Drawing.Size(16, 24)
        Me.L_Status.TabIndex = 37
        Me.L_Status.Text = "-"
        '
        'B_Connect_Datastream
        '
        Me.B_Connect_Datastream.Location = New System.Drawing.Point(668, 58)
        Me.B_Connect_Datastream.Name = "B_Connect_Datastream"
        Me.B_Connect_Datastream.Size = New System.Drawing.Size(75, 23)
        Me.B_Connect_Datastream.TabIndex = 36
        Me.B_Connect_Datastream.Text = "Connect"
        Me.B_Connect_Datastream.UseVisualStyleBackColor = True
        '
        'ComboBox_SerialPort
        '
        Me.ComboBox_SerialPort.FormattingEnabled = True
        Me.ComboBox_SerialPort.Location = New System.Drawing.Point(668, 5)
        Me.ComboBox_SerialPort.Name = "ComboBox_SerialPort"
        Me.ComboBox_SerialPort.Size = New System.Drawing.Size(75, 21)
        Me.ComboBox_SerialPort.TabIndex = 35
        '
        'L_CommStatusColour
        '
        Me.L_CommStatusColour.AutoSize = True
        Me.L_CommStatusColour.Font = New System.Drawing.Font("Wingdings", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.L_CommStatusColour.Location = New System.Drawing.Point(701, 73)
        Me.L_CommStatusColour.Name = "L_CommStatusColour"
        Me.L_CommStatusColour.Size = New System.Drawing.Size(59, 53)
        Me.L_CommStatusColour.TabIndex = 47
        Me.L_CommStatusColour.Text = "l"
        '
        'NUD_DataRate
        '
        Me.NUD_DataRate.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUD_DataRate.Location = New System.Drawing.Point(683, 34)
        Me.NUD_DataRate.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.NUD_DataRate.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_DataRate.Name = "NUD_DataRate"
        Me.NUD_DataRate.Size = New System.Drawing.Size(57, 20)
        Me.NUD_DataRate.TabIndex = 58
        Me.NUD_DataRate.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'B_ResetComms
        '
        Me.B_ResetComms.Location = New System.Drawing.Point(585, 58)
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
        Me.L_BasicData.Location = New System.Drawing.Point(231, 116)
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
        Me.C_WidebandO2Sensor.Location = New System.Drawing.Point(581, 90)
        Me.C_WidebandO2Sensor.Name = "C_WidebandO2Sensor"
        Me.C_WidebandO2Sensor.Size = New System.Drawing.Size(128, 17)
        Me.C_WidebandO2Sensor.TabIndex = 61
        Me.C_WidebandO2Sensor.Text = "Wideband O2 Sensor"
        Me.C_WidebandO2Sensor.UseVisualStyleBackColor = True
        '
        'L_Ov
        '
        Me.L_Ov.AutoSize = True
        Me.L_Ov.Enabled = False
        Me.L_Ov.Location = New System.Drawing.Point(578, 121)
        Me.L_Ov.Name = "L_Ov"
        Me.L_Ov.Size = New System.Drawing.Size(20, 13)
        Me.L_Ov.TabIndex = 62
        Me.L_Ov.Text = "0V"
        '
        'NUD_Widband0v
        '
        Me.NUD_Widband0v.DecimalPlaces = 2
        Me.NUD_Widband0v.Enabled = False
        Me.NUD_Widband0v.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NUD_Widband0v.Location = New System.Drawing.Point(599, 119)
        Me.NUD_Widband0v.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.NUD_Widband0v.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUD_Widband0v.Name = "NUD_Widband0v"
        Me.NUD_Widband0v.Size = New System.Drawing.Size(55, 20)
        Me.NUD_Widband0v.TabIndex = 63
        Me.NUD_Widband0v.Value = New Decimal(New Integer() {735, 0, 0, 131072})
        '
        'NUD_Widband5v
        '
        Me.NUD_Widband5v.DecimalPlaces = 2
        Me.NUD_Widband5v.Enabled = False
        Me.NUD_Widband5v.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NUD_Widband5v.Location = New System.Drawing.Point(680, 119)
        Me.NUD_Widband5v.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_Widband5v.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUD_Widband5v.Name = "NUD_Widband5v"
        Me.NUD_Widband5v.Size = New System.Drawing.Size(55, 20)
        Me.NUD_Widband5v.TabIndex = 65
        Me.NUD_Widband5v.Value = New Decimal(New Integer() {2239, 0, 0, 131072})
        '
        'L_5V
        '
        Me.L_5V.AutoSize = True
        Me.L_5V.Enabled = False
        Me.L_5V.Location = New System.Drawing.Point(661, 121)
        Me.L_5V.Name = "L_5V"
        Me.L_5V.Size = New System.Drawing.Size(20, 13)
        Me.L_5V.TabIndex = 64
        Me.L_5V.Text = "5V"
        '
        'K8EngineDataLogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 429)
        Me.Controls.Add(Me.NUD_Widband5v)
        Me.Controls.Add(Me.L_5V)
        Me.Controls.Add(Me.NUD_Widband0v)
        Me.Controls.Add(Me.L_Ov)
        Me.Controls.Add(Me.C_WidebandO2Sensor)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "K8EngineDataLogger"
        Me.Text = "K8 Engine Data Logger"
        CType(Me.NUD_DataRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_Widband0v, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_Widband5v, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents L_Ov As System.Windows.Forms.Label
    Friend WithEvents NUD_Widband0v As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_Widband5v As System.Windows.Forms.NumericUpDown
    Friend WithEvents L_5V As System.Windows.Forms.Label
End Class
