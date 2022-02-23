Imports System.IO

Public Class Settings

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Title
        TextBox2.Text = My.Settings.Wallpaper
        TextBox3.Text = GetLogsPath()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.Title = TextBox1.Text
        My.Settings.Wallpaper = TextBox2.Text
        My.Settings.Logs = TextBox3.Text
        My.Settings.Save()
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Log("Exit")
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.FileName = TextBox2.Text
        If OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.FileName = TextBox3.Text
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TextBox3.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As New Logs
        f.ShowDialog(Me)
    End Sub
End Class
