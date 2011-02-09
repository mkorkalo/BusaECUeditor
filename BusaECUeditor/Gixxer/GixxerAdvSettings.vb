Public Class GixxerAdvSettings
    Dim loading As Boolean
    Dim rpmconv As Long = (3840000000 / &H100)
    Dim addedrpm As Integer




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
        Me.Text = gixxer_modelname & " Advanced settings"

        If gixxer_msmode = 0 Then
            C_msmode.Enabled = False
        Else
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
        End If

        If gixxer_coilfi = 0 Then
            C_coil_fi_disable.Enabled = False
        Else
            If ReadFlashByte(gixxer_coilfi) = &H80 Then
                C_coil_fi_disable.Text = "Coil FI disabled"
                C_coil_fi_disable.Checked = True
            Else
                C_coil_fi_disable.Text = "Coil FI normal"
                C_coil_fi_disable.Checked = False
                WriteFlashByte(gixxer_coilfi, &HFF)
            End If
        End If

        If gixxer_pair = 0 Then
            C_PAIR.Enabled = False
        Else
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
        End If

        If gixxer_hoxflag = 0 Then
            C_HOX.Enabled = False
        Else
            If ReadFlashByte(gixxer_hoxflag) = &H80 Then
                C_HOX.Text = "HOX sensor ON"
                C_HOX.Checked = True
            Else
                C_HOX.Text = "HOX sensor OFF"
                C_HOX.Checked = False
            End If
        End If

        If gixxer_excva = 0 Then
            C_EXC.Enabled = False
        Else
            If ReadFlashByte(gixxer_excva_flag) = &HFF Then
                C_EXC.Checked = True
                C_EXC.Text = "EXC ON"
            Else
                C_EXC.Checked = False
                C_EXC.Text = "EXC OFF"
            End If
        End If


        If gixxer_GPS_AD_sensor_address_in_ignition_shiftkill = 0 Then
            NTCLT.Enabled = False
            C_2step.Enabled = False
        Else
            'populate NTCLT with initial value
            i = ReadFlashWord(gixxer_ignition_rpm_limiter + 6) ' &H60B30 this is the reference RPM that is stored in the system
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

            i = ReadFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill)
            If ReadFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill) <> &H80 Then C_2step.Checked = True Else C_2step.Checked = False
            If C_2step.Checked = True Then
                C_2step.Text = "2 step limiter ON"
                WriteFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill, gixxer_set_ign_default / &HFFFF)
                WriteFlashWord(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill + 1, gixxer_set_ign_default - (Int(gixxer_set_ign_default / &HFFFF) * &H10000))
            Else
                C_2step.Text = "2 step limiter OFF"
                WriteFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill, &H80)
                WriteFlashWord(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill + 1, gixxer_GPS_voltage_raw - &H800000)
            End If
        End If

        If gixxer_ecumode = 0 Then
            C_ECU.Enabled = False
        Else
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
        End If

        If gixxer_ics1 = 0 Then
            C_ICS.Enabled = False
        Else
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
        End If

        If gixxer_sd1 = 0 Then
            C_SD.Enabled = False
            Button4.Enabled = False
        Else
            If ReadFlashByte(gixxer_sd1) = &HFF Then C_SD.Checked = True Else C_SD.Checked = False
            If C_SD.Checked = True Then
                C_SD.Text = "SD active"
                WriteFlashByte(gixxer_sd1, &HFF)
                WriteFlashByte(gixxer_sd2, &HFF)
                WriteFlashByte(gixxer_sd3, &HFF)
            Else
                C_SD.Text = "SD disabled"
                WriteFlashByte(gixxer_sd1, &H0)
                WriteFlashByte(gixxer_sd2, &H0)
                WriteFlashByte(gixxer_sd3, &H0)
            End If
        End If

        If gixxer_fan = 0 Then
            c_fan.Enabled = False
        Else

            '
            ' Setting fan on of speed based on ecu values
            '
            ' If Metric then
            c_fan.Items.Add("105/100")
            c_fan.Items.Add("100/95")
            c_fan.Items.Add("95/90")
            c_fan.Items.Add("90/85")
            c_fan.Items.Add("85/80")
            ' else
            'c_fan.Items.Add("105/100")
            'c_fan.Items.Add("100/95")
            'c_fan.Items.Add("95/90")
            'c_fan.Items.Add("90/85")
            'c_fan.Items.Add("85/80")
            'endif

            i = Me.c_fan.SelectedIndex()
            i = ReadFlashByte(gixxer_fan + 1)
            Select Case i
                Case &HD8 ' 105/100
                    c_fan.SelectedIndex = 0
                Case &HD0 '100/95
                    c_fan.SelectedIndex = 1
                Case &HC8 '95/90
                    c_fan.SelectedIndex = 2
                Case &HC0 '90/85
                    c_fan.SelectedIndex = 3
                Case &HB8 '90/85
                    c_fan.SelectedIndex = 4
            End Select
        End If

        If gixxer_abc = 0 Then
            C_ABCmode.Enabled = False
        Else
            If ReadFlashByte(gixxer_abc) = &HA1 Then C_ABCmode.Checked = True Else C_ABCmode.Checked = False
            If C_ABCmode.Checked = True Then
                C_ABCmode.Text = "ABC normal"
                WriteFlashByte(gixxer_abc + 0, &HA1)
                WriteFlashByte(gixxer_abc + 1, &H9F)
                WriteFlashByte(gixxer_abc + 2, &H0)
                WriteFlashByte(gixxer_abc + 3, &H8)
            Else
                C_ABCmode.Text = "Fixed A-mode"
                WriteFlashByte(gixxer_abc + 0, &H91)
                WriteFlashByte(gixxer_abc + 1, &HF0)
                WriteFlashByte(gixxer_abc + 2, &H0)
                WriteFlashByte(gixxer_abc + 3, &H0)
            End If
        End If

        If gixxer_STP_map_first_table = 0 Then Button1.Enabled = False
        If gixxer_injectorbalance_map_first = 0 Then Button3.Enabled = False

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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
            baseline = 13100
            ' Set various RPM limits based on RPM value selected
            i = Val(NTCLT.Text)
            addedrpm = i - baseline ' we are just setting here the baseline

            WriteFlashWord(gixxer_ignition_rpm_limiter + 4, Int((rpmconv / (addedrpm + (rpmconv / &H47D))))) 'clutch limiter
            WriteFlashWord(gixxer_ignition_rpm_limiter + 6, Int((rpmconv / (addedrpm + (rpmconv / &H479))))) 'clutch limiter

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
                WriteFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill, gixxer_set_ign_default / &HFFFF)
                WriteFlashWord(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill + 1, gixxer_set_ign_default - (Int(gixxer_set_ign_default / &HFFFF) * &H10000))
            Else
                C_2step.Text = "2 step limiter OFF"
                WriteFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill, &H80)
                WriteFlashWord(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill + 1, gixxer_GPS_voltage_raw - &H800000)
                baseline = gixxer_baseline
                ' Set limiters back to stock
                loading = True
                i = ReadFlashWord(gixxer_RPM_limit_type1 + 6)
                i = Int(((rpmconv / (i + 0))) + 1)
                i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
                addedrpm = i - baseline ' we are just setting here the baseline
                If (ReadFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill) = &H80) Then WriteFlashWord(gixxer_ignition_rpm_limiter + 4, Int((rpmconv / (addedrpm + (rpmconv / &H47D))))) 'clutch limiter
                If (ReadFlashByte(gixxer_GPS_AD_sensor_address_in_ignition_shiftkill) = &H80) Then WriteFlashWord(gixxer_ignition_rpm_limiter + 6, Int((rpmconv / (addedrpm + (rpmconv / &H479))))) 'clutch limiter
                NTCLT.Items.Clear()
                'populate NTCLT with initial value
                i = ReadFlashWord(gixxer_ignition_rpm_limiter + 6) ' this is the reference RPM that is stored in the system
                i = Int(((rpmconv / (i + 0))))
                i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
                Me.NTCLT.Items.Add(i.ToString())
                i = 3000
                Do While i < 14500 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
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
            Select Case gixxer_ecumode

                Case &H73D2F
                    '
                    ' 21H50, 21H51, 21H60
                    '
                    Select Case C_ECU.Text
                        Case "US"
                            WriteFlashByte(gixxer_ecumode, &H80)
                        Case "EU"
                            WriteFlashByte(gixxer_ecumode, &HFF)
                        Case "Gen" 'generic model for those we do not know
                            WriteFlashByte(gixxer_ecumode, &H0)
                    End Select

                Case &H604CF

                    '
                    ' 21H50, 21H51, 21H60
                    '
                    Select Case C_ECU.Text
                        Case "US"
                            WriteFlashByte(gixxer_ecumode, &H80)
                            WriteFlashByte(&H6000A, &H80)
                            WriteFlashByte(&H6000B, &HC)
                            WriteFlashByte(&H6000C, &H1A)
                            WriteFlashByte(&H6000D, &HFF)
                            WriteFlashByte(&H6000F, &H0)
                            WriteFlashByte(&H60669, &HFF)
                            WriteFlashByte(&H604BC, 1)
                            WriteFlashByte(&H62ACA, &H1C)
                            WriteFlashByte(&H6292B, &H36)
                            WriteFlashByte(&HFFFF6, &H35)
                            WriteFlashByte(&HFFFF6, &H30)
                        Case "EU"
                            WriteFlashByte(gixxer_ecumode, &HFF)
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
                            WriteFlashByte(gixxer_ecumode, &H0)
                            WriteFlashByte(&H6292B, &H39)
                    End Select

                Case &H604CB
                    '
                    ' 21H00, 21H10
                    '
                    Select Case C_ECU.Text
                        Case "US"
                            WriteFlashByte(gixxer_ecumode, &H80) 'immobilizer_type
                            WriteFlashByte(&H6000A, &H80) 'same in 21H00 and 21H50/60
                            WriteFlashByte(&H6000B, &HC) 'same in 21H00 and 21H50/60
                            WriteFlashByte(&H6000C, &H1A) 'same in 21H00 and 21H50/60
                            WriteFlashByte(&H6000D, &HFF) 'same in 21H00 and 21H50/60
                            WriteFlashByte(&H6000F, &H0) 'same in 21H00 and 21H50/60
                            WriteFlashByte(&H60656, &HFF) 'EXCVA
                            WriteFlashByte(&H604B8, 1) 'US EU flag
                            WriteFlashByte(&H62A76, &H1C)
                            WriteFlashByte(&HFFFF6, &H30)
                            WriteFlashByte(&HFFFF6, &H34)
                        Case "EU"
                            WriteFlashByte(gixxer_ecumode, &HFF)
                            WriteFlashByte(&H6000A, &H0)
                            WriteFlashByte(&H6000B, &H32)
                            WriteFlashByte(&H6000C, &H8)
                            WriteFlashByte(&H6000D, &H0)
                            WriteFlashByte(&H6000F, &H80)
                            WriteFlashByte(&H60656, &H1)
                            WriteFlashByte(&H604B8, 3)
                            WriteFlashByte(&H62A76, &H7)
                            WriteFlashByte(&HFFFF6, &H31)
                            WriteFlashByte(&HFFFF6, &H31)

                        Case "Gen" 'generic model for those we do not know
                            WriteFlashByte(gixxer_ecumode, &H0)
                    End Select

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

    Private Sub C_SD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_SD.CheckedChanged
        If Not loading Then
            If C_SD.Checked = True Then
                C_SD.Text = "SD active"
                WriteFlashByte(gixxer_sd1, &HFF)
                WriteFlashByte(gixxer_sd2, &HFF)
                WriteFlashByte(gixxer_sd3, &HFF)
            Else
                C_SD.Text = "SD disabled"
                WriteFlashByte(gixxer_sd1, &H0)
                WriteFlashByte(gixxer_sd2, &H0)
                WriteFlashByte(gixxer_sd3, &H0)
            End If
        End If

    End Sub

    Private Sub G_misc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G_misc.Enter

    End Sub

    Private Sub c_fan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c_fan.SelectedIndexChanged
        Dim i As Integer
        If Not loading Then

            i = Me.c_fan.SelectedIndex()
            Select Case i
                Case 0 ' 105/100
                    WriteFlashByte(gixxer_fan, &HD0)
                    WriteFlashByte(gixxer_fan + 1, &HD8)
                    WriteFlashByte(gixxer_fan + 3, &HC8)
                    WriteFlashByte(gixxer_fan + 2, &HD0)
                Case 1 '100/95
                    WriteFlashByte(gixxer_fan, &HC8)
                    WriteFlashByte(gixxer_fan + 1, &HD0)
                    WriteFlashByte(gixxer_fan + 3, &HC0)
                    WriteFlashByte(gixxer_fan + 2, &HC8)

                Case 2 '95/90
                    WriteFlashByte(gixxer_fan, &HC0)
                    WriteFlashByte(gixxer_fan + 1, &HC8)
                    WriteFlashByte(gixxer_fan + 3, &HB8)
                    WriteFlashByte(gixxer_fan + 2, &HC0)

                Case 3 '90/85
                    WriteFlashByte(gixxer_fan, &HB8)
                    WriteFlashByte(gixxer_fan + 1, &HC0)
                    WriteFlashByte(gixxer_fan + 3, &HB9)
                    WriteFlashByte(gixxer_fan + 2, &HB8)

                Case 4 '85/80
                    WriteFlashByte(gixxer_fan, &HB0)
                    WriteFlashByte(gixxer_fan + 1, &HB8)
                    WriteFlashByte(gixxer_fan + 3, &HA8)
                    WriteFlashByte(gixxer_fan + 2, &HB0)

            End Select

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Gixxersteeringdampenermap.Show()
        Gixxersteeringdampenermap.Select()
    End Sub

    Private Sub C_ABCmode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ABCmode.CheckedChanged

        If Not loading Then
            If C_ABCmode.Checked = True Then
                C_ABCmode.Text = "ABC normal"
                WriteFlashByte(gixxer_abc + 0, &HA1)
                WriteFlashByte(gixxer_abc + 1, &H9F)
                WriteFlashByte(gixxer_abc + 2, &H0)
                WriteFlashByte(gixxer_abc + 3, &H8)
            Else
                C_ABCmode.Text = "Fixed A-mode"
                WriteFlashByte(gixxer_abc + 0, &H91)
                WriteFlashByte(gixxer_abc + 1, &HF0)
                WriteFlashByte(gixxer_abc + 2, &H0)
                WriteFlashByte(gixxer_abc + 3, &H0)

            End If
        End If

    End Sub
End Class