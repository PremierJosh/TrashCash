Imports TrashCash.Classes

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentsForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Mid = New System.Windows.Forms.Panel()
        Me.pnl_MidLeft = New System.Windows.Forms.Panel()
        Me.UC_PaymentDetails = New TrashCash.UC_PaymentDetails()
        Me.pnl_Grid = New System.Windows.Forms.Panel()
        Me.dg_WorkPay = New System.Windows.Forms.DataGridView()
        Me.CustomerNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentTypeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cm_PayGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkingPaymentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.pnl_GridHeader = New System.Windows.Forms.Panel()
        Me.lbl_RecentPayHeader = New System.Windows.Forms.Label()
        Me.tc_Master = New System.Windows.Forms.TabControl()
        Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
        Me.UC_CustomerNotes = New TrashCash.UC_CustomerNotes()
        Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
        Me.UC_CustomerInfoBoxes = New TrashCash.UC_CustomerInfoBoxes()
        Me.WorkingPaymentsTableAdapter = New TrashCash.DataSetTableAdapters.WorkingPaymentsTableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnl_TopContent = New System.Windows.Forms.Panel()
        Me.CustomerToolstrip1 = New TrashCash.Classes.CustomerToolstrip.CustomerToolstrip()
        Me.pnl_Mid.SuspendLayout()
        Me.pnl_MidLeft.SuspendLayout()
        Me.pnl_Grid.SuspendLayout()
        CType(Me.dg_WorkPay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm_PayGrid.SuspendLayout()
        CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_GridHeader.SuspendLayout()
        Me.tc_Master.SuspendLayout()
        Me.tc_p_CustNotes.SuspendLayout()
        Me.tc_p_CustInfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnl_TopContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Mid
        '
        Me.pnl_Mid.Controls.Add(Me.pnl_MidLeft)
        Me.pnl_Mid.Controls.Add(Me.pnl_Grid)
        Me.pnl_Mid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Mid.Location = New System.Drawing.Point(0, 53)
        Me.pnl_Mid.Name = "pnl_Mid"
        Me.pnl_Mid.Size = New System.Drawing.Size(916, 214)
        Me.pnl_Mid.TabIndex = 1
        '
        'pnl_MidLeft
        '
        Me.pnl_MidLeft.Controls.Add(Me.UC_PaymentDetails)
        Me.pnl_MidLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_MidLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnl_MidLeft.Name = "pnl_MidLeft"
        Me.pnl_MidLeft.Padding = New System.Windows.Forms.Padding(50, 0, 0, 0)
        Me.pnl_MidLeft.Size = New System.Drawing.Size(353, 214)
        Me.pnl_MidLeft.TabIndex = 1
        '
        'UC_PaymentDetails
        '
        Me.UC_PaymentDetails.CurrentCustomer = 0
        Me.UC_PaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_PaymentDetails.Location = New System.Drawing.Point(50, 0)
        Me.UC_PaymentDetails.Name = "UC_PaymentDetails"
        Me.UC_PaymentDetails.Size = New System.Drawing.Size(303, 214)
        Me.UC_PaymentDetails.TabIndex = 2
        '
        'pnl_Grid
        '
        Me.pnl_Grid.Controls.Add(Me.dg_WorkPay)
        Me.pnl_Grid.Controls.Add(Me.pnl_GridHeader)
        Me.pnl_Grid.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Grid.Location = New System.Drawing.Point(422, 0)
        Me.pnl_Grid.Name = "pnl_Grid"
        Me.pnl_Grid.Size = New System.Drawing.Size(494, 214)
        Me.pnl_Grid.TabIndex = 0
        '
        'dg_WorkPay
        '
        Me.dg_WorkPay.AllowUserToAddRows = False
        Me.dg_WorkPay.AllowUserToDeleteRows = False
        Me.dg_WorkPay.AllowUserToResizeRows = False
        Me.dg_WorkPay.AutoGenerateColumns = False
        Me.dg_WorkPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_WorkPay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNumberDataGridViewTextBoxColumn, Me.CustomerFullNameDataGridViewTextBoxColumn, Me.WorkingPaymentsAmountDataGridViewTextBoxColumn, Me.PaymentTypeNameDataGridViewTextBoxColumn, Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn})
        Me.dg_WorkPay.ContextMenuStrip = Me.cm_PayGrid
        Me.dg_WorkPay.DataSource = Me.WorkingPaymentsBindingSource
        Me.dg_WorkPay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_WorkPay.Location = New System.Drawing.Point(0, 29)
        Me.dg_WorkPay.MultiSelect = False
        Me.dg_WorkPay.Name = "dg_WorkPay"
        Me.dg_WorkPay.ReadOnly = True
        Me.dg_WorkPay.RowHeadersVisible = False
        Me.dg_WorkPay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_WorkPay.ShowCellToolTips = False
        Me.dg_WorkPay.Size = New System.Drawing.Size(494, 185)
        Me.dg_WorkPay.TabIndex = 102
        '
        'CustomerNumberDataGridViewTextBoxColumn
        '
        Me.CustomerNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CustomerNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerNumber"
        Me.CustomerNumberDataGridViewTextBoxColumn.HeaderText = "Customer #"
        Me.CustomerNumberDataGridViewTextBoxColumn.Name = "CustomerNumberDataGridViewTextBoxColumn"
        Me.CustomerNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerNumberDataGridViewTextBoxColumn.Width = 86
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WorkingPaymentsAmountDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsAmount"
        DataGridViewCellStyle1.Format = "C2"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Name = "WorkingPaymentsAmountDataGridViewTextBoxColumn"
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.WorkingPaymentsAmountDataGridViewTextBoxColumn.Width = 68
        '
        'PaymentTypeNameDataGridViewTextBoxColumn
        '
        Me.PaymentTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PaymentTypeNameDataGridViewTextBoxColumn.DataPropertyName = "PaymentTypeName"
        Me.PaymentTypeNameDataGridViewTextBoxColumn.HeaderText = "Method"
        Me.PaymentTypeNameDataGridViewTextBoxColumn.Name = "PaymentTypeNameDataGridViewTextBoxColumn"
        Me.PaymentTypeNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaymentTypeNameDataGridViewTextBoxColumn.Width = 68
        '
        'WorkingPaymentsCheckNumDataGridViewTextBoxColumn
        '
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.DataPropertyName = "WorkingPaymentsCheckNum"
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.HeaderText = "Ref #"
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.Name = "WorkingPaymentsCheckNumDataGridViewTextBoxColumn"
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.ReadOnly = True
        Me.WorkingPaymentsCheckNumDataGridViewTextBoxColumn.Width = 59
        '
        'cm_PayGrid
        '
        Me.cm_PayGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.cm_PayGrid.Name = "cm_PayGrid"
        Me.cm_PayGrid.Size = New System.Drawing.Size(205, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete Selected Payment"
        '
        'WorkingPaymentsBindingSource
        '
        Me.WorkingPaymentsBindingSource.DataMember = "WorkingPayments"
        Me.WorkingPaymentsBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnl_GridHeader
        '
        Me.pnl_GridHeader.Controls.Add(Me.lbl_RecentPayHeader)
        Me.pnl_GridHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_GridHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnl_GridHeader.Name = "pnl_GridHeader"
        Me.pnl_GridHeader.Size = New System.Drawing.Size(494, 29)
        Me.pnl_GridHeader.TabIndex = 0
        '
        'lbl_RecentPayHeader
        '
        Me.lbl_RecentPayHeader.BackColor = System.Drawing.Color.Transparent
        Me.lbl_RecentPayHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_RecentPayHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RecentPayHeader.Location = New System.Drawing.Point(0, 0)
        Me.lbl_RecentPayHeader.Name = "lbl_RecentPayHeader"
        Me.lbl_RecentPayHeader.Size = New System.Drawing.Size(494, 29)
        Me.lbl_RecentPayHeader.TabIndex = 101
        Me.lbl_RecentPayHeader.Text = "Recently Added Payments"
        Me.lbl_RecentPayHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tc_Master
        '
        Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
        Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
        Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tc_Master.Location = New System.Drawing.Point(0, 267)
        Me.tc_Master.Name = "tc_Master"
        Me.tc_Master.SelectedIndex = 0
        Me.tc_Master.Size = New System.Drawing.Size(916, 205)
        Me.tc_Master.TabIndex = 95
        '
        'tc_p_CustNotes
        '
        Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
        Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
        Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustNotes.Size = New System.Drawing.Size(908, 179)
        Me.tc_p_CustNotes.TabIndex = 3
        Me.tc_p_CustNotes.Text = "Customer Notes"
        '
        'UC_CustomerNotes
        '
        Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
        Me.UC_CustomerNotes.Size = New System.Drawing.Size(902, 173)
        Me.UC_CustomerNotes.TabIndex = 0
        '
        'tc_p_CustInfo
        '
        Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
        Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
        Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustInfo.Size = New System.Drawing.Size(908, 179)
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
        Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(902, 173)
        Me.UC_CustomerInfoBoxes.TabIndex = 0
        '
        'WorkingPaymentsTableAdapter
        '
        Me.WorkingPaymentsTableAdapter.ClearBeforeFill = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnl_TopContent)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.Panel1.Size = New System.Drawing.Size(916, 53)
        Me.Panel1.TabIndex = 96
        '
        'pnl_TopContent
        '
        Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_TopContent.Controls.Add(Me.CustomerToolstrip1)
        Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
        Me.pnl_TopContent.Name = "pnl_TopContent"
        Me.pnl_TopContent.Size = New System.Drawing.Size(876, 33)
        Me.pnl_TopContent.TabIndex = 2
        '
        'CustomerToolstrip1
        '
        Me.CustomerToolstrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomerToolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.CustomerToolstrip1.Location = New System.Drawing.Point(0, 0)
        Me.CustomerToolstrip1.Name = "CustomerToolstrip1"
        Me.CustomerToolstrip1.Size = New System.Drawing.Size(874, 31)
        Me.CustomerToolstrip1.TabIndex = 0
        Me.CustomerToolstrip1.Text = "CustomerToolstrip1"
        '
        'PaymentsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 472)
        Me.Controls.Add(Me.pnl_Mid)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tc_Master)
        Me.MaximizeBox = False
        Me.Name = "PaymentsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payments"
        Me.pnl_Mid.ResumeLayout(False)
        Me.pnl_MidLeft.ResumeLayout(False)
        Me.pnl_Grid.ResumeLayout(False)
        CType(Me.dg_WorkPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm_PayGrid.ResumeLayout(False)
        CType(Me.WorkingPaymentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_GridHeader.ResumeLayout(False)
        Me.tc_Master.ResumeLayout(False)
        Me.tc_p_CustNotes.ResumeLayout(False)
        Me.tc_p_CustInfo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnl_TopContent.ResumeLayout(False)
        Me.pnl_TopContent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Mid As System.Windows.Forms.Panel
    Friend WithEvents tc_Master As System.Windows.Forms.TabControl
    Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerNotes As TrashCash.UC_CustomerNotes
    Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerInfoBoxes As TrashCash.UC_CustomerInfoBoxes
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents WorkingPaymentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkingPaymentsTableAdapter As TrashCash.DataSetTableAdapters.WorkingPaymentsTableAdapter
    Friend WithEvents pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents dg_WorkPay As System.Windows.Forms.DataGridView
    Friend WithEvents CustomerNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingPaymentsCheckNumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnl_GridHeader As System.Windows.Forms.Panel
    Friend WithEvents lbl_RecentPayHeader As System.Windows.Forms.Label
    Friend WithEvents cm_PayGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
    Friend WithEvents pnl_MidLeft As System.Windows.Forms.Panel
    Friend WithEvents UC_PaymentDetails As TrashCash.UC_PaymentDetails
    Friend WithEvents CustomerToolstrip1 As TrashCash.Classes.CustomerToolstrip.CustomerToolstrip
End Class
