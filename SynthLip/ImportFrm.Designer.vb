<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportFrm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ClipImport = New System.Windows.Forms.Button()
        Me.DetailLabel = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'ClipImport
        '
        Me.ClipImport.Location = New System.Drawing.Point(12, 12)
        Me.ClipImport.Name = "ClipImport"
        Me.ClipImport.Size = New System.Drawing.Size(75, 23)
        Me.ClipImport.TabIndex = 0
        Me.ClipImport.Text = "Import"
        Me.ClipImport.UseVisualStyleBackColor = True
        '
        'DetailLabel
        '
        Me.DetailLabel.AutoSize = True
        Me.DetailLabel.Location = New System.Drawing.Point(12, 38)
        Me.DetailLabel.Name = "DetailLabel"
        Me.DetailLabel.Size = New System.Drawing.Size(97, 136)
        Me.DetailLabel.TabIndex = 2
        Me.DetailLabel.Text = "Details----------" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Path:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EditTime:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NoteCount:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ScriptVersion:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ProjectName:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tr" &
    "ack:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TrackName:"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(12, 177)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(394, 256)
        Me.CheckedListBox1.TabIndex = 3
        '
        'ImportFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 450)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.DetailLabel)
        Me.Controls.Add(Me.ClipImport)
        Me.Name = "ImportFrm"
        Me.Text = "ImportFrm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ClipImport As Button
    Friend WithEvents DetailLabel As Label
    Friend WithEvents CheckedListBox1 As CheckedListBox
End Class
