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
Public Class BKingIgnitionMap
    '
    ' K8Ignitionmap.vb contains all functions to edit ignitionmaps in ecueditor. it uses a global variable flash(addr) that
    ' has the full ecu image loaded as byte values. the fuelmap is edited on a grid and _changed values are
    ' written to the global variable flash(addr).
    '
#Region "Variables"

    Dim _change As Integer
    Dim _previousRow As Integer
    Dim _mapStructureTable As Long
    Dim _mapNumberOfColumns As Integer
    Dim _mapNumberOfRows As Integer
    Dim _editingMap As Long
    Dim _baseMap As Integer
    
#End Region

#Region "Form Events"

    Private Sub BKingIgnitionMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _change = 1 ' default _change to map when pressing +,- or *,/
        _previousRow = 0
        fuelmapvisible = True

        If readflashbyte(&H74388) <> 0 Then
            '
            ' First ask the user if the user wants to have ignition restrictions removed
            '
            If (MsgBox("Ignition unitfy, if you press OK then only using group1 maps for all gears and modes.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then

                '
                ' First make sure that only ignition group3 is used for tuning
                '
                writeflashbyte(&H74389 + 1, 1)
                writeflashbyte(&H74389 + 2, 1)
                writeflashbyte(&H74389 + 3, 1)
                writeflashbyte(&H74389 + 4, 1)
                writeflashbyte(&H74389 + 5, 1)
                writeflashbyte(&H74389 + 6, 1)
                '
                ' Make clutch map to use the same ignition map as for other gears too
                '
                writeflashbyte(&H74388, 0)
            Else
                '
                ' Giving canlel as answer to question about removing ignition resrictions now means that the ignition tuning shall not be used...
                '
                Me.Close()
            End If

        End If


        '
        ' select tpsmap as first map to show, this will unify cylinder specific fuelmaps
        '
        SelectMap(1)
        Ignitionmapvisible = True

    End Sub

    Private Sub BKingIgnitionMap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Ignitionmapvisible = False

    End Sub

#End Region

#Region "Control Events"

    Private Sub Ignitionmapgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IgnitionMapGrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = IgnitionMapGrid.CurrentCell.ColumnIndex
        r = IgnitionMapGrid.CurrentCell.RowIndex

        '
        ' This is the user interface shortcut keys processor.
        '
        Select Case e.KeyChar
            Case "+"
                IncreaseSelectedCells()
                ShowValues()
            Case "-"
                DecreaseSelectedCells()
                ShowValues()
            Case "0"
                SelectMap(1)
            Case "1"
                SelectMap(2)
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

        End Select

    End Sub

    Private Sub Ignitionmapgrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IgnitionMapGrid.MouseClick

        ShowValues()

    End Sub

    Private Sub Ignitionmapgrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles IgnitionMapGrid.CellEnter

        ShowValues()

    End Sub

    Private Sub Ignitionmapgrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles IgnitionMapGrid.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In IgnitionMapGrid.SelectedCells()
                If cell.RowIndex < rowIndex Then
                    rowIndex = cell.RowIndex
                End If

                If cell.ColumnIndex < columnStartIndex Then
                    columnStartIndex = cell.ColumnIndex
                End If
            Next

            lines = Clipboard.GetText().Split(ControlChars.CrLf)

            For Each line As String In lines
                Dim columnIndex As Integer
                Dim values As String()

                values = line.Split(ControlChars.Tab)
                columnIndex = columnStartIndex

                For Each value As String In values
                    If columnIndex < _mapNumberOfColumns And rowIndex < _mapNumberOfRows Then
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

    Private Sub B_MS0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MS0.Click

        SelectMap(1)

    End Sub

    Private Sub B_MS1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MS1.Click

        SelectMap(2)

    End Sub

#End Region

#Region "Functions"

    Public Function K8IgnDeg(ByVal i As Integer)

        Dim tmp As Integer
        tmp = (0.4 * i) - 12.5
        Return CInt(tmp)

    End Function

    Private Function K8IgnDegToECUVal(ByVal i As Integer)

        Dim tmp As Integer
        tmp = (i + 12.5) / 0.4

        If tmp > &HFF Then
            tmp = &HFF
            MsgBox("Mamixum value exceeded, using maximum value")

        End If

        Return CInt(tmp)

    End Function

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer

        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = IgnitionMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If IgnitionMapGrid.Item(c, r).Selected And n > 0 Then
                IgnitionMapGrid.Item(c, r).Value = IgnitionMapGrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)
                SetCellColour(c, r)
                n = n - 1
            End If

            If c < _mapNumberOfColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop
    End Sub

    Private Sub SetCellColour(ByVal c As Integer, ByVal r As Integer)
        '
        ' this subroutine compares the cell value to the value of the flash image initially read from the disk with open file
        ' and sets cell colour accordingly based on that comparison
        '
        Dim diff As Decimal

        diff = K8IgnDeg(((ReadFlashByte(_editingMap + (1 * (c + (r * _mapNumberOfColumns))))))) - K8IgnDeg(((ReadFlashBytecopy(_editingMap + (1 * (c + (r * _mapNumberOfColumns)))))))

        IgnitionMapGrid.Item(c, r).Style.ForeColor = Color.Black
        If Me.Text.Contains("TPS") And c < 11 Then IgnitionMapGrid.Item(c, r).Style.ForeColor = Color.Gray
        IgnitionMapGrid.Item(c, r).Style.BackColor = Color.White
        If CInt(diff) <= -1 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.Yellow
        If CInt(diff) <= -2 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.Pink
        If CInt(diff) <= -5 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.Red
        If CInt(diff) >= 1 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.LightGreen
        If CInt(diff) >= 2 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.YellowGreen
        If CInt(diff) >= 5 Then IgnitionMapGrid.Item(c, r).Style.BackColor = Color.Green


    End Sub

    Private Sub IncreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim increase As Integer

        increase = _change ' this is the value how much the cell is increased when pressing "+"
        i = 0
        r = 0
        c = 0


        n = IgnitionMapGrid.SelectedCells.Count()

        Do While (r < (_mapNumberOfRows - 1)) And n > 0

            If IgnitionMapGrid.Item(c, r).Selected And n > 0 Then
                IgnitionMapGrid.Item(c, r).Value = IgnitionMapGrid.Item(c, r).Value + increase
                SetFlashItem(c, r)
                SetCellColour(c, r)
                n = n - 1
            End If

            If c < _mapNumberOfColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop
    End Sub

    Private Sub SetFlashItem(ByVal c As Integer, ByVal r As Integer)

        Dim diff As Integer ' diff is the falue how much it is _changed compared to the visible map
        Dim m1 As Integer 'map new value
        Dim m2 As Integer 'map2 new value
        Dim maxval As Integer
        Dim minval As Integer
        Dim ms01, cylinder, modeabc As Integer
        Dim number_of_columns As Integer
        Dim copy_to_map As Long

        maxval = 89   ' not validated from ecu, maximum value to which the Ignitionmap item can be set
        minval = 1   ' not validated from ecu, minimum value to which the Ignitionmap item can be set

        m1 = IgnitionMapGrid.Item(c, r).Value
        m2 = K8IgnDeg((ReadFlashByte(_editingMap + (1 * (c + (r * _mapNumberOfColumns))))))

        diff = m2 - m1


        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval) Or (m2 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 < minval Then m1 = minval
        If m2 < minval Then m1 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 > maxval) Or (m2 > maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 > maxval Then m1 = maxval
        If m2 > maxval Then m1 = maxval

        '
        ' All maps will be now flashed with the same map value from the screen
        ' first converted to ecu value
        '

        If Me.Text.Contains("MS") Then
            '
            ' Only MS maps will be copied
            '
            cylinder = 1        ' 0,1,2,3
            ms01 = 1            ' 0,1
            modeabc = 0         ' 0,1,2
            number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            For cylinder = 0 To 3
                For ms01 = 1 To 1
                    For modeabc = 0 To 2
                        copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashByte(copy_to_map + (1 * (c + (r * number_of_columns))), K8IgnDegToECUVal(m1))
                    Next
                Next
            Next
        Else
            '
            ' Only Normal TPS maps will be copied
            '
            cylinder = 1        ' 0,1,2,3
            ms01 = 0            ' 0,1
            modeabc = 0         ' 0,1,2
            number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            For cylinder = 0 To 3
                For ms01 = 0 To 0
                    For modeabc = 0 To 2
                        copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashByte(copy_to_map + (1 * (c + (r * number_of_columns))), K8IgnDegToECUVal(m1))
                    Next
                Next
            Next
        End If
    End Sub

    Private Sub CopyMaps(ByVal i As Integer)
        '
        ' copy map contents to all cylinders and modeABC groups, depending on parameter only ms0 or ms1 or both ms0 and ms1
        '
        Dim number_of_columns, number_of_rows As Integer
        Dim copy_from_map, copy_to_map As Long
        Dim cylinder As Integer
        Dim modeabc As Integer
        Dim ms01 As Integer
        Dim cell As Integer
        Dim a, b As Integer

        Select Case i
            Case 0
                '
                ' only ms0 maps
                '
                a = 0
                b = 0
            Case 1
                '
                ' only ms1 map
                '
                a = 1
                b = 1
            Case 2
                '
                ' both ms0 and ms1 maps
                '
                a = 0
                b = 1
        End Select

        '
        ' This function will copy all the maps to be the same maps when
        ' starting to edit the fuel maps for the first time
        '
        '
        ' First define which map is used as a base map to copy from
        '
        cylinder = 1        ' 0,1,2,3
        ms01 = a            ' 0,1
        modeabc = 0         ' 0,1,2
        copy_from_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        number_of_rows = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        '
        ' Now copy the map contents for selected mode ms0 or ms1
        '
        For cylinder = 0 To 3
            For ms01 = a To b
                For modeabc = 0 To 2
                    copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                    For cell = 0 To ((number_of_columns - 1) * (number_of_rows - 1))
                        WriteFlashByte(copy_to_map + (1 * cell), ReadFlashByte(copy_from_map + (1 * cell)))
                    Next
                Next
            Next
        Next

    End Sub

    Public Sub LoadMap(ByVal ms01 As Integer)
        '
        ' This function loads a map into a grid including map contents and heading information
        '

        Dim columnheading_map, rowheading_map As Integer
        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer
        Dim cylinder, modeabc As Integer
        i = 0
        ii = 0

        '
        ' Fastflash mode in Bking not supported
        '
        'If (ReadFlashLongWord(&H549F4) <> &H566E8) And (ms01 = 1) Then
        'MsgBox("Please note that ms mode maps are flashed only when using full flashing. You need to _change flashmode.")
        'End If

        '
        ' Select which map is being used as a _baseMap for editing
        '
        cylinder = 1        ' 0,1,2,3
        modeabc = 0         ' 0,1,2
        columnheading_map = readflashlongword(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 4)
        rowheading_map = readflashlongword(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 8)
        _editingMap = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)

        '
        ' Generate column headings
        '
        IgnitionMapGrid.ColumnCount = _mapNumberOfColumns
        c = 0
        Do While c < _mapNumberOfColumns
            i = ReadFlashWord(columnheading_map + (c * 2))
            IgnitionMapGrid.Columns.Item(c).HeaderText = CalcK8TPS(i)
            IgnitionMapGrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        IgnitionMapGrid.RowCount = _mapNumberOfRows
        r = 0
        IgnitionMapGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < _mapNumberOfRows)
            i = ReadFlashWord(rowheading_map + (r * 2))
            IgnitionMapGrid.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            IgnitionMapGrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < _mapNumberOfRows)

            IgnitionMapGrid.Item(c, r).Value = K8IgnDeg(ReadFlashByte((i * 1) + _editingMap))
            SetCellColour(c, r)

            If c < _mapNumberOfColumns - 1 Then
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
        IgnitionMapGrid.AllowUserToAddRows = False
        IgnitionMapGrid.AllowUserToDeleteRows = False
        IgnitionMapGrid.AllowUserToOrderColumns = False
        IgnitionMapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect

        '
        ' 
        '
        If Me.Text.Contains("MS") Then
            CopyMaps(1)
        Else
            CopyMaps(0)
        End If


    End Sub

    Public Sub TraceMap()
        '
        ' based on enginedata show the position on the map and trace which cell is being accessed by ecu (almost)
        '
        Dim c As Integer
        Dim r As Integer

        '
        ' Lets select the map based on MS switch position for tracing and make sure that the correct map is visible when tracing
        '
        If Me.Text.Contains("MS") And MS = 0 Then
            SelectMap(MS + 1)
        End If
        If (Not Me.Text.Contains("MS")) And MS = 1 Then
            SelectMap(MS + 1)
        End If

        SetCellColour(cc, rr)

        ' enable automatic map switching when tracing and datastream on

        r = _mapNumberOfRows
        c = _mapNumberOfColumns

        r = 0
        rr = 0

        Do While (r < _mapNumberOfRows - 1)
            If RPM >= rr And RPM < Int(IgnitionMapGrid.Rows(r + 1).HeaderCell.Value) Then
                rr = r
                r = 256
            Else
                r = r + 1
                rr = Int(IgnitionMapGrid.Rows(r).HeaderCell.Value)
            End If
        Loop


        '
        ' Process TPS maps
        '
        c = 0
        cc = 0
        If CalcTPSDec(TPS) < Val(IgnitionMapGrid.Columns.Item(_mapNumberOfColumns - 1).HeaderCell.Value) Then
            Do While (c < _mapNumberOfColumns - 1)
                If CalcTPSDec(TPS) >= cc And CalcTPSDec(TPS) < IgnitionMapGrid.Columns.Item(c + 1).HeaderCell.Value Then
                    cc = c
                    c = 256
                Else
                    c = c + 1
                    cc = Int(IgnitionMapGrid.Columns.Item(c).HeaderCell.Value)
                End If
            Loop
        Else
            cc = _mapNumberOfColumns - 1
        End If

        If rr > _mapNumberOfRows Then rr = 0
        If rr < 0 Then rr = 0
        If cc > _mapNumberOfColumns Then cc = 0
        If cc < 0 Then cc = 0
        If rr <> 0 Or cc <> 0 Then
            IgnitionMapGrid.Item(cc, rr).Style.BackColor = Color.Blue
        Else
            SetCellColour(cc, rr)
        End If
    End Sub

    Private Sub ShowValues()
        Dim istr As String
        Dim r As Integer
        Dim c As Integer
        Dim diff As Integer

        istr = ""

        IgnRowSelected = IgnitionMapGrid.CurrentRow.Index

        Try
            istr = Str(IgnitionMapGrid.Columns.Item(IgnitionMapGrid.CurrentCell.ColumnIndex).HeaderCell.Value)

            T_RPM.Text = IgnitionMapGrid.CurrentRow.HeaderCell.Value & " rpm"
            T_TPSIAP.Text = "TPS = " & istr & "%"

            r = IgnitionMapGrid.CurrentRow.Index
            c = IgnitionMapGrid.CurrentCell.ColumnIndex

            diff = K8IgnDeg(((ReadFlashByte(_editingMap + (1 * (c + (r * _mapNumberOfColumns))))))) - K8IgnDeg(((ReadFlashByteCopy(_editingMap + (1 * (c + (r * _mapNumberOfColumns)))))))

            T_DEG.Text = Str(diff)

        Catch ex As Exception
        End Try

    End Sub

    Public Sub SelectMap(ByVal map As Integer)
        Dim cylinder, ms01, modeabc As Integer
        '
        ' map tracing function to be disabled when map is _changed
        '
        _previousRow = 0
        '
        ' We assume that ecu is programmed into just using group3 ignition maps. Thats how ecueditor is set
        ' when programming the ecu. If .bin is edited with another methods it may destroy the integrity
        ' of how Ecueditor assumes .bin being built.
        '
        Select Case map
            Case 1
                _mapStructureTable = &H549F4 'group1
                Me.Text = "ECUeditor - Ignition TPS/RPM map"
                ms01 = 0            ' 0,1
            Case 2
                _mapStructureTable = &H549F4
                Me.Text = "ECUeditor - Ignition MS TPS/RPM map"
                ms01 = 1            ' 0,1
        End Select
        rr = 0
        cc = 0

        '
        ' these are more or less global definitions for editing the maps
        '
        cylinder = 1        ' 0,1,2,3
        modeabc = 0         ' 0,1,2
        _editingMap = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        _mapNumberOfColumns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        _mapNumberOfRows = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        '
        ' Initialize map type selected. CopyMaps unifies cylinders and modeABC maps. LoadMap brings the map visible.
        '
        If Me.Text.Contains("MS") Then
            LoadMap(1)
            CopyMaps(1)
        Else
            LoadMap(0)
            CopyMaps(0)
        End If

        mapvisible = Me.Text

    End Sub

#End Region

#Region "Not Used"

    Private Sub B_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        PrintForm1.Print()

    End Sub

#End Region

End Class