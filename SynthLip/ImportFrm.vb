Public Class ImportFrm

    Private Sub ClipImport_Click(sender As Object, e As EventArgs) Handles ClipImport.Click
        Dim clip As String = GetClipboard()
        If clip = "" Then
            Exit Sub
        End If
        Dim metainfo As META = Decode(clip)
        MainFrm.Text = String.Format("Working on {0}", metainfo.PrjName)
        With metainfo
            Me.DetailLabel.Text = String.Format("Details----------
Path:{0}
EditTime:{1}
NoteCount:{2}
ScriptVersion:{3}
ProjectName:{4}
Track:{5}
TrackName:{6}", .PrjPath, .EditTime, .NoteCount, .ScriptVersion, .PrjName, .Track, .TrackName)
        End With
        Debug.WriteLine(String.Format("Successfully imported {0} - {1}", metainfo.PrjName, metainfo.TrackName))
        clip = clip.Substring(clip.IndexOf("[NOTE"))
        Dim note() As NOTEInfo = GetNotes(clip)
        Debug.Print("Attached noteset begining with " + note(0).Lyric)
    End Sub
End Class