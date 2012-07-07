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

Public Class K8boostfuel
    Public ADJ As Integer = &H55800 '&HFF if boostfuel inactive, no code present else boostfuel active
    Dim BOOSTFUELCODE As Integer = &H55A00
    Dim IDTAG As Integer = &H55800
    Dim BOOSTFUELVERSION As Integer = 112
    Dim boostfuelcodelenght As Integer = &H1000 'lenght of the boostfuel code in bytes for clearing the memory
    Dim loading As Boolean = True

    Dim rowheading_map As Integer = &H55854
    Dim columnheading_map As Integer = &H55844
    Dim editing_map As Integer = &H55874 '&H55854
    Dim change As Integer = 1
    Dim rr, cc As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (ReadFlashByte(ADJ) <> &HFF) Then
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_boostfuel_activation.CheckedChanged, C_boostfuel_activation.CheckedChanged
        If C_boostfuel_activation.Checked Then

            C_boostfuel_activation.Text = "Code active"

            If (ReadFlashByte(ADJ) = &HFF) Then
                modify_original_ECU_code(True)
                boostfuel_code_in_memory(True, boostfuelcodelenght)
                generate_map_table()
            End If

            read_boostfuel_settings()
        Else
            C_boostfuel_activation.Text = "Code not active"
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

    Private Sub boostfuel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        L_boostfuelver.Text = Str(BOOSTFUELVERSION)

        If (ReadFlashByte(ADJ) = &HFF) Then
            C_boostfuel_activation.Checked = False
            hide_boostfuel_settings()
        Else
            C_boostfuel_activation.Checked = True
            read_boostfuel_settings()
            'boostfuel_code_in_memory(True, boostfuelcodelenght)
            generate_map_table()

            If (ReadFlashWord(IDTAG) <> BOOSTFUELVERSION) Then
                MsgBox("boostfuel code incompatible with this version, please reactivate the boostfuel on this map " & Str(ReadFlashWord(IDTAG)))
                C_boostfuel_activation.Checked = False
                hide_boostfuel_settings()
            End If

        End If

        If metric Then
            G_boosttable.Text = "% add per each RPM/kPa range"
        Else
            G_boosttable.Text = "% add per each RPM/PSi range"
        End If

        loading = False

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
            '
            ' bring the ecu code back to original
            '
            ' GAUGEDATA BITFLAG
            WriteFlashWord(&H4E122, &H6874)
            ' KWP protocol to be able to read boost
            WriteFlashWord(&H525C8, &H7)
            WriteFlashWord(&H525CA, &HD11B)
            WriteFlashWord(&H525CC, &H7)
            WriteFlashWord(&H525CE, &HD11B)
            'WriteFlashWord(&H525CC, &H80) ' just for debugging
            'WriteFlashWord(&H525CE, &H652A) 'COV1 just for debugging
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
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\boostfuel.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("boostfuel code not found at: " & path, MsgBoxStyle.Critical)
            C_boostfuel_activation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the boostfuel code into memory address from the .bin file
            '
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                WriteFlashByte(i + ADJ, b(0))
                i = i + 1
            Loop
            fs.Close()

            i = ReadFlashWord(IDTAG)

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
        If ReadFlashByte(&H559D1) = &H0 Then
            C_fueladd.Text = "+ to TPS"
            C_fueladd.Checked = True
        Else
            C_fueladd.Text = "% of TPS"
            C_fueladd.Checked = False
        End If

        Select Case ReadFlashByte(&H55844)
            Case &H52
                B_rescale.Text = "GM3bar"
            Case Int(&H52 * 1.18)
                B_rescale.Text = "GM3bar ext"
            Case Else ' return back to GM3 bar standard map
                B_rescale.Text = "SSI5bar"
        End Select

        D_boostfuel.Visible = True
        C_solenoidcontrol.Visible = True
        solenoidcontrol_visible()
    End Sub

    Private Sub hide_boostfuel_settings()
        D_boostfuel.Visible = False
        C_solenoidcontrol.Visible = False
        solenoidcontrol_visible()
    End Sub

    Private Sub solenoidcontrol_visible()

        If ReadFlashByte(&H559D2) = &H0 Then 'Dutyactive
            D_solenoidcontrol.Visible = True
            C_solenoidcontrol.Checked = True
        Else
            D_solenoidcontrol.Visible = False
            C_solenoidcontrol.Checked = False
        End If

        If ReadFlashByte(&H559D3) = &H0 Then 'Solenoidtype
            C_bleed.Checked = True
            C_bleed.Text = "Normally Open"
        Else
            C_bleed.Checked = False
            C_bleed.Text = "Normally Closed"
        End If
    End Sub

    Private Sub generate_map_table()
        Dim c, r, i As Integer
        '
        ' Generate column headings
        '
        D_boostfuel.ColumnCount = 16

        c = 0

        Do While c < D_boostfuel.ColumnCount
            i = ReadFlashByte(columnheading_map + c)

            If B_rescale.Text.Contains("GM3") Then
                If Metric Then
                    D_boostfuel.Columns.Item(c).HeaderText = Int(((((i / 50.5) * 9.2) - 14.7) / 14.7) * 100)
                Else
                    D_boostfuel.Columns.Item(c).HeaderText = Int(((((i / 50.5) * 9.2) - 14.7)))
                End If
            Else
                '
                ' SSI5 bar calculates this differently
                '
                If Metric Then
                    'D_boostfuel.Columns.Item(c).HeaderText = Int(((((i / 50.5) * 9.2) - 14.7) / 14.7) * 100) * 1.5
                    D_boostfuel.Columns.Item(c).HeaderText = "n/a"
                Else
                    'D_boostfuel.Columns.Item(c).HeaderText = Int(((((i / 50.5) * 9.2) - 14.7))) * 1.5
                    D_boostfuel.Columns.Item(c).HeaderText = "n/a"
                End If
            End If
            D_boostfuel.Columns.Item(c).Width = 35
            c = c + 1
        Loop

        ' Generate row headings
        D_boostfuel.RowCount = 16
        D_boostfuel.RowHeadersWidth = 60
        r = 0
        Do While (r < D_boostfuel.RowCount)
            i = ReadFlashWord(rowheading_map + (r * 2))
            D_boostfuel.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            D_boostfuel.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        ' Show overboost limit
        If ReadFlashByte(&H55400) <> &HFF Then ' If shifter module is active, then enable overboost limit adjusting
            T_overboost.Enabled = True
            T_overboost.Visible = True
        Else
            T_overboost.Enabled = False
            T_overboost.Visible = False
        End If

        If metric Then
            T_overboost.Text = Int(((((ReadFlashWord(&H55802) / 50.5) * 9.2) - 14.7) / 14.7) * 100)
        Else
            T_overboost.Text = Int(((((ReadFlashWord(&H55802) / 50.5) * 9.2) - 14.7)))
        End If


        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_boostfuel.RowCount)

            If (D_boostfuel.Columns.Item(c).HeaderText > Abs(Val(T_overboost.Text))) And (ReadFlashByte(&H55400) <> &HFF) Then
                D_boostfuel.Item(c, r).Style.ForeColor = Color.Gray
            Else
                D_boostfuel.Item(c, r).Style.ForeColor = Color.Black
            End If

            D_boostfuel.Item(c, r).Value = Int(ReadFlashByte(i + editing_map))
            If c < D_boostfuel.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        If metric Then
            G_boosttable.Text = "% add per each RPM/kPa range"
        Else
            G_boosttable.Text = "% add per each RPM/PSi range"
        End If


        generate_duty_table()

    End Sub

    Private Sub D_boostfuel_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles D_boostfuel.CellEndEdit
        writemaptoflash()

    End Sub

    Private Sub writemaptoflash()
        Dim r, c, i As Integer
        '
        ' Copy grid contents to the bin
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_boostfuel.RowCount)
            If D_boostfuel.Item(c, r).Value < 0 Then
                D_boostfuel.Item(c, r).Value = 0
                MsgBox("Min value exceeded, using min value")
            End If
            If D_boostfuel.Item(c, r).Value > 255 Then
                D_boostfuel.Item(c, r).Value = 255
                MsgBox("Max value exceeded, using max value")
            End If

            WriteFlashByte(i + editing_map, (D_boostfuel.Item(c, r).Value))
            If c < D_boostfuel.ColumnCount - 1 Then
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
        '
        ' Copy grid contents to the bin
        '
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
            If (r = 0) Or (r = 1) Then
                If metric Then
                    WriteFlashWord((i * 2) + &H559A0, (((14.7 * D_duty.Item(c, r).Value / 100) + 14.7) * 50.5 / 9.2))
                    'D_duty.Item(c, r).Value = Int(((((ReadFlashWord((i * 2) + &H559A4) / 50.5) * 9.2) - 14.7) / 14.7) * 100)
                Else
                    WriteFlashWord((i * 2) + &H559A0, ((D_duty.Item(c, r).Value + 14.7) * 50.5 / 9.2))
                    ' D_duty.Item(c, r).Value = Int(((((ReadFlashWord((i * 2) + &H559A4) / 50.5) * 9.2) - 14.7)))
                End If
            Else
                'if Not ((C_bleed.Checked) And (r = 2)) Then
                WriteFlashWord((i * 2) + &H559A0, (D_duty.Item(c, r).Value))
                'Else
                'WriteFlashWord((i * 2) + &H559A0, (100 - D_duty.Item(c, r).Value))
                'End If


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

        n = D_boostfuel.SelectedCells.Count()

        Do While (r < D_boostfuel.RowCount)

            If D_boostfuel.Item(c, r).Selected And n > 0 Then
                D_boostfuel.Item(c, r).Value = D_boostfuel.Item(c, r).Value - decrease
                n = n - 1
            End If

            If c < D_boostfuel.ColumnCount - 1 Then
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

        n = D_boostfuel.SelectedCells.Count()

        Do While (r < D_boostfuel.RowCount)

            If D_boostfuel.Item(c, r).Selected And n > 0 Then
                D_boostfuel.Item(c, r).Value = Int(D_boostfuel.Item(c, r).Value / 1.05)
                n = n - 1
            End If

            If c < D_boostfuel.ColumnCount - 1 Then
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

        n = D_boostfuel.SelectedCells.Count()

        Do While (r < D_boostfuel.RowCount)

            If D_boostfuel.Item(c, r).Selected And n > 0 Then
                D_boostfuel.Item(c, r).Value = Int(D_boostfuel.Item(c, r).Value * 1.05)
                n = n - 1
            End If

            If c < D_boostfuel.ColumnCount - 1 Then
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


        n = D_boostfuel.SelectedCells.Count()

        Do While (r < D_boostfuel.RowCount) And n > 0

            If D_boostfuel.Item(c, r).Selected And n > 0 Then
                D_boostfuel.Item(c, r).Value = D_boostfuel.Item(c, r).Value + increase
                n = n - 1
            End If

            If c < D_boostfuel.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub D_boostfuel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles D_boostfuel.KeyPress

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
        If B_rescale.Text.Contains("GM3") Then
            If Metric Then
                i = Int(((((BOOST / 50.5) * 9.2) - 14.7) / 14.7) * 100)
            Else
                i = Int(((((BOOST / 50.5) * 9.2) - 14.7)))
            End If
        Else
            '
            ' ssI5BAR sensor calculates differently
            '
            If Metric Then
                'i = Int(((((BOOST / 50.5) * 9.2) - 14.7) / 14.7) * 100)
                i = 0
            Else
                'i = Int(((((BOOST / 50.5) * 9.2) - 14.7)))
                i = 0
            End If
        End If

        LED_BOOST.Text = Str(i)

        If C_boostfuel_activation.Checked = True Then

            '
            ' based on enginedata show the position on the map and trace which cell is being accessed by ecu (almost)
            '
            D_boostfuel.Item(cc, rr).Style.BackColor = Color.White

            Dim map_number_of_rows, map_number_of_columns As Integer

            map_number_of_rows = 16
            map_number_of_columns = 16

            '
            ' Lets select the map based on MS switch position for tracing and make sure that the correct map is visible when tracing
            '

            ' enable automatic map switching when tracing and datastream on

            r = map_number_of_rows
            c = map_number_of_columns

            '
            ' Process RPM rows
            '
            r = 0
            rr = 0
            Do While (r < map_number_of_rows - 1)
                If RPM >= rr And RPM < Int(D_boostfuel.Rows(r + 1).HeaderCell.Value) Then
                    rr = r
                    r = 256
                Else
                    r = r + 1
                    rr = Int(D_boostfuel.Rows(r).HeaderCell.Value)
                End If
            Loop


            '
            ' Process BOOST columns
            '
            c = 0
            cc = 0
            If i < Val(D_boostfuel.Columns.Item(map_number_of_columns - 1).HeaderCell.Value) Then
                Do While (c < map_number_of_columns - 1)
                    If i >= cc And i < D_boostfuel.Columns.Item(c + 1).HeaderCell.Value Then
                        cc = c
                        c = 256
                    Else
                        c = c + 1
                        cc = Int(D_boostfuel.Columns.Item(c).HeaderCell.Value)
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
                    D_boostfuel.Item(cc, rr).Style.BackColor = Color.Blue
                Else
                    D_boostfuel.Item(cc, rr).Style.BackColor = Color.White
                End If
            Else
                D_boostfuel.Item(cc, rr).Style.BackColor = Color.White
            End If
        End If

    End Sub

    Private Sub B_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        '
        '

    End Sub

    Private Sub generate_duty_table()
        Dim c, r, i As Integer

        '
        ' Generate column headings
        '
        D_duty.ColumnCount = 6
        c = 0
        Do While c < D_duty.ColumnCount
            D_duty.Columns.Item(c).HeaderText = "Gear " & Str(c + 1)
            D_duty.Columns.Item(c).Width = 70
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        D_duty.RowCount = 4

        D_duty.RowHeadersWidth = 110
        D_duty.Rows.Item(0).HeaderCell.Value = "0% over"
        D_duty.Rows.Item(1).HeaderCell.Value = "100% below"
        D_duty.Rows.Item(2).HeaderCell.Value = "Duty%"
        D_duty.Rows.Item(3).HeaderCell.Value = "Ign ret"


        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_duty.RowCount)

            If (r = 0) Or (r = 1) Then
                If B_rescale.Text.Contains("GM3") Then
                    If Metric Then
                        D_duty.Item(c, r).Value = Int(((((ReadFlashWord((i * 2) + &H559A0) / 50.5) * 9.2) - 14.7) / 14.7) * 100)
                    Else
                        D_duty.Item(c, r).Value = Int(((((ReadFlashWord((i * 2) + &H559A0) / 50.5) * 9.2) - 14.7)))
                    End If
                Else
                    '
                    ' SSI5 bar sensor calculates differently
                    '
                    If Metric Then
                        'D_duty.Item(c, r).Value = Int(((((ReadFlashWord((i * 2) + &H559A0) / 50.5) * 9.2) - 14.7) / 14.7) * 100) * 1.5
                        D_duty.Item(c, r).Value = 0
                    Else
                        'D_duty.Item(c, r).Value = Int(((((ReadFlashWord((i * 2) + &H559A0) / 50.5) * 9.2) - 14.7))) * 1.5
                        D_duty.Item(c, r).Value = 0
                    End If

                End If
            Else
                'If Not ((C_bleed.Checked) And (r = 2)) Then
                D_duty.Item(c, r).Value = Int((ReadFlashWord((i * 2) + &H559A0)))
                'Else
                'D_duty.Item(c, r).Value = 100 - Int((ReadFlashWord((i * 2) + &H559A0)))
                ' End If
                'D_duty.Item(c, r).Value = Int((ReadFlashWord((i * 2) + &H559A0)))
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

    Private Sub C_solenoidcontrol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_solenoidcontrol.CheckedChanged

        If C_solenoidcontrol.Checked = True Then
            C_solenoidcontrol.Text = "Active"
            D_solenoidcontrol.Visible = True
            WriteFlashByte(&H559D2, &H0) ' Dutyactive
            K8Advsettings.C_PAIR.Checked = False
        Else
            C_solenoidcontrol.Text = "Not active"
            D_solenoidcontrol.Visible = False
            WriteFlashByte(&H559D2, &HFF) ' Dutyactive
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
            WriteFlashByte(&H559D3, &H0)
        Else
            C_bleed.Text = "Normally Closed"
            WriteFlashByte(&H559D3, &HFF)
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
        Dim i As Integer

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

            If B_rescale.Text.Contains("GM3") Then
                If Metric Then
                    WriteFlashWord(&H55802, (((14.7 * Int(T_overboost.Text) / 100) + 14.7) * 50.5 / 9.2))
                Else
                    WriteFlashWord(&H55802, ((Int(T_overboost.Text) + 14.7) * 50.5 / 9.2))
                End If
            Else
                '
                ' SSI5bar sensor calculates boost settigns differently
                '
                If Metric Then
                    'WriteFlashWord(&H55802, (((14.7 * Int(T_overboost.Text) / 100) + 14.7) * 50.5 / 9.2) * 1.5)
                    WriteFlashWord(&H55802, 0)
                Else
                    'WriteFlashWord(&H55802, ((Int(T_overboost.Text) + 14.7) * 50.5 / 9.2) * 1.5)
                    WriteFlashWord(&H55802, 0)
                End If
            End If

            i = ReadFlashWord(&H55802)

            'generate_map_table()
        End If

    End Sub

    Private Sub C_fueladd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_fueladd.CheckedChanged
        If C_fueladd.Checked = True Then
            C_fueladd.Text = "+ to TPS"
            WriteFlashByte(&H559D1, &H0)
        Else
            C_fueladd.Text = "% of TPS"
            WriteFlashByte(&H559D1, &H10)
        End If

    End Sub

    Private Sub D_boostfuel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles D_boostfuel.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()

            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In D_boostfuel.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next



            rowIndex = D_boostfuel.CurrentCell.RowIndex

            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    If columnIndex < D_boostfuel.ColumnCount And rowIndex < D_boostfuel.RowCount Then
                        If IsNumeric(value) Then
                            D_boostfuel(columnIndex, rowIndex).Value = value
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
                    If columnIndex < D_boostfuel.ColumnCount And rowIndex < D_duty.RowCount Then
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

    Private Sub B_Apply_Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Apply_Map.Click
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
                            D_boostfuel.Item(cp, rp).Value = bin(em + i)

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_rescale.Click
        Dim multiplier As Decimal = 1.18
        Dim i As Integer
        i = ReadFlashByte(&H55844)

        If (MsgBox("Are you sure, this will change the scaling and you need to completely rebuild the boostmap ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then

            Select Case i
                Case &H52
                    B_rescale.Text = "GM3bar ext"
                    ' extend the map
                    WriteFlashByte(&H55844 + 0, Int(&H52 * multiplier))
                    WriteFlashByte(&H55844 + 1, Int(&H58 * multiplier))
                    WriteFlashByte(&H55844 + 2, Int(&H5E * multiplier))
                    WriteFlashByte(&H55844 + 3, Int(&H63 * multiplier))
                    WriteFlashByte(&H55844 + 4, Int(&H6C * multiplier))
                    WriteFlashByte(&H55844 + 5, Int(&H73 * multiplier))
                    WriteFlashByte(&H55844 + 6, Int(&H81 * multiplier))
                    WriteFlashByte(&H55844 + 7, Int(&H8B * multiplier))
                    WriteFlashByte(&H55844 + 8, Int(&H92 * multiplier))
                    WriteFlashByte(&H55844 + 9, Int(&H98 * multiplier))
                    WriteFlashByte(&H55844 + 10, Int(&HA0 * multiplier))
                    WriteFlashByte(&H55844 + 11, Int(&HA6 * multiplier))
                    WriteFlashByte(&H55844 + 12, Int(&HB2 * multiplier))
                    WriteFlashByte(&H55844 + 13, Int(&HBD * multiplier))
                    WriteFlashByte(&H55844 + 14, Int(&HCB * multiplier))
                    WriteFlashByte(&H55844 + 15, Int(&HD8 * multiplier))
                Case Int(&H52 * multiplier)
                    B_rescale.Text = "SSI5bar"
                    MsgBox("Please note that SSI5 bar sensor conversion is not yet functional, waiting for formulas")

                    '
                    ' vacuum area conversion
                    '
                    WriteFlashByte(&H55814 + 0, &H19)
                    WriteFlashByte(&H55814 + 1, &H1D)
                    WriteFlashByte(&H55814 + 2, &H21)
                    WriteFlashByte(&H55814 + 3, &H25)
                    WriteFlashByte(&H55814 + 4, &H29)
                    WriteFlashByte(&H55814 + 5, &H2D)
                    WriteFlashByte(&H55814 + 6, &H31)
                    WriteFlashByte(&H55814 + 7, &H35)
                    WriteFlashByte(&H55814 + 8, &H39)
                    WriteFlashByte(&H55814 + 9, &H42)
                    WriteFlashByte(&H55814 + 10, &H46)
                    WriteFlashByte(&H55814 + 11, &H4C)
                    WriteFlashByte(&H55814 + 12, &H51)
                    WriteFlashByte(&H55814 + 13, &HFF)
                    WriteFlashByte(&H55814 + 14, &HFF)
                    WriteFlashByte(&H55814 + 15, &HFF)
                    '
                    ' boostmap
                    '
                    WriteFlashByte(&H55844 + 0, &H42)
                    WriteFlashByte(&H55844 + 1, &H46)
                    WriteFlashByte(&H55844 + 2, &H4C)
                    WriteFlashByte(&H55844 + 3, &H51)
                    WriteFlashByte(&H55844 + 4, &H57)
                    WriteFlashByte(&H55844 + 5, &H5C)
                    WriteFlashByte(&H55844 + 6, &H62)
                    WriteFlashByte(&H55844 + 7, &H67)
                    WriteFlashByte(&H55844 + 8, &H6D)
                    WriteFlashByte(&H55844 + 9, &H72)
                    WriteFlashByte(&H55844 + 10, &H77)
                    WriteFlashByte(&H55844 + 11, &H7D)
                    WriteFlashByte(&H55844 + 12, &H85)
                    WriteFlashByte(&H55844 + 13, &HA0)
                    WriteFlashByte(&H55844 + 14, &HAE)
                    WriteFlashByte(&H55844 + 15, &HBB)


                Case Else ' return back to GM3 bar standard map
                    B_rescale.Text = "GM3bar"

                    '
                    ' vacuum area conversion
                    '
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
                    '
                    ' boostmap
                    '
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


End Class
