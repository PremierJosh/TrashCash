<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoicingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicingForm))
        Me.tc_Master = New System.Windows.Forms.TabControl()
        Me.tc_p_CustInfo = New System.Windows.Forms.TabPage()
        Me.UC_CustomerInfoBoxes = New TrashCash.UC_CustomerInfoBoxes()
        Me.tc_p_CustNotes = New System.Windows.Forms.TabPage()
        Me.UC_CustomerNotes = New TrashCash.UC_CustomerNotes()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_TopLeft = New System.Windows.Forms.Panel()
        Me.CustomerComboBox = New TrashCash.CustomerComboBox()
        Me.ck_ActiveCustOnly = New System.Windows.Forms.CheckBox()
        Me.UC_InvoiceDetails = New TrashCash.UC_InvoiceDetails()
        Me.cm_PrepInv = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cm_i_ModInv = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkingInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.ts_Top = New System.Windows.Forms.ToolStrip()
        Me.btn_DeleteInv = New System.Windows.Forms.ToolStripButton()
        Me.ts_b_CustSearch = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ts_b_SearchNum = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_b_SearchName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_b_SearchAddr = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkingInvoiceTableAdapter = New TrashCash.DataSetTableAdapters.WorkingInvoiceTableAdapter()
        Me.tt_Locked = New System.Windows.Forms.ToolTip(Me.components)
        Me.tc_Master.SuspendLayout()
        Me.tc_p_CustInfo.SuspendLayout()
        Me.tc_p_CustNotes.SuspendLayout()
        Me.pnl_Top.SuspendLayout()
        Me.pnl_TopLeft.SuspendLayout()
        Me.cm_PrepInv.SuspendLayout()
        CType(Me.WorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ts_Top.SuspendLayout()
        Me.SuspendLayout()
        '
        'tc_Master
        '
        Me.tc_Master.Controls.Add(Me.tc_p_CustInfo)
        Me.tc_Master.Controls.Add(Me.tc_p_CustNotes)
        Me.tc_Master.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tc_Master.Location = New System.Drawing.Point(0, 341)
        Me.tc_Master.Name = "tc_Master"
        Me.tc_Master.SelectedIndex = 0
        Me.tc_Master.Size = New System.Drawing.Size(912, 199)
        Me.tc_Master.TabIndex = 94
        '
        'tc_p_CustInfo
        '
        Me.tc_p_CustInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustInfo.Controls.Add(Me.UC_CustomerInfoBoxes)
        Me.tc_p_CustInfo.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustInfo.Name = "tc_p_CustInfo"
        Me.tc_p_CustInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustInfo.Size = New System.Drawing.Size(904, 173)
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
        Me.UC_CustomerInfoBoxes.Size = New System.Drawing.Size(898, 167)
        Me.UC_CustomerInfoBoxes.TabIndex = 0
        '
        'tc_p_CustNotes
        '
        Me.tc_p_CustNotes.BackColor = System.Drawing.SystemColors.Control
        Me.tc_p_CustNotes.Controls.Add(Me.UC_CustomerNotes)
        Me.tc_p_CustNotes.Location = New System.Drawing.Point(4, 22)
        Me.tc_p_CustNotes.Name = "tc_p_CustNotes"
        Me.tc_p_CustNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_p_CustNotes.Size = New System.Drawing.Size(904, 173)
        Me.tc_p_CustNotes.TabIndex = 3
        Me.tc_p_CustNotes.Text = "Customer Notes"
        '
        'UC_CustomerNotes
        '
        Me.UC_CustomerNotes.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_CustomerNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UC_CustomerNotes.Location = New System.Drawing.Point(3, 3)
        Me.UC_CustomerNotes.Name = "UC_CustomerNotes"
        Me.UC_CustomerNotes.Size = New System.Drawing.Size(898, 167)
        Me.UC_CustomerNotes.TabIndex = 0
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.pnl_TopLeft)
        Me.pnl_Top.Controls.Add(Me.ts_Top)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(912, 337)
        Me.pnl_Top.TabIndex = 95
        '
        'pnl_TopLeft
        '
        Me.pnl_TopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_TopLeft.Controls.Add(Me.CustomerComboBox)
        Me.pnl_TopLeft.Controls.Add(Me.ck_ActiveCustOnly)
        Me.pnl_TopLeft.Controls.Add(Me.UC_InvoiceDetails)
        Me.pnl_TopLeft.Location = New System.Drawing.Point(0, 26)
        Me.pnl_TopLeft.Name = "pnl_TopLeft"
        Me.pnl_TopLeft.Size = New System.Drawing.Size(428, 311)
        Me.pnl_TopLeft.TabIndex = 3
        '
        'CustomerComboBox
        '
        Me.CustomerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CustomerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerComboBox.DisplayMember = "CustomerFullName"
        Me.CustomerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CustomerComboBox.FormattingEnabled = True
        Me.CustomerComboBox.Location = New System.Drawing.Point(2, 9)
        Me.CustomerComboBox.Name = "CustomerComboBox"
        Me.CustomerComboBox.Size = New System.Drawing.Size(276, 21)
        Me.CustomerComboBox.TabIndex = 101
        Me.CustomerComboBox.ValueMember = "CustomerNumber"
        '
        'ck_ActiveCustOnly
        '
        Me.ck_ActiveCustOnly.AutoSize = True
        Me.ck_ActiveCustOnly.Checked = True
        Me.ck_ActiveCustOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_ActiveCustOnly.Location = New System.Drawing.Point(284, 12)
        Me.ck_ActiveCustOnly.Name = "ck_ActiveCustOnly"
        Me.ck_ActiveCustOnly.Size = New System.Drawing.Size(132, 17)
        Me.ck_ActiveCustOnly.TabIndex = 100
        Me.ck_ActiveCustOnly.Text = "Active Customers Only"
        Me.ck_ActiveCustOnly.UseVisualStyleBackColor = True
        '
        'UC_InvoiceDetails
        '
        Me.UC_InvoiceDetails.CurrentCustomer = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UC_InvoiceDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UC_InvoiceDetails.Location = New System.Drawing.Point(0, 35)
        Me.UC_InvoiceDetails.Name = "UC_InvoiceDetails"
        Me.UC_InvoiceDetails.Size = New System.Drawing.Size(426, 274)
        Me.UC_InvoiceDetails.TabIndex = 2
        ' Me.UC_InvoiceDetails.WorkingInvoiceID = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'cm_PrepInv
        '
        Me.cm_PrepInv.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cm_i_ModInv})
        Me.cm_PrepInv.Name = "cm_PrepInv"
        Me.cm_PrepInv.Size = New System.Drawing.Size(154, 26)
        '
        'cm_i_ModInv
        '
        Me.cm_i_ModInv.Name = "cm_i_ModInv"
        Me.cm_i_ModInv.Size = New System.Drawing.Size(153, 22)
        Me.cm_i_ModInv.Text = "Modify Invoice"
        '
        'WorkingInvoiceBindingSource
        '
        Me.WorkingInvoiceBindingSource.DataMember = "WorkingInvoice"
        Me.WorkingInvoiceBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ts_Top
        '
        Me.ts_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_DeleteInv, Me.ts_b_CustSearch})
        Me.ts_Top.Location = New System.Drawing.Point(0, 0)
        Me.ts_Top.Name = "ts_Top"
        Me.ts_Top.Size = New System.Drawing.Size(912, 26)
        Me.ts_Top.TabIndex = 4
        Me.ts_Top.Text = "ToolStrip1"
        '
        'btn_DeleteInv
        '
        Me.btn_DeleteInv.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_DeleteInv.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btn_DeleteInv.ForeColor = System.Drawing.Color.Red
        Me.btn_DeleteInv.Image = Global.TrashCash.My.Resources.Resources.remove
        Me.btn_DeleteInv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_DeleteInv.Name = "btn_DeleteInv"
        Me.btn_DeleteInv.Size = New System.Drawing.Size(124, 23)
        Me.btn_DeleteInv.Text = "Delete Invoice"
        Me.btn_DeleteInv.Visible = False
        '
        'ts_b_CustSearch
        '
        Me.ts_b_CustSearch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_b_SearchNum, Me.ts_b_SearchName, Me.ts_b_SearchAddr})
        Me.ts_b_CustSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ts_b_CustSearch.Image = CType(resources.GetObject("ts_b_CustSearch.Image"), System.Drawing.Image)
        Me.ts_b_CustSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_b_CustSearch.Name = "ts_b_CustSearch"
        Me.ts_b_CustSearch.Size = New System.Drawing.Size(142, 23)
        Me.ts_b_CustSearch.Text = "Customer Search"
        '
        'ts_b_SearchNum
        '
        Me.ts_b_SearchNum.Name = "ts_b_SearchNum"
        Me.ts_b_SearchNum.Size = New System.Drawing.Size(128, 24)
        Me.ts_b_SearchNum.Text = "Number"
        '
        'ts_b_SearchName
        '
        Me.ts_b_SearchName.Name = "ts_b_SearchName"
        Me.ts_b_SearchName.Size = New System.Drawing.Size(128, 24)
        Me.ts_b_SearchName.Text = "Name"
        '
        'ts_b_SearchAddr
        '
        Me.ts_b_SearchAddr.Name = "ts_b_SearchAddr"
        Me.ts_b_SearchAddr.Size = New System.Drawing.Size(128, 24)
        Me.ts_b_SearchAddr.Text = "Address"
        '
        'WorkingInvoiceTableAdapter
        '
        Me.WorkingInvoiceTableAdapter.ClearBeforeFill = True
        '
        'tt_Locked
        '
        Me.tt_Locked.AutomaticDelay = 0
        Me.tt_Locked.AutoPopDelay = 0
        Me.tt_Locked.InitialDelay = 0
        Me.tt_Locked.ReshowDelay = 100
        Me.tt_Locked.UseFading = False
        '
        'InvoicingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 540)
        Me.Controls.Add(Me.tc_Master)
        Me.Controls.Add(Me.pnl_Top)
        Me.Name = "InvoicingForm"
        Me.Text = "TrashCash | Invoicing"
        Me.tc_Master.ResumeLayout(False)
        Me.tc_p_CustInfo.ResumeLayout(False)
        Me.tc_p_CustNotes.ResumeLayout(False)
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        Me.pnl_TopLeft.ResumeLayout(False)
        Me.pnl_TopLeft.PerformLayout()
        Me.cm_PrepInv.ResumeLayout(False)
        CType(Me.WorkingInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ts_Top.ResumeLayout(False)
        Me.ts_Top.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tc_Master As System.Windows.Forms.TabControl
    Friend WithEvents tc_p_CustInfo As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerInfoBoxes As TrashCash.UC_CustomerInfoBoxes
    Friend WithEvents tc_p_CustNotes As System.Windows.Forms.TabPage
    Friend WithEvents UC_CustomerNotes As TrashCash.UC_CustomerNotes
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents ck_ActiveCustOnly As System.Windows.Forms.CheckBox
    Friend WithEvents UC_InvoiceDetails As TrashCash.UC_InvoiceDetails
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents WorkingInvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkingInvoiceTableAdapter As TrashCash.DataSetTableAdapters.WorkingInvoiceTableAdapter
    Friend WithEvents cm_PrepInv As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cm_i_ModInv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_TopLeft As System.Windows.Forms.Panel
    Friend WithEvents ts_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_DeleteInv As System.Windows.Forms.ToolStripButton
    Friend WithEvents tt_Locked As System.Windows.Forms.ToolTip
    Friend WithEvents CustomerComboBox As TrashCash.CustomerComboBox
    Friend WithEvents ts_b_CustSearch As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ts_b_SearchNum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts_b_SearchName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts_b_SearchAddr As System.Windows.Forms.ToolStripMenuItem
End Class
