Imports System.IO

Public Class LogBoxCfg

    Private Sub LogBoxCfg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        OpenFileDialog1.FileName = "LOGBOX.CFG"
        OpenFileDialog1.Filter = "LOGBOX.CFG|LOGBOX.CFG"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK And String.IsNullOrEmpty(OpenFileDialog1.FileName) = False Then

            Dim fileStream As FileStream = File.OpenRead(OpenFileDialog1.FileName)

            If (fileStream.Length >= 3) Then

                Dim buffer(fileStream.Length) As Byte
                fileStream.Read(buffer, 0, fileStream.Length)

                nudLogStartDelay.Value = buffer(0)

                If buffer(1) = 0 Then
                    chkEngineRunning.Checked = False
                Else
                    chkEngineRunning.Checked = True
                End If

                Dim coolant As Decimal = (buffer(2) - 32) * 5 / 9

                If coolant > 0 Then
                    nudCoolantTemp.Value = coolant
                End If

                Label1.Enabled = True
                Label2.Enabled = True
                Label3.Enabled = True

                nudCoolantTemp.Enabled = True
                nudLogStartDelay.Enabled = True
                chkEngineRunning.Enabled = True

                btnOK.Enabled = True

            End If

            fileStream.Close()

        End If

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        If String.IsNullOrEmpty(OpenFileDialog1.FileName) = False Then

            Dim buffer(3) As Byte

            buffer(0) = Decimal.ToByte(nudLogStartDelay.Value)

            If chkEngineRunning.Checked = True Then
                buffer(1) = 1
            Else
                buffer(1) = 0
            End If

            Dim coolantValue As Decimal = (nudCoolantTemp.Value * 9 / 5) + 32
            buffer(2) = Decimal.ToByte(coolantValue)

            Dim fileStream As FileStream = File.OpenWrite(OpenFileDialog1.FileName)

            fileStream.Write(buffer, 0, 3)

            fileStream.Close()

        End If

        Close()

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub
End Class