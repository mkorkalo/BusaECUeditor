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

Public Class BKingSTPMap
    '
    ' Fuelmap.vb contains all functions to edit fuelmaps in ecueditor. it uses a global variable flash(addr) that
    ' has the full ecu image loaded as byte values. the fuelmap is edited on a grid and _changed values are
    ' written to the global variable flash(addr).
    '

#Region "Variables"

    Dim _change As Integer
    Dim _previousRow As Integer
    Dim _ms01 As Integer
    Dim _modeABC As Integer
    Dim _fuelmap As Boolean
    Dim _mapStructureTable As Long
    Dim _mapNumberOfColumns As Integer
    Dim _mapNumberOfRows As Integer
    Dim _editingMap As Long
    Dim _rowHeadingMap As Long
    Dim _columnHeadingMap As Long
    Dim _sTPTrace As Boolean

#End Region

#Region "Form Events"

    Private Sub BKingSTPMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _change = 1 ' default _change to map when pressing +,- or *,/
        _previousRow = 0
        fuelmapvisible = True
        _sTPTrace = False

        ' select tpsmap as first map to show, this will unify cylinder specific fuelmaps
        '
        _ms01 = 0
        _modeABC = 0
        GEAR = 0

        _mapStructureTable = &H542C8
        Me.Text = "ECUeditor - BKing STP map editing - STP opening"
        _fuelmap = False
        SelectMap()


    End Sub

    Private Sub BKingSTPMap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        STPMapGrid_KeyPress(sender, e)

    End Sub

    Private Sub BKingSTPMap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        fuelmapvisible = False

    End Sub

#End Region

#Region "Control Events"

    Private Sub STPMapGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles STPMapGrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = STPMapGrid.CurrentCell.ColumnIndex
        r = STPMapGrid.CurrentCell.RowIndex

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
                GEAR = 0
                SelectMap()
            Case "1"
                GEAR = 1
                SelectMap()
            Case "2"
                GEAR = 2
                SelectMap()
            Case "3"
                GEAR = 3
                SelectMap()
            Case "4"
                GEAR = 4
                SelectMap()
            Case "5"
                GEAR = 5
                SelectMap()
            Case "6"
                GEAR = 6
                SelectMap()
            Case "f"
                _mapStructureTable = &H54F74
                Me.Text = "ECUeditor - Bking STP map editing - STP FUEL deduction"
                _fuelmap = True
                SelectMap()
            Case "F"
                _mapStructureTable = &H54F74
                Me.Text = "ECUeditor - BKing STP map editing - STP FUEL deduction"
                _fuelmap = True
                SelectMap()
            Case "s"
                _mapStructureTable = &H542C8
                Me.Text = "ECUeditor - BKing STP map editing - STP opening"
                _fuelmap = False
                SelectMap()
            Case "S"
                _mapStructureTable = &H542C8
                Me.Text = "ECUeditor - BKing STP map editing - STP opening"
                _fuelmap = False
                SelectMap()
            Case "a"
                _modeABC = 0
                SelectMap()
            Case "A"
                _modeABC = 0
                SelectMap()
            Case "b"
                _modeABC = 1
                SelectMap()
            Case "B"
                _modeABC = 1
                SelectMap()
            Case "c"
                _modeABC = 2
                SelectMap()
            Case "C"
                _modeABC = 2
                SelectMap()
            Case "m"
                If _ms01 = 1 Then _ms01 = 0 Else _ms01 = 1
                SelectMap()
            Case "M"
                If _ms01 = 1 Then _ms01 = 0 Else _ms01 = 1
                SelectMap()
            Case "t"
                _sTPTrace = Not _sTPTrace
                STPMapGrid.Item(cc, rr).Style.BackColor = Color.White
            Case "T"
                _sTPTrace = Not _sTPTrace
                STPMapGrid.Item(cc, rr).Style.BackColor = Color.White
            Case Chr(27)
                Me.Close()
            Case "P"
                printthis()
            Case "p"
                printthis()
            Case Else
                L_STPMAP.Text = Asc(e.KeyChar)


        End Select

    End Sub

    Private Sub STPMapGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles STPMapGrid.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In STPMapGrid.SelectedCells()
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

                    value = Replace(value, ControlChars.Lf, "") ' removing extra LF - issue 38

                    If columnIndex < _mapNumberOfColumns And rowIndex < _mapNumberOfRows Then
                        If IsNumeric(value) Then
                            STPMapGrid(columnIndex, rowIndex).Value = value
                            SetFlashItem(columnIndex, rowIndex)
                        End If
                    End If

                    columnIndex = columnIndex + 1
                Next

                rowIndex = rowIndex + 1
            Next

        End If

    End Sub

#End Region

#Region "Functions"

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = STPMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If STPMapGrid.Item(c, r).Selected And n > 0 Then
                STPMapGrid.Item(c, r).Value = STPMapGrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)

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

    Private Sub DivideSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = STPMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If STPMapGrid.Item(c, r).Selected And n > 0 Then
                STPMapGrid.Item(c, r).Value = Int(STPMapGrid.Item(c, r).Value / 1.05)
                SetFlashItem(c, r)

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

    Private Sub MultiplySelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = STPMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If STPMapGrid.Item(c, r).Selected And n > 0 Then
                STPMapGrid.Item(c, r).Value = Int(STPMapGrid.Item(c, r).Value * 1.05)
                SetFlashItem(c, r)

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


        n = STPMapGrid.SelectedCells.Count()

        Do While (r < (_mapNumberOfRows - 1)) And n > 0

            If STPMapGrid.Item(c, r).Selected And n > 0 Then
                STPMapGrid.Item(c, r).Value = STPMapGrid.Item(c, r).Value + increase
                SetFlashItem(c, r)

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

        Dim maxval As Integer
        Dim minval As Integer
        Dim m1 As Integer


        maxval = 255   ' not validated from ecu, maximum value to which the map item can be set
        minval = 0   ' not validated from ecu, minimum value to which the map item can be set

        If _fuelmap Then
            m1 = STPMapGrid.Item(c, r).Value * 128 / 100
        Else
            m1 = STPMapGrid.Item(c, r).Value * 255 / 100
        End If

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval)) Then
            MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
            m1 = minval
        End If

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If (m1 > maxval) Then
            MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
            m1 = maxval
        End If

        writeflashbyte(_editingMap + (1 * (c + (r * _mapNumberOfColumns))), (m1))

    End Sub

    Public Sub SelectMap()
        Dim i As Integer

        '
        ' map tracing function to be disabled when map is _changed
        '
        _previousRow = 0

        '
        ' these are more or less global definitions for editing the maps
        '

        i = _mapStructureTable + (GEAR * 6 * 4) + (((3 * _ms01) + _modeABC) * 4)
        _editingMap = readflashlongword(readflashlongword(i) + 12)
        _rowHeadingMap = readflashlongword(readflashlongword(i) + 8)
        _columnHeadingMap = readflashlongword(readflashlongword(i) + 4)
        _mapNumberOfColumns = ReadFlashByte(readflashlongword(i) + 1)
        _mapNumberOfRows = ReadFlashByte(readflashlongword(i) + 2)

        mapvisible = Me.Text

        LoadMap()


    End Sub

    Public Sub LoadMap()
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
        STPMapGrid.ColumnCount = _mapNumberOfColumns
        c = 0
        Do While c < _mapNumberOfColumns
            i = ReadFlashword(_columnHeadingMap + (c * 2))
            STPMapGrid.Columns.Item(c).HeaderText = CalcK8TPS(i)
            STPMapGrid.Columns.Item(c).Width = 50
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        STPMapGrid.RowHeadersWidth = 100
        STPMapGrid.RowCount = _mapNumberOfRows
        r = 0
        'STPmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < _mapNumberOfRows)
            i = ReadFlashword(_rowHeadingMap + (r * 2))
            STPMapGrid.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            STPMapGrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < _mapNumberOfRows)
            If _fuelmap Then
                STPMapGrid.Item(c, r).Value = Int(readflashbyte(i + _editingMap) * 100 / 128)
            Else
                STPMapGrid.Item(c, r).Value = Int(readflashbyte(i + _editingMap) * 100 / 255)

            End If


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
        STPMapGrid.AllowUserToAddRows = False
        STPMapGrid.AllowUserToDeleteRows = False
        STPMapGrid.AllowUserToOrderColumns = False
        STPMapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect

        If GEAR = 0 Then
            L_gear.Text = "NT"
        Else
            L_gear.Text = Str(GEAR)
        End If
        Select Case _modeABC
            Case 0
                L_mode.Text = "A"
            Case 1
                L_mode.Text = "B"
            Case 2
                L_mode.Text = "C"
            Case Else
                L_mode.Text = " "
        End Select


        L_MS.Text = Str(_ms01)


    End Sub

    Public Sub TraceMap(ByVal g As Integer, ByVal ms As Integer, ByVal m As Integer)
        ' based on enginedata show the position on the map and trace which cell is being accessed by ecu (almost)
        Dim c As Integer
        Dim r As Integer

        L_STPMAP.Text = Int(STP * 100 / 255)

        If _sTPTrace Then

            If (GEAR >= 0) And (GEAR <= 6) Then
                GEAR = g
            Else
                GEAR = 0
            End If
            If (ms >= 0) And (ms <= 1) Then
                _ms01 = ms
            Else
                _ms01 = 0
            End If

            If (m >= 0) And (m <= 2) Then
                _modeABC = m
            Else
                _modeABC = 0
            End If

            _mapStructureTable = &H542C8
            Me.Text = "ECUeditor - BKing STP map editing - STP opening"

            SelectMap()

            ' enable automatic map switching when tracing and datastream on
            r = _mapNumberOfRows
            c = _mapNumberOfColumns

            STPMapGrid.Item(cc, rr).Style.BackColor = Color.White

            r = 0
            rr = 0
            Do While (r < _mapNumberOfRows - 1)
                If RPM >= rr And RPM < Int(STPMapGrid.Rows(r + 1).HeaderCell.Value) Then
                    rr = r
                    r = 256
                Else
                    r = r + 1
                    rr = Int(STPMapGrid.Rows(r).HeaderCell.Value)
                End If
            Loop

            '
            ' Process TPS maps
            '
            c = 0
            cc = 0
            If CalcTPSDec(TPS) < Val(STPMapGrid.Columns.Item(_mapNumberOfColumns - 1).HeaderCell.Value) Then
                Do While (c < _mapNumberOfColumns - 1)
                    If CalcTPSDec(TPS) >= cc And CalcTPSDec(TPS) < STPMapGrid.Columns.Item(c + 1).HeaderCell.Value Then
                        cc = c
                        c = 256
                    Else
                        c = c + 1
                        cc = Int(STPMapGrid.Columns.Item(c).HeaderCell.Value)
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
                STPMapGrid.Item(cc, rr).Style.BackColor = Color.Blue
            Else
            End If
        End If

    End Sub

#End Region

End Class