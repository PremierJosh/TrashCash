Namespace Invoicing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CustomInvoicingForm
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
            Dim lbl_Addr1 As System.Windows.Forms.Label
            Dim lbl_Addr2 As System.Windows.Forms.Label
            Dim lbl_Addr3 As System.Windows.Forms.Label
            Dim lbl_CityState As System.Windows.Forms.Label
            Dim ZipLabel As System.Windows.Forms.Label
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
            Me.pnl_1 = New System.Windows.Forms.Panel()
            Me.pnl_TopContent = New System.Windows.Forms.Panel()
            Me.Ts_M_Customer = New TrashCash.ts_M_Customer()
            Me.pnl_2 = New System.Windows.Forms.Panel()
            Me.lbl_Rate = New System.Windows.Forms.Label()
            Me.tb_Rate = New TrashCash.Currency_TextBox()
            Me.lbl_LineType = New System.Windows.Forms.Label()
            Me.btn_AddLine = New System.Windows.Forms.Button()
            Me.cmb_LineTypes = New System.Windows.Forms.ComboBox()
            Me.CustomInvoiceLineTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Invoicing = New TrashCash.ds_Invoicing()
            Me.tb_DescText = New System.Windows.Forms.TextBox()
            Me.ck_Reminder = New System.Windows.Forms.CheckBox()
            Me.lbl_DescText = New System.Windows.Forms.Label()
            Me.lbl_DateOfSrvc = New System.Windows.Forms.Label()
            Me.grp_Address = New System.Windows.Forms.GroupBox()
            Me.tb_Addr1 = New System.Windows.Forms.TextBox()
            Me.tb_Addr2 = New System.Windows.Forms.TextBox()
            Me.tb_Addr3 = New System.Windows.Forms.TextBox()
            Me.tb_City = New System.Windows.Forms.TextBox()
            Me.tb_State = New System.Windows.Forms.TextBox()
            Me.lbl_RecentAddrs = New System.Windows.Forms.Label()
            Me.cmb_RecentAddr = New System.Windows.Forms.ComboBox()
            Me.CustomerRecentAddrsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.tb_Zip = New System.Windows.Forms.TextBox()
            Me.dtp_DateOfSrvc = New System.Windows.Forms.DateTimePicker()
            Me.pnl_3 = New System.Windows.Forms.Panel()
            Me.btn_CancelInv = New System.Windows.Forms.Button()
            Me.dg_LineItems = New System.Windows.Forms.DataGridView()
            Me.CITypeIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.RateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RenderedOnDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Addr1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DescTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CustomInvoiceLineItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.lbl_LineItems = New System.Windows.Forms.Label()
            Me.btn_CreateInv = New System.Windows.Forms.Button()
            Me.grp_InvDets = New System.Windows.Forms.GroupBox()
            Me.dtp_PostDate = New System.Windows.Forms.DateTimePicker()
            Me.dtp_DueDate = New System.Windows.Forms.DateTimePicker()
            Me.lbl_PostDate = New System.Windows.Forms.Label()
            Me.lbl_DueDate = New System.Windows.Forms.Label()
            Me.ck_Print = New System.Windows.Forms.CheckBox()
            Me.CustomInvoice_LineTypesTableAdapter = New TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter()
            Me.Customer_RecentAddrsTableAdapter = New TrashCash.ds_InvoicingTableAdapters.Customer_RecentAddrsTableAdapter()
            Me.TableAdapterManager = New TrashCash.ds_InvoicingTableAdapters.TableAdapterManager()
            Me.CustomInvoice_LineItemsTableAdapter = New TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineItemsTableAdapter()
            lbl_Addr1 = New System.Windows.Forms.Label()
            lbl_Addr2 = New System.Windows.Forms.Label()
            lbl_Addr3 = New System.Windows.Forms.Label()
            lbl_CityState = New System.Windows.Forms.Label()
            ZipLabel = New System.Windows.Forms.Label()
            Me.FlowLayoutPanel.SuspendLayout()
            Me.pnl_1.SuspendLayout()
            Me.pnl_TopContent.SuspendLayout()
            Me.pnl_2.SuspendLayout()
            CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Invoicing, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_Address.SuspendLayout()
            CType(Me.CustomerRecentAddrsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_3.SuspendLayout()
            CType(Me.dg_LineItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CustomInvoiceLineItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_InvDets.SuspendLayout()
            Me.SuspendLayout()
            '
            'lbl_Addr1
            '
            lbl_Addr1.AutoSize = True
            lbl_Addr1.Location = New System.Drawing.Point(10, 22)
            lbl_Addr1.Name = "lbl_Addr1"
            lbl_Addr1.Size = New System.Drawing.Size(57, 13)
            lbl_Addr1.TabIndex = 4
            lbl_Addr1.Text = "Address 1:"
            '
            'lbl_Addr2
            '
            lbl_Addr2.AutoSize = True
            lbl_Addr2.Location = New System.Drawing.Point(10, 48)
            lbl_Addr2.Name = "lbl_Addr2"
            lbl_Addr2.Size = New System.Drawing.Size(57, 13)
            lbl_Addr2.TabIndex = 6
            lbl_Addr2.Text = "Address 2:"
            '
            'lbl_Addr3
            '
            lbl_Addr3.AutoSize = True
            lbl_Addr3.Location = New System.Drawing.Point(10, 74)
            lbl_Addr3.Name = "lbl_Addr3"
            lbl_Addr3.Size = New System.Drawing.Size(57, 13)
            lbl_Addr3.TabIndex = 8
            lbl_Addr3.Text = "Address 3:"
            '
            'lbl_CityState
            '
            lbl_CityState.AutoSize = True
            lbl_CityState.Location = New System.Drawing.Point(10, 100)
            lbl_CityState.Name = "lbl_CityState"
            lbl_CityState.Size = New System.Drawing.Size(57, 13)
            lbl_CityState.TabIndex = 10
            lbl_CityState.Text = "City/State:"
            '
            'ZipLabel
            '
            ZipLabel.AutoSize = True
            ZipLabel.Location = New System.Drawing.Point(42, 127)
            ZipLabel.Name = "ZipLabel"
            ZipLabel.Size = New System.Drawing.Size(25, 13)
            ZipLabel.TabIndex = 14
            ZipLabel.Text = "Zip:"
            '
            'FlowLayoutPanel
            '
            Me.FlowLayoutPanel.Controls.Add(Me.pnl_1)
            Me.FlowLayoutPanel.Controls.Add(Me.pnl_2)
            Me.FlowLayoutPanel.Controls.Add(Me.pnl_3)
            Me.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.FlowLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
            Me.FlowLayoutPanel.Size = New System.Drawing.Size(855, 589)
            Me.FlowLayoutPanel.TabIndex = 0
            '
            'pnl_1
            '
            Me.pnl_1.Controls.Add(Me.pnl_TopContent)
            Me.pnl_1.Location = New System.Drawing.Point(3, 3)
            Me.pnl_1.Name = "pnl_1"
            Me.pnl_1.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
            Me.pnl_1.Size = New System.Drawing.Size(850, 53)
            Me.pnl_1.TabIndex = 98
            '
            'pnl_TopContent
            '
            Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TopContent.Controls.Add(Me.Ts_M_Customer)
            Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
            Me.pnl_TopContent.Name = "pnl_TopContent"
            Me.pnl_TopContent.Size = New System.Drawing.Size(810, 33)
            Me.pnl_TopContent.TabIndex = 2
            '
            'Ts_M_Customer
            '
            Me.Ts_M_Customer.CurrentCustomer = 0
            Me.Ts_M_Customer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Ts_M_Customer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.Ts_M_Customer.HomeForm = Nothing
            Me.Ts_M_Customer.Location = New System.Drawing.Point(0, 0)
            Me.Ts_M_Customer.Name = "Ts_M_Customer"
            Me.Ts_M_Customer.Size = New System.Drawing.Size(808, 31)
            Me.Ts_M_Customer.TabIndex = 2
            Me.Ts_M_Customer.Text = "Ts_M_Customer1"
            '
            'pnl_2
            '
            Me.pnl_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_2.Controls.Add(Me.lbl_Rate)
            Me.pnl_2.Controls.Add(Me.tb_Rate)
            Me.pnl_2.Controls.Add(Me.lbl_LineType)
            Me.pnl_2.Controls.Add(Me.btn_AddLine)
            Me.pnl_2.Controls.Add(Me.cmb_LineTypes)
            Me.pnl_2.Controls.Add(Me.tb_DescText)
            Me.pnl_2.Controls.Add(Me.ck_Reminder)
            Me.pnl_2.Controls.Add(Me.lbl_DescText)
            Me.pnl_2.Controls.Add(Me.lbl_DateOfSrvc)
            Me.pnl_2.Controls.Add(Me.grp_Address)
            Me.pnl_2.Controls.Add(Me.dtp_DateOfSrvc)
            Me.pnl_2.Location = New System.Drawing.Point(3, 62)
            Me.pnl_2.Name = "pnl_2"
            Me.pnl_2.Size = New System.Drawing.Size(840, 229)
            Me.pnl_2.TabIndex = 101
            Me.pnl_2.Visible = False
            '
            'lbl_Rate
            '
            Me.lbl_Rate.AutoSize = True
            Me.lbl_Rate.Location = New System.Drawing.Point(265, 32)
            Me.lbl_Rate.Name = "lbl_Rate"
            Me.lbl_Rate.Size = New System.Drawing.Size(33, 13)
            Me.lbl_Rate.TabIndex = 19
            Me.lbl_Rate.Text = "Rate:"
            '
            'tb_Rate
            '
            Me.tb_Rate.Location = New System.Drawing.Point(302, 29)
            Me.tb_Rate.Name = "tb_Rate"
            Me.tb_Rate.Size = New System.Drawing.Size(66, 20)
            Me.tb_Rate.TabIndex = 18
            '
            'lbl_LineType
            '
            Me.lbl_LineType.AutoSize = True
            Me.lbl_LineType.Location = New System.Drawing.Point(80, 12)
            Me.lbl_LineType.Name = "lbl_LineType"
            Me.lbl_LineType.Size = New System.Drawing.Size(110, 13)
            Me.lbl_LineType.TabIndex = 1
            Me.lbl_LineType.Text = "What type of charge?"
            '
            'btn_AddLine
            '
            Me.btn_AddLine.AutoSize = True
            Me.btn_AddLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_AddLine.Location = New System.Drawing.Point(168, 189)
            Me.btn_AddLine.Name = "btn_AddLine"
            Me.btn_AddLine.Size = New System.Drawing.Size(99, 26)
            Me.btn_AddLine.TabIndex = 17
            Me.btn_AddLine.Text = "Add Line Item"
            Me.btn_AddLine.UseVisualStyleBackColor = True
            '
            'cmb_LineTypes
            '
            Me.cmb_LineTypes.DataSource = Me.CustomInvoiceLineTypesBindingSource
            Me.cmb_LineTypes.DisplayMember = "Name"
            Me.cmb_LineTypes.FormattingEnabled = True
            Me.cmb_LineTypes.Location = New System.Drawing.Point(83, 28)
            Me.cmb_LineTypes.Name = "cmb_LineTypes"
            Me.cmb_LineTypes.Size = New System.Drawing.Size(156, 21)
            Me.cmb_LineTypes.TabIndex = 0
            Me.cmb_LineTypes.ValueMember = "CI_TypeID"
            '
            'CustomInvoiceLineTypesBindingSource
            '
            Me.CustomInvoiceLineTypesBindingSource.DataMember = "CustomInvoice_LineTypes"
            Me.CustomInvoiceLineTypesBindingSource.DataSource = Me.Ds_Invoicing
            '
            'Ds_Invoicing
            '
            Me.Ds_Invoicing.DataSetName = "ds_Invoicing"
            Me.Ds_Invoicing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'tb_DescText
            '
            Me.tb_DescText.Location = New System.Drawing.Point(83, 82)
            Me.tb_DescText.MaxLength = 4000
            Me.tb_DescText.Multiline = True
            Me.tb_DescText.Name = "tb_DescText"
            Me.tb_DescText.Size = New System.Drawing.Size(285, 46)
            Me.tb_DescText.TabIndex = 10
            '
            'ck_Reminder
            '
            Me.ck_Reminder.AutoSize = True
            Me.ck_Reminder.Location = New System.Drawing.Point(263, 167)
            Me.ck_Reminder.Name = "ck_Reminder"
            Me.ck_Reminder.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.ck_Reminder.Size = New System.Drawing.Size(105, 17)
            Me.ck_Reminder.TabIndex = 3
            Me.ck_Reminder.Text = "Create Reminder"
            Me.ck_Reminder.UseVisualStyleBackColor = True
            '
            'lbl_DescText
            '
            Me.lbl_DescText.AutoSize = True
            Me.lbl_DescText.Location = New System.Drawing.Point(80, 65)
            Me.lbl_DescText.Name = "lbl_DescText"
            Me.lbl_DescText.Size = New System.Drawing.Size(159, 13)
            Me.lbl_DescText.TabIndex = 11
            Me.lbl_DescText.Text = "Description of service performed"
            '
            'lbl_DateOfSrvc
            '
            Me.lbl_DateOfSrvc.AutoSize = True
            Me.lbl_DateOfSrvc.Location = New System.Drawing.Point(80, 144)
            Me.lbl_DateOfSrvc.Name = "lbl_DateOfSrvc"
            Me.lbl_DateOfSrvc.Size = New System.Drawing.Size(82, 13)
            Me.lbl_DateOfSrvc.TabIndex = 14
            Me.lbl_DateOfSrvc.Text = "Date of service:"
            '
            'grp_Address
            '
            Me.grp_Address.Controls.Add(lbl_Addr1)
            Me.grp_Address.Controls.Add(Me.tb_Addr1)
            Me.grp_Address.Controls.Add(lbl_Addr2)
            Me.grp_Address.Controls.Add(Me.tb_Addr2)
            Me.grp_Address.Controls.Add(lbl_Addr3)
            Me.grp_Address.Controls.Add(Me.tb_Addr3)
            Me.grp_Address.Controls.Add(lbl_CityState)
            Me.grp_Address.Controls.Add(Me.tb_City)
            Me.grp_Address.Controls.Add(Me.tb_State)
            Me.grp_Address.Controls.Add(Me.lbl_RecentAddrs)
            Me.grp_Address.Controls.Add(ZipLabel)
            Me.grp_Address.Controls.Add(Me.cmb_RecentAddr)
            Me.grp_Address.Controls.Add(Me.tb_Zip)
            Me.grp_Address.Location = New System.Drawing.Point(450, 11)
            Me.grp_Address.Name = "grp_Address"
            Me.grp_Address.Size = New System.Drawing.Size(285, 205)
            Me.grp_Address.TabIndex = 12
            Me.grp_Address.TabStop = False
            Me.grp_Address.Text = "Location"
            '
            'tb_Addr1
            '
            Me.tb_Addr1.Location = New System.Drawing.Point(73, 19)
            Me.tb_Addr1.Name = "tb_Addr1"
            Me.tb_Addr1.Size = New System.Drawing.Size(147, 20)
            Me.tb_Addr1.TabIndex = 5
            '
            'tb_Addr2
            '
            Me.tb_Addr2.Location = New System.Drawing.Point(73, 45)
            Me.tb_Addr2.Name = "tb_Addr2"
            Me.tb_Addr2.Size = New System.Drawing.Size(147, 20)
            Me.tb_Addr2.TabIndex = 7
            '
            'tb_Addr3
            '
            Me.tb_Addr3.Location = New System.Drawing.Point(73, 71)
            Me.tb_Addr3.Name = "tb_Addr3"
            Me.tb_Addr3.Size = New System.Drawing.Size(147, 20)
            Me.tb_Addr3.TabIndex = 9
            '
            'tb_City
            '
            Me.tb_City.Location = New System.Drawing.Point(73, 97)
            Me.tb_City.Name = "tb_City"
            Me.tb_City.Size = New System.Drawing.Size(100, 20)
            Me.tb_City.TabIndex = 11
            '
            'tb_State
            '
            Me.tb_State.Location = New System.Drawing.Point(179, 97)
            Me.tb_State.Name = "tb_State"
            Me.tb_State.Size = New System.Drawing.Size(41, 20)
            Me.tb_State.TabIndex = 13
            '
            'lbl_RecentAddrs
            '
            Me.lbl_RecentAddrs.AutoSize = True
            Me.lbl_RecentAddrs.Location = New System.Drawing.Point(10, 162)
            Me.lbl_RecentAddrs.Name = "lbl_RecentAddrs"
            Me.lbl_RecentAddrs.Size = New System.Drawing.Size(97, 13)
            Me.lbl_RecentAddrs.TabIndex = 0
            Me.lbl_RecentAddrs.Text = "Recent Addresses:"
            '
            'cmb_RecentAddr
            '
            Me.cmb_RecentAddr.DataSource = Me.CustomerRecentAddrsBindingSource
            Me.cmb_RecentAddr.DisplayMember = "Addr1"
            Me.cmb_RecentAddr.FormattingEnabled = True
            Me.cmb_RecentAddr.Location = New System.Drawing.Point(13, 178)
            Me.cmb_RecentAddr.Name = "cmb_RecentAddr"
            Me.cmb_RecentAddr.Size = New System.Drawing.Size(266, 21)
            Me.cmb_RecentAddr.TabIndex = 1
            Me.cmb_RecentAddr.ValueMember = "ID"
            '
            'CustomerRecentAddrsBindingSource
            '
            Me.CustomerRecentAddrsBindingSource.DataMember = "Customer_RecentAddrs"
            Me.CustomerRecentAddrsBindingSource.DataSource = Me.Ds_Invoicing
            '
            'tb_Zip
            '
            Me.tb_Zip.Location = New System.Drawing.Point(73, 123)
            Me.tb_Zip.Name = "tb_Zip"
            Me.tb_Zip.Size = New System.Drawing.Size(100, 20)
            Me.tb_Zip.TabIndex = 15
            '
            'dtp_DateOfSrvc
            '
            Me.dtp_DateOfSrvc.Location = New System.Drawing.Point(168, 141)
            Me.dtp_DateOfSrvc.Name = "dtp_DateOfSrvc"
            Me.dtp_DateOfSrvc.Size = New System.Drawing.Size(200, 20)
            Me.dtp_DateOfSrvc.TabIndex = 13
            '
            'pnl_3
            '
            Me.pnl_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_3.Controls.Add(Me.btn_CancelInv)
            Me.pnl_3.Controls.Add(Me.dg_LineItems)
            Me.pnl_3.Controls.Add(Me.lbl_LineItems)
            Me.pnl_3.Controls.Add(Me.btn_CreateInv)
            Me.pnl_3.Controls.Add(Me.grp_InvDets)
            Me.pnl_3.Location = New System.Drawing.Point(3, 297)
            Me.pnl_3.Name = "pnl_3"
            Me.pnl_3.Padding = New System.Windows.Forms.Padding(5)
            Me.pnl_3.Size = New System.Drawing.Size(840, 266)
            Me.pnl_3.TabIndex = 102
            Me.pnl_3.Visible = False
            '
            'btn_CancelInv
            '
            Me.btn_CancelInv.AutoSize = True
            Me.btn_CancelInv.ForeColor = System.Drawing.Color.Red
            Me.btn_CancelInv.Location = New System.Drawing.Point(740, 233)
            Me.btn_CancelInv.Name = "btn_CancelInv"
            Me.btn_CancelInv.Size = New System.Drawing.Size(88, 23)
            Me.btn_CancelInv.TabIndex = 19
            Me.btn_CancelInv.Text = "Cancel Invoice"
            Me.btn_CancelInv.UseVisualStyleBackColor = True
            '
            'dg_LineItems
            '
            Me.dg_LineItems.AllowUserToAddRows = False
            Me.dg_LineItems.AllowUserToDeleteRows = False
            Me.dg_LineItems.AutoGenerateColumns = False
            Me.dg_LineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_LineItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CITypeIDDataGridViewTextBoxColumn, Me.RateDataGridViewTextBoxColumn, Me.RenderedOnDateDataGridViewTextBoxColumn, Me.Addr1DataGridViewTextBoxColumn, Me.DescTextDataGridViewTextBoxColumn})
            Me.dg_LineItems.DataSource = Me.CustomInvoiceLineItemsBindingSource
            Me.dg_LineItems.Dock = System.Windows.Forms.DockStyle.Top
            Me.dg_LineItems.Location = New System.Drawing.Point(5, 25)
            Me.dg_LineItems.Name = "dg_LineItems"
            Me.dg_LineItems.ReadOnly = True
            Me.dg_LineItems.RowHeadersVisible = False
            Me.dg_LineItems.Size = New System.Drawing.Size(828, 108)
            Me.dg_LineItems.TabIndex = 18
            '
            'CITypeIDDataGridViewTextBoxColumn
            '
            Me.CITypeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.CITypeIDDataGridViewTextBoxColumn.DataPropertyName = "CI_TypeID"
            Me.CITypeIDDataGridViewTextBoxColumn.DataSource = Me.CustomInvoiceLineTypesBindingSource
            Me.CITypeIDDataGridViewTextBoxColumn.DisplayMember = "NAME"
            Me.CITypeIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
            Me.CITypeIDDataGridViewTextBoxColumn.HeaderText = "Charge Type"
            Me.CITypeIDDataGridViewTextBoxColumn.Name = "CITypeIDDataGridViewTextBoxColumn"
            Me.CITypeIDDataGridViewTextBoxColumn.ReadOnly = True
            Me.CITypeIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CITypeIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.CITypeIDDataGridViewTextBoxColumn.ValueMember = "CI_TypeID"
            Me.CITypeIDDataGridViewTextBoxColumn.Width = 86
            '
            'RateDataGridViewTextBoxColumn
            '
            Me.RateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.RateDataGridViewTextBoxColumn.DataPropertyName = "Rate"
            DataGridViewCellStyle3.Format = "d"
            Me.RateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
            Me.RateDataGridViewTextBoxColumn.HeaderText = "Rate"
            Me.RateDataGridViewTextBoxColumn.Name = "RateDataGridViewTextBoxColumn"
            Me.RateDataGridViewTextBoxColumn.ReadOnly = True
            Me.RateDataGridViewTextBoxColumn.Width = 55
            '
            'RenderedOnDateDataGridViewTextBoxColumn
            '
            Me.RenderedOnDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.RenderedOnDateDataGridViewTextBoxColumn.DataPropertyName = "RenderedOnDate"
            DataGridViewCellStyle4.Format = "d"
            Me.RenderedOnDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
            Me.RenderedOnDateDataGridViewTextBoxColumn.HeaderText = "Date of service"
            Me.RenderedOnDateDataGridViewTextBoxColumn.Name = "RenderedOnDateDataGridViewTextBoxColumn"
            Me.RenderedOnDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.RenderedOnDateDataGridViewTextBoxColumn.Width = 96
            '
            'Addr1DataGridViewTextBoxColumn
            '
            Me.Addr1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.Addr1DataGridViewTextBoxColumn.DataPropertyName = "Addr1"
            Me.Addr1DataGridViewTextBoxColumn.HeaderText = "Address 1"
            Me.Addr1DataGridViewTextBoxColumn.Name = "Addr1DataGridViewTextBoxColumn"
            Me.Addr1DataGridViewTextBoxColumn.ReadOnly = True
            Me.Addr1DataGridViewTextBoxColumn.Width = 73
            '
            'DescTextDataGridViewTextBoxColumn
            '
            Me.DescTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DescTextDataGridViewTextBoxColumn.DataPropertyName = "DescText"
            Me.DescTextDataGridViewTextBoxColumn.HeaderText = "Description"
            Me.DescTextDataGridViewTextBoxColumn.Name = "DescTextDataGridViewTextBoxColumn"
            Me.DescTextDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CustomInvoiceLineItemsBindingSource
            '
            Me.CustomInvoiceLineItemsBindingSource.DataMember = "CustomInvoice_LineItems"
            Me.CustomInvoiceLineItemsBindingSource.DataSource = Me.Ds_Invoicing
            '
            'lbl_LineItems
            '
            Me.lbl_LineItems.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_LineItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl_LineItems.Location = New System.Drawing.Point(5, 5)
            Me.lbl_LineItems.Name = "lbl_LineItems"
            Me.lbl_LineItems.Size = New System.Drawing.Size(828, 20)
            Me.lbl_LineItems.TabIndex = 17
            Me.lbl_LineItems.Text = "Line Items"
            '
            'btn_CreateInv
            '
            Me.btn_CreateInv.AutoSize = True
            Me.btn_CreateInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_CreateInv.Location = New System.Drawing.Point(459, 160)
            Me.btn_CreateInv.Name = "btn_CreateInv"
            Me.btn_CreateInv.Size = New System.Drawing.Size(111, 76)
            Me.btn_CreateInv.TabIndex = 16
            Me.btn_CreateInv.Text = "Create Invoice"
            Me.btn_CreateInv.UseVisualStyleBackColor = True
            '
            'grp_InvDets
            '
            Me.grp_InvDets.Controls.Add(Me.dtp_PostDate)
            Me.grp_InvDets.Controls.Add(Me.dtp_DueDate)
            Me.grp_InvDets.Controls.Add(Me.lbl_PostDate)
            Me.grp_InvDets.Controls.Add(Me.lbl_DueDate)
            Me.grp_InvDets.Controls.Add(Me.ck_Print)
            Me.grp_InvDets.Location = New System.Drawing.Point(223, 146)
            Me.grp_InvDets.Name = "grp_InvDets"
            Me.grp_InvDets.Size = New System.Drawing.Size(200, 100)
            Me.grp_InvDets.TabIndex = 15
            Me.grp_InvDets.TabStop = False
            Me.grp_InvDets.Text = "Invoice Details"
            '
            'dtp_PostDate
            '
            Me.dtp_PostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_PostDate.Location = New System.Drawing.Point(79, 21)
            Me.dtp_PostDate.Name = "dtp_PostDate"
            Me.dtp_PostDate.Size = New System.Drawing.Size(98, 20)
            Me.dtp_PostDate.TabIndex = 4
            '
            'dtp_DueDate
            '
            Me.dtp_DueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_DueDate.Location = New System.Drawing.Point(79, 47)
            Me.dtp_DueDate.Name = "dtp_DueDate"
            Me.dtp_DueDate.Size = New System.Drawing.Size(98, 20)
            Me.dtp_DueDate.TabIndex = 5
            '
            'lbl_PostDate
            '
            Me.lbl_PostDate.AutoSize = True
            Me.lbl_PostDate.Location = New System.Drawing.Point(16, 25)
            Me.lbl_PostDate.Name = "lbl_PostDate"
            Me.lbl_PostDate.Size = New System.Drawing.Size(57, 13)
            Me.lbl_PostDate.TabIndex = 6
            Me.lbl_PostDate.Text = "Post Date:"
            '
            'lbl_DueDate
            '
            Me.lbl_DueDate.AutoSize = True
            Me.lbl_DueDate.Location = New System.Drawing.Point(17, 51)
            Me.lbl_DueDate.Name = "lbl_DueDate"
            Me.lbl_DueDate.Size = New System.Drawing.Size(56, 13)
            Me.lbl_DueDate.TabIndex = 7
            Me.lbl_DueDate.Text = "Due Date:"
            '
            'ck_Print
            '
            Me.ck_Print.AutoSize = True
            Me.ck_Print.Checked = True
            Me.ck_Print.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ck_Print.Location = New System.Drawing.Point(53, 74)
            Me.ck_Print.Name = "ck_Print"
            Me.ck_Print.Size = New System.Drawing.Size(85, 17)
            Me.ck_Print.TabIndex = 2
            Me.ck_Print.Text = "Print Invoice"
            Me.ck_Print.UseVisualStyleBackColor = True
            '
            'CustomInvoice_LineTypesTableAdapter
            '
            Me.CustomInvoice_LineTypesTableAdapter.ClearBeforeFill = True
            '
            'Customer_RecentAddrsTableAdapter
            '
            Me.Customer_RecentAddrsTableAdapter.ClearBeforeFill = True
            '
            'TableAdapterManager
            '
            Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
            Me.TableAdapterManager.CustomInvoice_LineItemsTableAdapter = Me.CustomInvoice_LineItemsTableAdapter
            Me.TableAdapterManager.CustomInvoice_LineTypesTableAdapter = Me.CustomInvoice_LineTypesTableAdapter
            Me.TableAdapterManager.CustomInvoicesTableAdapter = Nothing
            Me.TableAdapterManager.UpdateOrder = TrashCash.ds_InvoicingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
            '
            'CustomInvoice_LineItemsTableAdapter
            '
            Me.CustomInvoice_LineItemsTableAdapter.ClearBeforeFill = True
            '
            'CustomInvoicingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(855, 589)
            Me.Controls.Add(Me.FlowLayoutPanel)
            Me.Name = "CustomInvoicingForm"
            Me.Text = "Custom Invoicing"
            Me.FlowLayoutPanel.ResumeLayout(False)
            Me.pnl_1.ResumeLayout(False)
            Me.pnl_TopContent.ResumeLayout(False)
            Me.pnl_TopContent.PerformLayout()
            Me.pnl_2.ResumeLayout(False)
            Me.pnl_2.PerformLayout()
            CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Invoicing, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_Address.ResumeLayout(False)
            Me.grp_Address.PerformLayout()
            CType(Me.CustomerRecentAddrsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_3.ResumeLayout(False)
            Me.pnl_3.PerformLayout()
            CType(Me.dg_LineItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CustomInvoiceLineItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_InvDets.ResumeLayout(False)
            Me.grp_InvDets.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents pnl_1 As System.Windows.Forms.Panel
        Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
        Friend WithEvents Ts_M_Customer As TrashCash.ts_M_Customer
        Friend WithEvents CustomInvoiceLineTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Ds_Invoicing As TrashCash.ds_Invoicing
        Friend WithEvents CustomInvoice_LineTypesTableAdapter As TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter
        Friend WithEvents CustomerRecentAddrsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Customer_RecentAddrsTableAdapter As TrashCash.ds_InvoicingTableAdapters.Customer_RecentAddrsTableAdapter
        Friend WithEvents TableAdapterManager As TrashCash.ds_InvoicingTableAdapters.TableAdapterManager
        Friend WithEvents pnl_2 As System.Windows.Forms.Panel
        Friend WithEvents lbl_LineType As System.Windows.Forms.Label
        Friend WithEvents btn_AddLine As System.Windows.Forms.Button
        Friend WithEvents cmb_LineTypes As System.Windows.Forms.ComboBox
        Friend WithEvents tb_DescText As System.Windows.Forms.TextBox
        Friend WithEvents ck_Reminder As System.Windows.Forms.CheckBox
        Friend WithEvents lbl_DescText As System.Windows.Forms.Label
        Friend WithEvents lbl_DateOfSrvc As System.Windows.Forms.Label
        Friend WithEvents grp_Address As System.Windows.Forms.GroupBox
        Friend WithEvents tb_Addr1 As System.Windows.Forms.TextBox
        Friend WithEvents tb_Addr2 As System.Windows.Forms.TextBox
        Friend WithEvents tb_Addr3 As System.Windows.Forms.TextBox
        Friend WithEvents tb_City As System.Windows.Forms.TextBox
        Friend WithEvents tb_State As System.Windows.Forms.TextBox
        Friend WithEvents lbl_RecentAddrs As System.Windows.Forms.Label
        Friend WithEvents cmb_RecentAddr As System.Windows.Forms.ComboBox
        Friend WithEvents tb_Zip As System.Windows.Forms.TextBox
        Friend WithEvents dtp_DateOfSrvc As System.Windows.Forms.DateTimePicker
        Friend WithEvents pnl_3 As System.Windows.Forms.Panel
        Friend WithEvents btn_CancelInv As System.Windows.Forms.Button
        Friend WithEvents dg_LineItems As System.Windows.Forms.DataGridView
        Friend WithEvents CITypeIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RenderedOnDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Addr1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DescTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CustomInvoiceLineItemsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents lbl_LineItems As System.Windows.Forms.Label
        Friend WithEvents btn_CreateInv As System.Windows.Forms.Button
        Friend WithEvents grp_InvDets As System.Windows.Forms.GroupBox
        Friend WithEvents dtp_PostDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtp_DueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lbl_PostDate As System.Windows.Forms.Label
        Friend WithEvents lbl_DueDate As System.Windows.Forms.Label
        Friend WithEvents ck_Print As System.Windows.Forms.CheckBox
        Friend WithEvents CustomInvoice_LineItemsTableAdapter As TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineItemsTableAdapter
        Friend WithEvents lbl_Rate As System.Windows.Forms.Label
        Friend WithEvents tb_Rate As TrashCash.Currency_TextBox
    End Class
End Namespace