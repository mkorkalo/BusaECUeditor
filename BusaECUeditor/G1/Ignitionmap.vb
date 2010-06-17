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

    Dim ignmapaddr_A1 As Integer
    Dim ignmapaddr_B1 As Integer
    Dim ignmapaddr_A2 As Integer
    Dim ignmapaddr_B2 As Integer
    Dim ignmapaddr_A34 As Integer
    Dim ignmapaddr_B34 As Integer
    Dim ignmapaddr_A56 As Integer
    Dim ignmapaddr_B56 As Integer

    Dim ign_sub As Decimal
    Dim ign_div As Integer
    Dim ign_mul As Integer
    Dim ign_rpmcomp As Integer


    Private Function igndeg(ByVal i As Integer)
        '(CInt((i * 1.31) - 3.5) + (0.75 * RPM / 1000))
        Return CInt(i)
    End Function
    Private Sub Ignitionmap_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Ignitionmapvisible = False
    End Sub

    Private Sub Ignitionmap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        change = 1 ' default change to map when pressing +/-
        previousrow = 0
        ign_sub = 0
        ign_div = 256
        ign_mul = 66
        selectmap(1)
        Ignitionmapvisible = True

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

        Do While (r < ignmaprows) And (r < 42)

            If Ignitionmapgrid.Item(c, r).Selected And n > 0 Then
                Ignitionmapgrid.Item(c, r).Value = Ignitionmapgrid.Item(c, r).Value - decrease
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < ignmapcolumns - 1 Then
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

        diff = (((readflashbyte(ignmapaddr_A + (1 * (c + (r * ignmapcolumns))))))) - (((readflashbytecopy(ignmapaddr_A + (1 * (c + (r * ignmapcolumns)))))))

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

        Do While (r < (ignmaprows - 1)) And (r < 42) And n > 0

            If Ignitionmapgrid.Item(c, r).Selected And n > 0 Then
                Ignitionmapgrid.Item(c, r).Value = Ignitionmapgrid.Item(c, r).Value + increase
                SetFlashItem(c, r)
                setCellColour(c, r)
                n = n - 1
            End If

            If c < ignmapcolumns - 1 Then
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
        m2 = igndeg((readflashbyte(ignmapaddr_A + (1 * (c + (r * ignmapcolumns)))) / ign_div) * ign_mul - ign_sub)

        diff = m2 - m1

        m1 = (((CInt((readflashbyte(ignmapaddr_A + (1 * (c + (r * ignmapcolumns)))) / ign_div) * ign_mul - ign_sub) - diff) + ign_sub) / ign_mul * ign_div)
        m2 = (((CInt((readflashbyte(ignmapaddr_B + (1 * (c + (r * ignmapcolumns)))) / ign_div) * ign_mul - ign_sub) - diff) + ign_sub) / ign_mul * ign_div)

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
        writeflashbyte(ignmapaddr_A1 + (1 * (c + (r * ignmapcolumns))), m1)
        writeflashbyte(ignmapaddr_B1 + (1 * (c + (r * ignmapcolumns))), m2)
        writeflashbyte(ignmapaddr_A2 + (1 * (c + (r * ignmapcolumns))), m1)
        writeflashbyte(ignmapaddr_B2 + (1 * (c + (r * ignmapcolumns))), m2)
        writeflashbyte(ignmapaddr_A34 + (1 * (c + (r * ignmapcolumns))), m1)
        writeflashbyte(ignmapaddr_B34 + (1 * (c + (r * ignmapcolumns))), m2)
        writeflashbyte(ignmapaddr_A56 + (1 * (c + (r * ignmapcolumns))), m1)
        writeflashbyte(ignmapaddr_B56 + (1 * (c + (r * ignmapcolumns))), m2)

    End Sub

    Public Sub selectmap(ByVal map As Integer)

        ' map tracing function to be disabled when map is changed
        previousrow = 0

        Select Case map
            Case 1
                ignmapaddr_A1 = &H32D12
                ignmapaddr_B1 = &H330C4
                ignmapaddr_A2 = &H33476
                ignmapaddr_B2 = &H33828
                ignmapaddr_A34 = &H33BDA
                ignmapaddr_B34 = &H33F8C
                ignmapaddr_A56 = &H3433E
                ignmapaddr_B56 = &H346F0

                ignmapaddr_A = ignmapaddr_A56
                ignmapaddr_B = ignmapaddr_B56
                ignmaprows = 36
                ignmapcolumns = 23
                Me.Text = "ECUeditor - Ignitionmap for all gears"
            Case 2
                ignmapaddr_A1 = &H34AA2
                ignmapaddr_B1 = &H34E54
                ignmapaddr_A2 = &H35206
                ignmapaddr_B2 = &H355B8
                ignmapaddr_A34 = &H3596A
                ignmapaddr_B34 = &H35D1C
                ignmapaddr_A56 = &H360CE
                ignmapaddr_B56 = &H36480

                ignmapaddr_A = ignmapaddr_A56
                ignmapaddr_B = ignmapaddr_B56

                ignmaprows = 36
                ignmapcolumns = 23
                Me.Text = "ECUeditor - MS Ignitionmap for all gears"
        End Select
        irr = 0
        icc = 0
        loadmap()
        '
        ' Inform the user that individual gear specific ignitionmaps are now gone
        ' and copy gear 56 map to all maps
        '
        If readflashword(ignmapaddr_A56 + (ignmaprows * ignmapcolumns) - 12) <> readflashword(ignmapaddr_A1 + (ignmaprows * ignmapcolumns) - 12) Then
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
        Do While (r < ignmaprows) And (r < 42)

            writeflashbyte(i + ignmapaddr_A1, (readflashbyte(i + ignmapaddr_A)))
            writeflashbyte(i + ignmapaddr_B1, (readflashbyte(i + ignmapaddr_B)))
            writeflashbyte(i + ignmapaddr_A2, (readflashbyte(i + ignmapaddr_A)))
            writeflashbyte(i + ignmapaddr_B2, (readflashbyte(i + ignmapaddr_B)))
            writeflashbyte(i + ignmapaddr_A34, (readflashbyte(i + ignmapaddr_A)))
            writeflashbyte(i + ignmapaddr_B34, (readflashbyte(i + ignmapaddr_B)))

            If c < ignmapcolumns - 1 Then
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

        Ignitionmapgrid.ColumnCount = ignmapcolumns
        If maprows > 42 Then
            Ignitionmapgrid.RowCount = 42
        Else
            Ignitionmapgrid.RowCount = ignmaprows
        End If


        c = 0
        r = 0
        Do While c < ignmapcolumns
            i = Int((readflashword(ignmapaddr_A - (2 * ignmaprows) - (2 * ignmapcolumns) + (c * 2))) / 256) ' * 0.00152587890625)
            Ignitionmapgrid.Columns.Item(c).HeaderText = calc_TPS(i)
            Ignitionmapgrid.Columns.Item(c).Width = 26
            c = c + 1
        Loop

        c = 0
        r = 0

        Ignitionmapgrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Do While (r < ignmaprows) And (r < 42)
            Ignitionmapgrid.Rows.Item(r).HeaderCell.Value = Str((readflashword(ignmapaddr_A - (2 * ignmaprows) + (r * 2)) / 2.56))
            Ignitionmapgrid.Rows.Item(r).Height = 15
            r = r + 1
        Loop


        c = 0
        r = 0
        i = 0
        Do While (r < ignmaprows) And (r < 42)

            Ignitionmapgrid.Item(c, r).Value = igndeg(readflashbyte((i) + ignmapaddr_A) / ign_div * ign_mul - ign_sub)
            setCellColour(c, r)
            If Not (readflashword(i + ignmapaddr_A) = readflashword(i + ignmapaddr_B)) Then
                B_unify.Visible = True
            End If

            If c < ignmapcolumns - 1 Then
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

        setCellColour(icc, irr)

        ' enable automatic map switching when tracing and datastream on

        r = ignmaprows
        c = ignmapcolumns

        r = 0
        irr = 0
        Do While (r < ignmaprows - 1)
            If RPM >= irr And RPM < Int(Ignitionmapgrid.Rows(r + 1).HeaderCell.Value) Then
                irr = r
                r = 256
            Else
                r = r + 1
                irr = Int(Ignitionmapgrid.Rows(r).HeaderCell.Value)
            End If
        Loop

        c = 0
        icc = 0
        If calc_TPS_dec(TPS) < Val(Ignitionmapgrid.Columns.Item(ignmapcolumns - 1).HeaderCell.Value) Then
            Do While (c < ignmapcolumns - 1)
                If calc_TPS_dec(TPS) >= icc And calc_TPS_dec(TPS) < Ignitionmapgrid.Columns.Item(c + 1).HeaderCell.Value Then
                    icc = c
                    c = 256
                Else
                    c = c + 1
                    icc = Int(Ignitionmapgrid.Columns.Item(c).HeaderCell.Value)
                End If
            Loop
        Else
            icc = ignmapcolumns - 1
        End If

        If irr > ignmaprows Then irr = 0
        If irr < 0 Then irr = 0
        If icc > ignmapcolumns Then icc = 0
        If icc < 0 Then icc = 0
        If irr <> 0 Or icc <> 0 Then
            Ignitionmapgrid.Item(icc, irr).Style.BackColor = Color.Blue
        Else
            setCellColour(icc, irr)
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
        ignrowselected = Ignitionmapgrid.CurrentRow.Index


        Try
            If Ignitionmapgrid.CurrentRow.Index <> previousrow And previousrow <= ignmaprows Then
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
            v = (Int(readflashbyte(((((ignmapcolumns * r) + c)) + ignmapaddr_A)) / ign_div * ign_mul - ign_sub) - Int(readflashbytecopy((((ignmapcolumns * r) + c)) + ignmapaddr_A) / ign_div * ign_mul - ign_sub))
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

        Do While (i < (ignmaprows * ignmapcolumns))
            writeflashword((i + ignmapaddr_B), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_A1), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_B1), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_A2), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_B2), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_A34), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_B34), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_A56), readflashword(i + ignmapaddr_A))
            writeflashword((i + ignmapaddr_B56), readflashword(i + ignmapaddr_A))
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
                writeflashword((i + &H34AA2), readflashword(i + &H32D12))
                writeflashword((i + &H34E54), readflashword(i + &H330C4))
                writeflashword((i + &H35206), readflashword(i + &H33476))
                writeflashword((i + &H355B8), readflashword(i + &H33828))
                writeflashword((i + &H3596A), readflashword(i + &H33BDA))
                writeflashword((i + &H35D1C), readflashword(i + &H33F8C))
                writeflashword((i + &H360CE), readflashword(i + &H3433E))
                writeflashword((i + &H36480), readflashword(i + &H346F0))
                i = i + 1
            Loop
        End If

    End Sub

End Class