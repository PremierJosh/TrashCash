Imports TrashCash.Classes

Namespace Admin.Payments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BouncedBankSelection
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
            Dim CustomerChargeRateLabel As System.Windows.Forms.Label
            Dim lbl_checkAmount As System.Windows.Forms.Label
            Dim lbl_RefNum As System.Windows.Forms.Label
            Me.tb_BankFee = New System.Windows.Forms.TextBox()
            Me.lbl_BankFee = New System.Windows.Forms.Label()
            Me.lbl_CustFee = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnl_Bot = New System.Windows.Forms.Panel()
            Me.btn_Cancel = New System.Windows.Forms.Button()
            Me.tb_CustFee = New TrashCash.Classes.CurrencyTextBox()
            Me.btn_Submit = New System.Windows.Forms.Button()
            Me.tb_CheckAmount = New System.Windows.Forms.TextBox()
            Me.tb_RefNum = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.CustomerToolstrip1 = New TrashCash.Classes.CustomerToolstrip.CustomerToolstrip()
            Me.cmb_Banks = New System.Windows.Forms.ComboBox()
            Me.BadCheckBanksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Payments = New TrashCash.ds_Payments()
            Me.Bad_Check_BanksTableAdapter = New TrashCash.ds_PaymentsTableAdapters.Bad_Check_BanksTableAdapter()
            Me.Panel2 = New System.Windows.Forms.Panel()
            BankBounceFeeLabel = New System.Windows.Forms.Label()
            CustomerChargeRateLabel = New System.Windows.Forms.Label()
            lbl_checkAmount = New System.Windows.Forms.Label()
            lbl_RefNum = New System.Windows.Forms.Label()
            Me.pnl_Bot.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.BadCheckBanksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Payments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'BankBounceFeeLabel
            '
            BankBounceFeeLabel.AutoSize = True
            BankBounceFeeLabel.Location = New System.Drawing.Point(46, 51)
            BankBounceFeeLabel.Name = "BankBounceFeeLabel"
            BankBounceFeeLabel.Size = New System.Drawing.Size(96, 13)
            BankBounceFeeLabel.TabIndex = 17
            BankBounceFeeLabel.Text = "Bank Bounce Fee:"
            '
            'CustomerChargeRateLabel
            '
            CustomerChargeRateLabel.AutoSize = True
            CustomerChargeRateLabel.Location = New System.Drawing.Point(66, 13)
            CustomerChargeRateLabel.Name = "CustomerChargeRateLabel"
            CustomerChargeRateLabel.Size = New System.Drawing.Size(75, 13)
            CustomerChargeRateLabel.TabIndex = 27
            CustomerChargeRateLabel.Text = "Customer Fee:"
            '
            'lbl_checkAmount
            '
            lbl_checkAmount.AutoSize = True
            lbl_checkAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lbl_checkAmount.Location = New System.Drawing.Point(370, 59)
            lbl_checkAmount.Name = "lbl_checkAmount"
            lbl_checkAmount.Size = New System.Drawing.Size(46, 13)
            lbl_checkAmount.TabIndex = 32
            lbl_checkAmount.Text = "Amount:"
            '
            'lbl_RefNum
            '
            lbl_RefNum.AutoSize = True
            lbl_RefNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lbl_RefNum.Location = New System.Drawing.Point(98, 59)
            lbl_RefNum.Name = "lbl_RefNum"
            lbl_RefNum.Size = New System.Drawing.Size(104, 13)
            lbl_RefNum.TabIndex = 37
            lbl_RefNum.Text = "Check Reference #:"
            '
            'tb_BankFee
            '
            Me.tb_BankFee.Location = New System.Drawing.Point(148, 48)
            Me.tb_BankFee.Name = "tb_BankFee"
            Me.tb_BankFee.ReadOnly = True
            Me.tb_BankFee.Size = New System.Drawing.Size(59, 20)
            Me.tb_BankFee.TabIndex = 18
            '
            'lbl_BankFee
            '
            Me.lbl_BankFee.Location = New System.Drawing.Point(224, 39)
            Me.lbl_BankFee.Name = "lbl_BankFee"
            Me.lbl_BankFee.Size = New System.Drawing.Size(340, 32)
            Me.lbl_BankFee.TabIndex = 29
            Me.lbl_BankFee.Text = "This is the fee the selected Bank charged us for the bounced check." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This is not " & _
        "charged to the Customer."
            '
            'lbl_CustFee
            '
            Me.lbl_CustFee.Location = New System.Drawing.Point(223, 10)
            Me.lbl_CustFee.Name = "lbl_CustFee"
            Me.lbl_CustFee.Size = New System.Drawing.Size(340, 39)
            Me.lbl_CustFee.TabIndex = 30
            Me.lbl_CustFee.Text = "This is the Fee we charge the Cutomer for bouncing a check."
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(118, 14)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(209, 13)
            Me.Label1.TabIndex = 33
            Me.Label1.Text = "Which Bank received the bounced check."
            '
            'pnl_Bot
            '
            Me.pnl_Bot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_Bot.Controls.Add(Me.btn_Cancel)
            Me.pnl_Bot.Controls.Add(Me.tb_CustFee)
            Me.pnl_Bot.Controls.Add(Me.btn_Submit)
            Me.pnl_Bot.Controls.Add(CustomerChargeRateLabel)
            Me.pnl_Bot.Controls.Add(Me.lbl_CustFee)
            Me.pnl_Bot.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnl_Bot.Location = New System.Drawing.Point(5, 187)
            Me.pnl_Bot.Name = "pnl_Bot"
            Me.pnl_Bot.Padding = New System.Windows.Forms.Padding(5)
            Me.pnl_Bot.Size = New System.Drawing.Size(640, 79)
            Me.pnl_Bot.TabIndex = 34
            '
            'btn_Cancel
            '
            Me.btn_Cancel.ForeColor = System.Drawing.Color.Red
            Me.btn_Cancel.Location = New System.Drawing.Point(318, 42)
            Me.btn_Cancel.Name = "btn_Cancel"
            Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
            Me.btn_Cancel.TabIndex = 33
            Me.btn_Cancel.Text = "Cancel"
            Me.btn_Cancel.UseVisualStyleBackColor = True
            '
            'tb_CustFee
            '
            Me.tb_CustFee.Location = New System.Drawing.Point(147, 10)
            Me.tb_CustFee.Name = "tb_CustFee"
            Me.tb_CustFee.Size = New System.Drawing.Size(59, 20)
            Me.tb_CustFee.TabIndex = 32
            '
            'btn_Submit
            '
            Me.btn_Submit.Location = New System.Drawing.Point(202, 42)
            Me.btn_Submit.Name = "btn_Submit"
            Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
            Me.btn_Submit.TabIndex = 31
            Me.btn_Submit.Text = "Submit"
            Me.btn_Submit.UseVisualStyleBackColor = True
            '
            'tb_CheckAmount
            '
            Me.tb_CheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tb_CheckAmount.Location = New System.Drawing.Point(422, 56)
            Me.tb_CheckAmount.Name = "tb_CheckAmount"
            Me.tb_CheckAmount.ReadOnly = True
            Me.tb_CheckAmount.Size = New System.Drawing.Size(59, 20)
            Me.tb_CheckAmount.TabIndex = 31
            '
            'tb_RefNum
            '
            Me.tb_RefNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tb_RefNum.Location = New System.Drawing.Point(205, 56)
            Me.tb_RefNum.Name = "tb_RefNum"
            Me.tb_RefNum.ReadOnly = True
            Me.tb_RefNum.Size = New System.Drawing.Size(128, 20)
            Me.tb_RefNum.TabIndex = 36
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.CustomerToolstrip1)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(5, 5)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(640, 33)
            Me.Panel1.TabIndex = 38
            '
            'CustomerToolstrip1
            '
            Me.CustomerToolstrip1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CustomerToolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.CustomerToolstrip1.Location = New System.Drawing.Point(0, 0)
            Me.CustomerToolstrip1.Name = "CustomerToolstrip1"
            Me.CustomerToolstrip1.Size = New System.Drawing.Size(640, 33)
            Me.CustomerToolstrip1.TabIndex = 0
            Me.CustomerToolstrip1.Text = "CustomerToolstrip1"
            '
            'cmb_Banks
            '
            Me.cmb_Banks.DataSource = Me.BadCheckBanksBindingSource
            Me.cmb_Banks.DisplayMember = "Bank_Name"
            Me.cmb_Banks.FormattingEnabled = True
            Me.cmb_Banks.Location = New System.Drawing.Point(333, 10)
            Me.cmb_Banks.Name = "cmb_Banks"
            Me.cmb_Banks.Size = New System.Drawing.Size(136, 21)
            Me.cmb_Banks.TabIndex = 39
            Me.cmb_Banks.ValueMember = "Bank_ID"
            '
            'BadCheckBanksBindingSource
            '
            Me.BadCheckBanksBindingSource.DataMember = "Bad_Check_Banks"
            Me.BadCheckBanksBindingSource.DataSource = Me.Payments
            '
            'Payments
            '
            Me.Payments.DataSetName = "ds_Payments"
            Me.Payments.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Bad_Check_BanksTableAdapter
            '
            Me.Bad_Check_BanksTableAdapter.ClearBeforeFill = True
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.lbl_BankFee)
            Me.Panel2.Controls.Add(Me.cmb_Banks)
            Me.Panel2.Controls.Add(Me.tb_BankFee)
            Me.Panel2.Controls.Add(BankBounceFeeLabel)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(5, 92)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(640, 95)
            Me.Panel2.TabIndex = 40
            '
            'BouncedBankSelection
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(650, 271)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.tb_RefNum)
            Me.Controls.Add(lbl_RefNum)
            Me.Controls.Add(Me.tb_CheckAmount)
            Me.Controls.Add(Me.pnl_Bot)
            Me.Controls.Add(lbl_checkAmount)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "BouncedBankSelection"
            Me.Padding = New System.Windows.Forms.Padding(5)
            Me.Text = "Bounced Check"
            Me.pnl_Bot.ResumeLayout(False)
            Me.pnl_Bot.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.BadCheckBanksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Payments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tb_BankFee As System.Windows.Forms.TextBox
        Friend WithEvents lbl_BankFee As System.Windows.Forms.Label
        Friend WithEvents lbl_CustFee As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents pnl_Bot As System.Windows.Forms.Panel
        Friend WithEvents tb_CheckAmount As System.Windows.Forms.TextBox
        Friend WithEvents btn_Submit As System.Windows.Forms.Button
        Friend WithEvents tb_CustFee As CurrencyTextBox
        Friend WithEvents btn_Cancel As System.Windows.Forms.Button
        Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents CustomerToolstrip1 As TrashCash.Classes.CustomerToolstrip.CustomerToolstrip
        Friend WithEvents cmb_Banks As System.Windows.Forms.ComboBox
        Friend WithEvents Payments As DS_Payments
        Friend WithEvents BadCheckBanksBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Bad_Check_BanksTableAdapter As ds_PaymentsTableAdapters.Bad_Check_BanksTableAdapter
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
    End Class
End Namespace