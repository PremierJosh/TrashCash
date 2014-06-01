Imports QBFC12Lib
Imports TrashCash.Admin

Namespace Classes


    ' ReSharper disable once InconsistentNaming
    Public Class QB_Procedures
        Protected MsgSetReq As IMsgSetRequest
        Protected SessMgr As QBSessionManager
        Protected HomeForm As TrashCashHome


        'Protected qta As DataSetTableAdapters.QueriesTableAdapter
        Private ReadOnly _cta As ds_CustomerTableAdapters.CustomerTableAdapter
        Private ReadOnly _rsta As ds_RecurringServiceTableAdapters.RecurringServiceTableAdapter

        Public Sub New(ByRef sessionManager As QBSessionManager, ByRef msgSetRequest As IMsgSetRequest, Optional ByRef homeForm As TrashCashHome = Nothing)
            ' setting sess mgr and msgsetreq
            SessMgr = sessionManager
            MsgSetReq = msgSetRequest
            If (homeForm IsNot Nothing) Then
                homeForm = homeForm
            End If

            _cta = New ds_CustomerTableAdapters.CustomerTableAdapter
            _rsta = New ds_RecurringServiceTableAdapters.RecurringServiceTableAdapter
        End Sub

        '    Public Function Customer_New(ByRef custRow As ds_Customer.CustomerRow) As Boolean
        '            ' return bool for success
        '            Dim addOk As Boolean

        '            ' build full name
        '            If (custRow.IsCustomerCompanyNameNull = False) Then
        '                custRow.CustomerFullName = custRow.CustomerCompanyName & " - " & custRow.CustomerNumber
        '            Else
        '                custRow.CustomerFullName = custRow.CustomerLastName & ", " & custRow.CustomerFirstName & " - " & custRow.CustomerNumber
        '            End If

        'retry:
        '            Dim customerAdd As ICustomerAdd = MsgSetReq.AppendCustomerAddRq

        '            ' General Customer Information
        '            customerAdd.Name.SetValue(custRow.CustomerFullName)
        '            If (custRow.IsCustomerCompanyNameNull = False) Then
        '                customerAdd.CompanyName.SetValue(custRow.CustomerCompanyName)
        '            End If
        '            If (custRow.IsCustomerFirstNameNull = False) Then
        '                customerAdd.FirstName.SetValue(custRow.CustomerFirstName)
        '            End If
        '            If (custRow.IsCustomerLastNameNull = False) Then
        '                customerAdd.LastName.SetValue(custRow.CustomerLastName)
        '            End If
        '            customerAdd.Phone.SetValue(custRow.CustomerPhone)

        '            If (custRow.IsCustomerAltPhoneNull = False) Then
        '                customerAdd.AltPhone.SetValue(custRow.CustomerAltPhone)
        '            End If
        '            If (custRow.IsCustomerContactNull = False) Then
        '                customerAdd.Contact.SetValue(custRow.CustomerContact)
        '            End If

        '            ' Billing Address Information
        '            customerAdd.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
        '            If (custRow.IsCustomerBillingAddr2Null = False) Then
        '                customerAdd.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
        '            End If
        '            If (custRow.IsCustomerBillingAddr3Null = False) Then
        '                customerAdd.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
        '            End If
        '            If (custRow.IsCustomerBillingAddr4Null = False) Then
        '                customerAdd.BillAddress.Addr4.SetValue(custRow.CustomerBillingAddr4)
        '            End If
        '            customerAdd.BillAddress.City.SetValue(custRow.CustomerBillingCity)
        '            customerAdd.BillAddress.State.SetValue(custRow.CustomerBillingState)
        '            customerAdd.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

        '            ' sending request
        '            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '            Dim respList As IResponseList = msgSetResp.ResponseList

        '            ' clear requests
        '            MsgSetReq.ClearRequests()

        '            ' looping through response with error checking
        '            For i = 0 To respList.Count - 1
        '                Dim resp As IResponse = respList.GetAt(i)
        '                If (resp.StatusCode = 0) Then
        '                    ' updating return var
        '                    addOk = True

        '                    Dim customerRet As ICustomerRet = resp.Detail
        '                    ' updating the custRow with ListID and EditSeq
        '                    custRow.CustomerListID = customerRet.ListID.GetValue
        '                    custRow.CustomerEditSeq = customerRet.EditSequence.GetValue

        '                    Try
        '                        ' commiting to DB
        '                        _cta.Update(custRow)
        '                    Catch ex As Exception
        '                        MsgBox(ex.Message)
        '                    End Try
        '                ElseIf (resp.StatusCode = 3100) Then

        '                    ' customer already exists with that name
        '                    Dim input As String = InputBox("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.")
        '                    If (input.Length > 0) Then
        '                        custRow.CustomerFullName = input

        '                        Try
        '                            ' commiting to DB
        '                            _cta.Update(custRow)
        '                            GoTo retry
        '                            'Exit Function
        '                        Catch ex As Exception
        '                            MsgBox(ex.Message)
        '                        End Try
        '                    End If
        '                Else
        '                    ' updating return var
        '                    addOk = False

        '                    ' error logging
        '                    GlobalConMgr.ResponseErr_Misc(resp)

        '                    ' delete row
        '                    Using qta As New ds_CustomerTableAdapters.QueriesTableAdapter
        '                        qta.Customer_DeleteByNum(custRow.CustomerNumber)
        '                    End Using

        '                    ' bail out
        '                    Return addOk
        '                End If
        '            Next i

        '            MsgBox("Customer: '" & custRow.CustomerFullName & "' added successfully.")

        '            Return addOk
        '        End Function

        '        Public Sub Customer_Update(ByRef custRow As ds_Customer.CustomerRow, ByVal err As Integer)
        'retry:
        '            Dim customerMod As ICustomerMod = MsgSetReq.AppendCustomerModRq

        '            customerMod.ListID.SetValue(custRow.CustomerListID)
        '            customerMod.EditSequence.SetValue(custRow.CustomerEditSeq)

        '            '''' customer information ''''
        '            customerMod.Name.SetValue(custRow.CustomerFullName)
        '            If (custRow.IsCustomerCompanyNameNull = False) Then
        '                customerMod.CompanyName.SetValue(custRow.CustomerCompanyName)
        '            End If
        '            If (custRow.IsCustomerFirstNameNull = False) Then
        '                customerMod.FirstName.SetValue(custRow.CustomerFirstName)
        '            End If
        '            If (custRow.IsCustomerLastNameNull = False) Then
        '                customerMod.LastName.SetValue(custRow.CustomerLastName)
        '            End If
        '            customerMod.Phone.SetValue(custRow.CustomerPhone)

        '            ' checking possibly blank alt phone
        '            If (custRow.IsCustomerAltPhoneNull = False) Then
        '                customerMod.AltPhone.SetValue(custRow.CustomerAltPhone)
        '            End If
        '            ' checking possibly blank contact field
        '            If (custRow.IsCustomerContactNull = False) Then
        '                customerMod.Contact.SetValue(custRow.CustomerContact)
        '            End If

        '            '''' billing information ''''
        '            ' required billAddr1
        '            customerMod.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
        '            ' checking billAddr2
        '            If (custRow.IsCustomerBillingAddr2Null = False) Then
        '                customerMod.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
        '            End If
        '            ' checking billAddr3
        '            If (custRow.IsCustomerBillingAddr3Null = False) Then
        '                customerMod.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
        '            End If
        '            customerMod.BillAddress.City.SetValue(custRow.CustomerBillingCity)
        '            customerMod.BillAddress.State.SetValue(custRow.CustomerBillingState)
        '            customerMod.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

        '            ' if cell = true, then customer is deactive
        '            If (custRow.CustomerIsDeactive = True) Then
        '                customerMod.IsActive.SetValue(False)
        '            Else
        '                customerMod.IsActive.SetValue(True)
        '            End If

        '            ' doing request and catching in msgSetResp
        '            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '            Dim respList As IResponseList = msgSetResp.ResponseList

        '            ' clear requests
        '            MsgSetReq.ClearRequests()

        '            ' looping through response for errors and writing to error log
        '            For i = 0 To respList.Count - 1
        '                Dim resp As IResponse = respList.GetAt(i)
        '                If (resp.StatusCode = 0) Then
        '                    Dim customerRet As ICustomerRet = resp.Detail

        '                    ' updating EditSeq in the DB
        '                    custRow.BeginEdit()
        '                    custRow.CustomerEditSeq = customerRet.EditSequence.GetValue()
        '                    custRow.EndEdit()

        '                    Try
        '                        ' update table
        '                        _cta.Update(custRow)
        '                    Catch ex As Exception
        '                        MsgBox(ex.Message)
        '                    End Try

        '                    MsgBox("Changes Complete")
        '                ElseIf (resp.StatusCode = 3200) Then
        '                    ' edit sequence missmatch
        '                    Dim q As New QB_Queries(SessMgr, MsgSetReq)
        '                    custRow.BeginEdit()
        '                    custRow.CustomerEditSeq = q.Customer_EditSequence(custRow.CustomerListID)
        '                    custRow.EndEdit()

        '                    Try
        '                        ' update table then retry
        '                        _cta.Update(custRow)
        '                        GoTo retry
        '                    Catch ex As Exception
        '                        MsgBox(ex.Message)
        '                    End Try

        '                Else
        '                    custRow.RejectChanges()
        '                    GlobalConMgr.ResponseErr_Misc(resp)
        '                End If
        '            Next i
        '        End Sub

        ' customer credit create - optional auto apply and sort mode
        'Public Sub Customer_Credit(ByVal customerNumber As Integer, ByVal creditAmount As Double, ByVal reason As String, ByVal itemListID As String, ByVal print As Boolean,
        '                           ByVal autoApply As Boolean, Optional ByVal applyOrder As String = "Desc")

        '    ' getting cuystomer listid
        '    Dim custListID As String = _cta.GetListID(customerNumber)

        '    Dim creditAdd As ICreditMemoAdd = MsgSetReq.AppendCreditMemoAddRq
        '    creditAdd.CustomerRef.ListID.SetValue(custListID)
        '    creditAdd.IsToBePrinted.SetValue(print)

        '    ' creating credit line
        '    Dim creditLine As IORCreditMemoLineAdd = creditAdd.ORCreditMemoLineAddList.Append
        '    creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(itemListID)
        '    creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(creditAmount)

        '    ' desc line
        '    Dim descLine As IORCreditMemoLineAdd = creditAdd.ORCreditMemoLineAddList.Append()
        '    descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
        '    descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
        '    descLine.CreditMemoLineAdd.Desc.SetValue(reason)
        '    descLine.CreditMemoLineAdd.Amount.Unset()
        '    descLine.CreditMemoLineAdd.Quantity.Unset()

        '    ' go
        '    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '    Dim respList As IResponseList = msgSetResp.ResponseList

        '    MsgSetReq.ClearRequests()

        '    For i = 0 To respList.Count - 1
        '        Dim resp As IResponse = respList.GetAt(i)

        '        If (resp.StatusCode = 0) Then
        '            Dim creditRet As ICreditMemoRet = resp.Detail

        '            ' insert record
        '            Using ta As New ds_CustomerTableAdapters.Customer_CreditsTableAdapter
        '                ta.Insert(customerNumber, creditRet.TxnID.GetValue, creditRet.TotalAmount.GetValue, creditRet.TimeCreated.GetValue,
        '                          reason, HomeForm.CurrentUserRow.USER_NAME, False, Nothing, Nothing, Nothing)
        '            End Using

        '            ' check if were going to use
        '            If (autoApply) Then
        '                ' get table of unpaid invoices
        '                Dim dt As ds_Display.QBUnpaidInvoicesDataTable = Invoicing_GetUnpaidTable(custListID)
        '                If (dt.Rows.Count > 0) Then
        '                    ' apply credit
        '                    Credits_PayOpenInvoices(custListID, creditRet.TxnID.GetValue, creditRet.CreditRemaining.GetValue, dt, applyOrder)
        '                End If
        '            End If
        '        Else
        '            GlobalConMgr.ResponseErr_Misc(resp)
        '        End If
        '    Next

        'End Sub

        ' customer credit void
        'Public Sub Customer_Credit_Void(ByRef row As ds_Customer.Customer_CreditsRow, ByVal voidReason As String)
        '    Dim voidTxn As ITxnVoid = MsgSetReq.AppendTxnVoidRq
        '    voidTxn.TxnVoidType.SetValue(ENTxnVoidType.tvtCreditMemo)
        '    voidTxn.TxnID.SetValue(row.CreditTxnID)

        '    ' go
        '    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '    Dim respList As IResponseList = msgSetResp.ResponseList

        '    MsgSetReq.ClearRequests()

        '    For i = 0 To respList.Count - 1
        '        Dim resp As IResponse = respList.GetAt(i)

        '        If (resp.StatusCode = 0) Then
        '            ' update row
        '            row.Voided = True
        '            row.VoidReason = voidReason
        '            row.VoidTime = Date.Now
        '            row.VoidUser = HomeForm.CurrentUserRow.USER_NAME

        '            Using ta As New ds_CustomerTableAdapters.Customer_CreditsTableAdapter
        '                Try
        '                    ta.Update(row)
        '                Catch ex As Exception
        '                    MessageBox.Show("Error Credit Void Update: " & ex.Message, "Sql Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                End Try
        '            End Using
        '        Else
        '            GlobalConMgr.ResponseErr_Misc(resp)
        '        End If
        '    Next

        'End Sub

        'Public Sub RecurringService_EndDateCredit(ByRef row As ds_RecurringService.RecurringServiceRow, ByVal creditAmount As Double,
        '                                          ByVal newEndDate As Date, ByVal billThruDate As Date)
        '    ' getting customer listid
        '    Dim customerListID As String = _cta.GetListID(row.CustomerNumber)


        '    ' getting service listid
        '    Dim serviceRow As ds_Types.ServiceTypesRow
        '    Dim ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
        '    serviceRow = ta.GetDataByID(row.ServiceTypeID).Rows(0)

        '    Dim creditMemoAdd As ICreditMemoAdd = MsgSetReq.AppendCreditMemoAddRq

        '    ' passing listid
        '    creditMemoAdd.CustomerRef.ListID.SetValue(customerListID)
        '    creditMemoAdd.IsToBePrinted.SetValue(False)

        '    Dim creditLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
        '    ' credit line info
        '    creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(serviceRow.ServiceListID)
        '    creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(creditAmount)

        '    ' description line
        '    Dim descLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
        '    descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
        '    descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
        '    descLine.CreditMemoLineAdd.Desc.SetValue("This service has been Invoiced upto " & billThruDate & ". The new End Date overlaps this Invoiced period. | New End Date: " & newEndDate.Date)
        '    descLine.CreditMemoLineAdd.Amount.Unset()
        '    descLine.CreditMemoLineAdd.Quantity.Unset()

        '    ' send request
        '    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '    Dim respList As IResponseList = msgSetResp.ResponseList

        '    ' clear msgsetreq
        '    MsgSetReq.ClearRequests()

        '    For i = 0 To respList.Count - 1
        '        Dim resp As IResponse = respList.GetAt(i)
        '        If (resp.StatusCode = 0) Then

        '            ' insert record
        '            Dim creditMemoRet As ICreditMemoRet = resp.Detail
        '            Try
        '                Using qta As New ds_RecurringServiceTableAdapters.QueriesTableAdapter
        '                    If (row.IsRecurringServiceEndDateNull) Then
        '                        qta.RecurringService_EndDateCredit_Insert(row.RecurringServiceID, Nothing, newEndDate, creditAmount, creditMemoRet.TxnID.GetValue)
        '                    Else
        '                        qta.RecurringService_EndDateCredit_Insert(row.RecurringServiceID, row.RecurringServiceEndDate, newEndDate, creditAmount, creditMemoRet.TxnID.GetValue)
        '                    End If
        '                End Using
        '            Catch ex As Exception
        '                MessageBox.Show("Error inserting Credit History: " & ex.Message, "Error Credit Record Insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End Try

        '            ' update row
        '            row.RecurringServiceEndDate = newEndDate.Date
        '            row.Credited = True
        '            ' commit
        '            Try
        '                _rsta.Update(row)
        '            Catch ex As Exception
        '                MsgBox(ex.Message)
        '            End Try

        '            ' get table of unpaid invoices
        '            Dim openInvDt As ds_Display.QBUnpaidInvoicesDataTable = Invoicing_GetUnpaidTable(customerListID)

        '            ' use new credit to pay newest invoices first
        '            Credits_PayOpenInvoices(customerListID, creditMemoRet.TxnID.GetValue, creditMemoRet.CreditRemaining.GetValue, openInvDt, "Desc")
        '        Else
        '            GlobalConMgr.ResponseErr_Misc(resp)
        '        End If
        '    Next i
        'End Sub

        ' void recurring service end date credit
        'Public Sub RecurringService_EndDateCredit_Void(ByRef row As ds_RecurringService.RecurringService_EndDateCreditsRow, ByVal voidReason As String)
        '    Dim txnVoid As ITxnVoid = MsgSetReq.AppendTxnVoidRq
        '    ' setting credit memo type and id
        '    txnVoid.TxnVoidType.SetValue(ENTxnVoidType.tvtCreditMemo)
        '    txnVoid.TxnID.SetValue(row.CreditMemoTxnID)

        '    ' go
        '    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '    Dim respList As IResponseList = msgSetResp.ResponseList

        '    MsgSetReq.ClearRequests()

        '    For i = 0 To respList.Count - 1
        '        Dim resp As IResponse = respList.GetAt(i)

        '        If (resp.StatusCode = 0) Then
        '            ' updating row
        '            row.Voided = True
        '            row.VoidDateTime = Date.Now
        '            row.VoidReason = voidReason
        '            row.VoidUser = HomeForm.CurrentUserRow.USER_NAME

        '            ' commit
        '            Using ta As New ds_RecurringServiceTableAdapters.RecurringService_EndDateCreditsTableAdapter
        '                ta.Update(row)
        '            End Using
        '        Else
        '            GlobalConMgr.ResponseErr_Misc(resp)
        '        End If
        '    Next
        'End Sub

        ' credit a recurring service on a specific day
        'Public Sub RecurringService_Credit(ByVal recurringServiceID As Integer, ByVal creditAmount As Double, ByVal dateOfCredit As Date, ByVal reason As String)
        '    ' get recurring service row
        '    Dim row As ds_RecurringService.RecurringServiceRow = _rsta.GetDataByID(recurringServiceID).Rows(0)
        '    ' getting customer listid
        '    Dim custListID As String = _cta.GetListID(row.CustomerNumber)
        '    ' getting service type listid
        '    Dim serviceListID As String
        '    Using ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
        '        serviceListID = ta.GetListIDByTypeID(row.ServiceTypeID)
        '    End Using

        '    ' create credit for customer
        '    Dim creditAdd As ICreditMemoAdd = MsgSetReq.AppendCreditMemoAddRq
        '    creditAdd.CustomerRef.ListID.SetValue(custListID)

        '    ' credit line1 = service type
        '    Dim creditLine As IORCreditMemoLineAdd = creditAdd.ORCreditMemoLineAddList.Append()
        '    creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(serviceListID)
        '    creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(creditAmount)

        '    ' desc line
        '    Dim descLine As IORCreditMemoLineAdd = creditAdd.ORCreditMemoLineAddList.Append()
        '    descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
        '    descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
        '    descLine.CreditMemoLineAdd.Desc.SetValue("Credit Issued for Service on " & dateOfCredit & ". Reason: " & reason)
        '    descLine.CreditMemoLineAdd.Amount.Unset()
        '    descLine.CreditMemoLineAdd.Quantity.Unset()

        '    ' go
        '    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '    Dim respList As IResponseList = msgSetResp.ResponseList

        '    MsgSetReq.ClearRequests()

        '    For i = 0 To respList.Count - 1
        '        Dim resp As IResponse = respList.GetAt(i)
        '        If (resp.StatusCode = 0) Then

        '            Dim creditRet As ICreditMemoRet = resp.Detail
        '            ' insert record
        '            Try
        '                Using ta As New ds_RecurringServiceTableAdapters.RecurringService_CreditsTableAdapter
        '                    ta.Insert(recurringServiceID,
        '                              creditRet.TxnID.GetValue,
        '                              dateOfCredit,
        '                              creditRet.TotalAmount.GetValue,
        '                              creditRet.TimeCreated.GetValue,
        '                              reason,
        '                              HomeForm.CurrentUserRow.USER_NAME,
        '                              False,
        '                              Nothing,
        '                              Nothing,
        '                              Nothing)
        '                End Using
        '            Catch ex As Exception
        '                MessageBox.Show("Error: RsCredit Insert: " & ex.Message, "Error Sql Proc Insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End Try

        '            ' now query for open invoices
        '            Dim openInvDT As ds_Display.QBUnpaidInvoicesDataTable = Invoicing_GetUnpaidTable(custListID)
        '            ' use new credit for these
        '            Credits_PayOpenInvoices(custListID, creditRet.TxnID.GetValue, creditRet.CreditRemaining.GetValue, openInvDT, "Asc")
        '        Else
        '            GlobalConMgr.ResponseErr_Misc(resp)
        '        End If
        '    Next


        'End Sub

        ' sub to use newly created credit to pay invoices using the move payment open inv table
        'Private Sub Credits_PayOpenInvoices(ByVal customerListID As String, ByVal creditTxnID As String, ByVal availAmount As Double, ByRef openInvoiceDT As ds_Display.QBUnpaidInvoicesDataTable, ByVal applyOrder As String)
        '    ' making sure we have rows
        '    If (openInvoiceDT.Rows.Count > 0) Then
        '        ' create data view that is sorted depending on the direction paramater Asc or Desc
        '        Dim dvInvoices As New DataView(openInvoiceDT, "", "Inv_TxnDate " & applyOrder, DataViewRowState.CurrentRows)

        '        ' var going to keep track of remaining credit
        '        Dim creditRemain As Double = availAmount

        '        ' payAdd to use credit
        '        Dim payAdd As IReceivePaymentAdd = MsgSetReq.AppendReceivePaymentAddRq
        '        payAdd.CustomerRef.ListID.SetValue(customerListID)

        '        For Each row As ds_Display.QBUnpaidInvoicesRow In dvInvoices.Table.Rows
        '            ' making sure we have credit still
        '            If (creditRemain > 0) Then
        '                Dim newAttached As IAppliedToTxnAdd = payAdd.ORApplyPayment.AppliedToTxnAddList.Append()
        '                newAttached.TxnID.SetValue(row.Inv_TxnID)

        '                'attaching credit
        '                Dim setCredit As ISetCredit = newAttached.SetCreditList.Append()
        '                setCredit.CreditTxnID.SetValue(creditTxnID)

        '                ' checking how much i can apply
        '                If (row.Remaining >= creditRemain) Then
        '                    setCredit.AppliedAmount.SetValue(creditRemain)
        '                    ' update remaining amount
        '                    creditRemain = 0
        '                    row.Remaining = row.Remaining - creditRemain
        '                Else
        '                    setCredit.AppliedAmount.SetValue(row.Remaining)
        '                    ' update remaining amount
        '                    creditRemain = creditRemain - row.Remaining
        '                    row.Remaining = 0
        '                End If
        '            End If
        '        Next

        '        ' go
        '        Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '        Dim respList As IResponseList = msgSetResp.ResponseList

        '        MsgSetReq.ClearRequests()

        '        For i = 0 To respList.Count - 1
        '            Dim resp As IResponse = respList.GetAt(i)

        '            ' resp wont = 1 since not a query
        '            If (resp.StatusCode <> 0) Then
        '                GlobalConMgr.ResponseErr_Misc(resp)
        '            End If
        '        Next
        '    End If
        'End Sub

        ' void a recurring service credit
        'Public Sub RecurringService_Credit_Void(ByVal recurringServiceCreditID As Integer, ByVal voidReason As String)
        '    Dim ta As New ds_RecurringServiceTableAdapters.RecurringService_CreditsTableAdapter
        '    Dim row As ds_RecurringService.RecurringService_CreditsRow = ta.GetDataByCreditID(recurringServiceCreditID).Rows(0)

        '    If (Not row.Voided) Then
        '        Dim txnVoid As ITxnVoid = MsgSetReq.AppendTxnVoidRq

        '        ' talking about credit
        '        txnVoid.TxnVoidType.SetValue(ENTxnVoidType.tvtCreditMemo)
        '        txnVoid.TxnID.SetValue(row.CreditMemoTxnID)

        '        ' go
        '        Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
        '        Dim respList As IResponseList = msgSetResp.ResponseList

        '        MsgSetReq.ClearRequests()

        '        For i = 0 To respList.Count - 1
        '            Dim resp As IResponse = respList.GetAt(i)

        '            If (resp.StatusCode = 0) Then
        '                ' credit voided: update row
        '                row.Voided = True
        '                row.VoidReason = voidReason
        '                row.VoidTime = Date.Now
        '                row.VoidUser = HomeForm.CurrentUserRow.USER_NAME

        '                Try
        '                    ta.Update(row)
        '                Catch ex As Exception
        '                    MsgBox("Credit Row Update SQL Error: " & ex.Message)
        '                End Try
        '            Else
        '                GlobalConMgr.ResponseErr_Misc(resp)
        '            End If
        '        Next
        '    End If
        'End Sub

        Public Function Customer_BounceCheck(ByVal checkRow As ds_Payments.PaymentHistory_DBRow, ByVal bankRow As ds_Payments.BAD_CHECK_BANKSRow, ByVal fee As Double) As Boolean
            ' return bool
            Dim bounced As Boolean

            ' getting customer listid
            Dim custListID As String = _cta.GetListID(checkRow.CustomerNumber)

            ' need to do 2 things:
            ' 1. invoice customer for bounced check amount and our fee
            ' 2. checkadd for bank

            ' 1. invoice first
            Dim invoiceAdd As IInvoiceAdd = MsgSetReq.AppendInvoiceAddRq

            ' going to need app defaults row for items
            Dim appRow As ds_Application.APP_SETTINGSRow
            Dim appTA As New ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter
            appRow = appTA.GetData().Rows(0)

            invoiceAdd.CustomerRef.ListID.SetValue(custListID)
            invoiceAdd.IsToBePrinted.SetValue(True)

            ' var to hold line items
            Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList

            ' first line item will be for the bounced check amount
            Dim checkLine As IORInvoiceLineAdd = lineList.Append
            checkLine.InvoiceLineAdd.ItemRef.ListID.SetValue(bankRow.QB_BANK_INV_ITEM_LISTID)
            checkLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(checkRow.Amount)
            checkLine.InvoiceLineAdd.Quantity.SetValue(1)
            ' setting description
            checkLine.InvoiceLineAdd.Desc.SetValue("Bounced Check #: " & checkRow.RefNumber & ". Received on " & checkRow.DateReceived.Date & " in the amount of " & FormatCurrency(checkRow.Amount) & ".")

            ' 2nd line till be for the fee we are charging the customer
            Dim feeLine As IORInvoiceLineAdd = lineList.Append
            feeLine.InvoiceLineAdd.ItemRef.ListID.SetValue(appRow.BAD_CHECK_CUSTITEM_LISTID)
            feeLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(fee)
            feeLine.InvoiceLineAdd.Quantity.SetValue(1)

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    ' update pay history table and set assoc row to bounced
                    Try
                        Using qta As New ds_PaymentsTableAdapters.QueriesTableAdapter
                            qta.PaymentHistory_SetBounced(checkRow.PaymentID, HomeForm.CurrentUserRow.USER_NAME)
                        End Using

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                    Return bounced
                End If
            Next

            ' doing checkadd to pay bank fee
            Dim checkAdd As ICheckAdd = MsgSetReq.AppendCheckAddRq

            'account ref is bank paying from
            checkAdd.AccountRef.ListID.SetValue(bankRow.QB_BANK_LISTID)
            ' payee is vendor
            checkAdd.PayeeEntityRef.ListID.SetValue(bankRow.QB_VENDOR_LISTID)
            ' ref number is returncheck
            checkAdd.RefNumber.SetValue("ReturnCheck")
            ' not printing
            checkAdd.IsToBePrinted.SetValue(False)

            Dim bankFeeLineList As IORItemLineAddList = checkAdd.ORItemLineAddList

            ' this is the check item from app defaults
            Dim bankFeeLine As IORItemLineAdd = bankFeeLineList.Append
            bankFeeLine.ItemLineAdd.ItemRef.ListID.SetValue(appRow.BAD_CHECK_CHECKITEM_LISTID)
            bankFeeLine.ItemLineAdd.Amount.SetValue(bankRow.BANK_FEE_DEFAULT)
            bankFeeLine.ItemLineAdd.Quantity.SetValue(1)

            msgSetResp = SessMgr.DoRequests(MsgSetReq)
            respList = msgSetResp.ResponseList

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    bounced = True
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

            ' inserting note for customer that check bounced
            Try
                Using ta As New ds_CustomerTableAdapters.CustomerNotesTableAdapter
                    ta.CustomerNotes_Insert(checkRow.CustomerNumber, "Bounced Check Ref #: " & checkRow.RefNumber & ". Bank Fee of " & FormatCurrency(bankRow.BANK_FEE_DEFAULT) & ". Customer charged " & FormatCurrency(fee) & ".")
                End Using
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


        Public Sub Payment_MoveToCustomer(ByVal paymentHistoryRow As ds_Payments.PaymentHistory_DBRow, ByVal newCustomerNumber As Integer)
            ' need to get current edit sequence first (which function updates row by ref) and list of applied txns
            Dim appliedList As List(Of String) = Payment_GetAppliedTxns(paymentHistoryRow)

            ' startResetDate is the earliest txnDate this payment we are moving paid for. all invoices with a txn date after this one will have their payments unapplied as well
            Dim startResetDate As Date

            ' if applied list is nothing because this payment wasn't applied to anything, set startResetDate as date of payment
            If (appliedList IsNot Nothing) Then
                startResetDate = Invoices_EarliestCreationDate(appliedList)
            Else
                startResetDate = paymentHistoryRow.DateReceived
            End If

            ' move payment - after reset payments by inv txnDate on orig customer
            Dim recPayMod As IReceivePaymentMod = MsgSetReq.AppendReceivePaymentModRq

            ' payment im talking about
            recPayMod.TxnID.SetValue(paymentHistoryRow.PaymentTxnID)
            recPayMod.EditSequence.SetValue(paymentHistoryRow.PaymentEditSeq)

            ' only need edit seq back
            recPayMod.IncludeRetElementList.Add("EditSequence")

            ' who its going to now
            recPayMod.CustomerRef.ListID.SetValue(_cta.GetListID(newCustomerNumber))

            ' wiping applied txns
            ' ReSharper disable once UnusedVariable
            Dim appliedTxnList As IAppliedToTxnModList = recPayMod.AppliedToTxnModList

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)

                If (resp.StatusCode = 0) Then
                    ' if response good, update and move payment
                    Dim payRet As IReceivePaymentRet = resp.Detail

                    Try
                        Using qta As New ds_PaymentsTableAdapters.QueriesTableAdapter
                            qta.PaymentHistory_MovePayToCust(paymentHistoryRow.PaymentID, newCustomerNumber, payRet.EditSequence.GetValue)
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("PaymentHistory_MovePayToCust: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Try
                        ' need to reset all payments on new customer made after this payment txn date, and then reapply them all
                        Payments_ResetAfterDate(newCustomerNumber, paymentHistoryRow.DateReceived, "Payments")
                    Catch ex As Exception
                        MessageBox.Show("Error Reset Payments New Customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Try
                        ' reset payments on invoices from orig customer after this date
                        Payments_ResetAfterDate(paymentHistoryRow.CustomerNumber, startResetDate, "Invoices")
                    Catch ex As Exception
                        MessageBox.Show("Error Reset Payments Old Customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

        End Sub

        Public Function Payment_GetAppliedTxns(ByRef row As ds_Payments.PaymentHistory_DBRow) As List(Of String)
            ' list im going to gather of applied txns to this payment
            Dim appTxnList As List(Of String) = Nothing

            Dim payQuery As IReceivePaymentQuery = MsgSetReq.AppendReceivePaymentQueryRq
            payQuery.ORTxnQuery.TxnIDList.Add(row.PaymentTxnID)

            ' only need edit sequence back
            payQuery.IncludeRetElementList.Add("EditSequence")
            payQuery.IncludeRetElementList.Add("AppliedToTxnRetList")

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

            ' loop through response
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    Dim payRetList As IReceivePaymentRetList = resp.Detail
                    For l = 0 To payRetList.Count - 1
                        Dim payRet As IReceivePaymentRet = payRetList.GetAt(l)

                        ' grabbing edit seq for return
                        row.PaymentEditSeq = payRet.EditSequence.GetValue

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
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

            Return appTxnList
        End Function

        Public Function Invoices_EarliestCreationDate(ByVal invoiceTxnIDList As List(Of String)) As Date
            ' return date var
            Dim earliestDate As Date = Nothing

            For Each txnID As String In invoiceTxnIDList
                Dim invQuery As IInvoiceQuery = MsgSetReq.AppendInvoiceQueryRq
                invQuery.ORInvoiceQuery.TxnIDList.Add(txnID)

                ' only need creation date back
                invQuery.IncludeRetElementList.Add("TxnDate")

                Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
                Dim respList As IResponseList = msgSetResp.ResponseList

                MsgSetReq.ClearRequests()

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

        Private Sub Payments_ResetAfterDate(ByVal customerNumber As Integer, ByVal afterDate As Date, ByVal routeMethod As String)
            ' getting customerlistid
            Dim custListID As String = _cta.GetListID(customerNumber)

            ' need to get list of rec pay txnID's that pay invoices after this date
            Dim unappliedPaymentDT As New ds_Display.QBUnappliedPaymentsDataTable

            ' checking method going after payids
            If (routeMethod = "Invoices") Then
                ' get invoices after this date and payments ids on them
                unappliedPaymentDT = Invoicing_PayTxnIDsOnInvsAfterDate(custListID, afterDate)

            ElseIf (routeMethod = "Payments") Then
                ' simple - can query for pays after date and get edit seq there too
                unappliedPaymentDT = Payments_PayTxnIDsAfterDate(custListID, afterDate)
            End If

            ' if we have no payments that need to be unapplied, exit sub
            If (unappliedPaymentDT.Rows.Count = 0) Then
                Exit Sub
            End If

            ' if we went the inv method to get payments, we need edit sequences
            If (routeMethod = "Invoices") Then
                Payments_GetEditSequences(unappliedPaymentDT)
            End If


            ' unapply all payments in table currently
            Payments_UnapplyFromTable(unappliedPaymentDT)

            ' now need to get list of all open invoices
            Dim openInvoiceDT As ds_Display.QBUnpaidInvoicesDataTable = Invoicing_GetUnpaidTable(custListID)

            ' making sure we have rows in both tables, otherwise just end procedure
            If (unappliedPaymentDT.Rows.Count > 0) Then
                If (openInvoiceDT.Rows.Count > 0) Then
                    ' now use the unapplied table to pay invoices in the open inv table
                    Payments_ApplyFromTblToTbl(unappliedPaymentDT, openInvoiceDT)
                End If
            End If

        End Sub

        Private Function Invoicing_PayTxnIDsOnInvsAfterDate(ByVal customerListID As String, ByVal afterDate As Date) As ds_Display.QBUnappliedPaymentsDataTable
            ' return list of pays need to unapply
            Dim unappliedDT As New ds_Display.QBUnappliedPaymentsDataTable

            Dim invQuery As IInvoiceQuery = MsgSetReq.AppendInvoiceQueryRq
            ' setting customer and date
            invQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
            ' note qbfc says itll return any from OR on this date forward
            invQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(afterDate)

            ' making sure getting linked txns to get rec pays used for this inv
            invQuery.IncludeLinkedTxns.SetValue(True)

            ' go
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

            ' looping
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)

                ' status check
                If (resp.StatusCode = 0) Then
                    Dim invRetList As IInvoiceRetList = resp.Detail

                    ' loop to get linked tnxs
                    For l = 0 To invRetList.Count - 1
                        Dim invRet As IInvoiceRet = invRetList.GetAt(l)

                        ' making sure we have linked txns
                        If (invRet.LinkedTxnList IsNot Nothing) Then
                            If (invRet.LinkedTxnList.Count > 0) Then

                                ' loop to get link txns that are rec pays and get their txnids
                                For j = 0 To invRet.LinkedTxnList.Count - 1
                                    Dim linkedTxn As ILinkedTxn = invRet.LinkedTxnList.GetAt(j)

                                    ' type check
                                    If (linkedTxn.TxnType.GetValue = QBFC12Lib.ENTxnType.ttReceivePayment) Then
                                        ' add to return table
                                        unappliedDT.AddQBUnappliedPaymentsRow(linkedTxn.TxnID.GetValue, Nothing, Nothing, Nothing, Nothing)

                                        unappliedDT.AcceptChanges()
                                    End If
                                Next
                            End If
                        End If
                    Next
                ElseIf (resp.StatusCode <> 1) Then
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

            Return unappliedDT
        End Function

        Private Sub Payments_GetEditSequences(ByRef unappliedDT As ds_Display.QBUnappliedPaymentsDataTable)
            ' looping through row to build large query to update at end
            For Each row As ds_Display.QBUnappliedPaymentsRow In unappliedDT.Rows
                Dim payQuery As IReceivePaymentQuery = MsgSetReq.AppendReceivePaymentQueryRq
                payQuery.ORTxnQuery.TxnIDList.Add(row.Pay_TxnID)

                ' only need edit seq back for now - will get txndate and total amount after mod since need new edit seq then anyways
                payQuery.IncludeRetElementList.Add("TxnID")
                payQuery.IncludeRetElementList.Add("TxnDate")
                payQuery.IncludeRetElementList.Add("TotalAmount")
                payQuery.IncludeRetElementList.Add("EditSequence")
            Next

            ' sending grouped request
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)

                ' status check
                If (resp.StatusCode = 0) Then
                    Dim payRetList As IReceivePaymentRetList = resp.Detail

                    ' loop through each rec pay ret
                    For l = 0 To payRetList.Count - 1
                        Dim payRet As IReceivePaymentRet = payRetList.GetAt(l)

                        ' get row from select which returns array, 0 index
                        Dim row As ds_Display.QBUnappliedPaymentsRow = unappliedDT.Select("Pay_TxnID LIKE '" & payRet.TxnID.GetValue & "'")(0)
                        row.Pay_EditSeq = payRet.EditSequence.GetValue
                        row.Pay_TxnDate = payRet.TxnDate.GetValue
                        row.Pay_Amount = payRet.TotalAmount.GetValue

                        ' commit changes
                        row.AcceptChanges()
                    Next
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

        End Sub

        Private Function Payments_PayTxnIDsAfterDate(ByVal customerListID As String, ByVal afterDate As Date) As ds_Display.QBUnappliedPaymentsDataTable
            ' return list of pays need to unapply
            Dim unappliedDT As New ds_Display.QBUnappliedPaymentsDataTable

            Dim payQuery As IReceivePaymentQuery = MsgSetReq.AppendReceivePaymentQueryRq
            ' setting customer and date
            payQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
            payQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(afterDate)

            ' only need a couple things back
            payQuery.IncludeRetElementList.Add("TxnID")
            payQuery.IncludeRetElementList.Add("TxnDate")
            payQuery.IncludeRetElementList.Add("TotalAmount")
            payQuery.IncludeRetElementList.Add("EditSequence")

            ' go
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

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
                        unappliedDT.AddQBUnappliedPaymentsRow(payRet.TxnID.GetValue, payRet.EditSequence.GetValue, payRet.TxnDate.GetValue, payRet.TotalAmount.GetValue, Nothing)
                        unappliedDT.AcceptChanges()
                    Next
                ElseIf (resp.StatusCode <> 1) Then
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next


            Return unappliedDT
        End Function

        Private Sub Payments_UnapplyFromTable(ByRef unappliedDT As ds_Display.QBUnappliedPaymentsDataTable)
            ' going to update this table
            For Each row As ds_Display.QBUnappliedPaymentsRow In unappliedDT.Rows
                ' mod to remove
                Dim recPayMod As IReceivePaymentMod = MsgSetReq.AppendReceivePaymentModRq
                recPayMod.TxnID.SetValue(row.Pay_TxnID)
                recPayMod.EditSequence.SetValue(row.Pay_EditSeq)

                ' need new edit seq and unused amount back for remaining
                recPayMod.IncludeRetElementList.Add("TxnID")
                recPayMod.IncludeRetElementList.Add("EditSequence")
                recPayMod.IncludeRetElementList.Add("UnusedPayment")

                ' submitting with a blank applied list should wipe it
                ' ReSharper disable once UnusedVariable
                Dim blankAppliedList As IAppliedToTxnModList = recPayMod.AppliedToTxnModList
            Next row

            ' fixing onError - rollback txns if errors
            MsgSetReq.Attributes.OnError = ENRqOnError.roeStop

            ' send request to wipe applied txns
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

            ' looping to update dt with new edit seq and remaining 
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)

                ' status check
                If (resp.StatusCode = 0) Then
                    Dim payRet As IReceivePaymentRet = resp.Detail

                    ' update db
                    Using ta As New ds_PaymentsTableAdapters.QueriesTableAdapter
                        ta.PaymentHistory_UpdateEditSeq(payRet.TxnID.GetValue, payRet.EditSequence.GetValue)
                    End Using

                    ' get row from select which returns array, 0 index
                    Dim row As ds_Display.QBUnappliedPaymentsRow = unappliedDT.Select("Pay_TxnID LIKE '" & payRet.TxnID.GetValue & "'")(0)
                    row.Pay_EditSeq = payRet.EditSequence.GetValue
                    row.Remaining = payRet.UnusedPayment.GetValue

                    ' commit changes
                    row.AcceptChanges()
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next
        End Sub

        Private Function Invoicing_GetUnpaidTable(ByVal customerListID As String) As ds_Display.QBUnpaidInvoicesDataTable
            ' return table of open invoices and their info
            Dim openInvDT As New ds_Display.QBUnpaidInvoicesDataTable

            Dim invQuery As IInvoiceQuery = MsgSetReq.AppendInvoiceQueryRq
            ' setting customer and paid status
            invQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
            invQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(ENPaidStatus.psNotPaidOnly)

            ' only need a couple values back
            invQuery.IncludeRetElementList.Add("TxnID")
            invQuery.IncludeRetElementList.Add("TxnDate")
            invQuery.IncludeRetElementList.Add("BalanceRemaining")

            ' go
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)

                ' status check
                If (resp.StatusCode = 0) Then
                    Dim invRetList As IInvoiceRetList = resp.Detail

                    For l = 0 To invRetList.Count - 1
                        Dim invRet As IInvoiceRet = invRetList.GetAt(l)

                        ' adding to table
                        openInvDT.AddQBUnpaidInvoicesRow(invRet.TxnID.GetValue, invRet.TxnDate.GetValue, invRet.BalanceRemaining.GetValue, invRet.BalanceRemaining.GetValue)
                        openInvDT.AcceptChanges()
                    Next
                ElseIf (resp.StatusCode <> 1) Then
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

            Return openInvDT
        End Function

        Private Sub Payments_ApplyFromTblToTbl(ByRef unappliedPaymentDT As ds_Display.QBUnappliedPaymentsDataTable, ByRef openInvoiceDT As ds_Display.QBUnpaidInvoicesDataTable)
            ' dataview for unapplied payments sorted by date
            Dim dvPay As New DataView(unappliedPaymentDT, "", "Pay_TxnDate ASC", DataViewRowState.CurrentRows)
            Dim dvInv As New DataView(openInvoiceDT, "", "Inv_TxnDate ASC", DataViewRowState.CurrentRows)

            For Each payRow As ds_Display.QBUnappliedPaymentsRow In dvPay.Table.Rows
                If (payRow.Remaining > 0) Then
                    ' going to mod this payment and append as many invoices as it can pay onto its apllied to txn list
                    Dim payMod As IReceivePaymentMod = MsgSetReq.AppendReceivePaymentModRq
                    payMod.TxnID.SetValue(payRow.Pay_TxnID)
                    payMod.EditSequence.SetValue(payRow.Pay_EditSeq)

                    ' only need edit seq and amount remaining back
                    payMod.IncludeRetElementList.Add("TxnID")
                    payMod.IncludeRetElementList.Add("EditSequence")
                    payMod.IncludeRetElementList.Add("UnusedPayment")

                    ' applied txn list
                    Dim appliedList As IAppliedToTxnModList = payMod.AppliedToTxnModList

                    For Each invRow As ds_Display.QBUnpaidInvoicesRow In dvInv.Table.Rows
                        ' making sure inv still needs to be paid
                        If (invRow.Remaining > 0) Then
                            Dim appliedItem As IAppliedToTxnMod = appliedList.Append

                            ' setting inv txn id
                            appliedItem.TxnID.SetValue(invRow.Inv_TxnID)

                            ' checking how much we can apply
                            If (payRow.Remaining >= invRow.Remaining) Then
                                ' payment is greater or the same as inv remaining so can use all remaining on inv
                                appliedItem.PaymentAmount.SetValue(invRow.Remaining)
                                ' update payment remaining
                                payRow.Remaining = payRow.Remaining - invRow.Remaining
                            Else
                                ' pay row is not enough to pay remaining on invoice, so applied amount will be pay remaining
                                appliedItem.PaymentAmount.SetValue(payRow.Remaining)
                                ' update pay remaining
                                payRow.Remaining = 0
                            End If
                        End If
                    Next

                    ' go
                    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
                    Dim respList As IResponseList = msgSetResp.ResponseList

                    MsgSetReq.ClearRequests()

                    For i = 0 To respList.Count - 1
                        Dim resp As IResponse = respList.GetAt(i)

                        ' status check
                        If (resp.StatusCode = 0) Then
                            Dim payRet As IReceivePaymentRet = resp.Detail

                            ' update edit seq in pay history
                            Using ta As New ds_PaymentsTableAdapters.QueriesTableAdapter
                                ta.PaymentHistory_UpdateEditSeq(payRet.TxnID.GetValue, payRet.EditSequence.GetValue)
                            End Using

                            ' update editseq and remaining in dt
                            payRow.Remaining = payRet.UnusedPayment.GetValue
                            payRow.Pay_EditSeq = payRet.EditSequence.GetValue

                        Else
                            GlobalConMgr.ResponseErr_Misc(resp)
                        End If
                    Next

                End If
            Next payRow
        End Sub




        'Public Function Invoicing_Custom(ByRef CustomerNumber As Integer, ByRef PostDate As Date, ByRef DueDate As Date, ByRef Print As Boolean,
        '                              ByVal InvDesc As String, ByRef lineItems As DataSet.CustomInvoice_LineItemsDataTable) As Integer
        '    Dim historyID As Integer

        '    ' checking balance of customer
        '    Dim c_Queries As New QB_Queries(SessMgr, MsgSetRequest)
        '    Dim custListID As String = cta.GetListID(CustomerNumber)

        '    Dim custBalance As Double = c_Queries.Customer_Balance(custListID)
        '    c_Queries = Nothing

        '    ' interfaces needed for InvoicingForm and line items
        '    Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq
        '    ' limiting response
        '    invoiceAdd.IncludeRetElementList.Add("TxnID")
        '    invoiceAdd.IncludeRetElementList.Add("RefNumber")
        '    invoiceAdd.IncludeRetElementList.Add("BalanceRemaining")
        '    invoiceAdd.IncludeRetElementList.Add("TimeCreated")
        '    invoiceAdd.IncludeRetElementList.Add("Subtotal")

        '    ' build request
        '    invoiceAdd.CustomerRef.ListID.SetValue(custListID)
        '    invoiceAdd.TxnDate.SetValue(PostDate)
        '    invoiceAdd.DueDate.SetValue(DueDate)
        '    invoiceAdd.IsToBePrinted.SetValue(Print)

        '    ' line list
        '    Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
        '    ' line item to reuse
        '    Dim lineItem As IORInvoiceLineAdd
        '    ' this is default item for custom invoices
        '    'Dim itemListID As String = qta.APP_GetCustomInvItem()
        '    Dim itemListID As String = "this"


        '    ' loop through line items
        '    For Each lineRow As DataSet.CustomInvoice_LineItemsRow In lineItems.Rows
        '        lineItem = lineList.Append

        '        lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(itemListID)
        '        lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineRow.Rate)
        '        lineItem.InvoiceLineAdd.Quantity.SetValue(1)
        '        lineItem.InvoiceLineAdd.Desc.SetValue(lineRow.Description)
        '    Next

        '    ' description line
        '    Dim descLine As IORInvoiceLineAdd = lineList.Append
        '    descLine.InvoiceLineAdd.ItemRef.ListID.Unset()
        '    descLine.InvoiceLineAdd.ItemRef.FullName.Unset()
        '    descLine.InvoiceLineAdd.Desc.SetValue(InvDesc)
        '    descLine.InvoiceLineAdd.Amount.Unset()
        '    descLine.InvoiceLineAdd.Quantity.Unset()

        '    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetRequest)
        '    Dim respList As IResponseList = msgSetResp.ResponseList

        '    MsgSetRequest.ClearRequests()

        '    For i = 0 To respList.Count - 1
        '        Dim resp As IResponse = respList.GetAt(i)
        '        If (resp.StatusCode <> 0) Then

        '            Try
        '                ResponseErr_Misc(resp)
        '            Catch ex As Exception
        '                MsgBox("Err_Invoice_Insert: " & ex.Message)
        '            End Try

        '        Else
        '            Dim invRet As IInvoiceRet = resp.Detail

        '            ' custom invoice history insert
        '            Try

        '                Dim hta As New Report_DataSetTableAdapters.CustomInvoiceHistoryTableAdapter
        '                'historyID = qta.CustomInvoiceHistory_Insert(CustomerNumber,
        '                '            invRet.TxnID.GetValue,
        '                '            invRet.RefNumber.GetValue,
        '                '            invRet.TimeCreated.GetValue,
        '                '            DueDate,
        '                '            invRet.Subtotal.GetValue)
        '            Catch ex As Exception
        '                MsgBox(ex.Message)
        '            End Try

        '            ' checking for overpayment usage
        '            If (invRet.BalanceRemaining.GetValue > 0) Then
        '                ' class to keep track of this
        '                Dim invObj As New NewInvObj
        '                invObj.CustomerListID = custListID
        '                invObj.TxnID = invRet.TxnID.GetValue
        '                invObj.BalanceRemaining = invRet.BalanceRemaining.GetValue

        '                If (custBalance < 0) Then
        '                    ' check for credits
        '                    Customer_CheckCredits(invObj)
        '                    If (invObj.BalanceRemaining > 0) Then
        '                        ' if balance remain after credits, check for overpayments
        '                        Customer_CheckOverpayments(invObj)
        '                    End If
        '                End If
        '            End If
        '        End If

        '    Next i

        '    Return historyID
        'End Function

        Public Sub Customer_CheckOverpayments(ByRef newInv As NewInvObj)
            Dim recievePayQuery As IReceivePaymentQuery = MsgSetReq.AppendReceivePaymentQueryRq

            ' only things i want back
            recievePayQuery.IncludeRetElementList.Add("UnusedPayment")
            recievePayQuery.IncludeRetElementList.Add("TxnID")
            recievePayQuery.IncludeRetElementList.Add("EditSequence")
            recievePayQuery.IncludeRetElementList.Add("AppliedToTxnRet")

            ' passing param here
            recievePayQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(newInv.CustomerListID)
            ' limiting results to last 30 payments
            recievePayQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(30)

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clearMsgSetReq
            MsgSetReq.ClearRequests()

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
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next i
        End Sub
        Private Function Customer_UseOverpayment(ByVal overpayTxnID As String,
                                                 ByVal overpayEditSeq As String,
                                                 ByVal overpayRemain As Double,
                                                 ByRef attachedTxns As IAppliedToTxnRetList,
                                                 ByRef newInv As NewInvObj) As Boolean
            ' this var will be returned after every overpayment to let the calling sub know if it needs to use another
            Dim paidOff As Boolean

            Dim recievePayMod As IReceivePaymentMod = MsgSetReq.AppendReceivePaymentModRq

            recievePayMod.TxnID.SetValue(overpayTxnID)
            recievePayMod.EditSequence.SetValue(overpayEditSeq)

            Dim appliedTxnList As IAppliedToTxnModList = recievePayMod.AppliedToTxnModList
            Dim appliedTxn As IAppliedToTxnMod

            ' readding existing attached txns
            If (attachedTxns IsNot Nothing) Then
                For i = 0 To attachedTxns.Count - 1
                    appliedTxn = appliedTxnList.Append()
                    appliedTxn.TxnID.SetValue(attachedTxns.GetAt(i).TxnID.GetValue)
                    appliedTxn.PaymentAmount.SetValue(attachedTxns.GetAt(i).Amount.GetValue)
                Next i
            End If

            ' adding newly created inv
            Dim newTxn As IAppliedToTxnMod
            newTxn = appliedTxnList.Append()
            newTxn.TxnID.SetValue(newInv.TxnID)

            ' match to see how much we are applying
            If ((newInv.BalanceRemaining - overpayRemain) <= 0) Then
                ' overpayment can cover the balance, so applied amount will be balance remaining
                newTxn.PaymentAmount.SetValue(newInv.BalanceRemaining)

                ' updating balance
                newInv.BalanceRemaining = 0
                ' updating return var
                paidOff = True
            Else
                ' balance will remain, so applied amount is the same as remaining overpayment
                newTxn.PaymentAmount.SetValue(overpayRemain)

                ' updating balance
                newInv.BalanceRemaining = Math.Round((newInv.BalanceRemaining - overpayRemain), 2)
                ' updating return var
                paidOff = False
            End If


            ' request is fully built, time to send and do response work
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' clear msgset
            MsgSetReq.ClearRequests()

            ' looping through responseList
            For i = 0 To responseList.Count - 1
                Dim resp As IResponse = responseList.GetAt(i)
                If (resp.StatusCode > 0) Then
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next i

            Return paidOff
        End Function
        Public Sub Customer_CheckCredits(ByRef newInv As NewInvObj)
            Dim creditMemoQuery As ICreditMemoQuery = MsgSetReq.AppendCreditMemoQueryRq

            ' only want these 2 things back
            creditMemoQuery.IncludeRetElementList.Add("CreditRemaining")
            creditMemoQuery.IncludeRetElementList.Add("TxnID")

            ' passing paramater here
            creditMemoQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(newInv.CustomerListID)

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetReq.ClearRequests()

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
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next i

        End Sub
        Private Function Customer_UseCredit(ByVal creditTxnID As String, ByVal creditRemain As Double, ByRef newInv As NewInvObj) As Boolean
            Dim paidOff As Boolean

            ' create interface
            Dim recievePayAdd As IReceivePaymentAdd = MsgSetReq.AppendReceivePaymentAddRq

            ' set attached cust
            recievePayAdd.CustomerRef.ListID.SetValue(newInv.CustomerListID)

            ' new invoice
            Dim newAttached As IAppliedToTxnAdd = recievePayAdd.ORApplyPayment.AppliedToTxnAddList.Append()
            newAttached.TxnID.SetValue(newInv.TxnID)

            Dim setCredit As ISetCredit = newAttached.SetCreditList.Append()
            setCredit.CreditTxnID.SetValue(creditTxnID)

            If (newInv.BalanceRemaining > 0) Then
                ' checking how much i can apply
                If ((newInv.BalanceRemaining - creditRemain) <= 0) Then
                    ' credit can cover the balance, so applied amount is the same as balance
                    setCredit.AppliedAmount.SetValue(newInv.BalanceRemaining)

                    ' updating balance
                    newInv.BalanceRemaining = 0
                Else
                    ' balance will remain, so applied amount is the same as remaining credit
                    setCredit.AppliedAmount.SetValue(creditRemain)

                    ' updating balance
                    newInv.BalanceRemaining = Math.Round((newInv.BalanceRemaining - creditRemain), 2)
                End If
            End If

            ' request is fully built, time to send and do response work
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetReq.ClearRequests()

            ' looping through responseList
            For i = 0 To responseList.Count - 1
                Dim resp As IResponse = responseList.GetAt(i)
                If (resp.StatusCode > 0) Then
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next i

            Return paidOff
        End Function

        Public Sub Items_NewServiceItem(ByVal serviceTypeID As Integer, ByVal qbAccount As String)
            ' getting row
            Dim ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
            Dim serviceRow As ds_Types.ServiceTypesRow = ta.GetDataByID(serviceTypeID).Rows(0)

            Dim itemAdd As IItemServiceAdd = MsgSetReq.AppendItemServiceAddRq

            ' setting item stuff
            itemAdd.Name.SetValue(serviceRow.ServiceName)
            itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(serviceRow.ServiceDescription)
            itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(serviceRow.ServiceRate)
            ' passing attached account
            itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(qbAccount)

            ' checking active state
            If (serviceRow.ServiceActive = False) Then
                itemAdd.IsActive.SetValue(False)
            Else
                itemAdd.IsActive.SetValue(True)
            End If

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetREq
            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    Dim itemRet As IItemServiceRet = resp.Detail

                    ' update db information with edit sequence and list id
                    serviceRow.ServiceListID = itemRet.ListID.GetValue
                    serviceRow.ServiceEditSequence = itemRet.EditSequence.GetValue

                    ' commit to db
                    Try
                        ta.Update(serviceRow)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                    ta.DeleteByID(serviceTypeID)
                End If
            Next i
        End Sub

        Public Sub Items_UpdateServiceItem(ByVal serviceTypeID As Decimal)
            ' getting row
            Dim ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
            Dim serviceRow As ds_Types.ServiceTypesRow = ta.GetDataByID(serviceTypeID).Rows(0)

            Dim itemMod As IItemServiceMod = MsgSetReq.AppendItemServiceModRq

            ' setting item we are talking about
            itemMod.ListID.SetValue(serviceRow.ServiceListID)
            itemMod.EditSequence.SetValue(serviceRow.ServiceEditSequence)

            ' update rate
            itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.ORPrice.Price.SetValue(serviceRow.ServiceRate)
            ' update description
            itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.Desc.SetValue(serviceRow.ServiceDescription)
            ' update active state
            If (serviceRow.ServiceActive = False) Then
                itemMod.IsActive.SetValue(False)
            Else
                itemMod.IsActive.SetValue(True)
            End If

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    Dim itemRet As IItemServiceRet = resp.Detail

                    ' update srvc row edit sequence
                    serviceRow.ServiceEditSequence = itemRet.EditSequence.GetValue
                    Try
                        ta.Update(serviceRow)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                ElseIf (resp.StatusCode = 3200) Then
                    ' update edit sequence in db
                    Items_UpdateEditSeq(serviceTypeID)
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next i
        End Sub

        Private Sub Items_UpdateEditSeq(ByVal serviceTypeID As Integer)
            Dim itemQuery As IItemQuery = MsgSetReq.AppendItemQueryRq

            ' getting service row
            Dim ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
            Dim serviceRow As ds_Types.ServiceTypesRow = ta.GetDataByID(serviceTypeID).Rows(0)


            ' setting listid
            itemQuery.ORListQuery.ListIDList.Add(serviceRow.ServiceListID)

            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            'clear msgSetReq
            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                Dim itemRetList As IORItemRetList = resp.Detail

                For j = 0 To itemRetList.Count - 1
                    Dim itemRet As IORItemRet = itemRetList.GetAt(j)

                    If (itemRet.ItemServiceRet IsNot Nothing) Then
                        ' update edit sequence
                        serviceRow.ServiceEditSequence = itemRet.ItemServiceRet.EditSequence.GetValue
                        ta.Update(serviceRow)

                        ' redo update
                        Items_UpdateServiceItem(serviceTypeID)
                        Exit Sub
                    End If
                Next
            Next
        End Sub

        Public Sub Items_ImportAllMissingListID(ByVal qbAccount As String)
            Dim ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
            Dim dt As ds_Types.ServiceTypesDataTable = ta.GetData

            For Each row As ds_Types.ServiceTypesRow In dt.Rows
                If (row.IsServiceListIDNull = True) Then
                    Dim itemAdd As IItemServiceAdd = MsgSetReq.AppendItemServiceAddRq

                    ' setting item stuff
                    itemAdd.Name.SetValue(row.ServiceName)
                    itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(row.ServiceDescription)
                    itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(row.ServiceRate)
                    ' passing attached account
                    itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(qbAccount)

                    ' checking active state
                    If (row.ServiceActive = False) Then
                        itemAdd.IsActive.SetValue(False)
                    Else
                        itemAdd.IsActive.SetValue(True)
                    End If

                    Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
                    Dim respList As IResponseList = msgSetResp.ResponseList

                    ' clear msgSetREq
                    MsgSetReq.ClearRequests()

                    For i = 0 To respList.Count - 1
                        Dim resp As IResponse = respList.GetAt(i)
                        If (resp.StatusCode = 0) Then
                            Dim itemRet As IItemServiceRet = resp.Detail

                            ' update db information with edit sequence and list id
                            row.ServiceListID = itemRet.ListID.GetValue
                            row.ServiceEditSequence = itemRet.EditSequence.GetValue

                            ' commit to db
                            Try
                                ta.Update(row)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        Else
                            GlobalConMgr.ResponseErr_Misc(resp)
                            'ta.DeleteByID(row.ServiceTypeID)
                        End If
                    Next i
                End If
            Next row

        End Sub

    End Class
End Namespace