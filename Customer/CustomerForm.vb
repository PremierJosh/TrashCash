Namespace Customer
    Public Class CustomerForm
        ' events for customer balance or in queue amount changing
        Friend Event CustomerBalanceChanged(ByVal customerNumber As Integer, ByRef formType As Type)
        Friend Event CustomerPaymentAdded(ByVal customerNumber As Integer, ByRef formType As Type)
        Friend Event ApprovalsChanged()

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
        Friend Sub RefreshCustBalance(ByVal customerNumber As Integer) Handles UC_RecurringService.BalanceChanged
           ' rec srvc is raising this event, balance was adjusted from credit
            UC_Quickbooks.FetchInvoices(0)
            ' let home form know customer balance changed from a credit
            RaiseEvent CustomerBalanceChanged(customerNumber, GetType(CustomerForm))
            CustomerToolstrip1.GetCustomerBalance()
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
            Dim newCust As New NewCustomer()
            newCust.ShowDialog()
            If (newCust.NewCustomerAdded) Then
                CustomerToolstrip1.RefreshCustomerList()
                CustomerToolstrip1.SelectCustomer(newCust.CustRow.CustomerNumber, True)
            End If
        End Sub

        Private Sub btn_Payments_Click(sender As Object, e As EventArgs) Handles btn_Payments.Click
            PayForm = New Payments.PaymentsForm(CBool(AppQTA.APP_GetDebugMode), customerNumber:=CurrentCustomer)
            payForm.ShowDialog()
        End Sub
        Private Sub PaymentAddedCatch(ByVal customerNumber As Integer, ByRef formType As Type) Handles PayForm.CustomerPaymentAdded
            RaiseEvent CustomerPaymentAdded(customerNumber, GetType(CustomerForm))
            CustomerToolstrip1.GetQueueAmount()
        End Sub

        Private Sub btn_Credit_Click(sender As Object, e As EventArgs) Handles btn_Credit.Click
            CreditForm = New CustomerCredit(CurrentCustomer)
            CreditForm.ShowDialog()
        End Sub
        Private Sub CreditAddCatch(ByVal customerNumber As Integer) Handles CreditForm.CreditAdded
            RaiseEvent CustomerBalanceChanged(CurrentCustomer, GetType(CustomerForm))
            CustomerToolstrip1.GetCustomerBalance()
            ' get invoices incase they were paid with credit
            UC_Quickbooks.FetchInvoices(0)
        End Sub
        
        Private Sub btn_Inv_Click(sender As Object, e As EventArgs) Handles btn_Inv.Click
            InvForm = New Invoicing.CustomInvoicingForm(CurrentCustomer)
            InvForm.ShowDialog()
        End Sub
        Private Sub InvoiceAddCatch(ByVal customerNumber As Integer, ByRef formType As Type) Handles InvForm.CustomerInvoiceAdded
            RaiseEvent CustomerBalanceChanged(customerNumber, GetType(CustomerForm))
            CustomerToolstrip1.GetCustomerBalance()
            ' get new invoices
            UC_Quickbooks.FetchInvoices(0)
        End Sub

        ' recurring service approval change
        Private Sub ApprovalsChanging() Handles UC_RecurringService.ApprovalCountChange
            RaiseEvent ApprovalsChanged()
        End Sub


        ' forms
        Friend WithEvents CreditForm As CustomerCredit
        Friend WithEvents InvForm As Invoicing.CustomInvoicingForm
        Friend WithEvents PayForm As Payments.PaymentsForm
    End Class
End Namespace