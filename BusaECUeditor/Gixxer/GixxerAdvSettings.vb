Public Class GixxerAdvSettings
    Dim loading As Boolean
    Dim rpmconv As Long = (3840000000 / &H100)
    Dim addedrpm As Integer

    Public gixxer_msmode As Integer = &H6063A
    Public gixxer_coilfi As Integer = &H60BC1
    Public gixxer_fan As Integer = &H6296A
    Public gixxer_pair As Integer = &H62ABA
    Public gixxer_pairloop As Integer = &H56D5C
    Public gixxer_excva As Integer = &H6000D
    Public gixxer_excva_flag As Integer = &H60669
    Public gixxer_hoxflag As Integer = &H614D4
    Public gixxer_ecumode As Integer = &H604CF
    Public gixxer_ics1 As Integer = &H622EE
    Public gixxer_ics2 As Integer = &H6230A
    Public gixxer_ics3 As Integer = &H62296
    Public gixxer_hox1 As Integer = &H614D4
    Public gixxer_hox2 As Integer = &H62243


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GixxerSTPmap.Show()
        GixxerSTPmap.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub C_msmode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_msmode.SelectedIndexChanged
        Dim i As Integer
        If Not loading Then
            i = Me.C_msmode.SelectedIndex()
            Select Case i
                Case 0
                    WriteFlashByte(gixxer_msmode, 0)
                Case 1
                    WriteFlashByte(gixxer_msmode, 1)
                Case 2
                    WriteFlashByte(gixxer_msmode, &HFF)
                Case Else
                    MsgBox("MS mode not detected, please reset the mode")
            End Select

        End If
    End Sub



    Private Sub GixxerAdvSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loading = True
        Dim i As Integer

        Me.C_msmode.Items.Add("mode 0")
        Me.C_msmode.Items.Add("mode 1")
        Me.C_msmode.Items.Add("switchable")

        i = ReadFlashByte(gixxer_msmode)
        Select Case i
            Case 0
                Me.C_msmode.SelectedIndex = 0
            Case 1
                Me.C_msmode.SelectedIndex = 1
            Case &HFF
                Me.C_msmode.SelectedIndex = 2
            Case Else
                MsgBox("MS mode not detected, please reset the mode")
        End Select
        If ReadFlashByte(gixxer_coilfi) = &H80 Then
            C_coil_fi_disable.Text = "Coil FI disabled"
            C_coil_fi_disable.Checked = True
        Else
            C_coil_fi_disable.Text = "Coil FI normal"
            C_coil_fi_disable.Checked = False
            WriteFlashByte(gixxer_coilfi, &HFF)
        End If


        If ReadFlashByte(gixxer_fan) = &HC8 Then
            C_FAN.Checked = True
            C_FAN.Text = "Fan ON/OFF 100/95"
            WriteFlashByte(gixxer_fan, &HC8)
            WriteFlashByte(gixxer_fan + 1, &HD0)
        Else
            C_FAN.Checked = False
            C_FAN.Text = "Fan ON/OFF 95/90"
            WriteFlashByte(gixxer_fan, &HC0)
            WriteFlashByte(gixxer_fan + 1, &HC8)
        End If

        If ReadFlashByte(gixxer_pair) = &HFF Then
            C_PAIR.Text = "PAIR ON"
            C_PAIR.Checked = True


            WriteFlashByte(gixxer_pair, &HFF) ' pair config flag
            WriteFlashByte(gixxer_pairloop, &HFE)
            WriteFlashByte(gixxer_pairloop + 1, &HFF)
            WriteFlashByte(gixxer_pairloop + 2, &HFC)
            WriteFlashByte(gixxer_pairloop + 3, &H10)
        Else
            C_PAIR.Text = "PAIR OFF"
            C_PAIR.Checked = False
            WriteFlashByte(gixxer_pair, &H80) ' pair config flag
            WriteFlashByte(gixxer_pairloop, &H70)
            WriteFlashByte(gixxer_pairloop + 1, &H0)
            WriteFlashByte(gixxer_pairloop + 1, &H70)
            WriteFlashByte(gixxer_pairloop + 3, &H0)
        End If

        If ReadFlashByte(gixxer_hoxflag) = &H80 Then
            C_HOX.Text = "HOX sensor ON"
            C_HOX.Checked = True
        Else
            C_HOX.Text = "HOX sensor OFF"
            C_HOX.Checked = False
        End If

        If ReadFlashByte(gixxer_excva_flag) = &HFF Then
            C_EXC.Checked = True
            C_EXC.Text = "EXC ON"
        Else
            C_EXC.Checked = False
            C_EXC.Text = "EXC OFF"
        End If

        'populate NTCLT with initial value
        i = ReadFlashWord(&H60B30) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))))
        i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
        Me.NTCLT.Items.Add(i.ToString())
        i = 3000
        Do While i < 13500 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.NTCLT.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.NTCLT.Items.Add(i.ToString())
        Me.NTCLT.SelectedIndex = 0
        Me.NTCLT.Enabled = True
        i = ReadFlashByte(&H3B4C1)
        If ReadFlashByte(&H3B4C1) = &H6 Then C_2step.Checked = True Else C_2step.Checked = False
        If C_2step.Checked = True Then
            C_2step.Text = "2 step limiter ON"
            WriteFlashByte(&H3B4C0 + 1, &H6)
            WriteFlashByte(&H3B4C0 + 2, &HB)
            WriteFlashByte(&H3B4C0 + 3, &H57)
        Else
            C_2step.Text = "2 step limiter OFF"
            WriteFlashByte(&H3B4C0 + 1, &H80)
            WriteFlashByte(&H3B4C0 + 2, &H50)
            WriteFlashByte(&H3B4C0 + 3, &HF9)
        End If

        C_ECU.Items.Add("EU") '0
        C_ECU.Items.Add("US") '1
        C_ECU.Items.Add("Gen") '2
        Select Case ReadFlashByte(gixxer_ecumode)
            Case &HFF
                C_ECU.SelectedIndex = 0
            Case &H80
                C_ECU.SelectedIndex = 1
            Case &H0
                C_ECU.SelectedIndex = 2
            Case Else
                MsgBox("ECU Type not detected, using generic")
                C_ECU.SelectedIndex = 2
        End Select

 
        If ReadFlashByte(gixxer_ics1) = &HFF Then C_ICS.Checked = True Else C_ICS.Checked = False
        If C_ICS.Checked = True Then
            C_ICS.Text = "ICS ON"
            WriteFlashByte(gixxer_ics1, &HFF) 'ICS solenoid port test error code disable
            WriteFlashByte(gixxer_ics1 + 10, &HFF) 'ICS port config const
            WriteFlashByte(gixxer_ics2, &HFF) 'rpm window error disable
            WriteFlashWord(gixxer_ics3, &H1400) 'idle RPM limit normal 2000rpm
        Else
            C_ICS.Text = "ISC OFF"
            WriteFlashByte(gixxer_ics1, &H0)  'ICS solenoid port test error code disable
            WriteFlashByte(gixxer_ics1 + 10, &H0) 'ICS port config const
            WriteFlashByte(gixxer_ics2, &H0) 'rpm window error disable
            WriteFlashWord(gixxer_ics3, &H7800) 'idle RPM high limit set to 12000rpm
        End If


        loading = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Gixxerinjectorbalancemap.Show()
        Gixxerinjectorbalancemap.Select()
    End Sub

    Private Sub C_coil_fi_disable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_coil_fi_disable.CheckedChanged
        If Not loading Then
            If C_coil_fi_disable.Checked = True Then
                C_coil_fi_disable.Text = "Coil FI disabled"
                WriteFlashByte(gixxer_coilfi, &H80)
            Else
                C_coil_fi_disable.Text = "Coil FI normal"
                WriteFlashByte(gixxer_coilfi, &HFF)
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_FAN.CheckedChanged

        If Not loading Then
            If C_FAN.Checked = True Then
                C_FAN.Text = "Fan ON/OFF 100/95"
                WriteFlashByte(gixxer_fan, &HC8)
                WriteFlashByte(gixxer_fan + 1, &HD0)
            Else
                C_FAN.Text = "Fan ON/OFF 95/90"
                WriteFlashByte(gixxer_fan, &HC0)
                WriteFlashByte(gixxer_fan + 1, &HC8)
            End If
        End If

    End Sub

    Private Sub C_PAIR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_PAIR.CheckedChanged
        If Not loading Then
            If C_PAIR.Checked = True Then
                C_PAIR.Text = "PAIR ON"
                WriteFlashByte(gixxer_pair, &HFF) ' pair config flag
                WriteFlashByte(gixxer_pairloop, &HFE)
                WriteFlashByte(gixxer_pairloop + 1, &HFF)
                WriteFlashByte(gixxer_pairloop + 2, &HFC)
                WriteFlashByte(gixxer_pairloop + 3, &H10)
            Else
                C_PAIR.Text = "PAIR OFF"
                WriteFlashByte(gixxer_pair, &H80)
                WriteFlashByte(gixxer_pairloop, &H70)
                WriteFlashByte(gixxer_pairloop + 1, &H0)
                WriteFlashByte(gixxer_pairloop + 2, &H70)
                WriteFlashByte(gixxer_pairloop + 3, &H0)

            End If
        End If

    End Sub

    Private Sub C_EXC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_EXC.CheckedChanged
        If Not loading Then


            If C_EXC.Checked = True Then
                C_EXC.Text = "EXCV ON"
                WriteFlashByte(gixxer_excva_flag, &HFF) '60669
                WriteFlashByte(gixxer_excva, &HFF) '6000D
                WriteFlashByte(gixxer_excva + 1, &H0)  '6000F
            Else
                C_EXC.Text = "EXCV OFF"
                WriteFlashByte(gixxer_excva_flag, &H1) 'could be 0 or 1
                WriteFlashByte(gixxer_excva, &H0) 'if 0 shows error on busa
                WriteFlashByte(gixxer_excva + 1, &H80)
            End If

        End If

    End Sub

 
    Private Sub C_HOX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_HOX.CheckedChanged
        If Not loading Then
            If C_HOX.Checked = True Then
                C_HOX.Text = "HOX sensor ON"
                WriteFlashByte(gixxer_hox1, &H80)
                WriteFlashByte(gixxer_hox2, &HFF)
            Else
                C_HOX.Text = "HOX sensor OFF"
                WriteFlashByte(gixxer_hox1, &H0)
                WriteFlashByte(gixxer_hox2, &H80)
            End If
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NTCLT.SelectedIndexChanged
        Dim i As Integer
        Dim baseline As Integer
        If Not loading Then


            '
            ' RPM/Fuel hard type 2, this is modified higher than stock as ecu default is not used in this case
            '
            baseline = 13050
            ' Set various RPM limits based on RPM value selected
            i = Val(NTCLT.Text)
            addedrpm = i - baseline ' we are just setting here the baseline

            WriteFlashWord(&H60B30, Int((rpmconv / (addedrpm + (rpmconv / &H47D))))) 'clutch limiter
            WriteFlashWord(&H60B32, Int((rpmconv / (addedrpm + (rpmconv / &H479))))) 'clutch limiter

            '
            ' Make ignition limiter to skip GPS error and GPS neutral using &H80 value as raw gps information
            '
            WriteFlashByte(&H3B4C0 + 1, &H6)
            WriteFlashByte(&H3B4C0 + 2, &HB)
            WriteFlashByte(&H3B4C0 + 3, &H57)
            C_2step.Checked = True
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_2step.CheckedChanged
        Dim baseline As Integer
        Dim i As Integer

        If Not loading Then

            If C_2step.Checked = True Then
                C_2step.Text = "2 step limiter ON"
                WriteFlashByte(&H3B4C0 + 1, &H6)
                WriteFlashByte(&H3B4C0 + 2, &HB)
                WriteFlashByte(&H3B4C0 + 3, &H57)
            Else
                C_2step.Text = "2 step limiter OFF"
                WriteFlashByte(&H3B4C0 + 1, &H80)
                WriteFlashByte(&H3B4C0 + 2, &H50)
                WriteFlashByte(&H3B4C0 + 3, &HF9)
                baseline = 13450
                ' Set limiters back to stock
                loading = True
                i = ReadFlashWord(&H61372)
                i = Int(((rpmconv / (i + 0))) + 1)
                i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
                addedrpm = i - baseline ' we are just setting here the baseline
                If (ReadFlashByte(&H3B4C1) = &H80) Then WriteFlashWord(&H60B30, Int((rpmconv / (addedrpm + (rpmconv / &H47D))))) 'clutch limiter
                If (ReadFlashByte(&H3B4C1) = &H80) Then WriteFlashWord(&H60B32, Int((rpmconv / (addedrpm + (rpmconv / &H479))))) 'clutch limiter
                NTCLT.Items.Clear()
                'populate NTCLT with initial value
                i = ReadFlashWord(&H60B30) ' this is the reference RPM that is stored in the system
                i = Int(((rpmconv / (i + 0))))
                i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
                Me.NTCLT.Items.Add(i.ToString())
                i = 3000
                Do While i < 13500 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
                    Me.NTCLT.Items.Add(i.ToString())
                    i = i + 100
                Loop
                Me.NTCLT.Items.Add(i.ToString())
                Me.NTCLT.SelectedIndex = 0
                Me.NTCLT.Enabled = True
                loading = False
            End If


        End If

    End Sub

    Private Sub C_ECU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ECU.SelectedIndexChanged

        If Not loading Then

            Select Case C_ECU.Text
                Case "US"
                    WriteFlashByte(&H604CF, &H80)
                    WriteFlashByte(&H6000A, &H80)
                    WriteFlashByte(&H6000B, &HC)
                    WriteFlashByte(&H6000C, &H1A)
                    WriteFlashByte(&H6000D, &HFF)
                    WriteFlashByte(&H6000F, &H0)
                    WriteFlashByte(&H60669, &HFF)
                    WriteFlashByte(&H604BC, 1)
                    WriteFlashByte(&H62ACA, &H1C)
                    WriteFlashByte(&H6292B, &H36)
                Case "EU"
                    WriteFlashByte(&H604CF, &HFF)
                    WriteFlashByte(&H6000A, &H0)
                    WriteFlashByte(&H6000B, &H32)
                    WriteFlashByte(&H6000C, &H8)
                    WriteFlashByte(&H6000D, &H0)
                    WriteFlashByte(&H6000F, &H80)
                    WriteFlashByte(&H60669, &H1)
                    WriteFlashByte(&H604BC, 3)
                    WriteFlashByte(&H62ACA, &H7)
                    WriteFlashByte(&H6292B, &H35)
                Case "Gen" 'generic model for those we do not know
                    WriteFlashByte(&H604CF, &H0)
                    WriteFlashByte(&H6292B, &H39)
            End Select

            main.SetECUType()
        End If


    End Sub

    Private Sub C_ICS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ICS.CheckedChanged
        If Not loading Then
            If C_ICS.Checked = True Then
                C_ICS.Text = "ICS ON"
                WriteFlashByte(gixxer_ics1, &HFF) 'ICS solenoid port test error code disable
                WriteFlashByte(gixxer_ics1 + 10, &HFF) 'ICS port config const
                WriteFlashByte(gixxer_ics2, &HFF) 'rpm window error disable
                WriteFlashWord(gixxer_ics3, &H1400) 'idle RPM limit normal 2000rpm
            Else
                C_ICS.Text = "ISC OFF"
                WriteFlashByte(gixxer_ics1, &H0)  'ICS solenoid port test error code disable
                WriteFlashByte(gixxer_ics1 + 10, &H0) 'ICS port config const
                WriteFlashByte(gixxer_ics2, &H0) 'rpm window error disable
                WriteFlashWord(gixxer_ics3, &H7800) 'idle RPM high limit set to 12000rpm
            End If
        End If


    End Sub
End Class