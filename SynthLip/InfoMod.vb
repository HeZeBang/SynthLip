Module InfoMod
    Public Function GetClipboard() As String
        Dim s As String = Clipboard.GetText
        If s.Contains("[#SYNTHLIP INFO]") Then
            Return s
        End If
        Return ""
    End Function

    Public Function DecodeHost(clip As String) As host
        Dim hostinfo As New host
        clip.Replace("[#SYNTHLIP INFO]" & Chr(10), "")
        Do
            Dim s As String = LineInput(clip)
            hostinfo.SetVal(s.Split(":")(0), s.Split(":")(1))
        Loop While clip.Contains("[#") = 0
        Return hostinfo
    End Function

End Module
