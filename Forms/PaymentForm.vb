Public Class PaymentForm

    ' modify property
    Private _currentCustomer As Decimal
    Public Property CurrentCustomer
        Get
            Return _currentCustomer
        End Get
        Set(value)
            If (Not IsModing) Then
                _currentCustomer = CDec(value)
                If (value > 0) Then
                    CustomerComboBox.SelectCustomer(value)
                    UC_CustomerInfoBoxes.CurrentCustomer = value
                    UC_CustomerNotes.CurrentCustomer = value
                    'UC_PaymentDetails.CurrentCustomer = value
                    GetBalance()
                End If
            End If
        End Set
    End Property
    Private _wrkPayID As Decimal
    Public Property WorkingPaymentID
        Get
            Return _wrkPayID
        End Get
        Set(value)
            If (Not IsModing) Then

                _wrkPayID = CDec(value)
                If (value > 0) Then

                    ' lock the grid and showtooltip
                    dg_WorkPay.Enabled = False
                    tt_Locked.Active = True
                    ' show delete payment button
                    btn_DeletePay.Visible = True

                    CustomerComboBox.Enabled = False
                    ck_ActiveCustOnly.Enabled = False
                    'UC_PaymentDetails.WorkingPaymentID = value

                    ' disable master tc
                    tc_Master.Enabled = False

                    ' modifying
                    _IsModing = True
                Else

                    CustomerComboBox.Enabled = True
                    ck_ActiveCustOnly.Enabled = True
                    Me.WorkingPaymentsTableAdapter.Fill(Me.DataSet.WorkingPayments)

                    ' unlock grid and hide tooltip
                    dg_WorkPay.Enabled = True
                    tt_Locked.Active = False
                    ' hide delete payment button
                    btn_DeletePay.Visible = False
                    If (_currentCustomer > 0) Then
                        UC_PaymentDetails.CurrentCustomer = _currentCustomer
                    End If

                    ' enable tc
                    tc_Master.Enabled = True

                    ' not modifying
                    _IsModing = False
                End If
            Else
                MsgBox("You must finish Modifying this Payment first.")
            End If
        End Set
    End Property

    ' vars
    Private _IsModing As Boolean = False
    Public ReadOnly Property IsModing As Boolean
        Get
            Return _IsModing
        End Get
    End Property
    Private LastCustomerChanged As Decimal = 0

    'Private Sub Prep()
    '    If (WorkingPaymentID <> 0) Then
    '        UC_PaymentDetails.Prep(CurrentCustomer, WorkingPaymentID)
    '        LockForMod(True, CurrentCustomer)
    '    Else
    '        CustomerComboBox.SelectCustomer(CurrentCustomer)
    '        UC_PaymentDetails.Prep(CurrentCustomer)
    '        LockForMod(False)
    '    End If

    '    UC_CustomerInfoBoxes.CurrentCustomer = CurrentCustomer
    '    UC_CustomerNotes.CurrentCustomer = CurrentCustomer

    'End Sub

    Private Sub UpdateCatch(ByVal CustomerNumber As Decimal) Handles UC_CustomerInfoBoxes.UpdateComplete
        CustomerComboBox.SelectCustomer(CustomerNumber)
        _IsModing = False
    End Sub

    Private Sub CustomerChanged(ByVal custNum As Decimal) Handles CustomerComboBox.CustomerChanged
        CurrentCustomer = custNum
        'WorkingPaymentID = 0
        UC_PaymentDetails.CurrentCustomer = custNum
        'UC_PaymentDetails.Prep(custNum)
        'UC_CustomerInfoBoxes.CurrentCustomer = custNum
        'UC_CustomerNotes.CurrentCustomer = custNum
        'GetBalance()
    End Sub

    'Private Sub PaymentCommit(ByVal CustomerNumber As Decimal, ByVal message As String) Handles UC_PaymentDetails.CommitComplete
    '    MsgBox(message)
    '    _IsModing = False
    '    WorkingPaymentID = 0
    '    'LockForMod(False)
    '    'UC_PaymentDetails.Prep(CustomerComboBox.SelectedValue)

    '    ' updating LastCustomerChanged
    '    LastCustomerChanged = CustomerNumber
    'End Sub

    Private Sub PaymentForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (LastCustomerChanged <> 0) Then
            Master.ChildClosing(LastCustomerChanged, "A Payment has been updated for Customer # " & LastCustomerChanged & ". Would you like to switch to this Customer?")
        Else
            Master.PrepItemRefresh()
        End If
    End Sub

    Private Sub PaymentForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cm_i_ModPayment_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_ModPayment.Click
        If (dg_WorkPay.SelectedRows.Count = 1) Then
            Dim row As DataRowView = dg_WorkPay.SelectedRows(0).DataBoundItem
            CurrentCustomer = row.Item("CustomerNumber")
            WorkingPaymentID = row.Item("WorkingPaymentsID")
            'LockForMod(True, row.Item("CustomerNumber"))
            'UC_PaymentDetails.Prep(row.Item("CustomerNumber"), row.Item("WorkingPaymentsID"))
        Else
            MsgBox("Please select a Payment to Modify")
        End If
    End Sub

    Private Sub ck_ActiveCustOnly_Click(sender As System.Object, e As System.EventArgs) Handles ck_ActiveCustOnly.Click
        If (ck_ActiveCustOnly.Checked = True) Then
            CustomerComboBox.CheckBox_ActiveOnly()
        Else
            CustomerComboBox.CheckBox_AllCustomers()
        End If
    End Sub

    Private Sub GetBalance()
        Dim q As New TrashCash.QB_Queries.Customer
        Dim balanceValue As Double = q.Balance(UC_CustomerInfoBoxes.CustomerListID)
        ' update label text
        lbl_BalanceValue.Text = FormatCurrency(balanceValue)
        ' color label depending on balance
        If (balanceValue <= 0) Then
            lbl_BalanceValue.ForeColor = Color.Green
        ElseIf (balanceValue > 0) Then
            lbl_BalanceValue.ForeColor = Color.Red
            'lbl_BalanceValue.Text.Insert(0, "-")
        End If
    End Sub

    Private Sub btn_DeletePay_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeletePay.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you wish to delete this Prepared Payment? It has not been submited to Quickbooks yet.", vbYesNo)
        If (result = MsgBoxResult.Yes) Then
            'UC_PaymentDetails.DeletePayment()
        End If
    End Sub

    Private Sub LockAll(ByVal bool As Boolean) Handles UC_CustomerInfoBoxes.Updating
        If (bool = True) Then
            ToolStrip1.Enabled = False
            UC_PaymentDetails.Enabled = False
            dg_WorkPay.Enabled = False

        Else
            ToolStrip1.Enabled = True
            UC_PaymentDetails.Enabled = True
            dg_WorkPay.Enabled = True

        End If
    End Sub

    Private Sub ts_b_SearchNum_Click(sender As System.Object, e As System.EventArgs) Handles ts_b_SearchNum.Click
        Dim input As String = InputBox("Please type a Customer Number below to Search for a matching Customer.", "Customer Search: By Number")
        If (IsNumeric(input) = True) Then
            CustomerComboBox.SearchByNumber(input)
            ck_ActiveCustOnly.Checked = False
        Else
            MsgBox("You must provide a full Customer Number.")
        End If
    End Sub

    Private Sub ts_b_SearchName_Click(sender As System.Object, e As System.EventArgs) Handles ts_b_SearchName.Click
        Dim input As String = InputBox("Please type a Customer Name or part of a Customer Name to Search for a matching Customer.", "Customer Search: By Name")
        CustomerComboBox.SearchbyName(input)
        ck_ActiveCustOnly.Checked = False
    End Sub

    Private Sub ts_b_SearchAddr_Click(sender As System.Object, e As System.EventArgs) Handles ts_b_SearchAddr.Click
        Dim input As String = InputBox("Please type a Billing or Service Street Address or part of one to Search for a matching Customer.", "Customer Search: By Address")
        CustomerComboBox.SearchByAddress(input)
        ck_ActiveCustOnly.Checked = False
    End Sub
    Private Sub ActiveStateChange(ByVal ActiveOnly As Boolean) Handles CustomerComboBox.ListActiveStateChange
        If (ActiveOnly = True) Then
            ck_ActiveCustOnly.Checked = True
        Else
            ck_ActiveCustOnly.Checked = False
        End If
    End Sub

End Class