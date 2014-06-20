Imports TrashCash.QBStuff
'Imports TrashCash.ds_Batching

Namespace Batching


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
          
            ' tas
            Private ReadOnly _ta As ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
            Private ReadOnly _lineTA As ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter
            Private ReadOnly _bta As ds_BatchingTableAdapters.Batch_InvoicesTableAdapter
            Private ReadOnly _bdt As ds_Batching.Batch_InvoicesDataTable

            Private ReadOnly _targetedBillDate As Date
            Public Sub New(ByVal targetedBillDate As Date)
                MyBase.New()
                ' instantiating tas
                _ta = New ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
                _dt = New ds_Batching.BATCH_WorkingInvoiceDataTable
                _lineTA = New ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter
                _bta = New ds_BatchingTableAdapters.Batch_InvoicesTableAdapter
                _bdt = New ds_Batching.Batch_InvoicesDataTable
                _ta.Fill(_dt)
                _targetedBillDate = targetedBillDate
            End Sub

            Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs)

                ' this will keep track of this batches progress
                Dim progress As New ProgressObj
                ' this is passed to the worker
                Dim progPercent As Integer
                ' this will keep track of time reporting so its not insane
                Dim lastReportTime As DateTime = Now
                ' this is how many milliseconds between progress reporting
                Const elapsedTime As Double = 500
                Dim batchRow As ds_Batching.Batch_InvoicesRow = _bdt.NewBatch_InvoicesRow

                If (_dt.Rows.Count > 0) Then
                    ' setting maximum on progress class
                    progress.MaximumValue = _dt.Rows.Count
                    ' getting total of this batch
                    Dim startTotal As Double = _bta.QueueTotal
                    ' completed counter and batching row
                    Dim errCount As Integer
                    Dim errOnPrevRun As Boolean
                    Dim compCount As Integer
                    Dim compTotal As Double

                    With batchRow
                        .TargetedBillDate = _targetedBillDate
                        .StartCount = _dt.Rows.Count
                        .StartSubtotal = startTotal
                        .StartTime = Date.Now
                        .StartUser = CurrentUser.USER_NAME
                        .ConnInterrupt = True
                    End With
                    _bdt.AddBatch_InvoicesRow(batchRow)

                    Try
                        ' batch inv row created
                        _bta.Update(batchRow)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    ' start looping through rows
                    For Each row As ds_Batching.BATCH_WorkingInvoiceRow In _dt.Rows
                        If (row.InvoiceStatus = 5) Then
                            ' checking if we errored and prompting to continue
                            If (errOnPrevRun) Then
                                Dim result As DialogResult = MessageBox.Show("There was an error adding the previous Invoice. Do you wish to continue with the batch?", "Batch Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                                If (result = DialogResult.Yes) Then
                                    e.Cancel = True
                                End If
                                ' reset bool
                                errOnPrevRun = False
                            End If
                            ' checking for cancel request
                            If (worker.CancellationPending = True) Then
                                e.Cancel = True
                                batchRow.Canceled = True
                                Exit For
                            End If
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
                            Dim invObj As QBInvoiceObj = Invoice(row, compTotal, batchRow.InvBatch_ID)

                            ' check status
                            If (row.InvoiceStatus = TC_ENItemStatus.Complete) Then
                                ' increment completed
                                compCount += 1
                                Try
                                    ' update batch row
                                    batchRow.CompletedCount = compCount
                                    batchRow.CompletedSubtotal = compTotal
                                    _bta.Update(batchRow)
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                                If (custBalance < 0) Then
                                    ' attempt to pay invoice
                                    QBMethods.PayInvoice(invObj, qbConMgr:=ConMgr)
                                End If
                            Else
                                errCount += 1
                                errOnPrevRun = True
                                Try
                                    ' update batch row
                                    batchRow.ErrCount = errCount
                                    _bta.Update(batchRow)
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                            End If
                        End If
                    Next row
                    ' update batch row for completion
                    With batchRow
                        .CompletedCount = compCount
                        .CompletedSubtotal = compTotal
                        .ErrCount = errCount
                        .EndTime = Date.Now
                        .EndUser = CurrentUser.USER_NAME
                        .ConnInterrupt = False
                    End With
                    Try
                        ' update batch row for completion
                        ' and delete completed rows
                        _bta.Update(batchRow)
                        _ta.Update(_dt)
                        _ta.DeleteComplete()
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
                Finalize()

            End Sub

            Private Function Invoice(ByRef row As ds_Batching.BATCH_WorkingInvoiceRow, ByRef compTotal As Double, ByRef batchID As Integer) As QBInvoiceObj
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

                Try
                    ' update to submited
                    row.InvoiceStatus = TC_ENItemStatus.Submitted
                    _ta.Update(row)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' i want to get the response back incase of errors
                Dim s As String = "s"
                Dim resp As Integer = QBRequests.InvoiceAdd(invObj:=invObj, qbConMgr:=ConMgr, message:=s)
                If (resp = 0) Then
                    ' looping through line rows to update their fields for billed history writing
                    For Each line As QBLineItemObj In invObj.LineList
                        Try
                            ' this should work for inserting history right here
                            _qta.BilledServices_InsertByLineItemID(line.Other1,
                                                                    invObj.TxnID,
                                                                    invObj.RefNumber,
                                                                    line.TxnLineID,
                                                                    batchID,
                                                                    line.Amount)
                            ' add total to completed
                            compTotal += line.Amount
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                    Try
                        ' update row
                        row.InvoiceStatus = TC_ENItemStatus.Complete
                        _ta.Update(row)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    row.InvoiceStatus = TC_ENItemStatus.Err
                    Try
                        ' insert error record
                        _ta.ERR_INVOICE_Insert(row.WorkingInvoiceID, resp, s)
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
            ' ta
            Private ReadOnly _ta As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
            Private ReadOnly _bta As ds_BatchingTableAdapters.Batch_PaymentsTableAdapter
            Private ReadOnly _bdt As ds_Batching.Batch_PaymentsDataTable

            Public Sub New()
                MyBase.New()
                ' instantiating ta
                _ta = New ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
                _dt = New ds_Batching.BATCH_WorkingPaymentsDataTable
                _ta.Fill(_dt)
                _bta = New ds_BatchingTableAdapters.Batch_PaymentsTableAdapter
                _bdt = New ds_Batching.Batch_PaymentsDataTable
            End Sub

            Public Sub Batch(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs)

                ' this will keep track of this batches progress
                Dim progress As New ProgressObj
                ' this is passed to the worker
                Dim progPercent As Integer
                ' this will keep track of time reporting so its not insane
                Dim lastReportTime As DateTime = Now
                ' this is how many milliseconds between progress reporting
                Const elapsedTime As Double = 100
                Dim batchRow As ds_Batching.Batch_PaymentsRow = _bdt.NewBatch_PaymentsRow

                If (_dt.Rows.Count > 0) Then
                    ' setting maximum on progress class
                    progress.MaximumValue = _dt.Rows.Count
                    ' getting total of this batch
                    Dim startTotal As Double = _dt.Compute("SUM(WorkingPaymentsAmount)", "")
                    ' completed counter and batching row
                    Dim errCount As Integer
                    Dim errOnPrevRun As Boolean
                    Dim compCount As Integer
                    Dim compTotal As Double

                    With batchRow
                        .StartCount = _dt.Rows.Count
                        .StartTotal = startTotal
                        .StartTime = Date.Now
                        .StartUser = CurrentUser.USER_NAME
                        .ConnInterrupt = True
                    End With
                    _bdt.AddBatch_PaymentsRow(batchRow)
                    Try
                        ' batch row creation
                        _bta.Update(batchRow)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    For Each row As ds_Batching.BATCH_WorkingPaymentsRow In _dt.Rows
                        If (row.WorkingPaymentsStatus = 5) Then
                            ' checking if we errored and prompting to continue
                            If (errOnPrevRun) Then
                                Dim result As DialogResult = MessageBox.Show("There was an error adding the previous Invoice. Do you wish to continue with the batch?", "Batch Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                                If (result = DialogResult.Yes) Then
                                    e.Cancel = True
                                End If
                                ' reset bool
                                errOnPrevRun = False
                            End If
                            ' checking for cancel request
                            If (worker.CancellationPending = True) Then
                                e.Cancel = True
                                batchRow.Canceled = True
                                Exit For
                            End If
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
                            If (row.WorkingPaymentsStatus = TC_ENItemStatus.Complete) Then
                                ' increment completed
                                compCount += 1
                                Try
                                    ' update batch row
                                    batchRow.CompletedCount = compCount
                                    batchRow.CompletedSubtotal = compTotal
                                    _bta.Update(batchRow)

                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                                ' inserting history record
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
                                                                                batchRow.PayBatch_ID,
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
                                                                    batchRow.PayBatch_ID,
                                                                    row.InsertedByUser)

                                    End If
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            Else
                                errCount += 1
                                errOnPrevRun = True
                                Try
                                    ' update batch row
                                    batchRow.ErrCount = errCount
                                    _bta.Update(batchRow)
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                            End If
                        End If
                    Next row
                    ' update batch row for completion
                    With batchRow
                        .CompletedCount = compCount
                        .CompletedSubtotal = compTotal
                        .ErrCount = errCount
                        .EndTime = Date.Now
                        .EndUser = CurrentUser.USER_NAME
                        .ConnInterrupt = False
                    End With
                    Try
                        ' update batch row for completion
                        ' and delete completed rows
                        _bta.Update(batchRow)
                        _ta.Update(_dt)
                        _ta.DeleteComplete()
                    Catch ex As SqlException
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
                ' i want the status message back for err writing
                Dim s As String = "s"
                Dim resp As Integer = QBRequests.PaymentAdd(payObj:=payObj, qbConMgr:=ConMgr, message:=s)
                If (resp = 0) Then
                    ' update to complete
                    row.WorkingPaymentsStatus = TC_ENItemStatus.Complete
                Else
                    row.WorkingPaymentsStatus = TC_ENItemStatus.Err
                    Try
                        _ta.ERR_PAYMENTS_Insert(row.WorkingPaymentsID, resp, s)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
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