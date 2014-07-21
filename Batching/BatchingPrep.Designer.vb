Namespace Batching
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BatchingPrep
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchingPrep))
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.BATCHWorkingInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DS_Batching = New TrashCash.ds_Batching()
            Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.btn_ModPayment = New System.Windows.Forms.ToolStripMenuItem()
            Me.btn_DeletePay = New System.Windows.Forms.ToolStripMenuItem()
            Me.BATCHWorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.BatchWorker = New System.ComponentModel.BackgroundWorker()
            Me.BATCH_WorkingPaymentsTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter()
            Me.BATCH_WorkingInvoiceTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter()
            Me.tc_Master = New System.Windows.Forms.TabControl()
            Me.tp_Inv = New System.Windows.Forms.TabPage()
            Me.dg_PrepInv = New System.Windows.Forms.DataGridView()
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.CustomerFullNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoicePostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StartBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EndBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnl_InvGen = New System.Windows.Forms.Panel()
            Me.btn_DeleteInvs = New System.Windows.Forms.Button()
            Me.lbl_InvQueueCount = New System.Windows.Forms.Label()
            Me.btn_GenerateInv = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dtp_GenInvTo = New System.Windows.Forms.DateTimePicker()
            Me.pnl_LeftBot = New System.Windows.Forms.Panel()
            Me.lbl_InvBatchCust = New System.Windows.Forms.Label()
            Me.btn_InvBatch = New System.Windows.Forms.Button()
            Me.lbl_InvBatchCount = New System.Windows.Forms.Label()
            Me.pb_Invoices = New System.Windows.Forms.ProgressBar()
            Me.tp_Pay = New System.Windows.Forms.TabPage()
            Me.lbl_PayQueueCount = New System.Windows.Forms.Label()
            Me.lbl_TotalCash = New System.Windows.Forms.Label()
            Me.lbl_TotalMoneyOrder = New System.Windows.Forms.Label()
            Me.lbl_TotalCheck = New System.Windows.Forms.Label()
            Me.tb_TotalMoneyOrder = New TrashCash.Classes.CurrencyTextBox()
            Me.tb_TotalCheck = New TrashCash.Classes.CurrencyTextBox()
            Me.tb_TotalCash = New TrashCash.Classes.CurrencyTextBox()
            Me.pb_Payments = New System.Windows.Forms.ProgressBar()
            Me.lbl_PayBatchCount = New System.Windows.Forms.Label()
            Me.lbl_PayBatchCust = New System.Windows.Forms.Label()
            Me.dg_PrepPay = New System.Windows.Forms.DataGridView()
            Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsType = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.PaymentTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Types = New TrashCash.ds_Types()
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsCheckNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.btn_PayBatch = New System.Windows.Forms.Button()
            Me.PaymentTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter()
            Me.btn_PayRefresh = New System.Windows.Forms.Button()
            CType(Me.BATCHWorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DS_Batching, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cm_PayGrid.SuspendLayout()
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tc_Master.SuspendLayout()
            Me.tp_Inv.SuspendLayout()
            CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_InvGen.SuspendLayout()
            Me.pnl_LeftBot.SuspendLayout()
            Me.tp_Pay.SuspendLayout()
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BATCHWorkingInvoiceBindingSource
            '
            Me.BATCHWorkingInvoiceBindingSource.DataMember = "BATCH_WorkingInvoice"
            Me.BATCHWorkingInvoiceBindingSource.DataSource = Me.DS_Batching
            '
            'DS_Batching
            '
            Me.DS_Batching.DataSetName = "ds_Batching"
            Me.DS_Batching.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'cm_PayGrid
            '
            Me.cm_PayGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ModPayment, Me.btn_DeletePay})
            Me.cm_PayGrid.Name = "cm_PayGrid"
            Me.cm_PayGrid.Size = New System.Drawing.Size(163, 48)
            '
            'btn_ModPayment
            '
            Me.btn_ModPayment.Name = "btn_ModPayment"
            Me.btn_ModPayment.Size = New System.Drawing.Size(162, 22)
            Me.btn_ModPayment.Text = "Modify Payment"
            '
            'btn_DeletePay
            '
            Me.btn_DeletePay.Name = "btn_DeletePay"
            Me.btn_DeletePay.Size = New System.Drawing.Size(162, 22)
            Me.btn_DeletePay.Text = "Delete Payment"
            '
            'BATCHWorkingPaymentsBindingSource
            '
            Me.BATCHWorkingPaymentsBindingSource.DataMember = "BATCH_WorkingPayments"
            Me.BATCHWorkingPaymentsBindingSource.DataSource = Me.DS_Batching
            '
            'BatchWorker
            '
            Me.BatchWorker.WorkerReportsProgress = True
            Me.BatchWorker.WorkerSupportsCancellation = True
            '
            'BATCH_WorkingPaymentsTableAdapter
            '
            Me.BATCH_WorkingPaymentsTableAdapter.ClearBeforeFill = True
            '
            'BATCH_WorkingInvoiceTableAdapter
            '
            Me.BATCH_WorkingInvoiceTableAdapter.ClearBeforeFill = True
            '
            'tc_Master
            '
            Me.tc_Master.Controls.Add(Me.tp_Inv)
            Me.tc_Master.Controls.Add(Me.tp_Pay)
            Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.tc_Master.Location = New System.Drawing.Point(0, 12)
            Me.tc_Master.Name = "tc_Master"
            Me.tc_Master.SelectedIndex = 0
            Me.tc_Master.Size = New System.Drawing.Size(759, 634)
            Me.tc_Master.TabIndex = 4
            '
            'tp_Inv
            '
            Me.tp_Inv.BackColor = System.Drawing.SystemColors.Control
            Me.tp_Inv.Controls.Add(Me.dg_PrepInv)
            Me.tp_Inv.Controls.Add(Me.pnl_InvGen)
            Me.tp_Inv.Controls.Add(Me.pnl_LeftBot)
            Me.tp_Inv.Location = New System.Drawing.Point(4, 22)
            Me.tp_Inv.Name = "tp_Inv"
            Me.tp_Inv.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_Inv.Size = New System.Drawing.Size(751, 608)
            Me.tp_Inv.TabIndex = 0
            Me.tp_Inv.Text = "Recurring Service Invoices"
            '
            'dg_PrepInv
            '
            Me.dg_PrepInv.AllowUserToAddRows = False
            Me.dg_PrepInv.AllowUserToDeleteRows = False
            Me.dg_PrepInv.AllowUserToResizeRows = False
            Me.dg_PrepInv.AutoGenerateColumns = False
            Me.dg_PrepInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dg_PrepInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceToBePrintedDataGridViewCheckBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn1, Me.InvoicePostDateDataGridViewTextBoxColumn, Me.StartBillingDateDataGridViewTextBoxColumn, Me.EndBillingDateDataGridViewTextBoxColumn, Me.TotalDataGridViewTextBoxColumn})
            Me.dg_PrepInv.DataSource = Me.BATCHWorkingInvoiceBindingSource
            Me.dg_PrepInv.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.dg_PrepInv.Location = New System.Drawing.Point(3, 120)
            Me.dg_PrepInv.MultiSelect = False
            Me.dg_PrepInv.Name = "dg_PrepInv"
            Me.dg_PrepInv.RowHeadersVisible = False
            Me.dg_PrepInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PrepInv.Size = New System.Drawing.Size(745, 402)
            Me.dg_PrepInv.TabIndex = 10
            '
            'InvoiceToBePrintedDataGridViewCheckBoxColumn
            '
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn.DataPropertyName = "InvoiceToBePrinted"
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn.HeaderText = "Print"
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn.Name = "InvoiceToBePrintedDataGridViewCheckBoxColumn"
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn.Width = 34
            '
            'CustomerFullNameDataGridViewTextBoxColumn1
            '
            Me.CustomerFullNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.CustomerFullNameDataGridViewTextBoxColumn1.DataPropertyName = "CustomerFullName"
            Me.CustomerFullNameDataGridViewTextBoxColumn1.HeaderText = "Customer Name"
            Me.CustomerFullNameDataGridViewTextBoxColumn1.Name = "CustomerFullNameDataGridViewTextBoxColumn1"
            '
            'InvoicePostDateDataGridViewTextBoxColumn
            '
            Me.InvoicePostDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.InvoicePostDateDataGridViewTextBoxColumn.DataPropertyName = "InvoicePostDate"
            DataGridViewCellStyle1.Format = "d"
            Me.InvoicePostDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
            Me.InvoicePostDateDataGridViewTextBoxColumn.HeaderText = "Post Date"
            Me.InvoicePostDateDataGridViewTextBoxColumn.Name = "InvoicePostDateDataGridViewTextBoxColumn"
            Me.InvoicePostDateDataGridViewTextBoxColumn.Width = 79
            '
            'StartBillingDateDataGridViewTextBoxColumn
            '
            Me.StartBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.StartBillingDateDataGridViewTextBoxColumn.DataPropertyName = "StartBillingDate"
            DataGridViewCellStyle2.Format = "d"
            Me.StartBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.StartBillingDateDataGridViewTextBoxColumn.HeaderText = "Start Billing"
            Me.StartBillingDateDataGridViewTextBoxColumn.Name = "StartBillingDateDataGridViewTextBoxColumn"
            Me.StartBillingDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.StartBillingDateDataGridViewTextBoxColumn.Width = 84
            '
            'EndBillingDateDataGridViewTextBoxColumn
            '
            Me.EndBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.EndBillingDateDataGridViewTextBoxColumn.DataPropertyName = "EndBillingDate"
            DataGridViewCellStyle3.Format = "d"
            Me.EndBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
            Me.EndBillingDateDataGridViewTextBoxColumn.HeaderText = "End Billing"
            Me.EndBillingDateDataGridViewTextBoxColumn.Name = "EndBillingDateDataGridViewTextBoxColumn"
            Me.EndBillingDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.EndBillingDateDataGridViewTextBoxColumn.Width = 81
            '
            'TotalDataGridViewTextBoxColumn
            '
            Me.TotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
            DataGridViewCellStyle4.Format = "C2"
            Me.TotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
            Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
            Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
            Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
            Me.TotalDataGridViewTextBoxColumn.Width = 56
            '
            'pnl_InvGen
            '
            Me.pnl_InvGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_InvGen.Controls.Add(Me.btn_DeleteInvs)
            Me.pnl_InvGen.Controls.Add(Me.lbl_InvQueueCount)
            Me.pnl_InvGen.Controls.Add(Me.btn_GenerateInv)
            Me.pnl_InvGen.Controls.Add(Me.Label2)
            Me.pnl_InvGen.Controls.Add(Me.dtp_GenInvTo)
            Me.pnl_InvGen.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_InvGen.Location = New System.Drawing.Point(3, 3)
            Me.pnl_InvGen.Name = "pnl_InvGen"
            Me.pnl_InvGen.Padding = New System.Windows.Forms.Padding(3)
            Me.pnl_InvGen.Size = New System.Drawing.Size(745, 111)
            Me.pnl_InvGen.TabIndex = 7
            '
            'btn_DeleteInvs
            '
            Me.btn_DeleteInvs.ForeColor = System.Drawing.Color.Red
            Me.btn_DeleteInvs.Location = New System.Drawing.Point(643, 67)
            Me.btn_DeleteInvs.Name = "btn_DeleteInvs"
            Me.btn_DeleteInvs.Size = New System.Drawing.Size(75, 23)
            Me.btn_DeleteInvs.TabIndex = 142
            Me.btn_DeleteInvs.Text = "Delete All"
            Me.btn_DeleteInvs.UseVisualStyleBackColor = True
            '
            'lbl_InvQueueCount
            '
            Me.lbl_InvQueueCount.AutoSize = True
            Me.lbl_InvQueueCount.Location = New System.Drawing.Point(614, 93)
            Me.lbl_InvQueueCount.Name = "lbl_InvQueueCount"
            Me.lbl_InvQueueCount.Size = New System.Drawing.Size(123, 13)
            Me.lbl_InvQueueCount.TabIndex = 141
            Me.lbl_InvQueueCount.Text = "Invoices in Queue: 1000"
            '
            'btn_GenerateInv
            '
            Me.btn_GenerateInv.AutoSize = True
            Me.btn_GenerateInv.Location = New System.Drawing.Point(319, 72)
            Me.btn_GenerateInv.Name = "btn_GenerateInv"
            Me.btn_GenerateInv.Size = New System.Drawing.Size(104, 23)
            Me.btn_GenerateInv.TabIndex = 2
            Me.btn_GenerateInv.Text = "Generate Invoices"
            Me.btn_GenerateInv.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label2.Location = New System.Drawing.Point(3, 3)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(737, 40)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = resources.GetString("Label2.Text")
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'dtp_GenInvTo
            '
            Me.dtp_GenInvTo.Location = New System.Drawing.Point(275, 46)
            Me.dtp_GenInvTo.Name = "dtp_GenInvTo"
            Me.dtp_GenInvTo.Size = New System.Drawing.Size(200, 20)
            Me.dtp_GenInvTo.TabIndex = 0
            '
            'pnl_LeftBot
            '
            Me.pnl_LeftBot.Controls.Add(Me.lbl_InvBatchCust)
            Me.pnl_LeftBot.Controls.Add(Me.btn_InvBatch)
            Me.pnl_LeftBot.Controls.Add(Me.lbl_InvBatchCount)
            Me.pnl_LeftBot.Controls.Add(Me.pb_Invoices)
            Me.pnl_LeftBot.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnl_LeftBot.Location = New System.Drawing.Point(3, 522)
            Me.pnl_LeftBot.Name = "pnl_LeftBot"
            Me.pnl_LeftBot.Size = New System.Drawing.Size(745, 83)
            Me.pnl_LeftBot.TabIndex = 9
            '
            'lbl_InvBatchCust
            '
            Me.lbl_InvBatchCust.AutoSize = True
            Me.lbl_InvBatchCust.Location = New System.Drawing.Point(3, 41)
            Me.lbl_InvBatchCust.Name = "lbl_InvBatchCust"
            Me.lbl_InvBatchCust.Size = New System.Drawing.Size(97, 13)
            Me.lbl_InvBatchCust.TabIndex = 3
            Me.lbl_InvBatchCust.Text = "fife abbyyyyyyyyyyy"
            Me.lbl_InvBatchCust.Visible = False
            '
            'btn_InvBatch
            '
            Me.btn_InvBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.btn_InvBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_InvBatch.Location = New System.Drawing.Point(291, 6)
            Me.btn_InvBatch.Name = "btn_InvBatch"
            Me.btn_InvBatch.Size = New System.Drawing.Size(172, 45)
            Me.btn_InvBatch.TabIndex = 6
            Me.btn_InvBatch.Text = "Batch Invoices"
            Me.btn_InvBatch.UseVisualStyleBackColor = True
            '
            'lbl_InvBatchCount
            '
            Me.lbl_InvBatchCount.Location = New System.Drawing.Point(653, 44)
            Me.lbl_InvBatchCount.Name = "lbl_InvBatchCount"
            Me.lbl_InvBatchCount.Size = New System.Drawing.Size(87, 13)
            Me.lbl_InvBatchCount.TabIndex = 1
            Me.lbl_InvBatchCount.Text = "100/100"
            Me.lbl_InvBatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbl_InvBatchCount.Visible = False
            '
            'pb_Invoices
            '
            Me.pb_Invoices.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pb_Invoices.Location = New System.Drawing.Point(0, 60)
            Me.pb_Invoices.Name = "pb_Invoices"
            Me.pb_Invoices.Size = New System.Drawing.Size(745, 23)
            Me.pb_Invoices.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.pb_Invoices.TabIndex = 0
            '
            'tp_Pay
            '
            Me.tp_Pay.BackColor = System.Drawing.SystemColors.Control
            Me.tp_Pay.Controls.Add(Me.lbl_PayQueueCount)
            Me.tp_Pay.Controls.Add(Me.lbl_TotalCash)
            Me.tp_Pay.Controls.Add(Me.lbl_TotalMoneyOrder)
            Me.tp_Pay.Controls.Add(Me.lbl_TotalCheck)
            Me.tp_Pay.Controls.Add(Me.tb_TotalMoneyOrder)
            Me.tp_Pay.Controls.Add(Me.tb_TotalCheck)
            Me.tp_Pay.Controls.Add(Me.tb_TotalCash)
            Me.tp_Pay.Controls.Add(Me.pb_Payments)
            Me.tp_Pay.Controls.Add(Me.lbl_PayBatchCount)
            Me.tp_Pay.Controls.Add(Me.lbl_PayBatchCust)
            Me.tp_Pay.Controls.Add(Me.dg_PrepPay)
            Me.tp_Pay.Controls.Add(Me.btn_PayBatch)
            Me.tp_Pay.Location = New System.Drawing.Point(4, 22)
            Me.tp_Pay.Name = "tp_Pay"
            Me.tp_Pay.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_Pay.Size = New System.Drawing.Size(751, 608)
            Me.tp_Pay.TabIndex = 1
            Me.tp_Pay.Text = "Payments"
            '
            'lbl_PayQueueCount
            '
            Me.lbl_PayQueueCount.AutoSize = True
            Me.lbl_PayQueueCount.Location = New System.Drawing.Point(614, 479)
            Me.lbl_PayQueueCount.Name = "lbl_PayQueueCount"
            Me.lbl_PayQueueCount.Size = New System.Drawing.Size(129, 13)
            Me.lbl_PayQueueCount.TabIndex = 140
            Me.lbl_PayQueueCount.Text = "Payments in Queue: 1000"
            '
            'lbl_TotalCash
            '
            Me.lbl_TotalCash.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lbl_TotalCash.AutoSize = True
            Me.lbl_TotalCash.Location = New System.Drawing.Point(167, 505)
            Me.lbl_TotalCash.Name = "lbl_TotalCash"
            Me.lbl_TotalCash.Size = New System.Drawing.Size(58, 13)
            Me.lbl_TotalCash.TabIndex = 139
            Me.lbl_TotalCash.Text = "Total Cash"
            '
            'lbl_TotalMoneyOrder
            '
            Me.lbl_TotalMoneyOrder.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lbl_TotalMoneyOrder.AutoSize = True
            Me.lbl_TotalMoneyOrder.Location = New System.Drawing.Point(493, 505)
            Me.lbl_TotalMoneyOrder.Name = "lbl_TotalMoneyOrder"
            Me.lbl_TotalMoneyOrder.Size = New System.Drawing.Size(95, 13)
            Me.lbl_TotalMoneyOrder.TabIndex = 138
            Me.lbl_TotalMoneyOrder.Text = "Total Money Order"
            '
            'lbl_TotalCheck
            '
            Me.lbl_TotalCheck.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lbl_TotalCheck.AutoSize = True
            Me.lbl_TotalCheck.Location = New System.Drawing.Point(334, 505)
            Me.lbl_TotalCheck.Name = "lbl_TotalCheck"
            Me.lbl_TotalCheck.Size = New System.Drawing.Size(70, 13)
            Me.lbl_TotalCheck.TabIndex = 137
            Me.lbl_TotalCheck.Text = "Total Checks"
            '
            'tb_TotalMoneyOrder
            '
            Me.tb_TotalMoneyOrder.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.tb_TotalMoneyOrder.Location = New System.Drawing.Point(491, 482)
            Me.tb_TotalMoneyOrder.Name = "tb_TotalMoneyOrder"
            Me.tb_TotalMoneyOrder.Size = New System.Drawing.Size(100, 20)
            Me.tb_TotalMoneyOrder.TabIndex = 136
            '
            'tb_TotalCheck
            '
            Me.tb_TotalCheck.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.tb_TotalCheck.Location = New System.Drawing.Point(318, 482)
            Me.tb_TotalCheck.Name = "tb_TotalCheck"
            Me.tb_TotalCheck.Size = New System.Drawing.Size(100, 20)
            Me.tb_TotalCheck.TabIndex = 135
            '
            'tb_TotalCash
            '
            Me.tb_TotalCash.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.tb_TotalCash.Location = New System.Drawing.Point(146, 482)
            Me.tb_TotalCash.Name = "tb_TotalCash"
            Me.tb_TotalCash.Size = New System.Drawing.Size(100, 20)
            Me.tb_TotalCash.TabIndex = 134
            '
            'pb_Payments
            '
            Me.pb_Payments.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pb_Payments.Location = New System.Drawing.Point(3, 582)
            Me.pb_Payments.Name = "pb_Payments"
            Me.pb_Payments.Size = New System.Drawing.Size(745, 23)
            Me.pb_Payments.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.pb_Payments.TabIndex = 133
            '
            'lbl_PayBatchCount
            '
            Me.lbl_PayBatchCount.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lbl_PayBatchCount.Location = New System.Drawing.Point(628, 558)
            Me.lbl_PayBatchCount.Name = "lbl_PayBatchCount"
            Me.lbl_PayBatchCount.Size = New System.Drawing.Size(120, 20)
            Me.lbl_PayBatchCount.TabIndex = 130
            Me.lbl_PayBatchCount.Text = "100/100"
            Me.lbl_PayBatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbl_PayBatchCount.Visible = False
            '
            'lbl_PayBatchCust
            '
            Me.lbl_PayBatchCust.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbl_PayBatchCust.AutoSize = True
            Me.lbl_PayBatchCust.Location = New System.Drawing.Point(6, 562)
            Me.lbl_PayBatchCust.Name = "lbl_PayBatchCust"
            Me.lbl_PayBatchCust.Size = New System.Drawing.Size(87, 13)
            Me.lbl_PayBatchCust.TabIndex = 131
            Me.lbl_PayBatchCust.Text = "fife abbyyyyyyyyy"
            Me.lbl_PayBatchCust.Visible = False
            '
            'dg_PrepPay
            '
            Me.dg_PrepPay.AllowUserToAddRows = False
            Me.dg_PrepPay.AllowUserToDeleteRows = False
            Me.dg_PrepPay.AllowUserToResizeRows = False
            Me.dg_PrepPay.AutoGenerateColumns = False
            Me.dg_PrepPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_PrepPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerFullNameDataGridViewTextBoxColumn, Me.WorkingPaymentsType, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNum})
            Me.dg_PrepPay.ContextMenuStrip = Me.cm_PayGrid
            Me.dg_PrepPay.DataSource = Me.BATCHWorkingPaymentsBindingSource
            Me.dg_PrepPay.Dock = System.Windows.Forms.DockStyle.Top
            Me.dg_PrepPay.Location = New System.Drawing.Point(3, 3)
            Me.dg_PrepPay.Name = "dg_PrepPay"
            Me.dg_PrepPay.ReadOnly = True
            Me.dg_PrepPay.RowHeadersVisible = False
            Me.dg_PrepPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PrepPay.Size = New System.Drawing.Size(745, 473)
            Me.dg_PrepPay.TabIndex = 132
            '
            'CustomerFullNameDataGridViewTextBoxColumn
            '
            Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
            Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Customer Name"
            Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
            Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'WorkingPaymentsType
            '
            Me.WorkingPaymentsType.DataPropertyName = "WorkingPaymentsType"
            Me.WorkingPaymentsType.DataSource = Me.PaymentTypesBindingSource
            Me.WorkingPaymentsType.DisplayMember = "PaymentTypeName"
            Me.WorkingPaymentsType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
            Me.WorkingPaymentsType.HeaderText = "Payment Type"
            Me.WorkingPaymentsType.Name = "WorkingPaymentsType"
            Me.WorkingPaymentsType.ReadOnly = True
            Me.WorkingPaymentsType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.WorkingPaymentsType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.WorkingPaymentsType.ValueMember = "PaymentTypeID"
            '
            'PaymentTypesBindingSource
            '
            Me.PaymentTypesBindingSource.DataMember = "PaymentTypes"
            Me.PaymentTypesBindingSource.DataSource = Me.Ds_Types
            '
            'Ds_Types
            '
            Me.Ds_Types.DataSetName = "ds_Types"
            Me.Ds_Types.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'WorkingPaymentsAmountDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
            DataGridViewCellStyle5.Format = "C2"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Name = "WorkingPaymentsAmountDataGridViewTextBoxColumn"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Width = 68
            '
            'WorkingPaymentsCheckNum
            '
            Me.WorkingPaymentsCheckNum.DataPropertyName = "WorkingPaymentsCheckNum"
            Me.WorkingPaymentsCheckNum.HeaderText = "Check #"
            Me.WorkingPaymentsCheckNum.Name = "WorkingPaymentsCheckNum"
            Me.WorkingPaymentsCheckNum.ReadOnly = True
            '
            'btn_PayBatch
            '
            Me.btn_PayBatch.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btn_PayBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.btn_PayBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_PayBatch.Location = New System.Drawing.Point(291, 525)
            Me.btn_PayBatch.Name = "btn_PayBatch"
            Me.btn_PayBatch.Size = New System.Drawing.Size(151, 45)
            Me.btn_PayBatch.TabIndex = 129
            Me.btn_PayBatch.Text = "Batch Payments"
            Me.btn_PayBatch.UseVisualStyleBackColor = True
            '
            'PaymentTypesTableAdapter
            '
            Me.PaymentTypesTableAdapter.ClearBeforeFill = True
            '
            'btn_PayRefresh
            '
            Me.btn_PayRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.btn_PayRefresh.Location = New System.Drawing.Point(677, 2)
            Me.btn_PayRefresh.Name = "btn_PayRefresh"
            Me.btn_PayRefresh.Size = New System.Drawing.Size(75, 23)
            Me.btn_PayRefresh.TabIndex = 140
            Me.btn_PayRefresh.Text = "Refresh"
            Me.btn_PayRefresh.UseVisualStyleBackColor = True
            '
            'BatchingPrep
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(759, 646)
            Me.Controls.Add(Me.btn_PayRefresh)
            Me.Controls.Add(Me.tc_Master)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "BatchingPrep"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Batching Work"
            CType(Me.BATCHWorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DS_Batching, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cm_PayGrid.ResumeLayout(False)
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tc_Master.ResumeLayout(False)
            Me.tp_Inv.ResumeLayout(False)
            CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_InvGen.ResumeLayout(False)
            Me.pnl_InvGen.PerformLayout()
            Me.pnl_LeftBot.ResumeLayout(False)
            Me.pnl_LeftBot.PerformLayout()
            Me.tp_Pay.ResumeLayout(False)
            Me.tp_Pay.PerformLayout()
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BatchWorker As System.ComponentModel.BackgroundWorker
        Friend WithEvents cm_PayGrid As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents btn_DeletePay As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DS_Batching As ds_Batching
        Friend WithEvents BATCHWorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BATCH_WorkingPaymentsTableAdapter As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
        Friend WithEvents BATCHWorkingInvoiceBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BATCH_WorkingInvoiceTableAdapter As ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
        Friend WithEvents tc_Master As System.Windows.Forms.TabControl
        Friend WithEvents tp_Inv As System.Windows.Forms.TabPage
        Friend WithEvents tp_Pay As System.Windows.Forms.TabPage
        Friend WithEvents Ds_Types As TrashCash.ds_Types
        Friend WithEvents PaymentTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PaymentTypesTableAdapter As TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter

        Friend WithEvents btn_ModPayment As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents dg_PrepInv As System.Windows.Forms.DataGridView
        Friend WithEvents InvoiceToBePrintedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoicePostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StartBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EndBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnl_InvGen As System.Windows.Forms.Panel
        Friend WithEvents btn_GenerateInv As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dtp_GenInvTo As System.Windows.Forms.DateTimePicker
        Public WithEvents pnl_LeftBot As System.Windows.Forms.Panel
        Public WithEvents lbl_InvBatchCust As System.Windows.Forms.Label
        Friend WithEvents btn_InvBatch As System.Windows.Forms.Button
        Public WithEvents lbl_InvBatchCount As System.Windows.Forms.Label
        Public WithEvents pb_Invoices As System.Windows.Forms.ProgressBar
        Friend WithEvents lbl_TotalCash As System.Windows.Forms.Label
        Friend WithEvents lbl_TotalMoneyOrder As System.Windows.Forms.Label
        Friend WithEvents lbl_TotalCheck As System.Windows.Forms.Label
        Friend WithEvents tb_TotalMoneyOrder As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents tb_TotalCheck As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents tb_TotalCash As TrashCash.Classes.CurrencyTextBox
        Public WithEvents pb_Payments As System.Windows.Forms.ProgressBar
        Public WithEvents lbl_PayBatchCount As System.Windows.Forms.Label
        Public WithEvents lbl_PayBatchCust As System.Windows.Forms.Label
        Friend WithEvents dg_PrepPay As System.Windows.Forms.DataGridView
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsType As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsCheckNum As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btn_PayBatch As System.Windows.Forms.Button
        Friend WithEvents btn_PayRefresh As System.Windows.Forms.Button
        Friend WithEvents lbl_InvQueueCount As System.Windows.Forms.Label
        Friend WithEvents lbl_PayQueueCount As System.Windows.Forms.Label
        Friend WithEvents btn_DeleteInvs As System.Windows.Forms.Button
    End Class
End Namespace