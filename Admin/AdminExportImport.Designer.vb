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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminExportImport))
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
            Me.tb_CustInvCount = New System.Windows.Forms.TextBox()
            Me.lbl_CustInvAdd = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.tb_ResetRecID = New System.Windows.Forms.TextBox()
            Me.btn_FetchRecReset = New System.Windows.Forms.Button()
            Me.lbl_SrvcResetHeader = New System.Windows.Forms.Label()
            Me.ServiceTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter()
            Me.lbl_RecResetID = New System.Windows.Forms.Label()
            Me.btn_LastBillThru = New System.Windows.Forms.Button()
            Me.btn_DeleteHistory = New System.Windows.Forms.Button()
            Me.lbl_DeleteTotal = New System.Windows.Forms.Label()
            Me.dtp_LastBillThru = New System.Windows.Forms.DateTimePicker()
            Me.grp_ResetInvGrp = New System.Windows.Forms.GroupBox()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.pnl_CustAdd.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.grp_ResetInvGrp.SuspendLayout()
            Me.SuspendLayout()
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.pnl_CustAdd)
            Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
            Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
            Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
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
            Me.Panel1.Controls.Add(Me.btn_AddSrvc)
            Me.Panel1.Controls.Add(Me.cmb_ServiceTypes)
            Me.Panel1.Controls.Add(Me.btn_AddSrvcs)
            Me.Panel1.Controls.Add(Me.cmb_IncomeAcc)
            Me.Panel1.Controls.Add(Me.lbl_ServiceAdd)
            Me.Panel1.Location = New System.Drawing.Point(3, 77)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(585, 70)
            Me.Panel1.TabIndex = 2
            '
            'btn_AddSrvc
            '
            Me.btn_AddSrvc.AutoSize = True
            Me.btn_AddSrvc.Location = New System.Drawing.Point(487, 40)
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
            Me.cmb_ServiceTypes.Location = New System.Drawing.Point(312, 40)
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
            Me.lbl_ServiceAdd.AutoSize = True
            Me.lbl_ServiceAdd.Location = New System.Drawing.Point(3, 18)
            Me.lbl_ServiceAdd.Name = "lbl_ServiceAdd"
            Me.lbl_ServiceAdd.Size = New System.Drawing.Size(310, 13)
            Me.lbl_ServiceAdd.TabIndex = 0
            Me.lbl_ServiceAdd.Text = "This will add all services to the following account in Quickbooks."
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.btn_AddCustInv)
            Me.Panel3.Controls.Add(Me.tb_CustInvCount)
            Me.Panel3.Controls.Add(Me.lbl_CustInvAdd)
            Me.Panel3.Location = New System.Drawing.Point(3, 153)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(585, 78)
            Me.Panel3.TabIndex = 4
            '
            'btn_AddCustInv
            '
            Me.btn_AddCustInv.AutoSize = True
            Me.btn_AddCustInv.Location = New System.Drawing.Point(442, 21)
            Me.btn_AddCustInv.Name = "btn_AddCustInv"
            Me.btn_AddCustInv.Size = New System.Drawing.Size(79, 23)
            Me.btn_AddCustInv.TabIndex = 2
            Me.btn_AddCustInv.Text = "Add Invoices"
            Me.btn_AddCustInv.UseVisualStyleBackColor = True
            '
            'tb_CustInvCount
            '
            Me.tb_CustInvCount.Location = New System.Drawing.Point(369, 23)
            Me.tb_CustInvCount.Name = "tb_CustInvCount"
            Me.tb_CustInvCount.Size = New System.Drawing.Size(67, 20)
            Me.tb_CustInvCount.TabIndex = 1
            '
            'lbl_CustInvAdd
            '
            Me.lbl_CustInvAdd.AutoSize = True
            Me.lbl_CustInvAdd.Location = New System.Drawing.Point(17, 26)
            Me.lbl_CustInvAdd.Name = "lbl_CustInvAdd"
            Me.lbl_CustInvAdd.Size = New System.Drawing.Size(346, 13)
            Me.lbl_CustInvAdd.TabIndex = 0
            Me.lbl_CustInvAdd.Text = "This will make custom invoices for each row in the Import_CustInv table."
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.grp_ResetInvGrp)
            Me.Panel2.Controls.Add(Me.lbl_RecResetID)
            Me.Panel2.Controls.Add(Me.tb_ResetRecID)
            Me.Panel2.Controls.Add(Me.btn_FetchRecReset)
            Me.Panel2.Controls.Add(Me.lbl_SrvcResetHeader)
            Me.Panel2.Location = New System.Drawing.Point(3, 237)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(585, 117)
            Me.Panel2.TabIndex = 5
            '
            'tb_ResetRecID
            '
            Me.tb_ResetRecID.Location = New System.Drawing.Point(125, 53)
            Me.tb_ResetRecID.Name = "tb_ResetRecID"
            Me.tb_ResetRecID.Size = New System.Drawing.Size(72, 20)
            Me.tb_ResetRecID.TabIndex = 2
            '
            'btn_FetchRecReset
            '
            Me.btn_FetchRecReset.Location = New System.Drawing.Point(203, 53)
            Me.btn_FetchRecReset.Name = "btn_FetchRecReset"
            Me.btn_FetchRecReset.Size = New System.Drawing.Size(71, 23)
            Me.btn_FetchRecReset.TabIndex = 1
            Me.btn_FetchRecReset.Text = "Fetch Info"
            Me.btn_FetchRecReset.UseVisualStyleBackColor = True
            '
            'lbl_SrvcResetHeader
            '
            Me.lbl_SrvcResetHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_SrvcResetHeader.Location = New System.Drawing.Point(0, 0)
            Me.lbl_SrvcResetHeader.Name = "lbl_SrvcResetHeader"
            Me.lbl_SrvcResetHeader.Size = New System.Drawing.Size(583, 39)
            Me.lbl_SrvcResetHeader.TabIndex = 0
            Me.lbl_SrvcResetHeader.Text = resources.GetString("lbl_SrvcResetHeader.Text")
            Me.lbl_SrvcResetHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ServiceTypesTableAdapter
            '
            Me.ServiceTypesTableAdapter.ClearBeforeFill = True
            '
            'lbl_RecResetID
            '
            Me.lbl_RecResetID.AutoSize = True
            Me.lbl_RecResetID.Location = New System.Drawing.Point(16, 56)
            Me.lbl_RecResetID.Name = "lbl_RecResetID"
            Me.lbl_RecResetID.Size = New System.Drawing.Size(103, 13)
            Me.lbl_RecResetID.TabIndex = 3
            Me.lbl_RecResetID.Text = "RecurringServiceID:"
            '
            'btn_LastBillThru
            '
            Me.btn_LastBillThru.Location = New System.Drawing.Point(32, 43)
            Me.btn_LastBillThru.Name = "btn_LastBillThru"
            Me.btn_LastBillThru.Size = New System.Drawing.Size(75, 23)
            Me.btn_LastBillThru.TabIndex = 4
            Me.btn_LastBillThru.Text = "LastBillThru"
            Me.btn_LastBillThru.UseVisualStyleBackColor = True
            '
            'btn_DeleteHistory
            '
            Me.btn_DeleteHistory.AutoSize = True
            Me.btn_DeleteHistory.Location = New System.Drawing.Point(166, 43)
            Me.btn_DeleteHistory.Name = "btn_DeleteHistory"
            Me.btn_DeleteHistory.Size = New System.Drawing.Size(83, 23)
            Me.btn_DeleteHistory.TabIndex = 5
            Me.btn_DeleteHistory.Text = "Delete History"
            Me.btn_DeleteHistory.UseVisualStyleBackColor = True
            '
            'lbl_DeleteTotal
            '
            Me.lbl_DeleteTotal.AutoSize = True
            Me.lbl_DeleteTotal.Location = New System.Drawing.Point(143, 20)
            Me.lbl_DeleteTotal.Name = "lbl_DeleteTotal"
            Me.lbl_DeleteTotal.Size = New System.Drawing.Size(114, 13)
            Me.lbl_DeleteTotal.TabIndex = 6
            Me.lbl_DeleteTotal.Text = "Total to be deleted: 99"
            '
            'dtp_LastBillThru
            '
            Me.dtp_LastBillThru.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_LastBillThru.Location = New System.Drawing.Point(18, 18)
            Me.dtp_LastBillThru.Name = "dtp_LastBillThru"
            Me.dtp_LastBillThru.Size = New System.Drawing.Size(104, 20)
            Me.dtp_LastBillThru.TabIndex = 7
            '
            'grp_ResetInvGrp
            '
            Me.grp_ResetInvGrp.Controls.Add(Me.dtp_LastBillThru)
            Me.grp_ResetInvGrp.Controls.Add(Me.btn_LastBillThru)
            Me.grp_ResetInvGrp.Controls.Add(Me.lbl_DeleteTotal)
            Me.grp_ResetInvGrp.Controls.Add(Me.btn_DeleteHistory)
            Me.grp_ResetInvGrp.Location = New System.Drawing.Point(298, 39)
            Me.grp_ResetInvGrp.Name = "grp_ResetInvGrp"
            Me.grp_ResetInvGrp.Size = New System.Drawing.Size(277, 73)
            Me.grp_ResetInvGrp.TabIndex = 8
            Me.grp_ResetInvGrp.TabStop = False
            Me.grp_ResetInvGrp.Text = "Recurring Service Info"
            Me.grp_ResetInvGrp.Visible = False
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
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.grp_ResetInvGrp.ResumeLayout(False)
            Me.grp_ResetInvGrp.PerformLayout()
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
        Friend WithEvents lbl_CustInvAdd As System.Windows.Forms.Label
        Friend WithEvents btn_AddCustInv As System.Windows.Forms.Button
        Friend WithEvents tb_CustInvCount As System.Windows.Forms.TextBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents cmb_ServiceTypes As System.Windows.Forms.ComboBox
        Friend WithEvents tb_ResetRecID As System.Windows.Forms.TextBox
        Friend WithEvents btn_FetchRecReset As System.Windows.Forms.Button
        Friend WithEvents lbl_SrvcResetHeader As System.Windows.Forms.Label
        Friend WithEvents btn_AddSrvc As System.Windows.Forms.Button
        Friend WithEvents Ds_Types As TrashCash.ds_Types
        Friend WithEvents ServiceTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ServiceTypesTableAdapter As TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter
        Friend WithEvents dtp_LastBillThru As System.Windows.Forms.DateTimePicker
        Friend WithEvents lbl_DeleteTotal As System.Windows.Forms.Label
        Friend WithEvents btn_DeleteHistory As System.Windows.Forms.Button
        Friend WithEvents btn_LastBillThru As System.Windows.Forms.Button
        Friend WithEvents lbl_RecResetID As System.Windows.Forms.Label
        Friend WithEvents grp_ResetInvGrp As System.Windows.Forms.GroupBox
    End Class
End Namespace