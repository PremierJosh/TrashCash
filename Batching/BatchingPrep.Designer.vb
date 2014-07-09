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
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchingPrep))
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.BATCHWorkingInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DS_Batching = New TrashCash.ds_Batching()
            Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.btn_ModPayment = New System.Windows.Forms.ToolStripMenuItem()
            Me.btn_DeletePay = New System.Windows.Forms.ToolStripMenuItem()
            Me.BATCHWorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.btn_Refresh = New System.Windows.Forms.ToolStripButton()
            Me.BatchWorker = New System.ComponentModel.BackgroundWorker()
            Me.BATCH_WorkingPaymentsTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter()
            Me.BATCH_WorkingInvoiceTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter()
            Me.tc_Master = New System.Windows.Forms.TabControl()
            Me.tp_Inv = New System.Windows.Forms.TabPage()
            Me.pnl_Left = New System.Windows.Forms.Panel()
            Me.dg_PrepInv = New System.Windows.Forms.DataGridView()
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.CustomerFullNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoicePostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StartBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EndBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnl_LeftBot = New System.Windows.Forms.Panel()
            Me.lbl_InvBatchCust = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lbl_InvBatchCount = New System.Windows.Forms.Label()
            Me.pb_Invoices = New System.Windows.Forms.ProgressBar()
            Me.pnl_Top = New System.Windows.Forms.Panel()
            Me.pnl_TopContent = New System.Windows.Forms.Panel()
            Me.btn_DeleteAllWrkInv = New System.Windows.Forms.Button()
            Me.btn_GenerateInv = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dtp_GenInvTo = New System.Windows.Forms.DateTimePicker()
            Me.tp_Pay = New System.Windows.Forms.TabPage()
            Me.pnl_PayRight = New System.Windows.Forms.Panel()
            Me.lbl_TotalCash = New System.Windows.Forms.Label()
            Me.lbl_TotalMoneyOrder = New System.Windows.Forms.Label()
            Me.lbl_TotalCheck = New System.Windows.Forms.Label()
            Me.tb_TotalMoneyOrder = New TrashCash.Classes.CurrencyTextBox()
            Me.tb_TotalCheck = New TrashCash.Classes.CurrencyTextBox()
            Me.tb_TotalCash = New TrashCash.Classes.CurrencyTextBox()
            Me.Label3 = New System.Windows.Forms.Label()
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
            Me.grp_ModPayInfo = New System.Windows.Forms.GroupBox()
            Me.btn_CancelPayMod = New System.Windows.Forms.Button()
            Me.lbl_PayType = New System.Windows.Forms.Label()
            Me.cmb_PayTypes = New System.Windows.Forms.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.tb_Amount = New TrashCash.Classes.CurrencyTextBox()
            Me.lbl_RefNumber = New System.Windows.Forms.Label()
            Me.btn_SavePayment = New System.Windows.Forms.Button()
            Me.lbl_DateOnCheck = New System.Windows.Forms.Label()
            Me.dtp_DateOnCheck = New System.Windows.Forms.DateTimePicker()
            Me.tb_RefNum = New System.Windows.Forms.TextBox()
            Me.PaymentTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter()
            CType(Me.BATCHWorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DS_Batching, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cm_PayGrid.SuspendLayout()
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip1.SuspendLayout()
            Me.tc_Master.SuspendLayout()
            Me.tp_Inv.SuspendLayout()
            Me.pnl_Left.SuspendLayout()
            CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_LeftBot.SuspendLayout()
            Me.pnl_Top.SuspendLayout()
            Me.pnl_TopContent.SuspendLayout()
            Me.tp_Pay.SuspendLayout()
            Me.pnl_PayRight.SuspendLayout()
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_ModPayInfo.SuspendLayout()
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
            'ToolStrip1
            '
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Refresh})
            Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(1034, 26)
            Me.ToolStrip1.TabIndex = 2
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'btn_Refresh
            '
            Me.btn_Refresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.btn_Refresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btn_Refresh.Image = Global.TrashCash.My.Resources.Resources.Refresh_icon
            Me.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_Refresh.Name = "btn_Refresh"
            Me.btn_Refresh.Size = New System.Drawing.Size(79, 23)
            Me.btn_Refresh.Text = "Refresh"
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
            Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tc_Master.Location = New System.Drawing.Point(0, 26)
            Me.tc_Master.Name = "tc_Master"
            Me.tc_Master.SelectedIndex = 0
            Me.tc_Master.Size = New System.Drawing.Size(1034, 613)
            Me.tc_Master.TabIndex = 4
            '
            'tp_Inv
            '
            Me.tp_Inv.BackColor = System.Drawing.SystemColors.Control
            Me.tp_Inv.Controls.Add(Me.pnl_Left)
            Me.tp_Inv.Controls.Add(Me.pnl_Top)
            Me.tp_Inv.Location = New System.Drawing.Point(4, 22)
            Me.tp_Inv.Name = "tp_Inv"
            Me.tp_Inv.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_Inv.Size = New System.Drawing.Size(1026, 587)
            Me.tp_Inv.TabIndex = 0
            Me.tp_Inv.Text = "Recurring Service Invoices"
            '
            'pnl_Left
            '
            Me.pnl_Left.Controls.Add(Me.dg_PrepInv)
            Me.pnl_Left.Controls.Add(Me.pnl_LeftBot)
            Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnl_Left.Location = New System.Drawing.Point(3, 117)
            Me.pnl_Left.Name = "pnl_Left"
            Me.pnl_Left.Padding = New System.Windows.Forms.Padding(3)
            Me.pnl_Left.Size = New System.Drawing.Size(616, 467)
            Me.pnl_Left.TabIndex = 5
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
            Me.dg_PrepInv.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg_PrepInv.Location = New System.Drawing.Point(3, 3)
            Me.dg_PrepInv.MultiSelect = False
            Me.dg_PrepInv.Name = "dg_PrepInv"
            Me.dg_PrepInv.RowHeadersVisible = False
            Me.dg_PrepInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PrepInv.Size = New System.Drawing.Size(610, 422)
            Me.dg_PrepInv.TabIndex = 2
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
            DataGridViewCellStyle6.Format = "d"
            Me.InvoicePostDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
            Me.InvoicePostDateDataGridViewTextBoxColumn.HeaderText = "Post Date"
            Me.InvoicePostDateDataGridViewTextBoxColumn.Name = "InvoicePostDateDataGridViewTextBoxColumn"
            Me.InvoicePostDateDataGridViewTextBoxColumn.Width = 79
            '
            'StartBillingDateDataGridViewTextBoxColumn
            '
            Me.StartBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.StartBillingDateDataGridViewTextBoxColumn.DataPropertyName = "StartBillingDate"
            DataGridViewCellStyle7.Format = "d"
            Me.StartBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
            Me.StartBillingDateDataGridViewTextBoxColumn.HeaderText = "Start Billing"
            Me.StartBillingDateDataGridViewTextBoxColumn.Name = "StartBillingDateDataGridViewTextBoxColumn"
            Me.StartBillingDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.StartBillingDateDataGridViewTextBoxColumn.Width = 84
            '
            'EndBillingDateDataGridViewTextBoxColumn
            '
            Me.EndBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.EndBillingDateDataGridViewTextBoxColumn.DataPropertyName = "EndBillingDate"
            DataGridViewCellStyle8.Format = "d"
            Me.EndBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
            Me.EndBillingDateDataGridViewTextBoxColumn.HeaderText = "End Billing"
            Me.EndBillingDateDataGridViewTextBoxColumn.Name = "EndBillingDateDataGridViewTextBoxColumn"
            Me.EndBillingDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.EndBillingDateDataGridViewTextBoxColumn.Width = 81
            '
            'TotalDataGridViewTextBoxColumn
            '
            Me.TotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
            DataGridViewCellStyle9.Format = "C2"
            Me.TotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
            Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
            Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
            Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
            Me.TotalDataGridViewTextBoxColumn.Width = 56
            '
            'pnl_LeftBot
            '
            Me.pnl_LeftBot.Controls.Add(Me.lbl_InvBatchCust)
            Me.pnl_LeftBot.Controls.Add(Me.Label1)
            Me.pnl_LeftBot.Controls.Add(Me.lbl_InvBatchCount)
            Me.pnl_LeftBot.Controls.Add(Me.pb_Invoices)
            Me.pnl_LeftBot.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnl_LeftBot.Location = New System.Drawing.Point(3, 425)
            Me.pnl_LeftBot.Name = "pnl_LeftBot"
            Me.pnl_LeftBot.Size = New System.Drawing.Size(610, 39)
            Me.pnl_LeftBot.TabIndex = 1
            Me.pnl_LeftBot.Visible = False
            '
            'lbl_InvBatchCust
            '
            Me.lbl_InvBatchCust.AutoSize = True
            Me.lbl_InvBatchCust.Location = New System.Drawing.Point(56, 1)
            Me.lbl_InvBatchCust.Name = "lbl_InvBatchCust"
            Me.lbl_InvBatchCust.Size = New System.Drawing.Size(0, 13)
            Me.lbl_InvBatchCust.TabIndex = 3
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 1)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(54, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Customer:"
            '
            'lbl_InvBatchCount
            '
            Me.lbl_InvBatchCount.Location = New System.Drawing.Point(519, 3)
            Me.lbl_InvBatchCount.Name = "lbl_InvBatchCount"
            Me.lbl_InvBatchCount.Size = New System.Drawing.Size(87, 13)
            Me.lbl_InvBatchCount.TabIndex = 1
            Me.lbl_InvBatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pb_Invoices
            '
            Me.pb_Invoices.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pb_Invoices.Location = New System.Drawing.Point(0, 16)
            Me.pb_Invoices.Name = "pb_Invoices"
            Me.pb_Invoices.Size = New System.Drawing.Size(610, 23)
            Me.pb_Invoices.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.pb_Invoices.TabIndex = 0
            '
            'pnl_Top
            '
            Me.pnl_Top.Controls.Add(Me.pnl_TopContent)
            Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_Top.Location = New System.Drawing.Point(3, 3)
            Me.pnl_Top.Margin = New System.Windows.Forms.Padding(10)
            Me.pnl_Top.Name = "pnl_Top"
            Me.pnl_Top.Padding = New System.Windows.Forms.Padding(100, 10, 100, 10)
            Me.pnl_Top.Size = New System.Drawing.Size(1020, 114)
            Me.pnl_Top.TabIndex = 4
            '
            'pnl_TopContent
            '
            Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TopContent.Controls.Add(Me.btn_DeleteAllWrkInv)
            Me.pnl_TopContent.Controls.Add(Me.btn_GenerateInv)
            Me.pnl_TopContent.Controls.Add(Me.Label2)
            Me.pnl_TopContent.Controls.Add(Me.dtp_GenInvTo)
            Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_TopContent.Location = New System.Drawing.Point(100, 10)
            Me.pnl_TopContent.Name = "pnl_TopContent"
            Me.pnl_TopContent.Padding = New System.Windows.Forms.Padding(3)
            Me.pnl_TopContent.Size = New System.Drawing.Size(820, 94)
            Me.pnl_TopContent.TabIndex = 0
            '
            'btn_DeleteAllWrkInv
            '
            Me.btn_DeleteAllWrkInv.AutoSize = True
            Me.btn_DeleteAllWrkInv.Location = New System.Drawing.Point(558, 61)
            Me.btn_DeleteAllWrkInv.Name = "btn_DeleteAllWrkInv"
            Me.btn_DeleteAllWrkInv.Size = New System.Drawing.Size(151, 23)
            Me.btn_DeleteAllWrkInv.TabIndex = 3
            Me.btn_DeleteAllWrkInv.Text = "Delete All Prepared Invoices"
            Me.btn_DeleteAllWrkInv.UseVisualStyleBackColor = True
            Me.btn_DeleteAllWrkInv.Visible = False
            '
            'btn_GenerateInv
            '
            Me.btn_GenerateInv.AutoSize = True
            Me.btn_GenerateInv.Location = New System.Drawing.Point(452, 61)
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
            Me.Label2.Size = New System.Drawing.Size(812, 59)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = resources.GetString("Label2.Text")
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'dtp_GenInvTo
            '
            Me.dtp_GenInvTo.Location = New System.Drawing.Point(228, 63)
            Me.dtp_GenInvTo.Name = "dtp_GenInvTo"
            Me.dtp_GenInvTo.Size = New System.Drawing.Size(200, 20)
            Me.dtp_GenInvTo.TabIndex = 0
            '
            'tp_Pay
            '
            Me.tp_Pay.BackColor = System.Drawing.SystemColors.Control
            Me.tp_Pay.Controls.Add(Me.pnl_PayRight)
            Me.tp_Pay.Controls.Add(Me.grp_ModPayInfo)
            Me.tp_Pay.Location = New System.Drawing.Point(4, 22)
            Me.tp_Pay.Name = "tp_Pay"
            Me.tp_Pay.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_Pay.Size = New System.Drawing.Size(1026, 587)
            Me.tp_Pay.TabIndex = 1
            Me.tp_Pay.Text = "Payments"
            '
            'pnl_PayRight
            '
            Me.pnl_PayRight.Controls.Add(Me.lbl_TotalCash)
            Me.pnl_PayRight.Controls.Add(Me.lbl_TotalMoneyOrder)
            Me.pnl_PayRight.Controls.Add(Me.lbl_TotalCheck)
            Me.pnl_PayRight.Controls.Add(Me.tb_TotalMoneyOrder)
            Me.pnl_PayRight.Controls.Add(Me.tb_TotalCheck)
            Me.pnl_PayRight.Controls.Add(Me.tb_TotalCash)
            Me.pnl_PayRight.Controls.Add(Me.Label3)
            Me.pnl_PayRight.Controls.Add(Me.pb_Payments)
            Me.pnl_PayRight.Controls.Add(Me.lbl_PayBatchCount)
            Me.pnl_PayRight.Controls.Add(Me.lbl_PayBatchCust)
            Me.pnl_PayRight.Controls.Add(Me.dg_PrepPay)
            Me.pnl_PayRight.Controls.Add(Me.btn_PayBatch)
            Me.pnl_PayRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnl_PayRight.Location = New System.Drawing.Point(402, 3)
            Me.pnl_PayRight.Name = "pnl_PayRight"
            Me.pnl_PayRight.Size = New System.Drawing.Size(621, 581)
            Me.pnl_PayRight.TabIndex = 120
            '
            'lbl_TotalCash
            '
            Me.lbl_TotalCash.AutoSize = True
            Me.lbl_TotalCash.Location = New System.Drawing.Point(80, 474)
            Me.lbl_TotalCash.Name = "lbl_TotalCash"
            Me.lbl_TotalCash.Size = New System.Drawing.Size(58, 13)
            Me.lbl_TotalCash.TabIndex = 128
            Me.lbl_TotalCash.Text = "Total Cash"
            '
            'lbl_TotalMoneyOrder
            '
            Me.lbl_TotalMoneyOrder.AutoSize = True
            Me.lbl_TotalMoneyOrder.Location = New System.Drawing.Point(457, 474)
            Me.lbl_TotalMoneyOrder.Name = "lbl_TotalMoneyOrder"
            Me.lbl_TotalMoneyOrder.Size = New System.Drawing.Size(95, 13)
            Me.lbl_TotalMoneyOrder.TabIndex = 127
            Me.lbl_TotalMoneyOrder.Text = "Total Money Order"
            '
            'lbl_TotalCheck
            '
            Me.lbl_TotalCheck.AutoSize = True
            Me.lbl_TotalCheck.Location = New System.Drawing.Point(276, 474)
            Me.lbl_TotalCheck.Name = "lbl_TotalCheck"
            Me.lbl_TotalCheck.Size = New System.Drawing.Size(70, 13)
            Me.lbl_TotalCheck.TabIndex = 126
            Me.lbl_TotalCheck.Text = "Total Checks"
            '
            'tb_TotalMoneyOrder
            '
            Me.tb_TotalMoneyOrder.Location = New System.Drawing.Point(455, 451)
            Me.tb_TotalMoneyOrder.Name = "tb_TotalMoneyOrder"
            Me.tb_TotalMoneyOrder.Size = New System.Drawing.Size(100, 20)
            Me.tb_TotalMoneyOrder.TabIndex = 124
            '
            'tb_TotalCheck
            '
            Me.tb_TotalCheck.Location = New System.Drawing.Point(260, 451)
            Me.tb_TotalCheck.Name = "tb_TotalCheck"
            Me.tb_TotalCheck.Size = New System.Drawing.Size(100, 20)
            Me.tb_TotalCheck.TabIndex = 123
            '
            'tb_TotalCash
            '
            Me.tb_TotalCash.Location = New System.Drawing.Point(60, 451)
            Me.tb_TotalCash.Name = "tb_TotalCash"
            Me.tb_TotalCash.Size = New System.Drawing.Size(100, 20)
            Me.tb_TotalCash.TabIndex = 122
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 542)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(54, 13)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "Customer:"
            '
            'pb_Payments
            '
            Me.pb_Payments.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pb_Payments.Location = New System.Drawing.Point(0, 558)
            Me.pb_Payments.Name = "pb_Payments"
            Me.pb_Payments.Size = New System.Drawing.Size(621, 23)
            Me.pb_Payments.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.pb_Payments.TabIndex = 121
            '
            'lbl_PayBatchCount
            '
            Me.lbl_PayBatchCount.Location = New System.Drawing.Point(496, 542)
            Me.lbl_PayBatchCount.Name = "lbl_PayBatchCount"
            Me.lbl_PayBatchCount.Size = New System.Drawing.Size(120, 13)
            Me.lbl_PayBatchCount.TabIndex = 4
            Me.lbl_PayBatchCount.Text = "100/100"
            Me.lbl_PayBatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lbl_PayBatchCust
            '
            Me.lbl_PayBatchCust.AutoSize = True
            Me.lbl_PayBatchCust.Location = New System.Drawing.Point(57, 542)
            Me.lbl_PayBatchCust.Name = "lbl_PayBatchCust"
            Me.lbl_PayBatchCust.Size = New System.Drawing.Size(52, 13)
            Me.lbl_PayBatchCust.TabIndex = 6
            Me.lbl_PayBatchCust.Text = "fife abbyy"
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
            Me.dg_PrepPay.Location = New System.Drawing.Point(0, 0)
            Me.dg_PrepPay.Name = "dg_PrepPay"
            Me.dg_PrepPay.ReadOnly = True
            Me.dg_PrepPay.RowHeadersVisible = False
            Me.dg_PrepPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PrepPay.Size = New System.Drawing.Size(621, 445)
            Me.dg_PrepPay.TabIndex = 120
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
            Me.Ds_Types.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'WorkingPaymentsAmountDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
            DataGridViewCellStyle10.Format = "C2"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
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
            Me.btn_PayBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.btn_PayBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_PayBatch.Location = New System.Drawing.Point(225, 494)
            Me.btn_PayBatch.Name = "btn_PayBatch"
            Me.btn_PayBatch.Size = New System.Drawing.Size(172, 45)
            Me.btn_PayBatch.TabIndex = 2
            Me.btn_PayBatch.Text = "Batch Payments"
            Me.btn_PayBatch.UseVisualStyleBackColor = True
            Me.btn_PayBatch.Visible = False
            '
            'grp_ModPayInfo
            '
            Me.grp_ModPayInfo.Controls.Add(Me.btn_CancelPayMod)
            Me.grp_ModPayInfo.Controls.Add(Me.lbl_PayType)
            Me.grp_ModPayInfo.Controls.Add(Me.cmb_PayTypes)
            Me.grp_ModPayInfo.Controls.Add(Me.Label4)
            Me.grp_ModPayInfo.Controls.Add(Me.tb_Amount)
            Me.grp_ModPayInfo.Controls.Add(Me.lbl_RefNumber)
            Me.grp_ModPayInfo.Controls.Add(Me.btn_SavePayment)
            Me.grp_ModPayInfo.Controls.Add(Me.lbl_DateOnCheck)
            Me.grp_ModPayInfo.Controls.Add(Me.dtp_DateOnCheck)
            Me.grp_ModPayInfo.Controls.Add(Me.tb_RefNum)
            Me.grp_ModPayInfo.Location = New System.Drawing.Point(63, 54)
            Me.grp_ModPayInfo.Name = "grp_ModPayInfo"
            Me.grp_ModPayInfo.Size = New System.Drawing.Size(236, 209)
            Me.grp_ModPayInfo.TabIndex = 117
            Me.grp_ModPayInfo.TabStop = False
            Me.grp_ModPayInfo.Text = "Modify Payment Information"
            Me.grp_ModPayInfo.Visible = False
            '
            'btn_CancelPayMod
            '
            Me.btn_CancelPayMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_CancelPayMod.ForeColor = System.Drawing.Color.Red
            Me.btn_CancelPayMod.Location = New System.Drawing.Point(26, 177)
            Me.btn_CancelPayMod.Name = "btn_CancelPayMod"
            Me.btn_CancelPayMod.Size = New System.Drawing.Size(187, 23)
            Me.btn_CancelPayMod.TabIndex = 115
            Me.btn_CancelPayMod.Text = "Cancel"
            Me.btn_CancelPayMod.UseVisualStyleBackColor = True
            '
            'lbl_PayType
            '
            Me.lbl_PayType.AutoSize = True
            Me.lbl_PayType.Location = New System.Drawing.Point(28, 16)
            Me.lbl_PayType.Name = "lbl_PayType"
            Me.lbl_PayType.Size = New System.Drawing.Size(78, 13)
            Me.lbl_PayType.TabIndex = 100
            Me.lbl_PayType.Text = "Payment Type:"
            '
            'cmb_PayTypes
            '
            Me.cmb_PayTypes.DataSource = Me.PaymentTypesBindingSource
            Me.cmb_PayTypes.DisplayMember = "PaymentTypeName"
            Me.cmb_PayTypes.FormattingEnabled = True
            Me.cmb_PayTypes.Location = New System.Drawing.Point(26, 32)
            Me.cmb_PayTypes.Name = "cmb_PayTypes"
            Me.cmb_PayTypes.Size = New System.Drawing.Size(175, 21)
            Me.cmb_PayTypes.TabIndex = 0
            Me.cmb_PayTypes.ValueMember = "PaymentTypeID"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(52, 62)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(46, 13)
            Me.Label4.TabIndex = 112
            Me.Label4.Text = "Amount:"
            '
            'tb_Amount
            '
            Me.tb_Amount.Location = New System.Drawing.Point(101, 59)
            Me.tb_Amount.Name = "tb_Amount"
            Me.tb_Amount.Size = New System.Drawing.Size(100, 20)
            Me.tb_Amount.TabIndex = 1
            '
            'lbl_RefNumber
            '
            Me.lbl_RefNumber.AutoSize = True
            Me.lbl_RefNumber.Location = New System.Drawing.Point(28, 85)
            Me.lbl_RefNumber.Name = "lbl_RefNumber"
            Me.lbl_RefNumber.Size = New System.Drawing.Size(70, 13)
            Me.lbl_RefNumber.TabIndex = 113
            Me.lbl_RefNumber.Text = "Reference #:"
            Me.lbl_RefNumber.Visible = False
            '
            'btn_SavePayment
            '
            Me.btn_SavePayment.Location = New System.Drawing.Point(26, 134)
            Me.btn_SavePayment.Name = "btn_SavePayment"
            Me.btn_SavePayment.Size = New System.Drawing.Size(187, 23)
            Me.btn_SavePayment.TabIndex = 6
            Me.btn_SavePayment.Text = "Save Payment"
            Me.btn_SavePayment.UseVisualStyleBackColor = True
            '
            'lbl_DateOnCheck
            '
            Me.lbl_DateOnCheck.AutoSize = True
            Me.lbl_DateOnCheck.Location = New System.Drawing.Point(30, 112)
            Me.lbl_DateOnCheck.Name = "lbl_DateOnCheck"
            Me.lbl_DateOnCheck.Size = New System.Drawing.Size(81, 13)
            Me.lbl_DateOnCheck.TabIndex = 114
            Me.lbl_DateOnCheck.Text = "Date on check:"
            Me.lbl_DateOnCheck.Visible = False
            '
            'dtp_DateOnCheck
            '
            Me.dtp_DateOnCheck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_DateOnCheck.Location = New System.Drawing.Point(117, 108)
            Me.dtp_DateOnCheck.Name = "dtp_DateOnCheck"
            Me.dtp_DateOnCheck.Size = New System.Drawing.Size(84, 20)
            Me.dtp_DateOnCheck.TabIndex = 3
            Me.dtp_DateOnCheck.Visible = False
            '
            'tb_RefNum
            '
            Me.tb_RefNum.Location = New System.Drawing.Point(101, 82)
            Me.tb_RefNum.Name = "tb_RefNum"
            Me.tb_RefNum.Size = New System.Drawing.Size(100, 20)
            Me.tb_RefNum.TabIndex = 2
            Me.tb_RefNum.Visible = False
            '
            'PaymentTypesTableAdapter
            '
            Me.PaymentTypesTableAdapter.ClearBeforeFill = True
            '
            'BatchingPrep
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1034, 639)
            Me.Controls.Add(Me.tc_Master)
            Me.Controls.Add(Me.ToolStrip1)
            Me.Name = "BatchingPrep"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Batching Work"
            CType(Me.BATCHWorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DS_Batching, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cm_PayGrid.ResumeLayout(False)
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            Me.tc_Master.ResumeLayout(False)
            Me.tp_Inv.ResumeLayout(False)
            Me.pnl_Left.ResumeLayout(False)
            CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_LeftBot.ResumeLayout(False)
            Me.pnl_LeftBot.PerformLayout()
            Me.pnl_Top.ResumeLayout(False)
            Me.pnl_TopContent.ResumeLayout(False)
            Me.pnl_TopContent.PerformLayout()
            Me.tp_Pay.ResumeLayout(False)
            Me.pnl_PayRight.ResumeLayout(False)
            Me.pnl_PayRight.PerformLayout()
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_ModPayInfo.ResumeLayout(False)
            Me.grp_ModPayInfo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
        Friend WithEvents btn_Refresh As System.Windows.Forms.ToolStripButton
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
        Public WithEvents pnl_Left As System.Windows.Forms.Panel
        Friend WithEvents dg_PrepInv As System.Windows.Forms.DataGridView
        Friend WithEvents InvoiceToBePrintedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoicePostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StartBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EndBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Public WithEvents pnl_LeftBot As System.Windows.Forms.Panel
        Public WithEvents lbl_InvBatchCust As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Public WithEvents lbl_InvBatchCount As System.Windows.Forms.Label
        Public WithEvents pb_Invoices As System.Windows.Forms.ProgressBar
        Friend WithEvents pnl_Top As System.Windows.Forms.Panel
        Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
        Friend WithEvents btn_DeleteAllWrkInv As System.Windows.Forms.Button
        Friend WithEvents btn_GenerateInv As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dtp_GenInvTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents tp_Pay As System.Windows.Forms.TabPage
        Public WithEvents lbl_PayBatchCust As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Public WithEvents lbl_PayBatchCount As System.Windows.Forms.Label
        Friend WithEvents Ds_Types As TrashCash.ds_Types
        Friend WithEvents PaymentTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PaymentTypesTableAdapter As TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter
        Friend WithEvents pnl_PayRight As System.Windows.Forms.Panel
        Friend WithEvents lbl_TotalMoneyOrder As System.Windows.Forms.Label
        Friend WithEvents lbl_TotalCheck As System.Windows.Forms.Label

        Friend WithEvents tb_TotalMoneyOrder As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents tb_TotalCheck As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents tb_TotalCash As TrashCash.Classes.CurrencyTextBox
        Public WithEvents pb_Payments As System.Windows.Forms.ProgressBar
        Friend WithEvents dg_PrepPay As System.Windows.Forms.DataGridView
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsType As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsCheckNum As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btn_PayBatch As System.Windows.Forms.Button
        Friend WithEvents grp_ModPayInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lbl_PayType As System.Windows.Forms.Label
        Friend WithEvents cmb_PayTypes As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents tb_Amount As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents lbl_RefNumber As System.Windows.Forms.Label
        Friend WithEvents btn_SavePayment As System.Windows.Forms.Button
        Friend WithEvents lbl_DateOnCheck As System.Windows.Forms.Label
        Friend WithEvents dtp_DateOnCheck As System.Windows.Forms.DateTimePicker
        Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
        Friend WithEvents lbl_TotalCash As System.Windows.Forms.Label
        Friend WithEvents btn_ModPayment As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btn_CancelPayMod As System.Windows.Forms.Button
    End Class
End Namespace