<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.lbl_Username = New System.Windows.Forms.Label()
        Me.lbl_PW = New System.Windows.Forms.Label()
        Me.tb_Username = New System.Windows.Forms.TextBox()
        Me.mtb_Password = New System.Windows.Forms.MaskedTextBox()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_Username
        '
        Me.lbl_Username.AutoSize = True
        Me.lbl_Username.Location = New System.Drawing.Point(48, 15)
        Me.lbl_Username.Name = "lbl_Username"
        Me.lbl_Username.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Username.TabIndex = 0
        Me.lbl_Username.Text = "Username:"
        '
        'lbl_PW
        '
        Me.lbl_PW.AutoSize = True
        Me.lbl_PW.Location = New System.Drawing.Point(48, 62)
        Me.lbl_PW.Name = "lbl_PW"
        Me.lbl_PW.Size = New System.Drawing.Size(56, 13)
        Me.lbl_PW.TabIndex = 1
        Me.lbl_PW.Text = "Password:"
        '
        'tb_Username
        '
        Me.tb_Username.Location = New System.Drawing.Point(112, 12)
        Me.tb_Username.Name = "tb_Username"
        Me.tb_Username.Size = New System.Drawing.Size(173, 20)
        Me.tb_Username.TabIndex = 2
        '
        'mtb_Password
        '
        Me.mtb_Password.Location = New System.Drawing.Point(110, 59)
        Me.mtb_Password.Name = "mtb_Password"
        Me.mtb_Password.Size = New System.Drawing.Size(175, 20)
        Me.mtb_Password.TabIndex = 3
        Me.mtb_Password.UseSystemPasswordChar = True
        '
        'btn_Login
        '
        Me.btn_Login.Location = New System.Drawing.Point(149, 86)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(75, 23)
        Me.btn_Login.TabIndex = 4
        Me.btn_Login.Text = "Login"
        Me.btn_Login.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 116)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.mtb_Password)
        Me.Controls.Add(Me.tb_Username)
        Me.Controls.Add(Me.lbl_PW)
        Me.Controls.Add(Me.lbl_Username)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Username As System.Windows.Forms.Label
    Friend WithEvents lbl_PW As System.Windows.Forms.Label
    Friend WithEvents tb_Username As System.Windows.Forms.TextBox
    Friend WithEvents mtb_Password As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_Login As System.Windows.Forms.Button
End Class
