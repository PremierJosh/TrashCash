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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchingPrep))
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnl_Left = New System.Windows.Forms.Panel()
            Me.dg_PrepInv = New System.Windows.Forms.DataGridView()
            Me.BATCHWorkingInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Batching = New TrashCash.ds_Batching()
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
            Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.BATCHWorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
            Me.BATCH_WorkingPaymentsTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter()
            Me.BATCH_WorkingInvoiceTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter()
            Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsCheckNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceToBePrintedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.CustomerFullNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoicePostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StartBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EndBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnl_Left.SuspendLayout()
            CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BATCHWorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Batching, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_LeftBot.SuspendLayout()
            Me.pnl_LeftTop.SuspendLayout()
            Me.pnl_Right.SuspendLayout()
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cm_PayGrid.SuspendLayout()
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.pnl_Left.Size = New System.Drawing.Size(616, 399)
            Me.pnl_Left.TabIndex = 0
            '
            'dg_PrepInv
            '
            Me.dg_PrepInv.AllowUserToAddRows = False
            Me.dg_PrepInv.AllowUserToDeleteRows = False
            Me.dg_PrepInv.AllowUserToResizeRows = False
            Me.dg_PrepInv.AutoGenerateColumns = False
            Me.dg_PrepInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_PrepInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceToBePrintedDataGridViewCheckBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn1, Me.InvoicePostDateDataGridViewTextBoxColumn, Me.StartBillingDateDataGridViewTextBoxColumn, Me.EndBillingDateDataGridViewTextBoxColumn, Me.TotalDataGridViewTextBoxColumn})
            Me.dg_PrepInv.DataSource = Me.BATCHWorkingInvoiceBindingSource
            Me.dg_PrepInv.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg_PrepInv.Location = New System.Drawing.Point(3, 30)
            Me.dg_PrepInv.MultiSelect = False
            Me.dg_PrepInv.Name = "dg_PrepInv"
            Me.dg_PrepInv.RowHeadersVisible = False
            Me.dg_PrepInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PrepInv.Size = New System.Drawing.Size(610, 327)
            Me.dg_PrepInv.TabIndex = 2
            '
            'BATCHWorkingInvoiceBindingSource
            '
            Me.BATCHWorkingInvoiceBindingSource.DataMember = "BATCH_WorkingInvoice"
            Me.BATCHWorkingInvoiceBindingSource.DataSource = Me.Ds_Batching
            '
            'Ds_Batching
            '
            Me.Ds_Batching.DataSetName = "ds_Batching"
            Me.Ds_Batching.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
            Me.pb_Invoices.Size = New System.Drawing.Size(610, 23)
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
            Me.pnl_LeftTop.Size = New System.Drawing.Size(610, 27)
            Me.pnl_LeftTop.TabIndex = 0
            '
            'btn_CancelInvBatch
            '
            Me.btn_CancelInvBatch.AutoSize = True
            Me.btn_CancelInvBatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.btn_CancelInvBatch.Dock = System.Windows.Forms.DockStyle.Right
            Me.btn_CancelInvBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_CancelInvBatch.ForeColor = System.Drawing.Color.Red
            Me.btn_CancelInvBatch.Location = New System.Drawing.Point(440, 2)
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
            Me.btn_InvBatch.Location = New System.Drawing.Point(520, 2)
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
            Me.pnl_Right.Location = New System.Drawing.Point(668, 140)
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
            Me.dg_PrepPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerFullNameDataGridViewTextBoxColumn, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNum})
            Me.dg_PrepPay.ContextMenuStrip = Me.cm_PayGrid
            Me.dg_PrepPay.DataSource = Me.BATCHWorkingPaymentsBindingSource
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
            'BATCHWorkingPaymentsBindingSource
            '
            Me.BATCHWorkingPaymentsBindingSource.DataMember = "BATCH_WorkingPayments"
            Me.BATCHWorkingPaymentsBindingSource.DataSource = Me.Ds_Batching
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
            Me.ToolStrip1.Size = New System.Drawing.Size(1098, 26)
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
            Me.pnl_Top.Size = New System.Drawing.Size(1098, 114)
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
            Me.pnl_TopContent.Size = New System.Drawing.Size(898, 94)
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
            Me.Label2.Size = New System.Drawing.Size(890, 59)
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
            'BATCH_WorkingPaymentsTableAdapter
            '
            Me.BATCH_WorkingPaymentsTableAdapter.ClearBeforeFill = True
            '
            'BATCH_WorkingInvoiceTableAdapter
            '
            Me.BATCH_WorkingInvoiceTableAdapter.ClearBeforeFill = True
            '
            'CustomerFullNameDataGridViewTextBoxColumn
            '
            Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
            Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Customer Name"
            Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
            Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
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
            'BatchingPrep
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1098, 539)
            Me.Controls.Add(Me.pnl_Right)
            Me.Controls.Add(Me.pnl_Left)
            Me.Controls.Add(Me.pnl_Top)
            Me.Controls.Add(Me.ToolStrip1)
            Me.Name = "BatchingPrep"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Batching Work"
            Me.pnl_Left.ResumeLayout(False)
            CType(Me.dg_PrepInv, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BATCHWorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Batching, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_LeftBot.ResumeLayout(False)
            Me.pnl_LeftBot.PerformLayout()
            Me.pnl_LeftTop.ResumeLayout(False)
            Me.pnl_LeftTop.PerformLayout()
            Me.pnl_Right.ResumeLayout(False)
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cm_PayGrid.ResumeLayout(False)
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents BatchWorker As System.ComponentModel.BackgroundWorker
        Friend WithEvents btn_CancelInvBatch As System.Windows.Forms.Button
        Friend WithEvents btn_CancelPayBatch As System.Windows.Forms.Button
        Friend WithEvents btn_DeleteAllWrkInv As System.Windows.Forms.Button
        Friend WithEvents cm_PayGrid As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents Ds_Batching As TrashCash.ds_Batching
        Friend WithEvents BATCHWorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BATCH_WorkingPaymentsTableAdapter As TrashCash.ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
        Friend WithEvents BATCHWorkingInvoiceBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BATCH_WorkingInvoiceTableAdapter As TrashCash.ds_BatchingTableAdapters.BATCH_WorkingInvoiceTableAdapter
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsCheckNum As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceToBePrintedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoicePostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StartBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EndBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace