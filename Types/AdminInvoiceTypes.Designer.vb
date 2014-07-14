Imports TrashCash.Invoicing

Namespace Types
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminInvoiceTypes
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
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.CITypeIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QBListIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QBEditSeqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InactiveDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.NAMEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CustomInvoiceLineTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Invoicing = New TrashCash.ds_Invoicing()
            Me.CustomInvoice_LineTypesTableAdapter = New TrashCash.ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter()
            Me.tb_Name = New System.Windows.Forms.TextBox()
            Me.tb_Desc = New System.Windows.Forms.TextBox()
            Me.cmb_QBAccount = New System.Windows.Forms.ComboBox()
            Me.btn_AddItem = New System.Windows.Forms.Button()
            Me.lbl_Name = New System.Windows.Forms.Label()
            Me.lbl_Desc = New System.Windows.Forms.Label()
            Me.lbl_QBaccount = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Invoicing, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridView1
            '
            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.AllowUserToDeleteRows = False
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CITypeIDDataGridViewTextBoxColumn, Me.QBListIDDataGridViewTextBoxColumn, Me.QBEditSeqDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.InactiveDataGridViewCheckBoxColumn, Me.NAMEDataGridViewTextBoxColumn})
            Me.DataGridView1.DataSource = Me.CustomInvoiceLineTypesBindingSource
            Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.DataGridView1.Location = New System.Drawing.Point(0, 120)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.ReadOnly = True
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.Size = New System.Drawing.Size(757, 183)
            Me.DataGridView1.TabIndex = 0
            '
            'CITypeIDDataGridViewTextBoxColumn
            '
            Me.CITypeIDDataGridViewTextBoxColumn.DataPropertyName = "CI_TypeID"
            Me.CITypeIDDataGridViewTextBoxColumn.HeaderText = "CI_TypeID"
            Me.CITypeIDDataGridViewTextBoxColumn.Name = "CITypeIDDataGridViewTextBoxColumn"
            Me.CITypeIDDataGridViewTextBoxColumn.ReadOnly = True
            '
            'QBListIDDataGridViewTextBoxColumn
            '
            Me.QBListIDDataGridViewTextBoxColumn.DataPropertyName = "QBListID"
            Me.QBListIDDataGridViewTextBoxColumn.HeaderText = "QBListID"
            Me.QBListIDDataGridViewTextBoxColumn.Name = "QBListIDDataGridViewTextBoxColumn"
            Me.QBListIDDataGridViewTextBoxColumn.ReadOnly = True
            '
            'QBEditSeqDataGridViewTextBoxColumn
            '
            Me.QBEditSeqDataGridViewTextBoxColumn.DataPropertyName = "QBEditSeq"
            Me.QBEditSeqDataGridViewTextBoxColumn.HeaderText = "QBEditSeq"
            Me.QBEditSeqDataGridViewTextBoxColumn.Name = "QBEditSeqDataGridViewTextBoxColumn"
            Me.QBEditSeqDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DescriptionDataGridViewTextBoxColumn
            '
            Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
            Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
            Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
            Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InactiveDataGridViewCheckBoxColumn
            '
            Me.InactiveDataGridViewCheckBoxColumn.DataPropertyName = "Inactive"
            Me.InactiveDataGridViewCheckBoxColumn.HeaderText = "Inactive"
            Me.InactiveDataGridViewCheckBoxColumn.Name = "InactiveDataGridViewCheckBoxColumn"
            Me.InactiveDataGridViewCheckBoxColumn.ReadOnly = True
            '
            'NAMEDataGridViewTextBoxColumn
            '
            Me.NAMEDataGridViewTextBoxColumn.DataPropertyName = "NAME"
            Me.NAMEDataGridViewTextBoxColumn.HeaderText = "NAME"
            Me.NAMEDataGridViewTextBoxColumn.Name = "NAMEDataGridViewTextBoxColumn"
            Me.NAMEDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CustomInvoiceLineTypesBindingSource
            '
            Me.CustomInvoiceLineTypesBindingSource.DataMember = "CustomInvoice_LineTypes"
            Me.CustomInvoiceLineTypesBindingSource.DataSource = Me.Invoicing
            '
            'Invoicing
            '
            Me.Invoicing.DataSetName = "ds_Invoicing"
            Me.Invoicing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'CustomInvoice_LineTypesTableAdapter
            '
            Me.CustomInvoice_LineTypesTableAdapter.ClearBeforeFill = True
            '
            'tb_Name
            '
            Me.tb_Name.Location = New System.Drawing.Point(31, 59)
            Me.tb_Name.Name = "tb_Name"
            Me.tb_Name.Size = New System.Drawing.Size(100, 20)
            Me.tb_Name.TabIndex = 1
            '
            'tb_Desc
            '
            Me.tb_Desc.Location = New System.Drawing.Point(137, 59)
            Me.tb_Desc.Name = "tb_Desc"
            Me.tb_Desc.Size = New System.Drawing.Size(351, 20)
            Me.tb_Desc.TabIndex = 3
            '
            'cmb_QBAccount
            '
            Me.cmb_QBAccount.FormattingEnabled = True
            Me.cmb_QBAccount.Location = New System.Drawing.Point(494, 59)
            Me.cmb_QBAccount.Name = "cmb_QBAccount"
            Me.cmb_QBAccount.Size = New System.Drawing.Size(154, 21)
            Me.cmb_QBAccount.TabIndex = 4
            '
            'btn_AddItem
            '
            Me.btn_AddItem.Location = New System.Drawing.Point(654, 59)
            Me.btn_AddItem.Name = "btn_AddItem"
            Me.btn_AddItem.Size = New System.Drawing.Size(75, 23)
            Me.btn_AddItem.TabIndex = 5
            Me.btn_AddItem.Text = "Add Item"
            Me.btn_AddItem.UseVisualStyleBackColor = True
            '
            'lbl_Name
            '
            Me.lbl_Name.AutoSize = True
            Me.lbl_Name.Location = New System.Drawing.Point(28, 43)
            Me.lbl_Name.Name = "lbl_Name"
            Me.lbl_Name.Size = New System.Drawing.Size(62, 13)
            Me.lbl_Name.TabIndex = 6
            Me.lbl_Name.Text = "Type Name"
            '
            'lbl_Desc
            '
            Me.lbl_Desc.AutoSize = True
            Me.lbl_Desc.Location = New System.Drawing.Point(137, 43)
            Me.lbl_Desc.Name = "lbl_Desc"
            Me.lbl_Desc.Size = New System.Drawing.Size(60, 13)
            Me.lbl_Desc.TabIndex = 7
            Me.lbl_Desc.Text = "Description"
            '
            'lbl_QBaccount
            '
            Me.lbl_QBaccount.AutoSize = True
            Me.lbl_QBaccount.Location = New System.Drawing.Point(491, 43)
            Me.lbl_QBaccount.Name = "lbl_QBaccount"
            Me.lbl_QBaccount.Size = New System.Drawing.Size(107, 13)
            Me.lbl_QBaccount.TabIndex = 8
            Me.lbl_QBaccount.Text = "Quickbooks Account"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(123, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(506, 13)
            Me.Label1.TabIndex = 9
            Me.Label1.Text = "Here you can add custom invoice types to Quickbooks and make them available to yo" & _
        "u inside TrashCash."
            '
            'AdminInvoiceTypes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(757, 303)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lbl_QBaccount)
            Me.Controls.Add(Me.lbl_Desc)
            Me.Controls.Add(Me.lbl_Name)
            Me.Controls.Add(Me.btn_AddItem)
            Me.Controls.Add(Me.cmb_QBAccount)
            Me.Controls.Add(Me.tb_Desc)
            Me.Controls.Add(Me.tb_Name)
            Me.Controls.Add(Me.DataGridView1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AdminInvoiceTypes"
            Me.Text = "Invoice Types"
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CustomInvoiceLineTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Invoicing, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents Invoicing As DS_Invoicing
        Friend WithEvents CustomInvoiceLineTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents CustomInvoice_LineTypesTableAdapter As ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter
        Friend WithEvents CITypeIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QBListIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QBEditSeqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InactiveDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents NAMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tb_Name As System.Windows.Forms.TextBox
        Friend WithEvents tb_Desc As System.Windows.Forms.TextBox
        Friend WithEvents cmb_QBAccount As System.Windows.Forms.ComboBox
        Friend WithEvents btn_AddItem As System.Windows.Forms.Button
        Friend WithEvents lbl_Name As System.Windows.Forms.Label
        Friend WithEvents lbl_Desc As System.Windows.Forms.Label
        Friend WithEvents lbl_QBaccount As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace