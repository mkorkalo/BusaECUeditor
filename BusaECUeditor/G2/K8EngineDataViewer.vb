Imports System.IO
Imports System.Drawing
Imports System.Text
Imports System.Math

Public Class K8EngineDataViewer

    Private _filePath As String
    Private _filePaths As List(Of String) = New List(Of String)
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
    Private _mapLoading As Boolean = False
    Private _cltAbove80 As Boolean = False
    Private _mapType As Integer = 1
    Private _fileType As Integer = 0
    Private _cellMean As Double = 0
    Private _cellStdDev As Double = 0
    Private _logValueSelectedIndex = -1

    Private _autoTunedTPS = False
    Private _autoTunedIAP = False
    Private _autoTunedBoost = False

    Private _autoTunedTPSFuelMap(,) As Integer
    Private _currentTPSFuelMap(,) As Integer

    Private _autoTunedIAPFuelMap(,) As Integer
    Private _currentIAPFuelMap(,) As Integer

    Private Sub K8EngineDataViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        C_WidebandO2Sensor.Checked = My.Settings.WidebandO2Sensor

        If ECUVersion = "bking" Then

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

        Else

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
            _tpsList.Add(55)
            _tpsList.Add(60)
            _tpsList.Add(65)
            _tpsList.Add(70)
            _tpsList.Add(80)
            _tpsList.Add(90)
            _tpsList.Add(100)

        End If

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

        If My.Settings.AutoTuneBoostPressureSensor = 0 Then
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
        ElseIf My.Settings.AutoTuneBoostPressureSensor = 1 Then
            _boostList.Add(2)
            _boostList.Add(4)
            _boostList.Add(5)
            _boostList.Add(6)
            _boostList.Add(8)
            _boostList.Add(9)
            _boostList.Add(12)
            _boostList.Add(15)
            _boostList.Add(16)
            _boostList.Add(17)
            _boostList.Add(19)
            _boostList.Add(20)
            _boostList.Add(23)
            _boostList.Add(25)
            _boostList.Add(28)
            _boostList.Add(31)
        End If

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
        _boostRPMList.Add(12500)

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

        If String.IsNullOrEmpty(My.Settings.AutoTuneTargetAFRFilePath) = False And File.Exists(My.Settings.AutoTuneTargetAFRFilePath) = True Then
            LoadTAFRFile(My.Settings.AutoTuneTargetAFRFilePath)
        Else
            Dim path As String = Application.StartupPath() & "\Common\BaseTargetAFR.tafr"
            LoadTAFRFile(path)
        End If

    End Sub

    Private ReadOnly Property SelectedMapString() As String
        Get

            If R_TPSRPM.Checked Then
                Return "TPS/RPM"
            ElseIf R_IAPRPM.Checked Then
                Return "IAP/RPM"
            ElseIf R_BOOSTRPM.Checked Then
                Return "Boost/RPM"
            End If

            Return ""

        End Get
    End Property

    Private Sub B_LoadDataFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_LoadDataFile.Click

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "*Raw.csv|*Raw.csv"

        OpenFileDialog1.Multiselect = True

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            _fileType = 1

            For Each fileName As String In OpenFileDialog1.FileNames
                _filePath = fileName

                If _filePaths.Contains(fileName) = False Then
                    _filePaths.Add(fileName)
                End If

                OpenFile(_filePath)
            Next
        End If

    End Sub

    Public Sub ClearData()

        _cltAbove80 = False

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

    Public Sub OpenFiles()

        For Each filePath As String In _filePaths
            _filePath = filePath
            OpenFile()
        Next

    End Sub

    Public Sub OpenFile()

        Try
            If String.IsNullOrEmpty(_filePath) = False Then

                L_FileName.Text = _filePath

                Dim reader As TextReader = New StreamReader(_filePath)
                Dim logValues As List(Of LogValue) = New List(Of LogValue)
                Dim previousLogValue As New LogValue

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
                        logValue.TPS = K8EngineDataLogger.CalcTPSDouble(values(2))
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
                        logValue.BATT = K8EngineDataLogger.CalcBattDouble(values(16))
                        logValue.PAIR = K8EngineDataLogger.CalcPair(values(17))
                        logValue.FUEL1 = values(18)
                        logValue.FUEL2 = values(19)
                        logValue.FUEL3 = values(20)
                        logValue.FUEL4 = values(21)

                        logValues.Add(logValue)

                    End If

                End While

                reader.Close()

                ApplyExhaustGasOffset(logValues)

                For Each logValue As LogValue In logValues

                    If CheckEngineDataFilter(logValue, previousLogValue) = True Then

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

                            If My.Settings.AutoTuneBoostTPSFilterEnabled = True Then
                                If logValue.BOOST < My.Settings.AutoTuneBoostTPSFilterValue Then
                                    _tpsValues(tpsIndex, rpmIndex).Add(logValue)
                                End If
                            Else
                                _tpsValues(tpsIndex, rpmIndex).Add(logValue)
                            End If

                        End If

                        If boostRPMIndex > -1 Then

                            _boostValues(boostIndex, boostRPMIndex).Add(logValue)

                        End If

                    End If

                    previousLogValue = logValue

                Next

                ShowMap()

            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

    Public Sub ApplyExhaustGasOffset(ByRef logValues As List(Of LogValue))

        If My.Settings.AutoTuneExhaustGasOffsetType = 1 Then

            For index As Integer = 1 To logValues.Count - 1

                Dim logValue As LogValue = logValues(index)
                Dim previousLogValue As LogValue = logValues(index - 1)

                If logValue.RPM - previousLogValue.RPM > My.Settings.AutoTuneExhaustGasOffset / 4 Then
                    If logValue.TPS <= 25 Then
                        logValue.RPM = logValue.RPM - My.Settings.AutoTuneExhaustGasOffset
                    Else
                        logValue.RPM = logValue.RPM - (100 - logValue.TPS) / 100 * My.Settings.AutoTuneExhaustGasOffset
                    End If
                End If

            Next

        Else

            ' (1340 cc / 2 rotations) * (10000 / 60 rotations/sec) = 111666 cc/sec
            Dim maxflux As Double = My.Settings.AutoTuneExhaustGasOffsetEngineCapacity / 2 * My.Settings.AutoTuneExhaustGasOffsetMaxEngineRPM / 60

            ' cc = cm3 =  (pipe cross section 10 cm2) * 4 * (pipe length 100 cm) = 4000
            Dim gasvolume As Double = Math.PI * ((My.Settings.AutoTuneExhaustGasOffsetHeaderPipeDiameter - 2) / 2 / 10) ^ 2 * 4 * My.Settings.AutoTuneExhaustGasOffsetHeaderPipeLength / 10

            Dim minflux As Double = gasvolume * 1000.0 / My.Settings.AutoTuneExhaustGasOffsetMaxTimeOffset

            For index As Integer = 0 To logValues.Count - 1

                Dim previousLogValues As SortedList(Of Integer, LogValue) = New SortedList(Of Integer, LogValue)
                Dim logValue As LogValue = logValues(index)

                ' cc/sec, Exhaust gas flux assumed to increase linearly with RPM and TPS
                Dim partflux As Double = maxflux * (logValue.RPM / My.Settings.AutoTuneExhaustGasOffsetMaxEngineRPM) * (logValue.TPS / 100.0)
                Dim flux As Double = partflux + minflux
                Dim timedelayms As Double = gasvolume * 1000.0 / flux

                For offset As Integer = 1 To 10

                    If index - offset > 1 Then

                        Dim previousLogValue As LogValue = logValues(index - offset)
                        Dim timeDifference As TimeSpan = logValue.LogTimeSpan.Subtract(previousLogValue.LogTimeSpan)
                        Dim difference As Integer = timeDifference.TotalMilliseconds - timedelayms

                        If previousLogValues.Keys.Contains(Math.Abs(difference)) = False Then
                            previousLogValues.Add(Math.Abs(difference), previousLogValue)
                        Else
                            previousLogValues.Add(Math.Abs(difference) - 1, previousLogValue)
                        End If

                        'Exit when the difference gets positive
                        If difference > 0 Then
                            Exit For
                        End If

                    End If
                Next

                If previousLogValues.Count > 0 Then
                    If previousLogValues.Keys(0) < My.Settings.AutoTuneExhaustGasOffsetMaxTimeOffset Then
                        previousLogValues.Values(0).AFR = logValue.AFR
                        previousLogValues.Values(0).ExhaustGasOffsetApplied = True
                    End If
                End If

            Next

            'Adjust values that were not adjusted by the Exhaust Gas Offset Process
            For index As Integer = 1 To logValues.Count - 2
                If logValues(index).ExhaustGasOffsetApplied = False Then
                    If logValues(index - 1).ExhaustGasOffsetApplied = True And logValues(index + 1).ExhaustGasOffsetApplied = True Then
                        If logValues(index + 1).LogTimeSpan.Subtract(logValues(index - 1).LogTimeSpan).TotalMilliseconds < My.Settings.AutoTuneExhaustGasOffsetMaxTimeOffset Then
                            logValues(index).AFR = (logValues(index - 1).AFR + logValues(index + 1).AFR) / 2
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Public Function CheckEngineDataFilter(ByRef logValue As LogValue, ByRef previousLogValue As LogValue)

        If My.Settings.FilterCLT80 = True Then
            If logValue.CLT >= 80 Then
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

        If My.Settings.FilterIAPDecl = True And logValue.TPS < 11 And logValue.RPM < previousLogValue.RPM Then
            Return False
        End If

        If My.Settings.AutoTuneFilterTransitions = True Then

            If logValue.TPS < 11 And Abs(logValue.IAP - previousLogValue.IAP) > My.Settings.AutoTuneFilterTransitionsIAP Then
                Return False
            ElseIf logValue.TPS >= 11 And Abs(logValue.TPS - previousLogValue.TPS) > My.Settings.AutoTuneFilterTransitionsTPS Then
                Return False
            End If

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
        Dim mean As Double
        Dim stdDev As Double
        Dim groupNumber As Integer = 1

        CalculateStdDevaition(values, mean, stdDev)
        _cellMean = mean
        _cellStdDev = stdDev

        Dim timeWindowValues As List(Of LogValue) = New List(Of LogValue)
        Dim timeWindowAvg As Double = 0

        For index As Integer = 0 To values.Count - 1
            Dim value As LogValue = values(index)

            If value.AFR >= mean - stdDev * My.Settings.AutoTuneCellStdDev And value.AFR <= mean + stdDev * My.Settings.AutoTuneCellStdDev Then

                dataCount = dataCount + 1

                If timeWindowValues.Count = 0 Then
                    value.GroupNumber = groupNumber
                    timeWindowValues.Add(value)
                End If

                Dim timeDifference As Integer = value.LogTimeSpan.Subtract(timeWindowValues(0).LogTimeSpan).TotalMilliseconds

                If timeDifference < My.Settings.AutoTuneTimeWindow And timeDifference >= 0 Then
                    If timeWindowValues.Contains(value) = False Then
                        value.GroupNumber = groupNumber
                        timeWindowValues.Add(value)
                    End If
                Else

                    timeWindowAvg = 0
                    groupNumber = groupNumber + 1

                    For Each timeWindowValue As LogValue In timeWindowValues
                        timeWindowAvg = timeWindowAvg + timeWindowValue.AFR
                    Next

                    timeWindowAvg = timeWindowAvg / timeWindowValues.Count

                    timeWindowValues.Clear()
                    value.GroupNumber = groupNumber
                    timeWindowValues.Add(value)

                    totalAfr = totalAfr + timeWindowAvg
                    totalCount = totalCount + 1
                End If
            Else
                value.GroupNumber = 0
            End If
        Next

        If timeWindowValues.Count > 0 Then

            timeWindowAvg = 0

            For Each timeWindowValue As LogValue In timeWindowValues
                timeWindowAvg = timeWindowAvg + timeWindowValue.AFR
            Next

            timeWindowAvg = timeWindowAvg / timeWindowValues.Count

            totalAfr = totalAfr + timeWindowAvg
            totalCount = totalCount + 1
        End If

        If totalCount > 0 Then

            avgAfr = totalAfr / totalCount

        End If

        Return avgAfr

    End Function

    Public Function CalculateAvgTPS(ByVal values As List(Of LogValue)) As Double

        Dim total As Double = 0
        Dim totalCount As Double = 0
        Dim avg As Double

        For Each value As LogValue In values

            total = total + value.TPS
            totalCount = totalCount + 1

        Next

        If totalCount > 0 Then

            avg = total / totalCount

        End If

        Return avg

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

            ShowMap()

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

        For xIndex As Integer = 0 To _tpsList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1
                G_FuelMap.Item(xIndex, yIndex).Style.Font = New Font(G_FuelMap.Font.FontFamily, G_FuelMap.Font.Size, FontStyle.Regular)
            Next
        Next

    End Sub

    Private Sub ShowTPSFuelHeaders()

        G_FuelMap.RowCount = _rpmList.Count
        G_FuelMap.ColumnCount = _tpsList.Count

        For index As Integer = 0 To _tpsList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0"
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

        For xIndex As Integer = 0 To _iapList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1
                G_FuelMap.Item(xIndex, yIndex).Style.Font = New Font(G_FuelMap.Font.FontFamily, G_FuelMap.Font.Size, FontStyle.Regular)
            Next
        Next

    End Sub

    Private Sub ShowIAPFuelHeaders()

        G_FuelMap.RowCount = _rpmList.Count
        G_FuelMap.ColumnCount = _iapList.Count

        For index As Integer = 0 To _iapList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0"
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
        Dim totalDataCount As Integer

        For xIndex As Integer = 0 To _tpsList.Count - 1 Step 1
            For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr = CalculateAvgAFR(_tpsValues(xIndex, yIndex), dataCount)
                totalDataCount = totalDataCount + _tpsValues(xIndex, yIndex).Count

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    G_FuelMap.Item(xIndex, yIndex).Value = avgAfr
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString() & " (" & totalDataCount & ")"

    End Sub

    Private Sub ShowDataCountTPSValues()

        ShowTPSHeaders()

        Dim dataCount As Integer
        Dim totalDataCount As Integer

        For xIndex As Integer = 0 To _tpsList.Count - 1 Step 1
            For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                totalDataCount = totalDataCount + _tpsValues(xIndex, yIndex).Count

                Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(xIndex, yIndex), dataCount)
                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    G_FuelMap.Item(xIndex, yIndex).Value = _tpsValues(xIndex, yIndex).Count.ToString("0")
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString() & " (" & totalDataCount & ")"

    End Sub

    Private Sub ShowLoggedIAPValues()

        ShowIAPHeaders()

        Dim dataCount As Integer
        Dim totalDataCount As Integer

        For xIndex As Integer = 0 To _iapList.Count - 1 Step 1
            For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(xIndex, yIndex), dataCount)
                totalDataCount = totalDataCount + _iapValues(xIndex, yIndex).Count

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    G_FuelMap.Item(xIndex, yIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(xIndex, yIndex).Value = avgAfr.ToString("0.00")
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString() & " (" & totalDataCount & ")"

    End Sub

    Private Sub ShowDataCountIAPValues()

        ShowIAPHeaders()

        Dim dataCount As Integer

        For xIndex As Integer = 0 To _iapList.Count - 1 Step 1
            For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(xIndex, yIndex), dataCount)

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    G_FuelMap.Item(xIndex, yIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(xIndex, yIndex).Value = _iapValues(xIndex, yIndex).Count.ToString("0")
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowLoggedBoostValues()

        ShowBoostHeaders()

        Dim dataCount As Integer

        For xIndex As Integer = 0 To _boostList.Count - 1 Step 1
            For yIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_boostValues(xIndex, yIndex), dataCount)

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _boostTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    G_FuelMap.Item(xIndex, yIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(xIndex, yIndex).Value = avgAfr.ToString("0.00")
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowDataCountBoostValues()

        ShowBoostHeaders()

        Dim dataCount As Integer

        For xIndex As Integer = 0 To _boostList.Count - 1 Step 1
            For yIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_boostValues(xIndex, yIndex), dataCount)

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _boostTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    G_FuelMap.Item(xIndex, yIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(xIndex, yIndex).Value = _boostValues(xIndex, yIndex).Count.ToString("0")
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowTargetTPSValues()

        ShowTPSHeaders()

        For xIndex As Integer = 0 To _tpsList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                G_FuelMap.Item(xIndex, yIndex).Value = _tpsTargetAFR(xIndex, yIndex)

            Next
        Next

    End Sub

    Private Sub ShowTargetIAPValues()

        ShowIAPHeaders()

        For xIndex As Integer = 0 To _iapList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                G_FuelMap.Item(xIndex, yIndex).Value = _iapTargetAFR(xIndex, yIndex)

            Next
        Next

    End Sub

    Private Sub ShowTargetBoostValues()

        ShowBoostHeaders()

        For xIndex As Integer = 0 To _boostList.Count - 1
            For yIndex As Integer = 0 To _boostRPMList.Count - 1

                G_FuelMap.Item(xIndex, yIndex).Value = _boostTargetAFR(xIndex, yIndex)

            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeTPSValues()

        ShowTPSHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For xIndex As Integer = 0 To _tpsList.Count - 1 Step 1
            If _tpsList(xIndex) >= 11 Then

                For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                    dataCount = 0
                    G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                    G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                    Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(xIndex, yIndex), dataCount)

                    If avgAfr > 0 Then

                        percentageChange = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                        If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                            G_FuelMap.Item(xIndex, yIndex).Value = percentageChange
                            G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                            G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                        End If
                    End If
                Next

            End If
        Next

    End Sub

    Private Sub ShowPercentageMapChangeIAPValues()

        ShowIAPHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For xIndex As Integer = 0 To _iapList.Count - 1 Step 1
            For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(xIndex, yIndex), dataCount)

                If avgAfr > 0 Then

                    percentageChange = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(xIndex, yIndex).Value = percentageChange
                        G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)
                    Else

                        G_FuelMap.Item(xIndex, yIndex).Value = ""

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeBoostValues()

        ShowBoostHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For xIndex As Integer = 0 To _boostList.Count - 1 Step 1
            For yIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_boostValues(xIndex, yIndex), dataCount)

                If avgAfr > 0 Then

                    percentageChange = AutoTuneCorrection((avgAfr - _boostTargetAFR(xIndex, yIndex)) / avgAfr * 100)

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(xIndex, yIndex).Value = percentageChange
                        G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub ShowAutoTunedTPSMap()

        ShowTPSFuelHeaders()

        Dim mapStructureTable As Integer
        Dim cylinder As Integer = 0        ' 0,1,2,3
        Dim ms01 As Integer = 0            ' 0,1
        Dim modeabc As Integer = 0
        Dim copyToMap As Long = 0
        Dim editingMap As Integer = 0
        Dim mapNumberOfColumns As Integer = 0
        Dim mapNumberOfRows As Integer = 0
        Dim autoTunePercentage As Double = 0
        Dim newValue As Integer = 0
        Dim percentageChange As Double
        Dim dataCount As Integer

        If ECUVersion = "gen2" Then
            mapStructureTable = &H52304
        ElseIf ECUVersion = "bking" Then
            mapStructureTable = &H54EB4
        ElseIf ECUVersion = "gixxer" Then
            mapStructureTable = gixxer_fuelmap_map_first + (2 * 4 * 24)
        End If

        editingMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        mapNumberOfColumns = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        mapNumberOfRows = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        ReDim _autoTunedTPSFuelMap(_tpsList.Count, _rpmList.Count)
        ReDim _currentTPSFuelMap(_tpsList.Count, _rpmList.Count)

        Dim c_map(_rpmList.Count, _tpsList.Count) As Integer
        Dim r_map(_rpmList.Count, _tpsList.Count) As Integer
        Dim p_map(_rpmList.Count, _tpsList.Count) As Integer
        Dim n_map(_rpmList.Count, _tpsList.Count) As Integer
        Dim op_map(_rpmList.Count, _tpsList.Count) As Decimal

        For xIndex As Integer = 0 To _tpsList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                dataCount = 0
                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim currentValue As Integer = ReadFlashWord(editingMap + (2 * (xIndex + (yIndex * mapNumberOfColumns))))

                _currentTPSFuelMap(xIndex, yIndex) = currentValue
                c_map(yIndex, xIndex) = currentValue
                r_map(yIndex, xIndex) = currentValue
                n_map(yIndex, xIndex) = currentValue
                p_map(yIndex, xIndex) = 0
                op_map(yIndex, xIndex) = 0

                If _tpsList(xIndex) >= 11 Then

                    Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(xIndex, yIndex), dataCount)

                    If avgAfr > 0 Then

                        Dim afrDelta As Double = Math.Abs(avgAfr - _tpsTargetAFR(xIndex, yIndex))

                        If afrDelta < 0.1 Then
                            percentageChange = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100) / 2
                        ElseIf afrDelta < 0.5 Then
                            percentageChange = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100)
                        ElseIf afrDelta < 1.0 Then
                            percentageChange = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100) * 2
                        Else
                            percentageChange = AutoTuneCorrection((avgAfr - _tpsTargetAFR(xIndex, yIndex)) / avgAfr * 100) * 3
                        End If

                        If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                            newValue = currentValue * (1 + percentageChange / 100)

                            c_map(yIndex, xIndex) = newValue
                            p_map(yIndex, xIndex) = 1
                            op_map(yIndex, xIndex) = percentageChange

                        End If
                    End If
                    End If
            Next
        Next

        Dim totalCount As Integer

        totalCount = MapSmoother(My.Settings.AutoTuneMapSmoothingStrength, _tpsList.Count, _rpmList.Count, c_map, p_map, r_map, n_map)

        L_SmoothedCells.Text = "Cells Smoothed: " & totalCount.ToString()

        For xIndex As Integer = 0 To _tpsList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                _autoTunedTPSFuelMap(xIndex, yIndex) = n_map(yIndex, xIndex)

                percentageChange = (n_map(yIndex, xIndex) - r_map(yIndex, xIndex)) / r_map(yIndex, xIndex) * 100

                G_FuelMap.Item(xIndex, yIndex).Value = n_map(yIndex, xIndex) / 24
                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                If percentageChange <> 0 And op_map(yIndex, xIndex) = 0 Then
                    G_FuelMap.Item(xIndex, yIndex).Style.Font = New Font(G_FuelMap.Font.FontFamily, G_FuelMap.Font.Size, FontStyle.Italic Or FontStyle.Bold)
                Else
                    G_FuelMap.Item(xIndex, yIndex).Style.Font = New Font(G_FuelMap.Font.FontFamily, G_FuelMap.Font.Size, FontStyle.Regular)
                End If

            Next
        Next

        If C_ShowCurrentMap.Checked Then
            C_ShowCurrentMap.Checked = False
        End If

    End Sub

    Private Sub ShowAutoTunedIAPMap()

        ShowIAPFuelHeaders()

        Dim mapStructureTable As Integer
        Dim mapStructureTable2 As Integer
        Dim cylinder As Integer = 0        ' 0,1,2,3
        Dim ms01 As Integer = 0            ' 0,1
        Dim modeabc As Integer = 0
        Dim copyToMap As Long = 0
        Dim copyToMap2 As Long = 0
        Dim editingMap As Integer = 0
        Dim mapNumberOfColumns As Integer = 0
        Dim mapNumberOfRows As Integer = 0
        Dim autoTunePercentage As Double = 0
        Dim newValue As Integer = 0
        Dim dataCount As Integer
        Dim percentageChange As Double = 0

        If ECUVersion = "gen2" Then
            mapStructureTable = &H52244
            mapStructureTable2 = &H522A4
        ElseIf ECUVersion = "bking" Then
            mapStructureTable = &H54DF4
            mapStructureTable2 = &H54E54
        ElseIf ECUVersion = "gixxer" Then
            mapStructureTable = gixxer_fuelmap_map_first
            mapStructureTable2 = gixxer_fuelmap_map_first + (4 * 24)
        End If

        editingMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        mapNumberOfColumns = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        mapNumberOfRows = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        ReDim _autoTunedIAPFuelMap(_iapList.Count, _rpmList.Count)
        ReDim _currentIAPFuelMap(_iapList.Count, _rpmList.Count)

        Dim c_map(_rpmList.Count, _iapList.Count) As Integer
        Dim r_map(_rpmList.Count, _iapList.Count) As Integer
        Dim p_map(_rpmList.Count, _iapList.Count) As Integer
        Dim n_map(_rpmList.Count, _iapList.Count) As Integer
        Dim op_map(_rpmList.Count, _tpsList.Count) As Decimal

        For xIndex As Integer = 0 To _iapList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                dataCount = 0
                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = Color.White
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = Color.Black

                Dim currentValue As Integer = ReadFlashWord(editingMap + (2 * (xIndex + (yIndex * mapNumberOfColumns))))

                _currentIAPFuelMap(xIndex, yIndex) = currentValue
                c_map(yIndex, xIndex) = currentValue
                r_map(yIndex, xIndex) = currentValue
                p_map(yIndex, xIndex) = 0
                op_map(yIndex, xIndex) = 0

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(xIndex, yIndex), dataCount)

                If avgAfr > 0 Then

                    Dim afrDelta As Double = Math.Abs(avgAfr - _tpsTargetAFR(xIndex, yIndex))

                    If afrDelta < 0.1 Then
                        percentageChange = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100) / 2
                    ElseIf afrDelta < 0.5 Then
                        percentageChange = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100)
                    ElseIf afrDelta < 1 Then
                        percentageChange = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100) * 2
                    Else
                        percentageChange = AutoTuneCorrection((avgAfr - _iapTargetAFR(xIndex, yIndex)) / avgAfr * 100) * 3
                    End If

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        newValue = currentValue * (1 + percentageChange / 100)

                        c_map(yIndex, xIndex) = newValue
                        p_map(yIndex, xIndex) = 1
                        op_map(yIndex, xIndex) = percentageChange

                    End If
                End If
            Next
        Next

        Dim totalCount As Integer

        totalCount = MapSmoother(My.Settings.AutoTuneMapSmoothingStrength, _iapList.Count, _rpmList.Count, c_map, p_map, r_map, n_map)

        L_SmoothedCells.Text = "Cells Smoothed: " & totalCount.ToString()

        For xIndex As Integer = 0 To _iapList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                _autoTunedIAPFuelMap(xIndex, yIndex) = n_map(yIndex, xIndex)

                percentageChange = (n_map(yIndex, xIndex) - r_map(yIndex, xIndex)) / r_map(yIndex, xIndex) * 100

                G_FuelMap.Item(xIndex, yIndex).Value = n_map(yIndex, xIndex) / 24
                G_FuelMap.Item(xIndex, yIndex).Style.BackColor = GetCellColor(percentageChange)
                G_FuelMap.Item(xIndex, yIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                If percentageChange <> 0 And op_map(yIndex, xIndex) = 0 Then
                    G_FuelMap.Item(xIndex, yIndex).Style.Font = New Font(G_FuelMap.Font.FontFamily, G_FuelMap.Font.Size, FontStyle.Italic Or FontStyle.Bold)
                Else
                    G_FuelMap.Item(xIndex, yIndex).Style.Font = New Font(G_FuelMap.Font.FontFamily, G_FuelMap.Font.Size, FontStyle.Regular)
                End If

            Next
        Next

        If C_ShowCurrentMap.Checked Then
            C_ShowCurrentMap.Checked = False
        End If

    End Sub

    Private Sub G_FuelMap_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellContentClick

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then

            L_AvgTPS.Text = ""

            Dim dataCount As Integer
            Dim avgAFR As Double
            Dim targetAFR As Double
            Dim values As List(Of LogValue) = New List(Of LogValue)

            If _mapType = 1 Then
                values = _tpsValues(e.ColumnIndex, e.RowIndex)
                targetAFR = _tpsTargetAFR(e.ColumnIndex, e.RowIndex)
                L_CellInfo.Text = "TPS: " & _tpsList(e.ColumnIndex) & "% RPM: " & _rpmList(e.RowIndex)
            ElseIf _mapType = 2 Then
                values = _iapValues(e.ColumnIndex, e.RowIndex)
                targetAFR = _iapTargetAFR(e.ColumnIndex, e.RowIndex)
                L_CellInfo.Text = "IAP: " & _iapList(e.ColumnIndex) & " RPM: " & _rpmList(e.RowIndex)
                L_AvgTPS.Text = "Avg TPS: " & CalculateAvgTPS(values).ToString("0.0")
            ElseIf _mapType = 3 Then
                values = _boostValues(e.ColumnIndex, e.RowIndex)
                L_CellInfo.Text = "Boost: " & _boostList(e.ColumnIndex) & " RPM: " & _boostRPMList(e.RowIndex)
                targetAFR = _boostTargetAFR(e.ColumnIndex, e.RowIndex)
            End If

            avgAFR = CalculateAvgAFR(values, dataCount)

            L_CellStats.Text = "Mean: " & _cellMean.ToString("0.00") & "  Std Dev: " & _cellStdDev.ToString("0.00")
            L_CellInfo.Text = L_CellInfo.Text & " AFR: " & avgAFR.ToString("0.00") & " ( " & targetAFR.ToString("0.0") & " ) Count: " & values.Count.ToString()

            LB_Values.DataSource = values
            LB_Values.Refresh()

        End If
    End Sub

    Private Sub ClearMap()

        If G_FuelMap.RowCount = 0 Or G_FuelMap.ColumnCount = 0 Then

            Return

        End If

        L_AvgTPS.Text = ""
        L_SmoothedCells.Text = ""

        For x As Integer = 0 To G_FuelMap.ColumnCount - 1
            For y As Integer = 0 To G_FuelMap.RowCount - 1
                G_FuelMap.Item(x, y).Value = ""
                G_FuelMap.Item(x, y).Style.BackColor = Color.White
                G_FuelMap.Item(x, y).Style.ForeColor = Color.Black
            Next
        Next

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

        _logValueSelectedIndex = LB_Values.SelectedIndex
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

            item = New ListViewItem("FUEL1 8bit", 0)
            item.SubItems.Add((logValue.FUEL1 / 25.6).ToString("0"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL2 8bit", 0)
            item.SubItems.Add((logValue.FUEL2 / 25.6).ToString("0"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL3 8bit", 0)
            item.SubItems.Add((logValue.FUEL3 / 25.6).ToString("0"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL4 8bit", 0)
            item.SubItems.Add((logValue.FUEL4 / 25.6).ToString("0"))
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

    Private Sub LB_Values_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles LB_Values.DrawItem

        If e.Index > -1 Then

            e.DrawBackground()

            Dim backgroundBrush As Brush = Brushes.White
            Dim textBrush As Brush = Brushes.Black

            Dim value As LogValue = LB_Values.Items(e.Index)
            Dim selectedValue As LogValue = LB_Values.SelectedItem

            ' Determine the color of the brush to draw each item based on the index of the item to draw.
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                backgroundBrush = Brushes.Blue
                textBrush = Brushes.White
            ElseIf value.AFR > (_cellMean + _cellStdDev * My.Settings.AutoTuneCellStdDev) Then
                backgroundBrush = Brushes.Coral
            ElseIf value.AFR < (_cellMean - _cellStdDev * My.Settings.AutoTuneCellStdDev) Then
                backgroundBrush = Brushes.LightBlue
            End If

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds)
            e.Graphics.DrawString(LB_Values.Items(e.Index).ToString(), e.Font, textBrush, e.Bounds, StringFormat.GenericDefault)

            e.DrawFocusRectangle()

        End If

    End Sub

    Private Sub C_WidebandO2Sensor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_WidebandO2Sensor.CheckedChanged

        My.Settings.WidebandO2Sensor = C_WidebandO2Sensor.Checked
        My.Settings.Save()

    End Sub

    Private Sub B_DataFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DataFilters.Click

        K8EngineDataFilter.ShowDialog()
        ShowMap()

    End Sub

    Private Sub R_LoggedAFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_LoggedAFR.CheckedChanged

        If R_LoggedAFR.Checked Then

            ShowMap()

            SetAutoTuneButton()

            B_LoadTargetAFR.Visible = False
            B_SaveTargetAFR.Visible = False

        End If

    End Sub

    Private Sub R_TargetAFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_TargetAFR.CheckedChanged

        If R_TargetAFR.Checked Then

            ShowMap()

            SetAutoTuneButton()

            B_LoadTargetAFR.Visible = True
            B_SaveTargetAFR.Visible = True

        End If

    End Sub

    Private Sub R_DataCount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_DataCount.CheckedChanged

        If R_DataCount.Checked Then

            ShowMap()

            SetAutoTuneButton()

            B_LoadTargetAFR.Visible = True
            B_SaveTargetAFR.Visible = True

        End If

    End Sub

    Private Sub R_PercentageMapChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_PercentageMapChange.CheckedChanged

        If R_PercentageMapChange.Checked Then

            ShowMap()

            SetAutoTuneButton()

            B_LoadTargetAFR.Visible = False
            B_SaveTargetAFR.Visible = False

        End If

    End Sub

    Private Sub R_AutoTunedMap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_AutoTunedMap.CheckedChanged

        If R_AutoTunedMap.Checked Then

            C_ShowCurrentMap.Checked = False

            ShowMap()

            SetAutoTuneButton()

            B_LoadTargetAFR.Visible = False
            B_SaveTargetAFR.Visible = False

        End If
    End Sub

    Private Sub C_ShowCurrentMap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ShowCurrentMap.CheckedChanged

        If C_ShowCurrentMap.Checked Then

            If R_TPSRPM.Checked Then

                For xIndex As Integer = 0 To _tpsList.Count - 1
                    For yIndex As Integer = 0 To _rpmList.Count - 1
                        G_FuelMap.Item(xIndex, yIndex).Value = _currentTPSFuelMap(xIndex, yIndex) / 24
                    Next
                Next

            ElseIf R_IAPRPM.Checked Then

                For xIndex As Integer = 0 To _iapList.Count - 1
                    For yIndex As Integer = 0 To _rpmList.Count - 1
                        G_FuelMap.Item(xIndex, yIndex).Value = _currentIAPFuelMap(xIndex, yIndex) / 24
                    Next
                Next

            End If

        Else

            If R_TPSRPM.Checked Then

                For xIndex As Integer = 0 To _tpsList.Count - 1
                    For yIndex As Integer = 0 To _rpmList.Count - 1
                        G_FuelMap.Item(xIndex, yIndex).Value = _autoTunedTPSFuelMap(xIndex, yIndex) / 24
                    Next
                Next

            ElseIf R_IAPRPM.Checked Then

                For xIndex As Integer = 0 To _iapList.Count - 1
                    For yIndex As Integer = 0 To _rpmList.Count - 1
                        G_FuelMap.Item(xIndex, yIndex).Value = _autoTunedIAPFuelMap(xIndex, yIndex) / 24
                    Next
                Next

            End If
        End If
    End Sub

    Private Sub SetAutoTuneButton()

        If R_AutoTunedMap.Checked = True Then
            B_AutoTune.Visible = True
            C_ShowCurrentMap.Visible = True
        Else
            B_AutoTune.Visible = False
            C_ShowCurrentMap.Visible = False
        End If

        If R_TPSRPM.Checked Then
            If _autoTunedTPS = False Then
                B_AutoTune.Enabled = True
            Else
                B_AutoTune.Enabled = False
            End If
        End If

        If R_IAPRPM.Checked Then
            If _autoTunedIAP = False Then
                B_AutoTune.Enabled = True
            Else
                B_AutoTune.Enabled = False
            End If
        End If

        If R_BOOSTRPM.Checked Then
            If _autoTunedBoost = False Then
                B_AutoTune.Enabled = False
            Else
                B_AutoTune.Enabled = False
            End If
        End If

    End Sub

    Private Sub ShowMap()

        _mapLoading = True

        ClearMap()

        If R_LoggedAFR.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditProgrammatically

            If _mapType = 1 Then
                ShowLoggedTPSValues()
            ElseIf _mapType = 2 Then
                ShowLoggedIAPValues()
            ElseIf _mapType = 3 Then
                ShowLoggedBoostValues()
            End If

        ElseIf R_TargetAFR.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            If _mapType = 1 Then
                ShowTargetTPSValues()
            ElseIf _mapType = 2 Then
                ShowTargetIAPValues()
            ElseIf _mapType = 3 Then
                ShowTargetBoostValues()
            End If

        ElseIf R_DataCount.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditProgrammatically

            If _mapType = 1 Then
                ShowDataCountTPSValues()
            ElseIf _mapType = 2 Then
                ShowDataCountIAPValues()
            ElseIf _mapType = 3 Then
                ShowDataCountBoostValues()
            End If

        ElseIf R_PercentageMapChange.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            If _mapType = 1 Then
                ShowPercentageMapChangeTPSValues()
            ElseIf _mapType = 2 Then
                ShowPercentageMapChangeIAPValues()
            ElseIf _mapType = 3 Then
                ShowPercentageMapChangeBoostValues()
            End If

        ElseIf R_AutoTunedMap.Checked Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            If _mapType = 1 Then
                ShowAutoTunedTPSMap()
            ElseIf _mapType = 2 Then
                ShowAutoTunedIAPMap()
            ElseIf _mapType = 3 Then

            End If

        End If

        _mapLoading = False

    End Sub

    Private Sub B_AutoTuneSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_AutoTuneSettings.Click

        K8AutoTuneSettings.ShowDialog()
        ShowMap()

    End Sub

    Private Sub B_SaveTargetAFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_SaveTargetAFR.Click

        Try

            SaveFileDialog1.Filter = ".tafr|*.tafr"

            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Using textFile As System.IO.TextWriter = New StreamWriter(SaveFileDialog1.FileName)

                    For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                        Dim stringBuilder As New StringBuilder()

                        For xIndex As Integer = 0 To _tpsList.Count - 1 Step 1

                            stringBuilder.Append(_tpsTargetAFR(xIndex, yIndex).ToString("0.0"))

                            If xIndex < _tpsList.Count - 1 Then
                                stringBuilder.Append("|")
                            End If
                        Next

                        textFile.WriteLine(stringBuilder.ToString())
                    Next

                    For yIndex As Integer = 0 To _rpmList.Count - 1
                        Dim stringBuilder As New StringBuilder()
                        For xIndex As Integer = 0 To _iapList.Count - 1

                            stringBuilder.Append(_iapTargetAFR(xIndex, yIndex).ToString("0.0"))

                            If xIndex < _iapList.Count - 1 Then
                                stringBuilder.Append("|")
                            End If
                        Next

                        textFile.WriteLine(stringBuilder.ToString())
                    Next

                    For yIndex As Integer = 0 To _boostRPMList.Count - 1
                        Dim stringBuilder As New StringBuilder()
                        For xIndex As Integer = 0 To _boostList.Count - 1

                            stringBuilder.Append(_boostTargetAFR(xIndex, yIndex).ToString("0.0"))

                            If xIndex < _boostList.Count - 1 Then
                                stringBuilder.Append("|")
                            End If
                        Next

                        textFile.WriteLine(stringBuilder.ToString())

                    Next

                    textFile.Close()

                    My.Settings.AutoTuneTargetAFRFilePath = SaveFileDialog1.FileName
                    My.Settings.Save()

                End Using

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace, "ECU Editor Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub B_LoadTargetAFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_LoadTargetAFR.Click

        Try

            OpenFileDialog1.Filter = ".tafr|*.tafr"

            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

                LoadTAFRFile(OpenFileDialog1.FileName)

                My.Settings.AutoTuneTargetAFRFilePath = OpenFileDialog1.FileName
                My.Settings.Save()

            End If

            ShowMap()

        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace, "ECU Editor Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub LoadTAFRFile(ByVal filePath As String)

        Try
            If String.IsNullOrEmpty(filePath) = False Then
                If File.Exists(filePath) Then

                    Using textFile As System.IO.TextReader = New StreamReader(filePath)

                        Dim line As String = textFile.ReadLine()
                        Dim tpsRPMIndex As Integer = 0
                        Dim iapRPMIndex As Integer = 0
                        Dim boostRPMIndex As Integer = 0

                        While String.IsNullOrEmpty(line) = False

                            Dim values As String() = line.Split("|")

                            If values.Length = 23 Then

                                For index As Integer = 0 To values.Length - 1 Step 1
                                    Dim value As Double = 0

                                    If Double.TryParse(values(index), value) Then
                                        _tpsTargetAFR(index, tpsRPMIndex) = value
                                    End If
                                Next

                                tpsRPMIndex = tpsRPMIndex + 1

                            End If

                            If values.Length = 21 Then

                                For index As Integer = 0 To values.Length - 1 Step 1
                                    Dim value As Double = 0

                                    If Double.TryParse(values(index), value) Then
                                        _iapTargetAFR(index, iapRPMIndex) = value
                                    End If
                                Next

                                iapRPMIndex = iapRPMIndex + 1

                            End If

                            If values.Length = 16 Then

                                For index As Integer = 0 To values.Length - 1 Step 1
                                    Dim value As Double = 0

                                    If Double.TryParse(values(index), value) Then
                                        _boostTargetAFR(index, boostRPMIndex) = value
                                    End If
                                Next

                                boostRPMIndex = boostRPMIndex + 1

                            End If

                            line = textFile.ReadLine()

                        End While

                        textFile.Close()

                    End Using
                End If
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace, "Open .tarf file error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub G_FuelMap_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellValueChanged

        If e.ColumnIndex < 0 Or e.RowIndex < 0 Or _mapLoading = True Then
            Return
        End If

        If R_TargetAFR.Checked = True Then

            Dim value As Double = 0

            If Double.TryParse(G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), value) = True Then

                If _mapType = 1 Then
                    _tpsTargetAFR(e.ColumnIndex, e.RowIndex) = value
                ElseIf _mapType = 2 Then
                    _iapTargetAFR(e.ColumnIndex, e.RowIndex) = value
                ElseIf _mapType = 3 Then
                    _boostTargetAFR(e.ColumnIndex, e.RowIndex) = value
                End If
            Else

                If _mapType = 1 Then
                    G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value = _tpsTargetAFR(e.ColumnIndex, e.RowIndex)
                ElseIf _mapType = 2 Then
                    G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value = _iapTargetAFR(e.ColumnIndex, e.RowIndex)
                ElseIf _mapType = 3 Then
                    G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value = _iapTargetAFR(e.ColumnIndex, e.RowIndex)
                End If

            End If

        ElseIf R_PercentageMapChange.Checked = True Then

            Dim value As Double = 0

            If Double.TryParse(G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), value) = True Then

                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = GetCellColor(value)
                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.ForeColor = GetCellForeColor(value)

            Else

                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = GetCellColor(0)
                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.ForeColor = GetCellForeColor(0)

            End If

        ElseIf R_AutoTunedMap.Checked = True Then

            If C_ShowCurrentMap.Checked = False Then

                Dim value As Double = 0

                If Double.TryParse(G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), value) = True Then

                    If R_TPSRPM.Checked Then
                        _autoTunedTPSFuelMap(e.ColumnIndex, e.RowIndex) = value * 24
                    ElseIf R_IAPRPM.Checked Then
                        _autoTunedIAPFuelMap(e.ColumnIndex, e.RowIndex) = value * 24
                    End If

                End If
            End If

        End If

    End Sub

    Private Sub G_FuelMap_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles G_FuelMap.KeyDown

        If R_TargetAFR.Checked = True Or R_PercentageMapChange.Checked = True Then

            If (e.Control = True And e.KeyCode = Keys.V) Then
                Dim rowIndex As Integer
                Dim lines As String()
                Dim columnStartIndex As Integer

                rowIndex = Integer.MaxValue
                columnStartIndex = Integer.MaxValue

                For Each cell As DataGridViewCell In G_FuelMap.SelectedCells()
                    If cell.RowIndex < rowIndex Then
                        rowIndex = cell.RowIndex
                    End If

                    If cell.ColumnIndex < columnStartIndex Then
                        columnStartIndex = cell.ColumnIndex
                    End If
                Next

                rowIndex = G_FuelMap.CurrentCell.RowIndex

                lines = Clipboard.GetText().Split(ControlChars.CrLf)

                For Each line As String In lines
                    Dim columnIndex As Integer
                    Dim values As String()

                    values = line.Split(ControlChars.Tab)
                    columnIndex = columnStartIndex

                    For Each value As String In values
                        value = Replace(value, ControlChars.Lf, "") ' removing extra LF - issue 38
                        If columnIndex < G_FuelMap.ColumnCount And rowIndex < G_FuelMap.RowCount Then
                            If IsNumeric(value) Then
                                G_FuelMap(columnIndex, rowIndex).Value = value
                            End If
                        End If

                        columnIndex = columnIndex + 1
                    Next

                    rowIndex = rowIndex + 1
                Next

            End If
        End If
    End Sub

    Private Sub R_TPSRPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_TPSRPM.CheckedChanged

        If R_TPSRPM.Checked = True Then

            L_MinTPS.Visible = False
            N_MinTPS.Visible = False

            _mapType = 1
            ShowMap()

            SetAutoTuneButton()

        End If

    End Sub

    Private Sub R_IAPRPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_IAPRPM.CheckedChanged

        If R_IAPRPM.Checked = True Then

            L_MinTPS.Visible = False
            N_MinTPS.Visible = False

            _mapType = 2
            ShowMap()

            SetAutoTuneButton()

        End If

    End Sub

    Private Sub R_BOOSTRPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_BOOSTRPM.CheckedChanged

        If R_BOOSTRPM.Checked = True Then

            L_MinTPS.Visible = True
            N_MinTPS.Visible = True
            N_MinTPS.Value = My.Settings.MinTPS

            _mapType = 3
            ShowMap()

            SetAutoTuneButton()

        End If

    End Sub

    Private Sub B_AutoTune_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_AutoTune.Click

        Dim message As String = "Apply the Auto Tuned Map Changes to the " & SelectedMapString & " fuel map?" & Environment.NewLine & "Click OK to continue"

        If MessageBox.Show(message, "ECU Editor Auto Tune", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

            Dim value As Double = 0

            If R_TPSRPM.Checked = True Then

                AutoTuneTPSFuelMap()
                _autoTunedTPS = True

            ElseIf R_IAPRPM.Checked = True Then

                AutoTuneIAPFuelMap()
                _autoTunedIAP = True

            ElseIf R_BOOSTRPM.Checked = True Then

                AutoTuneBoostFuelMap()
                _autoTunedBoost = True

            End If

            message = "Auto Tune Map Changes have been applied to " & SelectedMapString & " fuel map."
            MessageBox.Show(message, "ECU Editor Auto Tune", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            B_AutoTune.Enabled = False

        End If

    End Sub

    Public Sub AutoTuneTPSFuelMap()

        Dim mapStructureTable As Integer
        Dim cylinder As Integer = 0        ' 0,1,2,3
        Dim ms01 As Integer = 0            ' 0,1
        Dim modeabc As Integer = 0
        Dim copyToMap As Long = 0
        Dim editingMap As Integer = 0
        Dim mapNumberOfColumns As Integer = 0
        Dim mapNumberOfRows As Integer = 0
        Dim autoTunePercentage As Double = 0
        Dim currentValue As Integer = 0
        Dim newValue As Integer = 0
        Dim tuneSelectedCellsOnly As Boolean = False

        If G_FuelMap.SelectedCells.Count > 1 Then
            tuneSelectedCellsOnly = True
        End If

        If ECUVersion = "gen2" Then
            mapStructureTable = &H52304
        ElseIf ECUVersion = "bking" Then
            mapStructureTable = &H54EB4
        ElseIf ECUVersion = "gixxer" Then
            mapStructureTable = gixxer_fuelmap_map_first + (2 * 4 * 24)
            ms01 = 1
        End If

        editingMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        mapNumberOfColumns = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        mapNumberOfRows = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        For xIndex As Integer = 0 To _tpsList.Count - 1
            For yIndex As Integer = 0 To _rpmList.Count - 1

                Dim tuneCell As Boolean = True

                If tuneSelectedCellsOnly = True And G_FuelMap(xIndex, yIndex).Selected = False Then
                    tuneCell = False
                End If

                If tuneCell = True Then

                    newValue = _autoTunedTPSFuelMap(xIndex, yIndex)

                    For cylinder = 0 To 3
                        copyToMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                        WriteFlashWord(copyToMap + (2 * (xIndex + (yIndex * mapNumberOfColumns))), newValue)
                    Next
                End If
            Next
        Next

    End Sub

    Public Sub AutoTuneIAPFuelMap()

        Try

            Dim mapStructureTable As Integer
            Dim mapStructureTable2 As Integer
            Dim cylinder As Integer = 0        ' 0,1,2,3
            Dim ms01 As Integer = 0            ' 0,1
            Dim modeabc As Integer = 0
            Dim copyToMap As Long = 0
            Dim copyToMap2 As Long = 0
            Dim editingMap As Integer = 0
            Dim mapNumberOfColumns As Integer = 0
            Dim mapNumberOfRows As Integer = 0
            Dim autoTunePercentage As Double = 0
            Dim currentValue As Integer = 0
            Dim newValue As Integer = 0
            Dim tuneSelectedCellsOnly As Boolean = False

            If G_FuelMap.SelectedCells.Count > 1 Then
                tuneSelectedCellsOnly = True
            End If

            If ECUVersion = "gen2" Then
                mapStructureTable = &H52244
                mapStructureTable2 = &H522A4
            ElseIf ECUVersion = "bking" Then
                mapStructureTable = &H54DF4
                mapStructureTable2 = &H54E54
            ElseIf ECUVersion = "gixxer" Then
                mapStructureTable = gixxer_fuelmap_map_first
                mapStructureTable2 = gixxer_fuelmap_map_first + (4 * 24)
                ms01 = 1
            End If

            editingMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
            mapNumberOfColumns = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            mapNumberOfRows = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

            For xIndex As Integer = 0 To _iapList.Count - 1
                For yIndex As Integer = 0 To _rpmList.Count - 1
                    If Double.TryParse(G_FuelMap.Item(xIndex, yIndex).Value, autoTunePercentage) = True Then

                        Dim tuneCell As Boolean = True

                        If tuneSelectedCellsOnly = True And G_FuelMap(xIndex, yIndex).Selected = False Then
                            tuneCell = False
                        End If

                        If tuneCell = True Then

                            newValue = _autoTunedIAPFuelMap(xIndex, yIndex)

                            For cylinder = 0 To 3
                                For ms01 = 0 To 1

                                    copyToMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                                    WriteFlashWord(copyToMap + (2 * (xIndex + (yIndex * mapNumberOfColumns))), newValue)

                                    copyToMap2 = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable2 + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                                    WriteFlashWord(copyToMap2 + (2 * (xIndex + (yIndex * mapNumberOfColumns))), newValue)

                                Next
                            Next
                        End If
                    End If
                Next
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace)

        End Try
    End Sub

    Public Sub AutoTuneBoostFuelMap()

    End Sub

    Public Function AutoTuneCorrection(ByVal percentageChange As Double) As Double

        Return percentageChange * (My.Settings.AutoTuneStrength / 100)

    End Function

    Private Sub LB_Values_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LB_Values.KeyDown

        If (e.Control = True And e.KeyCode = Keys.D) Then

            Dim values As List(Of LogValue) = New List(Of LogValue)

            If _mapType = 1 Then
                values = _tpsValues(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)
            ElseIf _mapType = 2 Then
                values = _iapValues(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)
            ElseIf _mapType = 3 Then
                values = _boostValues(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)
            End If

            values.Remove(LB_Values.SelectedItem)

            LB_Values.DataSource = Nothing
            LB_Values.DataSource = values

            G_FuelMap.CurrentCell.Style.BackColor = Color.White
            G_FuelMap.CurrentCell.Style.ForeColor = Color.Black

            Dim dataCount As Integer
            Dim avgAfr As Decimal = CalculateAvgAFR(values, dataCount)

            If R_LoggedAFR.Checked Then

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)) / avgAfr * 100)

                    G_FuelMap.CurrentCell.Value = avgAfr
                    G_FuelMap.CurrentCell.Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.CurrentCell.Style.ForeColor = GetCellForeColor(percentageChange)
                Else
                    G_FuelMap.CurrentCell.Value = ""
                End If

            ElseIf R_PercentageMapChange.Checked = True Then
                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)) / avgAfr * 100)
                    G_FuelMap.CurrentCell.Value = percentageChange
                    G_FuelMap.CurrentCell.Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.CurrentCell.Style.ForeColor = GetCellForeColor(percentageChange)
                Else
                    G_FuelMap.CurrentCell.Value = ""
                End If
            End If

        End If

    End Sub

    Private Sub CalculateStdDevaition(ByRef logValues As List(Of LogValue), ByRef mean As Decimal, ByRef stdDev As Decimal)

        If logValues.Count = 0 Then
            mean = 0
            stdDev = 0
        Else

            Dim total As Double
            Dim sumOfSquaredDeviations As Double

            For Each value As LogValue In logValues
                total = total + value.AFR
            Next

            mean = total / logValues.Count

            For Each value As LogValue In logValues
                sumOfSquaredDeviations = sumOfSquaredDeviations + System.Math.Pow(value.AFR - mean, 2)
            Next

            stdDev = System.Math.Sqrt(sumOfSquaredDeviations / logValues.Count)

        End If

    End Sub

    Private Function DRound(ByVal val As Double) As Integer

        If val >= 0 Then
            Return Math.Truncate(val + 0.5)
        Else
            Return Math.Truncate(val - 0.5)
        End If

    End Function

    Private Function D2Fit(ByVal x1 As Integer, ByVal x3 As Integer, ByVal y1 As Integer, ByVal y2 As Integer, ByVal y3 As Integer) As Integer

        Dim d2 As Integer
        Dim x2 As Integer

        d2 = y1 - 2 * y2 + y3
        x2 = (x1 + x3 - d2)
        x2 = DRound(x2 / 2.0)

        Return x2

    End Function

    Private Function MapSmoother(ByVal map_smoothing_strength As Integer, ByVal maxVal As Integer, ByVal maxRPM As Integer, ByRef c_map As Integer(,), ByRef p_map As Integer(,), ByRef r_map As Integer(,), ByRef n_map As Integer(,))
        Dim iterationCount As Integer
        Dim totalCount As Integer
        Dim min_auto As Integer

        ' When map_smooth_strength is 0 the routine performs no action, otherwise performs multiple calls starting from 8 down to that value.
        ' Best option is always to use map_smooth_strength = 8, so any cell could be a candidate for smoothing, including the cells with no close changes (num_auto = 0).
        ' The special pass (min_auto = 0) has the only effect of applying  to all cells, including those with num_auto = 0, the "sanity check": min(tc,bc) <= cc <= max(tc,bc)
        ' The idea is that the algorithm start focusing on the areas with higher level of information, 
        ' so the interpolated cells are likely to have the best possible values. This is important since each generation
        ' of new cells is the base for further interpolation and values once established are never modified.

        min_auto = 8
        totalCount = 0

        For j As Integer = 0 To maxVal - 1 Step 1
            For i As Integer = 0 To maxRPM - 1 Step 1
                n_map(i, j) = c_map(i, j)
            Next
        Next

        If map_smoothing_strength > 9 Then

            For k As Integer = 1 To 3 Step 1
                totalCount = Do_Pre_Smooth(maxVal, maxRPM, c_map, p_map, r_map, n_map)
            Next

            map_smoothing_strength = map_smoothing_strength - 10
        End If

        If map_smoothing_strength = 0 Then
            For j As Integer = 0 To maxVal - 1 Step 1
                For i As Integer = 0 To maxRPM - 1 Step 1
                    n_map(i, j) = c_map(i, j)
                Next
            Next
            Return totalCount
        End If

        Do
            Do
                iterationCount = Do_Smooth(min_auto, maxVal, maxRPM, c_map, p_map, r_map, n_map)
                totalCount = totalCount + iterationCount
            Loop While iterationCount > 0
            min_auto = min_auto - 1
        Loop While min_auto > (8 - map_smoothing_strength)

        Return totalCount

    End Function

    Private Function Do_Pre_Smooth(ByVal maxVal As Integer, ByVal maxRPM As Integer, ByRef c_map As Integer(,), ByRef p_map As Integer(,), ByRef r_map As Integer(,), ByRef n_map As Integer(,))

        ' Values in the RPM/TPS and RPM/IAP matrix are considered as a function
        ' of 2 variables, with values sampled at regularly spaced increments.
        ' The purpose of this routine is to smooth the values comint from 
        ' the autotuned matrix. Each value is compared with the 8 surrounding
        ' values in order to correct or filer unlikely values.
        ' When less then 8 surrounding cells are modified, the missing cells are filled
        ' with the running map value.
        '
        '
        '               Autotune            
        '               square              
        '
        '             +----------+        
        '             |tlc tc trc|        
        '             |lc  cc rc |        
        '             |blc bc brc|       
        '             +----------+       
        '
        ' d/dr    = cc-tc                 first partial derivative by row
        ' d/dc    = cc-lc                 first partial derivative by column
        ' d2/dr2  = bc-2cc+tc             second partial derivative by row 2 times
        ' d2/dc2  = rc-2cc+lc             second partial derivative by col 2 times
        ' d2/drdc = (brc+tlc-trc-blc)/4   second partial derivative mixed
        '
        ' d2 = d/dr2 + 2(d/drdc) + d/dc2    second order differential
        '
        ' By equting the second order differentials in cc and cr, the result is:
        '
        ' bc-2cc+tc +(brc+tlc-trc-blc)/2 +rc-2cc+lc =
        ' br-2cr+tr +(brr+tlr-trr-blr)/2 +rr-2cr+lr
        '
        ' cc = cr +(bc-br+tc-tr+rc-rr+lc-lr)/4 +(brc-brr+tlc-tlr-trc+trr-blc+blr)/8
        '
        '
        Dim num_polished As Integer

        Dim tc As Integer   ' top cell on autotune matrix
        Dim bc As Integer   ' bottom cell on autotune matrix
        Dim lc As Integer   ' left cell on autotune matrix
        Dim rc As Integer   ' right cell on autotune matrix
        Dim cc As Integer   ' central cell on autotune matrix
        Dim trc As Integer  ' top right corner cell on autotune matrix
        Dim brc As Integer  ' bottom right corner cell on autotune matrix
        Dim tlc As Integer  ' top left corner cell on autotune matrix
        Dim blc As Integer  ' bottom left corner cell on autotune matrix
        Dim tr As Integer   ' top cell on running fuel matrix
        Dim br As Integer   ' bottom cell on running fuel matrix
        Dim lr As Integer   ' left cell on running fuel matrix
        Dim rr As Integer   ' right cell on running fuel matrix
        Dim cr As Integer   ' central cell on running fuel matrix
        Dim trr As Integer  ' top right corner cell on running fuel matrix
        Dim brr As Integer  ' bottom right corner cell on running fuel matrix
        Dim tlr As Integer  ' top left corner cell on running fuel matrix
        Dim blr As Integer  ' bottom left cell on running fuel matrix

        Dim local_factor As Double
        Dim clocal As Double
        Dim idiff As Integer
        Dim cdiff As Double
        Dim num_auto As Integer
        Dim s_map(maxRPM, maxVal) As Integer
        Dim n As Integer
        num_polished = 0

        For j As Integer = 1 To maxVal - 1 Step 1
            For i As Integer = 1 To maxRPM - 2 Step 1

                If p_map(i, j) = 0 Then
                    Continue For
                End If

                ' On each cell not on the boundary rows or columns, performs 2 dimensions, 2nd order interpolation

                ' Last column is handled as if it had an identical column on its right.
                If j = maxVal - 1 Then
                    n = 0
                Else
                    n = 1
                End If

                num_auto = 0
                cc = c_map(i, j)
                cr = r_map(i, j)

                If j = maxVal - 1 Then
                    idiff = 0
                End If

                tr = r_map(i - 1, j)
                br = r_map(i + 1, j)
                rr = r_map(i, j + n)
                lr = r_map(i, j - 1)

                trr = r_map(i - 1, j + n)
                tlr = r_map(i - 1, j - 1)
                brr = r_map(i + 1, j + n)
                blr = r_map(i + 1, j - 1)

                If p_map(i - 1, j) > 0 Then
                    tc = c_map(i - 1, j)
                    num_auto = num_auto + 1
                Else
                    tc = tr
                End If

                If p_map(i + 1, j) > 0 Then
                    bc = c_map(i + 1, j)
                    num_auto = num_auto + 1
                Else
                    bc = br
                End If

                If p_map(i, j + n) > 0 Then
                    rc = c_map(i, j + n)
                    num_auto = num_auto + 1
                Else
                    rc = rr
                End If

                If p_map(i, j - 1) > 0 Then
                    lc = c_map(i, j - 1)
                    num_auto = num_auto + 1
                Else
                    lc = lr
                End If


                If p_map(i - 1, j + n) > 0 Then
                    trc = c_map(i - 1, j + n)
                    num_auto = num_auto + 1
                Else
                    trc = trr
                End If

                If p_map(i - 1, j - 1) > 0 Then
                    tlc = c_map(i - 1, j - 1)
                    num_auto = num_auto + 1
                Else
                    tlc = tlr
                End If

                If p_map(i + 1, j + n) > 0 Then
                    brc = c_map(i + 1, j + n)
                    num_auto = num_auto + 1
                Else
                    brc = brr
                End If

                If p_map(i + 1, j - 1) > 0 Then
                    blc = c_map(i + 1, j - 1)
                    num_auto = num_auto + 1
                Else
                    blc = blr
                End If

                idiff = 2 * (bc - br + tc - tr + rc - rr + lc - lr) + (brc - brr + tlc - tlr - trc + trr - blc + blr)
                clocal = (8 * cr + idiff) / 8.0

                ' weighted average between the current central value and the value suggested by num_auto surrounding cells

                cdiff = 0.3 + (5.0 * Abs(cc - cr)) / cr  ' A large %map change reduces the trust on the central cell

                local_factor = num_auto * cdiff / 8.0

                If local_factor > 0.7 Then       ' Surrounding cells weight limited to 70%
                    local_factor = 0.7
                End If

                s_map(i, j) = DRound(clocal * local_factor + cc * (1.0 - local_factor))

            Next
        Next

        For j As Integer = 1 To maxVal - 1 Step 1
            For i As Integer = 1 To maxRPM - 2 Step 1

                If p_map(i, j) > 0 Then

                    c_map(i, j) = s_map(i, j)

                    If (Abs(c_map(i, j) - n_map(i, j)) * 1.0) / n_map(i, j) > 0.01 Then
                        num_polished = num_polished + 1
                    End If

                End If

            Next
        Next

        Return num_polished

    End Function

    Private Function Do_Smooth(ByVal min_auto As Integer, ByVal maxVal As Integer, ByVal maxRPM As Integer, ByRef c_map As Integer(,), ByRef p_map As Integer(,), ByRef r_map As Integer(,), ByRef n_map As Integer(,))
        '
        ' Values in the RPM/TPS and RPM/IAP matrix are considered as a function
        ' of 2 variables, with values sampled at regularly spaced increments.
        ' The purpose of this routine is to update the current fuel matrix using
        ' values coming from the autotuned matrix. The autotune matrix has frequently
        ' unchanged cells surrounded by modified cells. This routine tries to
        ' polish the surface with the objective of reproducing the shape of the current
        ' running map, either as slope in the axis directions (i.e. first order
        ' partial derivatives) or the curvature (i.e. second order partial derivaties).
        ' 8 cells are required to approximate the derivatives by finite differences.
        ' When less then 8 surrounding cells are modified, the missing cells are filled
        ' with the running map values.
        '
        '
        '               Autotune            Runtime
        '               square              square
        '
        '             +----------+        +----------+
        '             |tlc tc trc|        |tlr tr trr|
        '             |lc  cc rc |        |lr  cr rr |
        '             |blc bc brc|        |blr br brr|
        '             +----------+        +----------+
        '
        ' d/dr    = cc-tc                 first partial derivative by row
        ' d/dc    = cc-lc                 first partial derivative by column
        ' d2/dr2  = bc-2cc+tc             second partial derivative by row 2 times
        ' d2/dc2  = rc-2cc+lc             second partial derivative by col 2 times
        ' d2/drdc = (brc+tlc-trc-blc)/4   second partial derivative mixed
        '
        ' d2 = d/dr2 + 2(d/drdc) + d/dc2    second order differential
        '
        ' By equting the second order differentials in cc and cr, the result is:
        '
        ' bc-2cc+tc +(brc+tlc-trc-blc)/2 +rc-2cc+lc =
        ' br-2cr+tr +(brr+tlr-trr-blr)/2 +rr-2cr+lr
        '
        ' cc = cr +(bc-br+tc-tr+rc-rr+lc-lr)/4 +(brc-brr+tlc-tlr-trc+trr-blc+blr)/8
        '
        '
        Dim num_polished, num_auto, num_cross, num_edge As Integer

        Dim tc As Integer   ' top cell on autotune matrix
        Dim bc As Integer   ' bottom cell on autotune matrix
        Dim lc As Integer   ' left cell on autotune matrix
        Dim rc As Integer   ' right cell on autotune matrix
        Dim cc As Integer   ' central cell on autotune matrix
        Dim trc As Integer  ' top right corner cell on autotune matrix
        Dim brc As Integer  ' bottom right corner cell on autotune matrix
        Dim tlc As Integer  ' top left corner cell on autotune matrix
        Dim blc As Integer  ' bottom left corner cell on autotune matrix
        Dim tr As Integer   ' top cell on running fuel matrix
        Dim br As Integer   ' bottom cell on running fuel matrix
        Dim lr As Integer   ' left cell on running fuel matrix
        Dim rr As Integer   ' right cell on running fuel matrix
        Dim cr As Integer   ' central cell on running fuel matrix
        Dim trr As Integer  ' top right corner cell on running fuel matrix
        Dim brr As Integer  ' bottom right corner cell on running fuel matrix
        Dim tlr As Integer  ' top left corner cell on running fuel matrix
        Dim blr As Integer  ' bottom left cell on running fuel matrix

        num_polished = 0

        For j As Integer = 0 To maxVal - 1 Step 1
            For i As Integer = 0 To maxRPM - 1 Step 1

                num_auto = 0
                num_cross = 0
                num_edge = 0

                cc = c_map(i, j)
                cr = r_map(i, j)

                n_map(i, j) = cc

                If p_map(i, j) > 0 Then
                    Continue For
                End If

                If ((i = 0 Or i = maxRPM - 1) And (j = 0 Or j = maxVal - 1)) Then  ' ignore cells on the 4 corners
                    cc = cr
                    n_map(i, j) = cc
                    Continue For

                ElseIf (j = 0 Or j = maxVal - 1) Then    ' cell either on first or last column, performs 1 dimension, 2nd order interpolation

                    tc = c_map(i - 1, j)
                    bc = c_map(i + 1, j)
                    tr = r_map(i - 1, j)
                    br = r_map(i + 1, j)

                    If (p_map(i - 1, j) > 0) Then
                        num_cross = num_cross + 1
                    End If

                    If (p_map(i + 1, j) > 0) Then
                        num_cross = num_cross + 1
                    End If

                    If (Not (min_auto = 0 Or (min_auto = 1 And num_cross > 0) Or (min_auto > 1 And num_cross = 2))) Then
                        cc = cr
                        n_map(i, j) = cc
                        Continue For
                    End If

                    cc = D2Fit(tc, bc, tr, cr, br)

                    If cc > Max(tc, bc) Then
                        cc = Max(tc, bc)
                    End If

                    If cc < Min(tc, bc) Then
                        cc = Min(tc, bc)
                    End If

                ElseIf (i = 0 Or i = maxRPM - 1) Then    ' cell either on first or last row, performs 1 dimension, 2nd order interpolation

                    lc = c_map(i, j - 1)
                    rc = c_map(i, j + 1)
                    lr = r_map(i, j - 1)
                    rr = r_map(i, j + 1)

                    If (p_map(i, j - 1) > 0) Then
                        num_cross = num_cross + 1
                    End If

                    If (p_map(i, j + 1) > 0) Then
                        num_cross = num_cross + 1
                    End If

                    If (Not (min_auto = 0 Or (min_auto = 1 And num_cross > 0) Or (min_auto > 1 And num_cross = 2))) Then
                        cc = cr
                        n_map(i, j) = cc
                        Continue For
                    End If

                    cc = D2Fit(lc, rc, lr, cr, rr)

                    If cc > Max(lc, rc) Then
                        cc = Max(lc, rc)
                    End If

                    If cc < Min(lc, rc) Then
                        cc = Min(lc, rc)
                    End If

                Else  ' Any cell not on the boundary rows or columns, performs 2 dimensions, 2nd order interpolation

                    tr = r_map(i - 1, j)
                    br = r_map(i + 1, j)
                    rr = r_map(i, j + 1)
                    lr = r_map(i, j - 1)

                    tc = c_map(i - 1, j)
                    bc = c_map(i + 1, j)
                    rc = c_map(i, j + 1)
                    lc = c_map(i, j - 1)

                    If p_map(i - 1, j) > 0 Then
                        num_cross = num_cross + 1
                    End If

                    If p_map(i + 1, j) > 0 Then
                        num_cross = num_cross + 1
                    End If

                    If p_map(i, j + 1) > 0 Then
                        num_cross = num_cross + 1
                    End If

                    If p_map(i, j - 1) > 0 Then
                        num_cross = num_cross + 1
                    End If

                    trr = r_map(i - 1, j + 1)
                    tlr = r_map(i - 1, j - 1)
                    brr = r_map(i + 1, j + 1)
                    blr = r_map(i + 1, j - 1)

                    trc = c_map(i - 1, j + 1)
                    tlc = c_map(i - 1, j - 1)
                    brc = c_map(i + 1, j + 1)
                    blc = c_map(i + 1, j - 1)

                    If p_map(i - 1, j + 1) > 0 Then
                        num_edge = num_edge + 1
                    End If

                    If p_map(i - 1, j - 1) > 0 Then
                        num_edge = num_edge + 1
                    End If

                    If p_map(i + 1, j + 1) > 0 Then
                        num_edge = num_edge + 1
                    End If

                    If p_map(i + 1, j - 1) > 0 Then
                        num_edge = num_edge + 1
                    End If

                    num_auto = num_cross + num_edge

                    If (Not (min_auto = 0 Or (min_auto = 1 And num_auto > 0) Or (min_auto > 1 And num_auto >= min_auto And num_cross >= 2))) Then
                        cc = cr
                        n_map(i, j) = cc
                        Continue For
                    End If

                    cc = 2 * (bc - br + tc - tr + rc - rr + lc - lr) + (brc - brr + tlc - tlr - trc + trr - blc + blr)
                    cc = DRound((8 * cr + cc) / 8.0)

                    If cc < Min(tc, bc) Then
                        cc = Min(tc, bc)
                    End If

                    If cc > Max(tc, bc) Then
                        cc = Max(tc, bc)
                    End If

                End If

                p_map(i, j) = 1
                c_map(i, j) = cc
                n_map(i, j) = cc

                If cc <> cr Then
                    num_polished = num_polished + 1
                End If

            Next
        Next

        Return num_polished

    End Function

    Private Sub btnClear_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnClear.LinkClicked

        ClearData()
        ClearMap()
        L_FileName.Text = ""
        _filePath = ""
        _filePaths.Clear()
        L_CellInfo.Text = ""
        L_AvgTPS.Text = ""
        L_CellStats.Text = ""
        LB_Values.DataSource = New List(Of String)

    End Sub
End Class