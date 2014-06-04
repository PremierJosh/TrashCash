

Namespace Admin.Payments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminBanks
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
            Dim BankBounceFeeLabel As System.Windows.Forms.Label
            Dim lbl_vendorSelInfo As System.Windows.Forms.Label
            Dim lbl_BankInvItem As System.Windows.Forms.Label
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminBanks))
            Me.ts_Top = New System.Windows.Forms.ToolStrip()
            Me.btn_AddBank = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.cmb_BankList = New System.Windows.Forms.ToolStripComboBox()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.btn_ModBank = New System.Windows.Forms.ToolStripButton()
            Me.btn_SaveChanges = New System.Windows.Forms.ToolStripButton()
            Me.pnl_Bottom = New System.Windows.Forms.Panel()
            Me.lbl_BankName = New System.Windows.Forms.Label()
            Me.tb_BankName = New System.Windows.Forms.TextBox()
            Me.pnl_BankSelection = New System.Windows.Forms.Panel()
            Me.tb_BankFee = New TrashCash.Classes.CurrencyTextBox()
            Me.cmb_BankAccs = New System.Windows.Forms.ComboBox()
            Me.cmb_BanksInvItem = New System.Windows.Forms.ComboBox()
            Me.cmb_VendorAcc = New System.Windows.Forms.ComboBox()
            Me.lbl_BankSelecInfo = New System.Windows.Forms.Label()
            Me.Ds_Payments = New TrashCash.ds_Payments()
            Me.BadCheckBanksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Bad_Check_BanksTableAdapter = New TrashCash.ds_PaymentsTableAdapters.Bad_Check_BanksTableAdapter()
            Me.ck_Deactive = New System.Windows.Forms.CheckBox()
            BankBounceFeeLabel = New System.Windows.Forms.Label()
            lbl_vendorSelInfo = New System.Windows.Forms.Label()
            lbl_BankInvItem = New System.Windows.Forms.Label()
            Me.ts_Top.SuspendLayout()
            Me.pnl_Bottom.SuspendLayout()
            Me.pnl_BankSelection.SuspendLayout()
            CType(Me.Ds_Payments, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BadCheckBanksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BankBounceFeeLabel
            '
            BankBounceFeeLabel.AutoSize = True
            BankBounceFeeLabel.Location = New System.Drawing.Point(156, 93)
            BankBounceFeeLabel.Name = "BankBounceFeeLabel"
            BankBounceFeeLabel.Size = New System.Drawing.Size(220, 13)
            BankBounceFeeLabel.TabIndex = 48
            BankBounceFeeLabel.Text = "Fee this Bank charges for a Bounced Check."
            '
            'lbl_vendorSelInfo
            '
            lbl_vendorSelInfo.Location = New System.Drawing.Point(174, 67)
            lbl_vendorSelInfo.Name = "lbl_vendorSelInfo"
            lbl_vendorSelInfo.Size = New System.Drawing.Size(202, 17)
            lbl_vendorSelInfo.TabIndex = 46
            lbl_vendorSelInfo.Text = "This is the Vendor account for this Bank."
            '
            'lbl_BankInvItem
            '
            lbl_BankInvItem.Location = New System.Drawing.Point(13, 36)
            lbl_BankInvItem.Name = "lbl_BankInvItem"
            lbl_BankInvItem.Size = New System.Drawing.Size(363, 31)
            lbl_BankInvItem.TabIndex = 50
            lbl_BankInvItem.Text = "This is the Quickbooks Item that relates to this Bank Account for returned items." & _
        ""
            '
            'ts_Top
            '
            Me.ts_Top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ts_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_AddBank, Me.ToolStripSeparator2, Me.cmb_BankList, Me.ToolStripSeparator1, Me.btn_ModBank, Me.btn_SaveChanges})
            Me.ts_Top.Location = New System.Drawing.Point(0, 0)
            Me.ts_Top.Name = "ts_Top"
            Me.ts_Top.Size = New System.Drawing.Size(582, 25)
            Me.ts_Top.TabIndex = 0
            Me.ts_Top.Text = "ToolStrip1"
            '
            'btn_AddBank
            '
            Me.btn_AddBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btn_AddBank.Image = CType(resources.GetObject("btn_AddBank.Image"), System.Drawing.Image)
            Me.btn_AddBank.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_AddBank.Name = "btn_AddBank"
            Me.btn_AddBank.Size = New System.Drawing.Size(89, 22)
            Me.btn_AddBank.Text = "Add New Bank"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'cmb_BankList
            '
            Me.cmb_BankList.Name = "cmb_BankList"
            Me.cmb_BankList.Size = New System.Drawing.Size(121, 25)
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'btn_ModBank
            '
            Me.btn_ModBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btn_ModBank.Image = CType(resources.GetObject("btn_ModBank.Image"), System.Drawing.Image)
            Me.btn_ModBank.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_ModBank.Name = "btn_ModBank"
            Me.btn_ModBank.Size = New System.Drawing.Size(49, 22)
            Me.btn_ModBank.Text = "Modify"
            '
            'btn_SaveChanges
            '
            Me.btn_SaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btn_SaveChanges.Image = CType(resources.GetObject("btn_SaveChanges.Image"), System.Drawing.Image)
            Me.btn_SaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_SaveChanges.Name = "btn_SaveChanges"
            Me.btn_SaveChanges.Size = New System.Drawing.Size(84, 22)
            Me.btn_SaveChanges.Text = "Save Changes"
            Me.btn_SaveChanges.Visible = False
            '
            'pnl_Bottom
            '
            Me.pnl_Bottom.Controls.Add(Me.ck_Deactive)
            Me.pnl_Bottom.Controls.Add(Me.lbl_BankName)
            Me.pnl_Bottom.Controls.Add(Me.tb_BankName)
            Me.pnl_Bottom.Controls.Add(Me.pnl_BankSelection)
            Me.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_Bottom.Location = New System.Drawing.Point(0, 25)
            Me.pnl_Bottom.Name = "pnl_Bottom"
            Me.pnl_Bottom.Padding = New System.Windows.Forms.Padding(5)
            Me.pnl_Bottom.Size = New System.Drawing.Size(582, 163)
            Me.pnl_Bottom.TabIndex = 2
            '
            'lbl_BankName
            '
            Me.lbl_BankName.AutoSize = True
            Me.lbl_BankName.Location = New System.Drawing.Point(127, 9)
            Me.lbl_BankName.Name = "lbl_BankName"
            Me.lbl_BankName.Size = New System.Drawing.Size(131, 13)
            Me.lbl_BankName.TabIndex = 70
            Me.lbl_BankName.Text = "Name of this Bank setting:"
            '
            'tb_BankName
            '
            Me.tb_BankName.Location = New System.Drawing.Point(258, 6)
            Me.tb_BankName.Name = "tb_BankName"
            Me.tb_BankName.Size = New System.Drawing.Size(163, 20)
            Me.tb_BankName.TabIndex = 69
            '
            'pnl_BankSelection
            '
            Me.pnl_BankSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_BankSelection.Controls.Add(Me.tb_BankFee)
            Me.pnl_BankSelection.Controls.Add(Me.cmb_BankAccs)
            Me.pnl_BankSelection.Controls.Add(Me.cmb_BanksInvItem)
            Me.pnl_BankSelection.Controls.Add(Me.cmb_VendorAcc)
            Me.pnl_BankSelection.Controls.Add(BankBounceFeeLabel)
            Me.pnl_BankSelection.Controls.Add(Me.lbl_BankSelecInfo)
            Me.pnl_BankSelection.Controls.Add(lbl_vendorSelInfo)
            Me.pnl_BankSelection.Controls.Add(lbl_BankInvItem)
            Me.pnl_BankSelection.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnl_BankSelection.Location = New System.Drawing.Point(5, 40)
            Me.pnl_BankSelection.Name = "pnl_BankSelection"
            Me.pnl_BankSelection.Size = New System.Drawing.Size(572, 118)
            Me.pnl_BankSelection.TabIndex = 68
            '
            'tb_BankFee
            '
            Me.tb_BankFee.Location = New System.Drawing.Point(382, 91)
            Me.tb_BankFee.Name = "tb_BankFee"
            Me.tb_BankFee.Size = New System.Drawing.Size(62, 20)
            Me.tb_BankFee.TabIndex = 64
            '
            'cmb_BankAccs
            '
            Me.cmb_BankAccs.FormattingEnabled = True
            Me.cmb_BankAccs.Location = New System.Drawing.Point(382, 3)
            Me.cmb_BankAccs.Name = "cmb_BankAccs"
            Me.cmb_BankAccs.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BankAccs.TabIndex = 63
            '
            'cmb_BanksInvItem
            '
            Me.cmb_BanksInvItem.FormattingEnabled = True
            Me.cmb_BanksInvItem.Location = New System.Drawing.Point(382, 33)
            Me.cmb_BanksInvItem.Name = "cmb_BanksInvItem"
            Me.cmb_BanksInvItem.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BanksInvItem.TabIndex = 62
            '
            'cmb_VendorAcc
            '
            Me.cmb_VendorAcc.FormattingEnabled = True
            Me.cmb_VendorAcc.Location = New System.Drawing.Point(382, 64)
            Me.cmb_VendorAcc.Name = "cmb_VendorAcc"
            Me.cmb_VendorAcc.Size = New System.Drawing.Size(187, 21)
            Me.cmb_VendorAcc.TabIndex = 61
            '
            'lbl_BankSelecInfo
            '
            Me.lbl_BankSelecInfo.AutoSize = True
            Me.lbl_BankSelecInfo.Location = New System.Drawing.Point(10, 6)
            Me.lbl_BankSelecInfo.Name = "lbl_BankSelecInfo"
            Me.lbl_BankSelecInfo.Size = New System.Drawing.Size(366, 13)
            Me.lbl_BankSelecInfo.TabIndex = 59
            Me.lbl_BankSelecInfo.Text = "This is the Quickbooks Bank Account that could recieve a Bounced Check."
            '
            'Ds_Payments
            '
            Me.Ds_Payments.DataSetName = "ds_Payments"
            Me.Ds_Payments.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'BadCheckBanksBindingSource
            '
            Me.BadCheckBanksBindingSource.DataMember = "Bad_Check_Banks"
            Me.BadCheckBanksBindingSource.DataSource = Me.Ds_Payments
            '
            'Bad_Check_BanksTableAdapter
            '
            Me.Bad_Check_BanksTableAdapter.ClearBeforeFill = True
            '
            'ck_Deactive
            '
            Me.ck_Deactive.AutoSize = True
            Me.ck_Deactive.ForeColor = System.Drawing.Color.Red
            Me.ck_Deactive.Location = New System.Drawing.Point(440, 9)
            Me.ck_Deactive.Name = "ck_Deactive"
            Me.ck_Deactive.Size = New System.Drawing.Size(69, 17)
            Me.ck_Deactive.TabIndex = 71
            Me.ck_Deactive.Text = "Deactive"
            Me.ck_Deactive.UseVisualStyleBackColor = True
            '
            'AdminBanks
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(582, 188)
            Me.Controls.Add(Me.pnl_Bottom)
            Me.Controls.Add(Me.ts_Top)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AdminBanks"
            Me.Text = "Bank Maintenance"
            Me.ts_Top.ResumeLayout(False)
            Me.ts_Top.PerformLayout()
            Me.pnl_Bottom.ResumeLayout(False)
            Me.pnl_Bottom.PerformLayout()
            Me.pnl_BankSelection.ResumeLayout(False)
            Me.pnl_BankSelection.PerformLayout()
            CType(Me.Ds_Payments, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BadCheckBanksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ts_Top As System.Windows.Forms.ToolStrip
        Friend WithEvents btn_AddBank As System.Windows.Forms.ToolStripButton
        Friend WithEvents btn_ModBank As System.Windows.Forms.ToolStripButton
        Friend WithEvents btn_SaveChanges As System.Windows.Forms.ToolStripButton
  Friend WithEvents pnl_Bottom As System.Windows.Forms.Panel
        Friend WithEvents lbl_BankName As System.Windows.Forms.Label
        Friend WithEvents tb_BankName As System.Windows.Forms.TextBox
        Friend WithEvents pnl_BankSelection As System.Windows.Forms.Panel
        Friend WithEvents tb_BankFee As TrashCash.Classes.CurrencyTextBox
        Friend WithEvents cmb_BankAccs As System.Windows.Forms.ComboBox
        Friend WithEvents cmb_BanksInvItem As System.Windows.Forms.ComboBox
        Friend WithEvents cmb_VendorAcc As System.Windows.Forms.ComboBox
        Friend WithEvents lbl_BankSelecInfo As System.Windows.Forms.Label
        Friend WithEvents cmb_BankList As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents Ds_Payments As TrashCash.ds_Payments
        Friend WithEvents BadCheckBanksBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Bad_Check_BanksTableAdapter As TrashCash.ds_PaymentsTableAdapters.Bad_Check_BanksTableAdapter
        Friend WithEvents ck_Deactive As System.Windows.Forms.CheckBox
    End Class
End Namespace