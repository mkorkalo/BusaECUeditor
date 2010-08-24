Imports System.IO
Imports System.Drawing
Imports System.Text

Public Class K8EngineDataViewer

    Private _filePath As String
    Private _tpsList As List(Of Double) = New List(Of Double)
    Private _iapList As List(Of Double) = New List(Of Double)
    Private _rpmList As List(Of Integer) = New List(Of Integer)
    Private _boostList As List(Of Integer) = New List(Of Integer)
    Private _boostRPMList As List(Of Integer) = New List(Of Integer)

    Private _tpsValues(,) As List(Of LogValue)
    Private _iapValues(,) As List(Of LogValue)
    Private _boostValues(,) As List(Of LogValue)

    Private _tpsTargetAFR(,) As Double
    Private _iapTargetAFR(,) As Double
    Private _boostTargetAFR(,) As Double

    Private _tpsPercentageMapDelta(,) As Double
    Private _iapPercentageMapDelta(,) As Double
    Private _boostPercentageMapDelta(,) As Double

    Private _loading As Boolean = True
    Private _cltAbove80 As Boolean = False
    Private _mapType As Integer = 0
    Private _fileType As Integer = 0

    Private Sub K8EngineDataViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        C_WidebandO2Sensor.Checked = My.Settings.WidebandO2Sensor

        _tpsList.Add(0)
        _tpsList.Add(0.6)
        _tpsList.Add(1.2)
        _tpsList.Add(1.9)
        _tpsList.Add(2.5)
        _tpsList.Add(3.1)
        _tpsList.Add(3.7)
        _tpsList.Add(4.4)
        _tpsList.Add(6)
        _tpsList.Add(7)
        _tpsList.Add(8)
        _tpsList.Add(9)
        _tpsList.Add(11)
        _tpsList.Add(16)
        _tpsList.Add(21)
        _tpsList.Add(25)
        _tpsList.Add(30)
        _tpsList.Add(40)
        _tpsList.Add(50)
        _tpsList.Add(60)
        _tpsList.Add(70)
        _tpsList.Add(90)
        _tpsList.Add(100)

        _iapList.Add(68)
        _iapList.Add(59)
        _iapList.Add(50)
        _iapList.Add(41)
        _iapList.Add(39)
        _iapList.Add(36)
        _iapList.Add(34)
        _iapList.Add(32)
        _iapList.Add(30)
        _iapList.Add(27)
        _iapList.Add(25)
        _iapList.Add(23)
        _iapList.Add(20)
        _iapList.Add(18)
        _iapList.Add(14)
        _iapList.Add(11)
        _iapList.Add(9.1)
        _iapList.Add(6.8)
        _iapList.Add(4.6)
        _iapList.Add(2.3)
        _iapList.Add(0)


        For rpm As Integer = 800 To 5200 Step 200
            _rpmList.Add(rpm)
        Next

        For rpm As Integer = 5600 To 16000 Step 400
            _rpmList.Add(rpm)
        Next

        _boostList.Add(0)
        _boostList.Add(1)
        _boostList.Add(2)
        _boostList.Add(3)
        _boostList.Add(4)
        _boostList.Add(6)
        _boostList.Add(8)
        _boostList.Add(10)
        _boostList.Add(11)
        _boostList.Add(12)
        _boostList.Add(14)
        _boostList.Add(15)
        _boostList.Add(17)
        _boostList.Add(19)
        _boostList.Add(22)
        _boostList.Add(24)

        _boostRPMList.Add(4000)
        _boostRPMList.Add(5000)
        _boostRPMList.Add(5500)
        _boostRPMList.Add(6000)
        _boostRPMList.Add(6500)
        _boostRPMList.Add(7000)
        _boostRPMList.Add(7500)
        _boostRPMList.Add(8000)
        _boostRPMList.Add(8500)
        _boostRPMList.Add(9000)
        _boostRPMList.Add(9500)
        _boostRPMList.Add(10000)
        _boostRPMList.Add(10500)
        _boostRPMList.Add(11000)
        _boostRPMList.Add(11500)
        _boostRPMList.Add(12000)

        ReDim _tpsValues(_tpsList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _tpsList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _tpsValues(xindex, yindex) = New List(Of LogValue)

            Next
        Next

        ReDim _iapValues(_iapList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _iapList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _iapValues(xindex, yindex) = New List(Of LogValue)

            Next
        Next

        ReDim _boostValues(_boostList.Count, _boostRPMList.Count)

        For xindex As Integer = 0 To _boostList.Count - 1 Step 1
            For yindex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                _boostValues(xindex, yindex) = New List(Of LogValue)

            Next
        Next


        ReDim _tpsTargetAFR(_tpsList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _tpsList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _tpsTargetAFR(xindex, yindex) = 12.8

            Next
        Next

        ReDim _iapTargetAFR(_iapList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _iapList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _iapTargetAFR(xindex, yindex) = 14.7

            Next
        Next

        ReDim _boostTargetAFR(_boostList.Count, _boostRPMList.Count)

        For xindex As Integer = 0 To _boostList.Count - 1 Step 1
            For yindex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                _boostTargetAFR(xindex, yindex) = 12

            Next
        Next

    End Sub

    Private Sub B_LoadDataFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_LoadDataFile.Click

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "*Raw.csv|*Raw.csv"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            _fileType = 1
            _filePath = OpenFileDialog1.FileName
            OpenFile(_filePath)

        End If

    End Sub

    Public Sub ClearData()

        For x As Integer = 0 To _tpsValues.GetLength(0) - 1
            For y As Integer = 0 To _tpsValues.GetLength(1) - 1
                If _tpsValues(x, y) Is Nothing = False Then

                    _tpsValues(x, y).Clear()
                End If
            Next
        Next

        For x As Integer = 0 To _iapValues.GetLength(0) - 1
            For y As Integer = 0 To _iapValues.GetLength(1) - 1
                If _iapValues(x, y) Is Nothing = False Then
                    _iapValues(x, y).Clear()
                End If
            Next
        Next

        For x As Integer = 0 To _boostValues.GetLength(0) - 1
            For y As Integer = 0 To _boostValues.GetLength(1) - 1
                If _boostValues(x, y) Is Nothing = False Then
                    _boostValues(x, y).Clear()
                End If
            Next
        Next

    End Sub

    Public Sub OpenFile(ByVal filePath As String)

        _filePath = filePath
        OpenFile()

    End Sub

    Public Sub OpenFile()

        If String.IsNullOrEmpty(_filePath) = False Then

            L_FileName.Text = _filePath

            Dim reader As TextReader = New StreamReader(_filePath)

            Dim lineCount As Integer
            Dim nextLine As String = reader.ReadLine()

            While String.IsNullOrEmpty(nextLine) = False

                Dim values As String()
                values = nextLine.Split(",")
                nextLine = reader.ReadLine()
                lineCount = lineCount + 1

                If lineCount > 1 Then

                    Dim logValue As New LogValue

                    logValue.LogTime = values(0)
                    logValue.RPM = values(1)
                    logValue.TPS = K8EngineDataLogger.CalcTPS(values(2))
                    logValue.IAP = K8EngineDataLogger.CalcPressure(values(13)) - K8EngineDataLogger.CalcPressure(values(12))
                    logValue.H02 = values(4)
                    logValue.WIDEBAND = values(5)

                    If C_WidebandO2Sensor.Checked Then
                        logValue.AFR = K8EngineDataLogger.CalcWidebandAFR(values(5))
                    Else
                        logValue.AFR = K8EngineDataLogger.CalcAFR(values(4))
                    End If

                    logValue.IGN = K8EngineDataLogger.CalcIgnDeg(values(6))
                    logValue.STP = K8EngineDataLogger.CalcSTP(values(7))
                    logValue.GEAR = values(8)
                    logValue.CLUTCH = values(9)
                    logValue.NT = Boolean.Parse(values(10))
                    logValue.BOOST = K8EngineDataLogger.CalcBoost(values(11))
                    logValue.IP = K8EngineDataLogger.CalcPressure(values(12))
                    logValue.AP = K8EngineDataLogger.CalcPressure(values(13))
                    logValue.CLT = K8EngineDataLogger.CalcTemp(values(14))
                    logValue.IAT = K8EngineDataLogger.CalcTemp(values(15))
                    logValue.BATT = K8EngineDataLogger.CalcBatt(values(16))
                    logValue.PAIR = K8EngineDataLogger.CalcPair(values(17))
                    logValue.FUEL1 = values(18)
                    logValue.FUEL2 = values(19)
                    logValue.FUEL3 = values(20)
                    logValue.FUEL4 = values(21)

                    If values(23) > 10 And values(23) < 20 Then
                        logValue.MTS_AFR = values(23)
                    End If

                    If CheckEngineDataFilter(logValue) = True Then

                        Dim tpsIndex As Integer
                        Dim iapIndex As Integer
                        Dim rpmIndex As Integer
                        Dim boostIndex As Integer = -1
                        Dim boostRPMIndex As Integer = -1

                        If logValue.RPM > _rpmList(_rpmList.Count - 1) Then

                            rpmIndex = -1

                        Else

                            For index As Integer = 0 To _rpmList.Count - 1 Step 1

                                If logValue.RPM <= _rpmList(index) + (_rpmList(index + 1) - _rpmList(index)) / 2 Then
                                    rpmIndex = index
                                    Exit For
                                End If

                            Next

                        End If

                        If logValue.TPS >= 99 Then
                            tpsIndex = _tpsList.Count - 1
                        ElseIf logValue.TPS >= 80 Then
                            tpsIndex = _tpsList.Count - 2
                        Else
                            For index As Integer = 0 To _tpsList.Count - 1 Step 1

                                If logValue.TPS <= _tpsList(index) + (_tpsList(index + 1) - _tpsList(index)) / 2 Then
                                    tpsIndex = index
                                    Exit For
                                End If

                            Next
                        End If

                        If logValue.IAP > _iapList(0) Then

                            iapIndex = -1

                        ElseIf logValue.IAP > 62.5 Then

                            iapIndex = 0

                        Else
                            For index As Integer = _iapList.Count - 1 To 0 Step -1

                                If logValue.IAP <= _iapList(index) + (_iapList(index - 1) - _iapList(index)) / 2 Then
                                    iapIndex = index
                                    Exit For
                                End If

                            Next

                        End If

                        For index As Integer = 0 To _boostList.Count - 1

                            If logValue.BOOST <= _boostList(index) + 0.5 Then

                                boostIndex = index
                                Exit For

                            End If

                        Next

                        If boostIndex = -1 Then
                            boostIndex = _boostList.Count - 1
                        End If

                        For index As Integer = 1 To _boostRPMList.Count - 1

                            If logValue.RPM <= _boostRPMList(index) Then

                                boostRPMIndex = index
                                Exit For

                            End If

                        Next

                        If logValue.TPS < 11 And iapIndex > -1 And rpmIndex > -1 Then

                            _iapValues(iapIndex, rpmIndex).Add(logValue)

                        End If

                        If rpmIndex > -1 Then

                            _tpsValues(tpsIndex, rpmIndex).Add(logValue)

                        End If

                        If boostRPMIndex > -1 Then

                            _boostValues(boostIndex, boostRPMIndex).Add(logValue)

                        End If

                    End If

                End If

            End While

            reader.Close()

            B_TPS_RPM_Click(New Object(), New EventArgs())

        End If

    End Sub

    Public Function CheckEngineDataFilter(ByRef logValue As LogValue)

        If My.Settings.FilterCLT80 = True Then
            If logValue.CLT > 80 Then
                _cltAbove80 = True
            ElseIf _cltAbove80 = False Then
                Return False
            End If
        End If

        If My.Settings.FilterClutchIn = True Then
            If logValue.CLUTCH = "In" Then
                Return False
            End If
        End If

        If My.Settings.FilterGearNeutral = True Then
            If logValue.NT = True Then
                Return False
            End If
        End If

        If logValue.AFR < My.Settings.FilterAFRLessThan Then
            Return False
        End If

        If logValue.AFR > My.Settings.FilterAFRGreaterThan Then
            Return False
        End If

        Return True

    End Function

    Public Function CheckAutoTuneFilter(ByVal avgAfr As Double, ByRef percentageChange As Double, ByVal dataPoints As Integer) As Boolean

        If avgAfr > My.Settings.AutoTuneMaxAvgAFR Then
            Return False
        ElseIf avgAfr < My.Settings.AutoTuneMinAvgAFR Then
            Return False
        ElseIf dataPoints < My.Settings.AutoTuneMinNumberLoggedValuesInCell Then
            Return False
        ElseIf percentageChange > My.Settings.AutoTuneMaxPercentageFuelMapChange Then
            percentageChange = My.Settings.AutoTuneMaxPercentageFuelMapChange
        ElseIf percentageChange < -My.Settings.AutoTuneMaxPercentageFuelMapChange Then
            percentageChange = -My.Settings.AutoTuneMaxPercentageFuelMapChange
        End If

        Return True

    End Function

    Public Function CalculateAvgAFR(ByVal values As List(Of LogValue), ByRef dataCount As Integer) As Double

        Dim totalAfr As Double = 0
        Dim totalCount As Double = 0
        Dim avgAfr As Double

        For Each value As LogValue In values

            Dim afr As Double = 0

            If value.AFR > 0 Then
                dataCount = dataCount + 1
                totalAfr = totalAfr + value.AFR
                totalCount = totalCount + 1
            End If

        Next

        If totalCount > 0 Then

            avgAfr = totalAfr / totalCount

        End If

        Return avgAfr

    End Function

    Public Function GetCellColor(ByVal percentage As Double) As Color

        Try

            If percentage > My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Return Color.FromArgb(255, 0, 0)

            ElseIf percentage > 0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Dim greenValue As Integer = (My.Settings.AutoTuneMaxPercentageFuelMapChange - percentage) / My.Settings.AutoTuneMaxPercentageFuelMapChange * 255
                Return Color.FromArgb(255, greenValue, 0)

            ElseIf percentage <= 0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange And percentage >= -0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Return Color.White

            ElseIf percentage < -0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange And percentage > -My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Dim greenValue As Integer = (My.Settings.AutoTuneMaxPercentageFuelMapChange + percentage) / My.Settings.AutoTuneMaxPercentageFuelMapChange * 255
                Return Color.FromArgb(0, greenValue, 255)

            Else

                Return Color.FromArgb(0, 0, 255)

            End If

        Catch ex As Exception
            Dim mess As String = ex.Message

        End Try

    End Function

    Public Function GetCellForeColor(ByVal percentage As Double) As Color

        If percentage < -0.35 * My.Settings.AutoTuneMaxPercentageFuelMapChange Then

            Return Color.FromArgb(192, 192, 192)

        Else

            Return Color.Black

        End If

    End Function

    Public Sub OpenInnovateFile(ByVal filePath As String)

        If String.IsNullOrEmpty(filePath) = False Then

            L_FileName.Text = _filePath

            Dim reader As TextReader = New StreamReader(filePath)

            Dim lineCount As Integer
            Dim nextLine As String = reader.ReadLine()
            nextLine = reader.ReadLine()
            nextLine = reader.ReadLine()
            nextLine = reader.ReadLine()

            While String.IsNullOrEmpty(nextLine) = False

                Dim values As String()
                values = nextLine.Split(",")
                nextLine = reader.ReadLine()
                lineCount = lineCount + 1

                If lineCount > 1 Then

                    Dim logValue As New LogValue()
                    logValue.LogTime = values(0)
                    logValue.RPM = values(6)
                    logValue.TPS = values(7)
                    logValue.IAP = values(9) * -6.8947572931683609
                    logValue.AFR = values(1)
                    logValue.BOOST = values(9)

                    Dim tpsIndex As Integer
                    Dim iapIndex As Integer
                    Dim rpmIndex As Integer
                    Dim boostIndex As Integer = -1
                    Dim boostRPMIndex As Integer = -1

                    If logValue.RPM > _rpmList(_rpmList.Count - 1) Then

                        rpmIndex = -1

                    Else

                        For index As Integer = 0 To _rpmList.Count - 1 Step 1

                            If logValue.RPM <= _rpmList(index) + (_rpmList(index + 1) - _rpmList(index)) / 2 Then
                                rpmIndex = index
                                Exit For
                            End If

                        Next

                    End If

                    If logValue.TPS >= 99 Then
                        tpsIndex = _tpsList.Count - 1
                    ElseIf logValue.TPS >= 80 Then
                        tpsIndex = _tpsList.Count - 2
                    Else
                        For index As Integer = 0 To _tpsList.Count - 1 Step 1

                            If logValue.TPS <= _tpsList(index) + (_tpsList(index + 1) - _tpsList(index)) / 2 Then
                                tpsIndex = index
                                Exit For
                            End If

                        Next
                    End If

                    If logValue.IAP > _iapList(0) Then

                        iapIndex = -1

                    ElseIf logValue.IAP > 62.5 Then

                        iapIndex = 0

                    Else
                        For index As Integer = _iapList.Count - 1 To 0 Step -1

                            If logValue.IAP <= _iapList(index) + (_iapList(index - 1) - _iapList(index)) / 2 Then
                                iapIndex = index
                                Exit For
                            End If

                        Next

                    End If

                    For index As Integer = 0 To _boostList.Count - 1

                        If logValue.BOOST <= _boostList(index) + 0.5 Then

                            boostIndex = index
                            Exit For

                        End If

                    Next

                    If boostIndex = -1 Then
                        boostIndex = _boostList.Count - 1
                    End If

                    For index As Integer = 1 To _boostRPMList.Count - 1

                        If logValue.RPM <= _boostRPMList(index) Then

                            boostRPMIndex = index
                            Exit For

                        End If

                    Next

                    If logValue.TPS < 11 And iapIndex > -1 And rpmIndex > -1 Then

                        _iapValues(iapIndex, rpmIndex).Add(logValue)

                    End If

                    If rpmIndex > -1 Then

                        _tpsValues(tpsIndex, rpmIndex).Add(logValue)

                    End If

                    If boostRPMIndex > -1 Then

                        _boostValues(boostIndex, boostRPMIndex).Add(logValue)

                    End If
                End If
            End While

            reader.Close()

            B_TPS_RPM_Click(New Object(), New EventArgs())

        End If

    End Sub

    Private Sub ShowTPSHeaders()

        G_FuelMap.RowCount = _rpmList.Count
        G_FuelMap.ColumnCount = _tpsList.Count

        For index As Integer = 0 To _tpsList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0.0"
            G_FuelMap.Columns.Item(index).HeaderText() = _tpsList(index)
            G_FuelMap.Columns(index).Width = 35

        Next

        G_FuelMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        For index As Integer = 0 To _rpmList.Count - 1 Step 1

            G_FuelMap.Rows.Item(index).HeaderCell.Value = _rpmList(index).ToString()
            G_FuelMap.Rows.Item(index).Height = 15

        Next

    End Sub

    Private Sub ShowIAPHeaders()

        G_FuelMap.RowCount = _rpmList.Count
        G_FuelMap.ColumnCount = _iapList.Count

        For index As Integer = 0 To _iapList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0.0"
            G_FuelMap.Columns.Item(index).HeaderText() = _iapList(index)
            G_FuelMap.Columns(index).Width = 35

        Next

        G_FuelMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        For index As Integer = 0 To _rpmList.Count - 1 Step 1

            G_FuelMap.Rows.Item(index).HeaderCell.Value = _rpmList(index).ToString()
            G_FuelMap.Rows.Item(index).Height = 15

        Next

    End Sub

    Private Sub ShowBoostHeaders()

        G_FuelMap.RowCount = _boostRPMList.Count
        G_FuelMap.ColumnCount = _boostList.Count

        For index As Integer = 0 To _boostList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0.0"
            G_FuelMap.Columns.Item(index).HeaderText() = _boostList(index)
            G_FuelMap.Columns(index).Width = 35

        Next

        G_FuelMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        For index As Integer = 0 To _boostRPMList.Count - 1 Step 1

            G_FuelMap.Rows.Item(index).HeaderCell.Value = _boostRPMList(index).ToString()
            G_FuelMap.Rows.Item(index).Height = 15

        Next

    End Sub

    Private Sub ShowLoggedTPSValues()

        ShowTPSHeaders()

        Dim dataCount As Integer

        For tpsIndex As Integer = 0 To _tpsList.Count - 1 Step 1

            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(tpsIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    G_FuelMap.Item(tpsIndex, rpmIndex).Value = avgAfr

                End If

            Next

        Next

        L_DataCount.Text = "Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowLoggedIAPValues()

        ShowIAPHeaders()

        Dim dataCount As Integer

        For iapIndex As Integer = 0 To _iapList.Count - 1 Step 1

            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                Dim totalAfr As Double = 0
                Dim avgAfr As Double = 0
                Dim totalCount As Double = 0
                Dim values As List(Of LogValue) = _iapValues(iapIndex, rpmIndex)

                For Each value As LogValue In values

                    If value.AFR > 0 Then
                        dataCount = dataCount + 1
                        totalAfr = totalAfr + value.AFR
                        totalCount = totalCount + 1
                    End If

                Next

                If totalCount > 0 Then

                    avgAfr = totalAfr / totalCount

                    G_FuelMap.Item(iapIndex, rpmIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(iapIndex, rpmIndex).Value = avgAfr.ToString("0.00")

                End If

            Next

        Next

        L_DataCount.Text = "Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowLoggedBoostValues()

        ShowBoostHeaders()

        Dim dataCount As Integer

        For iapIndex As Integer = 0 To _boostList.Count - 1 Step 1

            For rpmIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                Dim totalAfr As Double = 0
                Dim avgAfr As Double = 0
                Dim totalCount As Double = 0
                Dim values As List(Of LogValue) = _boostValues(iapIndex, rpmIndex)

                For Each value As LogValue In values

                    If value.AFR > 0 And value.TPS > N_MinTPS.Value Then
                        dataCount = dataCount + 1
                        totalAfr = totalAfr + value.AFR
                        totalCount = totalCount + 1
                    End If

                Next

                If totalCount > 0 Then

                    avgAfr = totalAfr / totalCount

                    G_FuelMap.Item(iapIndex, rpmIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(iapIndex, rpmIndex).Value = avgAfr.ToString("0.00")

                End If

            Next

        Next

        L_DataCount.Text = "Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowTargetTPSValues()

        ShowTPSHeaders()

        For xindex As Integer = 0 To _tpsList.Count - 1
            For yindex As Integer = 0 To _rpmList.Count - 1

                G_FuelMap.Item(xindex, yindex).Value = _tpsTargetAFR(xindex, yindex)

            Next
        Next

    End Sub

    Private Sub ShowTargetIAPValues()

        ShowIAPHeaders()

        For xindex As Integer = 0 To _iapList.Count - 1
            For yindex As Integer = 0 To _rpmList.Count - 1

                G_FuelMap.Item(xindex, yindex).Value = _iapTargetAFR(xindex, yindex)

            Next
        Next

    End Sub

    Private Sub ShowTargetBoostValues()

        ShowBoostHeaders()

        For xindex As Integer = 0 To _boostList.Count - 1
            For yindex As Integer = 0 To _boostRPMList.Count - 1

                G_FuelMap.Item(xindex, yindex).Value = _boostTargetAFR(xindex, yindex)

            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeTPSValues()

        ShowTPSHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For tpsIndex As Integer = 0 To _tpsList.Count - 1 Step 1

            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(tpsIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(tpsIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(tpsIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then
                    percentageChange = (avgAfr - _tpsTargetAFR(tpsIndex, rpmIndex)) / avgAfr * 100

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(tpsIndex, rpmIndex).Value = percentageChange
                        G_FuelMap.Item(tpsIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(tpsIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeIAPValues()

        ShowIAPHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For iapIndex As Integer = 0 To _iapList.Count - 1 Step 1

            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(iapIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(iapIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(iapIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    percentageChange = (avgAfr - _iapTargetAFR(iapIndex, rpmIndex)) / avgAfr * 100

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(iapIndex, rpmIndex).Value = percentageChange
                        G_FuelMap.Item(iapIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(iapIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)
                    Else

                        G_FuelMap.Item(iapIndex, rpmIndex).Value = ""

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeBoostValues()

        ShowBoostHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For boostIndex As Integer = 0 To _boostList.Count - 1 Step 1
            For rpmIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(boostIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(boostIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_boostValues(boostIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    percentageChange = (avgAfr - _boostTargetAFR(boostIndex, rpmIndex)) / avgAfr * 100

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(boostIndex, rpmIndex).Value = percentageChange
                        G_FuelMap.Item(boostIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(boostIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub G_FuelMap_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellContentClick

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then

            Dim values As List(Of LogValue) = New List(Of LogValue)

            If _mapType = 1 Then
                values = _tpsValues(e.ColumnIndex, e.RowIndex)
            ElseIf _mapType = 2 Then
                values = _iapValues(e.ColumnIndex, e.RowIndex)
            ElseIf _mapType = 3 Then
                values = _boostValues(e.ColumnIndex, e.RowIndex)
            End If

            LB_Values.DataSource = values
            LB_Values.Focus()

        End If
    End Sub

    Private Sub ClearMap()

        If G_FuelMap.RowCount = 0 Or G_FuelMap.ColumnCount = 0 Then

            Return

        End If

        For x As Integer = 0 To G_FuelMap.ColumnCount - 1
            For y As Integer = 0 To G_FuelMap.RowCount - 1
                G_FuelMap.Item(x, y).Value = ""
                G_FuelMap.Item(x, y).Style.BackColor = Color.White
                G_FuelMap.Item(x, y).Style.ForeColor = Color.Black
            Next
        Next

    End Sub

    Private Sub B_TPS_RPM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_TPS_RPM.Click

        B_TPS_RPM.BackColor = Color.AntiqueWhite
        B_IAP_RPM.BackColor = Color.FromArgb(255, 240, 240, 240)
        B_BOOST_RPM.BackColor = Color.FromArgb(255, 240, 240, 240)

        L_MinTPS.Visible = False
        N_MinTPS.Visible = False

        _mapType = 1
        SelectMap()

    End Sub

    Private Sub B_IAP_RPM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_IAP_RPM.Click

        B_IAP_RPM.BackColor = Color.AntiqueWhite
        B_TPS_RPM.BackColor = Color.FromArgb(255, 240, 240, 240)
        B_BOOST_RPM.BackColor = Color.FromArgb(255, 240, 240, 240)

        L_MinTPS.Visible = False
        N_MinTPS.Visible = False

        _mapType = 2
        SelectMap()

    End Sub

    Private Sub B_BOOST_RPM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_BOOST_RPM.Click

        B_TPS_RPM.BackColor = Color.FromArgb(255, 240, 240, 240)
        B_IAP_RPM.BackColor = Color.FromArgb(255, 240, 240, 240)
        B_BOOST_RPM.BackColor = Color.AntiqueWhite

        L_MinTPS.Visible = True
        N_MinTPS.Visible = True
        N_MinTPS.Value = My.Settings.MinTPS

        _mapType = 3
        SelectMap()

    End Sub

    Private Sub G_FuelMap_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellClick

        G_FuelMap_CellContentClick(sender, e)

    End Sub

    Private Sub N_MinTPS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles N_MinTPS.ValueChanged

        If _loading = False Then

            My.Settings.MinTPS = N_MinTPS.Value
            My.Settings.Save()

            ShowLoggedBoostValues()

        End If

    End Sub

    Private Sub LB_Values_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Values.SelectedIndexChanged

        Dim logValue As LogValue = LB_Values.SelectedItem

        LV_ValueDetails.Items.Clear()

        If logValue Is Nothing = False Then

            Dim item As New ListViewItem("Log Time", 0)
            item.SubItems.Add(logValue.LogTime)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("RPM", 0)
            item.SubItems.Add(logValue.RPM)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("TPS", 0)
            item.SubItems.Add(logValue.TPS)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IAP", 0)
            item.SubItems.Add(logValue.IAP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("AFR", 0)
            item.SubItems.Add(logValue.AFR.ToString("0.00"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("H02", 0)
            item.SubItems.Add(logValue.H02)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("Wideband", 0)
            item.SubItems.Add(logValue.WIDEBAND)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("MTS AFR", 0)
            item.SubItems.Add(logValue.MTS_AFR)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IGN", 0)
            item.SubItems.Add(logValue.IGN)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("STP", 0)
            item.SubItems.Add(logValue.STP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("GEAR", 0)
            item.SubItems.Add(logValue.GEAR)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("Clutch", 0)
            item.SubItems.Add(logValue.CLUTCH)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("BOOST", 0)
            item.SubItems.Add(logValue.BOOST.ToString("0.0"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IP", 0)
            item.SubItems.Add(logValue.IP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("AP", 0)
            item.SubItems.Add(logValue.AP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("CLT", 0)
            item.SubItems.Add(logValue.CLT)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IAT", 0)
            item.SubItems.Add(logValue.IAT)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("BATT", 0)
            item.SubItems.Add(logValue.BATT)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL1", 0)
            item.SubItems.Add(logValue.FUEL1)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL2", 0)
            item.SubItems.Add(logValue.FUEL2)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL3", 0)
            item.SubItems.Add(logValue.FUEL3)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL4", 0)
            item.SubItems.Add(logValue.FUEL4)
            LV_ValueDetails.Items.Add(item)

        End If

    End Sub

    Private Sub C_WidebandO2Sensor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_WidebandO2Sensor.CheckedChanged

        My.Settings.WidebandO2Sensor = C_WidebandO2Sensor.Checked
        My.Settings.Save()

    End Sub

    Private Sub B_DataFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DataFilters.Click

        K8EngineDataFilter.Show()

    End Sub

    Private Sub rbtLoggedAFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtLoggedAFR.CheckedChanged

        SelectMap()

        B_LoadTargetAFR.Visible = False
        B_SaveTargetAFR.Visible = False

    End Sub

    Private Sub rbtTargetAFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTargetAFR.CheckedChanged

        SelectMap()

        B_LoadTargetAFR.Visible = True
        B_SaveTargetAFR.Visible = True

    End Sub

    Private Sub rbtPercentageMapChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPercentageMapChange.CheckedChanged

        SelectMap()

        B_LoadTargetAFR.Visible = False
        B_SaveTargetAFR.Visible = False

    End Sub

    Private Sub SelectMap()

        ClearMap()

        If rbtLoggedAFR.Checked = True Then

            If _mapType = 1 Then
                ShowLoggedTPSValues()
            ElseIf _mapType = 2 Then
                ShowLoggedIAPValues()
            ElseIf _mapType = 3 Then
                ShowLoggedBoostValues()
            End If

        ElseIf rbtTargetAFR.Checked = True Then

            If _mapType = 1 Then
                ShowTargetTPSValues()
            ElseIf _mapType = 2 Then
                ShowTargetIAPValues()
            ElseIf _mapType = 3 Then
                ShowTargetBoostValues()
            End If

        ElseIf rbtPercentageMapChange.Checked = True Then

            If _mapType = 1 Then
                ShowPercentageMapChangeTPSValues()
            ElseIf _mapType = 2 Then
                ShowPercentageMapChangeIAPValues()
            ElseIf _mapType = 3 Then
                ShowPercentageMapChangeBoostValues()
            End If

        End If

    End Sub

    Private Sub B_AutoTuneSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_AutoTuneSettings.Click

        K8AutoTuneSettings.Show()

    End Sub

    Private Sub B_SaveTargetAFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_SaveTargetAFR.Click

        SaveFileDialog1.Filter = ".tafr|*.tafr"

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Using textFile As System.IO.TextWriter = New StreamWriter(SaveFileDialog1.FileName)

                For x As Integer = 0 To _tpsTargetAFR.GetLength(0) - 1
                    Dim stringBuilder As New StringBuilder()
                    For y As Integer = 0 To _tpsTargetAFR.GetLength(1) - 1

                        stringBuilder.Append(_tpsTargetAFR(x, y).ToString("0.0"))
                        stringBuilder.Append(",")

                    Next

                    textFile.WriteLine(stringBuilder.ToString())
                Next

                For x As Integer = 0 To _iapTargetAFR.GetLength(0) - 1
                    Dim stringBuilder As New StringBuilder()
                    For y As Integer = 0 To _iapTargetAFR.GetLength(1) - 1

                        stringBuilder.Append(_iapTargetAFR(x, y).ToString("0.0"))
                        stringBuilder.Append(",")

                    Next

                    textFile.WriteLine(stringBuilder.ToString())
                Next

                For x As Integer = 0 To _boostTargetAFR.GetLength(0) - 1
                    Dim stringBuilder As New StringBuilder()
                    For y As Integer = 0 To _boostTargetAFR.GetLength(1) - 1

                        stringBuilder.Append(_boostTargetAFR(x, y).ToString("0.0"))
                        stringBuilder.Append(",")

                    Next

                    textFile.WriteLine(stringBuilder.ToString())
                Next

                textFile.Close()

            End Using

        End If

    End Sub
End Class