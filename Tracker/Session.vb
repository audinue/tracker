Imports System.IO

Public Class Session

    Friend Start As DateTime = Now
    Friend Limit As TimeSpan = TimeSpan.FromMinutes(5)
    Friend Notes As String

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim params = MyBase.CreateParams
            params.ClassStyle = params.ClassStyle Or &H200
            Return params
        End Get
    End Property

    Private Sub Session_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1_Tick(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim remaining = Limit.Subtract(Now.Subtract(Start))
        If remaining.Ticks <= 0 Then
            Button1_Click(Nothing, Nothing)
            Exit Sub
        End If
        Label2.Text = Now.ToShortDateString
        Label4.Text = Now.ToLongTimeString
        Label6.Text = Limit.ToString(TIMESPAN_FORMAT)
        Label8.Text = Start.ToLongTimeString
        Label10.Text = Start.Add(Limit).ToLongTimeString
        Label12.Text = Now.Subtract(Start).ToString(TIMESPAN_FORMAT)
        Label14.Text = remaining.ToString(TIMESPAN_FORMAT)
        Label16.Text = IIf(String.IsNullOrEmpty(Notes), "(empty)", Notes)
        Text = Label14.Text & " - " & My.Settings.Title
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New LoginForm
        f.Show()
        f.BringToFront()
        Log("Stop", New String() {Limit.ToString(TIMESPAN_FORMAT), Start, Now, Notes})
        Close()
    End Sub
End Class