Imports TrashCash.QBStuff
'Imports TrashCash.ds_Batching

Namespace Batching
    Public Class BatchInterruption

        ' batch type bool fields
        Friend PaymentBatch As Boolean
        Private _payBatchRow As ds_Batching.Batch_PaymentsRow
        Friend InvoiceBatch As Boolean
        Private _invBatchRow As ds_Batching.Batch_InvoicesRow


        ' tas
        Private _batchInvTA As ds_BatchingTableAdapters.Batch_InvoicesTableAdapter
        Private _batchPayTA As ds_BatchingTableAdapters.Batch_PaymentsTableAdapter



        Private Sub BatchInterruption_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            If (InvoiceBatch) Then
                ' instantiate ta
                _batchInvTA = New ds_BatchingTableAdapters.Batch_InvoicesTableAdapter
                _invBatchRow = _batchInvTA.GetNewest.Rows(0)
            ElseIf (PaymentBatch) Then
                ' instantiate ta
                _batchPayTA = New ds_BatchingTableAdapters.Batch_PaymentsTableAdapter
                _payBatchRow = _batchPayTA.GetNewest.Rows(0)
            End If

            ' checking if anything is submitted and if it needs work
            MessageBox.Show("Checking integrity of last Batch. This could take 1-2 minutes...")
            CheckSubmitted()
            MessageBox.Show("Batch queue verified. Ready to complete Batch.")
        End Sub



        Private Sub CheckSubmitted()
            Dim qta As New ds_BatchingTableAdapters.QueriesTableAdapter
            If (InvoiceBatch) Then
                Dim invTA As New ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
                Dim invDT As ds_Batching.BATCH_WorkingInvoiceDataTable = invTA.GetSubmitted
                ' any submitted we need to query for the invoice to see if it went
                If (invDT.Rows.Count > 0) Then
                    Dim lineTA As New ds_BatchingTableAdapters.BATCH_LineItemsTableAdapter
                    For Each row As ds_Batching.BATCH_WorkingInvoiceRow In invDT
                        ' lets get invoices on this customer made 1 day before this invoices post date
                        Dim invObjList As New List(Of QBInvoiceObj)
                        QBRequests.InvoiceQuery(invObjList, customerListID:=row.CustomerListID, fromDate:=DateAdd(DateInterval.Day, -1, row.InvoicePostDate), incLineItems:=True)
                        If (invObjList.Count > 0) Then
                            ' lets get line items for this invoice
                            Dim lineDT As ds_Batching.BATCH_LineItemsDataTable = lineTA.GetData(row.WorkingInvoiceID)
                            ' lets check line items on all returned invoices for the line items on this invoice
                            ' going to count how many we match and compare to how many in table
                            Dim matchCount As Integer
                            For Each lineRow As ds_Batching.BATCH_LineItemsRow In lineDT
                                For Each invObj As QBInvoiceObj In invObjList
                                    If (invObj.LineList IsNot Nothing) Then
                                        For Each line As QBLineItemObj In invObj.LineList
                                            If (lineRow.LineItemID = line.Other1) Then
                                                matchCount += 1
                                                ' checking if entry is in database
                                                If (Not qta.BilledServices_LineItemIDExist(lineRow.LineItemID)) Then
                                                    qta.BilledServices_InsertByLineItemID(lineRow.LineItemID, invObj.TxnID, invObj.RefNumber, line.TxnLineID, _invBatchRow.InvBatch_ID, lineRow.LineItemRate)
                                                End If
                                            End If
                                        Next
                                    End If
                                Next
                            Next
                            ' checking how many we matched vs how many in table
                            If (matchCount = lineDT.Rows.Count) Then
                                row.InvoiceStatus = TC_ENItemStatus.Complete
                                Try
                                    ' update the completed count
                                    _invBatchRow.CompletedCount += 1
                                    _batchInvTA.Update(_invBatchRow)
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                            Else
                                ' invoice not there, needs to be re-submitted
                                row.InvoiceStatus = TC_ENItemStatus.Ready
                            End If
                        Else
                            'no invoices, needs to be resubmitted
                            row.InvoiceStatus = TC_ENItemStatus.Ready
                        End If
                        Try
                            ' update with new status
                            invTA.Update(row)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If
            ElseIf (PaymentBatch) Then
                Dim payTA As New ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
                Dim payDT As ds_Batching.BATCH_WorkingPaymentsDataTable = payTA.GetSubmitted
                ' checking if any are submitted
                If (payDT.Rows.Count > 0) Then
                    For Each row As ds_Batching.BATCH_WorkingPaymentsRow In payDT
                        ' get payments made after this date
                        Dim payObjList As New List(Of QBRecievePaymentObj)
                        QBRequests.PaymentQuery(payObjList, customerListID:=row.CustomerListID, fromDate:=DateAdd(DateInterval.Day, -1, row.TIME_RECEIVED))
                        If (payObjList.Count > 0) Then
                            ' checking if payment exists in ret list
                            Dim payFound As Boolean
                            For Each payObj As QBRecievePaymentObj In payObjList
                                If (row.WorkingPaymentsID = payObj.Memo) Then
                                    ' payment found
                                    payFound = True
                                    ' if history doesnt exist, insert it
                                    If (Not qta.PaymentHistory_TxnIDExists(payObj.TxnID)) Then
                                        qta.PaymentHistory_Insert(row.WorkingPaymentsID, payObj.TxnID, payObj.EditSequence, _payBatchRow.PayBatch_ID, CurrentUser.USER_NAME)
                                    End If
                                End If
                            Next
                            ' checking if we found payment, update batch count and pay row
                            If (payFound) Then
                                row.WorkingPaymentsStatus = TC_ENItemStatus.Complete
                                Try
                                    _payBatchRow.CompletedCount += 1
                                    _batchPayTA.Update(_payBatchRow)
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                            Else
                                ' payment not found, needs to be resubmitted
                                row.WorkingPaymentsStatus = TC_ENItemStatus.Ready
                            End If
                        Else
                            'no payments found, needs to be resubmitted
                            row.WorkingPaymentsStatus = TC_ENItemStatus.Ready
                        End If
                        Try
                            ' update payment row
                            payTA.Update(row)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If
            End If

        End Sub


        Private Sub btn_FinBatch_Click(sender As System.Object, e As System.EventArgs) Handles btn_FinBatch.Click
            Dim result As MsgBoxResult = MsgBox("Begin batching?", MsgBoxStyle.YesNo)
            If (result = vbYes) Then
                ' show labels
                lbl_Count.Visible = True
                lbl_CustName.Visible = True
                If (InvoiceBatch) Then
                    ' date passed here doesn't matter
                    Dim batchInv As New QB_Batching.Invoicing()
                    BatchWorker.RunWorkerAsync(batchInv)
                ElseIf (PaymentBatch) Then
                    Dim batchPay As New QB_Batching.Payments
                    BatchWorker.RunWorkerAsync(batchPay)
                End If
            End If
        End Sub

        Private Sub BatchWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BatchWorker.DoWork
            ' create worker ref
            Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

            If (BatchWorker.CancellationPending = True) Then
                e.Cancel = True
                Exit Sub
            End If
            If (InvoiceBatch) Then
                e.Argument.batch(worker, e, _invBatchRow)
            ElseIf (PaymentBatch) Then
                e.Argument.batch(worker, e, _payBatchRow)
            End If

        End Sub

        Private Sub BatchWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BatchWorker.ProgressChanged
            Dim progress As ProgressObj = CType(e.UserState, ProgressObj)
            If (pb_Batch.Maximum <> progress.MaximumValue) Then
                pb_Batch.Maximum = progress.MaximumValue
            End If
            pb_Batch.Value = progress.CurrentValue
            lbl_Count.Text = progress.CurrentValue & "/" & progress.MaximumValue
            lbl_CustName.Text = progress.CurrentCustomer
        End Sub

        Private Sub InvoiceBatchWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BatchWorker.RunWorkerCompleted
            If (e.Error IsNot Nothing) Then
                MessageBox.Show("Error: " & e.Error.Message & ". Exception: " & e.Error.InnerException.ToString, "Batching Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (e.Cancelled) Then
                MessageBox.Show("Batch canceled.", "Batch Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Batch Completed.", "Batch Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BatchCompleted = True
            End If

            Close()
        End Sub

        Friend BatchCompleted As Boolean = False
    End Class
End Namespace