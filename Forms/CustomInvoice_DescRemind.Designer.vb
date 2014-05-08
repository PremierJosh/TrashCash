<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomInvoice_DescRemind
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
        Dim lbl_InvDescCountHeader As System.Windows.Forms.Label
        Dim lbl_RemindTextCharCount As System.Windows.Forms.Label
        Me.tb_InvTotal = New System.Windows.Forms.TextBox()
        Me.lbl_InvTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_PostDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_DueDate = New System.Windows.Forms.DateTimePicker()
        Me.postDateLbl = New System.Windows.Forms.Label()
        Me.grp_InvInfo = New System.Windows.Forms.GroupBox()
        Me.lbl_InvDescHeader = New System.Windows.Forms.Label()
        Me.tb_InvDesc = New System.Windows.Forms.TextBox()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.Ts_M_Customer1 = New TrashCash.ts_M_Customer()
        Me.lbl_InvDescLen = New System.Windows.Forms.Label()
        Me.lbl_ReminderText = New System.Windows.Forms.Label()
        Me.ck_CreateReminder = New System.Windows.Forms.CheckBox()
        Me.pnl_Bot = New System.Windows.Forms.Panel()
        Me.lbl_RemindTextLen = New System.Windows.Forms.Label()
        Me.lbl_RemindText = New System.Windows.Forms.Label()
        Me.dtp_RemindDate = New System.Windows.Forms.DateTimePicker()
        Me.tb_RemindText = New System.Windows.Forms.TextBox()
        Me.lbl_RemindDate = New System.Windows.Forms.Label()
        Me.pnl_BtnBottom = New System.Windows.Forms.Panel()
        Me.btn_Submit = New System.Windows.Forms.Button()
        lbl_InvDescCountHeader = New System.Windows.Forms.Label()
        lbl_RemindTextCharCount = New System.Windows.Forms.Label()
        Me.grp_InvInfo.SuspendLayout()
        Me.pnl_Top.SuspendLayout()
        Me.pnl_Bot.SuspendLayout()
        Me.pnl_BtnBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_InvDescCountHeader
        '
        lbl_InvDescCountHeader.AutoSize = True
        lbl_InvDescCountHeader.Location = New System.Drawing.Point(330, 241)
        lbl_InvDescCountHeader.Name = "lbl_InvDescCountHeader"
        lbl_InvDescCountHeader.Size = New System.Drawing.Size(87, 13)
        lbl_InvDescCountHeader.TabIndex = 77
        lbl_InvDescCountHeader.Text = "Character Count:"
        '
        'lbl_RemindTextCharCount
        '
        lbl_RemindTextCharCount.AutoSize = True
        lbl_RemindTextCharCount.Location = New System.Drawing.Point(330, 146)
        lbl_RemindTextCharCount.Name = "lbl_RemindTextCharCount"
        lbl_RemindTextCharCount.Size = New System.Drawing.Size(87, 13)
        lbl_RemindTextCharCount.TabIndex = 81
        lbl_RemindTextCharCount.Text = "Character Count:"
        '
        'tb_InvTotal
        '
        Me.tb_InvTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_InvTotal.Location = New System.Drawing.Point(7, 19)
        Me.tb_InvTotal.Name = "tb_InvTotal"
        Me.tb_InvTotal.ReadOnly = True
        Me.tb_InvTotal.Size = New System.Drawing.Size(70, 20)
        Me.tb_InvTotal.TabIndex = 1
        Me.tb_InvTotal.TabStop = False
        '
        'lbl_InvTotal
        '
        Me.lbl_InvTotal.AutoSize = True
        Me.lbl_InvTotal.Location = New System.Drawing.Point(8, 42)
        Me.lbl_InvTotal.Name = "lbl_InvTotal"
        Me.lbl_InvTotal.Size = New System.Drawing.Size(69, 13)
        Me.lbl_InvTotal.TabIndex = 2
        Me.lbl_InvTotal.Text = "‌Invoice Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Due Date:"
        '
        'dtp_PostDate
        '
        Me.dtp_PostDate.Enabled = False
        Me.dtp_PostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_PostDate.Location = New System.Drawing.Point(199, 19)
        Me.dtp_PostDate.Name = "dtp_PostDate"
        Me.dtp_PostDate.Size = New System.Drawing.Size(80, 20)
        Me.dtp_PostDate.TabIndex = 71
        Me.dtp_PostDate.TabStop = False
        '
        'dtp_DueDate
        '
        Me.dtp_DueDate.Enabled = False
        Me.dtp_DueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_DueDate.Location = New System.Drawing.Point(199, 45)
        Me.dtp_DueDate.Name = "dtp_DueDate"
        Me.dtp_DueDate.Size = New System.Drawing.Size(80, 20)
        Me.dtp_DueDate.TabIndex = 70
        Me.dtp_DueDate.TabStop = False
        '
        'postDateLbl
        '
        Me.postDateLbl.AutoSize = True
        Me.postDateLbl.Location = New System.Drawing.Point(141, 22)
        Me.postDateLbl.Name = "postDateLbl"
        Me.postDateLbl.Size = New System.Drawing.Size(57, 13)
        Me.postDateLbl.TabIndex = 73
        Me.postDateLbl.Text = "Post Date:"
        '
        'grp_InvInfo
        '
        Me.grp_InvInfo.Controls.Add(Me.dtp_PostDate)
        Me.grp_InvInfo.Controls.Add(Me.Label5)
        Me.grp_InvInfo.Controls.Add(Me.tb_InvTotal)
        Me.grp_InvInfo.Controls.Add(Me.dtp_DueDate)
        Me.grp_InvInfo.Controls.Add(Me.lbl_InvTotal)
        Me.grp_InvInfo.Controls.Add(Me.postDateLbl)
        Me.grp_InvInfo.Location = New System.Drawing.Point(79, 42)
        Me.grp_InvInfo.Name = "grp_InvInfo"
        Me.grp_InvInfo.Size = New System.Drawing.Size(285, 73)
        Me.grp_InvInfo.TabIndex = 74
        Me.grp_InvInfo.TabStop = False
        Me.grp_InvInfo.Text = "Invoice Information"
        '
        'lbl_InvDescHeader
        '
        Me.lbl_InvDescHeader.Location = New System.Drawing.Point(12, 118)
        Me.lbl_InvDescHeader.Name = "lbl_InvDescHeader"
        Me.lbl_InvDescHeader.Size = New System.Drawing.Size(420, 26)
        Me.lbl_InvDescHeader.TabIndex = 75
        Me.lbl_InvDescHeader.Text = "This is the Description that will Print on the Invoice. This is required."
        Me.lbl_InvDescHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tb_InvDesc
        '
        Me.tb_InvDesc.Location = New System.Drawing.Point(2, 147)
        Me.tb_InvDesc.MaxLength = 4000
        Me.tb_InvDesc.Multiline = True
        Me.tb_InvDesc.Name = "tb_InvDesc"
        Me.tb_InvDesc.Size = New System.Drawing.Size(490, 91)
        Me.tb_InvDesc.TabIndex = 0
        '
        'pnl_Top
        '
        Me.pnl_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Top.Controls.Add(Me.Ts_M_Customer1)
        Me.pnl_Top.Controls.Add(Me.lbl_InvDescLen)
        Me.pnl_Top.Controls.Add(lbl_InvDescCountHeader)
        Me.pnl_Top.Controls.Add(Me.grp_InvInfo)
        Me.pnl_Top.Controls.Add(Me.lbl_InvDescHeader)
        Me.pnl_Top.Controls.Add(Me.tb_InvDesc)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(3, 3)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(497, 261)
        Me.pnl_Top.TabIndex = 78
        '
        'Ts_M_Customer1
        '
        Me.Ts_M_Customer1.CurrentCustomer = 0
        Me.Ts_M_Customer1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Ts_M_Customer1.Location = New System.Drawing.Point(0, 0)
        Me.Ts_M_Customer1.Name = "Ts_M_Customer1"
        Me.Ts_M_Customer1.Size = New System.Drawing.Size(495, 25)
        Me.Ts_M_Customer1.TabIndex = 79
        Me.Ts_M_Customer1.Text = "Ts_M_Customer1"
        '
        'lbl_InvDescLen
        '
        Me.lbl_InvDescLen.Location = New System.Drawing.Point(423, 241)
        Me.lbl_InvDescLen.Name = "lbl_InvDescLen"
        Me.lbl_InvDescLen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_InvDescLen.Size = New System.Drawing.Size(69, 14)
        Me.lbl_InvDescLen.TabIndex = 78
        Me.lbl_InvDescLen.Text = "0"
        '
        'lbl_ReminderText
        '
        Me.lbl_ReminderText.Location = New System.Drawing.Point(5, 267)
        Me.lbl_ReminderText.Name = "lbl_ReminderText"
        Me.lbl_ReminderText.Size = New System.Drawing.Size(438, 33)
        Me.lbl_ReminderText.TabIndex = 79
        Me.lbl_ReminderText.Text = "If you would like to create a Reminder for this Custom Invoice, you can set that " & _
    "up below. Reminders will be viewable on the Calendar as well as printable for Re" & _
    "ports."
        Me.lbl_ReminderText.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ck_CreateReminder
        '
        Me.ck_CreateReminder.AutoSize = True
        Me.ck_CreateReminder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_CreateReminder.Location = New System.Drawing.Point(151, 297)
        Me.ck_CreateReminder.Name = "ck_CreateReminder"
        Me.ck_CreateReminder.Size = New System.Drawing.Size(120, 17)
        Me.ck_CreateReminder.TabIndex = 80
        Me.ck_CreateReminder.Text = "Create Reminder"
        Me.ck_CreateReminder.UseVisualStyleBackColor = True
        '
        'pnl_Bot
        '
        Me.pnl_Bot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Bot.Controls.Add(Me.lbl_RemindTextLen)
        Me.pnl_Bot.Controls.Add(lbl_RemindTextCharCount)
        Me.pnl_Bot.Controls.Add(Me.lbl_RemindText)
        Me.pnl_Bot.Controls.Add(Me.dtp_RemindDate)
        Me.pnl_Bot.Controls.Add(Me.tb_RemindText)
        Me.pnl_Bot.Controls.Add(Me.lbl_RemindDate)
        Me.pnl_Bot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Bot.Location = New System.Drawing.Point(3, 320)
        Me.pnl_Bot.Name = "pnl_Bot"
        Me.pnl_Bot.Padding = New System.Windows.Forms.Padding(3)
        Me.pnl_Bot.Size = New System.Drawing.Size(497, 164)
        Me.pnl_Bot.TabIndex = 81
        Me.pnl_Bot.Visible = False
        '
        'lbl_RemindTextLen
        '
        Me.lbl_RemindTextLen.Location = New System.Drawing.Point(423, 146)
        Me.lbl_RemindTextLen.Name = "lbl_RemindTextLen"
        Me.lbl_RemindTextLen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_RemindTextLen.Size = New System.Drawing.Size(69, 14)
        Me.lbl_RemindTextLen.TabIndex = 82
        Me.lbl_RemindTextLen.Text = "0"
        '
        'lbl_RemindText
        '
        Me.lbl_RemindText.Location = New System.Drawing.Point(12, 36)
        Me.lbl_RemindText.Name = "lbl_RemindText"
        Me.lbl_RemindText.Size = New System.Drawing.Size(420, 15)
        Me.lbl_RemindText.TabIndex = 79
        Me.lbl_RemindText.Text = "This is what will print on Reports. By default, it is the same text entered above" & _
    "."
        Me.lbl_RemindText.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'dtp_RemindDate
        '
        Me.dtp_RemindDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_RemindDate.Location = New System.Drawing.Point(217, 9)
        Me.dtp_RemindDate.Name = "dtp_RemindDate"
        Me.dtp_RemindDate.Size = New System.Drawing.Size(80, 20)
        Me.dtp_RemindDate.TabIndex = 74
        '
        'tb_RemindText
        '
        Me.tb_RemindText.Location = New System.Drawing.Point(0, 54)
        Me.tb_RemindText.MaxLength = 4000
        Me.tb_RemindText.Multiline = True
        Me.tb_RemindText.Name = "tb_RemindText"
        Me.tb_RemindText.Size = New System.Drawing.Size(492, 91)
        Me.tb_RemindText.TabIndex = 80
        '
        'lbl_RemindDate
        '
        Me.lbl_RemindDate.AutoSize = True
        Me.lbl_RemindDate.Location = New System.Drawing.Point(130, 12)
        Me.lbl_RemindDate.Name = "lbl_RemindDate"
        Me.lbl_RemindDate.Size = New System.Drawing.Size(81, 13)
        Me.lbl_RemindDate.TabIndex = 75
        Me.lbl_RemindDate.Text = "Reminder Date:"
        '
        'pnl_BtnBottom
        '
        Me.pnl_BtnBottom.Controls.Add(Me.btn_Submit)
        Me.pnl_BtnBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_BtnBottom.Location = New System.Drawing.Point(3, 484)
        Me.pnl_BtnBottom.Name = "pnl_BtnBottom"
        Me.pnl_BtnBottom.Size = New System.Drawing.Size(497, 38)
        Me.pnl_BtnBottom.TabIndex = 82
        '
        'btn_Submit
        '
        Me.btn_Submit.Location = New System.Drawing.Point(183, 6)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
        Me.btn_Submit.TabIndex = 0
        Me.btn_Submit.Text = "Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'CustomInvoice_DescRemind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 525)
        Me.Controls.Add(Me.pnl_Bot)
        Me.Controls.Add(Me.ck_CreateReminder)
        Me.Controls.Add(Me.lbl_ReminderText)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.pnl_BtnBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomInvoice_DescRemind"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Description & Reminder"
        Me.grp_InvInfo.ResumeLayout(False)
        Me.grp_InvInfo.PerformLayout()
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        Me.pnl_Bot.ResumeLayout(False)
        Me.pnl_Bot.PerformLayout()
        Me.pnl_BtnBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_InvTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_InvTotal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_PostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_DueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents postDateLbl As System.Windows.Forms.Label
    Friend WithEvents grp_InvInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_InvDescHeader As System.Windows.Forms.Label
    Friend WithEvents tb_InvDesc As System.Windows.Forms.TextBox
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents lbl_InvDescLen As System.Windows.Forms.Label
    Friend WithEvents lbl_ReminderText As System.Windows.Forms.Label
    Friend WithEvents ck_CreateReminder As System.Windows.Forms.CheckBox
    Friend WithEvents pnl_Bot As System.Windows.Forms.Panel
    Friend WithEvents lbl_RemindTextLen As System.Windows.Forms.Label
    Friend WithEvents lbl_RemindText As System.Windows.Forms.Label
    Friend WithEvents dtp_RemindDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_RemindText As System.Windows.Forms.TextBox
    Friend WithEvents lbl_RemindDate As System.Windows.Forms.Label
    Friend WithEvents pnl_BtnBottom As System.Windows.Forms.Panel
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
    Friend WithEvents Ts_M_Customer1 As TrashCash.ts_M_Customer
End Class
