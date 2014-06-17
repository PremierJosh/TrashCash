Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminExportImport
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
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.pnl_CustAdd = New System.Windows.Forms.Panel()
            Me.lbl_AllCustAddCount = New System.Windows.Forms.Label()
            Me.pb_AllCustAdd = New System.Windows.Forms.ProgressBar()
            Me.btn_AddCustomers = New System.Windows.Forms.Button()
            Me.tb_MissingCount = New System.Windows.Forms.TextBox()
            Me.lbl_AddCustInfo = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btn_AddSrvc = New System.Windows.Forms.Button()
            Me.cmb_ServiceTypes = New System.Windows.Forms.ComboBox()
            Me.ServiceTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Types = New TrashCash.ds_Types()
            Me.btn_AddSrvcs = New System.Windows.Forms.Button()
            Me.cmb_IncomeAcc = New System.Windows.Forms.ComboBox()
            Me.lbl_ServiceAdd = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btn_AddCustInv = New System.Windows.Forms.Button()
            Me.lbl_CustInvImport = New System.Windows.Forms.Label()
            Me.ServiceTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter()
            Me.lbl_Add1Srvc = New System.Windows.Forms.Label()
            Me.lbl_ImportInvType = New System.Windows.Forms.Label()
            Me.cmb_InvTypes = New System.Windows.Forms.ComboBox()
            Me.btn_AddInvType = New System.Windows.Forms.Button()
            Me.Ds_Invoicing = New TrashCash.ds_Invoicing()
            Me.CustomInvoiceLineTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CustomInvoice_LineTypesTableAdapter = New TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.pnl_CustAdd.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.Ds_Invoicing, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.pnl_CustAdd)
            Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
            Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(611, 503)
            Me.FlowLayoutPanel1.TabIndex = 0
            '
            'pnl_CustAdd
            '
            Me.pnl_CustAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_CustAdd.Controls.Add(Me.lbl_AllCustAddCount)
            Me.pnl_CustAdd.Controls.Add(Me.pb_AllCustAdd)
            Me.pnl_CustAdd.Controls.Add(Me.btn_AddCustomers)
            Me.pnl_CustAdd.Controls.Add(Me.tb_MissingCount)
            Me.pnl_CustAdd.Controls.Add(Me.lbl_AddCustInfo)
            Me.pnl_CustAdd.Location = New System.Drawing.Point(3, 3)
            Me.pnl_CustAdd.Name = "pnl_CustAdd"
            Me.pnl_CustAdd.Size = New System.Drawing.Size(585, 68)
            Me.pnl_CustAdd.TabIndex = 1
            '
            'lbl_AllCustAddCount
            '
            Me.lbl_AllCustAddCount.Location = New System.Drawing.Point(295, 22)
            Me.lbl_AllCustAddCount.Name = "lbl_AllCustAddCount"
            Me.lbl_AllCustAddCount.Size = New System.Drawing.Size(100, 13)
            Me.lbl_AllCustAddCount.TabIndex = 5
            Me.lbl_AllCustAddCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbl_AllCustAddCount.Visible = False
            '
            'pb_AllCustAdd
            '
            Me.pb_AllCustAdd.Location = New System.Drawing.Point(20, 38)
            Me.pb_AllCustAdd.Name = "pb_AllCustAdd"
            Me.pb_AllCustAdd.Size = New System.Drawing.Size(375, 23)
            Me.pb_AllCustAdd.TabIndex = 4
            Me.pb_AllCustAdd.Visible = False
            '
            'btn_AddCustomers
            '
            Me.btn_AddCustomers.AutoSize = True
            Me.btn_AddCustomers.Location = New System.Drawing.Point(426, 32)
            Me.btn_AddCustomers.Name = "btn_AddCustomers"
            Me.btn_AddCustomers.Size = New System.Drawing.Size(88, 23)
            Me.btn_AddCustomers.TabIndex = 3
            Me.btn_AddCustomers.Text = "Add Customers"
            Me.btn_AddCustomers.UseVisualStyleBackColor = True
            '
            'tb_MissingCount
            '
            Me.tb_MissingCount.Enabled = False
            Me.tb_MissingCount.Location = New System.Drawing.Point(426, 6)
            Me.tb_MissingCount.Name = "tb_MissingCount"
            Me.tb_MissingCount.Size = New System.Drawing.Size(88, 20)
            Me.tb_MissingCount.TabIndex = 1
            Me.tb_MissingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lbl_AddCustInfo
            '
            Me.lbl_AddCustInfo.Location = New System.Drawing.Point(3, 6)
            Me.lbl_AddCustInfo.Name = "lbl_AddCustInfo"
            Me.lbl_AddCustInfo.Size = New System.Drawing.Size(409, 28)
            Me.lbl_AddCustInfo.TabIndex = 0
            Me.lbl_AddCustInfo.Text = "This will import all Customers into Quickbooks. If there is a duplicate Customer " & _
        "Name, you will be prompted to chose a new name."
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.lbl_Add1Srvc)
            Me.Panel1.Controls.Add(Me.btn_AddSrvc)
            Me.Panel1.Controls.Add(Me.cmb_ServiceTypes)
            Me.Panel1.Controls.Add(Me.btn_AddSrvcs)
            Me.Panel1.Controls.Add(Me.cmb_IncomeAcc)
            Me.Panel1.Controls.Add(Me.lbl_ServiceAdd)
            Me.Panel1.Location = New System.Drawing.Point(3, 77)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(585, 106)
            Me.Panel1.TabIndex = 2
            '
            'btn_AddSrvc
            '
            Me.btn_AddSrvc.AutoSize = True
            Me.btn_AddSrvc.Location = New System.Drawing.Point(487, 55)
            Me.btn_AddSrvc.Name = "btn_AddSrvc"
            Me.btn_AddSrvc.Size = New System.Drawing.Size(87, 23)
            Me.btn_AddSrvc.TabIndex = 4
            Me.btn_AddSrvc.Text = "<- Add Service"
            Me.btn_AddSrvc.UseVisualStyleBackColor = True
            '
            'cmb_ServiceTypes
            '
            Me.cmb_ServiceTypes.DataSource = Me.ServiceTypesBindingSource
            Me.cmb_ServiceTypes.DisplayMember = "ServiceName"
            Me.cmb_ServiceTypes.FormattingEnabled = True
            Me.cmb_ServiceTypes.Location = New System.Drawing.Point(312, 56)
            Me.cmb_ServiceTypes.Name = "cmb_ServiceTypes"
            Me.cmb_ServiceTypes.Size = New System.Drawing.Size(169, 21)
            Me.cmb_ServiceTypes.TabIndex = 3
            Me.cmb_ServiceTypes.ValueMember = "ServiceTypeID"
            '
            'ServiceTypesBindingSource
            '
            Me.ServiceTypesBindingSource.DataMember = "ServiceTypes"
            Me.ServiceTypesBindingSource.DataSource = Me.Ds_Types
            '
            'Ds_Types
            '
            Me.Ds_Types.DataSetName = "ds_Types"
            Me.Ds_Types.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'btn_AddSrvcs
            '
            Me.btn_AddSrvcs.AutoSize = True
            Me.btn_AddSrvcs.Location = New System.Drawing.Point(487, 13)
            Me.btn_AddSrvcs.Name = "btn_AddSrvcs"
            Me.btn_AddSrvcs.Size = New System.Drawing.Size(94, 23)
            Me.btn_AddSrvcs.TabIndex = 2
            Me.btn_AddSrvcs.Text = "Add All Services"
            Me.btn_AddSrvcs.UseVisualStyleBackColor = True
            '
            'cmb_IncomeAcc
            '
            Me.cmb_IncomeAcc.FormattingEnabled = True
            Me.cmb_IncomeAcc.Location = New System.Drawing.Point(312, 15)
            Me.cmb_IncomeAcc.Name = "cmb_IncomeAcc"
            Me.cmb_IncomeAcc.Size = New System.Drawing.Size(169, 21)
            Me.cmb_IncomeAcc.TabIndex = 1
            '
            'lbl_ServiceAdd
            '
            Me.lbl_ServiceAdd.Location = New System.Drawing.Point(35, 14)
            Me.lbl_ServiceAdd.Name = "lbl_ServiceAdd"
            Me.lbl_ServiceAdd.Size = New System.Drawing.Size(274, 30)
            Me.lbl_ServiceAdd.TabIndex = 0
            Me.lbl_ServiceAdd.Text = "This will add all services missing list ID's to the following account in Quickboo" & _
        "ks."
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.btn_AddInvType)
            Me.Panel3.Controls.Add(Me.cmb_InvTypes)
            Me.Panel3.Controls.Add(Me.lbl_ImportInvType)
            Me.Panel3.Controls.Add(Me.btn_AddCustInv)
            Me.Panel3.Controls.Add(Me.lbl_CustInvImport)
            Me.Panel3.Location = New System.Drawing.Point(3, 189)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(585, 91)
            Me.Panel3.TabIndex = 4
            '
            'btn_AddCustInv
            '
            Me.btn_AddCustInv.AutoSize = True
            Me.btn_AddCustInv.Location = New System.Drawing.Point(474, 3)
            Me.btn_AddCustInv.Name = "btn_AddCustInv"
            Me.btn_AddCustInv.Size = New System.Drawing.Size(79, 23)
            Me.btn_AddCustInv.TabIndex = 2
            Me.btn_AddCustInv.Text = "Add Invoices"
            Me.btn_AddCustInv.UseVisualStyleBackColor = True
            '
            'lbl_CustInvImport
            '
            Me.lbl_CustInvImport.AutoSize = True
            Me.lbl_CustInvImport.Location = New System.Drawing.Point(5, 8)
            Me.lbl_CustInvImport.Name = "lbl_CustInvImport"
            Me.lbl_CustInvImport.Size = New System.Drawing.Size(376, 13)
            Me.lbl_CustInvImport.TabIndex = 0
            Me.lbl_CustInvImport.Text = "This will import all invoices in the Custom Invoice table that are missing a List" & _
        "ID"
            '
            'ServiceTypesTableAdapter
            '
            Me.ServiceTypesTableAdapter.ClearBeforeFill = True
            '
            'lbl_Add1Srvc
            '
            Me.lbl_Add1Srvc.AutoSize = True
            Me.lbl_Add1Srvc.Location = New System.Drawing.Point(32, 59)
            Me.lbl_Add1Srvc.Name = "lbl_Add1Srvc"
            Me.lbl_Add1Srvc.Size = New System.Drawing.Size(270, 13)
            Me.lbl_Add1Srvc.TabIndex = 5
            Me.lbl_Add1Srvc.Text = "This will add the selected Service to the above account"
            '
            'lbl_ImportInvType
            '
            Me.lbl_ImportInvType.AutoSize = True
            Me.lbl_ImportInvType.Location = New System.Drawing.Point(8, 45)
            Me.lbl_ImportInvType.Name = "lbl_ImportInvType"
            Me.lbl_ImportInvType.Size = New System.Drawing.Size(346, 13)
            Me.lbl_ImportInvType.TabIndex = 3
            Me.lbl_ImportInvType.Text = "This will import the selected Invoice type to the selected Account above"
            '
            'cmb_InvTypes
            '
            Me.cmb_InvTypes.DataSource = Me.CustomInvoiceLineTypesBindingSource
            Me.cmb_InvTypes.DisplayMember = "NAME"
            Me.cmb_InvTypes.FormattingEnabled = True
            Me.cmb_InvTypes.Location = New System.Drawing.Point(360, 42)
            Me.cmb_InvTypes.Name = "cmb_InvTypes"
            Me.cmb_InvTypes.Size = New System.Drawing.Size(130, 21)
            Me.cmb_InvTypes.TabIndex = 5
            Me.cmb_InvTypes.ValueMember = "CI_TypeID"
            '
            'btn_AddInvType
            '
            Me.btn_AddInvType.AutoSize = True
            Me.btn_AddInvType.Location = New System.Drawing.Point(493, 40)
            Me.btn_AddInvType.Name = "btn_AddInvType"
            Me.btn_AddInvType.Size = New System.Drawing.Size(87, 23)
            Me.btn_AddInvType.TabIndex = 6
            Me.btn_AddInvType.Text = "<- Add Service"
            Me.btn_AddInvType.UseVisualStyleBackColor = True
            '
            'Ds_Invoicing
            '
            Me.Ds_Invoicing.DataSetName = "ds_Invoicing"
            Me.Ds_Invoicing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'CustomInvoiceLineTypesBindingSource
            '
            Me.CustomInvoiceLineTypesBindingSource.DataMember = "CustomInvoice_LineTypes"
            Me.CustomInvoiceLineTypesBindingSource.DataSource = Me.Ds_Invoicing
            '
            'CustomInvoice_LineTypesTableAdapter
            '
            Me.CustomInvoice_LineTypesTableAdapter.ClearBeforeFill = True
            '
            'AdminExportImport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(611, 503)
            Me.Controls.Add(Me.FlowLayoutPanel1)
            Me.Name = "AdminExportImport"
            Me.Text = "ImportWork"
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.pnl_CustAdd.ResumeLayout(False)
            Me.pnl_CustAdd.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.Ds_Invoicing, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents pnl_CustAdd As System.Windows.Forms.Panel
        Friend WithEvents lbl_AllCustAddCount As System.Windows.Forms.Label
        Friend WithEvents pb_AllCustAdd As System.Windows.Forms.ProgressBar
        Friend WithEvents btn_AddCustomers As System.Windows.Forms.Button
        Friend WithEvents tb_MissingCount As System.Windows.Forms.TextBox
        Friend WithEvents lbl_AddCustInfo As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lbl_ServiceAdd As System.Windows.Forms.Label
        Friend WithEvents cmb_IncomeAcc As System.Windows.Forms.ComboBox
        Friend WithEvents btn_AddSrvcs As System.Windows.Forms.Button
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents lbl_CustInvImport As System.Windows.Forms.Label
        Friend WithEvents btn_AddCustInv As System.Windows.Forms.Button
        Friend WithEvents cmb_ServiceTypes As System.Windows.Forms.ComboBox
        Friend WithEvents btn_AddSrvc As System.Windows.Forms.Button
        Friend WithEvents Ds_Types As TrashCash.ds_Types
        Friend WithEvents ServiceTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ServiceTypesTableAdapter As TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter
        Friend WithEvents lbl_Add1Srvc As System.Windows.Forms.Label
        Friend WithEvents lbl_ImportInvType As System.Windows.Forms.Label
        Friend WithEvents btn_AddInvType As System.Windows.Forms.Button
        Friend WithEvents cmb_InvTypes As System.Windows.Forms.ComboBox
        Friend WithEvents Ds_Invoicing As TrashCash.ds_Invoicing
        Friend WithEvents CustomInvoiceLineTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents CustomInvoice_LineTypesTableAdapter As TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter
    End Class
End Namespace