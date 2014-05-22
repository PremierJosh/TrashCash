Namespace Admin
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BouncedBankSelection))
            Me.DataSet = New TrashCash.DataSet()
            Me.tb_BankFee = New System.Windows.Forms.TextBox()
            Me.lbl_BankFee = New System.Windows.Forms.Label()
            Me.lbl_CustFee = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnl_Bot = New System.Windows.Forms.Panel()
            Me.btn_Cancel = New System.Windows.Forms.Button()
            Me.tb_CustFee = New TrashCash.Currency_TextBox()
            Me.btn_Submit = New System.Windows.Forms.Button()
            Me.tb_CheckAmount = New System.Windows.Forms.TextBox()
            Me.Cmb_BadCheckBanks = New TrashCash.Database_ComboBoxes.cmb_BadCheckBanks()
            Me.tb_RefNum = New System.Windows.Forms.TextBox()
            Me.Ts_M_Customer1 = New TrashCash.ts_M_Customer()
            BankBounceFeeLabel = New System.Windows.Forms.Label()
            CustomerChargeRateLabel = New System.Windows.Forms.Label()
            lbl_checkAmount = New System.Windows.Forms.Label()
            lbl_RefNum = New System.Windows.Forms.Label()
            CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_Bot.SuspendLayout()
            Me.SuspendLayout()
            '
            'BankBounceFeeLabel
            '
            BankBounceFeeLabel.AutoSize = True
            BankBounceFeeLabel.Location = New System.Drawing.Point(7, 23)
            BankBounceFeeLabel.Name = "BankBounceFeeLabel"
            BankBounceFeeLabel.Size = New System.Drawing.Size(96, 13)
            BankBounceFeeLabel.TabIndex = 17
            BankBounceFeeLabel.Text = "Bank Bounce Fee:"
            '
            'CustomerChargeRateLabel
            '
            CustomerChargeRateLabel.AutoSize = True
            CustomerChargeRateLabel.Location = New System.Drawing.Point(28, 73)
            CustomerChargeRateLabel.Name = "CustomerChargeRateLabel"
            CustomerChargeRateLabel.Size = New System.Drawing.Size(75, 13)
            CustomerChargeRateLabel.TabIndex = 27
            CustomerChargeRateLabel.Text = "Customer Fee:"
            '
            'lbl_checkAmount
            '
            lbl_checkAmount.AutoSize = True
            lbl_checkAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lbl_checkAmount.Location = New System.Drawing.Point(335, 47)
            lbl_checkAmount.Name = "lbl_checkAmount"
            lbl_checkAmount.Size = New System.Drawing.Size(46, 13)
            lbl_checkAmount.TabIndex = 32
            lbl_checkAmount.Text = "Amount:"
            '
            'lbl_RefNum
            '
            lbl_RefNum.AutoSize = True
            lbl_RefNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lbl_RefNum.Location = New System.Drawing.Point(63, 47)
            lbl_RefNum.Name = "lbl_RefNum"
            lbl_RefNum.Size = New System.Drawing.Size(104, 13)
            lbl_RefNum.TabIndex = 37
            lbl_RefNum.Text = "Check Reference #:"
            '
            'DataSet
            '
            Me.DataSet.DataSetName = "DataSet"
            Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'tb_BankFee
            '
            Me.tb_BankFee.Location = New System.Drawing.Point(109, 20)
            Me.tb_BankFee.Name = "tb_BankFee"
            Me.tb_BankFee.ReadOnly = True
            Me.tb_BankFee.Size = New System.Drawing.Size(59, 20)
            Me.tb_BankFee.TabIndex = 18
            '
            'lbl_BankFee
            '
            Me.lbl_BankFee.Location = New System.Drawing.Point(185, 11)
            Me.lbl_BankFee.Name = "lbl_BankFee"
            Me.lbl_BankFee.Size = New System.Drawing.Size(231, 47)
            Me.lbl_BankFee.TabIndex = 29
            Me.lbl_BankFee.Text = "This is the Fee the Bank charged for the bounced check. If this amount is incorre" & _
                                  "ct, you must update it from Administration form."
            '
            'lbl_CustFee
            '
            Me.lbl_CustFee.Location = New System.Drawing.Point(185, 70)
            Me.lbl_CustFee.Name = "lbl_CustFee"
            Me.lbl_CustFee.Size = New System.Drawing.Size(227, 39)
            Me.lbl_CustFee.TabIndex = 30
            Me.lbl_CustFee.Text = "This is the Fee we charge the Cutomer for bouncing a check."
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(71, 74)
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
            Me.pnl_Bot.Controls.Add(BankBounceFeeLabel)
            Me.pnl_Bot.Controls.Add(Me.tb_BankFee)
            Me.pnl_Bot.Controls.Add(CustomerChargeRateLabel)
            Me.pnl_Bot.Controls.Add(Me.lbl_CustFee)
            Me.pnl_Bot.Controls.Add(Me.lbl_BankFee)
            Me.pnl_Bot.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnl_Bot.Location = New System.Drawing.Point(5, 102)
            Me.pnl_Bot.Name = "pnl_Bot"
            Me.pnl_Bot.Padding = New System.Windows.Forms.Padding(5)
            Me.pnl_Bot.Size = New System.Drawing.Size(535, 135)
            Me.pnl_Bot.TabIndex = 34
            '
            'btn_Cancel
            '
            Me.btn_Cancel.ForeColor = System.Drawing.Color.Red
            Me.btn_Cancel.Location = New System.Drawing.Point(280, 102)
            Me.btn_Cancel.Name = "btn_Cancel"
            Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
            Me.btn_Cancel.TabIndex = 33
            Me.btn_Cancel.Text = "Cancel"
            Me.btn_Cancel.UseVisualStyleBackColor = True
            '
            'tb_CustFee
            '
            Me.tb_CustFee.Location = New System.Drawing.Point(109, 70)
            Me.tb_CustFee.Name = "tb_CustFee"
            Me.tb_CustFee.Size = New System.Drawing.Size(59, 20)
            Me.tb_CustFee.TabIndex = 32
            '
            'btn_Submit
            '
            Me.btn_Submit.Location = New System.Drawing.Point(164, 102)
            Me.btn_Submit.Name = "btn_Submit"
            Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
            Me.btn_Submit.TabIndex = 31
            Me.btn_Submit.Text = "Submit"
            Me.btn_Submit.UseVisualStyleBackColor = True
            '
            'tb_CheckAmount
            '
            Me.tb_CheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tb_CheckAmount.Location = New System.Drawing.Point(387, 44)
            Me.tb_CheckAmount.Name = "tb_CheckAmount"
            Me.tb_CheckAmount.ReadOnly = True
            Me.tb_CheckAmount.Size = New System.Drawing.Size(59, 20)
            Me.tb_CheckAmount.TabIndex = 31
            '
            'Cmb_BadCheckBanks
            '
            Me.Cmb_BadCheckBanks.DisplayMember = "BANK_NAME"
            Me.Cmb_BadCheckBanks.FormattingEnabled = True
            Me.Cmb_BadCheckBanks.Location = New System.Drawing.Point(286, 71)
            Me.Cmb_BadCheckBanks.Name = "Cmb_BadCheckBanks"
            Me.Cmb_BadCheckBanks.Size = New System.Drawing.Size(121, 21)
            Me.Cmb_BadCheckBanks.TabIndex = 35
            Me.Cmb_BadCheckBanks.ValueMember = "BC_BANK_ID"
            '
            'tb_RefNum
            '
            Me.tb_RefNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tb_RefNum.Location = New System.Drawing.Point(170, 44)
            Me.tb_RefNum.Name = "tb_RefNum"
            Me.tb_RefNum.ReadOnly = True
            Me.tb_RefNum.Size = New System.Drawing.Size(128, 20)
            Me.tb_RefNum.TabIndex = 36
            '
            'Ts_M_Customer1
            '
            Me.Ts_M_Customer1.CurrentCustomer = 0
            Me.Ts_M_Customer1.Enabled = False
            Me.Ts_M_Customer1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.Ts_M_Customer1.Location = New System.Drawing.Point(5, 5)
            Me.Ts_M_Customer1.Name = "Ts_M_Customer1"
            Me.Ts_M_Customer1.Size = New System.Drawing.Size(535, 25)
            Me.Ts_M_Customer1.TabIndex = 38
            Me.Ts_M_Customer1.Text = "Ts_M_Customer1"
            '
            'BouncedBankSelection
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(545, 242)
            Me.Controls.Add(Me.Ts_M_Customer1)
            Me.Controls.Add(Me.tb_RefNum)
            Me.Controls.Add(lbl_RefNum)
            Me.Controls.Add(Me.Cmb_BadCheckBanks)
            Me.Controls.Add(Me.tb_CheckAmount)
            Me.Controls.Add(Me.pnl_Bot)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(lbl_checkAmount)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "BouncedBankSelection"
            Me.Padding = New System.Windows.Forms.Padding(5)
            Me.Text = "Bounced Check"
            CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_Bot.ResumeLayout(False)
            Me.pnl_Bot.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents DataSet As TrashCash.DataSet

        Friend WithEvents tb_BankFee As System.Windows.Forms.TextBox
        Friend WithEvents lbl_BankFee As System.Windows.Forms.Label
        Friend WithEvents lbl_CustFee As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents pnl_Bot As System.Windows.Forms.Panel
        Friend WithEvents tb_CheckAmount As System.Windows.Forms.TextBox
        Friend WithEvents btn_Submit As System.Windows.Forms.Button
        Friend WithEvents tb_CustFee As TrashCash.Currency_TextBox
        Friend WithEvents Cmb_BadCheckBanks As TrashCash.Database_ComboBoxes.cmb_BadCheckBanks
        Friend WithEvents btn_Cancel As System.Windows.Forms.Button
        Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
        Friend WithEvents Ts_M_Customer1 As TrashCash.ts_M_Customer
    End Class
End Namespace