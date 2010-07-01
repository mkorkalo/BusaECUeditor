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
Imports System
Imports System.IO
Imports System.Text
Imports System.Net.Mail

Public Class K8Advsettings
    Dim loading As Boolean
    Dim _stock = &H80
    Dim _300cc = &H60
    Dim _400cc = &H30
    Dim _500cc = &H20
    Dim _600cc = &H10


    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub R_Flash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_Flash.CheckedChanged
        If Not loading Then

            If R_Normal.Checked Then
                WriteFlashByte(&H553FA, &HFF)
            Else
                WriteFlashByte(&H553FA, &H0)
            End If
            R_Normal.Checked = Not R_Flash.Checked
        End If

    End Sub

    Private Sub R_Normal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_Normal.CheckedChanged
        If Not loading Then

            If R_Normal.Checked Then
                flashmode_normal()
            Else
                flashmode_fast()
            End If
        End If

        R_Flash.Checked = Not R_Normal.Checked

    End Sub

    Private Sub K8Advsettings_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
            PrintForm1.Print()
        End If


    End Sub

    Private Sub K8Advsettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loading = True

        '
        ' Check if dynomode is on or off
        '
        R_dynomode.Enabled = False
        If ReadFlashByte(&H728A9) <> &H20 Then
            R_dynomode_normal.Checked = True
            R_dynomode.Checked = False
        Else
            R_dynomode_normal.Checked = False
            R_dynomode.Checked = True
        End If

        If ReadFlashByte(&H7F004) = &HFF Then
            R_IAT_normal.Checked = True
        Else
            R_IAT_dynomode.Checked = True
        End If
        R_dynomode.Enabled = True

        '
        ' The flashmode_fast will be detected 
        '
        R_Normal.Enabled = False
        R_Flash.Enabled = False
        If ReadFlashLongWord(&H51F10) = &H53D18 Then
            '
            ' Do nothing
            '
            R_Normal.Checked = True
            R_Flash.Checked = False
            'C_ECU.Enabled = True
            'R_dynomode.Enabled = True
            'R_dynomode_normal.Enabled = True
        Else
            R_Normal.Checked = False
            R_Flash.Checked = True
            'C_ECU.Enabled = False
            'R_dynomode.Enabled = False
            'R_dynomode_normal.Enabled = False
            '
            ' Ignition MS map can be selected only when in full flash mode
            '
            If K8Ignitionmap.Visible() Then
                K8Ignitionmap.Close()
            End If
        End If
        R_Normal.Enabled = True
        R_Flash.Enabled = True

        C_ECU.Enabled = False
        C_ECU.Items.Add("EU")
        C_ECU.Items.Add("US")
        C_ECU.Items.Add("Cal")
        C_ECU.Items.Add("Gen")
        Select Case ReadFlashByte(&HFFFF6)
            Case &H30
                C_ECU.SelectedIndex = 0
            Case &H31
                C_ECU.SelectedIndex = 1
            Case &H32
                C_ECU.SelectedIndex = 2
            Case &H35
                C_ECU.SelectedIndex = 3
            Case Else
                MsgBox("ECU Type not detected, using generic")
                C_ECU.SelectedIndex = 4
        End Select

        C_secsize.Enabled = True
        C_secsize.Items.Add("Stock")
        C_secsize.Items.Add("300cc")
        C_secsize.Items.Add("400cc")
        C_secsize.Items.Add("500cc")
        C_secsize.Items.Add("600cc")
        Select Case ReadFlashByte(&H73AE0)
            Case _stock
                C_secsize.SelectedIndex = 0
            Case _300cc
                C_secsize.SelectedIndex = 1
            Case _400cc
                C_secsize.SelectedIndex = 2
            Case _500cc
                C_secsize.SelectedIndex = 3
            Case _600cc
                C_secsize.SelectedIndex = 4
            Case Else
                MsgBox("Secondary size not detected, using stock")
                C_secsize.SelectedIndex = 0
        End Select



        C_ECU.Enabled = True


        If ReadFlashByte(&H73B5D) = &H80 Then
            C_HOX.Text = "HOX sensor ON"
            C_HOX.Checked = True
        Else
            C_HOX.Text = "HOX sensor OFF"
            C_HOX.Checked = False
        End If

        If ReadFlashByte(&H51794) = &HFE Then
            C_PAIR.Text = "PAIR ON"
            C_PAIR.Checked = True
            WriteFlashByte(&H51794, &HFE)
            WriteFlashByte(&H51795, &HFF)
            WriteFlashByte(&H51796, &HFC)
            WriteFlashByte(&H51797, &HA8)
        Else
            C_PAIR.Text = "PAIR OFF"
            C_PAIR.Checked = False
            WriteFlashByte(&H51794, &H70)
            WriteFlashByte(&H51795, &H0)
            WriteFlashByte(&H51796, &H70)
            WriteFlashByte(&H51797, &H0)
        End If

        If ReadFlashByte(&H72584) = &H0 Then
            C_COV.Text = "COV ON"
            C_COV.Checked = True
        Else
            C_COV.Text = "COV OFF"
            C_COV.Checked = False
        End If


        If ReadFlashByte(&H7CAC0) = &HFF Then
            C_ICS.Text = "ICS ON"
            C_ICS.Checked = True
        Else
            C_ICS.Text = "ISC OFF"
            C_ICS.Checked = False
        End If

        If ReadFlashByte(&H72558) = &HFF Then
            C_ABCmode.Text = "ABC mode selectable"
            C_ABCmode.Checked = True
        Else
            C_ABCmode.Text = "ABC mode fixed to A"
            C_ABCmode.Checked = False
        End If


        If ReadFlashByte(&H72B00) = &H80 Then
            C_coil_fi_disable.Text = "Coil FI disabled for NLR SIM"
            C_coil_fi_disable.Checked = True
        Else
            C_coil_fi_disable.Text = "Coil FI normal"
            C_coil_fi_disable.Checked = False
            WriteFlashByte(&H72B00, &HFF)
        End If

        If ReadFlashByte(&H7D138) = 0 Then
            C_coolingfan.Checked = True
            C_coolingfan.Text = "Cooling fan FI disabled"
            WriteFlashByte(&H7D138, &H0)
        Else
            C_coolingfan.Checked = False
            C_coolingfan.Text = "Cooling fan normal"
            WriteFlashByte(&H7D138, &HFF)
        End If


        If readflashbyte(&H3E047) = 0 Then
            C_secondaries.Text = "Secondaries FI disabled"
            C_secondaries.Checked = True
            writeflashbyte(&H3E047, 0)
            writeflashbyte(&H3E26F, 0)
            writeflashbyte(&H3E497, 0)
            writeflashbyte(&H3E6BF, 0)
        Else
            C_secondaries.Text = "Secondaries FI normal"
            C_secondaries.Checked = False
            writeflashbyte(&H3E047, &HCD)
            writeflashbyte(&H3E26F, &HCD)
            writeflashbyte(&H3E497, &HCD)
            writeflashbyte(&H3E6BF, &HCD)
        End If

        '
        ' Set IAPTPS switching mode
        '
        ' Normal
        C_IAPTPS.Items.Add("Normal")
        C_IAPTPS.Items.Add("TPS only")
        C_IAPTPS.Items.Add("IAP only")
        Select Case ReadFlashByte(&H420B3)
            Case &HC
                WriteFlashByte(&H420B0, &HA1)
                WriteFlashByte(&H420B1, &H9F)
                WriteFlashByte(&H420B2, &H0)
                WriteFlashByte(&H420B3, &HC)
                C_IAPTPS.SelectedIndex = 0
            Case &HFF
                WriteFlashByte(&H420B0, &H91)
                WriteFlashByte(&H420B1, &HF0)
                WriteFlashByte(&H420B2, &H0)
                WriteFlashByte(&H420B3, &HFF)
                C_IAPTPS.SelectedIndex = 1
            Case &H0
                WriteFlashByte(&H420B0, &H91)
                WriteFlashByte(&H420B1, &HF0)
                WriteFlashByte(&H420B2, &H0)
                WriteFlashByte(&H420B3, &H0)
                C_IAPTPS.SelectedIndex = 2
        End Select

        loading = False

    End Sub

    Public Sub flashmode_normal()
        Dim b(1) As Byte
        Dim i As Long
        Dim fs As FileStream
        Dim fl(262144 * 4) As Byte
        Dim x As Long
        Dim s As String
        '
        ' change map stuctures back to normal
        '

        If Not loading Then

            ' Open the original file and read it to global variable fl
            fs = File.OpenRead(My.Application.Info.DirectoryPath & "\ecu.bin\K8.bin")
            i = 0
            Do While fs.Read(b, 0, 1) > 0
                fl(i) = b(0)
                i = i + 1
            Loop
            fs.Close()
            '
            ' change map structures all to point to original using the data from file
            '
            ' ignition maps
            For i = &H51D94 To &H51F13
                x = fl(i)
                s = Hex(ReadFlashByte(i))
                WriteFlashByte(i, fl(i))
            Next
            ' fuel IAP maps
            For i = &H52244 To &H52303
                x = fl(i)
                s = Hex(ReadFlashByte(i))
                WriteFlashByte(i, fl(i))
            Next
            ' fuel TPS maps
            For i = &H52304 To &H523C3
                x = fl(i)
                s = Hex(ReadFlashByte(i))
                WriteFlashByte(i, fl(i))
            Next
            C_ECU.Enabled = True
            'R_dynomode.Enabled = True
            'R_dynomode_normal.Enabled = True

            '
            ' Now lets copy the cylinder1 map to all maps as fastmode is ended
            '

            K8Fuelmap.selectmap(1)
            K8Fuelmap.copymaps(2)
        End If


    End Sub

    Private Sub flashmode_fast()
        Dim i As Long

        '
        ' change map structures all to point to MS0modeA
        '
        ' The flashmode_fast will be detected if &H51F10 = &H536C4 
        '
        If Not loading Then

            ' ignition maps
            For i = &H51D94 To &H51F10 Step 4
                'WriteFlashLongWord(i, &H536C4)
                WriteFlashLongWord(i, &H536D8)
            Next
            ' fuel IAP maps
            For i = &H52244 To &H52300 Step 4
                WriteFlashLongWord(i, &H5401C)
            Next
            ' fuel TPS maps
            For i = &H52304 To &H523C0 Step 4
                WriteFlashLongWord(i, &H5406C)
            Next
            C_ECU.Enabled = False
            'R_dynomode.Enabled = False
            'R_dynomode_normal.Enabled = False
        End If

    End Sub

    Private Sub C_ECU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ECU.SelectedIndexChanged
        Dim i As Integer

        If Not loading Then

            Select Case C_ECU.Text
                Case "EU"
                    WriteFlashByte(&H723D8, &H3)
                    WriteFlashByte(&H723EB, &HFF)
                    WriteFlashByte(&H72AAA, &HC)
                    WriteFlashByte(&H72AAB, &HC)
                    WriteFlashByte(&H72AAD, &HC)
                    WriteFlashByte(&H72AAE, &HC)
                    WriteFlashByte(&H7D0FF, &H30)
                    WriteFlashByte(&HFFFF6, &H30)
                    WriteFlashByte(&HFFFF7, &H30)
                    WriteFlashByte(&H7D10F, &H30)
                    WriteFlashByte(&H7D252, 0)

                Case "US"
                    WriteFlashByte(&H723D8, &H1)
                    WriteFlashByte(&H723EB, &H80)
                    WriteFlashByte(&H72AAA, &H0)
                    WriteFlashByte(&H72AAB, &H0)
                    WriteFlashByte(&H72AAD, &H0)
                    WriteFlashByte(&H72AAE, &H0)
                    WriteFlashByte(&H7D0FF, &H31)
                    WriteFlashByte(&HFFFF6, &H31)
                    WriteFlashByte(&HFFFF7, &H31)
                    WriteFlashByte(&H7D10F, &H30)
                    WriteFlashByte(&H7D252, 0)

                Case "Cal"
                    WriteFlashByte(&H723D8, &H1)
                    WriteFlashByte(&H723EB, &H80)
                    WriteFlashByte(&H72AAA, &H0)
                    WriteFlashByte(&H72AAB, &H0)
                    WriteFlashByte(&H72AAD, &H0)
                    WriteFlashByte(&H72AAE, &H0)
                    WriteFlashByte(&H7D0FF, &H32)
                    WriteFlashByte(&HFFFF6, &H32)
                    WriteFlashByte(&HFFFF7, &H30)
                    WriteFlashByte(&H7D10F, &H32)
                    WriteFlashByte(&H7D252, &HFF)

                Case "Gen" 'like US but without ign lock protection
                    WriteFlashByte(&H723D8, &H1)
                    WriteFlashByte(&H723EB, &H0)
                    WriteFlashByte(&H72AAA, &H0)
                    WriteFlashByte(&H72AAB, &H0)
                    WriteFlashByte(&H72AAD, &H0)
                    WriteFlashByte(&H72AAE, &H0)
                    WriteFlashByte(&H7D0FF, &H31)
                    WriteFlashByte(&HFFFF6, &H35)
                    WriteFlashByte(&HFFFF7, &H35)
                    WriteFlashByte(&H7D10F, &H30)
                    WriteFlashByte(&H7D252, 0)

            End Select

            '
            ' Now write the new ecu id visible on main screen and corresponding ecutype
            '
            main.ECUID.Text = ""
            Do While i < 8
                main.ECUID.Text = main.ECUID.Text & Chr(Flash(&HFFFF0 + i))
                i = i + 1
            Loop
            main.setecutype()
        End If

    End Sub

    Private Sub R_dynomode_normal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_dynomode_normal.CheckedChanged
        R_dynomode.Checked = Not R_dynomode_normal.Checked
        If Not loading Then

            If R_dynomode_normal.Checked Then
                dynomode_normal()
                B_ramairadjust.Enabled = True
            Else
                dynomode_on()
                B_ramairadjust.Enabled = False
            End If
        End If

    End Sub
    Private Sub IAT_dynomode_normal()
        WriteFlashByte(&H221EC, &HE0)
        WriteFlashByte(&H221ED, &H80)
        WriteFlashByte(&H221EE, &H43)
        WriteFlashByte(&H221EF, &H28)

        WriteFlashByte(&H22284, &HE0)
        WriteFlashByte(&H22285, &H80)
        WriteFlashByte(&H22286, &H43)
        WriteFlashByte(&H22287, &H28)

        WriteFlashByte(&H22244, &HE0)
        WriteFlashByte(&H22245, &H80)
        WriteFlashByte(&H22246, &H43)
        WriteFlashByte(&H22247, &H28)

        WriteFlashByte(&H22680, &HE0)
        WriteFlashByte(&H22681, &H80)
        WriteFlashByte(&H22682, &H43)
        WriteFlashByte(&H22683, &H28)

        WriteFlashByte(&H7F004, &HFF) ' back to original
        WriteFlashByte(&H7F005, &HFF) ' back to original

    End Sub
    Private Sub IAT_dynomode_fixed()

        WriteFlashByte(&H221EC, &HE0)
        WriteFlashByte(&H221ED, &H7)
        WriteFlashByte(&H221EE, &HF0)
        WriteFlashByte(&H221EF, &H4)

        WriteFlashByte(&H22284, &HE0)
        WriteFlashByte(&H22285, &H7)
        WriteFlashByte(&H22286, &HF0)
        WriteFlashByte(&H22287, &H4)

        WriteFlashByte(&H22244, &HE0)
        WriteFlashByte(&H22245, &H7)
        WriteFlashByte(&H22246, &HF0)
        WriteFlashByte(&H22247, &H4)

        WriteFlashByte(&H22680, &HE0)
        WriteFlashByte(&H22681, &H7)
        WriteFlashByte(&H22682, &HF0)
        WriteFlashByte(&H22683, &H4)

        WriteFlashByte(&H7F004, &H1) '+20C
        WriteFlashByte(&H7F005, &HFC) '+20C
        '
        '
        ' AND_IAT >> 2 = 7F, that means fixed value is &H1FC

    End Sub

    Private Sub dynomode_normal()
        '
        ' Set 1st gear ram air compensation to normal
        '
        WriteFlashByte(&H72859 + 0, &H5)
        WriteFlashByte(&H72859 + 1, &H9)
        WriteFlashByte(&H72859 + 2, &HE)
        WriteFlashByte(&H72859 + 3, &H12)
        WriteFlashByte(&H72859 + 4, &H17)
        WriteFlashByte(&H72859 + 5, &H1B)
        WriteFlashByte(&H72859 + 6, &H20)
        WriteFlashByte(&H72859 + 7, &H24)
        WriteFlashByte(&H72859 + 8, &H29)
        WriteFlashByte(&H72859 + 9, &H2D)
        WriteFlashByte(&H72859 + 10, &H32)
        WriteFlashByte(&H72859 + 11, &H36)
        WriteFlashByte(&H72859 + 12, &H3B)
        WriteFlashByte(&H72859 + 13, &H3F)
        WriteFlashByte(&H72859 + 14, &H44)
        WriteFlashByte(&H72859 + 15, &H48)
        WriteFlashByte(&H72859 + 16, &H4D)
        WriteFlashByte(&H72859 + 17, &H51)
        WriteFlashByte(&H72859 + 18, &H56)
        WriteFlashByte(&H72859 + 19, &H5A)
        '
        ' Set 2th gear ram air compensation to normal
        '
        WriteFlashByte(&H7286D + 0, &H6)
        WriteFlashByte(&H7286D + 1, &HC)
        WriteFlashByte(&H7286D + 2, &H12)
        WriteFlashByte(&H7286D + 3, &H18)
        WriteFlashByte(&H7286D + 4, &H1F)
        WriteFlashByte(&H7286D + 5, &H25)
        WriteFlashByte(&H7286D + 6, &H2B)
        WriteFlashByte(&H7286D + 7, &H31)
        WriteFlashByte(&H7286D + 8, &H37)
        WriteFlashByte(&H7286D + 9, &H3D)
        WriteFlashByte(&H7286D + 10, &H43)
        WriteFlashByte(&H7286D + 11, &H49)
        WriteFlashByte(&H7286D + 12, &H4F)
        WriteFlashByte(&H7286D + 13, &H55)
        WriteFlashByte(&H7286D + 14, &H5C)
        WriteFlashByte(&H7286D + 15, &H62)
        WriteFlashByte(&H7286D + 16, &H68)
        WriteFlashByte(&H7286D + 17, &H6E)
        WriteFlashByte(&H7286D + 18, &H74)
        WriteFlashByte(&H7286D + 19, &H7A)
        '
        ' Set 3th gear ram air compensation to normal
        '
        WriteFlashByte(&H72881 + 0, &H8)
        WriteFlashByte(&H72881 + 1, &HF)
        WriteFlashByte(&H72881 + 2, &H17)
        WriteFlashByte(&H72881 + 3, &H1F)
        WriteFlashByte(&H72881 + 4, &H27)
        WriteFlashByte(&H72881 + 5, &H2E)
        WriteFlashByte(&H72881 + 6, &H36)
        WriteFlashByte(&H72881 + 7, &H3E)
        WriteFlashByte(&H72881 + 8, &H46)
        WriteFlashByte(&H72881 + 9, &H4D)
        WriteFlashByte(&H72881 + 10, &H55)
        WriteFlashByte(&H72881 + 11, &H5D)
        WriteFlashByte(&H72881 + 12, &H65)
        WriteFlashByte(&H72881 + 13, &H6C)
        WriteFlashByte(&H72881 + 14, &H74)
        WriteFlashByte(&H72881 + 15, &H7C)
        WriteFlashByte(&H72881 + 16, &H84)
        WriteFlashByte(&H72881 + 17, &H8B)
        WriteFlashByte(&H72881 + 18, &H93)
        WriteFlashByte(&H72881 + 19, &H9B)
        '
        ' Set 4th gear ram air compensation to normal
        '
        WriteFlashByte(&H72895 + 0, &H9)
        WriteFlashByte(&H72895 + 1, &H12)
        WriteFlashByte(&H72895 + 2, &H1C)
        WriteFlashByte(&H72895 + 3, &H25)
        WriteFlashByte(&H72895 + 4, &H2E)
        WriteFlashByte(&H72895 + 5, &H37)
        WriteFlashByte(&H72895 + 6, &H40)
        WriteFlashByte(&H72895 + 7, &H4A)
        WriteFlashByte(&H72895 + 8, &H53)
        WriteFlashByte(&H72895 + 9, &H5C)
        WriteFlashByte(&H72895 + 10, &H65)
        WriteFlashByte(&H72895 + 11, &H6E)
        WriteFlashByte(&H72895 + 12, &H78)
        WriteFlashByte(&H72895 + 13, &H81)
        WriteFlashByte(&H72895 + 14, &H8A)
        WriteFlashByte(&H72895 + 15, &H93)
        WriteFlashByte(&H72895 + 16, &H9C)
        WriteFlashByte(&H72895 + 17, &HA6)
        WriteFlashByte(&H72895 + 18, &HAF)
        WriteFlashByte(&H72895 + 19, &HB8)
        '
        ' Set 5th gear ram air compensation to normal
        '
        WriteFlashByte(&H728A9 + 0, &HA)
        WriteFlashByte(&H728A9 + 1, &H15)
        WriteFlashByte(&H728A9 + 2, &H1F)
        WriteFlashByte(&H728A9 + 3, &H2A)
        WriteFlashByte(&H728A9 + 4, &H34)
        WriteFlashByte(&H728A9 + 5, &H3E)
        WriteFlashByte(&H728A9 + 6, &H49)
        WriteFlashByte(&H728A9 + 7, &H53)
        WriteFlashByte(&H728A9 + 8, &H5E)
        WriteFlashByte(&H728A9 + 9, &H68)
        WriteFlashByte(&H728A9 + 10, &H72)
        WriteFlashByte(&H728A9 + 11, &H7D)
        WriteFlashByte(&H728A9 + 12, &H87)
        WriteFlashByte(&H728A9 + 13, &H92)
        WriteFlashByte(&H728A9 + 14, &H9C)
        WriteFlashByte(&H728A9 + 15, &HA6)
        WriteFlashByte(&H728A9 + 16, &HB1)
        WriteFlashByte(&H728A9 + 17, &HBB)
        WriteFlashByte(&H728A9 + 18, &HC6)
        WriteFlashByte(&H728A9 + 19, &HD0)
        '
        ' Set 6th gear ram air compensation to normal
        '
        WriteFlashByte(&H728BD + 0, &HB)
        WriteFlashByte(&H728BD + 1, &H17)
        WriteFlashByte(&H728BD + 2, &H22)
        WriteFlashByte(&H728BD + 3, &H2D)
        WriteFlashByte(&H728BD + 4, &H39)
        WriteFlashByte(&H728BD + 5, &H44)
        WriteFlashByte(&H728BD + 6, &H4F)
        WriteFlashByte(&H728BD + 7, &H5B)
        WriteFlashByte(&H728BD + 8, &H66)
        WriteFlashByte(&H728BD + 9, &H71)
        WriteFlashByte(&H728BD + 10, &H7D)
        WriteFlashByte(&H728BD + 11, &H88)
        WriteFlashByte(&H728BD + 12, &H93)
        WriteFlashByte(&H728BD + 13, &H9F)
        WriteFlashByte(&H728BD + 14, &HAA)
        WriteFlashByte(&H728BD + 15, &HB5)
        WriteFlashByte(&H728BD + 16, &HC1)
        WriteFlashByte(&H728BD + 17, &HCC)
        WriteFlashByte(&H728BD + 18, &HD7)
        WriteFlashByte(&H728BD + 19, &HE3)

    End Sub
    Private Sub dynomode_on()
        Dim i As Integer
        If Not loading Then

            '
            ' Set ram air compensation to a fixed setting. 
            '

            '
            ' Gear 1
            '
            For i = &H72859 To &H7286C
                WriteFlashByte(i, &H20)
            Next
            '
            ' Gear 2
            '
            For i = &H7286D To &H72880
                WriteFlashByte(i, &H20)
            Next
            '
            ' Gear 3
            '
            For i = &H72881 To &H72894
                WriteFlashByte(i, &H20)
            Next
            '
            ' Gear 4
            '
            For i = &H72895 To &H728A8
                WriteFlashByte(i, &H20)
            Next
            '
            ' Gear 5
            '
            For i = &H728A9 To &H728BC
                WriteFlashByte(i, &H20)
            Next
            '
            ' Gear 6
            '
            For i = &H728BD To &H728D0
                WriteFlashByte(i, &H20)
            Next
        End If

    End Sub




    Private Sub R_IAT_dynomode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_IAT_dynomode.CheckedChanged
        R_IAT_normal.Checked = Not R_IAT_dynomode.Checked
        If Not loading Then

            If R_IAT_dynomode.Checked Then
                IAT_dynomode_fixed()
            Else
                IAT_dynomode_normal()
            End If
        End If
    End Sub

    Private Sub R_IAT_normal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_IAT_normal.CheckedChanged
        R_IAT_dynomode.Checked = Not R_IAT_normal.Checked
        If Not loading Then

            If R_IAT_dynomode.Checked Then
                IAT_dynomode_fixed()
                C_HOX.Checked = False
                C_PAIR.Checked = False
            Else
                IAT_dynomode_normal()
                C_HOX.Checked = True
                C_PAIR.Checked = True
            End If
        End If

    End Sub

    Private Sub B_boostfuel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_boostfuel.Click
        If (ReadFlashWord(&H55800) < 200) Or (ReadFlashByte(&H55800) = &HFF) Then
            K8boostfuel.Show()
            K8boostfuel.Select()
        Else
            MsgBox("Nitrouscontrol in use, please first deactivate it to use boostfuel")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WriteFlashByte(&H41DFD, &H10)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WriteFlashByte(&H41DFD, &HE0)
    End Sub


    Private Sub B_hexread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If T_hexaddr.Text.Contains("&H") Then
            T_hexvaluehi.Text = "&H" & Hex(Flash(Val(T_hexaddr.Text)))
        Else
            T_hexvaluehi.Text = "&H" & Hex(Flash(Val("&H" & T_hexaddr.Text)))
        End If
    End Sub



    Private Sub T_hexaddr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_hexaddr.TextChanged
        If T_hexaddr.Text.Contains("&H") Then
            T_hexvaluehi.Text = "&H" & Hex(Flash(Val(T_hexaddr.Text)))
        Else
            T_hexvaluehi.Text = "&H" & Hex(Flash(Val("&H" & T_hexaddr.Text)))
        End If
    End Sub


    Private Sub B_WRITE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_WRITE.Click
        Dim hi, addr As String

        If Not T_hexvaluehi.Text.Contains("&H") Then hi = "&H" & T_hexvaluehi.Text Else hi = T_hexvaluehi.Text
        If Not T_hexaddr.Text.Contains("&H") Then addr = "&H" & T_hexaddr.Text Else addr = T_hexaddr.Text

        WriteFlashByte(Val(addr), Val(hi))

    End Sub



    Private Sub C_HOX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_HOX.CheckedChanged
        If Not loading Then
            If C_HOX.Checked = True Then
                C_HOX.Text = "HOX sensor ON"
                WriteFlashByte(&H73B5D, &H80)
                WriteFlashByte(&H7CA17, &HFF)
            Else
                C_HOX.Text = "HOX sensor OFF"
                WriteFlashByte(&H73B5D, &H0)
                WriteFlashByte(&H7CA17, &H80)
            End If
        End If

    End Sub

    Private Sub C_secsize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_secsize.SelectedIndexChanged
        If Not loading Then
            Select Case C_secsize.Text
                Case "Stock"
                    WriteFlashByte(&H73AE0, _stock)
                Case "300cc"
                    WriteFlashByte(&H73AE0, _300cc)
                Case "400cc"
                    WriteFlashByte(&H73AE0, _400cc)
                Case "500cc"
                    WriteFlashByte(&H73AE0, _500cc)
                Case "600cc"
                    WriteFlashByte(&H73AE0, _600cc)
                Case Else
                    MsgBox("Size not defined, using stock size")
                    WriteFlashByte(&H73AE0, _stock)
            End Select
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_COV.CheckedChanged
        If Not loading Then
            If C_COV.Checked = True Then
                C_COV.Text = "COV ON"
                WriteFlashByte(&H72584, &H0)
            Else
                C_COV.Text = "COV OFF"
                WriteFlashByte(&H72584, &HFF)
            End If
        End If

    End Sub

    Private Sub C_PAIR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_PAIR.CheckedChanged
        If Not loading Then
            If C_PAIR.Checked = True Then
                C_PAIR.Text = "PAIR ON"
                WriteFlashByte(&H51794, &HFE) ' jump to set pair port subroutine
                WriteFlashByte(&H51795, &HFF)
                WriteFlashByte(&H51796, &HFC)
                WriteFlashByte(&H51797, &HA8)
                WriteFlashByte(&H7D24C, &HFF) ' pair config flag
            Else
                C_PAIR.Text = "PAIR OFF"
                WriteFlashByte(&H51794, &H70)
                WriteFlashByte(&H51795, &H0)
                WriteFlashByte(&H51796, &H70)
                WriteFlashByte(&H51797, &H0)
                WriteFlashByte(&H7D24C, &H80)
            End If
        End If

    End Sub

    Private Sub GroupBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        K8STPmap.Show()
        K8STPmap.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (ReadFlashWord(&H55800) >= 200) Then
            K8nitrouscontrol.Show()
            K8nitrouscontrol.Select()
        Else
            MsgBox("Boostfuel in use, please first deactivate it to use nitrouscontrol")
        End If
    End Sub

    Private Sub B_ramairadjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ramairadjust.Click
        K8ramair.Show()
        K8ramair.Select()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        K8injectorbalancemap.Show()
        K8injectorbalancemap.Select()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ICS.CheckedChanged
        If Not loading Then
            If C_ICS.Checked = True Then
                C_ICS.Text = "ICS ON"
                WriteFlashByte(&H7CAC0, &HFF) 'error code disable
                WriteFlashByte(&H7CADC, &HFF) 'rpm window error disable
            Else
                C_ICS.Text = "ISC OFF"
                WriteFlashByte(&H7CAC0, &H0) 'error code disable
                WriteFlashByte(&H7CADC, &H0) 'rpm window error disable
            End If
        End If


    End Sub

    Private Sub C_ABCmode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ABCmode.CheckedChanged
        If Not loading Then
            If C_ABCmode.Checked = True Then
                C_ABCmode.Text = "ABC mode selectable"
                WriteFlashByte(&H72558, &HFF)
                ' enable DSM1 and enable ABC
                WriteFlashByte(&H1D9E7, &H2) 'dsm1
                WriteFlashByte(&H1DCD7, &H2) 'dsm1
                WriteFlashByte(&H1DA5B, &H1) 'dsm2
                WriteFlashByte(&H1DCEF, &H1) 'dsm2
            Else
                C_ABCmode.Text = "ABC mode fixed to A"
                WriteFlashByte(&H72558, &H0)
                ' disable DSM
                WriteFlashByte(&H1D9E7, &HFF) 'dsm1
                WriteFlashByte(&H1DCD7, &HFF) 'dsm1
                WriteFlashByte(&H1DA5B, &HFF) 'dsm2
                WriteFlashByte(&H1DCEF, &HFF) 'dsm2

            End If
        End If


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        K8dwellignition.Show()
        K8dwellignition.Select()
    End Sub

    Private Sub C_coil_fi_disable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_coil_fi_disable.CheckedChanged
        If Not loading Then
            If C_coil_fi_disable.Checked = True Then
                C_coil_fi_disable.Text = "Coil FI disabled for NLR SIM"
                WriteFlashByte(&H72B00, &H80)
            Else
                C_coil_fi_disable.Text = "Coil FI normal"
                WriteFlashByte(&H72B00, &HFF)
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_coolingfan.CheckedChanged
        If Not loading Then
            If C_coolingfan.Checked = True Then
                C_coolingfan.Text = "Cooling fan FI disabled"
                WriteFlashByte(&H7D138, &H0)
            Else
                C_coolingfan.Text = "Cooling fan normal"
                WriteFlashByte(&H7D138, &HFF)
            End If
        End If

    End Sub

    Private Sub C_secondaries_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_secondaries.CheckedChanged
        If Not loading Then

            If C_secondaries.Checked Then
                C_secondaries.Text = "Secondaries FI disabled"
                writeflashbyte(&H3E047, 0)
                writeflashbyte(&H3E26F, 0)
                writeflashbyte(&H3E497, 0)
                writeflashbyte(&H3E6BF, 0)
            Else
                C_secondaries.Text = "Secondaries FI normal"
                writeflashbyte(&H3E047, &HCD)
                writeflashbyte(&H3E26F, &HCD)
                writeflashbyte(&H3E497, &HCD)
                writeflashbyte(&H3E6BF, &HCD)
            End If
        End If

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_IAPTPS.SelectedIndexChanged

        If Not loading Then

            Select Case C_IAPTPS.Text
                Case "Normal"
                    WriteFlashByte(&H420B0, &HA1)
                    WriteFlashByte(&H420B1, &H9F)
                    WriteFlashByte(&H420B2, &H0)
                    WriteFlashByte(&H420B3, &HC)
                    'C_IAPTPS.SelectedIndex = 0
                Case "TPS only"
                    WriteFlashByte(&H420B0, &H91)
                    WriteFlashByte(&H420B1, &HF0)
                    WriteFlashByte(&H420B2, &H0)
                    WriteFlashByte(&H420B3, &HFF)
                    'C_IAPTPS.SelectedIndex = 1
                Case "IAP only"
                    WriteFlashByte(&H420B0, &H91)
                    WriteFlashByte(&H420B1, &HF0)
                    WriteFlashByte(&H420B2, &H0)
                    WriteFlashByte(&H420B3, &H0)
                    'C_IAPTPS.SelectedIndex = 2
            End Select

        End If


    End Sub
End Class
