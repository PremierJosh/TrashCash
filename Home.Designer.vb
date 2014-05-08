<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Me.customersBtn = New System.Windows.Forms.Button()
        Me.paymentsBtn = New System.Windows.Forms.Button()
        Me.invoicingBtn = New System.Windows.Forms.Button()
        Me.testFormBtn = New System.Windows.Forms.Button()
        Me.batchRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.progressLbl = New System.Windows.Forms.Label()
        Me.progressItemLbl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.batchBtn = New System.Windows.Forms.Button()
        Me.autoInvRadioBtn = New System.Windows.Forms.RadioButton()
        Me.custInvRadioBtn = New System.Windows.Forms.RadioButton()
        Me.paymentCountLbl = New System.Windows.Forms.Label()
        Me.paymentRadioBtn = New System.Windows.Forms.RadioButton()
        Me.custInvCountLbl = New System.Windows.Forms.Label()
        Me.autoInvCountLbl = New System.Windows.Forms.Label()
        Me.refreshBtn = New System.Windows.Forms.Button()

        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'customersBtn
        '
        Me.customersBtn.AutoSize = True
        Me.customersBtn.Location = New System.Drawing.Point(234, 110)
        Me.customersBtn.Name = "customersBtn"
        Me.customersBtn.Size = New System.Drawing.Size(66, 23)
        Me.customersBtn.TabIndex = 0
        Me.customersBtn.Text = "Customers"
        Me.customersBtn.UseVisualStyleBackColor = True
        '
        'paymentsBtn
        '
        Me.paymentsBtn.AutoSize = True
        Me.paymentsBtn.Location = New System.Drawing.Point(234, 168)
        Me.paymentsBtn.Name = "paymentsBtn"
        Me.paymentsBtn.Size = New System.Drawing.Size(63, 23)
        Me.paymentsBtn.TabIndex = 2
        Me.paymentsBtn.Text = "Payments"
        Me.paymentsBtn.UseVisualStyleBackColor = True
        '
        'invoicingBtn
        '
        Me.invoicingBtn.AutoSize = True
        Me.invoicingBtn.Location = New System.Drawing.Point(234, 139)
        Me.invoicingBtn.Name = "invoicingBtn"
        Me.invoicingBtn.Size = New System.Drawing.Size(60, 23)
        Me.invoicingBtn.TabIndex = 1
        Me.invoicingBtn.Text = "Invoicing"
        Me.invoicingBtn.UseVisualStyleBackColor = True
        '
        'testFormBtn
        '
        Me.testFormBtn.AutoSize = True
        Me.testFormBtn.Location = New System.Drawing.Point(12, 12)
        Me.testFormBtn.Name = "testFormBtn"
        Me.testFormBtn.Size = New System.Drawing.Size(107, 23)
        Me.testFormBtn.TabIndex = 4
        Me.testFormBtn.TabStop = False
        Me.testFormBtn.Text = "Testing Form"
        Me.testFormBtn.UseVisualStyleBackColor = True
        '
        'batchRefreshTimer
        '
        Me.batchRefreshTimer.Interval = 10000
        '
        'progressBar
        '
        Me.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressBar.Location = New System.Drawing.Point(0, 297)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(393, 23)
        Me.progressBar.TabIndex = 10
        Me.progressBar.Visible = False
        '
        'progressLbl
        '
        Me.progressLbl.AutoSize = True
        Me.progressLbl.Location = New System.Drawing.Point(0, 284)
        Me.progressLbl.Name = "progressLbl"
        Me.progressLbl.Size = New System.Drawing.Size(146, 13)
        Me.progressLbl.TabIndex = 11
        Me.progressLbl.Text = "Payment Batch Progress: 0/0"
        Me.progressLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.progressLbl.Visible = False
        '
        'progressItemLbl
        '
        Me.progressItemLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressItemLbl.Location = New System.Drawing.Point(193, 284)
        Me.progressItemLbl.Name = "progressItemLbl"
        Me.progressItemLbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.progressItemLbl.Size = New System.Drawing.Size(200, 13)
        Me.progressItemLbl.TabIndex = 12
        Me.progressItemLbl.Text = "Progress Item Label Placeholder"
        Me.progressItemLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.progressItemLbl.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.batchBtn)
        Me.GroupBox1.Controls.Add(Me.autoInvRadioBtn)
        Me.GroupBox1.Controls.Add(Me.custInvRadioBtn)
        Me.GroupBox1.Controls.Add(Me.paymentCountLbl)
        Me.GroupBox1.Controls.Add(Me.paymentRadioBtn)
        Me.GroupBox1.Controls.Add(Me.custInvCountLbl)
        Me.GroupBox1.Controls.Add(Me.autoInvCountLbl)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 115)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Prepared Batches"
        '
        'batchBtn
        '
        Me.batchBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.batchBtn.Enabled = False
        Me.batchBtn.Location = New System.Drawing.Point(3, 89)
        Me.batchBtn.Name = "batchBtn"
        Me.batchBtn.Size = New System.Drawing.Size(146, 23)
        Me.batchBtn.TabIndex = 3
        Me.batchBtn.Text = "Start Batch"
        Me.batchBtn.UseVisualStyleBackColor = True
        '
        'autoInvRadioBtn
        '
        Me.autoInvRadioBtn.AutoSize = True
        Me.autoInvRadioBtn.Enabled = False
        Me.autoInvRadioBtn.Location = New System.Drawing.Point(34, 42)
        Me.autoInvRadioBtn.Name = "autoInvRadioBtn"
        Me.autoInvRadioBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.autoInvRadioBtn.Size = New System.Drawing.Size(115, 17)
        Me.autoInvRadioBtn.TabIndex = 15
        Me.autoInvRadioBtn.Text = "Automatic Invoices"
        Me.autoInvRadioBtn.UseVisualStyleBackColor = True
        '
        'custInvRadioBtn
        '
        Me.custInvRadioBtn.AutoSize = True
        Me.custInvRadioBtn.Enabled = False
        Me.custInvRadioBtn.Location = New System.Drawing.Point(34, 19)
        Me.custInvRadioBtn.Name = "custInvRadioBtn"
        Me.custInvRadioBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.custInvRadioBtn.Size = New System.Drawing.Size(103, 17)
        Me.custInvRadioBtn.TabIndex = 14
        Me.custInvRadioBtn.Text = "Custom Invoices"
        Me.custInvRadioBtn.UseVisualStyleBackColor = True
        '
        'paymentCountLbl
        '
        Me.paymentCountLbl.Location = New System.Drawing.Point(11, 67)
        Me.paymentCountLbl.Name = "paymentCountLbl"
        Me.paymentCountLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.paymentCountLbl.Size = New System.Drawing.Size(21, 13)
        Me.paymentCountLbl.TabIndex = 19
        Me.paymentCountLbl.Text = "##"
        Me.paymentCountLbl.Visible = False
        '
        'paymentRadioBtn
        '
        Me.paymentRadioBtn.AutoSize = True
        Me.paymentRadioBtn.Enabled = False
        Me.paymentRadioBtn.Location = New System.Drawing.Point(34, 65)
        Me.paymentRadioBtn.Name = "paymentRadioBtn"
        Me.paymentRadioBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.paymentRadioBtn.Size = New System.Drawing.Size(71, 17)
        Me.paymentRadioBtn.TabIndex = 16
        Me.paymentRadioBtn.Text = "Payments"
        Me.paymentRadioBtn.UseVisualStyleBackColor = True
        '
        'custInvCountLbl
        '
        Me.custInvCountLbl.Location = New System.Drawing.Point(11, 21)
        Me.custInvCountLbl.Name = "custInvCountLbl"
        Me.custInvCountLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.custInvCountLbl.Size = New System.Drawing.Size(21, 13)
        Me.custInvCountLbl.TabIndex = 17
        Me.custInvCountLbl.Text = "##"
        Me.custInvCountLbl.Visible = False
        '
        'autoInvCountLbl
        '
        Me.autoInvCountLbl.Location = New System.Drawing.Point(11, 44)
        Me.autoInvCountLbl.Name = "autoInvCountLbl"
        Me.autoInvCountLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.autoInvCountLbl.Size = New System.Drawing.Size(21, 13)
        Me.autoInvCountLbl.TabIndex = 18
        Me.autoInvCountLbl.Text = "##"
        Me.autoInvCountLbl.Visible = False
        '
        'refreshBtn
        '
        Me.refreshBtn.Location = New System.Drawing.Point(38, 53)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(75, 23)
        Me.refreshBtn.TabIndex = 14
        Me.refreshBtn.TabStop = False
        Me.refreshBtn.Text = "Refresh"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 320)
        Me.Controls.Add(Me.refreshBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.progressItemLbl)
        Me.Controls.Add(Me.progressLbl)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.testFormBtn)
        Me.Controls.Add(Me.invoicingBtn)
        Me.Controls.Add(Me.paymentsBtn)
        Me.Controls.Add(Me.customersBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Home"
        Me.Text = "TrashCash"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents customersBtn As System.Windows.Forms.Button
    Friend WithEvents paymentsBtn As System.Windows.Forms.Button
    Friend WithEvents invoicingBtn As System.Windows.Forms.Button

    Friend WithEvents testFormBtn As System.Windows.Forms.Button
    Friend WithEvents batchRefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents progressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents progressLbl As System.Windows.Forms.Label
    Friend WithEvents progressItemLbl As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents batchBtn As System.Windows.Forms.Button
    Friend WithEvents autoInvRadioBtn As System.Windows.Forms.RadioButton
    Friend WithEvents custInvRadioBtn As System.Windows.Forms.RadioButton
    Friend WithEvents paymentCountLbl As System.Windows.Forms.Label
    Friend WithEvents paymentRadioBtn As System.Windows.Forms.RadioButton
    Friend WithEvents custInvCountLbl As System.Windows.Forms.Label
    Friend WithEvents autoInvCountLbl As System.Windows.Forms.Label
    Friend WithEvents refreshBtn As System.Windows.Forms.Button

End Class
