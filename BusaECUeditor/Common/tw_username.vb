Public Class tw_username
    Private Sub B_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_save.Click
        My.Settings.username = t_username.Text
        My.Settings.Save()
        Me.Close()
    End Sub
End Class