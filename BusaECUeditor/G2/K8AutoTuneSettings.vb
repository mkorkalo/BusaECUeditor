Public Class K8AutoTuneSettings

    Private Sub K8AutoTuneSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        NUD_AutoTuneMinAvgAFR.Value = My.Settings.AutoTuneMinAvgAFR
        NUD_AutoTuneMaxAvgAFR.Value = My.Settings.AutoTuneMaxAvgAFR
        NUD_AutoTuneMaxPercentageFuelMapChange.Value = My.Settings.AutoTuneMaxPercentageFuelMapChange
        NUD_AutoTuneMinNumberLoggedValuesInCell.Value = My.Settings.AutoTuneMinNumberLoggedValuesInCell

    End Sub

    Private Sub B_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Ok.Click

        My.Settings.AutoTuneMinAvgAFR = NUD_AutoTuneMinAvgAFR.Value
        My.Settings.AutoTuneMaxAvgAFR = NUD_AutoTuneMaxAvgAFR.Value
        My.Settings.AutoTuneMaxPercentageFuelMapChange = NUD_AutoTuneMaxPercentageFuelMapChange.Value
        My.Settings.AutoTuneMinNumberLoggedValuesInCell = NUD_AutoTuneMinNumberLoggedValuesInCell.Value
        My.Settings.Save()

        Me.Close()

    End Sub

    Private Sub B_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Cancel.Click

        Me.Close()

    End Sub

End Class