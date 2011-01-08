'
'    This file is part of ecueditor - Hayabusa ECUeditor
'
'    Hayabusa ECUeditor is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Hayabusa ECUeditor is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with Hayabusa ECUeditor.  If not, see <http://www.gnu.org/licenses/>.
'
'    Notice: Please note that under GPL if you use this program or parts of it
'    you are obliged to distribute your software including source code
'    under this same license for free. For more information see paragraph 5
'    of the GNU licence.
'
'   27.12.2009 Initi sequence fixed based on feedback from Boerd, many thanks
'


'Imports System.Management ' required by WMI queries
Imports System.IO.Ports


Public Class K8Datastream
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
    Public comportnum As Integer
    Public rxbyte As Byte
    Public ticking As Integer
    Public FT_status As Integer
    Public rxqueue, txqueue, eventstat As Integer
    Public rxsptr As Integer
    Public rxs(128) As Byte
    Public kwpcomm As Integer
    Public slowinitdelay As Integer
    Public msgactive As Integer

    Dim hox_on As Boolean = True

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
    Dim WIDEBAND As Double
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

    Dim counter As Integer

    Private Sub K8Datastream_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try

            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

            If FT_status = 0 Then
                closeenginedatacomms()
            End If

            Timer2.Enabled = False

            ticking = 0
            FT_status = FT_Close(lngHandle)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub K8Datastream_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            '
            '
            '
            '
        End If
        If (e.KeyChar = "d") Or (e.KeyChar = "D") Then debug = Not debug
        If debug Then
            C_debug.Text = "debug is on"
        Else
            C_debug.Text = "debug is off"
        End If

    End Sub

    Private Sub K8datastream_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim j As Integer
        Dim s As String
        'Dim ps As String
        Dim pvs As String
        'Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName WHERE InstanceName LIKE 'FTDI%'")
        Dim OKtoactivate As Boolean
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String
        doneonce = False

        L_msg.Text = ""
        L_msg.ForeColor = Color.Black

        CLT_high = False
        iactive = False
        onceactive = False
        RPM = 0

        QueryPerformanceFrequency(qfreq)
        timerinterval = 150
        perferrorlimit = 60
        perferrorcounter = 0
        L_perftext.Text = Str(timerinterval) & "ms"

        j = 0
        i = 1
        pvs = ""
        s = My.Settings.Item("ComPort")

        Try

            j = -1
            i = 0
            ComboBox_Serialport.Items.Clear()

            For Each port In ports
                ComboBox_Serialport.Items.Add(port)
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
            ComboBox_Serialport.SelectedIndex = j
            'If j = 1 Then OKtoactivate = True ' only one FTDI comport found, ok to activate
            OKtoactivate = True ' only one FTDI comport found, ok to activate
        Else
            OKtoactivate = False
            MsgBox("Interface needs to be set. Select the correct com port on the following engine data monitoring screen. ", MsgBoxStyle.Information)
        End If

        If (notvalidinterface(pvs)) Then
            MsgBox("Problems in configuring the com port of the interface.", MsgBoxStyle.Critical)
            OKtoactivate = False
            End
        End If

        '
        ' Initialize the program, input for everything is serialport.portname 
        '
        If ComboBox_Serialport.Text <> "" Then

            SerialPort1.PortName = ComboBox_Serialport.Text ' this will be used for FTDI device handle, important to have correct value here
            slowinitdelay = 23

            If Len(SerialPort1.PortName) = 4 Then
                comportnum = Val(Mid$(SerialPort1.PortName, 4))   ' com port address
                If ((comportnum < 0) Or (comportnum > 15)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")
            Else
                comportnum = Val(Mid$(SerialPort1.PortName, 5))   ' com port address
                If ((comportnum < 0) Or (comportnum > 15)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")

            End If
            Timer2.Enabled = False
            Timer2.Interval = timerinterval

            B_Connect_Datastream.Enabled = True
            B_Clear_DTC.Enabled = False

        End If

        If debug Then
            C_debug.Text = "debug is on"
        Else
            C_debug.Text = "debug is off"
        End If

        If OKtoactivate Then
            startenginedatacomms()
        End If
        slowinitdelay = 23

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Serialport.SelectedIndexChanged

        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
                SerialPort1.PortName = ComboBox_Serialport.Text
                SerialPort1.Open()
            Else
                SerialPort1.PortName = ComboBox_Serialport.Text
                SerialPort1.Open()
                SerialPort1.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
        My.Settings.Item("ComPort") = ComboBox_Serialport.Text
        comportnum = Val(Mid$(SerialPort1.PortName, 4))   ' com port address for FTDI driver
        If ((comportnum < 0) Or (comportnum > 15)) Then MsgBox("USB FTDI COMport is non existing or out of range, program may not work")

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


        '
        ' Disable timer when processing the received package
        '
        Timer2.Enabled = False

        '
        ' Read if there is anything in the receive queue
        '
        FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)

        '
        ' Initialize variables
        '
        If Debug Then T_datacomm.Text = ""
        cksum = 0
        rxsptr = 0
        ticking = ticking + 1 ' a counter that counts that the process is active

        '
        ' Perform read package if no comms error and there is something to be read in receive queueue
        '
        If FT_status = 0 And rxqueue > 0 Then
            For i = 1 To rxqueue
                FT_Read_Bytes(lngHandle, rxbyte, 1, 1)
                If rxsptr > 128 Then rxsptr = 128
                rxs(rxsptr) = rxbyte
                rxsptr = rxsptr + 1
                If Debug Then T_datacomm.Text = T_datacomm.Text & Format(rxbyte, "x2") & " "
            Next
            ticking = 0
        End If

        '
        ' Rxqueue is 0x5 which is likely the echo from init request, reinit with different 5baud delays
        '
        If rxqueue = 5 Then
            kwpcomm = &H10 ' &H10 reset again
            '
            ' Try different 5baud init delays in case not connecting easily
            '
            System.Threading.Thread.Sleep(300)
            If slowinitdelay >= 22 Then
                slowinitdelay = slowinitdelay - 1
            Else
                slowinitdelay = 24 ' this is the max delay according to spec
                failcount = 0
            End If
        End If

        '
        ' Rxqueue contains data, but its a negative response to command &H21, just redo after a small sleep
        '
        If (rxqueue >= 11) And (kwpcomm = &H21) And (rxs(11) = &H7F) Then
            System.Threading.Thread.Sleep(300)
            kwpcomm = &H21
            Timer2.Enabled = True
        End If

        '
        ' Process what to do to previously read data
        '

        readdatastring()
        QueryPerformanceCounter(qpc1)
        writelabels()
        QueryPerformanceCounter(qpc2)
        If qpc2 <> 0 Then
            qtmp = Int((qpc2 - qpc1) / (qfreq / 1000000) / 1000) 'performance in ms
            If qtmp > perferrorlimit Then
                perferrorcounter = perferrorcounter + 1
            End If
            If (qtmp > perferrorlimit) And (Not doneonce) Then
                If perferrorcounter > 10 Then
                    L_perftext.Text = "250ms"
                    Timer2.Interval = 250
                End If
            End If
            If perferrorcounter > 10 Then
                If debug Then MsgBox("Please not that this PC may be to slow for the datastream to work in debug mode, press d to stop debug mode.")
                perferrorcounter = 0
            End If
            L_performanceindex.Text = qtmp
        End If

        'readdtcstring()

        '
        ' Process commands
        '
        Select Case kwpcomm
            Case &H0
                '
                ' just listening the line
                '
                T_datacomm.Text = T_datacomm.Text & "..."
            Case &H10
                '
                ' Initialize comms
                '
                L_comms.ForeColor = Color.Yellow

                '
                ' Get the FTDI device handle based on com port number
                '
                FT_status = FT_GetNumberOfDevices(i, 0, &H80000000)
                T_datacomm.Text = "Number of FTDI devices connected =" & i
                i = i - 1
                For x = 0 To i
                    FT_status = FT_Open(i, lngHandle) ' only one
                    FT_status = FT_GetComPortNumber(lngHandle, y)
                    If y = comportnum Then
                        x = i
                    Else
                        FT_status = FT_Close(lngHandle)
                    End If
                Next
                FT_status = FT_SetBaudRate(lngHandle, BaudRate)
                FT_status = FT_status + FT_SetDataCharacteristics(lngHandle, 8, 1, 0)   ' 8bits ,1 stop, parity none
                FT_status = FT_status + FT_SetTimeouts(lngHandle, 5, 5)               'rx and tx timeouts 10ms
                FT_status = FT_status + FT_SetLatencyTimer(lngHandle, 16)               'ms 16 is default
                FT_status = FT_status + FT_SetUSBParameters(lngHandle, 4096, 4096)      'only rx is active by FTDI

                FT_status = FT_ClrDtr(lngHandle) 'new for Interface V1.1 *****************************************************************

                T_datacomm.Text = T_datacomm.Text & Chr(13) & Chr(10) & "FTDI USB device opened for " & BaudRate & " baud, id=" & i & ", port=" & comportnum
                T_datacomm.Text = T_datacomm.Text & Chr(13) & Chr(10) & "Initiating 5baud fast initialization"
                i = slowinitdelay

                '
                ' FTDI USB device ok, lets chect that the device is in data monitoring mode
                '
                FT_status = FT_GetModemStatus(lngHandle, modemstat)

                If (modemstat <> &H6010) Then
                    MsgBox("Error: Power is not on, ECU is in programming mode or COM port is not set correcly. Modemstat=" & Hex(modemstat) & ", Comporterr=" & Hex(FT_status))
                End If

                '
                ' Show status in the titlebar
                '
                'If Me.Text.Contains("Synchronizing") And (Len(Me.Text) < 60) Then
                'Me.Text = Me.Text & "."
                'Else
                Me.Text = "Synchronizing ... "
                'End If

                '
                ' 
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
                    '
                    ' Reset ecu
                    '
                    If RPM = 0 Then
                        FT_status = FT_SetRts(lngHandle)
                        System.Threading.Thread.Sleep(300)
                        FT_status = FT_ClrRts(lngHandle)
                    End If
                    If RPM > 400 Then
                        If MsgBox("Press OK to restart ECU for resynchronizing", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            FT_status = FT_SetRts(lngHandle)
                            System.Threading.Thread.Sleep(300)
                            FT_status = FT_ClrRts(lngHandle)
                        End If

                    End If


                    '
                    ' 5 Baud Init using FTDI usb driver
                    '
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

                '
                ' Capture &H00 from ECU
                'that is not correct the &H00 is the echo from the FT_SetBreakOn
                '
                ticking = 0
                rxbyte = &HFF
                bytecount = 0
                x = 1
                'the only thing is here to see that is the RXD Pin is high****************************
                While (ticking < 25) And (rxbyte <> 0) And (bytecount = 0)
                    ticking = ticking + 1
                    FT_status = FT_Read_Bytes(lngHandle, rxbyte, 1, bytecount)
                    T_datacomm.Text = T_datacomm.Text & Chr(13) & Chr(10) & "Captured &H00 from ECU" & " using " & i & "ms"
                    i = 23 ' break the for next loop when &H00 found
                End While

                '
                ' Send init request to ecu if &H00 read succesfully
                '
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
                    '
                    ' Pass control timer to read bytes continously with kwpcommand &H21, read local id data
                    '
                    kwpcomm = &H21
                    ticking = 0
                    T_datacomm.Text = T_datacomm.Text & Chr(13) & Chr(10) & "Completed 5baud fast initialization" & Chr(13) & Chr(10)
                    Timer2.Enabled = True
                Else
                    Timer2.Enabled = False
                    ticking = 0
                    FT_status = FT_Close(lngHandle)
                    T_datacomm.Text = T_datacomm.Text & Chr(13) & Chr(10) & "Failed 5baud initialization" & Chr(13) & Chr(10)
                    Me.Text = "Did not synchronize, restart engine and reconnect.."
                End If

                counter = 0

            Case &H21
                '
                ' Request next data package and parse the package read earlier
                '

                L_comms.ForeColor = Color.Green
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
                Select Case ECUversion
                    Case "gen2"
                        Me.Text = "ecueditor.com - Hayabusa gen2 Enginedata active..."
                    Case "bking"
                        Me.Text = "ecueditor.com - Bking Enginedata active..."
                    Case "gixxer"
                        Me.Text = "ecueditor.com - GSX-R Enginedata active..."
                    Case "GixxerK5"
                        Me.Text = "ecueditor.com - Gsx1000R K5K6 Enginedata active...(testing only)"
                    Case Else
                        MsgBox("Not known ecuversion...")
                End Select
                Timer2.Enabled = True

                '
                ' Every nth counter loops execute next read other commands
                '
                counter = counter + 1
                If ((counter = 5) And modeabc) Or ((counter = 5) And (RPM < 2000)) Or ((counter = 5) And (debug)) Then
                    modeabc = False
                    kwpcomm = &H2180
                End If
                If ((counter = 10) And (RPM < 2000)) Or ((counter = 10) And (debug)) Then
                    kwpcomm = &H21C0
                End If
                If ((counter = 15) And (RPM < 2000)) Or ((counter = 15) And (debug)) Then 'Get DTC
                    kwpcomm = &H18
                End If
                If counter >= 15 Then
                    counter = 0
                End If

            Case &H2180
                '
                ' Request next data package and parse the package read earlier
                '
                L_comms.ForeColor = Color.Green
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

                Timer2.Enabled = True
                kwpcomm = &H21
                rxsptr = 0

            Case &H21C0
                '
                ' Request next data package and parse the package read earlier
                '
                L_comms.ForeColor = Color.Green
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

                Timer2.Enabled = True
                kwpcomm = &H21
                rxsptr = 0

            Case &H14
                '
                ' Send Clear DTC command to ecu, not tested
                '
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
                kwpcomm = &H21
                Timer2.Enabled = True

            Case &H18
                '
                ' Get DTC
                '
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

                kwpcomm = &H21
                Timer2.Enabled = True

            Case &H1A
                '
                ' Get ECUid
                '
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
                kwpcomm = &H1A
                Timer2.Enabled = True

            Case &H82
                '
                ' Send close comms command to ecu
                '
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
                '
                ' Close also the com port
                '
                FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)
                If FT_status = 0 Then
                    Timer2.Enabled = False
                    ticking = 0
                    FT_status = FT_Close(lngHandle)
                End If
                '               Timer2.Enabled = True
                'FT_status = FT_Close(lngHandle)
                L_comms.ForeColor = Color.Red
                B_Connect_Datastream.Text = "Connect"
                Me.Text = "ecueditor.com - Press connect to activate enginedata"

            Case &H3E
                '
                ' Send Keepalive package to ecu, not tested
                '
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
                Timer2.Enabled = True
            Case &H60180
                '
                ' Pair ON
                '
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HA5
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H6 + &HA5 + &H1 + &H80 + &H0 + &H0 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                kwpcomm = &H21
                Timer2.Enabled = True
            Case &H60100
                '
                ' Pair OFF
                '
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HA5
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H6 + &HA5 + &H1 + &H0 + &H0 + &H0 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                kwpcomm = &H21
                Timer2.Enabled = True
            Case &H60600
                '
                ' FAN
                '
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HA5
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H6 + &HA5 + &H6 + &H0 + &H0 + &H0 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                kwpcomm = &H21
                Timer2.Enabled = True
            Case &H60680
                '
                ' FAN
                '
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HA5
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H6 + &HA5 + &H6 + &H80 + &H80 + &H0 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                kwpcomm = &H21
                Timer2.Enabled = True
            Case &H60520
                '
                ' Reset ICS valve
                '
                txbyte = &H80
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H12
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HF1
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H6
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &HA5
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H5
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H20
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H70
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = &H0
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                txbyte = (&H80 + &H12 + &HF1 + &H6 + &HA5 + &H5 + &H20 + &H0 + &H70 + &H0) And &HFF
                FT_Write_Bytes(lngHandle, txbyte, 1, 1)
                kwpcomm = &H21
                Timer2.Enabled = True
            Case Else
                T_datacomm.Text = T_datacomm.Text = " - unknown command - "
                Timer2.Enabled = False ' justin case it should be false anyway
        End Select

        '
        ' No response from the line for a while, lets kill the comms
        '
        If ticking > 25 Then
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
            '
            ' Close also the com port
            '
            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)
            If FT_status = 0 Then
                Timer2.Enabled = False
                ticking = 0
                FT_status = FT_Close(lngHandle)
                B_Connect_Datastream.Text = "Connect"
            End If
        End If

        '
        ' If map is visible then perform tracemap for both maps
        '
        If fuelmapvisible Then
            Select Case ECUversion
                Case "gen2"
                    K8Fuelmap.tracemap()
                Case "bking"
                    BKingFuelmap.tracemap()
                Case "gixxer"
                    GixxerFuelmap.tracemap()
                Case Else
                    '  not implemented for other models
            End Select
        End If
        If IgnitionMapVisible Then
            Select Case ECUVersion
                Case "gen2"
                    K8Ignitionmap.tracemap()
                Case "bking"
                    BKingIgnitionMap.TraceMap()
                Case "gixxer"
                    GixxerIgnitionmap.tracemap()
                Case Else
                    '  not implemented for other models
            End Select
        End If


        If K8boostfuel.Visible Then K8boostfuel.tracemap()
        If K8STPmap.Visible Then K8STPmap.tracemap(GEAR, MS, MODE)
        If K8nitrouscontrol.Visible Then K8nitrouscontrol.tracemap()

        If RPM = 0 Then
            B_PAIR_ON.Visible = True
            B_PAIR_OFF.Visible = True
        Else
            B_PAIR_ON.Visible = False
            B_PAIR_OFF.Visible = False
        End If

        If L_Clutch.Text = "CLT ON" Then
            If RPM > 1100 And RPM < 1500 Then
                B_FANON.Visible = True
                B_FANOFF.Visible = True
            Else
                B_FANON.Visible = False
                B_FANOFF.Visible = False
            End If
        Else
            B_FANON.Visible = False
            B_FANOFF.Visible = False
        End If

        If RPM = 0 Then
            B_ICS.Visible = True
        Else
            B_ICS.Visible = False
        End If

    End Sub

    Private Function getdtcdecription(ByVal dtc As String) As String
        Select Case dtc
            Case "P0340" : Return "C11" & " " & dtc & " CPMS - Camshaft sensor"
            Case "P0335" : Return "C12" & " " & dtc & " CKPS - Crankshaft sensor"
            Case "P0105" : Return "C13" & " " & dtc & " IAPS Intake Air Pressure"
            Case "P0120" : Return "C14" & " " & dtc & " TPS  Throttle position sensor"
            Case "P0115" : Return "C15" & " " & dtc & " ECTS Engine Coolant"
            Case "P0110" : Return "C21" & " " & dtc & " IATS Intake Air Temperature"
            Case "P1450" : Return "C22" & " " & dtc & " APS  Atmospheric air pressure"
            Case "P1651" : Return "C23" & " " & dtc & " TOS  Tip over sensor"
            Case "P0351" : Return "C24" & " " & dtc & " IGN#1 Ignition Coil"
            Case "P0352" : Return "C25" & " " & dtc & " IGN#2 Ignition Coil"
            Case "P0353" : Return "C26" & " " & dtc & " IGN#3 Ignition Coil"
            Case "P0354" : Return "C27" & " " & dtc & " IGN#4 Ignition Coil"
            Case "P1655" : Return "C28" & " " & dtc & " STVA Secondar throttle motor"
            Case "P1654" : Return "C29" & " " & dtc & " STPS Secondary throttle sensor"
            Case "P0705" : Return "C31" & " " & dtc & " GPS  Gear position sensor"
            Case "P0201" : Return "C32" & " " & dtc & " PINJ#1 Primary Injector"
            Case "P0202" : Return "C33" & " " & dtc & " PINJ#2 Primary Injector"
            Case "P0203" : Return "C34" & " " & dtc & " PINJ#3 Primary Injector"
            Case "P0204" : Return "C35" & " " & dtc & " PINJ#4 Primary Injector"
            Case "P1764" : Return "C36" & " " & dtc & " SINJ#1 Secondary Injector"
            Case "P1765" : Return "C37" & " " & dtc & " SINJ#2 Secondary Injector"
            Case "P1766" : Return "C38" & " " & dtc & " SINJ#3 Secondary Injector"
            Case "P1767" : Return "C39" & " " & dtc & " SINJ#4 Secondary Injector"
            Case "P0505" : Return "C40" & " " & dtc & " ISC  Idle control valve"
            Case "P0506" : Return "C40" & " " & dtc & " ISC  Idle control valve"
            Case "P0507" : Return "C40" & " " & dtc & " ISC  Idle control valve"
            Case "P0230" : Return "C41" & " " & dtc & " FP,FPR Fuel Pump / relay"
            Case "P2505" : Return "C41" & " " & dtc & " FP,FPR Fuel Pump / relay"
            Case "P1650" : Return "C42" & " " & dtc & " IGN LCK"
            Case "P0130" : Return "C43" & " " & dtc & " HO2S Oxygen Sensor"
            Case "P0135" : Return "C43" & " " & dtc & " HO2S Oxygen sensor"
            Case "P1656" : Return "C49" & " " & dtc & " PAIR"
            Case "P1657" : Return "C46" & " " & dtc & " EXC sensor voltage too low or too high"
            Case "P1658" : Return "C46" & " " & dtc & " EXC motor not moving the EXC sensor"
            Case "P0480" : Return "C60" & " " & dtc & " FAN"
            Case "P0443" : Return "C62" & " " & dtc & " EVAP"
            Case Else
                Return dtc
        End Select
    End Function

    Private Sub readdatastring()
        Dim x As Integer
        Dim x20 As Integer

        '
        ' DTC positive response id=&H58 followed by number of DTCs
        ' DTC: DTC high byte, DTC low byte, DTC status
        '

        If (rxs(10) = &HF1) And (rxs(11) = &H12) And (rxs(13) = &H58) Then
            '
            ' Yes its a return package to read DTC command
            '
            ListBox1.Items.Clear()
            If rxs(14) <= 30 Then
                For x = 1 To (3 * rxs(14)) Step 3
                    '
                    ' Process all errorcodes reported by enquiry
                    '
                    If debug Then
                        If (rxs(14 + x + 2) And &H80) Then
                            '
                            ' If dtc status ´bit7 , i.e. fault present from this driving cycle
                            '
                            ' 0x01 bit0 = pending fault present
                            ' bit1 = pending fault state
                            ' bit2 = test running
                            ' bit3 = test inhibit
                            ' bit4 = test readiness
                            ' 0x20 bit5 = DTC validated and stored in non volatile memory
                            ' 0x40 bit6 = validated fault preset at time of request
                            ' 0x80 bit7 = validated fault has been present during this driving cycle
                            '
                            ListBox1.Items.Add(getdtcdecription("P" & Format(rxs(14 + x), "x2") & Format(rxs(14 + x + 1), "x2")))
                        End If
                    Else
                        If (rxs(14 + x + 2) And &H40) Then
                            '
                            ' If dtc status ´bit7 , i.e. fault present from this driving cycle
                            '
                            ' 0x01 bit0 = pending fault present
                            ' bit1 = pending fault state
                            ' bit2 = test running
                            ' bit3 = test inhibit
                            ' bit4 = test readiness
                            ' 0x20 bit5 = DTC validated and stored in non volatile memory
                            ' 0x40 bit6 = validated fault preset at time of request
                            ' 0x80 bit7 = validated fault has been present during this driving cycle
                            '
                            ListBox1.Items.Add(getdtcdecription("P" & Format(rxs(14 + x), "x2") & Format(rxs(14 + x + 1), "x2")))
                        End If

                    End If
                Next
            End If
        End If
        '
        ' Read datastring from &H21 read local id command to global variables if positive response (&H61)
        ' to service id
        '
        If (rxs(10) = &H34) And (rxs(11) = &H61) And (rxs(12) = &H8) Then
            If debug Then T_2108.Text = ""

            WIDEBAND = (rxs(20) * 256) + rxs(21)

            For x = 0 To 62
                If Debug Then T_2108.Text = T_2108.Text & Format(rxs(x), "x2") & " "
                Select Case x
                    Case 22
                        BOOST = rxs(x)
                    Case 24
                        RPMhi = rxs(x)
                    Case 25
                        RPMlo = rxs(x)
                        RPM = CInt((((&HFF * RPMhi) + RPMlo) / 2.55) / 10) * 10
                    Case 26
                        TPS = rxs(x)
                    Case 27
                        IP = rxs(x)
                        IAPabs = rxs(x)
                    Case 28
                        ' conversion formula using known thermostat and room temperature
                        CLT = ((rxs(x)) - 15) * 1.1
                    Case 29
                        ' conversion formula using known thermostat and room temperature
                        IAT = ((rxs(x)) - 15) * 1.1
                    Case 30
                        AP = rxs(x)
                        SAPabs = rxs(x)
                        IAP = (AP * 4 * 0.136) - (IP * 4 * 0.136)
                    Case 31
                        BATT = rxs(x)
                    Case 32
                        HO2 = rxs(x)
                    Case 33
                        Gear = rxs(x)
                    Case 38
                        FUELhi1 = rxs(x)
                    Case 39
                        FUELlo1 = rxs(x)
                        FUEL1 = (((256 * FUELhi1) + FUELlo1) / 25.6)
                    Case 40
                        FUELhi2 = rxs(x)
                    Case 41
                        FUELlo2 = rxs(x)
                        FUEL2 = (((256 * FUELhi2) + FUELlo2) / 25.6)
                    Case 42
                        FUELhi3 = rxs(x)
                    Case 43
                        FUELlo3 = rxs(x)
                        FUEL3 = (((256 * FUELhi3) + FUELlo3) / 25.6)
                    Case 44
                        FUELhi4 = rxs(x)
                    Case 45
                        FUELlo4 = rxs(x)
                        FUEL4 = (((256 * FUELhi4) + FUELlo4) / 25.6)
                    Case 49 'ignition
                        IGN = K8Ignitionmap.K8igndeg(rxs(x))
                    Case 53
                        STP = rxs(x)
                    Case 57
                        If (rxs(x) <> &H30) Then 'either of the mode switch is pressed hence need to read modeabc
                            modeabc = True
                        End If
                        If (rxs(x) = &H20) Then
                            DSM1 = True
                        Else
                            DSM1 = False
                        End If

                    Case 58
                        PAIR = rxs(x) And 1 'first bit is PAIR signal
                    Case 59
                        MS = rxs(x) And 1 'first bit is MS signal
                        CLUTCH = rxs(x) And &H10 'b10000 is clutch switch signal
                    Case 60
                        NT = (rxs(x) And 2)
                        hox_on = (rxs(x) And &H20)
                End Select
            Next
        End If

        If (rxs(10) = &H66) And (rxs(11) = &H61) And (rxs(12) = &H80) Then
            T_2180.Text = ""
            For x = 0 To 112
                If debug Then T_2180.Text = T_2180.Text & Format(rxs(x), "x2") & " "
                Select Case x
                    Case 20 'basefuel highbyte
                        x20 = rxs(x)
                    Case 21 'hasefuel lowbyte
                        L_basefuel.Text = Str((x20 * 256) + rxs(x))
                        'Case 43
                        'L_primaries.Text = "(" & Str(CInt(rxs(x) / 127 * 100)) & "%)"
                        'Case 44
                        'L_Secondaries.Text = "(" & Str(CInt(rxs(x) / 127 * 100)) & "%)"
                    Case 105 'mode abc
                        MODE = rxs(x)
                        Select Case rxs(x)
                            Case 0
                                L_modeA.Visible = True
                                L_modeB.Visible = False
                                L_modeC.Visible = False
                            Case 1
                                L_modeA.Visible = False
                                L_modeB.Visible = True
                                L_modeC.Visible = False
                            Case 2
                                L_modeA.Visible = False
                                L_modeB.Visible = False
                                L_modeC.Visible = True
                        End Select
                End Select

            Next

        End If
        If (rxs(10) = &H66) And (rxs(11) = &H61) And (rxs(12) = &HC0) Then
            T_21C0.Text = ""
            For x = 0 To 112
                If debug Then T_21C0.Text = T_21C0.Text & Format(rxs(x), "x2") & " "
                Select Case x
                    Case 41
                        L_prim.Text = Str(Int(100 * rxs(x) / 127)) & "%"
                    Case 42
                        L_sec.Text = Str(Int(100 * rxs(x) / 127)) & "%"
                    Case 43
                        L_covabc.Text = Str(Int(100 * (rxs(x) - &H80) / 127)) & "%"
                    Case 44
                        L_cov1.Text = Str(Int(100 * (rxs(x) - &H80) / 127)) & "%"
                    Case 45
                        L_cov2.Text = Str(Int(100 * (rxs(x) - &H80) / 127)) & "%"
                    Case 46
                        L_cov3.Text = Str(Int(100 * (rxs(x) - &H80) / 127)) & "%"
                    Case 47
                        L_cov4.Text = Str(Int(100 * (rxs(x) - &H80) / 127)) & "%"
                End Select

            Next

        End If

    End Sub

    Private Sub writelabels()
        '
        ' This subroutine writes the LED style labels and the RPM gauge
        '

        Dim cltmetric As Integer
        If msgactive < 500 Then
            If L_msg.Text <> "" Then
                msgactive = msgactive + 1
            End If
        Else
            msgactive = 0
            L_msg.Text = ""
            L_msg.ForeColor = Color.Black
        End If
        '
        ' Set RPM gauge to red if exeeding std limiter
        '
        If RPM > 13000 Then
            AquaGauge1.Value = 13
        Else
            AquaGauge1.Value = RPM / 1000
        End If
        AquaGauge1.DialText = "x1000r/min"

        If RPM > 11000 Then
            LED_RPM.ForeColor = Color.Red
        Else
            LED_RPM.ForeColor = Color.Black
        End If


        '
        ' Lets convert the IAP and SAP values to kPa. The datastream has /4 values in mmHg.
        '
        LED_IAPabs.Text = Int((IAPabs * 4) * 0.136)
        LED_SAPabs.Text = Int((SAPabs * 4) * 0.136)


        '
        ' Coolant seems to be fahrenheit - 10 based on service manual resistance values.
        ' This needs to be verified with real SDS values
        '
        A_CLT.Value = Int((CLT - 32) * 5 / 9) ' gauge uses always celsius
        If metric Then
            LED_CLT.Text = Int((CLT - 32) * 5 / 9)
            L_CLT.Text = "CLT C"
        Else
            LED_CLT.Text = CLT
            L_CLT.Text = "CLT F"
        End If
        '
        ' Lets set the red led lit up if clt high
        '
        cltmetric = ((CLT - 32) * 5 / 9)
        If cltmetric >= 115 Then
            L_CLThigh.ForeColor = Color.Firebrick
        Else
            L_CLThigh.ForeColor = Color.Silver
        End If
        '
        ' Set coolant value color based on temperature
        '
        If cltmetric >= 114 Then
            LED_CLT.ForeColor = Color.Red
        Else
            If cltmetric >= 90 Then
                LED_CLT.ForeColor = Color.Black
            Else
                LED_CLT.ForeColor = Color.Gray
            End If
        End If

        '
        ' IAT seems to be fahrenheit - 10 based on service manual resistance values.
        ' This needs to be verified with real SDS values
        '
        If metric Then
            LED_IAT.Text = Int((IAT - 32) * 5 / 9)
            L_IAT.Text = "IAT C"
        Else
            LED_IAT.Text = IAT
            L_IAT.Text = "IAT F"
        End If

        '
        ' Set coolant value color based on temperature
        '
        If cltmetric >= 114 Then
            LED_CLT.ForeColor = Color.Red
        Else
            If cltmetric >= 90 Then
                LED_CLT.ForeColor = Color.Black
            Else
                LED_CLT.ForeColor = Color.Gray
            End If
        End If

        LED_RPM.Text = Str(RPM)

        LED_TPS.Text = CalcTPS(TPS)
        If TPS <= 11 Then
            LED_TPS.ForeColor = Color.Gray
        Else
            LED_TPS.ForeColor = Color.Black
        End If

        LED_IAP.Text = Str(IAP)

        LED_FUEL.Text = Str(FUEL1)
        duty = CInt((FUEL1 * RPM) / 45000)

        If duty > 100 Then
            LED_FUEL.ForeColor = Color.Red
        Else
            LED_FUEL.ForeColor = Color.Black
        End If
        If duty > 100 Then
            L_msg.Text = "Fuel pulse maximum was exceeded"
            L_msg.ForeColor = Color.Red
        End If
        LED_DUTY.Text = Str(duty)
        If duty > 50 Then
            If duty > 100 Then
                L_msg.Text = "Fuel pulse maximum was exceeded"
                L_msg.ForeColor = Color.Red
            Else
                If L_sec.Text.Contains("80") Then
                    L_msg.Text = "Inj balance 50/50 recommended"
                    L_msg.ForeColor = Color.Black

                Else
                    debug = True
                    L_msg.Text = "High duty, forced debug mode"
                    L_msg.ForeColor = Color.Gray
                End If
            End If
        End If


        LED_IGN.Text = Str(IGN)

        If My.Settings.WidebandO2Sensor = True Then
            LED_HO2.Text = K8EngineDataLogger.CalcWidebandAFR(WIDEBAND)
        Else
            LED_HO2.Text = K8EngineDataLogger.CalcAFR(HO2)
        End If

        LED_BATT.Text = Replace(Format(BATT / 12.7, "#0.0"), ",", ".")


        '
        ' MS Signal is normally gRounded and that sets MS0 map as default
        ' when open MS signal is set to MS1 map
        '
        If MS = 0 Then
            L_MS.Text = "MS 0"
        Else
            L_MS.Text = "MS 1"
        End If

        '
        ' Clutch switch is normally closed, i.e. 1, when clutch is depressed clutch switch opens and sets clutch signal to 0
        '
        If CLUTCH <> 0 Then
            L_Clutch.Text = "CLT ON"
        Else
            L_Clutch.Text = "CLT OFF"
        End If

        '
        ' This is the neutral switch from GPS (gear position sensor), it is normally 0 ie gear on, 1 when neutral is on.
        '
        If NT <> 0 Then
            L_NT.Text = "NT OFF"
        Else
            L_NT.Text = "NT ON"
        End If

        If PAIR <> 0 Then
            L_PAIR.Text = "PAIR ON"
        Else
            L_PAIR.Text = "PAIR OFF"
        End If

        '
        ' This is a GPS sensor resistance value which sets a gear
        '
        Select Case GEAR
            Case 0
                LED_GEAR.Text = "0"
            Case 1
                LED_GEAR.Text = "1"
            Case 2
                LED_GEAR.Text = "2"
            Case 3
                LED_GEAR.Text = "3"
            Case 4
                LED_GEAR.Text = "4"
            Case 5
                LED_GEAR.Text = "5"
            Case 6
                LED_GEAR.Text = "6"
            Case Else
                LED_GEAR.Text = " "
        End Select

        LED_TIME.Text = Format(TimeOfDay.Hour, "#0") & ":" & Format(TimeOfDay.Minute, "00")

        If K8enginedatalog.Visible() Then
            K8enginedatalog.called_externally()
        End If

        L_STP.Text = Int(STP / 2.56)
    End Sub

    Public Function ho2toafr(ByVal h As Integer) As String

        L_ho2raw.Text = h

        '
        ' Hox sensor is either disabled of acting funny
        '
        If (h = 0) Or (h = &HFF) Then
            LED_HO2.ForeColor = Color.Black
            Return "---"
        End If

        If h <= 20 Then
            LED_HO2.ForeColor = Color.Red
        Else
            If h >= 50 Then
                LED_HO2.ForeColor = Color.Green
            Else
                LED_HO2.ForeColor = Color.Black
            End If
        End If

        '
        ' Bosch LSM-11 narrowband according to who2.com converted with raw voltage values
        '
        If h < 6 Then Return "lean"
        If h < 8 Then Return "14.8"
        If h < 28 Then Return "14.4"
        If h < 32 Then Return "14.1"
        If h < 33 Then Return "13.8"
        If h < 34 Then Return "13.6"
        If h < 35 Then Return "13.4"
        If h < 36 Then Return "13.2"
        If h < 37 Then Return "12.8"
        If h < 38 Then Return "12.6"
        If h < 39 Then Return "12.4"
        If h < 40 Then Return "12.0" Else Return "rich"

        '
        ' Old conversion
        '
        'If h < 19 Then Return "lean"
        'If h < 20 Then Return "15.0"
        'If h < 21 Then Return "14.9"
        'If h < 22 Then Return "14.8"
        'If h < 23 Then Return "14.7"
        'If h < 25 Then Return "14.6"
        'If h < 35 Then Return "14.5"
        'If h < 36 Then Return "14.4"
        'If h < 37 Then Return "14.3"
        'If h < 38 Then Return "14.2"
        'If h < 39 Then Return "14.1"
        'If h < 40 Then Return "14.0"
        'If h < 41 Then Return "13.8"
        'If h < 42 Then Return "13.7"
        'If h < 43 Then Return "13.5"
        'If h < 44 Then Return "13.4"
        'If h < 45 Then Return "13.2"
        'If h < 46 Then Return "13.0"
        'If h < 47 Then Return "12.9"
        'If h < 48 Then Return "12.7"
        'If h < 49 Then Return "12.6"
        'If h < 50 Then Return "12.5" Else Return "rich"

    End Function


    Private Function notvalidinterface(ByVal pvs As String) As Boolean
        Return (False)
    End Function

    Private Sub B_Clear_DTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Clear_DTC.Click
        '
        ' Clear DTC
        '
        ListBox1.Items.Clear()
        kwpcomm = &H14
    End Sub

    Public Sub startenginedatacomms()
        '
        ' Start ECU comunications
        '
        kwpcomm = &H10 ' next command is initialize
        B_Clear_DTC.Enabled = True
        Timer2.Enabled = True
        B_Connect_Datastream.Text = "Close"

    End Sub
    Public Sub closeenginedatacomms()
        '
        ' Close ECU communications
        '
        kwpcomm = &H82 ' next command is close comms
        B_Clear_DTC.Enabled = False
        '
        ' Forced com port closing
        '
        '*****New Code waiting that the comms is closed ***************
        Me.Text = "ecueditor.com - Please wait the ECU need this time"
        FT_status = FT_Close(lngHandle)
        Do
            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)
            System.Threading.Thread.Sleep(50)
        Loop Until FT_status = 1
        Timer2.Enabled = False
        L_comms.ForeColor = Color.Red
        System.Threading.Thread.Sleep(1500)

        Me.Text = "ecueditor.com - Press connect to activate enginedata"
        '***************end new Code***********************************
        B_Connect_Datastream.Text = "Connect"


    End Sub
    Private Sub B_Connect_Datastream_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Connect_Datastream.Click
        Dim i As Integer
        Dim j As Integer
        Dim s As String
        'Dim ps As String
        Dim pvs As String
        'Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName WHERE InstanceName LIKE 'FTDI%'")
        Dim OKtoactivate As Boolean
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String

        If B_Connect_Datastream.Text = "Connect" Then


            j = 0
            i = 1
            pvs = ""
            s = My.Settings.Item("ComPort")
            Try

                j = -1
                i = 0
                ComboBox_Serialport.Items.Clear()

                For Each port In ports
                    ComboBox_Serialport.Items.Add(port)
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
                ComboBox_Serialport.SelectedIndex = j
                'If j = 1 Then OKtoactivate = True ' only one FTDI comport found, ok to activate
                OKtoactivate = True ' only one FTDI comport found, ok to activate
            Else
                OKtoactivate = False
                MsgBox("Interface needs to be set. Select the correct com port on the following engine data monitoring screen. ", MsgBoxStyle.Information)
            End If

            If (notvalidinterface(pvs)) Then
                MsgBox("Problems in configuring the com port of the interface.", MsgBoxStyle.Critical)
                OKtoactivate = False
                End
            End If

            '
            ' Initialize the program, input for everything is serialport.portname 
            '
            If ComboBox_Serialport.Text <> "" Then

                SerialPort1.PortName = ComboBox_Serialport.Text ' this will be used for FTDI device handle, important to have correct value here
                slowinitdelay = 23

                If Len(SerialPort1.PortName) = 4 Then
                    comportnum = Val(Mid$(SerialPort1.PortName, 4))   ' com port address
                    If ((comportnum < 0) Or (comportnum > 9)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")
                Else
                    comportnum = Val(Mid$(SerialPort1.PortName, 5))   ' com port address
                    If ((comportnum < 0) Or (comportnum > 15)) Then MsgBox("USB FTDI COMport is non existing or out of normal range, program may not work")

                End If
                Timer2.Enabled = False
                Timer2.Interval = timerinterval

                B_Connect_Datastream.Enabled = True
                B_Clear_DTC.Enabled = False

            End If

            If OKtoactivate Then
                startenginedatacomms()
            End If
            kwpcomm = &H10

            FT_status = FT_SetRts(lngHandle)
            System.Threading.Thread.Sleep(300)
            FT_status = FT_ClrRts(lngHandle)
            System.Threading.Thread.Sleep(2000)


        Else
            FT_status = FT_GetStatus(lngHandle, rxqueue, txqueue, eventstat)
            If FT_status = 0 Then
                closeenginedatacomms()
            End If
            Timer2.Enabled = False
            ticking = 0

        End If

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        ' Get DTC
        '
        kwpcomm = &H18
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        ' Read ECU id
        '
        kwpcomm = &H1A
    End Sub


    Private Sub B_Enginedatalog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Enginedatalog.Click
        If K8enginedatalog.Visible() Then
            K8enginedatalog.Close()
        Else
            K8enginedatalog.Show()
            K8enginedatalog.Focus()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kwpcomm = &H2180
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_stop_engine.Click
        L_msg.Text = ""
        L_msg.ForeColor = Color.Black
        FT_status = FT_SetRts(lngHandle)
        System.Threading.Thread.Sleep(300)
        FT_status = FT_ClrRts(lngHandle)
        kwpcomm = &H10
    End Sub

   
    Private Sub L_comms_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles L_comms.ForeColorChanged
        If (L_comms.ForeColor = Color.Green) Or (L_comms.ForeColor = Color.Yellow) Then
            B_stop_engine.Visible = True
            ComboBox_Serialport.Enabled = False
        Else
            B_stop_engine.Visible = False
            ComboBox_Serialport.Enabled = True
        End If
    End Sub

    Private Sub C_debug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_debug.Click
        If debug Then
            debug = False
        Else
            debug = True
        End If

        If debug Then
            C_debug.Text = "debug is on"
        Else
            C_debug.Text = "debug is off"
        End If

    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_PAIR_ON.Click
        '
        ' Clear PAIR ON
        '
        kwpcomm = &H60180

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_PAIR_OFF.Click
        '
        ' Clear PAIR OFF
        '
        kwpcomm = &H60100

    End Sub

    Private Sub B_IDLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ICS.Click
        '
        ' Clear Set Idle
        '
        kwpcomm = &H60520

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_FANON.Click
        kwpcomm = &H60680
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_FANOFF.Click
        kwpcomm = &H60600
    End Sub
End Class