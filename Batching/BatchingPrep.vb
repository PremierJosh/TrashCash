Imports TrashCash.Customer

Namespace Batching

    Public Class BatchingPrep
        ' private vart for tracking batching
        Private _batching As Boolean

        ' event to update progress % on home mdi parent
        Friend Event BatchProgPerc(ByVal batchPercent As Integer)
        Friend Event CustomerPaymentMod(ByVal customerNumber As Integer)

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

                    If (value = True) Then
                        ' disable batch buttons
                        btn_PayBatch.Enabled = False

                        btn_DeleteAllWrkInv.Enabled = False
                        btn_GenerateInv.Enabled = False
                        ' cancel buttons visibility will be handled by that batch button changing to a cancel call
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

                        ElseIf (_payBatchRunning) Then
                            btn_PayBatch.Text = "Batch Payments"
                            btn_PayBatch.ForeColor = SystemColors.ControlText
                        End If
                        ' set type bools for batch to false
                        _payBatchRunning = False
                        _invBatchRunning = False

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
                    lbl_InvBatchCust.Text = value
                ElseIf (_payBatchRunning) Then
                    ' payments
                    lbl_PayBatchCust.Text = value
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
                        pb_Invoices.Increment(1)
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
                    MsgBox("You cannot close this screen while Batching is in progress.")
                Else
                    Hide()
                End If
            End If
        End Sub

        ' overloading show method to refresh queues
        Public Overloads Sub Show()
            MyBase.Show()

            RefreshBatchQueue()
        End Sub

        Private Sub BatchingPrep_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
            'TODO: This line of code loads data into the 'Ds_Types.PaymentTypes' table. You can move, or remove it, as needed.
            PaymentTypesTableAdapter.Fill(Ds_Types.PaymentTypes)
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
                BATCH_WorkingPaymentsTableAdapter.Fill(Ds_Batching.BATCH_WorkingPayments)
            Else
                'btn_PayBatch.Visible = False
                MessageBox.Show("There are Payments with errors. You will be unable to batch payments till the errors are cleared.", "Payments with errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' invoices
            errCount = qta.WorkingInvoice_ErrCount
            If (errCount = 0) Then
                Dim recCount As Integer = qta.WorkingInvoice_ErrCount
                If (recCount = 0) Then
                    BATCH_WorkingInvoiceTableAdapter.Fill(Ds_Batching.BATCH_WorkingInvoice)
                End If
            Else
                'btn_GenerateInv.Visible = False
                'btn_InvBatch.Visible = False
                MessageBox.Show("There are Invoices with errors. You will be unable to batch or generate invoices till the errors are cleared.", "Invoices with errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btn_Batch_Click(sender As System.Object, e As System.EventArgs)
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
                    Dim payment As New QB_Batching.Payments()
                    ' start the worker
                    BatchWorker.RunWorkerAsync(payment)
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
                    Dim invoice As New QB_Batching.Invoicing(_targetedBillDate)
                    ' start the work
                    BatchWorker.RunWorkerAsync(invoice)
                End If
            End If

        End Sub

        Private _targetedBillDate As Date
        Private Sub btn_GenerateInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_GenerateInv.Click
            ' if there are invoices already, we cannot generate
            'Dim qta As New DataSetTableAdapters.QueriesTableAdapter
            Dim count As Integer = QTA.WorkingInvoice_Count

            If (count = 0) Then
                ' checking if dtp is more than 30 days our
                Dim futureDate As Date = DateAdd(DateInterval.Day, 30, Date.Now).Date
                If (dtp_GenInvTo.Value.Date > futureDate) Then
                    MsgBox("You cannot generate Invoices more than 30 days ahead of time.")
                Else
                    btn_GenerateInv.UseWaitCursor = True
                    QTA.GenerateRecurringInvoices(dtp_GenInvTo.Value.Date)
                    BATCH_WorkingInvoiceTableAdapter.Fill(DS_Batching.BATCH_WorkingInvoice)
                    btn_GenerateInv.UseWaitCursor = False
                    _targetedBillDate = dtp_GenInvTo.Value.Date
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
                        QTA.WorkingInvoice_UpdatePrint(actualRow.WorkingInvoiceID, "True")
                    Else
                        QTA.WorkingInvoice_UpdatePrint(actualRow.WorkingInvoiceID, "False")
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
            RefreshBatchQueue()
        End Sub

        Private Sub btn_CancelInvBatch_Click(sender As System.Object, e As System.EventArgs)
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
            QTA = New ds_BatchingTableAdapters.QueriesTableAdapter
        End Sub

      Private Sub btn_DeleteAllWrkInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteAllWrkInv.Click
            Dim result As MsgBoxResult = MsgBox("Are you sure you want to delete all Prepared Invoices?", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                Try
                    BATCH_WorkingInvoiceTableAdapter.DeleteAll()
                    RefreshBatchQueue()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Sub

        Private Sub btn_DeletePay_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeletePay.Click
            If (dg_PrepPay.SelectedRows.Count = 1) Then
                Dim row As ds_Batching.BATCH_WorkingPaymentsRow = CType(dg_PrepPay.SelectedRows(0).DataBoundItem, DataRowView).Row
                Dim result As DialogResult = MessageBox.Show("Delete this Prepared Payment?", "Confirm Prepared Payment delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    BATCH_WorkingPaymentsTableAdapter.DeleteByID(row.WorkingPaymentsID)
                    ' raise event
                    RaiseEvent CustomerPaymentMod(row.CustomerNumber)
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
            TotalCash = cash
            TotalChecks = checks
            TotalMoneyOrder = moneyO
        End Sub

        Private Function PayBatch_VerifyTotals() As Boolean
            Dim err As Boolean
            Dim s As New System.Text.StringBuilder

            ' cash total
            If (TotalCash > 0) Then
                If (CDbl(tb_TotalCash.Text) <> TotalCash) Then
                    tb_TotalCash.BackColor = AppColors.TextBoxErr
                    err = True
                    s.Append("- Total Cash incorrect").AppendLine()
                    tb_TotalCash.Clear()
                Else
                    tb_TotalCash.BackColor = AppColors.TextBoxDef
                End If
            End If

            ' check total
            If (TotalChecks > 0) Then
                If (CDbl(tb_TotalCheck.Text) <> TotalChecks) Then
                    tb_TotalCheck.BackColor = AppColors.TextBoxErr
                    err = True
                    s.Append("- Total Checks incorrect").AppendLine()
                    tb_TotalCheck.Clear()
                Else
                    tb_TotalCheck.BackColor = AppColors.TextBoxDef
                End If
            End If

            ' money order total
            If (TotalMoneyOrder > 0) Then
                If (CDbl(tb_TotalMoneyOrder.Text) <> TotalMoneyOrder) Then
                    tb_TotalMoneyOrder.BackColor = AppColors.TextBoxErr
                    err = True
                    s.Append("- Total Money Orders incorrect")
                    tb_TotalMoneyOrder.Clear()
                Else
                    tb_TotalMoneyOrder.BackColor = AppColors.TextBoxDef
                End If
            End If

            If (Not err) Then
                Return True
            Else
                MessageBox.Show("Please correct the following totals before batching can begin:" & vbCrLf & s.ToString, "Totals Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Function

        Private Sub btn_PayBatch_Click(sender As System.Object, e As System.EventArgs) Handles btn_PayBatch.Click
            If (Not _payBatchRunning) Then
                If (PayBatch_VerifyTotals()) Then
                    Dim result As DialogResult = MessageBox.Show("Payment Totals Match. Begin Batching " & dg_PrepPay.RowCount & " payments?", "Begin Payment Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (result = Windows.Forms.DialogResult.Yes) Then
                        ' change button and set form var
                        btn_PayBatch.Text = "Cancel Batch"
                        btn_PayBatch.ForeColor = Color.Red
                        _payBatchRunning = True
                        ' init the object that the worker calls
                        Dim payBatcher As New QB_Batching.Payments()
                        ' start the worker
                        BatchWorker.RunWorkerAsync(payBatcher)
                    End If
                Else
                    ' totals did not match - err message is in validation
                End If
            Else
                ' batch is running, this is a cancel call
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to stop this Payment Batch?", "Stop Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    BatchWorker.CancelAsync()
                End If
            End If

        End Sub

        Private Sub tc_Master_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tc_Master.SelectedIndexChanged
            If (_lockTab) Then
                If (tc_Master.SelectedIndex = 0) Then
                    MessageBox.Show("You must finish modifying the payment first.", "Finish Modifying Payment", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    tc_Master.SelectedIndex = 1
                End If
            Else
                If (tc_Master.SelectedIndex = 0) Then
                    BATCH_WorkingInvoiceTableAdapter.Fill(DS_Batching.BATCH_WorkingInvoice)
                Else
                    BATCH_WorkingPaymentsTableAdapter.Fill(DS_Batching.BATCH_WorkingPayments)
                End If
            End If
            
        End Sub

        Private Sub dg_PrepPay_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_PrepPay.CellMouseDown
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                For Each row As DataGridViewRow In dg_PrepPay
                    row.Selected = False
                Next
                dg_PrepPay.Rows(e.RowIndex).Selected = True
            End If
        End Sub

        Private Sub dg_PrepPay_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_PrepPay.RowsAdded
            PayBatch_TotalsPrep()
        End Sub

        Private Sub cmb_PayTypes_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmb_PayTypes.SelectedValueChanged
            If (cmb_PayTypes.SelectedValue = TC_ENPaymentTypes.Cash) Then
                lbl_RefNumber.Visible = False
                tb_RefNum.Visible = False
                lbl_DateOnCheck.Visible = False
                dtp_DateOnCheck.Visible = False
            Else
                lbl_RefNumber.Visible = True
                tb_RefNum.Visible = True
                lbl_DateOnCheck.Visible = True
                dtp_DateOnCheck.Visible = True
            End If
        End Sub

        Private _lockTab As Boolean
        Private Sub btn_ModPayment_Click(sender As System.Object, e As System.EventArgs) Handles btn_ModPayment.Click
            If (dg_PrepPay.SelectedRows.Count = 1) Then
                grp_ModPayInfo.Visible = True
            End If
        End Sub

        Private Sub grp_ModPayInfo_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles grp_ModPayInfo.VisibleChanged
            If (grp_ModPayInfo.Visible = True) Then
                ' lock form to this tab
                _lockTab = True
                pnl_PayRight.Enabled = False
                cm_PayGrid.Enabled = False
                ' visible - get row and set boxes
                Dim row As ds_Batching.BATCH_WorkingPaymentsRow = CType(dg_PrepPay.SelectedRows(0).DataBoundItem, DataRowView).Row
                cmb_PayTypes.SelectedValue = row.WorkingPaymentsType
                tb_Amount.Text = row.WorkingPaymentsAmount
                If (Not row.IsWorkingPaymentsCheckNumNull) Then
                    tb_RefNum.Text = row.WorkingPaymentsCheckNum
                End If
                If (Not row.IsDATE_ON_CHECKNull) Then
                    dtp_DateOnCheck.Value = row.DATE_ON_CHECK
                End If
            Else
                _lockTab = False
                cm_PayGrid.Enabled = True
                ' hidden
                cmb_PayTypes.SelectedIndex = 0
                tb_Amount.Clear()
                tb_RefNum.Clear()
                dtp_DateOnCheck.Value = Date.Now
            End If

        End Sub

        
        Private Sub btn_CancelPayMod_Click(sender As System.Object, e As System.EventArgs) Handles btn_CancelPayMod.Click
            grp_ModPayInfo.Visible = False
        End Sub

        Private Sub btn_SavePayment_Click(sender As System.Object, e As System.EventArgs) Handles btn_SavePayment.Click
            Dim checkRefNum As String
            Dim dateOnCheck As Date?

            If (cmb_PayTypes.SelectedValue <> TC_ENPaymentTypes.Cash) Then
                ' get date
                dateOnCheck = dtp_DateOnCheck.Value.Date

                ' remove all spaces from begining and end
                checkRefNum = Trim(tb_RefNum.Text)
                ' replace all zeros by spaces, and then, left-trim that result, ie, remove starting spaces. 
                'The external Replace replaces the spaces left in the string to their initial 0 character.
                Replace(LTrim(Replace(checkRefNum, "0", " ")), " ", "0")

                ' having them confirm check number
                If (checkRefNum <> "") Then
                    ' hide current ref number
                    tb_RefNum.Visible = False
                    Dim reEntry As String = InputBox("Please enter the check number again:", "Confirm Check #")
                    ' show ref number after input
                    tb_RefNum.Visible = True
                    ' trim entry number and compare
                    Trim(reEntry)
                    Replace(LTrim(Replace(reEntry, "0", " ")), " ", "0")
                    ' do these match
                    If (reEntry <> checkRefNum) Then
                        MessageBox.Show("Check numbers do not match. Please re-enter the check number and double check information.", "Check # Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        tb_RefNum.Clear()
                        Exit Sub
                    End If
                End If
            End If


            Dim row As ds_Batching.BATCH_WorkingPaymentsRow = CType(dg_PrepPay.SelectedRows(0).DataBoundItem, DataRowView).Row
            With row
                .WorkingPaymentsType = cmb_PayTypes.SelectedValue
                .WorkingPaymentsAmount = tb_Amount.Text
                If (checkRefNum IsNot Nothing) Then
                    .WorkingPaymentsCheckNum = checkRefNum
                End If
                If (dateOnCheck IsNot Nothing) Then
                    .DATE_ON_CHECK = dateOnCheck
                End If
            End With

            ' save row
            Try
                row.EndEdit()
                BATCH_WorkingPaymentsTableAdapter.Update(row)
                RaiseEvent CustomerPaymentMod(row.CustomerNumber)
                grp_ModPayInfo.Visible = False
            Catch ex as SqlException
                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace