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

Imports System.Windows.Forms
Imports System.IO

Public Class K8nitrouscontrol
    Dim ADJ As Integer = &H55800 '&HFF if nitrouscontrol inactive, no code present else nitrouscontrol active
    Dim nitrouscontrolCODE As Integer = &H55A00
    Dim IDTAG As Integer = &H55800
    Dim nitrouscontrolVERSION As Integer = 209
    Dim nitrouscontrolcodelenght As Integer = &H1000 'lenght of the nitrouscontrol code in bytes for clearing the memory
    Dim tableaddress As Integer = &H559A0

    Dim rowheading_map As Integer = &H55854
    Dim columnheading_map As Integer = &H55844
    Dim editing_map As Integer = &H55874 '&H55854
    Dim change As Integer = 1
    Dim rr, cc As Integer
    Dim fuelconv As Decimal = 1
    Dim loading As Boolean = True
    Dim dcounter As Integer = 250





    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (readflashbyte(ADJ) <> &HFF) Then
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_nitrouscontrol_activation.CheckedChanged, C_nitrouscontrol_activation.CheckedChanged
        If C_nitrouscontrol_activation.Checked Then
            C_nitrouscontrol_activation.Text = "Code active"
            D_fuel_nitrouscontrol.Visible = True
            G_gencontrol.Visible = True
            If (readflashbyte(ADJ) = &HFF) Then
                modify_original_ECU_code(True)
                nitrouscontrol_code_in_memory(True, nitrouscontrolcodelenght)
            End If
        Else
            C_nitrouscontrol_activation.Text = "Code not active"
            modify_original_ECU_code(False)
            nitrouscontrol_code_in_memory(False, nitrouscontrolcodelenght)
            D_fuel_nitrouscontrol.Visible = False
            G_gencontrol.Visible = False
        End If
    End Sub

    Private Sub K8nitrouscontrol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case "p"
                printthis()
            Case "P"
                printthis()
            Case "*"
                MultiplySelectedCells()
            Case "/"
                DivideSelectedCells()
            Case "+"
                IncreaseSelectedCells()
            Case "-"
                DecreaseSelectedCells()
            Case Chr(27)
                Me.Close()
        End Select
        writemaptoflash()

    End Sub

    Private Sub printthis()
        PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
        PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
        PrintForm1.Print()
    End Sub

    Private Sub nitrouscontrol_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        D_fuel_nitrouscontrol.Visible = False
        G_gencontrol.Visible = False
        R_nitrous_on.Visible = False
        L_solenoid_status.Visible = False

        K8Advsettings.C_PAIR.Checked = False

        L_nitrouscontrolver.Text = Str(nitrouscontrolVERSION)

        If (readflashbyte(ADJ) = &HFF) Then
            C_nitrouscontrol_activation.Checked = False
        Else
            C_nitrouscontrol_activation.Checked = True
            'nitrouscontrol_code_in_memory(True, nitrouscontrolcodelenght)

            If (readflashword(IDTAG) <> nitrouscontrolVERSION) Then
                MsgBox("nitrouscontrol code incompatible with this version, please reactivate the nitrouscontrol on this map")
                C_nitrouscontrol_activation.Checked = False
            End If

        End If
        If C_nitrouscontrol_activation.Checked Then
            generate_general_settings()
            generate_nitrouscontrol_table()
        End If
    End Sub
    Private Sub generate_general_settings()
        Dim i As Integer
        C_RPM_LOW.Items.Clear()
        C_RPM_LOW.Items.Add(Str(CInt(readflashword(&H55802) / 2.56)))
        For i = 5000 To 12500 Step 100
            C_RPM_LOW.Items.Add(Str(i))
        Next
        C_RPM_LOW.SelectedIndex = 0
        C_RPM_HIGH.Items.Clear()
        C_RPM_HIGH.Items.Add(Str(CInt(readflashword(&H55804) / 2.56)))
        For i = 6000 To 12500 Step 100
            C_RPM_HIGH.Items.Add(Str(i))
        Next
        C_RPM_HIGH.SelectedIndex = 0
        C_RUNHZ.Items.Clear()
        C_RUNHZ.Items.Add(Str(CInt(dcounter / readflashword(&H5580A))))
        For i = 5 To 15 Step 1
            C_RUNHZ.Items.Add(Str(i))
        Next
        C_RUNHZ.SelectedIndex = 0
        L_TPS.Text = CInt(100 * readflashword(&H55806) / &H370)
        
        If readflashbyte(&H5580E) = &HFF Then
            C_wetkit.Checked = True
            C_wetkit.Text = "Emulation ON"
        Else
            C_wetkit.Checked = False
            C_wetkit.Text = "Emulation OFF"
        End If
        If readflashbyte(&H5580F) <> &H0 Then
            C_buttonactive.Text = "RPM/TPS/Button"
            C_buttonactive.Checked = True
        Else
            C_buttonactive.Text = "RPM only"
            C_buttonactive.Checked = False
        End If
        If readflashbyte(&H55810) = &H1 Then
            C_DSMSELECTED.Text = "Lower"
            C_DSMSELECTED.Checked = False
        Else
            C_DSMSELECTED.Text = "Upper"
            C_DSMSELECTED.Checked = True
        End If


        loading = False
    End Sub
    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        Dim pcdisp, blk As Integer

        If method Then
            '
            ' Lets activate a branch to nitrouscontrol code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the nitrouscontrol code
            ' as part of each main loop
            '
            ' AD_conversion loop no jump to separate code
            pcdisp = (nitrouscontrolCODE - &H41D8) / 4
            blk = 0
            If pcdisp > &HFFFF Then
                blk = Int(pcdisp / &H10000)
                pcdisp = pcdisp And &HFFFF
            End If
            writeflashbyte(&H41D8, &HFE)
            writeflashbyte(&H41D9, blk)
            writeflashword(&H41DA, pcdisp)
            'cylinder 1 
            writeflashword(&H41408, &H6400) ' ldi R4, 0
            writeflashword(&H413E2, &H6818)
            writeflashword(&H41460, &H4400) ' + 0
            writeflashword(&H41462, &H5446) ' << 5
            'cylinder 2 
            writeflashword(&H414D8, &H6400)
            writeflashword(&H414B2, &H6818)
            writeflashword(&H41530, &H4400) ' + 0
            writeflashword(&H41532, &H5446) ' << 5
            'cylinder 3 
            writeflashword(&H415A8, &H6400)
            writeflashword(&H41582, &H6818)
            writeflashword(&H41600, &H4400) ' + 0
            writeflashword(&H41602, &H5446) ' << 5
            'cylinder 4 
            writeflashword(&H41678, &H6400)
            writeflashword(&H41652, &H6818)
            writeflashword(&H416D0, &H4400) ' + 0
            writeflashword(&H416D2, &H5446) ' << 5
            ' disable DSM1 and set fixed mode A
            writeflashbyte(&H1D9E7, &HFF) 'dsm1
            writeflashbyte(&H1DCD7, &HFF) 'dsm1
            writeflashbyte(&H1DA5B, &HFF) 'dsm2
            writeflashbyte(&H1DCEF, &HFF) 'dsm2

            D_fuel_nitrouscontrol.Visible = True
            ' set ignition retard to read the nitrouscontrol module variable
            writeflashbyte(&H33C22, &H68)
            writeflashbyte(&H33C23, &H56)

            K8Advsettings.C_ABCmode.Checked = False


        Else
            '
            ' bring the ecu code back to original
            '
            ' AD_conversion loop no jump to separate code
            writeflashword(&H41D8, &HFE00)
            writeflashword(&H41DA, &HBAC9)
            'cylinder 1 
            writeflashword(&H41408, &H4400)
            writeflashword(&H413E2, &H652A)
            writeflashword(&H41460, &H4480)
            writeflashword(&H41462, &H5442)
            'cylinder 2 
            writeflashword(&H414D8, &H4400)
            writeflashword(&H414B2, &H652B)
            writeflashword(&H41530, &H4480)
            writeflashword(&H41532, &H5442)
            'cylinder 3 
            writeflashword(&H415A8, &H4400)
            writeflashword(&H41582, &H652C)
            writeflashword(&H41600, &H4480)
            writeflashword(&H41602, &H5442)
            'cylinder 4 
            writeflashword(&H41678, &H4400)
            writeflashword(&H41652, &H652D)
            writeflashword(&H416D0, &H4480)
            writeflashword(&H416D2, &H5442)
            ' enable DSM1 and enable ABC
            writeflashbyte(&H1D9E7, &H2) 'dsm1
            writeflashbyte(&H1DCD7, &H2) 'dsm1
            writeflashbyte(&H1DA5B, &H1) 'dsm2
            writeflashbyte(&H1DCEF, &H1) 'dsm2
            D_fuel_nitrouscontrol.Visible = False
            ' set ignition retard to read the stock variable
            writeflashbyte(&H33C22, &H63)
            writeflashbyte(&H33C23, &HA2)

        End If
    End Sub
    Private Sub nitrouscontrol_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\nitrouscontrol.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("nitrouscontrol code not found at: " & path, MsgBoxStyle.Critical)
            C_nitrouscontrol_activation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the nitrouscontrol code into memory address from the .bin file
            '
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                writeflashbyte(i + ADJ, b(0))
                i = i + 1
            Loop
            fs.Close()

            i = readflashword(IDTAG)

            If readflashword(IDTAG) <> nitrouscontrolVERSION Then
                MsgBox("This nitrouscontrol code is not compatible with this ECUeditor version !!!")
                For i = 0 To lenght
                    writeflashbyte(i + ADJ, &HFF)
                Next
                Me.Close()
            End If
            generate_general_settings()
            generate_nitrouscontrol_table()
        Else
            ' reset the nitrouscontrol code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                writeflashbyte(i + ADJ, &HFF)
            Next
        End If
    End Sub



    Private Sub B_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintForm1.Print()
    End Sub


    Private Sub generate_nitrouscontrol_table()
        Dim c, r, i As Integer

        '
        ' Generate column headings
        '
        D_fuel_nitrouscontrol.ColumnCount = 6
        c = 0
        Do While c < D_fuel_nitrouscontrol.ColumnCount
            D_fuel_nitrouscontrol.Columns.Item(c).HeaderText = "Gear" & Str(c + 1)
            D_fuel_nitrouscontrol.Columns.Item(c).Width = 40
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        D_fuel_nitrouscontrol.RowCount = 4

        D_fuel_nitrouscontrol.RowHeadersWidth = 120
        For i = 1 To D_fuel_nitrouscontrol.RowCount
            Select Case i
                Case 1
                    D_fuel_nitrouscontrol.Rows.Item(i - 1).HeaderCell.Value = "Nitrous duty %"
                Case 2
                    D_fuel_nitrouscontrol.Rows.Item(i - 1).HeaderCell.Value = "Fuel add %"
                Case 3
                    D_fuel_nitrouscontrol.Rows.Item(i - 1).HeaderCell.Value = "Ign retard deg"
                Case 4
                    D_fuel_nitrouscontrol.Rows.Item(i - 1).HeaderCell.Value = "Ramp up ms"
            End Select


        Next



        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_fuel_nitrouscontrol.RowCount)

            Select Case r + 1
                Case 1 ' case as is duty cycle
                    D_fuel_nitrouscontrol.Item(c, r).Value = readflashword((i * 2) + tableaddress)
                Case 2 ' fuel map
                    D_fuel_nitrouscontrol.Item(c, r).Value = Int(readflashword((i * 2) + tableaddress) / fuelconv)
                Case 3 ' ignition retard map
                    D_fuel_nitrouscontrol.Item(c, r).Value = Int(readflashword((i * 2) + tableaddress) * 0.4)
                Case 4 ' rampuptime
                    D_fuel_nitrouscontrol.Item(c, r).Value = readflashword((i * 2) + tableaddress)
            End Select

            If c < D_fuel_nitrouscontrol.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_fuel_nitrouscontrol.SelectedCells.Count()

        Do While (r < D_fuel_nitrouscontrol.RowCount)
            Select Case r + 1
                Case 4
                    decrease = 100
                Case Else
                    decrease = 1
            End Select

            If D_fuel_nitrouscontrol.Item(c, r).Selected And n > 0 Then
                D_fuel_nitrouscontrol.Item(c, r).Value = D_fuel_nitrouscontrol.Item(c, r).Value - decrease
                n = n - 1
            End If

            If c < D_fuel_nitrouscontrol.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop
    End Sub

    Private Sub DivideSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_fuel_nitrouscontrol.SelectedCells.Count()

        Do While (r < D_fuel_nitrouscontrol.RowCount)

            If D_fuel_nitrouscontrol.Item(c, r).Selected And n > 0 Then
                D_fuel_nitrouscontrol.Item(c, r).Value = Int(D_fuel_nitrouscontrol.Item(c, r).Value / 1.05)
                n = n - 1
            End If

            If c < D_fuel_nitrouscontrol.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop
    End Sub
    Private Sub MultiplySelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_fuel_nitrouscontrol.SelectedCells.Count()

        Do While (r < D_fuel_nitrouscontrol.RowCount)

            If D_fuel_nitrouscontrol.Item(c, r).Selected And n > 0 Then
                D_fuel_nitrouscontrol.Item(c, r).Value = Int(D_fuel_nitrouscontrol.Item(c, r).Value * 1.05)
                n = n - 1
            End If

            If c < D_fuel_nitrouscontrol.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop
    End Sub

    Private Sub IncreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim increase As Integer

        increase = change ' this is the value how much the cell is increased when pressing "+"
        i = 0
        r = 0
        c = 0


        n = D_fuel_nitrouscontrol.SelectedCells.Count()

        Do While (r < D_fuel_nitrouscontrol.RowCount) And n > 0

            Select Case r + 1
                Case 4
                    increase = 100
                Case Else
                    increase = 1
            End Select

            If D_fuel_nitrouscontrol.Item(c, r).Selected And n > 0 Then
                D_fuel_nitrouscontrol.Item(c, r).Value = D_fuel_nitrouscontrol.Item(c, r).Value + increase
                n = n - 1
            End If

            If c < D_fuel_nitrouscontrol.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Public Sub tracemap()
        R_nitrous_on.Visible = True
        L_solenoid_status.Visible = True
        If DSM1 Then
            R_nitrous_on.Checked = True
        Else
            R_nitrous_on.Checked = False
        End If
    End Sub


    Private Sub writemaptoflash()
        Dim r, c, i As Integer
        '
        ' Copy grid contents to the bin
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_fuel_nitrouscontrol.RowCount)
            Select Case r + 1
                Case 1 ' as it is duty cycles
                    If D_fuel_nitrouscontrol.Item(c, r).Value < 0 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 0
                        MsgBox("Min value exceeded, using min value")
                    End If
                    If D_fuel_nitrouscontrol.Item(c, r).Value > 100 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 100
                        MsgBox("Max value exceeded, using max value")
                    End If
                    writeflashword((i * 2) + tableaddress, (D_fuel_nitrouscontrol.Item(c, r).Value))
                Case 2
                    If D_fuel_nitrouscontrol.Item(c, r).Value < 0 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 0
                        MsgBox("Min value exceeded, using min value")
                    End If
                    If D_fuel_nitrouscontrol.Item(c, r).Value > 100 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 100
                        MsgBox("Max value exceeded, using max value")
                    End If
                    writeflashword((i * 2) + tableaddress, (D_fuel_nitrouscontrol.Item(c, r).Value * fuelconv))
                Case 3 ' / ign retard in degrees, the module handles conversion with 0.4
                    If D_fuel_nitrouscontrol.Item(c, r).Value < 0 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 0
                        MsgBox("Min value exceeded, using min value")
                    End If
                    If D_fuel_nitrouscontrol.Item(c, r).Value > 20 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 20
                        MsgBox("Max value exceeded, using max value")
                    End If
                    writeflashword((i * 2) + tableaddress, (D_fuel_nitrouscontrol.Item(c, r).Value / 0.4))
                Case 4 ' as it is rampuptime
                    If D_fuel_nitrouscontrol.Item(c, r).Value < 0 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 0
                        MsgBox("Min value exceeded, using min value")
                    End If
                    If D_fuel_nitrouscontrol.Item(c, r).Value > 8000 Then
                        D_fuel_nitrouscontrol.Item(c, r).Value = 8000
                        MsgBox("Max value exceeded, using max value")
                    End If
                    writeflashword((i * 2) + tableaddress, (D_fuel_nitrouscontrol.Item(c, r).Value))
                Case Else
                    MsgBox("Error in writing nitrous controller map values")
            End Select
            If c < D_fuel_nitrouscontrol.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    
    Private Sub C_RPM_LOW_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_RPM_LOW.SelectedIndexChanged
        If Not loading Then
            writeflashword(&H55802, CInt(Val(C_RPM_LOW.Text) * 2.56))
        End If
    End Sub

    Private Sub C_RPM_HIGH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_RPM_HIGH.SelectedIndexChanged
        If Not loading Then
            writeflashword(&H55804, CInt(Val(C_RPM_HIGH.Text) * 2.56))
        End If
    End Sub

    Private Sub C_RUNHZ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_RUNHZ.SelectedIndexChanged
        If Not loading Then
            writeflashword(&H5580A, CInt(dcounter / Val(C_RUNHZ.Text)))
        End If
    End Sub

    Private Sub Linklabel_program_homepage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Linklabel_program_homepage.LinkClicked
        System.Diagnostics.Process.Start("http://www.ecueditor.com")
    End Sub

    Private Sub C_wetkit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_wetkit.CheckedChanged
        If Not loading Then
            If C_wetkit.Checked Then
                C_wetkit.Text = "Emulation on"
                writeflashbyte(&H5580E, &HFF)
            Else
                C_wetkit.Text = "Emulation off"
                writeflashbyte(&H5580E, &H0)
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_buttonactive.CheckedChanged
        If Not loading Then
            If C_buttonactive.Checked Then
                C_buttonactive.Text = "RPM/TPS/Button"
                writeflashbyte(&H5580F, &HFF)
            Else
                C_buttonactive.Text = "RPM/TPS only"
                writeflashbyte(&H5580F, &H0)
            End If
        End If

    End Sub

    Private Sub C_DSMSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_DSMSELECTED.CheckedChanged
        If Not loading Then
            If Not C_DSMSELECTED.Checked Then
                C_DSMSELECTED.Text = "Lower"
                writeflashbyte(&H55810, &H1)
            Else
                C_DSMSELECTED.Text = "Upper"
                writeflashbyte(&H55810, &H2)
            End If
        End If

    End Sub
End Class
