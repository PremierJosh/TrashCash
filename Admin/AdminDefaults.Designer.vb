Imports TrashCash.Classes

Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminDefaults
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
            Dim lbl_CustInfoDesc As System.Windows.Forms.Label
            Dim lbl_CheckItem As System.Windows.Forms.Label
            Dim CustomerChargeRateLabel As System.Windows.Forms.Label
            Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
            Me.hdr_BadCheck = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.tb_BadCheckCustFee = New TrashCash.Classes.CurrencyTextBox()
            Me.cmb_BadCheckItem = New System.Windows.Forms.ComboBox()
            Me.cmb_BadCheckCustInvItem = New System.Windows.Forms.ComboBox()
            Me.lbl_DateLimits = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.dtp_CurrClosedDate = New System.Windows.Forms.DateTimePicker()
            Me.lbl_CompClosingDate = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.nud_InvArrLimit = New System.Windows.Forms.NumericUpDown()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.nud_InvAdvLimit = New System.Windows.Forms.NumericUpDown()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btn_Save = New System.Windows.Forms.Button()
            lbl_CustInfoDesc = New System.Windows.Forms.Label()
            lbl_CheckItem = New System.Windows.Forms.Label()
            CustomerChargeRateLabel = New System.Windows.Forms.Label()
            Me.FlowLayoutPanel.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.nud_InvArrLimit, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nud_InvAdvLimit, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lbl_CustInfoDesc
            '
            lbl_CustInfoDesc.Location = New System.Drawing.Point(14, 42)
            lbl_CustInfoDesc.Name = "lbl_CustInfoDesc"
            lbl_CustInfoDesc.Size = New System.Drawing.Size(356, 22)
            lbl_CustInfoDesc.TabIndex = 56
            lbl_CustInfoDesc.Text = "This is the Quickbooks Item that represents our fee for the returned item."
            '
            'lbl_CheckItem
            '
            lbl_CheckItem.Location = New System.Drawing.Point(8, 5)
            lbl_CheckItem.Name = "lbl_CheckItem"
            lbl_CheckItem.Size = New System.Drawing.Size(362, 27)
            lbl_CheckItem.TabIndex = 47
            lbl_CheckItem.Text = "This is the Quickbooks Item that represents a returned check and is the amount th" & _
        "at the bank is charging us."
            '
            'CustomerChargeRateLabel
            '
            CustomerChargeRateLabel.AutoSize = True
            CustomerChargeRateLabel.Location = New System.Drawing.Point(155, 69)
            CustomerChargeRateLabel.Name = "CustomerChargeRateLabel"
            CustomerChargeRateLabel.Size = New System.Drawing.Size(205, 13)
            CustomerChargeRateLabel.TabIndex = 52
            CustomerChargeRateLabel.Text = "Our Fee for a Customer bouncing a check"
            '
            'FlowLayoutPanel
            '
            Me.FlowLayoutPanel.Controls.Add(Me.hdr_BadCheck)
            Me.FlowLayoutPanel.Controls.Add(Me.Panel1)
            Me.FlowLayoutPanel.Controls.Add(Me.lbl_DateLimits)
            Me.FlowLayoutPanel.Controls.Add(Me.Panel2)
            Me.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.FlowLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
            Me.FlowLayoutPanel.Size = New System.Drawing.Size(666, 283)
            Me.FlowLayoutPanel.TabIndex = 1
            '
            'hdr_BadCheck
            '
            Me.hdr_BadCheck.AutoSize = True
            Me.hdr_BadCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.hdr_BadCheck.Location = New System.Drawing.Point(3, 0)
            Me.hdr_BadCheck.Name = "hdr_BadCheck"
            Me.hdr_BadCheck.Size = New System.Drawing.Size(149, 16)
            Me.hdr_BadCheck.TabIndex = 5
            Me.hdr_BadCheck.Text = "Bad Check Settings"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.tb_BadCheckCustFee)
            Me.Panel1.Controls.Add(Me.cmb_BadCheckItem)
            Me.Panel1.Controls.Add(Me.cmb_BadCheckCustInvItem)
            Me.Panel1.Controls.Add(lbl_CustInfoDesc)
            Me.Panel1.Controls.Add(lbl_CheckItem)
            Me.Panel1.Controls.Add(CustomerChargeRateLabel)
            Me.Panel1.Location = New System.Drawing.Point(3, 19)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(578, 107)
            Me.Panel1.TabIndex = 4
            '
            'tb_BadCheckCustFee
            '
            Me.tb_BadCheckCustFee.Location = New System.Drawing.Point(376, 66)
            Me.tb_BadCheckCustFee.Name = "tb_BadCheckCustFee"
            Me.tb_BadCheckCustFee.Size = New System.Drawing.Size(100, 20)
            Me.tb_BadCheckCustFee.TabIndex = 61
            '
            'cmb_BadCheckItem
            '
            Me.cmb_BadCheckItem.FormattingEnabled = True
            Me.cmb_BadCheckItem.Location = New System.Drawing.Point(376, 3)
            Me.cmb_BadCheckItem.Name = "cmb_BadCheckItem"
            Me.cmb_BadCheckItem.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BadCheckItem.TabIndex = 60
            '
            'cmb_BadCheckCustInvItem
            '
            Me.cmb_BadCheckCustInvItem.FormattingEnabled = True
            Me.cmb_BadCheckCustInvItem.Location = New System.Drawing.Point(376, 39)
            Me.cmb_BadCheckCustInvItem.Name = "cmb_BadCheckCustInvItem"
            Me.cmb_BadCheckCustInvItem.Size = New System.Drawing.Size(187, 21)
            Me.cmb_BadCheckCustInvItem.TabIndex = 59
            '
            'lbl_DateLimits
            '
            Me.lbl_DateLimits.AutoSize = True
            Me.lbl_DateLimits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl_DateLimits.Location = New System.Drawing.Point(3, 129)
            Me.lbl_DateLimits.Name = "lbl_DateLimits"
            Me.lbl_DateLimits.Size = New System.Drawing.Size(88, 16)
            Me.lbl_DateLimits.TabIndex = 7
            Me.lbl_DateLimits.Text = "Date Limits"
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.dtp_CurrClosedDate)
            Me.Panel2.Controls.Add(Me.lbl_CompClosingDate)
            Me.Panel2.Controls.Add(Me.GroupBox1)
            Me.Panel2.Location = New System.Drawing.Point(3, 148)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(578, 107)
            Me.Panel2.TabIndex = 8
            '
            'dtp_CurrClosedDate
            '
            Me.dtp_CurrClosedDate.Enabled = False
            Me.dtp_CurrClosedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtp_CurrClosedDate.Location = New System.Drawing.Point(349, 53)
            Me.dtp_CurrClosedDate.Name = "dtp_CurrClosedDate"
            Me.dtp_CurrClosedDate.Size = New System.Drawing.Size(98, 20)
            Me.dtp_CurrClosedDate.TabIndex = 3
            '
            'lbl_CompClosingDate
            '
            Me.lbl_CompClosingDate.Location = New System.Drawing.Point(273, 8)
            Me.lbl_CompClosingDate.Name = "lbl_CompClosingDate"
            Me.lbl_CompClosingDate.Size = New System.Drawing.Size(282, 42)
            Me.lbl_CompClosingDate.TabIndex = 2
            Me.lbl_CompClosingDate.Text = "Current Quickbooks Company file closing date. This is only adjustable within Quic" & _
        "kbooks by an Administrator." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.nud_InvArrLimit)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.nud_InvAdvLimit)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Location = New System.Drawing.Point(34, 3)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(200, 86)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Invoicing"
            '
            'nud_InvArrLimit
            '
            Me.nud_InvArrLimit.Location = New System.Drawing.Point(146, 54)
            Me.nud_InvArrLimit.Name = "nud_InvArrLimit"
            Me.nud_InvArrLimit.Size = New System.Drawing.Size(42, 20)
            Me.nud_InvArrLimit.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(137, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Max post days in arrearage:"
            '
            'nud_InvAdvLimit
            '
            Me.nud_InvAdvLimit.Location = New System.Drawing.Point(146, 27)
            Me.nud_InvAdvLimit.Name = "nud_InvAdvLimit"
            Me.nud_InvAdvLimit.Size = New System.Drawing.Size(42, 20)
            Me.nud_InvAdvLimit.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 29)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(134, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Max post days in advance:"
            '
            'btn_Save
            '
            Me.btn_Save.Location = New System.Drawing.Point(263, 289)
            Me.btn_Save.Name = "btn_Save"
            Me.btn_Save.Size = New System.Drawing.Size(75, 23)
            Me.btn_Save.TabIndex = 2
            Me.btn_Save.Text = "Save"
            Me.btn_Save.UseVisualStyleBackColor = True
            '
            'AdminDefaults
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(666, 324)
            Me.Controls.Add(Me.btn_Save)
            Me.Controls.Add(Me.FlowLayoutPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "AdminDefaults"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "TrashCash Defaults"
            Me.FlowLayoutPanel.ResumeLayout(False)
            Me.FlowLayoutPanel.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.nud_InvArrLimit, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nud_InvAdvLimit, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cmb_BadCheckItem As System.Windows.Forms.ComboBox
        Friend WithEvents cmb_BadCheckCustInvItem As System.Windows.Forms.ComboBox
        Friend WithEvents hdr_BadCheck As System.Windows.Forms.Label
        Friend WithEvents tb_BadCheckCustFee As CurrencyTextBox
        Friend WithEvents btn_Save As System.Windows.Forms.Button
        Friend WithEvents lbl_DateLimits As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents dtp_CurrClosedDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lbl_CompClosingDate As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents nud_InvArrLimit As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents nud_InvAdvLimit As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace