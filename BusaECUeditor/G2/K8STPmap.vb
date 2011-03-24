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
Imports System.IO

Public Class K8STPmap
    '
    ' STPmap.vb contains all functions to edit STPmaps in ecueditor. it uses a global variable flash(addr) that
    ' has the full ecu image loaded as byte values. the STPmap is edited on a grid and changed values are
    ' written to the global variable flash(addr).
    '
    Dim change As Integer
    Dim previousrow As Integer
    Dim toprow(50) As Integer
    Dim TPSmap As Boolean
    Dim previouscolour As Color
    Dim gear, ms01, modeabc As Integer
    Dim STPmap As Boolean
    Dim map_structure_table As Long
    Dim map_number_of_structures As Integer
    Dim map_number_of_columns, map_number_of_rows As Integer
    Dim editing_map As Long
    Dim rowheadingmap, columnheadingmap As Long
    Dim basemap As Integer
    Dim cc, rr As Integer
    Dim stptrace As Boolean



    Private Sub STPmap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Visible = False
    End Sub

    Private Sub STPmap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        change = 1 ' default change to map when pressing +,- or *,/
        previousrow = 0
        Me.Visible = True
        stptrace = False

        '
        ' Extend STP opening map to higher rpm
        '
        WriteFlashWord(&H7006C, &H7D00) 'Gear 0
        WriteFlashWord(&H700AA, &H7D00) 'Gear 1
        WriteFlashWord(&H700E8, &H7D00) 'Gear 2
        WriteFlashWord(&H70126, &H7D00) 'Gear 3
        WriteFlashWord(&H70164, &H7D00) 'Gear 4
        WriteFlashWord(&H701A2, &H7D00) 'Gear 5
        WriteFlashWord(&H701E0, &H7D00) 'Gear 6

        '
        ' Extend STP fuelling map to higher rpm
        '
        WriteFlashWord(&H79002, &H7D00) 'Gear 0
        WriteFlashWord(&H79040, &H7D00) 'Gear 1
        WriteFlashWord(&H7907E, &H7D00) 'Gear 2
        WriteFlashWord(&H790BC, &H7D00) 'Gear 3
        WriteFlashWord(&H790FA, &H7D00) 'Gear 4
        WriteFlashWord(&H79138, &H7D00) 'Gear 5
        WriteFlashWord(&H79176, &H7D00) 'Gear 6


        '
        ' select tpsmap as first map to show, this will unify cylinder specific STPmaps
        '
        ms01 = 0
        modeabc = 0
        gear = 0

        map_structure_table = &H517B8
        Me.Text = "ECUeditor - STP map editing - STP opening"
        STPmap = False
        selectmap()
        LED_GEAR.Text = gear.ToString

    End Sub
    Private Sub parsecommands(ByVal comm As String)
        Dim c As Integer
        Dim r As Integer
        c = STPmapgrid.CurrentCell.ColumnIndex
        r = STPmapgrid.CurrentCell.RowIndex

        ' this is the user interface shortcut keys processor
        Select Case comm
            Case "*"
                MultiplySelectedCells()

            Case "/"
                DivideSelectedCells()

            Case "+"
                IncreaseSelectedCells()

            Case "-"
                DecreaseSelectedCells()

            Case "0"
                gear = 0
                selectmap()
            Case "1"
                gear = 1
                selectmap()
            Case "2"
                gear = 2
                selectmap()
            Case "3"
                gear = 3
                selectmap()
            Case "4"
                gear = 4
                selectmap()
            Case "5"
                gear = 5
                selectmap()
            Case "6"
                gear = 6
                selectmap()
            Case "f"
                map_structure_table = &H523E4
                Me.Text = "ECUeditor - STP map editing - STP FUEL adjustment"
                STPmap = True
                selectmap()
            Case "F"
                map_structure_table = &H523E4
                Me.Text = "ECUeditor - STP map editing - STP FUEL adjustment"
                STPmap = True
                selectmap()
            Case "s"
                map_structure_table = &H517B8
                Me.Text = "ECUeditor - STP map editing - STP opening"
                STPmap = False
                selectmap()
            Case "S"
                map_structure_table = &H517B8
                Me.Text = "ECUeditor - STP map editing - STP opening"
                STPmap = False
                selectmap()
            Case "a"
                modeabc = 0
                selectmap()
            Case "A"
                modeabc = 0
                selectmap()
            Case "b"
                modeabc = 1
                selectmap()
            Case "B"
                modeabc = 1
                selectmap()
            Case "c"
                modeabc = 2
                selectmap()
            Case "C"
                modeabc = 2
                selectmap()
            Case "m"
                If ms01 = 1 Then ms01 = 0 Else ms01 = 1
                selectmap()
            Case "M"
                If ms01 = 1 Then ms01 = 0 Else ms01 = 1
                selectmap()
            Case "t"
                stptrace = Not stptrace
                STPmapgrid.Item(cc, rr).Style.BackColor = Color.White
            Case "T"
                stptrace = Not stptrace
                STPmapgrid.Item(cc, rr).Style.BackColor = Color.White
            Case Chr(27)
                Me.Close()
            Case "P"
                '
                '
                '
            Case Else
                L_STPMAP.Text = Asc(comm)


        End Select
        LED_GEAR.Text = gear.ToString

    End Sub


    Private Sub STPmapgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles STPmapgrid.KeyPress

        parsecommands(e.KeyChar)

    End Sub
    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = STPmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If STPmapgrid.Item(c, r).Selected And n > 0 Then
                STPmapgrid.Item(c, r).Value = STPmapgrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)

                n = n - 1
            End If

            If c < map_number_of_columns - 1 Then
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

        n = STPmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If STPmapgrid.Item(c, r).Selected And n > 0 Then
                STPmapgrid.Item(c, r).Value = Int(STPmapgrid.Item(c, r).Value / 1.05)
                SetFlashItem(c, r)

                n = n - 1
            End If

            If c < map_number_of_columns - 1 Then
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

        n = STPmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If STPmapgrid.Item(c, r).Selected And n > 0 Then
                STPmapgrid.Item(c, r).Value = Int(STPmapgrid.Item(c, r).Value * 1.05)
                SetFlashItem(c, r)

                n = n - 1
            End If

            If c < map_number_of_columns - 1 Then
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


        n = STPmapgrid.SelectedCells.Count()

        Do While (r < (map_number_of_rows)) And n > 0

            If STPmapgrid.Item(c, r).Selected And n > 0 Then
                STPmapgrid.Item(c, r).Value = STPmapgrid.Item(c, r).Value + increase
                SetFlashItem(c, r)

                n = n - 1
            End If

            If c < map_number_of_columns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub



    Private Sub SetFlashItem(ByVal c As Integer, ByVal r As Integer)


        Dim maxval As Integer
        Dim minval As Integer
        Dim m1 As Integer


        maxval = &HFF   ' not validated from ecu, maximum value to which the map item can be set
        minval = 0   ' not validated from ecu, minimum value to which the map item can be set

        If STPmap Then
            m1 = STPmapgrid.Item(c, r).Value * 128 / 100
        Else
            m1 = STPmapgrid.Item(c, r).Value * 255 / 100
        End If

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 <= minval Then m1 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 > maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 > maxval Then m1 = maxval

        WriteFlashByte(editing_map + (1 * (c + (r * map_number_of_columns))), (m1))

        If STPmap Then
            STPmapgrid.Item(c, r).Value = CInt(m1 * 100 / 128)
        Else
            STPmapgrid.Item(c, r).Value = CInt(m1 * 100 / 255)
        End If


    End Sub



    Public Sub selectmap()
        Dim i As Integer

        '
        ' map tracing function to be disabled when map is changed
        '
        previousrow = 0

        '
        ' these are more or less global definitions for editing the maps
        '

        i = map_structure_table + (gear * 6 * 4) + (((3 * ms01) + modeabc) * 4)
        editing_map = ReadFlashLongWord(ReadFlashLongWord(i) + 12)
        rowheadingmap = ReadFlashLongWord(ReadFlashLongWord(i) + 8)
        columnheadingmap = ReadFlashLongWord(ReadFlashLongWord(i) + 4)
        map_number_of_columns = ReadFlashByte(ReadFlashLongWord(i) + 1)
        map_number_of_rows = ReadFlashByte(ReadFlashLongWord(i) + 2)

        MapVisible = Me.Text

        loadmap()


    End Sub
    Public Sub loadmap()
        '
        ' This function loads a map into a grid including map contents and heading information
        '

        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer

        i = 0
        ii = 0

        '
        ' Generate column headings
        '
        STPmapgrid.ColumnCount = map_number_of_columns
        c = 0
        Do While c < map_number_of_columns
            i = ReadFlashWord(columnheadingmap + (c * 2))
            STPmapgrid.Columns.Item(c).HeaderText = CalcK8TPS(i)
            STPmapgrid.Columns.Item(c).Width = 50
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        STPmapgrid.RowHeadersWidth = 100
        STPmapgrid.RowCount = map_number_of_rows
        r = 0
        'STPmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < map_number_of_rows)
            i = ReadFlashWord(rowheadingmap + (r * 2))
            STPmapgrid.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            STPmapgrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < map_number_of_rows)
            If STPmap Then
                STPmapgrid.Item(c, r).Value = Int(ReadFlashByte(i + editing_map) * 100 / 128)
            Else
                STPmapgrid.Item(c, r).Value = Int(ReadFlashByte(i + editing_map) * 100 / 255)

            End If


            If c < map_number_of_columns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        '
        ' Define some grid properties
        '
        STPmapgrid.AllowUserToAddRows = False
        STPmapgrid.AllowUserToDeleteRows = False
        STPmapgrid.AllowUserToOrderColumns = False
        STPmapgrid.SelectionMode = DataGridViewSelectionMode.CellSelect

        If gear = 0 Then
            L_gear.Text = "NT"
        Else
            L_gear.Text = Str(gear)
        End If
        Select Case modeabc
            Case 0
                L_mode.Text = "A"
            Case 1
                L_mode.Text = "B"
            Case 2
                L_mode.Text = "C"
            Case Else
                L_mode.Text = " "
        End Select


        L_MS.Text = Str(ms01)


    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Public Sub tracemap(ByVal g As Integer, ByVal ms As Integer, ByVal m As Integer)
        '
        ' based on enginedata show the position on the map and trace which cell is being accessed by ecu (almost)
        '
        Dim c As Integer
        Dim r As Integer



        L_STPMAP.Text = Int(STP * 100 / 255)

        If stptrace Then

            If (gear >= 0) And (gear <= 6) Then
                gear = g
            Else
                gear = 0
            End If
            If (ms >= 0) And (ms <= 1) Then
                ms01 = ms
            Else
                ms01 = 0
            End If

            If (m >= 0) And (m <= 2) Then
                modeabc = m
            Else
                modeabc = 0
            End If

            map_structure_table = &H517B8
            Me.Text = "ECUeditor - STP map editing - STP opening"

            selectmap()

            ' enable automatic map switching when tracing and datastream on

            r = map_number_of_rows
            c = map_number_of_columns

            STPmapgrid.Item(cc, rr).Style.BackColor = Color.White

            r = 0
            rr = 0
            Do While (r < map_number_of_rows - 1)
                If RPM >= rr And RPM < Int(STPmapgrid.Rows(r + 1).HeaderCell.Value) Then
                    rr = r
                    r = 256
                Else
                    r = r + 1
                    rr = Int(STPmapgrid.Rows(r).HeaderCell.Value)
                End If
            Loop

            '
            ' Process TPS maps
            '
            c = 0
            cc = 0
            If CalcTPSDec(TPS) < Val(STPmapgrid.Columns.Item(map_number_of_columns - 1).HeaderCell.Value) Then
                Do While (c < map_number_of_columns - 1)
                    If CalcTPSDec(TPS) >= cc And CalcTPSDec(TPS) < STPmapgrid.Columns.Item(c + 1).HeaderCell.Value Then
                        cc = c
                        c = 256
                    Else
                        c = c + 1
                        cc = Int(STPmapgrid.Columns.Item(c).HeaderCell.Value)
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
                STPmapgrid.Item(cc, rr).Style.BackColor = Color.Blue
            Else
            End If
        End If

    End Sub
    Private Sub STPMapgrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles STPmapgrid.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()

            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In STPmapgrid.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next

            rowIndex = STPmapgrid.CurrentCell.RowIndex

            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    value = Replace(value, ControlChars.Lf, "") ' removing extra LF - issue 38
                    If columnIndex < STPmapgrid.ColumnCount And rowIndex < STPmapgrid.RowCount Then
                        If IsNumeric(value) Then
                            STPmapgrid(columnIndex, rowIndex).Value = value
                            SetFlashItem(columnIndex, rowIndex)
                        End If
                    End If

                    columnIndex = columnIndex + 1
                Next

                rowIndex = rowIndex + 1
            Next

        End If


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        parsecommands("0")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        parsecommands("1")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        parsecommands("2")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        parsecommands("3")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        parsecommands("4")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        parsecommands("5")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        parsecommands("6")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        parsecommands("S")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        parsecommands("F")
    End Sub
End Class