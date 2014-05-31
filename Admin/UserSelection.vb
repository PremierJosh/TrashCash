Namespace Admin
    Public Class UserSelection
     Private _authUserRow As ds_App.USERSRow = Nothing

        Public ReadOnly Property AuthUserRow As ds_App.USERSRow
            Get
                Return _authUserRow
            End Get
        End Property
        Private Sub UserSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ' fill users
            UserTA.Fill(Ds_App.USERS)
        End Sub

        ' password text after auth
        Private _pwText As String
        Friend ReadOnly Property AuthPWText As String
            Get
                Return _pwText
            End Get
        End Property

        ' var for changing pw
        Private ReadOnly _pwChange As Boolean = False

        Private Sub btn_Login_Click(sender As System.Object, e As System.EventArgs) Handles btn_Login.Click
            Cursor = Cursors.WaitCursor

            Dim userID As Integer
            userID = AppQTA.USERS_Authenticate(cmb_Users.GetItemText(cmb_Users.SelectedItem).ToString, mtb_Password.Text)

            ' checking if this is for a pw change
            If (_pwChange) Then
                ' making sure theres something in the field
                If (Trim(mtb_Password.Text).Length > 0) Then
                    _pwText = mtb_Password.Text
                    mtb_Password.Clear()
                    Close()
                Else
                    _pwText = Nothing
                End If
            ElseIf (userID <> Nothing) Then

                ' getting new user row
                _authUserRow = UserTA.GetDataByID(userID).Rows(0)
                
                cmb_Users.SelectedIndex = 0
                ' grabbing pw at finish
                _pwText = mtb_Password.Text

                mtb_Password.Clear()
                Close()
            Else
                MsgBox("Username and/or Password is incorrect.")
            End If

            Cursor = Cursors.Default
        End Sub

        Public Sub New(ByVal windowTitle As String, Optional ByVal changePW As Boolean = False)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = windowTitle

            ' checking if this is for a changed password
            _pwChange = ChangePW
        End Sub

        Private Sub mtb_Password_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles mtb_Password.KeyDown
            If (e.KeyCode = Keys.Enter) Then
                btn_Login.PerformClick()
            End If
        End Sub

        Private Sub mtb_Password_Enter(sender As System.Object, e As System.EventArgs) Handles mtb_Password.Enter, mtb_Password.GotFocus
            If (Trim(mtb_Password.Text).Length > 0) Then
                mtb_Password.SelectAll()
            End If
        End Sub
    End Class
End Namespace