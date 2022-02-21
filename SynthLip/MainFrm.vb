Public Class MainFrm

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub DebugButton_Click(sender As Object, e As EventArgs) Handles DebugButton.Click
        Me.ShowPanel.Controls.Clear()
        Dim showfrm As New DbgFrm
        showfrm.FormBorderStyle = FormBorderStyle.None
        showfrm.TopLevel = False
        showfrm.Parent = Me.ShowPanel
        showfrm.Dock = DockStyle.Fill
        showfrm.Show()
    End Sub

    Private Sub MainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        Me.ShowPanel.Controls.Clear()
        Dim showfrm As New ImportFrm
        showfrm.FormBorderStyle = FormBorderStyle.None
        showfrm.TopLevel = False
        showfrm.Parent = Me.ShowPanel
        showfrm.Dock = DockStyle.Fill
        showfrm.Show()
    End Sub
End Class