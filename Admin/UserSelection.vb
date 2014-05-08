Public Class UserSelection
    Private qta As ds_ProgramTableAdapters.QueriesTableAdapter
    ' events
    Friend Event AdminShow(ByVal authLvl As Integer)

    Private Sub UserSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        qta = New ds_ProgramTableAdapters.QueriesTableAdapter

    End Sub

    Private Sub btn_Login_Click(sender As System.Object, e As System.EventArgs) Handles btn_Login.Click
        Me.Cursor = Cursors.WaitCursor

        Dim userID As Integer
        userID = qta.USERS_Authenticate(Cmb_Users.GetItemText(Cmb_Users.SelectedItem).ToString, mtb_Password.Text)
        If (userID <> Nothing) Then
            RaiseEvent AdminShow(Cmb_Users.AuthLevel)
            Cmb_Users.SelectedIndex = 0
            mtb_Password.Clear()
            Me.Close()
        Else
            MsgBox("Username and/or Password is incorrect.")
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub mtb_Password_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles mtb_Password.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btn_Login.PerformClick()
        End If
    End Sub
End Class