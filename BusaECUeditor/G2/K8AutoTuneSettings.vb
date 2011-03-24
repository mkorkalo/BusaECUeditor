Public Class K8AutoTuneSettings

    Private Sub K8AutoTuneSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        NUD_AutoTuneMinAvgAFR.Value = My.Settings.AutoTuneMinAvgAFR
        NUD_AutoTuneMaxAvgAFR.Value = My.Settings.AutoTuneMaxAvgAFR
        NUD_AFRStdDev.Value = My.Settings.AutoTuneCellStdDev
        NUD_AutoTuneTimeWindow.Value = My.Settings.AutoTuneTimeWindow
        NUD_AutoTuneMaxPercentageFuelMapChange.Value = My.Settings.AutoTuneMaxPercentageFuelMapChange
        NUD_AutoTuneMinNumberLoggedValuesInCell.Value = My.Settings.AutoTuneMinNumberLoggedValuesInCell
        TB_AutoTuneStrength.Value = My.Settings.AutoTuneStrength
        L_AutoTuneStrength.Text = TB_AutoTuneStrength.Value.ToString() & " %"
        NUD_ExhaustGasVelocityOffset.Value = My.Settings.AutoTuneExhaustGasOffset

    End Sub

    Private Sub B_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Ok.Click

        My.Settings.AutoTuneMinAvgAFR = NUD_AutoTuneMinAvgAFR.Value
        My.Settings.AutoTuneMaxAvgAFR = NUD_AutoTuneMaxAvgAFR.Value
        My.Settings.AutoTuneCellStdDev = NUD_AFRStdDev.Value
        My.Settings.AutoTuneTimeWindow = NUD_AutoTuneTimeWindow.Value
        My.Settings.AutoTuneMaxPercentageFuelMapChange = NUD_AutoTuneMaxPercentageFuelMapChange.Value
        My.Settings.AutoTuneMinNumberLoggedValuesInCell = NUD_AutoTuneMinNumberLoggedValuesInCell.Value
        My.Settings.AutoTuneStrength = TB_AutoTuneStrength.Value
        My.Settings.AutoTuneExhaustGasOffset = NUD_ExhaustGasVelocityOffset.Value
        My.Settings.Save()

        K8EngineDataViewer.ClearData()
        K8EngineDataViewer.OpenFile()

        Me.Close()

    End Sub

    Private Sub B_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Cancel.Click

        Me.Close()

    End Sub

    Private Sub TB_AutoTuneStrength_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AutoTuneStrength.Scroll

        L_AutoTuneStrength.Text = TB_AutoTuneStrength.Value.ToString() & " %"

    End Sub
End Class