Imports System.IO

Public Class Logs

    Private Lines As New List(Of String())

    Private Sub Logs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each line In File.ReadAllLines(GetLogsPath)
            Lines.Add(line.Split(vbTab))
        Next
        ListView1.VirtualListSize = Lines.Count
    End Sub

    Private Sub ListView1_RetrieveVirtualItem(sender As Object, e As RetrieveVirtualItemEventArgs) Handles ListView1.RetrieveVirtualItem
        Dim line = Lines(e.ItemIndex)
        Dim item As New ListViewItem
        item.Text = line(0)
        For i = 1 To 5
            If i < line.Length Then
                item.SubItems.Add(line(i))
            Else
                item.SubItems.Add(String.Empty)
            End If
        Next
        e.Item = item
    End Sub
End Class