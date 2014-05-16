<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecurringService
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecurringService))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.ck_EndDate = New System.Windows.Forms.CheckBox()
        Me.grp_PickupDay = New System.Windows.Forms.GroupBox()
        Me.ck_Sat = New System.Windows.Forms.CheckBox()
        Me.RecurringServiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Program = New TrashCash.ds_Program()
        Me.ck_Fri = New System.Windows.Forms.CheckBox()
        Me.ck_Thurs = New System.Windows.Forms.CheckBox()
        Me.ck_Weds = New System.Windows.Forms.CheckBox()
        Me.ck_Sun = New System.Windows.Forms.CheckBox()
        Me.ck_Tues = New System.Windows.Forms.CheckBox()
        Me.ck_Mon = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.btn_Approve = New System.Windows.Forms.Button()
        Me.lbl_BillThru = New System.Windows.Forms.Label()
        Me.lbl_CustName = New System.Windows.Forms.Label()
        Me.grp_BasicInfo = New System.Windows.Forms.GroupBox()
        Me.nud_BillLength = New System.Windows.Forms.NumericUpDown()
        Me.Cmb_ServiceTypes = New TrashCash.Database_ComboBoxes.cmb_ServiceTypes()
        Me.lbl_DefPriceValue = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_DefPriceHeader = New System.Windows.Forms.Label()
        Me.nud_Quantity = New System.Windows.Forms.NumericUpDown()
        Me.lbl_Quantity = New System.Windows.Forms.Label()
        Me.tb_Rate = New TrashCash.Currency_TextBox()
        Me.lbl_Rate = New System.Windows.Forms.Label()
        Me.grp_Dates = New System.Windows.Forms.GroupBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.tc_Master = New System.Windows.Forms.TabControl()
        Me.tp_SrvcInfo = New System.Windows.Forms.TabPage()
        Me.lbl_CreditMsg = New System.Windows.Forms.Label()
        Me.lbl_RecStatus = New System.Windows.Forms.Label()
        Me.grp_SrvcAddr = New System.Windows.Forms.GroupBox()
        Me.btn_CopyAddr = New System.Windows.Forms.Button()
        Me.lbl_SrvcZip = New System.Windows.Forms.Label()
        Me.lbl_SrvcCityState = New System.Windows.Forms.Label()
        Me.lbl_SrvcStreet = New System.Windows.Forms.Label()
        Me.tb_SrvcAddr1 = New System.Windows.Forms.TextBox()
        Me.tb_SrvcAddr2 = New System.Windows.Forms.TextBox()
        Me.tb_SrvcAddr3 = New System.Windows.Forms.TextBox()
        Me.tb_SrvcZip = New System.Windows.Forms.TextBox()
        Me.tb_SrvcState = New System.Windows.Forms.TextBox()
        Me.tb_SrvcCity = New System.Windows.Forms.TextBox()
        Me.tp_BillHist = New System.Windows.Forms.TabPage()
        Me.dg_SrvcBillHistory = New System.Windows.Forms.DataGridView()
        Me.BilledServiceIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvRefNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BilledServicesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Display = New TrashCash.ds_Display()
        Me.tp_Notes = New System.Windows.Forms.TabPage()
        Me.dg_ServiceNotes = New System.Windows.Forms.DataGridView()
        Me.ServiceNoteTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsertedByUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNoteDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNotesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RecurringServiceTableAdapter = New TrashCash.ds_ProgramTableAdapters.RecurringServiceTableAdapter()
        Me.BilledServicesTableAdapter = New TrashCash.ds_DisplayTableAdapters.BilledServicesTableAdapter()
        Me.ServiceNotesTableAdapter = New TrashCash.ds_DisplayTableAdapters.ServiceNotesTableAdapter()
        Me.tt_BillLength = New System.Windows.Forms.ToolTip(Me.components)
        Me.tp_Credits = New System.Windows.Forms.TabPage()
        Me.lbl_Credits = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.pnl_CreditDG = New System.Windows.Forms.Panel()
        Me.lbl_CreditDG = New System.Windows.Forms.Label()
        Me.dg_CreditHistory = New System.Windows.Forms.DataGridView()
        Me.grp_PickupDay.SuspendLayout()
        CType(Me.RecurringServiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Program, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Top.SuspendLayout()
        Me.grp_BasicInfo.SuspendLayout()
        CType(Me.nud_BillLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_Quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Dates.SuspendLayout()
        Me.tc_Master.SuspendLayout()
        Me.tp_SrvcInfo.SuspendLayout()
        Me.grp_SrvcAddr.SuspendLayout()
        Me.tp_BillHist.SuspendLayout()
        CType(Me.dg_SrvcBillHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BilledServicesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Notes.SuspendLayout()
        CType(Me.dg_ServiceNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServiceNotesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Credits.SuspendLayout()
        Me.pnl_CreditDG.SuspendLayout()
        CType(Me.dg_CreditHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_EndDate.Location = New System.Drawing.Point(289, 19)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(79, 20)
        Me.dtp_EndDate.TabIndex = 6
        '
        'ck_EndDate
        '
        Me.ck_EndDate.AutoSize = True
        Me.ck_EndDate.Location = New System.Drawing.Point(165, 22)
        Me.ck_EndDate.Name = "ck_EndDate"
        Me.ck_EndDate.Size = New System.Drawing.Size(122, 17)
        Me.ck_EndDate.TabIndex = 5
        Me.ck_EndDate.Text = "Last Day of Service:"
        Me.ck_EndDate.UseVisualStyleBackColor = True
        '
        'grp_PickupDay
        '
        Me.grp_PickupDay.Controls.Add(Me.ck_Sat)
        Me.grp_PickupDay.Controls.Add(Me.ck_Fri)
        Me.grp_PickupDay.Controls.Add(Me.ck_Thurs)
        Me.grp_PickupDay.Controls.Add(Me.ck_Weds)
        Me.grp_PickupDay.Controls.Add(Me.ck_Sun)
        Me.grp_PickupDay.Controls.Add(Me.ck_Tues)
        Me.grp_PickupDay.Controls.Add(Me.ck_Mon)
        Me.grp_PickupDay.Location = New System.Drawing.Point(62, 155)
        Me.grp_PickupDay.Name = "grp_PickupDay"
        Me.grp_PickupDay.Size = New System.Drawing.Size(376, 41)
        Me.grp_PickupDay.TabIndex = 65
        Me.grp_PickupDay.TabStop = False
        Me.grp_PickupDay.Text = "Pickup Day"
        '
        'ck_Sat
        '
        Me.ck_Sat.AutoSize = True
        Me.ck_Sat.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Saturday", True))
        Me.ck_Sat.Location = New System.Drawing.Point(328, 18)
        Me.ck_Sat.Name = "ck_Sat"
        Me.ck_Sat.Size = New System.Drawing.Size(42, 17)
        Me.ck_Sat.TabIndex = 13
        Me.ck_Sat.Text = "Sat"
        Me.ck_Sat.UseVisualStyleBackColor = True
        '
        'RecurringServiceBindingSource
        '
        Me.RecurringServiceBindingSource.DataMember = "RecurringService"
        Me.RecurringServiceBindingSource.DataSource = Me.Ds_Program
        '
        'Ds_Program
        '
        Me.Ds_Program.DataSetName = "ds_Program"
        Me.Ds_Program.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ck_Fri
        '
        Me.ck_Fri.AutoSize = True
        Me.ck_Fri.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Friday", True))
        Me.ck_Fri.Location = New System.Drawing.Point(285, 18)
        Me.ck_Fri.Name = "ck_Fri"
        Me.ck_Fri.Size = New System.Drawing.Size(37, 17)
        Me.ck_Fri.TabIndex = 12
        Me.ck_Fri.Text = "Fri"
        Me.ck_Fri.UseVisualStyleBackColor = True
        '
        'ck_Thurs
        '
        Me.ck_Thurs.AutoSize = True
        Me.ck_Thurs.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Thursday", True))
        Me.ck_Thurs.Location = New System.Drawing.Point(226, 18)
        Me.ck_Thurs.Name = "ck_Thurs"
        Me.ck_Thurs.Size = New System.Drawing.Size(53, 17)
        Me.ck_Thurs.TabIndex = 11
        Me.ck_Thurs.Text = "Thurs"
        Me.ck_Thurs.UseVisualStyleBackColor = True
        '
        'ck_Weds
        '
        Me.ck_Weds.AutoSize = True
        Me.ck_Weds.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Wednesday", True))
        Me.ck_Weds.Location = New System.Drawing.Point(166, 18)
        Me.ck_Weds.Name = "ck_Weds"
        Me.ck_Weds.Size = New System.Drawing.Size(54, 17)
        Me.ck_Weds.TabIndex = 10
        Me.ck_Weds.Text = "Weds"
        Me.ck_Weds.UseVisualStyleBackColor = True
        '
        'ck_Sun
        '
        Me.ck_Sun.AutoSize = True
        Me.ck_Sun.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Sunday", True))
        Me.ck_Sun.Location = New System.Drawing.Point(6, 18)
        Me.ck_Sun.Name = "ck_Sun"
        Me.ck_Sun.Size = New System.Drawing.Size(45, 17)
        Me.ck_Sun.TabIndex = 7
        Me.ck_Sun.Text = "Sun"
        Me.ck_Sun.UseVisualStyleBackColor = True
        '
        'ck_Tues
        '
        Me.ck_Tues.AutoSize = True
        Me.ck_Tues.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Tuesday", True))
        Me.ck_Tues.Location = New System.Drawing.Point(110, 18)
        Me.ck_Tues.Name = "ck_Tues"
        Me.ck_Tues.Size = New System.Drawing.Size(50, 17)
        Me.ck_Tues.TabIndex = 9
        Me.ck_Tues.Text = "Tues"
        Me.ck_Tues.UseVisualStyleBackColor = True
        '
        'ck_Mon
        '
        Me.ck_Mon.AutoSize = True
        Me.ck_Mon.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Monday", True))
        Me.ck_Mon.Location = New System.Drawing.Point(57, 18)
        Me.ck_Mon.Name = "ck_Mon"
        Me.ck_Mon.Size = New System.Drawing.Size(47, 17)
        Me.ck_Mon.TabIndex = 8
        Me.ck_Mon.Text = "Mon"
        Me.ck_Mon.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Start Date:"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RecurringServiceBindingSource, "RecurringServiceStartDate", True))
        Me.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_StartDate.Location = New System.Drawing.Point(74, 19)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(79, 20)
        Me.dtp_StartDate.TabIndex = 4
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.btn_Approve)
        Me.pnl_Top.Controls.Add(Me.lbl_BillThru)
        Me.pnl_Top.Controls.Add(Me.lbl_CustName)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(861, 87)
        Me.pnl_Top.TabIndex = 72
        '
        'btn_Approve
        '
        Me.btn_Approve.AutoSize = True
        Me.btn_Approve.BackColor = System.Drawing.Color.DarkGreen
        Me.btn_Approve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Approve.ForeColor = System.Drawing.Color.Lime
        Me.btn_Approve.Location = New System.Drawing.Point(376, 26)
        Me.btn_Approve.Name = "btn_Approve"
        Me.btn_Approve.Size = New System.Drawing.Size(100, 25)
        Me.btn_Approve.TabIndex = 21
        Me.btn_Approve.Text = "Approve Service"
        Me.btn_Approve.UseVisualStyleBackColor = False
        Me.btn_Approve.Visible = False
        '
        'lbl_BillThru
        '
        Me.lbl_BillThru.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbl_BillThru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BillThru.Location = New System.Drawing.Point(0, 54)
        Me.lbl_BillThru.Name = "lbl_BillThru"
        Me.lbl_BillThru.Size = New System.Drawing.Size(861, 33)
        Me.lbl_BillThru.TabIndex = 74
        Me.lbl_BillThru.Text = "Billed Through " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2/1/1988"
        Me.lbl_BillThru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lbl_BillThru.Visible = False
        '
        'lbl_CustName
        '
        Me.lbl_CustName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CustName.Location = New System.Drawing.Point(0, 0)
        Me.lbl_CustName.Name = "lbl_CustName"
        Me.lbl_CustName.Size = New System.Drawing.Size(861, 24)
        Me.lbl_CustName.TabIndex = 72
        Me.lbl_CustName.Text = "CustomerName"
        Me.lbl_CustName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_BasicInfo
        '
        Me.grp_BasicInfo.Controls.Add(Me.nud_BillLength)
        Me.grp_BasicInfo.Controls.Add(Me.Cmb_ServiceTypes)
        Me.grp_BasicInfo.Controls.Add(Me.lbl_DefPriceValue)
        Me.grp_BasicInfo.Controls.Add(Me.Label3)
        Me.grp_BasicInfo.Controls.Add(Me.lbl_DefPriceHeader)
        Me.grp_BasicInfo.Controls.Add(Me.nud_Quantity)
        Me.grp_BasicInfo.Controls.Add(Me.lbl_Quantity)
        Me.grp_BasicInfo.Controls.Add(Me.tb_Rate)
        Me.grp_BasicInfo.Controls.Add(Me.lbl_Rate)
        Me.grp_BasicInfo.Location = New System.Drawing.Point(59, 6)
        Me.grp_BasicInfo.Name = "grp_BasicInfo"
        Me.grp_BasicInfo.Size = New System.Drawing.Size(379, 85)
        Me.grp_BasicInfo.TabIndex = 73
        Me.grp_BasicInfo.TabStop = False
        Me.grp_BasicInfo.Text = "Basic Service Information"
        '
        'nud_BillLength
        '
        Me.nud_BillLength.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RecurringServiceBindingSource, "RecurringServiceBillLength", True))
        Me.nud_BillLength.Location = New System.Drawing.Point(293, 50)
        Me.nud_BillLength.Name = "nud_BillLength"
        Me.nud_BillLength.Size = New System.Drawing.Size(36, 20)
        Me.nud_BillLength.TabIndex = 3
        Me.nud_BillLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tt_BillLength.SetToolTip(Me.nud_BillLength, "Bill Length is the number of months this Recurring Service will bill for.")
        '
        'Cmb_ServiceTypes
        '
        Me.Cmb_ServiceTypes.DisplayMember = "ServiceName"
        Me.Cmb_ServiceTypes.FormattingEnabled = True
        Me.Cmb_ServiceTypes.Location = New System.Drawing.Point(9, 18)
        Me.Cmb_ServiceTypes.Name = "Cmb_ServiceTypes"
        Me.Cmb_ServiceTypes.Size = New System.Drawing.Size(240, 21)
        Me.Cmb_ServiceTypes.TabIndex = 0
        Me.Cmb_ServiceTypes.ValueMember = "ServiceTypeID"
        '
        'lbl_DefPriceValue
        '
        Me.lbl_DefPriceValue.AutoSize = True
        Me.lbl_DefPriceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_DefPriceValue.Location = New System.Drawing.Point(323, 20)
        Me.lbl_DefPriceValue.Name = "lbl_DefPriceValue"
        Me.lbl_DefPriceValue.Size = New System.Drawing.Size(15, 15)
        Me.lbl_DefPriceValue.TabIndex = 78
        Me.lbl_DefPriceValue.Text = "3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Bill Length:"
        Me.tt_BillLength.SetToolTip(Me.Label3, "Bill Length is the number of months this Recurring Service will bill for.")
        '
        'lbl_DefPriceHeader
        '
        Me.lbl_DefPriceHeader.AutoSize = True
        Me.lbl_DefPriceHeader.Location = New System.Drawing.Point(255, 21)
        Me.lbl_DefPriceHeader.Name = "lbl_DefPriceHeader"
        Me.lbl_DefPriceHeader.Size = New System.Drawing.Size(70, 13)
        Me.lbl_DefPriceHeader.TabIndex = 77
        Me.lbl_DefPriceHeader.Text = "Default Rate:"
        '
        'nud_Quantity
        '
        Me.nud_Quantity.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RecurringServiceBindingSource, "RecurringServiceQuantity", True))
        Me.nud_Quantity.Location = New System.Drawing.Point(177, 50)
        Me.nud_Quantity.Name = "nud_Quantity"
        Me.nud_Quantity.Size = New System.Drawing.Size(36, 20)
        Me.nud_Quantity.TabIndex = 2
        Me.nud_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nud_Quantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lbl_Quantity
        '
        Me.lbl_Quantity.AutoSize = True
        Me.lbl_Quantity.Location = New System.Drawing.Point(128, 52)
        Me.lbl_Quantity.Name = "lbl_Quantity"
        Me.lbl_Quantity.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Quantity.TabIndex = 82
        Me.lbl_Quantity.Text = "Quantity:"
        '
        'tb_Rate
        '
        Me.tb_Rate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceRate", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, Nothing, "C2"))
        Me.tb_Rate.Location = New System.Drawing.Point(41, 50)
        Me.tb_Rate.Name = "tb_Rate"
        Me.tb_Rate.Size = New System.Drawing.Size(66, 20)
        Me.tb_Rate.TabIndex = 1
        '
        'lbl_Rate
        '
        Me.lbl_Rate.AutoSize = True
        Me.lbl_Rate.Location = New System.Drawing.Point(7, 52)
        Me.lbl_Rate.Name = "lbl_Rate"
        Me.lbl_Rate.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Rate.TabIndex = 75
        Me.lbl_Rate.Text = "Rate:"
        '
        'grp_Dates
        '
        Me.grp_Dates.Controls.Add(Me.dtp_StartDate)
        Me.grp_Dates.Controls.Add(Me.dtp_EndDate)
        Me.grp_Dates.Controls.Add(Me.Label5)
        Me.grp_Dates.Controls.Add(Me.ck_EndDate)
        Me.grp_Dates.Location = New System.Drawing.Point(59, 97)
        Me.grp_Dates.Name = "grp_Dates"
        Me.grp_Dates.Size = New System.Drawing.Size(373, 52)
        Me.grp_Dates.TabIndex = 80
        Me.grp_Dates.TabStop = False
        Me.grp_Dates.Text = "Date Information"
        '
        'btn_Save
        '
        Me.btn_Save.AutoSize = True
        Me.btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Save.Location = New System.Drawing.Point(360, 263)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(184, 30)
        Me.btn_Save.TabIndex = 22
        Me.btn_Save.Text = "Save Recurring Service"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'tc_Master
        '
        Me.tc_Master.Controls.Add(Me.tp_SrvcInfo)
        Me.tc_Master.Controls.Add(Me.tp_BillHist)
        Me.tc_Master.Controls.Add(Me.tp_Notes)
        Me.tc_Master.Controls.Add(Me.tp_Credits)
        Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Master.Location = New System.Drawing.Point(0, 87)
        Me.tc_Master.Name = "tc_Master"
        Me.tc_Master.SelectedIndex = 0
        Me.tc_Master.Size = New System.Drawing.Size(861, 328)
        Me.tc_Master.TabIndex = 83
        '
        'tp_SrvcInfo
        '
        Me.tp_SrvcInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tp_SrvcInfo.Controls.Add(Me.lbl_CreditMsg)
        Me.tp_SrvcInfo.Controls.Add(Me.lbl_RecStatus)
        Me.tp_SrvcInfo.Controls.Add(Me.grp_SrvcAddr)
        Me.tp_SrvcInfo.Controls.Add(Me.btn_Save)
        Me.tp_SrvcInfo.Controls.Add(Me.grp_PickupDay)
        Me.tp_SrvcInfo.Controls.Add(Me.grp_BasicInfo)
        Me.tp_SrvcInfo.Controls.Add(Me.grp_Dates)
        Me.tp_SrvcInfo.Location = New System.Drawing.Point(4, 22)
        Me.tp_SrvcInfo.Name = "tp_SrvcInfo"
        Me.tp_SrvcInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_SrvcInfo.Size = New System.Drawing.Size(853, 302)
        Me.tp_SrvcInfo.TabIndex = 0
        Me.tp_SrvcInfo.Text = "Service Information"
        '
        'lbl_CreditMsg
        '
        Me.lbl_CreditMsg.ForeColor = System.Drawing.Color.ForestGreen
        Me.lbl_CreditMsg.Location = New System.Drawing.Point(2, 230)
        Me.lbl_CreditMsg.Name = "lbl_CreditMsg"
        Me.lbl_CreditMsg.Size = New System.Drawing.Size(897, 27)
        Me.lbl_CreditMsg.TabIndex = 85
        Me.lbl_CreditMsg.Text = "Credit message here"
        Me.lbl_CreditMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_CreditMsg.Visible = False
        '
        'lbl_RecStatus
        '
        Me.lbl_RecStatus.Location = New System.Drawing.Point(0, 202)
        Me.lbl_RecStatus.Name = "lbl_RecStatus"
        Me.lbl_RecStatus.Size = New System.Drawing.Size(897, 26)
        Me.lbl_RecStatus.TabIndex = 84
        Me.lbl_RecStatus.Text = "Status of invoice message here"
        Me.lbl_RecStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_SrvcAddr
        '
        Me.grp_SrvcAddr.Controls.Add(Me.btn_CopyAddr)
        Me.grp_SrvcAddr.Controls.Add(Me.lbl_SrvcZip)
        Me.grp_SrvcAddr.Controls.Add(Me.lbl_SrvcCityState)
        Me.grp_SrvcAddr.Controls.Add(Me.lbl_SrvcStreet)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcAddr1)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcAddr2)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcAddr3)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcZip)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcState)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcCity)
        Me.grp_SrvcAddr.Location = New System.Drawing.Point(570, 6)
        Me.grp_SrvcAddr.Name = "grp_SrvcAddr"
        Me.grp_SrvcAddr.Size = New System.Drawing.Size(223, 175)
        Me.grp_SrvcAddr.TabIndex = 83
        Me.grp_SrvcAddr.TabStop = False
        Me.grp_SrvcAddr.Text = "Recurring Service Address"
        '
        'btn_CopyAddr
        '
        Me.btn_CopyAddr.AutoSize = True
        Me.btn_CopyAddr.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_CopyAddr.Location = New System.Drawing.Point(3, 149)
        Me.btn_CopyAddr.Name = "btn_CopyAddr"
        Me.btn_CopyAddr.Size = New System.Drawing.Size(217, 23)
        Me.btn_CopyAddr.TabIndex = 20
        Me.btn_CopyAddr.Text = "Copy Customer Billing Address"
        Me.btn_CopyAddr.UseVisualStyleBackColor = True
        '
        'lbl_SrvcZip
        '
        Me.lbl_SrvcZip.AutoSize = True
        Me.lbl_SrvcZip.Location = New System.Drawing.Point(38, 122)
        Me.lbl_SrvcZip.Name = "lbl_SrvcZip"
        Me.lbl_SrvcZip.Size = New System.Drawing.Size(25, 13)
        Me.lbl_SrvcZip.TabIndex = 74
        Me.lbl_SrvcZip.Text = "Zip:"
        '
        'lbl_SrvcCityState
        '
        Me.lbl_SrvcCityState.AutoSize = True
        Me.lbl_SrvcCityState.Location = New System.Drawing.Point(6, 96)
        Me.lbl_SrvcCityState.Name = "lbl_SrvcCityState"
        Me.lbl_SrvcCityState.Size = New System.Drawing.Size(57, 13)
        Me.lbl_SrvcCityState.TabIndex = 73
        Me.lbl_SrvcCityState.Text = "City/State:"
        '
        'lbl_SrvcStreet
        '
        Me.lbl_SrvcStreet.AutoSize = True
        Me.lbl_SrvcStreet.Location = New System.Drawing.Point(25, 18)
        Me.lbl_SrvcStreet.Name = "lbl_SrvcStreet"
        Me.lbl_SrvcStreet.Size = New System.Drawing.Size(38, 13)
        Me.lbl_SrvcStreet.TabIndex = 72
        Me.lbl_SrvcStreet.Text = "Street:"
        '
        'tb_SrvcAddr1
        '
        Me.tb_SrvcAddr1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceAddr1", True))
        Me.tb_SrvcAddr1.Location = New System.Drawing.Point(69, 15)
        Me.tb_SrvcAddr1.Name = "tb_SrvcAddr1"
        Me.tb_SrvcAddr1.Size = New System.Drawing.Size(144, 20)
        Me.tb_SrvcAddr1.TabIndex = 14
        '
        'tb_SrvcAddr2
        '
        Me.tb_SrvcAddr2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceAddr2", True))
        Me.tb_SrvcAddr2.Location = New System.Drawing.Point(69, 41)
        Me.tb_SrvcAddr2.Name = "tb_SrvcAddr2"
        Me.tb_SrvcAddr2.Size = New System.Drawing.Size(144, 20)
        Me.tb_SrvcAddr2.TabIndex = 15
        '
        'tb_SrvcAddr3
        '
        Me.tb_SrvcAddr3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceAddr3", True))
        Me.tb_SrvcAddr3.Location = New System.Drawing.Point(69, 65)
        Me.tb_SrvcAddr3.Name = "tb_SrvcAddr3"
        Me.tb_SrvcAddr3.Size = New System.Drawing.Size(144, 20)
        Me.tb_SrvcAddr3.TabIndex = 16
        '
        'tb_SrvcZip
        '
        Me.tb_SrvcZip.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceZip", True))
        Me.tb_SrvcZip.Location = New System.Drawing.Point(69, 119)
        Me.tb_SrvcZip.Name = "tb_SrvcZip"
        Me.tb_SrvcZip.Size = New System.Drawing.Size(62, 20)
        Me.tb_SrvcZip.TabIndex = 19
        '
        'tb_SrvcState
        '
        Me.tb_SrvcState.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceState", True))
        Me.tb_SrvcState.Location = New System.Drawing.Point(180, 93)
        Me.tb_SrvcState.Name = "tb_SrvcState"
        Me.tb_SrvcState.Size = New System.Drawing.Size(33, 20)
        Me.tb_SrvcState.TabIndex = 18
        '
        'tb_SrvcCity
        '
        Me.tb_SrvcCity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceCity", True))
        Me.tb_SrvcCity.Location = New System.Drawing.Point(69, 93)
        Me.tb_SrvcCity.Name = "tb_SrvcCity"
        Me.tb_SrvcCity.Size = New System.Drawing.Size(105, 20)
        Me.tb_SrvcCity.TabIndex = 17
        '
        'tp_BillHist
        '
        Me.tp_BillHist.BackColor = System.Drawing.SystemColors.Control
        Me.tp_BillHist.Controls.Add(Me.dg_SrvcBillHistory)
        Me.tp_BillHist.Location = New System.Drawing.Point(4, 22)
        Me.tp_BillHist.Name = "tp_BillHist"
        Me.tp_BillHist.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_BillHist.Size = New System.Drawing.Size(853, 302)
        Me.tp_BillHist.TabIndex = 1
        Me.tp_BillHist.Text = "Service Bill History"
        '
        'dg_SrvcBillHistory
        '
        Me.dg_SrvcBillHistory.AllowUserToAddRows = False
        Me.dg_SrvcBillHistory.AllowUserToDeleteRows = False
        Me.dg_SrvcBillHistory.AutoGenerateColumns = False
        Me.dg_SrvcBillHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_SrvcBillHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BilledServiceIDDataGridViewTextBoxColumn, Me.InvRefNumberDataGridViewTextBoxColumn, Me.StartBillingDateDataGridViewTextBoxColumn, Me.EndBillingDateDataGridViewTextBoxColumn, Me.LineTotalDataGridViewTextBoxColumn})
        Me.dg_SrvcBillHistory.DataSource = Me.BilledServicesBindingSource
        Me.dg_SrvcBillHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_SrvcBillHistory.Location = New System.Drawing.Point(3, 3)
        Me.dg_SrvcBillHistory.Name = "dg_SrvcBillHistory"
        Me.dg_SrvcBillHistory.ReadOnly = True
        Me.dg_SrvcBillHistory.RowHeadersVisible = False
        Me.dg_SrvcBillHistory.Size = New System.Drawing.Size(847, 296)
        Me.dg_SrvcBillHistory.TabIndex = 0
        '
        'BilledServiceIDDataGridViewTextBoxColumn
        '
        Me.BilledServiceIDDataGridViewTextBoxColumn.DataPropertyName = "BilledServiceID"
        Me.BilledServiceIDDataGridViewTextBoxColumn.HeaderText = "BilledServiceID"
        Me.BilledServiceIDDataGridViewTextBoxColumn.Name = "BilledServiceIDDataGridViewTextBoxColumn"
        Me.BilledServiceIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.BilledServiceIDDataGridViewTextBoxColumn.Visible = False
        '
        'InvRefNumberDataGridViewTextBoxColumn
        '
        Me.InvRefNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.InvRefNumberDataGridViewTextBoxColumn.DataPropertyName = "InvRefNumber"
        Me.InvRefNumberDataGridViewTextBoxColumn.HeaderText = "Invoice #"
        Me.InvRefNumberDataGridViewTextBoxColumn.Name = "InvRefNumberDataGridViewTextBoxColumn"
        Me.InvRefNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StartBillingDateDataGridViewTextBoxColumn
        '
        Me.StartBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.StartBillingDateDataGridViewTextBoxColumn.DataPropertyName = "StartBillingDate"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.StartBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.StartBillingDateDataGridViewTextBoxColumn.HeaderText = "Start Billing Date"
        Me.StartBillingDateDataGridViewTextBoxColumn.Name = "StartBillingDateDataGridViewTextBoxColumn"
        Me.StartBillingDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EndBillingDateDataGridViewTextBoxColumn
        '
        Me.EndBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EndBillingDateDataGridViewTextBoxColumn.DataPropertyName = "EndBillingDate"
        DataGridViewCellStyle2.Format = "d"
        Me.EndBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.EndBillingDateDataGridViewTextBoxColumn.HeaderText = "End Billing Date"
        Me.EndBillingDateDataGridViewTextBoxColumn.Name = "EndBillingDateDataGridViewTextBoxColumn"
        Me.EndBillingDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LineTotalDataGridViewTextBoxColumn
        '
        Me.LineTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LineTotalDataGridViewTextBoxColumn.DataPropertyName = "LineTotal"
        DataGridViewCellStyle3.Format = "C2"
        Me.LineTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.LineTotalDataGridViewTextBoxColumn.HeaderText = "Line Total"
        Me.LineTotalDataGridViewTextBoxColumn.Name = "LineTotalDataGridViewTextBoxColumn"
        Me.LineTotalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'BilledServicesBindingSource
        '
        Me.BilledServicesBindingSource.DataMember = "BilledServices"
        Me.BilledServicesBindingSource.DataSource = Me.Ds_Display
        '
        'Ds_Display
        '
        Me.Ds_Display.DataSetName = "ds_Display"
        Me.Ds_Display.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tp_Notes
        '
        Me.tp_Notes.BackColor = System.Drawing.SystemColors.Control
        Me.tp_Notes.Controls.Add(Me.dg_ServiceNotes)
        Me.tp_Notes.Location = New System.Drawing.Point(4, 22)
        Me.tp_Notes.Name = "tp_Notes"
        Me.tp_Notes.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_Notes.Size = New System.Drawing.Size(853, 302)
        Me.tp_Notes.TabIndex = 2
        Me.tp_Notes.Text = "Service Notes"
        '
        'dg_ServiceNotes
        '
        Me.dg_ServiceNotes.AllowUserToAddRows = False
        Me.dg_ServiceNotes.AllowUserToDeleteRows = False
        Me.dg_ServiceNotes.AutoGenerateColumns = False
        Me.dg_ServiceNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_ServiceNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceNoteTextDataGridViewTextBoxColumn, Me.InsertedByUser, Me.ServiceNoteDateDataGridViewTextBoxColumn})
        Me.dg_ServiceNotes.DataSource = Me.ServiceNotesBindingSource
        Me.dg_ServiceNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_ServiceNotes.Location = New System.Drawing.Point(3, 3)
        Me.dg_ServiceNotes.Name = "dg_ServiceNotes"
        Me.dg_ServiceNotes.ReadOnly = True
        Me.dg_ServiceNotes.Size = New System.Drawing.Size(847, 296)
        Me.dg_ServiceNotes.TabIndex = 0
        '
        'ServiceNoteTextDataGridViewTextBoxColumn
        '
        Me.ServiceNoteTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ServiceNoteTextDataGridViewTextBoxColumn.DataPropertyName = "ServiceNoteText"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.HeaderText = "Note"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.Name = "ServiceNoteTextDataGridViewTextBoxColumn"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InsertedByUser
        '
        Me.InsertedByUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InsertedByUser.DataPropertyName = "InsertedByUser"
        Me.InsertedByUser.HeaderText = "User"
        Me.InsertedByUser.Name = "InsertedByUser"
        Me.InsertedByUser.ReadOnly = True
        Me.InsertedByUser.Width = 54
        '
        'ServiceNoteDateDataGridViewTextBoxColumn
        '
        Me.ServiceNoteDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ServiceNoteDateDataGridViewTextBoxColumn.DataPropertyName = "ServiceNoteDate"
        DataGridViewCellStyle4.Format = "g"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ServiceNoteDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ServiceNoteDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.Name = "ServiceNoteDateDataGridViewTextBoxColumn"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ServiceNoteDateDataGridViewTextBoxColumn.Width = 55
        '
        'ServiceNotesBindingSource
        '
        Me.ServiceNotesBindingSource.DataMember = "ServiceNotes"
        Me.ServiceNotesBindingSource.DataSource = Me.Ds_Display
        '
        'RecurringServiceTableAdapter
        '
        Me.RecurringServiceTableAdapter.ClearBeforeFill = True
        '
        'BilledServicesTableAdapter
        '
        Me.BilledServicesTableAdapter.ClearBeforeFill = True
        '
        'ServiceNotesTableAdapter
        '
        Me.ServiceNotesTableAdapter.ClearBeforeFill = True
        '
        'tp_Credits
        '
        Me.tp_Credits.BackColor = System.Drawing.SystemColors.Control
        Me.tp_Credits.Controls.Add(Me.DateTimePicker1)
        Me.tp_Credits.Controls.Add(Me.lbl_Credits)
        Me.tp_Credits.Controls.Add(Me.pnl_CreditDG)
        Me.tp_Credits.Location = New System.Drawing.Point(4, 22)
        Me.tp_Credits.Name = "tp_Credits"
        Me.tp_Credits.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_Credits.Size = New System.Drawing.Size(853, 302)
        Me.tp_Credits.TabIndex = 3
        Me.tp_Credits.Text = "Credits"
        '
        'lbl_Credits
        '
        Me.lbl_Credits.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_Credits.Location = New System.Drawing.Point(434, 3)
        Me.lbl_Credits.Name = "lbl_Credits"
        Me.lbl_Credits.Size = New System.Drawing.Size(416, 31)
        Me.lbl_Credits.TabIndex = 0
        Me.lbl_Credits.Text = "You can issue this Customer a credit linked to this Recurring Service." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "For examp" & _
    "le, a missed pickup that was billed for."
        Me.lbl_Credits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(596, 115)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'pnl_CreditDG
        '
        Me.pnl_CreditDG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_CreditDG.Controls.Add(Me.dg_CreditHistory)
        Me.pnl_CreditDG.Controls.Add(Me.lbl_CreditDG)
        Me.pnl_CreditDG.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_CreditDG.Location = New System.Drawing.Point(3, 3)
        Me.pnl_CreditDG.Name = "pnl_CreditDG"
        Me.pnl_CreditDG.Size = New System.Drawing.Size(431, 296)
        Me.pnl_CreditDG.TabIndex = 2
        '
        'lbl_CreditDG
        '
        Me.lbl_CreditDG.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_CreditDG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CreditDG.Location = New System.Drawing.Point(0, 0)
        Me.lbl_CreditDG.Name = "lbl_CreditDG"
        Me.lbl_CreditDG.Size = New System.Drawing.Size(429, 25)
        Me.lbl_CreditDG.TabIndex = 1
        Me.lbl_CreditDG.Text = "Credit History"
        '
        'dg_CreditHistory
        '
        Me.dg_CreditHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_CreditHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_CreditHistory.Location = New System.Drawing.Point(0, 25)
        Me.dg_CreditHistory.Name = "dg_CreditHistory"
        Me.dg_CreditHistory.Size = New System.Drawing.Size(429, 269)
        Me.dg_CreditHistory.TabIndex = 2
        '
        'RecurringService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 415)
        Me.Controls.Add(Me.tc_Master)
        Me.Controls.Add(Me.pnl_Top)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecurringService"
        Me.Text = "RecurringService"
        Me.grp_PickupDay.ResumeLayout(False)
        Me.grp_PickupDay.PerformLayout()
        CType(Me.RecurringServiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Program, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        Me.grp_BasicInfo.ResumeLayout(False)
        Me.grp_BasicInfo.PerformLayout()
        CType(Me.nud_BillLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_Quantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Dates.ResumeLayout(False)
        Me.grp_Dates.PerformLayout()
        Me.tc_Master.ResumeLayout(False)
        Me.tp_SrvcInfo.ResumeLayout(False)
        Me.tp_SrvcInfo.PerformLayout()
        Me.grp_SrvcAddr.ResumeLayout(False)
        Me.grp_SrvcAddr.PerformLayout()
        Me.tp_BillHist.ResumeLayout(False)
        CType(Me.dg_SrvcBillHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BilledServicesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Notes.ResumeLayout(False)
        CType(Me.dg_ServiceNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServiceNotesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Credits.ResumeLayout(False)
        Me.pnl_CreditDG.ResumeLayout(False)
        CType(Me.dg_CreditHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ck_EndDate As System.Windows.Forms.CheckBox
    Friend WithEvents grp_PickupDay As System.Windows.Forms.GroupBox
    Friend WithEvents ck_Sat As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Fri As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Thurs As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Weds As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Sun As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Tues As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Mon As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents lbl_BillThru As System.Windows.Forms.Label
    Friend WithEvents lbl_CustName As System.Windows.Forms.Label
    Friend WithEvents grp_BasicInfo As System.Windows.Forms.GroupBox
    Friend WithEvents nud_Quantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl_Quantity As System.Windows.Forms.Label
    Friend WithEvents tb_Rate As TrashCash.Currency_TextBox
    Friend WithEvents lbl_DefPriceValue As System.Windows.Forms.Label
    Friend WithEvents lbl_DefPriceHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_Rate As System.Windows.Forms.Label
    Friend WithEvents nud_BillLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grp_Dates As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Approve As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents tc_Master As System.Windows.Forms.TabControl
    Friend WithEvents tp_SrvcInfo As System.Windows.Forms.TabPage
    Friend WithEvents tp_BillHist As System.Windows.Forms.TabPage
    Friend WithEvents grp_SrvcAddr As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_SrvcZip As System.Windows.Forms.Label
    Friend WithEvents lbl_SrvcCityState As System.Windows.Forms.Label
    Friend WithEvents lbl_SrvcStreet As System.Windows.Forms.Label
    Friend WithEvents tb_SrvcAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcAddr3 As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcZip As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcState As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcCity As System.Windows.Forms.TextBox
    Friend WithEvents btn_CopyAddr As System.Windows.Forms.Button
    Friend WithEvents tp_Notes As System.Windows.Forms.TabPage
    Friend WithEvents dg_SrvcBillHistory As System.Windows.Forms.DataGridView
    Friend WithEvents BilledServiceIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvRefNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledServicesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Display As TrashCash.ds_Display
    Friend WithEvents dg_ServiceNotes As System.Windows.Forms.DataGridView
    Friend WithEvents ServiceNotesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BilledServicesTableAdapter As TrashCash.ds_DisplayTableAdapters.BilledServicesTableAdapter
    Friend WithEvents ServiceNotesTableAdapter As TrashCash.ds_DisplayTableAdapters.ServiceNotesTableAdapter
    Friend WithEvents Ds_Program As TrashCash.ds_Program
    Friend WithEvents RecurringServiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecurringServiceTableAdapter As TrashCash.ds_ProgramTableAdapters.RecurringServiceTableAdapter
    Friend WithEvents Cmb_ServiceTypes As TrashCash.Database_ComboBoxes.cmb_ServiceTypes
    Friend WithEvents lbl_RecStatus As System.Windows.Forms.Label
    Friend WithEvents lbl_CreditMsg As System.Windows.Forms.Label
    Friend WithEvents ServiceNoteTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertedByUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNoteDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tt_BillLength As System.Windows.Forms.ToolTip
    Friend WithEvents tp_Credits As System.Windows.Forms.TabPage
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Credits As System.Windows.Forms.Label
    Friend WithEvents pnl_CreditDG As System.Windows.Forms.Panel
    Friend WithEvents dg_CreditHistory As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_CreditDG As System.Windows.Forms.Label
End Class
