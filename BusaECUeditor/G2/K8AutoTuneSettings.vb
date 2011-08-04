Public Class K8AutoTuneSettings

    Private Sub K8AutoTuneSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        NUD_AutoTuneMinAvgAFR.Value = My.Settings.AutoTuneMinAvgAFR
        NUD_AutoTuneMaxAvgAFR.Value = My.Settings.AutoTuneMaxAvgAFR
        NUD_AFRStdDev.Value = My.Settings.AutoTuneCellStdDev
        NUD_AutoTuneTimeWindow.Value = My.Settings.AutoTuneTimeWindow
        NUD_AutoTuneMapSmoothingStrength.Value = My.Settings.AutoTuneMapSmoothingStrength
        NUD_AutoTuneMaxPercentageFuelMapChange.Value = My.Settings.AutoTuneMaxPercentageFuelMapChange
        NUD_AutoTuneMinNumberLoggedValuesInCell.Value = My.Settings.AutoTuneMinNumberLoggedValuesInCell
        TB_AutoTuneStrength.Value = My.Settings.AutoTuneStrength
        L_AutoTuneStrength.Text = TB_AutoTuneStrength.Value.ToString() & " %"

        NUD_ExhaustGasVelocityOffset.Value = My.Settings.AutoTuneExhaustGasOffset
        NUD_MaxTimeOffset.Value = My.Settings.AutoTuneExhaustGasOffsetMaxTimeOffset
        NUD_EngineCapacity.Value = My.Settings.AutoTuneExhaustGasOffsetEngineCapacity
        NUD_MaxEngineRPM.Value = My.Settings.AutoTuneExhaustGasOffsetMaxEngineRPM
        NUD_HeaderPipeDiameter.Value = My.Settings.AutoTuneExhaustGasOffsetHeaderPipeDiameter
        NUD_HeaderPipeLength.Value = My.Settings.AutoTuneExhaustGasOffsetHeaderPipeLength

        If My.Settings.AutoTuneExhaustGasOffsetType = 1 Then
            R_ExhaustGasVelocityOffset1.Checked = True
        Else
            R_ExhaustGasVelocityOffset2.Checked = True
        End If

        C_BoostPressureSensor.Items.Add("GM 3 Bar")
        C_BoostPressureSensor.Items.Add("GM 3 Bar Ext")
        C_BoostPressureSensor.SelectedIndex = My.Settings.AutoTuneBoostPressureSensor

    End Sub

    Private Sub B_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Ok.Click

        My.Settings.AutoTuneMinAvgAFR = NUD_AutoTuneMinAvgAFR.Value
        My.Settings.AutoTuneMaxAvgAFR = NUD_AutoTuneMaxAvgAFR.Value
        My.Settings.AutoTuneCellStdDev = NUD_AFRStdDev.Value
        My.Settings.AutoTuneTimeWindow = NUD_AutoTuneTimeWindow.Value
        My.Settings.AutoTuneMapSmoothingStrength = NUD_AutoTuneMapSmoothingStrength.Value
        My.Settings.AutoTuneMaxPercentageFuelMapChange = NUD_AutoTuneMaxPercentageFuelMapChange.Value
        My.Settings.AutoTuneMinNumberLoggedValuesInCell = NUD_AutoTuneMinNumberLoggedValuesInCell.Value
        My.Settings.AutoTuneStrength = TB_AutoTuneStrength.Value

        My.Settings.AutoTuneExhaustGasOffset = NUD_ExhaustGasVelocityOffset.Value
        My.Settings.AutoTuneExhaustGasOffsetMaxTimeOffset = NUD_MaxTimeOffset.Value
        My.Settings.AutoTuneExhaustGasOffsetEngineCapacity = NUD_EngineCapacity.Value
        My.Settings.AutoTuneExhaustGasOffsetMaxEngineRPM = NUD_MaxEngineRPM.Value
        My.Settings.AutoTuneExhaustGasOffsetHeaderPipeDiameter = NUD_HeaderPipeDiameter.Value
        My.Settings.AutoTuneExhaustGasOffsetHeaderPipeLength = NUD_HeaderPipeLength.Value

        If R_ExhaustGasVelocityOffset1.Checked Then
            My.Settings.AutoTuneExhaustGasOffsetType = 1
        Else
            My.Settings.AutoTuneExhaustGasOffsetType = 2
        End If

        My.Settings.AutoTuneBoostPressureSensor = C_BoostPressureSensor.SelectedIndex

        My.Settings.Save()

        K8EngineDataViewer.ClearData()
        K8EngineDataViewer.OpenFiles()

        Me.Close()

    End Sub

    Private Sub B_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Cancel.Click

        Me.Close()

    End Sub

    Private Sub TB_AutoTuneStrength_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AutoTuneStrength.Scroll

        L_AutoTuneStrength.Text = TB_AutoTuneStrength.Value.ToString() & " %"

    End Sub

    Private Sub R_ExhaustGasVelocityOffset1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_ExhaustGasVelocityOffset1.CheckedChanged

        If R_ExhaustGasVelocityOffset1.Checked = True Then

            NUD_ExhaustGasVelocityOffset.Enabled = True

            L_EngineCapacity.Enabled = False
            NUD_EngineCapacity.Enabled = False
            L_MaxEngineRPM.Enabled = False
            NUD_MaxEngineRPM.Enabled = False
            L_HeaderPipeDiameter.Enabled = False
            NUD_HeaderPipeDiameter.Enabled = False
            L_HeaderPipeLength.Enabled = False
            NUD_HeaderPipeLength.Enabled = False

        Else

            NUD_ExhaustGasVelocityOffset.Enabled = False

            L_EngineCapacity.Enabled = True
            NUD_EngineCapacity.Enabled = True
            L_MaxEngineRPM.Enabled = True
            NUD_MaxEngineRPM.Enabled = True
            L_HeaderPipeDiameter.Enabled = True
            NUD_HeaderPipeDiameter.Enabled = True
            L_HeaderPipeLength.Enabled = True
            NUD_HeaderPipeLength.Enabled = True

        End If

    End Sub
End Class