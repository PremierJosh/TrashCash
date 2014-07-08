Imports TrashCash.Classes
Imports TrashCash.Customer

Namespace Payments

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PaymentsForm
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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.btn_DeletePay = New System.Windows.Forms.ToolStripMenuItem()
            Me.tc_Master = New System.Windows.Forms.TabControl()
            Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
            Me.UC_CustomerNotes = New TrashCash.Customer.UC_CustomerNotes()
            Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
            Me.UC_CustomerInfoBoxes = New TrashCash.Customer.UC_CustomerInfoBoxes()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.pnl_TopContent = New System.Windows.Forms.Panel()
            Me.CustomerToolstrip1 = New TrashCash.Classes.CustomerToolstrip.CustomerToolstrip()
            Me.pnl_Right = New System.Windows.Forms.Panel()
            Me.dg_PrepPay = New System.Windows.Forms.DataGridView()
            Me.CustomerFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsCheckNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BATCHWorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Batching = New TrashCash.ds_Batching()
            Me.lbl_PaysInQueue = New System.Windows.Forms.Label()
            Me.cmb_PayTypes = New System.Windows.Forms.ComboBox()
            Me.PaymentTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Types = New TrashCash.ds_Types()
            Me.PaymentTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter()
            Me.lbl_PayType = New System.Windows.Forms.Label()
            Me.dtp_Override = New System.Windows.Forms.DateTimePicker()
            Me.btn_AddPayment = New System.Windows.Forms.Button()
            Me.dtp_DateOnCheck = New System.Windows.Forms.DateTimePicker()
            Me.tb_RefNum = New System.Windows.Forms.TextBox()
            Me.lbl_DateOnCheck = New System.Windows.Forms.Label()
            Me.lbl_RefNumber = New System.Windows.Forms.Label()
            Me.tb_Amount = New TrashCash.Classes.CurrencyTextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BATCH_WorkingPaymentsTableAdapter = New TrashCash.ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter()
            Me.grp_PrevPayInfo = New System.Windows.Forms.GroupBox()
            Me.lbl_PrevPayInfo = New System.Windows.Forms.Label()
            Me.dtp_PrevDateOnCheck = New System.Windows.Forms.DateTimePicker()
            Me.tb_PrevRefNum = New System.Windows.Forms.TextBox()
            Me.lbl_PrevDateOnCheck = New System.Windows.Forms.Label()
            Me.lbl_PrevRefNum = New System.Windows.Forms.Label()
            Me.tb_PrevAmount = New TrashCash.Classes.CurrencyTextBox()
            Me.lbl_PrevAmount = New System.Windows.Forms.Label()
            Me.grp_NewPayInfo = New System.Windows.Forms.GroupBox()
            Me.ck_Backdate = New System.Windows.Forms.CheckBox()
            Me.cm_PayGrid.SuspendLayout()
            Me.tc_Master.SuspendLayout()
            Me.tc_p_CustNotes.SuspendLayout()
            Me.tc_p_CustInfo.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.pnl_TopContent.SuspendLayout()
            Me.pnl_Right.SuspendLayout()
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Batching, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_PrevPayInfo.SuspendLayout()
            Me.grp_NewPayInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'cm_PayGrid
            '
            Me.cm_PayGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_DeletePay})
            Me.cm_PayGrid.Name = "cm_PayGrid"
            Me.cm_PayGrid.Size = New System.Drawing.Size(205, 26)
            '
            'btn_DeletePay
            '
            Me.btn_DeletePay.Name = "btn_DeletePay"
            Me.btn_DeletePay.Size = New System.Drawing.Size(204, 22)
            Me.btn_DeletePay.Text = "Delete Selected Payment"
            '
            'tc_Master
            '
            Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
            Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
            Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.tc_Master.Location = New System.Drawing.Point(0, 267)
            Me.tc_Master.Name = "tc_Master"
            Me.tc_Master.SelectedIndex = 0
            Me.tc_Master.Size = New System.Drawing.Size(966, 205)
            Me.tc_Master.TabIndex = 95
            '
            'tc_p_CustNotes
            '
            Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
            Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
            Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_CustNotes.Size = New System.Drawing.Size(958, 179)
            Me.tc_p_CustNotes.TabIndex = 3
            Me.tc_p_CustNotes.Text = "Customer Notes"
            '
            'UC_CustomerNotes
            '
            Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
            Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
            Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
            Me.UC_CustomerNotes.Size = New System.Drawing.Size(952, 173)
            Me.UC_CustomerNotes.TabIndex = 0
            '
            'tc_p_CustInfo
            '
            Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
            Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
            Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_CustInfo.Size = New System.Drawing.Size(958, 179)
            Me.tc_p_CustInfo.TabIndex = 0
            Me.tc_p_CustInfo.Text = "Customer Information"
            '
            'UC_CustomerInfoBoxes
            '
            Me.UC_CustomerInfoBoxes.AllowUpdate = False
            Me.UC_CustomerInfoBoxes.CurrentCustomer = 0
            Me.UC_CustomerInfoBoxes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_CustomerInfoBoxes.IsUpdating = False
            Me.UC_CustomerInfoBoxes.Location = New System.Drawing.Point(3, 3)
            Me.UC_CustomerInfoBoxes.Name = "UC_CustomerInfoBoxes"
            Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(952, 173)
            Me.UC_CustomerInfoBoxes.TabIndex = 0
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.pnl_TopContent)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
            Me.Panel1.Size = New System.Drawing.Size(966, 53)
            Me.Panel1.TabIndex = 96
            '
            'pnl_TopContent
            '
            Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TopContent.Controls.Add(Me.CustomerToolstrip1)
            Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
            Me.pnl_TopContent.Name = "pnl_TopContent"
            Me.pnl_TopContent.Size = New System.Drawing.Size(926, 33)
            Me.pnl_TopContent.TabIndex = 2
            '
            'CustomerToolstrip1
            '
            Me.CustomerToolstrip1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CustomerToolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.CustomerToolstrip1.Location = New System.Drawing.Point(0, 0)
            Me.CustomerToolstrip1.Name = "CustomerToolstrip1"
            Me.CustomerToolstrip1.Size = New System.Drawing.Size(924, 31)
            Me.CustomerToolstrip1.TabIndex = 0
            Me.CustomerToolstrip1.Text = "CustomerToolstrip1"
            '
            'pnl_Right
            '
            Me.pnl_Right.Controls.Add(Me.dg_PrepPay)
            Me.pnl_Right.Controls.Add(Me.lbl_PaysInQueue)
            Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnl_Right.Location = New System.Drawing.Point(453, 53)
            Me.pnl_Right.Name = "pnl_Right"
            Me.pnl_Right.Size = New System.Drawing.Size(513, 214)
            Me.pnl_Right.TabIndex = 98
            '
            'dg_PrepPay
            '
            Me.dg_PrepPay.AllowUserToAddRows = False
            Me.dg_PrepPay.AllowUserToDeleteRows = False
            Me.dg_PrepPay.AllowUserToResizeRows = False
            Me.dg_PrepPay.AutoGenerateColumns = False
            Me.dg_PrepPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dg_PrepPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerFullName, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNum})
            Me.dg_PrepPay.ContextMenuStrip = Me.cm_PayGrid
            Me.dg_PrepPay.DataSource = Me.BATCHWorkingPaymentsBindingSource
            Me.dg_PrepPay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg_PrepPay.Location = New System.Drawing.Point(0, 21)
            Me.dg_PrepPay.MultiSelect = False
            Me.dg_PrepPay.Name = "dg_PrepPay"
            Me.dg_PrepPay.ReadOnly = True
            Me.dg_PrepPay.RowHeadersVisible = False
            Me.dg_PrepPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PrepPay.Size = New System.Drawing.Size(513, 193)
            Me.dg_PrepPay.TabIndex = 99
            '
            'CustomerFullName
            '
            Me.CustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.CustomerFullName.DataPropertyName = "CustomerFullName"
            Me.CustomerFullName.HeaderText = "Customer Name"
            Me.CustomerFullName.Name = "CustomerFullName"
            Me.CustomerFullName.ReadOnly = True
            '
            'WorkingPaymentsAmountDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
            DataGridViewCellStyle2.Format = "C2"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Name = "WorkingPaymentsAmountDataGridViewTextBoxColumn"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Width = 68
            '
            'WorkingPaymentsCheckNum
            '
            Me.WorkingPaymentsCheckNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.WorkingPaymentsCheckNum.DataPropertyName = "WorkingPaymentsCheckNum"
            Me.WorkingPaymentsCheckNum.HeaderText = "Check #"
            Me.WorkingPaymentsCheckNum.Name = "WorkingPaymentsCheckNum"
            Me.WorkingPaymentsCheckNum.ReadOnly = True
            Me.WorkingPaymentsCheckNum.Width = 73
            '
            'BATCHWorkingPaymentsBindingSource
            '
            Me.BATCHWorkingPaymentsBindingSource.DataMember = "BATCH_WorkingPayments"
            Me.BATCHWorkingPaymentsBindingSource.DataSource = Me.Ds_Batching
            '
            'Ds_Batching
            '
            Me.Ds_Batching.DataSetName = "ds_Batching"
            Me.Ds_Batching.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'lbl_PaysInQueue
            '
            Me.lbl_PaysInQueue.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_PaysInQueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl_PaysInQueue.Location = New System.Drawing.Point(0, 0)
            Me.lbl_PaysInQueue.Name = "lbl_PaysInQueue"
            Me.lbl_PaysInQueue.Size = New System.Drawing.Size(513, 21)
            Me.lbl_PaysInQueue.TabIndex = 98
            Me.lbl_PaysInQueue.Text = "Payments in Queue"
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
            'PaymentTypesBindingSource
            '
            Me.PaymentTypesBindingSource.DataMember = "PaymentTypes"
            Me.PaymentTypesBindingSource.DataSource = Me.Ds_Types
            '
            'Ds_Types
            '
            Me.Ds_Types.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'PaymentTypesTableAdapter
            '
            Me.PaymentTypesTableAdapter.ClearBeforeFill = True
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
            'dtp_Override
            '
            Me.dtp_Override.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_Override.Location = New System.Drawing.Point(117, 134)
            Me.dtp_Override.Name = "dtp_Override"
            Me.dtp_Override.Size = New System.Drawing.Size(84, 20)
            Me.dtp_Override.TabIndex = 5
            Me.dtp_Override.Visible = False
            '
            'btn_AddPayment
            '
            Me.btn_AddPayment.Location = New System.Drawing.Point(26, 164)
            Me.btn_AddPayment.Name = "btn_AddPayment"
            Me.btn_AddPayment.Size = New System.Drawing.Size(187, 23)
            Me.btn_AddPayment.TabIndex = 6
            Me.btn_AddPayment.Text = "Add Payment"
            Me.btn_AddPayment.UseVisualStyleBackColor = True
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
            'tb_Amount
            '
            Me.tb_Amount.Location = New System.Drawing.Point(101, 59)
            Me.tb_Amount.Name = "tb_Amount"
            Me.tb_Amount.Size = New System.Drawing.Size(100, 20)
            Me.tb_Amount.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(52, 62)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(46, 13)
            Me.Label1.TabIndex = 112
            Me.Label1.Text = "Amount:"
            '
            'BATCH_WorkingPaymentsTableAdapter
            '
            Me.BATCH_WorkingPaymentsTableAdapter.ClearBeforeFill = True
            '
            'grp_PrevPayInfo
            '
            Me.grp_PrevPayInfo.Controls.Add(Me.lbl_PrevPayInfo)
            Me.grp_PrevPayInfo.Controls.Add(Me.dtp_PrevDateOnCheck)
            Me.grp_PrevPayInfo.Controls.Add(Me.tb_PrevRefNum)
            Me.grp_PrevPayInfo.Controls.Add(Me.lbl_PrevDateOnCheck)
            Me.grp_PrevPayInfo.Controls.Add(Me.lbl_PrevRefNum)
            Me.grp_PrevPayInfo.Controls.Add(Me.tb_PrevAmount)
            Me.grp_PrevPayInfo.Controls.Add(Me.lbl_PrevAmount)
            Me.grp_PrevPayInfo.Location = New System.Drawing.Point(254, 148)
            Me.grp_PrevPayInfo.Name = "grp_PrevPayInfo"
            Me.grp_PrevPayInfo.Size = New System.Drawing.Size(193, 119)
            Me.grp_PrevPayInfo.TabIndex = 115
            Me.grp_PrevPayInfo.TabStop = False
            Me.grp_PrevPayInfo.Text = "Last Batched Payment"
            '
            'lbl_PrevPayInfo
            '
            Me.lbl_PrevPayInfo.Location = New System.Drawing.Point(14, 14)
            Me.lbl_PrevPayInfo.Name = "lbl_PrevPayInfo"
            Me.lbl_PrevPayInfo.Size = New System.Drawing.Size(168, 30)
            Me.lbl_PrevPayInfo.TabIndex = 121
            Me.lbl_PrevPayInfo.Text = "Received on: 12/31/14" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "by Premier"
            Me.lbl_PrevPayInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dtp_PrevDateOnCheck
            '
            Me.dtp_PrevDateOnCheck.Enabled = False
            Me.dtp_PrevDateOnCheck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_PrevDateOnCheck.Location = New System.Drawing.Point(98, 95)
            Me.dtp_PrevDateOnCheck.Name = "dtp_PrevDateOnCheck"
            Me.dtp_PrevDateOnCheck.Size = New System.Drawing.Size(84, 20)
            Me.dtp_PrevDateOnCheck.TabIndex = 117
            Me.dtp_PrevDateOnCheck.Visible = False
            '
            'tb_PrevRefNum
            '
            Me.tb_PrevRefNum.Enabled = False
            Me.tb_PrevRefNum.Location = New System.Drawing.Point(82, 69)
            Me.tb_PrevRefNum.Name = "tb_PrevRefNum"
            Me.tb_PrevRefNum.Size = New System.Drawing.Size(100, 20)
            Me.tb_PrevRefNum.TabIndex = 116
            Me.tb_PrevRefNum.Visible = False
            '
            'lbl_PrevDateOnCheck
            '
            Me.lbl_PrevDateOnCheck.AutoSize = True
            Me.lbl_PrevDateOnCheck.Enabled = False
            Me.lbl_PrevDateOnCheck.Location = New System.Drawing.Point(11, 99)
            Me.lbl_PrevDateOnCheck.Name = "lbl_PrevDateOnCheck"
            Me.lbl_PrevDateOnCheck.Size = New System.Drawing.Size(81, 13)
            Me.lbl_PrevDateOnCheck.TabIndex = 120
            Me.lbl_PrevDateOnCheck.Text = "Date on check:"
            Me.lbl_PrevDateOnCheck.Visible = False
            '
            'lbl_PrevRefNum
            '
            Me.lbl_PrevRefNum.AutoSize = True
            Me.lbl_PrevRefNum.Enabled = False
            Me.lbl_PrevRefNum.Location = New System.Drawing.Point(9, 72)
            Me.lbl_PrevRefNum.Name = "lbl_PrevRefNum"
            Me.lbl_PrevRefNum.Size = New System.Drawing.Size(70, 13)
            Me.lbl_PrevRefNum.TabIndex = 119
            Me.lbl_PrevRefNum.Text = "Reference #:"
            Me.lbl_PrevRefNum.Visible = False
            '
            'tb_PrevAmount
            '
            Me.tb_PrevAmount.Enabled = False
            Me.tb_PrevAmount.Location = New System.Drawing.Point(82, 46)
            Me.tb_PrevAmount.Name = "tb_PrevAmount"
            Me.tb_PrevAmount.Size = New System.Drawing.Size(100, 20)
            Me.tb_PrevAmount.TabIndex = 115
            '
            'lbl_PrevAmount
            '
            Me.lbl_PrevAmount.AutoSize = True
            Me.lbl_PrevAmount.Enabled = False
            Me.lbl_PrevAmount.Location = New System.Drawing.Point(33, 49)
            Me.lbl_PrevAmount.Name = "lbl_PrevAmount"
            Me.lbl_PrevAmount.Size = New System.Drawing.Size(46, 13)
            Me.lbl_PrevAmount.TabIndex = 118
            Me.lbl_PrevAmount.Text = "Amount:"
            '
            'grp_NewPayInfo
            '
            Me.grp_NewPayInfo.Controls.Add(Me.ck_Backdate)
            Me.grp_NewPayInfo.Controls.Add(Me.lbl_PayType)
            Me.grp_NewPayInfo.Controls.Add(Me.cmb_PayTypes)
            Me.grp_NewPayInfo.Controls.Add(Me.Label1)
            Me.grp_NewPayInfo.Controls.Add(Me.dtp_Override)
            Me.grp_NewPayInfo.Controls.Add(Me.tb_Amount)
            Me.grp_NewPayInfo.Controls.Add(Me.lbl_RefNumber)
            Me.grp_NewPayInfo.Controls.Add(Me.btn_AddPayment)
            Me.grp_NewPayInfo.Controls.Add(Me.lbl_DateOnCheck)
            Me.grp_NewPayInfo.Controls.Add(Me.dtp_DateOnCheck)
            Me.grp_NewPayInfo.Controls.Add(Me.tb_RefNum)
            Me.grp_NewPayInfo.Location = New System.Drawing.Point(12, 61)
            Me.grp_NewPayInfo.Name = "grp_NewPayInfo"
            Me.grp_NewPayInfo.Size = New System.Drawing.Size(236, 202)
            Me.grp_NewPayInfo.TabIndex = 116
            Me.grp_NewPayInfo.TabStop = False
            Me.grp_NewPayInfo.Text = "New Payment Information"
            '
            'ck_Backdate
            '
            Me.ck_Backdate.AutoSize = True
            Me.ck_Backdate.Location = New System.Drawing.Point(30, 136)
            Me.ck_Backdate.Name = "ck_Backdate"
            Me.ck_Backdate.Size = New System.Drawing.Size(72, 17)
            Me.ck_Backdate.TabIndex = 117
            Me.ck_Backdate.Text = "Backdate"
            Me.ck_Backdate.UseVisualStyleBackColor = True
            '
            'PaymentsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(966, 472)
            Me.Controls.Add(Me.grp_NewPayInfo)
            Me.Controls.Add(Me.grp_PrevPayInfo)
            Me.Controls.Add(Me.pnl_Right)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.tc_Master)
            Me.MaximizeBox = False
            Me.Name = "PaymentsForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Payments"
            Me.cm_PayGrid.ResumeLayout(False)
            Me.tc_Master.ResumeLayout(False)
            Me.tc_p_CustNotes.ResumeLayout(False)
            Me.tc_p_CustInfo.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.pnl_TopContent.ResumeLayout(False)
            Me.pnl_TopContent.PerformLayout()
            Me.pnl_Right.ResumeLayout(False)
            CType(Me.dg_PrepPay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BATCHWorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Batching, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_PrevPayInfo.ResumeLayout(False)
            Me.grp_PrevPayInfo.PerformLayout()
            Me.grp_NewPayInfo.ResumeLayout(False)
            Me.grp_NewPayInfo.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents tc_Master As System.Windows.Forms.TabControl
        Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
        Friend WithEvents UC_CustomerNotes As UC_CustomerNotes
        Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
        Friend WithEvents UC_CustomerInfoBoxes As UC_CustomerInfoBoxes
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaymentTypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cm_PayGrid As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents btn_DeletePay As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
        Friend WithEvents CustomerToolstrip1 As TrashCash.Classes.CustomerToolstrip.CustomerToolstrip
        Friend WithEvents pnl_Right As System.Windows.Forms.Panel
        Friend WithEvents lbl_PaysInQueue As System.Windows.Forms.Label
        Friend WithEvents cmb_PayTypes As System.Windows.Forms.ComboBox
        Friend WithEvents Ds_Types As TrashCash.ds_Types
        Friend WithEvents PaymentTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PaymentTypesTableAdapter As TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter
        Friend WithEvents lbl_PayType As System.Windows.Forms.Label
        Friend WithEvents dtp_Override As System.Windows.Forms.DateTimePicker
        Friend WithEvents btn_AddPayment As System.Windows.Forms.Button
        Friend WithEvents dtp_DateOnCheck As System.Windows.Forms.DateTimePicker
        Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
        Friend WithEvents lbl_DateOnCheck As System.Windows.Forms.Label
        Friend WithEvents lbl_RefNumber As System.Windows.Forms.Label
        Friend WithEvents tb_Amount As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Ds_Batching As TrashCash.ds_Batching
        Friend WithEvents BATCHWorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents BATCH_WorkingPaymentsTableAdapter As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter
        Friend WithEvents dg_PrepPay As System.Windows.Forms.DataGridView
        Friend WithEvents CustomerFullName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsCheckNum As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents grp_PrevPayInfo As System.Windows.Forms.GroupBox
        Friend WithEvents dtp_PrevDateOnCheck As System.Windows.Forms.DateTimePicker
        Friend WithEvents tb_PrevRefNum As System.Windows.Forms.TextBox
        Friend WithEvents lbl_PrevDateOnCheck As System.Windows.Forms.Label
        Friend WithEvents lbl_PrevRefNum As System.Windows.Forms.Label
        Friend WithEvents tb_PrevAmount As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents lbl_PrevAmount As System.Windows.Forms.Label
        Friend WithEvents lbl_PrevPayInfo As System.Windows.Forms.Label
        Friend WithEvents grp_NewPayInfo As System.Windows.Forms.GroupBox
        Friend WithEvents ck_Backdate As System.Windows.Forms.CheckBox
     End Class
End Namespace