Imports TwitterVB2

Public Class tw_auth

    Private Sub tw_auth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim twConn As New TwitterAPI
        Dim strPassword As String
        Dim strUserName As String

        If My.Settings.m_strToken.Trim.Length = 0 Then
            strUserName = t_username.Text
            strPassword = t_pwd.Text
            If strUserName <> "" And strPassword <> "" Then
                twConn.XAuth(strUserName, strPassword, My.Settings.m_strConsumerKey, My.Settings.m_strConsumerSecret)
                My.Settings.m_strToken = twConn.OAuth_Token
                My.Settings.m_strTokenSecret = twConn.OAuth_TokenSecret
                My.Settings.Save()
                If My.Settings.m_strToken = " " Or My.Settings.m_strTokenSecret = " " Then
                    MsgBox("Login failed, try again")
                End If
            Else
                twConn.AuthenticateWith(My.Settings.m_strConsumerKey, My.Settings.m_strConsumerSecret, My.Settings.m_strToken, My.Settings.m_strTokenSecret)
            End If
        End If


    End Sub
End Class