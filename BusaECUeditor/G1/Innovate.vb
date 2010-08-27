Imports System.Windows.Forms


Public Class Innovate
    Dim SampleCount As Integer
    Dim AFR_Input As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        MTS1.Disconnect()
        Me.Close()
    End Sub

    Private Sub InnovateSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        innovatevisible = True
    End Sub

    
    Private Sub BuildInputCharts()
        ' Subroutine to update all the Charts and text
        ' This gets called when we load the form, when we connect
        ' And when we disconnect
        Dim inpstr As Object
        Dim n As Object
        Dim icount As Object
        ' Get input details
        ' Start with the count (0 if not connected)

        icount = MTS1.InputCount

        ' Any active channels?
        If icount <> 0 Then

            ' Clip at 8!!!
            If icount > 8 Then

                icount = 8
            End If

            ' Channel index is base 0
            icount = icount - 1

            ' Loop through available channels
            For n = 0 To icount
                ' Turn Grids on

                ' Get the Input details
                ' Start with the input name and Units
                MTS1.CurrentInput = n
                inpstr = Format(n + 1) & ": " & MTS1.InputName
                inpstr = inpstr + " " + MTS1.InputUnit

                ' If AFR, append the multipler, if 5V, input the unit range
                If MTS1.InputType = 1 Then
                    inpstr = inpstr + " (" + Format(MTS1.InputAFRMultiplier) + ")"
                ElseIf MTS1.InputType = 2 Then
                    inpstr = inpstr + " (" + Format(MTS1.InputMinValue) + ".." + Format(MTS1.InputMaxValue) + ")"
                End If

                InputDetails.Text = inpstr

                ' Set the Channel Value
                Channelvalue.Text = ""
            Next n
        Else
            ' If there are no actual channels, step back to -1
            ' So the next loop will clear all
            icount = -1
        End If

    End Sub

    ' This routine is called when our main form loads
    ' It builds a listbox of available MTS ports and
    ' selects the first one.  If no ports are available
    ' we put up an error and exit
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim i As Object
        Dim n As Object
        ' Are there any ports available?
        n = MTS1.PortCount

        ' If no, warn and exit, otherwise, generate a
        ' droplist
        If n = 0 Then
            MsgBox("No MTS Ports available!")
            End
        Else
            PortList.Items.Clear()
            n = n - 1
            For i = 0 To n
                MTS1.CurrentPort = i
                PortList.Items.Insert(i, MTS1.PortName)
            Next i

            ' Default to first port
            PortList.SelectedIndex = 0
        End If

        ' Setup our screen for disconnect state
        BuildInputCharts()
    End Sub

    ' This routine is called when our main form unloads
    ' We always call disconnect just to make sure!
    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MTS1.Disconnect()
        innovatevisible = False

    End Sub



    ' This event is signaled when an open connection fails
    ' We put up an error message, then 'press' the Disconnect button!
    Private Sub MTS1_ConnectionError(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MTS1.ConnectionError
        ' Alert the user an error occured
        MsgBox("Connection Timeout")

        ' Do Disconnect Logic
    End Sub

    ' This event is always triggered in response to a 'Connect'
    ' call to the SDK.  We well get:
    '   0 = Success
    '   -1 = No data read on Comm port
    '   < -1 = Internals errors (bad comm port specified, etc.)
    '
    ' If connect succeeds, we toggle the buttons, build our
    ' inputs, clear our sample count, and start data flowing.
    ' If an error occurs, we put up a message box
    Private Sub MTS1_ConnectionEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMTSSDKLib._IMTSEvents_ConnectionEventEvent) Handles MTS1.ConnectionEvent
        ' Connected?  Let's go!
        If eventArgs.result = 0 Then
            ' Toggle buttons
            ConnectButton.Enabled = False

            ' Get Channel info
            BuildInputCharts()

            ' Clear Sample buffer
            SampleCount = 0

            ' Start Data flowing
            MTS1.StartData()

            ' Report errors to user
        ElseIf eventArgs.result = -1 Then
            MsgBox("No MTS Data detected")
        Else
            MsgBox("Connect Error: " & Format(eventArgs.result))
        End If
    End Sub

    ' This function is called whenever:
    '   We are connected
    '   We have called StartData (only need to call once)
    '   New sample data is available
    ' Normally, this is called at about 12 Hz, but the rate
    ' Will be slower if we are connected to an LM-1 or LC-1
    ' In an Error or Special state (ex. Calibration)
    '
    ' For the example, we do several things.  On
    Public Sub MTS1_NewData()
        Dim sample As Object
        Dim icount As Object
        ' We allocate a double for our calculations
        Dim CValue As Double

        ' Get data for all our inputs
        icount = MTS1.InputCount
        If icount > 0 Then
            ' Increment our Sample Count

            ' If we have had 3 samples, (about .25 second)
            ' Update the numeric values and charts

            icount = icount - 1

            ' Do the following for every channel
            ' Select the Input

            MTS1.CurrentInput = AFR_Input

            ' Fetch the raw sample
            sample = MTS1.InputSample ' 0-1023

            ' We have to treat LAMBDA, AFR, and 5 Volt
            ' channels differently.  We also check for
            ' Special function codes (warmup, error,
            ' invalid data, etc.)

            If MTS1.InputType = 1 Then  ' AFR
                If MTS1.InputFunction = 0 Then ' MTS_FUNC_LAMBDA
                    ' Turn into .001 steps
                    CValue = sample
                    CValue = CValue / 1000
                    ' Add .5 offset
                    CValue = CValue + 0.5
                    ' Multply for AFR
                    CValue = CValue * MTS1.InputAFRMultiplier
                    AFR = Int(CValue * 10)
                    LED_AFR.BackColor = Color.Black
                    If CValue >= 16.0 Then LED_AFR.ForeColor = Color.Red
                    If CValue >= 14.0 Then LED_AFR.ForeColor = Color.LightPink
                    If CValue <= 12.5 Then LED_AFR.ForeColor = Color.Yellow
                    If CValue < 10.0 Then LED_AFR.ForeColor = Color.Gray

                    LED_AFR.Text = Format(CValue, "00.0")
                    Channelvalue.Text = Format(CValue, "00.0") & " (AFR)"
                End If
                If MTS1.InputFunction = 1 Then ' MTS_FUNC_LAMBDA
                    ' Turn into .001 steps
                    CValue = sample / 10

                    ' Add .5 offset

                    ' Multply for AFR
                    'CValue = CValue * MTS1.InputAFRMultiplier
                    AFR = Int(CValue * 10)
                    LED_AFR.BackColor = Color.Gray

                    If CValue >= 20.5 And CValue <= 21.5 Then
                        LED_AFR.ForeColor = Color.Green
                    Else
                        LED_AFR.ForeColor = Color.Red

                    End If
                    LED_AFR.Text = Format(CValue, "00.0")
                    Channelvalue.Text = Format(CValue, "00.0") & " (O2 %)"
                End If

                ' Lamba is identical to AFR, except we do not multiply
            End If

        End If
    End Sub

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click
        Dim i As Integer
        ' Set the MTS port to the current user selection
        MTS1.CurrentPort = Portlist.SelectedIndex
        ' Try to connect
        MTS1.Connect()
        For i = 0 To MTS1.InputCount - 1
            If MTS1.InputType = 1 And MTS1.InputFunction = 1 Then ' MTS_FUNC_LAMBDA
                AFR_Input = i
                AFR = 10
            End If
        Next

    End Sub

End Class

