Imports TrashCash.Classes

Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminPayments
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminPayments))
            Me.pnl_Top = New System.Windows.Forms.Panel()
            Me.pnl_TopContent = New System.Windows.Forms.Panel()
            Me.dg_PaymentHistory = New System.Windows.Forms.DataGridView()
            Me.PaymentTypeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RefNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DateReceivedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InsertedByUserDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cm_AlterPayment = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.cm_i_BounceCheck = New System.Windows.Forms.ToolStripMenuItem()
            Me.cm_i_MovePayment = New System.Windows.Forms.ToolStripMenuItem()
            Me.PaymentHistoryDisplayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Payments = New TrashCash.ds_Payments()
            Me.pnl_Filter = New System.Windows.Forms.Panel()
            Me.ck_All = New System.Windows.Forms.CheckBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
            Me.lbl_DateFilter = New System.Windows.Forms.Label()
            Me.PaymentHistory_DisplayTableAdapter = New TrashCash.ds_PaymentsTableAdapters.PaymentHistory_DisplayTableAdapter()
            Me.CustomerToolstrip1 = New TrashCash.Classes.CustomerToolstrip.CustomerToolstrip()
            Me.pnl_Top.SuspendLayout()
            Me.pnl_TopContent.SuspendLayout()
            CType(Me.dg_PaymentHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cm_AlterPayment.SuspendLayout()
            CType(Me.PaymentHistoryDisplayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Payments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_Filter.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnl_Top
            '
            Me.pnl_Top.Controls.Add(Me.pnl_TopContent)
            Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
            Me.pnl_Top.Name = "pnl_Top"
            Me.pnl_Top.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
            Me.pnl_Top.Size = New System.Drawing.Size(869, 53)
            Me.pnl_Top.TabIndex = 15
            '
            'pnl_TopContent
            '
            Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TopContent.Controls.Add(Me.CustomerToolstrip1)
            Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
            Me.pnl_TopContent.Name = "pnl_TopContent"
            Me.pnl_TopContent.Size = New System.Drawing.Size(829, 33)
            Me.pnl_TopContent.TabIndex = 14
            '
            'dg_PaymentHistory
            '
            Me.dg_PaymentHistory.AllowUserToAddRows = False
            Me.dg_PaymentHistory.AllowUserToDeleteRows = False
            Me.dg_PaymentHistory.AutoGenerateColumns = False
            Me.dg_PaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dg_PaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_PaymentHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PaymentTypeNameDataGridViewTextBoxColumn, Me.RefNumberDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.DateReceivedDataGridViewTextBoxColumn, Me.InsertedByUserDataGridViewTextBoxColumn})
            Me.dg_PaymentHistory.ContextMenuStrip = Me.cm_AlterPayment
            Me.dg_PaymentHistory.DataSource = Me.PaymentHistoryDisplayBindingSource
            Me.dg_PaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg_PaymentHistory.Location = New System.Drawing.Point(0, 117)
            Me.dg_PaymentHistory.MultiSelect = False
            Me.dg_PaymentHistory.Name = "dg_PaymentHistory"
            Me.dg_PaymentHistory.ReadOnly = True
            Me.dg_PaymentHistory.RowHeadersVisible = False
            Me.dg_PaymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_PaymentHistory.Size = New System.Drawing.Size(869, 341)
            Me.dg_PaymentHistory.TabIndex = 16
            '
            'PaymentTypeNameDataGridViewTextBoxColumn
            '
            Me.PaymentTypeNameDataGridViewTextBoxColumn.DataPropertyName = "PaymentTypeName"
            Me.PaymentTypeNameDataGridViewTextBoxColumn.HeaderText = "Payment Type"
            Me.PaymentTypeNameDataGridViewTextBoxColumn.Name = "PaymentTypeNameDataGridViewTextBoxColumn"
            Me.PaymentTypeNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'RefNumberDataGridViewTextBoxColumn
            '
            Me.RefNumberDataGridViewTextBoxColumn.DataPropertyName = "RefNumber"
            Me.RefNumberDataGridViewTextBoxColumn.HeaderText = "Ref #"
            Me.RefNumberDataGridViewTextBoxColumn.Name = "RefNumberDataGridViewTextBoxColumn"
            Me.RefNumberDataGridViewTextBoxColumn.ReadOnly = True
            '
            'AmountDataGridViewTextBoxColumn
            '
            Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
            DataGridViewCellStyle1.Format = "C2"
            Me.AmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
            Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
            Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DateReceivedDataGridViewTextBoxColumn
            '
            Me.DateReceivedDataGridViewTextBoxColumn.DataPropertyName = "DateReceived"
            DataGridViewCellStyle2.Format = "d"
            Me.DateReceivedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.DateReceivedDataGridViewTextBoxColumn.HeaderText = "Date Received"
            Me.DateReceivedDataGridViewTextBoxColumn.Name = "DateReceivedDataGridViewTextBoxColumn"
            Me.DateReceivedDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InsertedByUserDataGridViewTextBoxColumn
            '
            Me.InsertedByUserDataGridViewTextBoxColumn.DataPropertyName = "InsertedByUser"
            Me.InsertedByUserDataGridViewTextBoxColumn.HeaderText = "Inserted By"
            Me.InsertedByUserDataGridViewTextBoxColumn.Name = "InsertedByUserDataGridViewTextBoxColumn"
            Me.InsertedByUserDataGridViewTextBoxColumn.ReadOnly = True
            '
            'cm_AlterPayment
            '
            Me.cm_AlterPayment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_i_BounceCheck, Me.cm_i_MovePayment})
            Me.cm_AlterPayment.Name = "cm_BounceCheck"
            Me.cm_AlterPayment.Size = New System.Drawing.Size(155, 48)
            '
            'cm_i_BounceCheck
            '
            Me.cm_i_BounceCheck.Name = "cm_i_BounceCheck"
            Me.cm_i_BounceCheck.Size = New System.Drawing.Size(154, 22)
            Me.cm_i_BounceCheck.Text = "Bounce Check"
            '
            'cm_i_MovePayment
            '
            Me.cm_i_MovePayment.Name = "cm_i_MovePayment"
            Me.cm_i_MovePayment.Size = New System.Drawing.Size(154, 22)
            Me.cm_i_MovePayment.Text = "Move Payment"
            '
            'PaymentHistoryDisplayBindingSource
            '
            Me.PaymentHistoryDisplayBindingSource.DataMember = "PaymentHistory_Display"
            Me.PaymentHistoryDisplayBindingSource.DataSource = Me.Ds_Payments
            '
            'Ds_Payments
            '
            Me.Ds_Payments.DataSetName = "ds_Payments"
            Me.Ds_Payments.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'pnl_Filter
            '
            Me.pnl_Filter.Controls.Add(Me.ck_All)
            Me.pnl_Filter.Controls.Add(Me.Label2)
            Me.pnl_Filter.Controls.Add(Me.dtp_EndDate)
            Me.pnl_Filter.Controls.Add(Me.Label1)
            Me.pnl_Filter.Controls.Add(Me.dtp_StartDate)
            Me.pnl_Filter.Controls.Add(Me.lbl_DateFilter)
            Me.pnl_Filter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_Filter.Location = New System.Drawing.Point(0, 53)
            Me.pnl_Filter.Name = "pnl_Filter"
            Me.pnl_Filter.Size = New System.Drawing.Size(869, 64)
            Me.pnl_Filter.TabIndex = 17
            '
         'ck_All
            '
            Me.ck_All.AutoSize = True
            Me.ck_All.Location = New System.Drawing.Point(513, 31)
            Me.ck_All.Name = "ck_All"
            Me.ck_All.Size = New System.Drawing.Size(37, 17)
            Me.ck_All.TabIndex = 9
            Me.ck_All.Text = "All"
            Me.ck_All.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(334, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(46, 13)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Method:"
            '
            'dtp_EndDate
            '
            Me.dtp_EndDate.Location = New System.Drawing.Point(513, 3)
            Me.dtp_EndDate.Name = "dtp_EndDate"
            Me.dtp_EndDate.Size = New System.Drawing.Size(200, 20)
            Me.dtp_EndDate.TabIndex = 3
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(482, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(25, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "and"
            '
            'dtp_StartDate
            '
            Me.dtp_StartDate.Location = New System.Drawing.Point(276, 3)
            Me.dtp_StartDate.Name = "dtp_StartDate"
            Me.dtp_StartDate.Size = New System.Drawing.Size(200, 20)
            Me.dtp_StartDate.TabIndex = 1
            '
            'lbl_DateFilter
            '
            Me.lbl_DateFilter.AutoSize = True
            Me.lbl_DateFilter.Location = New System.Drawing.Point(169, 5)
            Me.lbl_DateFilter.Name = "lbl_DateFilter"
            Me.lbl_DateFilter.Size = New System.Drawing.Size(101, 13)
            Me.lbl_DateFilter.TabIndex = 0
            Me.lbl_DateFilter.Text = "Received Between:"
            '
            'PaymentHistory_DisplayTableAdapter
            '
            Me.PaymentHistory_DisplayTableAdapter.ClearBeforeFill = True
            '
            'CustomerToolstrip1
            '
            Me.CustomerToolstrip1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CustomerToolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.CustomerToolstrip1.Location = New System.Drawing.Point(0, 0)
            Me.CustomerToolstrip1.Name = "CustomerToolstrip1"
            Me.CustomerToolstrip1.Size = New System.Drawing.Size(827, 31)
            Me.CustomerToolstrip1.TabIndex = 0
            Me.CustomerToolstrip1.Text = "CustomerToolstrip1"
            '
            'AdminPayments
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(869, 458)
            Me.Controls.Add(Me.dg_PaymentHistory)
            Me.Controls.Add(Me.pnl_Filter)
            Me.Controls.Add(Me.pnl_Top)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AdminPayments"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Payment History"
            Me.pnl_Top.ResumeLayout(False)
            Me.pnl_TopContent.ResumeLayout(False)
            Me.pnl_TopContent.PerformLayout()
            CType(Me.dg_PaymentHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cm_AlterPayment.ResumeLayout(False)
            CType(Me.PaymentHistoryDisplayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Payments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_Filter.ResumeLayout(False)
            Me.pnl_Filter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pnl_Top As System.Windows.Forms.Panel
        Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
        Friend WithEvents dg_PaymentHistory As System.Windows.Forms.DataGridView
        Friend WithEvents pnl_Filter As System.Windows.Forms.Panel
        Friend WithEvents ck_All As System.Windows.Forms.CheckBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lbl_DateFilter As System.Windows.Forms.Label
        Friend WithEvents cm_AlterPayment As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents cm_i_BounceCheck As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents cm_i_MovePayment As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents PaymentTypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RefNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DateReceivedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InsertedByUserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaymentHistoryDisplayBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Ds_Payments As TrashCash.ds_Payments
        Friend WithEvents PaymentHistory_DisplayTableAdapter As TrashCash.ds_PaymentsTableAdapters.PaymentHistory_DisplayTableAdapter
 Friend WithEvents CustomerToolstrip1 As TrashCash.Classes.CustomerToolstrip.CustomerToolstrip
    End Class
End Namespace