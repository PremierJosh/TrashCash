<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_InvoiceDetails
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CustomInvoiceLineItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet = New TrashCash.DataSet()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.grp_ItemInfo = New System.Windows.Forms.GroupBox()
        Me.tb_Rate = New TrashCash.Currency_TextBox()
        Me.btn_AddLine = New System.Windows.Forms.Button()
        Me.lbl_Rate = New System.Windows.Forms.Label()
        Me.lbl_Desc = New System.Windows.Forms.Label()
        Me.tb_Desc = New System.Windows.Forms.TextBox()
        Me.pnl_Bot = New System.Windows.Forms.Panel()
        Me.btn_Commit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ck_PrintInv = New System.Windows.Forms.CheckBox()
        Me.dtp_PostDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_DueDate = New System.Windows.Forms.DateTimePicker()
        Me.postDateLbl = New System.Windows.Forms.Label()
        Me.tb_Total = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnl_Right = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg_LineItem = New System.Windows.Forms.DataGridView()
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.CustomInvoiceLineItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Top.SuspendLayout()
        Me.grp_ItemInfo.SuspendLayout()
        Me.pnl_Bot.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnl_Right.SuspendLayout()
        CType(Me.dg_LineItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomInvoiceLineItemsBindingSource
        '
        Me.CustomInvoiceLineItemsBindingSource.DataMember = "CustomInvoice LineItems"
        Me.CustomInvoiceLineItemsBindingSource.DataSource = Me.DataSet
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.grp_ItemInfo)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(629, 76)
        Me.pnl_Top.TabIndex = 85
        '
        'grp_ItemInfo
        '
        Me.grp_ItemInfo.Controls.Add(Me.tb_Rate)
        Me.grp_ItemInfo.Controls.Add(Me.btn_AddLine)
        Me.grp_ItemInfo.Controls.Add(Me.lbl_Rate)
        Me.grp_ItemInfo.Controls.Add(Me.lbl_Desc)
        Me.grp_ItemInfo.Controls.Add(Me.tb_Desc)
        Me.grp_ItemInfo.Location = New System.Drawing.Point(3, 2)
        Me.grp_ItemInfo.Name = "grp_ItemInfo"
        Me.grp_ItemInfo.Size = New System.Drawing.Size(623, 72)
        Me.grp_ItemInfo.TabIndex = 83
        Me.grp_ItemInfo.TabStop = False
        Me.grp_ItemInfo.Text = "Line Item"
        '
        'tb_Rate
        '
        Me.tb_Rate.Location = New System.Drawing.Point(387, 26)
        Me.tb_Rate.Name = "tb_Rate"
        Me.tb_Rate.Size = New System.Drawing.Size(78, 20)
        Me.tb_Rate.TabIndex = 1
        '
        'btn_AddLine
        '
        Me.btn_AddLine.Location = New System.Drawing.Point(508, 26)
        Me.btn_AddLine.Name = "btn_AddLine"
        Me.btn_AddLine.Size = New System.Drawing.Size(75, 23)
        Me.btn_AddLine.TabIndex = 2
        Me.btn_AddLine.Text = "Add Line"
        Me.btn_AddLine.UseVisualStyleBackColor = True
        '
        'lbl_Rate
        '
        Me.lbl_Rate.AutoSize = True
        Me.lbl_Rate.Location = New System.Drawing.Point(398, 11)
        Me.lbl_Rate.Name = "lbl_Rate"
        Me.lbl_Rate.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Rate.TabIndex = 3
        Me.lbl_Rate.Text = "Rate:"
        '
        'lbl_Desc
        '
        Me.lbl_Desc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Desc.Location = New System.Drawing.Point(6, 9)
        Me.lbl_Desc.Name = "lbl_Desc"
        Me.lbl_Desc.Size = New System.Drawing.Size(365, 17)
        Me.lbl_Desc.TabIndex = 1
        Me.lbl_Desc.Text = "Description"
        Me.lbl_Desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_Desc
        '
        Me.tb_Desc.Location = New System.Drawing.Point(6, 26)
        Me.tb_Desc.Multiline = True
        Me.tb_Desc.Name = "tb_Desc"
        Me.tb_Desc.Size = New System.Drawing.Size(365, 40)
        Me.tb_Desc.TabIndex = 0
        '
        'pnl_Bot
        '
        Me.pnl_Bot.Controls.Add(Me.btn_Commit)
        Me.pnl_Bot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Bot.Location = New System.Drawing.Point(0, 218)
        Me.pnl_Bot.Name = "pnl_Bot"
        Me.pnl_Bot.Size = New System.Drawing.Size(629, 38)
        Me.pnl_Bot.TabIndex = 86
        '
        'btn_Commit
        '
        Me.btn_Commit.AutoSize = True
        Me.btn_Commit.Location = New System.Drawing.Point(207, 6)
        Me.btn_Commit.Name = "btn_Commit"
        Me.btn_Commit.Size = New System.Drawing.Size(192, 23)
        Me.btn_Commit.TabIndex = 79
        Me.btn_Commit.TabStop = False
        Me.btn_Commit.Text = "Submit Invoice"
        Me.btn_Commit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ck_PrintInv)
        Me.GroupBox1.Controls.Add(Me.dtp_PostDate)
        Me.GroupBox1.Controls.Add(Me.dtp_DueDate)
        Me.GroupBox1.Controls.Add(Me.postDateLbl)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(147, 90)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Due Date:"
        '
        'ck_PrintInv
        '
        Me.ck_PrintInv.AutoSize = True
        Me.ck_PrintInv.Location = New System.Drawing.Point(31, 65)
        Me.ck_PrintInv.Name = "ck_PrintInv"
        Me.ck_PrintInv.Size = New System.Drawing.Size(85, 17)
        Me.ck_PrintInv.TabIndex = 5
        Me.ck_PrintInv.TabStop = False
        Me.ck_PrintInv.Text = "Print Invoice"
        Me.ck_PrintInv.UseVisualStyleBackColor = True
        '
        'dtp_PostDate
        '
        Me.dtp_PostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_PostDate.Location = New System.Drawing.Point(64, 13)
        Me.dtp_PostDate.Name = "dtp_PostDate"
        Me.dtp_PostDate.Size = New System.Drawing.Size(80, 20)
        Me.dtp_PostDate.TabIndex = 4
        Me.dtp_PostDate.TabStop = False
        '
        'dtp_DueDate
        '
        Me.dtp_DueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_DueDate.Location = New System.Drawing.Point(64, 39)
        Me.dtp_DueDate.Name = "dtp_DueDate"
        Me.dtp_DueDate.Size = New System.Drawing.Size(80, 20)
        Me.dtp_DueDate.TabIndex = 3
        Me.dtp_DueDate.TabStop = False
        '
        'postDateLbl
        '
        Me.postDateLbl.AutoSize = True
        Me.postDateLbl.Location = New System.Drawing.Point(6, 16)
        Me.postDateLbl.Name = "postDateLbl"
        Me.postDateLbl.Size = New System.Drawing.Size(57, 13)
        Me.postDateLbl.TabIndex = 69
        Me.postDateLbl.Text = "Post Date:"
        '
        'tb_Total
        '
        Me.tb_Total.Location = New System.Drawing.Point(65, 102)
        Me.tb_Total.Name = "tb_Total"
        Me.tb_Total.ReadOnly = True
        Me.tb_Total.Size = New System.Drawing.Size(67, 20)
        Me.tb_Total.TabIndex = 62
        Me.tb_Total.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Total:"
        '
        'pnl_Right
        '
        Me.pnl_Right.Controls.Add(Me.GroupBox1)
        Me.pnl_Right.Controls.Add(Me.tb_Total)
        Me.pnl_Right.Controls.Add(Me.Label4)
        Me.pnl_Right.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_Right.Location = New System.Drawing.Point(479, 76)
        Me.pnl_Right.Name = "pnl_Right"
        Me.pnl_Right.Size = New System.Drawing.Size(150, 142)
        Me.pnl_Right.TabIndex = 87
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "LineItemRate"
        DataGridViewCellStyle1.Format = "C2"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "LineItemQuantity"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'dg_LineItem
        '
        Me.dg_LineItem.AllowUserToAddRows = False
        Me.dg_LineItem.AllowUserToDeleteRows = False
        Me.dg_LineItem.AllowUserToResizeRows = False
        Me.dg_LineItem.AutoGenerateColumns = False
        Me.dg_LineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_LineItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DescriptionDataGridViewTextBoxColumn, Me.RateDataGridViewTextBoxColumn})
        Me.dg_LineItem.DataSource = Me.CustomInvoiceLineItemsBindingSource
        Me.dg_LineItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_LineItem.Location = New System.Drawing.Point(0, 76)
        Me.dg_LineItem.MultiSelect = False
        Me.dg_LineItem.Name = "dg_LineItem"
        Me.dg_LineItem.ReadOnly = True
        Me.dg_LineItem.RowHeadersVisible = False
        Me.dg_LineItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_LineItem.Size = New System.Drawing.Size(479, 142)
        Me.dg_LineItem.TabIndex = 88
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RateDataGridViewTextBoxColumn
        '
        Me.RateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RateDataGridViewTextBoxColumn.DataPropertyName = "Rate"
        DataGridViewCellStyle2.Format = "C2"
        Me.RateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.RateDataGridViewTextBoxColumn.HeaderText = "Rate"
        Me.RateDataGridViewTextBoxColumn.Name = "RateDataGridViewTextBoxColumn"
        Me.RateDataGridViewTextBoxColumn.ReadOnly = True
        Me.RateDataGridViewTextBoxColumn.Width = 55
        '
        'UC_InvoiceDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dg_LineItem)
        Me.Controls.Add(Me.pnl_Right)
        Me.Controls.Add(Me.pnl_Top)
        Me.Controls.Add(Me.pnl_Bot)
        Me.Name = "UC_InvoiceDetails"
        Me.Size = New System.Drawing.Size(629, 256)
        CType(Me.CustomInvoiceLineItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Top.ResumeLayout(False)
        Me.grp_ItemInfo.ResumeLayout(False)
        Me.grp_ItemInfo.PerformLayout()
        Me.pnl_Bot.ResumeLayout(False)
        Me.pnl_Bot.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnl_Right.ResumeLayout(False)
        Me.pnl_Right.PerformLayout()
        CType(Me.dg_LineItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataSet As TrashCash.DataSet
    Friend WithEvents btn_Commit As System.Windows.Forms.Button
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents pnl_Bot As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ck_PrintInv As System.Windows.Forms.CheckBox
    Friend WithEvents tb_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_PostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_DueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents postDateLbl As System.Windows.Forms.Label
    Friend WithEvents pnl_Right As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grp_ItemInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btn_AddLine As System.Windows.Forms.Button
    Friend WithEvents lbl_Rate As System.Windows.Forms.Label
    Friend WithEvents lbl_Desc As System.Windows.Forms.Label
    Friend WithEvents tb_Desc As System.Windows.Forms.TextBox
    Friend WithEvents CustomInvoiceLineItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dg_LineItem As System.Windows.Forms.DataGridView
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tb_Rate As TrashCash.Currency_TextBox

End Class
