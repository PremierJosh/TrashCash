Imports System.Windows.Forms
Imports TrashCash.QBStuff
Imports QBFC12Lib

Public Class TrashCashHome
    ' var for current user id row
    Private _currentUserRow As ds_Application.USERSRow
    Public Property CurrentUserRow As ds_Application.USERSRow
        Get
            Return _currentUserRow
        End Get
        Set(value As ds_Application.USERSRow)
            _currentUserRow = value

            CurrentUser = value

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
                Case 1
                    _bypassLogin = True
                Case Is > 3
                    MessageBox.Show("AUTH LEVEL UNKNOWKN")
            End Select
        End Set
    End Property


    'var for batching
    Private _batchRunning As Boolean

    ' var for class files
    Protected CReporting As Reports.Reporting
    Public ReadOnly Property Reporting As Reports.Reporting
        Get
            Return CReporting
        End Get
    End Property
    ' var for all child forms
    Friend WithEvents PayForm As Payments.PaymentsForm
    Friend WithEvents BatchForm As Batching.BatchingPrep
    Friend WithEvents Customer As Customer.CustomerForm
    Friend WithEvents PendingApprovals As RecurringService.PendingApprovals
    Friend WithEvents InvForm As Invoicing.CustomInvoicingForm

    ' event handles
    Private Sub PaymentModCatch(ByVal customerNumber As Integer) Handles PayForm.CustomerPaymentMod, Customer.CustomerPaymentMod, BatchForm.CustomerPaymentMod
        ' came from custom invoicing form, need to update customer form balance if matches
        If (Customer IsNot Nothing) Then
            If (Customer.CurrentCustomer = customerNumber) Then
                Customer.CustomerToolstrip1.GetQueueAmount()
                ' checking for 1 of 3 showdialog forms
                If (Customer.CreditForm IsNot Nothing) Then
                    Customer.CreditForm.CustomerToolstrip1.GetQueueAmount()
                End If
                If (Customer.InvForm IsNot Nothing) Then
                    Customer.InvForm.CustomerToolstrip1.GetQueueAmount()
                End If
                If (Customer.PayForm IsNot Nothing) Then
                    Customer.PayForm.CustomerToolstrip1.GetQueueAmount()
                End If
            End If
        End If
        ' need to update in queue on other forms if exist and match new customer
        If (PayForm IsNot Nothing) Then
            If (PayForm.CurrentCustomer = customerNumber) Then
                PayForm.CustomerToolstrip1.GetQueueAmount()
            End If
        End If
        If (InvForm IsNot Nothing) Then
            If (InvForm.CurrentCustomer = customerNumber) Then
                InvForm.CustomerToolstrip1.GetQueueAmount()
            End If
        End If
        ' checking for batch prep form
        If (BatchForm IsNot Nothing) Then
            BatchForm.BATCH_WorkingPaymentsTableAdapter.Fill(BatchForm.DS_Batching.BATCH_WorkingPayments)
        End If

        ' checking for admin payments
        If (TrashCashAdmin IsNot Nothing) Then
            If (TrashCashAdmin.AdminPay IsNot Nothing) Then
                If (TrashCashAdmin.AdminPay.CurrentCustomer = customerNumber) Then
                    TrashCashAdmin.AdminPay.CustomerToolstrip1.GetQueueAmount()
                End If
            End If
        End If
    End Sub
    Private Sub BalanceChangeCatch(ByVal customerNumber As Integer) Handles InvForm.CustomerInvoiceAdded, Customer.CustomerBalanceChanged
        RefreshCustomerBalance(customerNumber)
    End Sub
    ' admin payment event catches
    Friend Sub CustomerCheckBounced(ByVal customerNumber As Integer)
        RefreshCustomerBalance(customerNumber)
        ' fetch customer notes
        If (Customer.UC_CustomerNotes.CurrentCustomer = customerNumber) Then
            Customer.UC_CustomerNotes.CurrentCustomer = customerNumber
        End If
    End Sub
    Friend Sub CustomerPaymentMoved(ByVal origCustomerNumber As Integer, ByVal newCustomerNumber As Integer)
        RefreshCustomerBalance(origCustomerNumber)
        RefreshCustomerBalance(newCustomerNumber)
    End Sub

    ' sub to refresh customer balance on all forms
    Private Sub RefreshCustomerBalance(ByVal customerNumber As Integer)
        If (Customer IsNot Nothing) Then
            If (Customer.CurrentCustomer = customerNumber) Then
                Customer.CustomerToolstrip1.GetCustomerBalance()
                ' checking for 1 of 3 showdialog forms
                If (Customer.CreditForm IsNot Nothing) Then
                    Customer.CreditForm.CustomerToolstrip1.GetCustomerBalance()
                End If
                If (Customer.InvForm IsNot Nothing) Then
                    Customer.InvForm.CustomerToolstrip1.GetCustomerBalance()
                End If
                If (Customer.PayForm IsNot Nothing) Then
                    Customer.PayForm.CustomerToolstrip1.GetCustomerBalance()
                End If
            End If
        End If
        ' need to update balances on other forms if exist and match new customer
        If (PayForm IsNot Nothing) Then
            If (PayForm.CurrentCustomer = customerNumber) Then
                PayForm.CustomerToolstrip1.GetCustomerBalance()
            End If
        End If
        If (InvForm IsNot Nothing) Then
            If (InvForm.CurrentCustomer = customerNumber) Then
                InvForm.CustomerToolstrip1.GetCustomerBalance()
            End If
        End If

        ' checking for admin payments
        If (TrashCashAdmin IsNot Nothing) Then
            If (TrashCashAdmin.AdminPay IsNot Nothing) Then
                If (TrashCashAdmin.AdminPay.CurrentCustomer = customerNumber) Then
                    TrashCashAdmin.AdminPay.CustomerToolstrip1.GetCustomerBalance()
                End If
            End If
        End If
    End Sub
    ' vars for admin forms'
    Friend WithEvents UserSelection As Admin.UserSelection
    Friend WithEvents TrashCashAdmin As Admin.TrashCashAdmin

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
        pb_Batching.Value = 0
        pb_Batching.Visible = running
        lbl_BatchProg.Visible = running
    End Sub
    Private Sub BatchProgPercUpdate(ByVal batchProg As Integer) Handles BatchForm.BatchProgPerc
        lbl_BatchProg.Text = batchProg & "%"
        pb_Batching.Value = batchProg
    End Sub

    Private Sub btn_Payments_Click(sender As Object, e As EventArgs) Handles btn_Payments.Click
        If (PayForm Is Nothing) Then
            PayForm = New Payments.PaymentsForm(CBool(AppQTA.APP_GetDebugMode))
            PayForm.MdiParent = Me
        End If
        PayForm.Show()
        PayForm.BringToFront()
        PayForm.CustomerToolstrip1.QuickSearch.TextBox.SelectAll()
    End Sub

    Private Sub btn_NewCustTab_Click(sender As Object, e As EventArgs) Handles btn_CustTab.Click
        If (Customer Is Nothing) Then
            Customer = New Customer.CustomerForm
            Customer.MdiParent = Me
        End If
        Customer.Show()
        Customer.BringToFront()
        Customer.CustomerToolstrip1.QuickSearch.TextBox.Select()
    End Sub

    Private Sub btn_BatchWork_Click(sender As Object, e As EventArgs) Handles btn_BatchWork.Click
        If (BatchForm Is Nothing) Then
            BatchForm = New Batching.BatchingPrep
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

        ' create new conMgrObj
        GlobalConMgr = New QBConMgr
       

        Try
            Dim connected As Boolean = GlobalConMgr.InitCon()
            If (Not connected) Then
                Application.Restart()
                Exit Sub
            End If
            'temp: setting vars here for other forms
            AppSessMgr = GlobalConMgr.SessionManager
            AppMsgSetReq = GlobalConMgr.MessageSetRequest
            ' dim all classes
            CreateAllClasses()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' get current company closing date and max adv and arr post date limites
        CompanyClosingDate = QBRequests.CompanyClosingDateQuery
        Dim row As ds_Application.App_SettingsRow = AppTA.GetData().Rows(0)
        InvMaxAdvancedDays = row.InvPost_MaxAdvDays
        InvMaxArrearageDays = row.InvPost_MaxArrDays
        ' create global reference to this form
        HomeForm = Me

        _splash.Close()

        ' maximize window
        WindowState = FormWindowState.Maximized

        ' getting approvals pending on load
        RefreshApprovCount(True)

        ' checking if a batch didn't complete last time the program was run
       Dim finBatch As Batching.BatchInterruption = Nothing
        If (row.Batching_Invoices) Then
            finBatch = New Batching.BatchInterruption
            finBatch.InvoiceBatch = True
        ElseIf (row.Batching_Payments) Then
            finBatch = New Batching.BatchInterruption
            finBatch.PaymentBatch = True
        End If

        If (finBatch IsNot Nothing) Then
            finBatch.ShowDialog()
            ' check if batch finished
            If (Not finBatch.BatchCompleted) Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub ApprovalsWorked(ByVal countRemain As Integer) Handles PendingApprovals.RemainingApprovals
        PendingApprovalsCount = countRemain
    End Sub

    Friend Sub RefreshApprovCount(Optional ByRef initLoad As Boolean = False) Handles Customer.ApprovalsChanged
        ' fetching pending approval count
        PendingApprovalsCount = RecurringService_PendingApprovalsTableAdapter.RecurringService_PendingApprovals_Count()

        ' checking if initial load
        If (initLoad) Then
            btn_PendApprovs.PerformClick()
        End If

        ' tell approval form if its open to refresh
        If (PendingApprovals IsNot Nothing) Then
            If (PendingApprovals.IsDisposed = False) Then
                PendingApprovals.RefreshApprovalList()
            End If
        End If
    End Sub

    Private Sub CreateAllClasses()
        CReporting = New Reports.Reporting(SessionManager, MsgSetRequest)
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
            MsgBox("Error getting QBFileLoc: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_Rpt_AllCustomerBalances_Click(sender As Object, e As EventArgs) Handles btn_Rpt_AllCustomerBalances.Click
        Dim rf As New Reports.Report_AllCustBalances()
        rf.Show()
    End Sub

    Private Sub btn_Rpt_PayReceived_Click(sender As Object, e As EventArgs) Handles btn_Rpt_PayReceived.Click
        Dim rf As New Reports.Report_PaymentsReceived
        rf.Show()
    End Sub


    Private Sub btn_Rpt_DaysEvents_Click(sender As Object, e As EventArgs) Handles btn_Rpt_DaysEvents.Click
        Dim rf As New Reports.Report_DaysEvents
        rf.Show()
    End Sub

    Private ReadOnly _splash As SplashScreen
    Public Sub New(ByRef splash As SplashScreen, ByVal userID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _splash = splash

        ' setting userid row
        CurrentUserRow = UserTA.GetDataByID(userID).Rows(0)
    End Sub

    Private Sub UnderOverEvenCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnderOverEvenCustomerToolStripMenuItem.Click
        Dim rf As New Reports.Report_UnderOverEven(Me)
        rf.Show()
    End Sub

    Friend Sub RefreshCustomerForm()
        If (Customer IsNot Nothing) Then
            Customer.CurrentCustomer = Customer.CurrentCustomer
        End If
    End Sub

    Private Sub btn_PendApprovs_Click(sender As Object, e As EventArgs) Handles btn_PendApprovs.Click
        If (PendingApprovals Is Nothing) Then
            PendingApprovals = New RecurringService.PendingApprovals(Me)
            PendingApprovals.MdiParent = Me
        End If
        PendingApprovals.Show()
        PendingApprovals.BringToFront()
    End Sub

    Private Sub Batch_RefreshBalance_Tick(sender As Object, e As EventArgs) Handles Batch_RefreshBalance.Tick
        ' refresh balances on timer tick (every 10 seconds)
        If (GlobalConMgr.MessageSetRequest.RequestList.Count = 0) Then
            If (Customer IsNot Nothing) Then
                Customer.CustomerToolstrip1.GetCustomerBalance()
            End If
            If (PayForm IsNot Nothing) Then
                PayForm.CustomerToolstrip1.GetCustomerBalance()
            End If
            If (InvForm IsNot Nothing) Then
                InvForm.CustomerToolstrip1.GetCustomerBalance()
            End If
            If (TrashCashAdmin IsNot Nothing) Then
                If (TrashCashAdmin.AdminPay IsNot Nothing) Then
                    TrashCashAdmin.AdminPay.CustomerToolstrip1.GetCustomerBalance()
                End If
            End If
        End If
    End Sub

    Private Sub menu_Admin_Click(sender As Object, e As EventArgs) Handles menu_Admin.Click
        ' trying to open
        Dim open As Boolean = False
        Dim userRow As ds_Application.USERSRow = _currentUserRow
        If (_bypassLogin) Then
            open = True
        Else
            UserSelection = New Admin.UserSelection("Administration Login")
            UserSelection.ShowDialog()
            If (UserSelection.AuthUserRow IsNot Nothing) Then
                open = True
                userRow = UserSelection.AuthUserRow
            End If
            UserSelection = Nothing
        End If

        If (open) Then
            ' making sure userrow auth level is less than 3
            If (userRow.USER_AUTHLVL < 3) Then
                TrashCashAdmin = New Admin.TrashCashAdmin(userRow)
                TrashCashAdmin.Show()
            Else
                MessageBox.Show("No administrator privledges.", "No privledges", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub btn_SwitchUser_Click(sender As Object, e As EventArgs) Handles btn_SwitchUser.Click
        If (Not _batchRunning) Then
            Dim userSwitch As New Admin.UserSelection("User Switch")
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
        UserSelection = New Admin.UserSelection("Select User for Password Change")
        UserSelection.ShowDialog()

        If (UserSelection.AuthUserRow IsNot Nothing) Then
            ' grab id and current pw of confirmed user
            Dim changeUserID As Integer = UserSelection.AuthUserRow.USER_ID
            Dim currentPW As String = UserSelection.AuthPWText

            'get new password
            UserSelection = New Admin.UserSelection("New Password", ChangePW:=True)
            UserSelection.cmb_Users.SelectedValue = changeUserID
            UserSelection.cmb_Users.Enabled = False
            UserSelection.ShowDialog()

            ' change password
            If (UserSelection.AuthPWText IsNot Nothing) Then
                UserTA.ChangePassword(changeUserID, UserSelection.AuthPWText, currentPW)
            End If

        End If
    End Sub

    Private Sub btn_Invoicing_Click(sender As Object, e As EventArgs) Handles btn_Invoicing.Click
        If (InvForm Is Nothing) Then
            InvForm = New Invoicing.CustomInvoicingForm
            InvForm.MdiParent = Me
        End If
        InvForm.BringToFront()
        InvForm.Show()
        InvForm.CustomerToolstrip1.QuickSearch.TextBox.SelectAll()
    End Sub
End Class
