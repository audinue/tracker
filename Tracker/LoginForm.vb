Public Class LoginForm

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim params = MyBase.CreateParams
            params.ClassStyle = params.ClassStyle Or &H200
            Return params
        End Get
    End Property

    Sub LoadWallpaper()
        If Not String.IsNullOrEmpty(My.Settings.Wallpaper) Then
            Try
                BackgroundImage = Bitmap.FromFile(My.Settings.Wallpaper)
            Catch ex As Exception
                'Ignore
            End Try
        End If
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWallpaper()
        Dim f As New LoginChildForm
        f.Show(Me)
    End Sub

    Private Sub LoginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.Shift And e.KeyCode = Keys.P Then
            Dim f As New Settings
            f.ShowDialog(Me)
            LoadWallpaper()
        End If
    End Sub

    Private Sub LoginForm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        KeyboardJammer.Jam()
    End Sub

    Private Sub LoginForm_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed
        KeyboardJammer.UnJam()
    End Sub
End Class
