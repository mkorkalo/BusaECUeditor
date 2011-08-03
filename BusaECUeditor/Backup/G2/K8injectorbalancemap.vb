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
Imports System.IO

Public Class K8injectorbalancemap
    '
    ' Fuelmap.vb contains all functions to edit fuelmaps in ecueditor. it uses a global variable flash(addr) that
    ' has the full ecu image loaded as byte values. the fuelmap is edited on a grid and changed values are
    ' written to the global variable flash(addr).
    '
    Dim change As Integer
    Dim previousrow As Integer
    Dim toprow(50) As Integer
    Dim TPSmap As Boolean
    Dim previouscolour As Color
    Dim gear, ms01, modeabc As Integer
    Dim fuelmap As Boolean
    Dim map_structure_table As Long
    Dim map_number_of_structures As Integer
    Dim map_number_of_columns, map_number_of_rows As Integer
    Dim editing_map As Long
    Dim rowheadingmap, columnheadingmap As Long
    Dim basemap As Integer
    Dim cc, rr As Integer
    Dim INJBALtrace As Boolean
    Dim col As Integer = 2
    Dim cel As Integer = 2


    Private Function decode(ByVal i As Integer) As Integer
        ' return the value that is displayed on the screen
        Return CInt(100 * i / &H8000)
    End Function

    Private Function encode(ByVal i As Integer) As Integer
        ' return the value that is written to flash
        Return CInt(&H8000 * i / 100)
    End Function



    Private Sub Fuelmap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fuelmapvisible = False
    End Sub

    Private Sub Fuelmap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        change = 1 ' default change to map when pressing +,- or *,/
        previousrow = 0
        fuelmapvisible = True
        INJBALtrace = False

        L_geartext.Visible = False
        L_gear.Visible = False


        '
        ' select tpsmap as first map to show, this will unify cylinder specific fuelmaps
        '
        ms01 = 0
        modeabc = 0
        gear = 0

        map_structure_table = &H5222C
        Me.Text = "ECUeditor - Injector balance map editing"
        fuelmap = False
        selectmap()


    End Sub


    Private Sub Fuelmapgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles INJBALmapgrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = INJBALmapgrid.CurrentCell.ColumnIndex
        r = INJBALmapgrid.CurrentCell.RowIndex

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
            Case "0"
                If L_gear.Visible Then
                    gear = 0
                    selectmap()
                End If
            Case "1"
                If L_gear.Visible Then
                    gear = 1
                    selectmap()
                End If
            Case "2"
                If L_gear.Visible Then
                    gear = 2
                    selectmap()
                End If
            Case "3"
                If L_gear.Visible Then
                    gear = 3
                    selectmap()
                End If
            Case "4"
                If L_gear.Visible Then
                    gear = 4
                    selectmap()
                End If
            Case "5"
                If L_gear.Visible Then
                    gear = 5
                    selectmap()
                End If
            Case "6"
                If L_gear.Visible Then
                    gear = 6
                    selectmap()
                End If
            Case "a"
                modeabc = 0
                selectmap()
            Case "A"
                modeabc = 0
                selectmap()
                'Case "b"
                '    modeabc = 1
                '    selectmap()
                'Case "B"
                '    modeabc = 1
                '    selectmap()
                'Case "c"
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
            Case Chr(27)
                Me.Close()
            Case "P"
                PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
                PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
                PrintForm1.Print()
            Case "p"
                PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
                PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
                PrintForm1.Print()
            Case Else


        End Select

    End Sub
    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = INJBALmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If INJBALmapgrid.Item(c, r).Selected And n > 0 Then
                INJBALmapgrid.Item(c, r).Value = INJBALmapgrid.Item(c, r).Value - decrease
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

        n = INJBALmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If INJBALmapgrid.Item(c, r).Selected And n > 0 Then
                INJBALmapgrid.Item(c, r).Value = Int(INJBALmapgrid.Item(c, r).Value / 1.05)
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

        n = INJBALmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If INJBALmapgrid.Item(c, r).Selected And n > 0 Then
                INJBALmapgrid.Item(c, r).Value = Int(INJBALmapgrid.Item(c, r).Value * 1.05)
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


        n = INJBALmapgrid.SelectedCells.Count()

        Do While (r < (map_number_of_rows - 1)) And n > 0

            If INJBALmapgrid.Item(c, r).Selected And n > 0 Then
                INJBALmapgrid.Item(c, r).Value = INJBALmapgrid.Item(c, r).Value + increase
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


        maxval = 255   ' not validated from ecu, maximum value to which the map item can be set
        minval = 0   ' not validated from ecu, minimum value to which the map item can be set

        m1 = INJBALmapgrid.Item(c, r).Value

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 <= minval Then m1 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 >= maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 >= maxval Then m1 = maxval

        If col = 1 Then
            WriteFlashByte(editing_map + (cel * (c + (r * map_number_of_columns))), encode(m1))
        Else
            WriteFlashWord(editing_map + (cel * (c + (r * map_number_of_columns))), encode(m1))
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

        mapvisible = Me.Text

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
        INJBALmapgrid.ColumnCount = map_number_of_columns
        c = 0
        Do While c < map_number_of_columns
            If col = 1 Then
                i = ReadFlashByte(columnheadingmap + (c * col))
            Else
                i = ReadFlashWord(columnheadingmap + (c * col))
            End If
            INJBALmapgrid.Columns.Item(c).HeaderText = CalcK8TPS(i)
            INJBALmapgrid.Columns.Item(c).Width = 50
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        INJBALmapgrid.RowHeadersWidth = 100
        INJBALmapgrid.RowCount = map_number_of_rows
        r = 0
        'INJBALmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < map_number_of_rows)

            i = ReadFlashWord(rowheadingmap + (r * 2))

            INJBALmapgrid.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            INJBALmapgrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < map_number_of_rows)
            If cel = 1 Then
                INJBALmapgrid.Item(c, r).Value = decode(ReadFlashByte((i * cel) + editing_map))
            Else
                INJBALmapgrid.Item(c, r).Value = decode(ReadFlashWord((i * cel) + editing_map))
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
        INJBALmapgrid.AllowUserToAddRows = False
        INJBALmapgrid.AllowUserToDeleteRows = False
        INJBALmapgrid.AllowUserToOrderColumns = False
        INJBALmapgrid.SelectionMode = DataGridViewSelectionMode.CellSelect

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

End Class