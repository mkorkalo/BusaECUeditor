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

Public Class BKingFuelMap
    '
    ' Fuelmap.vb contains all functions to edit fuelmaps in ecueditor. it uses a global variable flash(addr) that
    ' has the full ecu image loaded as byte values. the fuelmap is edited on a grid and changed values are
    ' written to the global variable flash(addr).
    '

#Region "Variables"

    Dim _change As Integer
    Dim _previousRow As Integer
    Dim _tPSMap As Boolean
    Dim _mapStructureTable As Long
    Dim _mapNumberOfColumns As Integer
    Dim _mapNumberOfRows As Integer
    Dim _editingMap As Long
    Dim _baseMap As Integer
    Dim _setMode As Integer

#End Region

#Region "Properties"

    Public Property SetMode() As Integer
        Get

            Return _setMode

        End Get
        Set(ByVal value As Integer)

            _setMode = value

        End Set
    End Property

#End Region

#Region "Form Events"

    Private Sub BKingFuelMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _change = 1 ' default change to map when pressing +,- or *,/
        _previousRow = 0
        fuelmapvisible = True
        _setMode = 0

        ' select tpsmap as first map to show, this will unify cylinder specific fuelmaps
        SelectMap(1)

    End Sub

    Private Sub BKingFuelMap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        FuelMapGrid_KeyPress(sender, e)

    End Sub

    Private Sub BKingFuelMap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        fuelmapvisible = False

    End Sub

#End Region

#Region "Control Events"

    Private Sub B_TPSMAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_TPS.Click

        SelectMap(1)

    End Sub

    Private Sub B_IAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_IAP.Click

        SelectMap(2)

    End Sub

    Private Sub B_MSTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MSTP.Click

        SelectMap(4)

    End Sub

    Private Sub B_Apply_Map_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Apply_MAP.Click
        ' Lets use OpenFileDialog to open a new flash image file
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        Dim fs As FileStream
        Dim path As String
        Dim pcv(&HA90)
        Dim bz(&H205)
        Dim rp, cp, pcvr, pcvc, noc, nor, bzr, bzc As Integer
        Dim b(1) As Byte
        Dim i As Integer
        Dim v As Integer
        Dim adj As Decimal
        Dim filetype As String
        Dim rpmcorr, tpscorr As Decimal


        MsgBox("Note: This feature is currently for testing. Only apply once for each map.")
        '
        ' remember also to make a note not to apply the pc maps twice...
        '

        fdlg.InitialDirectory = ""
        fdlg.Title = "Open a map file"
        fdlg.Filter = "PCV (*.pvm)|*.pvm|BZ (*.zfm1)|*.zfm1"
        fdlg.FilterIndex = 1
        fdlg.RestoreDirectory = True

        '
        ' Apply changes to the TPS map
        '
        SelectMap(1)
        noc = ReadFlashByte(readflashlongword(_mapStructureTable + ((0 * 6) + (3 * 0) + 0) * 4) + 1)
        nor = ReadFlashByte(readflashlongword(_mapStructureTable + ((0 * 6) + (3 * 0) + 0) * 4) + 2)


        If fdlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = fdlg.FileName

            filetype = ""
            If fdlg.FileName.Contains("pvm") Then
                filetype = "pcv"
            End If
            If fdlg.FileName.Contains("zfm1") Then
                filetype = "bz"
            End If


            Select Case filetype
                Case "pcv"
                    '
                    ' Powercommander 5 file
                    '

                    '
                    ' First lets get the file to the memory and check that it can be applied
                    '
                    fs = File.OpenRead(path)
                    i = 0
                    Do While fs.Read(b, 0, 1) > 0
                        If i > &HA87 Then
                            MsgBox("pcv file too long, program aborts")
                            Return
                        End If
                        pcv(i) = b(0)
                        i = i + 1
                    Loop
                    fs.Close()

                    rp = 0
                    cp = 0
                    ' 
                    ' Lets process the table, we use ecueditor table as its bigger in size
                    '
                    For rp = 0 To nor - 1
                        For cp = 0 To noc - 1

                            '
                            ' First map the ecueditor map columns and rows to pcv rows and columns
                            '
                            pcvr = EEToPCVR(rp)
                            pcvc = EEToPCVC(cp)
                            '
                            ' Now lets calculate the % change to ecueditor fuelmap value
                            '
                            rpmcorr = rp / 500
                            tpscorr = cp / 1000
                            adj = (tpscorr + rpmcorr + 1)
                            v = (pcv(&H230 + (10 * pcvr) + pcvc) - &H64)
                            FuelMapGrid.Item(cp, rp).Value = Int(FuelMapGrid.Item(cp, rp).Value * adj * (1 + (v / 100)))

                            '
                            ' Set value on map to ecu flash
                            '
                            SetFlashItem(cp, rp)
                            SetCellColour(cp, rp)
                        Next
                    Next
                Case "bz"
                    '
                    ' Bazzaz file
                    '

                    '
                    ' First lets get the file to the memory and check that it can be applied
                    '
                    fs = File.OpenRead(path)
                    i = 0
                    Do While fs.Read(b, 0, 1) > 0
                        If i > &H203 Then
                            MsgBox("zfm1 file too long, program aborts")
                            Return
                        End If
                        bz(i) = b(0)
                        i = i + 1
                    Loop
                    fs.Close()

                    rp = 0
                    cp = 0
                    ' 
                    ' Lets process the table, we use ecueditor table as its bigger in size
                    '
                    For rp = 0 To nor - 1
                        For cp = 0 To noc - 1

                            '
                            ' First map the ecueditor map columns and rows to bz rows and columns
                            ' bz table has r/c reversed to ee rows and columns
                            '
                            bzr = EEToBzr(rp)
                            bzc = EEToBzc(cp)
                            If (bzr = 2) And (bzc = 5) Then
                                bzr = bzr
                            End If
                            '
                            ' Now lets calculate the % change to ecueditor fuelmap value
                            '
                            adj = 1.0 ' this is a number reserved for AFR adjustments 
                            v = (bz(15 + (13 * bzr) + bzc)) ' here get value and reverse columns
                            If v >= 50 Then v = v - &HFF ' make negative values too...
                            FuelMapGrid.Item(cp, rp).Value = Int(FuelMapGrid.Item(cp, rp).Value * adj * (1 + (v / 100)))

                            '
                            ' Set value on map to ecu flash
                            '
                            SetFlashItem(cp, rp)
                            SetCellColour(cp, rp)
                        Next
                    Next
                Case Else
                    MsgBox("Unknown filetype")
            End Select

        End If
    End Sub

    Private Sub FuelMapGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FuelMapGrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = FuelMapGrid.CurrentCell.ColumnIndex
        r = FuelMapGrid.CurrentCell.RowIndex

        ' this is the user interface shortcut keys processor
        Select Case e.KeyChar
            Case "*"
                MultiplySelectedCells()
                ShowValues()
            Case "/"
                DivideSelectedCells()
                ShowValues()
            Case "+"
                IncreaseSelectedCells()
                ShowValues()
            Case "-"
                DecreaseSelectedCells()
                ShowValues()
            Case "1"
                SelectMap(1)
            Case "T"
                SelectMap(1)
            Case "t"
                SelectMap(1)
            Case "2"
                SelectMap(2)
            Case "I"
                SelectMap(2)
            Case "i"
                SelectMap(2)
            Case "3"
                SelectMap(3)
            Case "4"
                SelectMap(4)
            Case "a"
                _setMode = 0
                SelectMap(1)
            Case "A"
                _setMode = 0
                SelectMap(1)
            Case "b"
                _setMode = 1
                SelectMap(1)
            Case "B"
                _setMode = 1
                SelectMap(1)
            Case "c"
                CopyMaps(2)
            Case "C"
                CopyMaps(2)
            Case Chr(27)
                Me.Close()
            Case "P"
                printthis()
            Case "p"
                printthis()
        End Select

    End Sub

    Private Sub FuelMapGrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FuelMapGrid.MouseClick

        ShowValues()

    End Sub

    Private Sub FuelMapGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FuelMapGrid.CellEnter

        ShowValues()

    End Sub

    Private Sub FuelMapGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FuelMapGrid.KeyDown

        If (e.Control = True And e.KeyCode = Keys.V) Then
            Dim rowIndex As Integer
            Dim lines As String()
            Dim columnStartIndex As Integer

            rowIndex = Integer.MaxValue
            columnStartIndex = Integer.MaxValue

            For Each cell As DataGridViewCell In FuelMapGrid.SelectedCells()
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
                            FuelMapGrid(columnIndex, rowIndex).Value = value
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

#Region "Functions"

    Public Function FuelPW(ByVal pW As Integer)

        ' change ecu values on values on the screen.
        Return CInt(pW / 24)

    End Function

    Function FuelPWToECUVal(ByVal pw As Integer)

        ' change screen values back to ecu values.
        Return CInt(pw * 24)

    End Function

    Private Sub DecreaseSelectedCells()

        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer

        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = FuelMapGrid.Item(c, r).Value - decrease
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

    Private Sub DivideSelectedCells()

        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer

        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = Int(FuelMapGrid.Item(c, r).Value / 1.05)
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

    Private Sub MultiplySelectedCells()

        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer

        decrease = _change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < _mapNumberOfRows)

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = Int(FuelMapGrid.Item(c, r).Value * 1.05)
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

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < (_mapNumberOfRows - 1)) And n > 0

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = FuelMapGrid.Item(c, r).Value + increase
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

        ' this subroutine compares the cell value to the value of the flash image initially read from the disk with open file
        ' and sets cell colour accordingly based on that comparison        
        Dim diff As Decimal

        diff = (((ReadFlashWord(_editingMap + (2 * (c + (r * _mapNumberOfColumns))))))) - (((ReadFlashWordCopy(_editingMap + (2 * (c + (r * _mapNumberOfColumns)))))))

        '
        ' Only set cell colour if cursor is on the grid.
        '
        If (Me.Visible) Then
            FuelMapGrid.Item(c, r).Style.ForeColor = Color.Black
            If Me.Text.Contains("TPS") And c < 11 Then FuelMapGrid.Item(c, r).Style.ForeColor = Color.Gray
            FuelMapGrid.Item(c, r).Style.BackColor = Color.White
            If CInt(diff) < -1 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Yellow
            If CInt(diff) < -2 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Pink
            If CInt(diff) < -5 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Red
            If CInt(diff) > 1 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.LightGreen
            If CInt(diff) > 2 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.YellowGreen
            If CInt(diff) > 5 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Green
        End If

    End Sub

    Private Sub SetFlashItem(ByVal c As Integer, ByVal r As Integer)

        Dim diff As Integer ' diff is the falue how much it is changed compared to the visible map
        Dim m1 As Integer 'map1 new value
        Dim m2 As Integer 'map2 new value
        Dim maxval As Integer
        Dim minval As Integer
        Dim ms01, cylinder, modeabc As Integer
        Dim number_of_columns As Integer
        Dim copy_to_map As Long
        Dim copy_to_map2 As Long
        Dim mapsel As Boolean

        mapsel = False

        maxval = 400   ' not validated from ecu, maximum value to which the map item can be set
        minval = 5   ' not validated from ecu, minimum value to which the map item can be set

        m1 = FuelMapGrid.Item(c, r).Value
        m2 = FuelPW((ReadFlashWord(_editingMap + (2 * (c + (r * _mapNumberOfColumns))))))

        diff = m2 - m1


        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval) Or (m2 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 < minval Then m1 = minval
        If m2 < minval Then m2 = minval

        ' lets check that we do not exceed Ignitionmap values that the ecu can handle
        If ((m1 > maxval) Or (m2 > maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 > maxval Then m1 = maxval
        If m2 > maxval Then m1 = maxval

        '
        ' All maps will be now flashed with the same map value from the screen
        ' first converted to ecu value
        '
        If Me.Text.Contains("Fuel IAP/RPM") Then
            mapsel = True
            cylinder = 0        ' 0,1,2,3
            ms01 = 0            ' 0,1
            number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            For cylinder = 0 To 3
                For ms01 = 0 To 1
                    For modeabc = _setMode To _setMode
                        '
                        ' This is normal on gear idle map
                        '
                        copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashWord(copy_to_map + (2 * (c + (r * number_of_columns))), FuelPWToECUVal(m1))
                        '
                        ' Need to write the values also to idle neutral map
                        ' &H54DF4 on gear, &H54E54 on neutral
                        '
                        copy_to_map2 = readflashlongword(readflashlongword((&H54E54 + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashWord(copy_to_map2 + (2 * (c + (r * number_of_columns))), FuelPWToECUVal(m1))
                    Next
                Next
            Next
        End If
        If Me.Text.Contains("Fuel MS TPS/RPM") Then
            '
            ' Only MS TPS maps will be copied
            '
            mapsel = True
            cylinder = 0        ' 0,1,2,3
            ms01 = 1            ' 0,1
            number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            For cylinder = 0 To 3
                For ms01 = 1 To 1
                    For modeabc = _setMode To _setMode
                        copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashWord(copy_to_map + (2 * (c + (r * number_of_columns))), FuelPWToECUVal(m1))
                    Next
                Next
            Next
        End If
        If Me.Text.Contains("Fuel TPS/RPM") Then

            '
            ' Only Normal TPS maps will be copied
            '
            mapsel = True
            cylinder = 0        ' 0,1,2,3
            ms01 = 0            ' 0,1
            number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            For cylinder = 0 To 3
                For ms01 = 0 To 0
                    For modeabc = _setMode To _setMode
                        copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashWord(copy_to_map + (2 * (c + (r * number_of_columns))), FuelPWToECUVal(m1))
                    Next
                Next
            Next
        End If
        If mapsel = False Then MsgBox("Did not detect correct map, fuel mapping may be incorrect.")

    End Sub

    Public Sub SelectMap(ByVal map As Integer)

        Dim cylinder As Integer
        Dim ms01 As Integer
        Dim modeabc As Integer

        ' map tracing function to be disabled when map is changed
        _previousRow = 0

        Select Case map
            Case 1
                _mapStructureTable = &H54EB4
                Me.Text = "ECUeditor - Fuel TPS/RPM map"
                ms01 = 0            ' 0,1
            Case 2
                _mapStructureTable = &H54DF4 '&H54DF4 on gear, &H54E54 on neutral
                Me.Text = "ECUeditor - Fuel IAP/RPM map"
                ms01 = 0            ' 0,1
            Case 4
                _mapStructureTable = &H54EB4
                Me.Text = "ECUeditor - Fuel MS TPS/RPM map"
                ms01 = 1            ' 0,1
        End Select

        rr = 0
        cc = 0

        ' these are more or less global definitions for editing the maps
        cylinder = 0        ' 0,1,2,3
        modeabc = _setMode  ' 0,1,2
        _editingMap = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        _mapNumberOfColumns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        _mapNumberOfRows = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        ' Global variable of which map type is being edited
        If Me.Text.Contains("TPS") Then
            _tPSMap = True
        Else
            _tPSMap = False
        End If

        ' Initialize map type selected. Copymaps unifies cylinders and modeABC maps. Loadmap brings the map visible.
        If Me.Text.Contains("MS") Then
            LoadMap(1)
            CopyMaps(1)
        Else
            LoadMap(0)
            CopyMaps(0)
        End If

        mapvisible = Me.Text

    End Sub

    Public Sub LoadMap(ByVal ms01 As Integer)

        ' This function loads a map into a grid including map contents and heading information
        Dim columnheading_map, rowheading_map As Integer
        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer
        Dim cylinder, modeabc As Integer
        i = 0
        ii = 0

        Select Case _setMode
            Case 0 : L_modeabc.Text = "A"
            Case 1 : L_modeabc.Text = "B"
            Case 2 : L_modeabc.Text = "C"
        End Select
        '
        ' Select which map is being used as a _baseMap for editing
        '
        cylinder = 0        ' 0,1,2,3
        modeabc = _setMode         ' 0,1,2
        columnheading_map = readflashlongword(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 4)
        rowheading_map = readflashlongword(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 8)
        _editingMap = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)

        '
        ' Generate column headings
        '
        FuelMapGrid.ColumnCount = _mapNumberOfColumns
        c = 0
        Do While c < _mapNumberOfColumns
            i = ReadFlashWord(columnheading_map + (c * 2))
            If _tPSMap Then
                FuelMapGrid.Columns.Item(c).HeaderText = CalcK8TPS(i)
            Else
                FuelMapGrid.Columns.Item(c).HeaderText = CalcK8IAP(i)
            End If
            FuelMapGrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        FuelMapGrid.RowCount = _mapNumberOfRows
        r = 0
        FuelMapGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < _mapNumberOfRows)
            i = ReadFlashWord(rowheading_map + (r * 2))
            FuelMapGrid.Rows.Item(r).HeaderCell.Value = Str(Int(i / 2.56))
            FuelMapGrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop

        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < _mapNumberOfRows)

            FuelMapGrid.Item(c, r).Value = FuelPW(ReadFlashWord((i * 2) + _editingMap))
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
        FuelMapGrid.AllowUserToAddRows = False
        FuelMapGrid.AllowUserToDeleteRows = False
        FuelMapGrid.AllowUserToOrderColumns = False
        FuelMapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Sub

    Public Sub TraceMap()

        ' based on enginedata show the position on the map and trace which cell is being accessed by ecu (almost)
        Dim c As Integer
        Dim r As Integer

        SetCellColour(cc, rr)

        ' enable automatic map switching when tracing and datastream on

        r = _mapNumberOfRows
        c = _mapNumberOfColumns

        r = 0
        rr = 0
        Do While (r < _mapNumberOfRows - 1)
            If RPM >= rr And RPM < Int(FuelMapGrid.Rows(r + 1).HeaderCell.Value) Then
                rr = r
                r = 256
            Else
                r = r + 1
                rr = Int(FuelMapGrid.Rows(r).HeaderCell.Value)
            End If
        Loop


        If _tPSMap Then
            '
            ' Process TPS maps
            '
            c = 0
            cc = 0
            If CalcTPSDec(TPS) < Val(FuelMapGrid.Columns.Item(_mapNumberOfColumns - 1).HeaderCell.Value) Then
                Do While (c < _mapNumberOfColumns - 1)
                    If CalcTPSDec(TPS) >= cc And CalcTPSDec(TPS) < FuelMapGrid.Columns.Item(c + 1).HeaderCell.Value Then
                        cc = c
                        c = 256
                    Else
                        c = c + 1
                        cc = Int(FuelMapGrid.Columns.Item(c).HeaderCell.Value)
                    End If
                Loop
            Else
                cc = _mapNumberOfColumns - 1
            End If
        Else
            '
            ' Process IAP maps
            '
            c = 0
            cc = 256

            Do While (c < _mapNumberOfColumns - 1)
                If IAP <= cc And IAP > Int(FuelMapGrid.Columns.Item(c + 1).HeaderCell.Value) Then
                    cc = c
                    c = 256
                Else
                    c = c + 1
                    cc = Int(FuelMapGrid.Columns.Item(c).HeaderCell.Value)
                End If
            Loop
        End If

        If rr > _mapNumberOfRows Then rr = 0
        If rr < 0 Then rr = 0
        If cc > _mapNumberOfColumns Then cc = 0
        If cc < 0 Then cc = 0
        If rr <> 0 Or cc <> 0 Then
            SetCellColour(0, rr)
            FuelMapGrid.Item(cc, rr).Style.BackColor = Color.Blue
        Else
            SetCellColour(cc, rr)
        End If
    End Sub

    Public Sub CopyMaps(ByVal i As Integer)
        '
        ' copy map contents to all cylinders and modeABC groups, depending on parameter only ms0 or ms1 or both ms0 and ms1
        '
        Dim number_of_columns, number_of_rows As Integer
        Dim copy_from_map, copy_to_map, copy_to_map2 As Long
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
        cylinder = 0        ' 0,1,2,3
        ms01 = a            ' 0,1
        modeabc = _setMode         ' 0,1,2
        copy_from_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        number_of_columns = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        number_of_rows = ReadFlashByte(readflashlongword(_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        '
        ' Now copy the map contents for selected mode ms0 or ms1
        '
        For cylinder = 0 To 3
            For ms01 = a To b
                For modeabc = _setMode To _setMode
                    copy_to_map = readflashlongword(readflashlongword((_mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                    For cell = 0 To ((number_of_columns - 1) * (number_of_rows - 1))
                        WriteFlashWord(copy_to_map + (cell * 2), ReadFlashWord(copy_from_map + (cell * 2)))
                        '
                        ' If IAP map then also copy to idle map in addition to on gear map
                        ' &H54DF4 on gear, &H54E54 on neutral
                        '
                        If _mapStructureTable = &H54DF4 Then
                            copy_to_map2 = readflashlongword(readflashlongword((&H54E54 + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                            WriteFlashWord(copy_to_map2 + (cell * 2), ReadFlashWord(copy_from_map + (cell * 2)))
                        End If
                    Next
                Next
            Next
        Next

    End Sub

    Private Sub ShowValues()
        '
        ' show the values on topmost boxes. for gen2 this is not really completed function.
        '
        Dim istr As String
        Dim r As Integer
        Dim c As Integer
        Dim msrpm As Integer
        Dim v, m1, m2 As Integer
        Dim p As Decimal

        istr = ""
        rowselected = FuelMapGrid.CurrentRow.Index

        Try

            istr = Str(FuelMapGrid.Columns.Item(FuelMapGrid.CurrentCell.ColumnIndex).HeaderCell.Value)

            '
            ' Editing position 
            '
            T_RPM.Text = FuelMapGrid.CurrentRow.HeaderCell.Value & " rpm"
            If Me.Text.Contains("TPS") Then
                T_TPSIAP.Text = "TPS = " & istr & "%"
            Else
                T_TPSIAP.Text = "IAP = " & istr
            End If

            '
            ' Now lets show the difference compared to comparemap
            '
            r = FuelMapGrid.CurrentRow.Index
            c = FuelMapGrid.CurrentCell.ColumnIndex
            m2 = FuelMapGrid.Item(c, r).Value
            m1 = FuelPW((ReadFlashWordCopy(_editingMap + (2 * (c + (r * _mapNumberOfColumns))))))
            v = m2 - m1
            p = ((m2 / m1) - 1) * 100
            If v > 0 Then
                T_change.Text = "+" & Str(v) & " (" & Format(p, "##0") & "%)"
            Else
                T_change.Text = Str(v) & " (" & Format(p, "##0") & "%)"
            End If

            msrpm = 1 / (FuelMapGrid.CurrentRow.HeaderCell.Value / 60) * 1000 * 2

        Catch ex As Exception
        End Try

    End Sub

    Private Function EEToPCVR(ByVal r As Integer) As Integer
        '
        ' ecueditor row to pcv row conversion table
        ' first row is 0
        '
        Select Case r
            Case 0 : Return 1
            Case 1 : Return 2
            Case 2 : Return 3
            Case 3 : Return 4
            Case 4 : Return 4
            Case 5 : Return 5
            Case 6 : Return 6
            Case 7 : Return 7
            Case 8 : Return 8
            Case 9 : Return 8
            Case 10 : Return 9
            Case 11 : Return 10
            Case 12 : Return 11
            Case 13 : Return 12
            Case 14 : Return 12
            Case 15 : Return 13
            Case 16 : Return 14
            Case 17 : Return 15
            Case 18 : Return 16
            Case 19 : Return 16
            Case 20 : Return 17
            Case 21 : Return 18
            Case 22 : Return 19
            Case 23 : Return 20
            Case 24 : Return 22
            Case 25 : Return 24
            Case 26 : Return 25
            Case 27 : Return 27
            Case 28 : Return 28
            Case 29 : Return 20
            Case 30 : Return 32
            Case 31 : Return 33
            Case 32 : Return 35
            Case 33 : Return 37
            Case 34 : Return 38
            Case 35 : Return 40
            Case 36 : Return 41
            Case 37 : Return 43
            Case 38 : Return 44
            Case 39 : Return 46
            Case 40 : Return 46
            Case 41 : Return 46
            Case 42 : Return 46
            Case 43 : Return 46
            Case 44 : Return 46
            Case 45 : Return 46
            Case 46 : Return 46
            Case 47 : Return 46
            Case 48 : Return 46
            Case 49 : Return 46
            Case Else
                MsgBox("Error in converting pcv row")

        End Select
    End Function

    Private Function EEToPCVC(ByVal c As Integer) As Integer
        '
        ' ecueditor column to pcv column conversion table
        ' first column is 0
        '
        Select Case c
            Case 0 : Return 1
            Case 1 : Return 1
            Case 2 : Return 1
            Case 3 : Return 1
            Case 4 : Return 2
            Case 5 : Return 2
            Case 6 : Return 2
            Case 7 : Return 3
            Case 8 : Return 3
            Case 9 : Return 3
            Case 10 : Return 4
            Case 11 : Return 5
            Case 12 : Return 5
            Case 13 : Return 6
            Case 14 : Return 6
            Case 15 : Return 7
            Case 16 : Return 7
            Case 17 : Return 7
            Case 18 : Return 7
            Case 19 : Return 8
            Case 20 : Return 8
            Case 21 : Return 9
            Case 22 : Return 9
            Case Else
                MsgBox("Error in converting pcv map column")
        End Select
    End Function

    Private Function EEToBzr(ByVal r As Integer) As Integer
        '
        ' ecueditor row to bazzaz row conversion table
        ' first row is 0. Note bazzaz table is x-y reversed.
        '
        Select Case r
            Case 0 : Return 0
            Case 1 : Return 1
            Case 2 : Return 1
            Case 3 : Return 2
            Case 4 : Return 2
            Case 5 : Return 3
            Case 6 : Return 3
            Case 7 : Return 3
            Case 8 : Return 4
            Case 9 : Return 4
            Case 10 : Return 5
            Case 11 : Return 5
            Case 12 : Return 5
            Case 13 : Return 6
            Case 14 : Return 6
            Case 15 : Return 7
            Case 16 : Return 7
            Case 17 : Return 7
            Case 18 : Return 8
            Case 19 : Return 8
            Case 20 : Return 9
            Case 21 : Return 9
            Case 22 : Return 9
            Case 23 : Return 10
            Case 24 : Return 11
            Case 25 : Return 15
            Case 26 : Return 12
            Case 27 : Return 13
            Case 28 : Return 14
            Case 29 : Return 15
            Case 30 : Return 16
            Case 31 : Return 17
            Case 32 : Return 17
            Case 33 : Return 18
            Case 34 : Return 19
            Case 35 : Return 20
            Case 36 : Return 21
            Case 37 : Return 21
            Case 38 : Return 22
            Case 39 : Return 23
            Case 40 : Return 24
            Case 41 : Return 25
            Case 42 : Return 25
            Case 43 : Return 26
            Case 44 : Return 26 ' from here on not verified
            Case 45 : Return 26
            Case 46 : Return 27
            Case 47 : Return 27
            Case 48 : Return 31
            Case 49 : Return 31
            Case Else
                MsgBox("Error in converting bz row")


        End Select
    End Function

    Private Function EEToBzc(ByVal c As Integer) As Integer
        '
        ' ecueditor column to bz conversion table
        ' first column is 0. Note bazzaz table is x-y reversed.
        '
        Select Case c
            Case 0 : Return 0
            Case 1 : Return 0
            Case 2 : Return 0
            Case 3 : Return 0
            Case 4 : Return 1
            Case 5 : Return 1
            Case 6 : Return 1
            Case 7 : Return 2
            Case 8 : Return 2
            Case 9 : Return 2
            Case 10 : Return 3
            Case 11 : Return 3
            Case 12 : Return 3
            Case 13 : Return 4
            Case 14 : Return 5
            Case 15 : Return 6
            Case 16 : Return 6
            Case 17 : Return 7
            Case 18 : Return 7
            Case 19 : Return 8
            Case 20 : Return 9
            Case 21 : Return 10
            Case 22 : Return 11
            Case Else
                MsgBox("Error in converting bz map column")
        End Select
    End Function

#End Region

End Class