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
                    Catch ex As SqlException
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
                        
                        ' send invoice through row
                        Dim invObj As QBInvoiceObj = Invoice(row)

                        ' check status
                        If (row.InvoiceStatus = ENItemStatus.Err) Then
                            ' update err count
                            err += 1
                        ElseIf (row.InvoiceStatus = ENItemStatus.Complete) Then
                            While invObj.BalanceRemaining > 0
                                If (custBalance < 0) Then
                                    ' attempt to pay invoice
                                    QBMethods.PayInvoice_WithExcessFunds(invObj, qbConMgr:=ConMgr)
                                End If
                            End While
                        End If
                        ' checking for cancel request
                        If (worker.CancellationPending = True) Then
                            e.Cancel = True
                            Exit For
                        End If
                    Next row
                    Try
                        ' update batch row for completion
                        ' and delete completed rows
                        _qta.BATCH_HISTORY_INVOICE_UpdateForCompletion(_batchID, Date.Now, err)
                        _ta.Update(_dt)
                        _ta.DeleteComplete()
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Private ReadOnly _dt As ds_Batching.BATCH_WorkingPaymentsDataTable

            ' current batch id
            Private _batchID As Integer
            ' ta
            Private ReadOnly _ta As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter

            Public Sub New(ByVal batchPayDt As ds_Batching.BATCH_WorkingPaymentsDataTable)
                MyBase.New()
                ' instantiating ta
                _ta = New ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
                _dt = batchPayDt
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
                        _batchID = _qta.BATCH_HISTORY_PAY_Insert(Date.Now, _dt.Rows.Count)
                    Catch ex as SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                  
                    For Each row As ds_Batching.BATCH_WorkingPaymentsRow In _dt.Rows
                        ' updating progress counter and customer
                        progress.CurrentValue += 1
                        progress.CurrentCustomer = row.CustomerFullName
                        ' getting percent
                        progPercent = CInt(progress.CurrentValue / progress.MaximumValue * 100)
                        ' report if enough time has passed
                        If (Now > lastReportTime.AddMilliseconds(elapsedTime)) Then
                            worker.ReportProgress(progPercent, progress)
                        End If

                        ' send payment to quickbooks through row ref
                        Dim payObj As QBRecievePaymentObj = ReceivePayment(row)

                        ' check status
                        If (row.WorkingPaymentsStatus = ENItemStatus.Err) Then
                            ' update err
                            err += 1
                        ElseIf (row.WorkingPaymentsStatus = ENItemStatus.Complete) Then
                            Try
                                ' insert for cash 
                                If (row.WorkingPaymentsType = 1) Then
                                    _ta.PaymentHistory_Insert(row.CustomerNumber,
                                                              Nothing,
                                                              payObj.TxnID,
                                                              payObj.EditSequence,
                                                              row.WorkingPaymentsType,
                                                              payObj.TotalAmount,
                                                              row.TIME_RECEIVED,
                                                              Nothing,
                                                              _batchID,
                                                              row.InsertedByUser
                                                              )

                                Else
                                    ' insert for non cash
                                    _ta.PaymentHistory_Insert(row.CustomerNumber,
                                                              payObj.RefNumber,
                                                              payObj.TxnID,
                                                              payObj.EditSequence,
                                                              row.WorkingPaymentsType,
                                                              payObj.TotalAmount,
                                                              row.TIME_RECEIVED,
                                                              row.DATE_ON_CHECK,
                                                              _batchID,
                                                              row.InsertedByUser)

                                End If
                            Catch ex As SqlException
                                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End If
                        ' checking for cancel request
                        If (worker.CancellationPending = True) Then
                            e.Cancel = True
                            Exit For
                        End If
                    Next row
                    Try
                        ' update batch row for completeion
                        ' and delete completed rows
                        _qta.BATCH_HISTORY_PAY_UpdateForCompletion(_batchID, Date.Now, err)
                        _ta.Update(_dt)
                        _ta.DeleteComplete()
                    Catch ex as SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If

                Finalize()
            End Sub

            Private Function ReceivePayment(ByRef row As ds_Batching.BATCH_WorkingPaymentsRow) As QBRecievePaymentObj
                ' return obj
                Dim payObj As New QBRecievePaymentObj
                With payObj
                    .CustomerListID = row.CustomerListID
                    .TotalAmount = row.WorkingPaymentsAmount
                    .PayTypeName = row.QB_REFRENCE
                    .TxnDate = row.TIME_RECEIVED
                    If (Not row.IsWorkingPaymentsCheckNumNull) Then
                        .RefNumber = row.WorkingPaymentsCheckNum
                    End If
                End With

                Dim resp As IResponse = QBRequests.PaymentAdd(payObj:=payObj, qbConMgr:=ConMgr)
                If (resp.StatusCode = 0) Then
                    Dim recPaymentRet As IReceivePaymentRet = resp.Detail
                    ' update to complete
                    row.WorkingPaymentsStatus = ENItemStatus.Complete
                    ' get other values for history insert
                    payObj.TxnID = recPaymentRet.TxnID.GetValue
                    payObj.EditSequence = recPaymentRet.EditSequence.GetValue
                    If (recPaymentRet.RefNumber IsNot Nothing) Then
                        payObj.RefNumber = recPaymentRet.RefNumber.GetValue
                    End If
                Else
                    row.WorkingPaymentsStatus = ENItemStatus.Err
                    Try
                        _ta.ERR_PAYMENTS_Insert(row.WorkingPaymentsID, resp.StatusCode.ToString, resp.StatusMessage)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

                Try
                    _ta.Update(row)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Return payObj
            End Function

            Protected Overrides Sub Finalize()
                MyBase.Finalize()
            End Sub
        End Class


        Protected Overrides Sub Finalize()
            ConMgr.CloseCon()
        End Sub
    End Class
End Namespace