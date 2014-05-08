<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentForm))
        Me.WorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.tc_Master = New System.Windows.Forms.TabControl()
        Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
        Me.UC_CustomerInfoBoxes = New TrashCash.UC_CustomerInfoBoxes()
        Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
        Me.UC_CustomerNotes = New TrashCash.UC_CustomerNotes()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.dg_WorkPay = New System.Windows.Forms.DataGridView()
        Me.CustomerNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm_WorkPay = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cm_i_ModPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_PrepPayHeader = New System.Windows.Forms.Label()
        Me.pnl_TopLeft = New System.Windows.Forms.Panel()
        Me.CustomerComboBox = New TrashCash.CustomerComboBox()
        Me.UC_PaymentDetails = New TrashCash.UC_PaymentDetails()
        Me.lbl_BalanceValue = New System.Windows.Forms.Label()
        Me.ck_ActiveCustOnly = New System.Windows.Forms.CheckBox()
        Me.lbl_BalanceHeader = New System.Windows.Forms.Label()
        Me.WorkingPaymentsTableAdapter = New TrashCash.DataSetTableAdapters.WorkingPaymentsTableAdapter()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_DeletePay = New System.Windows.Forms.ToolStripButton()
        Me.ts_b_CustSearch = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ts_b_SearchNum = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_b_SearchName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_b_SearchAddr = New System.Windows.Forms.ToolStripMenuItem()
        Me.tt_Locked = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Master.SuspendLayout()
        Me.tc_p_CustInfo.SuspendLayout()
        Me.tc_p_CustNotes.SuspendLayout()
        Me.pnl_Top.SuspendLayout()
        Me.pnl_Right.SuspendLayout()
        CType(Me.dg_WorkPay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm_WorkPay.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnl_TopLeft.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkingPaymentsBindingSource
        '
        Me.WorkingPaymentsBindingSource.DataMember = "WorkingPayments"
        Me.WorkingPaymentsBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tc_Master
        '
        Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
        Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
        Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tc_Master.Location = New System.Drawing.Point(0, 255)
        Me.tc_Master.Name = "tc_Master"
        Me.tc_Master.SelectedIndex = 0
        Me.tc_Master.Size = New System.Drawing.Size(912, 199)
        Me.tc_Master.TabIndex = 93
        '
        'tc_p_CustInfo
        '
        Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
        Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
        Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustInfo.Size = New System.Drawing.Size(904, 173)
        Me.tc_p_CustInfo.TabIndex = 0
        Me.tc_p_CustInfo.Text = "Customer Information"
        '
        'UC_CustomerInfoBoxes
        '
        Me.UC_CustomerInfoBoxes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_CustomerInfoBoxes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerInfoBoxes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerInfoBoxes.Name = "UC_CustomerInfoBoxes"
        Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(898, 167)
        Me.UC_CustomerInfoBoxes.TabIndex = 0
        '
        'tc_p_CustNotes
        '
        Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
        Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
        Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustNotes.Size = New System.Drawing.Size(904, 173)
        Me.tc_p_CustNotes.TabIndex = 3
        Me.tc_p_CustNotes.Text = "Customer Notes"
        '
        'UC_CustomerNotes
        '
        Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
        Me.UC_CustomerNotes.Size = New System.Drawing.Size(898, 167)
        Me.UC_CustomerNotes.TabIndex = 0
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.pnl_Right)
        Me.pnl_Top.Controls.Add(Me.pnl_TopLeft)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 26)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(912, 227)
        Me.pnl_Top.TabIndex = 96
        '
        'pnl_Right
        '
        Me.pnl_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Right.Controls.Add(Me.dg_WorkPay)
        Me.pnl_Right.Controls.Add(Me.Panel2)
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(431, 0)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(481, 227)
        Me.pnl_Right.TabIndex = 102
        '
        'dg_WorkPay
        '
        Me.dg_WorkPay.AllowUserToAddRows = False
        Me.dg_WorkPay.AllowUserToDeleteRows = False
        Me.dg_WorkPay.AllowUserToResizeRows = False
        Me.dg_WorkPay.AutoGenerateColumns = False
        Me.dg_WorkPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_WorkPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNumberDataGridViewTextBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.WorkingPaymentsTypeDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn})
        Me.dg_WorkPay.ContextMenuStrip = Me.cm_WorkPay
        Me.dg_WorkPay.DataSource = Me.WorkingPaymentsBindingSource
        Me.dg_WorkPay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_WorkPay.Location = New System.Drawing.Point(0, 25)
        Me.dg_WorkPay.MultiSelect = False
        Me.dg_WorkPay.Name = "dg_WorkPay"
        Me.dg_WorkPay.ReadOnly = True
        Me.dg_WorkPay.RowHeadersVisible = False
        Me.dg_WorkPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_WorkPay.ShowCellToolTips = False
        Me.dg_WorkPay.Size = New System.Drawing.Size(479, 200)
        Me.dg_WorkPay.TabIndex = 101
        Me.tt_Locked.SetToolTip(Me.dg_WorkPay, "Please finish Modifying the current payment first.")
        '
        'CustomerNumberDataGridViewTextBoxColumn
        '
        Me.CustomerNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CustomerNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerNumber"
        Me.CustomerNumberDataGridViewTextBoxColumn.HeaderText = "Customer #"
        Me.CustomerNumberDataGridViewTextBoxColumn.Name = "CustomerNumberDataGridViewTextBoxColumn"
        Me.CustomerNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerNumberDataGridViewTextBoxColumn.Width = 86
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WorkingPaymentsAmountDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
        DataGridViewCellStyle1.Format = "C2"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Name = "WorkingPaymentsAmountDataGridViewTextBoxColumn"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Width = 68
        '
        'WorkingPaymentsTypeDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsTypeDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsType"
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
        'cm_WorkPay
        '
        Me.cm_WorkPay.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_i_ModPayment})
        Me.cm_WorkPay.Name = "cm_WorkPay"
        Me.cm_WorkPay.Size = New System.Drawing.Size(163, 26)
        '
        'cm_i_ModPayment
        '
        Me.cm_i_ModPayment.Name = "cm_i_ModPayment"
        Me.cm_i_ModPayment.Size = New System.Drawing.Size(162, 22)
        Me.cm_i_ModPayment.Text = "Modify Payment"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbl_PrepPayHeader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(479, 25)
        Me.Panel2.TabIndex = 103
        '
        'lbl_PrepPayHeader
        '
        Me.lbl_PrepPayHeader.AutoSize = True
        Me.lbl_PrepPayHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrepPayHeader.Location = New System.Drawing.Point(3, 4)
        Me.lbl_PrepPayHeader.Name = "lbl_PrepPayHeader"
        Me.lbl_PrepPayHeader.Size = New System.Drawing.Size(167, 16)
        Me.lbl_PrepPayHeader.TabIndex = 99
        Me.lbl_PrepPayHeader.Text = "All Prepared Payments"
        '
        'pnl_TopLeft
        '
        Me.pnl_TopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_TopLeft.Controls.Add(Me.CustomerComboBox)
        Me.pnl_TopLeft.Controls.Add(Me.UC_PaymentDetails)
        Me.pnl_TopLeft.Controls.Add(Me.lbl_BalanceValue)
        Me.pnl_TopLeft.Controls.Add(Me.ck_ActiveCustOnly)
        Me.pnl_TopLeft.Controls.Add(Me.lbl_BalanceHeader)
        Me.pnl_TopLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_TopLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnl_TopLeft.Name = "pnl_TopLeft"
        Me.pnl_TopLeft.Size = New System.Drawing.Size(411, 227)
        Me.pnl_TopLeft.TabIndex = 100
        '
        'CustomerComboBox
        '
        Me.CustomerComboBox.DisplayMember = "CustomerFullName"
        Me.CustomerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CustomerComboBox.FormattingEnabled = True
        Me.CustomerComboBox.Location = New System.Drawing.Point(4, 4)
        Me.CustomerComboBox.Name = "CustomerComboBox"
        Me.CustomerComboBox.Size = New System.Drawing.Size(264, 21)
        Me.CustomerComboBox.TabIndex = 99
        Me.CustomerComboBox.ValueMember = "CustomerNumber"
        '
        'UC_PaymentDetails
        '
        Me.UC_PaymentDetails.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_PaymentDetails.Location = New System.Drawing.Point(96, 71)
        Me.UC_PaymentDetails.Name = "UC_PaymentDetails"
        Me.UC_PaymentDetails.Size = New System.Drawing.Size(198, 133)
        Me.UC_PaymentDetails.TabIndex = 97
        'Me.UC_PaymentDetails.WorkingPaymentID = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'lbl_BalanceValue
        '
        Me.lbl_BalanceValue.AutoSize = True
        Me.lbl_BalanceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_BalanceValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BalanceValue.Location = New System.Drawing.Point(217, 36)
        Me.lbl_BalanceValue.Name = "lbl_BalanceValue"
        Me.lbl_BalanceValue.Size = New System.Drawing.Size(66, 18)
        Me.lbl_BalanceValue.TabIndex = 97
        Me.lbl_BalanceValue.Text = "-$1000.00"
        '
        'ck_ActiveCustOnly
        '
        Me.ck_ActiveCustOnly.AutoSize = True
        Me.ck_ActiveCustOnly.Checked = True
        Me.ck_ActiveCustOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_ActiveCustOnly.Location = New System.Drawing.Point(274, 6)
        Me.ck_ActiveCustOnly.Name = "ck_ActiveCustOnly"
        Me.ck_ActiveCustOnly.Size = New System.Drawing.Size(132, 17)
        Me.ck_ActiveCustOnly.TabIndex = 98
        Me.ck_ActiveCustOnly.Text = "Active Customers Only"
        Me.ck_ActiveCustOnly.UseVisualStyleBackColor = True
        '
        'lbl_BalanceHeader
        '
        Me.lbl_BalanceHeader.AutoSize = True
        Me.lbl_BalanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BalanceHeader.Location = New System.Drawing.Point(105, 37)
        Me.lbl_BalanceHeader.Name = "lbl_BalanceHeader"
        Me.lbl_BalanceHeader.Size = New System.Drawing.Size(106, 16)
        Me.lbl_BalanceHeader.TabIndex = 96
        Me.lbl_BalanceHeader.Text = "Current Balance:"
        '
        'WorkingPaymentsTableAdapter
        '
        Me.WorkingPaymentsTableAdapter.ClearBeforeFill = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_DeletePay, Me.ts_b_CustSearch})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(912, 26)
        Me.ToolStrip1.TabIndex = 98
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_DeletePay
        '
        Me.btn_DeletePay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_DeletePay.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_DeletePay.ForeColor = System.Drawing.Color.Red
        Me.btn_DeletePay.Image = Global.TrashCash.My.Resources.Resources.remove
        Me.btn_DeletePay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_DeletePay.Name = "btn_DeletePay"
        Me.btn_DeletePay.Size = New System.Drawing.Size(135, 23)
        Me.btn_DeletePay.Text = "Delete Payment"
        Me.btn_DeletePay.Visible = False
        '
        'ts_b_CustSearch
        '
        Me.ts_b_CustSearch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_b_SearchNum, Me.ts_b_SearchName, Me.ts_b_SearchAddr})
        Me.ts_b_CustSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ts_b_CustSearch.Image = CType(resources.GetObject("ts_b_CustSearch.Image"), System.Drawing.Image)
        Me.ts_b_CustSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_b_CustSearch.Name = "ts_b_CustSearch"
        Me.ts_b_CustSearch.Size = New System.Drawing.Size(142, 23)
        Me.ts_b_CustSearch.Text = "Customer Search"
        '
        'ts_b_SearchNum
        '
        Me.ts_b_SearchNum.Name = "ts_b_SearchNum"
        Me.ts_b_SearchNum.Size = New System.Drawing.Size(128, 24)
        Me.ts_b_SearchNum.Text = "Number"
        '
        'ts_b_SearchName
        '
        Me.ts_b_SearchName.Name = "ts_b_SearchName"
        Me.ts_b_SearchName.Size = New System.Drawing.Size(128, 24)
        Me.ts_b_SearchName.Text = "Name"
        '
        'ts_b_SearchAddr
        '
        Me.ts_b_SearchAddr.Name = "ts_b_SearchAddr"
        Me.ts_b_SearchAddr.Size = New System.Drawing.Size(128, 24)
        Me.ts_b_SearchAddr.Text = "Address"
        '
        'tt_Locked
        '
        Me.tt_Locked.AutomaticDelay = 0
        Me.tt_Locked.AutoPopDelay = 0
        Me.tt_Locked.InitialDelay = 0
        Me.tt_Locked.ReshowDelay = 100
        Me.tt_Locked.ShowAlways = True
        Me.tt_Locked.UseFading = False
        '
        'PaymentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 454)
        Me.Controls.Add(Me.tc_Master)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "PaymentForm"
        Me.Text = "TrashCash | Payments"
        CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Master.ResumeLayout(False)
        Me.tc_p_CustInfo.ResumeLayout(False)
        Me.tc_p_CustNotes.ResumeLayout(False)
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Right.ResumeLayout(False)
        CType(Me.dg_WorkPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm_WorkPay.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnl_TopLeft.ResumeLayout(False)
        Me.pnl_TopLeft.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tc_Master As System.Windows.Forms.TabControl
    Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerInfoBoxes As TrashCash.UC_CustomerInfoBoxes
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents ck_ActiveCustOnly As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_BalanceValue As System.Windows.Forms.Label
    Friend WithEvents lbl_BalanceHeader As System.Windows.Forms.Label
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents WorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkingPaymentsTableAdapter As TrashCash.DataSetTableAdapters.WorkingPaymentsTableAdapter
    Friend WithEvents pnl_TopLeft As System.Windows.Forms.Panel
    Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerNotes As TrashCash.UC_CustomerNotes
    Friend WithEvents UC_PaymentDetails As TrashCash.UC_PaymentDetails
    Friend WithEvents dg_WorkPay As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsCheckNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cm_WorkPay As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cm_i_ModPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_Right As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_PrepPayHeader As System.Windows.Forms.Label
    Friend WithEvents tt_Locked As System.Windows.Forms.ToolTip
    Friend WithEvents btn_DeletePay As System.Windows.Forms.ToolStripButton
    Friend WithEvents CustomerComboBox As TrashCash.CustomerComboBox
    Friend WithEvents ts_b_CustSearch As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ts_b_SearchNum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts_b_SearchName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts_b_SearchAddr As System.Windows.Forms.ToolStripMenuItem
End Class
