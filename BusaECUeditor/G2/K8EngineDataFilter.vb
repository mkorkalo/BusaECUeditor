Public Class K8EngineDataFilter

    Private Sub K8EngineDataFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        C_FilterCLT80.Checked = My.Settings.FilterCLT80
        C_GearNeutral.Checked = My.Settings.FilterGearNeutral
        C_FilterClutchIn.Checked = My.Settings.FilterClutchIn
        C_FilterZeroRPM.Checked = My.Settings.FilterZeroRPMData
        NUD_FilterAFRLessThan.Value = My.Settings.FilterAFRLessThan
        NUD_FilterAFRGreaterThan.Value = My.Settings.FilterAFRGreaterThan
        C_FilterIAPDecel.Checked = My.Settings.FilterIAPDecl

        C_FilterCellTransitions.Checked = My.Settings.AutoTuneFilterTransitions
        NUD_AutoTuneFilterTransitionsIAP.Value = My.Settings.AutoTuneFilterTransitionsIAP
        NUD_AutoTuneFilterTransitionsTPS.Value = My.Settings.AutoTuneFilterTransitionsTPS

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        My.Settings.FilterCLT80 = C_FilterCLT80.Checked
        My.Settings.FilterClutchIn = C_FilterClutchIn.Checked
        My.Settings.FilterGearNeutral = C_GearNeutral.Checked
        My.Settings.FilterZeroRPMData = C_FilterZeroRPM.Checked
        My.Settings.FilterAFRLessThan = NUD_FilterAFRLessThan.Value
        My.Settings.FilterAFRGreaterThan = NUD_FilterAFRGreaterThan.Value
        My.Settings.FilterIAPDecl = C_FilterIAPDecel.Checked
        My.Settings.AutoTuneFilterTransitions = C_FilterCellTransitions.Checked
        My.Settings.AutoTuneFilterTransitionsIAP = NUD_AutoTuneFilterTransitionsIAP.Value
        My.Settings.AutoTuneFilterTransitionsTPS = NUD_AutoTuneFilterTransitionsTPS.Value
        My.Settings.Save()

        K8EngineDataViewer.ClearData()
        K8EngineDataViewer.OpenFiles()

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub C_FilterCellTransitions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_FilterCellTransitions.CheckedChanged

        If C_FilterCellTransitions.Checked Then
            L_AutoTuneFilterTransitionsIAP.Enabled = True
            NUD_AutoTuneFilterTransitionsIAP.Enabled = True

            L_AutoTuneFilterTransitionsTPS.Enabled = True
            NUD_AutoTuneFilterTransitionsTPS.Enabled = True
        Else
            L_AutoTuneFilterTransitionsIAP.Enabled = False
            NUD_AutoTuneFilterTransitionsIAP.Enabled = False

            L_AutoTuneFilterTransitionsTPS.Enabled = False
            NUD_AutoTuneFilterTransitionsTPS.Enabled = False
        End If

    End Sub
End Class