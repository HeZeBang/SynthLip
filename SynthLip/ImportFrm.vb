Public Class ImportFrm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim clip As String = GetClipboard()
        Dim hinfo As host = DecodeHost(clip)
        Me.TextBox1.Text += hinfo.PrjName
    End Sub
End Class