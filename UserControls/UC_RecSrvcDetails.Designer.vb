<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_RecSrvcDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_RecSrvcDetails))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Left = New System.Windows.Forms.Panel()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.tc_RecSrvc = New System.Windows.Forms.TabControl()
        Me.Notes = New System.Windows.Forms.TabPage()
        Me.dg_Notes = New System.Windows.Forms.DataGridView()
        Me.ServiceNoteTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNoteDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm_Notes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cm_i_NewNote = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceNotesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.AddrInfo = New System.Windows.Forms.TabPage()
        Me.btn_CopyAddr = New System.Windows.Forms.Button()
        Me.lbl_AddrInfo = New System.Windows.Forms.Label()
        Me.grp_SrvcAddr = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tb_SrvcAddr1 = New System.Windows.Forms.TextBox()
        Me.RecurringServiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tb_SrvcAddr2 = New System.Windows.Forms.TextBox()
        Me.tb_SrvcAddr3 = New System.Windows.Forms.TextBox()
        Me.tb_SrvcZip = New System.Windows.Forms.TextBox()
        Me.tb_SrvcState = New System.Windows.Forms.TextBox()
        Me.tb_SrvcCity = New System.Windows.Forms.TextBox()
        Me.grp_EndDate = New System.Windows.Forms.GroupBox()
        Me.lbl_LastInvDate = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_LastInvHeader = New System.Windows.Forms.Label()
        Me.ck_EndDate = New System.Windows.Forms.CheckBox()
        Me.btn_Commit = New System.Windows.Forms.Button()
        Me.srvcInfoGrp = New System.Windows.Forms.GroupBox()
        Me.tb_Rate = New TrashCash.Currency_TextBox()
        Me.Cmb_ServiceTypes = New TrashCash.Database_ComboBoxes.cmb_ServiceTypes()
        Me.lbl_AssetID = New System.Windows.Forms.Label()
        Me.nud_BillLength = New System.Windows.Forms.NumericUpDown()
        Me.lbl_DefPriceValue = New System.Windows.Forms.Label()
        Me.lbl_DefPriceHeader = New System.Windows.Forms.Label()
        Me.grp_PickupDay = New System.Windows.Forms.GroupBox()
        Me.ck_Sat = New System.Windows.Forms.CheckBox()
        Me.ck_Fri = New System.Windows.Forms.CheckBox()
        Me.ck_Thurs = New System.Windows.Forms.CheckBox()
        Me.ck_Weds = New System.Windows.Forms.CheckBox()
        Me.ck_Sun = New System.Windows.Forms.CheckBox()
        Me.ck_Tues = New System.Windows.Forms.CheckBox()
        Me.ck_Mon = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tt_BillLength = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceTableAdapter = New TrashCash.DataSetTableAdapters.RecurringServiceTableAdapter()
        Me.ServiceNotesTableAdapter = New TrashCash.DataSetTableAdapters.ServiceNotesTableAdapter()
        Me.pnl_Left.SuspendLayout()
        Me.pnl_Right.SuspendLayout()
        Me.tc_RecSrvc.SuspendLayout()
        Me.Notes.SuspendLayout()
        CType(Me.dg_Notes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm_Notes.SuspendLayout()
        CType(Me.ServiceNotesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddrInfo.SuspendLayout()
        Me.grp_SrvcAddr.SuspendLayout()
        CType(Me.RecurringServiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_EndDate.SuspendLayout()
        Me.srvcInfoGrp.SuspendLayout()
        CType(Me.nud_BillLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_PickupDay.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Left
        '
        Me.pnl_Left.Controls.Add(Me.pnl_Right)
        Me.pnl_Left.Controls.Add(Me.grp_EndDate)
        Me.pnl_Left.Controls.Add(Me.btn_Commit)
        Me.pnl_Left.Controls.Add(Me.srvcInfoGrp)
        Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Left.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Left.Name = "pnl_Left"
        Me.pnl_Left.Size = New System.Drawing.Size(900, 219)
        Me.pnl_Left.TabIndex = 71
        '
        'pnl_Right
        '
        Me.pnl_Right.Controls.Add(Me.tc_RecSrvc)
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(430, 0)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(470, 219)
        Me.pnl_Right.TabIndex = 69
        '
        'tc_RecSrvc
        '
        Me.tc_RecSrvc.Controls.Add(Me.Notes)
        Me.tc_RecSrvc.Controls.Add(Me.AddrInfo)
        Me.tc_RecSrvc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_RecSrvc.Location = New System.Drawing.Point(0, 0)
        Me.tc_RecSrvc.Name = "tc_RecSrvc"
        Me.tc_RecSrvc.SelectedIndex = 0
        Me.tc_RecSrvc.Size = New System.Drawing.Size(470, 219)
        Me.tc_RecSrvc.TabIndex = 1
        '
        'Notes
        '
        Me.Notes.BackColor = System.Drawing.SystemColors.Control
        Me.Notes.Controls.Add(Me.dg_Notes)
        Me.Notes.Location = New System.Drawing.Point(4, 22)
        Me.Notes.Name = "Notes"
        Me.Notes.Padding = New System.Windows.Forms.Padding(3)
        Me.Notes.Size = New System.Drawing.Size(462, 193)
        Me.Notes.TabIndex = 0
        Me.Notes.Text = "Recurring Service Notes"
        '
        'dg_Notes
        '
        Me.dg_Notes.AllowUserToAddRows = False
        Me.dg_Notes.AllowUserToDeleteRows = False
        Me.dg_Notes.AllowUserToResizeRows = False
        Me.dg_Notes.AutoGenerateColumns = False
        Me.dg_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Notes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceNoteTextDataGridViewTextBoxColumn, Me.ServiceNoteDateDataGridViewTextBoxColumn})
        Me.dg_Notes.ContextMenuStrip = Me.cm_Notes
        Me.dg_Notes.DataSource = Me.ServiceNotesBindingSource
        Me.dg_Notes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_Notes.Location = New System.Drawing.Point(3, 3)
        Me.dg_Notes.Name = "dg_Notes"
        Me.dg_Notes.ReadOnly = True
        Me.dg_Notes.RowHeadersVisible = False
        Me.dg_Notes.Size = New System.Drawing.Size(456, 187)
        Me.dg_Notes.TabIndex = 0
        '
        'ServiceNoteTextDataGridViewTextBoxColumn
        '
        Me.ServiceNoteTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ServiceNoteTextDataGridViewTextBoxColumn.DataPropertyName = "ServiceNoteText"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.HeaderText = "Note"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.Name = "ServiceNoteTextDataGridViewTextBoxColumn"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ServiceNoteDateDataGridViewTextBoxColumn
        '
        Me.ServiceNoteDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ServiceNoteDateDataGridViewTextBoxColumn.DataPropertyName = "ServiceNoteDate"
        DataGridViewCellStyle1.Format = "d"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ServiceNoteDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.Name = "ServiceNoteDateDataGridViewTextBoxColumn"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ServiceNoteDateDataGridViewTextBoxColumn.Width = 55
        '
        'cm_Notes
        '
        Me.cm_Notes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_i_NewNote})
        Me.cm_Notes.Name = "cm_Notes"
        Me.cm_Notes.Size = New System.Drawing.Size(128, 26)
        '
        'cm_i_NewNote
        '
        Me.cm_i_NewNote.Name = "cm_i_NewNote"
        Me.cm_i_NewNote.Size = New System.Drawing.Size(127, 22)
        Me.cm_i_NewNote.Text = "New Note"
        '
        'ServiceNotesBindingSource
        '
        Me.ServiceNotesBindingSource.DataMember = "ServiceNotes"
        Me.ServiceNotesBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.EnforceConstraints = False
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AddrInfo
        '
        Me.AddrInfo.BackColor = System.Drawing.SystemColors.Control
        Me.AddrInfo.Controls.Add(Me.btn_CopyAddr)
        Me.AddrInfo.Controls.Add(Me.lbl_AddrInfo)
        Me.AddrInfo.Controls.Add(Me.grp_SrvcAddr)
        Me.AddrInfo.Location = New System.Drawing.Point(4, 22)
        Me.AddrInfo.Name = "AddrInfo"
        Me.AddrInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.AddrInfo.Size = New System.Drawing.Size(462, 193)
        Me.AddrInfo.TabIndex = 1
        Me.AddrInfo.Text = "Service Address"
        '
        'btn_CopyAddr
        '
        Me.btn_CopyAddr.AutoSize = True
        Me.btn_CopyAddr.Location = New System.Drawing.Point(250, 72)
        Me.btn_CopyAddr.Name = "btn_CopyAddr"
        Me.btn_CopyAddr.Size = New System.Drawing.Size(159, 23)
        Me.btn_CopyAddr.TabIndex = 75
        Me.btn_CopyAddr.Text = "Copy Customer Billing Address"
        Me.btn_CopyAddr.UseVisualStyleBackColor = True
        '
        'lbl_AddrInfo
        '
        Me.lbl_AddrInfo.Location = New System.Drawing.Point(239, 10)
        Me.lbl_AddrInfo.Name = "lbl_AddrInfo"
        Me.lbl_AddrInfo.Size = New System.Drawing.Size(185, 16)
        Me.lbl_AddrInfo.TabIndex = 74
        Me.lbl_AddrInfo.Text = "This Address will print on Reports."
        '
        'grp_SrvcAddr
        '
        Me.grp_SrvcAddr.Controls.Add(Me.Label17)
        Me.grp_SrvcAddr.Controls.Add(Me.Label18)
        Me.grp_SrvcAddr.Controls.Add(Me.Label19)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcAddr1)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcAddr2)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcAddr3)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcZip)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcState)
        Me.grp_SrvcAddr.Controls.Add(Me.tb_SrvcCity)
        Me.grp_SrvcAddr.Location = New System.Drawing.Point(6, 6)
        Me.grp_SrvcAddr.Name = "grp_SrvcAddr"
        Me.grp_SrvcAddr.Size = New System.Drawing.Size(223, 150)
        Me.grp_SrvcAddr.TabIndex = 72
        Me.grp_SrvcAddr.TabStop = False
        Me.grp_SrvcAddr.Text = "Recurring Service Address"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(38, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(25, 13)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "Zip:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 13)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "City/State:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(25, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "Street:"
        '
        'tb_SrvcAddr1
        '
        Me.tb_SrvcAddr1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceAddr1", True))
        Me.tb_SrvcAddr1.Location = New System.Drawing.Point(69, 15)
        Me.tb_SrvcAddr1.Name = "tb_SrvcAddr1"
        Me.tb_SrvcAddr1.Size = New System.Drawing.Size(144, 20)
        Me.tb_SrvcAddr1.TabIndex = 66
        '
        'RecurringServiceBindingSource
        '
        Me.RecurringServiceBindingSource.DataMember = "RecurringService"
        Me.RecurringServiceBindingSource.DataSource = Me.DataSet
        '
        'tb_SrvcAddr2
        '
        Me.tb_SrvcAddr2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceAddr2", True))
        Me.tb_SrvcAddr2.Location = New System.Drawing.Point(69, 41)
        Me.tb_SrvcAddr2.Name = "tb_SrvcAddr2"
        Me.tb_SrvcAddr2.Size = New System.Drawing.Size(144, 20)
        Me.tb_SrvcAddr2.TabIndex = 67
        '
        'tb_SrvcAddr3
        '
        Me.tb_SrvcAddr3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceAddr3", True))
        Me.tb_SrvcAddr3.Location = New System.Drawing.Point(69, 65)
        Me.tb_SrvcAddr3.Name = "tb_SrvcAddr3"
        Me.tb_SrvcAddr3.Size = New System.Drawing.Size(144, 20)
        Me.tb_SrvcAddr3.TabIndex = 68
        '
        'tb_SrvcZip
        '
        Me.tb_SrvcZip.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceZip", True))
        Me.tb_SrvcZip.Location = New System.Drawing.Point(69, 119)
        Me.tb_SrvcZip.Name = "tb_SrvcZip"
        Me.tb_SrvcZip.Size = New System.Drawing.Size(62, 20)
        Me.tb_SrvcZip.TabIndex = 71
        '
        'tb_SrvcState
        '
        Me.tb_SrvcState.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceState", True))
        Me.tb_SrvcState.Location = New System.Drawing.Point(180, 93)
        Me.tb_SrvcState.Name = "tb_SrvcState"
        Me.tb_SrvcState.Size = New System.Drawing.Size(33, 20)
        Me.tb_SrvcState.TabIndex = 70
        '
        'tb_SrvcCity
        '
        Me.tb_SrvcCity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceCity", True))
        Me.tb_SrvcCity.Location = New System.Drawing.Point(69, 93)
        Me.tb_SrvcCity.Name = "tb_SrvcCity"
        Me.tb_SrvcCity.Size = New System.Drawing.Size(105, 20)
        Me.tb_SrvcCity.TabIndex = 69
        '
        'grp_EndDate
        '
        Me.grp_EndDate.Controls.Add(Me.lbl_LastInvDate)
        Me.grp_EndDate.Controls.Add(Me.dtp_EndDate)
        Me.grp_EndDate.Controls.Add(Me.lbl_LastInvHeader)
        Me.grp_EndDate.Controls.Add(Me.ck_EndDate)
        Me.grp_EndDate.Location = New System.Drawing.Point(3, 155)
        Me.grp_EndDate.Name = "grp_EndDate"
        Me.grp_EndDate.Size = New System.Drawing.Size(242, 57)
        Me.grp_EndDate.TabIndex = 68
        Me.grp_EndDate.TabStop = False
        Me.grp_EndDate.Text = "End Date"
        '
        'lbl_LastInvDate
        '
        Me.lbl_LastInvDate.AutoSize = True
        Me.lbl_LastInvDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LastInvDate.Location = New System.Drawing.Point(135, 37)
        Me.lbl_LastInvDate.Name = "lbl_LastInvDate"
        Me.lbl_LastInvDate.Size = New System.Drawing.Size(75, 13)
        Me.lbl_LastInvDate.TabIndex = 71
        Me.lbl_LastInvDate.Text = "10/10/1990"
        Me.lbl_LastInvDate.Visible = False
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_EndDate.Location = New System.Drawing.Point(134, 14)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(79, 20)
        Me.dtp_EndDate.TabIndex = 66
        '
        'lbl_LastInvHeader
        '
        Me.lbl_LastInvHeader.AutoSize = True
        Me.lbl_LastInvHeader.Location = New System.Drawing.Point(9, 37)
        Me.lbl_LastInvHeader.Name = "lbl_LastInvHeader"
        Me.lbl_LastInvHeader.Size = New System.Drawing.Size(84, 13)
        Me.lbl_LastInvHeader.TabIndex = 70
        Me.lbl_LastInvHeader.Text = "Invoiced Up To:"
        Me.lbl_LastInvHeader.Visible = False
        '
        'ck_EndDate
        '
        Me.ck_EndDate.AutoSize = True
        Me.ck_EndDate.Location = New System.Drawing.Point(6, 17)
        Me.ck_EndDate.Name = "ck_EndDate"
        Me.ck_EndDate.Size = New System.Drawing.Size(122, 17)
        Me.ck_EndDate.TabIndex = 0
        Me.ck_EndDate.Text = "Last Day of Service:"
        Me.ck_EndDate.UseVisualStyleBackColor = True
        '
        'btn_Commit
        '
        Me.btn_Commit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_Commit.Location = New System.Drawing.Point(251, 169)
        Me.btn_Commit.Name = "btn_Commit"
        Me.btn_Commit.Size = New System.Drawing.Size(122, 23)
        Me.btn_Commit.TabIndex = 4
        Me.btn_Commit.Text = "Add Recurring Service"
        Me.btn_Commit.UseVisualStyleBackColor = True
        '
        'srvcInfoGrp
        '
        Me.srvcInfoGrp.Controls.Add(Me.tb_Rate)
        Me.srvcInfoGrp.Controls.Add(Me.Cmb_ServiceTypes)
        Me.srvcInfoGrp.Controls.Add(Me.lbl_AssetID)
        Me.srvcInfoGrp.Controls.Add(Me.nud_BillLength)
        Me.srvcInfoGrp.Controls.Add(Me.lbl_DefPriceValue)
        Me.srvcInfoGrp.Controls.Add(Me.lbl_DefPriceHeader)
        Me.srvcInfoGrp.Controls.Add(Me.grp_PickupDay)
        Me.srvcInfoGrp.Controls.Add(Me.Label5)
        Me.srvcInfoGrp.Controls.Add(Me.dtp_StartDate)
        Me.srvcInfoGrp.Controls.Add(Me.Label1)
        Me.srvcInfoGrp.Controls.Add(Me.Label3)
        Me.srvcInfoGrp.Location = New System.Drawing.Point(3, 3)
        Me.srvcInfoGrp.Name = "srvcInfoGrp"
        Me.srvcInfoGrp.Size = New System.Drawing.Size(388, 146)
        Me.srvcInfoGrp.TabIndex = 65
        Me.srvcInfoGrp.TabStop = False
        Me.srvcInfoGrp.Text = "Service Information"
        '
        'tb_Rate
        '
        Me.tb_Rate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RecurringServiceBindingSource, "RecurringServiceRate", True))
        Me.tb_Rate.Location = New System.Drawing.Point(197, 43)
        Me.tb_Rate.Name = "tb_Rate"
        Me.tb_Rate.Size = New System.Drawing.Size(66, 20)
        Me.tb_Rate.TabIndex = 74
        '
        'Cmb_ServiceTypes
        '
        Me.Cmb_ServiceTypes.DisplayMember = "ServiceName"
        Me.Cmb_ServiceTypes.FormattingEnabled = True
        Me.Cmb_ServiceTypes.Location = New System.Drawing.Point(12, 17)
        Me.Cmb_ServiceTypes.Name = "Cmb_ServiceTypes"
        Me.Cmb_ServiceTypes.Size = New System.Drawing.Size(364, 21)
        Me.Cmb_ServiceTypes.TabIndex = 73
        Me.Cmb_ServiceTypes.ValueMember = "ServiceTypeID"
        '
        'lbl_AssetID
        '
        Me.lbl_AssetID.AutoSize = True
        Me.lbl_AssetID.Location = New System.Drawing.Point(158, 76)
        Me.lbl_AssetID.Name = "lbl_AssetID"
        Me.lbl_AssetID.Size = New System.Drawing.Size(74, 13)
        Me.lbl_AssetID.TabIndex = 72
        Me.lbl_AssetID.Text = "Equipment ID:"
        '
        'nud_BillLength
        '
        Me.nud_BillLength.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RecurringServiceBindingSource, "RecurringServiceBillLength", True))
        Me.nud_BillLength.Location = New System.Drawing.Point(334, 44)
        Me.nud_BillLength.Name = "nud_BillLength"
        Me.nud_BillLength.Size = New System.Drawing.Size(36, 20)
        Me.nud_BillLength.TabIndex = 71
        Me.nud_BillLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_DefPriceValue
        '
        Me.lbl_DefPriceValue.AutoSize = True
        Me.lbl_DefPriceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_DefPriceValue.Location = New System.Drawing.Point(83, 46)
        Me.lbl_DefPriceValue.Name = "lbl_DefPriceValue"
        Me.lbl_DefPriceValue.Size = New System.Drawing.Size(48, 15)
        Me.lbl_DefPriceValue.TabIndex = 70
        Me.lbl_DefPriceValue.Text = "$100.00"
        '
        'lbl_DefPriceHeader
        '
        Me.lbl_DefPriceHeader.AutoSize = True
        Me.lbl_DefPriceHeader.Location = New System.Drawing.Point(6, 47)
        Me.lbl_DefPriceHeader.Name = "lbl_DefPriceHeader"
        Me.lbl_DefPriceHeader.Size = New System.Drawing.Size(70, 13)
        Me.lbl_DefPriceHeader.TabIndex = 66
        Me.lbl_DefPriceHeader.Text = "Default Rate:"
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
        Me.grp_PickupDay.Location = New System.Drawing.Point(6, 99)
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
        Me.ck_Sat.TabIndex = 72
        Me.ck_Sat.Text = "Sat"
        Me.ck_Sat.UseVisualStyleBackColor = True
        '
        'ck_Fri
        '
        Me.ck_Fri.AutoSize = True
        Me.ck_Fri.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.RecurringServiceBindingSource, "PU_Friday", True))
        Me.ck_Fri.Location = New System.Drawing.Point(285, 18)
        Me.ck_Fri.Name = "ck_Fri"
        Me.ck_Fri.Size = New System.Drawing.Size(37, 17)
        Me.ck_Fri.TabIndex = 70
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
        Me.ck_Thurs.TabIndex = 71
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
        Me.ck_Weds.TabIndex = 70
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
        Me.ck_Sun.TabIndex = 70
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
        Me.ck_Tues.TabIndex = 1
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
        Me.ck_Mon.TabIndex = 0
        Me.ck_Mon.Text = "Mon"
        Me.ck_Mon.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Start Date:"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RecurringServiceBindingSource, "RecurringServiceStartDate", True))
        Me.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_StartDate.Location = New System.Drawing.Point(71, 73)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(79, 20)
        Me.dtp_StartDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(158, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Rate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Bill Length:"
        Me.tt_BillLength.SetToolTip(Me.Label3, "This is how long this service is rated for. A Bill Length of two means this rate " & _
        "is for two months of service.")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ServiceNoteText"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Note"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ServiceNoteDate"
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'RecurringServiceTableAdapter
        '
        Me.RecurringServiceTableAdapter.ClearBeforeFill = True
        '
        'ServiceNotesTableAdapter
        '
        Me.ServiceNotesTableAdapter.ClearBeforeFill = True
        '
        'UC_RecSrvcDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnl_Left)
        Me.Name = "UC_RecSrvcDetails"
        Me.Size = New System.Drawing.Size(900, 219)
        Me.pnl_Left.ResumeLayout(False)
        Me.pnl_Right.ResumeLayout(False)
        Me.tc_RecSrvc.ResumeLayout(False)
        Me.Notes.ResumeLayout(False)
        CType(Me.dg_Notes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm_Notes.ResumeLayout(False)
        CType(Me.ServiceNotesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddrInfo.ResumeLayout(False)
        Me.AddrInfo.PerformLayout()
        Me.grp_SrvcAddr.ResumeLayout(False)
        Me.grp_SrvcAddr.PerformLayout()
        CType(Me.RecurringServiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_EndDate.ResumeLayout(False)
        Me.grp_EndDate.PerformLayout()
        Me.srvcInfoGrp.ResumeLayout(False)
        Me.srvcInfoGrp.PerformLayout()
        CType(Me.nud_BillLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_PickupDay.ResumeLayout(False)
        Me.grp_PickupDay.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Left As System.Windows.Forms.Panel
    Friend WithEvents grp_EndDate As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ck_EndDate As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Commit As System.Windows.Forms.Button
    Friend WithEvents srvcInfoGrp As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_DefPriceHeader As System.Windows.Forms.Label
    Friend WithEvents grp_PickupDay As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_DefPriceValue As System.Windows.Forms.Label
    Friend WithEvents RecurringServiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents RecurringServiceTableAdapter As TrashCash.DataSetTableAdapters.RecurringServiceTableAdapter
    Friend WithEvents pnl_Right As System.Windows.Forms.Panel
    Friend WithEvents dg_Notes As System.Windows.Forms.DataGridView
    Friend WithEvents ServiceNoteTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNoteDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNotesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServiceNotesTableAdapter As TrashCash.DataSetTableAdapters.ServiceNotesTableAdapter
    Friend WithEvents cm_Notes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cm_i_NewNote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ck_Sat As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Fri As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Thurs As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Weds As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Sun As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Tues As System.Windows.Forms.CheckBox
    Friend WithEvents ck_Mon As System.Windows.Forms.CheckBox
    Friend WithEvents tt_BillLength As System.Windows.Forms.ToolTip
    Friend WithEvents tc_RecSrvc As System.Windows.Forms.TabControl
    Friend WithEvents Notes As System.Windows.Forms.TabPage
    Friend WithEvents AddrInfo As System.Windows.Forms.TabPage
    Friend WithEvents grp_SrvcAddr As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tb_SrvcAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcAddr3 As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcZip As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcState As System.Windows.Forms.TextBox
    Friend WithEvents tb_SrvcCity As System.Windows.Forms.TextBox
    Friend WithEvents lbl_LastInvDate As System.Windows.Forms.Label
    Friend WithEvents lbl_LastInvHeader As System.Windows.Forms.Label
    Friend WithEvents nud_BillLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl_AddrInfo As System.Windows.Forms.Label
    Friend WithEvents lbl_AssetID As System.Windows.Forms.Label
    Friend WithEvents Cmb_ServiceTypes As TrashCash.Database_ComboBoxes.cmb_ServiceTypes
    Friend WithEvents tb_Rate As TrashCash.Currency_TextBox
    Friend WithEvents btn_CopyAddr As System.Windows.Forms.Button

End Class
