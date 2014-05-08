Public Class Login
    Private qta As ds_ProgramTableAdapters.QueriesTableAdapter

    Private Sub btn_Login_Click(sender As System.Object, e As System.EventArgs) Handles btn_Login.Click
        Me.Cursor = Cursors.WaitCursor

        Dim userID As Integer
        userID = qta.USERS_Authenticate(tb_Username.Text, mtb_Password.Text)
        If (userID <> Nothing) Then
            ' CHANGE CONNECTION STRING
            Dim conPW As String = "Yealink01"
            My.Settings.Item("QBDBConnectionString") = "Data Source=" & My.Settings.SQLSERVER & ";Initial Catalog=" & My.Settings.DATABASENAME & ";Integrated Security=False;USER ID=" & qta.USERS_GetName(userID).ToString & ";Password=" & conPW

            Dim splash As New SplashScreen
            splash.Show()
            Me.Hide()
            Dim home As New TrashCash_Home(splash, userID)
            home.Show()
            Me.Close()
        Else
            MsgBox("Username and/or Password is incorrect.")
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Login_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        qta = New ds_ProgramTableAdapters.QueriesTableAdapter
        'clear boxes and reset user index
        mtb_Password.Clear()
        tb_Username.Clear()
        ' close connection form
        If (_conForm IsNot Nothing) Then
            _conForm.Close()
        End If
    End Sub

    Private _conForm As Connection
    Public Sub New(ByRef ConForm As Connection)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _conForm = ConForm
    End Sub

    Private Sub mtb_Password_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles mtb_Password.KeyDown, tb_Username.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btn_Login.PerformClick()
        End If
    End Sub
End Class