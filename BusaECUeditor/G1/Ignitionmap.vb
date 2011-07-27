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

Public Class IgnitionMap

#Region "Variables"

    Dim _change As Integer
    Dim _previousRow As Integer

    Dim _ignMapAddrA1 As Integer
    Dim _ignMapAddrB1 As Integer
    Dim _ignMapAddrA2 As Integer
    Dim _ignMapAddrB2 As Integer
    Dim _ignMapAddrA34 As Integer
    Dim _ignMapAddrB34 As Integer
    Dim _ignMapAddrA56 As Integer
    Dim _ignMapAddrB56 As Integer

    Dim _ignSub As Decimal
    Dim _ignDiv As Integer
    Dim _ignMul As Integer
    Dim _ignRpmComp As Integer

#End Region

#Region "Form Events"

    Private Sub IgnitionMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _change = 1 ' default _change to map when pressing +/-
        _previousRow = 0
        _ignSub = 0
        _ignDiv = 256
        _ignMul = 66
        SelectMap(1)
        IgnitionMapVisible = True

    End Sub

    Private Sub IgnitionMap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        IgnitionMapVisible = False
    End Sub

#End Region

#Region "Control Events"

    Private Sub IgnitionMapGrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IgnitionMapGrid.MouseClick
        ShowValues()
    End Sub

    Private Sub IgnitionMapGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IgnitionMapGrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = IgnitionMapGrid.CurrentCell.ColumnIndex
        r = IgnitionMapGrid.CurrentCell.RowIndex

        ' this is the user interface shortcut keys processor
        Select Case e.KeyChar
            Case "+"
                IncreaseSelectedCells()
            Case "-"
                DecreaseSelectedCells()
            Case "1"
                SelectMap(1)
            Case "2"
                SelectMap(2)
            Case "c"
                CopyTpsToMsMap()
            Case Chr(27)
                Me.Close()
        End Select

    End Sub

    Private Sub IgnitionMapGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles IgnitionMapGrid.CellEnter
        ShowValues()
    End Sub

    Private Sub B_TPSMAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_IGN.Click
        SelectMap(1)
    End Sub

    Private Sub B_MSTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MSIGN.Click
        SelectMap(2)
    End Sub

    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click
        Me.Close()
    End Sub

    Private Sub B_Unify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Unify.Click
        If MsgBox("This will unify cylinderbank specific ignitionmaps to this map, do you agree", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Unify()
            B_Unify.Visible = False
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim v As Integer

        Dim decrease As Integer

        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = IgnitionMapGrid.SelectedCells.Count()

        Do While (r < IgnMapRows) And (r < 42)

            If IgnitionMapGrid.Item(c, r).Selected And n > 0 Then
                IgnitionMapGrid.Item(c, r).Value = IgnitionMapGrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)
                SetCellColour(c, r)
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

    Private Sub SetCellColour(ByVal c As Integer, ByVal r As Integer)
        '
        ' this subroutine compares the cell value to the value of the flash image initially read from the disk with open file
        ' and sets cell colour aiccordingly based on that comparison
        '
        Dim diff As Decimal

        diff = (((ReadFlashByte(IgnMapAddrA + (1 * (c + (r * IgnMapColumns))))))) - (((ReadFlashByteCopy(IgnMapAddrA + (1 * (c + (r * IgnMapColumns)))))))

        IgnitionMapGrid.Item(c, r).Style.ForeColor = Color.Black
        IgnitionMapGrid.Item(c, r).Style.BackColor = Color.White
        If CInt(diff) <> 0 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.LightGray
        If CInt(diff) < -2 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.DarkGray
        If CInt(diff) < -5 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.Gray
        If CInt(diff) > 2 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.LightBlue
        If CInt(diff) > 5 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.Blue


    End Sub

    Private Sub IncreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim v As Integer

        Dim increase As Integer

        increase = _change ' this is the value how much the cell is increased when pressing "+"
        i = 0

        n = IgnitionMapGrid.SelectedCells.Count()

        Do While (r < (IgnMapRows - 1)) And (r < 42) And n > 0

            If IgnitionMapGrid.Item(c, r).Selected And n > 0 Then
                IgnitionMapGrid.Item(c, r).Value = IgnitionMapGrid.Item(c, r).Value + increase
                SetFlashItem(c, r)
                SetCellColour(c, r)
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

        Dim diff As Integer ' diff is the falue how much it is _changed compared to the visible map
        Dim m1 As Integer 'map1 new value
        Dim m2 As Integer 'map2 new value
        Dim maxval As Integer
        Dim minval As Integer

        ' The Ignitionmap values are divided by 48 which puts the figures close to millisecond/10 values
        maxval = 175   ' not validated from ecu, maximum value to which the Ignitionmap item can be set
        minval = 32   ' not validated from ecu, minimum value to which the Ignitionmap item can be set

        m1 = IgnitionMapGrid.Item(c, r).Value
        m2 = IgnDeg((ReadFlashByte(IgnMapAddrA + (1 * (c + (r * IgnMapColumns)))) / _ignDiv) * _ignMul - _ignSub)

        diff = m2 - m1

        m1 = (((CInt((ReadFlashByte(IgnMapAddrA + (1 * (c + (r * IgnMapColumns)))) / _ignDiv) * _ignMul - _ignSub) - diff) + _ignSub) / _ignMul * _ignDiv)
        m2 = (((CInt((ReadFlashByte(IgnMapAddrB + (1 * (c + (r * IgnMapColumns)))) / _ignDiv) * _ignMul - _ignSub) - diff) + _ignSub) / _ignMul * _ignDiv)

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
        WriteFlashByte(_ignMapAddrA1 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(_ignMapAddrB1 + (1 * (c + (r * IgnMapColumns))), m2)
        WriteFlashByte(_ignMapAddrA2 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(_ignMapAddrB2 + (1 * (c + (r * IgnMapColumns))), m2)
        WriteFlashByte(_ignMapAddrA34 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(_ignMapAddrB34 + (1 * (c + (r * IgnMapColumns))), m2)
        WriteFlashByte(_ignMapAddrA56 + (1 * (c + (r * IgnMapColumns))), m1)
        WriteFlashByte(_ignMapAddrB56 + (1 * (c + (r * IgnMapColumns))), m2)

    End Sub

    Public Sub SelectMap(ByVal map As Integer)

        ' map tracing function to be disabled when map is _changed
        _previousRow = 0

        Select Case map
            Case 1
                _ignMapAddrA1 = &H32D12
                _ignMapAddrB1 = &H330C4
                _ignMapAddrA2 = &H33476
                _ignMapAddrB2 = &H33828
                _ignMapAddrA34 = &H33BDA
                _ignMapAddrB34 = &H33F8C
                _ignMapAddrA56 = &H3433E
                _ignMapAddrB56 = &H346F0

                IgnMapAddrA = _ignMapAddrA56
                IgnMapAddrB = _ignMapAddrB56
                IgnMapRows = 36
                IgnMapColumns = 23
                Me.Text = "ECUeditor - Ignitionmap for all gears"
            Case 2
                _ignMapAddrA1 = &H34AA2
                _ignMapAddrB1 = &H34E54
                _ignMapAddrA2 = &H35206
                _ignMapAddrB2 = &H355B8
                _ignMapAddrA34 = &H3596A
                _ignMapAddrB34 = &H35D1C
                _ignMapAddrA56 = &H360CE
                _ignMapAddrB56 = &H36480

                IgnMapAddrA = _ignMapAddrA56
                IgnMapAddrB = _ignMapAddrB56

                IgnMapRows = 36
                IgnMapColumns = 23
                Me.Text = "ECUeditor - MS Ignitionmap for all gears"
        End Select
        IRR = 0
        ICC = 0
        LoadMap()
        '
        ' Inform the user that individual gear specific ignitionmaps are now gone
        ' and copy gear 56 map to all maps
        '
        If ReadFlashWord(_ignMapAddrA56 + (IgnMapRows * IgnMapColumns) - 12) <> ReadFlashWord(_ignMapAddrA1 + (IgnMapRows * IgnMapColumns) - 12) Then
            MsgBox("Please note, from now on all gears will be using this ignitionmap when flashed", MsgBoxStyle.Information)
            CopyMaps()
        End If

    End Sub

    Private Sub CopyMaps()
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

            WriteFlashByte(i + _ignMapAddrA1, (ReadFlashByte(i + IgnMapAddrA)))
            WriteFlashByte(i + _ignMapAddrB1, (ReadFlashByte(i + IgnMapAddrB)))
            WriteFlashByte(i + _ignMapAddrA2, (ReadFlashByte(i + IgnMapAddrA)))
            WriteFlashByte(i + _ignMapAddrB2, (ReadFlashByte(i + IgnMapAddrB)))
            WriteFlashByte(i + _ignMapAddrA34, (ReadFlashByte(i + IgnMapAddrA)))
            WriteFlashByte(i + _ignMapAddrB34, (ReadFlashByte(i + IgnMapAddrB)))

            If c < IgnMapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Public Sub LoadMap()

        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer
        B_Unify.Visible = False

        i = 0
        ii = 0

        IgnitionMapGrid.ColumnCount = IgnMapColumns
        If MapRows > 42 Then
            IgnitionMapGrid.RowCount = 42
        Else
            IgnitionMapGrid.RowCount = IgnMapRows
        End If


        c = 0
        r = 0
        Do While c < IgnMapColumns
            i = Int((ReadFlashWord(IgnMapAddrA - (2 * IgnMapRows) - (2 * IgnMapColumns) + (c * 2))) / 256) ' * 0.00152587890625)
            IgnitionMapGrid.Columns.Item(c).HeaderText = CalcTPS(i)
            IgnitionMapGrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        c = 0
        r = 0

        IgnitionMapGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < IgnMapRows) And (r < 42)
            IgnitionMapGrid.Rows.Item(r).HeaderCell.Value = Str((ReadFlashWord(IgnMapAddrA - (2 * IgnMapRows) + (r * 2)) / 2.56))
            IgnitionMapGrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop


        c = 0
        r = 0
        i = 0
        Do While (r < IgnMapRows) And (r < 42)

            IgnitionMapGrid.Item(c, r).Value = IgnDeg(ReadFlashByte((i) + IgnMapAddrA) / _ignDiv * _ignMul - _ignSub)
            SetCellColour(c, r)
            If Not (ReadFlashWord(i + IgnMapAddrA) = ReadFlashWord(i + IgnMapAddrB)) Then
                B_Unify.Visible = True
            End If

            If c < IgnMapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        IgnitionMapGrid.AllowUserToAddRows = False
        IgnitionMapGrid.AllowUserToDeleteRows = False
        IgnitionMapGrid.AllowUserToOrderColumns = False
        IgnitionMapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Sub

    Public Sub TraceMap()
        Dim c As Integer
        Dim r As Integer

        SetCellColour(ICC, IRR)

        ' enable automatic map switching when tracing and datastream on

        r = IgnMapRows
        c = IgnMapColumns

        r = 0
        IRR = 0
        Do While (r < IgnMapRows - 1)
            If RPM >= IRR And RPM < Int(IgnitionMapGrid.Rows(r + 1).HeaderCell.Value) Then
                IRR = r
                r = 256
            Else
                r = r + 1
                IRR = Int(IgnitionMapGrid.Rows(r).HeaderCell.Value)
            End If
        Loop

        c = 0
        ICC = 0
        If CalcTPSDec(TPS) < Val(IgnitionMapGrid.Columns.Item(IgnMapColumns - 1).HeaderCell.Value) Then
            Do While (c < IgnMapColumns - 1)
                If CalcTPSDec(TPS) >= ICC And CalcTPSDec(TPS) < IgnitionMapGrid.Columns.Item(c + 1).HeaderCell.Value Then
                    ICC = c
                    c = 256
                Else
                    c = c + 1
                    ICC = Int(IgnitionMapGrid.Columns.Item(c).HeaderCell.Value)
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
            IgnitionMapGrid.Item(ICC, IRR).Style.BackColor = Color.Blue
        Else
            SetCellColour(ICC, IRR)
        End If
    End Sub

    Private Function IgnDeg(ByVal i As Integer)
        '(CInt((i * 1.31) - 3.5) + (0.75 * RPM / 1000))
        Return CInt(i)
    End Function

    Private Sub ShowValues()
        Dim istr As String
        Dim r As Integer
        Dim c As Integer
        Dim v As Integer

        istr = ""
        IgnRowSelected = IgnitionMapGrid.CurrentRow.Index


        Try
            If IgnitionMapGrid.CurrentRow.Index <> _previousRow And _previousRow <= IgnMapRows Then
                IgnitionMapGrid.CurrentRow.Height = 20
                IgnitionMapGrid.Rows.Item(_previousRow).Height = 15
                _previousRow = IgnitionMapGrid.CurrentRow.Index
            Else
                _previousRow = IgnitionMapGrid.CurrentRow.Index
            End If

            istr = Str(IgnitionMapGrid.Columns.Item(IgnitionMapGrid.CurrentCell.ColumnIndex).HeaderCell.Value)

            T_RPM.Text = IgnitionMapGrid.CurrentRow.HeaderCell.Value & " rpm"
            T_TPSIAP.Text = "TPS = " & istr & "%"

            r = IgnitionMapGrid.CurrentRow.Index
            c = IgnitionMapGrid.CurrentCell.ColumnIndex
            v = (Int(ReadFlashByte(((((IgnMapColumns * r) + c)) + IgnMapAddrA)) / _ignDiv * _ignMul - _ignSub) - Int(ReadFlashByteCopy((((IgnMapColumns * r) + c)) + IgnMapAddrA) / _ignDiv * _ignMul - _ignSub))
            If v > 0 Then
                T_valdiff.Text = "+" & Str(v)
            Else
                T_valdiff.Text = Str(v)
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Unify()
        Dim i As Integer
        i = 0

        Do While (i < (IgnMapRows * IgnMapColumns))
            WriteFlashWord((i + IgnMapAddrB), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrA1), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrB1), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrA2), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrB2), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrA34), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrB34), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrA56), ReadFlashWord(i + IgnMapAddrA))
            WriteFlashWord((i + _ignMapAddrB56), ReadFlashWord(i + IgnMapAddrA))
            i = i + 1
        Loop
        B_Unify.Visible = False

    End Sub

    Private Sub CopyTpsToMsMap()
        '
        ' This soubroutine copies the TPS map contents into MS map
        '
        Dim i As Integer
        i = MsgBox("Copy the Ignition map contents to MS map, the old MS map will be deleted", MsgBoxStyle.OkCancel)
        If i = 1 Then ' OK pressed
            i = 0
            Do While (i < (((IgnMapRows) * (IgnMapColumns))))
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
    Private Sub Ignitionmapgrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles IgnitionMapGrid.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In Ignitionmapgrid.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next



            rowIndex = Ignitionmapgrid.CurrentCell.RowIndex

            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    value = Replace(value, ControlChars.Lf, "") ' removing extra LF - issue 38
                    If columnIndex < IgnMapColumns And rowIndex < IgnMapRows Then
                        If IsNumeric(value) Then
                            IgnitionMapGrid(columnIndex, rowIndex).Value = value
                            SetFlashItem(columnIndex, rowIndex)
                            SetCellColour(columnIndex, rowIndex)
                        End If
                    End If

                    columnIndex = columnIndex + 1
                Next

                rowIndex = rowIndex + 1
            Next

        End If
    End Sub

#End Region

End Class