﻿Imports System.Windows.Forms

Public Class Gixxerramair


    Dim change As Integer = 1


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub generate_ramair_table()
        Dim c, r, i As Integer

        '
        ' Generate column headings
        '
        D_ramair.ColumnCount = 20
        c = 0
        Do While c < D_ramair.ColumnCount
            D_ramair.Columns.Item(c).HeaderText = Int(ReadFlashWord(gixxerramair_columnheader + (2 * c)) / 2.56)
            D_ramair.Columns.Item(c).Width = 40
            c = c + 1
        Loop

        '
        ' Generate row headings
        '
        D_ramair.RowCount = 6

        D_ramair.RowHeadersWidth = 80
        For i = 1 To 6
            D_ramair.Rows.Item(i - 1).HeaderCell.Value = "Gear " & Str(i)
        Next



        '
        ' Generate map contents into a grid
        '
        c = 0
        r = 0
        i = 0
        Do While (r < D_ramair.RowCount)

            D_ramair.Item(c, r).Value = ReadFlashByte((i) + gixxerramair_map)

            If c < D_ramair.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub K8ramair_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Ramair editing - " & gixxer_modelname
        generate_ramair_table()
    End Sub

    Private Sub DecreaseSelectedCells()
        Dim c As Integer
        Dim r As Integer
        Dim i As Integer
        Dim n As Integer

        Dim decrease As Integer


        decrease = change ' This is the amount that value is decreased when pressing "-"

        i = 0

        n = D_ramair.SelectedCells.Count()

        Do While (r < D_ramair.RowCount)

            If D_ramair.Item(c, r).Selected And n > 0 Then
                D_ramair.Item(c, r).Value = D_ramair.Item(c, r).Value - decrease
                n = n - 1
            End If

            If c < D_ramair.ColumnCount - 1 Then
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

        n = D_ramair.SelectedCells.Count()

        Do While (r < D_ramair.RowCount)

            If D_ramair.Item(c, r).Selected And n > 0 Then
                D_ramair.Item(c, r).Value = Int(D_ramair.Item(c, r).Value / 1.05)
                n = n - 1
            End If

            If c < D_ramair.ColumnCount - 1 Then
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

        n = D_ramair.SelectedCells.Count()

        Do While (r < D_ramair.RowCount)

            If D_ramair.Item(c, r).Selected And n > 0 Then
                D_ramair.Item(c, r).Value = Int(D_ramair.Item(c, r).Value * 1.05)
                n = n - 1
            End If

            If c < D_ramair.ColumnCount - 1 Then
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


        n = D_ramair.SelectedCells.Count()

        Do While (r < D_ramair.RowCount) And n > 0

            If D_ramair.Item(c, r).Selected And n > 0 Then
                D_ramair.Item(c, r).Value = D_ramair.Item(c, r).Value + increase
                n = n - 1
            End If

            If c < D_ramair.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub


    Private Sub D_ramair_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles D_ramair.KeyPress
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
        Do While (r < D_ramair.RowCount)
            If D_ramair.Item(c, r).Value < 0 Then
                D_ramair.Item(c, r).Value = 0
                MsgBox("Min value exceeded, using min value")
            End If
            If D_ramair.Item(c, r).Value > 255 Then
                D_ramair.Item(c, r).Value = 255
                MsgBox("Max value exceeded, using max value")
            End If

            WriteFlashByte(i + gixxerramair_map, (D_ramair.Item(c, r).Value))
            If c < D_ramair.ColumnCount - 1 Then
                c = c + 1
            Else
                c = 0
                r = r + 1
            End If
            i = i + 1
        Loop

    End Sub

    Private Sub Gixxerramair_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
