Imports System.IO

Module Module1

    Friend Const TIMESPAN_FORMAT = "hh\:mm\:ss"

    Function GetLogsPath() As String
        If String.IsNullOrEmpty(My.Settings.Logs) Then
            Return Application.UserAppDataPath & "\Logs.txt"
        Else
            Return My.Settings.Logs
        End If
    End Function

    Sub Log(type As String, suffix As String())
        File.AppendAllText(GetLogsPath, type & vbTab & Now & vbTab & String.Join(vbTab, suffix) & vbCrLf)
    End Sub

    Sub Log(type As String)
        File.AppendAllText(GetLogsPath, type & vbTab & Now & vbCrLf)
    End Sub

End Module
