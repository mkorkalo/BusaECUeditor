Public Class BoostFuelTypeDialog

    Private Sub B_Extended_Click(sender As System.Object, e As System.EventArgs) Handles B_Extended.Click
        BoostFuelMode = 1
        Close()
    End Sub

    Private Sub B_Legacy_Click(sender As System.Object, e As System.EventArgs) Handles B_Legacy.Click
        BoostFuelMode = 2
        Close()
    End Sub

End Class