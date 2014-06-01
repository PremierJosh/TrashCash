Namespace Customer
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UC_CustomerInfoBoxes
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
            Me.grp_SrvcInvInfo = New System.Windows.Forms.GroupBox()
            Me.nud_BillInterval = New System.Windows.Forms.NumericUpDown()
            Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Customer = New TrashCash.ds_Customer()
           Me.ck_SingleInv = New System.Windows.Forms.CheckBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
            Me.chk_CustPrintInv = New System.Windows.Forms.CheckBox()
            Me.chk_CustBillAdvance = New System.Windows.Forms.CheckBox()
            Me.grp_GenInfo = New System.Windows.Forms.GroupBox()
            Me.tb_CompanyName = New System.Windows.Forms.TextBox()
            Me.lbl_CompName = New System.Windows.Forms.Label()
            Me.lbl_LastName = New System.Windows.Forms.Label()
            Me.tb_LastName = New System.Windows.Forms.TextBox()
            Me.lbl_FirstName = New System.Windows.Forms.Label()
            Me.tb_FirstName = New System.Windows.Forms.TextBox()
            Me.box_CustNum = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.box_CustFullName = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.box_CustPhone = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.box_CustAltPhone = New System.Windows.Forms.TextBox()
            Me.chk_CustDeactive = New System.Windows.Forms.CheckBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.box_CustContact = New System.Windows.Forms.TextBox()
            Me.cm_Update = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.btn_UpdateInfo = New System.Windows.Forms.ToolStripMenuItem()
            Me.btn_SaveChanges = New System.Windows.Forms.ToolStripMenuItem()
            Me.grp_BillAddr = New System.Windows.Forms.GroupBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.tb_BillAddr4 = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.box_CustBillAddr1 = New System.Windows.Forms.TextBox()
            Me.box_CustBillAddr2 = New System.Windows.Forms.TextBox()
            Me.box_CustBillCity = New System.Windows.Forms.TextBox()
            Me.box_CustBillAddr3 = New System.Windows.Forms.TextBox()
            Me.box_CustBillState = New System.Windows.Forms.TextBox()
            Me.box_CustBillZip = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.tt_CustBillInterval = New System.Windows.Forms.ToolTip(Me.components)
            Me.CustomerTableAdapter = New TrashCash.ds_CustomerTableAdapters.CustomerTableAdapter()
            Me.lbl_BillInterval = New System.Windows.Forms.Label()
            Me.grp_SrvcInvInfo.SuspendLayout()
            CType(Me.nud_BillInterval, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_GenInfo.SuspendLayout()
            Me.cm_Update.SuspendLayout()
            Me.grp_BillAddr.SuspendLayout()
            Me.SuspendLayout()
            '
            'grp_SrvcInvInfo
            '
            Me.grp_SrvcInvInfo.Controls.Add(Me.nud_BillInterval)
           Me.grp_SrvcInvInfo.Controls.Add(Me.ck_SingleInv)
            Me.grp_SrvcInvInfo.Controls.Add(Me.Label10)
            Me.grp_SrvcInvInfo.Controls.Add(Me.dtp_StartDate)
            Me.grp_SrvcInvInfo.Controls.Add(Me.chk_CustPrintInv)
            Me.grp_SrvcInvInfo.Controls.Add(Me.chk_CustBillAdvance)
            Me.grp_SrvcInvInfo.Location = New System.Drawing.Point(484, 3)
            Me.grp_SrvcInvInfo.Name = "grp_SrvcInvInfo"
            Me.grp_SrvcInvInfo.Size = New System.Drawing.Size(172, 169)
            Me.grp_SrvcInvInfo.TabIndex = 2
            Me.grp_SrvcInvInfo.TabStop = False
            Me.grp_SrvcInvInfo.Text = "Service and Invoice Information"
            '
            'nud_BillInterval
            '
            Me.nud_BillInterval.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CustomerBindingSource, "CustomerBillInterval", True))
            Me.nud_BillInterval.Location = New System.Drawing.Point(107, 140)
            Me.nud_BillInterval.Name = "nud_BillInterval"
            Me.nud_BillInterval.Size = New System.Drawing.Size(31, 20)
            Me.nud_BillInterval.TabIndex = 10
            Me.nud_BillInterval.Value = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nud_BillInterval.Visible = False
            '
            'CustomerBindingSource
            '
            Me.CustomerBindingSource.DataMember = "Customer"
            Me.CustomerBindingSource.DataSource = Me.Ds_Customer
            '
            'Ds_Customer
            '
            Me.Ds_Customer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        
            '
            'ck_SingleInv
            '
            Me.ck_SingleInv.AutoSize = True
            Me.ck_SingleInv.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerReceiveOneInvoice", True))
            Me.ck_SingleInv.Location = New System.Drawing.Point(10, 121)
            Me.ck_SingleInv.Name = "ck_SingleInv"
            Me.ck_SingleInv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.ck_SingleInv.Size = New System.Drawing.Size(141, 17)
            Me.ck_SingleInv.TabIndex = 9
            Me.ck_SingleInv.Text = "Receives Single Invoice"
            Me.ck_SingleInv.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(6, 73)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(58, 13)
            Me.Label10.TabIndex = 70
            Me.Label10.Text = "Start Date:"
            '
            'dtp_StartDate
            '
            Me.dtp_StartDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CustomerBindingSource, "CustomerStartDate", True))
            Me.dtp_StartDate.Enabled = False
            Me.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_StartDate.Location = New System.Drawing.Point(70, 68)
            Me.dtp_StartDate.Name = "dtp_StartDate"
            Me.dtp_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.dtp_StartDate.TabIndex = 8
            Me.dtp_StartDate.TabStop = False
            '
            'chk_CustPrintInv
            '
            Me.chk_CustPrintInv.AutoSize = True
            Me.chk_CustPrintInv.Checked = True
            Me.chk_CustPrintInv.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chk_CustPrintInv.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerPrintInvoices", True))
            Me.chk_CustPrintInv.Location = New System.Drawing.Point(61, 45)
            Me.chk_CustPrintInv.Name = "chk_CustPrintInv"
            Me.chk_CustPrintInv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chk_CustPrintInv.Size = New System.Drawing.Size(90, 17)
            Me.chk_CustPrintInv.TabIndex = 7
            Me.chk_CustPrintInv.Text = "Print Invoices"
            Me.chk_CustPrintInv.UseVisualStyleBackColor = True
            '
            'chk_CustBillAdvance
            '
            Me.chk_CustBillAdvance.AutoSize = True
            Me.chk_CustBillAdvance.Checked = True
            Me.chk_CustBillAdvance.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chk_CustBillAdvance.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerBilledInAdvance", True))
            Me.chk_CustBillAdvance.Location = New System.Drawing.Point(43, 22)
            Me.chk_CustBillAdvance.Name = "chk_CustBillAdvance"
            Me.chk_CustBillAdvance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chk_CustBillAdvance.Size = New System.Drawing.Size(108, 17)
            Me.chk_CustBillAdvance.TabIndex = 6
            Me.chk_CustBillAdvance.Text = "Billed in Advance"
            Me.chk_CustBillAdvance.UseVisualStyleBackColor = True
            '
            'grp_GenInfo
            '
            Me.grp_GenInfo.Controls.Add(Me.tb_CompanyName)
            Me.grp_GenInfo.Controls.Add(Me.lbl_CompName)
            Me.grp_GenInfo.Controls.Add(Me.lbl_LastName)
            Me.grp_GenInfo.Controls.Add(Me.tb_LastName)
            Me.grp_GenInfo.Controls.Add(Me.lbl_FirstName)
            Me.grp_GenInfo.Controls.Add(Me.tb_FirstName)
            Me.grp_GenInfo.Controls.Add(Me.box_CustNum)
            Me.grp_GenInfo.Controls.Add(Me.Label1)
            Me.grp_GenInfo.Controls.Add(Me.box_CustFullName)
            Me.grp_GenInfo.Controls.Add(Me.Label2)
            Me.grp_GenInfo.Controls.Add(Me.box_CustPhone)
            Me.grp_GenInfo.Controls.Add(Me.Label3)
            Me.grp_GenInfo.Controls.Add(Me.box_CustAltPhone)
            Me.grp_GenInfo.Controls.Add(Me.chk_CustDeactive)
            Me.grp_GenInfo.Controls.Add(Me.Label7)
            Me.grp_GenInfo.Controls.Add(Me.Label8)
            Me.grp_GenInfo.Controls.Add(Me.box_CustContact)
            Me.grp_GenInfo.Location = New System.Drawing.Point(3, 3)
            Me.grp_GenInfo.Name = "grp_GenInfo"
            Me.grp_GenInfo.Size = New System.Drawing.Size(465, 169)
            Me.grp_GenInfo.TabIndex = 1
            Me.grp_GenInfo.TabStop = False
            Me.grp_GenInfo.Text = "General Information"
            '
            'tb_CompanyName
            '
            Me.tb_CompanyName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerCompanyName", True))
            Me.tb_CompanyName.Location = New System.Drawing.Point(97, 81)
            Me.tb_CompanyName.MaxLength = 41
            Me.tb_CompanyName.Name = "tb_CompanyName"
            Me.tb_CompanyName.Size = New System.Drawing.Size(256, 20)
            Me.tb_CompanyName.TabIndex = 0
            Me.tb_CompanyName.TabStop = False
            '
            'lbl_CompName
            '
            Me.lbl_CompName.AutoSize = True
            Me.lbl_CompName.Location = New System.Drawing.Point(6, 83)
            Me.lbl_CompName.Name = "lbl_CompName"
            Me.lbl_CompName.Size = New System.Drawing.Size(85, 13)
            Me.lbl_CompName.TabIndex = 72
            Me.lbl_CompName.Text = "Company Name:"
            '
            'lbl_LastName
            '
            Me.lbl_LastName.AutoSize = True
            Me.lbl_LastName.Location = New System.Drawing.Point(236, 111)
            Me.lbl_LastName.Name = "lbl_LastName"
            Me.lbl_LastName.Size = New System.Drawing.Size(61, 13)
            Me.lbl_LastName.TabIndex = 69
            Me.lbl_LastName.Text = "Last Name:"
            '
            'tb_LastName
            '
            Me.tb_LastName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerLastName", True))
            Me.tb_LastName.Location = New System.Drawing.Point(303, 108)
            Me.tb_LastName.MaxLength = 25
            Me.tb_LastName.Name = "tb_LastName"
            Me.tb_LastName.Size = New System.Drawing.Size(157, 20)
            Me.tb_LastName.TabIndex = 2
            Me.tb_LastName.TabStop = False
            '
            'lbl_FirstName
            '
            Me.lbl_FirstName.AutoSize = True
            Me.lbl_FirstName.Location = New System.Drawing.Point(6, 111)
            Me.lbl_FirstName.Name = "lbl_FirstName"
            Me.lbl_FirstName.Size = New System.Drawing.Size(60, 13)
            Me.lbl_FirstName.TabIndex = 67
            Me.lbl_FirstName.Text = "First Name:"
            '
            'tb_FirstName
            '
            Me.tb_FirstName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerFirstName", True))
            Me.tb_FirstName.Location = New System.Drawing.Point(72, 108)
            Me.tb_FirstName.MaxLength = 25
            Me.tb_FirstName.Name = "tb_FirstName"
            Me.tb_FirstName.Size = New System.Drawing.Size(158, 20)
            Me.tb_FirstName.TabIndex = 1
            Me.tb_FirstName.TabStop = False
            '
            'box_CustNum
            '
            Me.box_CustNum.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerNumber", True))
            Me.box_CustNum.Enabled = False
            Me.box_CustNum.Location = New System.Drawing.Point(56, 19)
            Me.box_CustNum.Name = "box_CustNum"
            Me.box_CustNum.ReadOnly = True
            Me.box_CustNum.Size = New System.Drawing.Size(58, 20)
            Me.box_CustNum.TabIndex = 41
            Me.box_CustNum.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 22)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(47, 13)
            Me.Label1.TabIndex = 42
            Me.Label1.Text = "Number:"
            '
            'box_CustFullName
            '
            Me.box_CustFullName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerFullName", True))
            Me.box_CustFullName.Location = New System.Drawing.Point(208, 19)
            Me.box_CustFullName.Name = "box_CustFullName"
            Me.box_CustFullName.ReadOnly = True
            Me.box_CustFullName.Size = New System.Drawing.Size(251, 20)
            Me.box_CustFullName.TabIndex = 0
            Me.box_CustFullName.TabStop = False
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(120, 22)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(85, 13)
            Me.Label2.TabIndex = 43
            Me.Label2.Text = "Customer Name:"
            '
            'box_CustPhone
            '
            Me.box_CustPhone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerPhone", True))
            Me.box_CustPhone.Location = New System.Drawing.Point(57, 138)
            Me.box_CustPhone.Name = "box_CustPhone"
            Me.box_CustPhone.Size = New System.Drawing.Size(85, 20)
            Me.box_CustPhone.TabIndex = 3
            Me.box_CustPhone.TabStop = False
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(9, 142)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(41, 13)
            Me.Label3.TabIndex = 44
            Me.Label3.Text = "Phone:"
            '
            'box_CustAltPhone
            '
            Me.box_CustAltPhone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerAltPhone", True))
            Me.box_CustAltPhone.Location = New System.Drawing.Point(210, 138)
            Me.box_CustAltPhone.Name = "box_CustAltPhone"
            Me.box_CustAltPhone.Size = New System.Drawing.Size(82, 20)
            Me.box_CustAltPhone.TabIndex = 4
            Me.box_CustAltPhone.TabStop = False
            '
            'chk_CustDeactive
            '
            Me.chk_CustDeactive.AutoSize = True
            Me.chk_CustDeactive.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerIsDeactive", True))
            Me.chk_CustDeactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chk_CustDeactive.ForeColor = System.Drawing.Color.Red
            Me.chk_CustDeactive.Location = New System.Drawing.Point(161, 51)
            Me.chk_CustDeactive.Name = "chk_CustDeactive"
            Me.chk_CustDeactive.Size = New System.Drawing.Size(160, 20)
            Me.chk_CustDeactive.TabIndex = 63
            Me.chk_CustDeactive.TabStop = False
            Me.chk_CustDeactive.Text = "Deactivated Customer"
            Me.chk_CustDeactive.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(298, 142)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(47, 13)
            Me.Label7.TabIndex = 65
            Me.Label7.Text = "Contact:"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(148, 142)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 13)
            Me.Label8.TabIndex = 47
            Me.Label8.Text = "Alt Phone:"
            '
            'box_CustContact
            '
            Me.box_CustContact.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerContact", True))
            Me.box_CustContact.Location = New System.Drawing.Point(351, 138)
            Me.box_CustContact.Name = "box_CustContact"
            Me.box_CustContact.Size = New System.Drawing.Size(108, 20)
            Me.box_CustContact.TabIndex = 5
            Me.box_CustContact.TabStop = False
            '
            'cm_Update
            '
            Me.cm_Update.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_UpdateInfo, Me.btn_SaveChanges})
            Me.cm_Update.Name = "cm_Update"
            Me.cm_Update.Size = New System.Drawing.Size(179, 48)
            '
            'btn_UpdateInfo
            '
            Me.btn_UpdateInfo.Name = "btn_UpdateInfo"
            Me.btn_UpdateInfo.Size = New System.Drawing.Size(178, 22)
            Me.btn_UpdateInfo.Text = "Update Information"
            '
            'btn_SaveChanges
            '
            Me.btn_SaveChanges.Name = "btn_SaveChanges"
            Me.btn_SaveChanges.Size = New System.Drawing.Size(178, 22)
            Me.btn_SaveChanges.Text = "Save Changes"
            Me.btn_SaveChanges.Visible = False
            '
            'grp_BillAddr
            '
            Me.grp_BillAddr.Controls.Add(Me.Label13)
            Me.grp_BillAddr.Controls.Add(Me.tb_BillAddr4)
            Me.grp_BillAddr.Controls.Add(Me.Label12)
            Me.grp_BillAddr.Controls.Add(Me.Label11)
            Me.grp_BillAddr.Controls.Add(Me.box_CustBillAddr1)
            Me.grp_BillAddr.Controls.Add(Me.box_CustBillAddr2)
            Me.grp_BillAddr.Controls.Add(Me.box_CustBillCity)
            Me.grp_BillAddr.Controls.Add(Me.box_CustBillAddr3)
            Me.grp_BillAddr.Controls.Add(Me.box_CustBillState)
            Me.grp_BillAddr.Controls.Add(Me.box_CustBillZip)
            Me.grp_BillAddr.Controls.Add(Me.Label6)
            Me.grp_BillAddr.Controls.Add(Me.Label5)
            Me.grp_BillAddr.Controls.Add(Me.Label4)
            Me.grp_BillAddr.Location = New System.Drawing.Point(674, 3)
            Me.grp_BillAddr.Name = "grp_BillAddr"
            Me.grp_BillAddr.Size = New System.Drawing.Size(223, 169)
            Me.grp_BillAddr.TabIndex = 3
            Me.grp_BillAddr.TabStop = False
            Me.grp_BillAddr.Text = "Billing Address"
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(8, 96)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(57, 13)
            Me.Label13.TabIndex = 71
            Me.Label13.Text = "Address 4:"
            '
            'tb_BillAddr4
            '
            Me.tb_BillAddr4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr4", True))
            Me.tb_BillAddr4.Location = New System.Drawing.Point(71, 93)
            Me.tb_BillAddr4.Name = "tb_BillAddr4"
            Me.tb_BillAddr4.Size = New System.Drawing.Size(144, 20)
            Me.tb_BillAddr4.TabIndex = 14
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(8, 70)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(57, 13)
            Me.Label12.TabIndex = 69
            Me.Label12.Text = "Address 3:"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(8, 44)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(57, 13)
            Me.Label11.TabIndex = 68
            Me.Label11.Text = "Address 2:"
            '
            'box_CustBillAddr1
            '
            Me.box_CustBillAddr1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr1", True))
            Me.box_CustBillAddr1.Location = New System.Drawing.Point(71, 15)
            Me.box_CustBillAddr1.Name = "box_CustBillAddr1"
            Me.box_CustBillAddr1.Size = New System.Drawing.Size(144, 20)
            Me.box_CustBillAddr1.TabIndex = 11
            '
            'box_CustBillAddr2
            '
            Me.box_CustBillAddr2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr2", True))
            Me.box_CustBillAddr2.Location = New System.Drawing.Point(71, 41)
            Me.box_CustBillAddr2.Name = "box_CustBillAddr2"
            Me.box_CustBillAddr2.Size = New System.Drawing.Size(144, 20)
            Me.box_CustBillAddr2.TabIndex = 12
            '
            'box_CustBillCity
            '
            Me.box_CustBillCity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingCity", True))
            Me.box_CustBillCity.Location = New System.Drawing.Point(71, 119)
            Me.box_CustBillCity.Name = "box_CustBillCity"
            Me.box_CustBillCity.Size = New System.Drawing.Size(105, 20)
            Me.box_CustBillCity.TabIndex = 15
            '
            'box_CustBillAddr3
            '
            Me.box_CustBillAddr3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr3", True))
            Me.box_CustBillAddr3.Location = New System.Drawing.Point(71, 67)
            Me.box_CustBillAddr3.Name = "box_CustBillAddr3"
            Me.box_CustBillAddr3.Size = New System.Drawing.Size(144, 20)
            Me.box_CustBillAddr3.TabIndex = 13
            '
            'box_CustBillState
            '
            Me.box_CustBillState.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingState", True))
            Me.box_CustBillState.Location = New System.Drawing.Point(182, 119)
            Me.box_CustBillState.Name = "box_CustBillState"
            Me.box_CustBillState.Size = New System.Drawing.Size(33, 20)
            Me.box_CustBillState.TabIndex = 16
            '
            'box_CustBillZip
            '
            Me.box_CustBillZip.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingZip", True))
            Me.box_CustBillZip.Location = New System.Drawing.Point(71, 145)
            Me.box_CustBillZip.Name = "box_CustBillZip"
            Me.box_CustBillZip.Size = New System.Drawing.Size(62, 20)
            Me.box_CustBillZip.TabIndex = 17
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(40, 148)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(25, 13)
            Me.Label6.TabIndex = 67
            Me.Label6.Text = "Zip:"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(8, 122)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(57, 13)
            Me.Label5.TabIndex = 66
            Me.Label5.Text = "City/State:"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(8, 18)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(57, 13)
            Me.Label4.TabIndex = 65
            Me.Label4.Text = "Address 1:"
            '
            'CustomerTableAdapter
            '
            Me.CustomerTableAdapter.ClearBeforeFill = True
            '
            'lbl_BillInterval
            '
            Me.lbl_BillInterval.AutoSize = True
            Me.lbl_BillInterval.Location = New System.Drawing.Point(40, 142)
            Me.lbl_BillInterval.Name = "lbl_BillInterval"
            Me.lbl_BillInterval.Size = New System.Drawing.Size(61, 13)
            Me.lbl_BillInterval.TabIndex = 76
            Me.lbl_BillInterval.Text = "Bill Interval:"
            Me.tt_CustBillInterval.SetToolTip(Me.lbl_BillInterval, "How many months between this customer recieving an invoice.")
            '
            'UC_CustomerInfoBoxes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ContextMenuStrip = Me.cm_Update
            Me.Controls.Add(Me.grp_BillAddr)
            Me.Controls.Add(Me.grp_SrvcInvInfo)
            Me.Controls.Add(Me.grp_GenInfo)
            Me.Name = "UC_CustomerInfoBoxes"
            Me.Size = New System.Drawing.Size(900, 172)
            Me.grp_SrvcInvInfo.ResumeLayout(False)
            Me.grp_SrvcInvInfo.PerformLayout()
            CType(Me.nud_BillInterval, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_GenInfo.ResumeLayout(False)
            Me.grp_GenInfo.PerformLayout()
            Me.cm_Update.ResumeLayout(False)
            Me.grp_BillAddr.ResumeLayout(False)
            Me.grp_BillAddr.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents grp_SrvcInvInfo As System.Windows.Forms.GroupBox
        Friend WithEvents chk_CustPrintInv As System.Windows.Forms.CheckBox
        Friend WithEvents chk_CustBillAdvance As System.Windows.Forms.CheckBox
        Friend WithEvents grp_GenInfo As System.Windows.Forms.GroupBox
        Friend WithEvents box_CustNum As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents box_CustFullName As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents box_CustPhone As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents chk_CustDeactive As System.Windows.Forms.CheckBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents box_CustContact As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents cm_Update As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents btn_UpdateInfo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents grp_BillAddr As System.Windows.Forms.GroupBox
        Friend WithEvents box_CustBillAddr1 As System.Windows.Forms.TextBox
        Friend WithEvents box_CustBillAddr2 As System.Windows.Forms.TextBox
        Friend WithEvents box_CustBillCity As System.Windows.Forms.TextBox
        Friend WithEvents box_CustBillAddr3 As System.Windows.Forms.TextBox
        Friend WithEvents box_CustBillState As System.Windows.Forms.TextBox
        Friend WithEvents box_CustBillZip As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents ck_SingleInv As System.Windows.Forms.CheckBox
     Friend WithEvents tt_CustBillInterval As System.Windows.Forms.ToolTip
        Friend WithEvents lbl_LastName As System.Windows.Forms.Label
        Friend WithEvents tb_LastName As System.Windows.Forms.TextBox
        Friend WithEvents lbl_FirstName As System.Windows.Forms.Label
        Friend WithEvents tb_FirstName As System.Windows.Forms.TextBox
        Friend WithEvents tb_CompanyName As System.Windows.Forms.TextBox
        Friend WithEvents lbl_CompName As System.Windows.Forms.Label
        Friend WithEvents box_CustAltPhone As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents tb_BillAddr4 As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents nud_BillInterval As System.Windows.Forms.NumericUpDown
        Friend WithEvents CustomerBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Ds_Customer As TrashCash.ds_Customer
        Friend WithEvents CustomerTableAdapter As TrashCash.ds_CustomerTableAdapters.CustomerTableAdapter
        Friend WithEvents btn_SaveChanges As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents lbl_BillInterval As System.Windows.Forms.Label

    End Class
End Namespace