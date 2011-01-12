Public Class GixxerAdvSettings
    Dim loading As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GixxerSTPmap.Show()
        GixxerSTPmap.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub C_msmode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_msmode.SelectedIndexChanged
        Dim i As Integer
        If Not loading Then
            i = Me.C_msmode.SelectedIndex()
            Select Case i
                Case 0
                    WriteFlashByte(&H6063A, 0)
                Case 1
                    WriteFlashByte(&H6063A, 1)
                Case 2
                    WriteFlashByte(&H6063A, &HFF)
                Case Else
                    MsgBox("MS mode not detected, please reset the mode")
            End Select

        End If
    End Sub
    

    Private Sub GixxerAdvSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loading = True
        Dim i As Integer

        Me.C_msmode.Items.Add("mode 0")
        Me.C_msmode.Items.Add("mode 1")
        Me.C_msmode.Items.Add("switchable")

        i = ReadFlashByte(&H6063A)
        Select Case i
            Case 0
                Me.C_msmode.SelectedIndex = 0
            Case 1
                Me.C_msmode.SelectedIndex = 1
            Case &HFF
                Me.C_msmode.SelectedIndex = 2
            Case Else
                MsgBox("MS mode not detected, please reset the mode")
        End Select
        loading = False
    End Sub
End Class