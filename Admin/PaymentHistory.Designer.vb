﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentHistory))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_TopContent = New System.Windows.Forms.Panel()
        Me.Ts_M_Customer = New TrashCash.ts_M_Customer()
        Me.dg_PaymentHistory = New System.Windows.Forms.DataGridView()
        Me.PaymentTypeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateReceivedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm_BounceCheck = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cm_i_BouncedCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.PaymentHistoryTableAdapter = New TrashCash.DataSetTableAdapters.PaymentHistoryTableAdapter()
        Me.pnl_Filter = New System.Windows.Forms.Panel()
        Me.Cmb_PaymentTypes = New TrashCash.Database_ComboBoxes.cmb_PaymentTypes()
        Me.ck_All = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_DateFilter = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnl_Top.SuspendLayout()
        Me.pnl_TopContent.SuspendLayout()
        CType(Me.dg_PaymentHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm_BounceCheck.SuspendLayout()
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnl_TopContent.Controls.Add(Me.Ts_M_Customer)
        Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
        Me.pnl_TopContent.Name = "pnl_TopContent"
        Me.pnl_TopContent.Size = New System.Drawing.Size(829, 33)
        Me.pnl_TopContent.TabIndex = 14
        '
        'Ts_M_Customer
        '
        Me.Ts_M_Customer.CurrentCustomer = 0
        Me.Ts_M_Customer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ts_M_Customer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Ts_M_Customer.Location = New System.Drawing.Point(0, 0)
        Me.Ts_M_Customer.Name = "Ts_M_Customer"
        Me.Ts_M_Customer.Size = New System.Drawing.Size(827, 31)
        Me.Ts_M_Customer.TabIndex = 0
        Me.Ts_M_Customer.Text = "Ts_M_Customer1"
        '
        'dg_PaymentHistory
        '
        Me.dg_PaymentHistory.AllowUserToAddRows = False
        Me.dg_PaymentHistory.AllowUserToDeleteRows = False
        Me.dg_PaymentHistory.AutoGenerateColumns = False
        Me.dg_PaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_PaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_PaymentHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PaymentTypeNameDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.DateReceivedDataGridViewTextBoxColumn, Me.RefNumber})
        Me.dg_PaymentHistory.ContextMenuStrip = Me.cm_BounceCheck
        Me.dg_PaymentHistory.DataSource = Me.PaymentHistoryBindingSource
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
        Me.PaymentTypeNameDataGridViewTextBoxColumn.HeaderText = "Payment Method"
        Me.PaymentTypeNameDataGridViewTextBoxColumn.Name = "PaymentTypeNameDataGridViewTextBoxColumn"
        Me.PaymentTypeNameDataGridViewTextBoxColumn.ReadOnly = True
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
        'RefNumber
        '
        Me.RefNumber.DataPropertyName = "RefNumber"
        Me.RefNumber.HeaderText = "RefNumber"
        Me.RefNumber.Name = "RefNumber"
        Me.RefNumber.ReadOnly = True
        '
        'cm_BounceCheck
        '
        Me.cm_BounceCheck.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_i_BouncedCheck})
        Me.cm_BounceCheck.Name = "cm_BounceCheck"
        Me.cm_BounceCheck.Size = New System.Drawing.Size(158, 26)
        '
        'cm_i_BouncedCheck
        '
        Me.cm_i_BouncedCheck.Name = "cm_i_BouncedCheck"
        Me.cm_i_BouncedCheck.Size = New System.Drawing.Size(157, 22)
        Me.cm_i_BouncedCheck.Text = "Bounced Check"
        '
        'PaymentHistoryBindingSource
        '
        Me.PaymentHistoryBindingSource.DataMember = "PaymentHistory"
        Me.PaymentHistoryBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PaymentHistoryTableAdapter
        '
        Me.PaymentHistoryTableAdapter.ClearBeforeFill = True
        '
        'pnl_Filter
        '
        Me.pnl_Filter.Controls.Add(Me.Cmb_PaymentTypes)
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
        'Cmb_PaymentTypes
        '
        Me.Cmb_PaymentTypes.DisplayMember = "PaymentTypeName"
        Me.Cmb_PaymentTypes.FormattingEnabled = True
        Me.Cmb_PaymentTypes.Location = New System.Drawing.Point(386, 29)
        Me.Cmb_PaymentTypes.Name = "Cmb_PaymentTypes"
        Me.Cmb_PaymentTypes.Size = New System.Drawing.Size(121, 21)
        Me.Cmb_PaymentTypes.TabIndex = 11
        Me.Cmb_PaymentTypes.ValueMember = "PaymentTypeID"
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PaymentTypeName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Payment Method"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 217
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Amount"
        DataGridViewCellStyle3.Format = "C2"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 216
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DateReceived"
        DataGridViewCellStyle4.Format = "d"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.HeaderText = "Date Received"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 217
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "RefNumber"
        Me.DataGridViewTextBoxColumn4.HeaderText = "RefNumber"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 216
        '
        'PaymentHistory
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
        Me.Name = "PaymentHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment History"
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_TopContent.ResumeLayout(False)
        Me.pnl_TopContent.PerformLayout()
        CType(Me.dg_PaymentHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm_BounceCheck.ResumeLayout(False)
        CType(Me.PaymentHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Filter.ResumeLayout(False)
        Me.pnl_Filter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
    Friend WithEvents dg_PaymentHistory As System.Windows.Forms.DataGridView
    Friend WithEvents PaymentHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents PaymentHistoryTableAdapter As TrashCash.DataSetTableAdapters.PaymentHistoryTableAdapter
    Friend WithEvents pnl_Filter As System.Windows.Forms.Panel
    Friend WithEvents ck_All As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_DateFilter As System.Windows.Forms.Label
    Friend WithEvents cm_BounceCheck As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cm_i_BouncedCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ts_M_Customer As TrashCash.ts_M_Customer
    Friend WithEvents PaymentTypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateReceivedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cmb_PaymentTypes As TrashCash.Database_ComboBoxes.cmb_PaymentTypes
End Class
