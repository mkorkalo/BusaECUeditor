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

Public Class FuelMap

#Region "Variables"

    Dim _change As Integer
    Dim _previousRow As Integer
    Dim _tPSmap As Boolean

#End Region

#Region "Form Events"

    Private Sub FuelMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SelectMap(1)
        _change = 1 ' default _change to map when pressing +,- or *,/
        _previousRow = 0
        FuelMapVisible = True

    End Sub

    Private Sub FuelMap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        FuelMapVisible = False

    End Sub

#End Region

#Region "Control Events"

    Private Sub FuelMapGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FuelMapGrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = FuelMapGrid.CurrentCell.ColumnIndex
        r = FuelMapGrid.CurrentCell.RowIndex

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
            Case Chr(27)
                Me.Close()
            Case "c"
                CopyTpsToMsMap()
        End Select

    End Sub

    Private Sub FuelMapGrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FuelMapGrid.MouseClick

        ShowValues()

    End Sub

    Private Sub FuelMapGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FuelMapGrid.CellEnter

        ShowValues()

    End Sub

    Private Sub B__tPSmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_TPS.Click
        SelectMap(1)
    End Sub

    Private Sub B_IAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_IAP.Click
        SelectMap(2)
    End Sub

    Private Sub B_Idle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectMap(3)
    End Sub

    Private Sub B_MSTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MSTP.Click
        SelectMap(4)
    End Sub

    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click
        Me.Close()
    End Sub

    Private Sub B_Unify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Unify.Click

        If MsgBox("This will unify cylinder specific fuelmaps to this map, do you agree", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < MapRows) And (r < 42)

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = FuelMapGrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)
                SetCellColour(c, r)
                n = n - 1
            End If

            If c < MapColumns - 1 Then
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

    Private Sub DivideSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim v As Integer

        i = 0

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < MapRows) And (r < 42)

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = CInt((FuelMapGrid.Item(c, r).Value * 100) / (5 + 100))
                SetFlashItem(c, r)
                SetCellColour(c, r)
                n = n - 1
            End If

            If c < MapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        v = Val(T_valdiff.Text)
        v = Int(v * (100 / (_change + 100)))
        If v > 0 Then
            T_valdiff.Text = "+" & Str(v)
        Else
            T_valdiff.Text = Str(v)
        End If


    End Sub

    Private Sub MultiplySelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer
        Dim v As Integer

        i = 0

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < MapRows) And (r < 42)

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = CInt((FuelMapGrid.Item(c, r).Value * (5 + 100)) / 100)
                SetFlashItem(c, r)
                SetCellColour(c, r)
                n = n - 1
            End If

            If c < MapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        v = Val(T_valdiff.Text)
        v = Int(v * ((_change + 100) / 100))
        If v > 0 Then
            T_valdiff.Text = "+" & Str(v)
        Else
            T_valdiff.Text = Str(v)
        End If


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

        n = FuelMapGrid.SelectedCells.Count()

        Do While (r < (MapRows - 1)) And (r < 42) And n > 0

            If FuelMapGrid.Item(c, r).Selected And n > 0 Then
                FuelMapGrid.Item(c, r).Value = FuelMapGrid.Item(c, r).Value + increase
                SetFlashItem(c, r)
                SetCellColour(c, r)
                n = n - 1
            End If

            If c < MapColumns - 1 Then
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

    Private Sub SetCellColour(ByVal c As Integer, ByVal r As Integer)
        '
        ' this subroutine compares the cell value to the value of the flash image initially read from the disk with open file
        ' and sets cell colour accordingly based on that comparison
        '
        Dim diff As Decimal

        diff = (((ReadFlashWord(MapAddr1 + (2 * (c + (r * MapColumns))))))) - (((ReadFlashWordCopy(MapAddr1 + (2 * (c + (r * MapColumns)))))))

        FuelMapGrid.Item(c, r).Style.ForeColor = Color.Black
        If Me.Text.Contains("TPS") And c < 11 Then FuelMapGrid.Item(c, r).Style.ForeColor = Color.Gray
        FuelMapGrid.Item(c, r).Style.BackColor = Color.White
        If CInt(diff) < -1 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Yellow
        If CInt(diff) < -2 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Pink
        If CInt(diff) < -5 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Red
        If CInt(diff) > 1 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.LightGreen
        If CInt(diff) > 2 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.YellowGreen
        If CInt(diff) > 5 * 24 Then FuelMapGrid.Item(c, r).Style.BackColor = Color.Green

    End Sub

    Private Sub SetFlashItem(ByVal c As Integer, ByVal r As Integer)

        Dim diff As Integer ' diff is the falue how much it is _changed compared to the visible map
        Dim m1 As Integer 'map1 new value
        Dim m2 As Integer 'map2 new value
        Dim m3 As Integer 'map3 new value
        Dim m4 As Integer 'map4 new value
        Dim maxval As Integer
        Dim minval As Integer
        Dim idle_MapAddr1 As Integer
        Dim idle_MapAddr2 As Integer
        Dim idle_MapAddr3 As Integer
        Dim idle_MapAddr4 As Integer
        Dim idle_maprows As Integer
        Dim idle_mapcolumns As Integer

        ' The fuelmap values are divided by 48 which puts the figures close to millisecond/10 values
        maxval = 32 * 2 * 128   ' not validated from ecu, maximum value to which the fuelmap item can be set
        minval = 12 * 2 * 5     ' not validated from ecu, minimum value to which the fuelmap item can be set

        m1 = FuelMapGrid.Item(c, r).Value
        m2 = Int(ReadFlashWord(MapAddr1 + (2 * (c + (r * MapColumns)))) / 24) 'Int(ReadFlashWord((i * 2) + MapAddr1) / 48)

        diff = Int(ReadFlashWord(MapAddr1 + (2 * (c + (r * MapColumns)))) / 24) - (FuelMapGrid.Item(c, r).Value)

        m1 = (Int(ReadFlashWord(MapAddr1 + (2 * (c + (r * MapColumns)))) / 24) - diff) * 24
        m2 = (Int(ReadFlashWord(MapAddr2 + (2 * (c + (r * MapColumns)))) / 24) - diff) * 24
        m3 = (Int(ReadFlashWord(MapAddr3 + (2 * (c + (r * MapColumns)))) / 24) - diff) * 24
        m4 = (Int(ReadFlashWord(MapAddr4 + (2 * (c + (r * MapColumns)))) / 24) - diff) * 24

        ' lets check that we do not have too small values that the ecu can not handle
        If ((m1 < minval) Or (m2 < minval) Or (m3 < minval) Or (m4 < minval)) Then MsgBox("Minimum cell value exceeded", MsgBoxStyle.Information)
        If m1 < minval Then m1 = minval
        If m2 < minval Then m2 = minval
        If m3 < minval Then m3 = minval
        If m4 < minval Then m3 = minval

        ' lets check that we do not exceed fuelmap values that the ecu can handle
        If ((m1 > maxval) Or (m2 > maxval) Or (m3 > maxval) Or (m4 > maxval)) Then MsgBox("Maximum cell value exceeded", MsgBoxStyle.Information)
        If m1 > maxval Then m1 = maxval
        If m2 > maxval Then m1 = maxval
        If m3 > maxval Then m1 = maxval
        If m4 > maxval Then m1 = maxval


        WriteFlashWord(MapAddr1 + (2 * (c + (r * MapColumns))), m1)
        WriteFlashWord(MapAddr2 + (2 * (c + (r * MapColumns))), m2)
        WriteFlashWord(MapAddr3 + (2 * (c + (r * MapColumns))), m3)
        WriteFlashWord(MapAddr4 + (2 * (c + (r * MapColumns))), m4)

        ' now lets also update both IAP idlemaps if there are any _changes to the idlemap area
        ' and also the other full size IAP map
        If Me.Text.Contains("IAP") Then

            '
            ' write the ms map values also on MS map as MS values are not used for e.g. Nitrous
            ' so its assumed that user wants to retain the IAP maps for MS use also...
            ' I.e. these are the IAP ms maps that get written together with IAP maps
            '
            WriteFlashWord(&H2DF04 + (2 * (c + (r * MapColumns))), m1)
            WriteFlashWord(&H2E692 + (2 * (c + (r * MapColumns))), m2)
            WriteFlashWord(&H2EE20 + (2 * (c + (r * MapColumns))), m3)
            WriteFlashWord(&H2F5AE + (2 * (c + (r * MapColumns))), m4)


            '
            ' then lets write both ms and normal idle map values
            '
            idle_MapAddr1 = &H2D652
            idle_MapAddr2 = &H2D770
            idle_MapAddr3 = &H2D88E
            idle_MapAddr4 = &H2D9AC

            idle_maprows = 8
            idle_mapcolumns = 15
            ' idlemap is located in these positions on the IAP map
            If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                'idlemap has 600rpm row as first row which is not existing in normal fuel map
                'if this is the first row, then copy also those values to the map just assuming 
                ' that 600rpm is the same as 800rpm
                If r = 0 Then
                    WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                End If
                WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
            End If

            idle_MapAddr1 = &H31DE2
            idle_MapAddr2 = &H31F00
            idle_MapAddr3 = &H3201E
            idle_MapAddr4 = &H3213C

            idle_maprows = 8
            idle_mapcolumns = 15
            ' idlemap is located in these positions on the IAP map
            If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                'idlemap has 600rpm row as first row which is not existing in normal fuel map
                'if this is the first row, then copy also those values to the map just assuming 
                ' that 600rpm is the same as 800rpm
                If r = 0 Then
                    WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                End If
                WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
            End If
        Else
            If Me.Text.Contains("MS") Then

                '
                ' Not an IAP map, so lets write the MS TPS idle maps
                '

                idle_MapAddr1 = &H2DA6C
                idle_MapAddr2 = &H2DBC0
                idle_MapAddr3 = &H2DCBA
                idle_MapAddr4 = &H2DDB4

                idle_maprows = 8
                idle_mapcolumns = 13
                ' idlemap is located in these positions on the IAP map
                If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                    'idlemap has 600rpm row as first row which is not existing in normal fuel map
                    'if this is the first row, then copy also those values to the map just assuming 
                    ' that 600rpm is the same as 800rpm
                    If r = 0 Then
                        WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                        WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                        WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                        WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                    End If
                    WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
                End If
            Else
                '
                ' Not a MS TPS idle maps so must be normal TPS idle map
                '

                idle_MapAddr1 = &H32256
                idle_MapAddr2 = &H32350
                idle_MapAddr3 = &H3244A
                idle_MapAddr4 = &H32544

                idle_maprows = 8
                idle_mapcolumns = 13
                ' idlemap is located in these positions on the IAP map
                If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                    'idlemap has 600rpm row as first row which is not existing in normal fuel map
                    'if this is the first row, then copy also those values to the map just assuming 
                    ' that 600rpm is the same as 800rpm
                    If r = 0 Then
                        WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                        WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                        WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                        WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                    End If
                    WriteFlashWord(idle_MapAddr1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_MapAddr2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_MapAddr3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_MapAddr4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
                End If

            End If

        End If


    End Sub

    Public Sub SelectMap(ByVal map As Integer)
        ' map tracing function to be disabled when map is _changed
        _previousRow = 0

        Select Case map
            Case 1
                MapAddr1 = &H2B5B0
                MapAddr2 = &H2BDEE
                MapAddr3 = &H2C62C
                MapAddr4 = &H2CE6A

                MapRows = 43
                MapColumns = 23
                Me.Text = "ECUeditor - Fuel TPS/RPM map"
            Case 2
                MapAddr1 = &H29774
                MapAddr2 = &H29F02
                MapAddr3 = &H2A690
                MapAddr4 = &H2AE1E

                MapRows = 43
                MapColumns = 21
                Me.Text = "ECUeditor - Fuel IAP/RPM map"
            Case 3
                MapAddr1 = &H2D652
                MapAddr2 = &H2D770
                MapAddr3 = &H2D88E
                MapAddr4 = &H2D9AC

                MapRows = 8
                MapColumns = 15
                Me.Text = "ECUeditor - Fuel IAP/RPM Idle map"

            Case 4
                MapAddr1 = &H2FD40
                MapAddr2 = &H3057E
                MapAddr3 = &H30DBC
                MapAddr4 = &H315FA

                MapRows = 43
                MapColumns = 23
                Me.Text = "ECUeditor - Fuel MS TPS/RPM map"

        End Select
        RR = 0
        CC = 0

        MapVisible = Me.Text
        If Me.Text.Contains("TPS") Then _tPSmap = True Else _tPSmap = False
        LoadMap()
    End Sub

    Public Sub LoadMap()

        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer
        B_Unify.Visible = False
        i = 0
        ii = 0

        FuelMapGrid.ColumnCount = MapColumns
        If MapRows > 42 Then
            FuelMapGrid.RowCount = 42
        Else
            FuelMapGrid.RowCount = MapRows
        End If


        c = 0
        r = 0
        Do While c < MapColumns
            i = Int((ReadFlashWord(MapAddr1 - (2 * MapRows) - (2 * MapColumns) + (c * 2))) / 256) ' * 0.00152587890625)
            If _tPSmap Then
                FuelMapGrid.Columns.Item(c).HeaderText = CalcTPS(i)
            Else
                FuelMapGrid.Columns.Item(c).HeaderText = Str(i)
            End If
            FuelMapGrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        c = 0
        r = 0

        FuelMapGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < MapRows) And (r < 42)
            FuelMapGrid.Rows.Item(r).HeaderCell.Value = Str((ReadFlashWord(MapAddr1 - (2 * MapRows) + (r * 2)) / 2.56))
            FuelMapGrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop


        c = 0
        r = 0
        i = 0
        Do While (r < MapRows) And (r < 42)

            FuelMapGrid.Item(c, r).Value = Int(ReadFlashWord((i * 2) + MapAddr1) / 24) '48
            SetCellColour(c, r)
            If Not (ReadFlashWord((i * 2) + MapAddr1) = ReadFlashWord((i * 2) + MapAddr2)) Then
                B_Unify.Visible = True
            End If

            If c < MapColumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        FuelMapGrid.AllowUserToAddRows = False
        FuelMapGrid.AllowUserToDeleteRows = False
        FuelMapGrid.AllowUserToOrderColumns = False
        FuelMapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Sub

    Public Sub TraceMap()
        Dim c As Integer
        Dim r As Integer

        SetCellColour(CC, RR)

        ' enable automatic map switching when tracing and datastream on

        r = MapRows
        c = MapColumns

        r = 0
        RR = 0
        Do While (r < MapRows - 1)
            If RPM >= RR And RPM < Int(FuelMapGrid.Rows(r + 1).HeaderCell.Value) Then
                RR = r
                r = 256
            Else
                r = r + 1
                RR = Int(FuelMapGrid.Rows(r).HeaderCell.Value)
            End If
        Loop

        If _tPSmap Then
            '
            ' Process TPS maps
            '
            c = 0
            CC = 0
            If CalcTPSDec(TPS) < Val(FuelMapGrid.Columns.Item(MapColumns - 1).HeaderCell.Value) Then
                Do While (c < MapColumns - 1)
                    If CalcTPSDec(TPS) >= CC And CalcTPSDec(TPS) < FuelMapGrid.Columns.Item(c + 1).HeaderCell.Value Then
                        CC = c
                        c = 256
                    Else
                        c = c + 1
                        CC = Int(FuelMapGrid.Columns.Item(c).HeaderCell.Value)
                    End If
                Loop
            Else
                CC = MapColumns - 1
            End If
        Else
            '
            ' Process IAP maps
            '
            c = 0
            CC = 256
            Do While (c < MapColumns - 1)
                If IAP <= CC And IAP > CInt(FuelMapGrid.Columns.Item(c + 1).HeaderCell.Value) Then
                    CC = c
                    c = 256
                Else
                    c = c + 1
                    CC = CInt(FuelMapGrid.Columns.Item(c).HeaderCell.Value)
                End If
            Loop
        End If

        If RR > MapRows Then RR = 0
        If RR < 0 Then RR = 0
        If CC > MapColumns Then CC = 0
        If CC < 0 Then CC = 0
        If RR <> 0 Or CC <> 0 Then
            FuelMapGrid.Item(CC, RR).Style.BackColor = Color.Blue
        Else
            SetCellColour(CC, RR)
        End If
    End Sub

    Private Sub Unify()

        Dim i As Integer

        Do While (i < (((MapRows) * (MapColumns))))
            WriteFlashWord(((i * 2) + MapAddr2), ReadFlashWord((i * 2) + MapAddr1))
            WriteFlashWord(((i * 2) + MapAddr3), ReadFlashWord((i * 2) + MapAddr1))
            WriteFlashWord(((i * 2) + MapAddr4), ReadFlashWord((i * 2) + MapAddr1))
            i = i + 1
        Loop
        B_Unify.Visible = False

    End Sub

    Private Sub CopyTpsToMsMap()
        '
        ' This subroutine copies the TPS map contents into MS map
        '
        Dim i As Integer
        If _tPSmap Then
            i = MsgBox("Copy the TPS map contents to MS map, the old MS map will be deleted", MsgBoxStyle.OkCancel)
            If i = 1 Then ' OK pressed
                i = 0
                Do While (i < (((MapRows) * (MapColumns))))
                    WriteFlashWord(((i * 2) + &H2FD40), ReadFlashWord((i * 2) + &H2B5B0))
                    WriteFlashWord(((i * 2) + &H3057E), ReadFlashWord((i * 2) + &H2BDEE))
                    WriteFlashWord(((i * 2) + &H30DBC), ReadFlashWord((i * 2) + &H2C62C))
                    WriteFlashWord(((i * 2) + &H315FA), ReadFlashWord((i * 2) + &H2CE6A))
                    i = i + 1
                Loop
            End If
        End If

    End Sub

    Private Sub ShowValues()
        Dim istr As String
        Dim r As Integer
        Dim c As Integer
        Dim v As Integer
        Dim msrpm As Integer

        istr = ""

        RowSelected = FuelMapGrid.CurrentRow.Index

        Try
            If FuelMapGrid.CurrentRow.Index <> _previousRow And _previousRow <= MapRows Then
                FuelMapGrid.CurrentRow.Height = 20
                FuelMapGrid.Rows.Item(_previousRow).Height = 15
                _previousRow = FuelMapGrid.CurrentRow.Index
            Else
                _previousRow = FuelMapGrid.CurrentRow.Index
            End If

            istr = Str(FuelMapGrid.Columns.Item(FuelMapGrid.CurrentCell.ColumnIndex).HeaderCell.Value)

            T_RPM.Text = FuelMapGrid.CurrentRow.HeaderCell.Value & " rpm"
            If Me.Text.Contains("TPS") Then
                T_TPSIAP.Text = "TPS = " & istr & "%"
            Else
                T_TPSIAP.Text = "IAP = " & istr
            End If

            r = FuelMapGrid.CurrentRow.Index
            c = FuelMapGrid.CurrentCell.ColumnIndex
            v = Int(ReadFlashWord(((((MapColumns * r) + c) * 2) + MapAddr1)) / 24) - Int(ReadFlashWordCopy((((MapColumns * r) + c) * 2) + MapAddr1) / 24)
            If v > 0 Then
                T_valdiff.Text = "+" & Str(v)
            Else
                T_valdiff.Text = Str(v)
            End If

            msrpm = 1 / (FuelMapGrid.CurrentRow.HeaderCell.Value / 60) * 1000 * 2
            'T_duty.Text = Int((100 * Int(ReadFlashWord(((((mapcolumns * r) + c) * 2) + MapAddr1)) / 24) / 19) / msrpm) & "%"


        Catch ex As Exception
        End Try

    End Sub

#End Region

End Class