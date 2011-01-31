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

Public Class Gixxersteeringdampenermap

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
    Dim map_structure_table As Long
    Dim map_number_of_structures As Integer
    Dim map_number_of_columns, map_number_of_rows As Integer
    Dim editing_map As Long
    Dim columnheadingmap As Long
    Dim basemap As Integer
    Dim cc, rr As Integer
    Dim col As Integer = 2
    Dim cel As Integer = 2


    Private Function decode(ByVal i As Integer) As Integer
        ' return the value that is displayed on the screen
        Return CInt(100 * i / &H4000)
    End Function

    Private Function encode(ByVal i As Integer) As Integer
        ' return the value that is written to flash
        Return CInt(&H4000 * i / 100)
    End Function



    Private Sub Fuelmap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fuelmapvisible = False
    End Sub

    Private Sub Fuelmap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        change = 1 ' default change to map when pressing +,- or *,/
        previousrow = 0


        map_structure_table = &H5D840

        Me.Text = gixxer_injectorbalance_map_name & "- steering dampener map editing"
        selectmap()


    End Sub


    Private Sub Fuelmapgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SDmapgrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = SDmapgrid.CurrentCell.ColumnIndex
        r = SDmapgrid.CurrentCell.RowIndex

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
            Case Chr(27)
                Me.Close()
            Case "P"
                printthis()
            Case "p"
                printthis()
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

        n = SDmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If SDmapgrid.Item(c, r).Selected And n > 0 Then
                SDmapgrid.Item(c, r).Value = SDmapgrid.Item(c, r).Value - decrease
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

        n = SDmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If SDmapgrid.Item(c, r).Selected And n > 0 Then
                SDmapgrid.Item(c, r).Value = Int(SDmapgrid.Item(c, r).Value / 1.05)
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

        n = SDmapgrid.SelectedCells.Count()

        Do While (r < map_number_of_rows)

            If SDmapgrid.Item(c, r).Selected And n > 0 Then
                SDmapgrid.Item(c, r).Value = Int(SDmapgrid.Item(c, r).Value * 1.05)
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


        n = SDmapgrid.SelectedCells.Count()

        Do While (r <= (map_number_of_rows - 1)) And n > 0

            If SDmapgrid.Item(c, r).Selected And n > 0 Then
                SDmapgrid.Item(c, r).Value = SDmapgrid.Item(c, r).Value + increase
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


        maxval = 100   ' not validated from ecu, maximum value to which the map item can be set
        minval = 0   ' not validated from ecu, minimum value to which the map item can be set

        m1 = SDmapgrid.Item(c, r).Value

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 <= minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 <= minval Then m1 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 >= maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 >= maxval Then m1 = maxval
        If m1 = minval Or m1 = maxval Then loadmap()
        Dim i
        i = encode(m1)
        WriteFlashWord(editing_map + (c * 2), encode(m1))
        

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

        i = map_structure_table
        editing_map = ReadFlashLongWord(i + 8)
        columnheadingmap = ReadFlashLongWord(i + 4)
        map_number_of_columns = ReadFlashByte(i + 1)
        map_number_of_rows = 1

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
        SDmapgrid.ColumnCount = map_number_of_columns
        c = 0
        Do While c < map_number_of_columns
            i = ReadFlashByte(columnheadingmap + (c * col))
            SDmapgrid.Columns.Item(c).HeaderText = Int(i * 2)
            SDmapgrid.Columns.Item(c).Width = 30
            c = c + 1
        Loop

        '
        ' Generate row headings
        '

        SDmapgrid.RowHeadersWidth = 100
        SDmapgrid.RowCount = map_number_of_rows
        SDmapgrid.Rows.Item(0).HeaderCell.Value = "Duty%"
        r = 0

        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < map_number_of_rows)
            SDmapgrid.Item(c, r).Value = decode(ReadFlashWord((i * 2) + editing_map))
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
        SDmapgrid.AllowUserToAddRows = False
        SDmapgrid.AllowUserToDeleteRows = False
        SDmapgrid.AllowUserToOrderColumns = False
        SDmapgrid.SelectionMode = DataGridViewSelectionMode.CellSelect


    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class