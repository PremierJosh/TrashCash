
Namespace Customer
    Public Class CustomerForm
        ' new cust var so can switch form when new cust added
        Friend WithEvents _newCust As NewCustomer
        Friend WithEvents _payForm As PaymentsForm
        Friend WithEvents _creditForm As CustomerCredit
        Friend WithEvents _invForm As Invoicing.CustomInvoicingForm

        ' home form ref var
        Private _home As TrashCashHome

        Protected _currentCustomer As Integer
        Public Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                If (_currentCustomer <> value) Then
                    _currentCustomer = value

                    UC_CustomerInfoBoxes.CurrentCustomer = value
                    UC_CustomerNotes.CurrentCustomer = value
                    UC_RecurringService.CurrentCustomer = value
                    UC_Quickbooks.CurrentCustomer = value
                    UC_Quickbooks.CustomerListID = UC_CustomerInfoBoxes.CustomerListID
                    UC_PreparedItems.CurrentCustomer = value

                    ' update window title
                    Text = CustomerToolstrip1.ToString
                    ' send name to uc_recsrvc
                    UC_RecurringService.CustomerName = CustomerToolstrip1.ToString
                End If
            End Set
        End Property

        ' refresh balance event handleing
        Friend Sub RefreshCustBalance(Optional ByVal customerNumber As Integer = 0) Handles UC_RecurringService.RefreshBalance
            CustomerToolstrip1.GetCustomerBalance()
        End Sub

        Private Sub Customer_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub Customer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            If (CustomerToolstrip1.CurrentCustomer <> Nothing) Then
                CurrentCustomer = CustomerToolstrip1.CurrentCustomer
            End If
            UC_Quickbooks._HomeForm = _home

        End Sub

        Private Sub CustomerChanged(ByVal CustomerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
            CurrentCustomer = CustomerNumber
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

        Private Sub btn_NewCust_Click(sender As System.Object, e As System.EventArgs) Handles btn_NewCust.Click
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

        Public Sub New(ByRef HomeForm As TrashCashHome)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _home = HomeForm
            UC_Quickbooks._HomeForm = HomeForm
           UC_RecurringService.HomeForm = HomeForm
            CustomerToolstrip1.GetCustomerBalance()
        End Sub


        Private Sub btn_Payments_Click(sender As System.Object, e As System.EventArgs) Handles btn_Payments.Click
            _payForm = New PaymentsForm(_home, _customerNumber:=CurrentCustomer)
            ' when opened from customer screen, showdialog
            _payForm.ShowDialog()
        End Sub

        Private Sub btn_Credit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Credit.Click
            _creditForm = New CustomerCredit(_home, CurrentCustomer)
            _creditForm.ShowDialog()
        End Sub

        Private Sub btn_Inv_Click(sender As System.Object, e As System.EventArgs) Handles btn_Inv.Click
            _invForm = New Invoicing.CustomInvoicingForm(CurrentCustomer)
            _invForm.ShowDialog()
        End Sub
    End Class
End Namespace