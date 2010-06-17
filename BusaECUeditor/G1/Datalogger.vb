Public Class Datalogger
    Private Sub Datalogger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AxEChartCtl1.GraphUpdateSpeedInMS = 500
        AxEChartCtl2.GraphUpdateSpeedInMS = 500
        AxEChartCtl1.GraphMaximum = 14000
        AxEChartCtl2.GraphMaximum = 100
    End Sub

End Class