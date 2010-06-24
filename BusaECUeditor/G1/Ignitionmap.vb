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

Public Class Ignitionmap
    Dim change As Integer
    Dim previousrow As Integer

    Dim IgnMapAddrA1 As Integer
    Dim IgnMapAddrB1 As Integer
    Dim IgnMapAddrA2 As Integer
    Dim IgnMapAddrB2 As Integer
    Dim IgnMapAddrA34 As Integer
    Dim IgnMapAddrB34 As Integer
    Dim IgnMapAddrA56 As Integer
    Dim IgnMapAddrB56 As Integer

    Dim ign_sub As Decimal
    Dim ign_div As Integer
    Dim ign_mul As Integer
    Dim ign_rpmcomp As Integer


    Private Function igndeg(ByVal i As Integer)
        '(CInt((i * 1.31) - 3.5) + (0.75 * RPM / 1000))
        Return CInt(i)
    End Function
    Private Sub Ignitionmap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        IgnitionMapVisible = False
    End Sub

    Private Sub Ignitionmap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        change = 1 ' default change to map when pressing +/-
        previousrow = 0
        ign_sub = 0
        ign_div = 256
        ign_mul = 66
        selectmap(1)
        IgnitionMapVisible = True

    End Sub


    Private Sub Ignitionmapgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Ignitionmapgrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = Ignitionmapgrid.CurrentCell.ColumnIndex
        r = Ignitionmapgrid.CurrentCell.RowIndex

        ' this is the user interface shortcut keys processor
        Select Case e.KeyChar
            Case "+"
                IncreaseSelectedCells()
            Case "-"
                DecreaseSelectedCells()
            Case "1"
                selectmap(1)
            Case "2"
                selectmap(2)
            Case "c"
                copy_tps_to_ms_map()
            Case Chr(27)
                Me.Close()
        End Select

    End Sub
    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim v As Integer

        Dim decrease As Integer

        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = Ignitionmapgrid.SelectedCells.Count()

        Do While (r < IgnMapRows) And (r < 42)

            If Ignitionmapgrid.Item(c, r).Selected And n > 0 Then
                Ignitionmapgrid.Item(c, r).Value = Ignitionmapgrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < IgnMapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        v = Val(T_valdiff.Text)
        v = v - 1
        If v > 0 Then
            T_valdiff.Text = "+" & Str(v)
        Else
            T_valdiff.Text = Str(v)
        End If

    End Sub

    Private Sub setCellColour(ByVal c As Integer, ByVal r As Integer)
        '
        ' this subroutine compares the cell value to the value of the flash image initially read from the disk with open file
        ' and sets cell colour aiccordingly based on that comparison
        '
        Dim diff As Decimal

        diff = (((ReadFlashByte(IgnMapAddrA + (1 * (c + (r * IgnMapColumns))))))) - (((ReadFlashByteCopy(IgnMapAddrA + (1 * (c + (r * IgnMapColumns)))))))

        Ignitionmapgrid.Item(c, r).Style.ForeColor = Color.Black
        Ignitionmapgrid.Item(c, r).Style.BackColor = Color.White
        If CInt(diff) <> 0 Then Ignitionmapgrid.Item(c, r).Style.BackColor = Color.LightGray
        If CInt(diff) < -2 Then Ignitionmapgrid.Item(c, r).Style.BackColor = Color.DarkGray
        If CInt(diff) < -5 Then Ignitionmapgrid.Item(c, r).Style.BackColor = Color.Gray
        If CInt(diff) > 2 Then Ignitionmapgrid.Item(c, r).Style.BackColor = Color.LightBlue
        If CInt(diff) > 5 Then Ignitionmapgrid.Item(c, r).Style.BackColor = Color.Blue


    End Sub
    Private Sub IncreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim v As Integer

        Dim increase As Integer

        increase = change ' this is the value how much the cell is increased when pressing "+"
        i = 0

        n = Ignitionmapgrid.SelectedCells.Count()

        Do While (r < (IgnMapRows - 1)) And (r < 42) And n > 0

            If Ignitionmapgrid.Item(c, r).Selected And n > 0 Then
                Ignitionmapgrid.Item(c, r).Value = Ignitionmapgrid.Item(c, r).Value + increase
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < IgnMapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        v = Val(T_valdiff.Text)
        v = v + 1
        If v > 0 Then
            T_valdiff.Text = "+" & Str(v)
        Else
            T_valdiff.Text = Str(v)
        End If


    End Sub


    Private Sub SetFlashItem(ByVal c As Integer, ByVal r As Integer)

        Dim diff As Integer ' diff is the falue how much it is changed compared to the visible map
        Dim m1 As Integer 'map1 new value
        Dim m2 As Integer 'map2 new value
        Dim maxval As Integer
        Dim minval As Integer

        ' The Ignitionmap values are divided by 48 which puts the figures close to millisecond/10 values
        maxval = 175   ' not validated from ecu, maximum value to which the Ignitionmap item can be set
        minval = 32   ' not validated from ecu, minimum value to which the Ignitionmap item can be set

        m1 = Ignitionmapgrid.Item(c, r).Value
        m2 = igndeg((ReadFlashByte(IgnMapAddrA + (1 * (c + (r * IgnMapColumns)))) / ign_div) * ign_mul - ign_sub)

        diff = m2 - m1

        m1 = (((CInt((ReadFlashByte(IgnMapAddrA + (1 * (c + (r * IgnMapColumns)))) / ign_div) * ign_mul - ign_sub) - diff) + ign_sub) / ign_mul * ign_div)
        m2 = (((CInt((ReadFlashByte(IgnMapAddrB + (1 * (c + (r * IgnMapColumns)))) / ign_div) * ign_mul - ign_sub) - diff) + ign_sub) / ign_mul * ign_div)

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval) Or (m2 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 < minval Then m1 = minval
        If m2 < minval Then m2 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 > maxval) Or (m2 > maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 > maxval Then m1 = maxval
        If m2 > maxval Then m1 = maxval

        '
        ' All ignitionmaps will be now flashed with the same values
        '
        WriteFlashByte(IgnMapAddrA1 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(IgnMapAddrB1 + (1 * (c + (r * IgnMapColumns))), m2)
        WriteFlashByte(IgnMapAddrA2 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(IgnMapAddrB2 + (1 * (c + (r * IgnMapColumns))), m2)
        WriteFlashByte(IgnMapAddrA34 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(IgnMapAddrB34 + (1 * (c + (r * IgnMapColumns))), m2)
        WriteFlashByte(IgnMapAddrA56 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(IgnMapAddrB56 + (1 * (c + (r * IgnMapColumns))), m2)

    End Sub

    Public Sub selectmap(ByVal map As Integer)

        ' map tracing function to be disabled when map is changed
        previousrow = 0

        Select Case map
            Case 1
                IgnMapAddrA1 = &H32D12
                IgnMapAddrB1 = &H330C4
                IgnMapAddrA2 = &H33476
                IgnMapAddrB2 = &H33828
                IgnMapAddrA34 = &H33BDA
                IgnMapAddrB34 = &H33F8C
                IgnMapAddrA56 = &H3433E
                IgnMapAddrB56 = &H346F0

                IgnMapAddrA = IgnMapAddrA56
                IgnMapAddrB = IgnMapAddrB56
                IgnMapRows = 36
                IgnMapColumns = 23
                Me.Text = "ECUeditor - Ignitionmap for all gears"
            Case 2
                IgnMapAddrA1 = &H34AA2
                IgnMapAddrB1 = &H34E54
                IgnMapAddrA2 = &H35206
                IgnMapAddrB2 = &H355B8
                IgnMapAddrA34 = &H3596A
                IgnMapAddrB34 = &H35D1C
                IgnMapAddrA56 = &H360CE
                IgnMapAddrB56 = &H36480

                IgnMapAddrA = IgnMapAddrA56
                IgnMapAddrB = IgnMapAddrB56

                IgnMapRows = 36
                IgnMapColumns = 23
                Me.Text = "ECUeditor - MS Ignitionmap for all gears"
        End Select
        IRR = 0
        ICC = 0
        loadmap()
        '
        ' Inform the user that individual gear specific ignitionmaps are now gone
        ' and copy gear 56 map to all maps
        '
        If ReadFlashWord(IgnMapAddrA56 + (IgnMapRows * IgnMapColumns) - 12) <> ReadFlashWord(IgnMapAddrA1 + (IgnMapRows * IgnMapColumns) - 12) Then
            MsgBox("Please note, from now on all gears will be using this ignitionmap when flashed", MsgBoxStyle.Information)
            copymaps()
        End If

    End Sub

    Private Sub copymaps()
        '
        ' This function will copy all the maps to be the same gear 5 maps
        '

        Dim c As Integer
        Dim r As Integer
        Dim i As Integer

        c = 0
        r = 0
        i = 0
        Do While (r < IgnMapRows) And (r < 42)

            WriteFlashByte(i + IgnMapAddrA1, (ReadFlashByte(i + IgnMapAddrA)))
            WriteFlashByte(i + IgnMapAddrB1, (ReadFlashByte(i + IgnMapAddrB)))
            WriteFlashByte(i + IgnMapAddrA2, (ReadFlashByte(i + IgnMapAddrA)))
            WriteFlashByte(i + IgnMapAddrB2, (ReadFlashByte(i + IgnMapAddrB)))
            WriteFlashByte(i + IgnMapAddrA34, (ReadFlashByte(i + IgnMapAddrA)))
            WriteFlashByte(i + IgnMapAddrB34, (ReadFlashByte(i + IgnMapAddrB)))

            If c < IgnMapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Public Sub loadmap()

        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer
        B_unify.Visible = False

        i = 0
        ii = 0

        Ignitionmapgrid.ColumnCount = IgnMapColumns
        If MapRows > 42 Then
            Ignitionmapgrid.RowCount = 42
        Else
            Ignitionmapgrid.RowCount = IgnMapRows
        End If


        c = 0
        r = 0
        Do While c < IgnMapColumns
            i = Int((ReadFlashWord(IgnMapAddrA - (2 * IgnMapRows) - (2 * IgnMapColumns) + (c * 2))) / 256) ' * 0.00152587890625)
            Ignitionmapgrid.Columns.Item(c).HeaderText = CalcTPS(i)
            Ignitionmapgrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        c = 0
        r = 0

        Ignitionmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < IgnMapRows) And (r < 42)
            Ignitionmapgrid.Rows.Item(r).HeaderCell.Value = Str((ReadFlashWord(IgnMapAddrA - (2 * IgnMapRows) + (r * 2)) / 2.56))
            Ignitionmapgrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop


        c = 0
        r = 0
        i = 0
        Do While (r < IgnMapRows) And (r < 42)

            Ignitionmapgrid.Item(c, r).Value = igndeg(ReadFlashByte((i) + IgnMapAddrA) / ign_div * ign_mul - ign_sub)
            setCellColour(c, r)
            If Not (ReadFlashWord(i + IgnMapAddrA) = ReadFlashWord(i + IgnMapAddrB)) Then
                B_unify.Visible = True
            End If

            If c < IgnMapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        Ignitionmapgrid.AllowUserToAddRows = False
        Ignitionmapgrid.AllowUserToDeleteRows = False
        Ignitionmapgrid.AllowUserToOrderColumns = False
        Ignitionmapgrid.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Sub

    Public Sub tracemap()
        Dim c As Integer
        Dim r As Integer

        setCellColour(ICC, IRR)

        ' enable automatic map switching when tracing and datastream on

        r = IgnMapRows
        c = IgnMapColumns

        r = 0
        IRR = 0
        Do While (r < IgnMapRows - 1)
            If RPM >= IRR And RPM < Int(Ignitionmapgrid.Rows(r + 1).HeaderCell.Value) Then
                IRR = r
                r = 256
            Else
                r = r + 1
                IRR = Int(Ignitionmapgrid.Rows(r).HeaderCell.Value)
            End If
        Loop

        c = 0
        ICC = 0
        If CalcTPSDec(TPS) < Val(Ignitionmapgrid.Columns.Item(IgnMapColumns - 1).HeaderCell.Value) Then
            Do While (c < IgnMapColumns - 1)
                If CalcTPSDec(TPS) >= ICC And CalcTPSDec(TPS) < Ignitionmapgrid.Columns.Item(c + 1).HeaderCell.Value Then
                    ICC = c
                    c = 256
                Else
                    c = c + 1
                    ICC = Int(Ignitionmapgrid.Columns.Item(c).HeaderCell.Value)
                End If
            Loop
        Else
            ICC = IgnMapColumns - 1
        End If

        If IRR > IgnMapRows Then IRR = 0
        If IRR < 0 Then IRR = 0
        If ICC > IgnMapColumns Then ICC = 0
        If ICC < 0 Then ICC = 0
        If IRR <> 0 Or ICC <> 0 Then
            Ignitionmapgrid.Item(ICC, IRR).Style.BackColor = Color.Blue
        Else
            setCellColour(ICC, IRR)
        End If
    End Sub
    Private Sub B_TPSMAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_IGN.Click
        selectmap(1)
    End Sub

    Private Sub B_MSTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MSIGN.Click
        selectmap(2)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub show_values()
        Dim istr As String
        Dim r As Integer
        Dim c As Integer
        Dim v As Integer

        istr = ""
        IgnRowSelected = Ignitionmapgrid.CurrentRow.Index


        Try
            If Ignitionmapgrid.CurrentRow.Index <> previousrow And previousrow <= IgnMapRows Then
                Ignitionmapgrid.CurrentRow.Height = 20
                Ignitionmapgrid.Rows.Item(previousrow).Height = 15
                previousrow = Ignitionmapgrid.CurrentRow.Index
            Else
                previousrow = Ignitionmapgrid.CurrentRow.Index
            End If

            istr = Str(Ignitionmapgrid.Columns.Item(Ignitionmapgrid.CurrentCell.ColumnIndex).HeaderCell.Value)

            T_RPM.Text = Ignitionmapgrid.CurrentRow.HeaderCell.Value & " rpm"
            T_TPSIAP.Text = "TPS = " & istr & "%"

            r = Ignitionmapgrid.CurrentRow.Index
            c = Ignitionmapgrid.CurrentCell.ColumnIndex
            v = (Int(ReadFlashByte(((((IgnMapColumns * r) + c)) + IgnMapAddrA)) / ign_div * ign_mul - ign_sub) - Int(ReadFlashByteCopy((((IgnMapColumns * r) + c)) + IgnMapAddrA) / ign_div * ign_mul - ign_sub))
            If v > 0 Then
                T_valdiff.Text = "+" & Str(v)
            Else
                T_valdiff.Text = Str(v)
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Ignitionmapgrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Ignitionmapgrid.MouseClick
        show_values()
    End Sub

    Private Sub Ignitionmapgrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Ignitionmapgrid.CellEnter
        show_values()
    End Sub


    Private Sub B_unify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_unify.Click
        If MsgBox("This will unify cylinderbank specific ignitionmaps to this map, do you agree", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            unify()
            B_unify.Visible = False
        End If
    End Sub

    Private Sub unify()
        Dim i As Integer
        i = 0

        Do While (i < (IgnMapRows * IgnMapColumns))
            WriteFlashWord((i + IgnMapAddrB), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrA1), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrB1), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrA2), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrB2), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrA34), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrB34), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrA56), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + IgnMapAddrB56), ReadFlashWord(i + IgnMapAddrA))
            i = i + 1
        Loop
        B_unify.Visible = False

    End Sub
    Private Sub copy_tps_to_ms_map()
        '
        ' This soubroutine copies the TPS map contents into MS map
        '
        Dim i As Integer
        i = MsgBox("Copy the Ignition map contents to MS map, the old MS map will be deleted", MsgBoxStyle.OkCancel)
        If i = 1 Then ' OK pressed
            i = 0
            Do While (i < (((ignmaprows) * (ignmapcolumns))))
                WriteFlashWord((i + &H34AA2), ReadFlashWord(i + &H32D12))
                WriteFlashWord((i + &H34E54), ReadFlashWord(i + &H330C4))
                WriteFlashWord((i + &H35206), ReadFlashWord(i + &H33476))
                WriteFlashWord((i + &H355B8), ReadFlashWord(i + &H33828))
                WriteFlashWord((i + &H3596A), ReadFlashWord(i + &H33BDA))
                WriteFlashWord((i + &H35D1C), ReadFlashWord(i + &H33F8C))
                WriteFlashWord((i + &H360CE), ReadFlashWord(i + &H3433E))
                WriteFlashWord((i + &H36480), ReadFlashWord(i + &H346F0))
                i = i + 1
            Loop
        End If

    End Sub

End Class