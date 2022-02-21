<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.SkinBut = New System.Windows.Forms.Button()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.DebugButton = New System.Windows.Forms.Button()
        Me.ShowPanel = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.ImportButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.SkinBut)
        Me.FlowLayoutPanel1.Controls.Add(Me.EditButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ExportButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.DebugButton)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(105, 426)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'ImportButton
        '
        Me.ImportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.ImportButton.Location = New System.Drawing.Point(3, 3)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(99, 39)
        Me.ImportButton.TabIndex = 0
        Me.ImportButton.Text = "Import"
        Me.ImportButton.UseVisualStyleBackColor = False
        '
        'SkinBut
        '
        Me.SkinBut.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SkinBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SkinBut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.SkinBut.Location = New System.Drawing.Point(3, 48)
        Me.SkinBut.Name = "SkinBut"
        Me.SkinBut.Size = New System.Drawing.Size(99, 39)
        Me.SkinBut.TabIndex = 4
        Me.SkinBut.Text = "Skin"
        Me.SkinBut.UseVisualStyleBackColor = False
        '
        'EditButton
        '
        Me.EditButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.EditButton.Location = New System.Drawing.Point(3, 93)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(99, 39)
        Me.EditButton.TabIndex = 1
        Me.EditButton.Text = "Edit"
        Me.EditButton.UseVisualStyleBackColor = False
        '
        'ExportButton
        '
        Me.ExportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.ExportButton.Location = New System.Drawing.Point(3, 138)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(99, 39)
        Me.ExportButton.TabIndex = 2
        Me.ExportButton.Text = "Export"
        Me.ExportButton.UseVisualStyleBackColor = False
        '
        'DebugButton
        '
        Me.DebugButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DebugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DebugButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.DebugButton.Location = New System.Drawing.Point(3, 183)
        Me.DebugButton.Name = "DebugButton"
        Me.DebugButton.Size = New System.Drawing.Size(99, 39)
        Me.DebugButton.TabIndex = 3
        Me.DebugButton.Text = "Debug"
        Me.DebugButton.UseVisualStyleBackColor = False
        '
        'ShowPanel
        '
        Me.ShowPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShowPanel.Location = New System.Drawing.Point(123, 12)
        Me.ShowPanel.Name = "ShowPanel"
        Me.ShowPanel.Size = New System.Drawing.Size(665, 426)
        Me.ShowPanel.TabIndex = 3
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ShowPanel)
        Me.Name = "MainFrm"
        Me.Text = "MainFrm"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ImportButton As Button
    Friend WithEvents EditButton As Button
    Friend WithEvents ExportButton As Button
    Friend WithEvents ShowPanel As Panel
    Friend WithEvents DebugButton As Button
    Friend WithEvents SkinBut As Button
End Class
