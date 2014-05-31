'Imports TrashCash.QBSubs
Imports TrashCash.Customer
Imports TrashCash.Classes
Imports TrashCash.Utilities
Imports TrashCash.Utilities.Functions
Imports QBFC12Lib

Public Class BatchingPrep
    ' private vart for tracking batching
    Private _batching As Boolean

    ' event to update progress % on home mdi parent
    Friend Event e_BatchProgPerc(ByVal batchPercent As Integer)

    Friend Event BatchRunning(ByVal running As Boolean)
    Public Property Batching As Boolean
        Get
            Return _batching
        End Get
        Set(value As Boolean)
            If (_batching <> value) Then
                _batching = value

                If (value = True) Then
                    UseWaitCursor = True
                    ' hide batch btns
                    btn_PayBatch.Visible = False
                    btn_InvBatch.Visible = False
                    btn_DeleteAllWrkInv.Visible = False
                    ' hide cm for deleting payments
                    cm_PayGrid.Enabled = False
                Else
                    ' reset cursor
                    UseWaitCursor = False
                    ' reset pb max var
                    PB_MaximumValue = Nothing
                    PB_CurrentValue = 1
                    PB_Customer = Nothing
                    lastPercent = -1
                    PB_Percent = 0

                    ' hide both panels again
                    pnl_LeftBot.Visible = False
                    pnl_RightBot.Visible = False

                    ' hide cancel buttons
                    btn_CancelInvBatch.Visible = False
                    btn_CancelPayBatch.Visible = False
                    ' show delete payment cm
                    cm_PayGrid.Enabled = True
                End If

                ' raising event
                RaiseEvent BatchRunning(value)
            End If
        End Set
    End Property

    Protected _pb_max As Integer
    Private Property PB_MaximumValue As Integer
        Get
            Return _pb_max
        End Get
        Set(value As Integer)
            If (_pb_max <> value) Then
                _pb_max = value
            End If
        End Set
    End Property
    ' this gets updated from the batch worker and updates the count labels
    Private WriteOnly Property PB_CurrentValue As Integer
        Set(value As Integer)
            If (pnl_LeftBot.Visible = True) Then
                lbl_InvBatchCount.Text = value & "/" & PB_MaximumValue
            ElseIf (pnl_RightBot.Visible = True) Then
                lbl_PayBatchCount.Text = value & "/" & PB_MaximumValue
            End If
        End Set
    End Property
    ' this gets updated from the batch worker and sets the associated customer label
    Private WriteOnly Property PB_Customer As String
        Set(value As String)
            If (pnl_LeftBot.Visible = True) Then
                lbl_InvBatchCust.Text = value
            ElseIf (pnl_RightBot.Visible = True) Then
                ' payments
                lbl_PayBatchCust.Text = value
            End If
        End Set
    End Property
    ' this gets updated from the batch worker and updates the assoc pb
    ' the var is to prevent setting excessively with the other events
    Protected lastPercent As Integer
    Private WriteOnly Property PB_Percent
        Set(value)
            If (value > lastPercent) Then

                ' raise event for home status bar update
                RaiseEvent e_BatchProgPerc(value)

                If (pnl_LeftBot.Visible) Then
                    ' invoices
                    pb_Invoices.Value = value
                ElseIf (pnl_RightBot.Visible) Then
                    ' payments
                    pb_Payments.Value = value
                End If
            End If
        End Set
    End Property

    Public Property MasterForm As CustomerForm
    Protected qta As ds_BatchingTableAdapters.QueriesTableAdapter

    Private Sub BatchingPrep_FormClosed(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
            e.Cancel = True
            If (Batching) Then
                MsgBox("You cannot close this screen with Batching is in progress.")
            Else
                Me.Hide()
            End If
        End If
    End Sub

    ' overloading show method to refresh queues
    Public Overloads Sub Show()
        MyBase.Show()

        RefreshBatchQueue()
    End Sub

    Private Sub BatchingPrep_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        RefreshBatchQueue()
    End Sub

    Private Sub btn_Refresh_Click(sender As System.Object, e As System.EventArgs) Handles btn_Refresh.Click
        RefreshBatchQueue()
    End Sub
    Private Sub RefreshBatchQueue()
        Dim errCount As Integer

        ' payments
        errCount = qta.WorkingPayments_ErrCount
        If (errCount = 0) Then
            Me.BATCH_WorkingPaymentsTableAdapter.Fill(Me.Ds_Batching.BATCH_WorkingPayments)
        Else
            'btn_PayBatch.Visible = False
            MessageBox.Show("There are Payments with errors. You will be unable to batch payments till the errors are cleared.", "Payments with errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' invoices
        errCount = qta.WorkingInvoice_ErrCount
        If (errCount = 0) Then
            Dim recCount As Integer = qta.WorkingInvoice_ErrCount
            If (recCount = 0) Then
                Me.BATCH_WorkingInvoiceTableAdapter.Fill(Me.Ds_Batching.BATCH_WorkingInvoice)
            End If
        Else
            'btn_GenerateInv.Visible = False
            'btn_InvBatch.Visible = False
            MessageBox.Show("There are Invoices with errors. You will be unable to batch or generate invoices till the errors are cleared.", "Invoices with errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_Batch_Click(sender As System.Object, e As System.EventArgs) Handles btn_PayBatch.Click, btn_InvBatch.Click
        ' first build string
        Dim promptS As String

        If (sender.Name = btn_PayBatch.Name) Then
            ' payment batch click
            promptS = "Begin batching " & dg_PrepPay.RowCount.ToString & " payment(s)?"
            Dim result As MsgBoxResult = MsgBox(promptS, MsgBoxStyle.YesNo)

            If (result = MsgBoxResult.Yes) Then
                ' set personal propert which updates master
                Batching = True
                ' show pay batch pb pnl
                pnl_RightBot.Visible = True
                ' show cancel btn
                btn_CancelPayBatch.Visible = True
                btn_CancelPayBatch.Enabled = True
                ' init the object that the worker calls
                Dim Payment As New QB_Batching.Payments(Me.Ds_Batching.BATCH_WorkingPayments)
                ' start the worker
                BatchWorker.RunWorkerAsync(Payment)
            End If
        ElseIf (sender.Name = btn_InvBatch.Name) Then
            ' inv click
            promptS = "Begin batching " & dg_PrepInv.RowCount.ToString & " invoice(s)?"
            Dim result As MsgBoxResult = MsgBox(promptS, MsgBoxStyle.YesNo)

            If (result = MsgBoxResult.Yes) Then
                ' set personal propert which updates master
                Batching = True
                ' show inv batch pb panel
                pnl_LeftBot.Visible = True
                ' show cancel btn
                btn_CancelInvBatch.Visible = True
                btn_CancelInvBatch.Enabled = True
                ' init the object that the worker calls
                Dim Invoice As New QB_Batching.Invoicing(Me.Ds_Batching.BATCH_WorkingInvoice)
                ' start the work
                BatchWorker.RunWorkerAsync(Invoice)
            End If
        End If

    End Sub

    Private Sub btn_GenerateInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_GenerateInv.Click
        ' if there are invoices already, we cannot generate
        'Dim qta As New DataSetTableAdapters.QueriesTableAdapter
        Dim count As Integer = qta.WorkingInvoice_RecurringCount

        If (count = 0) Then
            ' checking if dtp is more than 30 days our
            Dim futureDate As Date = DateAdd(DateInterval.Day, 30, Date.Now).Date
            If (dtp_GenInvTo.Value.Date > futureDate) Then
                MsgBox("You cannot generate Invoices more than 30 days ahead of time.")
            Else
                Me.Cursor = Cursors.WaitCursor
                qta.GenerateRecurringInvoices(dtp_GenInvTo.Value.Date)
                Me.BATCH_WorkingInvoiceTableAdapter.Fill(Me.Ds_Batching.BATCH_WorkingInvoice)
                Me.Cursor = Cursors.Default
            End If
        Else
            MsgBox("You cannot Generate Recurring Service Invoices while there are other Recurring Service Invoices prepared. You must first Batch or Delete them.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dg_PrepInv_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_PrepInv.CellContentClick
        If (e.ColumnIndex = 5) Then
            Try
                Dim row As DataRowView = dg_PrepInv.Rows(dg_PrepInv.SelectedRows(0).Index).DataBoundItem
                Dim actualRow As ds_Batching.BATCH_WorkingInvoiceRow = row.Row

                If (dg_PrepInv.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue = True) Then
                    qta.WorkingInvoice_UpdatePrint(actualRow.WorkingInvoiceID, "True")
                Else
                    qta.WorkingInvoice_UpdatePrint(actualRow.WorkingInvoiceID, "False")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BatchWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BatchWorker.DoWork
        ' create worker ref
        Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

        If (BatchWorker.CancellationPending = True) Then
            e.Cancel = True
            Exit Sub
        End If

        e.Argument.batch(worker, e)
    End Sub

    Private Sub BatchWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BatchWorker.ProgressChanged
        Dim progress As ProgressObj = CType(e.UserState, ProgressObj)

        PB_MaximumValue = progress.MaximumValue
        PB_CurrentValue = progress.CurrentValue
        PB_Customer = progress.CurrentCustomer

        ' progress
        PB_Percent = e.ProgressPercentage

        ' checking cursor state
        If (UseWaitCursor = False) Then
            UseWaitCursor = True
        End If

    End Sub

    Private Sub InvoiceBatchWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BatchWorker.RunWorkerCompleted
        If (e.Error IsNot Nothing) Then
            MsgBox("Error: " & e.Error.Message & ". Exception: " & e.Error.InnerException.ToString)
        ElseIf (e.Cancelled) Then
            MsgBox("Batch canceled.", MsgBoxStyle.SystemModal)
        Else
            MsgBox("Batch Completed.", MsgBoxStyle.SystemModal)
        End If

        Batching = False


        ' refil dataset
        RefreshBatchQueue()
    End Sub

    Private Sub btn_CancelInvBatch_Click(sender As System.Object, e As System.EventArgs) Handles btn_CancelInvBatch.Click, btn_CancelPayBatch.Click
        If (BatchWorker.WorkerSupportsCancellation = True) Then
            If (BatchWorker.CancellationPending = False) Then
                BatchWorker.CancelAsync()
                sender.enabled = False
            End If
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        qta = New ds_BatchingTableAdapters.QueriesTableAdapter
    End Sub


    Private Sub dg_PrepPay_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_PrepPay.RowsAdded, dg_PrepInv.RowsAdded
        PrepItemCountChanging()
    End Sub

    Private Sub dg_PrepPay_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg_PrepPay.RowsRemoved, dg_PrepInv.RowsRemoved
        PrepItemCountChanging()
    End Sub
    Private Sub PrepItemCountChanging()
        ' inv grid first
        If (dg_PrepInv.RowCount > 0) Then
            If (Not Batching) Then
                btn_InvBatch.Visible = True
                btn_InvBatch.Text = "Batch " & dg_PrepInv.RowCount & " Invoices"
                btn_GenerateInv.Enabled = False
                ' show delete all btn
                btn_DeleteAllWrkInv.Visible = True
            End If
        Else
            btn_InvBatch.Visible = False
            btn_GenerateInv.Enabled = True
            ' hide delete all btn
            btn_DeleteAllWrkInv.Visible = False
        End If

        ' pay grid
        If (dg_PrepPay.RowCount > 0) Then
            If (Not Batching) Then
                btn_PayBatch.Visible = True
                btn_PayBatch.Text = "Batch " & dg_PrepPay.RowCount & " Payments"
            End If
        Else
            btn_PayBatch.Visible = False
        End If
    End Sub

    Private Sub btn_DeleteAllWrkInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteAllWrkInv.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to delete all Prepared Invoices?", MsgBoxStyle.YesNo)
        If (result = MsgBoxResult.Yes) Then
            Try
                Me.BATCH_WorkingInvoiceTableAdapter.DeleteAll()
                RefreshBatchQueue()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If (dg_PrepPay.SelectedRows.Count = 1) Then
            Dim drv As DataRowView = dg_PrepPay.SelectedRows.Item(0).DataBoundItem
            Dim row As DataSet.WorkingPaymentsRow = drv.Row
            Dim result As MsgBoxResult = MsgBox("Delete this Prepared Payment?", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                Me.BATCH_WorkingPaymentsTableAdapter.DeleteByID(row.WorkingPaymentsID)
                dg_PrepPay.Rows.RemoveAt(dg_PrepPay.SelectedRows.Item(0).Index)
            End If
        Else
            MsgBox("Please select a Payment First.")
        End If
    End Sub
End Class