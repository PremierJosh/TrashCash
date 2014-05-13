Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling


Public Class QB_Procedures2
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

    Protected qta As DataSetTableAdapters.QueriesTableAdapter
    Protected cta As DataSetTableAdapters.CustomerTableAdapter
    Protected rsta As DataSetTableAdapters.RecurringServiceTableAdapter
    Protected wta As DataSetTableAdapters.Batch_WorkingInvoiceTableAdapter
    Protected lidt As DataSet.BATCH_LineItemsDataTable
    Protected lita As DataSetTableAdapters.BATCH_LineItemsTableAdapter
    Protected stta As DataSetTableAdapters.ServiceTypesTableAdapter
    Protected strow As DataSet.ServiceTypesRow

    ' new tas
    Protected p_rsta As ds_ProgramTableAdapters.RecurringServiceTableAdapter
    Protected p_qta As ds_ProgramTableAdapters.QueriesTableAdapter

    Public Sub New(ByRef SessionManager As QBSessionManager, ByRef MsgSetReq As IMsgSetRequest)
        ' setting sess mgr and msgsetreq
        _sessMgr = SessionManager
        _msgSetReq = MsgSetReq

        qta = New DataSetTableAdapters.QueriesTableAdapter
        cta = New DataSetTableAdapters.CustomerTableAdapter
        rsta = New DataSetTableAdapters.RecurringServiceTableAdapter
        wta = New DataSetTableAdapters.Batch_WorkingInvoiceTableAdapter
        lidt = New DataSet.BATCH_LineItemsDataTable
        lita = New DataSetTableAdapters.BATCH_LineItemsTableAdapter
        stta = New DataSetTableAdapters.ServiceTypesTableAdapter

        ' new tas
        p_rsta = New ds_ProgramTableAdapters.RecurringServiceTableAdapter
        p_qta = New ds_ProgramTableAdapters.QueriesTableAdapter
    End Sub


    Protected Function VoidTransactionByTxnID(ByVal TxnID As String, ByVal VoidType As ENTxnVoidType) As Boolean
        ' return bool
        Dim voided As Boolean

        Dim txnVoid As ITxnVoid = MsgSetRequest.AppendTxnVoidRq

        ' setting txn we are talking about
        txnVoid.TxnVoidType.SetValue(VoidType)
        txnVoid.TxnID.SetValue(TxnID)


        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgsetreq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode <> 0) Then
                ResponseErr_Misc(resp)
            Else
                voided = True
            End If
        Next i

        Return voided
    End Function


    Public Sub Customer_AddMissingListID(ByRef form As ImportWork)
        Dim missingCount As Integer = qta.Customer_MissingListIDCount

        ' fill table
        If (missingCount > 0) Then
            Dim dt As DataSet.CustomerDataTable
            dt = cta.GetAllWithMissingListID

            ' pb init stuff
            Dim progCounter As Integer = 0
            form.pb_AllCustAdd.Maximum = dt.Rows.Count
            form.lbl_AllCustAddCount.Text = progCounter & "/" & dt.Rows.Count

            ' loop through table
            For Each custRow As DataSet.CustomerRow In dt

                ' pb update stuff
                progCounter += 1
                form.pb_AllCustAdd.Value = progCounter
                form.lbl_AllCustAddCount.Text = progCounter & "/" & dt.Rows.Count

                Dim customerAdd As ICustomerAdd = MsgSetRequest.AppendCustomerAddRq

                ' General Customer Information
                customerAdd.Name.SetValue(custRow.CustomerFullName)
                If (custRow.IsCustomerCompanyNameNull = False) Then
                    customerAdd.CompanyName.SetValue(custRow.CustomerCompanyName)
                End If
                If (custRow.IsCustomerFirstNameNull = False) Then
                    customerAdd.FirstName.SetValue(custRow.CustomerFirstName)
                End If
                If (custRow.IsCustomerLastNameNull = False) Then
                    customerAdd.LastName.SetValue(custRow.CustomerLastName)
                End If
                customerAdd.Phone.SetValue(custRow.CustomerPhone)
                If (custRow.IsCustomerAltPhoneNull = False) Then
                    customerAdd.AltPhone.SetValue(custRow.CustomerAltPhone)
                End If
                If (custRow.IsCustomerContactNull = False) Then
                    customerAdd.Contact.SetValue(custRow.CustomerContact)
                End If
                ' setting active status
                If (custRow.CustomerIsDeactive = True) Then
                    customerAdd.IsActive.SetValue(False)
                Else
                    customerAdd.IsActive.SetValue(True)
                End If

                ' Billing Address Information
                ' addr1 is first name + last name if first name is present, otherwise company name
                customerAdd.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
                If (custRow.IsCustomerBillingAddr2Null = False) Then
                    customerAdd.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
                End If
                If (custRow.IsCustomerBillingAddr3Null = False) Then
                    customerAdd.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
                End If
                If (custRow.IsCustomerBillingAddr4Null = False) Then
                    customerAdd.BillAddress.Addr4.SetValue(custRow.CustomerBillingAddr4)
                End If
                customerAdd.BillAddress.City.SetValue(custRow.CustomerBillingCity)
                customerAdd.BillAddress.State.SetValue(custRow.CustomerBillingState)
                customerAdd.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

                ' sending request
                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim responseList As IResponseList = msgSetResp.ResponseList

                'clear msgSetREq
                MsgSetRequest.ClearRequests()

                ' looping through response with error checking
                For i = 0 To responseList.Count - 1
                    Dim response As IResponse = responseList.GetAt(i)
                    If (response.StatusCode = 0) Then
                        Dim responseType As ENResponseType
                        responseType = CType(response.Type.GetValue(), ENResponseType)
                        If (responseType = QBFC12Lib.ENResponseType.rtCustomerAddRs) Then
                            Dim customerRet As ICustomerRet = response.Detail
                            ' updating the custRow with ListID and EditSeq
                            custRow.CustomerListID = customerRet.ListID.GetValue
                            custRow.CustomerEditSeq = customerRet.EditSequence.GetValue

                            Try
                                ' commiting to DB
                                cta.Update(custRow)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        End If

                    ElseIf (response.StatusCode = 3100) Then
                        ' customer name already exists
                        Dim input As String = InputBox("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.")
                        If (input.Length > 0) Then
                            custRow.CustomerFullName = input

                            Try
                                ' commiting to DB
                                cta.Update(custRow)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                            ' moving to next customer
                            GoTo skipCustomer
                        End If
                    Else
                        ' error logging
                        ResponseErr_Misc(response)

                        ' bail out
                        Exit Sub

                    End If

                Next i

skipCustomer:
            Next custRow

            ' checking if customers still missing listids. most likely from having to rename
            missingCount = qta.Customer_MissingListIDCount
            If (missingCount > 0) Then
                Customer_AddMissingListID(form)
            End If

        End If
        MsgBox("All Customers Added. If this is the initially load, be sure to import services!")
    End Sub

    Public Function Customer_New(ByRef custRow As DataSet.CustomerRow) As Boolean
        ' return bool for success
        Dim addOK As Boolean

        ' build full name
        If (custRow.IsCustomerCompanyNameNull = False) Then
            custRow.CustomerFullName = custRow.CustomerCompanyName & " - " & custRow.CustomerNumber
        Else
            custRow.CustomerFullName = custRow.CustomerLastName & ", " & custRow.CustomerFirstName & " - " & custRow.CustomerNumber
        End If

retry:
        Dim customerAdd As ICustomerAdd = MsgSetRequest.AppendCustomerAddRq

        ' General Customer Information
        customerAdd.Name.SetValue(custRow.CustomerFullName)
        If (custRow.IsCustomerCompanyNameNull = False) Then
            customerAdd.CompanyName.SetValue(custRow.CustomerCompanyName)
        End If
        If (custRow.IsCustomerFirstNameNull = False) Then
            customerAdd.FirstName.SetValue(custRow.CustomerFirstName)
        End If
        If (custRow.IsCustomerLastNameNull = False) Then
            customerAdd.LastName.SetValue(custRow.CustomerLastName)
        End If
        customerAdd.Phone.SetValue(custRow.CustomerPhone)

        If (custRow.IsCustomerAltPhoneNull = False) Then
            customerAdd.AltPhone.SetValue(custRow.CustomerAltPhone)
        End If
        If (custRow.IsCustomerContactNull = False) Then
            customerAdd.Contact.SetValue(custRow.CustomerContact)
        End If

        ' Billing Address Information
        customerAdd.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
        If (custRow.IsCustomerBillingAddr2Null = False) Then
            customerAdd.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
        End If
        If (custRow.IsCustomerBillingAddr3Null = False) Then
            customerAdd.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
        End If
        If (custRow.IsCustomerBillingAddr4Null = False) Then
            customerAdd.BillAddress.Addr4.SetValue(custRow.CustomerBillingAddr4)
        End If
        customerAdd.BillAddress.City.SetValue(custRow.CustomerBillingCity)
        customerAdd.BillAddress.State.SetValue(custRow.CustomerBillingState)
        customerAdd.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

        ' sending request
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear requests
        MsgSetRequest.ClearRequests()

        ' looping through response with error checking
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                ' updating return var
                addOK = True

                Dim customerRet As ICustomerRet = resp.Detail
                ' updating the custRow with ListID and EditSeq
                custRow.CustomerListID = customerRet.ListID.GetValue
                custRow.CustomerEditSeq = customerRet.EditSequence.GetValue

                Try
                    ' commiting to DB
                    cta.Update(custRow)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf (resp.StatusCode = 3100) Then

                ' customer already exists with that name
                Dim input As String = InputBox("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.")
                If (input.Length > 0) Then
                    custRow.CustomerFullName = input

                    Try
                        ' commiting to DB
                        cta.Update(custRow)
                        GoTo retry
                        'Exit Function
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                ' updating return var
                addOK = False

                ' error logging
                ResponseErr_Misc(resp)

                ' delete row
                qta.Customer_DeleteByNum(custRow.CustomerNumber)

                ' bail out
                Return addOK
            End If
        Next i

        MsgBox("Customer: '" & custRow.CustomerFullName & "' added successfully.")

        Return addOK
    End Function
    Public Sub Customer_Update(ByRef custRow As DataSet.CustomerRow)
retry:
        Dim customerMod As ICustomerMod = MsgSetRequest.AppendCustomerModRq

        customerMod.ListID.SetValue(custRow.CustomerListID)
        customerMod.EditSequence.SetValue(custRow.CustomerEditSeq)

        '''' customer information ''''
        customerMod.Name.SetValue(custRow.CustomerFullName)
        If (custRow.IsCustomerCompanyNameNull = False) Then
            customerMod.CompanyName.SetValue(custRow.CustomerCompanyName)
        End If
        If (custRow.IsCustomerFirstNameNull = False) Then
            customerMod.FirstName.SetValue(custRow.CustomerFirstName)
        End If
        If (custRow.IsCustomerLastNameNull = False) Then
            customerMod.LastName.SetValue(custRow.CustomerLastName)
        End If
        customerMod.Phone.SetValue(custRow.CustomerPhone)

        ' checking possibly blank alt phone
        If (custRow.IsCustomerAltPhoneNull = False) Then
            customerMod.AltPhone.SetValue(custRow.CustomerAltPhone)
        End If
        ' checking possibly blank contact field
        If (custRow.IsCustomerContactNull = False) Then
            customerMod.Contact.SetValue(custRow.CustomerContact)
        End If

        '''' billing information ''''
        ' required billAddr1
        customerMod.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
        ' checking billAddr2
        If (custRow.IsCustomerBillingAddr2Null = False) Then
            customerMod.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
        End If
        ' checking billAddr3
        If (custRow.IsCustomerBillingAddr3Null = False) Then
            customerMod.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
        End If
        customerMod.BillAddress.City.SetValue(custRow.CustomerBillingCity)
        customerMod.BillAddress.State.SetValue(custRow.CustomerBillingState)
        customerMod.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

        ' if cell = true, then customer is deactive
        If (custRow.CustomerIsDeactive = True) Then
            customerMod.IsActive.SetValue(False)
        Else
            customerMod.IsActive.SetValue(True)
        End If

        ' doing request and catching in msgSetResp
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear requests
        MsgSetRequest.ClearRequests()

        ' looping through response for errors and writing to error log
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                Dim customerRet As ICustomerRet = resp.Detail

                ' updating EditSeq in the DB
                custRow.BeginEdit()
                custRow.CustomerEditSeq = customerRet.EditSequence.GetValue()
                custRow.EndEdit()

                Try
                    ' update table
                    cta.Update(custRow)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                MsgBox("Changes Complete")
            ElseIf (resp.StatusCode = 3200) Then
                ' edit sequence missmatch
                Dim q As New QB_Queries2(SessionManager, MsgSetRequest)
                custRow.BeginEdit()
                custRow.CustomerEditSeq = q.Customer_EditSequence(custRow.CustomerListID)
                custRow.EndEdit()

                Try
                    ' update table then retry
                    cta.Update(custRow)
                    GoTo retry
                    Exit Sub
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else
                custRow.RejectChanges()
                ResponseErr_Misc(resp)
            End If
        Next i
    End Sub

    Public Sub RecurringService_Credit(ByRef row As ds_Program.RecurringServiceRow, ByVal creditAmount As Double,
                                ByVal newEndDate As Date)

        Dim creditMemoAdd As ICreditMemoAdd = MsgSetRequest.AppendCreditMemoAddRq

        ' passing listid
        creditMemoAdd.CustomerRef.ListID.SetValue(qta.Customer_GetListID(row.CustomerNumber))
        creditMemoAdd.IsToBePrinted.SetValue(False)

        Dim creditLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
        ' credit line info
        creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(qta.ServiceTypes_GetListIDByTypeID(row.ServiceTypeID))
        creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(creditAmount)

        ' description line
        Dim descLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
        descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
        descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
        descLine.CreditMemoLineAdd.Desc.SetValue("This service has been Invoiced upto " & qta.RecurringService_LastInvDate(row.RecurringServiceID) & ". The new End Date overlaps this Invoiced period. | New End Date: " & newEndDate.Date)
        descLine.CreditMemoLineAdd.Amount.Unset()
        descLine.CreditMemoLineAdd.Quantity.Unset()

        ' send request
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgsetreq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                ' update row
                row.RecurringServiceEndDate = newEndDate.Date
                row.Credited = True

                ' insert record
                Dim creditMemoRet As ICreditMemoRet = resp.Detail
                Try
                    p_qta.RecurringService_Credit_Insert(row.RecurringServiceID, newEndDate, creditAmount, creditMemoRet.TxnID.GetValue)
                Catch ex As Exception
                    MessageBox.Show("Error inserting Credit History: " & ex.Message, "Error Credit Record Insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                ' commit
                Try
                    p_rsta.Update(row)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                ResponseErr_Misc(resp)
            End If
        Next i
    End Sub
    Public Function Customer_BounceCheck(ByVal CheckRow As DataSet.PaymentHistoryRow, ByVal BankRow As ds_Program.BAD_CHECK_BANKS_Row, ByVal Fee As Double) As Boolean
        ' return bool
        Dim bounced As Boolean

        ' need to do 2 things:
        ' 1. invoice customer for bounced check amount and our fee
        ' 2. checkadd for bank

        ' 1. invoice first
        Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq

        ' going to need app defaults row for items
        Dim app_row As ds_Program.APP_SETTINGS_Row
        Dim app_ta As New ds_ProgramTableAdapters.APP_SETTINGS_TableAdapter
        app_row = app_ta.GetData().Rows(0)
        ' discarding ta
        app_ta = Nothing

        invoiceAdd.CustomerRef.ListID.SetValue(qta.Customer_GetListID(CheckRow.CustomerNumber))
        invoiceAdd.IsToBePrinted.SetValue(True)

        ' var to hold line items
        Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList

        ' first line item will be for the bounced check amount
        Dim checkLine As IORInvoiceLineAdd = lineList.Append
        checkLine.InvoiceLineAdd.ItemRef.ListID.SetValue(BankRow.QB_BANK_INV_ITEM_LISTID)
        checkLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(CheckRow.Amount)
        checkLine.InvoiceLineAdd.Quantity.SetValue(1)
        ' setting description
        checkLine.InvoiceLineAdd.Desc.SetValue("Bounced Check #: " & CheckRow.RefNumber & ". Received on " & CheckRow.DateReceived.Date & " in the amount of " & FormatCurrency(CheckRow.Amount) & ".")

        ' 2nd line till be for the fee we are charging the customer
        Dim feeLine As IORInvoiceLineAdd = lineList.Append
        feeLine.InvoiceLineAdd.ItemRef.ListID.SetValue(app_row.BAD_CHECK_CUSTITEM_LISTID)
        feeLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(Fee)
        feeLine.InvoiceLineAdd.Quantity.SetValue(1)

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                ' update pay history table and set assoc row to bounced
                Try
                    Dim ta As New DataSetTableAdapters.PaymentHistoryTableAdapter
                    ta.SetBounced(CheckRow.PaymentID)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                ResponseErr_Misc(resp)
                Return bounced
            End If
        Next

        ' doing checkadd to pay bank fee
        Dim checkAdd As ICheckAdd = MsgSetRequest.AppendCheckAddRq

        'account ref is bank paying from
        checkAdd.AccountRef.ListID.SetValue(BankRow.QB_BANK_LISTID)
        ' payee is vendor
        checkAdd.PayeeEntityRef.ListID.SetValue(BankRow.QB_VENDOR_LISTID)
        ' ref number is returncheck
        checkAdd.RefNumber.SetValue("ReturnCheck")
        ' not printing
        checkAdd.IsToBePrinted.SetValue(False)

        Dim bankFeeLineList As IORItemLineAddList = checkAdd.ORItemLineAddList

        ' this is the check item from app defaults
        Dim bankFeeLine As IORItemLineAdd = bankFeeLineList.Append
        bankFeeLine.ItemLineAdd.ItemRef.ListID.SetValue(app_row.BAD_CHECK_CHECKITEM_LISTID)
        bankFeeLine.ItemLineAdd.Amount.SetValue(BankRow.BANK_FEE_DEFAULT)
        bankFeeLine.ItemLineAdd.Quantity.SetValue(1)

        msgSetResp = SessionManager.DoRequests(MsgSetRequest)
        respList = msgSetResp.ResponseList

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                bounced = True
            Else
                ResponseErr_Misc(resp)
            End If
        Next

        ' inserting note for customer that check bounced
        Try
            qta.CustomerNotes_Insert(CheckRow.CustomerNumber, "Bounced Check Ref #: " & CheckRow.RefNumber & ". Bank Fee of " & FormatCurrency(BankRow.BANK_FEE_DEFAULT) & ". Customer charged " & FormatCurrency(Fee) & ".")
        Catch ex As Exception
            MsgBox("NoteInsert Err: " & ex.Message)
        End Try

        Return bounced
    End Function

    Public Class NewInvObj
        Public CustomerListID
        Public TxnID
        Public BalanceRemaining
    End Class


    Public Sub Payment_MoveToCustomer(ByVal PaymentHistoryRow As ds_Payments.PaymentHistory_DBRow, ByVal NewCustomerNumber As Integer)
        ' need to get current edit sequence first (which function updates row by ref) and list of applied txns
        Dim appliedList As List(Of String) = Payment_GetAppliedTxns(PaymentHistoryRow)

        ' startResetDate is the earliest txnDate this payment we are moving paid for. all invoices with a txn date after this one will have their payments unapplied as well
        Dim startResetDate As Date

        ' if applied list is nothing because this payment wasn't applied to anything, set startResetDate as date of payment
        If (appliedList IsNot Nothing) Then
            Invoices_EarliestCreationDate(appliedList)
        Else
            startResetDate = PaymentHistoryRow.DateReceived
        End If

        ' move payment - after reset payments by inv txnDate on orig customer
        Dim recPayMod As IReceivePaymentMod = MsgSetRequest.AppendReceivePaymentModRq

        ' payment im talking about
        recPayMod.TxnID.SetValue(PaymentHistoryRow.PaymentTxnID)
        recPayMod.EditSequence.SetValue(PaymentHistoryRow.PaymentEditSeq)

        ' who its going to now
        Using ta As New ds_CustomerTableAdapters.QueriesTableAdapter
            recPayMod.CustomerRef.ListID.SetValue(ta.Customer_GetListID(NewCustomerNumber))
        End Using

        ' wiping applied txns
        Dim appliedTxnList As IAppliedToTxnModList = recPayMod.AppliedToTxnModList

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)

            If (resp.StatusCode = 0) Then
                Try
                    ' if response good, update and move payment
                    Dim payRet As IReceivePaymentRet = resp.Detail

                    Using qta As New ds_PaymentsTableAdapters.QueriesTableAdapter
                        qta.PaymentHistory_MovePayToCust(PaymentHistoryRow.PaymentID, NewCustomerNumber, payRet.EditSequence.GetValue)
                    End Using

                    ' need to reset all payments on new customer made after this payment txn date, and then reapply them all


                    ' reset payments on orig customer after this date
                    Payments_ResetAfterDate(PaymentHistoryRow.CustomerNumber, startResetDate)

                    ' TODO: using startResetDate from above, query invoices with a txndate after this, getting linkedtxns.
                    ' if linktxntype is recpayment, add txnid to list. after list compiled for all invoices, query for rec pay edit seq and amount
                    ' mod all payments to unapply and update db edit seqs
                    ' query for open invoices. go down unapplied list and compile large msgsetreq with multiple pay mods
                Catch ex As Exception
                    MessageBox.Show("Error: SQL Stored Proc: PaymentHistory_MovePayToCust", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                ResponseErr_Misc(resp)
            End If
        Next

    End Sub

    Public Function Payment_GetAppliedTxns(ByRef Row As ds_Payments.PaymentHistory_DBRow) As List(Of String)
        ' list im going to gather of applied txns to this payment
        Dim appTxnList As List(Of String) = Nothing

        Dim payQuery As IReceivePaymentQuery = MsgSetRequest.AppendReceivePaymentQueryRq
        payQuery.ORTxnQuery.TxnIDList.Add(Row.PaymentTxnID)

        ' only need edit sequence back
        payQuery.IncludeRetElementList.Add("EditSequence")
        payQuery.IncludeRetElementList.Add("AppliedToTxnRetList")

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        ' loop through response
        For i = 0 To respList.Count
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                Dim payRetList As IReceivePaymentRetList = resp.Detail
                For l = 0 To payRetList.Count - 1
                    Dim payRet As IReceivePaymentRet = payRetList.GetAt(l)

                    ' grabbing edit seq for return
                    Row.PaymentEditSeq = payRet.EditSequence.GetValue

                    If (payRet.AppliedToTxnRetList IsNot Nothing) Then

                        ' looping through applied to txn list to get txn this is applied to, then have to query each to find oldest date
                        Dim appliedTxnList As IAppliedToTxnRetList = payRet.AppliedToTxnRetList
                        For j = 0 To appliedTxnList.Count - 1
                            Dim appTxn As IAppliedToTxnRet = appliedTxnList.GetAt(j)

                            ' add inv id to list of applied txns
                            appTxnList.Add(appTxn.TxnID.GetValue)
                        Next
                    End If
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next

        Return appTxnList
    End Function

    Public Function Invoices_EarliestCreationDate(ByVal InvoiceTxnIDList As List(Of String)) As Date
        ' return date var
        Dim earliestDate As Date = Nothing

        For Each txnID As String In InvoiceTxnIDList
            Dim invQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq
            invQuery.ORInvoiceQuery.TxnIDList.Add(txnID)

            ' only need creation date back
            invQuery.IncludeRetElementList.Add("TxnDate")

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetRequest.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                Dim invRet As IInvoiceRet = resp.Detail

                ' checking if this create date is before the earliest we have so far
                If (invRet.TimeCreated.GetValue < earliestDate) Then
                    earliestDate = invRet.TimeCreated.GetValue
                End If
            Next
        Next

        Return earliestDate
    End Function

    Private Sub Payments_ResetAfterDate(ByVal CustomerNumber As Integer, ByVal AfterDate As Date, ByVal RouteMethod As String)
        ' getting customerlistid
        Dim custListID As String = Nothing
        Using qta As New ds_CustomerTableAdapters.QueriesTableAdapter
            custListID = qta.Customer_GetListID(CustomerNumber)
        End Using

        ' need to get list of rec pay txnID's that pay invoices after this date
        Dim unappliedPaymentDT As New ds_Payments.MovePayment_UnappliedPaymentsDataTable

        ' checking method going after payids
        If (RouteMethod = "Invoices") Then
            ' need to get edit sequences after using this function
            unappliedPaymentDT = Invoicing_PayTxnIDsOnInvsAfterDate(custListID, AfterDate)

            ' get other column values for this table for upcoming mods
            Payments_GetEditSequences(unappliedPaymentDT)
        ElseIf (RouteMethod = "Payments") Then
            ' simple - can query for pays after date and get edit seq there too
            unappliedPaymentDT = Payments_PayTxnIDsAfterDate(custListID, AfterDate)

        End If

        ' unapply all payments in table currently
        Payments_UnapplyFromTable(unappliedPaymentDT)

        ' now need to get list of all open invoices
        Dim openInvoiceDT As ds_Payments.MovePayment_OpenInvoicesDataTable = Invoicing_GetUnpaidTable(custListID)

        ' now need to mod all these payments with a blank attached txn list
        ' also need to get their new edit seq and update the db accordingly
        ' finally, return a datatable of these txns
    End Sub

    Private Function Invoicing_PayTxnIDsOnInvsAfterDate(ByVal CustomerListID As String, ByVal AfterDate As Date) As ds_Payments.MovePayment_UnappliedPaymentsDataTable
        ' return list of pays need to unapply
        Dim unappliedDT As New ds_Payments.MovePayment_UnappliedPaymentsDataTable

        Dim invQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq
        ' setting customer and date
        invQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(CustomerListID)
        ' note qbfc says itll return any from OR on this date forward
        invQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(AfterDate)

        ' making sure getting linked txns to get rec pays used for this inv
        invQuery.IncludeLinkedTxns.SetValue(True)

        ' go
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        ' looping
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)

            ' status check
            If (resp.StatusCode = 0) Then
                Dim invRetList As IInvoiceRetList = resp.Detail

                ' loop to get linked tnxs
                For l = 0 To invRetList.Count - 1
                    Dim invRet As IInvoiceRet = invRetList.GetAt(l)

                    ' loop to get link txns that are rec pays and get their txnids
                    For j = 0 To invRet.LinkedTxnList.Count - 1
                        Dim linkedTxn As ILinkedTxn = invRet.LinkedTxnList.GetAt(j)

                        ' type check
                        If (linkedTxn.TxnType.GetValue = QBFC12Lib.ENTxnType.ttReceivePayment) Then
                            ' add to return table
                            unappliedDT.AddMovePayment_UnappliedPaymentsRow(linkedTxn.TxnID.GetValue, Nothing, Nothing, Nothing, Nothing)

                            unappliedDT.AcceptChanges()
                        End If
                    Next
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next

        Return unappliedDT
    End Function

    Private Sub Payments_GetEditSequences(ByRef UnappliedDT As ds_Payments.MovePayment_UnappliedPaymentsDataTable)
        ' looping through row to build large query to update at end
        For Each row As ds_Payments.MovePayment_UnappliedPaymentsRow In UnappliedDT.Rows
            Dim payQuery As IReceivePaymentQuery = MsgSetRequest.AppendReceivePaymentQueryRq
            payQuery.ORTxnQuery.TxnIDList.Add(row.Pay_TxnID)

            ' only need edit seq back for now - will get txndate and total amount after mod since need new edit seq then anyways
            payQuery.IncludeRetElementList.Add("TxnID")
            payQuery.IncludeRetElementList.Add("TxnDate")
            payQuery.IncludeRetElementList.Add("TotalAmount")
            payQuery.IncludeRetElementList.Add("EditSequence")
        Next

        ' sending grouped request
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)

            ' status check
            If (resp.StatusCode = 0) Then
                Dim payRetList As IReceivePaymentRetList = resp.Detail

                ' loop through each rec pay ret
                For l = 0 To payRetList.Count - 1
                    Dim payRet As IReceivePaymentRet = payRetList.GetAt(l)

                    ' get row from select which returns array, 0 index
                    Dim row As ds_Payments.MovePayment_UnappliedPaymentsRow = UnappliedDT.Select("Pay_TxnID = " & payRet.TxnID.GetValue)(0)
                    row.Pay_EditSeq = payRet.EditSequence.GetValue
                    row.Pay_TxnDate = payRet.TxnDate.GetValue
                    row.Pay_Amount = payRet.TotalAmount.GetValue

                    ' commit changes
                    row.AcceptChanges()
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next

    End Sub

    Private Function Payments_PayTxnIDsAfterDate(ByVal CustomerListID As String, ByVal AfterDate As Date) As ds_Payments.MovePayment_UnappliedPaymentsDataTable
        ' return list of pays need to unapply
        Dim unappliedDT As New ds_Payments.MovePayment_UnappliedPaymentsDataTable

        Dim payQuery As IReceivePaymentQuery = MsgSetRequest.AppendReceivePaymentQueryRq
        ' setting customer and date
        payQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(CustomerListID)
        payQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(AfterDate)

        ' only need a couple things back
        payQuery.IncludeRetElementList.Add("TxnID")
        payQuery.IncludeRetElementList.Add("TxnDate")
        payQuery.IncludeRetElementList.Add("TotalAmount")
        payQuery.IncludeRetElementList.Add("EditSequence")

        ' go
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        ' loop through getting info
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)

            ' status check
            If (resp.StatusCode = 0) Then
                Dim payRetList As IReceivePaymentRetList = resp.Detail

                ' looping through response details to get info i need for table
                For l = 0 To payRetList.Count - 1
                    Dim payRet As IReceivePaymentRet = payRetList.GetAt(l)

                    ' adding to return table
                    unappliedDT.AddMovePayment_UnappliedPaymentsRow(payRet.TxnID.GetValue, payRet.EditSequence.GetValue, payRet.TxnDate.GetValue, payRet.TotalAmount.GetValue, Nothing)
                    unappliedDT.AcceptChanges()
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next


        Return unappliedDT
    End Function

    Private Sub Payments_UnapplyFromTable(ByRef UnappliedDT As ds_Payments.MovePayment_UnappliedPaymentsDataTable)
        ' going to update this table
        For Each row As ds_Payments.MovePayment_UnappliedPaymentsRow In UnappliedDT.Rows
            ' mod to remove
            Dim recPayMod As IReceivePaymentMod = MsgSetRequest.AppendReceivePaymentModRq
            recPayMod.TxnID.SetValue(row.Pay_TxnID)
            recPayMod.EditSequence.SetValue(row.Pay_EditSeq)

            ' need new edit seq and unused amount back for remaining
            recPayMod.IncludeRetElementList.Add("TxnID")
            recPayMod.IncludeRetElementList.Add("EditSequence")
            recPayMod.IncludeRetElementList.Add("UnusedPayment")

            ' submitting with a blank applied list should wipe it
            Dim blankAppliedList As IAppliedToTxnModList = recPayMod.AppliedToTxnModList
        Next row

        ' send request to wipe applied txns
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        ' looping to update dt with new edit seq and remaining 
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)

            ' status check
            If (resp.StatusCode = 0) Then
                Dim payRetList As IReceivePaymentRetList = resp.Detail

                ' loop through each rec pay ret
                For l = 0 To payRetList.Count - 1
                    Dim payRet As IReceivePaymentRet = payRetList.GetAt(l)

                    ' update db
                    Using ta As New ds_PaymentsTableAdapters.QueriesTableAdapter
                        ta.PaymentHistory_UpdateEditSeq(payRet.TxnID.GetValue, payRet.EditSequence.GetValue)
                    End Using

                    ' get row from select which returns array, 0 index
                    Dim row As ds_Payments.MovePayment_UnappliedPaymentsRow = UnappliedDT.Select("Pay_TxnID = " & payRet.TxnID.GetValue)(0)
                    row.Pay_EditSeq = payRet.EditSequence.GetValue
                    row.Remaining = payRet.UnusedPayment.GetValue

                    ' commit changes
                    row.AcceptChanges()
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next
    End Sub

    Private Function Invoicing_GetUnpaidTable(ByVal CustomerListID As String) As ds_Payments.MovePayment_OpenInvoicesDataTable
        ' return table of open invoices and their info
        Dim openInvDT As New ds_Payments.MovePayment_OpenInvoicesDataTable

        Dim invQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq
        ' setting customer and paid status
        invQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(CustomerListID)
        invQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(ENPaidStatus.psNotPaidOnly)

        ' only need a couple values back
        invQuery.IncludeRetElementList.Add("TxnID")
        invQuery.IncludeRetElementList.Add("TxnDate")
        invQuery.IncludeRetElementList.Add("BalanceRemaining")

        ' go
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)

            ' status check
            If (resp.StatusCode = 0) Then
                Dim invRetList As IInvoiceRetList = resp.Detail

                For l = 0 To invRetList.Count - 1
                    Dim invRet As IInvoiceRet = invRetList.GetAt(l)

                    ' adding to table
                    openInvDT.AddMovePayment_OpenInvoicesRow(invRet.TxnID.GetValue, invRet.TxnDate.GetValue, invRet.BalanceRemaining.GetValue, invRet.BalanceRemaining.GetValue)
                    openInvDT.AcceptChanges()
                Next
            Else
                ResponseErr_Misc(resp)
            End If
        Next

        Return openInvDT
    End Function




    Public Function Invoicing_Custom(ByRef CustomerNumber As Integer, ByRef PostDate As Date, ByRef DueDate As Date, ByRef Print As Boolean,
                                  ByVal InvDesc As String, ByRef lineItems As DataSet.CustomInvoice_LineItemsDataTable) As Integer
        Dim historyID As Integer

        ' checking balance of customer
        Dim c_Queries As New QB_Queries2(SessionManager, MsgSetRequest)
        Dim custListID As String = qta.Customer_GetListID(CustomerNumber)
        Dim custBalance As Double = c_Queries.Customer_Balance(custListID)
        c_Queries = Nothing

        ' interfaces needed for invoicing and line items
        Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq
        ' limiting response
        invoiceAdd.IncludeRetElementList.Add("TxnID")
        invoiceAdd.IncludeRetElementList.Add("RefNumber")
        invoiceAdd.IncludeRetElementList.Add("BalanceRemaining")
        invoiceAdd.IncludeRetElementList.Add("TimeCreated")
        invoiceAdd.IncludeRetElementList.Add("Subtotal")

        ' build request
        invoiceAdd.CustomerRef.ListID.SetValue(custListID)
        invoiceAdd.TxnDate.SetValue(PostDate)
        invoiceAdd.DueDate.SetValue(DueDate)
        invoiceAdd.IsToBePrinted.SetValue(Print)

        ' line list
        Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
        ' line item to reuse
        Dim lineItem As IORInvoiceLineAdd
        ' this is default item for custom invoices
        Dim itemListID As String = qta.APP_GetCustomInvItem()


        ' loop through line items
        For Each lineRow As DataSet.CustomInvoice_LineItemsRow In lineItems.Rows
            lineItem = lineList.Append

            lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(itemListID)
            lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineRow.Rate)
            lineItem.InvoiceLineAdd.Quantity.SetValue(1)
            lineItem.InvoiceLineAdd.Desc.SetValue(lineRow.Description)
        Next

        ' description line
        Dim descLine As IORInvoiceLineAdd = lineList.Append
        descLine.InvoiceLineAdd.ItemRef.ListID.Unset()
        descLine.InvoiceLineAdd.ItemRef.FullName.Unset()
        descLine.InvoiceLineAdd.Desc.SetValue(InvDesc)
        descLine.InvoiceLineAdd.Amount.Unset()
        descLine.InvoiceLineAdd.Quantity.Unset()

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode <> 0) Then

                Try
                    ResponseErr_Misc(resp)
                Catch ex As Exception
                    MsgBox("Err_Invoice_Insert: " & ex.Message)
                End Try

            Else
                Dim invRet As IInvoiceRet = resp.Detail

                ' custom invoice history insert
                Try

                    Dim hta As New Report_DataSetTableAdapters.CustomInvoiceHistoryTableAdapter
                    historyID = qta.CustomInvoiceHistory_Insert(CustomerNumber,
                                invRet.TxnID.GetValue,
                                invRet.RefNumber.GetValue,
                                invRet.TimeCreated.GetValue,
                                DueDate,
                                invRet.Subtotal.GetValue)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                ' checking for overpayment usage
                If (invRet.BalanceRemaining.GetValue > 0) Then
                    ' class to keep track of this
                    Dim invObj As New NewInvObj
                    invObj.CustomerListID = custListID
                    invObj.TxnID = invRet.TxnID.GetValue
                    invObj.BalanceRemaining = invRet.BalanceRemaining.GetValue

                    If (custBalance < 0) Then
                        ' check for credits
                        Customer_CheckCredits(invObj)
                        If (invObj.BalanceRemaining > 0) Then
                            ' if balance remain after credits, check for overpayments
                            Customer_CheckOverpayments(invObj)
                        End If
                    End If
                End If
            End If

        Next i

        Return historyID
    End Function
    Public Function Invoicing_Void(ByVal TxnID As String) As Boolean
        ' return bool
        Dim voided As Boolean
        voided = VoidTransactionByTxnID(TxnID, ENTxnVoidType.tvtInvoice)
        Return voided
    End Function

    Public Sub Customer_CheckOverpayments(ByRef newInv As NewInvObj)
        Dim recievePayQuery As IReceivePaymentQuery = MsgSetRequest.AppendReceivePaymentQueryRq

        ' only things i want back
        recievePayQuery.IncludeRetElementList.Add("UnusedPayment")
        recievePayQuery.IncludeRetElementList.Add("TxnID")
        recievePayQuery.IncludeRetElementList.Add("EditSequence")
        recievePayQuery.IncludeRetElementList.Add("AppliedToTxnRet")

        ' passing param here
        recievePayQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(newInv.CustomerListID)
        ' limiting results to last 30 payments
        recievePayQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(30)

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clearMsgSetReq
        MsgSetRequest.ClearRequests()

        ' looping through responseList
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                If (resp.Detail IsNot Nothing) Then
                    Dim recievePayRetList As IReceivePaymentRetList = resp.Detail
                    For l = 0 To recievePayRetList.Count - 1
                        Dim recievePayRet As IReceivePaymentRet = recievePayRetList.GetAt(l)
                        If (recievePayRet IsNot Nothing) Then

                            ' making sure invoice still has balance
                            If (newInv.BalanceRemaining > 0) Then
                                ' checking if UnusedPayment > 0
                                If (recievePayRet.UnusedPayment.GetValue > 0) Then

                                    ' reading through applied to txn ret for upcoming mod
                                    Dim appliedTxnList As IAppliedToTxnRetList = recievePayRet.AppliedToTxnRetList

                                    ' mod the payment for the new invoice
                                    ' need to catch return bool if its paid off
                                    Dim paidOff As Boolean =
                                        Customer_UseOverpayment(recievePayRet.TxnID.GetValue,
                                                   recievePayRet.EditSequence.GetValue,
                                                   recievePayRet.UnusedPayment.GetValue,
                                                   appliedTxnList,
                                                   newInv)

                                    ' exiting if paid off
                                    If (paidOff) Then
                                        Exit For
                                    End If
                                End If
                            End If
                        End If
                    Next l
                End If
            ElseIf (resp.StatusCode = 1) Then
                ' no payments = exit sub
                Exit Sub
            ElseIf (resp.StatusCode > 1) Then
                ResponseErr_Misc(resp)
            End If
        Next i
    End Sub
    Private Function Customer_UseOverpayment(ByVal OverpayTxnID As String,
                               ByVal OverpayEditSeq As String,
                               ByVal OverpayRemain As Double,
                               ByRef AttachedTxns As IAppliedToTxnRetList,
                               ByRef newInv As NewInvObj) As Boolean
        ' this var will be returned after every overpayment to let the calling sub know if it needs to use another
        Dim paidOff As Boolean

        Dim recievePayMod As IReceivePaymentMod = MsgSetRequest.AppendReceivePaymentModRq

        recievePayMod.TxnID.SetValue(OverpayTxnID)
        recievePayMod.EditSequence.SetValue(OverpayEditSeq)

        Dim appliedTxnList As IAppliedToTxnModList = recievePayMod.AppliedToTxnModList
        Dim appliedTxn As IAppliedToTxnMod

        ' readding existing attached txns
        If (AttachedTxns IsNot Nothing) Then
            For i = 0 To AttachedTxns.Count - 1
                appliedTxn = appliedTxnList.Append()
                appliedTxn.TxnID.SetValue(AttachedTxns.GetAt(i).TxnID.GetValue)
                appliedTxn.PaymentAmount.SetValue(AttachedTxns.GetAt(i).Amount.GetValue)
            Next i
        End If

        ' adding newly created inv
        Dim newTxn As IAppliedToTxnMod
        newTxn = appliedTxnList.Append()
        newTxn.TxnID.SetValue(newInv.TxnID)

        ' match to see how much we are applying
        If ((newInv.BalanceRemaining - OverpayRemain) <= 0) Then
            ' overpayment can cover the balance, so applied amount will be balance remaining
            newTxn.PaymentAmount.SetValue(newInv.BalanceRemaining)

            ' updating balance
            newInv.BalanceRemaining = 0
            ' updating return var
            paidOff = True
        Else
            ' balance will remain, so applied amount is the same as remaining overpayment
            newTxn.PaymentAmount.SetValue(OverpayRemain)

            ' updating balance
            newInv.BalanceRemaining = Math.Round((newInv.BalanceRemaining - OverpayRemain), 2)
            ' updating return var
            paidOff = False
        End If


        ' request is fully built, time to send and do response work
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim responseList As IResponseList = msgSetResp.ResponseList

        ' clear msgset
        MsgSetRequest.ClearRequests()

        ' looping through responseList
        For i = 0 To responseList.Count - 1
            Dim resp As IResponse = responseList.GetAt(i)
            If (resp.StatusCode > 0) Then
                ResponseErr_Misc(resp)
            End If
        Next i

        Return paidOff
    End Function
    Public Sub Customer_CheckCredits(ByRef newInv As NewInvObj)
        Dim creditMemoQuery As ICreditMemoQuery = MsgSetRequest.AppendCreditMemoQueryRq

        ' only want these 2 things back
        creditMemoQuery.IncludeRetElementList.Add("CreditRemaining")
        creditMemoQuery.IncludeRetElementList.Add("TxnID")

        ' passing paramater here
        creditMemoQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(newInv.CustomerListID)

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        ' looping through responseList
        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                If (resp.Detail IsNot Nothing) Then
                    Dim creditMemoRetList As ICreditMemoRetList = resp.Detail
                    For l = 0 To creditMemoRetList.Count - 1
                        ' making sure we still need to apply credits before exiting sub
                        If (newInv.BalanceRemaining > 0) Then
                            Dim creditMemoRet As ICreditMemoRet = creditMemoRetList.GetAt(l)
                            ' checking if CreditRemaining > 0
                            If (creditMemoRet.CreditRemaining.GetValue > 0) Then
                                ' catching return bool if balance remains so can exit for loop
                                Dim paidOff As Boolean =
                                Customer_UseCredit(creditMemoRet.TxnID.GetValue, creditMemoRet.CreditRemaining.GetValue,
                                          newInv)

                                ' exit loop
                                If (paidOff) Then
                                    Exit For
                                End If
                            End If
                        End If
                    Next l
                End If
            ElseIf (resp.StatusCode = 1) Then
                'no credits = exit sub
                Exit Sub
            ElseIf (resp.StatusCode > 1) Then
                ResponseErr_Misc(resp)
            End If
        Next i

    End Sub
    Private Function Customer_UseCredit(ByVal CreditTxnID As String, ByVal CreditRemain As Double, ByRef newInv As NewInvObj) As Boolean
        Dim paidOff As Boolean

        ' create interface
        Dim recievePayAdd As IReceivePaymentAdd = MsgSetRequest.AppendReceivePaymentAddRq

        ' set attached cust
        recievePayAdd.CustomerRef.ListID.SetValue(newInv.CustomerListID)

        ' new invoice
        Dim newAttached As IAppliedToTxnAdd = recievePayAdd.ORApplyPayment.AppliedToTxnAddList.Append()
        newAttached.TxnID.SetValue(newInv.TxnID)

        Dim setCredit As ISetCredit = newAttached.SetCreditList.Append()
        setCredit.CreditTxnID.SetValue(CreditTxnID)

        If (newInv.BalanceRemaining > 0) Then
            ' checking how much i can apply
            If ((newInv.BalanceRemaining - CreditRemain) <= 0) Then
                ' credit can cover the balance, so applied amount is the same as balance
                setCredit.AppliedAmount.SetValue(newInv.BalanceRemaining)

                ' updating balance
                newInv.BalanceRemaining = 0
            Else
                ' balance will remain, so applied amount is the same as remaining credit
                setCredit.AppliedAmount.SetValue(CreditRemain)

                ' updating balance
                newInv.BalanceRemaining = Math.Round((newInv.BalanceRemaining - CreditRemain), 2)
            End If
        End If

        ' request is fully built, time to send and do response work
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim responseList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        ' looping through responseList
        For i = 0 To responseList.Count - 1
            Dim resp As IResponse = responseList.GetAt(i)
            If (resp.StatusCode > 0) Then
                ResponseErr_Misc(resp)
            End If
        Next i

        Return paidOff
    End Function

    Public Sub Items_NewServiceItem(ByVal serviceTypeID As Integer, ByVal QBAccountListID As String)
        strow = stta.GetDataByID(serviceTypeID).Rows(0)

        Dim itemAdd As IItemServiceAdd = MsgSetRequest.AppendItemServiceAddRq

        ' setting item stuff
        itemAdd.Name.SetValue(strow.ServiceName)
        itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(strow.ServiceDescription)
        itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(strow.ServiceRate)
        ' passing attached account
        itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(QBAccountListID)

        ' checking active state
        If (strow.ServiceActive = False) Then
            itemAdd.IsActive.SetValue(False)
        Else
            itemAdd.IsActive.SetValue(True)
        End If

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetREq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                Dim itemRet As IItemServiceRet = resp.Detail

                ' update db information with edit sequence and list id
                strow.ServiceListID = itemRet.ListID.GetValue
                strow.ServiceEditSequence = itemRet.EditSequence.GetValue

                ' commit to db
                Try
                    stta.Update(strow)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                ResponseErr_Misc(resp)
                stta.DeleteByID(serviceTypeID)
            End If
        Next i
    End Sub

    Public Sub Items_UpdateServiceItem(ByVal ServiceTypeID As Decimal)
        strow = stta.GetDataByID(ServiceTypeID).Rows(0)

        Dim itemMod As IItemServiceMod = MsgSetRequest.AppendItemServiceModRq

        ' setting item we are talking about
        itemMod.ListID.SetValue(strow.ServiceListID)
        itemMod.EditSequence.SetValue(strow.ServiceEditSequence)

        ' update rate
        itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.ORPrice.Price.SetValue(strow.ServiceRate)
        ' update description
        itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.Desc.SetValue(strow.ServiceDescription)
        ' update active state
        If (strow.ServiceActive = False) Then
            itemMod.IsActive.SetValue(False)
        Else
            itemMod.IsActive.SetValue(True)
        End If

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        ' clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode = 0) Then
                Dim itemRet As IItemServiceRet = resp.Detail

                ' update srvc row edit sequence
                strow.ServiceEditSequence = itemRet.EditSequence.GetValue
                Try
                    stta.Update(strow)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf (resp.StatusCode = 3200) Then
                ' update edit sequence in db
                Items_UpdateEditSeq(ServiceTypeID)
            Else
                ResponseErr_Misc(resp)
            End If
        Next i
    End Sub

    Private Sub Items_UpdateEditSeq(ByVal serviceTypeID As Integer)
        Dim itemQuery As IItemQuery = MsgSetRequest.AppendItemQueryRq

        ' setting listid
        itemQuery.ORListQuery.ListIDList.Add(qta.ServiceTypes_GetListIDByTypeID(serviceTypeID))

        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        'clear msgSetReq
        MsgSetRequest.ClearRequests()

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            Dim itemRetList As IORItemRetList = resp.Detail

            For j = 0 To itemRetList.Count - 1
                Dim itemRet As IORItemRet = itemRetList.GetAt(j)

                If (itemRet.ItemServiceRet IsNot Nothing) Then
                    ' update edit sequence
                    qta.ServiceTypes_UpdateEditSeq(serviceTypeID, itemRet.ItemServiceRet.EditSequence.GetValue)
                    ' redo update
                    Items_UpdateServiceItem(serviceTypeID)
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Public Sub Items_ImportAllMissingListID(ByVal QBAccount As String)
        Dim dt As New DataSet.ServiceTypesDataTable

        ' fill dt
        stta.FillWithAll(dt)

        For Each row As DataSet.ServiceTypesRow In dt.Rows
            If (row.IsServiceListIDNull = True) Then
                Dim itemAdd As IItemServiceAdd = MsgSetRequest.AppendItemServiceAddRq

                ' setting item stuff
                itemAdd.Name.SetValue(row.ServiceName)
                itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(row.ServiceDescription)
                itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(row.ServiceRate)
                ' passing attached account
                itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(QBAccount)

                ' checking active state
                If (row.ServiceActive = False) Then
                    itemAdd.IsActive.SetValue(False)
                Else
                    itemAdd.IsActive.SetValue(True)
                End If

                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList

                ' clear msgSetREq
                MsgSetRequest.ClearRequests()

                For i = 0 To respList.Count - 1
                    Dim resp As IResponse = respList.GetAt(i)
                    If (resp.StatusCode = 0) Then
                        Dim itemRet As IItemServiceRet = resp.Detail

                        ' update db information with edit sequence and list id
                        row.ServiceListID = itemRet.ListID.GetValue
                        row.ServiceEditSequence = itemRet.EditSequence.GetValue

                        ' commit to db
                        Try
                            stta.Update(row)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        ResponseErr_Misc(resp)
                        stta.DeleteByID(row.ServiceTypeID)
                    End If
                Next i
            End If
        Next row

    End Sub
End Class
