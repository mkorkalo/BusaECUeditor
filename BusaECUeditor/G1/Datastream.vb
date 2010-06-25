'
'    This file is part of BusaECUeditor - Hayabusa ECUeditor
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
Imports System.Management ' required by WMI queries


Public Class Datastream

#Region "Variables"

    Dim _bit15 As UInt16 = &H2 ^ 15
    Dim _bit14 As UInt16 = &H2 ^ 14
    Dim _bit13 As UInt16 = &H2 ^ 13
    Dim _bit12 As UInt16 = &H2 ^ 12
    Dim _bit11 As UInt16 = &H2 ^ 11
    Dim _bit10 As UInt16 = &H2 ^ 10
    Dim _bit9 As UInt16 = &H2 ^ 9
    Dim _bit8 As UInt16 = &H2 ^ 8
    Dim _bit7 As UInt16 = &H2 ^ 7
    Dim _bit6 As UInt16 = &H2 ^ 6
    Dim _bit5 As UInt16 = &H2 ^ 5
    Dim _bit4 As UInt16 = &H2 ^ 4
    Dim _bit3 As UInt16 = &H2 ^ 3
    Dim _bit2 As UInt16 = &H2 ^ 2
    Dim _bit1 As UInt16 = &H2 ^ 1
    Dim _bit0 As UInt16 = &H2 ^ 0

    Dim _hReceived As Boolean = False

    Dim _byteCount As Integer
    Dim _checkSum As Integer
    Dim _serialByte(12) As Byte
    Dim _temperature As Integer
    Dim _checkSumError As Integer
    Dim _CLTHigh As Boolean
    Dim _iActive As Boolean
    Dim _onceActive As Boolean
    Dim _chTPS As Integer
    Dim _chIAP As Integer
    Dim _chRPM As Integer
    Dim _chCLT As Integer
    Dim _chIGN As Integer
    Dim _chUSR As Integer

#End Region

#Region "Form Events"

    Private Sub DataStream_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim j As Integer
        Dim s As String
        Dim ps As String
        Dim pvs As String
        Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName WHERE InstanceName LIKE 'FTDI%'")
        Dim OKtoactivate As Boolean
        _CLTHigh = False
        _iActive = False
        _onceActive = False

        j = 0
        i = 1
        pvs = ""
        s = My.Settings.Item("ComPort")
        Try

            For Each queryObj As ManagementObject In searcher.Get()
                ps = queryObj("PortName")
                If ps = s Then
                    pvs = queryObj("InstanceName")
                    j = i 'Val(Mid(ps, 4, 1))
                End If
                C_SerialPort.Items.Add(ps)
                i = i + 1
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred while searching valid Interface ports " & ex.Message)
            OKtoactivate = False
        End Try
        If j > 0 Then
            C_SerialPort.SelectedIndex = j - 1
            If j = 1 Then OKtoactivate = True ' only one FTDI comport found, ok to activate
        Else
            OKtoactivate = False
            MsgBox("Interface needs to be set. Connect valid interface cable and restart program. ", MsgBoxStyle.Information)
        End If

        If (notvalidinterface(pvs)) Then
            MsgBox("Problems in configuring the Interface ", MsgBoxStyle.Critical)
            OKtoactivate = False
            End
        End If

        C_Uservar1.Items.Add("Air Temp") '0-
        C_Uservar1.Items.Add("Amb pre") '1-
        C_Uservar1.Items.Add("ECU Voltage") '2-
        C_Uservar1.Items.Add("Air pre") '3-
        C_Uservar1.Items.Add("AFR (EU)") '4-
        C_Uservar1.Items.Add("Yoshbox Cyl F1 adj") '5-30
        C_Uservar1.Items.Add("Yoshbox Cyl R2 adj") '6-31
        C_Uservar1.Items.Add("Yoshbox Cyl 3 adj") '7-32
        C_Uservar1.Items.Add("Yoshbox Cyl 4 adj") '8-33
        C_Uservar1.Items.Add("Yoshbox L/M/H") '9-42
        C_Uservar1.Items.Add("Oxy sens (EU)") '10-
        C_Uservar1.Items.Add("GPS sensor") '11-
        C_Uservar1.Items.Add("Sensor Error") '12-

        RAMVAR_USR1 = Val(My.Settings.Item("User1")) 'case else

        _byteCount = 0
        _checkSum = 0
        Try
            SerialPort1.PortName = C_SerialPort.Text
            SerialPort1.Open()
            SerialPort1.Close()
        Catch ex As Exception
            TextBox1.Text = ex.Message
        End Try

        B_Logging.Enabled = False
        C_Uservar1.Enabled = True
        TrackBar_Datalog.Enabled = False
        Timer2.Interval = TimerInterval
        Timer2.Enabled = False
        DataLogPointer = 0
        _checksumerror = 0

        If OKtoactivate Then B_DataStreamOn_Click(Me, System.EventArgs.Empty)

        If main.ECUID.Text.Contains("BB34BB") Then
            R_OxySensor.Visible = True
        Else
            R_OxySensor.Visible = False
        End If
    End Sub

    Private Sub DataStream_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
    End Sub

    Private Sub DataStream_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If SerialPort1.IsOpen() Then
            Try
                SerialPort1.Close()
            Catch ex As Exception
                MsgBox("Closing")
            End Try
        End If
        Me.T_MapSelected.Text = ""

    End Sub
#End Region

#Region "Control Events"

    Private Sub C_SerialPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_SerialPort.SelectedIndexChanged

        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
                SerialPort1.PortName = C_SerialPort.Text
                SerialPort1.Open()
            Else
                SerialPort1.PortName = C_SerialPort.Text
                SerialPort1.Open()
                SerialPort1.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
        My.Settings.Item("ComPort") = C_SerialPort.Text


    End Sub

    Private Sub B_DataStreamOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DataStreamOn.Click
        Timer2.Enabled = Not Timer2.Enabled
        Me.Text = "Datastream"
        If Timer2.Enabled Then

            B_DataStreamOn.Text = "Data OFF"
            B_Logging.Enabled = True
            C_SerialPort.Enabled = False
            C_Uservar1.Enabled = False
            Try
                SerialPort1.Open()
            Catch ex As Exception
                TextBox1.Text = ex.Message
                If Not SerialPort1.IsOpen() Then
                    B_DataStreamOn.Text = "Data ON"
                    B_Logging.Enabled = False
                    _CLTHigh = False
                    C_SerialPort.Enabled = True
                    C_Uservar1.Enabled = True
                    T_MapSelected.Text = ""
                    Timer2.Enabled = False
                End If
            End Try
        Else
            B_DataStreamOn.Text = "Data ON"
            B_Logging.Enabled = False
            _CLTHigh = False
            C_SerialPort.Enabled = True
            C_Uservar1.Enabled = True
            T_MapSelected.Text = ""
            Timer2.Enabled = False
            Try
                SerialPort1.Close()
            Catch ex As Exception
                TextBox1.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub B_Logging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Logging.Click
        If B_Logging.Text = "Logging ON" Then
            B_Logging.Text = "Logging OFF"
            DataLogPointer = 1
            TrackBar_Datalog.Enabled = False
            Datalogger.Show()
        Else
            B_Logging.Text = "Logging ON"
            DataLogLength = DataLogPointer
            DataLogPointer = 0
            TrackBar_Datalog.Enabled = True
            TrackBar_Datalog.Maximum = DataLogLength
            TrackBar_Datalog.Value = DataLogLength
            TextBox1.Text = Str(DataLogLength)
            Datalogger.Close()
        End If
    End Sub

    Private Sub C_UserVar1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C_Uservar1.TextChanged
        Select Case C_Uservar1.SelectedIndex
            Case 0 ' air temperature
                RAMVAR_USR1 = 8
            Case 1 ' Ambient pressure
                RAMVAR_USR1 = 9
            Case 2 ' Voltage compensation
                RAMVAR_USR1 = 10
            Case 3 ' Air Pressure
                RAMVAR_USR1 = 21
            Case 4 ' Oxy sensor (EU models)
                RAMVAR_USR1 = 76
            Case 5
                RAMVAR_USR1 = 30
            Case 6
                RAMVAR_USR1 = 31
            Case 7
                RAMVAR_USR1 = 32
            Case 8
                RAMVAR_USR1 = 33
            Case 9
                RAMVAR_USR1 = 42
            Case 10
                RAMVAR_USR1 = 76
            Case 11
                'GPS sensor
                RAMVAR_USR1 = 62
            Case 12
                'Sensor error
                RAMVAR_USR1 = 0
            Case Else
                RAMVAR_USR1 = Val(C_Uservar1.Text)
        End Select

        If RAMVAR_USR1 < 0 Or RAMVAR_USR1 > 255 Then
            RAMVAR_USR1 = 0
            MsgBox("Invalid USR1 parameter value(", MsgBoxStyle.OkOnly)
        Else
            My.Settings.Item("User1") = Str(RAMVAR_USR1)
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim d As Double

        '
        ' in case the coolant is dangerously high, inform the user as the clt sensor is not working
        '
        If _CLTHigh Then
            SendGaugeData()
        Else
            ReadProcessOnGoing = True
            ReadRamVar()
            ReadProcessOnGoing = False
            If FuelMapVisible Then Fuelmap.tracemap()
            If IgnitionMapVisible Then Ignitionmap.tracemap()
        End If

        If _checksumerror <> 0 Then
            'sendreset()
            TextBox1.Text = "Checksum general error in program"
        Else
            WriteLabels()


            If DataLogPointer > 0 Then
                DataLogLength = DataLogPointer
                DataLog(DataLogPointer, 0) = DataLogPointer
                DataLog(DataLogPointer, 2) = RPM
                DataLog(DataLogPointer, 3) = TPS
                DataLog(DataLogPointer, 4) = IAP
                DataLog(DataLogPointer, 5) = AP
                DataLog(DataLogPointer, 6) = CLT
                DataLog(DataLogPointer, 7) = USR1
                DataLog(DataLogPointer, 8) = Fuel
                DataLog(DataLogPointer, 9) = IGN
                DataLog(DataLogPointer, 10) = AFR

                DataLogPointer = DataLogPointer + 1

                If DataLogPointer >= MaxDataLog Then
                    B_Logging.Text = "Logging ON"
                    DataLogLength = DataLogPointer
                    DataLogPointer = 0
                    TrackBar_Datalog.Enabled = True
                    TrackBar_Datalog.Maximum = DataLogLength
                    TextBox1.Text = Str(DataLogLength)
                    Datalogger.Close()
                    MsgBox("Maximum datalog length exceeded", MsgBoxStyle.Information)
                End If
                '
                ' Lets show some fancy gauges here while datalogging
                '
                d = RPM
                Datalogger.AxEChartCtl1.SetValue(d)
                d = CalcTPS(TPS)
                Datalogger.AxEChartCtl2.SetValue(d)
                Datalogger.AxEChartCtl1.Update()
                Datalogger.AxEChartCtl2.Update()
                Datalogger.L_capleft.Text = Str(Int(DataLogPointer * 100 / MaxDataLog)) & "%"
                If ((DataLogPointer / MaxDataLog) * 100) > 90 Then
                    Datalogger.L_capleft.ForeColor = Color.Red
                Else
                    Datalogger.L_capleft.ForeColor = Color.Black
                End If


            End If
        End If

    End Sub

    Private Sub TrackBar_Datalog_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar_Datalog.Scroll

        DataLogPointer = TrackBar_Datalog.Value
        TextBox1.Text = Str(TrackBar_Datalog.Value)


        RPM = DataLog(TrackBar_Datalog.Value, 2)
        TPS = DataLog(TrackBar_Datalog.Value, 3)
        IAP = DataLog(TrackBar_Datalog.Value, 4)
        OXY = DataLog(TrackBar_Datalog.Value, 5)
        CLT = DataLog(TrackBar_Datalog.Value, 6)
        USR1 = DataLog(TrackBar_Datalog.Value, 7)
        Fuel = DataLog(TrackBar_Datalog.Value, 8)
        IGN = DataLog(TrackBar_Datalog.Value, 9)
        AFR = DataLog(TrackBar_Datalog.Value, 10)
        If FuelMapVisible Then Fuelmap.tracemap()
        If IgnitionMapVisible Then Ignitionmap.tracemap()

        writelabels()

    End Sub

#End Region

#Region "Functions"

    Private Sub Wait(ByVal i As Integer)
        Dim cnt As Integer
        cnt = 0
        Do While cnt < i
            cnt = cnt + 1
        Loop

    End Sub

    Private Sub ReadRamVar()
        Dim b(16) As Byte
        Dim i As Integer
        Dim c As Integer
        Dim l As Integer
        Dim oxysensoractive As Boolean

        c = 0
        i = 0


        b(0) = &H13
        b(1) = 8 + 3 ' Variables + other bytes Number of bytes in string

        b(2) = 3 ' 1=RPM
        b(3) = 5 ' 2=TPS
        b(4) = 6 ' 3=IAP
        b(5) = 9 ' 9=AP
        b(6) = 7 ' 5=CLT
        b(7) = RAMVAR_USR1 ' 6=user can define this
        b(8) = 13 ' Fuel highbit
        b(9) = 49 ' IGN 49=cyl0, 50=cyl1

        l = b(1)
        i = 0
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c = c - 256
            i = i + 1
        Loop
        If c <> 0 Then
            b(b(1) - 1) = 256 - c
        Else
            b(b(1) - 1) = 0
        End If


        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Write(b, 0, l)
                SerialPort1.Read(b, 0, l)
                Wait(1500)
                SerialPort1.Read(b, 0, l)
            End If

        Catch ex As System.TimeoutException
            TextBox1.Text = ex.Message & TextBox1.Text
        End Try

        ' check checksum of read bytes
        c = 0
        i = 0
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c = c - 256
            i = i + 1
        Loop

        If (b(1) = l) And (b(l - 1) = (256 - c)) Then

            RPM = Int(b(2)) * 100
            TPS = b(3)
            IP = b(4)
            AP = b(5)
            CLT = b(6)
            'FUEL = CInt(((b(8) * 256) - 1024) * 2.47 / 100) * 2 ' if 48, then *1, if 24 then*2
            'FUEL = Int(((b(8) * 12.8) - 64))
            Fuel = Int(((b(8) * 12.2) - 48))
            IGN = CInt(((b(9) * 2.56 / 10) * 1.31) - 3.5) + (0.75 * RPM / 1000)
            'IGN = CInt(b(9) * 2.56 / 10)

            '
            ' Now lets update the user selectable variable
            '
            Select Case RAMVAR_USR1
                Case 8
                    USR1 = (((b(7) - 32) * 10) / 18)
                Case 62
                    If b(7) = &H1 Then USR1 = 0
                    If b(7) = &H2 Then USR1 = 1
                    If b(7) = &H4 Then USR1 = 2
                    If b(7) = &H8 Then USR1 = 3
                    If b(7) = &H10 Then USR1 = 4
                    If b(7) = &H20 Then USR1 = 5
                    If b(7) = &H40 Then USR1 = 6

                Case Else
                    USR1 = b(7)
            End Select

            IAP = AP - IP + 1 ' calculate x axis scale ambient - manifold
            If IAP < 0 Then
                IAP = 0
            End If

            If ((((CLT - 32) * 10) / 18) > 110) Then
                _CLTHigh = True
                Me.Text = "Datastream COOLANT TEMPERATURE WARNING, pgm restart required"
                MsgBox("Coolant temperature high, pgm restart required", MsgBoxStyle.Critical)
                Me.Close()
            Else
                _CLTHigh = False
                TextBox1.Text = "Datastream active" & Str(b(l - 1)) & "=" & Str(256 - c)
                Me.Text = "Datastream active"
            End If
        Else
            TextBox1.Text = "Synchronizing datastream..."
            Me.Text = "Datastream resynchronizing... (restart engine!!!)"
            ' often the synchronizing problems are caused that the automapping feature
            ' is on and causes the serial protocol to fail due to redrawing and recalculating
            ' the map. So lets turn the automatic map changing feature off...
            ' If Fuelmap.Visible And Fuelmap.C_automap.Checked Then Fuelmap.C_automap.Checked = False
        End If

        '
        ' As last item lets update if oxy sensor is active or not, this is experimental and for information code only...
        ' not fully tested and validated. Based on assumptions of reading the disassembler.
        '
        oxysensoractive = False
        If IAP > ReadFlashByte(&H295E2) And IAP < ReadFlashByte(&H295E3) And main.ECUID.Text.Contains("BB34BB51") And T_MapSelected.Text.Contains("IAP") Then
            oxysensoractive = True
        End If
        If TPS > ReadFlashByte(&H295E0) And TPS < ReadFlashByte(&H295E1) And main.ECUID.Text.Contains("BB34BB51") And T_MapSelected.Text.Contains("TPS") Then
            oxysensoractive = True
        End If
        If Not (oxysensoractive And RPM > ReadFlashWord(&H28C2E) / 2.56 And RPM < ReadFlashWord(&H28C2C) / 2.56 And CLT > ReadFlashByte(&H295DF)) Then
            oxysensoractive = False
        End If
        R_OxySensor.Checked = oxysensoractive


    End Sub

    Private Sub SendGaugeData()

        Dim b(10) As Byte
        Dim i As Integer
        Dim c As Integer
        Dim l As Integer
        c = 0
        i = 0

        b(0) = 5
        b(1) = 128
        b(2) = 0
        b(3) = 0
        b(4) = 0
        b(5) = 0
        b(6) = 0
        b(7) = 0

        l = 8
        i = 0
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c = c - 256
            i = i + 1
        Loop
        If c <> 0 Then
            b(l - 1) = 256 - c
        Else
            b(l - 1) = 0
        End If

        Try
            SerialPort1.Write(b, 0, l)
            SerialPort1.Read(b, 0, l)

        Catch ex As Exception
            TextBox1.Text = ex.Message
        End Try

        If (b(l - 1) <> (256 - c)) Then
            _checksumerror = 3
            TextBox1.Text = "Checksum error in sending gauge data"
        End If

    End Sub

    Private Sub SendReset()

        Dim b(10) As Byte
        Dim i As Integer
        Dim c As Integer
        Dim l As Integer
        c = 0
        i = 0

        b(0) = &H10 ' reset
        b(1) = 0
        b(2) = 0
        b(3) = 0
        b(4) = 0
        b(5) = 0
        b(6) = 0
        b(7) = 0

        l = 3
        i = 0
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c = c - 256
            i = i + 1
        Loop
        If c <> 0 Then
            b(l - 1) = 256 - c
        Else
            b(l - 1) = 0
        End If

        Try
            SerialPort1.Write(b, 0, l)
            SerialPort1.Read(b, 0, l)

        Catch ex As Exception
            TextBox1.Text = ex.Message
        End Try

        If (b(l - 1) <> (256 - c)) Then
            _checksumerror = 3
            TextBox1.Text = "Checksum error in sending reset data"
        End If

    End Sub

    Private Sub WriteLabels()

        RPMGauge.Deflection = RPM

        If RPM > 10800 Then
            LED_RPM.ForeColor = Color.Red
        Else
            LED_RPM.ForeColor = Color.White
        End If

        If ((((CLT - 32) * 10) / 18) > 95) Then
            LED_CLT.ForeColor = Color.Red
        Else
            If ((((CLT - 32) * 10) / 18) >= 80) Then
                LED_CLT.ForeColor = Color.White
            Else
                LED_CLT.ForeColor = Color.Gray
            End If

        End If

        ' Select which map is currently in use. IDLE Map is always assumed non TPS map...
        If Int(((TPS - 55) / (256 - 55)) * 100) >= 7 Then
            T_MapSelected.Text = "TPS"
        Else
            If RPM < 2000 Then
                T_MapSelected.Text = "IDLE"
            Else
                T_MapSelected.Text = "IAP"
            End If
        End If

        LED_RPM.Text = Str(RPM)
        LED_TPS.Text = CalcTPS(TPS)
        LED_IAP.Text = Str(IAP)

        If Metric Then
            LED_CLT.Text = Str(Int(((CLT - 32) * 10) / 18)) ' temperature in celsius
        Else
            LED_CLT.Text = Str(((9 / 5) * (Int(((CLT - 32) * 10) / 18))) - 32) ' temperature in fahrenheit
        End If

        LED_FUEL.Text = Str(Fuel)
        LED_IGN.Text = Str(IGN)

        If RAMVAR_USR1 = 0 Then ' sensor error, codes tested unless otherwise noted
            If USR1 = &H0 Then LED_USR1.Text = "C00"
            If (USR1 And &H1) = &H1 Then LED_USR1.Text = "C11"
            If (USR1 And &H2) = &H2 Then LED_USR1.Text = "C12" ' not tested, just guessed
            If (USR1 And &H4) = &H4 Then LED_USR1.Text = "C13"
            If (USR1 And &H8) = &H8 Then LED_USR1.Text = "C14"
            If (USR1 And &H10) = &H10 Then LED_USR1.Text = "C15"
            If (USR1 And &H20) = &H20 Then LED_USR1.Text = "C21"
            If (USR1 And &H40) = &H40 Then LED_USR1.Text = "C22"
            If (USR1 And &H80) = &H80 Then LED_USR1.Text = "C23"
        Else
            LED_USR1.Text = Str(USR1)
        End If


    End Sub

    Private Function NotValidInterface(ByVal pvs As String) As Boolean
        Return (False)
    End Function

#End Region

#Region "Not Used"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sendreset()
    End Sub

#End Region

End Class