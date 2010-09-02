Imports System.IO.Ports
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.Text

Public Class K8EngineDataLogger

#Region "Variables"

    Public Declare Function FT_GetModemStatus Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByRef modstat As Integer) As Integer
    Public Declare Function FT_SetRts Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_ClrRts Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer

    Public Declare Function FT_SetDtr Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer 'new for Interface V1.1 ***************************************
    Public Declare Function FT_ClrDtr Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer 'new for Interface V1.1 ***************************************

    Public Declare Function FT_SetBreakOn Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_SetBreakOff Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_Open Lib "FTD2XX.DLL" (ByVal iDevice As Integer, ByRef lnghandle As Integer) As Integer
    Public Declare Function FT_GetNumberOfDevices Lib "FTD2XX.DLL" Alias "FT_ListDevices" (ByRef lngNumberofdevices As Integer, ByVal pvarg2 As String, ByVal lngflags As Integer) As Integer
    Public Declare Function FT_ListDevices Lib "FTD2XX.DLL" (ByRef lngNumberofdevices As Integer, ByVal pvarg2 As String, ByVal lngflags As Integer) As Integer
    Public Declare Function FT_Close Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_GetComPortNumber Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByRef portnumber As Integer) As Integer
    Public Declare Function FT_SetBaudRate Lib "FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngBaudRate As Integer) As Integer
    Public Declare Function FT_Write_Bytes Lib "FTD2XX.DLL" Alias "FT_Write" (ByVal lngHandle As Integer, ByRef lpvBuffer As Byte, ByVal lngBufferSize As Integer, ByRef lngBytesWritten As Integer) As Integer
    Public Declare Function FT_Read_Bytes Lib "FTD2XX.DLL" Alias "FT_Read" (ByVal lngHandle As Integer, ByRef lpvBuffer As Byte, ByVal lngBufferSize As Integer, ByRef lngBytesReturned As Integer) As Integer
    Public Declare Function FT_GetStatus Lib "FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lngamountInRxQueue As Integer, ByRef lngAmountInTxQueue As Integer, ByRef lngEventStatus As Integer) As Integer
    Public Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
    Public Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
    Public Declare Function FT_SetDataCharacteristics Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByVal uWordLength As Byte, ByVal uStopBits As Byte, ByVal uParity As Byte) As Integer
    Public Declare Function FT_SetTimeouts Lib "FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal rxTimeout As Integer, ByVal txTimeout As Integer) As Integer
    Public Declare Function FT_SetLatencyTimer Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByVal uTime As Byte) As Integer
    Public Declare Function FT_SetUSBParameters Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByVal dwInTransferSize As Integer, ByVal dwOutTransferSize As Integer) As Integer

    Declare Function QueryPerformanceCounter Lib "Kernel32" (ByRef X As Long) As Short 'new HighResTimer*******************************
    Declare Function QueryPerformanceFrequency Lib "Kernel32" (ByRef X As Long) As Short    ' new HighResTimer************************

    Public debug As Boolean = False

    Public lngHandle As Integer
    Public comPortNumber As Integer
    Public rxbyte As Byte
    Public ticking As Integer
    Public FT_status As Integer
    Public rxqueue, txqueue, eventstat As Integer
    Public rxsptr As Integer
    Public rxs(128) As Byte
    Public kwpcomm As Integer
    Public slowinitdelay As Integer
    Public msgactive As Integer

    Dim HOX_ON As Boolean = True

    Dim bit15 As UInt16 = &H2 ^ 15
    Dim bit14 As UInt16 = &H2 ^ 14
    Dim bit13 As UInt16 = &H2 ^ 13
    Dim bit12 As UInt16 = &H2 ^ 12
    Dim bit11 As UInt16 = &H2 ^ 11
    Dim bit10 As UInt16 = &H2 ^ 10
    Dim bit9 As UInt16 = &H2 ^ 9
    Dim bit8 As UInt16 = &H2 ^ 8
    Dim bit7 As UInt16 = &H2 ^ 7
    Dim bit6 As UInt16 = &H2 ^ 6
    Dim bit5 As UInt16 = &H2 ^ 5
    Dim bit4 As UInt16 = &H2 ^ 4
    Dim bit3 As UInt16 = &H2 ^ 3
    Dim bit2 As UInt16 = &H2 ^ 2
    Dim bit1 As UInt16 = &H2 ^ 1
    Dim bit0 As UInt16 = &H2 ^ 0

    Dim h_received As Boolean = False

    Dim bytecount As Integer
    Dim checksum As Integer
    Dim serialbyte(12) As Byte
    Dim temperature As Integer
    Dim checksumerror As Integer
    Dim CLT_high As Boolean
    Dim iactive As Boolean
    Dim onceactive As Boolean
    Dim ch_TPS As Integer
    Dim ch_IAP As Integer
    Dim ch_RPM As Integer
    Dim ch_CLT As Integer
    Dim ch_IGN As Integer
    Dim ch_USR As Integer
    Dim RPMhi As Integer
    Dim RPMlo As Integer
    Dim FUELhi1 As Integer
    Dim FUELlo1 As Integer
    Dim FUELhi2 As Integer
    Dim FUELlo2 As Integer
    Dim FUELhi3 As Integer
    Dim FUELlo3 As Integer
    Dim FUELhi4 As Integer
    Dim FUELlo4 As Integer
    Dim FUEL1, FUEL2, FUEL3, FUEL4 As Integer
    Dim qpc1, qpc2, qfreq As Long
    Dim qtmp As Integer
    Dim doneonce As Boolean
    Dim timerinterval, perferrorcounter, perferrorlimit As Integer
    Dim modeabc As Boolean
    Dim duty As Integer

    Dim RPM As Integer
    Dim BOOST As Integer
    Dim BOOST2 As Integer
    Dim TPS As Integer
    Dim IP As Integer
    Dim IAPabs As Integer
    Dim CLT As Integer
    Dim IAT As Integer
    Dim AP As Integer
    Dim SAPabs As Integer
    Dim IAP As Integer
    Dim BATT As Integer
    Dim HO2 As Integer
    Dim WIDEBAND1 As Integer
    Dim WIDEBAND2 As Integer
    Dim WIDEBAND As Integer
    Dim GEAR As Integer
    Dim IGN As Integer
    Dim STP As Integer
    Dim DSM1 As Integer
    Dim PAIR As Integer
    Dim MS As Integer
    Dim CLUTCH As Integer
    Dim NT As Integer
    Dim MODE As Integer

    Dim MTS_AFR As Double

    Dim counter As Integer

    Dim filePath As String
    Dim filePathRaw As String

    Dim _continueLogging As Boolean = False
    Dim _connected As Boolean = False
    Dim _mtsConnected As Boolean = False

    Dim EngineDataCommsStopwatch As New Stopwatch
    Dim numberOfLogs As Long
    Dim logRate As Integer = 75
    Dim commStatus As String

    Private Delegate Sub LogMessage(ByVal message As String)
    Dim LogCommsMessage As LogMessage

    Dim _initialized As Boolean = False


    Dim LogFile As StreamWriter
    Dim LogFileRaw As StreamWriter
    Dim _logTime As String
    Private _syncRoot As Object = New Object()
    Private _syncRootComms As Object = New Object()
    Dim _sendCommsMessages As Boolean = False
    Dim _echoCount As Integer = 0
    Dim _lastCommsDate As DateTime = DateTime.Now

    Dim _repeatedDataCount As Integer
    Dim _lastTPS As Integer
    Dim _lastRPM As Integer
    Dim _lastIAP As Integer
    Dim _lastHO2 As Integer
    Dim _lastWideBand As Integer
    Dim _lastFuel1 As Integer
    Dim _newData As Boolean = False
    Dim _reConnect As Boolean = False

#End Region

#Region "Properties"

    Public Property SendCommsMessages() As Boolean
        Get

            Return _sendCommsMessages

        End Get
        Set(ByVal value As Boolean)

            _sendCommsMessages = value

        End Set
    End Property

    Public Property ContinueLogging() As Boolean
        Get

            Return _continueLogging

        End Get
        Set(ByVal value As Boolean)

            _continueLogging = value

        End Set
    End Property

#End Region

#Region "Form Events"

    Private Sub K8EngineDataLogger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        C_WidebandO2Sensor.Checked = My.Settings.WidebandO2Sensor
        NUD_Widband0v.Value = My.Settings.Wideband0V
        NUD_Widband5v.Value = My.Settings.Wideband5V

        Dim i As Integer
        Dim j As Integer
        Dim userComPort As String
        Dim pvs As String
        Dim OkToActivate As Boolean
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String
        doneonce = False

        LogCommsMessage = New LogMessage(AddressOf T_CommsLog_AddMessage)

        iactive = False
        onceactive = False
        RPM = 0

        j = 0
        i = 1
        pvs = ""
        userComPort = My.Settings.Item("ComPort")

        Try

            j = -1
            i = 0
            ComboBox_SerialPort.Items.Clear()

            For Each port In ports

                ComboBox_SerialPort.Items.Add(port)

                If port = userComPort Then
                    j = i
                End If

                i = i + 1

            Next port

        Catch ex As Exception

            MessageBox.Show("An error occurred while searching valid COM ports " & ex.Message)
            _connected = False
            OkToActivate = False

        End Try

        If j >= 0 Then
            ComboBox_SerialPort.SelectedIndex = j

            'If j = 1 Then OKtoactivate = True ' only one FTDI comport found, ok to activate
            OkToActivate = True ' only one FTDI comport found, ok to activate

        Else
            OkToActivate = False
            _connected = False
            MsgBox("Interface needs to be set. Select the correct com port. ", MsgBoxStyle.Information)
        End If

        ' Initialize the program, input for everything is serialport.portname 
        If ComboBox_SerialPort.Text <> "" Then

            SerialPort1.PortName = ComboBox_SerialPort.Text ' this will be used for FTDI device handle, important to have correct value here

            If Len(SerialPort1.PortName) = 4 Then
                comPortNumber = Val(Mid$(SerialPort1.PortName, 4))   ' com port address
                If ((comPortNumber < 0) Or (comPortNumber > 15)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")
            Else
                comPortNumber = Val(Mid$(SerialPort1.PortName, 5))   ' com port address
                If ((comPortNumber < 0) Or (comPortNumber > 15)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")

            End If

        End If

        QueryPerformanceFrequency(qfreq)
        slowinitdelay = 23

        If OkToActivate Then

            StartEngineDataComms()

        End If

        NUD_DataRate.Value = My.Settings.DataRate

        Timer2.Interval = My.Settings.DataRate
        logRate = My.Settings.LogRate

    End Sub

    Private Sub K8EngineDataLogger_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        _initialized = True

    End Sub

    Private Sub K8EngineDataLogger_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        StopEngineDataComms()

    End Sub

#End Region

#Region "Control Events"

    Private Sub ComboBox_SerialPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_SerialPort.SelectedIndexChanged
        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
                SerialPort1.PortName = ComboBox_SerialPort.Text
                SerialPort1.Open()
            Else
                SerialPort1.PortName = ComboBox_SerialPort.Text
                SerialPort1.Open()
                SerialPort1.Close()
            End If
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.OkOnly)

        End Try

        My.Settings.ComPort = ComboBox_SerialPort.Text
        My.Settings.Save()

        comPortNumber = Val(Mid$(SerialPort1.PortName, 4))   ' com port address for FTDI driver

        If ((comPortNumber < 0) Or (comPortNumber > 15)) Then
            MsgBox("USB FTDI COMport is non existing or out of range, program may not work")
        End If

    End Sub

    Private Sub B_Connect_Datastream_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Connect_Datastream.Click

        Dim i As Integer
        Dim j As Integer
        Dim s As String
        Dim pvs As String

        Dim OKtoactivate As Boolean
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String

        If B_Connect_Datastream.Text = "Connect" Then

            B_Connect_Datastream.Text = "Close"

            _lastCommsDate = DateTime.Now
            _repeatedDataCount = 0

            j = 0
            i = 1
            pvs = ""
            s = My.Settings.Item("ComPort")

            Try

                j = -1
                i = 0
                ComboBox_SerialPort.Items.Clear()

                For Each port In ports
                    ComboBox_SerialPort.Items.Add(port)
                    If port = s Then
                        j = i
                    End If
                    i = i + 1
                Next port

            Catch ex As Exception
                MessageBox.Show("An error occurred while searching valid COM ports " & ex.Message)
                OKtoactivate = False
            End Try
            If j >= 0 Then
                ComboBox_SerialPort.SelectedIndex = j
                'If j = 1 Then OKtoactivate = True ' only one FTDI comport found, ok to activate
                OKtoactivate = True ' only one FTDI comport found, ok to activate
            Else
                OKtoactivate = False
                MsgBox("Interface needs to be set. Select the correct com port on the following engine data monitoring screen. ", MsgBoxStyle.Information)
            End If


            ' Initialize the program, input for everything is serialport.portname 
            If ComboBox_SerialPort.Text <> "" Then

                SerialPort1.PortName = ComboBox_SerialPort.Text ' this will be used for FTDI device handle, important to have correct value here
                slowinitdelay = 23

                If Len(SerialPort1.PortName) = 4 Then
                    comPortNumber = Val(Mid$(SerialPort1.PortName, 4))   ' com port address
                    If ((comPortNumber < 0) Or (comPortNumber > 9)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")
                Else
                    comPortNumber = Val(Mid$(SerialPort1.PortName, 5))   ' com port address
                    If ((comPortNumber < 0) Or (comPortNumber > 15)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")

                End If

                B_Connect_Datastream.Enabled = True

            End If

            If OKtoactivate Then
                StartEngineDataComms()
            End If

            kwpcomm = &H10

            FT_status = FT_SetRts(lngHandle)
            System.Threading.Thread.Sleep(300)

            FT_status = FT_ClrRts(lngHandle)
            System.Threading.Thread.Sleep(2000)

        Else

            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

            If FT_status = 0 Then
                StopEngineDataComms()
            End If

            ticking = 0

        End If

    End Sub

    Private Sub B_CreateLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_CreateLogFile.Click

        SaveFileDialog1.Filter = ".csv|*.csv"
        SaveFileDialog1.FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm")

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            filePath = SaveFileDialog1.FileName
            filePathRaw = filePath.Substring(0, filePath.Length - 4) & " Raw.csv"
            B_StartLogging.Enabled = True
            L_FileName.Text = filePath

            'Automatically start logging
            B_StartLogging_Click(sender, e)
        End If

    End Sub

    Private Sub B_StartLogging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_StartLogging.Click

        If String.IsNullOrEmpty(filePath) = False Then

            B_CreateLogFile.Enabled = False
            B_ViewDataLog.Enabled = False
            B_StartLogging.Enabled = False
            B_StopLogging.Enabled = True

            numberOfLogs = 0
            logRate = Timer2.Interval / 2

            'LogFile = New StreamWriter(filePath)
            LogFileRaw = New StreamWriter(filePathRaw)

            WriteDataLogHeader()
            WriteDataLog()

            EngineDataCommsStopwatch.Reset()
            EngineDataCommsStopwatch.Start()

            Me.ContinueLogging = True

            'Start Thread to log data
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf EngineDataLoggingLoop))

        End If

    End Sub

    Private Sub B_StopLogging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_StopLogging.Click

        B_CreateLogFile.Enabled = True
        B_ViewDataLog.Enabled = True
        B_StartLogging.Enabled = True
        B_StopLogging.Enabled = False

        Me.ContinueLogging = False

        If LogFile Is Nothing = False Then

            LogFile.Close()
            LogFile = Nothing

        End If

        If LogFileRaw Is Nothing = False Then

            LogFileRaw.Close()
            LogFileRaw = Nothing

        End If
    End Sub

    Private Sub B_ViewDataLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ViewDataLog.Click

        K8EngineDataViewer.Show()
        K8EngineDataViewer.OpenFile(filePathRaw)

    End Sub

    Private Sub B_ClearCommsLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ClearCommsLog.Click

        T_CommsLog.Clear()

    End Sub

    Private Sub Timer_UpdateGUI_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_UpdateGUI.Tick

        If _reConnect = True Then
            _reConnect = False
            Connect()
        End If

        If Me.SendCommsMessages = True And (DateTime.Now.Subtract(_lastCommsDate).TotalSeconds > 60) Then
            AddCommsMessage("Auto Reset Comms: Last Comms Date > 90sec ago or Same Data Repeated > 50 times")
            EnableTimer2(False)
            Disconnect()
            _connected = False
            Thread.Sleep(2000)
            _reConnect = True
            _repeatedDataCount = 0
            _lastCommsDate = DateTime.Now
        End If

        If _connected = True Then

            B_Connect_Datastream.Text = "Close"
            L_CommStatusColour.ForeColor = Color.Green
            L_BasicData.Text = "TPS: " & CalcTPS(TPS) & " RPM: " & RPM & " IAP: " & CalcPressure(IAP) & " Gear: " & GEAR
            
            If C_WidebandO2Sensor.Checked = True Then
                L_AFR.Text = "AFR: " + CalcWidebandAFR(WIDEBAND).ToString("00.00")
            Else
                L_AFR.Text = "AFR: " + CalcAFR(HO2).ToString("00.00")
            End If

        ElseIf _connected = False Then

            B_Connect_Datastream.Text = "Connect"
            L_CommStatusColour.ForeColor = Color.Red
            L_BasicData.Text = ""
            L_AFR.Text = ""
            
        End If

        L_Status.Text = "Log Count: " & numberOfLogs.ToString()

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Dim i As Integer
        Dim txbyte As Byte
        Dim cksum As Integer
        Dim x, y As Integer
        Dim bytecount As Integer
        Dim modemstat As Integer
        Dim failcount As Integer

        'new Var for HighResTimer*********************************************
        Dim Ctr1 As Long
        Dim Ctr2 As Long
        Dim Freq As Long
        '*******************End************************************************

        ' Disable timer when processing the received package

        ' Read if there is anything in the receive queue
        FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

        ' Initialize variables
        cksum = 0
        rxsptr = 0
        ticking = ticking + 1 ' a counter that counts that the process is active

        ' Perform read package if no comms error and there is something to be read in receive queueue
        If FT_status = 0 And rxqueue > 0 Then
            For i = 1 To rxqueue
                FT_Read_Bytes(lngHandle, rxbyte, 1, 1)
                If rxsptr > 128 Then rxsptr = 128
                rxs(rxsptr) = rxbyte
                rxsptr = rxsptr + 1
                'If Debug Then T_datacomm.Text = T_datacomm.Text & Format(rxbyte, "x2") & " "
            Next

            ticking = 0

        End If

        ' Rxqueue is 0x5 which is likely the echo from init request, reinit with different 5baud delays
        If rxqueue = 5 Then

            ' &H10 reset again
            kwpcomm = &H10

            ' Try different 5baud init delays in case not connecting easily
            System.Threading.Thread.Sleep(300)

            If slowinitdelay >= 22 Then
                slowinitdelay = slowinitdelay - 1
            Else
                slowinitdelay = 24 ' this is the max delay according to spec
                failcount = 0
            End If

        End If

        ' Rxqueue contains data, but its a negative response to command &H21, just redo after a small sleep
        If (rxqueue >= 11) And (kwpcomm = &H21) And (rxs(11) = &H7F) Then
            System.Threading.Thread.Sleep(300)
            kwpcomm = &H21
            EnableTimer2(True)
        End If

        ' Process what to do to previously read data
        QueryPerformanceFrequency(qfreq)
        QueryPerformanceCounter(qpc1)
        ReadDataString()
        QueryPerformanceCounter(qpc2)

        If qpc2 <> 0 Then
            qtmp = Int((qpc2 - qpc1) / (qfreq / 1000000) / 1000) 'performance in ms
            If qtmp > perferrorlimit Then
                perferrorcounter = perferrorcounter + 1
            End If
            If (qtmp > perferrorlimit) And (Not doneonce) Then
                If perferrorcounter > 10 Then
                    Timer2.Interval = My.Settings.DataRate * 2
                Else
                    Timer2.Interval = My.Settings.DataRate
                End If
            End If

            If perferrorcounter > 10 Then
                'AddCommsMessage("Please not that this PC may be to slow for the datastream to work in debug mode, press d to stop debug mode.")
                perferrorcounter = 0
            End If

        End If

        ' Process commands
        Select Case kwpcomm
            Case &H0

                ' just listening the line

            Case &H10

                EnableTimer2(False)

                ' Initialize comms
                ' Get the FTDI device handle based on com port number
                FT_status = FT_GetNumberOfDevices(i, 0, &H80000000)

                AddCommsMessage("Number of FTDI devices connected = " & i)

                i = i - 1

                For x = 0 To i
                    FT_status = FT_Open(i, lngHandle) ' only one
                    FT_status = FT_GetComPortNumber(lngHandle, y)

                    If y = comPortNumber Then
                        x = i
                    Else
                        FT_status = FT_Close(lngHandle)
                    End If
                Next

                'FT_status = FT_SetBaudRate(lngHandle, 10400)
                FT_status = FT_SetBaudRate(lngHandle, BaudRate)
                FT_status = FT_status + FT_SetDataCharacteristics(lngHandle, 8, 1, 0)   ' 8bits ,1 stop, parity none
                FT_status = FT_status + FT_SetTimeouts(lngHandle, 5, 5)               'rx and tx timeouts 10ms
                FT_status = FT_status + FT_SetLatencyTimer(lngHandle, 16)               'ms 16 is default
                FT_status = FT_status + FT_SetUSBParameters(lngHandle, 4096, 4096)      'only rx is active by FTDI

                FT_status = FT_ClrDtr(lngHandle) 'new for Interface V1.1 *****************************************************************

                AddCommsMessage("FTDI USB device opened for " & BaudRate & " baud, id=" & i & ", port=" & comPortNumber)
                AddCommsMessage("Initiating 5baud fast initialization")

                i = slowinitdelay

                'FTDI USB device ok, lets chect that the device is in data monitoring mode
                FT_status = FT_GetModemStatus(lngHandle, modemstat)

                If (modemstat <> &H6010) Then
                    AddCommsMessage("Error: Power is not on, ECU is in programming mode or COM port is not set correcly. Modemstat=" & Hex(modemstat) & ", Comporterr=" & Hex(FT_status))
                    AddCommsMessage("")
                    _connected = False
                    EnableTimer2(False)
                    Me.SendCommsMessages = False
                    Return
                End If

                '*************New Code***************************************************************
                Ctr1 = 0
                Ctr2 = 0
                Freq = 0

                If QueryPerformanceCounter(Ctr1) Then

                    QueryPerformanceCounter(Ctr2)
                    QueryPerformanceFrequency(Freq)

                    FT_status = FT_SetBreakOff(lngHandle)       ' K-line high
                    Do Until (Ctr2 - Ctr1) / (Freq / 1000000) >= 300000 'wait 300ms
                        QueryPerformanceCounter(Ctr2)
                    Loop
                    FT_status = FT_SetBreakOn(lngHandle)        ' K-line low
                    Do Until (Ctr1 - Ctr2) / (Freq / 1000000) >= 24500 'wait 25ms
                        QueryPerformanceCounter(Ctr1)
                    Loop
                    FT_status = FT_SetBreakOff(lngHandle)       ' K-line high
                    Do Until (Ctr2 - Ctr1) / (Freq / 1000000) >= 24500 'wait 25ms
                        QueryPerformanceCounter(Ctr2)
                    Loop

                Else

                    '***********old Code*************************
                    ' Reset ecu
                    If RPM = 0 Then
                        FT_status = FT_SetRts(lngHandle)
                        System.Threading.Thread.Sleep(300)
                        FT_status = FT_ClrRts(lngHandle)
                    End If

                    If RPM > 400 Then
                        AddCommsMessage("Press OK to restart ECU for resynchronizing")
                        FT_status = FT_SetRts(lngHandle)
                        System.Threading.Thread.Sleep(300)
                        FT_status = FT_ClrRts(lngHandle)
                    End If

                    ' 5 Baud Init using FTDI usb driver
                    System.Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Highest
                    timeBeginPeriod(1)
                    FT_status = FT_SetBreakOff(lngHandle)       ' K-line high
                    System.Threading.Thread.Sleep(300)
                    FT_status = FT_SetBreakOn(lngHandle)        ' K-line low
                    System.Threading.Thread.Sleep(i)
                    FT_status = FT_SetBreakOff(lngHandle)       ' K-line high
                    System.Threading.Thread.Sleep(i)
                    timeEndPeriod(1)
                    System.Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Normal

                End If


                ' Capture &H00 from ECU that is not correct the &H00 is the echo from the FT_SetBreakOn
                ticking = 0
                rxbyte = &HFF
                bytecount = 0
                x = 1

                'the only thing is here to see that is the RXD Pin is high****************************
                While (ticking < 25) And (rxbyte <> 0) And (bytecount = 0)
                    ticking = ticking + 1
                    FT_status = FT_Read_Bytes(lngHandle, rxbyte, 1, bytecount)
                    'T_datacomm.Text = T_datacomm.Text & Chr(13) & Chr(10) & "Captured &H00 from ECU" & " using " & i & "ms"
                    i = 23 ' break the for next loop when &H00 found
                End While

                ' Send init request to ecu if &H00 read succesfully
                If ticking < 25 Then
                    txbyte = &H81
                    FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                    txbyte = &H12
                    FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                    txbyte = &HF1
                    FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                    txbyte = &H81
                    FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                    txbyte = &H5
                    FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                    ' Pass control timer to read bytes continously with kwpcommand &H21, read local id data
                    kwpcomm = &H21
                    ticking = 0
                    AddCommsMessage("Completed 5baud fast initialization" & Chr(13) & Chr(10))
                    EnableTimer2(True)
                Else
                    EnableTimer2(False)
                    ticking = 0
                    FT_status = FT_Close(lngHandle)
                    AddCommsMessage("Failed 5baud initialization" & Chr(13) & Chr(10))
                End If

                counter = 0

            Case &H21

                ' Request next data package and parse the package read earlier
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H2
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H21
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H8
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H2 + &H21 + &H8) And &HFF ' &HAE
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21

                ' Every nth counter loops execute next read other commands
                '
                'counter = counter + 1
                'If ((counter = 5) And modeabc) Or ((counter = 5) And (RPM < 2000)) Or ((counter = 5) And (debug)) Then
                '    modeabc = False
                '    kwpcomm = &H2180
                'End If
                'If ((counter = 10) And (RPM < 2000)) Or ((counter = 10) And (debug)) Then
                '    kwpcomm = &H21C0
                'End If
                'If ((counter = 15) And (RPM < 2000)) Or ((counter = 15) And (debug)) Then 'Get DTC
                '    kwpcomm = &H18
                'End If
                'If counter >= 15 Then
                '    counter = 0
                'End If

            Case &H2180

                ' Request next data package and parse the package read earlier
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H2
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H21
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H2 + &H21 + &H80) And &HFF ' &HAE
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21
                EnableTimer2(True)

            Case &H21C0

                ' Request next data package and parse the package read earlier
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H2
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H21
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HC0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H2 + &H21 + &HC0) And &HFF ' &HAE
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21
                EnableTimer2(True)

            Case &H2140

                ' Request next data package and parse the package read earlier
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H2
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H21
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H40
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H2 + &H21 + &H40) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21
                EnableTimer2(True)

            Case &H14

                ' Send Clear DTC command to ecu, not tested
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H3
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H14
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H3 + &H14 + &H0 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21
                EnableTimer2(True)

            Case &H18

                ' Get DTC
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H4
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H18
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H4 + &H18 + &H0 + &H0 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21
                EnableTimer2(True)

            Case &H1A

                ' Get ECUid
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H2
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H1A
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H91
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H2 + &H1A + &H91) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                rxsptr = 0
                kwpcomm = &H21
                EnableTimer2(True)

            Case &H82

                ' Send close comms command to ecu
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H81
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H1 + &H81) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                ' Close also the com port
                FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

                If FT_status = 0 Then
                    ticking = 0
                    FT_status = FT_Close(lngHandle)
                End If

                AddCommsMessage("Close Comms message sent to ECU")

                Thread.Sleep(1000)

                kwpcomm = &H10
                EnableTimer2(True)

                'FT_status = FT_Close(lngHandle)
                'L_comms.ForeColor = Color.Red
                'B_Connect_Datastream.Text = "Connect"
                'Me.Text = "Hayabusa Ecueditor2 - Press connect to activate enginedata"

            Case &H3E

                ' Send Keepalive package to ecu, not tested
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HE
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)

                kwpcomm = &H21
                EnableTimer2(True)

            Case Else
                AddCommsMessage(" - unknown command - ")
                EnableTimer2(False)

        End Select

        ' No response from the line for a while, lets kill the comms
        If ticking > 25 Then

            kwpcomm = &H82
            EnableTimer2(True)

        End If

        ' If map is visible then perform tracemap for both maps
        '
        'If fuelmapvisible Then
        '    Select Case ECUversion
        '        Case "gen2"
        '            If MODE <> K8Fuelmap.setmode Then
        '                If K8Fuelmap.Visible Then
        '                    'K8Fuelmap.setmode = MODE
        '                    '
        '                    ' xxxxxxxxxxxxxxxxxx
        '                    '
        '                    'MsgBox("Please change fuelmap Mode to same as the gauge shows")
        '                End If

        '            End If
        '            K8Fuelmap.tracemap()
        '        Case "bking"
        '            BKingFuelmap.tracemap()
        '            If MODE <> BKingFuelmap.setmode Then
        '                If BKingFuelmap.Visible Then
        '                    'BKingFuelmap.setmode = MODE
        '                    'MsgBox("Please change fuelmap Mode to same as the gauge shows")
        '                End If
        '            End If
        '    End Select
        'End If
        'If Ignitionmapvisible Then K8Ignitionmap.tracemap()
        'If K8boostfuel.Visible Then K8boostfuel.tracemap()
        'If K8STPmap.Visible Then K8STPmap.tracemap(GEAR, MS, MODE)
        'If K8nitrouscontrol.Visible Then K8nitrouscontrol.tracemap()

    End Sub

    Private Sub AddCommsMessage(ByVal message As String)

        Try

            Dim params() As Object = {message}
            Me.Invoke(LogCommsMessage, params)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub T_CommsLog_AddMessage(ByVal message As String)

        If C_ShowCommsMessages.Checked = True Then

            T_CommsLog.AppendText(message)
            T_CommsLog.AppendText(Environment.NewLine)

        End If

    End Sub

    Private Sub B_ResetComms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ResetComms.Click

        Disconnect()
        Thread.Sleep(2000)
        _reConnect = True

    End Sub

    Private Sub NUD_DataRate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_DataRate.ValueChanged

        If _initialized = True Then

            My.Settings.DataRate = NUD_DataRate.Value
            My.Settings.Save()

            Timer2.Interval = NUD_DataRate.Value

        End If

    End Sub

    Private Sub C_WidebandO2Sensor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_WidebandO2Sensor.CheckedChanged

        If C_WidebandO2Sensor.Checked Then
            L_5V.Enabled = True
            L_Ov.Enabled = True
            NUD_Widband0v.Enabled = True
            NUD_Widband5v.Enabled = True
        Else
            L_5V.Enabled = False
            L_Ov.Enabled = False
            NUD_Widband0v.Enabled = False
            NUD_Widband5v.Enabled = False
        End If

        My.Settings.WidebandO2Sensor = C_WidebandO2Sensor.Checked
        My.Settings.Save()

    End Sub

    Private Sub NUD_Widband0v_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Widband0v.ValueChanged

        If _initialized = True Then

            My.Settings.Wideband0V = NUD_Widband0v.Value
            My.Settings.Save()
        End If

    End Sub

    Private Sub NUD_Widband5v_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Widband5v.ValueChanged

        If _initialized = True Then
            My.Settings.Wideband5V = NUD_Widband5v.Value
            My.Settings.Save()
        End If

    End Sub

#End Region

#Region "Functions"

    Public Sub Connect()

        Dim i As Integer
        Dim j As Integer
        Dim userComPort As String

        Dim OkToActivate As Boolean
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String

        _lastCommsDate = DateTime.Now
        _repeatedDataCount = 0

        j = 0
        i = 1

        userComPort = My.Settings.Item("ComPort")

        Try

            j = -1
            i = 0

            For Each port In ports

                If port = userComPort Then
                    j = i
                End If

                i = i + 1
            Next port

        Catch ex As Exception
            AddCommsMessage("An error occurred while searching valid COM ports " & ex.Message)
            OkToActivate = False
        End Try

        If j >= 0 Then
            OkToActivate = True ' only one FTDI comport found, ok to activate
        Else
            OkToActivate = False
            AddCommsMessage("Interface needs to be set. Select the correct com port on the following engine data monitoring screen. ")
        End If

        SerialPort1.PortName = ComboBox_SerialPort.Text ' this will be used for FTDI device handle, important to have correct value here
        slowinitdelay = 23

        If Len(SerialPort1.PortName) = 4 Then
            comPortNumber = Val(Mid$(SerialPort1.PortName, 4))   ' com port address
            If ((comPortNumber < 0) Or (comPortNumber > 9)) Then AddCommsMessage("USB FTDI COMport is non existing or out of normal range, program may not work")
        Else
            comPortNumber = Val(Mid$(SerialPort1.PortName, 5))   ' com port address
            If ((comPortNumber < 0) Or (comPortNumber > 15)) Then AddCommsMessage("USB FTDI COMport is non existing or out of normal range, program may not work")
        End If

        If OkToActivate Then
            StartEngineDataComms()
        End If

        kwpcomm = &H10

        FT_status = FT_SetRts(lngHandle)
        System.Threading.Thread.Sleep(300)

        FT_status = FT_ClrRts(lngHandle)
        System.Threading.Thread.Sleep(2000)

    End Sub

    Public Sub Disconnect()

        _connected = False

        FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

        If FT_status = 0 Then
            StopEngineDataComms()
        End If

        ticking = 0

    End Sub

    Private Sub SendCommsMessage()

        SyncLock _syncRootComms

            If Me.SendCommsMessages = False Then
                Return
            End If

            ' Initialize variables
            rxsptr = 0
            ticking = ticking + 1 ' a counter that counts that the process is active

            'Read Data waiting in the Rx Queue
            ReadRxQueue()

            ' Rxqueue is 0x5 which is likely the echo from init request, reinit with different 5baud delay
            If rxqueue = 5 Then

                AddCommsMessage("rxqueue = 5")

                _echoCount = _echoCount + 1

                ' Reinitialize very nth time
                If _echoCount > 5 Then

                    _echoCount = 0
                    StopEngineDataComms()
                    StartEngineDataComms()

                    Return

                Else

                    kwpcomm = &H10 ' &H10 reset again

                    'Set Comms Intialized to False so we dont get multiple requests queued up
                    Me.SendCommsMessages = False

                    'Sleep for awhile
                    System.Threading.Thread.Sleep(3000)

                    'Set Comms Initialized to True so new Requests can be started
                    Me.SendCommsMessages = True

                    Return

                End If

            Else

                'Process Data Read from ecu
                ReadDataString()

            End If

            Select Case kwpcomm
                Case &H0

                    ' Listening on the Comms Line
                    AddCommsMessage("&H0 Listening")

                Case &H10

                    InitializeComms()

                Case &H2108

                    RequestEngineData(&H8)

                Case &H2180

                    RequestEngineData(&H80)
                    kwpcomm = &H2108

                Case &H21C0

                    RequestEngineData(&HC0)
                    kwpcomm = &H2108

                Case &H14

                    ClearDTCData()
                    kwpcomm = &H2108

                Case &H18

                    RequestDTCData()
                    kwpcomm = &H2108

                Case &H1A

                    RequestECUID()
                    kwpcomm = &H2180

                Case &H82

                    SendCloseComms()

                Case &H3E

                    SendKeepAlive()
                    kwpcomm = &H2108

                Case Else
                    AddCommsMessage(kwpcomm & " - unknown command - ")

            End Select

            ' No response from the line for a while, lets re start the comms
            If ticking > 25 Then

                StopEngineDataComms()
                StartEngineDataComms()

            End If

        End SyncLock

    End Sub

    Private Sub InitializeComms()

        Me.SendCommsMessages = False

        ' Initialize comms
        AddCommsMessage("&H10 Initialize Comms")

        ' Get the FTDI device handle based on com port number
        Dim numberOfDevices As Integer
        Dim currentComPortNumber As Integer
        Dim modemStatus As Integer
        Dim stopwatch As Stopwatch = New Stopwatch()

        FT_status = FT_GetNumberOfDevices(numberOfDevices, 0, &H80000000)

        For index As Integer = 0 To numberOfDevices - 1

            FT_status = FT_Open(index, lngHandle)
            FT_status = FT_GetComPortNumber(lngHandle, currentComPortNumber)

            If currentComPortNumber <> comPortNumber Then
                FT_status = FT_Close(lngHandle)
            End If

        Next

        FT_status = FT_SetBaudRate(lngHandle, 10400)
        'FT_status = FT_SetBaudRate(lngHandle, 19230)
        FT_status = FT_status + FT_SetDataCharacteristics(lngHandle, 8, 1, 0)   ' 8bits ,1 stop, parity none
        FT_status = FT_status + FT_SetTimeouts(lngHandle, 5, 5)               'rx and tx timeouts 10ms
        FT_status = FT_status + FT_SetLatencyTimer(lngHandle, 16)               'ms 16 is default
        FT_status = FT_status + FT_SetUSBParameters(lngHandle, 4096, 4096)      'only rx is active by FTDI

        FT_status = FT_ClrDtr(lngHandle)

        AddCommsMessage("FTDI USB device opened for 10400 baud, port=" & comPortNumber)
        AddCommsMessage("Initiating 5baud fast initialization")

        ' FTDI USB device ok, lets check that the device is in data monitoring mode
        FT_status = FT_GetModemStatus(lngHandle, modemStatus)

        If (modemStatus <> &H6010) Then

            commStatus = "Error: Power is not on, ECU is in programming mode or COM port is not set correcly. Modemstat=" & Hex(modemStatus) & ", Comporterr=" & Hex(FT_status)
            AddCommsMessage(commStatus)
            StopEngineDataComms()
            Return

        End If

        AddCommsMessage("Comms Initialization")

        Dim Ctr1 As Long
        Dim Ctr2 As Long
        Dim Freq As Long

        Ctr1 = 0
        Ctr2 = 0
        Freq = 0

        QueryPerformanceCounter(Ctr2)
        QueryPerformanceFrequency(Freq)

        FT_status = FT_SetBreakOff(lngHandle)       ' K-line high
        Do Until (Ctr2 - Ctr1) / (Freq / 1000000) >= 300000 'wait 300ms
            QueryPerformanceCounter(Ctr2)
        Loop
        FT_status = FT_SetBreakOn(lngHandle)        ' K-line low
        Do Until (Ctr1 - Ctr2) / (Freq / 1000000) >= 24500 'wait 25ms
            QueryPerformanceCounter(Ctr1)
        Loop
        FT_status = FT_SetBreakOff(lngHandle)       ' K-line high
        Do Until (Ctr2 - Ctr1) / (Freq / 1000000) >= 24500 'wait 25ms
            QueryPerformanceCounter(Ctr2)
        Loop

        ' Capture &H00 from ECU that is not correct the &H00 is the echo from the FT_SetBreakOn
        ticking = 0
        rxbyte = &HFF
        bytecount = 0

        'the only thing is here to see that is the RXD Pin is high****************************
        While (ticking < 25) And (rxbyte <> 0) And (bytecount = 0)
            ticking = ticking + 1
            FT_status = FT_Read_Bytes(lngHandle, rxbyte, 1, bytecount)

            ' break the for next loop when &H00 found
        End While

        '&H00 read succesfully
        If ticking < 25 Then

            'Send init request to ecu
            Dim txByte As Byte

            txByte = &H81
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &H12
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &HF1
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &H81
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &H5
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            ' Pass control timer to read bytes continously with kwpcommand &H2108
            kwpcomm = &H2108
            ticking = 0

            AddCommsMessage("Completed 5baud fast initialization" & Chr(13) & Chr(10))

        Else

            ticking = 0
            AddCommsMessage("Failed 5baud initialization" & Chr(13) & Chr(10))

            StopEngineDataComms()
            StartEngineDataComms()

        End If

        counter = 0

        Thread.Sleep(logRate)

        Me.SendCommsMessages = True

    End Sub

    Private Sub ReadRxQueue()

        'initialize rx pointer
        rxsptr = 0

        ' Read if there is anything in the receive queue
        FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

        ' Perform read package if no comms error and there is something to be read in receive queueue
        If FT_status = 0 And rxqueue > 0 Then
            For i As Integer = 1 To rxqueue

                FT_Read_Bytes(lngHandle, rxbyte, 1, 1)

                If rxsptr > 128 Then
                    rxsptr = 128
                End If

                rxs(rxsptr) = rxbyte
                rxsptr = rxsptr + 1
            Next

            ticking = 0

        End If

    End Sub

    Private Sub RequestEngineData(ByVal value As Integer)

        ' Request next data package
        Dim txbyte As Byte

        txbyte = &H80
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

        txbyte = &H12
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

        txbyte = &HF1
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

        txbyte = &H2
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

        txbyte = &H21
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

        txbyte = value
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

        txbyte = (&H80 + &H12 + &HF1 + &H2 + &H21 + value) And &HFF
        FT_Write_Bytes(lngHandle, txbyte, 1, 1)

    End Sub

    Private Sub ClearDTCData()

        ' Send Clear DTC command to ecu
        Dim txByte As Byte

        txByte = &H80
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H12
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &HF1
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H3
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H14
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H0
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H0
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = (&H80 + &H12 + &HF1 + &H3 + &H14 + &H0 + &H0) And &HFF
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

    End Sub

    Private Sub RequestDTCData()

        ' Request DTC
        Dim txByte As Byte

        txByte = &H80
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H12
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &HF1
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H4
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H18
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H0
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H0
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H0
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = (&H80 + &H12 + &HF1 + &H4 + &H18 + &H0 + &H0 + &H0) And &HFF
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

    End Sub

    Private Sub RequestECUID()

        ' Get ECUid
        Dim txByte As Byte

        txByte = &H80
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H12
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &HF1
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H2
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H1A
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H91
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = (&H80 + &H12 + &HF1 + &H2 + &H1A + &H91) And &HFF
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

    End Sub

    Private Sub SendCloseComms()

        SyncLock _syncRoot

            ' Send Close Comms Command to ecu
            Dim txByte As Byte
            txByte = &H80
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &H12
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &HF1
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &H1
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = &H81
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            txByte = (&H80 + &H12 + &HF1 + &H1 + &H81) And &HFF
            FT_Write_Bytes(lngHandle, txByte, 1, 1)

            ' Close the COM port
            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

            If FT_status = 0 Then
                ticking = 0
                FT_status = FT_Close(lngHandle)
            End If

            FT_status = FT_Close(lngHandle)

        End SyncLock

    End Sub

    Private Sub SendKeepAlive()

        ' Send Keepalive package to ecu, not tested
        Dim txByte As Byte

        txByte = &H80
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H12
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &HF1
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &H1
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

        txByte = &HE
        FT_Write_Bytes(lngHandle, txByte, 1, 1)

    End Sub

    Public Sub StartEngineDataComms()

        AddCommsMessage("Staring Engine Data Comms")

        ' Set Initialize Command and Start Timer
        kwpcomm = &H10
        Me.SendCommsMessages = True
        EnableTimer2(True)

    End Sub

    Public Sub StopEngineDataComms()

        ' Close ECU communications
        SendCloseComms()

        ' Forced com port closing
        FT_status = FT_Close(lngHandle)

        Do
            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)
            System.Threading.Thread.Sleep(50)
        Loop Until FT_status = 1

        System.Threading.Thread.Sleep(500)

        EnableTimer2(False)
        Me.SendCommsMessages = False
        _connected = False

        AddCommsMessage("Engine Data Comms Closed")
        AddCommsMessage("")

    End Sub

    Private Sub EngineDataLoggingLoop()

        EngineDataCommsStopwatch.Reset()
        EngineDataCommsStopwatch.Start()

        While Me.ContinueLogging = True

            'If EngineDataCommsStopwatch.ElapsedMilliseconds Mod logRate = 0 Then
            If _newData = True Then

                _newData = False

                Dim logTime As StringBuilder = New StringBuilder()
                logTime.Append(EngineDataCommsStopwatch.Elapsed.Hours.ToString("00"))
                logTime.Append(":")
                logTime.Append(EngineDataCommsStopwatch.Elapsed.Minutes.ToString("00"))
                logTime.Append(":")
                logTime.Append(EngineDataCommsStopwatch.Elapsed.Seconds.ToString("00"))
                logTime.Append(".")
                logTime.Append(EngineDataCommsStopwatch.Elapsed.Milliseconds.ToString("000"))
                _logTime = logTime.ToString()

                WriteDataLog()
                WriteDataLogRaw()

                Thread.Sleep(5)

            End If

            Thread.Sleep(0)

        End While

    End Sub

    Private Sub WriteDataLogs()

        If Me.ContinueLogging = True Then

            Dim logTime As StringBuilder = New StringBuilder()
            logTime.Append(EngineDataCommsStopwatch.Elapsed.Hours.ToString("00"))
            logTime.Append(":")
            logTime.Append(EngineDataCommsStopwatch.Elapsed.Minutes.ToString("00"))
            logTime.Append(":")
            logTime.Append(EngineDataCommsStopwatch.Elapsed.Seconds.ToString("00"))
            logTime.Append(".")
            logTime.Append(EngineDataCommsStopwatch.Elapsed.Milliseconds.ToString("000"))
            _logTime = logTime.ToString()

            'WriteDataLog()
            WriteDataLogRaw()

        End If

    End Sub

    Private Sub ReadDataString()

        SyncLock _syncRoot

            ' Read datastring from &H21 read local id command to global variables if positive response (&H61)to service id
            If (rxs(10) = &H34) And (rxs(11) = &H61) And (rxs(12) = &H8) Then

                _connected = True

                WIDEBAND1 = rxs(20)
                WIDEBAND2 = rxs(21)
                WIDEBAND = (WIDEBAND1 * 256) + WIDEBAND2

                BOOST = rxs(22)
                BOOST2 = rxs(23)
                RPMhi = rxs(24)
                RPMlo = rxs(25)
                RPM = CInt((((&HFF * RPMhi) + RPMlo) / 2.55) / 10) * 10
                TPS = rxs(26)
                IP = rxs(27)
                IAPabs = rxs(27)
                CLT = rxs(28)
                IAT = rxs(29)
                AP = rxs(30)
                SAPabs = rxs(30)
                IAP = AP - IP
                BATT = rxs(31)
                HO2 = rxs(32)
                GEAR = rxs(33)
                FUELhi1 = rxs(38)
                FUELlo1 = rxs(39)
                FUEL1 = (256 * FUELhi1) + FUELlo1
                FUELhi2 = rxs(40)
                FUELlo2 = rxs(41)
                FUEL2 = (256 * FUELhi2) + FUELlo2
                FUELhi3 = rxs(42)
                FUELlo3 = rxs(43)
                FUEL3 = (256 * FUELhi3) + FUELlo3
                FUELhi4 = rxs(44)
                FUELlo4 = rxs(45)
                FUEL4 = (256 * FUELhi4) + FUELlo4
                IGN = rxs(49)
                STP = rxs(53)
                PAIR = rxs(58) And 1
                MS = rxs(59) And 1 'first bit is MS signal
                CLUTCH = rxs(59) And &H10 'b10000 is clutch switch signal
                NT = (rxs(60) And 2)
                HOX_ON = (rxs(60) And &H20)

                If _lastRPM = RPM And _lastTPS = TPS And _lastIAP = IAP And _lastHO2 = HO2 And _lastWideBand = WIDEBAND And _lastFuel1 = FUEL1 Then

                    _newData = False
                    _repeatedDataCount = _repeatedDataCount + 1

                Else

                    _newData = True

                    _lastRPM = RPM
                    _lastTPS = TPS
                    _lastIAP = IAP
                    _lastHO2 = HO2
                    _lastWideBand = WIDEBAND
                    _lastFuel1 = FUEL1


                    _repeatedDataCount = 0
                    _lastCommsDate = DateTime.Now

                    WriteDataLogs()

                End If

            End If

        End SyncLock

        ' Rxqueue contains data, but its a negative response to command &H21, just redo after a small sleep
        If (rxqueue >= 11) And (kwpcomm = &H2108) And (rxs(11) = &H7F) Then
            AddCommsMessage("Negative Response to &H21 command")

            Me.SendCommsMessages = False
            System.Threading.Thread.Sleep(300)

            kwpcomm = &H21
            Me.SendCommsMessages = True

        End If

    End Sub

    Private Sub WriteDataLogHeader()

        If LogFile Is Nothing = False Then

            Dim logEntry As StringBuilder = New StringBuilder()

            logEntry.Append("Log Time")
            logEntry.Append(",")
            logEntry.Append("RPM")
            logEntry.Append(",")
            logEntry.Append("TPS")
            logEntry.Append(",")
            logEntry.Append("IAP")
            logEntry.Append(",")
            logEntry.Append("HO2")
            logEntry.Append(",")
            logEntry.Append("HO2 Wideband")
            logEntry.Append(",")
            logEntry.Append("IGN")
            logEntry.Append(",")
            logEntry.Append("STP")
            logEntry.Append(",")
            logEntry.Append("GEAR")
            logEntry.Append(",")
            logEntry.Append("CLUTCH")
            logEntry.Append(",")
            logEntry.Append("NT")
            logEntry.Append(",")
            logEntry.Append("BOOST")
            logEntry.Append(",")
            logEntry.Append("IP")
            logEntry.Append(",")
            logEntry.Append("AP")
            logEntry.Append(",")
            logEntry.Append("CLT")
            logEntry.Append(",")
            logEntry.Append("IAT")
            logEntry.Append(",")
            logEntry.Append("BATT")
            logEntry.Append(",")
            logEntry.Append("PAIR")
            logEntry.Append(",")
            logEntry.Append("FUEL1")
            logEntry.Append(",")
            logEntry.Append("FUEL2")
            logEntry.Append(",")
            logEntry.Append("FUEL3")
            logEntry.Append(",")
            logEntry.Append("FUEL4")
            logEntry.Append(",")
            logEntry.Append("HOX_ON")
            logEntry.Append(",")
            logEntry.Append("MTS AFR")


            LogFile.WriteLine(logEntry.ToString())

        End If

        If LogFileRaw Is Nothing = False Then

            Dim logEntry As StringBuilder = New StringBuilder()

            logEntry.Append("Log Time")
            logEntry.Append(",")
            logEntry.Append("RPM")
            logEntry.Append(",")
            logEntry.Append("TPS")
            logEntry.Append(",")
            logEntry.Append("IAP")
            logEntry.Append(",")
            logEntry.Append("HO2")
            logEntry.Append(",")
            logEntry.Append("HO2 Wideband")
            logEntry.Append(",")
            logEntry.Append("IGN")
            logEntry.Append(",")
            logEntry.Append("STP")
            logEntry.Append(",")
            logEntry.Append("GEAR")
            logEntry.Append(",")
            logEntry.Append("CLUTCH")
            logEntry.Append(",")
            logEntry.Append("NT")
            logEntry.Append(",")
            logEntry.Append("BOOST")
            logEntry.Append(",")
            logEntry.Append("IP")
            logEntry.Append(",")
            logEntry.Append("AP")
            logEntry.Append(",")
            logEntry.Append("CLT")
            logEntry.Append(",")
            logEntry.Append("IAT")
            logEntry.Append(",")
            logEntry.Append("BATT")
            logEntry.Append(",")
            logEntry.Append("PAIR")
            logEntry.Append(",")
            logEntry.Append("FUEL1")
            logEntry.Append(",")
            logEntry.Append("FUEL2")
            logEntry.Append(",")
            logEntry.Append("FUEL3")
            logEntry.Append(",")
            logEntry.Append("FUEL4")
            logEntry.Append(",")
            logEntry.Append("HOX_ON")
            logEntry.Append(",")
            logEntry.Append("MTS AFR")

            LogFileRaw.WriteLine(logEntry.ToString())

        End If

    End Sub

    Private Sub WriteDataLog()

        SyncLock _syncRoot

            If LogFile Is Nothing = False And Me.ContinueLogging = True And _connected = True Then

                Dim logEntry As StringBuilder = New StringBuilder()
                logEntry.Append(_logTime)
                logEntry.Append(",")
                logEntry.Append(RPM)
                logEntry.Append(",")
                logEntry.Append(CalcTPS(TPS))
                logEntry.Append(",")
                logEntry.Append(CalcPressure(IAP))
                logEntry.Append(",")

                If C_WidebandO2Sensor.Checked Then
                    logEntry.Append(CalcWidebandAFR(WIDEBAND))
                Else
                    logEntry.Append(CalcAFR(HO2))
                End If

                logEntry.Append(",")
                logEntry.Append(WIDEBAND)
                logEntry.Append(",")
                logEntry.Append(CalcIgnDeg(IGN))
                logEntry.Append(",")
                logEntry.Append(CalcSTP(STP))
                logEntry.Append(",")
                logEntry.Append(GEAR)
                logEntry.Append(",")
                logEntry.Append(CalcClutch(CLUTCH))
                logEntry.Append(",")
                logEntry.Append(CalcNeutral(NT))
                logEntry.Append(",")
                logEntry.Append(CalcPressure(BOOST))
                logEntry.Append(",")
                logEntry.Append(CalcPressure(IP))
                logEntry.Append(",")
                logEntry.Append(CalcPressure(AP))
                logEntry.Append(",")
                logEntry.Append(CalcTemp(CLT))
                logEntry.Append(",")
                logEntry.Append(CalcTemp(IAT))
                logEntry.Append(",")
                logEntry.Append(CalcBatt(BATT))
                logEntry.Append(",")
                logEntry.Append(CalcPair(PAIR))
                logEntry.Append(",")
                logEntry.Append(FUEL1)
                logEntry.Append(",")
                logEntry.Append(FUEL2)
                logEntry.Append(",")
                logEntry.Append(FUEL3)
                logEntry.Append(",")
                logEntry.Append(FUEL4)
                logEntry.Append(",")
                logEntry.Append(CalculateHOXOn(HOX_ON))
                logEntry.Append(",")
                logEntry.Append(MTS_AFR.ToString("0.00"))

                LogFile.WriteLine(logEntry.ToString())

            End If

        End SyncLock

    End Sub

    Private Sub WriteDataLogRaw()

        SyncLock _syncRoot

            If LogFileRaw Is Nothing = False And Me.ContinueLogging = True And _connected = True Then

                numberOfLogs = numberOfLogs + 1

                Dim logEntry As StringBuilder = New StringBuilder()

                logEntry.Append(_logTime)
                logEntry.Append(",")
                logEntry.Append(RPM)
                logEntry.Append(",")
                logEntry.Append(TPS)
                logEntry.Append(",")
                logEntry.Append(IAP)
                logEntry.Append(",")
                logEntry.Append(HO2)
                logEntry.Append(",")
                logEntry.Append(WIDEBAND)
                logEntry.Append(",")
                logEntry.Append(IGN)
                logEntry.Append(",")
                logEntry.Append(STP)
                logEntry.Append(",")
                logEntry.Append(GEAR)
                logEntry.Append(",")
                logEntry.Append(CalcClutch(CLUTCH))
                logEntry.Append(",")
                logEntry.Append(CalcNeutral(NT))
                logEntry.Append(",")
                logEntry.Append(BOOST)
                logEntry.Append(",")
                logEntry.Append(IP)
                logEntry.Append(",")
                logEntry.Append(AP)
                logEntry.Append(",")
                logEntry.Append(CLT)
                logEntry.Append(",")
                logEntry.Append(IAT)
                logEntry.Append(",")
                logEntry.Append(BATT)
                logEntry.Append(",")
                logEntry.Append(PAIR)
                logEntry.Append(",")
                logEntry.Append(FUEL1)
                logEntry.Append(",")
                logEntry.Append(FUEL2)
                logEntry.Append(",")
                logEntry.Append(FUEL3)
                logEntry.Append(",")
                logEntry.Append(FUEL4)
                logEntry.Append(",")
                logEntry.Append(HOX_ON)
                logEntry.Append(",")
                logEntry.Append(MTS_AFR.ToString("0.00"))

                LogFileRaw.WriteLine(logEntry.ToString())

            End If

        End SyncLock

    End Sub

    Public Function CalcIgnDeg(ByVal value As Integer) As Integer

        Return (0.4 * value) - 12.5

    End Function

    Public Function CalcTPS(ByVal value As Integer) As String

        Dim tps As Decimal

        'tps min value = 56; max value = 228; range = 172
        'tps = (value - 56) / (228 - 56) * 100
        tps = ((value - 55) / (256 - 55)) * 125

        If (tps < 0) Then
            tps = 0
        ElseIf tps > 100 Then
            tps = 100
        End If

        If tps >= 10 Then
            Return Format(tps, "###")
        Else
            Return Format(tps, "#0.#")
        End If

    End Function

    Public Function CalcSTP(ByVal value As Integer) As Integer

        Return Int(value / 2.55)

    End Function

    Public Function CalcWidebandAFR(ByVal value As Double) As Double

        Dim range As Double = My.Settings.Wideband5V - My.Settings.Wideband0V
        Dim percentageOfRange As Double = value / 1023

        Return My.Settings.Wideband0V + range * percentageOfRange

    End Function

    Public Function CalcAFR(ByVal value As Integer) As Double

        If value = 0 Then
            Return 0
        ElseIf value <= 19 Then
            Return InterpolateValue(1, 19, 18.2, 16.65, value)
        ElseIf value <= 28 Then
            Return InterpolateValue(19, 28, 16.65, 14.5, value)
        ElseIf value <= 40 Then
            Return InterpolateValue(28, 40, 14.5, 13.55, value)
        ElseIf value = 41 Then
            Return 13.45
        ElseIf value = 42 Then
            Return 13.35
        ElseIf value = 43 Then
            Return 13.25
        ElseIf value = 44 Then
            Return 13
        ElseIf value = 45 Then
            Return 12.7
        ElseIf value = 46 Then
            Return 12.6
        ElseIf value = 47 Then
            Return 12.25
        ElseIf value = 48 Then
            Return 11.75
        ElseIf value = 49 Then
            Return 11.45
        ElseIf value > 49 Then
            Return 0
        End If

    End Function

    Private Function InterpolateValue(ByVal rangeLow As Integer, ByVal rangeHigh As Integer, ByVal valueLow As Double, ByVal valueHigh As Double, ByVal value As Integer) As Double

        Dim result As Double = 0

        Dim range As Integer = rangeHigh - rangeLow
        Dim valueRange As Double = valueHigh - valueLow
        Dim valuePercentage As Double = (value - rangeLow) / range

        result = valueLow + (valuePercentage * valueRange)

        Return result

    End Function

    Public Function CalcPressure(ByVal value As Integer) As Integer

        Return Int((value * 4) * 0.136)

    End Function

    Public Function CalcBoost(ByVal value As Integer)

        Return ((value / 50.5) * 9.2) - 14.7

    End Function

    Public Function CalcTemp(ByVal value As Integer) As Integer

        Return Int((value - 32) * 5 / 9)

    End Function

    Public Function CalcBatt(ByVal value As Integer) As String

        Return Replace(Format(value / 12.7, "#0.0"), ",", ".")

    End Function

    Public Function CalcClutch(ByVal value As Integer) As String

        If value = 0 Then
            Return "Out"
        Else
            Return "In"
        End If

    End Function

    Public Function CalcPair(ByVal value As Integer) As String

        If value = 0 Then
            Return "Off"
        Else
            Return "On"
        End If

    End Function

    Public Function CalcNeutral(ByVal value As Integer) As String

        If value = 0 Then
            Return "True"
        Else
            Return "False"
        End If
    End Function

    Public Function CalculateHOXOn(ByVal value As Boolean) As String

        If value = True Then
            Return "True"
        Else
            Return "False"
        End If

    End Function

    Public Sub EnableTimer2(ByVal enable As Boolean)

        If enable = False Then

            Timer2.Enabled = False

        Else
            'If _mtsConnected = False Then
            Timer2.Enabled = True
            'End If
        End If

    End Sub

#End Region

End Class