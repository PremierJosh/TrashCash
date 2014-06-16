Namespace Customer
    Public Class CustomerForm
        ' new cust var so can switch form when new cust added
        Private WithEvents _newCust As NewCustomer

        Private _currentCustomer As Integer

        Public Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                _currentCustomer = value

                UC_CustomerInfoBoxes.CurrentCustomer = value
                UC_CustomerNotes.CurrentCustomer = value
                UC_RecurringService.CurrentCustomer = value
                UC_Quickbooks.CurrentCustomer = value
                UC_Quickbooks.CustomerListID = UC_CustomerInfoBoxes.CustomerListID

                ' update window title
                Text = CustomerToolstrip1.ToString
                ' send name to uc_recsrvc
                UC_RecurringService.CustomerName = CustomerToolstrip1.ToString
            End Set
        End Property

        ' refresh balance event handleing
        Friend Sub RefreshCustBalance(Optional ByVal customerNumber As Integer = 0) _
            Handles UC_RecurringService.RefreshBalance
            CustomerToolstrip1.GetCustomerBalance()
            ' if rec srvc is raising this event, balance was adjusted from credit
            UC_Quickbooks.FetchInvoices(0)
        End Sub

        Private Sub Customer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub Customer_Load(sender As Object, e As EventArgs) Handles Me.Load
            If (CustomerToolstrip1.CurrentCustomer <> Nothing) Then
                CurrentCustomer = CustomerToolstrip1.CurrentCustomer
            End If
            ' set focus to quick search
            CustomerToolstrip1.QuickSearch.TextBox.Select()
            CustomerToolstrip1.GetCustomerBalance()
        End Sub

        Private Sub CustomerChanged(ByVal customerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
            CurrentCustomer = customerNumber
        End Sub

        ' event handle for begining to update customer info
        Private Sub LockAll(ByVal bool As Boolean) Handles UC_CustomerInfoBoxes.Updating
            If (bool = True) Then
                CustomerToolstrip1.Enabled = False
                ts_Top.Enabled = False

                ' lock tc
                tc_Master.Enabled = False

            Else
                CustomerToolstrip1.Enabled = True
                ts_Top.Enabled = True

                ' unlock tc
                tc_Master.Enabled = True
            End If
        End Sub

        ' event handle for completed updating
        Private Sub CustomerInfoUpdated(ByVal bool As Boolean) Handles UC_CustomerInfoBoxes.Updating
            If (bool = False) Then
                CustomerToolstrip1.RefreshCustomerList()
            End If
        End Sub

        Private Sub btn_NewCust_Click(sender As Object, e As EventArgs) Handles btn_NewCust.Click
            _newCust = New NewCustomer()
            _newCust.ShowDialog()
        End Sub

        ' new cust event handle to switch to it
        Private Sub NewCustomer(ByVal newCustNum As Integer) Handles _newCust.NewCustomerAdded
            CustomerToolstrip1.RefreshCustomerList()
            CustomerToolstrip1.SelectCustomer(newCustNum, True)
            ' clearing newcust var
            _newCust = Nothing
        End Sub

        Public Sub New(ByRef homeForm As TrashCashHome)
            ' This call is required by the designer.
            InitializeComponent()


            ' Add any initialization after the InitializeComponent() call.
            UC_RecurringService.HomeForm = homeForm
            CustomerToolstrip1.GetCustomerBalance()
        End Sub


        Private Sub btn_Payments_Click(sender As Object, e As EventArgs) Handles btn_Payments.Click
            Dim payForm As New Payments.PaymentsForm(CBool(AppQTA.APP_GetDebugMode), customerNumber:=CurrentCustomer)
            payForm.ShowDialog()
            If (payForm.PaymentAdded) Then
                ' update to grab items in queue
                CustomerToolstrip1.GetCustomerBalance()
            End If
        End Sub

        Private Sub btn_Credit_Click(sender As Object, e As EventArgs) Handles btn_Credit.Click
            Dim creditForm As New CustomerCredit(CurrentCustomer)
            creditForm.ShowDialog()
            If (creditForm.BalanceChanged) Then
                ' update customer balance
                CustomerToolstrip1.GetCustomerBalance()
                ' update invoices
                UC_Quickbooks.CustomerListID = UC_Quickbooks.CustomerListID
            End If
        End Sub

        Private Sub btn_Inv_Click(sender As Object, e As EventArgs) Handles btn_Inv.Click
            Dim invForm As New Invoicing.CustomInvoicingForm(CurrentCustomer)
            invForm.ShowDialog()
            If (invForm.BalanceChanged) Then
                ' update customer balance
                CustomerToolstrip1.GetCustomerBalance()
                ' update invoices
                UC_Quickbooks.CustomerListID = UC_Quickbooks.CustomerListID
            End If
        End Sub
    End Class
End Namespace