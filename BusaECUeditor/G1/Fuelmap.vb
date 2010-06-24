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

Public Class Fuelmap
    Dim change As Integer
    Dim previousrow As Integer
    Dim toprow(50) As Integer
    Dim TPSmap As Boolean
    Dim previouscolour As Color

    Private Sub Fuelmap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fuelmapvisible = False
    End Sub

    Private Sub Fuelmap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectmap(1)
        change = 1 ' default change to map when pressing +,- or *,/
        previousrow = 0
        fuelmapvisible = True

    End Sub




    Private Sub Fuelmapgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Fuelmapgrid.KeyPress

        Dim c As Integer
        Dim r As Integer
        c = Fuelmapgrid.CurrentCell.ColumnIndex
        r = Fuelmapgrid.CurrentCell.RowIndex

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
                selectmap(1)
            Case "T"
                selectmap(1)
            Case "t"
                selectmap(1)
            Case "2"
                selectmap(2)
            Case "I"
                selectmap(2)
            Case "i"
                selectmap(2)
            Case "3"
                selectmap(3)
            Case "4"
                selectmap(4)
            Case Chr(27)
                Me.Close()
            Case "c"
                copy_tps_to_ms_map()
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

        n = Fuelmapgrid.SelectedCells.Count()

        Do While (r < maprows) And (r < 42)

            If Fuelmapgrid.Item(c, r).Selected And n > 0 Then
                Fuelmapgrid.Item(c, r).Value = Fuelmapgrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < mapcolumns - 1 Then
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

        n = Fuelmapgrid.SelectedCells.Count()

        Do While (r < maprows) And (r < 42)

            If Fuelmapgrid.Item(c, r).Selected And n > 0 Then
                Fuelmapgrid.Item(c, r).Value = CInt((Fuelmapgrid.Item(c, r).Value * 100) / (5 + 100))
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < mapcolumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        v = Val(T_valdiff.Text)
        v = Int(v * (100 / (change + 100)))
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

        n = Fuelmapgrid.SelectedCells.Count()

        Do While (r < maprows) And (r < 42)

            If Fuelmapgrid.Item(c, r).Selected And n > 0 Then
                Fuelmapgrid.Item(c, r).Value = CInt((Fuelmapgrid.Item(c, r).Value * (5 + 100)) / 100)
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < mapcolumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        v = Val(T_valdiff.Text)
        v = Int(v * ((change + 100) / 100))
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

        increase = change ' this is the value how much the cell is increased when pressing "+"
        i = 0

        n = Fuelmapgrid.SelectedCells.Count()

        Do While (r < (maprows - 1)) And (r < 42) And n > 0

            If Fuelmapgrid.Item(c, r).Selected And n > 0 Then
                Fuelmapgrid.Item(c, r).Value = Fuelmapgrid.Item(c, r).Value + increase
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < mapcolumns - 1 Then
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
    Private Sub setCellColour(ByVal c As Integer, ByVal r As Integer)
        '
        ' this subroutine compares the cell value to the value of the flash image initially read from the disk with open file
        ' and sets cell colour accordingly based on that comparison
        '
        Dim diff As Decimal

        diff = (((ReadFlashWord(mapaddr_1 + (2 * (c + (r * mapcolumns))))))) - (((ReadFlashWordCopy(mapaddr_1 + (2 * (c + (r * mapcolumns)))))))

        Fuelmapgrid.Item(c, r).Style.ForeColor = Color.Black
        If Me.Text.Contains("TPS") And c < 11 Then Fuelmapgrid.Item(c, r).Style.ForeColor = Color.Gray
        Fuelmapgrid.Item(c, r).Style.BackColor = Color.White
        If CInt(diff) < -1 Then Fuelmapgrid.Item(c, r).Style.BackColor = Color.Yellow
        If CInt(diff) < -2 * 24 Then Fuelmapgrid.Item(c, r).Style.BackColor = Color.Pink
        If CInt(diff) < -5 * 24 Then Fuelmapgrid.Item(c, r).Style.BackColor = Color.Red
        If CInt(diff) > 1 Then Fuelmapgrid.Item(c, r).Style.BackColor = Color.LightGreen
        If CInt(diff) > 2 * 24 Then Fuelmapgrid.Item(c, r).Style.BackColor = Color.YellowGreen
        If CInt(diff) > 5 * 24 Then Fuelmapgrid.Item(c, r).Style.BackColor = Color.Green


    End Sub


    Private Sub SetFlashItem(ByVal c As Integer, ByVal r As Integer)

        Dim diff As Integer ' diff is the falue how much it is changed compared to the visible map
        Dim m1 As Integer 'map1 new value
        Dim m2 As Integer 'map2 new value
        Dim m3 As Integer 'map3 new value
        Dim m4 As Integer 'map4 new value
        Dim maxval As Integer
        Dim minval As Integer
        Dim idle_mapaddr_1 As Integer
        Dim idle_mapaddr_2 As Integer
        Dim idle_mapaddr_3 As Integer
        Dim idle_mapaddr_4 As Integer
        Dim idle_maprows As Integer
        Dim idle_mapcolumns As Integer

        ' The fuelmap values are divided by 48 which puts the figures close to millisecond/10 values
        maxval = 32 * 2 * 128   ' not validated from ecu, maximum value to which the fuelmap item can be set
        minval = 12 * 2 * 5     ' not validated from ecu, minimum value to which the fuelmap item can be set

        m1 = Fuelmapgrid.Item(c, r).Value
        m2 = Int(ReadFlashWord(mapaddr_1 + (2 * (c + (r * mapcolumns)))) / 24) 'Int(ReadFlashWord((i * 2) + mapaddr_1) / 48)

        diff = Int(ReadFlashWord(mapaddr_1 + (2 * (c + (r * mapcolumns)))) / 24) - (Fuelmapgrid.Item(c, r).Value)

        m1 = (Int(ReadFlashWord(mapaddr_1 + (2 * (c + (r * mapcolumns)))) / 24) - diff) * 24
        m2 = (Int(ReadFlashWord(mapaddr_2 + (2 * (c + (r * mapcolumns)))) / 24) - diff) * 24
        m3 = (Int(ReadFlashWord(mapaddr_3 + (2 * (c + (r * mapcolumns)))) / 24) - diff) * 24
        m4 = (Int(ReadFlashWord(mapaddr_4 + (2 * (c + (r * mapcolumns)))) / 24) - diff) * 24

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


        WriteFlashWord(mapaddr_1 + (2 * (c + (r * mapcolumns))), m1)
        WriteFlashWord(mapaddr_2 + (2 * (c + (r * mapcolumns))), m2)
        WriteFlashWord(mapaddr_3 + (2 * (c + (r * mapcolumns))), m3)
        WriteFlashWord(mapaddr_4 + (2 * (c + (r * mapcolumns))), m4)

        ' now lets also update both IAP idlemaps if there are any changes to the idlemap area
        ' and also the other full size IAP map
        If Me.Text.Contains("IAP") Then

            '
            ' write the ms map values also on MS map as MS values are not used for e.g. Nitrous
            ' so its assumed that user wants to retain the IAP maps for MS use also...
            ' I.e. these are the IAP ms maps that get written together with IAP maps
            '
            WriteFlashWord(&H2DF04 + (2 * (c + (r * mapcolumns))), m1)
            WriteFlashWord(&H2E692 + (2 * (c + (r * mapcolumns))), m2)
            WriteFlashWord(&H2EE20 + (2 * (c + (r * mapcolumns))), m3)
            WriteFlashWord(&H2F5AE + (2 * (c + (r * mapcolumns))), m4)


            '
            ' then lets write both ms and normal idle map values
            '
            idle_mapaddr_1 = &H2D652
            idle_mapaddr_2 = &H2D770
            idle_mapaddr_3 = &H2D88E
            idle_mapaddr_4 = &H2D9AC

            idle_maprows = 8
            idle_mapcolumns = 15
            ' idlemap is located in these positions on the IAP map
            If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                'idlemap has 600rpm row as first row which is not existing in normal fuel map
                'if this is the first row, then copy also those values to the map just assuming 
                ' that 600rpm is the same as 800rpm
                If r = 0 Then
                    WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                End If
                WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
            End If

            idle_mapaddr_1 = &H31DE2
            idle_mapaddr_2 = &H31F00
            idle_mapaddr_3 = &H3201E
            idle_mapaddr_4 = &H3213C

            idle_maprows = 8
            idle_mapcolumns = 15
            ' idlemap is located in these positions on the IAP map
            If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                'idlemap has 600rpm row as first row which is not existing in normal fuel map
                'if this is the first row, then copy also those values to the map just assuming 
                ' that 600rpm is the same as 800rpm
                If r = 0 Then
                    WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                End If
                WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
            End If
        Else
            If Me.Text.Contains("MS") Then

                '
                ' Not an IAP map, so lets write the MS TPS idle maps
                '

                idle_mapaddr_1 = &H2DA6C
                idle_mapaddr_2 = &H2DBC0
                idle_mapaddr_3 = &H2DCBA
                idle_mapaddr_4 = &H2DDB4

                idle_maprows = 8
                idle_mapcolumns = 13
                ' idlemap is located in these positions on the IAP map
                If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                    'idlemap has 600rpm row as first row which is not existing in normal fuel map
                    'if this is the first row, then copy also those values to the map just assuming 
                    ' that 600rpm is the same as 800rpm
                    If r = 0 Then
                        WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                        WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                        WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                        WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                    End If
                    WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
                End If
            Else
                '
                ' Not a MS TPS idle maps so must be normal TPS idle map
                '

                idle_mapaddr_1 = &H32256
                idle_mapaddr_2 = &H32350
                idle_mapaddr_3 = &H3244A
                idle_mapaddr_4 = &H32544

                idle_maprows = 8
                idle_mapcolumns = 13
                ' idlemap is located in these positions on the IAP map
                If c >= 3 And c <= 17 And r >= 0 And r <= 6 Then
                    'idlemap has 600rpm row as first row which is not existing in normal fuel map
                    'if this is the first row, then copy also those values to the map just assuming 
                    ' that 600rpm is the same as 800rpm
                    If r = 0 Then
                        WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + (r * idle_mapcolumns))), m1)
                        WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + (r * idle_mapcolumns))), m2)
                        WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + (r * idle_mapcolumns))), m3)
                        WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + (r * idle_mapcolumns))), m4)
                    End If
                    WriteFlashWord(idle_mapaddr_1 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m1)
                    WriteFlashWord(idle_mapaddr_2 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m2)
                    WriteFlashWord(idle_mapaddr_3 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m3)
                    WriteFlashWord(idle_mapaddr_4 + (2 * ((c - 3) + ((r + 1) * idle_mapcolumns))), m4)
                End If

            End If

        End If


    End Sub

    Public Sub selectmap(ByVal map As Integer)
        ' map tracing function to be disabled when map is changed
        previousrow = 0

        Select Case map
            Case 1
                mapaddr_1 = &H2B5B0
                mapaddr_2 = &H2BDEE
                mapaddr_3 = &H2C62C
                mapaddr_4 = &H2CE6A

                maprows = 43
                mapcolumns = 23
                Me.Text = "ECUeditor - Fuel TPS/RPM map"
            Case 2
                mapaddr_1 = &H29774
                mapaddr_2 = &H29F02
                mapaddr_3 = &H2A690
                mapaddr_4 = &H2AE1E

                maprows = 43
                mapcolumns = 21
                Me.Text = "ECUeditor - Fuel IAP/RPM map"
            Case 3
                mapaddr_1 = &H2D652
                mapaddr_2 = &H2D770
                mapaddr_3 = &H2D88E
                mapaddr_4 = &H2D9AC

                maprows = 8
                mapcolumns = 15
                Me.Text = "ECUeditor - Fuel IAP/RPM Idle map"

            Case 4
                mapaddr_1 = &H2FD40
                mapaddr_2 = &H3057E
                mapaddr_3 = &H30DBC
                mapaddr_4 = &H315FA

                maprows = 43
                mapcolumns = 23
                Me.Text = "ECUeditor - Fuel MS TPS/RPM map"

        End Select
        rr = 0
        cc = 0

        mapvisible = Me.Text
        If Me.Text.Contains("TPS") Then TPSmap = True Else TPSmap = False
        loadmap()
    End Sub
    Public Sub loadmap()

        Dim i As Integer
        Dim ii As Integer
        Dim c As Integer
        Dim r As Integer
        B_unify.Visible = False
        i = 0
        ii = 0

        Fuelmapgrid.ColumnCount = mapcolumns
        If maprows > 42 Then
            Fuelmapgrid.RowCount = 42
        Else
            Fuelmapgrid.RowCount = maprows
        End If


        c = 0
        r = 0
        Do While c < mapcolumns
            i = Int((ReadFlashWord(mapaddr_1 - (2 * maprows) - (2 * mapcolumns) + (c * 2))) / 256) ' * 0.00152587890625)
            If TPSmap Then
                Fuelmapgrid.Columns.Item(c).HeaderText = CalcTPS(i)
            Else
                Fuelmapgrid.Columns.Item(c).HeaderText = Str(i)
            End If
            Fuelmapgrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        c = 0
        r = 0

        Fuelmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < maprows) And (r < 42)
            Fuelmapgrid.Rows.Item(r).HeaderCell.Value = Str((ReadFlashWord(mapaddr_1 - (2 * maprows) + (r * 2)) / 2.56))
            Fuelmapgrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop


        c = 0
        r = 0
        i = 0
        Do While (r < maprows) And (r < 42)

            Fuelmapgrid.Item(c, r).Value = Int(ReadFlashWord((i * 2) + mapaddr_1) / 24) '48
            setCellColour(c, r)
            If Not (ReadFlashWord((i * 2) + mapaddr_1) = ReadFlashWord((i * 2) + mapaddr_2)) Then
                B_unify.Visible = True
            End If

            If c < mapcolumns - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

        Fuelmapgrid.AllowUserToAddRows = False
        Fuelmapgrid.AllowUserToDeleteRows = False
        Fuelmapgrid.AllowUserToOrderColumns = False
        Fuelmapgrid.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Sub


    Public Sub tracemap()
        Dim c As Integer
        Dim r As Integer

        setCellColour(cc, rr)

        ' enable automatic map switching when tracing and datastream on

        r = maprows
        c = mapcolumns

        r = 0
        rr = 0
        Do While (r < maprows - 1)
            If RPM >= rr And RPM < Int(Fuelmapgrid.Rows(r + 1).HeaderCell.Value) Then
                rr = r
                r = 256
            Else
                r = r + 1
                rr = Int(Fuelmapgrid.Rows(r).HeaderCell.Value)
            End If
        Loop

        If TPSmap Then
            '
            ' Process TPS maps
            '
            c = 0
            cc = 0
            If CalcTPSDec(TPS) < Val(Fuelmapgrid.Columns.Item(mapcolumns - 1).HeaderCell.Value) Then
                Do While (c < mapcolumns - 1)
                    If CalcTPSDec(TPS) >= cc And CalcTPSDec(TPS) < Fuelmapgrid.Columns.Item(c + 1).HeaderCell.Value Then
                        cc = c
                        c = 256
                    Else
                        c = c + 1
                        cc = Int(Fuelmapgrid.Columns.Item(c).HeaderCell.Value)
                    End If
                Loop
            Else
                cc = mapcolumns - 1
            End If
        Else
            '
            ' Process IAP maps
            '
            c = 0
            cc = 256
            Do While (c < mapcolumns - 1)
                If IAP <= cc And IAP > CInt(Fuelmapgrid.Columns.Item(c + 1).HeaderCell.Value) Then
                    cc = c
                    c = 256
                Else
                    c = c + 1
                    cc = CInt(Fuelmapgrid.Columns.Item(c).HeaderCell.Value)
                End If
            Loop
        End If

        If rr > maprows Then rr = 0
        If rr < 0 Then rr = 0
        If cc > mapcolumns Then cc = 0
        If cc < 0 Then cc = 0
        If rr <> 0 Or cc <> 0 Then
            Fuelmapgrid.Item(cc, rr).Style.BackColor = Color.Blue
        Else
            setCellColour(cc, rr)
        End If
    End Sub
    Private Sub B_TPSMAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_TPS.Click
        selectmap(1)
    End Sub

    Private Sub B_IAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_IAP.Click
        selectmap(2)
    End Sub

    Private Sub B_Idle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectmap(3)
    End Sub
    Private Sub B_MSTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MSTP.Click
        selectmap(4)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub



    Private Sub show_values()
        Dim istr As String
        Dim r As Integer
        Dim c As Integer
        Dim v As Integer
        Dim msrpm As Integer

        istr = ""

        rowselected = Fuelmapgrid.CurrentRow.Index

        Try
            If Fuelmapgrid.CurrentRow.Index <> previousrow And previousrow <= maprows Then
                Fuelmapgrid.CurrentRow.Height = 20
                Fuelmapgrid.Rows.Item(previousrow).Height = 15
                previousrow = Fuelmapgrid.CurrentRow.Index
            Else
                previousrow = Fuelmapgrid.CurrentRow.Index
            End If

            istr = Str(Fuelmapgrid.Columns.Item(Fuelmapgrid.CurrentCell.ColumnIndex).HeaderCell.Value)

            T_RPM.Text = Fuelmapgrid.CurrentRow.HeaderCell.Value & " rpm"
            If Me.Text.Contains("TPS") Then
                T_TPSIAP.Text = "TPS = " & istr & "%"
            Else
                T_TPSIAP.Text = "IAP = " & istr
            End If

            r = Fuelmapgrid.CurrentRow.Index
            c = Fuelmapgrid.CurrentCell.ColumnIndex
            v = Int(ReadFlashWord(((((mapcolumns * r) + c) * 2) + mapaddr_1)) / 24) - Int(ReadFlashWordCopy((((mapcolumns * r) + c) * 2) + mapaddr_1) / 24)
            If v > 0 Then
                T_valdiff.Text = "+" & Str(v)
            Else
                T_valdiff.Text = Str(v)
            End If

            msrpm = 1 / (Fuelmapgrid.CurrentRow.HeaderCell.Value / 60) * 1000 * 2
            'T_duty.Text = Int((100 * Int(ReadFlashWord(((((mapcolumns * r) + c) * 2) + mapaddr_1)) / 24) / 19) / msrpm) & "%"


        Catch ex As Exception
        End Try

    End Sub
    Private Sub Fuelmapgrid_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Fuelmapgrid.MouseClick
        show_values()
    End Sub

    Private Sub Fuelmapgrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Fuelmapgrid.CellEnter
        show_values()
    End Sub


    Private Sub copy_tps_to_ms_map()
        '
        ' This subroutine copies the TPS map contents into MS map
        '
        Dim i As Integer
        If TPSmap Then
            i = MsgBox("Copy the TPS map contents to MS map, the old MS map will be deleted", MsgBoxStyle.OkCancel)
            If i = 1 Then ' OK pressed
                i = 0
                Do While (i < (((maprows) * (mapcolumns))))
                    WriteFlashWord(((i * 2) + &H2FD40), ReadFlashWord((i * 2) + &H2B5B0))
                    WriteFlashWord(((i * 2) + &H3057E), ReadFlashWord((i * 2) + &H2BDEE))
                    WriteFlashWord(((i * 2) + &H30DBC), ReadFlashWord((i * 2) + &H2C62C))
                    WriteFlashWord(((i * 2) + &H315FA), ReadFlashWord((i * 2) + &H2CE6A))
                    i = i + 1
                Loop
            End If
        End If

    End Sub

    Private Sub unify()
        Dim i As Integer

        Do While (i < (((maprows) * (mapcolumns))))
            WriteFlashWord(((i * 2) + mapaddr_2), ReadFlashWord((i * 2) + mapaddr_1))
            WriteFlashWord(((i * 2) + mapaddr_3), ReadFlashWord((i * 2) + mapaddr_1))
            WriteFlashWord(((i * 2) + mapaddr_4), ReadFlashWord((i * 2) + mapaddr_1))
            i = i + 1
        Loop
        B_unify.Visible = False
    End Sub

    Private Sub B_unify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_unify.Click
        If MsgBox("This will unify cylinder specific fuelmaps to this map, do you agree", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            unify()
            B_unify.Visible = False
        End If
    End Sub


End Class