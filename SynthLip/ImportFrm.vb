Public Class ImportFrm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ClipImport.Click
        Dim clip As String = GetClipboard()
        If clip = "" Then
            Exit Sub
        End If
        Dim hinfo As host = DecodeHost(clip)
        Me.TextBox1.Text += hinfo.PrjName & hinfo.Track
        Debug.WriteLine("Successfully imported " & hinfo.PrjName & " - " & hinfo.TrackName)
    End Sub
End Class