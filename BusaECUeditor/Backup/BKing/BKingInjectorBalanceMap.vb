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

Public Class BKingInjectorBalanceMap
    '
    ' _fuelMap.vb contains all functions to edit _fuelMaps in ecueditor. it uses a global variable flash(addr) that
    ' has the full ecu image loaded as byte values. the _fuelMap is edited on a grid and _changed values are
    ' written to the global variable flash(addr).
    '
#Region "Variables"

    Dim _change As Integer
    Dim _previousRow As Integer
    Dim _gear As Integer
    Dim _ms01 As Integer
    Dim _modeABC As Integer
    Dim _fuelMap As Boolean
    Dim _mapStructureTable As Long
    Dim _mapNumberOfColumns As Integer
    Dim _mapNumberOfRows As Integer
    Dim _editingMap As Long
    Dim _rowHeadingMap As Long
    Dim _columnHeadingMap As Long
    Dim _baseMap As Integer
    Dim _injBalTrace As Boolean
    Dim _col As Integer = 2
    Dim _cel As Integer = 2

#End Region

#Region "Form Events"

    Private Sub BKingInjectorBalanceMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _change = 1 ' default _change to map when pressing +,- or *,/
        _previousRow = 0
        fuelmapvisible = True
        _injBalTrace = False

        L_geartext.Visible = False
        L_gear.Visible = False

        ' select tpsmap as first map to show, this will unify cylinder specific _fuelMaps
        _ms01 = 0
        _modeABC = 0
        _gear = 0

        _mapStructureTable = &H54DDC
        Me.Text = "ECUeditor - Bking Injector balance map editing"
        _fuelMap = False
        SelectMap()

    End Sub

    Private Sub BKingInjectorBalanceMap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        InjBalMapGrid_KeyPress(sender, e)

    End Sub

    Private Sub BKingInjectorBalanceMap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        fuelmapvisible = False

    End Sub

#End Region

#Region "Control Events"

    Private Sub InjBalMapGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles InjBalMapGrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = InjBalMapGrid.CurrentCell.ColumnIndex
        r = InjBalMapGrid.CurrentCell.RowIndex

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

                    _gear = 0
                    SelectMap()
                End If
            Case "1"
                If L_gear.Visible Then
                    _gear = 1
                    SelectMap()
                End If
            Case "2"
                If L_gear.Visible Then
                    _gear = 2
                    SelectMap()
                End If
            Case "3"
                If L_gear.Visible Then
                    _gear = 3
                    SelectMap()
                End If
            Case "4"
                If L_gear.Visible Then
                    _gear = 4
                    SelectMap()
                End If
            Case "5"
                If L_gear.Visible Then
                    _gear = 5
                    SelectMap()
                End If
            Case "6"
                If L_gear.Visible Then
                    _gear = 6
                    SelectMap()
                End If
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

#End Region

#Region "Functions"

    Private Function Decode(ByVal i As Integer) As Integer

        ' return the value that is displayed on the screen
        Return CInt(100 * i / &H8000)

    End Function

    Private Function Encode(ByVal i As Integer) As Integer

        ' return the value that is written to flash
        Return CInt(&H8000 * i / 100)

    End Function

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = InjBalMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If InjBalMapGrid.Item(c, r).Selected And n > 0 Then
                InjBalMapGrid.Item(c, r).Value = InjBalMapGrid.Item(c, r).Value - decrease
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

        n = InjBalMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If InjBalMapGrid.Item(c, r).Selected And n > 0 Then
                InjBalMapGrid.Item(c, r).Value = Int(InjBalMapGrid.Item(c, r).Value / 1.05)
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

        n = InjBalMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If InjBalMapGrid.Item(c, r).Selected And n > 0 Then
                InjBalMapGrid.Item(c, r).Value = Int(InjBalMapGrid.Item(c, r).Value * 1.05)
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


        n = InjBalMapGrid.SelectedCells.Count()

        Do While (r < (_mapNumberOfRows - 1)) And n > 0

            If InjBalMapGrid.Item(c, r).Selected And n > 0 Then
                InjBalMapGrid.Item(c, r).Value = InjBalMapGrid.Item(c, r).Value + increase
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

        m1 = InjBalMapGrid.Item(c, r).Value

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 <= minval Then m1 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 >= maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 >= maxval Then m1 = maxval

        If _col = 1 Then
            writeflashbyte(_editingMap + (_cel * (c + (r * _mapNumberOfColumns))), Encode(m1))
        Else
            writeflashword(_editingMap + (_cel * (c + (r * _mapNumberOfColumns))), Encode(m1))
        End If

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

        i = _mapStructureTable + (_gear * 6 * 4) + (((3 * _ms01) + _modeABC) * 4)
        _editingMap = readflashlongword(readflashlongword(i) + 12)
        _rowHeadingMap = readflashlongword(readflashlongword(i) + 8)
        _columnHeadingMap = readflashlongword(readflashlongword(i) + 4)
        _mapNumberOfColumns = ReadFlashByte(readflashlongword(i) + 1)
        _mapNumberOfRows = ReadFlashByte(readflashlongword(i) + 2)

        mapvisible = Me.Text

        LoadMap()


    End Sub

    Public Sub LoadMap()

        ' This function loads a map into a grid including map contents and heading information
        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer

        i = 0
        ii = 0

        ' Generate column headings
        InjBalMapGrid.ColumnCount = _mapNumberOfColumns
        c = 0
        Do While c < _mapNumberOfColumns
            If _col = 1 Then
                i = readflashbyte(_columnHeadingMap + (c * _col))
            Else
                i = ReadFlashword(_columnHeadingMap + (c * _col))
            End If
            InjBalMapGrid.Columns.Item(c).HeaderText = CalcK8TPS(i)
            InjBalMapGrid.Columns.Item(c).Width = 50
            c = c + 1
        Loop

        ' Generate row headings
        InjBalMapGrid.RowHeadersWidth = 100
        InjBalMapGrid.RowCount = _mapNumberOfRows
        r = 0

        'INJBALmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < _mapNumberOfRows)

            i = ReadFlashword(_rowHeadingMap + (r * 2))

            InjBalMapGrid.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            InjBalMapGrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        ' Generate map contents into a grid
        c = 0
        r = 0
        i = 0
        Do While (r < _mapNumberOfRows)
            If _cel = 1 Then
                InjBalMapGrid.Item(c, r).Value = Decode(ReadFlashByte((i * _cel) + _editingMap))
            Else
                InjBalMapGrid.Item(c, r).Value = Decode(ReadFlashword((i * _cel) + _editingMap))
            End If
            If c < _mapNumberOfColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        ' Define some grid properties
        InjBalMapGrid.AllowUserToAddRows = False
        InjBalMapGrid.AllowUserToDeleteRows = False
        InjBalMapGrid.AllowUserToOrderColumns = False
        InjBalMapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect

        If _gear = 0 Then
            L_gear.Text = "NT"
        Else
            L_gear.Text = Str(_gear)
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

#End Region

End Class