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
                    WriteFlashByte(&H6063A, 0)
                Case 1
                    WriteFlashByte(&H6063A, 1)
                Case 2
                    WriteFlashByte(&H6063A, &HFF)
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

        i = ReadFlashByte(&H6063A)
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

        If ReadFlashByte(&H60BC1) = &H80 Then
            C_coil_fi_disable.Text = "Coil FI disabled"
            C_coil_fi_disable.Checked = True
        Else
            C_coil_fi_disable.Text = "Coil FI normal"
            C_coil_fi_disable.Checked = False
            WriteFlashByte(&H60BC1, &HFF)
        End If


        If ReadFlashByte(&H6296A) = &HC8 Then
            C_FAN.Checked = True
            C_FAN.Text = "Fan ON/OFF 100/95"
            WriteFlashByte(&H6296A, &HC8)
            WriteFlashByte(&H6296B, &HD0)
        Else
            C_FAN.Checked = False
            C_FAN.Text = "Fan ON/OFF 95/90"
            WriteFlashByte(&H6296A, &HC0)
            WriteFlashByte(&H6296B, &HC8)
        End If

        If ReadFlashByte(&H62ABA) = &HFF Then
            C_PAIR.Text = "PAIR ON"
            C_PAIR.Checked = True
            WriteFlashByte(&H62ABA, &HFF) ' pair config flag
            WriteFlashByte(&H56D5C, &HFE)
            WriteFlashByte(&H56D5D, &HFF)
            WriteFlashByte(&H56D5E, &HFC)
            WriteFlashByte(&H56D5F, &H10)
        Else
            C_PAIR.Text = "PAIR OFF"
            C_PAIR.Checked = False
            WriteFlashByte(&H62ABA, &H80) ' pair config flag
            WriteFlashByte(&H56D5C, &H70)
            WriteFlashByte(&H56D5D, &H0)
            WriteFlashByte(&H56D5E, &H70)
            WriteFlashByte(&H56D5F, &H0)
        End If

        If ReadFlashByte(&H614D4) = &H80 Then
            C_HOX.Text = "HOX sensor ON"
            C_HOX.Checked = True
        Else
            C_HOX.Text = "HOX sensor OFF"
            C_HOX.Checked = False
        End If

        If ReadFlashByte(&H60669) = &HFF Then
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
        Select Case ReadFlashByte(&H6292B)
            Case &H35
                C_ECU.SelectedIndex = 0
            Case &H36
                C_ECU.SelectedIndex = 1
            Case &H39
                C_ECU.SelectedIndex = 2
            Case Else
                MsgBox("ECU Type not detected, using generic")
                C_ECU.SelectedIndex = 2
        End Select



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
                WriteFlashByte(&H60BC1, &H80)
            Else
                C_coil_fi_disable.Text = "Coil FI normal"
                WriteFlashByte(&H60BC1, &HFF)
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_FAN.CheckedChanged

        If Not loading Then
            If C_FAN.Checked = True Then
                C_FAN.Text = "Fan ON/OFF 100/95"
                WriteFlashByte(&H6296A, &HC8)
                WriteFlashByte(&H6296B, &HD0)
            Else
                C_FAN.Text = "Fan ON/OFF 95/90"
                WriteFlashByte(&H6296A, &HC0)
                WriteFlashByte(&H6296B, &HC8)
            End If
        End If

    End Sub

    Private Sub C_PAIR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_PAIR.CheckedChanged
        If Not loading Then
            If C_PAIR.Checked = True Then
                C_PAIR.Text = "PAIR ON"
                WriteFlashByte(&H62ABA, &HFF) ' pair config flag
                WriteFlashByte(&H56D5C, &HFE)
                WriteFlashByte(&H56D5D, &HFF)
                WriteFlashByte(&H56D5E, &HFC)
                WriteFlashByte(&H56D5F, &H10)
            Else
                C_PAIR.Text = "PAIR OFF"
                WriteFlashByte(&H62ABA, &H80)
                WriteFlashByte(&H56D5C, &H70)
                WriteFlashByte(&H56D5D, &H0)
                WriteFlashByte(&H56D5E, &H70)
                WriteFlashByte(&H56D5F, &H0)

            End If
        End If

    End Sub

    Private Sub C_EXC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_EXC.CheckedChanged
        If Not loading Then

            If C_EXC.Checked = True Then
                C_EXC.Text = "EXCV ON"
                WriteFlashByte(&H60669, &HFF) '60669
                WriteFlashByte(&H6000D, &HFF) '6000D
                WriteFlashByte(&H6000F, &H0)  '6000F
            Else
                C_EXC.Text = "EXCV OFF"
                WriteFlashByte(&H60669, &H1) 'could be 0 or 1
                WriteFlashByte(&H6000D, &H0) 'if 0 shows error on busa
                WriteFlashByte(&H6000F, &H80)
            End If

        End If

    End Sub

    Private Sub C_HOX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_HOX.CheckedChanged
        If Not loading Then
            If C_HOX.Checked = True Then
                C_HOX.Text = "HOX sensor ON"
                WriteFlashByte(&H614D4, &H80)
                WriteFlashByte(&H62243, &HFF)
            Else
                C_HOX.Text = "HOX sensor OFF"
                WriteFlashByte(&H614D4, &H0)
                WriteFlashByte(&H62243, &H80)
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
        Dim i As Integer

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
End Class