Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling


Public Class QB_Queries

    Protected _msgSetReq As IMsgSetRequest
    Private ReadOnly Property MsgSetRequest As IMsgSetRequest
        Get
            Return _msgSetReq
        End Get
    End Property
    Protected _sessMgr As QBSessionManager
    Private ReadOnly Property SessionManager As QBSessionManager
        Get
            Return _sessMgr
        End Get
    End Property

    Public Sub New(ByRef SessionManager As QBSessionManager, ByRef MsgSetReq As IMsgSetRequest)
        _sessMgr = SessionManager
        _msgSetReq = MsgSetReq
    End Sub

    Public Class InvoiceTotalBalance
        Public Property Subtotal As Double
        Public Property Balance As Double
    End Class


    Public Function Invoice_GetBalance(ByVal TxnID As String) As InvoiceTotalBalance
        Dim invObj As New InvoiceTotalBalance

        Dim invoiceQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq

        ' passing inv txn id property
        invoiceQuery.ORInvoiceQuery.TxnIDList.Add(TxnID)
        ' just getting balance
        invoiceQuery.IncludeRetElementList.Add("BalanceRemaining")
        invoiceQuery.IncludeRetElementList.Add("Subtotal")

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                Dim invoiceRetList As IInvoiceRetList = resp.Detail
                For j = 0 To invoiceRetList.Count - 1
                    Dim invoiceRet As IInvoiceRet = invoiceRetList.GetAt(j)

                    invObj.Balance = invoiceRet.BalanceRemaining.GetValue
                    invObj.Subtotal = invoiceRet.Subtotal.GetValue

                Next j
            ElseIf (resp.StatusCode = 1) Then
                MsgBox("No Invoices match search criteria in QuickBooks")
            Else
                ResponseErr_Misc(resp)

            End If
        Next i

        Return invObj
    End Function
    Public Sub Invoice_ForDisplay(ByRef paidStatus As QBFC12Lib.ENPaidStatus, ByRef dg_dt As ds_Display.QB_InvoiceDisplayDataTable,
                                Optional ByRef custListID As String = Nothing,
                                Optional ByRef fromDate As Date = Nothing, Optional ByRef toDate As Date = Nothing)

        Dim invQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq

        ' limiting response
        invQuery.IncludeRetElementList.Add("RefNumber")
        invQuery.IncludeRetElementList.Add("TxnDate")
        invQuery.IncludeRetElementList.Add("TimeCreated")
        invQuery.IncludeRetElementList.Add("CustomerRef")
        invQuery.IncludeRetElementList.Add("Subtotal")
        invQuery.IncludeRetElementList.Add("BalanceRemaining")
        invQuery.IncludeRetElementList.Add("DueDate")

        ' using custListID param here if provided
        If (custListID.Length > 1) Then
            invQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(custListID)
        End If
        ' using From Date param here
        If (fromDate <> Nothing) Then
            invQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fromDate)
        End If
        ' using To Date param here
        If (toDate <> Nothing) Then
            invQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(toDate)
        End If

        ' if no date filter is passed, limiting results
        If ((toDate = Nothing) And (fromDate = Nothing)) Then
            invQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(50)
        End If

        ' paid status is always passed
        invQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(paidStatus)

        ' sending request
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        ' looping through response list
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(0)
            If (resp.StatusCode = 0) Then
                ' if response is good then clear table for incoming rows
                dg_dt.Clear()

                Dim invRetList As IInvoiceRetList = resp.Detail
                ' looping through invoice ret list
                For j = 0 To invRetList.Count - 1
                    Dim invRet As IInvoiceRet = invRetList.GetAt(j)
                    ' building new row
                    Dim newRow As ds_Display.QB_InvoiceDisplayRow = dg_dt.NewQB_InvoiceDisplayRow
                    newRow.InvoiceNumber = invRet.RefNumber.GetValue
                    newRow.InvoicePostDate = invRet.TxnDate.GetValue.Date
                    newRow.InvoiceCreationDate = invRet.TimeCreated.GetValue.Date
                    newRow.CustomerName = invRet.CustomerRef.FullName.GetValue

                    '2.0 - dimming qta to drop in cust num here
                    Dim qta As New DataSetTableAdapters.QueriesTableAdapter
                    newRow.CustomerNumber = qta.Customer_GetNumberFromListID(invRet.CustomerRef.ListID.GetValue)

                    newRow.InvoiceTotal = invRet.Subtotal.GetValue
                    newRow.InvoiceBalance = invRet.BalanceRemaining.GetValue
                    newRow.InvoiceDueDate = invRet.DueDate.GetValue.Date
                    dg_dt.AddQB_InvoiceDisplayRow(newRow)
                Next j
            ElseIf (resp.StatusCode = 1) Then
                'MsgBox("No Invoices match search criteria in QuickBooks")
            ElseIf (resp.StatusCode > 1) Then
                ResponseErr_Misc(resp)
            End If
        Next i

    End Sub


    Public Sub Payments_ForDisplay(ByRef dg_dt As ds_Display.QB_PaymentsDisplayDataTable, ByRef custListID As String, _
                                  Optional ByRef fromDate As Date = Nothing, Optional ByRef toDate As Date = Nothing)

        Dim payQuery As IReceivePaymentQuery = MsgSetRequest.AppendReceivePaymentQueryRq

        payQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(custListID)

        ' checking if a fromDate was passed
        If (fromDate <> Nothing) Then
            payQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fromDate)
        End If
        ' checking if a toDate was passed
        If (toDate <> Nothing) Then
            payQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(toDate)
        End If

        ' if no date filter is passed, limiting results
        If ((toDate = Nothing) And (fromDate = Nothing)) Then
            payQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(50)
        End If

        ' making sure I get the response information i want
        payQuery.IncludeRetElementList.Add("TxnNumber")
        payQuery.IncludeRetElementList.Add("TxnDate")
        payQuery.IncludeRetElementList.Add("TotalAmount")
        payQuery.IncludeRetElementList.Add("RefNumber")
        payQuery.IncludeRetElementList.Add("PaymentMethodRef")

        ' sending response
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        ' looping through response with error checking
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                ' if good clear table for new rows clear table
                dg_dt.Clear()

                Dim paymentRetList As IReceivePaymentRetList = resp.Detail
                For l = 0 To paymentRetList.Count - 1
                    Dim paymentRet As IReceivePaymentRet = paymentRetList.GetAt(l)
                    ' building new paymentList row
                    Dim newRow As ds_Display.QB_PaymentsDisplayRow = dg_dt.NewQB_PaymentsDisplayRow
                    newRow.PaymentTxnNumber = paymentRet.TxnNumber.GetValue
                    newRow.PaymentDate = paymentRet.TxnDate.GetValue
                    newRow.PaymentAmount = paymentRet.TotalAmount.GetValue
                    newRow.PaymentMethod = paymentRet.PaymentMethodRef.FullName.GetValue
                    If (paymentRet.RefNumber IsNot Nothing) Then
                        newRow.PaymentCheckNum = paymentRet.RefNumber.GetValue
                    End If
                    dg_dt.AddQB_PaymentsDisplayRow(newRow)
                Next l
            ElseIf (resp.StatusCode = 1) Then
                'MsgBox("No Recieved Payments match search criteria in Quickbooks.")
            ElseIf (resp.StatusCode > 1) Then
                ResponseErr_Misc(resp)
            End If
        Next i
    End Sub


    Public Overloads Function Customer_Balance(ByVal ListID As String) As Double
        ' customer listID var im sending
        Dim _balance As Double
        _balance = Customer_GetBalance(ListID)
        Return _balance

    End Function
    Public Overloads Function Customer_Balance(ByVal decNumber As Decimal) As Double
        ' cust number coming in
        Dim qta As New DataSetTableAdapters.QueriesTableAdapter
        Dim custListID As String = qta.Customer_GetListID(decNumber)
        qta = Nothing

        Dim _balance As Double
        _balance = Customer_GetBalance(custListID)
        Return _balance
    End Function
    Public Overloads Function Customer_Balance(ByVal intNumber As Integer) As Double
        ' cust number coming in
        Dim qta As New DataSetTableAdapters.QueriesTableAdapter
        Dim custListID As String = qta.Customer_GetListID(intNumber)
        qta = Nothing

        Dim _balance As Double
        _balance = Customer_GetBalance(custListID)
        Return _balance
    End Function
    Private Function Customer_GetBalance(ByRef custListID As String) As Double
        Dim returnVar As Double

        Dim custQuery As ICustomerQuery = MsgSetRequest.AppendCustomerQueryRq

        custQuery.ORCustomerListQuery.ListIDList.Add(custListID)
        custQuery.IncludeRetElementList.Add("TotalBalance")

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i As Integer = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            ' response check and logging
            If (resp.StatusCode = 0) Then

                Dim custRetList As ICustomerRetList = resp.Detail
                For j = 0 To custRetList.Count - 1
                    Dim custRet As ICustomerRet = custRetList.GetAt(j)
                    returnVar = custRet.TotalBalance.GetValue
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next i

        Return returnVar
    End Function

    Public Overloads Function Customer_EditSequence(ByVal ListID As String) As String
        ' customer listID var im sending
        Dim _editSeq As String
        _editSeq = Customer_GetEditSequence(ListID)
        Return _editSeq
    End Function
    Public Overloads Function Customer_EditSequence(ByVal decNumber As Decimal) As Double
        ' cust number coming in
        Dim qta As New DataSetTableAdapters.QueriesTableAdapter
        Dim ListID As String = qta.Customer_GetListID(decNumber)
        qta = Nothing

        Dim _editSeq As String
        _editSeq = Customer_GetEditSequence(ListID)
        Return _editSeq
    End Function
    Public Overloads Function Customer_EditSequence(ByVal intNumber As Integer) As Double
        ' cust number coming in
        Dim qta As New DataSetTableAdapters.QueriesTableAdapter
        Dim ListID As String = qta.Customer_GetListID(intNumber)
        qta = Nothing

        Dim _editSeq As String
        _editSeq = Customer_GetEditSequence(ListID)
        Return _editSeq
    End Function
    Private Function Customer_GetEditSequence(ByVal custListID As String) As String
        Dim editSeq As String = Nothing

        Dim custQuery As ICustomerQuery = MsgSetRequest.AppendCustomerQueryRq

        custQuery.ORCustomerListQuery.ListIDList.Add(custListID)
        custQuery.IncludeRetElementList.Add("EditSequence")

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        'clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim response As IResponse = respList.GetAt(i)
            If (response.StatusCode = 0) Then
                If (response.Detail IsNot Nothing) Then
                    Dim custRetList As ICustomerRetList = response.Detail
                    For j = 0 To custRetList.Count - 1
                        Dim custRet As ICustomerRet = custRetList.GetAt(j)

                        ' update row
                        editSeq = custRet.EditSequence.GetValue
                        Return editSeq
                    Next j
                End If
            Else
                ' error logging
                ResponseErr_Misc(response)
            End If
        Next i

        Return editSeq
    End Function


    Public Class ComboBoxPair
        Public Property ValueMember
        Public Property DisplayMember
    End Class

    Public Sub CMB_BindServiceItem(ByRef cmb As ComboBox)
        Dim list As List(Of ComboBoxPair) = CMB_ServiceItemList()
        cmb.DisplayMember = "DisplayMember"
        cmb.ValueMember = "ValueMember"
        cmb.DataSource = list
    End Sub

    Private Function CMB_ServiceItemList() As List(Of ComboBoxPair)
        ' return list
        Dim itemList As New List(Of ComboBoxPair)


        Dim itemQuery As IItemServiceQuery = MsgSetRequest.AppendItemServiceQueryRq

        ' active items only
        itemQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)
        ' limit response for combo box
        itemQuery.IncludeRetElementList.Add("ListID")
        itemQuery.IncludeRetElementList.Add("FullName")

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList
        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim response As IResponse = respList.GetAt(i) '
            If (response.StatusCode = 0) Then

                Dim itemRetList As IItemServiceRetList = response.Detail

                For j = 0 To itemRetList.Count - 1
                    Dim itemRet As IItemServiceRet = itemRetList.GetAt(j)

                    ' making item
                    Dim item As New ComboBoxPair
                    item.DisplayMember = itemRet.FullName.GetValue
                    item.ValueMember = itemRet.ListID.GetValue

                    itemList.Add(item)
                Next
            Else
                ResponseErr_Misc(response)
            End If
        Next

        Return itemList
    End Function

    Public Sub CMB_BindOtherChargeItems(ByRef cmb As ComboBox)
        Dim list As List(Of ComboBoxPair) = CMB_OtherChargeItemList()
        cmb.DisplayMember = "DisplayMember"
        cmb.ValueMember = "ValueMember"
        cmb.DataSource = list
    End Sub
    Private Function CMB_OtherChargeItemList() As List(Of ComboBoxPair)
        ' return list
        Dim itemList As New List(Of ComboBoxPair)


        Dim itemQuery As IItemOtherChargeQuery = MsgSetRequest.AppendItemOtherChargeQueryRq

        ' active items only
        itemQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)
        ' limit response for combo box
        itemQuery.IncludeRetElementList.Add("ListID")
        itemQuery.IncludeRetElementList.Add("FullName")

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList
        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim response As IResponse = respList.GetAt(i) '
            If (response.StatusCode = 0) Then

                Dim itemRetList As IItemOtherChargeRetList = response.Detail

                For j = 0 To itemRetList.Count - 1
                    Dim itemRet As IItemOtherChargeRet = itemRetList.GetAt(j)

                    ' making item
                    Dim item As New ComboBoxPair
                    item.DisplayMember = itemRet.FullName.GetValue
                    item.ValueMember = itemRet.ListID.GetValue

                    itemList.Add(item)
                Next
            Else
                ResponseErr_Misc(response)
            End If
        Next

        Return itemList
    End Function

    Public Sub CMB_BindVendorAccount(ByRef cmb As ComboBox)
        Dim list As List(Of ComboBoxPair) = CMB_VendorAccountList()
        cmb.DisplayMember = "DisplayMember"
        cmb.ValueMember = "ValueMember"
        cmb.DataSource = list
    End Sub
    Private Function CMB_VendorAccountList() As List(Of ComboBoxPair)
        ' return list
        Dim vendorList As New List(Of ComboBoxPair)

        Dim vendorQuery As IVendorQuery = MsgSetRequest.AppendVendorQueryRq

        ' making sure we only get active vendors
        vendorQuery.ORVendorListQuery.VendorListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgsetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim response As IResponse = respList.GetAt(i)
            If (response.StatusCode = 0) Then

                Dim vendorRetList As IVendorRetList = response.Detail

                For j = 0 To vendorRetList.Count - 1
                    Dim vendorRet As IVendorRet = vendorRetList.GetAt(j)

                    ' item going into list
                    Dim item As New ComboBoxPair
                    item.DisplayMember = vendorRet.Name.GetValue
                    item.ValueMember = vendorRet.ListID.GetValue

                    ' adding to list
                    vendorList.Add(item)
                Next
            Else
                ResponseErr_Misc(response)
            End If
        Next

        Return vendorList
    End Function

    Public Sub CMB_BindBankAccount(ByRef cmb As ComboBox)
        Dim list As List(Of ComboBoxPair) = CMB_GetAccountList(Bank:=True)
        cmb.DisplayMember = "DisplayMember"
        cmb.ValueMember = "ValueMember"
        cmb.DataSource = list
    End Sub
    Public Sub CMB_BindIncomeAccount(ByRef cmb As ComboBox)
        Dim list As List(Of ComboBoxPair) = CMB_GetAccountList(Income:=True)
        cmb.DisplayMember = "DisplayMember"
        cmb.ValueMember = "ValueMember"
        cmb.DataSource = list
    End Sub
    Private Function CMB_GetAccountList(Optional ByVal Income As Boolean = False, Optional ByVal Bank As Boolean = False) As List(Of ComboBoxPair)
        ' return array for data binding
        Dim accountList As New List(Of ComboBoxPair)

        Dim accountQuery As IAccountQuery = MsgSetRequest.AppendAccountQueryRq

        ' getting only requested accounts
        If (Income = True) Then
            accountQuery.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(ENAccountType.atIncome)
        ElseIf (Bank = True) Then
            accountQuery.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(ENAccountType.atBank)
        End If

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim response As IResponse = respList.GetAt(i)

            ' making sure we have responses
            If (response.StatusCode = 0) Then
                If (response.Detail IsNot Nothing) Then

                    Dim accountRetList As IAccountRetList = response.Detail

                    For l = 0 To accountRetList.Count - 1
                        Dim accountRet As IAccountRet = accountRetList.GetAt(l)

                        'creating list item
                        Dim item As New ComboBoxPair
                        item.DisplayMember = accountRet.Name.GetValue.ToString
                        item.ValueMember = accountRet.ListID.GetValue.ToString

                        'adding to list
                        accountList.Add(item)
                    Next l
                End If
            Else
                ResponseErr_Misc(response)
            End If
        Next i

        Return accountList
    End Function

End Class
