Public Class LoginChildForm

    Private WithEvents Sett As My.MySettings

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim params = MyBase.CreateParams
            params.ClassStyle = params.ClassStyle Or &H200
            Return params
        End Get
    End Property

    Private Sub LoginChildForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sett = My.Settings
        Text = My.Settings.Title
        Timer1_Tick(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ContextMenuStrip1.Show(MousePosition)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Now.ToShortDateString
        Label4.Text = Now.ToLongTimeString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New Session
        f.Start = Now
        If RadioButton1.Checked Then
            f.Limit = TimeSpan.FromMinutes(5)
        ElseIf RadioButton2.Checked Then
            f.Limit = TimeSpan.FromMinutes(15)
        ElseIf RadioButton3.Checked Then
            f.Limit = TimeSpan.FromMinutes(30)
        ElseIf RadioButton4.Checked Then
            f.Limit = TimeSpan.FromMinutes(TextBox1.Text)
        End If
        f.Notes = TextBox2.Text
        f.Show()
        Log("Start")
        Owner.Close()
    End Sub

    Private Sub HibernateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HibernateToolStripMenuItem.Click
        Log("Power Off")
        Process.Start("shutdown", "/h /f")

    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShutdownToolStripMenuItem.Click
        Log("Power Off")
        Process.Start("shutdown", "/s /t 0")
    End Sub

    Private Sub App_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles Sett.PropertyChanged
        If e.PropertyName = "Title" Then
            Text = My.Settings.Title
        End If
    End Sub
End Class