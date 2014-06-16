Imports TrashCash.Customer

Namespace Admin.Payments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MovePaymentForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovePaymentForm))
            Me.pnl_top = New System.Windows.Forms.Panel()
            Me.lbl_FormInfo = New System.Windows.Forms.Label()
            Me.grp_CurPayInfo = New System.Windows.Forms.GroupBox()
            Me.lbl_InputBy = New System.Windows.Forms.Label()
            Me.dtp_DateOnChk = New System.Windows.Forms.DateTimePicker()
            Me.lbl_DateOnCk = New System.Windows.Forms.Label()
            Me.dtp_RecDateTime = New System.Windows.Forms.DateTimePicker()
            Me.lbl_RecDate = New System.Windows.Forms.Label()
            Me.tb_RefNum = New System.Windows.Forms.TextBox()
            Me.lbl_RefNum = New System.Windows.Forms.Label()
            Me.tb_Amount = New System.Windows.Forms.TextBox()
            Me.lbl_Amount = New System.Windows.Forms.Label()
            Me.cmb_CurrCustomer = New System.Windows.Forms.ComboBox()
            Me.CurrentCustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_Customer = New ds_Customer()
            Me.lbl_CurrCustomer = New System.Windows.Forms.Label()
            Me.Customer_ListByActiveTableAdapter = New ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter()
            Me.lbl_NewCust = New System.Windows.Forms.Label()
            Me.cmb_MoveToCust = New System.Windows.Forms.ComboBox()
            Me.btn_MovePay = New System.Windows.Forms.Button()
            Me.NewCustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.pnl_top.SuspendLayout()
            Me.grp_CurPayInfo.SuspendLayout()
            CType(Me.CurrentCustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NewCustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnl_top
            '
            Me.pnl_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_top.Controls.Add(Me.lbl_FormInfo)
            Me.pnl_top.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_top.Location = New System.Drawing.Point(0, 0)
            Me.pnl_top.Name = "pnl_top"
            Me.pnl_top.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.pnl_top.Size = New System.Drawing.Size(565, 66)
            Me.pnl_top.TabIndex = 0
            '
            'lbl_FormInfo
            '
            Me.lbl_FormInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_FormInfo.Location = New System.Drawing.Point(0, 5)
            Me.lbl_FormInfo.Name = "lbl_FormInfo"
            Me.lbl_FormInfo.Size = New System.Drawing.Size(563, 53)
            Me.lbl_FormInfo.TabIndex = 0
            Me.lbl_FormInfo.Text = resources.GetString("lbl_FormInfo.Text")
            Me.lbl_FormInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grp_CurPayInfo
            '
            Me.grp_CurPayInfo.Controls.Add(Me.lbl_InputBy)
            Me.grp_CurPayInfo.Controls.Add(Me.dtp_DateOnChk)
            Me.grp_CurPayInfo.Controls.Add(Me.lbl_DateOnCk)
            Me.grp_CurPayInfo.Controls.Add(Me.dtp_RecDateTime)
            Me.grp_CurPayInfo.Controls.Add(Me.lbl_RecDate)
            Me.grp_CurPayInfo.Controls.Add(Me.tb_RefNum)
            Me.grp_CurPayInfo.Controls.Add(Me.lbl_RefNum)
            Me.grp_CurPayInfo.Controls.Add(Me.tb_Amount)
            Me.grp_CurPayInfo.Controls.Add(Me.lbl_Amount)
            Me.grp_CurPayInfo.Controls.Add(Me.cmb_CurrCustomer)
            Me.grp_CurPayInfo.Controls.Add(Me.lbl_CurrCustomer)
            Me.grp_CurPayInfo.Enabled = False
            Me.grp_CurPayInfo.Location = New System.Drawing.Point(23, 72)
            Me.grp_CurPayInfo.Name = "grp_CurPayInfo"
            Me.grp_CurPayInfo.Size = New System.Drawing.Size(529, 129)
            Me.grp_CurPayInfo.TabIndex = 1
            Me.grp_CurPayInfo.TabStop = False
            Me.grp_CurPayInfo.Text = "Current Payment Information"
            '
            'lbl_InputBy
            '
            Me.lbl_InputBy.AutoSize = True
            Me.lbl_InputBy.Location = New System.Drawing.Point(406, 91)
            Me.lbl_InputBy.Name = "lbl_InputBy"
            Me.lbl_InputBy.Size = New System.Drawing.Size(87, 13)
            Me.lbl_InputBy.TabIndex = 10
            Me.lbl_InputBy.Text = "Input By: Premier"
            '
            'dtp_DateOnChk
            '
            Me.dtp_DateOnChk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_DateOnChk.Location = New System.Drawing.Point(284, 87)
            Me.dtp_DateOnChk.Name = "dtp_DateOnChk"
            Me.dtp_DateOnChk.Size = New System.Drawing.Size(85, 20)
            Me.dtp_DateOnChk.TabIndex = 9
            Me.dtp_DateOnChk.Visible = False
            '
            'lbl_DateOnCk
            '
            Me.lbl_DateOnCk.AutoSize = True
            Me.lbl_DateOnCk.Location = New System.Drawing.Point(197, 91)
            Me.lbl_DateOnCk.Name = "lbl_DateOnCk"
            Me.lbl_DateOnCk.Size = New System.Drawing.Size(81, 13)
            Me.lbl_DateOnCk.TabIndex = 8
            Me.lbl_DateOnCk.Text = "Date on check:"
            Me.lbl_DateOnCk.Visible = False
            '
            'dtp_RecDateTime
            '
            Me.dtp_RecDateTime.CustomFormat = "ddddd, MMMM dd, yyyy hh:mm tt"
            Me.dtp_RecDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtp_RecDateTime.Location = New System.Drawing.Point(276, 61)
            Me.dtp_RecDateTime.Name = "dtp_RecDateTime"
            Me.dtp_RecDateTime.Size = New System.Drawing.Size(232, 20)
            Me.dtp_RecDateTime.TabIndex = 7
            '
            'lbl_RecDate
            '
            Me.lbl_RecDate.AutoSize = True
            Me.lbl_RecDate.Location = New System.Drawing.Point(197, 64)
            Me.lbl_RecDate.Name = "lbl_RecDate"
            Me.lbl_RecDate.Size = New System.Drawing.Size(73, 13)
            Me.lbl_RecDate.TabIndex = 6
            Me.lbl_RecDate.Text = "Received On:"
            '
            'tb_RefNum
            '
            Me.tb_RefNum.Location = New System.Drawing.Point(80, 87)
            Me.tb_RefNum.Name = "tb_RefNum"
            Me.tb_RefNum.Size = New System.Drawing.Size(100, 20)
            Me.tb_RefNum.TabIndex = 5
            Me.tb_RefNum.Visible = False
            '
            'lbl_RefNum
            '
            Me.lbl_RefNum.AutoSize = True
            Me.lbl_RefNum.Location = New System.Drawing.Point(4, 91)
            Me.lbl_RefNum.Name = "lbl_RefNum"
            Me.lbl_RefNum.Size = New System.Drawing.Size(70, 13)
            Me.lbl_RefNum.TabIndex = 4
            Me.lbl_RefNum.Text = "Reference #:"
            Me.lbl_RefNum.Visible = False
            '
            'tb_Amount
            '
            Me.tb_Amount.Location = New System.Drawing.Point(80, 61)
            Me.tb_Amount.Name = "tb_Amount"
            Me.tb_Amount.Size = New System.Drawing.Size(100, 20)
            Me.tb_Amount.TabIndex = 3
            '
            'lbl_Amount
            '
            Me.lbl_Amount.AutoSize = True
            Me.lbl_Amount.Location = New System.Drawing.Point(28, 64)
            Me.lbl_Amount.Name = "lbl_Amount"
            Me.lbl_Amount.Size = New System.Drawing.Size(46, 13)
            Me.lbl_Amount.TabIndex = 2
            Me.lbl_Amount.Text = "Amount:"
            '
            'cmb_CurrCustomer
            '
            Me.cmb_CurrCustomer.DataSource = Me.CurrentCustomerBindingSource
            Me.cmb_CurrCustomer.DisplayMember = "CustomerFullName"
            Me.cmb_CurrCustomer.Enabled = False
            Me.cmb_CurrCustomer.FormattingEnabled = True
            Me.cmb_CurrCustomer.Location = New System.Drawing.Point(103, 22)
            Me.cmb_CurrCustomer.Name = "cmb_CurrCustomer"
            Me.cmb_CurrCustomer.Size = New System.Drawing.Size(351, 21)
            Me.cmb_CurrCustomer.TabIndex = 1
            Me.cmb_CurrCustomer.ValueMember = "CustomerNumber"
            '
            'CurrentCustomerBindingSource
            '
            Me.CurrentCustomerBindingSource.DataMember = "Customer_ListByActive"
            Me.CurrentCustomerBindingSource.DataSource = Me.Ds_Customer
            '
            'Ds_Customer
            '
            Me.Ds_Customer.DataSetName = "ds_Customer"
            Me.Ds_Customer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'lbl_CurrCustomer
            '
            Me.lbl_CurrCustomer.AutoSize = True
            Me.lbl_CurrCustomer.Location = New System.Drawing.Point(6, 25)
            Me.lbl_CurrCustomer.Name = "lbl_CurrCustomer"
            Me.lbl_CurrCustomer.Size = New System.Drawing.Size(91, 13)
            Me.lbl_CurrCustomer.TabIndex = 0
            Me.lbl_CurrCustomer.Text = "Current Customer:"
            '
            'Customer_ListByActiveTableAdapter
            '
            Me.Customer_ListByActiveTableAdapter.ClearBeforeFill = True
            '
            'lbl_NewCust
            '
            Me.lbl_NewCust.AutoSize = True
            Me.lbl_NewCust.Location = New System.Drawing.Point(15, 227)
            Me.lbl_NewCust.Name = "lbl_NewCust"
            Me.lbl_NewCust.Size = New System.Drawing.Size(96, 13)
            Me.lbl_NewCust.TabIndex = 2
            Me.lbl_NewCust.Text = "Move to Customer:"
            '
            'cmb_MoveToCust
            '
            Me.cmb_MoveToCust.DataSource = Me.NewCustomerBindingSource
            Me.cmb_MoveToCust.DisplayMember = "CustomerFullName"
            Me.cmb_MoveToCust.FormattingEnabled = True
            Me.cmb_MoveToCust.Location = New System.Drawing.Point(116, 224)
            Me.cmb_MoveToCust.Name = "cmb_MoveToCust"
            Me.cmb_MoveToCust.Size = New System.Drawing.Size(361, 21)
            Me.cmb_MoveToCust.TabIndex = 3
            Me.cmb_MoveToCust.ValueMember = "CustomerNumber"
            '
            'btn_MovePay
            '
            Me.btn_MovePay.AutoSize = True
            Me.btn_MovePay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_MovePay.Location = New System.Drawing.Point(214, 267)
            Me.btn_MovePay.Name = "btn_MovePay"
            Me.btn_MovePay.Size = New System.Drawing.Size(108, 26)
            Me.btn_MovePay.TabIndex = 5
            Me.btn_MovePay.Text = "Move Payment"
            Me.btn_MovePay.UseVisualStyleBackColor = True
            '
            'NewCustomerBindingSource
            '
            Me.NewCustomerBindingSource.DataMember = "Customer_ListByActive"
            Me.NewCustomerBindingSource.DataSource = Me.Ds_Customer
            '
            'MovePaymentForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(565, 324)
            Me.Controls.Add(Me.btn_MovePay)
            Me.Controls.Add(Me.cmb_MoveToCust)
            Me.Controls.Add(Me.lbl_NewCust)
            Me.Controls.Add(Me.grp_CurPayInfo)
            Me.Controls.Add(Me.pnl_top)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "MovePaymentForm"
            Me.Text = "Move Payment"
            Me.pnl_top.ResumeLayout(False)
            Me.grp_CurPayInfo.ResumeLayout(False)
            Me.grp_CurPayInfo.PerformLayout()
            CType(Me.CurrentCustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NewCustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents pnl_top As System.Windows.Forms.Panel
        Friend WithEvents lbl_FormInfo As System.Windows.Forms.Label
        Friend WithEvents grp_CurPayInfo As System.Windows.Forms.GroupBox
        Friend WithEvents cmb_CurrCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CurrentCustomerBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Ds_Customer As ds_Customer
        Friend WithEvents lbl_CurrCustomer As System.Windows.Forms.Label
        Friend WithEvents Customer_ListByActiveTableAdapter As ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter
        Friend WithEvents lbl_InputBy As System.Windows.Forms.Label
        Friend WithEvents dtp_DateOnChk As System.Windows.Forms.DateTimePicker
        Friend WithEvents lbl_DateOnCk As System.Windows.Forms.Label
        Friend WithEvents dtp_RecDateTime As System.Windows.Forms.DateTimePicker
        Friend WithEvents lbl_RecDate As System.Windows.Forms.Label
        Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
        Friend WithEvents lbl_RefNum As System.Windows.Forms.Label
        Friend WithEvents tb_Amount As System.Windows.Forms.TextBox
        Friend WithEvents lbl_Amount As System.Windows.Forms.Label
        Friend WithEvents lbl_NewCust As System.Windows.Forms.Label
        Friend WithEvents cmb_MoveToCust As System.Windows.Forms.ComboBox
        Friend WithEvents btn_MovePay As System.Windows.Forms.Button
        Friend WithEvents NewCustomerBindingSource As System.Windows.Forms.BindingSource
    End Class
End Namespace