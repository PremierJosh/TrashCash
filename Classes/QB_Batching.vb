Imports QBFC12Lib

Namespace Classes


    ' ReSharper disable once InconsistentNaming
    Public MustInherit Class QB_Batching
        Protected MsgSetReq As IMsgSetRequest
        Private ReadOnly Property MsgSetRequest As IMsgSetRequest
            Get
                Return MsgSetReq
            End Get
        End Property
        Protected SessMgr As QBSessionManager
        Private ReadOnly Property SessionManager As QBSessionManager
            Get
                Return SessMgr
            End Get
        End Property

        ' connection status bool
        Protected Connected As Boolean
        ' session status bool
        Protected InSession As Boolean
        ' class vars
        Private ReadOnly _queries As QB_Queries
        Private ReadOnly _procedures As QB_Procedures
        ' qta
        Private ReadOnly _qta As ds_BatchingTableAdapters.QueriesTableAdapter

        Public Sub New()
            SessMgr = New QBSessionManager

            If (Not Connected) Then
                SessionManager.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
                Connected = True
            End If
            If (Not InSession) Then
                SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)
                InSession = True
            End If

            MsgSetReq = SessionManager.CreateMsgSetRequest("US", 11, 0)

            ' instantiate 
            _queries = New QB_Queries(SessionManager, MsgSetRequest)
            _procedures = New QB_Procedures(SessionManager, MsgSetRequest)
            _qta = New ds_BatchingTableAdapters.QueriesTableAdapter
        End Sub

        Public Class Invoicing
            Inherits QB_Batching

            ' dt for line items
            Protected Linedt As ds_Batching.BATCH_LineItemsDataTable
            ' dt for invoices
            Protected Widt As ds_Batching.BATCH_WorkingInvoiceDataTable
            ' current batch id
            Protected BatchID As Integer

            ' tas
            Protected Wita As ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
            Protected Lita As ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter

            Public Sub New(ByVal invoiceDt As ds_Batching.BATCH_WorkingInvoiceDataTable)
                MyBase.new()
                ' instantiating tas
                Wita = New ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
                Lita = New ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter

                Widt = invoiceDt
            End Sub

            Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker,
                             ByVal e As System.ComponentModel.DoWorkEventArgs)
                If (InSession) Then
                    ' this will keep track of this batches progress
                    Dim progress As New Utilities.ProgressObj

                    ' this is passed to the worker
                    Dim progPercent As Integer

                    ' this will keep track of time reporting so its not insane
                    Dim lastReportTime As DateTime = Now
                    ' this is how many milliseconds between progress reporting
                    Const elapsedTime As Double = 100


                    If (Widt.Rows.Count > 0) Then
                        ' setting maximum on progress class
                        progress.MaximumValue = Widt.Rows.Count

                        ' err counter
                        Dim err As Integer

                        ' batch history insert
                        Try
                            BatchID = _qta.BATCH_HISTORY_INV_Insert(Date.Now, Widt.Rows.Count)
                        Catch ex As SqlClient.SqlException
                            MsgBox("Batch History Insert: " & ex.Message)
                        End Try

                        ' start looping through rows
                        For Each row As ds_Batching.BATCH_WorkingInvoiceRow In Widt.Rows
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
                            Dim custBalance As Double = _queries.Customer_Balance(row.CustomerListID)

                            ' send row
                            Invoice(row)

                            ' update row in db
                            Try
                                Wita.Update(row)
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
                                    For Each lineRow As ds_Batching.BATCH_LineItemsRow In Linedt.Rows
                                        ' get total of line row
                                        Dim lineTotal As Double = (lineRow.LineItemRate * lineRow.LineItemQuantity)

                                        Try
                                            _qta.BilledServices_InsertByLineItemID(lineRow.LineItemID,
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
                                        Dim invObj As New QB_Procedures.NewInvObj
                                        invObj.CustomerListID = row.CustomerListID
                                        invObj.TxnID = row._InvTxnID
                                        invObj.BalanceRemaining = row.InvoiceBalance

                                        ' check for credits
                                        _procedures.Customer_CheckCredits(invObj)
                                        If (invObj.BalanceRemaining > 0) Then
                                            ' if balance remain after credits, check for overpayments
                                            _procedures.Customer_CheckOverpayments(invObj)
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
                            _qta.BATCH_HISTORY_INVOICE_UpdateForCompletion(BatchID, Date.Now, err)
                            Wita.Update(Widt)
                            Wita.DeleteComplete()
                        Catch ex As Exception
                            MsgBox("Batch History Invoice Complete Update: " & ex.Message)
                        End Try
                    End If
                End If

                MsgSetRequest.ClearRequests()
                Finalize()
            End Sub

            Private Sub Invoice(ByRef invRow As ds_Batching.BATCH_WorkingInvoiceRow)

                If (InSession) Then
                    ' fill line table
                    Linedt = Lita.GetData(invRow.WorkingInvoiceID)

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
                    For Each lineRow As ds_Batching.BATCH_LineItemsRow In Linedt.Rows
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
                                Wita.ERR_INVOICE_Insert(invRow.WorkingInvoiceID,
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
                            Dim id As Integer
                            Dim row As ds_Batching.BATCH_LineItemsRow
                            ' looping through line rows to update their fields for billed history writing
                            For l = 0 To invLineRetList.Count - 1
                                invLineRet = invLineRetList.GetAt(l)
                                lineID = invLineRet.InvoiceLineRet.Other1.GetValue
                                id = Integer.Parse(lineID)

                                ' see if this works... going to grab row by dts key search feature
                                ' then update its linerow
                                row = Linedt.FindByLineItemID(id)
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
                If (Connected) Then
                    If (InSession) Then
                        SessionManager.EndSession()
                        InSession = False
                    End If
                    SessionManager.CloseConnection()
                    Connected = False
                End If

                MyBase.Finalize()
            End Sub
        End Class


        Public Class Payments
            Inherits QB_Batching

            Protected Dt As ds_Batching.BATCH_WorkingPaymentsDataTable

            ' current batch id
            Protected BatchID As Integer
            ' ta
            Protected Ta As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter

            Public Sub New(ByVal batchPayDt As ds_Batching.BATCH_WorkingPaymentsDataTable)
                MyBase.New()
                ' instantiating ta

                Ta = New ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
                Dt = batchPayDt
            End Sub

            Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker,
                             ByVal e As System.ComponentModel.DoWorkEventArgs)

                If (InSession) Then
                    ' this will keep track of this batches progress
                    Dim progress As New Utilities.ProgressObj

                    ' this is passed to the worker
                    Dim progPercent As Integer

                    ' this will keep track of time reporting so its not insane
                    Dim lastReportTime As DateTime = Now
                    ' this is how many milliseconds between progress reporting
                    Const elapsedTime As Double = 100

                    If (Dt.Rows.Count > 0) Then
                        ' setting maximum on progress class
                        progress.MaximumValue = Dt.Rows.Count

                        ' err counter
                        Dim err As Integer

                        ' batch history insert
                        Try
                            BatchID = _qta.BATCH_HISTORY_PAY_Insert(Date.Now, Dt.Rows.Count)
                        Catch ex As Exception
                            MsgBox("Batch History Insert: " & ex.Message)
                            e.Cancel = True
                        End Try

                        For Each row As ds_Batching.BATCH_WorkingPaymentsRow In Dt.Rows
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
                                Ta.Update(row)
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
                                        Ta.PaymentHistory_Insert(row.CustomerNumber,
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
                                        Ta.PaymentHistory_Insert(row.CustomerNumber,
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
                            _qta.BATCH_HISTORY_PAY_UpdateForCompletion(BatchID, Date.Now, err)
                            Ta.Update(Dt)
                            Ta.DeleteComplete()
                        Catch ex As Exception
                            MsgBox("Batch History Pay Complete Update: " & ex.Message)
                        End Try
                    End If
                End If

                MsgSetRequest.ClearRequests()
                Finalize()
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
                            Ta.ERR_PAYMENTS_Insert(row.WorkingPaymentsID, resp.StatusCode.ToString, resp.StatusMessage)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Next i

                MsgSetRequest.ClearRequests()
            End Sub

            Protected Overrides Sub Finalize()
                If (Connected) Then
                    If (InSession) Then
                        SessionManager.EndSession()
                        InSession = False
                    End If
                    SessionManager.CloseConnection()
                    Connected = False
                End If

                ' clear vars
                Dt = Nothing
                Ta = Nothing
                BatchID = Nothing
                MyBase.Finalize()
            End Sub
        End Class


        Protected Overrides Sub Finalize()
            If (Connected) Then
                If (InSession) Then
                    SessionManager.EndSession()
                    InSession = False
                End If
                SessionManager.CloseConnection()
                Connected = False
            End If

            'clear vars
            SessMgr = Nothing
            MsgSetReq = Nothing
            Connected = Nothing
            InSession = Nothing

            MyBase.Finalize()
        End Sub
    End Class
End Namespace