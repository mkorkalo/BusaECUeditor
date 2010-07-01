Imports System.Windows.Forms



Public Class K8enginedatalog
    
    Public Sub called_externally()
        '
        ' This function gets called each timer click from enginedata.
        '

        Dim i As Integer

        Select Case K8Datastream.ho2toafr(HO2)
            Case "lean"
                i = 15
            Case "rich"
                i = 11
            Case Else
                i = Val(Replace(K8Datastream.ho2toafr(HO2), ".", ","))
        End Select
        If RPM > 1500 Then
            Me.P_RPM.AddValue(RPM)
            Me.P_TPS.AddValue(Val(CalcTPS(TPS)))
            Me.P_AFR.AddValue(i)

            Me.L_datalog.Items.Add(Format(RPM, "00000   ") & Format(CalcTPSDec(TPS), "00.0   ") & Format(IAP, "00.0   ") & K8Datastream.ho2toafr(HO2) & " " & Format(BOOST, "000"))
            Me.L_record.ForeColor = Color.Green

        Else
            Me.L_record.ForeColor = Color.Black
        End If

    End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()

    End Sub



    Private Sub K8enginedatalog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        '
        '

        Me.P_RPM.TimerMode = SpPerfChart.TimerMode.Disabled
        Me.P_TPS.TimerMode = SpPerfChart.TimerMode.Disabled
        Me.P_AFR.TimerMode = SpPerfChart.TimerMode.Disabled
    End Sub

    Private Sub traceitem()
        '
        ' This sub closes enginedata, then puts the active row on RPM, TPS and IAP and finally opens respective fuelmap
        ' and initiates tracing to show where on the map we are.
        '

        '
        ' Close enginedata so that it will not disturb, control is now with this screen
        '
        If K8Datastream.Visible() Then
            K8Datastream.closeenginedatacomms()
        End If

        '
        ' Put values from table to global variables
        '
        RPM = Val(Mid$(L_datalog.Text, 1, 5))
        TPS = CalcTPSToVal(Mid$(L_datalog.Text, 8, 4))
        IAP = Val(Mid$(L_datalog.Text, 16, 4))
        BOOST = Val(Mid$(L_datalog.Text, 28, 3))

        '
        ' If fuelmap is not visible we will show it
        '
        If Not K8Fuelmap.Visible() Then
            K8Fuelmap.Show()
            K8Fuelmap.Focus()
        End If

        If CalcTPSDec(TPS) > 10 Then
            '
            ' Select TPS map
            '
            K8Fuelmap.selectmap(1)
        Else
            '
            ' Select IAP map
            '
            K8Fuelmap.selectmap(2)
        End If

        '
        ' Now lets trace the map cell with this value
        '
        K8Fuelmap.tracemap()

        If K8boostfuel.Visible Then K8boostfuel.tracemap()

    End Sub

    Private Sub L_datalog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles L_datalog.Click
        traceitem()
    End Sub

    Private Sub L_datalog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_datalog.SelectedIndexChanged
        traceitem()
    End Sub

    Private Sub B_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Clear.Click
        Me.L_datalog.Items.Clear()
    End Sub
End Class
