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

Imports System.Windows.Forms
Imports System.IO
Imports System.Math

Public Class K8BoostFuelExtended
    Public ADJ As Integer = &H55800 '&HFF if boostfuel inactive, no code present else boostfuel active
    Dim BOOSTFUELCODE As Integer = &H55D00
    Dim IDTAG As Integer = &H55800
    Dim BOOSTFUELVERSION As Integer = 113
    Dim boostfuelcodelenght As Integer = &H1000 'length of the boostfuel code in bytes for clearing the memory

    Dim rowheading_map As Integer = &H5585C
    Dim columnheading_map As Integer = &H55844
    Dim editing_map As Integer = &H5588C

    Dim ignitionretard_columns As Integer = &H55ADC
    Dim ignitionretard_map As Integer = &H55AF4

    Dim loading As Boolean = True

    Dim change As Integer = 1
    Dim rr, cc As Integer
    Dim KPA_PSI As Double = 6.8947572931683609

    Private Sub boostfuel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer

        D_BoostIgnitionRetard.RowCount = 1
        D_BoostIgnitionRetard.ColumnCount = 24

        D_BoostIgnitionRetard(0, 0).Value = 12

        L_boostfuelver.Text = Str(BOOSTFUELVERSION)
        loading = True

        If (ReadFlashByte(ADJ) = &HFF) Then
            C_BoostfuelActivation.Checked = False
            hide_boostfuel_settings()
        Else
            i = ReadFlashWord(IDTAG)

            If i = 112 Then
                LoadPreviousMap()
                i = BOOSTFUELVERSION
                MsgBox("Your Boost Fuel Map is from the previous version of this module and has been upgraded, please check values in the boost fuel map", MsgBoxStyle.Information, Nothing)
            End If

            If (i <> BOOSTFUELVERSION) Then
                MsgBox("boostfuel code incompatible with this version, please reactivate the boostfuel on this map " & Str(ReadFlashWord(IDTAG)))
                C_BoostfuelActivation.Checked = False
                hide_boostfuel_settings()
            Else
                C_BoostfuelActivation.Checked = True
                B_ApplySensorValues.Enabled = True
                read_boostfuel_settings()
                generate_map_table()
            End If

            If Metric Then
                G_boosttable.Text = "% add per each RPM/kPa range"
            Else
                G_boosttable.Text = "% add per each RPM/PSi range"
            End If

            loading = False

        End If

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (ReadFlashByte(ADJ) <> &HFF) Then
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub C_BoostfuelActivation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_BoostfuelActivation.CheckedChanged, C_BoostfuelActivation.CheckedChanged
        If C_BoostfuelActivation.Checked Then

            B_ApplySensorValues.Enabled = True
            C_BoostfuelActivation.Text = "Code active"

            If (ReadFlashByte(ADJ) = &HFF) Then
                modify_original_ECU_code(True)
                boostfuel_code_in_memory(True, boostfuelcodelenght)
                generate_map_table()
            End If

            read_boostfuel_settings()
        Else
            B_ApplySensorValues.Enabled = False
            C_BoostfuelActivation.Text = "Code not active"
            modify_original_ECU_code(False)
            boostfuel_code_in_memory(False, boostfuelcodelenght)
            hide_boostfuel_settings()
        End If
    End Sub

    Private Sub K8boostfuel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            printthis()
        End If

    End Sub

    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        Dim pcdisp, blk As Integer

        If method Then
            '
            ' Lets activate a branch to boostfuel code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the boostfuel code
            ' as part of each main loop
            '
            ' GAUGEDATA BITFLAG FOR BLINKING LIGHT
            WriteFlashWord(&H4E122, &H6828) 'let the gaugedata read the copy of the variable

            ' KWP protocol to be able to read boost and COV1
            WriteFlashWord(&H525C8, &H80)
            WriteFlashWord(&H525CA, &H6824) 'RAW pressure voltage from AD converter
            WriteFlashWord(&H525CC, &H80)
            WriteFlashWord(&H525CE, &H681A) 'EMULATED IAP after GM3 bar map conversion

            ' AD_conversion loop 
            WriteFlashWord(&H4112, &H682A) 'ECU AD converter value

            pcdisp = (BOOSTFUELCODE - &H41D8) / 4
            blk = 0

            If pcdisp > &HFFFF Then
                blk = Int(pcdisp / &H10000)
                pcdisp = pcdisp And &HFFFF
            End If

            'Branch to Boost Fuel Code
            WriteFlashByte(&H41D8, &HFE)
            WriteFlashByte(&H41D9, blk)
            WriteFlashWord(&H41DA, pcdisp)

            'cylinder 1 
            WriteFlashWord(&H41408, &H6400) ' ldi R4, 0
            WriteFlashWord(&H413E2, &H6818)
            WriteFlashWord(&H41460, &H4400) ' + 0
            WriteFlashWord(&H41462, &H5446) ' << 5
            'cylinder 2 
            WriteFlashWord(&H414D8, &H6400)
            WriteFlashWord(&H414B2, &H6818)
            WriteFlashWord(&H41530, &H4400) ' + 0
            WriteFlashWord(&H41532, &H5446) ' << 5
            'cylinder 3 
            WriteFlashWord(&H415A8, &H6400)
            WriteFlashWord(&H41582, &H6818)
            WriteFlashWord(&H41600, &H4400) ' + 0
            WriteFlashWord(&H41602, &H5446) ' << 5
            'cylinder 4 
            WriteFlashWord(&H41678, &H6400)
            WriteFlashWord(&H41652, &H6818)
            WriteFlashWord(&H416D0, &H4400) ' + 0
            WriteFlashWord(&H416D2, &H5446) ' << 5

            ' set ignition retard to read the nitrouscontrol module variable
            WriteFlashByte(&H33C22, &H68)
            WriteFlashByte(&H33C23, &H56)

            K8Advsettings.C_ABCmode.Checked = False

        Else
            ' bring the ecu code back to original

            ' GAUGEDATA BITFLAG
            WriteFlashWord(&H4E122, &H6874)

            ' KWP protocol to be able to read boost
            WriteFlashWord(&H525C8, &H7)
            WriteFlashWord(&H525CA, &HD11B)
            WriteFlashWord(&H525CC, &H7)
            WriteFlashWord(&H525CE, &HD11B)
            
            ' AD_conversion loop no jump to separate code
            WriteFlashWord(&H41D8, &HFE00)
            WriteFlashWord(&H41DA, &HBAC9)
            WriteFlashWord(&H4112, &H42F0) 'ECU AD converter value

            'cylinder 1 
            WriteFlashWord(&H41408, &H4400)
            WriteFlashWord(&H413E2, &H652A)
            WriteFlashWord(&H41460, &H4480)
            WriteFlashWord(&H41462, &H5442)

            'cylinder 2 
            WriteFlashWord(&H414D8, &H4400)
            WriteFlashWord(&H414B2, &H652B)
            WriteFlashWord(&H41530, &H4480)
            WriteFlashWord(&H41532, &H5442)

            'cylinder 3 
            WriteFlashWord(&H415A8, &H4400)
            WriteFlashWord(&H41582, &H652C)
            WriteFlashWord(&H41600, &H4480)
            WriteFlashWord(&H41602, &H5442)

            'cylinder 4 
            WriteFlashWord(&H41678, &H4400)
            WriteFlashWord(&H41652, &H652D)
            WriteFlashWord(&H416D0, &H4480)
            WriteFlashWord(&H416D2, &H5442)

            ' set ignition retard to read the stock variable
            WriteFlashByte(&H33C22, &H63)
            WriteFlashByte(&H33C23, &HA2)

        End If
    End Sub

    Private Sub boostfuel_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\BoostFuelExtended.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("boostfuel code not found at: " & path, MsgBoxStyle.Critical)
            C_BoostfuelActivation.Checked = False
        End If


        If method And File.Exists(path) Then

            ' write the boostfuel code into memory address from the .bin file
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                WriteFlashByte(i + ADJ, b(0))
                i = i + 1
            Loop
            fs.Close()

            If ReadFlashWord(IDTAG) <> BOOSTFUELVERSION Then
                MsgBox("This boostfuel code is not compatible with this ECUeditor version !!!")
                For i = 0 To lenght
                    WriteFlashByte(i + ADJ, &HFF)
                Next
                Me.Close()
            End If
        Else
            ' reset the boostfuel code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                WriteFlashByte(i + ADJ, &HFF)
            Next
        End If
    End Sub

    Private Sub read_boostfuel_settings()

        If ReadFlashByte(&H55C39) = &H0 Then
            C_fueladd.Text = "+ to TPS"
            C_fueladd.Checked = True
        Else
            C_fueladd.Text = "% of TPS"
            C_fueladd.Checked = False
        End If

        G_BoostIgnitionRetard.Visible = True
        D_BoostFuel.Visible = True
        C_solenoidcontrol.Visible = True
        solenoidcontrol_visible()

    End Sub

    Private Sub hide_boostfuel_settings()
        D_BoostFuel.Visible = False
        C_solenoidcontrol.Visible = False
        G_BoostIgnitionRetard.Visible = False
        solenoidcontrol_visible()
    End Sub

    Private Sub solenoidcontrol_visible()

        If ReadFlashByte(&H55C3A) = &H0 Then 'Dutyactive
            D_solenoidcontrol.Visible = True
            C_solenoidcontrol.Checked = True
        Else
            D_solenoidcontrol.Visible = False
            C_solenoidcontrol.Checked = False
        End If

        If ReadFlashByte(&H55C3B) = &H0 Then 'Solenoidtype
            C_bleed.Checked = True
            C_bleed.Text = "Normally Open"
        Else
            C_bleed.Checked = False
            C_bleed.Text = "Normally Closed"
        End If
    End Sub

    Private Sub LoadPreviousMap()

        Dim previousColumns(16) As Integer
        Dim previousMap(16, 16) As Integer
        Dim previousColumnHeadingMap As Integer = &H55844
        Dim previousEditingMap As Integer = &H55874 '&H55854

        For column As Integer = 0 To 15

            previousColumns(column) = ReadFlashByte(previousColumnHeadingMap + column)

            For row As Integer = 0 To 15

                previousMap(column, row) = ReadFlashByte(previousEditingMap + row * 16 + column)

            Next
        Next

        modify_original_ECU_code(True)
        boostfuel_code_in_memory(True, boostfuelcodelenght)

        C_SensorType.SelectedIndex = 0
        C_SensorType_SelectedIndexChanged(New Object(), New EventArgs())

        Dim currentColumns(17) As Integer
        currentColumns(0) = ConvertKPaToInt(101)

        For count As Integer = 0 To 16
            Dim kpa As Double = ConvertPSIToKPa(count * 2 + 1) + 101
            currentColumns(count + 1) = ConvertKPaToInt(kpa)
        Next

        For index As Integer = 0 To 17

            For previousIndex As Integer = 0 To 15

                If previousColumns(previousIndex) = currentColumns(index) Then

                    For row As Integer = 0 To 15
                        WriteFlashByte(editing_map + row * 24 + index, previousMap(previousIndex, row))
                    Next

                ElseIf previousColumns(previousIndex) < currentColumns(index) And previousColumns(previousIndex + 1) > currentColumns(index) Then

                    Dim percentage As Double = (currentColumns(index) - previousColumns(previousIndex)) / (previousColumns(previousIndex + 1) - previousColumns(previousIndex))

                    For row As Integer = 0 To 15
                        Dim value As Integer = previousMap(previousIndex, row) + (previousMap(previousIndex + 1, row) - previousMap(previousIndex, row)) * percentage
                        WriteFlashByte(editing_map + row * 24 + index, value)
                    Next

                End If

            Next
        Next

    End Sub

    Private Sub generate_map_table()
        Dim i, c, r, value, lastValue As Integer

        NUD_SensorVoltage1.Value = ReadFlashWord(&H55C30) / 10
        NUD_SensorPressure1.Value = ReadFlashWord(&H55C32) / 10

        NUD_SensorVoltage2.Value = ReadFlashWord(&H55C34) / 10
        NUD_SensorPressure2.Value = ReadFlashWord(&H55C36) / 10

        C_BoostPressureDisplay.SelectedIndex = My.Settings.BoostPressureDisplay

        ' Generate column headings
        D_BoostFuel.ColumnCount = 24
        D_BoostIgnitionRetard.ColumnCount = 24
        D_BoostIgnitionRetard.Rows.Item(0).HeaderCell.Value = "_____"

        c = 0

        Do While c < D_BoostFuel.ColumnCount

            D_BoostFuel.Columns(c).Visible = True
            D_BoostIgnitionRetard.Columns(c).Visible = True

            value = ReadFlashByte(columnheading_map + c)

            If C_BoostPressureDisplay.SelectedIndex = 0 Then
                Dim psi As Double = ConvertIntToPSI(value)
                D_BoostFuel.Columns.Item(c).HeaderText = (psi - 14.7).ToString("0")
                D_BoostIgnitionRetard.Columns.Item(c).HeaderText = (psi - 14.7).ToString("0")
            Else
                Dim kpa As Double = ConvertIntToKPa(value)

                If kpa < 101 Then
                    kpa = 101
                End If

                D_BoostFuel.Columns.Item(c).HeaderText = (kpa - 101).ToString("0")
                D_BoostIgnitionRetard.Columns.Item(c).HeaderText = (kpa - 101).ToString("0")
            End If

            D_BoostFuel.Columns.Item(c).Width = 35
            D_BoostIgnitionRetard.Columns.Item(c).Width = 35

            If lastValue = &HFF Then
                D_BoostFuel.Columns(c).Visible = False
                D_BoostIgnitionRetard.Columns(c).Visible = False
            End If

            c = c + 1
            lastValue = value
        Loop

        D_BoostIgnitionRetard.RowCount = 1

        ' Generate row headings
        D_BoostFuel.RowCount = 24
        D_BoostFuel.RowHeadersWidth = 60
        r = 0

        Do While (r < D_BoostFuel.RowCount)
            i = ReadFlashWord(rowheading_map + (r * 2))
            D_BoostFuel.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            D_BoostFuel.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        ' Show overboost limit
        '
        If ReadFlashByte(&H55400) <> &HFF Then ' If shifter module is active, then enable overboost limit adjusting
            T_overboost.Enabled = True
            T_overboost.Visible = True
        Else
            T_overboost.Enabled = False
            T_overboost.Visible = False
        End If

        If C_BoostPressureDisplay.SelectedIndex = 0 Then
            T_overboost.Text = ConvertIntToPSI(ReadFlashWord(&H55802)).ToString("0")
        Else
            T_overboost.Text = ConvertIntToKPa(ReadFlashWord(&H55802)).ToString("0")
        End If

        ' Generate map contents into a grid
        c = 0
        r = 0
        i = 0

        Do While (r < D_BoostFuel.RowCount)

            If (D_BoostFuel.Columns.Item(c).HeaderText > Abs(Val(T_overboost.Text))) And (ReadFlashByte(&H55400) <> &HFF) Then
                D_BoostFuel.Item(c, r).Style.ForeColor = Color.Gray
            Else
                D_BoostFuel.Item(c, r).Style.ForeColor = Color.Black
            End If

            D_BoostFuel.Item(c, r).Value = Int(ReadFlashByte(i + editing_map))
            If c < D_BoostFuel.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        If C_BoostPressureDisplay.SelectedIndex = 0 Then
            G_boosttable.Text = "% add per each RPM/PSi range"
        Else
            G_boosttable.Text = "% add per each RPM/kPa range"
        End If

        LoadIgnitionRetardMap()
        generate_duty_table()

    End Sub

    Private Sub generate_duty_table()
        Dim c, r, i As Integer

        ' Generate column headings
        D_duty.ColumnCount = 6
        c = 0
        Do While c < D_duty.ColumnCount
            D_duty.Columns.Item(c).HeaderText = "Gear " & Str(c + 1)
            D_duty.Columns.Item(c).Width = 70
            c = c + 1
        Loop

        ' Generate row headings
        D_duty.RowCount = 4

        D_duty.RowHeadersWidth = 110
        D_duty.Rows.Item(0).HeaderCell.Value = "0% over"
        D_duty.Rows.Item(1).HeaderCell.Value = "100% below"
        D_duty.Rows.Item(2).HeaderCell.Value = "Duty%"
        D_duty.Rows.Item(3).HeaderCell.Value = "Ign ret"

        ' Generate map contents into a grid
        c = 0
        r = 0
        i = 0

        Dim address As Integer = &H55C00

        Do While (r < D_duty.RowCount)

            If (r = 0) Or (r = 1) Then

                If C_BoostPressureDisplay.SelectedIndex = 0 Then
                    D_duty.Item(c, r).Value = (ConvertIntToPSI(ReadFlashWord((i * 2) + address)) - 14.7).ToString("0")
                Else
                    D_duty.Item(c, r).Value = (ConvertIntToKPa(ReadFlashWord((i * 2) + address)) - 101).ToString("0")
                End If
            Else
                D_duty.Item(c, r).Value = Int((ReadFlashWord((i * 2) + address)))
            End If

            If c < D_duty.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        If metric Then
            L_solenoid_control.Text = "Solenoid controlled boost duty and max pressure Kpa"
        Else
            L_solenoid_control.Text = "Solenoid controlled boost duty and max pressure Psi"
        End If

    End Sub

    Private Sub D_boostfuel_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles D_BoostFuel.CellEndEdit
        writemaptoflash()
    End Sub

    Private Sub writemaptoflash()
        Dim r, c, i As Integer

        ' Copy grid contents to the bin
        c = 0
        r = 0
        i = 0

        Do While (r < D_BoostFuel.RowCount)

            If D_BoostFuel.Item(c, r).Value < 0 Then
                D_BoostFuel.Item(c, r).Value = 0
                MsgBox("Min value exceeded, using min value")
            End If

            If D_BoostFuel.Item(c, r).Value > 255 Then
                D_BoostFuel.Item(c, r).Value = 255
                MsgBox("Max value exceeded, using max value")
            End If

            WriteFlashByte(i + editing_map, (D_BoostFuel.Item(c, r).Value))

            If c < D_BoostFuel.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub duty_writemaptoflash()
        Dim r, c, i As Integer

        ' Copy grid contents to the bin
        c = 0
        r = 0
        i = 0

        Do While (r < D_duty.RowCount)
            If D_duty.Item(c, r).Value < 0 Then
                D_duty.Item(c, r).Value = 0
                MsgBox("Min value exceeded, using min value")
            End If
            If D_duty.Item(c, r).Value > 255 Then
                D_duty.Item(c, r).Value = 255
                MsgBox("Max value exceeded, using max value")
            End If

            Dim address As Integer = &H55C00

            If (r = 0) Or (r = 1) Then
                If C_BoostPressureDisplay.SelectedIndex = 0 Then
                    Dim value As Integer = ConvertPSIToInt(D_duty.Item(c, r).Value + 14.7)
                    WriteFlashWord((i * 2) + address, value)
                Else
                    Dim value As Integer = ConvertKPaToInt(D_duty.Item(c, r).Value + 101)
                    WriteFlashWord((i * 2) + address, value)
                End If
            Else
                WriteFlashWord((i * 2) + address, (D_duty.Item(c, r).Value))
            End If

            If c < D_duty.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If

            i = i + 1

        Loop
    End Sub

    Private Sub Duty_DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer

        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_duty.SelectedCells.Count()

        Do While (r < D_duty.RowCount)

            If D_duty.Item(c, r).Selected And n > 0 Then
                D_duty.Item(c, r).Value = D_duty.Item(c, r).Value - decrease
                n = n - 1
            End If

            If c < D_duty.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub Duty_IncreaseSelectedCells()

        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim increase As Integer

        increase = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_duty.SelectedCells.Count()

        Do While (r < D_duty.RowCount)

            If D_duty.Item(c, r).Selected And n > 0 Then
                D_duty.Item(c, r).Value = D_duty.Item(c, r).Value + increase
                n = n - 1
            End If

            If c < D_duty.ColumnCount - 1 Then
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

        n = D_BoostFuel.SelectedCells.Count()

        Do While (r < D_BoostFuel.RowCount)

            If D_BoostFuel.Item(c, r).Selected And n > 0 Then
                D_BoostFuel.Item(c, r).Value = D_BoostFuel.Item(c, r).Value - decrease
                n = n - 1
            End If

            If c < D_BoostFuel.ColumnCount - 1 Then
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

        n = D_BoostFuel.SelectedCells.Count()

        Do While (r < D_BoostFuel.RowCount)

            If D_BoostFuel.Item(c, r).Selected And n > 0 Then
                D_BoostFuel.Item(c, r).Value = Int(D_BoostFuel.Item(c, r).Value / 1.05)
                n = n - 1
            End If

            If c < D_BoostFuel.ColumnCount - 1 Then
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

        n = D_BoostFuel.SelectedCells.Count()

        Do While (r < D_BoostFuel.RowCount)

            If D_BoostFuel.Item(c, r).Selected And n > 0 Then
                D_BoostFuel.Item(c, r).Value = Int(D_BoostFuel.Item(c, r).Value * 1.05)
                n = n - 1
            End If

            If c < D_BoostFuel.ColumnCount - 1 Then
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

        n = D_BoostFuel.SelectedCells.Count()

        Do While (r < D_BoostFuel.RowCount) And n > 0

            If D_BoostFuel.Item(c, r).Selected And n > 0 Then
                D_BoostFuel.Item(c, r).Value = D_BoostFuel.Item(c, r).Value + increase
                n = n - 1
            End If

            If c < D_BoostFuel.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub D_boostfuel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles D_BoostFuel.KeyPress

        ' this is the user interface shortcut keys processor
        Select Case e.KeyChar
            Case "*"
                MultiplySelectedCells()
            Case "/"
                DivideSelectedCells()
            Case "+"
                IncreaseSelectedCells()
            Case "-"
                DecreaseSelectedCells()
            Case "d"
                setdebugrpmstep()
            Case Chr(27)
                Me.Close()
        End Select

        writemaptoflash()

    End Sub

    Public Sub tracemap()
        Dim i As Integer
        Dim c As Integer
        Dim r As Integer

        If C_BoostPressureDisplay.SelectedIndex = 0 Then
            i = ConvertIntToPSI(BOOST) - ConvertKPaToPSI(101)
        Else
            i = ConvertIntToKPa(BOOST) - 101
        End If

        LED_BOOST.Text = Str(i)

        If C_BoostfuelActivation.Checked = True Then

            ' based on enginedata show the position on the map and trace which cell is being accessed by ecu (almost)
            D_BoostFuel.Item(cc, rr).Style.BackColor = Color.White
            D_BoostIgnitionRetard.Item(cc, 0).Style.BackColor = Color.White

            Dim map_number_of_rows, map_number_of_columns As Integer

            map_number_of_rows = D_BoostFuel.RowCount
            map_number_of_columns = D_BoostFuel.ColumnCount

            ' Lets select the map based on MS switch position for tracing and make sure that the correct map is visible when tracing
            ' enable automatic map switching when tracing and datastream on

            r = map_number_of_rows
            c = map_number_of_columns

            ' Process RPM rows
            r = 0
            rr = 0

            Do While (r < map_number_of_rows - 1)
                If RPM >= rr And RPM < Int(D_BoostFuel.Rows(r + 1).HeaderCell.Value) Then
                    rr = r
                    r = 256
                Else
                    r = r + 1
                    rr = Int(D_BoostFuel.Rows(r).HeaderCell.Value)
                End If
            Loop

            ' Process BOOST columns
            c = 0
            cc = 0
            If i < Val(D_BoostFuel.Columns.Item(map_number_of_columns - 1).HeaderCell.Value) Then
                Do While (c < map_number_of_columns - 1)
                    If i >= cc And i < D_BoostFuel.Columns.Item(c + 1).HeaderCell.Value Then
                        cc = c
                        c = 256
                    Else
                        c = c + 1
                        cc = Int(D_BoostFuel.Columns.Item(c).HeaderCell.Value)
                    End If
                Loop
            Else
                cc = map_number_of_columns - 1
            End If

            If rr > map_number_of_rows Then rr = 0
            If rr < 0 Then rr = 0
            If cc > map_number_of_columns Then cc = 0
            If cc < 0 Then cc = 0
            If rr <> 0 Or cc <> 0 Then
                If RPM >= 4000 Then
                    D_BoostFuel.Item(cc, rr).Style.BackColor = Color.Blue
                    D_BoostIgnitionRetard.Item(cc, 0).Style.BackColor = Color.Blue
                Else
                    D_BoostFuel.Item(cc, rr).Style.BackColor = Color.White
                    D_BoostIgnitionRetard.Item(cc, 0).Style.BackColor = Color.White
                End If
            Else
                D_BoostFuel.Item(cc, rr).Style.BackColor = Color.White
                D_BoostIgnitionRetard.Item(cc, 0).Style.BackColor = Color.White
            End If
        End If

    End Sub

    Private Sub C_solenoidcontrol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_solenoidcontrol.CheckedChanged

        If C_solenoidcontrol.Checked = True Then
            C_solenoidcontrol.Text = "Active"
            D_solenoidcontrol.Visible = True
            WriteFlashByte(&H55C3A, &H0)
            K8Advsettings.C_PAIR.Checked = False
        Else
            C_solenoidcontrol.Text = "Not active"
            D_solenoidcontrol.Visible = False
            WriteFlashByte(&H55C3A, &HFF)
        End If

        generate_duty_table()

    End Sub

    Private Sub D_duty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles D_duty.KeyPress
        Select Case e.KeyChar
            Case "+"
                Duty_IncreaseSelectedCells()
            Case "-"
                Duty_DecreaseSelectedCells()
            Case Chr(27)
                Me.Close()
            Case "d"
                setdebugrpmstep()
            Case "P"
                printthis()
            Case "p"
                printthis()
        End Select

        duty_writemaptoflash()

    End Sub

    Private Sub C_bleed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_bleed.CheckedChanged

        If C_bleed.Checked = True Then
            C_bleed.Text = "Normally Open"
            WriteFlashByte(&H55C3B, &H0)
        Else
            C_bleed.Text = "Normally Closed"
            WriteFlashByte(&H55C3B, &HFF)
        End If
        generate_duty_table()

    End Sub

    Private Sub setdebugrpmstep()
        If ReadFlashWord(rowheading_map) = 0 Then
            WriteFlashWord(rowheading_map, &H2800)
        Else
            WriteFlashWord(rowheading_map, 0)
        End If
        generate_map_table()
    End Sub

    Private Sub T_overboost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles T_overboost.KeyPress
        
        If ReadFlashByte(&H55400) = &HFF Then
            MsgBox("To use overboost limit you must have shifter code active")
            T_overboost.Enabled = False
            T_overboost.Visible = False
        Else
            Select Case e.KeyChar
                Case "+"
                    T_overboost.Text = Abs(Val(T_overboost.Text)) + 1
                Case "-"
                    T_overboost.Text = Abs(Val(T_overboost.Text)) - 1
            End Select

            If Abs(Val(T_overboost.Text)) <= 5 Then T_overboost.Text = "5"
            If Abs(Val(T_overboost.Text)) > 250 Then T_overboost.Text = "250"

            If C_BoostPressureDisplay.SelectedIndex = 0 Then
                WriteFlashWord(&H55802, ConvertPSIToInt(T_overboost.Text))
            Else
                WriteFlashWord(&H55802, ConvertKPaToInt(T_overboost.Text))
            End If
        End If
    End Sub

    Private Sub C_fueladd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_fueladd.CheckedChanged
        If C_fueladd.Checked = True Then
            C_fueladd.Text = "+ to TPS"
            WriteFlashByte(&H55C39, &H0)
        Else
            C_fueladd.Text = "% of TPS"
            WriteFlashByte(&H55C39, &H10)
        End If

    End Sub

    Private Sub D_boostfuel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles D_BoostFuel.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In D_BoostFuel.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next

            rowIndex = D_BoostFuel.CurrentCell.RowIndex

            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    If columnIndex < D_BoostFuel.ColumnCount And rowIndex < D_BoostFuel.RowCount Then
                        If IsNumeric(value) Then
                            D_BoostFuel(columnIndex, rowIndex).Value = value
                            'SetFlashItem(columnIndex, rowIndex)
                        End If
                    End If

                    columnIndex = columnIndex + 1
                Next

                rowIndex = rowIndex + 1
            Next

        End If
        writemaptoflash()

    End Sub

    Private Sub D_duty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles D_duty.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In D_duty.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next

            rowIndex = D_duty.CurrentCell.RowIndex
            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    value = Replace(value, ControlChars.Lf, "") ' removing extra LF - issue 38
                    If columnIndex < D_BoostFuel.ColumnCount And rowIndex < D_duty.RowCount Then
                        If IsNumeric(value) Then
                            D_duty(columnIndex, rowIndex).Value = value
                        End If
                    End If

                    columnIndex = columnIndex + 1
                Next

                rowIndex = rowIndex + 1
            Next

        End If
        duty_writemaptoflash()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        K8BoostControlDiagram.Show()
    End Sub

    Private Sub B_Apply_Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Lets use OpenFileDialog to open a new flash image file
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        Dim fs As FileStream
        Dim path As String
        Dim pcv(&HA90)
        Dim bz(&H205)
        Dim bin((262144 * 4) + 1)
        Dim rp, cp, noc, nor As Integer
        Dim b(1) As Byte
        Dim i As Integer
        Dim filetype As String
        Dim em As Integer


        MsgBox("Note: This feature is currently for testing. Only apply once for each map.")
        '
        ' remember also to make a note not to apply the pc maps twice...
        '

        fdlg.InitialDirectory = ""
        fdlg.Title = "Open a map file"
        fdlg.Filter = "bin (*.bin)|*.bin"
        fdlg.FilterIndex = 1
        fdlg.RestoreDirectory = True

        '
        ' Apply changes to the TPS map
        '
        noc = 16
        nor = 16


        If fdlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = fdlg.FileName

            filetype = ""

            If fdlg.FileName.Contains("bin") Then
                filetype = "bin"
            End If


            Select Case filetype
                Case "bin"
                    '
                    ' ECCeditor or other type .bin file
                    '

                    '
                    ' First lets get the file to the memory and check that it can be applied
                    '
                    fs = File.OpenRead(path)
                    i = 0
                    Do While fs.Read(b, 0, 1) > 0
                        If i > (262144 * 4) Then
                            MsgBox("not a gen2 .bin file, program aborts")
                            Return
                        End If
                        bin(i) = b(0)
                        i = i + 1
                    Loop
                    fs.Close()
                    If i <> (262144 * 4) Then
                        MsgBox("not a gen2 .bin file, program aborts")
                        Return
                    End If

                    rp = 0
                    cp = 0
                    ' 
                    ' Lets process the table, we use ecueditor table as its bigger in size
                    '
                    For rp = 0 To nor - 1
                        For cp = 0 To noc - 1

                            '
                            ' Now lets copy the fuelmap information to the table
                            '
                            i = (rp * noc) + cp

                            em = &H55874
                            D_BoostFuel.Item(cp, rp).Value = bin(em + i)

                            '
                            ' Set value on map to ecu flash
                            '
                        Next
                    Next
                Case Else
                    MsgBox("Unsupported filetype")
            End Select
            writemaptoflash()

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim multiplier As Decimal = 1.18
        Dim i As Integer
        i = ReadFlashByte(&H55844)

        If (MsgBox("Are you sure, this will change the scaling and you need to completely rebuild the boostmap ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then

            Select Case i
                Case &H52

                    ' vacuum area conversion
                    WriteFlashByte(&H55814 + 0, &H0)
                    WriteFlashByte(&H55814 + 1, &H8)
                    WriteFlashByte(&H55814 + 2, &H10)
                    WriteFlashByte(&H55814 + 3, &H18)
                    WriteFlashByte(&H55814 + 4, &H20)
                    WriteFlashByte(&H55814 + 5, &H27)
                    WriteFlashByte(&H55814 + 6, &H30)
                    WriteFlashByte(&H55814 + 7, &H38)
                    WriteFlashByte(&H55814 + 8, &H3F)
                    WriteFlashByte(&H55814 + 9, &H50)
                    WriteFlashByte(&H55814 + 10, &H60)
                    WriteFlashByte(&H55814 + 11, &H6C)
                    WriteFlashByte(&H55814 + 12, &HFF)
                    WriteFlashByte(&H55814 + 13, &HFF)
                    WriteFlashByte(&H55814 + 14, &HFF)
                    WriteFlashByte(&H55814 + 15, &HFF)

                    ' boostmap
                    WriteFlashByte(&H55844 + 0, &H52)
                    WriteFlashByte(&H55844 + 1, &H58)
                    WriteFlashByte(&H55844 + 2, &H5E)
                    WriteFlashByte(&H55844 + 3, &H63)
                    WriteFlashByte(&H55844 + 4, &H6C)
                    WriteFlashByte(&H55844 + 5, &H73)
                    WriteFlashByte(&H55844 + 6, &H81)
                    WriteFlashByte(&H55844 + 7, &H8B)
                    WriteFlashByte(&H55844 + 8, &H92)
                    WriteFlashByte(&H55844 + 9, &H98)
                    WriteFlashByte(&H55844 + 10, &HA0)
                    WriteFlashByte(&H55844 + 11, &HA6)
                    WriteFlashByte(&H55844 + 12, &HB2)
                    WriteFlashByte(&H55844 + 13, &HBD)
                    WriteFlashByte(&H55844 + 14, &HCB)
                    WriteFlashByte(&H55844 + 15, &HD8)
            End Select

            generate_map_table()
            writemaptoflash()

        End If

    End Sub

    Private Sub C_SensorType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_SensorType.SelectedIndexChanged

        If C_SensorType.SelectedItem.ToString() = "GM 3 Bar" Then

            NUD_SensorVoltage1.Value = 0
            NUD_SensorPressure1.Value = 0

            NUD_SensorVoltage2.Value = 5
            NUD_SensorPressure2.Value = 313

        ElseIf C_SensorType.SelectedItem.ToString() = "SSI 5 Bar" Then

            NUD_SensorVoltage1.Value = 0.5
            NUD_SensorPressure1.Value = 0

            NUD_SensorVoltage2.Value = 4.5
            NUD_SensorPressure2.Value = 516

        Else

            NUD_SensorVoltage1.Value = 0
            NUD_SensorPressure1.Value = 0

            NUD_SensorVoltage2.Value = 5
            NUD_SensorPressure2.Value = 516

        End If

    End Sub

    Private Sub B_ApplySensorValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ApplySensorValues.Click

        If B_ApplySensorValues.Text = "Edit" Then

            NUD_SensorPressure1.Enabled = True
            NUD_SensorPressure2.Enabled = True
            NUD_SensorVoltage1.Enabled = True
            NUD_SensorVoltage2.Enabled = True

            C_SensorType.Enabled = True

            B_ApplySensorValues.Text = "Save"
        Else

            SaveSensorValues()

            Dim kpa = 101
            Dim psi = 0
            Dim value As Double = ConvertKPaToInt(101)

            WriteFlashByte(columnheading_map, value)

            For count As Integer = 0 To 22

                psi = 1 + count * 2
                kpa = 101 + (psi * KPA_PSI)
                value = ConvertKPaToInt(kpa)
                WriteFlashByte((count + 1) + columnheading_map, value)
                WriteFlashByte((count + 1) + ignitionretard_columns, value)

            Next

            Dim address As Integer = &H55814

            'Sensor Map
            WriteFlashByte(address, ConvertKPaToInt(0))
            WriteFlashByte(address + 1, ConvertKPaToInt(10))
            WriteFlashByte(address + 2, ConvertKPaToInt(20))
            WriteFlashByte(address + 3, ConvertKPaToInt(30))
            WriteFlashByte(address + 4, ConvertKPaToInt(40))
            WriteFlashByte(address + 5, ConvertKPaToInt(49))
            WriteFlashByte(address + 6, ConvertKPaToInt(60))
            WriteFlashByte(address + 7, ConvertKPaToInt(70))
            WriteFlashByte(address + 8, ConvertKPaToInt(79))
            WriteFlashByte(address + 9, ConvertKPaToInt(101))
            WriteFlashByte(address + 10, ConvertKPaToInt(121))
            WriteFlashByte(address + 11, ConvertKPaToInt(136))

            generate_map_table()

            NUD_SensorPressure1.Enabled = False
            NUD_SensorPressure2.Enabled = False
            NUD_SensorVoltage1.Enabled = False
            NUD_SensorVoltage2.Enabled = False

            C_SensorType.Enabled = False

            B_ApplySensorValues.Text = "Edit"
        End If
        

    End Sub

    Public Function ConvertPSIToInt(ByVal value As Double) As Integer

        value = ConvertPSIToKPa(value)
        Return ConvertKPaToInt(value)

    End Function

    Public Function ConvertKPaToInt(ByVal value As Double) As Integer

        Dim kpaRange As Double = NUD_SensorPressure2.Value - NUD_SensorPressure1.Value
        Dim voltageRange As Double = NUD_SensorVoltage2.Value - NUD_SensorVoltage1.Value
        Dim kpaPerVolt As Double = kpaRange / voltageRange

        Dim voltage As Double = ((value - NUD_SensorPressure1.Value) / kpaRange * voltageRange) + NUD_SensorVoltage1.Value

        Dim result As Integer = ConvertVoltageToInt(voltage)

        If result > 255 Then
            result = 255
        End If

        If result < 0 Then
            result = 0
        End If

        Return result

    End Function

    Public Function ConvertVoltageToInt(ByVal voltage As Double) As Double

        If voltage < 0 Then
            voltage = 0
        End If

        If voltage > 5 Then
            voltage = 5
        End If

        Return voltage * 255 / 5

    End Function

    Public Function ConvertIntToVoltage(ByVal value As Integer) As Double

        If value > 255 Then
            value = 255
        End If

        If value < 0 Then
            value = 0
        End If

        Return value * 5 / 255

    End Function

    Public Function ConvertIntToKPa(ByVal value As Integer) As Double

        Dim voltage As Double = ConvertIntToVoltage(value)
        Return ConvertVoltageToKPa(voltage)

    End Function

    Public Function ConvertIntToPSI(ByVal value As Integer) As Double

        Return ConvertKPaToPSI(ConvertIntToKPa(value))

    End Function

    Public Function ConvertVoltageToKPa(ByVal voltage As Double) As Double

        Dim pressureRange As Double = NUD_SensorPressure2.Value - NUD_SensorPressure1.Value
        Dim voltageRange As Double = NUD_SensorVoltage2.Value - NUD_SensorVoltage1.Value

        Return (voltage - NUD_SensorVoltage1.Value) / voltageRange * pressureRange

    End Function

    Public Function ConvertKPaToPSI(ByVal kPa As Double) As Double

        Return kPa / KPA_PSI

    End Function

    Public Function ConvertPSIToKPa(ByVal psi As Double) As Double

        Return psi * KPA_PSI

    End Function

    Private Sub C_BoostPressureDisplay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_BoostPressureDisplay.SelectedIndexChanged

        My.Settings.BoostPressureDisplay = C_BoostPressureDisplay.SelectedIndex
        My.Settings.Save()

        generate_map_table()

    End Sub

    Private Sub SaveSensorValues()

        WriteFlashWord(&H55C30, NUD_SensorVoltage1.Value * 10)
        WriteFlashWord(&H55C32, NUD_SensorPressure1.Value * 10)
        WriteFlashWord(&H55C34, NUD_SensorVoltage2.Value * 10)
        WriteFlashWord(&H55C36, NUD_SensorPressure2.Value * 10)

    End Sub

    Private Sub D_BoostIgnitionRetard_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles D_BoostIgnitionRetard.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In D_BoostIgnitionRetard.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next

            rowIndex = D_BoostIgnitionRetard.CurrentCell.RowIndex

            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    If columnIndex < D_BoostIgnitionRetard.ColumnCount And rowIndex < D_BoostIgnitionRetard.RowCount Then
                        If IsNumeric(value) Then
                            D_BoostIgnitionRetard(columnIndex, rowIndex).Value = value
                        End If
                    End If

                    columnIndex = columnIndex + 1
                Next

                rowIndex = rowIndex + 1
            Next

        End If

        WriteIgnitionRetardMap()

    End Sub

    Private Sub D_BoostIgnitionRetard_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles D_BoostIgnitionRetard.KeyPress

        ' this is the user interface shortcut keys processor
        Select Case e.KeyChar
            Case "+"

                For Each cell As DataGridViewCell In D_BoostIgnitionRetard.SelectedCells()
                    cell.Value = cell.Value + 1
                Next

            Case "-"

                For Each cell As DataGridViewCell In D_BoostIgnitionRetard.SelectedCells()

                    If cell.Value > 0 Then
                        cell.Value = cell.Value - 1
                    End If
                Next

        End Select

        WriteIgnitionRetardMap()

    End Sub

    Private Sub WriteIgnitionRetardMap()

        Dim address As Integer = &H55AF4

        For index As Integer = 0 To D_BoostIgnitionRetard.ColumnCount - 1
            WriteFlashByte(address + index, D_BoostIgnitionRetard.Item(index, 0).Value)
        Next

    End Sub

    Private Sub LoadIgnitionRetardMap()

        Dim address As Integer = &H55AF4

        For index As Integer = 0 To D_BoostIgnitionRetard.ColumnCount - 1
            D_BoostIgnitionRetard.Item(index, 0).Value = ReadFlashByte(address + index)
        Next

    End Sub

End Class
