Module InfoMod
    Public Function GetClipboard() As String
        Dim s As String = Clipboard.GetText
        If s.Contains("[#SYNTHLIP INFO]") Then
            Return s
        End If
        Return ""
    End Function

    Public Function DecodeHost(clip As String) As host
        If clip = "" Then
            Return Nothing
        End If
        Dim hostinfo As New host
        clip = clip.Replace("[#SYNTHLIP INFO]" & vbLf, "")
        Debug.WriteLine(clip)
        Do While clip.IndexOf("[NOTE") <> 0
            Dim line() As String = clip.Split(vbLf, 2)
            Dim divide() As String = line(0).Split(":")
            hostinfo.SetVal(divide(0), divide(1))

            clip = line(1)
            MainFrm.Text = clip.Contains("[NOTE")

        Loop
        Return hostinfo
    End Function

End Module
