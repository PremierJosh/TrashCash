﻿Namespace Batching

    Public Class BatchingPrep
        ' private vart for tracking batching
        Private _batching As Boolean

        ' event to update progress % on home mdi parent
        Friend Event BatchProgPerc(ByVal batchPercent As Integer)
        Friend Event CustomerQueueAdjusted(ByVal customerNumber As Integer)
        Friend Event InvoiceQueueAdjusted()

        Private _payBatchRunning As Boolean
        Private _invBatchRunning As Boolean


        Friend Event BatchRunning(ByVal running As Boolean)
        Public Property Batching As Boolean
            Get
                Return _batching
            End Get
            Set(value As Boolean)
                If (_batching <> value) Then
                    _batching = value

                    ' clear text values from labels
                    lbl_InvBatchCount.Text = ""
                    lbl_InvBatchCust.Text = ""
                    lbl_PayBatchCount.Text = ""
                    lbl_PayBatchCust.Text = ""

                    If (value = True) Then
                        ' disable generating new invoices
                        btn_GenerateInv.Enabled = False
                        ' disbable delete invoices
                        If (dg_PrepInv.RowCount > 0) Then
                            btn_DeleteInvs.Enabled = False
                        End If
                        ' change button text to cancel and disable other button
                        If (_invBatchRunning) Then
                            ' change button for cancelation and disable other batch btn
                            btn_PayBatch.Enabled = False
                            btn_InvBatch.Text = "Cancel Invoice Batch"
                            btn_InvBatch.ForeColor = Color.Red
                            ' show labels for batching
                            lbl_InvBatchCust.Visible = True
                            lbl_InvBatchCount.Visible = True
                        ElseIf (_payBatchRunning) Then
                            ' change button for cancelation and disable other batch btn
                            btn_InvBatch.Enabled = False
                            btn_PayBatch.Text = "Cancel Payment Batch"
                            btn_PayBatch.ForeColor = Color.Red
                            ' show labels for batching
                            lbl_PayBatchCust.Visible = True
                            lbl_PayBatchCount.Visible = True
                            ' disable total fields
                            tb_TotalCash.Enabled = False
                            tb_TotalCheck.Enabled = False
                            tb_TotalMoneyOrder.Enabled = False
                        End If
                        ' disable mod and del pay menu
                        cm_PayGrid.Enabled = False
                    Else
                        ' reset pb max var
                        PbMaximumValue = Nothing
                        PbCurrentValue = 1
                        PbCustomer = Nothing
                        _lastPercent = -1
                        PbPercent = 0
                        ' change button text to normal
                        If (_invBatchRunning) Then
                            ' set buttons back to normal and enable clicking on other button
                            btn_PayBatch.Enabled = True
                            btn_InvBatch.Text = "Batch Invoices"
                            btn_InvBatch.ForeColor = SystemColors.ControlText
                            ' hide labels
                            lbl_InvBatchCust.Visible = False
                            lbl_InvBatchCount.Visible = False
                        ElseIf (_payBatchRunning) Then
                            ' set buttons back to normal and enable clicking on other button
                            btn_InvBatch.Enabled = True
                            btn_PayBatch.Text = "Batch Payments"
                            btn_PayBatch.ForeColor = SystemColors.ControlText
                            ' hide labels
                            lbl_PayBatchCust.Visible = False
                            lbl_PayBatchCount.Visible = False
                            ' enable total fields and clear the text
                            tb_TotalCash.Enabled = True
                            tb_TotalCash.Clear()
                            tb_TotalCheck.Enabled = True
                            tb_TotalCheck.Clear()
                            tb_TotalMoneyOrder.Enabled = True
                            tb_TotalMoneyOrder.Clear()
                        End If
                        ' set type bools for batch to false
                        _payBatchRunning = False
                        _invBatchRunning = False
                        ' enable generating new invoices
                        btn_GenerateInv.Enabled = True
                        If (dg_PrepInv.RowCount > 0) Then
                            btn_DeleteInvs.Enabled = True
                        End If

                        ' show delete and payment menu
                        cm_PayGrid.Enabled = True
                    End If

                    ' raising event
                    RaiseEvent BatchRunning(value)
                End If
            End Set
        End Property

        Private _pbMax As Integer
        Private Property PbMaximumValue As Integer
            Get
                Return _pbMax
            End Get
            Set(value As Integer)
                If (_pbMax <> value) Then
                    _pbMax = value
                    If (_invBatchRunning) Then
                        pb_Invoices.Maximum = 100
                    ElseIf (_payBatchRunning) Then
                        pb_Payments.Maximum = 100
                    End If
                End If
            End Set
        End Property
        ' this gets updated from the batch worker and updates the count labels
        Private WriteOnly Property PbCurrentValue As Integer
            Set(value As Integer)
                If (_invBatchRunning) Then
                    lbl_InvBatchCount.Text = value & "/" & PbMaximumValue
                ElseIf (_payBatchRunning) Then
                    lbl_PayBatchCount.Text = value & "/" & PbMaximumValue
                End If
            End Set
        End Property
        ' this gets updated from the batch worker and sets the associated customer label
        Private WriteOnly Property PbCustomer As String
            Set(value As String)
                If (_invBatchRunning) Then
                    lbl_InvBatchCust.Text = "Customer: " & value
                ElseIf (_payBatchRunning) Then
                    ' payments
                    lbl_PayBatchCust.Text = "Customer: " & value
                End If
            End Set
        End Property
        ' this gets updated from the batch worker and updates the assoc pb
        ' the var is to prevent setting excessively with the other events
        Private _lastPercent As Integer
        Private WriteOnly Property PbPercent
            Set(value)
                If (value > _lastPercent) Then

                    ' raise event for home status bar update
                    RaiseEvent BatchProgPerc(value)

                    If (_invBatchRunning) Then
                        ' invoices
                        pb_Invoices.Value = value
                    ElseIf (_payBatchRunning) Then
                        ' payments
                        pb_Payments.Value = value
                    End If
                End If
            End Set
        End Property

        Protected QTA As ds_BatchingTableAdapters.QueriesTableAdapter

        Private Sub BatchingPrep_FormClosed(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                If (Batching) Then
                    MessageBox.Show("You cannot close this screen while Batching is in progress.", "Batch in progress", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Hide()
                End If
            End If
        End Sub

        ' overloading show method to refresh queues
        Public Overloads Sub Show()
            MyBase.Show()
            'CheckBatchQueues(refillTables:=True)
        End Sub

        Private Sub BatchingPrep_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
            ' fill with pay types
            PaymentTypesTableAdapter.Fill(Ds_Types.PaymentTypes)
            CheckBatchQueues(refillTables:=True)
        End Sub

        Friend Sub CheckBatchQueues(Optional ByVal refillTables As Boolean = False)
            Dim errCount As Integer

            If (refillTables) Then
                BATCH_WorkingInvoiceTableAdapter.Fill(DS_Batching.BATCH_WorkingInvoice)
                BATCH_WorkingPaymentsTableAdapter.Fill(DS_Batching.BATCH_WorkingPayments)
            End If

            ' payments
            errCount = QTA.WorkingPayments_ErrCount
            If (errCount = 0) Then
                ' check payment batching totals
                PayBatch_TotalsPrep()
                If (dg_PrepPay.RowCount > 0) Then
                    btn_PayBatch.Enabled = True
                    cm_PayGrid.Enabled = True
                    ' update count lbl
                    lbl_PayQueueCount.Text = "Payments in Queue: " & dg_PrepPay.RowCount
                Else
                    btn_PayBatch.Enabled = False
                    cm_PayGrid.Enabled = False
                    ' hide count lbl
                    lbl_PayQueueCount.Text = ""
                End If
            Else
                btn_PayBatch.Enabled = False
                MessageBox.Show("There are Payments with errors. You will be unable to batch payments till the errors are cleared.", "Payments with errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' invoices
            errCount = QTA.WorkingInvoice_ErrCount
            If (errCount = 0) Then
                If (dg_PrepInv.RowCount > 0) Then
                    btn_InvBatch.Enabled = True
                    ' update count label
                    lbl_InvQueueCount.Text = "Invoices in Queue: " & dg_PrepInv.RowCount
                    btn_DeleteInvs.Visible = True
                Else
                    btn_InvBatch.Enabled = False
                    ' hide count lbl
                    lbl_InvQueueCount.Text = ""
                    btn_DeleteInvs.Visible = False
                End If
            Else
                btn_InvBatch.Enabled = False
                MessageBox.Show("There are Invoices with errors. You will be unable to batch or generate invoices till the errors are cleared.", "Invoices with errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        End Sub

        'Private Sub btn_Batch_Click(sender As System.Object, e As System.EventArgs)
        '    ' first build string
        '    Dim promptS As String

        '    If (sender.Name = btn_PayBatch.Name) Then
        '        ' payment batch click
        '        promptS = "Begin batching " & dg_PrepPay.RowCount.ToString & " payment(s)?"
        '        Dim result As MsgBoxResult = MsgBox(promptS, MsgBoxStyle.YesNo)

        '        If (result = MsgBoxResult.Yes) Then
        '            ' set personal propert which updates master
        '            Batching = True
        '            ' show pay batch pb pnl
        '            pnl_RightBot.Visible = True
        '            ' show cancel btn
        '            btn_CancelPayBatch.Visible = True
        '            btn_CancelPayBatch.Enabled = True
        '            ' init the object that the worker calls
        '            Dim payment As New QB_Batching.Payments()
        '            ' start the worker
        '            BatchWorker.RunWorkerAsync(payment)
        '        End If
        '    ElseIf (sender.Name = btn_InvBatch.Name) Then
        '        ' inv click
        '        promptS = "Begin batching " & dg_PrepInv.RowCount.ToString & " invoice(s)?"
        '        Dim result As MsgBoxResult = MsgBox(promptS, MsgBoxStyle.YesNo)

        '        If (result = MsgBoxResult.Yes) Then
        '            ' set personal propert which updates master
        '            Batching = True
        '            ' show inv batch pb panel
        '            pnl_LeftBot.Visible = True
        '            ' init the object that the worker calls
        '            Dim invoice As New QB_Batching.Invoicing(_targetedBillDate)
        '            ' start the work
        '            BatchWorker.RunWorkerAsync(invoice)
        '        End If
        '    End If

        'End Sub

        Private _targetedBillDate As Date
        Private Sub btn_GenerateInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_GenerateInv.Click
            ' if there are invoices already, we cannot generate
            Dim count As Integer = QTA.WorkingInvoice_Count

            If (count = 0) Then
                ' checking if dtp is more than 30 days our
                Dim futureDate As Date = DateAdd(DateInterval.Day, 30, Date.Now).Date
                If (dtp_GenInvTo.Value.Date > futureDate) Then
                    MessageBox.Show("You cannot generate Invoices more than 30 days ahead of time.", "Generate Date too far", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                Dim result As DialogResult = MessageBox.Show("There are currently invoices in queue. You must delete or batch them before generating again." & vbCrLf &
                                "Do you wish to delete these invoices and generate again?", "Invoices Already in Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    BATCH_WorkingInvoiceTableAdapter.DeleteAll()
                Else
                    Exit Sub
                End If
            End If

            Cursor = Cursors.WaitCursor
            QTA.GenerateRecurringInvoices(dtp_GenInvTo.Value.Date)
            ' refil table
            BATCH_WorkingInvoiceTableAdapter.Fill(DS_Batching.BATCH_WorkingInvoice)
            ' carrying targeted date here for batch record
            _targetedBillDate = dtp_GenInvTo.Value.Date
            ' update queue and raise event
            CheckBatchQueues()
            RaiseEvent InvoiceQueueAdjusted()
            Cursor = Cursors.Default
        End Sub

        Private Sub dg_PrepInv_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_PrepInv.CellContentClick
            If (e.ColumnIndex = 5) Then
                Try
                    Dim row As ds_Batching.BATCH_WorkingInvoiceRow = CType(dg_PrepInv.Rows(dg_PrepInv.SelectedRows(0).Index).DataBoundItem, DataRowView).Row

                    If (dg_PrepInv.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue = True) Then
                        QTA.WorkingInvoice_UpdatePrint(row.WorkingInvoiceID, "True")
                    Else
                        QTA.WorkingInvoice_UpdatePrint(row.WorkingInvoiceID, "False")
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
            PbMaximumValue = progress.MaximumValue
            PbCurrentValue = progress.CurrentValue
            PbCustomer = progress.CurrentCustomer
            ' progress
            PbPercent = e.ProgressPercentage
        End Sub

        Private Sub InvoiceBatchWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BatchWorker.RunWorkerCompleted
            If (e.Error IsNot Nothing) Then
                MessageBox.Show("Error: " & e.Error.Message & ". Exception: " & e.Error.InnerException.ToString, "Batching Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (e.Cancelled) Then
                MessageBox.Show("Batch canceled.", "Batch Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Batch Completed.", "Batch Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Batching = False
            ' refil dataset
            CheckBatchQueues(refillTables:=True)
            RaiseEvent InvoiceQueueAdjusted()
        End Sub

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            QTA = New ds_BatchingTableAdapters.QueriesTableAdapter
        End Sub

        Private Sub btn_DeletePay_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeletePay.Click
            If (dg_PrepPay.SelectedRows.Count = 1) Then
                Dim row As ds_Batching.BATCH_WorkingPaymentsRow = CType(dg_PrepPay.SelectedRows(0).DataBoundItem, DataRowView).Row
                Dim custNum As Integer = row.CustomerNumber
                Dim result As DialogResult = MessageBox.Show("Delete this Prepared Payment?", "Confirm Prepared Payment delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    BATCH_WorkingPaymentsTableAdapter.DeleteByID(row.WorkingPaymentsID)
                    ' raise event and refil table
                    RaiseEvent CustomerQueueAdjusted(custNum)
                End If
            Else
                MessageBox.Show("Please select a Prepared Payment first", "No Prepared Payment selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private _totalCash As Double
        Private Property TotalCash As Double
            Get
                Return _totalCash
            End Get
            Set(value As Double)
                _totalCash = value

                If (value > 0) Then
                    lbl_TotalCash.Visible = True
                    tb_TotalCash.Visible = True
                Else
                    lbl_TotalCash.Visible = False
                    tb_TotalCash.Visible = False
                End If
            End Set
        End Property

        Private _totalChecks As Double
        Private Property TotalChecks As Double
            Get
                Return _totalChecks
            End Get
            Set(value As Double)
                _totalChecks = value

                If (value > 0) Then
                    lbl_TotalCheck.Visible = True
                    tb_TotalCheck.Visible = True
                Else
                    lbl_TotalCheck.Visible = False
                    tb_TotalCheck.Visible = False
                End If
            End Set
        End Property

        Private _totalMoneyOrder As Double
        Private Property TotalMoneyOrder As Double
            Get
                Return _totalMoneyOrder
            End Get
            Set(value As Double)
                _totalMoneyOrder = value

                If (value > 0) Then
                    lbl_TotalMoneyOrder.Visible = True
                    tb_TotalMoneyOrder.Visible = True
                Else
                    lbl_TotalMoneyOrder.Visible = False
                    tb_TotalMoneyOrder.Visible = False
                End If
            End Set
        End Property

        Private Sub PayBatch_TotalsPrep()
            Dim cash As Double
            Dim checks As Double
            Dim moneyO As Double

            For Each row As ds_Batching.BATCH_WorkingPaymentsRow In DS_Batching.BATCH_WorkingPayments
                If (row.WorkingPaymentsType = TC_ENPaymentTypes.Cash) Then
                    cash += row.WorkingPaymentsAmount
                ElseIf (row.WorkingPaymentsType = TC_ENPaymentTypes.Check) Then
                    checks += row.WorkingPaymentsAmount
                ElseIf (row.WorkingPaymentsType = TC_ENPaymentTypes.MoneyOrder) Then
                    moneyO += row.WorkingPaymentsAmount
                End If
            Next

          ' set properties
            TotalCash = Math.Round(cash, 2)
            TotalChecks = Math.Round(checks, 2)
            TotalMoneyOrder = Math.Round(moneyO, 2)
        End Sub

        Private Function PayBatch_VerifyTotals() As Boolean
            Dim cashErr As Boolean = False
            Dim checkErr As Boolean = False
            Dim moErr As Boolean = False
            Dim s As New System.Text.StringBuilder

            ' cash total
            If (TotalCash > 0) Then
                If (Trim(tb_TotalCash.Text) <> "") Then
                    If (CDbl(tb_TotalCash.Text) <> TotalCash) Then
                        cashErr = True
                        s.Append("- Total Cash incorrect").AppendLine()
                    End If
                Else
                    cashErr = True
                    s.Append("- Total Cash empty").AppendLine()
                End If
            End If
            If (cashErr) Then
                tb_TotalCash.BackColor = AppColors.TextBoxErr
                tb_TotalCash.Clear()
            Else
                tb_TotalCash.BackColor = AppColors.TextBoxDef
            End If

            ' check total
            If (TotalChecks > 0) Then
                If (Trim(tb_TotalCheck.Text) <> "") Then
                    If (CDbl(tb_TotalCheck.Text) <> TotalChecks) Then
                        checkErr = True
                        s.Append("- Total Checks incorrect").AppendLine()
                    End If
                Else
                    checkErr = True
                    s.Append("- Total Checks empty").AppendLine()
                End If
            End If
            If (checkErr) Then
                tb_TotalCheck.BackColor = AppColors.TextBoxErr
                tb_TotalCheck.Clear()
            Else
                tb_TotalCheck.BackColor = AppColors.TextBoxDef
            End If

            ' money order total
            If (TotalMoneyOrder > 0) Then
                If (Trim(tb_TotalMoneyOrder.Text) <> "") Then
                    If (CDbl(tb_TotalMoneyOrder.Text) <> TotalMoneyOrder) Then
                        moErr = True
                        s.Append("- Total Money Orders incorrect")
                    End If
                Else
                    moErr = True
                    s.Append("- Total Money Orders empty")
                End If
            End If
            If (moErr) Then
                tb_TotalMoneyOrder.BackColor = AppColors.TextBoxErr
                tb_TotalMoneyOrder.Clear()
            Else
                tb_TotalMoneyOrder.BackColor = AppColors.TextBoxDef
            End If

            If (Not cashErr And Not checkErr And Not moErr) Then
                Return True
            Else
                MessageBox.Show("Please correct the following totals before batching can begin:" & vbCrLf & s.ToString, "Totals Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Function
        

        Private Sub tc_Master_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tc_Master.SelectedIndexChanged
            If (tc_Master.SelectedIndex = 0) Then
                BATCH_WorkingInvoiceTableAdapter.Fill(DS_Batching.BATCH_WorkingInvoice)
            Else
                BATCH_WorkingPaymentsTableAdapter.Fill(DS_Batching.BATCH_WorkingPayments)
            End If
        End Sub

        Private Sub dg_PrepPay_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_PrepPay.CellMouseDown
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                For Each row As DataGridViewRow In dg_PrepPay.SelectedRows
                    row.Selected = False
                Next
                dg_PrepPay.Rows(e.RowIndex).Selected = True
            End If
        End Sub


        Private Sub btn_InvBatch_Click(sender As System.Object, e As System.EventArgs) Handles btn_InvBatch.Click
            If (Not _invBatchRunning) Then
                Dim result As DialogResult = MessageBox.Show("Begin Batching " & dg_PrepInv.RowCount & " invoices?", "Begin Invoice Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    _invBatchRunning = True
                    Batching = True
                    ' init the object that the worker calls
                    Dim invoice As New QB_Batching.Invoicing(_targetedBillDate)
                    ' start the work
                    BatchWorker.RunWorkerAsync(invoice)
                End If
            Else
                ' batch is running, this is a cancel
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to stop this Invoice Batch?", "Stop Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    If (BatchWorker.WorkerSupportsCancellation) Then
                        If (Not BatchWorker.CancellationPending) Then
                            BatchWorker.CancelAsync()
                        End If
                    End If
                End If
            End If

        End Sub

        Private Sub btn_PayBatch_Click(sender As System.Object, e As System.EventArgs) Handles btn_PayBatch.Click
            If (Not _payBatchRunning) Then
                If (PayBatch_VerifyTotals()) Then
                    Dim result As DialogResult = MessageBox.Show("Payment Totals Match. Begin Batching " & dg_PrepPay.RowCount & " payments?", "Begin Payment Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (result = Windows.Forms.DialogResult.Yes) Then
                        ' set properties to set controls
                        _payBatchRunning = True
                        Batching = True
                        ' init the object that the worker calls
                        Dim payBatcher As New QB_Batching.Payments()
                        ' start the worker
                        BatchWorker.RunWorkerAsync(payBatcher)
                    End If
                End If
            Else
                ' batch is running, this is a cancel call
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to stop this Payment Batch?", "Stop Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    If (BatchWorker.WorkerSupportsCancellation) Then
                        If (Not BatchWorker.CancellationPending) Then
                            BatchWorker.CancelAsync()
                        End If
                    End If
                End If
            End If

        End Sub

        Private Sub btn_PayRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btn_PayRefresh.Click
            If (Not Batching) Then
                CheckBatchQueues(refillTables:=True)
            End If
        End Sub

        Private Sub btn_ModPayment_Click(sender As System.Object, e As System.EventArgs) Handles btn_ModPayment.Click
            Dim row As ds_Batching.BATCH_WorkingPaymentsRow = CType(dg_PrepPay.SelectedRows(0).DataBoundItem, DataRowView).Row
            Dim custNum As Integer = row.CustomerNumber
            Dim modForm As New PaymentModifyForm(row, BATCH_WorkingPaymentsTableAdapter, Ds_Types.PaymentTypes)
            modForm.ShowDialog()
            ' raise event
            RaiseEvent CustomerQueueAdjusted(custNum)
     End Sub

        Private Sub btn_DeleteInvs_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteInvs.Click
            Dim result As DialogResult = MessageBox.Show("Delete all prepared invoices?", "Delete Invoices", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.Yes) Then
                BATCH_WorkingInvoiceTableAdapter.DeleteAll()
                DS_Batching.BATCH_WorkingInvoice.Clear()
                CheckBatchQueues()
                RaiseEvent InvoiceQueueAdjusted()
            End If
        End Sub
    End Class
End Namespace