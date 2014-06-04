Imports TrashCash.Classes

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_PaymentDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_PaymentDetails))
        Me.btn_AddPayment = New System.Windows.Forms.Button()
        Me.grp_PayInfo = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_RefNumber = New System.Windows.Forms.Label()
        Me.tb_RefNum = New System.Windows.Forms.TextBox()
        Me.lbl_DateOnCheck = New System.Windows.Forms.Label()
        Me.dtp_DateOnCheck = New System.Windows.Forms.DateTimePicker()
        Me.ck_Override = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtp_Override = New System.Windows.Forms.DateTimePicker()
        Me.tb_Amount = New CurrencyTextBox()
        Me.grp_PayInfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_AddPayment
        '
        Me.btn_AddPayment.Location = New System.Drawing.Point(9, 165)
        Me.btn_AddPayment.Name = "btn_AddPayment"
        Me.btn_AddPayment.Size = New System.Drawing.Size(187, 23)
        Me.btn_AddPayment.TabIndex = 6
        Me.btn_AddPayment.Text = "Add Payment"
        Me.btn_AddPayment.UseVisualStyleBackColor = True
        '
        'grp_PayInfo
        '
        Me.grp_PayInfo.Location = New System.Drawing.Point(12, 9)
        Me.grp_PayInfo.Name = "grp_PayInfo"
        Me.grp_PayInfo.Size = New System.Drawing.Size(187, 45)
        Me.grp_PayInfo.TabIndex = 98
        Me.grp_PayInfo.TabStop = False
        Me.grp_PayInfo.Text = "Payment Method"
        '
       
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Amount:"
        '
        'lbl_RefNumber
        '
        Me.lbl_RefNumber.AutoSize = True
        Me.lbl_RefNumber.Location = New System.Drawing.Point(11, 86)
        Me.lbl_RefNumber.Name = "lbl_RefNumber"
        Me.lbl_RefNumber.Size = New System.Drawing.Size(70, 13)
        Me.lbl_RefNumber.TabIndex = 103
        Me.lbl_RefNumber.Text = "Reference #:"
        Me.lbl_RefNumber.Visible = False
        '
        'tb_RefNum
        '
        Me.tb_RefNum.Location = New System.Drawing.Point(84, 83)
        Me.tb_RefNum.Name = "tb_RefNum"
        Me.tb_RefNum.Size = New System.Drawing.Size(100, 20)
        Me.tb_RefNum.TabIndex = 2
        Me.tb_RefNum.TabStop = False
        Me.tb_RefNum.Visible = False
        '
        'lbl_DateOnCheck
        '
        Me.lbl_DateOnCheck.AutoSize = True
        Me.lbl_DateOnCheck.Location = New System.Drawing.Point(13, 113)
        Me.lbl_DateOnCheck.Name = "lbl_DateOnCheck"
        Me.lbl_DateOnCheck.Size = New System.Drawing.Size(81, 13)
        Me.lbl_DateOnCheck.TabIndex = 105
        Me.lbl_DateOnCheck.Text = "Date on check:"
        Me.lbl_DateOnCheck.Visible = False
        '
        'dtp_DateOnCheck
        '
        Me.dtp_DateOnCheck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_DateOnCheck.Location = New System.Drawing.Point(100, 109)
        Me.dtp_DateOnCheck.Name = "dtp_DateOnCheck"
        Me.dtp_DateOnCheck.Size = New System.Drawing.Size(84, 20)
        Me.dtp_DateOnCheck.TabIndex = 3
        Me.dtp_DateOnCheck.Visible = False
        '
        'ck_Override
        '
        Me.ck_Override.AutoSize = True
        Me.ck_Override.Location = New System.Drawing.Point(18, 142)
        Me.ck_Override.Name = "ck_Override"
        Me.ck_Override.Size = New System.Drawing.Size(63, 17)
        Me.ck_Override.TabIndex = 4
        Me.ck_Override.Text = "Overide"
        Me.ck_Override.UseVisualStyleBackColor = True
        Me.ck_Override.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtp_Override)
        Me.Panel1.Controls.Add(Me.grp_PayInfo)
        Me.Panel1.Controls.Add(Me.ck_Override)
        Me.Panel1.Controls.Add(Me.btn_AddPayment)
        Me.Panel1.Controls.Add(Me.dtp_DateOnCheck)
        Me.Panel1.Controls.Add(Me.tb_RefNum)
        Me.Panel1.Controls.Add(Me.lbl_DateOnCheck)
        Me.Panel1.Controls.Add(Me.lbl_RefNumber)
        Me.Panel1.Controls.Add(Me.tb_Amount)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(206, 207)
        Me.Panel1.TabIndex = 108
        '
        'dtp_Override
        '
        Me.dtp_Override.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Override.Location = New System.Drawing.Point(100, 135)
        Me.dtp_Override.Name = "dtp_Override"
        Me.dtp_Override.Size = New System.Drawing.Size(84, 20)
        Me.dtp_Override.TabIndex = 5
        Me.dtp_Override.Visible = False
        '
        'tb_Amount
        '
        Me.tb_Amount.Location = New System.Drawing.Point(84, 60)
        Me.tb_Amount.Name = "tb_Amount"
        Me.tb_Amount.Size = New System.Drawing.Size(100, 20)
        Me.tb_Amount.TabIndex = 1
        '
        'UC_PaymentDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UC_PaymentDetails"
        Me.Size = New System.Drawing.Size(206, 207)
        Me.grp_PayInfo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_AddPayment As System.Windows.Forms.Button
    Friend WithEvents grp_PayInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_RefNumber As System.Windows.Forms.Label
    Friend WithEvents tb_RefNum As System.Windows.Forms.TextBox
    Friend WithEvents tb_Amount As CurrencyTextBox
    Friend WithEvents lbl_DateOnCheck As System.Windows.Forms.Label
    Friend WithEvents dtp_DateOnCheck As System.Windows.Forms.DateTimePicker
    Friend WithEvents ck_Override As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtp_Override As System.Windows.Forms.DateTimePicker

End Class
