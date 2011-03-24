Imports System.Windows.Forms.DataVisualization.Charting

Public Class GixxerFuelGraph
    Dim s As System.Object = GixxerFuelmap.Fuelmapgrid

    Public Sub redraw()
        Dim x, y, i As Integer

        For y = 1 To s.RowCount - 1
            Chart1.Series(y).ChartType = SeriesChartType.Line
            For x = 1 To s.ColumnCount - 1
                i = s.item(x, y).Value
                Chart1.Series(y).Points.Item(x - 1).SetValueY(i)
            Next
        Next

    End Sub

    Private Sub graph_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x, y, i As Integer

        For y = 1 To s.RowCount
            Chart1.Series.Add(y)
        Next
        For y = 1 To s.RowCount - 1
            Chart1.Series(y).ChartType = SeriesChartType.Line
            For x = 1 To s.ColumnCount - 1
                i = s.item(x, y).Value
                Chart1.Series(y).Points.AddY(i)
            Next
        Next

    End Sub
End Class