Imports System.Windows.Forms
Imports System.ServiceProcess
Imports TrashCash.ds_ProgramTableAdapters
Imports QBFC12Lib

Public Class TrashCashHome
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
            Text = "TrashCash       | Current User: " & value.USER_NAME
            ' update auth level
            AuthLevel = value.USER_AUTHLVL

            ' close all child windows
            For Each f As Form In MdiChildren
                f.Close()
            Next

            ' close admin form if open
            If (TrashCashAdmin IsNot Nothing) Then
                TrashCashAdmin.Close()
                TrashCashAdmin = Nothing
            End If

            ' CHANGE CONNECTION STRING
            Const conPW As String = "Yealink01"
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
            Select Case value
                Case value = 1
                    _bypassLogin = True
                Case value > 3
                    MessageBox.Show("AUTH LEVEL UNKNOWKN")
            End Select
        End Set
    End Property


    'var for batching
    Private _batchRunning As Boolean

    ' var for class files
    Protected QBQueries As QB_Queries
    Public ReadOnly Property Queries As QB_Queries
        Get
            Return QBQueries
        End Get
    End Property
    Protected QBProcedures As QB_Procedures
    Public ReadOnly Property Procedures As QB_Procedures
        Get
            Return QBProcedures
        End Get
    End Property
    Protected CReporting As Reporting
    Public ReadOnly Property Reporting As Reporting
        Get
            Return CReporting
        End Get
    End Property

    ' var for all child forms
    Friend WithEvents PayForm As Payments
    Friend WithEvents BatchForm As BatchingPrep
    Friend WithEvents Customer As Customer
    Friend WithEvents PendingApprovals As PendingApprovals

    ' vars for admin forms'
    Friend WithEvents UserSelection As UserSelection
    Friend WithEvents TrashCashAdmin As TrashCash_Admin

    ' qb session and msg set req
    Friend AppSessMgr As QBSessionManager
    Public ReadOnly Property SessionManager As QBSessionManager
        Get
            Return AppSessMgr
        End Get
    End Property
    Protected Friend AppMsgSetReq As IMsgSetRequest
    Public ReadOnly Property MsgSetRequest As IMsgSetRequest
        Get
            Return AppMsgSetReq
        End Get
    End Property

    ' pending approvals property
    Dim _pendingApprovalCount As Integer = 0
    Public Property PendingApprovalsCount As Integer
        Get
            Return _pendingApprovalCount
        End Get
        Set(value As Integer)
            _pendingApprovalCount = value

            If (value > 0) Then
                btn_PendApprovs.Visible = True
                btn_PendApprovs.Text = "Pending Approvals: " & value
            Else
                btn_PendApprovs.Visible = False
            End If
        End Set
    End Property

    ' batch running event catch
    Private Sub BatchRunning(ByVal running As Boolean) Handles BatchForm.BatchRunning
        _batchRunning = running
        ' start timer to refresh balance every 10 seconds
        Batch_RefreshBalance.Enabled = running
        ' make progress bar visible
        pb_Batching.Visible = running
        lbl_BatchProg.Visible = running
    End Sub
    Private Sub BatchProgPercUpdate(ByVal batchProg As Integer) Handles BatchForm.e_BatchProgPerc
        lbl_BatchProg.Text = batchProg & "%"
    End Sub

    Private Sub btn_Payments_Click(sender As Object, e As EventArgs) Handles btn_Payments.Click
        Dim needNew As Boolean = False

        If (PayForm IsNot Nothing) Then
            If (PayForm.IsDisposed = True) Then
                needNew = True
            End If
        Else
            needNew = True
        End If

        If (needNew) Then
            PayForm = New Payments(Me)
            PayForm.MdiParent = Me
        End If

        PayForm.Show()
        PayForm.BringToFront()
    End Sub

    Private Sub btn_NewCustTab_Click(sender As Object, e As EventArgs) Handles btn_CustTab.Click
        Dim needNew As Boolean = False

        If (Customer IsNot Nothing) Then
            If (Customer.IsDisposed = True) Then
                needNew = True
            End If
        Else
            needNew = True
        End If

        If (needNew) Then
            Customer = New Customer(Me)
            Customer.MdiParent = Me
        End If
        Customer.Show()
        Customer.BringToFront()
    End Sub

    Private Sub btn_BatchWork_Click(sender As Object, e As EventArgs) Handles btn_BatchWork.Click
        If (BatchForm Is Nothing) Then
            BatchForm = New BatchingPrep
            BatchForm.MdiParent = Me
        End If

        BatchForm.Show()
        BatchForm.BringToFront()
    End Sub



    Private Sub TrashCash_Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If (_batchRunning) Then
            e.Cancel = True
            MsgBox("You cannot exit in the middle of a Batch. Please wait for the batch to finish.")
            BatchForm.BringToFront()
        Else
            Try
                AppSessMgr.EndSession()
                AppSessMgr.CloseConnection()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Application.Exit()
            End Try
        End If

    End Sub

    Private Sub TrashCash_Home_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetQBFileLocation()

        Try
            AppSessMgr = New QBSessionManager
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        QBInitConnection()

        ' dim all classes
        CreateAllClasses()
        _splash.Close()

        ' maximize window
        WindowState = FormWindowState.Maximized

        ' getting approvals pending on load
        RefreshApprovCount(True)

    End Sub

    Private Sub ApprovalsWorked(ByVal countRemain As Integer) Handles PendingApprovals.RemainingApprovals
        PendingApprovalsCount = countRemain
    End Sub

    Friend Sub RefreshApprovCount(Optional ByRef initLoad As Boolean = False)
        ' fetching pending approval count
        PendingApprovals = RecurringService_PendingApprovalsTableAdapter.RecurringService_PendingApprovals_Count()

        ' checking if initial load
        If (initLoad) Then
            btn_PendApprovs.PerformClick()
        End If

        ' tell approval form if its open to refresh
        If (_PendingApprovals IsNot Nothing) Then
            If (_PendingApprovals.IsDisposed = False) Then
                _PendingApprovals.RefreshApprovalList()
            End If
        End If
    End Sub
    Private Sub QBInitConnection(Optional ByVal retry As Boolean = False)
        Try
            AppSessMgr.CloseConnection()
            AppSessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
            AppSessMgr.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)

            ' new msg set
            AppMsgSetReq = AppSessMgr.CreateMsgSetRequest("US", 11, 0)
        Catch ex As Exception
            ' going to check if services are running and if not, start them
            If (Not retry) Then
                StartQBFCServices()
            Else
                MsgBox(ex.Message)
                Application.Exit()
            End If
        End Try
    End Sub

    Private Sub StartQBFCServices()
        Dim s As New List(Of String)
        s.Add("QBCFMonitorService")
        s.Add("QBIDPService")
        s.Add("QuickbooksDB23")

        For Each service As String In s
            Dim sc As New ServiceController(service)
            If (sc.Status = ServiceControllerStatus.Stopped) Then
                Try
                    sc.Start()
                Catch ex As Exception
                    MsgBox("Failed to start Service: " & service & ". EX: " & ex.Message)
                End Try
            End If
        Next

        QBInitConnection(True)
    End Sub
    '    Private Sub KillQBProcess()
    '        ' QBW32.exe killing
    '        For Each p As Process In Process.GetProcessesByName("QBW32.exe")
    '            p.CloseMainWindow()
    '            p.WaitForExit(20000)
    '            If (p.HasExited = False) Then
    '                p.Kill()
    '            End If
    '        Next
    '
    '        ' QBW32Pro.exe killing
    '        For Each p As Process In Process.GetProcessesByName("QBW32Pro.exe")
    '            p.CloseMainWindow()
    '            p.WaitForExit(20000)
    '            If (p.HasExited = False) Then
    '                p.Kill()
    '            End If
    '        Next
    '
    '        Try
    '            app_SessMgr.CloseConnection()
    '            app_SessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
    '            app_SessMgr.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)
    '
    '            ' new msg set
    '            app_MsgSetReq = app_SessMgr.CreateMsgSetRequest("US", 11, 0)
    '        Catch ex As Exception
    '            MsgBox("Retry failed and Kill Process failed. Please try restarting TrashCash.")
    '            Application.Exit()
    '        End Try
    '
    '    End Sub

    Private Sub CreateAllClasses()
        QBQueries = New QB_Queries(SessionManager, MsgSetRequest)
        QBProcedures = New QB_Procedures(SessionManager, MsgSetRequest, Me)
        CReporting = New Reporting(SessionManager, MsgSetRequest)
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

    Private Sub btn_Rpt_AllCustomerBalances_Click(sender As Object, e As EventArgs) Handles btn_Rpt_AllCustomerBalances.Click
        Dim rf As New f_AllCustBalances(Me)
        rf.Show()
    End Sub

    Private Sub btn_Rpt_PayReceived_Click(sender As Object, e As EventArgs) Handles btn_Rpt_PayReceived.Click
        Dim rf As New f_PaymentsReceived
        rf.Show()
    End Sub


    Private Sub btn_Rpt_DaysEvents_Click(sender As Object, e As EventArgs) Handles btn_Rpt_DaysEvents.Click
        Dim rf As New f_DaysEvents
        rf.Show()
    End Sub

    Private ReadOnly _splash As SplashScreen
    Public Sub New(ByRef splash As SplashScreen, ByVal userID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _splash = splash

        ' setting userid row
        Using ta As New USERSTableAdapter
            CurrentUserRow = ta.GetDataByID(userID).Rows(0)
        End Using
    End Sub

    Private Sub UnderOverEvenCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnderOverEvenCustomerToolStripMenuItem.Click
        Dim rf As New f_UnderOverEven(Me)
        rf.Show()
    End Sub

    Friend Sub RefreshCustomerForm()
        If (Customer IsNot Nothing) Then
            Customer.CurrentCustomer = Customer.CurrentCustomer
        End If
    End Sub

    Private Sub btn_PendApprovs_Click(sender As Object, e As EventArgs) Handles btn_PendApprovs.Click
        Dim needNew As Boolean = False

        If (_PendingApprovals IsNot Nothing) Then
            If (_PendingApprovals.IsDisposed = True) Then
                needNew = True
            End If
        Else
            needNew = True
        End If

        If (needNew) Then
            _PendingApprovals = New PendingApprovals(Me)
            _PendingApprovals.MdiParent = Me
        End If

        _PendingApprovals.Show()
        _PendingApprovals.BringToFront()

    End Sub

    Private Sub Batch_RefreshBalance_Tick(sender As Object, e As EventArgs) Handles Batch_RefreshBalance.Tick
        ' if customer form already open, refresh the balance
        If (Customer IsNot Nothing) Then
            Customer.RefreshCustBalance()
        End If
    End Sub

    Private Sub menu_Admin_Click(sender As Object, e As EventArgs) Handles menu_Admin.Click
        If (TrashCashAdmin IsNot Nothing) Then
            If (TrashCashAdmin.IsDisposed = False) Then
                TrashCashAdmin.BringToFront()
                TrashCashAdmin.Show()
            End If
        Else
            Dim open As Boolean = False
            Dim userRow As ds_Program.USERSRow = _currentUserRow

            If (_bypassLogin) Then
                open = True
            Else
                UserSelection = New UserSelection("Administration Login")
                UserSelection.ShowDialog()
                If (UserSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                    userRow = UserSelection.AuthUserRow
                End If
                UserSelection = Nothing
            End If

            If (open) Then
                ' making sure userrow is less than 3
                If (userRow.USER_AUTHLVL < 3) Then
                    TrashCashAdmin = New TrashCash_Admin(Me, userRow)
                    TrashCashAdmin.Show()
                Else
                    MessageBox.Show("No administrator privledges.", "No privledges", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btn_SwitchUser_Click(sender As Object, e As EventArgs) Handles btn_SwitchUser.Click
        If (Not _BatchRunning) Then
            Dim userSwitch As New UserSelection("User Switch")
            userSwitch.ShowDialog()
            If (userSwitch.AuthUserRow IsNot Nothing) Then
                ' get new row 
                CurrentUserRow = userSwitch.AuthUserRow
            End If

        Else
            MessageBox.Show("Cannot switch user during a batch.", "Batch Running", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_ChangePass_Click(sender As Object, e As EventArgs) Handles btn_ChangePass.Click
        ' check password
        UserSelection = New UserSelection("Select User for Password Change")
        UserSelection.ShowDialog()

        If (UserSelection.AuthUserRow IsNot Nothing) Then
            ' grab id and current pw of confirmed user
            Dim changeUserID As Integer = UserSelection.AuthUserRow.USER_ID
            Dim currentPW As String = UserSelection.AuthPWText

            'get new password
            UserSelection = New UserSelection("New Password", ChangePW:=True)
            UserSelection.Cmb_Users.SelectedValue = changeUserID
            UserSelection.Cmb_Users.Enabled = False
            UserSelection.ShowDialog()

            ' change password
            If (UserSelection.AuthPWText IsNot Nothing) Then
                Using ta As New USERSTableAdapter
                    ta.ChangePassword(changeUserID, UserSelection.AuthPWText, currentPW)
                End Using
            End If

        End If
    End Sub

    Private Sub btn_Invoicing_Click(sender As Object, e As EventArgs) Handles btn_Invoicing.Click

    End Sub
End Class
