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

Public Class Advsettings
    Dim solenoid_on_low As Integer
    Dim solenoid_on_high As Integer
    Dim solenoid_off_low As Integer
    Dim Solenoid_off_high As Integer
    Dim solenoidchangeok As Boolean
    Dim injector_A As Integer
    Dim injector_B As Integer
    Dim fuelconsumption As Integer
    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click
        Me.Close()
    End Sub


    Private Sub MiscSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim dwell As Integer

        solenoid_on_low = &H32C78   ' RPM/100, byte, 5
        solenoid_on_high = &H32C78 + 1 '8
        solenoid_off_low = &H32C78 + 2 '22
        Solenoid_off_high = &H32C78 + 3
        solenoidchangeok = False


        IAPLow.Text = Str(ReadFlashByte(&H295E2))
        IAPHigh.Text = Str(ReadFlashByte(&H295E3))
        TPSLow.Text = Str(Int((ReadFlashByte(&H295E0))))
        TPSHigh.Text = Str(Int(CalcTPSDec(ReadFlashByte(&H295E1))))
        RPMLow.Text = Str(Int(ReadFlashWord(&H28C2E) / 2.56))
        RPMHigh.Text = Str(Int(ReadFlashWord(&H28C2C) / 2.56))
        CLTMin.Text = Str((((ReadFlashByte(&H295DF) - 32) * 10) / 18))


        '
        ' Set Gearing compensation combos and initial value
        '
        C_Gearing.Enabled = False
        C_Gearing.Items.Add("dynomode") '0
        C_Gearing.Items.Add("16/40") '1
        C_Gearing.Items.Add("16/43") '2
        C_Gearing.Items.Add("17/40") '3
        C_Gearing.Items.Add("18/38") '4
        C_Gearing.Items.Add("18/40") '5
        C_Gearing.Items.Add("18/42") '6
        C_Gearing.Items.Add("18/43") '7
        C_Gearing.Items.Add("Turbo") '8
        C_Gearing.Items.Add("TRE 5th") '9

        i = CInt(ReadFlashByte(&H28B4C + 8))
        C_Gearing.Enabled = True
        Select Case i
            Case CInt(105 * 16 / 17 * 40 / 40)
                C_Gearing.SelectedIndex = 1
            Case CInt(105 * 16 / 17 * 40 / 43)
                C_Gearing.SelectedIndex = 2
            Case CInt(105 * 17 / 17 * 40 / 40)
                C_Gearing.SelectedIndex = 3
            Case CInt(105 * 18 / 17 * 40 / 38)
                C_Gearing.SelectedIndex = 4
            Case CInt(105 * 18 / 17 * 40 / 40)
                C_Gearing.SelectedIndex = 5
            Case CInt(105 * 18 / 17 * 40 / 42)
                C_Gearing.SelectedIndex = 6
            Case CInt(105 * 18 / 17 * 40 / 43)
                C_Gearing.SelectedIndex = 7
            Case CInt(32 * 1.05)
                C_Gearing.SelectedIndex = 8
            Case CInt(96)
                C_Gearing.SelectedIndex = 9
            Case Else
                'MsgBox("Gear compensation set to dynomode")
                C_Gearing.SelectedIndex = 0
        End Select


        '
        ' Ignition dwell table
        '
        dwell = ReadFlashByte(&H3686E + 27)
        C_dwell.Items.Add(Str(CInt(100 * dwell / 101)))
        C_dwell.Items.Add("100")
        C_dwell.Items.Add("105")
        C_dwell.Items.Add("110")
        C_dwell.Items.Add("120")
        C_dwell.SelectedIndex = 0

        '
        ' preset the selection and actual value of injector size words
        '
        injector_A = &HDA42 ' word
        injector_B = &HDAAA
        i = CInt((128 / ReadFlashWord(injector_A) * 100) / 5) * 5
        C_injectorsize.Items.Add(Str(i))
        C_injectorsize.Items.Add("400")
        C_injectorsize.Items.Add("350")
        C_injectorsize.Items.Add("300")
        C_injectorsize.Items.Add("250")
        C_injectorsize.Items.Add("200")
        C_injectorsize.Items.Add("150")
        C_injectorsize.Items.Add("145")
        C_injectorsize.Items.Add("140")
        C_injectorsize.Items.Add("135")
        C_injectorsize.Items.Add("130")
        C_injectorsize.Items.Add("125")
        C_injectorsize.Items.Add("120")
        C_injectorsize.Items.Add("115")
        C_injectorsize.Items.Add("110")
        C_injectorsize.Items.Add("105")
        C_injectorsize.Items.Add("100")
        C_injectorsize.Items.Add("95")
        C_injectorsize.Items.Add("90")
        C_injectorsize.Items.Add("85")
        C_injectorsize.Items.Add("80")
        C_injectorsize.SelectedIndex = 0

        '
        ' preset the selection and actual value of fuelconsumption byte
        '
        fuelconsumption = &H7913
        i = ReadFlashByte(fuelconsumption)
        'i = (CInt(i - 100) * 2) + 100
        C_fuelconsumption.Items.Add(Str(i))
        'C_fuelconsumption.Items.Add("150")
        'C_fuelconsumption.Items.Add("145")
        'C_fuelconsumption.Items.Add("140")
        'C_fuelconsumption.Items.Add("135")
        'C_fuelconsumption.Items.Add("130")
        C_fuelconsumption.Items.Add("125")
        C_fuelconsumption.Items.Add("120")
        C_fuelconsumption.Items.Add("115")
        C_fuelconsumption.Items.Add("110")
        C_fuelconsumption.Items.Add("105")
        C_fuelconsumption.Items.Add("100")
        C_fuelconsumption.Items.Add("95")
        C_fuelconsumption.Items.Add("90")
        C_fuelconsumption.Items.Add("85")
        C_fuelconsumption.Items.Add("80")
        C_fuelconsumption.SelectedIndex = 0

        C_solenoid_on.Items.Add(Str(ReadFlashByte(solenoid_on_low) * 100))
        C_solenoid_off.Items.Add(Str(ReadFlashByte(solenoid_off_low) * 100))
        C_solenoid_on.SelectedIndex = 0
        C_solenoid_off.SelectedIndex = 0
        For i = 1 To 20
            C_solenoid_on.Items.Add(Str(i * 500))
            C_solenoid_off.Items.Add(Str(i * 500))
        Next
        For i = 101 To 120
            C_solenoid_on.Items.Add(Str(i * 100))
            C_solenoid_off.Items.Add(Str(i * 100))
        Next

        solenoidchangeok = True

        If ReadFlashByte(&H28BD4) = &HFF Then
            IAT_disable.Checked = False
        Else
            IAT_disable.Checked = True
        End If


        If ReadFlashWord(&H8846) <> &HF852 Then
            IAP_range.Checked = True
        Else
            IAP_range.Checked = False
        End If

        If ReadFlashWord(&H7650) <> &HCB01 Then
            C_antitheft.Checked = True
        Else
            C_antitheft.Checked = False
        End If

        If ReadFlashWord(&H28C2C) <> &H3000 Then
            C_cranking.Checked = True
        Else
            C_cranking.Checked = False
        End If

        '
        ' Enable disable yoshbox compensation
        '
        If ReadFlashWord(&HE95A) <> &H6540 Then
            C_yoshbox.Checked = True
        Else
            C_yoshbox.Checked = False
        End If


        '
        ' Lets see the acceleration enrichment here...
        '
        For i = -5 To 5
            C_Accel.Items.Add(Str(i * 20))
        Next
        Select Case Int(ReadFlashByte(&H32A39 + 6))
            Case 32
                i = -100
                C_Accel.SelectedIndex = 0
            Case 41
                i = -80
                C_Accel.SelectedIndex = 1
            Case 51
                i = -60
                C_Accel.SelectedIndex = 2
            Case 60
                i = -40
                C_Accel.SelectedIndex = 3
            Case 70
                i = -20
                C_Accel.SelectedIndex = 4
            Case 80
                i = 0
                C_Accel.SelectedIndex = 5
            Case 89
                i = 20
                C_Accel.SelectedIndex = 6
            Case 99
                i = 40
                C_Accel.SelectedIndex = 7
            Case 108
                i = 60
                C_Accel.SelectedIndex = 8
            Case 118
                i = 80
                C_Accel.SelectedIndex = 9
            Case 128
                i = 100
                C_Accel.SelectedIndex = 10
            Case Else
                MsgBox("Could not calculate acccel enrichment, please reset", MsgBoxStyle.Information)
        End Select

        Solenoid_TPS.Enabled = False
        If ReadFlashByte(&H10A8F) = &HA7 Then
            Solenoid_TPS.Text = "Normal"
            Solenoid_TPS.Checked = False
        ElseIf ReadFlashByte(&H10A8F) = &H3E Then
            Solenoid_TPS.Text = "TPS > 85%"
            Solenoid_TPS.Checked = True
        Else
            Solenoid_TPS.Text = "Unknown"
            MsgBox("Unknown ecu setting, please do not use this file !!!")
        End If
        Solenoid_TPS.Enabled = True


        C_IAPTPSswitchingpoint.Items.Add(CalcTPS(ReadFlashByte(&H294FC)))
        C_IAPTPSswitchingpoint.SelectedIndex = 0
        For i = 2 To 15
            C_IAPTPSswitchingpoint.Items.Add(Str(i))
        Next


    End Sub


    Private Sub C_injectorsize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_injectorsize.SelectedIndexChanged
        Dim i As Integer
        Dim newsize As Decimal
        '
        ' Injectorsize is calculated as 128 + injector size
        ' std injectorsize is 128, hence any change required needs to be doubled
        ' on the other hand the effect to the flow is change=sqrt((new+128)/(old+128)) -> change=sqrt(new)/sqrt(old)
        ' sqrt(new+128)=change*sqrt(old+128)-> .... thats almost the same as 2* change....
        '
        i = Val(C_injectorsize.Text)
        'i = ((i - 100) * 2) + 100
        newsize = (100 / i) * 128
        WriteFlashWord(injector_A, CInt(newsize))
        WriteFlashWord(injector_B, CInt(newsize))
    End Sub

    Private Sub C_solenoid_on_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_solenoid_on.SelectedIndexChanged
        Dim i As Integer
        If solenoidchangeok Then
            If (ReadFlashByte(solenoid_on_low) = 5) And (ReadFlashByte(solenoid_on_high) = 8) And (ReadFlashByte(solenoid_off_low) = 22) Then
                MsgBox("If you Flash the ecu your after this the IAC solenoid will be reprogrammed as Nitrous control relay", MsgBoxStyle.Information)
            End If
            i = Val(C_solenoid_on.Text)
            WriteFlashByte(solenoid_on_low, Int(i / 100))
            WriteFlashByte(solenoid_on_high, Int((i + 100) / 100))
        End If
    End Sub

    Private Sub C_solenoid_off_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_solenoid_off.SelectedIndexChanged
        Dim i As Integer
        If solenoidchangeok Then
            If (ReadFlashByte(solenoid_on_low) = 5) And (ReadFlashByte(solenoid_on_high) = 8) And (ReadFlashByte(solenoid_off_low) = 22) Then
                MsgBox("If you Flash the ecu your after this the IAC solenoid will be reprogrammed as Nitrous control relay", MsgBoxStyle.Information)
            End If
            i = Val(C_solenoid_off.Text)
            WriteFlashByte(solenoid_off_low, Int(i / 100))
            WriteFlashByte(Solenoid_off_high, Int((i + 100) / 100))
        End If
    End Sub


    Private Sub IAT_disable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IAT_disable.CheckedChanged
        Dim i As Integer
        ' IAT_disable.Checked = Not IAT_disable.Checked
        If IAT_disable.Checked Then
            IAT_disable.Text = "IAT fixed to 24C"
            For i = 0 To 29
                WriteFlashByte(&H28BD4 + i, 75) '65=18C, 75=24C, 128=54C
            Next
        Else
            IAT_disable.Text = "IAT normal"
            ' set IAT values back to normal
            WriteFlashByte(&H28BD4 + 0, &HFF)
            WriteFlashByte(&H28BD4 + 1, &HFF)
            WriteFlashByte(&H28BD4 + 2, &HD3)
            WriteFlashByte(&H28BD4 + 3, &HB8)
            WriteFlashByte(&H28BD4 + 4, &HA6)
            WriteFlashByte(&H28BD4 + 5, &H98)
            WriteFlashByte(&H28BD4 + 6, &H8D)
            WriteFlashByte(&H28BD4 + 7, &H83)
            WriteFlashByte(&H28BD4 + 8, &H7B)
            WriteFlashByte(&H28BD4 + 9, &H74)
            WriteFlashByte(&H28BD4 + 10, &H6D)
            WriteFlashByte(&H28BD4 + 11, &H67)
            WriteFlashByte(&H28BD4 + 12, &H61)
            WriteFlashByte(&H28BD4 + 13, &H5B)
            WriteFlashByte(&H28BD4 + 14, &H56)
            WriteFlashByte(&H28BD4 + 15, &H51)
            WriteFlashByte(&H28BD4 + 16, &H4C)
            WriteFlashByte(&H28BD4 + 17, &H47)
            WriteFlashByte(&H28BD4 + 18, &H43)
            WriteFlashByte(&H28BD4 + 19, &H3E)
            WriteFlashByte(&H28BD4 + 20, &H39)
            WriteFlashByte(&H28BD4 + 21, &H34)
            WriteFlashByte(&H28BD4 + 22, &H30)
            WriteFlashByte(&H28BD4 + 23, &H2B)
            WriteFlashByte(&H28BD4 + 24, &H25)
            WriteFlashByte(&H28BD4 + 25, &H20)
            WriteFlashByte(&H28BD4 + 26, &H1A)
            WriteFlashByte(&H28BD4 + 27, &H13)
            WriteFlashByte(&H28BD4 + 28, &HC)
            WriteFlashByte(&H28BD4 + 29, &H3)
        End If
    End Sub


    Private Sub C_Accel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Accel.SelectedIndexChanged
        Dim change As Integer

        change = Val(C_Accel.Items.Item(C_Accel.SelectedIndex))
        WriteFlashByte(&H32A39 + 0, 32 + Int((1 + (change / 100)) * 0))
        WriteFlashByte(&H32A39 + 1, 32 + Int((1 + (change / 100)) * 3))
        WriteFlashByte(&H32A39 + 2, 32 + Int((1 + (change / 100)) * 7))
        WriteFlashByte(&H32A39 + 3, 32 + Int((1 + (change / 100)) * 15))
        WriteFlashByte(&H32A39 + 4, 32 + Int((1 + (change / 100)) * 24))
        WriteFlashByte(&H32A39 + 5, 32 + Int((1 + (change / 100)) * 35))
        WriteFlashByte(&H32A39 + 6, 32 + Int((1 + (change / 100)) * 48))

    End Sub


    Private Sub Solenoid_TPS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Solenoid_TPS.CheckedChanged
        Dim i As Integer
        i = ReadFlashByte(&H10A4B)
        If Solenoid_TPS.Enabled Then
            If Solenoid_TPS.Checked Then                'If TPS>88%, i.e. RAM=3 then branch
                WriteFlashByte(&H10A8F, &H3E)           'RAM ADDR FFFF833E, low byte of RAM addr to tested
                WriteFlashByte(&H10A4A, 136)            'COMMAND CMP/EQ (if #imm=r0 then 1-->T)
                WriteFlashByte(&H10A4B, 3)              'CMP byte , byte is the value to be tested 3 = appr 85% throttle opening
                Solenoid_TPS.Text = "TPS > 85%"
            Else                                        ' ...normal function...
                WriteFlashByte(&H10A8F, &HA7)           'RAM ADDR FFFF83A7
                WriteFlashByte(&H10A4A, 200)            'COMMAND TST
                WriteFlashByte(&H10A4B, 1)              'TST byte
                Solenoid_TPS.Text = "Normal"
            End If
        End If
    End Sub

    Private Sub C_fuelconsumption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_fuelconsumption.SelectedIndexChanged
        Dim i As UInt16
        '
        i = Val(C_fuelconsumption.Text)
        'i = CInt((i - 100) / 2) + 100
        WriteFlashByte(fuelconsumption, i)
    End Sub

    Private Sub setgearmap(ByVal addr As Integer, ByVal v1 As Integer, ByVal v2 As Integer, ByVal v3 As Integer, ByVal v4 As Integer, ByVal v5 As Integer, ByVal v6 As Integer, ByVal v7 As Integer, ByVal v8 As Integer, ByVal v9 As Integer, ByVal v10 As Integer, ByVal v11 As Integer, ByVal v12 As Integer, ByVal v13 As Integer, ByVal v14 As Integer, ByVal v15 As Integer, ByVal change As Integer)
        WriteFlashByte(addr + 0, CInt(v1 * change / 100))
        WriteFlashByte(addr + 1, CInt(v2 * change / 100))
        WriteFlashByte(addr + 2, CInt(v3 * change / 100))
        WriteFlashByte(addr + 3, CInt(v4 * change / 100))
        WriteFlashByte(addr + 4, CInt(v5 * change / 100))
        WriteFlashByte(addr + 5, CInt(v6 * change / 100))
        WriteFlashByte(addr + 6, CInt(v7 * change / 100))
        WriteFlashByte(addr + 7, CInt(v8 * change / 100))
        WriteFlashByte(addr + 8, CInt(v9 * change / 100))
        WriteFlashByte(addr + 9, CInt(v10 * change / 100))
        WriteFlashByte(addr + 10, CInt(v11 * change / 100))
        WriteFlashByte(addr + 11, CInt(v12 * change / 100))
        WriteFlashByte(addr + 12, CInt(v13 * change / 100))
        WriteFlashByte(addr + 13, CInt(v14 * change / 100))
        WriteFlashByte(addr + 14, CInt(v15 * change / 100))
    End Sub
    Private Sub set_gearing(ByVal gearing As String)
        Dim change As Integer

        Select Case gearing
            Case "16/40"
                change = CInt(100 * 16 / 17 * 40 / 40)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "16/43"
                change = CInt(100 * 16 / 17 * 40 / 43)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "17/40"
                change = CInt(100 * 17 / 17 * 40 / 40)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "18/38"
                change = CInt(100 * 18 / 17 * 40 / 38)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "18/40"
                change = CInt(100 * 18 / 17 * 40 / 40)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "18/42"
                change = CInt(100 * 18 / 17 * 40 / 42)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "18/43"
                change = CInt(100 * 18 / 17 * 40 / 43)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
            Case "dynomode"
                change = 100 ' 'using flat gearing for all gears
                setgearmap(&H28A66, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28A94, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28AC2, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28AF0, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28B1E, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28B4C, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
            Case "Turbo"
                change = 105 ' 'using a flat gear map or all gears for a turbo bike, ram air does not change much between gears
                setgearmap(&H28A66, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28A94, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28AC2, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28AF0, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28B1E, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
                setgearmap(&H28B4C, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, change)
            Case "TRE 5th"
                change = CInt(100)
                setgearmap(&H28A66, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28A94, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28AC2, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28AF0, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
            Case Else
                MsgBox("ERROR: Gearing settings not found, using stock setting 17/40")
                change = CInt(100 * 17 / 17 * 40 / 40)
                setgearmap(&H28A66, 5, 9, 14, 19, 23, 28, 33, 37, 42, 47, 51, 56, 61, 65, 70, change)
                setgearmap(&H28A94, 6, 13, 19, 25, 31, 38, 44, 50, 57, 63, 69, 75, 82, 88, 94, change)
                setgearmap(&H28AC2, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120, change)
                setgearmap(&H28AF0, 9, 19, 28, 38, 47, 57, 66, 76, 85, 95, 104, 114, 123, 133, 142, change)
                setgearmap(&H28B1E, 11, 21, 32, 43, 54, 64, 75, 86, 96, 107, 118, 129, 139, 150, 161, change)
                setgearmap(&H28B4C, 12, 23, 35, 47, 58, 70, 82, 93, 105, 117, 128, 140, 152, 164, 175, change)
        End Select
    End Sub

    Private Sub C_Gearing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Gearing.SelectedIndexChanged
        set_gearing(C_Gearing.Text)
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub C_IAPTPSswitchingpoint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_IAPTPSswitchingpoint.SelectedIndexChanged
        Dim i, j As Integer

        i = Val(C_IAPTPSswitchingpoint.Text)

        'x=(((i - 55) / (256 - 55)) * 125)
        '(x*(256 - 55)/125)+55 = i


        j = (i * (256 - 55) / 125) + 55

        WriteFlashByte(&H294FC, j)

    End Sub

    Private Sub IAP_range_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IAP_range.CheckedChanged
        If IAP_range.Checked Then
            IAP_range.Text = "IAP extended"
            WriteFlashWord(&H8846, &HFF00)
        Else
            IAP_range.Text = "IAP normal"
            WriteFlashWord(&H8846, &HF852)
        End If
    End Sub

    Private Sub C_antitheft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_antitheft.CheckedChanged
        If C_antitheft.Checked Then
            C_antitheft.Text = "Lock compatible"
            WriteFlashWord(&H7650, &H9)
        Else
            C_antitheft.Text = "Lock normal"
            WriteFlashWord(&H7650, &HCB01)
        End If
    End Sub

    Private Sub C_cranking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_cranking.CheckedChanged
        If C_cranking.Checked Then
            C_cranking.Text = "Lower RPM"
            WriteFlashWord(&H28C2C, &H3C00)
        Else
            C_cranking.Text = "RPM normal"
            WriteFlashWord(&H28C2C, &H3000)
        End If

    End Sub

    Private Sub C_yoshbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_yoshbox.CheckedChanged
        If C_yoshbox.Checked Then
            C_yoshbox.Text = "Disabled"
            WriteFlashWord(&HE95A, &HE580)
            WriteFlashWord(&HE960, &HE080)
            WriteFlashWord(&HE966, &HE080)
            WriteFlashWord(&HE96E, &HE080)
            WriteFlashWord(&HDB90, &HE080)
            WriteFlashWord(&HDB98, &HE080)
            WriteFlashWord(&HDBA0, &HE080)
        Else
            C_yoshbox.Text = "Normal"
            WriteFlashWord(&HE95A, &H6540)
            WriteFlashWord(&HE960, &H8441)
            WriteFlashWord(&HE966, &H8442)
            WriteFlashWord(&HE96E, &H8443)
            WriteFlashWord(&HDB90, &H8444)
            WriteFlashWord(&HDB98, &H8445)
            WriteFlashWord(&HDBA0, &H8446)
        End If

    End Sub

    Private Sub C_dwell_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_dwell.SelectedIndexChanged
        Dim i As Integer
        Dim j As Integer
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer

        i = Val(C_dwell.Text)
        j = ReadFlashByte(&H3686E + 27)

        Select Case j
            Case 101    ' 100% map in use
                x = 100
            Case 106    ' 105% map in use
                x = 105
            Case 111    ' 110% map in use
                x = 110
            Case 121    ' 120% map in use
                x = 120
        End Select

        For y = 27 To ((9 * 18) - 1)
            z = ReadFlashByte(&H3686E + y)
            z = CInt((z * i) / x)
            WriteFlashByte(&H3686E + y, z)
        Next

        z = 0

    End Sub
End Class