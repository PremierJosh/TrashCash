Imports TrashCash.QBStuff
Imports QBFC12Lib

Namespace Classes


    ' ReSharper disable once InconsistentNaming
    Public MustInherit Class QB_Batching
        Protected Friend ConMgr As QBConMgr
        
        ' qta
        Private ReadOnly _qta As ds_BatchingTableAdapters.QueriesTableAdapter

        Protected Friend Sub New()
            If (ConMgr Is Nothing) Then
                ConMgr = New QBConMgr
                ConMgr.InitCon()
            End If

            _qta = New ds_BatchingTableAdapters.QueriesTableAdapter
        End Sub

        Public Class Invoicing
            Inherits QB_Batching

            ' dt for line items
            Private _lineDT As ds_Batching.BATCH_LineItemsDataTable
            ' dt for invoices
            Private ReadOnly _dt As ds_Batching.BATCH_WorkingInvoiceDataTable
            ' current batch id
            Private _batchID As Integer

            ' tas
            Private ReadOnly _ta As ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
            Private ReadOnly _lineTA As ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter

            Public Sub New(ByVal invoiceDt As ds_Batching.BATCH_WorkingInvoiceDataTable)
                MyBase.New()
                ' instantiating tas
                _ta = New ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
                _lineTA = New ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter

                _dt = invoiceDt
            End Sub

            Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker,
                             ByVal e As System.ComponentModel.DoWorkEventArgs)
             ' this will keep track of this batches progress
                Dim progress As New ProgressObj
                ' this is passed to the worker
                    Dim progPercent As Integer
                ' this will keep track of time reporting so its not insane
                    Dim lastReportTime As DateTime = Now
                    ' this is how many milliseconds between progress reporting
                    Const elapsedTime As Double = 100
                

                    If (_dt.Rows.Count > 0) Then
                        ' setting maximum on progress class
                        progress.MaximumValue = _dt.Rows.Count

                        ' err counter
                        Dim err As Integer
                        Try
                            ' batch history insert
                            _batchID = _qta.BATCH_HISTORY_INV_Insert(Date.Now, _dt.Rows.Count)
                        Catch ex as SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        ' start looping through rows
                        For Each row As ds_Batching.BATCH_WorkingInvoiceRow In _dt.Rows
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
                        Dim custBalance As Double = ConMgr.GetCustomerBalance(row.CustomerListID)


                        ' send row
                        Dim invObj As QBInvoiceObj
                            Invoice(row)

                           ' check status
                            If (row.InvoiceStatus = 6) Then
                                ' update err count
                                err += 1
                            ElseIf (row.InvoiceStatus = 7) Then
                            If (invObj.BalanceRemaining > 0) Then
                                If (custBalance < 0) Then
                                    ' get list of creditObjs avail for use
                                    Dim resp As IResponse = QBRequests.CreditMemoQuery(listID:=invObj.CustomerListID, qbConMgr:=ConMgr)
                                    Dim creditObjList As List(Of QBCreditObj) = QBMethods.
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
                            _qta.BATCH_HISTORY_INVOICE_UpdateForCompletion(_batchID, Date.Now, err)
                            _ta.Update(_dt)
                            _ta.DeleteComplete()
                        Catch ex As Exception
                            MsgBox("Batch History Invoice Complete Update: " & ex.Message)
                        End Try
                    End If
              
            Finalize()
            End Sub

            Private Function Invoice(ByRef row As ds_Batching.BATCH_WorkingInvoiceRow) As QBInvoiceObj
                ' create invObj
                Dim invObj As New QBInvoiceObj
                With invObj
                    .CustomerListID = row.CustomerListID
                    .DueDate = row.InvoiceDueDate
                    .TxnDate = row.InvoicePostDate
                    .IsToBePrinted = row.InvoiceToBePrinted
                    ' checking memo
                    If (Not row.IsInvoiceMemoNull) Then
                        .Memo = row.InvoiceMemo
                    End If
                    .LineList = New List(Of QBLineItemObj)
                End With
                ' fill line table
                _lineDT = _lineTA.GetData(row.WorkingInvoiceID)
                ' loop through line items
                For Each lineRow As ds_Batching.BATCH_LineItemsRow In _lineDT.Rows
                    Dim line As New QBLineItemObj
                    With line
                        .ItemListID = lineRow.ServiceListID
                        .Rate = lineRow.LineItemRate
                        .Quantity = lineRow.LineItemQuantity
                        .Desc = lineRow.Description
                        ' writing table id to other1 so i can catch and update billed services with better detail
                        .Other1 = lineRow.LineItemID
                    End With
                    ' add line
                    invObj.LineList.Add(line)
                Next

                Dim resp As IResponse = QBRequests.InvoiceAdd(invObj:=invObj, qbConMgr:=ConMgr)
                If (resp.StatusCode = 0) Then
                    row.InvoiceStatus = ENItemStatus.Complete
                    ' grabbing ret and lineRetList
                    Dim invRet As IInvoiceRet = resp.Detail
                    ' updating invObj
                    With invObj
                        .TxnID = invRet.TxnID.GetValue
                        .RefNumber = invRet.RefNumber.GetValue
                        .BalanceRemaining = invRet.BalanceRemaining.GetValue
                    End With

                    ' looping through line rows to update their fields for billed history writing
                    Dim retLineList As IORInvoiceLineRetList = invRet.ORInvoiceLineRetList
                    For i = 0 To retLineList.Count - 1
                        Dim lineRet As IORInvoiceLineRet = retLineList.GetAt(i)
                        Dim lineID As String = lineRet.InvoiceLineRet.Other1.GetValue
                        Try
                            ' this should work for inserting history right here
                            _qta.BilledServices_InsertByLineItemID(Integer.Parse(lineID),
                                                                    invObj.TxnID,
                                                                    invObj.RefNumber,
                                                                    lineRet.InvoiceLineRet.TxnLineID.GetValue,
                                                                    _batchID,
                                                                    lineRet.InvoiceLineRet.Amount.GetValue)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                    Try
                        ' update row
                        _ta.Update(row)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    row.InvoiceStatus = ENItemStatus.Err
                    Try
                        ' insert error record
                        _ta.ERR_INVOICE_Insert(row.WorkingInvoiceID, resp.StatusCode, resp.StatusMessage)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If

                Return invObj
            End Function

            Protected Overrides Sub Finalize()
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
            ConMgr.CloseCon()
        End Sub
    End Class
End Namespace