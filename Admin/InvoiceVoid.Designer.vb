<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceVoid
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dg_RecServices = New System.Windows.Forms.DataGridView()
        Me.CustomerNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceRateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.lbl_RecGridInfo = New System.Windows.Forms.Label()
        Me.pnl_RecBtm = New System.Windows.Forms.Panel()
        Me.btn_RecFetch = New System.Windows.Forms.Button()
        Me.lbl_InvNum = New System.Windows.Forms.Label()
        Me.tb_InvNum = New System.Windows.Forms.TextBox()
        Me.grp_InvInfo = New System.Windows.Forms.GroupBox()
        Me.dtp_EndBilling = New System.Windows.Forms.DateTimePicker()
        Me.lbl_EndBilling = New System.Windows.Forms.Label()
        Me.dtp_StartBill = New System.Windows.Forms.DateTimePicker()
        Me.lbl_StartBill = New System.Windows.Forms.Label()
        Me.btn_RecVoid = New System.Windows.Forms.Button()
        Me.lbl_Balance = New System.Windows.Forms.Label()
        Me.tb_Balance = New System.Windows.Forms.TextBox()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.tb_Total = New System.Windows.Forms.TextBox()
        Me.btn_RecReset = New System.Windows.Forms.Button()
        Me.RecurringServiceTableAdapter = New TrashCash.DataSetTableAdapters.RecurringServiceTableAdapter()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tc_InvType = New System.Windows.Forms.TabControl()
        Me.tc_p_RecSrvInv = New System.Windows.Forms.TabPage()
        Me.pnl_MasterBottom = New System.Windows.Forms.Panel()
        CType(Me.dg_RecServices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecurringServiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_RecBtm.SuspendLayout()
        Me.grp_InvInfo.SuspendLayout()
        Me.tc_InvType.SuspendLayout()
        Me.tc_p_RecSrvInv.SuspendLayout()
        Me.pnl_MasterBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_RecServices
        '
        Me.dg_RecServices.AllowUserToAddRows = False
        Me.dg_RecServices.AllowUserToDeleteRows = False
        Me.dg_RecServices.AutoGenerateColumns = False
        Me.dg_RecServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_RecServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNumberDataGridViewTextBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn, Me.ServiceNameDataGridViewTextBoxColumn, Me.RecurringServiceRateDataGridViewTextBoxColumn, Me.RecurringServiceQuantityDataGridViewTextBoxColumn, Me.RecurringServiceStartDateDataGridViewTextBoxColumn, Me.RecurringServiceEndDateDataGridViewTextBoxColumn})
        Me.dg_RecServices.DataSource = Me.RecurringServiceBindingSource
        Me.dg_RecServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_RecServices.Location = New System.Drawing.Point(0, 0)
        Me.dg_RecServices.Name = "dg_RecServices"
        Me.dg_RecServices.ReadOnly = True
        Me.dg_RecServices.RowHeadersVisible = False
        Me.dg_RecServices.Size = New System.Drawing.Size(786, 141)
        Me.dg_RecServices.TabIndex = 3
        '
        'CustomerNumberDataGridViewTextBoxColumn
        '
        Me.CustomerNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerNumber"
        Me.CustomerNumberDataGridViewTextBoxColumn.HeaderText = "Customer #"
        Me.CustomerNumberDataGridViewTextBoxColumn.Name = "CustomerNumberDataGridViewTextBoxColumn"
        Me.CustomerNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ServiceNameDataGridViewTextBoxColumn
        '
        Me.ServiceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
        Me.ServiceNameDataGridViewTextBoxColumn.HeaderText = "Service"
        Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
        Me.ServiceNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.ServiceNameDataGridViewTextBoxColumn.Width = 68
        '
        'RecurringServiceRateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceRateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceRate"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.RecurringServiceRateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.RecurringServiceRateDataGridViewTextBoxColumn.HeaderText = "Rate"
        Me.RecurringServiceRateDataGridViewTextBoxColumn.Name = "RecurringServiceRateDataGridViewTextBoxColumn"
        Me.RecurringServiceRateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RecurringServiceQuantityDataGridViewTextBoxColumn
        '
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceQuantity"
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.Name = "RecurringServiceQuantityDataGridViewTextBoxColumn"
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RecurringServiceStartDateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceStartDate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.Name = "RecurringServiceStartDateDataGridViewTextBoxColumn"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RecurringServiceEndDateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceEndDate"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.HeaderText = "End Date"
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.Name = "RecurringServiceEndDateDataGridViewTextBoxColumn"
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RecurringServiceBindingSource
        '
        Me.RecurringServiceBindingSource.DataMember = "RecurringService"
        Me.RecurringServiceBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbl_RecGridInfo
        '
        Me.lbl_RecGridInfo.Location = New System.Drawing.Point(2, 193)
        Me.lbl_RecGridInfo.Name = "lbl_RecGridInfo"
        Me.lbl_RecGridInfo.Size = New System.Drawing.Size(786, 32)
        Me.lbl_RecGridInfo.TabIndex = 4
        Me.lbl_RecGridInfo.Text = "These are the Recurring Service(s) used to create this Invoice and is for refrenc" & _
    "e only. If you need to change any of the Recurring Service details, you can do s" & _
    "o at any time from the Home screen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl_RecGridInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnl_RecBtm
        '
        Me.pnl_RecBtm.Controls.Add(Me.dg_RecServices)
        Me.pnl_RecBtm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_RecBtm.Location = New System.Drawing.Point(3, 232)
        Me.pnl_RecBtm.Name = "pnl_RecBtm"
        Me.pnl_RecBtm.Size = New System.Drawing.Size(786, 141)
        Me.pnl_RecBtm.TabIndex = 5
        '
        'btn_RecFetch
        '
        Me.btn_RecFetch.Location = New System.Drawing.Point(398, 11)
        Me.btn_RecFetch.Name = "btn_RecFetch"
        Me.btn_RecFetch.Size = New System.Drawing.Size(75, 23)
        Me.btn_RecFetch.TabIndex = 2
        Me.btn_RecFetch.Text = "Fetch Info"
        Me.btn_RecFetch.UseVisualStyleBackColor = True
        '
        'lbl_InvNum
        '
        Me.lbl_InvNum.AutoSize = True
        Me.lbl_InvNum.Location = New System.Drawing.Point(201, 16)
        Me.lbl_InvNum.Name = "lbl_InvNum"
        Me.lbl_InvNum.Size = New System.Drawing.Size(85, 13)
        Me.lbl_InvNum.TabIndex = 1
        Me.lbl_InvNum.Text = "Invoice Number:"
        '
        'tb_InvNum
        '
        Me.tb_InvNum.Location = New System.Drawing.Point(292, 13)
        Me.tb_InvNum.Name = "tb_InvNum"
        Me.tb_InvNum.Size = New System.Drawing.Size(100, 20)
        Me.tb_InvNum.TabIndex = 0
        '
        'grp_InvInfo
        '
        Me.grp_InvInfo.Controls.Add(Me.dtp_EndBilling)
        Me.grp_InvInfo.Controls.Add(Me.lbl_EndBilling)
        Me.grp_InvInfo.Controls.Add(Me.dtp_StartBill)
        Me.grp_InvInfo.Controls.Add(Me.lbl_StartBill)
        Me.grp_InvInfo.Controls.Add(Me.btn_RecVoid)
        Me.grp_InvInfo.Controls.Add(Me.lbl_Balance)
        Me.grp_InvInfo.Controls.Add(Me.tb_Balance)
        Me.grp_InvInfo.Controls.Add(Me.lbl_Total)
        Me.grp_InvInfo.Controls.Add(Me.tb_Total)
        Me.grp_InvInfo.Location = New System.Drawing.Point(191, 48)
        Me.grp_InvInfo.Name = "grp_InvInfo"
        Me.grp_InvInfo.Size = New System.Drawing.Size(373, 132)
        Me.grp_InvInfo.TabIndex = 6
        Me.grp_InvInfo.TabStop = False
        Me.grp_InvInfo.Text = "Invoice Information"
        Me.grp_InvInfo.Visible = False
        '
        'dtp_EndBilling
        '
        Me.dtp_EndBilling.Enabled = False
        Me.dtp_EndBilling.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_EndBilling.Location = New System.Drawing.Point(111, 61)
        Me.dtp_EndBilling.Name = "dtp_EndBilling"
        Me.dtp_EndBilling.Size = New System.Drawing.Size(79, 20)
        Me.dtp_EndBilling.TabIndex = 13
        '
        'lbl_EndBilling
        '
        Me.lbl_EndBilling.AutoSize = True
        Me.lbl_EndBilling.Location = New System.Drawing.Point(10, 64)
        Me.lbl_EndBilling.Name = "lbl_EndBilling"
        Me.lbl_EndBilling.Size = New System.Drawing.Size(92, 13)
        Me.lbl_EndBilling.TabIndex = 12
        Me.lbl_EndBilling.Text = "End Billing Period:"
        '
        'dtp_StartBill
        '
        Me.dtp_StartBill.Enabled = False
        Me.dtp_StartBill.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_StartBill.Location = New System.Drawing.Point(111, 31)
        Me.dtp_StartBill.Name = "dtp_StartBill"
        Me.dtp_StartBill.Size = New System.Drawing.Size(79, 20)
        Me.dtp_StartBill.TabIndex = 11
        '
        'lbl_StartBill
        '
        Me.lbl_StartBill.AutoSize = True
        Me.lbl_StartBill.Location = New System.Drawing.Point(10, 34)
        Me.lbl_StartBill.Name = "lbl_StartBill"
        Me.lbl_StartBill.Size = New System.Drawing.Size(95, 13)
        Me.lbl_StartBill.TabIndex = 10
        Me.lbl_StartBill.Text = "Start Billing Period:"
        '
        'btn_RecVoid
        '
        Me.btn_RecVoid.AutoSize = True
        Me.btn_RecVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecVoid.ForeColor = System.Drawing.Color.Red
        Me.btn_RecVoid.Location = New System.Drawing.Point(145, 94)
        Me.btn_RecVoid.Name = "btn_RecVoid"
        Me.btn_RecVoid.Size = New System.Drawing.Size(100, 23)
        Me.btn_RecVoid.TabIndex = 7
        Me.btn_RecVoid.Text = "Void Invoice"
        Me.btn_RecVoid.UseVisualStyleBackColor = True
        '
        'lbl_Balance
        '
        Me.lbl_Balance.AutoSize = True
        Me.lbl_Balance.Location = New System.Drawing.Point(196, 60)
        Me.lbl_Balance.Name = "lbl_Balance"
        Me.lbl_Balance.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Balance.TabIndex = 9
        Me.lbl_Balance.Text = "Balance:"
        '
        'tb_Balance
        '
        Me.tb_Balance.Enabled = False
        Me.tb_Balance.Location = New System.Drawing.Point(251, 57)
        Me.tb_Balance.Name = "tb_Balance"
        Me.tb_Balance.ReadOnly = True
        Me.tb_Balance.Size = New System.Drawing.Size(100, 20)
        Me.tb_Balance.TabIndex = 8
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Location = New System.Drawing.Point(211, 34)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(34, 13)
        Me.lbl_Total.TabIndex = 7
        Me.lbl_Total.Text = "Total:"
        '
        'tb_Total
        '
        Me.tb_Total.Enabled = False
        Me.tb_Total.Location = New System.Drawing.Point(251, 31)
        Me.tb_Total.Name = "tb_Total"
        Me.tb_Total.ReadOnly = True
        Me.tb_Total.Size = New System.Drawing.Size(100, 20)
        Me.tb_Total.TabIndex = 6
        '
        'btn_RecReset
        '
        Me.btn_RecReset.Location = New System.Drawing.Point(479, 11)
        Me.btn_RecReset.Name = "btn_RecReset"
        Me.btn_RecReset.Size = New System.Drawing.Size(75, 23)
        Me.btn_RecReset.TabIndex = 7
        Me.btn_RecReset.Text = "Reset Form"
        Me.btn_RecReset.UseVisualStyleBackColor = True
        Me.btn_RecReset.Visible = False
        '
        'RecurringServiceTableAdapter
        '
        Me.RecurringServiceTableAdapter.ClearBeforeFill = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CustomerNumber"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Customer #"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CustomerFullName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ServiceName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Service"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "RecurringServiceRate"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "RecurringServiceQuantity"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "RecurringServiceStartDate"
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn6.HeaderText = "Start Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "RecurringServiceEndDate"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn7.HeaderText = "End Date"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'tc_InvType
        '
        Me.tc_InvType.Controls.Add(Me.tc_p_RecSrvInv)
        Me.tc_InvType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_InvType.Location = New System.Drawing.Point(0, 0)
        Me.tc_InvType.Name = "tc_InvType"
        Me.tc_InvType.SelectedIndex = 0
        Me.tc_InvType.Size = New System.Drawing.Size(800, 402)
        Me.tc_InvType.TabIndex = 8
        '
        'tc_p_RecSrvInv
        '
        Me.tc_p_RecSrvInv.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_RecSrvInv.Controls.Add(Me.lbl_InvNum)
        Me.tc_p_RecSrvInv.Controls.Add(Me.pnl_RecBtm)
        Me.tc_p_RecSrvInv.Controls.Add(Me.btn_RecReset)
        Me.tc_p_RecSrvInv.Controls.Add(Me.tb_InvNum)
        Me.tc_p_RecSrvInv.Controls.Add(Me.grp_InvInfo)
        Me.tc_p_RecSrvInv.Controls.Add(Me.btn_RecFetch)
        Me.tc_p_RecSrvInv.Controls.Add(Me.lbl_RecGridInfo)
        Me.tc_p_RecSrvInv.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_RecSrvInv.Name = "tc_p_RecSrvInv"
        Me.tc_p_RecSrvInv.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_RecSrvInv.Size = New System.Drawing.Size(792, 376)
        Me.tc_p_RecSrvInv.TabIndex = 0
        Me.tc_p_RecSrvInv.Text = "Recurring Service Invoice"
        '
        'pnl_MasterBottom
        '
        Me.pnl_MasterBottom.Controls.Add(Me.tc_InvType)
        Me.pnl_MasterBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_MasterBottom.Location = New System.Drawing.Point(0, 9)
        Me.pnl_MasterBottom.Name = "pnl_MasterBottom"
        Me.pnl_MasterBottom.Size = New System.Drawing.Size(800, 402)
        Me.pnl_MasterBottom.TabIndex = 9
        '
        'InvoiceVoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 411)
        Me.Controls.Add(Me.pnl_MasterBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InvoiceVoid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice Void"
        CType(Me.dg_RecServices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecurringServiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_RecBtm.ResumeLayout(False)
        Me.grp_InvInfo.ResumeLayout(False)
        Me.grp_InvInfo.PerformLayout()
        Me.tc_InvType.ResumeLayout(False)
        Me.tc_p_RecSrvInv.ResumeLayout(False)
        Me.tc_p_RecSrvInv.PerformLayout()
        Me.pnl_MasterBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg_RecServices As System.Windows.Forms.DataGridView
    Friend WithEvents RecurringServiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents RecurringServiceTableAdapter As TrashCash.DataSetTableAdapters.RecurringServiceTableAdapter
    Friend WithEvents CustomerNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceRateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceStartDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceEndDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_RecGridInfo As System.Windows.Forms.Label
    Friend WithEvents pnl_RecBtm As System.Windows.Forms.Panel
    Friend WithEvents btn_RecFetch As System.Windows.Forms.Button
    Friend WithEvents lbl_InvNum As System.Windows.Forms.Label
    Friend WithEvents tb_InvNum As System.Windows.Forms.TextBox
    Friend WithEvents grp_InvInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btn_RecVoid As System.Windows.Forms.Button
    Friend WithEvents lbl_Balance As System.Windows.Forms.Label
    Friend WithEvents tb_Balance As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents tb_Total As System.Windows.Forms.TextBox
    Friend WithEvents btn_RecReset As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tc_InvType As System.Windows.Forms.TabControl
    Friend WithEvents tc_p_RecSrvInv As System.Windows.Forms.TabPage
    Friend WithEvents pnl_MasterBottom As System.Windows.Forms.Panel
    Friend WithEvents dtp_EndBilling As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_EndBilling As System.Windows.Forms.Label
    Friend WithEvents dtp_StartBill As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_StartBill As System.Windows.Forms.Label
End Class
