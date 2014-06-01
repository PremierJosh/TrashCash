Imports TrashCash.QBStuff
Imports TrashCash.Classes

Namespace Customer

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CustomerForm
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
            Me.tc_Master = New System.Windows.Forms.TabControl()
            Me.tc_p_Notes = New System.Windows.Forms.TabPage()
            Me.UC_CustomerNotes = New TrashCash.UC_CustomerNotes()
            Me.tc_p_RecSrvcs = New System.Windows.Forms.TabPage()
            Me.UC_RecurringService = New TrashCash.UC_RecurringService()
            Me.tc_p_QBItems = New System.Windows.Forms.TabPage()
            Me.UC_Quickbooks = New UC_Quickbooks()
            Me.tc_p_PrepItems = New System.Windows.Forms.TabPage()
            Me.UC_PreparedItems = New TrashCash.UC_PreparedItems()
            Me.pnl_Top = New System.Windows.Forms.Panel()
            Me.pnl_TopContent = New System.Windows.Forms.Panel()
            Me.ts_Top = New System.Windows.Forms.ToolStrip()
            Me.btn_Inv = New System.Windows.Forms.ToolStripButton()
            Me.btn_Payments = New System.Windows.Forms.ToolStripButton()
            Me.btn_NewCust = New System.Windows.Forms.ToolStripButton()
            Me.btn_Credit = New System.Windows.Forms.ToolStripButton()
            Me.UC_CustomerInfoBoxes = New UC_CustomerInfoBoxes()
            Me.CustomerToolstrip1 = New TrashCash.Classes.CustomerToolstrip.CustomerToolstrip()
            Me.tc_Master.SuspendLayout()
            Me.tc_p_Notes.SuspendLayout()
            Me.tc_p_RecSrvcs.SuspendLayout()
            Me.tc_p_QBItems.SuspendLayout()
            Me.tc_p_PrepItems.SuspendLayout()
            Me.pnl_Top.SuspendLayout()
            Me.pnl_TopContent.SuspendLayout()
            Me.ts_Top.SuspendLayout()
            Me.SuspendLayout()
            '
            'tc_Master
            '
            Me.tc_Master.Controls.Add(Me.tc_p_Notes)
            Me.tc_Master.Controls.Add(Me.tc_p_RecSrvcs)
            Me.tc_Master.Controls.Add(Me.tc_p_QBItems)
            Me.tc_Master.Controls.Add(Me.tc_p_PrepItems)
            Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.tc_Master.Location = New System.Drawing.Point(0, 252)
            Me.tc_Master.Name = "tc_Master"
            Me.tc_Master.SelectedIndex = 0
            Me.tc_Master.Size = New System.Drawing.Size(902, 296)
            Me.tc_Master.TabIndex = 11
            '
            'tc_p_Notes
            '
            Me.tc_p_Notes.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_Notes.Controls.Add(Me.UC_CustomerNotes)
            Me.tc_p_Notes.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_Notes.Name = "tc_p_Notes"
            Me.tc_p_Notes.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_Notes.Size = New System.Drawing.Size(894, 270)
            Me.tc_p_Notes.TabIndex = 0
            Me.tc_p_Notes.Text = "Notes"
            '
            'UC_CustomerNotes
            '
            Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
            Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
            Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
            Me.UC_CustomerNotes.Size = New System.Drawing.Size(888, 264)
            Me.UC_CustomerNotes.TabIndex = 0
            '
            'tc_p_RecSrvcs
            '
            Me.tc_p_RecSrvcs.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_RecSrvcs.Controls.Add(Me.UC_RecurringService)
            Me.tc_p_RecSrvcs.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_RecSrvcs.Name = "tc_p_RecSrvcs"
            Me.tc_p_RecSrvcs.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_RecSrvcs.Size = New System.Drawing.Size(894, 270)
            Me.tc_p_RecSrvcs.TabIndex = 1
            Me.tc_p_RecSrvcs.Text = "Recurring Services"
            '
            'UC_RecurringService
            '
            Me.UC_RecurringService.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
            Me.UC_RecurringService.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_RecurringService.Location = New System.Drawing.Point(3, 3)
            Me.UC_RecurringService.Name = "UC_RecurringService"
            Me.UC_RecurringService.Size = New System.Drawing.Size(888, 264)
            Me.UC_RecurringService.TabIndex = 0
            '
            'tc_p_QBItems
            '
            Me.tc_p_QBItems.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_QBItems.Controls.Add(Me.UC_Quickbooks)
            Me.tc_p_QBItems.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_QBItems.Name = "tc_p_QBItems"
            Me.tc_p_QBItems.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_QBItems.Size = New System.Drawing.Size(894, 270)
            Me.tc_p_QBItems.TabIndex = 2
            Me.tc_p_QBItems.Text = "In Quickbooks"
            '
            'UC_Quickbooks
            '
            Me.UC_Quickbooks.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
            Me.UC_Quickbooks.CustomerListID = Nothing
            Me.UC_Quickbooks.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_Quickbooks.Location = New System.Drawing.Point(3, 3)
            Me.UC_Quickbooks.Name = "UC_Quickbooks"
            Me.UC_Quickbooks.Size = New System.Drawing.Size(888, 264)
            Me.UC_Quickbooks.TabIndex = 0
            '
            'tc_p_PrepItems
            '
            Me.tc_p_PrepItems.BackColor = System.Drawing.SystemColors.Control
            Me.tc_p_PrepItems.Controls.Add(Me.UC_PreparedItems)
            Me.tc_p_PrepItems.Location = New System.Drawing.Point(4, 22)
            Me.tc_p_PrepItems.Name = "tc_p_PrepItems"
            Me.tc_p_PrepItems.Padding = New System.Windows.Forms.Padding(3)
            Me.tc_p_PrepItems.Size = New System.Drawing.Size(894, 270)
            Me.tc_p_PrepItems.TabIndex = 3
            Me.tc_p_PrepItems.Text = "Prepared Items"
            '
            'UC_PreparedItems
            '
            Me.UC_PreparedItems.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
            Me.UC_PreparedItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_PreparedItems.Location = New System.Drawing.Point(3, 3)
            Me.UC_PreparedItems.Name = "UC_PreparedItems"
            Me.UC_PreparedItems.Size = New System.Drawing.Size(888, 264)
            Me.UC_PreparedItems.TabIndex = 0
            '
            'pnl_Top
            '
            Me.pnl_Top.Controls.Add(Me.pnl_TopContent)
            Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_Top.Location = New System.Drawing.Point(0, 25)
            Me.pnl_Top.Name = "pnl_Top"
            Me.pnl_Top.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
            Me.pnl_Top.Size = New System.Drawing.Size(902, 53)
            Me.pnl_Top.TabIndex = 0
            '
            'pnl_TopContent
            '
            Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TopContent.Controls.Add(Me.CustomerToolstrip1)
            Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
            Me.pnl_TopContent.Name = "pnl_TopContent"
            Me.pnl_TopContent.Size = New System.Drawing.Size(862, 33)
            Me.pnl_TopContent.TabIndex = 14
            '
            'ts_Top
            '
            Me.ts_Top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ts_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Inv, Me.btn_Payments, Me.btn_NewCust, Me.btn_Credit})
            Me.ts_Top.Location = New System.Drawing.Point(0, 0)
            Me.ts_Top.Name = "ts_Top"
            Me.ts_Top.Size = New System.Drawing.Size(902, 25)
            Me.ts_Top.TabIndex = 0
            Me.ts_Top.Text = "ToolStrip1"
            '
            'btn_Inv
            '
            Me.btn_Inv.Image = Global.TrashCash.My.Resources.Resources.invoicingIcon
            Me.btn_Inv.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_Inv.Name = "btn_Inv"
            Me.btn_Inv.Size = New System.Drawing.Size(102, 22)
            Me.btn_Inv.Text = "Create Invoice"
            '
            'btn_Payments
            '
            Me.btn_Payments.Image = Global.TrashCash.My.Resources.Resources.Payments_icon
            Me.btn_Payments.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_Payments.Name = "btn_Payments"
            Me.btn_Payments.Size = New System.Drawing.Size(117, 22)
            Me.btn_Payments.Text = "Receive Payment"
            '
            'btn_NewCust
            '
            Me.btn_NewCust.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.btn_NewCust.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_NewCust.Image = Global.TrashCash.My.Resources.Resources.iconAddNewCustomer
            Me.btn_NewCust.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_NewCust.Name = "btn_NewCust"
            Me.btn_NewCust.Size = New System.Drawing.Size(110, 22)
            Me.btn_NewCust.Text = "New Customer"
            '
            'btn_Credit
            '
            Me.btn_Credit.Image = Global.TrashCash.My.Resources.Resources.credits
            Me.btn_Credit.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btn_Credit.Name = "btn_Credit"
            Me.btn_Credit.Size = New System.Drawing.Size(59, 22)
            Me.btn_Credit.Text = "Credit"
            '
            'UC_CustomerInfoBoxes
            '
            Me.UC_CustomerInfoBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.UC_CustomerInfoBoxes.CurrentCustomer = 0
            Me.UC_CustomerInfoBoxes.Dock = System.Windows.Forms.DockStyle.Top
            Me.UC_CustomerInfoBoxes.isUpdating = False
            Me.UC_CustomerInfoBoxes.Location = New System.Drawing.Point(0, 78)
            Me.UC_CustomerInfoBoxes.Name = "UC_CustomerInfoBoxes"
            Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(902, 172)
            Me.UC_CustomerInfoBoxes.TabIndex = 9
            '
            'CustomerToolstrip1
            '
            Me.CustomerToolstrip1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CustomerToolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.CustomerToolstrip1.Location = New System.Drawing.Point(0, 0)
            Me.CustomerToolstrip1.Name = "CustomerToolstrip1"
            Me.CustomerToolstrip1.Size = New System.Drawing.Size(860, 31)
            Me.CustomerToolstrip1.TabIndex = 0
            Me.CustomerToolstrip1.Text = "CustomerToolstrip1"
            '
            'CustomerForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(902, 548)
            Me.Controls.Add(Me.tc_Master)
            Me.Controls.Add(Me.UC_CustomerInfoBoxes)
            Me.Controls.Add(Me.pnl_Top)
            Me.Controls.Add(Me.ts_Top)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "CustomerForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Current Customer: Fife Abby - 1000"
            Me.tc_Master.ResumeLayout(False)
            Me.tc_p_Notes.ResumeLayout(False)
            Me.tc_p_RecSrvcs.ResumeLayout(False)
            Me.tc_p_QBItems.ResumeLayout(False)
            Me.tc_p_PrepItems.ResumeLayout(False)
            Me.pnl_Top.ResumeLayout(False)
            Me.pnl_TopContent.ResumeLayout(False)
            Me.pnl_TopContent.PerformLayout()
            Me.ts_Top.ResumeLayout(False)
            Me.ts_Top.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents UC_CustomerInfoBoxes As UC_CustomerInfoBoxes
        Friend WithEvents tc_Master As System.Windows.Forms.TabControl
        Friend WithEvents tc_p_Notes As System.Windows.Forms.TabPage
        Friend WithEvents UC_CustomerNotes As TrashCash.UC_CustomerNotes
        Friend WithEvents tc_p_RecSrvcs As System.Windows.Forms.TabPage
        Friend WithEvents UC_RecurringService As TrashCash.UC_RecurringService
        Friend WithEvents tc_p_PrepItems As System.Windows.Forms.TabPage
        Friend WithEvents UC_PreparedItems As TrashCash.UC_PreparedItems
        Friend WithEvents pnl_Top As System.Windows.Forms.Panel
        Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
        Friend WithEvents ts_Top As System.Windows.Forms.ToolStrip
        Friend WithEvents btn_Inv As System.Windows.Forms.ToolStripButton
        Friend WithEvents btn_Payments As System.Windows.Forms.ToolStripButton
        Friend WithEvents btn_NewCust As System.Windows.Forms.ToolStripButton
        Friend WithEvents tc_p_QBItems As System.Windows.Forms.TabPage
        Friend WithEvents UC_Quickbooks As UC_Quickbooks
        Friend WithEvents btn_Credit As System.Windows.Forms.ToolStripButton
        Friend WithEvents CustomerToolstrip1 As TrashCash.Classes.CustomerToolstrip.CustomerToolstrip
    End Class
End Namespace