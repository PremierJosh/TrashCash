Imports TrashCash.ds_Batching

Namespace Batching
    Public Class BatchInterruption

        ' batch type bool fields
        Friend PaymentBatch As Boolean
        Friend InvoiceBatch As Boolean

        ' tas
        Private _invTA As ds_BatchingTableAdapters.Batch_InvoicesTableAdapter
        Private _payTA As ds_BatchingTableAdapters.Batch_PaymentsTableAdapter

   

        Private Sub BatchInterruption_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            If (InvoiceBatch) Then
                ' instantiate ta
                _invTA = New ds_BatchingTableAdapters.Batch_InvoicesTableAdapter
            ElseIf (PaymentBatch) Then
                ' instantiate ta
                _payTA = New ds_BatchingTableAdapters.Batch_PaymentsTableAdapter
            End If
        End Sub


        Private Sub btn_FinBatch_Click(sender As System.Object, e As System.EventArgs) Handles btn_FinBatch.Click
            Dim result As MsgBoxResult = MsgBox("Begin batching?", MsgBoxStyle.YesNo)
            If (result = vbYes) Then
                If (InvoiceBatch) Then
                    ' date passed here doesn't matter
                    Dim batchInv As New Batching.QB_Batching.Invoicing()
                    BatchWorker.RunWorkerAsync(batchInv)
                ElseIf (PaymentBatch) Then
                    Dim batchPay As New Batching.QB_Batching.Payments
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
                Dim row As ds_Batching.Batch_InvoicesRow = _invTA.GetNewest.Rows(0)
                e.Argument.batch(worker, e, row)
            ElseIf (PaymentBatch) Then
                Dim row As ds_Batching.Batch_PaymentsRow = _payTA.GetNewest.Rows(0)
                e.Argument.batch(worker, e, row)
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
            End If
        End Sub
    End Class
End Namespace