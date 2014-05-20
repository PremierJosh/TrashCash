Imports System.Windows.Forms
Imports TrashCash.TrashCash_Utils
Imports TrashCash.TrashCash_Utils._Functions
Imports TrashCash.TrashCash_Utils.Err_Handling
Imports QBFC12Lib
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class TrashCash_Home
    ' var for current user id row
    Private _currentUserRow As ds_Program.USERSRow
    Public Property CurrentUserRow As ds_Program.USERSRow
        Get
            Return _currentUserRow
        End Get
        Set(value As ds_Program.USERSRow)
            _currentUserRow = value

            ' update name on status bars
            btn_CurrentUser.Text = "Current User: " & value.USER_NAME
            Me.Text = "TrashCash       | Current User: " & value.USER_NAME
            ' update auth level
            AuthLevel = value.USER_AUTHLVL

            ' close all child windows
            For Each f As Form In Me.MdiChildren
                f.Close()
                f = Nothing
            Next

            ' close admin form if open
            If (f_TrashCash_Admin IsNot Nothing) Then
                f_TrashCash_Admin.Close()
                f_TrashCash_Admin = Nothing
            End If

            ' CHANGE CONNECTION STRING
            Dim conPW As String = "Yealink01"
            My.Settings.Item("QBDBConnectionString") = "Data Source=" & My.Settings.SQLSERVER & ";Initial Catalog=" & My.Settings.DATABASENAME & ";Integrated Security=False;USER ID=" & value.USER_NAME & ";Password=" & conPW
        End Set
    End Property

    ' public auth level property for easier access and event raising
    Private _authLevel As Integer
    ' vars for quick menu checking
    Private _bypassLogin As Boolean = False
    Public Property AuthLevel As Integer
        Get
            Return _authLevel
        End Get
        Set(value As Integer)
            _authLevel = value

            ' current as of 5/16/14
            ' ID---NAME---AUTHLVL
            ' 1	  Premier	1
            ' 2	  Phyllis	1
            ' 3	  Pam		2
            ' 4	  Nicole	3

            ' auth level 1 is super admin, no login prompts
            If (value = 1) Then
                _bypassLogin = True
            Else
                MessageBox.Show("AUTH LEVEL UNKNOWKN")
            End If
        End Set
    End Property


    ' ds_program qta
    Private qta As ds_ProgramTableAdapters.QueriesTableAdapter

    'var for batching
    Private _BatchRunning As Boolean

    ' var for class files
    Protected c_QB_Queries As QB_Queries
    Public ReadOnly Property Queries As QB_Queries
        Get
            Return c_QB_Queries
        End Get
    End Property
    Protected c_QB_Procedures As QB_Procedures
    Public ReadOnly Property Procedures As QB_Procedures
        Get
            Return c_QB_Procedures
        End Get
    End Property
    Protected c_Reporting As Reporting
    Public ReadOnly Property Reporting As Reporting
        Get
            Return c_Reporting
        End Get
    End Property

    ' var for all child forms
    Friend WithEvents _payForm As Payments
    Friend WithEvents _batchForm As BatchingPrep
    Friend WithEvents _customer As Customer
    Friend WithEvents _pendingApprovals As PendingApprovals

    ' vars for admin forms'
    Friend WithEvents f_UserSelection As UserSelection
    Friend WithEvents f_TrashCash_Admin As TrashCash_Admin

    ' qb session and msg set req
    Friend app_SessMgr As QBSessionManager
    Public ReadOnly Property SessionManager As QBSessionManager
        Get
            Return app_SessMgr
        End Get
    End Property
    Protected Friend app_MsgSetReq As IMsgSetRequest
    Public ReadOnly Property MsgSetRequest As IMsgSetRequest
        Get
            Return app_MsgSetReq
        End Get
    End Property

    ' pending approvals property
    Dim _pendingApprovalC As Integer = 0
    Public Property PendingApprovals As Integer
        Get
            Return _pendingApprovalC
        End Get
        Set(value As Integer)
            _pendingApprovalC = value

            If (value > 0) Then
                btn_PendApprovs.Visible = True
                btn_PendApprovs.Text = "Pending Approvals: " & value
            Else
                btn_PendApprovs.Visible = False
            End If
        End Set
    End Property

    ' batch running event catch
    Private Sub BatchRunning(ByVal running As Boolean) Handles _batchForm.BatchRunning
        _BatchRunning = running
        ' start timer to refresh balance every 10 seconds
        Batch_RefreshBalance.Enabled = running
        ' make progress bar visible
        pb_Batching.Visible = running
        lbl_BatchProg.Visible = running
    End Sub
    Private Sub BatchProgPercUpdate(ByVal batchProg As Integer) Handles _batchForm.e_BatchProgPerc
        lbl_BatchProg.Text = batchProg & "%"
    End Sub

    Private Sub btn_Payments_Click(sender As System.Object, e As System.EventArgs) Handles btn_Payments.Click
        If (_payForm Is Nothing) Then
            _payForm = New Payments(Me)
            _payForm.MdiParent = Me
        End If

        _payForm.Show()
        _payForm.BringToFront()
    End Sub

    Private Sub btn_NewCustTab_Click(sender As System.Object, e As System.EventArgs) Handles btn_CustTab.Click
        If (_customer Is Nothing) Then
            _customer = New Customer(Me)
            _customer.MdiParent = Me
        End If

        _customer.Show()
        _customer.BringToFront()
    End Sub

    Private Sub btn_BatchWork_Click(sender As System.Object, e As System.EventArgs) Handles btn_BatchWork.Click
        If (_batchForm Is Nothing) Then
            _batchForm = New BatchingPrep
            _batchForm.MdiParent = Me
        End If

        _batchForm.Show()
        _batchForm.BringToFront()
    End Sub



    Private Sub TrashCash_Home_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (_BatchRunning) Then
            e.Cancel = True
            MsgBox("You cannot exit in the middle of a Batch. Please wait for the batch to finish.")
            _batchForm.BringToFront()
        Else
            Try
                app_SessMgr.EndSession()
                app_SessMgr.CloseConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Application.Exit()
            End Try
        End If

    End Sub

    Private Sub TrashCash_Home_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        GetQBFileLocation()

        Try
            app_SessMgr = New QBSessionManager
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        QBInitConnection(False)

        ' dim all classes
        CreateAllClasses()
        _splash.Close()

        ' maximize window
        Me.WindowState = FormWindowState.Maximized

        ' getting approvals pending on load
        RefreshApprovCount(True)

        '
    End Sub

    Private Sub ApprovalsWorked(ByVal countRemain As Integer) Handles _pendingApprovals.RemainingApprovals
        PendingApprovals = countRemain
    End Sub

    Friend Sub RefreshApprovCount(Optional ByRef InitLoad As Boolean = False)
        ' fetching pending approval count
        PendingApprovals = Me.RecurringService_PendingApprovalsTableAdapter.RecurringService_PendingApprovals_Count()

        ' checking if initial load
        If (InitLoad) Then
            btn_PendApprovs.PerformClick()
        End If

    End Sub
    Private Sub QBInitConnection(ByVal retry As Boolean)
        'If (retry) Then
        '    app_SessMgr.CloseConnection()
        '    'app_SessMgr = New QBSessionManager
        'End If

        Try
            app_SessMgr.CloseConnection()
            app_SessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
            app_SessMgr.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)

            ' new msg set
            app_MsgSetReq = app_SessMgr.CreateMsgSetRequest("US", 11, 0)
        Catch ex As Exception
            If (Not retry) Then
                Dim result As MsgBoxResult = MsgBox(ex.Message & vbCrLf & "Retry?", MsgBoxStyle.YesNo)
                If (result = MsgBoxResult.Yes) Then
                    QBInitConnection(True)
                Else
                    Application.Exit()
                End If
            Else
                Dim killprompt As MsgBoxResult = MsgBox("Retry unsuccessful, would you like to try stopping the Quickbooks process? This could cause data loss if Quickbooks is being used." & vbCrLf & _
                                                        "This process could take up to 30 seconds to complete.", MsgBoxStyle.YesNo)
                If (killprompt = MsgBoxResult.Yes) Then
                    KillQBProcess()
                Else
                    Application.Exit()
                End If
            End If
        End Try

        If (retry) Then
            MsgBox("Successfully connected to Quickbooks.")
        End If
    End Sub
    Private Sub KillQBProcess()
        ' QBW32.exe killing
        For Each p As Process In Process.GetProcessesByName("QBW32.exe")
            p.CloseMainWindow()
            p.WaitForExit(20000)
            If (p.HasExited = False) Then
                p.Kill()
            End If
        Next

        ' QBW32Pro.exe killing
        For Each p As Process In Process.GetProcessesByName("QBW32Pro.exe")
            p.CloseMainWindow()
            p.WaitForExit(20000)
            If (p.HasExited = False) Then
                p.Kill()
            End If
        Next

        Try
            app_SessMgr.CloseConnection()
            app_SessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
            app_SessMgr.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)

            ' new msg set
            app_MsgSetReq = app_SessMgr.CreateMsgSetRequest("US", 11, 0)
        Catch ex As Exception
            MsgBox("Retry failed and Kill Process failed. Please try restarting TrashCash.")
            Application.Exit()
        End Try

    End Sub

    Private Sub CreateAllClasses()
        c_QB_Queries = New QB_Queries(SessionManager, MsgSetRequest)
        c_QB_Procedures = New QB_Procedures(SessionManager, MsgSetRequest, Me)
        c_Reporting = New Reporting(SessionManager, MsgSetRequest)
    End Sub

    Private Sub GetQBFileLocation()
        Try
            'con
            Dim con As New SqlConnection
            con.ConnectionString = My.Settings.QBDBConnectionString

            ' command
            Dim cmd As New SqlCommand("APP_GetQBFileLoc", con)
            cmd.CommandType = CommandType.StoredProcedure

            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim fileLoc As String = Nothing

            While reader.Read
                fileLoc = reader.Item(0)
            End While

            If (fileLoc IsNot Nothing) Then
                My.Settings.QB_FILE_LOCATION = fileLoc
            End If
            'con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'ParentForm.Close()
        End Try
    End Sub

    Private Sub btn_Rpt_AllCustomerBalances_Click(sender As System.Object, e As System.EventArgs) Handles btn_Rpt_AllCustomerBalances.Click
        Dim rf As New f_AllCustBalances(Me)
        rf.Show()
    End Sub

    Private Sub btn_Rpt_PayReceived_Click(sender As System.Object, e As System.EventArgs) Handles btn_Rpt_PayReceived.Click
        Dim rf As New f_PaymentsReceived
        rf.Show()
    End Sub


    Private Sub btn_Rpt_DaysEvents_Click(sender As System.Object, e As System.EventArgs) Handles btn_Rpt_DaysEvents.Click
        Dim rf As New f_DaysEvents
        rf.Show()
    End Sub

    Private _splash As SplashScreen
    Public Sub New(ByRef Splash As SplashScreen, ByVal UserID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _splash = Splash

        ' setting userid row
        Using ta As New ds_ProgramTableAdapters.USERSTableAdapter
            CurrentUserRow = ta.GetDataByID(UserID).Rows(0)
        End Using

        qta = New ds_ProgramTableAdapters.QueriesTableAdapter
    End Sub

    Private Sub UnderOverEvenCustomerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnderOverEvenCustomerToolStripMenuItem.Click
        Dim rf As New f_UnderOverEven(Me)
        rf.Show()
    End Sub

    Friend Sub RefreshCustomerForm()
        If (_customer IsNot Nothing) Then
            _customer.CurrentCustomer = _customer.CurrentCustomer
        End If
    End Sub

    Private Sub btn_PendApprovs_Click(sender As System.Object, e As System.EventArgs) Handles btn_PendApprovs.Click
        If (_pendingApprovals Is Nothing) Then
            _pendingApprovals = New PendingApprovals(Me)
            _pendingApprovals.MdiParent = Me
        End If

        _pendingApprovals.Show()
        _pendingApprovals.BringToFront()
    End Sub

    Private Sub Batch_RefreshBalance_Tick(sender As System.Object, e As System.EventArgs) Handles Batch_RefreshBalance.Tick
        ' if customer form already open, refresh the balance
        If (_customer IsNot Nothing) Then
            _customer.RefreshCustBalance()
        End If
    End Sub

    Private Sub menu_Admin_Click(sender As System.Object, e As System.EventArgs) Handles menu_Admin.Click
        If (f_TrashCash_Admin IsNot Nothing) Then
            f_TrashCash_Admin.BringToFront()
            f_TrashCash_Admin.Show()
        Else
            Dim open As Boolean = False
            Dim userRow As ds_Program.USERSRow = _currentUserRow

            If (_bypassLogin) Then
                open = True
            Else
                f_UserSelection = New UserSelection("Administration Login")
                f_UserSelection.ShowDialog()
                If (f_UserSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                    userRow = f_UserSelection.AuthUserRow
                End If
                f_UserSelection = Nothing
            End If

            If (open) Then
                ' making sure userrow is less than 3
                If (userRow.USER_AUTHLVL < 3) Then
                    f_TrashCash_Admin = New TrashCash_Admin(Me, userRow)
                    f_TrashCash_Admin.Show()
                Else
                    MessageBox.Show("No administrator privledges.", "No privledges", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btn_SwitchUser_Click(sender As System.Object, e As System.EventArgs) Handles btn_SwitchUser.Click
        If (Not _BatchRunning) Then
            Dim f_userSwitch As New UserSelection("User Switch")
            f_userSwitch.ShowDialog()
            If (f_userSwitch.AuthUserRow IsNot Nothing) Then
                ' get new row 
                CurrentUserRow = f_userSwitch.AuthUserRow
            End If

            f_userSwitch = Nothing
        Else
            MessageBox.Show("Cannot switch user during a batch.", "Batch Running", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_ChangePass_Click(sender As System.Object, e As System.EventArgs) Handles btn_ChangePass.Click
        ' check password
        f_UserSelection = New UserSelection("Select User for Password Change")
        f_UserSelection.ShowDialog()

        If (f_UserSelection.AuthUserRow IsNot Nothing) Then
            ' grab id and current pw of confirmed user
            Dim changeUserID As Integer = f_UserSelection.AuthUserRow.USER_ID
            Dim currentPW As String = f_UserSelection.AuthPWText

            'get new password
            f_UserSelection = New UserSelection("New Password", ChangePW:=True)
            f_UserSelection.Cmb_Users.SelectedValue = changeUserID
            f_UserSelection.Cmb_Users.Enabled = False
            f_UserSelection.ShowDialog()

            ' change password
            If (f_UserSelection.AuthPWText IsNot Nothing) Then
                Using ta As New ds_ProgramTableAdapters.USERSTableAdapter
                    ta.ChangePassword(changeUserID, f_UserSelection.AuthPWText, currentPW)
                End Using
            End If

        End If
    End Sub
End Class
