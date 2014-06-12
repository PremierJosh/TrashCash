Imports TrashCash._DataSets

Namespace QBStuff
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UC_Quickbooks
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.grp_DateFilter = New System.Windows.Forms.GroupBox()
            Me.dtp_ItemFrom = New System.Windows.Forms.DateTimePicker()
            Me.dtp_ItemTo = New System.Windows.Forms.DateTimePicker()
            Me.chk_ItemTo = New System.Windows.Forms.CheckBox()
            Me.chk_ItemFrom = New System.Windows.Forms.CheckBox()
            Me.tc_Quickbooks = New System.Windows.Forms.TabControl()
            Me.tc_qb_p_Invoices = New System.Windows.Forms.TabPage()
            Me.dg_QBInvoices = New System.Windows.Forms.DataGridView()
            Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoicePostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceDueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceCreationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QBInvoiceDisplayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Display = New TrashCash._DataSets.DS_Display()
            Me.tc_qb_p_Payments = New System.Windows.Forms.TabPage()
            Me.dg_QBPayments = New System.Windows.Forms.DataGridView()
            Me.PaymentDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaymentAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaymentMethodDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaymentCheckNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QBPaymentsDisplayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.btn_ViewUnpaidInv = New System.Windows.Forms.Button()
            Me.btn_ViewAllInv = New System.Windows.Forms.Button()
            Me.btn_ViewPayments = New System.Windows.Forms.Button()
            Me.grp_DateFilter.SuspendLayout()
            Me.tc_Quickbooks.SuspendLayout()
            Me.tc_qb_p_Invoices.SuspendLayout()
            CType(Me.dg_QBInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.QBInvoiceDisplayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Display, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tc_qb_p_Payments.SuspendLayout()
            CType(Me.dg_QBPayments, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.QBPaymentsDisplayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grp_DateFilter
            '
            Me.grp_DateFilter.BackColor = System.Drawing.SystemColors.Control
            Me.grp_DateFilter.Controls.Add(Me.dtp_ItemFrom)
            Me.grp_DateFilter.Controls.Add(Me.dtp_ItemTo)
            Me.grp_DateFilter.Controls.Add(Me.chk_ItemTo)
            Me.grp_DateFilter.Controls.Add(Me.chk_ItemFrom)
            Me.grp_DateFilter.Location = New System.Drawing.Point(725, 6)
            Me.grp_DateFilter.Name = "grp_DateFilter"
            Me.grp_DateFilter.Size = New System.Drawing.Size(168, 67)
            Me.grp_DateFilter.TabIndex = 56
            Me.grp_DateFilter.TabStop = False
            Me.grp_DateFilter.Text = "Post Date Filter"
            '
            'dtp_ItemFrom
            '
            Me.dtp_ItemFrom.Enabled = False
            Me.dtp_ItemFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_ItemFrom.Location = New System.Drawing.Point(65, 16)
            Me.dtp_ItemFrom.Name = "dtp_ItemFrom"
            Me.dtp_ItemFrom.Size = New System.Drawing.Size(95, 20)
            Me.dtp_ItemFrom.TabIndex = 6
            '
            'dtp_ItemTo
            '
            Me.dtp_ItemTo.Enabled = False
            Me.dtp_ItemTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_ItemTo.Location = New System.Drawing.Point(65, 41)
            Me.dtp_ItemTo.Name = "dtp_ItemTo"
            Me.dtp_ItemTo.Size = New System.Drawing.Size(95, 20)
            Me.dtp_ItemTo.TabIndex = 9
            '
            'chk_ItemTo
            '
            Me.chk_ItemTo.AutoSize = True
            Me.chk_ItemTo.Location = New System.Drawing.Point(7, 42)
            Me.chk_ItemTo.Name = "chk_ItemTo"
            Me.chk_ItemTo.Size = New System.Drawing.Size(42, 17)
            Me.chk_ItemTo.TabIndex = 7
            Me.chk_ItemTo.Text = "To:"
            Me.chk_ItemTo.UseVisualStyleBackColor = True
            '
            'chk_ItemFrom
            '
            Me.chk_ItemFrom.AutoSize = True
            Me.chk_ItemFrom.Location = New System.Drawing.Point(7, 19)
            Me.chk_ItemFrom.Name = "chk_ItemFrom"
            Me.chk_ItemFrom.Size = New System.Drawing.Size(52, 17)
            Me.chk_ItemFrom.TabIndex = 8
            Me.chk_ItemFrom.Text = "From:"
            Me.chk_ItemFrom.UseVisualStyleBackColor = True
            '
            'tc_Quickbooks
            '
            Me.tc_Quickbooks.Controls.Add(Me.tc_qb_p_Invoices)
            Me.tc_Quickbooks.Controls.Add(Me.tc_qb_p_Payments)
            Me.tc_Quickbooks.Dock = System.Windows.Forms.DockStyle.Left
            Me.tc_Quickbooks.Location = New System.Drawing.Point(0, 0)
            Me.tc_Quickbooks.Name = "tc_Quickbooks"
            Me.tc_Quickbooks.SelectedIndex = 0
            Me.tc_Quickbooks.Size = New System.Drawing.Size(719, 230)
            Me.tc_Quickbooks.TabIndex = 57
            Me.tc_Quickbooks.TabStop = False
            '
            'tc_qb_p_Invoices
            '
            Me.tc_qb_p_Invoices.AccessibleName = "tc_qb_p_Invoices"
            Me.tc_qb_p_Invoices.BackColor = System.Drawing.SystemColors.Control
            Me.tc_qb_p_Invoices.Controls.Add(Me.dg_QBInvoices)
            Me.tc_qb_p_Invoices.Location = New System.Drawing.Point(4, 22)
            Me.tc_qb_p_Invoices.Name = "tc_qb_p_Invoices"
            Me.tc_qb_p_Invoices.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_qb_p_Invoices.Size = New System.Drawing.Size(711, 204)
            Me.tc_qb_p_Invoices.TabIndex = 0
            Me.tc_qb_p_Invoices.Text = "Invoices"
            '
            'dg_QBInvoices
            '
            Me.dg_QBInvoices.AllowUserToAddRows = False
            Me.dg_QBInvoices.AllowUserToDeleteRows = False
            Me.dg_QBInvoices.AllowUserToResizeRows = False
            Me.dg_QBInvoices.AutoGenerateColumns = False
            Me.dg_QBInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dg_QBInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_QBInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn, Me.InvoicePostDateDataGridViewTextBoxColumn, Me.InvoiceDueDateDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn, Me.InvoiceBalanceDataGridViewTextBoxColumn, Me.InvoiceCreationDateDataGridViewTextBoxColumn})
            Me.dg_QBInvoices.DataSource = Me.QBInvoiceDisplayBindingSource
            Me.dg_QBInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg_QBInvoices.Location = New System.Drawing.Point(3, 3)
            Me.dg_QBInvoices.Name = "dg_QBInvoices"
            Me.dg_QBInvoices.ReadOnly = True
            Me.dg_QBInvoices.RowHeadersWidth = 30
            Me.dg_QBInvoices.Size = New System.Drawing.Size(705, 198)
            Me.dg_QBInvoices.TabIndex = 1
            Me.dg_QBInvoices.TabStop = False
            '
            'InvoiceNumberDataGridViewTextBoxColumn
            '
            Me.InvoiceNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
            Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice Ref #"
            Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
            Me.InvoiceNumberDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoicePostDateDataGridViewTextBoxColumn
            '
            Me.InvoicePostDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.InvoicePostDateDataGridViewTextBoxColumn.DataPropertyName = "InvoicePostDate"
            DataGridViewCellStyle1.Format = "d"
            Me.InvoicePostDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
            Me.InvoicePostDateDataGridViewTextBoxColumn.HeaderText = "Post Date"
            Me.InvoicePostDateDataGridViewTextBoxColumn.Name = "InvoicePostDateDataGridViewTextBoxColumn"
            Me.InvoicePostDateDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoiceDueDateDataGridViewTextBoxColumn
            '
            Me.InvoiceDueDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.InvoiceDueDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDueDate"
            DataGridViewCellStyle2.Format = "d"
            Me.InvoiceDueDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.InvoiceDueDateDataGridViewTextBoxColumn.HeaderText = "Due Date"
            Me.InvoiceDueDateDataGridViewTextBoxColumn.Name = "InvoiceDueDateDataGridViewTextBoxColumn"
            Me.InvoiceDueDateDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoiceTotalDataGridViewTextBoxColumn
            '
            Me.InvoiceTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
            DataGridViewCellStyle3.Format = "C2"
            Me.InvoiceTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
            Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "Total"
            Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
            Me.InvoiceTotalDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoiceBalanceDataGridViewTextBoxColumn
            '
            Me.InvoiceBalanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.InvoiceBalanceDataGridViewTextBoxColumn.DataPropertyName = "InvoiceBalance"
            DataGridViewCellStyle4.Format = "C2"
            DataGridViewCellStyle4.NullValue = Nothing
            Me.InvoiceBalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
            Me.InvoiceBalanceDataGridViewTextBoxColumn.HeaderText = "Balance"
            Me.InvoiceBalanceDataGridViewTextBoxColumn.Name = "InvoiceBalanceDataGridViewTextBoxColumn"
            Me.InvoiceBalanceDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoiceCreationDateDataGridViewTextBoxColumn
            '
            Me.InvoiceCreationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.InvoiceCreationDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceCreationDate"
            DataGridViewCellStyle5.Format = "d"
            Me.InvoiceCreationDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
            Me.InvoiceCreationDateDataGridViewTextBoxColumn.HeaderText = "Creation Date"
            Me.InvoiceCreationDateDataGridViewTextBoxColumn.Name = "InvoiceCreationDateDataGridViewTextBoxColumn"
            Me.InvoiceCreationDateDataGridViewTextBoxColumn.ReadOnly = True
            '
            'QBInvoiceDisplayBindingSource
            '
            Me.QBInvoiceDisplayBindingSource.DataMember = "QB_InvoiceDisplay"
            Me.QBInvoiceDisplayBindingSource.DataSource = Me.Display
            '
            'Display
            '
            Me.Display.DataSetName = "ds_Display"
            Me.Display.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'tc_qb_p_Payments
            '
            Me.tc_qb_p_Payments.AccessibleName = "tc_qb_p_Payments"
            Me.tc_qb_p_Payments.BackColor = System.Drawing.SystemColors.Control
            Me.tc_qb_p_Payments.Controls.Add(Me.dg_QBPayments)
            Me.tc_qb_p_Payments.Location = New System.Drawing.Point(4, 22)
            Me.tc_qb_p_Payments.Name = "tc_qb_p_Payments"
            Me.tc_qb_p_Payments.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_qb_p_Payments.Size = New System.Drawing.Size(711, 204)
            Me.tc_qb_p_Payments.TabIndex = 1
            Me.tc_qb_p_Payments.Text = "Payments"
            '
            'dg_QBPayments
            '
            Me.dg_QBPayments.AllowUserToAddRows = False
            Me.dg_QBPayments.AllowUserToDeleteRows = False
            Me.dg_QBPayments.AllowUserToResizeRows = False
            Me.dg_QBPayments.AutoGenerateColumns = False
            Me.dg_QBPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_QBPayments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PaymentDateDataGridViewTextBoxColumn, Me.PaymentAmountDataGridViewTextBoxColumn, Me.PaymentMethodDataGridViewTextBoxColumn, Me.PaymentCheckNumDataGridViewTextBoxColumn})
            Me.dg_QBPayments.DataSource = Me.QBPaymentsDisplayBindingSource
            Me.dg_QBPayments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg_QBPayments.Location = New System.Drawing.Point(3, 3)
            Me.dg_QBPayments.Name = "dg_QBPayments"
            Me.dg_QBPayments.ReadOnly = True
            Me.dg_QBPayments.RowHeadersWidth = 30
            Me.dg_QBPayments.Size = New System.Drawing.Size(705, 198)
            Me.dg_QBPayments.TabIndex = 44
            Me.dg_QBPayments.TabStop = False
            '
            'PaymentDateDataGridViewTextBoxColumn
            '
            Me.PaymentDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.PaymentDateDataGridViewTextBoxColumn.DataPropertyName = "PaymentDate"
            DataGridViewCellStyle6.Format = "d"
            Me.PaymentDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
            Me.PaymentDateDataGridViewTextBoxColumn.HeaderText = "Date"
            Me.PaymentDateDataGridViewTextBoxColumn.Name = "PaymentDateDataGridViewTextBoxColumn"
            Me.PaymentDateDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaymentAmountDataGridViewTextBoxColumn
            '
            Me.PaymentAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.PaymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount"
            DataGridViewCellStyle7.Format = "C2"
            Me.PaymentAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
            Me.PaymentAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.PaymentAmountDataGridViewTextBoxColumn.Name = "PaymentAmountDataGridViewTextBoxColumn"
            Me.PaymentAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaymentMethodDataGridViewTextBoxColumn
            '
            Me.PaymentMethodDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.PaymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod"
            Me.PaymentMethodDataGridViewTextBoxColumn.HeaderText = "Payment Method"
            Me.PaymentMethodDataGridViewTextBoxColumn.Name = "PaymentMethodDataGridViewTextBoxColumn"
            Me.PaymentMethodDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaymentCheckNumDataGridViewTextBoxColumn
            '
            Me.PaymentCheckNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.PaymentCheckNumDataGridViewTextBoxColumn.DataPropertyName = "PaymentCheckNum"
            Me.PaymentCheckNumDataGridViewTextBoxColumn.HeaderText = "Check #"
            Me.PaymentCheckNumDataGridViewTextBoxColumn.Name = "PaymentCheckNumDataGridViewTextBoxColumn"
            Me.PaymentCheckNumDataGridViewTextBoxColumn.ReadOnly = True
            '
            'QBPaymentsDisplayBindingSource
            '
            Me.QBPaymentsDisplayBindingSource.DataMember = "QB_PaymentsDisplay"
            Me.QBPaymentsDisplayBindingSource.DataSource = Me.Display
            '
            'btn_ViewUnpaidInv
            '
            Me.btn_ViewUnpaidInv.Location = New System.Drawing.Point(719, 135)
            Me.btn_ViewUnpaidInv.Name = "btn_ViewUnpaidInv"
            Me.btn_ViewUnpaidInv.Size = New System.Drawing.Size(181, 32)
            Me.btn_ViewUnpaidInv.TabIndex = 59
            Me.btn_ViewUnpaidInv.Text = "View All Unpaid Invoices"
            Me.btn_ViewUnpaidInv.UseVisualStyleBackColor = True
            Me.btn_ViewUnpaidInv.Visible = False
            '
            'btn_ViewAllInv
            '
            Me.btn_ViewAllInv.Location = New System.Drawing.Point(719, 95)
            Me.btn_ViewAllInv.Name = "btn_ViewAllInv"
            Me.btn_ViewAllInv.Size = New System.Drawing.Size(181, 32)
            Me.btn_ViewAllInv.TabIndex = 60
            Me.btn_ViewAllInv.Text = "View All Invoices"
            Me.btn_ViewAllInv.UseVisualStyleBackColor = True
            Me.btn_ViewAllInv.Visible = False
            '
            'btn_ViewPayments
            '
            Me.btn_ViewPayments.Location = New System.Drawing.Point(719, 175)
            Me.btn_ViewPayments.Name = "btn_ViewPayments"
            Me.btn_ViewPayments.Size = New System.Drawing.Size(181, 32)
            Me.btn_ViewPayments.TabIndex = 61
            Me.btn_ViewPayments.Text = "View Payments"
            Me.btn_ViewPayments.UseVisualStyleBackColor = True
            Me.btn_ViewPayments.Visible = False
            '
            'UC_Quickbooks
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.btn_ViewPayments)
            Me.Controls.Add(Me.btn_ViewAllInv)
            Me.Controls.Add(Me.btn_ViewUnpaidInv)
            Me.Controls.Add(Me.grp_DateFilter)
            Me.Controls.Add(Me.tc_Quickbooks)
            Me.Name = "UC_Quickbooks"
            Me.Size = New System.Drawing.Size(900, 230)
            Me.grp_DateFilter.ResumeLayout(False)
            Me.grp_DateFilter.PerformLayout()
            Me.tc_Quickbooks.ResumeLayout(False)
            Me.tc_qb_p_Invoices.ResumeLayout(False)
            CType(Me.dg_QBInvoices, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.QBInvoiceDisplayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Display, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tc_qb_p_Payments.ResumeLayout(False)
            CType(Me.dg_QBPayments, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.QBPaymentsDisplayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents grp_DateFilter As System.Windows.Forms.GroupBox
        Friend WithEvents dtp_ItemFrom As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtp_ItemTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents chk_ItemTo As System.Windows.Forms.CheckBox
        Friend WithEvents chk_ItemFrom As System.Windows.Forms.CheckBox
        Friend WithEvents tc_Quickbooks As System.Windows.Forms.TabControl
        Friend WithEvents tc_qb_p_Invoices As System.Windows.Forms.TabPage
        Friend WithEvents dg_QBInvoices As System.Windows.Forms.DataGridView
        Friend WithEvents tc_qb_p_Payments As System.Windows.Forms.TabPage
        Friend WithEvents dg_QBPayments As System.Windows.Forms.DataGridView
        Friend WithEvents btn_ViewUnpaidInv As System.Windows.Forms.Button
        Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoicePostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceDueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceCreationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QBInvoiceDisplayBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Display As DS_Display
        Friend WithEvents PaymentDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaymentAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaymentMethodDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaymentCheckNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QBPaymentsDisplayBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents btn_ViewAllInv As System.Windows.Forms.Button
        Friend WithEvents btn_ViewPayments As System.Windows.Forms.Button

    End Class
End Namespace