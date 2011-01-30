Imports System.Windows.Forms.DataVisualization.Charting

Public Class graph

    Private Sub graph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim X, Y, i As Integer

        For Y = 1 To GixxerFuelmap.Fuelmapgrid.RowCount
            Chart1.Series.Add(Y)
        Next

        For Y = 1 To GixxerFuelmap.Fuelmapgrid.RowCount - 1
            Chart1.Series(Y).ChartType = SeriesChartType.Line
            For X = 1 To GixxerFuelmap.Fuelmapgrid.ColumnCount - 1
                i = GixxerFuelmap.Fuelmapgrid(X, Y).Value
                Chart1.Series(Y).Points.AddY(i)
            Next
        Next

    End Sub

End Class