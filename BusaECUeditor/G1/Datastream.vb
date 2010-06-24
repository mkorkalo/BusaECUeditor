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


    Private Sub Datastream_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If SerialPort1.IsOpen() Then
            Try
                SerialPort1.Close()
            Catch ex As Exception
                MsgBox("Closing")
            End Try
        End If
        Me.MapSelected.Text = ""

    End Sub

    Private Sub Datastream_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
    End Sub




    Private Sub datastream_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim j As Integer
        Dim s As String
        Dim ps As String
        Dim pvs As String
        Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName WHERE InstanceName LIKE 'FTDI%'")
        Dim OKtoactivate As Boolean
        CLT_high = False
        iactive = False
        onceactive = False

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
                ComboBox_Serialport.Items.Add(ps)
                i = i + 1
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred while searching valid Interface ports " & ex.Message)
            OKtoactivate = False
        End Try
        If j > 0 Then
            ComboBox_Serialport.SelectedIndex = j - 1
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

        Combobox_Uservar1.Items.Add("Air Temp") '0-
        Combobox_Uservar1.Items.Add("Amb pre") '1-
        Combobox_Uservar1.Items.Add("ECU Voltage") '2-
        Combobox_Uservar1.Items.Add("Air pre") '3-
        Combobox_Uservar1.Items.Add("AFR (EU)") '4-
        Combobox_Uservar1.Items.Add("Yoshbox Cyl F1 adj") '5-30
        Combobox_Uservar1.Items.Add("Yoshbox Cyl R2 adj") '6-31
        Combobox_Uservar1.Items.Add("Yoshbox Cyl 3 adj") '7-32
        Combobox_Uservar1.Items.Add("Yoshbox Cyl 4 adj") '8-33
        Combobox_Uservar1.Items.Add("Yoshbox L/M/H") '9-42
        Combobox_Uservar1.Items.Add("Oxy sens (EU)") '10-
        Combobox_Uservar1.Items.Add("GPS sensor") '11-
        Combobox_Uservar1.Items.Add("Sensor Error") '12-

        RAMVAR_USR1 = Val(My.Settings.Item("User1")) 'case else

        bytecount = 0
        checksum = 0
        Try
            SerialPort1.PortName = ComboBox_Serialport.Text
            SerialPort1.Open()
            SerialPort1.Close()
        Catch ex As Exception
            TextBox1.Text = ex.Message
        End Try

        B_logging.Enabled = False
        Combobox_Uservar1.Enabled = True
        Datalog_trackbar.Enabled = False
        Timer2.Interval = timerinterval
        Timer2.Enabled = False
        datalogpointer = 0
        checksumerror = 0

        If OKtoactivate Then Button5_Click(Me, System.EventArgs.Empty)

        If main.ECUID.Text.Contains("BB34BB") Then
            R_oxysensor.Visible = True
        Else
            R_oxysensor.Visible = False
        End If
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


    End Sub


    Private Sub wait(ByVal i As Integer)
        Dim cnt As Integer
        cnt = 0
        Do While cnt < i
            cnt = cnt + 1
        Loop

    End Sub

    Private Sub readramvar()
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
                wait(1500)
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
            IntakeAirPressure = b(4)
            AirPressure = b(5)
            CLT = b(6)
            'FUEL = CInt(((b(8) * 256) - 1024) * 2.47 / 100) * 2 ' if 48, then *1, if 24 then*2
            'FUEL = Int(((b(8) * 12.8) - 64))
            FUEL = Int(((b(8) * 12.2) - 48))
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

            IAP = AirPressure - IntakeAirPressure + 1 ' calculate x axis scale ambient - manifold
            If IAP < 0 Then
                IAP = 0
            End If

            If ((((CLT - 32) * 10) / 18) > 110) Then
                CLT_high = True
                Me.Text = "Datastream COOLANT TEMPERATURE WARNING, pgm restart required"
                MsgBox("Coolant temperature high, pgm restart required", MsgBoxStyle.Critical)
                Me.Close()
            Else
                CLT_high = False
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
        If IAP > ReadFlashByte(&H295E2) And IAP < ReadFlashByte(&H295E3) And main.ECUID.Text.Contains("BB34BB51") And MapSelected.Text.Contains("IAP") Then
            oxysensoractive = True
        End If
        If TPS > ReadFlashByte(&H295E0) And TPS < ReadFlashByte(&H295E1) And main.ECUID.Text.Contains("BB34BB51") And MapSelected.Text.Contains("TPS") Then
            oxysensoractive = True
        End If
        If Not (oxysensoractive And RPM > ReadFlashWord(&H28C2E) / 2.56 And RPM < ReadFlashWord(&H28C2C) / 2.56 And CLT > ReadFlashByte(&H295DF)) Then
            oxysensoractive = False
        End If
        R_oxysensor.Checked = oxysensoractive


    End Sub


    Private Sub sendgaugedata()

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
            checksumerror = 3
            TextBox1.Text = "Checksum error in sending gauge data"
        End If

    End Sub

    Private Sub sendreset()

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
            checksumerror = 3
            TextBox1.Text = "Checksum error in sending reset data"
        End If

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DatastreamON.Click
        Timer2.Enabled = Not Timer2.Enabled
        Me.Text = "Datastream"
        If Timer2.Enabled Then

            B_DatastreamON.Text = "Data OFF"
            B_logging.Enabled = True
            ComboBox_Serialport.Enabled = False
            Combobox_Uservar1.Enabled = False
            Try
                SerialPort1.Open()
            Catch ex As Exception
                TextBox1.Text = ex.Message
                If Not SerialPort1.IsOpen() Then
                    B_DatastreamON.Text = "Data ON"
                    B_logging.Enabled = False
                    CLT_high = False
                    ComboBox_Serialport.Enabled = True
                    Combobox_Uservar1.Enabled = True
                    MapSelected.Text = ""
                    Timer2.Enabled = False
                End If
            End Try
        Else
            B_DatastreamON.Text = "Data ON"
            B_logging.Enabled = False
            CLT_high = False
            ComboBox_Serialport.Enabled = True
            Combobox_Uservar1.Enabled = True
            MapSelected.Text = ""
            Timer2.Enabled = False
            Try
                SerialPort1.Close()
            Catch ex As Exception
                TextBox1.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim d As Double

        '
        ' in case the coolant is dangerously high, inform the user as the clt sensor is not working
        '
        If CLT_high Then
            sendgaugedata()
        Else
            readprocessongoing = True
            readramvar()
            readprocessongoing = False
            If fuelmapvisible Then Fuelmap.tracemap()
            If Ignitionmapvisible Then Ignitionmap.tracemap()
        End If

        If checksumerror <> 0 Then
            'sendreset()
            TextBox1.Text = "Checksum general error in program"
        Else
            writelabels()


            If datalogpointer > 0 Then
                dataloglenght = datalogpointer
                datalog(datalogpointer, 0) = datalogpointer
                datalog(datalogpointer, 2) = RPM
                datalog(datalogpointer, 3) = TPS
                datalog(datalogpointer, 4) = IAP
                datalog(datalogpointer, 5) = AirPressure
                datalog(datalogpointer, 6) = CLT
                datalog(datalogpointer, 7) = USR1
                datalog(datalogpointer, 8) = FUEL
                datalog(datalogpointer, 9) = IGN
                datalog(datalogpointer, 10) = AFR

                datalogpointer = datalogpointer + 1

                If datalogpointer >= maxdatalog Then
                    B_logging.Text = "Logging ON"
                    dataloglenght = datalogpointer
                    datalogpointer = 0
                    Datalog_trackbar.Enabled = True
                    Datalog_trackbar.Maximum = dataloglenght
                    TextBox1.Text = Str(dataloglenght)
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
                Datalogger.L_capleft.Text = Str(Int(datalogpointer * 100 / maxdatalog)) & "%"
                If ((datalogpointer / maxdatalog) * 100) > 90 Then
                    Datalogger.L_capleft.ForeColor = Color.Red
                Else
                    Datalogger.L_capleft.ForeColor = Color.Black
                End If


            End If
        End If

    End Sub


    Private Sub B_logging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_logging.Click
        If B_logging.Text = "Logging ON" Then
            B_logging.Text = "Logging OFF"
            datalogpointer = 1
            Datalog_trackbar.Enabled = False
            Datalogger.Show()
        Else
            B_logging.Text = "Logging ON"
            dataloglenght = datalogpointer
            datalogpointer = 0
            Datalog_trackbar.Enabled = True
            Datalog_trackbar.Maximum = dataloglenght
            Datalog_trackbar.Value = datalogpointer
            TextBox1.Text = Str(dataloglenght)
            Datalogger.Close()
        End If
    End Sub

    Private Sub Datalog_trackbar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datalog_trackbar.Scroll

        datalogpointer = Datalog_trackbar.Value
        TextBox1.Text = Str(Datalog_trackbar.Value)


        RPM = datalog(Datalog_trackbar.Value, 2)
        TPS = datalog(Datalog_trackbar.Value, 3)
        IAP = datalog(Datalog_trackbar.Value, 4)
        OXY = datalog(Datalog_trackbar.Value, 5)
        CLT = datalog(Datalog_trackbar.Value, 6)
        USR1 = datalog(Datalog_trackbar.Value, 7)
        FUEL = datalog(Datalog_trackbar.Value, 8)
        IGN = datalog(Datalog_trackbar.Value, 9)
        AFR = datalog(Datalog_trackbar.Value, 10)
        If fuelmapvisible Then Fuelmap.tracemap()
        If Ignitionmapvisible Then Ignitionmap.tracemap()

        writelabels()

    End Sub

    Private Sub writelabels()

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
            MapSelected.Text = "TPS"
        Else
            If RPM < 2000 Then
                MapSelected.Text = "IDLE"
            Else
                MapSelected.Text = "IAP"
            End If
        End If

        LED_RPM.Text = Str(RPM)
        LED_TPS.Text = CalcTPS(TPS)
        LED_IAP.Text = Str(IAP)

        If metric Then
            LED_CLT.Text = Str(Int(((CLT - 32) * 10) / 18)) ' temperature in celsius
        Else
            LED_CLT.Text = Str(((9 / 5) * (Int(((CLT - 32) * 10) / 18))) - 32) ' temperature in fahrenheit
        End If

        LED_FUEL.Text = Str(FUEL)
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sendreset()
    End Sub

    Private Sub Combobox_Uservar1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combobox_Uservar1.TextChanged
        Select Case Combobox_Uservar1.SelectedIndex
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
                RAMVAR_USR1 = Val(Combobox_Uservar1.Text)
        End Select

        If RAMVAR_USR1 < 0 Or RAMVAR_USR1 > 255 Then
            RAMVAR_USR1 = 0
            MsgBox("Invalid USR1 parameter value(", MsgBoxStyle.OkOnly)
        Else
            My.Settings.Item("User1") = Str(RAMVAR_USR1)
        End If

    End Sub

    Private Function notvalidinterface(ByVal pvs As String) As Boolean
        Return (False)
    End Function

 
End Class