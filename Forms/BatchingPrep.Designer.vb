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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchingPrep))
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Left = New System.Windows.Forms.Panel()
        Me.dg_PrepInv = New System.Windows.Forms.DataGridView()
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceDueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoicePostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.pnl_LeftBot = New System.Windows.Forms.Panel()
        Me.lbl_InvBatchCust = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_InvBatchCount = New System.Windows.Forms.Label()
        Me.pb_Invoices = New System.Windows.Forms.ProgressBar()
        Me.pnl_LeftTop = New System.Windows.Forms.Panel()
        Me.btn_CancelInvBatch = New System.Windows.Forms.Button()
        Me.btn_InvBatch = New System.Windows.Forms.Button()
        Me.lbl_InvHeader = New System.Windows.Forms.Label()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.dg_PrepPay = New System.Windows.Forms.DataGridView()
        Me.CustomerFullNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnl_RightBot = New System.Windows.Forms.Panel()
        Me.lbl_PayBatchCust = New System.Windows.Forms.Label()
        Me.pb_Payments = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_PayBatchCount = New System.Windows.Forms.Label()
        Me.pnl_RightTop = New System.Windows.Forms.Panel()
        Me.btn_CancelPayBatch = New System.Windows.Forms.Button()
        Me.btn_PayBatch = New System.Windows.Forms.Button()
        Me.lbl_PrepPayHeader = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_TopContent = New System.Windows.Forms.Panel()
        Me.btn_DeleteAllWrkInv = New System.Windows.Forms.Button()
        Me.btn_GenerateInv = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_GenInvTo = New System.Windows.Forms.DateTimePicker()
        Me.BatchWorker = New System.ComponentModel.BackgroundWorker()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsTableAdapter = New TrashCash.DataSetTableAdapters.WorkingPaymentsTableAdapter()
        Me.WorkingInvoiceTableAdapter = New TrashCash.DataSetTableAdapters.WorkingInvoiceTableAdapter()
        Me.pnl_Left.SuspendLayout()
        CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_LeftBot.SuspendLayout()
        Me.pnl_LeftTop.SuspendLayout()
        Me.pnl_Right.SuspendLayout()
        CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm_PayGrid.SuspendLayout()
        CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_RightBot.SuspendLayout()
        Me.pnl_RightTop.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnl_Top.SuspendLayout()
        Me.pnl_TopContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Left
        '
        Me.pnl_Left.Controls.Add(Me.dg_PrepInv)
        Me.pnl_Left.Controls.Add(Me.pnl_LeftBot)
        Me.pnl_Left.Controls.Add(Me.pnl_LeftTop)
        Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_Left.Location = New System.Drawing.Point(0, 140)
        Me.pnl_Left.Name = "pnl_Left"
        Me.pnl_Left.Padding = New System.Windows.Forms.Padding(3)
        Me.pnl_Left.Size = New System.Drawing.Size(555, 399)
        Me.pnl_Left.TabIndex = 0
        '
        'dg_PrepInv
        '
        Me.dg_PrepInv.AllowUserToAddRows = False
        Me.dg_PrepInv.AllowUserToDeleteRows = False
        Me.dg_PrepInv.AllowUserToResizeRows = False
        Me.dg_PrepInv.AutoGenerateColumns = False
        Me.dg_PrepInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_PrepInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceToBePrintedDataGridViewTextBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn, Me.InvoiceDueDateDataGridViewTextBoxColumn, Me.InvoicePostDateDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn})
        Me.dg_PrepInv.DataSource = Me.WorkingInvoiceBindingSource
        Me.dg_PrepInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_PrepInv.Location = New System.Drawing.Point(3, 30)
        Me.dg_PrepInv.MultiSelect = False
        Me.dg_PrepInv.Name = "dg_PrepInv"
        Me.dg_PrepInv.RowHeadersVisible = False
        Me.dg_PrepInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_PrepInv.Size = New System.Drawing.Size(549, 327)
        Me.dg_PrepInv.TabIndex = 2
        '
        'InvoiceToBePrintedDataGridViewTextBoxColumn
        '
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.DataPropertyName = "InvoiceToBePrinted"
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.FalseValue = "False"
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.HeaderText = "Printing"
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.Name = "InvoiceToBePrintedDataGridViewTextBoxColumn"
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.TrueValue = "True"
        Me.InvoiceToBePrintedDataGridViewTextBoxColumn.Width = 67
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InvoiceDueDateDataGridViewTextBoxColumn
        '
        Me.InvoiceDueDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InvoiceDueDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDueDate"
        DataGridViewCellStyle11.Format = "d"
        Me.InvoiceDueDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.InvoiceDueDateDataGridViewTextBoxColumn.HeaderText = "Due Date"
        Me.InvoiceDueDateDataGridViewTextBoxColumn.Name = "InvoiceDueDateDataGridViewTextBoxColumn"
        Me.InvoiceDueDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceDueDateDataGridViewTextBoxColumn.Width = 78
        '
        'InvoicePostDateDataGridViewTextBoxColumn
        '
        Me.InvoicePostDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InvoicePostDateDataGridViewTextBoxColumn.DataPropertyName = "InvoicePostDate"
        DataGridViewCellStyle12.Format = "d"
        Me.InvoicePostDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.InvoicePostDateDataGridViewTextBoxColumn.HeaderText = "Post Date"
        Me.InvoicePostDateDataGridViewTextBoxColumn.Name = "InvoicePostDateDataGridViewTextBoxColumn"
        Me.InvoicePostDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoicePostDateDataGridViewTextBoxColumn.Width = 79
        '
        'InvoiceTotalDataGridViewTextBoxColumn
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle13.Format = "C2"
        Me.InvoiceTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
        Me.InvoiceTotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceTotalDataGridViewTextBoxColumn.Width = 56
        '
        'WorkingInvoiceBindingSource
        '
        Me.WorkingInvoiceBindingSource.DataMember = "WorkingInvoice"
        Me.WorkingInvoiceBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.EnforceConstraints = False
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnl_LeftBot
        '
        Me.pnl_LeftBot.Controls.Add(Me.lbl_InvBatchCust)
        Me.pnl_LeftBot.Controls.Add(Me.Label1)
        Me.pnl_LeftBot.Controls.Add(Me.lbl_InvBatchCount)
        Me.pnl_LeftBot.Controls.Add(Me.pb_Invoices)
        Me.pnl_LeftBot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_LeftBot.Location = New System.Drawing.Point(3, 357)
        Me.pnl_LeftBot.Name = "pnl_LeftBot"
        Me.pnl_LeftBot.Size = New System.Drawing.Size(549, 39)
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
        Me.lbl_InvBatchCount.Location = New System.Drawing.Point(459, 3)
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
        Me.pb_Invoices.Size = New System.Drawing.Size(549, 23)
        Me.pb_Invoices.TabIndex = 0
        '
        'pnl_LeftTop
        '
        Me.pnl_LeftTop.Controls.Add(Me.btn_CancelInvBatch)
        Me.pnl_LeftTop.Controls.Add(Me.btn_InvBatch)
        Me.pnl_LeftTop.Controls.Add(Me.lbl_InvHeader)
        Me.pnl_LeftTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_LeftTop.Location = New System.Drawing.Point(3, 3)
        Me.pnl_LeftTop.Name = "pnl_LeftTop"
        Me.pnl_LeftTop.Padding = New System.Windows.Forms.Padding(2)
        Me.pnl_LeftTop.Size = New System.Drawing.Size(549, 27)
        Me.pnl_LeftTop.TabIndex = 0
        '
        'btn_CancelInvBatch
        '
        Me.btn_CancelInvBatch.AutoSize = True
        Me.btn_CancelInvBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_CancelInvBatch.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_CancelInvBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CancelInvBatch.ForeColor = System.Drawing.Color.Red
        Me.btn_CancelInvBatch.Location = New System.Drawing.Point(379, 2)
        Me.btn_CancelInvBatch.Name = "btn_CancelInvBatch"
        Me.btn_CancelInvBatch.Size = New System.Drawing.Size(80, 23)
        Me.btn_CancelInvBatch.TabIndex = 2
        Me.btn_CancelInvBatch.Text = "Stop Batch"
        Me.btn_CancelInvBatch.UseVisualStyleBackColor = True
        Me.btn_CancelInvBatch.Visible = False
        '
        'btn_InvBatch
        '
        Me.btn_InvBatch.AutoSize = True
        Me.btn_InvBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_InvBatch.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_InvBatch.Location = New System.Drawing.Point(459, 2)
        Me.btn_InvBatch.Name = "btn_InvBatch"
        Me.btn_InvBatch.Size = New System.Drawing.Size(88, 23)
        Me.btn_InvBatch.TabIndex = 1
        Me.btn_InvBatch.Text = "Batch Invoices"
        Me.btn_InvBatch.UseVisualStyleBackColor = True
        Me.btn_InvBatch.Visible = False
        '
        'lbl_InvHeader
        '
        Me.lbl_InvHeader.AutoSize = True
        Me.lbl_InvHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_InvHeader.Location = New System.Drawing.Point(5, 3)
        Me.lbl_InvHeader.Name = "lbl_InvHeader"
        Me.lbl_InvHeader.Size = New System.Drawing.Size(135, 16)
        Me.lbl_InvHeader.TabIndex = 0
        Me.lbl_InvHeader.Text = "Prepared Invoices"
        '
        'pnl_Right
        '
        Me.pnl_Right.Controls.Add(Me.dg_PrepPay)
        Me.pnl_Right.Controls.Add(Me.pnl_RightBot)
        Me.pnl_Right.Controls.Add(Me.pnl_RightTop)
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(597, 140)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Padding = New System.Windows.Forms.Padding(3)
        Me.pnl_Right.Size = New System.Drawing.Size(430, 399)
        Me.pnl_Right.TabIndex = 1
        '
        'dg_PrepPay
        '
        Me.dg_PrepPay.AllowUserToAddRows = False
        Me.dg_PrepPay.AllowUserToDeleteRows = False
        Me.dg_PrepPay.AllowUserToResizeRows = False
        Me.dg_PrepPay.AutoGenerateColumns = False
        Me.dg_PrepPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_PrepPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerFullNameDataGridViewTextBoxColumn1, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.WorkingPaymentsTypeDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn})
        Me.dg_PrepPay.ContextMenuStrip = Me.cm_PayGrid
        Me.dg_PrepPay.DataSource = Me.WorkingPaymentsBindingSource
        Me.dg_PrepPay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_PrepPay.Location = New System.Drawing.Point(3, 30)
        Me.dg_PrepPay.MultiSelect = False
        Me.dg_PrepPay.Name = "dg_PrepPay"
        Me.dg_PrepPay.ReadOnly = True
        Me.dg_PrepPay.RowHeadersVisible = False
        Me.dg_PrepPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_PrepPay.Size = New System.Drawing.Size(424, 327)
        Me.dg_PrepPay.TabIndex = 3
        '
        'CustomerFullNameDataGridViewTextBoxColumn1
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn1.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.CustomerFullNameDataGridViewTextBoxColumn1.Name = "CustomerFullNameDataGridViewTextBoxColumn1"
        Me.CustomerFullNameDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'WorkingPaymentsAmountDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
        DataGridViewCellStyle14.Format = "C2"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Name = "WorkingPaymentsAmountDataGridViewTextBoxColumn"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Width = 68
        '
        'WorkingPaymentsTypeDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.DataPropertyName = "PaymentTypeName"
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.HeaderText = "Method"
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.Name = "WorkingPaymentsTypeDataGridViewTextBoxColumn"
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.Width = 68
        '
        'WorkingPaymentsCheckNumDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsCheckNum"
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.HeaderText = "Check #"
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.Name = "WorkingPaymentsCheckNumDataGridViewTextBoxColumn"
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.ReadOnly = True
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.Width = 73
        '
        'cm_PayGrid
        '
        Me.cm_PayGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.cm_PayGrid.Name = "cm_PayGrid"
        Me.cm_PayGrid.Size = New System.Drawing.Size(205, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete Selected Payment"
        '
        'WorkingPaymentsBindingSource
        '
        Me.WorkingPaymentsBindingSource.DataMember = "WorkingPayments"
        Me.WorkingPaymentsBindingSource.DataSource = Me.DataSet
        '
        'pnl_RightBot
        '
        Me.pnl_RightBot.Controls.Add(Me.lbl_PayBatchCust)
        Me.pnl_RightBot.Controls.Add(Me.pb_Payments)
        Me.pnl_RightBot.Controls.Add(Me.Label3)
        Me.pnl_RightBot.Controls.Add(Me.lbl_PayBatchCount)
        Me.pnl_RightBot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_RightBot.Location = New System.Drawing.Point(3, 357)
        Me.pnl_RightBot.Name = "pnl_RightBot"
        Me.pnl_RightBot.Size = New System.Drawing.Size(424, 39)
        Me.pnl_RightBot.TabIndex = 2
        Me.pnl_RightBot.Visible = False
        '
        'lbl_PayBatchCust
        '
        Me.lbl_PayBatchCust.AutoSize = True
        Me.lbl_PayBatchCust.Location = New System.Drawing.Point(56, 1)
        Me.lbl_PayBatchCust.Name = "lbl_PayBatchCust"
        Me.lbl_PayBatchCust.Size = New System.Drawing.Size(0, 13)
        Me.lbl_PayBatchCust.TabIndex = 6
        '
        'pb_Payments
        '
        Me.pb_Payments.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pb_Payments.Location = New System.Drawing.Point(0, 16)
        Me.pb_Payments.Name = "pb_Payments"
        Me.pb_Payments.Size = New System.Drawing.Size(424, 23)
        Me.pb_Payments.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Customer:"
        '
        'lbl_PayBatchCount
        '
        Me.lbl_PayBatchCount.Location = New System.Drawing.Point(302, 0)
        Me.lbl_PayBatchCount.Name = "lbl_PayBatchCount"
        Me.lbl_PayBatchCount.Size = New System.Drawing.Size(120, 13)
        Me.lbl_PayBatchCount.TabIndex = 4
        Me.lbl_PayBatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnl_RightTop
        '
        Me.pnl_RightTop.Controls.Add(Me.btn_CancelPayBatch)
        Me.pnl_RightTop.Controls.Add(Me.btn_PayBatch)
        Me.pnl_RightTop.Controls.Add(Me.lbl_PrepPayHeader)
        Me.pnl_RightTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_RightTop.Location = New System.Drawing.Point(3, 3)
        Me.pnl_RightTop.Name = "pnl_RightTop"
        Me.pnl_RightTop.Padding = New System.Windows.Forms.Padding(2)
        Me.pnl_RightTop.Size = New System.Drawing.Size(424, 27)
        Me.pnl_RightTop.TabIndex = 1
        '
        'btn_CancelPayBatch
        '
        Me.btn_CancelPayBatch.AutoSize = True
        Me.btn_CancelPayBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_CancelPayBatch.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_CancelPayBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CancelPayBatch.ForeColor = System.Drawing.Color.Red
        Me.btn_CancelPayBatch.Location = New System.Drawing.Point(248, 2)
        Me.btn_CancelPayBatch.Name = "btn_CancelPayBatch"
        Me.btn_CancelPayBatch.Size = New System.Drawing.Size(80, 23)
        Me.btn_CancelPayBatch.TabIndex = 3
        Me.btn_CancelPayBatch.Text = "Stop Batch"
        Me.btn_CancelPayBatch.UseVisualStyleBackColor = True
        Me.btn_CancelPayBatch.Visible = False
        '
        'btn_PayBatch
        '
        Me.btn_PayBatch.AutoSize = True
        Me.btn_PayBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_PayBatch.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_PayBatch.Location = New System.Drawing.Point(328, 2)
        Me.btn_PayBatch.Name = "btn_PayBatch"
        Me.btn_PayBatch.Size = New System.Drawing.Size(94, 23)
        Me.btn_PayBatch.TabIndex = 2
        Me.btn_PayBatch.Text = "Batch Payments"
        Me.btn_PayBatch.UseVisualStyleBackColor = True
        Me.btn_PayBatch.Visible = False
        '
        'lbl_PrepPayHeader
        '
        Me.lbl_PrepPayHeader.AutoSize = True
        Me.lbl_PrepPayHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrepPayHeader.Location = New System.Drawing.Point(5, 4)
        Me.lbl_PrepPayHeader.Name = "lbl_PrepPayHeader"
        Me.lbl_PrepPayHeader.Size = New System.Drawing.Size(145, 16)
        Me.lbl_PrepPayHeader.TabIndex = 1
        Me.lbl_PrepPayHeader.Text = "Prepared Payments"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Refresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1027, 26)
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
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.pnl_TopContent)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 26)
        Me.pnl_Top.Margin = New System.Windows.Forms.Padding(10)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Padding = New System.Windows.Forms.Padding(100, 10, 100, 10)
        Me.pnl_Top.Size = New System.Drawing.Size(1027, 114)
        Me.pnl_Top.TabIndex = 3
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
        Me.pnl_TopContent.Size = New System.Drawing.Size(827, 94)
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
        Me.Label2.Size = New System.Drawing.Size(819, 59)
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
        'BatchWorker
        '
        Me.BatchWorker.WorkerReportsProgress = True
        Me.BatchWorker.WorkerSupportsCancellation = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CustomerNumber"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Customer #"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CustomerFullName"
        DataGridViewCellStyle15.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "InvoiceDueDate"
        DataGridViewCellStyle16.Format = "d"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn3.HeaderText = "Due Date"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "InvoicePostDate"
        DataGridViewCellStyle17.Format = "d"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn4.HeaderText = "Post Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle18.Format = "C2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn5.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CustomerNumber"
        DataGridViewCellStyle19.Format = "C2"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewTextBoxColumn6.HeaderText = "Customer #"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CustomerFullName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "WorkingPaymentsAmount"
        DataGridViewCellStyle20.Format = "C2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "PaymentTypeName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Method"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "WorkingPaymentsCheckNum"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Check #"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'WorkingPaymentsTableAdapter
        '
        Me.WorkingPaymentsTableAdapter.ClearBeforeFill = True
        '
        'WorkingInvoiceTableAdapter
        '
        Me.WorkingInvoiceTableAdapter.ClearBeforeFill = True
        '
        'BatchingPrep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 539)
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.pnl_Left)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "BatchingPrep"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Batching Work"
        Me.pnl_Left.ResumeLayout(False)
        CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_LeftBot.ResumeLayout(False)
        Me.pnl_LeftBot.PerformLayout()
        Me.pnl_LeftTop.ResumeLayout(False)
        Me.pnl_LeftTop.PerformLayout()
        Me.pnl_Right.ResumeLayout(False)
        CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm_PayGrid.ResumeLayout(False)
        CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_RightBot.ResumeLayout(False)
        Me.pnl_RightBot.PerformLayout()
        Me.pnl_RightTop.ResumeLayout(False)
        Me.pnl_RightTop.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_TopContent.ResumeLayout(False)
        Me.pnl_TopContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg_PrepInv As System.Windows.Forms.DataGridView
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnl_LeftTop As System.Windows.Forms.Panel
    Friend WithEvents lbl_InvHeader As System.Windows.Forms.Label
    Friend WithEvents pnl_Right As System.Windows.Forms.Panel
    Friend WithEvents dg_PrepPay As System.Windows.Forms.DataGridView
    Friend WithEvents pnl_RightBot As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnl_RightTop As System.Windows.Forms.Panel
    Friend WithEvents lbl_PrepPayHeader As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_InvBatch As System.Windows.Forms.Button
    Friend WithEvents btn_PayBatch As System.Windows.Forms.Button
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
    Friend WithEvents btn_GenerateInv As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_GenInvTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Refresh As System.Windows.Forms.ToolStripButton
    Public WithEvents lbl_InvBatchCust As System.Windows.Forms.Label
    Public WithEvents lbl_InvBatchCount As System.Windows.Forms.Label
    Public WithEvents pb_Invoices As System.Windows.Forms.ProgressBar
    Public WithEvents lbl_PayBatchCust As System.Windows.Forms.Label
    Public WithEvents pb_Payments As System.Windows.Forms.ProgressBar
    Public WithEvents lbl_PayBatchCount As System.Windows.Forms.Label
    Public WithEvents pnl_Left As System.Windows.Forms.Panel
    Public WithEvents pnl_LeftBot As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsTableAdapter As TrashCash.DataSetTableAdapters.WorkingPaymentsTableAdapter
    Friend WithEvents WorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkingInvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkingInvoiceTableAdapter As TrashCash.DataSetTableAdapters.WorkingInvoiceTableAdapter
    Friend WithEvents BatchWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_CancelInvBatch As System.Windows.Forms.Button
    Friend WithEvents btn_CancelPayBatch As System.Windows.Forms.Button
    Friend WithEvents InvoiceToBePrintedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoicePostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsCheckNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_DeleteAllWrkInv As System.Windows.Forms.Button
    Friend WithEvents cm_PayGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
