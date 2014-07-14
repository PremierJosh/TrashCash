Namespace Customer
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NewCustomer
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
            Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
            Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Customer = New TrashCash.ds_Customer()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.btn_CreateCust = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.nud_BillInterval = New System.Windows.Forms.NumericUpDown()
            Me.lbl_BillInterval = New System.Windows.Forms.Label()
            Me.ck_SingleInv = New System.Windows.Forms.CheckBox()
            Me.ck_PrintInv = New System.Windows.Forms.CheckBox()
            Me.ck_BillInAdvance = New System.Windows.Forms.CheckBox()
            Me.billedAdvanceTooltip = New System.Windows.Forms.ToolTip(Me.components)
            Me.tt_CustBillInterval = New System.Windows.Forms.ToolTip(Me.components)
            Me.lbl_BillInter = New System.Windows.Forms.Label()
            Me.grp_GenInfo = New System.Windows.Forms.GroupBox()
            Me.tb_CompanyName = New System.Windows.Forms.TextBox()
            Me.lbl_CompName = New System.Windows.Forms.Label()
            Me.lbl_LastName = New System.Windows.Forms.Label()
            Me.tb_LastName = New System.Windows.Forms.TextBox()
            Me.lbl_FirstName = New System.Windows.Forms.Label()
            Me.tb_FirstName = New System.Windows.Forms.TextBox()
            Me.tb_Phone = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.tb_AltPhone = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.tb_Contact = New System.Windows.Forms.TextBox()
            Me.grp_BillAddr = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.tb_Addr4 = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.tb_Addr1 = New System.Windows.Forms.TextBox()
            Me.tb_Addr2 = New System.Windows.Forms.TextBox()
            Me.tb_City = New System.Windows.Forms.TextBox()
            Me.tb_Addr3 = New System.Windows.Forms.TextBox()
            Me.tb_State = New System.Windows.Forms.TextBox()
            Me.tb_Zip = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.CustomerTableAdapter = New TrashCash.ds_CustomerTableAdapters.CustomerTableAdapter()
            CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            CType(Me.nud_BillInterval, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_GenInfo.SuspendLayout()
            Me.grp_BillAddr.SuspendLayout()
            Me.SuspendLayout()
            '
            'dtp_StartDate
            '
            Me.dtp_StartDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CustomerBindingSource, "CustomerStartDate", True))
            Me.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_StartDate.Location = New System.Drawing.Point(116, 69)
            Me.dtp_StartDate.Name = "dtp_StartDate"
            Me.dtp_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.dtp_StartDate.TabIndex = 4
            '
            'CustomerBindingSource
            '
            Me.CustomerBindingSource.DataMember = "Customer"
            Me.CustomerBindingSource.DataSource = Me.Ds_Customer
            '
            'Ds_Customer
            '
            Me.Ds_Customer.DataSetName = "ds_Customer"
            Me.Ds_Customer.EnforceConstraints = False
            Me.Ds_Customer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(52, 73)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(58, 13)
            Me.Label9.TabIndex = 68
            Me.Label9.Text = "Start Date:"
            '
            'btn_CreateCust
            '
            Me.btn_CreateCust.AutoSize = True
            Me.btn_CreateCust.Location = New System.Drawing.Point(158, 339)
            Me.btn_CreateCust.Name = "btn_CreateCust"
            Me.btn_CreateCust.Size = New System.Drawing.Size(184, 23)
            Me.btn_CreateCust.TabIndex = 3
            Me.btn_CreateCust.Text = "Create Customer"
            Me.btn_CreateCust.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.nud_BillInterval)
            Me.GroupBox2.Controls.Add(Me.lbl_BillInterval)
            Me.GroupBox2.Controls.Add(Me.ck_SingleInv)
            Me.GroupBox2.Controls.Add(Me.Label9)
            Me.GroupBox2.Controls.Add(Me.ck_PrintInv)
            Me.GroupBox2.Controls.Add(Me.ck_BillInAdvance)
            Me.GroupBox2.Controls.Add(Me.dtp_StartDate)
            Me.GroupBox2.Location = New System.Drawing.Point(26, 134)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(200, 169)
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Service and Invoice Information"
            '
            'nud_BillInterval
            '
            Me.nud_BillInterval.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CustomerBindingSource, "CustomerBillInterval", True))
            Me.nud_BillInterval.Location = New System.Drawing.Point(166, 138)
            Me.nud_BillInterval.Name = "nud_BillInterval"
            Me.nud_BillInterval.Size = New System.Drawing.Size(31, 20)
            Me.nud_BillInterval.TabIndex = 5
            Me.tt_CustBillInterval.SetToolTip(Me.nud_BillInterval, "How many months between this customer recieving an invoice.")
            Me.nud_BillInterval.Value = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nud_BillInterval.Visible = False
            '
            'lbl_BillInterval
            '
            Me.lbl_BillInterval.AutoSize = True
            Me.lbl_BillInterval.Location = New System.Drawing.Point(99, 140)
            Me.lbl_BillInterval.Name = "lbl_BillInterval"
            Me.lbl_BillInterval.Size = New System.Drawing.Size(61, 13)
            Me.lbl_BillInterval.TabIndex = 78
            Me.lbl_BillInterval.Text = "Bill Interval:"
            Me.tt_CustBillInterval.SetToolTip(Me.lbl_BillInterval, "How many months between this customer recieving an invoice.")
            Me.lbl_BillInterval.Visible = False
            '
            'ck_SingleInv
            '
            Me.ck_SingleInv.AutoSize = True
            Me.ck_SingleInv.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerReceiveOneInvoice", True))
            Me.ck_SingleInv.Location = New System.Drawing.Point(53, 115)
            Me.ck_SingleInv.Name = "ck_SingleInv"
            Me.ck_SingleInv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.ck_SingleInv.Size = New System.Drawing.Size(141, 17)
            Me.ck_SingleInv.TabIndex = 1
            Me.ck_SingleInv.Text = "Recieves Single Invoice"
            Me.ck_SingleInv.UseVisualStyleBackColor = True
            '
            'ck_PrintInv
            '
            Me.ck_PrintInv.AutoSize = True
            Me.ck_PrintInv.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerPrintInvoices", True))
            Me.ck_PrintInv.Location = New System.Drawing.Point(104, 46)
            Me.ck_PrintInv.Name = "ck_PrintInv"
            Me.ck_PrintInv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.ck_PrintInv.Size = New System.Drawing.Size(90, 17)
            Me.ck_PrintInv.TabIndex = 3
            Me.ck_PrintInv.Text = "Print Invoices"
            Me.billedAdvanceTooltip.SetToolTip(Me.ck_PrintInv, "If checked, Customer will be billed in advance for the services they will recieve" & _
            " in the next billing cycle.")
            Me.ck_PrintInv.UseVisualStyleBackColor = True
            '
            'ck_BillInAdvance
            '
            Me.ck_BillInAdvance.AutoSize = True
            Me.ck_BillInAdvance.Checked = True
            Me.ck_BillInAdvance.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ck_BillInAdvance.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CustomerBindingSource, "CustomerBilledInAdvance", True))
            Me.ck_BillInAdvance.Location = New System.Drawing.Point(86, 23)
            Me.ck_BillInAdvance.Name = "ck_BillInAdvance"
            Me.ck_BillInAdvance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.ck_BillInAdvance.Size = New System.Drawing.Size(108, 17)
            Me.ck_BillInAdvance.TabIndex = 2
            Me.ck_BillInAdvance.Text = "Billed in Advance"
            Me.billedAdvanceTooltip.SetToolTip(Me.ck_BillInAdvance, "If checked, Customer will be billed in advance for the services they will recieve" & _
            " in the next billing cycle.")
            Me.ck_BillInAdvance.UseVisualStyleBackColor = True
            '
            'billedAdvanceTooltip
            '
            Me.billedAdvanceTooltip.AutomaticDelay = 100
            Me.billedAdvanceTooltip.AutoPopDelay = 10000
            Me.billedAdvanceTooltip.InitialDelay = 100
            Me.billedAdvanceTooltip.ReshowDelay = 20
            '
            'lbl_BillInter
            '
            Me.lbl_BillInter.AutoSize = True
            Me.lbl_BillInter.Location = New System.Drawing.Point(99, 140)
            Me.lbl_BillInter.Name = "lbl_BillInter"
            Me.lbl_BillInter.Size = New System.Drawing.Size(61, 13)
            Me.lbl_BillInter.TabIndex = 78
            Me.lbl_BillInter.Text = "Bill Interval:"
            Me.tt_CustBillInterval.SetToolTip(Me.lbl_BillInter, "How many months between this customer recieving an invoice.")
            Me.lbl_BillInter.Visible = False
            '
            'grp_GenInfo
            '
            Me.grp_GenInfo.Controls.Add(Me.tb_CompanyName)
            Me.grp_GenInfo.Controls.Add(Me.lbl_CompName)
            Me.grp_GenInfo.Controls.Add(Me.lbl_LastName)
            Me.grp_GenInfo.Controls.Add(Me.tb_LastName)
            Me.grp_GenInfo.Controls.Add(Me.lbl_FirstName)
            Me.grp_GenInfo.Controls.Add(Me.tb_FirstName)
            Me.grp_GenInfo.Controls.Add(Me.tb_Phone)
            Me.grp_GenInfo.Controls.Add(Me.Label12)
            Me.grp_GenInfo.Controls.Add(Me.tb_AltPhone)
            Me.grp_GenInfo.Controls.Add(Me.Label13)
            Me.grp_GenInfo.Controls.Add(Me.Label14)
            Me.grp_GenInfo.Controls.Add(Me.tb_Contact)
            Me.grp_GenInfo.Location = New System.Drawing.Point(26, 12)
            Me.grp_GenInfo.Name = "grp_GenInfo"
            Me.grp_GenInfo.Size = New System.Drawing.Size(465, 104)
            Me.grp_GenInfo.TabIndex = 0
            Me.grp_GenInfo.TabStop = False
            Me.grp_GenInfo.Text = "General Information"
            '
            'tb_CompanyName
            '
            Me.tb_CompanyName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerCompanyName", True))
            Me.tb_CompanyName.Location = New System.Drawing.Point(97, 19)
            Me.tb_CompanyName.MaxLength = 41
            Me.tb_CompanyName.Name = "tb_CompanyName"
            Me.tb_CompanyName.Size = New System.Drawing.Size(256, 20)
            Me.tb_CompanyName.TabIndex = 1
            Me.tb_CompanyName.TabStop = False
            '
            'lbl_CompName
            '
            Me.lbl_CompName.AutoSize = True
            Me.lbl_CompName.Location = New System.Drawing.Point(6, 21)
            Me.lbl_CompName.Name = "lbl_CompName"
            Me.lbl_CompName.Size = New System.Drawing.Size(85, 13)
            Me.lbl_CompName.TabIndex = 72
            Me.lbl_CompName.Text = "Company Name:"
            '
            'lbl_LastName
            '
            Me.lbl_LastName.AutoSize = True
            Me.lbl_LastName.Location = New System.Drawing.Point(236, 49)
            Me.lbl_LastName.Name = "lbl_LastName"
            Me.lbl_LastName.Size = New System.Drawing.Size(61, 13)
            Me.lbl_LastName.TabIndex = 69
            Me.lbl_LastName.Text = "Last Name:"
            '
            'tb_LastName
            '
            Me.tb_LastName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerLastName", True))
            Me.tb_LastName.Location = New System.Drawing.Point(303, 46)
            Me.tb_LastName.MaxLength = 25
            Me.tb_LastName.Name = "tb_LastName"
            Me.tb_LastName.Size = New System.Drawing.Size(157, 20)
            Me.tb_LastName.TabIndex = 3
            '
            'lbl_FirstName
            '
            Me.lbl_FirstName.AutoSize = True
            Me.lbl_FirstName.Location = New System.Drawing.Point(6, 49)
            Me.lbl_FirstName.Name = "lbl_FirstName"
            Me.lbl_FirstName.Size = New System.Drawing.Size(60, 13)
            Me.lbl_FirstName.TabIndex = 67
            Me.lbl_FirstName.Text = "First Name:"
            '
            'tb_FirstName
            '
            Me.tb_FirstName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerFirstName", True))
            Me.tb_FirstName.Location = New System.Drawing.Point(72, 46)
            Me.tb_FirstName.MaxLength = 25
            Me.tb_FirstName.Name = "tb_FirstName"
            Me.tb_FirstName.Size = New System.Drawing.Size(158, 20)
            Me.tb_FirstName.TabIndex = 2
            '
            'tb_Phone
            '
            Me.tb_Phone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerPhone", True))
            Me.tb_Phone.Location = New System.Drawing.Point(57, 76)
            Me.tb_Phone.Name = "tb_Phone"
            Me.tb_Phone.Size = New System.Drawing.Size(85, 20)
            Me.tb_Phone.TabIndex = 4
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(9, 80)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(41, 13)
            Me.Label12.TabIndex = 44
            Me.Label12.Text = "Phone:"
            '
            'tb_AltPhone
            '
            Me.tb_AltPhone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerAltPhone", True))
            Me.tb_AltPhone.Location = New System.Drawing.Point(210, 76)
            Me.tb_AltPhone.Name = "tb_AltPhone"
            Me.tb_AltPhone.Size = New System.Drawing.Size(82, 20)
            Me.tb_AltPhone.TabIndex = 5
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(298, 80)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(47, 13)
            Me.Label13.TabIndex = 65
            Me.Label13.Text = "Contact:"
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(148, 80)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(56, 13)
            Me.Label14.TabIndex = 47
            Me.Label14.Text = "Alt Phone:"
            '
            'tb_Contact
            '
            Me.tb_Contact.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerContact", True))
            Me.tb_Contact.Location = New System.Drawing.Point(351, 76)
            Me.tb_Contact.Name = "tb_Contact"
            Me.tb_Contact.Size = New System.Drawing.Size(108, 20)
            Me.tb_Contact.TabIndex = 6
            '
            'grp_BillAddr
            '
            Me.grp_BillAddr.Controls.Add(Me.Label2)
            Me.grp_BillAddr.Controls.Add(Me.tb_Addr4)
            Me.grp_BillAddr.Controls.Add(Me.Label3)
            Me.grp_BillAddr.Controls.Add(Me.Label11)
            Me.grp_BillAddr.Controls.Add(Me.tb_Addr1)
            Me.grp_BillAddr.Controls.Add(Me.tb_Addr2)
            Me.grp_BillAddr.Controls.Add(Me.tb_City)
            Me.grp_BillAddr.Controls.Add(Me.tb_Addr3)
            Me.grp_BillAddr.Controls.Add(Me.tb_State)
            Me.grp_BillAddr.Controls.Add(Me.tb_Zip)
            Me.grp_BillAddr.Controls.Add(Me.Label6)
            Me.grp_BillAddr.Controls.Add(Me.Label5)
            Me.grp_BillAddr.Controls.Add(Me.Label4)
            Me.grp_BillAddr.Location = New System.Drawing.Point(268, 134)
            Me.grp_BillAddr.Name = "grp_BillAddr"
            Me.grp_BillAddr.Size = New System.Drawing.Size(223, 169)
            Me.grp_BillAddr.TabIndex = 1
            Me.grp_BillAddr.TabStop = False
            Me.grp_BillAddr.Text = "Billing Address"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(8, 96)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(57, 13)
            Me.Label2.TabIndex = 71
            Me.Label2.Text = "Address 4:"
            '
            'tb_Addr4
            '
            Me.tb_Addr4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr4", True))
            Me.tb_Addr4.Location = New System.Drawing.Point(71, 93)
            Me.tb_Addr4.Name = "tb_Addr4"
            Me.tb_Addr4.Size = New System.Drawing.Size(144, 20)
            Me.tb_Addr4.TabIndex = 4
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(8, 70)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(57, 13)
            Me.Label3.TabIndex = 69
            Me.Label3.Text = "Address 3:"
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
            'tb_Addr1
            '
            Me.tb_Addr1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr1", True))
            Me.tb_Addr1.Location = New System.Drawing.Point(71, 15)
            Me.tb_Addr1.Name = "tb_Addr1"
            Me.tb_Addr1.Size = New System.Drawing.Size(144, 20)
            Me.tb_Addr1.TabIndex = 1
            '
            'tb_Addr2
            '
            Me.tb_Addr2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr2", True))
            Me.tb_Addr2.Location = New System.Drawing.Point(71, 41)
            Me.tb_Addr2.Name = "tb_Addr2"
            Me.tb_Addr2.Size = New System.Drawing.Size(144, 20)
            Me.tb_Addr2.TabIndex = 2
            '
            'tb_City
            '
            Me.tb_City.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingCity", True))
            Me.tb_City.Location = New System.Drawing.Point(71, 119)
            Me.tb_City.Name = "tb_City"
            Me.tb_City.Size = New System.Drawing.Size(105, 20)
            Me.tb_City.TabIndex = 5
            '
            'tb_Addr3
            '
            Me.tb_Addr3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingAddr3", True))
            Me.tb_Addr3.Location = New System.Drawing.Point(71, 67)
            Me.tb_Addr3.Name = "tb_Addr3"
            Me.tb_Addr3.Size = New System.Drawing.Size(144, 20)
            Me.tb_Addr3.TabIndex = 3
            '
            'tb_State
            '
            Me.tb_State.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingState", True))
            Me.tb_State.Location = New System.Drawing.Point(182, 119)
            Me.tb_State.Name = "tb_State"
            Me.tb_State.Size = New System.Drawing.Size(33, 20)
            Me.tb_State.TabIndex = 6
            '
            'tb_Zip
            '
            Me.tb_Zip.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerBillingZip", True))
            Me.tb_Zip.Location = New System.Drawing.Point(71, 145)
            Me.tb_Zip.Name = "tb_Zip"
            Me.tb_Zip.Size = New System.Drawing.Size(62, 20)
            Me.tb_Zip.TabIndex = 7
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
            'NewCustomer
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(512, 384)
            Me.Controls.Add(Me.grp_BillAddr)
            Me.Controls.Add(Me.grp_GenInfo)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.btn_CreateCust)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "NewCustomer"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "TrashCash | New Customer"
            CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            CType(Me.nud_BillInterval, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_GenInfo.ResumeLayout(False)
            Me.grp_GenInfo.PerformLayout()
            Me.grp_BillAddr.ResumeLayout(False)
            Me.grp_BillAddr.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btn_CreateCust As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents ck_BillInAdvance As System.Windows.Forms.CheckBox
        Friend WithEvents billedAdvanceTooltip As System.Windows.Forms.ToolTip
        Friend WithEvents ck_PrintInv As System.Windows.Forms.CheckBox
        Friend WithEvents ck_SingleInv As System.Windows.Forms.CheckBox
        Friend WithEvents lbl_BillInterval As System.Windows.Forms.Label
        Friend WithEvents tt_CustBillInterval As System.Windows.Forms.ToolTip
        Friend WithEvents nud_BillInterval As System.Windows.Forms.NumericUpDown
        Friend WithEvents grp_GenInfo As System.Windows.Forms.GroupBox
        Friend WithEvents tb_CompanyName As System.Windows.Forms.TextBox
        Friend WithEvents lbl_CompName As System.Windows.Forms.Label
        Friend WithEvents lbl_LastName As System.Windows.Forms.Label
        Friend WithEvents tb_LastName As System.Windows.Forms.TextBox
        Friend WithEvents lbl_FirstName As System.Windows.Forms.Label
        Friend WithEvents tb_FirstName As System.Windows.Forms.TextBox
        Friend WithEvents tb_Phone As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents tb_AltPhone As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents tb_Contact As System.Windows.Forms.TextBox
        Friend WithEvents grp_BillAddr As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents tb_Addr4 As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents tb_Addr1 As System.Windows.Forms.TextBox
        Friend WithEvents tb_Addr2 As System.Windows.Forms.TextBox
        Friend WithEvents tb_City As System.Windows.Forms.TextBox
        Friend WithEvents tb_Addr3 As System.Windows.Forms.TextBox
        Friend WithEvents tb_State As System.Windows.Forms.TextBox
        Friend WithEvents tb_Zip As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents CustomerBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Ds_Customer As ds_Customer
        Friend WithEvents CustomerTableAdapter As ds_CustomerTableAdapters.CustomerTableAdapter
        Friend WithEvents lbl_BillInter As System.Windows.Forms.Label
    End Class
End Namespace