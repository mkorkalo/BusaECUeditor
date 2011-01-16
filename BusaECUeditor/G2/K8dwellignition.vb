Imports System.Windows.Forms

Public Class K8dwellignition

    Dim change As Integer = 1


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub generate_dwell_table()
        Dim c, r, i As Integer

        '
        ' Generate column headings
        '
        D_dwell.ColumnCount = 9
        c = 0
        Do While c < D_dwell.ColumnCount
            D_dwell.Columns.Item(c).HeaderText = Replace(Format((ReadFlashByte(&H733C0 + c)) / 12.7, "#0.0"), ",", ".")
            D_dwell.Columns.Item(c).Width = 40
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        D_dwell.RowCount = 20
        D_dwell.RowHeadersWidth = 80
        For i = 1 To D_dwell.RowCount
            D_dwell.Rows.Item(i - 1).HeaderCell.Value = Str(Int(ReadFlashWord(&H72C08 + (2 * (i - 1))) / 2.56))
        Next



        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_dwell.RowCount)

            D_dwell.Item(c, r).Value = ReadFlashByte((i) + &H733C9)

            If c < D_dwell.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub K8clutchedignition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MsgBox("Dwell setting is fairly untested feature, please use with caution !!!")
        generate_dwell_table()
    End Sub

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_dwell.SelectedCells.Count()

        Do While (r < D_dwell.RowCount)

            If D_dwell.Item(c, r).Selected And n > 0 Then
                D_dwell.Item(c, r).Value = D_dwell.Item(c, r).Value - decrease
                n = n - 1
            End If

            If c < D_dwell.ColumnCount - 1 Then
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

        n = D_dwell.SelectedCells.Count()

        Do While (r < D_dwell.RowCount)

            If D_dwell.Item(c, r).Selected And n > 0 Then
                D_dwell.Item(c, r).Value = Int(D_dwell.Item(c, r).Value / 1.05)
                n = n - 1
            End If

            If c < D_dwell.ColumnCount - 1 Then
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

        n = D_dwell.SelectedCells.Count()

        Do While (r < D_dwell.RowCount)

            If D_dwell.Item(c, r).Selected And n > 0 Then
                D_dwell.Item(c, r).Value = Int(D_dwell.Item(c, r).Value * 1.05)
                n = n - 1
            End If

            If c < D_dwell.ColumnCount - 1 Then
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


        n = D_dwell.SelectedCells.Count()

        Do While (r < D_dwell.RowCount) And n > 0

            If D_dwell.Item(c, r).Selected And n > 0 Then
                D_dwell.Item(c, r).Value = D_dwell.Item(c, r).Value + increase
                n = n - 1
            End If

            If c < D_dwell.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub


    Private Sub D_ramair_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles D_dwell.KeyPress
        ' this is the user interface shortcut keys processor
        Select Case e.KeyChar
            Case "+"
                IncreaseSelectedCells()
            Case "-"
                DecreaseSelectedCells()
            Case "P"
                printthis()
            Case "p"
                printthis()
            Case Chr(27)
                Me.Close()
        End Select

        writemaptoflash()

    End Sub


    Private Sub writemaptoflash()
        Dim r, c, i As Integer
        '
        ' Copy grid contents to the bin
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_dwell.RowCount)
            If D_dwell.Item(c, r).Value < 0 Then
                D_dwell.Item(c, r).Value = 0
                MsgBox("Min value exceeded, using min value")
            End If
            If D_dwell.Item(c, r).Value > 255 Then
                D_dwell.Item(c, r).Value = 255
                MsgBox("Max value exceeded, using max value")
            End If

            WriteFlashByte(i + &H733C9, (D_dwell.Item(c, r).Value))
            If c < D_dwell.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

End Class
