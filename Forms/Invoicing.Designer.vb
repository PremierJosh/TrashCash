<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Invoicing
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
        Me.UC_InvoiceDetails = New TrashCash.UC_InvoiceDetails()
        Me.tc_Master = New System.Windows.Forms.TabControl()
        Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
        Me.UC_CustomerNotes = New TrashCash.UC_CustomerNotes()
        Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
        Me.UC_CustomerInfoBoxes = New TrashCash.UC_CustomerInfoBoxes()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_TopContent = New System.Windows.Forms.Panel()
        Me.Ts_M_Customer = New TrashCash.ts_M_Customer()
        Me.tc_Master.SuspendLayout()
        Me.tc_p_CustNotes.SuspendLayout()
        Me.tc_p_CustInfo.SuspendLayout()
        Me.pnl_Top.SuspendLayout()
        Me.pnl_TopContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'UC_InvoiceDetails
        '
        Me.UC_InvoiceDetails.CurrentCustomer = 0
        Me.UC_InvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_InvoiceDetails.Location = New System.Drawing.Point(0, 53)
        Me.UC_InvoiceDetails.Name = "UC_InvoiceDetails"
        Me.UC_InvoiceDetails.Padding = New System.Windows.Forms.Padding(20)
        Me.UC_InvoiceDetails.Size = New System.Drawing.Size(914, 293)
        Me.UC_InvoiceDetails.TabIndex = 1
        '
        'tc_Master
        '
        Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
        Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
        Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tc_Master.Location = New System.Drawing.Point(0, 346)
        Me.tc_Master.Name = "tc_Master"
        Me.tc_Master.SelectedIndex = 0
        Me.tc_Master.Size = New System.Drawing.Size(914, 204)
        Me.tc_Master.TabIndex = 94
        '
        'tc_p_CustNotes
        '
        Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
        Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
        Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustNotes.Size = New System.Drawing.Size(906, 178)
        Me.tc_p_CustNotes.TabIndex = 3
        Me.tc_p_CustNotes.Text = "Customer Notes"
        '
        'UC_CustomerNotes
        '
        Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
        Me.UC_CustomerNotes.Size = New System.Drawing.Size(900, 172)
        Me.UC_CustomerNotes.TabIndex = 0
        '
        'tc_p_CustInfo
        '
        Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
        Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
        Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustInfo.Size = New System.Drawing.Size(906, 178)
        Me.tc_p_CustInfo.TabIndex = 0
        Me.tc_p_CustInfo.Text = "Customer Information"
        '
        'UC_CustomerInfoBoxes
        '
        Me.UC_CustomerInfoBoxes.CurrentCustomer = 0
        Me.UC_CustomerInfoBoxes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerInfoBoxes.isUpdating = False
        Me.UC_CustomerInfoBoxes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerInfoBoxes.Name = "UC_CustomerInfoBoxes"
        Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(900, 172)
        Me.UC_CustomerInfoBoxes.TabIndex = 0
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.pnl_TopContent)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnl_Top.Size = New System.Drawing.Size(914, 53)
        Me.pnl_Top.TabIndex = 95
        '
        'pnl_TopContent
        '
        Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_TopContent.Controls.Add(Me.Ts_M_Customer)
        Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
        Me.pnl_TopContent.Name = "pnl_TopContent"
        Me.pnl_TopContent.Size = New System.Drawing.Size(874, 33)
        Me.pnl_TopContent.TabIndex = 2
        '
        'Ts_M_Customer
        '
        Me.Ts_M_Customer.CurrentCustomer = 0
        Me.Ts_M_Customer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ts_M_Customer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Ts_M_Customer.Location = New System.Drawing.Point(0, 0)
        Me.Ts_M_Customer.Name = "Ts_M_Customer"
        Me.Ts_M_Customer.Size = New System.Drawing.Size(872, 31)
        Me.Ts_M_Customer.TabIndex = 2
        Me.Ts_M_Customer.Text = "Ts_M_Customer1"
        '
        'Invoicing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 550)
        Me.Controls.Add(Me.UC_InvoiceDetails)
        Me.Controls.Add(Me.tc_Master)
        Me.Controls.Add(Me.pnl_Top)
        Me.Name = "Invoicing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoicing"
        Me.tc_Master.ResumeLayout(False)
        Me.tc_p_CustNotes.ResumeLayout(False)
        Me.tc_p_CustInfo.ResumeLayout(False)
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_TopContent.ResumeLayout(False)
        Me.pnl_TopContent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UC_InvoiceDetails As TrashCash.UC_InvoiceDetails
    Friend WithEvents tc_Master As System.Windows.Forms.TabControl
    Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerNotes As TrashCash.UC_CustomerNotes
    Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerInfoBoxes As TrashCash.UC_CustomerInfoBoxes
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
    Friend WithEvents Ts_M_Customer As TrashCash.ts_M_Customer
End Class
