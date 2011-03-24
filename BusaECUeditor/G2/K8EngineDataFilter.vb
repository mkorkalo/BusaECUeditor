Public Class K8EngineDataFilter

    Private Sub K8EngineDataFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        C_FilterCLT80.Checked = My.Settings.FilterCLT80
        C_GearNeutral.Checked = My.Settings.FilterGearNeutral
        C_FilterClutchIn.Checked = My.Settings.FilterClutchIn
        NUD_FilterAFRLessThan.Value = My.Settings.FilterAFRLessThan
        NUD_FilterAFRGreaterThan.Value = My.Settings.FilterAFRGreaterThan

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        My.Settings.FilterCLT80 = C_FilterCLT80.Checked
        My.Settings.FilterClutchIn = C_FilterClutchIn.Checked
        My.Settings.FilterGearNeutral = C_GearNeutral.Checked
        My.Settings.FilterAFRLessThan = NUD_FilterAFRLessThan.Value
        My.Settings.FilterAFRGreaterThan = NUD_FilterAFRGreaterThan.Value
        My.Settings.Save()

        EngineDataViewer.ClearData()
        EngineDataViewer.OpenFile()

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub
End Class