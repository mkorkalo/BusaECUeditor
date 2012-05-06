Imports System.Text

Public Class LogValue

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
    Public GroupNumber As Integer
    Public ExhaustGasOffsetApplied As Boolean = False

    Public Property LogTimeSpan() As TimeSpan
        Get
            If String.IsNullOrEmpty(LogTime) = False Then

                Dim hours As Integer
                Dim minutes As Integer
                Dim seconds As Integer
                Dim milliseconds As Integer

                hours = Integer.Parse(LogTime.Substring(0, 2))
                minutes = Integer.Parse(LogTime.Substring(3, 2))
                seconds = Integer.Parse(LogTime.Substring(6, 2))
                milliseconds = Integer.Parse(LogTime.Substring(9, LogTime.Length - 9))

                Return New TimeSpan(0, hours, minutes, seconds, milliseconds)

            End If
        End Get
        Set(value As TimeSpan)

            Dim builder As New StringBuilder()
            builder.Append(value.Hours.ToString("00"))
            builder.Append(":")
            builder.Append(value.Minutes.ToString("00"))
            builder.Append(":")
            builder.Append(value.Seconds.ToString("00"))
            builder.Append(".")
            builder.Append(value.Milliseconds.ToString("000"))
            LogTime = builder.ToString()

        End Set
    End Property

    Public Overrides Function ToString() As String

        If MTS_AFR > 0 Then
            Return AFR.ToString("0.00") & "  -  " & MTS_AFR.ToString("0.00") & " - " & WIDEBAND.ToString("0") & " - " & LogTime
        Else
            If GroupNumber > 0 Then
                Return AFR.ToString("0.00") & " - " & WIDEBAND.ToString("0") & " - " & LogTime & " (" & GroupNumber & ")"
            Else
                Return AFR.ToString("0.00") & " - " & WIDEBAND.ToString("0") & " - " & LogTime
            End If

        End If

    End Function

End Class
