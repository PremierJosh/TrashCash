Imports QBFC12Lib
Imports TrashCash.QB_Procedures
Imports TrashCash.TrashCash_Utils
Imports TrashCash.TrashCash_Utils.Err_Handling


Public MustInherit Class QB_Batching
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

    ' connection status bool
    Protected connected As Boolean
    ' session status bool
    Protected inSession As Boolean
    ' class vars
    Private c_Queries As QB_Queries
    Private c_Procedures As QB_Procedures
    ' qta
    Private qta As ds_BatchingTableAdapters.QueriesTableAdapter

    Public Sub New()
        _sessMgr = New QBSessionManager

        If (Not connected) Then
            SessionManager.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
            connected = True
        End If
        If (Not inSession) Then
            SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)
            inSession = True
        End If

        _msgSetReq = SessionManager.CreateMsgSetRequest("US", 11, 0)

        ' instantiate 
        c_Queries = New QB_Queries(SessionManager, MsgSetRequest)
        c_Procedures = New QB_Procedures(SessionManager, MsgSetRequest)
        qta = New ds_BatchingTableAdapters.QueriesTableAdapter
    End Sub

    Public Class Invoicing
        Inherits QB_Batching

        ' dt for line items
        Protected linedt As ds_Batching.BATCH_LineItemsDataTable
        ' dt for invoices
        Protected widt As ds_Batching.BATCH_WorkingInvoiceDataTable
        ' current batch id
        Protected BatchID As Integer

        ' tas
        Protected wita As ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
        Protected lita As ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter

        Public Sub New(ByVal InvoiceDT As ds_Batching.BATCH_WorkingInvoiceDataTable)
            MyBase.new()
            ' instantiating tas
            wita = New ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
            lita = New ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter

            widt = InvoiceDT
        End Sub

        Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker,
                                  ByVal e As System.ComponentModel.DoWorkEventArgs)
            If (inSession) Then
                ' this will keep track of this batches progress
                Dim progress As New ProgressObj

                ' this is passed to the worker
                Dim progPercent As Integer

                ' this will keep track of time reporting so its not insane
                Dim lastReportTime As DateTime = Now
                ' this is how many milliseconds between progress reporting
                Dim elapsedTime As Double = 100


                If (widt.Rows.Count > 0) Then
                    ' setting maximum on progress class
                    progress.MaximumValue = widt.Rows.Count

                    ' err counter
                    Dim err As Integer

                    ' batch history insert
                    Try
                        BatchID = qta.BATCH_HISTORY_INV_Insert(Date.Now, widt.Rows.Count)
                    Catch ex As SqlClient.SqlException
                        MsgBox("Batch History Insert: " & ex.Message)
                    End Try

                    ' start looping through rows
                    For Each row As ds_Batching.BATCH_WorkingInvoiceRow In widt.Rows
                        ' updating progress counter and customer
                        progress.CurrentValue += 1
                        progress.CurrentCustomer = row.CustomerFullName

                        ' getting percent
                        progPercent = CInt(progress.CurrentValue / progress.MaximumValue * 100)

                        ' report if enough time has passed
                        If (Now > lastReportTime.AddMilliseconds(elapsedTime)) Then
                            worker.ReportProgress(progPercent, progress)
                        End If

                        ' checking balance of customer
                        Dim custBalance As Double = c_Queries.Customer_Balance(row.CustomerListID)

                        ' send row
                        Invoice(row)

                        ' update row in db
                        Try
                            wita.Update(row)
                        Catch ex As Exception
                            MsgBox("WorkingInvoice Update Err: " & ex.Message)
                        End Try

                        ' check status
                        If (row.InvoiceStatus = 6) Then
                            ' update err count
                            err += 1
                        ElseIf (row.InvoiceStatus = 7) Then
                            ' update billed services table if inv is recurring
                            If (row.IsRecurring) Then
                                For Each lineRow As ds_Batching.BATCH_LineItemsRow In linedt.Rows
                                    ' get total of line row
                                    Dim lineTotal As Double = (lineRow.LineItemRate * lineRow.LineItemQuantity)

                                    Try
                                        qta.BilledServices_InsertByLineItemID(lineRow.LineItemID,
                                                                              row._InvTxnID,
                                                                              row._InvRefNum,
                                                                              lineRow._LineTxnID,
                                                                              BatchID,
                                                                              lineTotal)
                                    Catch ex As Exception
                                        MsgBox("BilledServices Insert: " & ex.Message)
                                    End Try

                                Next
                            End If

                            If (row.InvoiceBalance > 0) Then
                                If (custBalance < 0) Then
                                    ' class to keep track of this
                                    Dim invObj As New NewInvObj
                                    invObj.CustomerListID = row.CustomerListID
                                    invObj.TxnID = row._InvTxnID
                                    invObj.BalanceRemaining = row.InvoiceBalance

                                    ' check for credits
                                    c_Procedures.Customer_CheckCredits(invObj)
                                    If (invObj.BalanceRemaining > 0) Then
                                        ' if balance remain after credits, check for overpayments
                                        c_Procedures.Customer_CheckOverpayments(invObj)
                                    End If
                                End If
                            End If
                        End If

                        ' checking for cancel request
                        If (worker.CancellationPending = True) Then
                            e.Cancel = True
                            Exit For
                        End If
                    Next row

                    ' update batch row for completion
                    ' and delete completed rows
                    Try
                        qta.BATCH_HISTORY_INVOICE_UpdateForCompletion(BatchID, Date.Now, err)
                        wita.Update(widt)
                        wita.DeleteComplete()
                    Catch ex As Exception
                        MsgBox("Batch History Invoice Complete Update: " & ex.Message)
                    End Try
                End If
            End If

            MsgSetRequest.ClearRequests()
            Me.Finalize()
        End Sub

        Private Sub Invoice(ByRef invRow As ds_Batching.BATCH_WorkingInvoiceRow)

            If (inSession) Then
                ' fill line table
                linedt = lita.GetData(invRow.WorkingInvoiceID)

                ' interfaces needed for invoicing and line items
                Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq
                ' not going to limit response. i want a lot of data back
                'invoiceAdd.IncludeRetElementList.Add("TxnID")
                'invoiceAdd.IncludeRetElementList.Add("RefNumber")
                'invoiceAdd.IncludeRetElementList.Add("BalanceRemaining")
                'invoiceAdd.IncludeRetElementList.Add("ORInvoiceLineRetList")

                ' build request
                invoiceAdd.CustomerRef.ListID.SetValue(invRow.CustomerListID)
                invoiceAdd.TxnDate.SetValue(invRow.InvoicePostDate)
                invoiceAdd.DueDate.SetValue(invRow.InvoiceDueDate)
                invoiceAdd.IsToBePrinted.SetValue(invRow.InvoiceToBePrinted)

                ' checking if memo provided
                If (invRow.IsInvoiceMemoNull = False) Then
                    invoiceAdd.Memo.SetValue(invRow.InvoiceMemo)
                End If

                ' line list
                Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
                ' line item to reuse
                Dim lineItem As IORInvoiceLineAdd

                ' loop through line items
                For Each lineRow As ds_Batching.BATCH_LineItemsRow In linedt.Rows
                    lineItem = lineList.Append

                    lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(lineRow.ServiceListID)
                    lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineRow.LineItemRate)
                    lineItem.InvoiceLineAdd.Quantity.SetValue(lineRow.LineItemQuantity)
                    lineItem.InvoiceLineAdd.Desc.SetValue(lineRow.Description)

                    ' writing table id to other1 so i can catch and update billed services with better detail
                    lineItem.InvoiceLineAdd.Other1.SetValue(lineRow.LineItemID)
                Next

                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList
                Dim resp As IResponse
                Dim invRet As IInvoiceRet
                Dim invLineRetList As IORInvoiceLineRetList
                Dim invLineRet As IORInvoiceLineRet

                For i = 0 To respList.Count - 1
                    resp = respList.GetAt(i)
                    If (resp.StatusCode <> 0) Then
                        invRow.InvoiceStatus = 6

                        Try
                            ' insert err row
                            wita.ERR_INVOICE_Insert(invRow.WorkingInvoiceID,
                                                    resp.StatusCode,
                                                    resp.StatusMessage)
                        Catch ex As Exception
                            MsgBox("Err_Invoice_Insert: " & ex.Message)
                        End Try

                    Else
                        ' delay update till billed services written
                        invRow.InvoiceStatus = 7

                        ' grabbing ret and lineRetList
                        invRet = resp.Detail
                        invLineRetList = invRet.ORInvoiceLineRetList

                        Dim lineID As String
                        Dim _ID As Integer
                        Dim row As ds_Batching.BATCH_LineItemsRow
                        ' looping through line rows to update their fields for billed history writing
                        For l = 0 To invLineRetList.Count - 1
                            invLineRet = invLineRetList.GetAt(l)
                            lineID = invLineRet.InvoiceLineRet.Other1.GetValue
                            _ID = Integer.Parse(lineID)

                            ' see if this works... going to grab row by dts key search feature
                            ' then update its linerow
                            row = linedt.FindByLineItemID(_ID)
                            row._LineTxnID = invLineRet.InvoiceLineRet.TxnLineID.GetValue
                        Next

                        ' updating invrow
                        invRow._InvTxnID = invRet.TxnID.GetValue
                        invRow._InvRefNum = invRet.RefNumber.GetValue
                        invRow.InvoiceBalance = invRet.BalanceRemaining.GetValue
                    End If
                Next

                MsgSetRequest.ClearRequests()
            End If
        End Sub

        Protected Overrides Sub Finalize()
            If (connected) Then
                If (inSession) Then
                    SessionManager.EndSession()
                    inSession = False
                End If
                SessionManager.CloseConnection()
                connected = False
            End If

            MyBase.Finalize()
        End Sub
    End Class


    Public Class Payments
        Inherits QB_Batching

        Protected dt As ds_Batching.BATCH_WorkingPaymentsDataTable

        ' current batch id
        Protected BatchID As Integer
        ' ta
        Protected ta As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter

        Public Sub New(ByVal BatchPayDT As ds_Batching.BATCH_WorkingPaymentsDataTable)
            MyBase.New()
            ' instantiating ta

            ta = New ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
            dt = BatchPayDT
        End Sub

        Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker,
                                    ByVal e As System.ComponentModel.DoWorkEventArgs)

            If (inSession) Then
                ' this will keep track of this batches progress
                Dim progress As New ProgressObj

                ' this is passed to the worker
                Dim progPercent As Integer

                ' this will keep track of time reporting so its not insane
                Dim lastReportTime As DateTime = Now
                ' this is how many milliseconds between progress reporting
                Dim elapsedTime As Double = 100

                If (dt.Rows.Count > 0) Then
                    ' setting maximum on progress class
                    progress.MaximumValue = dt.Rows.Count

                    ' err counter
                    Dim err As Integer

                    ' batch history insert
                    Try
                        BatchID = qta.BATCH_HISTORY_PAY_Insert(Date.Now, dt.Rows.Count)
                    Catch ex As Exception
                        MsgBox("Batch History Insert: " & ex.Message)
                        e.Cancel = True
                    End Try

                    For Each row As ds_Batching.BATCH_WorkingPaymentsRow In dt.Rows
                        ' updating progress counter and customer
                        progress.CurrentValue += 1
                        progress.CurrentCustomer = row.CustomerFullName

                        ' getting percent
                        progPercent = CInt(progress.CurrentValue / progress.MaximumValue * 100)

                        ' report if enough time has passed
                        If (Now > lastReportTime.AddMilliseconds(elapsedTime)) Then
                            worker.ReportProgress(progPercent, progress)
                        End If

                        ' send row
                        ReceivePayment(row)


                        ' update row in db
                        Try
                            ta.Update(row)
                        Catch ex As Exception
                            MsgBox("WorkingPayment Update: " & ex.Message)
                            e.Cancel = True
                            Exit For
                        End Try

                        ' check status
                        If (row.WorkingPaymentsStatus = 6) Then
                            ' update err
                            err += 1
                            e.Cancel = True
                            Exit For
                        ElseIf (row.WorkingPaymentsStatus = 7) Then
                            Try
                                ' insert for cash 
                                If (row.WorkingPaymentsType = 1) Then
                                    ta.PaymentHistory_Insert(row.CustomerNumber,
                                                        Nothing,
                                                        row.TxnID,
                                                        row.EditSequence,
                                                        row.WorkingPaymentsType,
                                                        row.WorkingPaymentsAmount,
                                                        row.TIME_RECEIVED,
                                                        Nothing,
                                                        BatchID,
                                                        row.InsertedByUser
                                                                            )

                                Else
                                    ' insert for non cash
                                    ta.PaymentHistory_Insert(row.CustomerNumber,
                                                        row.WorkingPaymentsCheckNum,
                                                        row.TxnID,
                                                        row.EditSequence,
                                                        row.WorkingPaymentsType,
                                                        row.WorkingPaymentsAmount,
                                                        row.TIME_RECEIVED,
                                                        row.DATE_ON_CHECK,
                                                        BatchID,
                                                        row.InsertedByUser)

                                End If


                            Catch ex As Exception
                                MsgBox("PayHistory Insert: " & ex.Message)
                                e.Cancel = True
                                Exit For
                            End Try

                        End If

                        ' checking for cancel request
                        If (worker.CancellationPending = True) Then
                            e.Cancel = True
                            Exit For
                        End If
                    Next row

                    ' update batch row for completeion
                    ' and delete completed rows
                    Try
                        qta.BATCH_HISTORY_PAY_UpdateForCompletion(BatchID, Date.Now, err)
                        ta.Update(dt)
                        ta.DeleteComplete()
                    Catch ex As Exception
                        MsgBox("Batch History Pay Complete Update: " & ex.Message)
                    End Try
                End If
            End If

            MsgSetRequest.ClearRequests()
            Me.Finalize()
        End Sub

        Private Sub ReceivePayment(ByRef row As ds_Batching.BATCH_WorkingPaymentsRow)

            ' building request
            Dim recPayment As IReceivePaymentAdd = MsgSetRequest.AppendReceivePaymentAddRq

            ' limiting response info
            recPayment.IncludeRetElementList.Add("RefNumber")
            recPayment.IncludeRetElementList.Add("TxnID")
            recPayment.IncludeRetElementList.Add("TimeCreated")
            recPayment.IncludeRetElementList.Add("EditSequence")

            ' grabbing list id
            recPayment.CustomerRef.ListID.SetValue(row.CustomerListID)
            recPayment.TotalAmount.SetValue(row.WorkingPaymentsAmount)
            recPayment.PaymentMethodRef.FullName.SetValue(row.QB_REFRENCE)
            recPayment.TxnDate.SetValue(row.TIME_RECEIVED)

            ' checking for a check number
            If (row.IsWorkingPaymentsCheckNumNull = False) Then
                recPayment.RefNumber.SetValue(row.WorkingPaymentsCheckNum)
            End If

            ' by default, they will auto apply and i will catch overpayments and apply them to open invoices
            recPayment.ORApplyPayment.IsAutoApply.SetValue(True)

            ' response work
            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' looping through response with error checking
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    Dim recPaymentRet As IReceivePaymentRet = resp.Detail


                    ' update to complete
                    row.WorkingPaymentsStatus = 7
                    ' get other values for history insert
                    row.TxnID = recPaymentRet.TxnID.GetValue
                    row.EditSequence = recPaymentRet.EditSequence.GetValue


                    If (recPaymentRet.RefNumber IsNot Nothing) Then
                        row.TxnNumber = recPaymentRet.RefNumber.GetValue
                    End If
                    row.DateReceived = recPaymentRet.TimeCreated.GetValue.Date
                Else
                    row.WorkingPaymentsStatus = 6


                    Try
                        ta.ERR_PAYMENTS_Insert(row.WorkingPaymentsID, resp.StatusCode.ToString, resp.StatusMessage)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next i

            MsgSetRequest.ClearRequests()
        End Sub

        Protected Overrides Sub Finalize()
            If (connected) Then
                If (inSession) Then
                    SessionManager.EndSession()
                    inSession = False
                End If
                SessionManager.CloseConnection()
                connected = False
            End If

            ' clear vars
            dt = Nothing
            ta = Nothing
            BatchID = Nothing
            MyBase.Finalize()
        End Sub
    End Class


    Protected Overrides Sub Finalize()
        If (connected) Then
            If (inSession) Then
                SessionManager.EndSession()
                inSession = False
            End If
            SessionManager.CloseConnection()
            connected = False
        End If

        'clear vars
        _sessMgr = Nothing
        _msgSetReq = Nothing
        connected = Nothing
        inSession = Nothing

        MyBase.Finalize()
    End Sub
End Class
