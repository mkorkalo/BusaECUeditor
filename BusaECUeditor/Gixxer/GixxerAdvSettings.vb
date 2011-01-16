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

        If ReadFlashByte(&H60BC1) = &H80 Then
            C_coil_fi_disable.Text = "Coil FI disabled"
            C_coil_fi_disable.Checked = True
        Else
            C_coil_fi_disable.Text = "Coil FI normal"
            C_coil_fi_disable.Checked = False
            WriteFlashByte(&H60BC1, &HFF)
        End If


        If ReadFlashByte(&H6296A) = &HC8 Then
            C_FAN.Checked = True
            C_FAN.Text = "Fan ON/OFF 100/95"
            WriteFlashByte(&H6296A, &HC8)
            WriteFlashByte(&H6296B, &HD0)
        Else
            C_FAN.Checked = False
            C_FAN.Text = "Fan ON/OFF 95/90"
            WriteFlashByte(&H6296A, &HC0)
            WriteFlashByte(&H6296B, &HC8)
        End If

        If ReadFlashByte(&H62ABA) = &HFF Then
            C_PAIR.Text = "PAIR ON"
            C_PAIR.Checked = True
            WriteFlashByte(&H62ABA, &HFF) ' pair config flag
            WriteFlashByte(&H56D5C, &HFE)
            WriteFlashByte(&H56D5D, &HFF)
            WriteFlashByte(&H56D5E, &HFC)
            WriteFlashByte(&H56D5F, &H10)
        Else
            C_PAIR.Text = "PAIR OFF"
            C_PAIR.Checked = False
            WriteFlashByte(&H62ABA, &H80) ' pair config flag
            WriteFlashByte(&H56D5C, &H70)
            WriteFlashByte(&H56D5D, &H0)
            WriteFlashByte(&H56D5E, &H70)
            WriteFlashByte(&H56D5F, &H0)
        End If

        If ReadFlashByte(&H614D4) = &H80 Then
            C_HOX.Text = "HOX sensor ON"
            C_HOX.Checked = True
        Else
            C_HOX.Text = "HOX sensor OFF"
            C_HOX.Checked = False
        End If

        If ReadFlashByte(&H60669) = &HFF Then
            C_EXC.Checked = True
            C_EXC.Text = "EXC ON"
        Else
            C_EXC.Checked = False
            C_EXC.Text = "EXC OFF"
        End If


        loading = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Gixxerinjectorbalancemap.Show()
        Gixxerinjectorbalancemap.Select()
    End Sub

    Private Sub C_coil_fi_disable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_coil_fi_disable.CheckedChanged
        If Not loading Then
            If C_coil_fi_disable.Checked = True Then
                C_coil_fi_disable.Text = "Coil FI disabled"
                WriteFlashByte(&H60BC1, &H80)
            Else
                C_coil_fi_disable.Text = "Coil FI normal"
                WriteFlashByte(&H60BC1, &HFF)
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_FAN.CheckedChanged

        If Not loading Then
            If C_FAN.Checked = True Then
                C_FAN.Text = "Fan ON/OFF 100/95"
                WriteFlashByte(&H6296A, &HC8)
                WriteFlashByte(&H6296B, &HD0)
            Else
                C_FAN.Text = "Fan ON/OFF 95/90"
                WriteFlashByte(&H6296A, &HC0)
                WriteFlashByte(&H6296B, &HC8)
            End If
        End If

    End Sub

    Private Sub C_PAIR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_PAIR.CheckedChanged
        If Not loading Then
            If C_PAIR.Checked = True Then
                C_PAIR.Text = "PAIR ON"
                WriteFlashByte(&H62ABA, &HFF) ' pair config flag
                WriteFlashByte(&H56D5C, &HFE)
                WriteFlashByte(&H56D5D, &HFF)
                WriteFlashByte(&H56D5E, &HFC)
                WriteFlashByte(&H56D5F, &H10)
            Else
                C_PAIR.Text = "PAIR OFF"
                WriteFlashByte(&H62ABA, &H80)
                WriteFlashByte(&H56D5C, &H70)
                WriteFlashByte(&H56D5D, &H0)
                WriteFlashByte(&H56D5E, &H70)
                WriteFlashByte(&H56D5F, &H0)

            End If
        End If

    End Sub

    Private Sub C_EXC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_EXC.CheckedChanged
        If Not loading Then

            If C_EXC.Checked = True Then
                C_EXC.Text = "EXCV ON"
                WriteFlashByte(&H60669, &HFF) '60669
                WriteFlashByte(&H6000D, &HFF) '6000D
                WriteFlashByte(&H6000F, &H0)  '6000F
            Else
                C_EXC.Text = "EXCV OFF"
                WriteFlashByte(&H60669, &H1) 'could be 0 or 1
                WriteFlashByte(&H6000D, &H0) 'if 0 shows error on busa
                WriteFlashByte(&H6000F, &H80)
            End If

        End If

    End Sub

    Private Sub C_HOX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_HOX.CheckedChanged
        If Not loading Then
            If C_HOX.Checked = True Then
                C_HOX.Text = "HOX sensor ON"
                WriteFlashByte(&H614D4, &H80)
                WriteFlashByte(&H62243, &HFF)
            Else
                C_HOX.Text = "HOX sensor OFF"
                WriteFlashByte(&H614D4, &H0)
                WriteFlashByte(&H62243, &H80)
            End If
        End If
    End Sub
End Class