<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrashCashHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrashCashHome))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.btn_CurrentUser = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_SwitchUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ChangePass = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_Spacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_BatchProg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pb_Batching = New System.Windows.Forms.ToolStripProgressBar()
        Me.ts_AppBtns = New System.Windows.Forms.ToolStrip()
        Me.btn_CustTab = New System.Windows.Forms.ToolStripButton()
        Me.btn_Invoicing = New System.Windows.Forms.ToolStripButton()
        Me.btn_Payments = New System.Windows.Forms.ToolStripButton()
        Me.btn_BatchWork = New System.Windows.Forms.ToolStripButton()
        Me.btn_Reports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_Rpt_AllCustomerBalances = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Rpt_PayReceived = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Rpt_DaysEvents = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderOverEvenCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Admin = New System.Windows.Forms.ToolStripButton()
        Me.btn_PendApprovs = New System.Windows.Forms.ToolStripButton()
        Me.RecurringService_PendingApprovalsTableAdapter = New TrashCash.ds_RecurringServiceTableAdapters.RecurringService_PendingApprovalsTableAdapter()
        Me.Batch_RefreshBalance = New System.Windows.Forms.Timer(Me.components)
        Me.tt_AdminItem = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip.SuspendLayout()
        Me.ts_AppBtns.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CurrentUser, Me.lbl_Spacer, Me.lbl_BatchProg, Me.pb_Batching})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 544)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(931, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'btn_CurrentUser
        '
        Me.btn_CurrentUser.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_SwitchUser, Me.btn_ChangePass})
        Me.btn_CurrentUser.Name = "btn_CurrentUser"
        Me.btn_CurrentUser.Size = New System.Drawing.Size(89, 20)
        Me.btn_CurrentUser.Text = "Current User:"
        '
        'btn_SwitchUser
        '
        Me.btn_SwitchUser.Name = "btn_SwitchUser"
        Me.btn_SwitchUser.Size = New System.Drawing.Size(168, 22)
        Me.btn_SwitchUser.Text = "Switch User"
        '
        'btn_ChangePass
        '
        Me.btn_ChangePass.Name = "btn_ChangePass"
        Me.btn_ChangePass.Size = New System.Drawing.Size(168, 22)
        Me.btn_ChangePass.Text = "Change Password"
        '
        'lbl_Spacer
        '
        Me.lbl_Spacer.Name = "lbl_Spacer"
        Me.lbl_Spacer.Size = New System.Drawing.Size(827, 17)
        Me.lbl_Spacer.Spring = True
        Me.lbl_Spacer.Text = " "
        '
        'lbl_BatchProg
        '
        Me.lbl_BatchProg.Name = "lbl_BatchProg"
        Me.lbl_BatchProg.Size = New System.Drawing.Size(35, 17)
        Me.lbl_BatchProg.Text = "100%"
        Me.lbl_BatchProg.Visible = False
        '
        'pb_Batching
        '
        Me.pb_Batching.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pb_Batching.Name = "pb_Batching"
        Me.pb_Batching.Size = New System.Drawing.Size(200, 16)
        Me.pb_Batching.Visible = False
        '
        'ts_AppBtns
        '
        Me.ts_AppBtns.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_AppBtns.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CustTab, Me.btn_Invoicing, Me.btn_Payments, Me.btn_BatchWork, Me.btn_Reports, Me.menu_Admin, Me.btn_PendApprovs})
        Me.ts_AppBtns.Location = New System.Drawing.Point(0, 0)
        Me.ts_AppBtns.Name = "ts_AppBtns"
        Me.ts_AppBtns.Size = New System.Drawing.Size(931, 26)
        Me.ts_AppBtns.TabIndex = 10
        Me.ts_AppBtns.Text = "TsAppBtns"
        '
        'btn_CustTab
        '
        Me.btn_CustTab.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btn_CustTab.Image = Global.TrashCash.My.Resources.Resources.plus_icon
        Me.btn_CustTab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_CustTab.Name = "btn_CustTab"
        Me.btn_CustTab.Size = New System.Drawing.Size(89, 23)
        Me.btn_CustTab.Text = "Customer"
        '
        'btn_Invoicing
        '
        Me.btn_Invoicing.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btn_Invoicing.Image = Global.TrashCash.My.Resources.Resources.invoicingIcon
        Me.btn_Invoicing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Invoicing.Name = "btn_Invoicing"
        Me.btn_Invoicing.Size = New System.Drawing.Size(84, 23)
        Me.btn_Invoicing.Text = "Invoicing"
        '
        'btn_Payments
        '
        Me.btn_Payments.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btn_Payments.Image = Global.TrashCash.My.Resources.Resources.Payments_icon
        Me.btn_Payments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Payments.Name = "btn_Payments"
        Me.btn_Payments.Size = New System.Drawing.Size(89, 23)
        Me.btn_Payments.Text = "Payments"
        '
        'btn_BatchWork
        '
        Me.btn_BatchWork.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_BatchWork.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BatchWork.Image = Global.TrashCash.My.Resources.Resources.batchIcon
        Me.btn_BatchWork.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_BatchWork.Name = "btn_BatchWork"
        Me.btn_BatchWork.Size = New System.Drawing.Size(99, 23)
        Me.btn_BatchWork.Text = "Batch Work"
        '
        'btn_Reports
        '
        Me.btn_Reports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Rpt_AllCustomerBalances, Me.btn_Rpt_PayReceived, Me.btn_Rpt_DaysEvents, Me.UnderOverEvenCustomerToolStripMenuItem})
        Me.btn_Reports.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btn_Reports.Image = Global.TrashCash.My.Resources.Resources.reports
        Me.btn_Reports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Reports.Name = "btn_Reports"
        Me.btn_Reports.Size = New System.Drawing.Size(85, 23)
        Me.btn_Reports.Text = "Reports"
        '
        'btn_Rpt_AllCustomerBalances
        '
        Me.btn_Rpt_AllCustomerBalances.Name = "btn_Rpt_AllCustomerBalances"
        Me.btn_Rpt_AllCustomerBalances.Size = New System.Drawing.Size(255, 24)
        Me.btn_Rpt_AllCustomerBalances.Text = "All Customer Balances"
        '
        'btn_Rpt_PayReceived
        '
        Me.btn_Rpt_PayReceived.Name = "btn_Rpt_PayReceived"
        Me.btn_Rpt_PayReceived.Size = New System.Drawing.Size(255, 24)
        Me.btn_Rpt_PayReceived.Text = "Payments Received "
        '
        'btn_Rpt_DaysEvents
        '
        Me.btn_Rpt_DaysEvents.Name = "btn_Rpt_DaysEvents"
        Me.btn_Rpt_DaysEvents.Size = New System.Drawing.Size(255, 24)
        Me.btn_Rpt_DaysEvents.Text = "Days Events"
        '
        'UnderOverEvenCustomerToolStripMenuItem
        '
        Me.UnderOverEvenCustomerToolStripMenuItem.Name = "UnderOverEvenCustomerToolStripMenuItem"
        Me.UnderOverEvenCustomerToolStripMenuItem.Size = New System.Drawing.Size(255, 24)
        Me.UnderOverEvenCustomerToolStripMenuItem.Text = "Under/Over/Even Customers"
        '
        'menu_Admin
        '
        Me.menu_Admin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.menu_Admin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.menu_Admin.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.menu_Admin.Image = CType(resources.GetObject("menu_Admin.Image"), System.Drawing.Image)
        Me.menu_Admin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menu_Admin.Name = "menu_Admin"
        Me.menu_Admin.Size = New System.Drawing.Size(103, 23)
        Me.menu_Admin.Text = "Administration"
        '
        'btn_PendApprovs
        '
        Me.btn_PendApprovs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_PendApprovs.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_PendApprovs.ForeColor = System.Drawing.Color.OrangeRed
        Me.btn_PendApprovs.Image = CType(resources.GetObject("btn_PendApprovs.Image"), System.Drawing.Image)
        Me.btn_PendApprovs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_PendApprovs.Name = "btn_PendApprovs"
        Me.btn_PendApprovs.Size = New System.Drawing.Size(158, 23)
        Me.btn_PendApprovs.Text = "Pending Approvals: 100"
        Me.btn_PendApprovs.Visible = False
        '
        'RecurringService_PendingApprovalsTableAdapter
        '
        Me.RecurringService_PendingApprovalsTableAdapter.ClearBeforeFill = True
        '
        'Batch_RefreshBalance
        '
        Me.Batch_RefreshBalance.Interval = 10000
        '
        'TrashCashHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 566)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ts_AppBtns)
        Me.IsMdiContainer = True
        Me.Name = "TrashCashHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TrashCash"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ts_AppBtns.ResumeLayout(False)
        Me.ts_AppBtns.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ts_AppBtns As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_Invoicing As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Payments As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_BatchWork As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_CustTab As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Reports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn_Rpt_AllCustomerBalances As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Rpt_PayReceived As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Rpt_DaysEvents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderOverEvenCustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_PendApprovs As System.Windows.Forms.ToolStripButton
    Friend WithEvents RecurringService_PendingApprovalsTableAdapter As TrashCash.ds_RecurringServiceTableAdapters.RecurringService_PendingApprovalsTableAdapter
    Friend WithEvents Batch_RefreshBalance As System.Windows.Forms.Timer
    Friend WithEvents tt_AdminItem As System.Windows.Forms.ToolTip
    Friend WithEvents btn_CurrentUser As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn_SwitchUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_ChangePass As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_Spacer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_BatchProg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pb_Batching As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents menu_Admin As System.Windows.Forms.ToolStripButton

End Class
