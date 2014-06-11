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
            Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.WorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Payments = New DS_Payments()
            Me.tc_Master = New System.Windows.Forms.TabControl()
            Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
            Me.UC_CustomerNotes = New UC_CustomerNotes()
            Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
            Me.UC_CustomerInfoBoxes = New TrashCash.Customer.UC_CustomerInfoBoxes()
            Me.WorkingPaymentsTableAdapter = New WorkingPaymentsTableAdapter()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.pnl_TopContent = New System.Windows.Forms.Panel()
            Me.CustomerToolstrip1 = New TrashCash.Classes.CustomerToolstrip.CustomerToolstrip()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.WorkingPaymentsIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CustomerNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.WorkingPaymentsStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TIMERECEIVEDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DATEONCHECKDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InsertedByUserDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnl_Right = New System.Windows.Forms.Panel()
            Me.lbl_PaysInQueue = New System.Windows.Forms.Label()
            Me.cmb_PayTypes = New System.Windows.Forms.ComboBox()
            Me.PaymentTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Types = New TrashCash.ds_Types()
            Me.PaymentTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter()
            Me.lbl_PayType = New System.Windows.Forms.Label()
            Me.dtp_Override = New System.Windows.Forms.DateTimePicker()
            Me.ck_Override = New System.Windows.Forms.CheckBox()
            Me.btn_AddPayment = New System.Windows.Forms.Button()
            Me.dtp_DateOnCheck = New System.Windows.Forms.DateTimePicker()
            Me.tb_RefNum = New System.Windows.Forms.TextBox()
            Me.lbl_DateOnCheck = New System.Windows.Forms.Label()
            Me.lbl_RefNumber = New System.Windows.Forms.Label()
            Me.tb_Amount = New TrashCash.Classes.CurrencyTextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cm_PayGrid.SuspendLayout()
            CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Payments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tc_Master.SuspendLayout()
            Me.tc_p_CustNotes.SuspendLayout()
            Me.tc_p_CustInfo.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.pnl_TopContent.SuspendLayout()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_Right.SuspendLayout()
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.WorkingPaymentsBindingSource.DataSource = Me.Payments
            '
            'ds_Payments
            '
            Me.Payments.DataSetName = "DataSet"
            Me.Payments.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'tc_Master
            '
            Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
            Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
            Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.tc_Master.Location = New System.Drawing.Point(0, 267)
            Me.tc_Master.Name = "tc_Master"
            Me.tc_Master.SelectedIndex = 0
            Me.tc_Master.Size = New System.Drawing.Size(916, 205)
            Me.tc_Master.TabIndex = 95
            '
            'tc_p_CustNotes
            '
            Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
            Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
            Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_CustNotes.Size = New System.Drawing.Size(908, 179)
            Me.tc_p_CustNotes.TabIndex = 3
            Me.tc_p_CustNotes.Text = "Customer Notes"
            '
            'UC_CustomerNotes
            '
            Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
            Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
            Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
            Me.UC_CustomerNotes.Size = New System.Drawing.Size(902, 173)
            Me.UC_CustomerNotes.TabIndex = 0
            '
            'tc_p_CustInfo
            '
            Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
            Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
            Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_CustInfo.Size = New System.Drawing.Size(908, 179)
            Me.tc_p_CustInfo.TabIndex = 0
            Me.tc_p_CustInfo.Text = "Customer Information"
            '
            'UC_CustomerInfoBoxes
            '
            Me.UC_CustomerInfoBoxes.CurrentCustomer = 0
            Me.UC_CustomerInfoBoxes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_CustomerInfoBoxes.IsUpdating = False
            Me.UC_CustomerInfoBoxes.Location = New System.Drawing.Point(3, 3)
            Me.UC_CustomerInfoBoxes.Name = "UC_CustomerInfoBoxes"
            Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(902, 173)
            Me.UC_CustomerInfoBoxes.TabIndex = 0
            '
            'WorkingPaymentsTableAdapter
            '
            Me.WorkingPaymentsTableAdapter.ClearBeforeFill = False
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.pnl_TopContent)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
            Me.Panel1.Size = New System.Drawing.Size(916, 53)
            Me.Panel1.TabIndex = 96
            '
            'pnl_TopContent
            '
            Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TopContent.Controls.Add(Me.CustomerToolstrip1)
            Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
            Me.pnl_TopContent.Name = "pnl_TopContent"
            Me.pnl_TopContent.Size = New System.Drawing.Size(876, 33)
            Me.pnl_TopContent.TabIndex = 2
            '
            'CustomerToolstrip1
            '
            Me.CustomerToolstrip1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CustomerToolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.CustomerToolstrip1.Location = New System.Drawing.Point(0, 0)
            Me.CustomerToolstrip1.Name = "CustomerToolstrip1"
            Me.CustomerToolstrip1.Size = New System.Drawing.Size(874, 31)
            Me.CustomerToolstrip1.TabIndex = 0
            Me.CustomerToolstrip1.Text = "CustomerToolstrip1"
            '
            'DataGridView1
            '
            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.AllowUserToDeleteRows = False
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WorkingPaymentsIDDataGridViewTextBoxColumn, Me.CustomerNumberDataGridViewTextBoxColumn, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.WorkingPaymentsTypeDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn, Me.WorkingPaymentsStatusDataGridViewTextBoxColumn, Me.TIMERECEIVEDDataGridViewTextBoxColumn, Me.DATEONCHECKDataGridViewTextBoxColumn, Me.InsertedByUserDataGridViewTextBoxColumn})
            Me.DataGridView1.DataSource = Me.WorkingPaymentsBindingSource
            Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridView1.Location = New System.Drawing.Point(0, 21)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.ReadOnly = True
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.Size = New System.Drawing.Size(513, 193)
            Me.DataGridView1.TabIndex = 97
            '
            'WorkingPaymentsIDDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsIDDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsID"
            Me.WorkingPaymentsIDDataGridViewTextBoxColumn.HeaderText = "WorkingPaymentsID"
            Me.WorkingPaymentsIDDataGridViewTextBoxColumn.Name = "WorkingPaymentsIDDataGridViewTextBoxColumn"
            Me.WorkingPaymentsIDDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CustomerNumberDataGridViewTextBoxColumn
            '
            Me.CustomerNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerNumber"
            Me.CustomerNumberDataGridViewTextBoxColumn.HeaderText = "CustomerNumber"
            Me.CustomerNumberDataGridViewTextBoxColumn.Name = "CustomerNumberDataGridViewTextBoxColumn"
            Me.CustomerNumberDataGridViewTextBoxColumn.ReadOnly = True
            '
            'WorkingPaymentsAmountDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.HeaderText = "WorkingPaymentsAmount"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Name = "WorkingPaymentsAmountDataGridViewTextBoxColumn"
            Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'WorkingPaymentsTypeDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsType"
            Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.HeaderText = "WorkingPaymentsType"
            Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.Name = "WorkingPaymentsTypeDataGridViewTextBoxColumn"
            Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'WorkingPaymentsCheckNumDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsCheckNum"
            Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.HeaderText = "WorkingPaymentsCheckNum"
            Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.Name = "WorkingPaymentsCheckNumDataGridViewTextBoxColumn"
            Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.ReadOnly = True
            '
            'WorkingPaymentsStatusDataGridViewTextBoxColumn
            '
            Me.WorkingPaymentsStatusDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsStatus"
            Me.WorkingPaymentsStatusDataGridViewTextBoxColumn.HeaderText = "WorkingPaymentsStatus"
            Me.WorkingPaymentsStatusDataGridViewTextBoxColumn.Name = "WorkingPaymentsStatusDataGridViewTextBoxColumn"
            Me.WorkingPaymentsStatusDataGridViewTextBoxColumn.ReadOnly = True
            '
            'TIMERECEIVEDDataGridViewTextBoxColumn
            '
            Me.TIMERECEIVEDDataGridViewTextBoxColumn.DataPropertyName = "TIME_RECEIVED"
            Me.TIMERECEIVEDDataGridViewTextBoxColumn.HeaderText = "TIME_RECEIVED"
            Me.TIMERECEIVEDDataGridViewTextBoxColumn.Name = "TIMERECEIVEDDataGridViewTextBoxColumn"
            Me.TIMERECEIVEDDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DATEONCHECKDataGridViewTextBoxColumn
            '
            Me.DATEONCHECKDataGridViewTextBoxColumn.DataPropertyName = "DATE_ON_CHECK"
            Me.DATEONCHECKDataGridViewTextBoxColumn.HeaderText = "DATE_ON_CHECK"
            Me.DATEONCHECKDataGridViewTextBoxColumn.Name = "DATEONCHECKDataGridViewTextBoxColumn"
            Me.DATEONCHECKDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InsertedByUserDataGridViewTextBoxColumn
            '
            Me.InsertedByUserDataGridViewTextBoxColumn.DataPropertyName = "InsertedByUser"
            Me.InsertedByUserDataGridViewTextBoxColumn.HeaderText = "InsertedByUser"
            Me.InsertedByUserDataGridViewTextBoxColumn.Name = "InsertedByUserDataGridViewTextBoxColumn"
            Me.InsertedByUserDataGridViewTextBoxColumn.ReadOnly = True
            '
            'pnl_Right
            '
            Me.pnl_Right.Controls.Add(Me.DataGridView1)
            Me.pnl_Right.Controls.Add(Me.lbl_PaysInQueue)
            Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnl_Right.Location = New System.Drawing.Point(403, 53)
            Me.pnl_Right.Name = "pnl_Right"
            Me.pnl_Right.Size = New System.Drawing.Size(513, 214)
            Me.pnl_Right.TabIndex = 98
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
            Me.cmb_PayTypes.Location = New System.Drawing.Point(58, 83)
            Me.cmb_PayTypes.Name = "cmb_PayTypes"
            Me.cmb_PayTypes.Size = New System.Drawing.Size(175, 21)
            Me.cmb_PayTypes.TabIndex = 99
            Me.cmb_PayTypes.ValueMember = "PaymentTypeID"
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
            'PaymentTypesTableAdapter
            '
            Me.PaymentTypesTableAdapter.ClearBeforeFill = True
            '
            'lbl_PayType
            '
            Me.lbl_PayType.AutoSize = True
            Me.lbl_PayType.Location = New System.Drawing.Point(60, 67)
            Me.lbl_PayType.Name = "lbl_PayType"
            Me.lbl_PayType.Size = New System.Drawing.Size(78, 13)
            Me.lbl_PayType.TabIndex = 100
            Me.lbl_PayType.Text = "Payment Type:"
            '
            'dtp_Override
            '
            Me.dtp_Override.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_Override.Location = New System.Drawing.Point(149, 185)
            Me.dtp_Override.Name = "dtp_Override"
            Me.dtp_Override.Size = New System.Drawing.Size(84, 20)
            Me.dtp_Override.TabIndex = 110
            Me.dtp_Override.Visible = False
            '
            'ck_Override
            '
            Me.ck_Override.AutoSize = True
            Me.ck_Override.Location = New System.Drawing.Point(67, 192)
            Me.ck_Override.Name = "ck_Override"
            Me.ck_Override.Size = New System.Drawing.Size(63, 17)
            Me.ck_Override.TabIndex = 109
            Me.ck_Override.Text = "Overide"
            Me.ck_Override.UseVisualStyleBackColor = True
            Me.ck_Override.Visible = False
            '
            'btn_AddPayment
            '
            Me.btn_AddPayment.Location = New System.Drawing.Point(58, 215)
            Me.btn_AddPayment.Name = "btn_AddPayment"
            Me.btn_AddPayment.Size = New System.Drawing.Size(187, 23)
            Me.btn_AddPayment.TabIndex = 111
            Me.btn_AddPayment.Text = "Add Payment"
            Me.btn_AddPayment.UseVisualStyleBackColor = True
            '
            'dtp_DateOnCheck
            '
            Me.dtp_DateOnCheck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_DateOnCheck.Location = New System.Drawing.Point(149, 159)
            Me.dtp_DateOnCheck.Name = "dtp_DateOnCheck"
            Me.dtp_DateOnCheck.Size = New System.Drawing.Size(84, 20)
            Me.dtp_DateOnCheck.TabIndex = 108
            Me.dtp_DateOnCheck.Visible = False
            '
            'tb_RefNum
            '
            Me.tb_RefNum.Location = New System.Drawing.Point(133, 133)
            Me.tb_RefNum.Name = "tb_RefNum"
            Me.tb_RefNum.Size = New System.Drawing.Size(100, 20)
            Me.tb_RefNum.TabIndex = 107
            Me.tb_RefNum.TabStop = False
            Me.tb_RefNum.Visible = False
            '
            'lbl_DateOnCheck
            '
            Me.lbl_DateOnCheck.AutoSize = True
            Me.lbl_DateOnCheck.Location = New System.Drawing.Point(62, 163)
            Me.lbl_DateOnCheck.Name = "lbl_DateOnCheck"
            Me.lbl_DateOnCheck.Size = New System.Drawing.Size(81, 13)
            Me.lbl_DateOnCheck.TabIndex = 114
            Me.lbl_DateOnCheck.Text = "Date on check:"
            Me.lbl_DateOnCheck.Visible = False
            '
            'lbl_RefNumber
            '
            Me.lbl_RefNumber.AutoSize = True
            Me.lbl_RefNumber.Location = New System.Drawing.Point(60, 136)
            Me.lbl_RefNumber.Name = "lbl_RefNumber"
            Me.lbl_RefNumber.Size = New System.Drawing.Size(70, 13)
            Me.lbl_RefNumber.TabIndex = 113
            Me.lbl_RefNumber.Text = "Reference #:"
            Me.lbl_RefNumber.Visible = False
            '
            'tb_Amount
            '
            Me.tb_Amount.Location = New System.Drawing.Point(133, 110)
            Me.tb_Amount.Name = "tb_Amount"
            Me.tb_Amount.Size = New System.Drawing.Size(100, 20)
            Me.tb_Amount.TabIndex = 106
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(84, 113)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(46, 13)
            Me.Label1.TabIndex = 112
            Me.Label1.Text = "Amount:"
            '
            'PaymentsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(916, 472)
            Me.Controls.Add(Me.dtp_Override)
            Me.Controls.Add(Me.ck_Override)
            Me.Controls.Add(Me.btn_AddPayment)
            Me.Controls.Add(Me.dtp_DateOnCheck)
            Me.Controls.Add(Me.tb_RefNum)
            Me.Controls.Add(Me.lbl_DateOnCheck)
            Me.Controls.Add(Me.lbl_RefNumber)
            Me.Controls.Add(Me.tb_Amount)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lbl_PayType)
            Me.Controls.Add(Me.cmb_PayTypes)
            Me.Controls.Add(Me.pnl_Right)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.tc_Master)
            Me.MaximizeBox = False
            Me.Name = "PaymentsForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Payments"
            Me.cm_PayGrid.ResumeLayout(False)
            CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Payments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tc_Master.ResumeLayout(False)
            Me.tc_p_CustNotes.ResumeLayout(False)
            Me.tc_p_CustInfo.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.pnl_TopContent.ResumeLayout(False)
            Me.pnl_TopContent.PerformLayout()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_Right.ResumeLayout(False)
            CType(Me.PaymentTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tc_Master As System.Windows.Forms.TabControl
        Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
        Friend WithEvents UC_CustomerNotes As UC_CustomerNotes
        Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
        Friend WithEvents UC_CustomerInfoBoxes As UC_CustomerInfoBoxes
        Friend WithEvents Payments As DS_Payments
        Friend WithEvents WorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents WorkingPaymentsTableAdapter As WorkingPaymentsTableAdapter
        Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaymentTypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cm_PayGrid As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
        Friend WithEvents CustomerToolstrip1 As TrashCash.Classes.CustomerToolstrip.CustomerToolstrip
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents WorkingPaymentsIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CustomerNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsCheckNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WorkingPaymentsStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TIMERECEIVEDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DATEONCHECKDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InsertedByUserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnl_Right As System.Windows.Forms.Panel
        Friend WithEvents lbl_PaysInQueue As System.Windows.Forms.Label
        Friend WithEvents cmb_PayTypes As System.Windows.Forms.ComboBox
        Friend WithEvents Ds_Types As TrashCash.ds_Types
        Friend WithEvents PaymentTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PaymentTypesTableAdapter As TrashCash.ds_TypesTableAdapters.PaymentTypesTableAdapter
        Friend WithEvents lbl_PayType As System.Windows.Forms.Label
        Friend WithEvents dtp_Override As System.Windows.Forms.DateTimePicker
        Friend WithEvents ck_Override As System.Windows.Forms.CheckBox
        Friend WithEvents btn_AddPayment As System.Windows.Forms.Button
        Friend WithEvents dtp_DateOnCheck As System.Windows.Forms.DateTimePicker
        Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
        Friend WithEvents lbl_DateOnCheck As System.Windows.Forms.Label
        Friend WithEvents lbl_RefNumber As System.Windows.Forms.Label
        Friend WithEvents tb_Amount As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace