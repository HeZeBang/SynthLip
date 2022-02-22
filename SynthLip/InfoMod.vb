Module InfoMod

    Public Function GetClipboard() As String
        Dim s As String = Clipboard.GetText
        If s.Contains("[#SYNTHLIP INFO]") Then
            Return s
        End If
        Return ""
    End Function

    Public Function Decode(clip As String) As META
        If Not clip.Contains("#SYNTHLIP INFO") Then
            Return Nothing
        End If
        clip = clip.Replace("#SYNTHLIP INFO" & vbLf, "")
        clip = clip.Substring(0, clip.IndexOf("[") - 1)
        Dim metainfo As New META

        Using document As JsonDocument = JsonDocument.Parse(clip)

        End Using

        'Do While clip.IndexOf("[NOTE") <> 0
        'Dim line() As String = clip.Split(vbLf, 2)
        'Dim divide() As String = line(0).Split(":")
        'metainfo.SetVal(divide(0), divide(1))
        'clip = line(1)
        'Loop
        Return metainfo
    End Function

    Public Function GetNotes(clip As String) As NOTEInfo()
        If clip = "" Then
            Return Nothing
        End If
        Dim note() As NOTEInfo

        'clip = clip.Replace("[#SYNTHLIP INFO]" & vbLf, "")
        Dim cnt As Integer = 0
        Do While clip.Contains(String.Format("[NOTE{0}]" & vbLf, cnt))
            clip = clip.Substring(clip.IndexOf("]" & vbLf) + 2)
            cnt += 1

            'note(cnt) = New NOTEInfo
            Dim tmpdata As New NOTEInfo
            While clip <> ""
                Dim line() As String = clip.Split(vbLf, 2)
                Dim divide() As String = line(0).Split(":")
                'Dim note(cnt) As New NOTEInfo
                'note(cnt).SetVal(divide(0), divide(1))
                tmpdata.SetVal(divide(0), divide(1))
                clip = line(1)
            End While
        Loop
        Return note
    End Function
End Module
