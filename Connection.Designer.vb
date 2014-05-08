<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Connection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_FindQBFile = New System.Windows.Forms.Button()
        Me.tb_QBFileLoc = New System.Windows.Forms.TextBox()
        Me.cmb_Server = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_DB = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn_FindQBFile
        '
        Me.btn_FindQBFile.AutoSize = True
        Me.btn_FindQBFile.Location = New System.Drawing.Point(169, 169)
        Me.btn_FindQBFile.Name = "btn_FindQBFile"
        Me.btn_FindQBFile.Size = New System.Drawing.Size(116, 23)
        Me.btn_FindQBFile.TabIndex = 0
        Me.btn_FindQBFile.Text = "Find Quickbooks File"
        Me.btn_FindQBFile.UseVisualStyleBackColor = True
        '
        'tb_QBFileLoc
        '
        Me.tb_QBFileLoc.Location = New System.Drawing.Point(53, 143)
        Me.tb_QBFileLoc.Name = "tb_QBFileLoc"
        Me.tb_QBFileLoc.Size = New System.Drawing.Size(349, 20)
        Me.tb_QBFileLoc.TabIndex = 1
        '
        'cmb_Server
        '
        Me.cmb_Server.FormattingEnabled = True
        Me.cmb_Server.Location = New System.Drawing.Point(108, 44)
        Me.cmb_Server.Name = "cmb_Server"
        Me.cmb_Server.Size = New System.Drawing.Size(332, 21)
        Me.cmb_Server.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select Server:"
        '
        'btn_Submit
        '
        Me.btn_Submit.Location = New System.Drawing.Point(194, 217)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
        Me.btn_Submit.TabIndex = 4
        Me.btn_Submit.Text = "Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Select Database:"
        '
        'cmb_DB
        '
        Me.cmb_DB.FormattingEnabled = True
        Me.cmb_DB.Location = New System.Drawing.Point(108, 75)
        Me.cmb_DB.Name = "cmb_DB"
        Me.cmb_DB.Size = New System.Drawing.Size(332, 21)
        Me.cmb_DB.TabIndex = 5
        '
        'Connection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 265)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_DB)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_Server)
        Me.Controls.Add(Me.tb_QBFileLoc)
        Me.Controls.Add(Me.btn_FindQBFile)
        Me.Name = "Connection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_FindQBFile As System.Windows.Forms.Button
    Friend WithEvents tb_QBFileLoc As System.Windows.Forms.TextBox
    Friend WithEvents cmb_Server As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_DB As System.Windows.Forms.ComboBox
End Class
