Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserSelection
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserSelection))
            Me.Cmb_Users = New TrashCash.Database_ComboBoxes.cmb_Users()
            Me.mtb_Password = New System.Windows.Forms.MaskedTextBox()
            Me.lbl_PW = New System.Windows.Forms.Label()
            Me.lbl_Username = New System.Windows.Forms.Label()
            Me.btn_Login = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Cmb_Users
            '
            Me.Cmb_Users.DisplayMember = "USER_NAME"
            Me.Cmb_Users.FormattingEnabled = True
            Me.Cmb_Users.Location = New System.Drawing.Point(80, 12)
            Me.Cmb_Users.Name = "Cmb_Users"
            Me.Cmb_Users.Size = New System.Drawing.Size(175, 21)
            Me.Cmb_Users.TabIndex = 0
            Me.Cmb_Users.ValueMember = "USER_UD"
            '
            'mtb_Password
            '
            Me.mtb_Password.Location = New System.Drawing.Point(80, 59)
            Me.mtb_Password.Name = "mtb_Password"
            Me.mtb_Password.Size = New System.Drawing.Size(175, 20)
            Me.mtb_Password.TabIndex = 6
            Me.mtb_Password.UseSystemPasswordChar = True
            '
            'lbl_PW
            '
            Me.lbl_PW.AutoSize = True
            Me.lbl_PW.Location = New System.Drawing.Point(18, 62)
            Me.lbl_PW.Name = "lbl_PW"
            Me.lbl_PW.Size = New System.Drawing.Size(56, 13)
            Me.lbl_PW.TabIndex = 5
            Me.lbl_PW.Text = "Password:"
            '
            'lbl_Username
            '
            Me.lbl_Username.AutoSize = True
            Me.lbl_Username.Location = New System.Drawing.Point(18, 15)
            Me.lbl_Username.Name = "lbl_Username"
            Me.lbl_Username.Size = New System.Drawing.Size(58, 13)
            Me.lbl_Username.TabIndex = 4
            Me.lbl_Username.Text = "Username:"
            '
            'btn_Login
            '
            Me.btn_Login.Location = New System.Drawing.Point(113, 91)
            Me.btn_Login.Name = "btn_Login"
            Me.btn_Login.Size = New System.Drawing.Size(75, 23)
            Me.btn_Login.TabIndex = 7
            Me.btn_Login.Text = "Login"
            Me.btn_Login.UseVisualStyleBackColor = True
            '
            'UserSelection
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 126)
            Me.Controls.Add(Me.btn_Login)
            Me.Controls.Add(Me.mtb_Password)
            Me.Controls.Add(Me.lbl_PW)
            Me.Controls.Add(Me.lbl_Username)
            Me.Controls.Add(Me.Cmb_Users)
            Me.Name = "UserSelection"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "User Selection"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Cmb_Users As TrashCash.Database_ComboBoxes.cmb_Users
        Friend WithEvents mtb_Password As System.Windows.Forms.MaskedTextBox
        Friend WithEvents lbl_PW As System.Windows.Forms.Label
        Friend WithEvents lbl_Username As System.Windows.Forms.Label
        Friend WithEvents btn_Login As System.Windows.Forms.Button
    End Class
End Namespace