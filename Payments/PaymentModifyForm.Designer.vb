<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentModifyForm
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
        Me.lbl_PayType = New System.Windows.Forms.Label()
        Me.cmb_PayTypes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_Amount = New TrashCash.Classes.CurrencyTextBox()
        Me.lbl_RefNumber = New System.Windows.Forms.Label()
        Me.btn_SavePayment = New System.Windows.Forms.Button()
        Me.lbl_DateOnCheck = New System.Windows.Forms.Label()
        Me.dtp_DateOnCheck = New System.Windows.Forms.DateTimePicker()
        Me.tb_RefNum = New System.Windows.Forms.TextBox()
        Me.lbl_CustName = New System.Windows.Forms.Label()
        Me.lbl_WrongCustInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_PayType
        '
        Me.lbl_PayType.AutoSize = True
        Me.lbl_PayType.Location = New System.Drawing.Point(76, 95)
        Me.lbl_PayType.Name = "lbl_PayType"
        Me.lbl_PayType.Size = New System.Drawing.Size(78, 13)
        Me.lbl_PayType.TabIndex = 100
        Me.lbl_PayType.Text = "Payment Type:"
        '
        'cmb_PayTypes
        '
        Me.cmb_PayTypes.DisplayMember = "PaymentTypeName"
        Me.cmb_PayTypes.FormattingEnabled = True
        Me.cmb_PayTypes.Location = New System.Drawing.Point(73, 112)
        Me.cmb_PayTypes.Name = "cmb_PayTypes"
        Me.cmb_PayTypes.Size = New System.Drawing.Size(175, 21)
        Me.cmb_PayTypes.TabIndex = 0
        Me.cmb_PayTypes.ValueMember = "PaymentTypeID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(99, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Amount:"
        '
        'tb_Amount
        '
        Me.tb_Amount.Location = New System.Drawing.Point(148, 139)
        Me.tb_Amount.Name = "tb_Amount"
        Me.tb_Amount.Size = New System.Drawing.Size(100, 20)
        Me.tb_Amount.TabIndex = 1
        '
        'lbl_RefNumber
        '
        Me.lbl_RefNumber.AutoSize = True
        Me.lbl_RefNumber.Location = New System.Drawing.Point(75, 165)
        Me.lbl_RefNumber.Name = "lbl_RefNumber"
        Me.lbl_RefNumber.Size = New System.Drawing.Size(70, 13)
        Me.lbl_RefNumber.TabIndex = 113
        Me.lbl_RefNumber.Text = "Reference #:"
        Me.lbl_RefNumber.Visible = False
        '
        'btn_SavePayment
        '
        Me.btn_SavePayment.Location = New System.Drawing.Point(73, 214)
        Me.btn_SavePayment.Name = "btn_SavePayment"
        Me.btn_SavePayment.Size = New System.Drawing.Size(187, 23)
        Me.btn_SavePayment.TabIndex = 6
        Me.btn_SavePayment.Text = "Save Payment"
        Me.btn_SavePayment.UseVisualStyleBackColor = True
        '
        'lbl_DateOnCheck
        '
        Me.lbl_DateOnCheck.AutoSize = True
        Me.lbl_DateOnCheck.Location = New System.Drawing.Point(79, 191)
        Me.lbl_DateOnCheck.Name = "lbl_DateOnCheck"
        Me.lbl_DateOnCheck.Size = New System.Drawing.Size(81, 13)
        Me.lbl_DateOnCheck.TabIndex = 114
        Me.lbl_DateOnCheck.Text = "Date on check:"
        Me.lbl_DateOnCheck.Visible = False
        '
        'dtp_DateOnCheck
        '
        Me.dtp_DateOnCheck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_DateOnCheck.Location = New System.Drawing.Point(164, 188)
        Me.dtp_DateOnCheck.Name = "dtp_DateOnCheck"
        Me.dtp_DateOnCheck.Size = New System.Drawing.Size(84, 20)
        Me.dtp_DateOnCheck.TabIndex = 3
        Me.dtp_DateOnCheck.Visible = False
        '
        'tb_RefNum
        '
        Me.tb_RefNum.Location = New System.Drawing.Point(148, 162)
        Me.tb_RefNum.Name = "tb_RefNum"
        Me.tb_RefNum.Size = New System.Drawing.Size(100, 20)
        Me.tb_RefNum.TabIndex = 2
        Me.tb_RefNum.Visible = False
        '
        'lbl_CustName
        '
        Me.lbl_CustName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_CustName.Location = New System.Drawing.Point(5, 5)
        Me.lbl_CustName.Name = "lbl_CustName"
        Me.lbl_CustName.Size = New System.Drawing.Size(322, 20)
        Me.lbl_CustName.TabIndex = 115
        Me.lbl_CustName.Text = "Label1"
        Me.lbl_CustName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_WrongCustInfo
        '
        Me.lbl_WrongCustInfo.Location = New System.Drawing.Point(5, 38)
        Me.lbl_WrongCustInfo.Name = "lbl_WrongCustInfo"
        Me.lbl_WrongCustInfo.Size = New System.Drawing.Size(322, 45)
        Me.lbl_WrongCustInfo.TabIndex = 116
        Me.lbl_WrongCustInfo.Text = "If this payment is on the wrong customer, you must delete it and re-add the payme" & _
    "nt under the correct Customer."
        Me.lbl_WrongCustInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PaymentModifyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 262)
        Me.Controls.Add(Me.lbl_WrongCustInfo)
        Me.Controls.Add(Me.lbl_CustName)
        Me.Controls.Add(Me.lbl_PayType)
        Me.Controls.Add(Me.cmb_PayTypes)
        Me.Controls.Add(Me.tb_RefNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_DateOnCheck)
        Me.Controls.Add(Me.tb_Amount)
        Me.Controls.Add(Me.lbl_DateOnCheck)
        Me.Controls.Add(Me.lbl_RefNumber)
        Me.Controls.Add(Me.btn_SavePayment)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PaymentModifyForm"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Payment | Modify"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_PayType As System.Windows.Forms.Label
    Friend WithEvents cmb_PayTypes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_Amount As TrashCash.Classes.CurrencyTextBox
    Friend WithEvents lbl_RefNumber As System.Windows.Forms.Label
    Friend WithEvents btn_SavePayment As System.Windows.Forms.Button
    Friend WithEvents lbl_DateOnCheck As System.Windows.Forms.Label
    Friend WithEvents dtp_DateOnCheck As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CustName As System.Windows.Forms.Label
    Friend WithEvents lbl_WrongCustInfo As System.Windows.Forms.Label
End Class
