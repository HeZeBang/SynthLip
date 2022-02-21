Module InfoMod
    Public Function GetClipboard() As String
        Dim s As String = Clipboard.GetText
        If s.Contains("[#SYNTHLIP INFO]") Then
            Return s
        End If
        Return ""
    End Function

    Public Function Decode(clip As String) As Object()
        Dim retval As Object()
        clip.Replace("[#SYNTHLIP INFO]" & Chr(10), "")
        Dim hostinfo As New host
        For i As Integer = 0 To 4

        Next
        Return Nothing
    End Function

End Module
