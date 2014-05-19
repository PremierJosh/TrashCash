Imports QBFC12Lib
Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class Customer
    ' new cust var so can switch form when new cust added
    Friend WithEvents _newCust As NewCustomer

    Friend WithEvents _payForm As Payments

    ' home form ref var
    Private _home As TrashCash_Home

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
                Me.Text = Ts_M_Customer.cmb_Customer.ComboBox.Text.ToString
                ' send name to uc_recsrvc
                UC_RecurringService.CustomerName = Ts_M_Customer.cmb_Customer.ComboBox.Text.ToString
            End If
        End Set
    End Property

    ' refresh balance event handleing
    Friend Sub RefreshCustBalance(Optional ByVal CustomerNumber As Integer = 0) Handles UC_RecurringService.RefreshBalance
        Ts_M_Customer.lbl_CustBalance.SetBalance(_home.Queries.Customer_Balance(Me.CurrentCustomer))
    End Sub

    Private Sub Customer_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub Customer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If (Ts_M_Customer.cmb_Customer.ComboBox.SelectedValue IsNot Nothing) Then
            Me.CurrentCustomer = Ts_M_Customer.cmb_Customer.ComboBox.SelectedValue
            Ts_M_Customer.CurrentCustomer = Me.CurrentCustomer
            ' init balance set
            Ts_M_Customer.lbl_CustBalance.SetBalance(_home.Queries.Customer_Balance(Me.CurrentCustomer))
        End If
        UC_Quickbooks._HomeForm = _home
    End Sub

    Private Sub CustomerChanged(ByVal CustomerNumber As Integer) Handles Ts_M_Customer.CustomerChanging
        Me.CurrentCustomer = CustomerNumber
        Ts_M_Customer.lbl_CustBalance.SetBalance(_home.Queries.Customer_Balance(CustomerNumber))
    End Sub

    ' event handle for begining to update customer info
    Private Sub LockAll(ByVal bool As Boolean) Handles UC_CustomerInfoBoxes.Updating
        If (bool = True) Then
            Ts_M_Customer.Enabled = False
            ts_Top.Enabled = False

            ' lock tc
            tc_Master.Enabled = False

        Else
            Ts_M_Customer.Enabled = True
            ts_Top.Enabled = True

            ' unlock tc
            tc_Master.Enabled = True
        End If
    End Sub

    ' event handle for completed updating
    Private Sub CustomerInfoUpdated(ByVal CustomerNumber As Decimal) Handles UC_CustomerInfoBoxes.UpdateComplete
        Ts_M_Customer.RefreshCustomerList()
    End Sub

    Private Sub btn_NewCust_Click(sender As System.Object, e As System.EventArgs) Handles btn_NewCust.Click
        _newCust = New NewCustomer(_home)
        _newCust.ShowDialog()
    End Sub

    ' new cust event handle to switch to it
    Private Sub NewCustomer(ByVal newCustNum As Integer) Handles _newCust.NewCustomerAdded
        Ts_M_Customer.tb_QuickSearch.Text = ""
        Ts_M_Customer.RefreshCustomerList()
        Ts_M_Customer.SelectCustWithEvent(newCustNum)
        ' clearing newcust var
        _newCust = Nothing
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _home = HomeForm
        UC_Quickbooks._HomeForm = HomeForm
        UC_CustomerInfoBoxes.HomeForm = HomeForm
        UC_RecurringService.HomeForm = HomeForm
    End Sub


    Private Sub btn_Payments_Click(sender As System.Object, e As System.EventArgs) Handles btn_Payments.Click
        _payForm = New Payments(_home, _customerNumber:=CurrentCustomer)
        ' when opened from customer screen, showdialog
        _payForm.ShowDialog()
    End Sub

End Class