'Imports QBFC12Lib
'Imports System.IO

'Module QBSubs
'    ' all requests run through sessMgr on the master form - used for simpler refrence here
'    Dim sessMgr As QBSessionManager = Master.app_SessMgr


'    'Public Sub ResponseErrorLoging(ByRef response As IResponse)
'    '    ' INSERT ROW INTO ERR_MISC TABLE
'    '    Dim qta As New DataSetTableAdapters.QueriesTableAdapter

'    '    qta.ERR_MISC_Insert(response.Type.GetValue.ToString, response.StatusCode.ToString, response.StatusMessage, Date.Now)
'    'End Sub
'    ' old custbalance query
'    'Public Function QB_BalanceQuery(ByRef custListID As String) As Double
'    '    Dim returnVar As Double

'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim custQuery As ICustomerQuery = msgSetReq.AppendCustomerQueryRq

'    '    custQuery.ORCustomerListQuery.ListIDList.Add(custListID)
'    '    custQuery.IncludeRetElementList.Add("TotalBalance")

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim respList As IResponseList = msgSetResp.ResponseList


'    '    For i As Integer = 0 To respList.Count - 1
'    '        Dim response As IResponse = respList.GetAt(i)
'    '        ' response check and logging
'    '        If (response.StatusCode = 0) Then
'    '            Dim custRetList As ICustomerRetList = response.Detail
'    '            For j = 0 To custRetList.Count - 1
'    '                Dim custRet As ICustomerRet = custRetList.GetAt(j)
'    '                returnVar = custRet.TotalBalance.GetValue
'    '            Next

'    '        Else
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i

'    '    Return returnVar
'    'End Function

'    'Public Sub QB_UpdateCustomer(ByRef custRow As DataSet.CustomerRow)
'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim customerMod As ICustomerMod = msgSetReq.AppendCustomerModRq

'    '    customerMod.ListID.SetValue(custRow.CustomerListID)
'    '    customerMod.EditSequence.SetValue(custRow.CustomerEditSeq)

'    '    '''' customer information ''''
'    '    customerMod.Name.SetValue(custRow.CustomerFullName)

'    '    customerMod.Phone.SetValue(custRow.CustomerPhone)

'    '    ' checking possibly blank alt phone
'    '    If (custRow.IsCustomerAltPhoneNull = False) Then
'    '        customerMod.AltPhone.SetValue(custRow.CustomerAltPhone)
'    '    End If
'    '    ' checking possibly blank contact field
'    '    If (custRow.IsCustomerContactNull = False) Then
'    '        customerMod.Contact.SetValue(custRow.CustomerContact)
'    '    End If

'    '    '''' billing information ''''
'    '    ' required billAddr1
'    '    customerMod.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
'    '    ' checking billAddr2
'    '    If (custRow.IsCustomerBillingAddr2Null = False) Then
'    '        customerMod.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
'    '    End If
'    '    ' checking billAddr3
'    '    If (custRow.IsCustomerBillingAddr3Null = False) Then
'    '        customerMod.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
'    '    End If
'    '    customerMod.BillAddress.City.SetValue(custRow.CustomerBillingCity)
'    '    customerMod.BillAddress.State.SetValue(custRow.CustomerBillingState)
'    '    customerMod.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

'    '    ' if cell = true, then customer is deactive
'    '    If (custRow.CustomerIsDeactive = True) Then
'    '        customerMod.IsActive.SetValue(False)
'    '    Else
'    '        customerMod.IsActive.SetValue(True)
'    '    End If

'    '    ' doing request and catching in msgSetResp
'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList
'    '    ' looping through response for errors and writing to error log
'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            Dim customerRet As ICustomerRet = response.Detail

'    '            ' updating EditSeq in the DB
'    '            custRow.BeginEdit()
'    '            custRow.CustomerEditSeq = customerRet.EditSequence.GetValue()
'    '            custRow.EndEdit()

'    '            ' update table
'    '            Dim cta As New DataSetTableAdapters.CustomerTableAdapter
'    '            cta.Update(custRow)

'    '            MsgBox("Changes Complete")
'    '        ElseIf (response.StatusCode = 3200) Then
'    '            ' edit sequence missmatch
'    '            QB_GetCustEditSeq(custRow)
'    '        Else
'    '            custRow.RejectChanges()
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i
'    'End Sub


'    'Private Sub QB_GetCustEditSeq(ByRef custRow As DataSet.CustomerRow)
'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim custQuery As ICustomerQuery = msgSetReq.AppendCustomerQueryRq

'    '    custQuery.ORCustomerListQuery.ListIDList.Add(custRow.CustomerListID)

'    '    custQuery.IncludeRetElementList.Add("EditSequence")

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim respList As IResponseList = msgSetResp.ResponseList

'    '    For i = 0 To respList.Count - 1
'    '        Dim response As IResponse = respList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            If (response.Detail IsNot Nothing) Then
'    '                Dim custRetList As ICustomerRetList = response.Detail
'    '                For j = 0 To custRetList.Count - 1
'    '                    Dim custRet As ICustomerRet = custRetList.GetAt(j)

'    '                    ' update row
'    '                    custRow.CustomerEditSeq = custRet.EditSequence.GetValue
'    '                    Dim cta As New DataSetTableAdapters.CustomerTableAdapter
'    '                    cta.Update(custRow)

'    '                    ' re-do cust info update
'    '                    QB_UpdateCustomer(custRow)
'    '                Next j
'    '            End If
'    '        Else
'    '            ' error logging
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i
'    'End Sub


'    'Public Sub QB_CustomerAdd(ByRef custRow As DataSet.CustomerRow, ByRef custTbl As DataSet.CustomerDataTable, ByRef ta As DataSetTableAdapters.CustomerTableAdapter)
'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim customerAdd As ICustomerAdd = msgSetReq.AppendCustomerAddRq

'    '    ' General Customer Information
'    '    customerAdd.Name.SetValue(custRow.CustomerFullName)
'    '    customerAdd.Phone.SetValue(custRow.CustomerPhone)

'    '    If (custRow.IsCustomerAltPhoneNull = False) Then
'    '        customerAdd.AltPhone.SetValue(custRow.CustomerAltPhone)
'    '    End If
'    '    If (custRow.IsCustomerContactNull = False) Then
'    '        customerAdd.Contact.SetValue(custRow.CustomerContact)
'    '    End If

'    '    ' Billing Address Information
'    '    customerAdd.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
'    '    If (custRow.IsCustomerBillingAddr2Null = False) Then
'    '        customerAdd.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
'    '    End If
'    '    If (custRow.IsCustomerBillingAddr3Null = False) Then
'    '        customerAdd.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
'    '    End If
'    '    customerAdd.BillAddress.City.SetValue(custRow.CustomerBillingCity)
'    '    customerAdd.BillAddress.State.SetValue(custRow.CustomerBillingState)
'    '    customerAdd.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

'    '    ' sending request
'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList

'    '    ' looping through response with error checking
'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            Dim customerRet As ICustomerRet = response.Detail
'    '            ' updating the custRow with ListID and EditSeq
'    '            custRow.CustomerListID = customerRet.ListID.GetValue
'    '            custRow.CustomerEditSeq = customerRet.EditSequence.GetValue

'    '            ' add to table
'    '            custTbl.AddCustomerRow(custRow)

'    '            Try
'    '                ' commiting to DB
'    '                ta.Update(custRow)
'    '            Catch ex As Exception
'    '                MsgBox(ex.Message)
'    '            End Try
'    '        ElseIf (response.StatusCode = 3100) Then
'    '            ' customer already exists with that name
'    '            Dim input As String = InputBox("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.")
'    '            If (input.Length > 0) Then
'    '                custRow.CustomerFullName = input

'    '                Try
'    '                    ' commiting to DB
'    '                    ta.Update(custRow)
'    '                Catch ex As Exception
'    '                    MsgBox(ex.Message)
'    '                End Try
'    '            End If

'    '            QB_CustomerAdd(custRow, custTbl, ta)
'    '            Exit Sub
'    '        Else
'    '            ' error logging
'    '            ResponseErrorLoging(response)

'    '            ' delete row
'    '            Dim qta As New DataSetTableAdapters.QueriesTableAdapter
'    '            qta.Customer_DeleteByNum(custRow.CustomerNumber)

'    '            ' bail out
'    '            Exit Sub
'    '        End If
'    '    Next i

'    '    ' clearing msgSetReq for DataExt fields
'    '    msgSetReq.ClearRequests()

'    '    ' Customer Number
'    '    Dim customerNumber As IDataExtMod = msgSetReq.AppendDataExtModRq
'    '    customerNumber.OwnerID.SetValue("0")
'    '    customerNumber.DataExtName.SetValue("Customer Number")
'    '    customerNumber.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
'    '    customerNumber.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(custRow.CustomerListID)
'    '    customerNumber.DataExtValue.SetValue(custRow.CustomerNumber)

'    '    ' sending request then clearing to prep for Start Date DataExt
'    '    sessMgr.DoRequests(msgSetReq)
'    '    msgSetReq.ClearRequests()

'    '    ' Customer Start Date
'    '    Dim customerStartDate As IDataExtMod = msgSetReq.AppendDataExtModRq
'    '    customerStartDate.OwnerID.SetValue("0")
'    '    customerStartDate.DataExtName.SetValue("Start Date")
'    '    customerStartDate.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
'    '    customerStartDate.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(custRow.CustomerListID)
'    '    customerStartDate.DataExtValue.SetValue(custRow.CustomerStartDate)

'    '    'sending request
'    '    sessMgr.DoRequests(msgSetReq)

'    '    MsgBox("Customer: '" & custRow.CustomerFullName & " - " & custRow.CustomerNumber & "' added successfully.")
'    'End Sub

'    'Public Sub QB_InvoiceQuery(ByRef paidStatus As QBFC12Lib.ENPaidStatus, ByRef invTbl As DataSet.QB_InvoiceDisplayDataTable, _
'    '                           Optional ByRef custListID As String = "", Optional ByRef fromDate As DateTime = #1/1/1900#, _
'    '                                                                        Optional ByRef toDate As DateTime = #1/1/1900#)


'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim invoiceQuery As IInvoiceQuery = msgSetReq.AppendInvoiceQueryRq

'    '    ' using custListID param here if provided
'    '    If (custListID.Length > 1) Then
'    '        invoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(custListID)
'    '    End If
'    '    ' using From Date param here
'    '    If (fromDate <> #1/1/1900#) Then
'    '        invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fromDate)
'    '    End If
'    '    ' using To Date param here
'    '    If (toDate <> #1/1/1900#) Then
'    '        invoiceQuery.ORInvoiceQuery.InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(toDate)
'    '    End If

'    '    ' if no date filter is passed, limiting results
'    '    If ((toDate = #1/1/1900#) And (fromDate = #1/1/1900#)) Then
'    '        invoiceQuery.ORInvoiceQuery.InvoiceFilter.MaxReturned.SetValue(50)
'    '    End If

'    '    ' paid status is always passed
'    '    invoiceQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(paidStatus)

'    '    ' sending request
'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList
'    '    ' looping through response list
'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(0)
'    '        If (response.StatusCode = 0) Then
'    '            ' if response is good then clear table for incoming rows
'    '            invTbl.Clear()

'    '            Dim invoiceRetList As IInvoiceRetList = response.Detail
'    '            ' looping through invoice ret list
'    '            For j = 0 To invoiceRetList.Count - 1
'    '                Dim invoiceRet As IInvoiceRet = invoiceRetList.GetAt(j)
'    '                ' building new row
'    '                Dim newRow As DataSet.QB_InvoiceDisplayRow = invTbl.NewQB_InvoiceDisplayRow
'    '                newRow.InvoiceNumber = invoiceRet.TxnNumber.GetValue
'    '                newRow.InvoicePostDate = invoiceRet.TxnDate.GetValue.Date
'    '                newRow.InvoiceCreationDate = invoiceRet.TimeCreated.GetValue.Date
'    '                newRow.CustomerName = invoiceRet.CustomerRef.FullName.GetValue

'    '                '2.0 - dimming qta to drop in cust num here
'    '                Dim qta As New DataSetTableAdapters.QueriesTableAdapter
'    '                newRow.CustomerNumber = qta.Customer_GetNumberFromListID(invoiceRet.CustomerRef.ListID.GetValue)

'    '                newRow.InvoiceTotal = invoiceRet.Subtotal.GetValue
'    '                newRow.InvoiceBalance = invoiceRet.BalanceRemaining.GetValue
'    '                newRow.InvoiceDueDate = invoiceRet.DueDate.GetValue.Date
'    '                invTbl.AddQB_InvoiceDisplayRow(newRow)
'    '            Next j
'    '        ElseIf (response.StatusCode = 1) Then
'    '            MsgBox("No Invoices match search criteria in QuickBooks")
'    '        ElseIf (response.StatusCode > 1) Then
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i
'    'End Sub

'    'Public Sub QB_BatchInvoices(ByRef Form As BatchingPrep)
'    '    ' wrking inv table and TA
'    '    Dim wrkInvTbl As New DataSet.WorkingInvoiceDataTable
'    '    Dim wrkInvTA As New DataSetTableAdapters.WorkingInvoiceTableAdapter

'    '    ' need a queries TA because lineItem table doesnt carry item list IDs
'    '    Dim qta As New DataSetTableAdapters.QueriesTableAdapter
'    '    Dim batchID As Integer

'    '    ' fill tables for upcoming work
'    '    wrkInvTA.FillByID(wrkInvTbl, "Status", "5")

'    '    ' error counter
'    '    Dim err As Integer = 0

'    '    'progress bar stuff
'    '    Dim progCounter As Integer = 0
'    '    Form.pb_Invoices.Maximum = wrkInvTbl.Rows.Count
'    '    Form.lbl_InvBatchCount.Text = progCounter & "/" & wrkInvTbl.Rows.Count

'    '    If (wrkInvTbl.Rows.Count > 0) Then

'    '        ' insert batch row
'    '        batchID = CType(qta.BATCH_HISTORY_INV_Insert(DateTime.Now, wrkInvTbl.Rows.Count), Integer)

'    '        For Each invRow As DataSet.WorkingInvoiceRow In wrkInvTbl.Rows
'    '            ' progress bar stuff
'    '            progCounter += 1
'    '            Form.pb_Invoices.Value = progCounter
'    '            Form.lbl_InvBatchCount.Text = progCounter & "/" & wrkInvTbl.Rows.Count
'    '            Form.lbl_InvBatchCust.Text = invRow.CustomerFullName & " - " & invRow.CustomerNumber

'    '            ' var to hold line item ID's for recurring service so we can update billeservices table after
'    '            Dim lineItemIDList As New List(Of Integer)

'    '            ' time to build msgSetReq
'    '            Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '            Dim invoiceAdd As IInvoiceAdd = msgSetReq.AppendInvoiceAddRq

'    '            ' start building request with non line item information
'    '            Dim cta As New DataSetTableAdapters.CustomerTableAdapter
'    '            Dim custRow As DataSet.CustomerRow = cta.GetData(invRow.CustomerNumber).Rows(0)

'    '            ' grabbing the current customer balance
'    '            Dim custBalance As Double = QB_BalanceQuery(custRow.CustomerListID)
'    '            Dim creditPoss As Boolean = False
'    '            If (custBalance < 0) Then
'    '                creditPoss = True
'    '            End If

'    '            invoiceAdd.CustomerRef.ListID.SetValue(custRow.CustomerListID)

'    '            ' checking if memo is provided
'    '            If (invRow.IsInvoiceMemoNull = False) Then
'    '                invoiceAdd.Memo.SetValue(invRow.InvoiceMemo)
'    '            End If

'    '            invoiceAdd.TxnDate.SetValue(invRow.InvoicePostDate)
'    '            invoiceAdd.DueDate.SetValue(invRow.InvoiceDueDate)
'    '            invoiceAdd.IsToBePrinted.SetValue(CBool(invRow.InvoiceToBePrinted))

'    '            ' line item table and TA
'    '            Dim lineItmTbl As New DataSet.LineItemDataTable
'    '            Dim lineItmTA As New DataSetTableAdapters.LineItemTableAdapter

'    '            ' filling lineitem tbl for new invoice
'    '            lineItmTA.FillByWorkingInvoiceID(lineItmTbl, invRow.WorkingInvoiceID)

'    '            ' this should allow me to call new lines repeatidly
'    '            Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList

'    '            'looping through rows
'    '            For Each lineRow As DataSet.LineItemRow In lineItmTbl.Rows
'    '                Dim newestLine As IORInvoiceLineAdd = lineList.Append()

'    '                newestLine.InvoiceLineAdd.ItemRef.ListID.SetValue(qta.ServiceTypes_GetListIDByTypeID(lineRow.ServiceTypeID))
'    '                newestLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineRow.LineItemRate)
'    '                newestLine.InvoiceLineAdd.Quantity.SetValue(lineRow.LineItemQuantity)
'    '                ' adding line item desc
'    '                newestLine.InvoiceLineAdd.Desc.SetValue(qta.ServiceTypes_GetDescByID(lineRow.ServiceTypeID))

'    '                ' checking for descriptions - these will be added as a blank line item
'    '                If (lineRow.IsLineItemDescriptionNull = False) Then
'    '                    ' create blank line for description
'    '                    Dim descLine As IORInvoiceLineAdd = lineList.Append()
'    '                    descLine.InvoiceLineAdd.ItemRef.ListID.Unset()
'    '                    descLine.InvoiceLineAdd.ItemRef.FullName.Unset()
'    '                    descLine.InvoiceLineAdd.Desc.SetValue(lineRow.LineItemDescription)
'    '                    descLine.InvoiceLineAdd.Amount.Unset()
'    '                    descLine.InvoiceLineAdd.Quantity.Unset()
'    '                End If

'    '                ' checking for recurring service id
'    '                If (invRow.IsRecurring = True) Then
'    '                    lineItemIDList.Add(lineRow.LineItemID)
'    '                End If

'    '            Next lineRow

'    '            'sending request and catching response
'    '            Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '            Dim respList As IResponseList = msgSetResp.ResponseList

'    '            For i = 0 To respList.Count - 1
'    '                Dim response As IResponse = respList.GetAt(i)
'    '                If (response.StatusCode <> 0) Then
'    '                    ' if response fails, do whatever here
'    '                    'ResponseErrorLoging(response)

'    '                    ' insert to err table
'    '                    wrkInvTA.ERR_INVOICE_Insert(invRow.WorkingInvoiceID, response.StatusCode.ToString, response.StatusMessage)
'    '                    err += 1
'    '                    invRow.InvoiceStatus = 6
'    '                Else
'    '                    ' if response passes, do whatever here
'    '                    Dim invoiceRet As IInvoiceRet = response.Detail
'    '                    'success logging
'    '                    'InvoiceBatchLoging(invoiceRet)

'    '                    If (invoiceRet.BalanceRemaining.GetValue > 0) Then
'    '                        If (creditPoss = True) Then
'    '                            '*******************************
'    '                            ' need to check if we can use credits and overpayments
'    '                            QB_UtalizeExcessFunds(invoiceRet)
'    '                            '********************************
'    '                        End If
'    '                    End If

'    '                    'write to billed services table if lineItemIDList has items
'    '                    If (lineItemIDList.Count > 0) Then
'    '                        For Each lineID As Integer In lineItemIDList
'    '                            Try
'    '                                qta.BilledServices_InsertByLineItemID(lineID, invoiceRet.TxnID.GetValue, invoiceRet.TxnNumber.GetValue, batchID)
'    '                            Catch ex As Exception
'    '                                MsgBox(ex.Message)
'    '                            End Try
'    '                        Next lineID
'    '                    End If

'    '                    ' update InvoiceStatus on WorkingInvoice row
'    '                    invRow.InvoiceStatus = 7
'    '                End If
'    '                ' next response
'    '            Next i
'    '            Try
'    '                ' updating workinginvRow
'    '                wrkInvTA.Update(invRow)
'    '            Catch ex As Exception
'    '                MsgBox(ex.Message)
'    '            Finally
'    '                wrkInvTA.DeleteComplete()
'    '            End Try


'    '        Next invRow
'    '    End If

'    '    ' finishing stuff
'    '    If (err = 0) Then
'    '        MsgBox("Batch completed")
'    '    Else
'    '        MsgBox("Batch completed with error(s). Total error count is " & err & "." & vbCrLf _
'    '               & "Please contact Premier")
'    '    End If

'    '    ' UPDATE BATCH HISTORY
'    '    qta.BATCH_HISTORY_INVOICE_UpdateForCompletion(batchID, Date.Now, err)

'    '    ' delete completed
'    '    wrkInvTA.DeleteComplete()
'    'End Sub

'    'Public Sub QB_BatchPayments(ByRef Form As BatchingPrep)
'    '    Dim payTbl As New DataSet.WorkingPaymentsDataTable
'    '    Dim payTA As New DataSetTableAdapters.WorkingPaymentsTableAdapter
'    '    Dim qta As New DataSetTableAdapters.QueriesTableAdapter
'    '    Dim phta As New DataSetTableAdapters.PaymentHistoryTableAdapter

'    '    Dim paySessMgr As New QBSessionManager
'    '    paySessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
'    '    Dim msgSetReq As IMsgSetRequest = paySessMgr.CreateMsgSetRequest("US", 11, 0)

'    '    Dim receivePayment As IReceivePaymentAdd
'    '    Dim msgSetResp As IMsgSetResponse
'    '    Dim responseList As IResponseList
'    '    Dim receivePaymentRet As IReceivePaymentRet

'    '    Dim batchID As Integer

'    '    Dim err As Integer = 0
'    '    Dim curBatchNum As Integer = 0

'    '    'Dim sessMgr2 As QBSessionManager


'    '    ' filling WorkingPayments table
'    '    payTA.Batch_Fill(payTbl)

'    '    'progress bar stuff here
'    '    Dim progCounter As Integer = 0
'    '    Form.pb_Payments.Maximum = payTbl.Rows.Count
'    '    Form.lbl_PayBatchCount.Text = progCounter & "/" & payTbl.Rows.Count

'    '    If (payTbl.Rows.Count > 0) Then
'    '        ' insert batch row
'    '        batchID = CType(qta.BATCH_HISTORY_PAY_Insert(DateTime.Now, payTbl.Rows.Count), Integer)

'    '        For Each paymentRow As DataSet.WorkingPaymentsRow In payTbl
'    '            If (paymentRow.WorkingPaymentsStatus = 5) Then
'    '                Try
'    '                    ' going to try restarting the session every 1000 payments
'    '                    If (curBatchNum = 0) Then
'    '                        paySessMgr.BeginSession(My.Settings.QBFileLocation, ENOpenMode.omDontCare)
'    '                        curBatchNum = 1
'    '                    ElseIf (curBatchNum = 1000) Then
'    '                        curBatchNum = 1
'    '                        paySessMgr.EndSession()
'    '                        paySessMgr.BeginSession(My.Settings.QBFileLocation, ENOpenMode.omDontCare)
'    '                    Else
'    '                        curBatchNum += 1
'    '                    End If

'    '                    msgSetReq.ClearRequests()

'    '                    'progress bar stuff
'    '                    progCounter += 1
'    '                    Form.pb_Payments.Value = progCounter
'    '                    Form.lbl_PayBatchCount.Text = progCounter & "/" & payTbl.Rows.Count
'    '                    Form.lbl_PayBatchCust.Text = paymentRow.CustomerFullName & " - " & paymentRow.CustomerNumber

'    '                    ' building request
'    '                    receivePayment = msgSetReq.AppendReceivePaymentAddRq
'    '                    ' grabbing list id

'    '                    receivePayment.CustomerRef.ListID.SetValue(qta.Customer_GetListID(paymentRow.CustomerNumber))
'    '                    receivePayment.TotalAmount.SetValue(paymentRow.WorkingPaymentsAmount)
'    '                    receivePayment.PaymentMethodRef.FullName.SetValue(paymentRow.PaymentTypeName)

'    '                    ' checking for a check number
'    '                    Dim _refNum As String
'    '                    If (paymentRow.IsWorkingPaymentsCheckNumNull = False) Then
'    '                        _refNum = paymentRow.WorkingPaymentsCheckNum
'    '                        receivePayment.RefNumber.SetValue(paymentRow.WorkingPaymentsCheckNum)
'    '                    Else
'    '                        _refNum = ""
'    '                    End If

'    '                    ' by default, they will auto apply and i will catch overpayments and apply them to open invoices
'    '                    receivePayment.ORApplyPayment.IsAutoApply.SetValue(True)

'    '                    ' response work
'    '                    msgSetResp = paySessMgr.DoRequests(msgSetReq)
'    '                    responseList = msgSetResp.ResponseList

'    '                    ' looping through response with error checking
'    '                    For i = 0 To responseList.Count - 1
'    '                        Dim response As IResponse = responseList.GetAt(i)
'    '                        If (response.StatusCode = 0) Then
'    '                            ' if response good, do stuff here
'    '                            receivePaymentRet = response.Detail

'    '                            ' write to log
'    '                            'PaymentBatchLoging(recievePaymentRet)
'    '                            paymentRow.WorkingPaymentsStatus = 7

'    '                            ' write to payment history table

'    '                            Try
'    '                                phta.PaymentHistory_Insert(paymentRow.CustomerNumber, receivePaymentRet.TxnNumber.GetValue, _refNum, receivePaymentRet.TxnID.GetValue, paymentRow.WorkingPaymentsType, paymentRow.WorkingPaymentsAmount, receivePaymentRet.TxnDate.GetValue.Date, batchID)
'    '                            Catch ex As Exception
'    '                                MsgBox("Pay History:  " & ex.Message)

'    '                            End Try

'    '                            Try
'    '                                payTA.Update(paymentRow)
'    '                            Catch ex As Exception
'    '                                MsgBox(ex.Message)
'    '                            Finally
'    '                                payTA.DeleteComplete()
'    '                            End Try

'    '                            ' clear vars
'    '                            response = Nothing
'    '                            receivePaymentRet = Nothing
'    '                        Else
'    '                            ' if response is bad, do stuff here
'    '                            'ResponseErrorLoging(response)

'    '                            Try
'    '                                ' err log insert
'    '                                payTA.ERR_PAYMENTS_Insert(paymentRow.WorkingPaymentsID, response.StatusCode.ToString, response.StatusMessage)
'    '                                err += 1
'    '                                paymentRow.WorkingPaymentsStatus = 6
'    '                            Catch ex As Exception
'    '                                MsgBox(ex.Message)
'    '                            End Try

'    '                        End If
'    '                    Next i

'    '                    ' clearing vars
'    '                    responseList = Nothing
'    '                    'msgSetReq.ClearRequests()
'    '                    'msgSetReq = Nothing
'    '                    msgSetResp = Nothing
'    '                    receivePayment = Nothing


'    '                    'sessMgr2.EndSession()
'    '                    'sessMgr2.CloseConnection()
'    '                    'sessMgr2 = Nothing

'    '                Catch ex As Exception
'    '                    MsgBox(ex.Message)
'    '                End Try

'    '            End If

'    '        Next (paymentRow)
'    '    End If

'    '    ' finishing stuff
'    '    If (err = 0) Then
'    '        MsgBox("Batch completed")
'    '    Else
'    '        MsgBox("Batch completed with error(s). Total error count is " & err & "." & vbCrLf _
'    '               & "Please contact Premier")
'    '    End If

'    '    ' end session and close connection and clear vars
'    '    paySessMgr.EndSession()
'    '    paySessMgr.CloseConnection()
'    '    paySessMgr = Nothing
'    '    msgSetReq = Nothing

'    '    ' UPDATE BATCH HISTORY
'    '    qta.BATCH_HISTORY_PAY_UpdateForCompletion(batchID, Date.Now, err)

'    '    ' delete completed
'    '    payTA.DeleteComplete()
'    'End Sub


'    'Public Sub QB_CreditMemoAdd(ByRef Row As DataSet.RecurringServiceRow, ByVal CreditAmount As Double, ByVal OldEndDate As Date, ByVal NewEndDate As Date)
'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim creditMemoAdd As ICreditMemoAdd = msgSetReq.AppendCreditMemoAddRq

'    '    ' need qta for list ids
'    '    Dim qta As New DataSetTableAdapters.QueriesTableAdapter

'    '    ' passing listid
'    '    creditMemoAdd.CustomerRef.ListID.SetValue(qta.Customer_GetListID(Row.CustomerNumber))
'    '    creditMemoAdd.IsToBePrinted.SetValue(False)

'    '    Dim creditLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()

'    '    ' credit line info
'    '    creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(qta.ServiceTypes_GetListIDByTypeID(Row.ServiceTypeID))
'    '    creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(CreditAmount)

'    '    ' description line
'    '    Dim descLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
'    '    descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
'    '    descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
'    '    descLine.CreditMemoLineAdd.Desc.SetValue("This service has been Invoiced upto " & qta.RecurringService_LastInvDate(Row.RecurringServiceID) & ". The new End Date overlaps this Invoiced period. | Previous End Date: " & OldEndDate.Date & " | New End Date: " & NewEndDate.Date)
'    '    descLine.CreditMemoLineAdd.Amount.Unset()
'    '    descLine.CreditMemoLineAdd.Quantity.Unset()

'    '    ' send request
'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList

'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            ' update row
'    '            Row.RecurringServiceEndDate = NewEndDate.Date
'    '            Row.Credited = True
'    '        Else
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i

'    'End Sub

'    'Public Sub QB_RecievePaymentQuery(ByRef payTbl As DataSet.QB_PaymentsDisplayDataTable, ByRef custListID As String, _
'    '                                  Optional ByRef fromDate As DateTime = #1/1/1900#, Optional ByRef toDate As DateTime = #1/1/1900#)

'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim paymentQuery As IReceivePaymentQuery = msgSetReq.AppendReceivePaymentQueryRq

'    '    paymentQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(custListID)

'    '    ' checking if a fromDate was passed
'    '    If (fromDate.Date <> #1/1/1900#) Then
'    '        paymentQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fromDate)
'    '    End If
'    '    ' checking if a toDate was passed
'    '    If (toDate.Date <> #1/1/1900#) Then
'    '        paymentQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(toDate)
'    '    End If

'    '    ' if no date filter is passed, limiting results
'    '    If ((toDate = #1/1/1900#) And (fromDate = #1/1/1900#)) Then
'    '        paymentQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(50)
'    '    End If

'    '    ' making sure I get the response information i want
'    '    paymentQuery.IncludeRetElementList.Add("TxnNumber")
'    '    paymentQuery.IncludeRetElementList.Add("TxnDate")
'    '    paymentQuery.IncludeRetElementList.Add("TotalAmount")
'    '    paymentQuery.IncludeRetElementList.Add("RefNumber")
'    '    paymentQuery.IncludeRetElementList.Add("PaymentMethodRef")

'    '    ' sending response
'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList
'    '    ' looping through response with error checking
'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            ' if good clear table for new rows clear table
'    '            payTbl.Clear()

'    '            Dim paymentRetList As IReceivePaymentRetList = response.Detail
'    '            For l = 0 To paymentRetList.Count - 1
'    '                Dim paymentRet As IReceivePaymentRet = paymentRetList.GetAt(l)
'    '                ' building new paymentList row
'    '                Dim newRow As DataSet.QB_PaymentsDisplayRow = payTbl.NewQB_PaymentsDisplayRow
'    '                newRow.PaymentTxnNumber = paymentRet.TxnNumber.GetValue
'    '                newRow.PaymentDate = paymentRet.TxnDate.GetValue
'    '                newRow.PaymentAmount = paymentRet.TotalAmount.GetValue
'    '                newRow.PaymentMethod = paymentRet.PaymentMethodRef.FullName.GetValue
'    '                If (paymentRet.RefNumber IsNot Nothing) Then
'    '                    newRow.PaymentCheckNum = paymentRet.RefNumber.GetValue
'    '                End If
'    '                payTbl.AddQB_PaymentsDisplayRow(newRow)
'    '            Next l
'    '        ElseIf (response.StatusCode = 1) Then
'    '            MsgBox("No Recieved Payments match search criteria in Quickbooks.")
'    '        ElseIf (response.StatusCode > 1) Then
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i

'    'End Sub


'    'Public Sub QB_UtalizeExcessFunds(ByVal InvoiceRet As IInvoiceRet)
'    '    ' var to keep track of balance remaining on inv
'    '    Dim updatedBalance As Double = InvoiceRet.BalanceRemaining.GetValue

'    '    ' only need 1 msgset here
'    '    Dim overpaySessMgr As New QBSessionManager
'    '    overpaySessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
'    '    Dim msgSetReq As IMsgSetRequest
'    '    msgSetReq = overpaySessMgr.CreateMsgSetRequest("US", 11, 0)

'    '    ' var for CreditList
'    '    Dim CreditList As List(Of FundItem) = QB_CreditMemoCheck(InvoiceRet.CustomerRef.ListID.GetValue, msgSetReq)

'    '    ' going to use Credits first
'    '    If (CreditList.Count > 0) Then
'    '        For Each credit As FundItem In CreditList

'    '            If (updatedBalance > 0) Then

'    '                Dim recievePayAdd As IReceivePaymentAdd = msgSetReq.AppendReceivePaymentAddRq

'    '                recievePayAdd.CustomerRef.ListID.SetValue(InvoiceRet.CustomerRef.ListID.GetValue)
'    '                'recievePayAdd.ORApplyPayment.IsAutoApply.SetValue(False)

'    '                Dim newAttached As IAppliedToTxnAdd = recievePayAdd.ORApplyPayment.AppliedToTxnAddList.Append()

'    '                ' bringing in InvoiceTxnID
'    '                newAttached.TxnID.SetValue(InvoiceRet.TxnID.GetValue)

'    '                Dim setCredit As ISetCredit = newAttached.SetCreditList.Append()
'    '                setCredit.CreditTxnID.SetValue(credit.TxnID)

'    '                If (updatedBalance > 0) Then
'    '                    ' checking how much i can apply
'    '                    If ((updatedBalance - credit.AvailAmount) <= 0) Then
'    '                        ' credit can cover the balance, so applied amount is the same as balance
'    '                        setCredit.AppliedAmount.SetValue(updatedBalance)

'    '                        ' updating balance
'    '                        updatedBalance = 0
'    '                    Else
'    '                        ' balance will remain, so applied amount is the same as remaining credit
'    '                        setCredit.AppliedAmount.SetValue(credit.AvailAmount)

'    '                        ' updating balance
'    '                        updatedBalance = updatedBalance - credit.AvailAmount
'    '                    End If
'    '                End If

'    '                ' request is fully built, time to send and do response work
'    '                Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '                Dim responseList As IResponseList = msgSetResp.ResponseList

'    '                ' looping through responseList
'    '                For i = 0 To responseList.Count - 1
'    '                    Dim response As IResponse = responseList.GetAt(i)
'    '                    If (response.StatusCode > 0) Then
'    '                        ResponseErrorLoging(response)
'    '                    End If
'    '                Next i

'    '                msgSetReq.ClearRequests()
'    '            End If
'    '        Next credit
'    '    End If


'    '    If (updatedBalance > 0) Then
'    '        ' credits did not cover full invoice, we need to use overpayments now
'    '        Dim OverpayList As List(Of FundItem) = QB_OverpaymentCheck(InvoiceRet.CustomerRef.ListID.GetValue, msgSetReq)

'    '        If (OverpayList.Count > 0) Then
'    '            ' looping through overpay list
'    '            For Each overpayment As FundItem In OverpayList

'    '                ' checking balance
'    '                If (updatedBalance > 0) Then
'    '                    Dim recievePayMod As IReceivePaymentMod = msgSetReq.AppendReceivePaymentModRq

'    '                    recievePayMod.TxnID.SetValue(overpayment.TxnID)
'    '                    recievePayMod.EditSequence.SetValue(overpayment.EditSequence)

'    '                    Dim appliedTxnList As IAppliedToTxnModList = recievePayMod.AppliedToTxnModList

'    '                    ' readding existing attached txns
'    '                    For Each attachedTxn As AttachedTxn In overpayment.AttachedTxns
'    '                        appliedTxnList.Append()
'    '                        Dim appliedTxn As IAppliedToTxnMod = appliedTxnList.GetAt(appliedTxnList.Count - 1)
'    '                        appliedTxn.TxnID.SetValue(attachedTxn.TxnID)
'    '                        appliedTxn.PaymentAmount.SetValue(attachedTxn.AppliedAmount)
'    '                    Next attachedTxn

'    '                    ' adding newly created inv
'    '                    Dim newTxn As IAppliedToTxnMod = appliedTxnList.Append
'    '                    newTxn.TxnID.SetValue(InvoiceRet.TxnID.GetValue)

'    '                    ' match to see how much we are applying
'    '                    If ((updatedBalance - overpayment.AvailAmount) <= 0) Then
'    '                        ' overpayment can cover the balance, so applied amount will be balance remaining
'    '                        newTxn.PaymentAmount.SetValue(CDbl(updatedBalance))

'    '                        ' updating balance
'    '                        updatedBalance = 0
'    '                    Else
'    '                        ' balance will remain, so applied amount is the same as remaining overpayment
'    '                        newTxn.PaymentAmount.SetValue(overpayment.AvailAmount)

'    '                        ' updating balance
'    '                        updatedBalance = updatedBalance - overpayment.AvailAmount
'    '                        updatedBalance = Math.Round(updatedBalance, 2)
'    '                    End If


'    '                    ' request is fully built, time to send and do response work
'    '                    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '                    Dim responseList As IResponseList = msgSetResp.ResponseList

'    '                    ' looping through responseList
'    '                    For i = 0 To responseList.Count - 1
'    '                        Dim response As IResponse = responseList.GetAt(i)
'    '                        If (response.StatusCode > 0) Then
'    '                            ResponseErrorLoging(response)
'    '                        End If
'    '                    Next i
'    '                    msgSetReq.ClearRequests()
'    '                End If
'    '            Next overpayment
'    '        End If
'    '    End If
'    'End Sub

'    'Public Function QB_OverpaymentCheck(ByVal CustomerListID As String, ByRef msgSetReq As IMsgSetRequest)
'    '    ' return var
'    '    Dim OverpayList As New List(Of FundItem)

'    '    'Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim recievePayQuery As IReceivePaymentQuery = msgSetReq.AppendReceivePaymentQueryRq

'    '    ' only things i want back
'    '    recievePayQuery.IncludeRetElementList.Add("UnusedPayment")
'    '    recievePayQuery.IncludeRetElementList.Add("TxnID")
'    '    recievePayQuery.IncludeRetElementList.Add("EditSequence")
'    '    recievePayQuery.IncludeRetElementList.Add("AppliedToTxnRet")

'    '    ' passing param here
'    '    recievePayQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(CustomerListID)

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList

'    '    ' looping through responseList
'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            If (response.Detail IsNot Nothing) Then
'    '                Dim recievePayRetList As IReceivePaymentRetList = response.Detail
'    '                For l = 0 To recievePayRetList.Count - 1
'    '                    Dim recievePayRet As IReceivePaymentRet = recievePayRetList.GetAt(l)
'    '                    If (recievePayRet IsNot Nothing) Then
'    '                        ' checking if UnusedPayment > 0
'    '                        If (recievePayRet.UnusedPayment.GetValue > 0) Then
'    '                            ' adding payment info to list
'    '                            OverpayList.Add(New FundItem(recievePayRet.TxnID.GetValue, recievePayRet.UnusedPayment.GetValue, recievePayRet.EditSequence.GetValue))

'    '                            ' reading through applied to txn ret for upcoming mod
'    '                            Dim appliedTxnList As IAppliedToTxnRetList = recievePayRet.AppliedToTxnRetList

'    '                            ' checking to see if anything is in the list
'    '                            If (appliedTxnList IsNot Nothing) Then
'    '                                ' creating var for easier refrence
'    '                                Dim overpayment = OverpayList.Last

'    '                                For j = 0 To appliedTxnList.Count - 1
'    '                                    Dim appliedTxn As IAppliedToTxnRet = appliedTxnList.GetAt(j)
'    '                                    overpayment.AppendTxn(New AttachedTxn(appliedTxn.TxnID.GetValue, appliedTxn.Amount.GetValue))
'    '                                Next j
'    '                            End If
'    '                        End If
'    '                    End If
'    '                Next l
'    '            End If
'    '        ElseIf (response.StatusCode > 1) Then
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i

'    '    'clear vars
'    '    msgSetResp = Nothing
'    '    responseList = Nothing

'    '    ' clear msgSetReq
'    '    msgSetReq.ClearRequests()

'    '    Return OverpayList
'    'End Function

'    'Public Function QB_CreditMemoCheck(ByVal CustomerListID As String, ByRef msgSetReq As IMsgSetRequest)
'    '    ' return var
'    '    Dim CreditList As New List(Of FundItem)

'    '    'Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim creditMemoQuery As ICreditMemoQuery = msgSetReq.AppendCreditMemoQueryRq

'    '    ' only want these 2 things back
'    '    creditMemoQuery.IncludeRetElementList.Add("CreditRemaining")
'    '    creditMemoQuery.IncludeRetElementList.Add("TxnID")

'    '    ' passing paramater here
'    '    creditMemoQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(CustomerListID)

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim responseList As IResponseList = msgSetResp.ResponseList

'    '    ' looping through responseList
'    '    For i = 0 To responseList.Count - 1
'    '        Dim response As IResponse = responseList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            If (response.Detail IsNot Nothing) Then
'    '                Dim creditMemoRetList As ICreditMemoRetList = response.Detail
'    '                For l = 0 To creditMemoRetList.Count - 1
'    '                    Dim creditMemoRet As ICreditMemoRet = creditMemoRetList.GetAt(l)

'    '                    ' checking if CreditRemaining > 0
'    '                    If (creditMemoRet.CreditRemaining.GetValue > 0) Then
'    '                        ' adding to list
'    '                        CreditList.Add(New FundItem(creditMemoRet.TxnID.GetValue, creditMemoRet.CreditRemaining.GetValue))
'    '                    End If
'    '                Next l
'    '            End If
'    '        ElseIf (response.StatusCode = 1) Then
'    '            ' if response is statuscode 1 then nothing is returned; for a credit memo check we dont want to report that
'    '        ElseIf (response.StatusCode > 1) Then
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i

'    '    'clear vars
'    '    msgSetResp = Nothing
'    '    responseList = Nothing

'    '    ' clear msgSetReq
'    '    msgSetReq.ClearRequests()

'    '    Return CreditList
'    'End Function

'    'Public Sub QB_UpdateServiceItem(ByVal ServiceTypeID As Decimal)
'    '    Dim ta As New DataSetTableAdapters.ServiceTypesTableAdapter
'    '    Dim row As DataSet.ServiceTypesRow = ta.GetDataByID(ServiceTypeID).Rows(0)

'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim itemMod As IItemServiceMod = msgSetReq.AppendItemServiceModRq

'    '    ' setting item we are talking about
'    '    itemMod.ListID.SetValue(row.ServiceListID)
'    '    itemMod.EditSequence.SetValue(row.ServiceEditSequence)

'    '    ' update rate
'    '    itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.ORPrice.Price.SetValue(row.ServiceRate)
'    '    ' update description
'    '    itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.Desc.SetValue(row.ServiceDescription)
'    '    ' update active state
'    '    If (row.ServiceActive = False) Then
'    '        itemMod.IsActive.SetValue(False)
'    '    Else
'    '        itemMod.IsActive.SetValue(True)
'    '    End If

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim respList As IResponseList = msgSetResp.ResponseList

'    '    For i = 0 To respList.Count - 1
'    '        Dim response As IResponse = respList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            Dim itemRet As IItemServiceRet = response.Detail

'    '            ' update srvc row edit sequence
'    '            row.ServiceEditSequence = itemRet.EditSequence.GetValue
'    '            Try
'    '                ta.Update(row)
'    '            Catch ex As Exception
'    '                MsgBox(ex.Message)
'    '            End Try
'    '        ElseIf (response.StatusCode = 3200) Then
'    '            ' update edit sequence in db
'    '            QB_UpdateServiceItemEditSeq(ServiceTypeID)
'    '        Else
'    '            ResponseErrorLoging(response)
'    '        End If
'    '    Next i

'    'End Sub

'    'Private Sub QB_UpdateServiceItemEditSeq(ByVal ServiceTypeID As Decimal)
'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim itemQuery As IItemQuery = msgSetReq.AppendItemQueryRq

'    '    ' var for ta to get list id of service and to update later
'    '    Dim qta As New DataSetTableAdapters.QueriesTableAdapter

'    '    ' setting listid
'    '    itemQuery.ORListQuery.ListIDList.Add(qta.ServiceTypes_GetListIDByTypeID(ServiceTypeID))

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim respList As IResponseList = msgSetResp.ResponseList

'    '    For i = 0 To respList.Count - 1
'    '        Dim response As IResponse = respList.GetAt(i)
'    '        Dim itemRetList As IORItemRetList = response.Detail

'    '        For j = 0 To itemRetList.Count - 1
'    '            Dim itemRet As IORItemRet = itemRetList.GetAt(j)

'    '            If (itemRet.ItemServiceRet IsNot Nothing) Then
'    '                ' update edit sequence
'    '                qta.ServiceTypes_UpdateEditSeq(ServiceTypeID, itemRet.ItemServiceRet.EditSequence.GetValue)
'    '                ' redo update
'    '                QB_UpdateServiceItem(ServiceTypeID)
'    '            End If
'    '        Next
'    '    Next
'    'End Sub

'    'Public Sub QB_AddServiceItem(ByVal ServiceTypeID As Decimal, ByVal AccountListID As String)
'    '    Dim ta As New DataSetTableAdapters.ServiceTypesTableAdapter
'    '    Dim row As DataSet.ServiceTypesRow = ta.GetDataByID(ServiceTypeID).Rows(0)

'    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    '    Dim itemAdd As IItemServiceAdd = msgSetReq.AppendItemServiceAddRq

'    '    ' setting item stuff
'    '    itemAdd.Name.SetValue(row.ServiceName)
'    '    itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(row.ServiceDescription)
'    '    itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(row.ServiceRate)
'    '    ' passing attached account
'    '    itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(AccountListID)

'    '    ' checking active state
'    '    If (row.ServiceActive = False) Then
'    '        itemAdd.IsActive.SetValue(False)
'    '    Else
'    '        itemAdd.IsActive.SetValue(True)
'    '    End If

'    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    '    Dim respList As IResponseList = msgSetResp.ResponseList

'    '    For i = 0 To respList.Count - 1
'    '        Dim response As IResponse = respList.GetAt(i)
'    '        If (response.StatusCode = 0) Then
'    '            Dim itemRet As IItemServiceRet = response.Detail

'    '            ' update db information with edit sequence and list id
'    '            row.ServiceListID = itemRet.ListID.GetValue
'    '            row.ServiceEditSequence = itemRet.EditSequence.GetValue

'    '            ' commit to db
'    '            Try
'    '                ta.Update(row)
'    '            Catch ex As Exception
'    '                MsgBox(ex.Message)
'    '            End Try
'    '        Else
'    '            ResponseErrorLoging(response)
'    '            ta.DeleteByID(ServiceTypeID)
'    '        End If
'    '    Next i

'    'End Sub








'    Public Class FundItem
'        Friend _txnID As String
'        Friend _editSeq As String
'        Friend _availAmount As Double
'        Friend _attachedTxns As New List(Of AttachedTxn)

'        Public Property TxnID() As String
'            Get
'                Return _txnID
'            End Get
'            Set(value As String)
'                _txnID = value
'            End Set
'        End Property

'        Public Property EditSequence() As String
'            Get
'                Return _editSeq
'            End Get
'            Set(value As String)
'                _editSeq = value
'            End Set
'        End Property
'        Public Property AvailAmount() As Double
'            Get
'                Return _availAmount
'            End Get
'            Set(value As Double)
'                _availAmount = value
'            End Set
'        End Property

'        ReadOnly Property AttachedTxns() As List(Of AttachedTxn)
'            Get
'                Return _attachedTxns
'            End Get
'        End Property

'        Public Sub AppendTxn(ByVal AttachTxn As AttachedTxn)
'            _attachedTxns.Add(AttachTxn)
'        End Sub

'        Public Sub New(ByVal txnID As String, ByVal appliedAmount As Double, Optional ByVal editSeq As String = "")
'            _txnID = txnID
'            _availAmount = appliedAmount
'            If (editSeq.Length > 0) Then
'                _editSeq = editSeq
'            End If
'        End Sub
'    End Class

'    Public Class AttachedTxn
'        Friend _txnID As String
'        Friend _appliedAmount As String

'        Public Property TxnID() As String
'            Get
'                Return _txnID
'            End Get
'            Set(value As String)
'                _txnID = value
'            End Set
'        End Property

'        Public Property AppliedAmount() As Double
'            Get
'                Return _appliedAmount
'            End Get
'            Set(value As Double)
'                _appliedAmount = value
'            End Set
'        End Property

'        Public Sub New(ByVal txnID As String, ByVal appliedAmount As Double)
'            _txnID = txnID
'            _appliedAmount = appliedAmount
'        End Sub
'    End Class

'End Module