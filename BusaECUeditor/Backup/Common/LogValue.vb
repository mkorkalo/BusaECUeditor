﻿Public Class LogValue

    Public LogTime As String
    Public RPM As Integer
    Public TPS As Double
    Public IAP As Double
    Public H02 As Integer
    Public WIDEBAND As Integer
    Public AFR As Double
    Public IGN As Double
    Public STP As Double
    Public GEAR As Integer
    Public CLUTCH As String
    Public NT As Boolean
    Public BOOST As Double
    Public IP As Double
    Public AP As Double
    Public CLT As Double
    Public IAT As Double
    Public BATT As Double
    Public PAIR As String
    Public FUEL1 As Double
    Public FUEL2 As Double
    Public FUEL3 As Double
    Public FUEL4 As Double
    Public MTS_AFR As Double

    Public Overrides Function ToString() As String

        If MTS_AFR > 0 Then
            Return AFR.ToString("0.00") & "  -  " & MTS_AFR.ToString("0.00") & " - " & WIDEBAND.ToString("0")
        Else
            Return AFR.ToString("0.00") & " - " & WIDEBAND.ToString("0")
        End If

    End Function

End Class
