Namespace Types
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminServiceTypes
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
            Me.ServiceTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ds_Types = New TrashCash.ds_Types()
            Me.ServiceTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter()
            Me.lbl_FormInfo = New System.Windows.Forms.Label()
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
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.tb_Name = New System.Windows.Forms.TextBox()
            Me.lbl_SrvcName = New System.Windows.Forms.Label()
            Me.cmb_QBAcc = New System.Windows.Forms.ComboBox()
            Me.lbl_Acc = New System.Windows.Forms.Label()
            Me.tb_Rate = New TrashCash.Classes.CurrencyTextBox()
            Me.lbl_Rate = New System.Windows.Forms.Label()
            Me.nud_BillLen = New System.Windows.Forms.NumericUpDown()
            Me.lbl_BillLen = New System.Windows.Forms.Label()
            Me.ServiceTypeIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceListIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceEditSequenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceRateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceBillLengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tb_Desc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btn_AddItem = New System.Windows.Forms.Button()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nud_BillLen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ServiceTypesBindingSource
            '
            Me.ServiceTypesBindingSource.DataMember = "ServiceTypes"
            Me.ServiceTypesBindingSource.DataSource = Me.ds_Types
            '
            'ds_Types
            '
            Me.ds_Types.DataSetName = "ds_Types"
            Me.ds_Types.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ServiceTypesTableAdapter
            '
            Me.ServiceTypesTableAdapter.ClearBeforeFill = True
            '
            'lbl_FormInfo
            '
            Me.lbl_FormInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_FormInfo.Location = New System.Drawing.Point(0, 0)
            Me.lbl_FormInfo.Name = "lbl_FormInfo"
            Me.lbl_FormInfo.Size = New System.Drawing.Size(832, 21)
            Me.lbl_FormInfo.TabIndex = 2
            Me.lbl_FormInfo.Text = "You can add and view exisiting Quickbooks items used for Service Types."
            Me.lbl_FormInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "ServiceName"
            Me.DataGridViewTextBoxColumn1.HeaderText = "Service Name"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "ServiceRate"
            Me.DataGridViewTextBoxColumn2.HeaderText = "Service Rate"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "ServiceDescription"
            Me.DataGridViewTextBoxColumn3.HeaderText = "Service Description"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "ServiceBillLength"
            Me.DataGridViewTextBoxColumn4.HeaderText = "Service Bill Length"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "ServiceTypeID"
            Me.DataGridViewTextBoxColumn5.HeaderText = "ServiceTypeID"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "ServiceName"
            Me.DataGridViewTextBoxColumn6.HeaderText = "ServiceName"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "ServiceListID"
            Me.DataGridViewTextBoxColumn7.HeaderText = "ServiceListID"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "ServiceEditSequence"
            Me.DataGridViewTextBoxColumn8.HeaderText = "ServiceEditSequence"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "ServiceRate"
            Me.DataGridViewTextBoxColumn9.HeaderText = "ServiceRate"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "ServiceDescription"
            Me.DataGridViewTextBoxColumn10.HeaderText = "ServiceDescription"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "ServiceBillLength"
            Me.DataGridViewTextBoxColumn11.HeaderText = "ServiceBillLength"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            '
            'DataGridView1
            '
            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.AllowUserToDeleteRows = False
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceTypeIDDataGridViewTextBoxColumn, Me.ServiceNameDataGridViewTextBoxColumn, Me.ServiceListIDDataGridViewTextBoxColumn, Me.ServiceEditSequenceDataGridViewTextBoxColumn, Me.ServiceRateDataGridViewTextBoxColumn, Me.ServiceDescriptionDataGridViewTextBoxColumn, Me.ServiceBillLengthDataGridViewTextBoxColumn})
            Me.DataGridView1.DataSource = Me.ServiceTypesBindingSource
            Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.DataGridView1.Location = New System.Drawing.Point(0, 149)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.ReadOnly = True
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.Size = New System.Drawing.Size(832, 198)
            Me.DataGridView1.TabIndex = 3
            '
            'tb_Name
            '
            Me.tb_Name.Location = New System.Drawing.Point(25, 60)
            Me.tb_Name.Name = "tb_Name"
            Me.tb_Name.Size = New System.Drawing.Size(100, 20)
            Me.tb_Name.TabIndex = 4
            '
            'lbl_SrvcName
            '
            Me.lbl_SrvcName.AutoSize = True
            Me.lbl_SrvcName.Location = New System.Drawing.Point(35, 44)
            Me.lbl_SrvcName.Name = "lbl_SrvcName"
            Me.lbl_SrvcName.Size = New System.Drawing.Size(74, 13)
            Me.lbl_SrvcName.TabIndex = 5
            Me.lbl_SrvcName.Text = "Service Name"
            '
            'cmb_QBAcc
            '
            Me.cmb_QBAcc.FormattingEnabled = True
            Me.cmb_QBAcc.Location = New System.Drawing.Point(144, 60)
            Me.cmb_QBAcc.Name = "cmb_QBAcc"
            Me.cmb_QBAcc.Size = New System.Drawing.Size(164, 21)
            Me.cmb_QBAcc.TabIndex = 6
            '
            'lbl_Acc
            '
            Me.lbl_Acc.AutoSize = True
            Me.lbl_Acc.Location = New System.Drawing.Point(176, 44)
            Me.lbl_Acc.Name = "lbl_Acc"
            Me.lbl_Acc.Size = New System.Drawing.Size(107, 13)
            Me.lbl_Acc.TabIndex = 7
            Me.lbl_Acc.Text = "Quickbooks Account"
            '
            'tb_Rate
            '
            Me.tb_Rate.Location = New System.Drawing.Point(322, 60)
            Me.tb_Rate.Name = "tb_Rate"
            Me.tb_Rate.Size = New System.Drawing.Size(100, 20)
            Me.tb_Rate.TabIndex = 8
            '
            'lbl_Rate
            '
            Me.lbl_Rate.AutoSize = True
            Me.lbl_Rate.Location = New System.Drawing.Point(338, 44)
            Me.lbl_Rate.Name = "lbl_Rate"
            Me.lbl_Rate.Size = New System.Drawing.Size(67, 13)
            Me.lbl_Rate.TabIndex = 9
            Me.lbl_Rate.Text = "Default Rate"
            '
            'nud_BillLen
            '
            Me.nud_BillLen.Location = New System.Drawing.Point(467, 61)
            Me.nud_BillLen.Name = "nud_BillLen"
            Me.nud_BillLen.Size = New System.Drawing.Size(29, 20)
            Me.nud_BillLen.TabIndex = 10
            Me.nud_BillLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.nud_BillLen.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'lbl_BillLen
            '
            Me.lbl_BillLen.AutoSize = True
            Me.lbl_BillLen.Location = New System.Drawing.Point(441, 44)
            Me.lbl_BillLen.Name = "lbl_BillLen"
            Me.lbl_BillLen.Size = New System.Drawing.Size(93, 13)
            Me.lbl_BillLen.TabIndex = 11
            Me.lbl_BillLen.Text = "Default Bill Length"
            '
            'ServiceTypeIDDataGridViewTextBoxColumn
            '
            Me.ServiceTypeIDDataGridViewTextBoxColumn.DataPropertyName = "ServiceTypeID"
            Me.ServiceTypeIDDataGridViewTextBoxColumn.HeaderText = "ServiceTypeID"
            Me.ServiceTypeIDDataGridViewTextBoxColumn.Name = "ServiceTypeIDDataGridViewTextBoxColumn"
            Me.ServiceTypeIDDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceTypeIDDataGridViewTextBoxColumn.Width = 103
            '
            'ServiceNameDataGridViewTextBoxColumn
            '
            Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
            Me.ServiceNameDataGridViewTextBoxColumn.HeaderText = "ServiceName"
            Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
            Me.ServiceNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceNameDataGridViewTextBoxColumn.Width = 96
            '
            'ServiceListIDDataGridViewTextBoxColumn
            '
            Me.ServiceListIDDataGridViewTextBoxColumn.DataPropertyName = "ServiceListID"
            Me.ServiceListIDDataGridViewTextBoxColumn.HeaderText = "ServiceListID"
            Me.ServiceListIDDataGridViewTextBoxColumn.Name = "ServiceListIDDataGridViewTextBoxColumn"
            Me.ServiceListIDDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceListIDDataGridViewTextBoxColumn.Width = 95
            '
            'ServiceEditSequenceDataGridViewTextBoxColumn
            '
            Me.ServiceEditSequenceDataGridViewTextBoxColumn.DataPropertyName = "ServiceEditSequence"
            Me.ServiceEditSequenceDataGridViewTextBoxColumn.HeaderText = "ServiceEditSequence"
            Me.ServiceEditSequenceDataGridViewTextBoxColumn.Name = "ServiceEditSequenceDataGridViewTextBoxColumn"
            Me.ServiceEditSequenceDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceEditSequenceDataGridViewTextBoxColumn.Width = 135
            '
            'ServiceRateDataGridViewTextBoxColumn
            '
            Me.ServiceRateDataGridViewTextBoxColumn.DataPropertyName = "ServiceRate"
            Me.ServiceRateDataGridViewTextBoxColumn.HeaderText = "ServiceRate"
            Me.ServiceRateDataGridViewTextBoxColumn.Name = "ServiceRateDataGridViewTextBoxColumn"
            Me.ServiceRateDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceRateDataGridViewTextBoxColumn.Width = 91
            '
            'ServiceDescriptionDataGridViewTextBoxColumn
            '
            Me.ServiceDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ServiceDescription"
            Me.ServiceDescriptionDataGridViewTextBoxColumn.HeaderText = "ServiceDescription"
            Me.ServiceDescriptionDataGridViewTextBoxColumn.Name = "ServiceDescriptionDataGridViewTextBoxColumn"
            Me.ServiceDescriptionDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceDescriptionDataGridViewTextBoxColumn.Width = 121
            '
            'ServiceBillLengthDataGridViewTextBoxColumn
            '
            Me.ServiceBillLengthDataGridViewTextBoxColumn.DataPropertyName = "ServiceBillLength"
            Me.ServiceBillLengthDataGridViewTextBoxColumn.HeaderText = "ServiceBillLength"
            Me.ServiceBillLengthDataGridViewTextBoxColumn.Name = "ServiceBillLengthDataGridViewTextBoxColumn"
            Me.ServiceBillLengthDataGridViewTextBoxColumn.ReadOnly = True
            Me.ServiceBillLengthDataGridViewTextBoxColumn.Width = 114
            '
            'tb_Desc
            '
            Me.tb_Desc.Location = New System.Drawing.Point(542, 60)
            Me.tb_Desc.Multiline = True
            Me.tb_Desc.Name = "tb_Desc"
            Me.tb_Desc.Size = New System.Drawing.Size(162, 49)
            Me.tb_Desc.TabIndex = 12
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(573, 44)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(100, 13)
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "Generic Description"
            '
            'btn_AddItem
            '
            Me.btn_AddItem.Location = New System.Drawing.Point(733, 61)
            Me.btn_AddItem.Name = "btn_AddItem"
            Me.btn_AddItem.Size = New System.Drawing.Size(75, 48)
            Me.btn_AddItem.TabIndex = 14
            Me.btn_AddItem.Text = "Add Item"
            Me.btn_AddItem.UseVisualStyleBackColor = True
            '
            'AdminServiceTypes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(832, 347)
            Me.Controls.Add(Me.btn_AddItem)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.tb_Desc)
            Me.Controls.Add(Me.lbl_BillLen)
            Me.Controls.Add(Me.nud_BillLen)
            Me.Controls.Add(Me.lbl_Rate)
            Me.Controls.Add(Me.tb_Rate)
            Me.Controls.Add(Me.lbl_Acc)
            Me.Controls.Add(Me.cmb_QBAcc)
            Me.Controls.Add(Me.lbl_SrvcName)
            Me.Controls.Add(Me.tb_Name)
            Me.Controls.Add(Me.DataGridView1)
            Me.Controls.Add(Me.lbl_FormInfo)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AdminServiceTypes"
            Me.Text = "Service Types"
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nud_BillLen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ds_Types As TrashCash.ds_Types
        Friend WithEvents ServiceTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ServiceTypesTableAdapter As TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter
        Friend WithEvents lbl_FormInfo As System.Windows.Forms.Label
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
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents tb_Name As System.Windows.Forms.TextBox
        Friend WithEvents ServiceTypeIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceListIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceEditSequenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceRateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceBillLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lbl_SrvcName As System.Windows.Forms.Label
        Friend WithEvents cmb_QBAcc As System.Windows.Forms.ComboBox
        Friend WithEvents lbl_Acc As System.Windows.Forms.Label
        Friend WithEvents tb_Rate As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents lbl_Rate As System.Windows.Forms.Label
        Friend WithEvents nud_BillLen As System.Windows.Forms.NumericUpDown
        Friend WithEvents lbl_BillLen As System.Windows.Forms.Label
        Friend WithEvents tb_Desc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btn_AddItem As System.Windows.Forms.Button
    End Class
End Namespace