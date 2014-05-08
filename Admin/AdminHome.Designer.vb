<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminHome
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
        Me.pnl_ServiceTypes = New System.Windows.Forms.Panel()
        Me.btn_ServiceTypeForm = New System.Windows.Forms.Button()
        Me.lbl_ServiceTypeInfo2 = New System.Windows.Forms.Label()
        Me.lbl_ServiceTypeInfo = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl_InvoiceVoid = New System.Windows.Forms.Panel()
        Me.btn_InvVoid = New System.Windows.Forms.Button()
        Me.lbl_InvoiceVoidInfo = New System.Windows.Forms.Label()
        Me.pnl_BounceCheck = New System.Windows.Forms.Panel()
        Me.btn_PayHistory = New System.Windows.Forms.Button()
        Me.lbl_BounceCheckInfo = New System.Windows.Forms.Label()
        Me.pnl_BankSetup = New System.Windows.Forms.Panel()
        Me.btn_BankAdmin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnl_AppDefaults = New System.Windows.Forms.Panel()
        Me.btn_AppDefaults = New System.Windows.Forms.Button()
        Me.lbl_AppDefInfo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnl_ServiceTypes.SuspendLayout()
        Me.FlowLayoutPanel.SuspendLayout()
        Me.pnl_InvoiceVoid.SuspendLayout()
        Me.pnl_BounceCheck.SuspendLayout()
        Me.pnl_BankSetup.SuspendLayout()
        Me.pnl_AppDefaults.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_ServiceTypes
        '
        Me.pnl_ServiceTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_ServiceTypes.Controls.Add(Me.btn_ServiceTypeForm)
        Me.pnl_ServiceTypes.Controls.Add(Me.lbl_ServiceTypeInfo2)
        Me.pnl_ServiceTypes.Controls.Add(Me.lbl_ServiceTypeInfo)
        Me.pnl_ServiceTypes.Location = New System.Drawing.Point(3, 3)
        Me.pnl_ServiceTypes.Name = "pnl_ServiceTypes"
        Me.pnl_ServiceTypes.Size = New System.Drawing.Size(585, 48)
        Me.pnl_ServiceTypes.TabIndex = 1
        '
        'btn_ServiceTypeForm
        '
        Me.btn_ServiceTypeForm.AutoSize = True
        Me.btn_ServiceTypeForm.Location = New System.Drawing.Point(426, 9)
        Me.btn_ServiceTypeForm.Name = "btn_ServiceTypeForm"
        Me.btn_ServiceTypeForm.Size = New System.Drawing.Size(145, 25)
        Me.btn_ServiceTypeForm.TabIndex = 2
        Me.btn_ServiceTypeForm.Text = "Service Type Maintenance"
        Me.btn_ServiceTypeForm.UseVisualStyleBackColor = True
        '
        'lbl_ServiceTypeInfo2
        '
        Me.lbl_ServiceTypeInfo2.AutoSize = True
        Me.lbl_ServiceTypeInfo2.Location = New System.Drawing.Point(3, 21)
        Me.lbl_ServiceTypeInfo2.Name = "lbl_ServiceTypeInfo2"
        Me.lbl_ServiceTypeInfo2.Size = New System.Drawing.Size(306, 13)
        Me.lbl_ServiceTypeInfo2.TabIndex = 1
        Me.lbl_ServiceTypeInfo2.Text = "These are also the various Services used to invoice Customers."
        '
        'lbl_ServiceTypeInfo
        '
        Me.lbl_ServiceTypeInfo.AutoSize = True
        Me.lbl_ServiceTypeInfo.Location = New System.Drawing.Point(3, 8)
        Me.lbl_ServiceTypeInfo.Name = "lbl_ServiceTypeInfo"
        Me.lbl_ServiceTypeInfo.Size = New System.Drawing.Size(320, 13)
        Me.lbl_ServiceTypeInfo.TabIndex = 0
        Me.lbl_ServiceTypeInfo.Text = "This form is used to Add, Modify, or set Quickbooks Items inactive."
        '
        'FlowLayoutPanel
        '
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_ServiceTypes)
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_InvoiceVoid)
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_BounceCheck)
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_BankSetup)
        Me.FlowLayoutPanel.Controls.Add(Me.pnl_AppDefaults)
        Me.FlowLayoutPanel.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
        Me.FlowLayoutPanel.Size = New System.Drawing.Size(594, 324)
        Me.FlowLayoutPanel.TabIndex = 2
        '
        'pnl_InvoiceVoid
        '
        Me.pnl_InvoiceVoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_InvoiceVoid.Controls.Add(Me.btn_InvVoid)
        Me.pnl_InvoiceVoid.Controls.Add(Me.lbl_InvoiceVoidInfo)
        Me.pnl_InvoiceVoid.Location = New System.Drawing.Point(3, 57)
        Me.pnl_InvoiceVoid.Name = "pnl_InvoiceVoid"
        Me.pnl_InvoiceVoid.Size = New System.Drawing.Size(585, 39)
        Me.pnl_InvoiceVoid.TabIndex = 2
        Me.pnl_InvoiceVoid.Visible = False
        '
        'btn_InvVoid
        '
        Me.btn_InvVoid.AutoSize = True
        Me.btn_InvVoid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_InvVoid.Location = New System.Drawing.Point(426, 8)
        Me.btn_InvVoid.Name = "btn_InvVoid"
        Me.btn_InvVoid.Size = New System.Drawing.Size(76, 23)
        Me.btn_InvVoid.TabIndex = 1
        Me.btn_InvVoid.Text = "Invoice Void"
        Me.btn_InvVoid.UseVisualStyleBackColor = True
        '
        'lbl_InvoiceVoidInfo
        '
        Me.lbl_InvoiceVoidInfo.AutoSize = True
        Me.lbl_InvoiceVoidInfo.Location = New System.Drawing.Point(3, 8)
        Me.lbl_InvoiceVoidInfo.Name = "lbl_InvoiceVoidInfo"
        Me.lbl_InvoiceVoidInfo.Size = New System.Drawing.Size(357, 13)
        Me.lbl_InvoiceVoidInfo.TabIndex = 0
        Me.lbl_InvoiceVoidInfo.Text = "This form is used to void Invoices generated ONLY by Recurring Services."
        '
        'pnl_BounceCheck
        '
        Me.pnl_BounceCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_BounceCheck.Controls.Add(Me.btn_PayHistory)
        Me.pnl_BounceCheck.Controls.Add(Me.lbl_BounceCheckInfo)
        Me.pnl_BounceCheck.Location = New System.Drawing.Point(3, 102)
        Me.pnl_BounceCheck.Name = "pnl_BounceCheck"
        Me.pnl_BounceCheck.Size = New System.Drawing.Size(585, 40)
        Me.pnl_BounceCheck.TabIndex = 4
        '
        'btn_PayHistory
        '
        Me.btn_PayHistory.AutoSize = True
        Me.btn_PayHistory.Location = New System.Drawing.Point(426, 8)
        Me.btn_PayHistory.Name = "btn_PayHistory"
        Me.btn_PayHistory.Size = New System.Drawing.Size(93, 23)
        Me.btn_PayHistory.TabIndex = 1
        Me.btn_PayHistory.Text = "Payment History"
        Me.btn_PayHistory.UseVisualStyleBackColor = True
        '
        'lbl_BounceCheckInfo
        '
        Me.lbl_BounceCheckInfo.Location = New System.Drawing.Point(3, 8)
        Me.lbl_BounceCheckInfo.Name = "lbl_BounceCheckInfo"
        Me.lbl_BounceCheckInfo.Size = New System.Drawing.Size(409, 36)
        Me.lbl_BounceCheckInfo.TabIndex = 0
        Me.lbl_BounceCheckInfo.Text = "This form is used to view a Customers payment history and handle Bounced Checks."
        '
        'pnl_BankSetup
        '
        Me.pnl_BankSetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_BankSetup.Controls.Add(Me.btn_BankAdmin)
        Me.pnl_BankSetup.Controls.Add(Me.Label1)
        Me.pnl_BankSetup.Location = New System.Drawing.Point(3, 148)
        Me.pnl_BankSetup.Name = "pnl_BankSetup"
        Me.pnl_BankSetup.Size = New System.Drawing.Size(585, 44)
        Me.pnl_BankSetup.TabIndex = 3
        '
        'btn_BankAdmin
        '
        Me.btn_BankAdmin.AutoSize = True
        Me.btn_BankAdmin.Location = New System.Drawing.Point(426, 8)
        Me.btn_BankAdmin.Name = "btn_BankAdmin"
        Me.btn_BankAdmin.Size = New System.Drawing.Size(107, 23)
        Me.btn_BankAdmin.TabIndex = 1
        Me.btn_BankAdmin.Text = "Bank Maintenance"
        Me.btn_BankAdmin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This form is used to setup the Banks used for Bounced Check handling."
        '
        'pnl_AppDefaults
        '
        Me.pnl_AppDefaults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_AppDefaults.Controls.Add(Me.btn_AppDefaults)
        Me.pnl_AppDefaults.Controls.Add(Me.lbl_AppDefInfo)
        Me.pnl_AppDefaults.Location = New System.Drawing.Point(3, 198)
        Me.pnl_AppDefaults.Name = "pnl_AppDefaults"
        Me.pnl_AppDefaults.Size = New System.Drawing.Size(585, 44)
        Me.pnl_AppDefaults.TabIndex = 5
        '
        'btn_AppDefaults
        '
        Me.btn_AppDefaults.AutoSize = True
        Me.btn_AppDefaults.Location = New System.Drawing.Point(426, 8)
        Me.btn_AppDefaults.Name = "btn_AppDefaults"
        Me.btn_AppDefaults.Size = New System.Drawing.Size(111, 23)
        Me.btn_AppDefaults.TabIndex = 1
        Me.btn_AppDefaults.Text = "TrashCash Defaults"
        Me.btn_AppDefaults.UseVisualStyleBackColor = True
        '
        'lbl_AppDefInfo
        '
        Me.lbl_AppDefInfo.AutoSize = True
        Me.lbl_AppDefInfo.Location = New System.Drawing.Point(3, 8)
        Me.lbl_AppDefInfo.Name = "lbl_AppDefInfo"
        Me.lbl_AppDefInfo.Size = New System.Drawing.Size(202, 13)
        Me.lbl_AppDefInfo.TabIndex = 0
        Me.lbl_AppDefInfo.Text = "Here you can set various default settings."
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 248)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(17, 14)
        Me.Panel1.TabIndex = 6
        '
        'AdminHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 324)
        Me.Controls.Add(Me.FlowLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdminHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Administration"
        Me.pnl_ServiceTypes.ResumeLayout(False)
        Me.pnl_ServiceTypes.PerformLayout()
        Me.FlowLayoutPanel.ResumeLayout(False)
        Me.pnl_InvoiceVoid.ResumeLayout(False)
        Me.pnl_InvoiceVoid.PerformLayout()
        Me.pnl_BounceCheck.ResumeLayout(False)
        Me.pnl_BounceCheck.PerformLayout()
        Me.pnl_BankSetup.ResumeLayout(False)
        Me.pnl_BankSetup.PerformLayout()
        Me.pnl_AppDefaults.ResumeLayout(False)
        Me.pnl_AppDefaults.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_ServiceTypes As System.Windows.Forms.Panel
    Friend WithEvents btn_ServiceTypeForm As System.Windows.Forms.Button
    Friend WithEvents lbl_ServiceTypeInfo2 As System.Windows.Forms.Label
    Friend WithEvents lbl_ServiceTypeInfo As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl_InvoiceVoid As System.Windows.Forms.Panel
    Friend WithEvents btn_InvVoid As System.Windows.Forms.Button
    Friend WithEvents lbl_InvoiceVoidInfo As System.Windows.Forms.Label
    Friend WithEvents pnl_BankSetup As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_BankAdmin As System.Windows.Forms.Button
    Friend WithEvents pnl_BounceCheck As System.Windows.Forms.Panel
    Friend WithEvents btn_PayHistory As System.Windows.Forms.Button
    Friend WithEvents lbl_BounceCheckInfo As System.Windows.Forms.Label
    Friend WithEvents pnl_AppDefaults As System.Windows.Forms.Panel
    Friend WithEvents btn_AppDefaults As System.Windows.Forms.Button
    Friend WithEvents lbl_AppDefInfo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
