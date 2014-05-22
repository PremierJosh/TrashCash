Namespace Admin
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdminServiceTypes
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
            Me.dg_Item = New System.Windows.Forms.DataGridView()
            Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceRateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceBillLengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.cm_ServiceEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.EditItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.NewItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ServiceTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ds_Types = New TrashCash.ds_Types()
            Me.ServiceTypesTableAdapter = New TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter()
            Me.lbl_FormInfo = New System.Windows.Forms.Label()
            Me.grp_ServiceEdit = New System.Windows.Forms.GroupBox()
            Me.UC_ServiceTypesDetails1 = New UC_ServiceTypesDetails()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.dg_Item, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cm_ServiceEdit.SuspendLayout()
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ds_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grp_ServiceEdit.SuspendLayout()
            Me.SuspendLayout()
            '
            'dg_Item
            '
            Me.dg_Item.AllowUserToAddRows = False
            Me.dg_Item.AllowUserToDeleteRows = False
            Me.dg_Item.AllowUserToResizeRows = False
            Me.dg_Item.AutoGenerateColumns = False
            Me.dg_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_Item.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceNameDataGridViewTextBoxColumn, Me.ServiceRateDataGridViewTextBoxColumn, Me.ServiceDescriptionDataGridViewTextBoxColumn, Me.ServiceBillLengthDataGridViewTextBoxColumn})
            Me.dg_Item.ContextMenuStrip = Me.cm_ServiceEdit
            Me.dg_Item.DataSource = Me.ServiceTypesBindingSource
            Me.dg_Item.Location = New System.Drawing.Point(12, 87)
            Me.dg_Item.MultiSelect = False
            Me.dg_Item.Name = "dg_Item"
            Me.dg_Item.RowHeadersVisible = False
            Me.dg_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_Item.Size = New System.Drawing.Size(477, 248)
            Me.dg_Item.TabIndex = 0
            '
            'ServiceNameDataGridViewTextBoxColumn
            '
            Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
            Me.ServiceNameDataGridViewTextBoxColumn.HeaderText = "Service Name"
            Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
            '
            'ServiceRateDataGridViewTextBoxColumn
            '
            Me.ServiceRateDataGridViewTextBoxColumn.DataPropertyName = "ServiceRate"
            Me.ServiceRateDataGridViewTextBoxColumn.HeaderText = "Service Rate"
            Me.ServiceRateDataGridViewTextBoxColumn.Name = "ServiceRateDataGridViewTextBoxColumn"
            '
            'ServiceDescriptionDataGridViewTextBoxColumn
            '
            Me.ServiceDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ServiceDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ServiceDescription"
            Me.ServiceDescriptionDataGridViewTextBoxColumn.HeaderText = "Service Description"
            Me.ServiceDescriptionDataGridViewTextBoxColumn.Name = "ServiceDescriptionDataGridViewTextBoxColumn"
            '
            'ServiceBillLengthDataGridViewTextBoxColumn
            '
            Me.ServiceBillLengthDataGridViewTextBoxColumn.DataPropertyName = "ServiceBillLength"
            Me.ServiceBillLengthDataGridViewTextBoxColumn.HeaderText = "Service Bill Length"
            Me.ServiceBillLengthDataGridViewTextBoxColumn.Name = "ServiceBillLengthDataGridViewTextBoxColumn"
            '
            'cm_ServiceEdit
            '
            Me.cm_ServiceEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditItemToolStripMenuItem, Me.NewItemToolStripMenuItem})
            Me.cm_ServiceEdit.Name = "cm_ServiceEdit"
            Me.cm_ServiceEdit.Size = New System.Drawing.Size(126, 48)
            '
            'EditItemToolStripMenuItem
            '
            Me.EditItemToolStripMenuItem.Name = "EditItemToolStripMenuItem"
            Me.EditItemToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
            Me.EditItemToolStripMenuItem.Text = "Edit Item"
            '
            'NewItemToolStripMenuItem
            '
            Me.NewItemToolStripMenuItem.Name = "NewItemToolStripMenuItem"
            Me.NewItemToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
            Me.NewItemToolStripMenuItem.Text = "New Item"
            '
            'ServiceTypesBindingSource
            '
            Me.ServiceTypesBindingSource.DataMember = "ServiceTypes"
            Me.ServiceTypesBindingSource.DataSource = Me.ds_Types
            '
            'DataSet
            '
            Me.ds_Types.DataSetName = "ds_Types"
            Me.ds_Types.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ServiceTypesTableAdapter
            '
            Me.ServiceTypesTableAdapter.ClearBeforeFill = True
            '
            'lbl_FormInfo
            '
            Me.lbl_FormInfo.Location = New System.Drawing.Point(9, 9)
            Me.lbl_FormInfo.Name = "lbl_FormInfo"
            Me.lbl_FormInfo.Size = New System.Drawing.Size(803, 33)
            Me.lbl_FormInfo.TabIndex = 2
            Me.lbl_FormInfo.Text = "This grid represents all Quickbooks Items currently available to be added and use" & _
                                   "d by this program. Any changes made on this screen will change the associated it" & _
                                   "ems in Quickbooks."
            '
            'grp_ServiceEdit
            '
            Me.grp_ServiceEdit.Controls.Add(Me.UC_ServiceTypesDetails1)
            Me.grp_ServiceEdit.Location = New System.Drawing.Point(495, 87)
            Me.grp_ServiceEdit.Name = "grp_ServiceEdit"
            Me.grp_ServiceEdit.Size = New System.Drawing.Size(327, 248)
            Me.grp_ServiceEdit.TabIndex = 4
            Me.grp_ServiceEdit.TabStop = False
            Me.grp_ServiceEdit.Text = "Service Item"
            Me.grp_ServiceEdit.Visible = False
            '
            'UC_ServiceTypesDetails1
            '
            Me.UC_ServiceTypesDetails1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.UC_ServiceTypesDetails1.Location = New System.Drawing.Point(3, 16)
            Me.UC_ServiceTypesDetails1.Name = "UC_ServiceTypesDetails1"
            Me.UC_ServiceTypesDetails1.Size = New System.Drawing.Size(321, 229)
            Me.UC_ServiceTypesDetails1.TabIndex = 0
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "ServiceName"
            Me.DataGridViewTextBoxColumn1.HeaderText = "Service Name"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "ServiceRate"
            Me.DataGridViewTextBoxColumn2.HeaderText = "Service Rate"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "ServiceDescription"
            Me.DataGridViewTextBoxColumn3.HeaderText = "Service Description"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "ServiceBillLength"
            Me.DataGridViewTextBoxColumn4.HeaderText = "Service Bill Length"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "ServiceTypeID"
            Me.DataGridViewTextBoxColumn5.HeaderText = "ServiceTypeID"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "ServiceName"
            Me.DataGridViewTextBoxColumn6.HeaderText = "ServiceName"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "ServiceListID"
            Me.DataGridViewTextBoxColumn7.HeaderText = "ServiceListID"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "ServiceEditSequence"
            Me.DataGridViewTextBoxColumn8.HeaderText = "ServiceEditSequence"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "ServiceRate"
            Me.DataGridViewTextBoxColumn9.HeaderText = "ServiceRate"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "ServiceDescription"
            Me.DataGridViewTextBoxColumn10.HeaderText = "ServiceDescription"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "ServiceBillLength"
            Me.DataGridViewTextBoxColumn11.HeaderText = "ServiceBillLength"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            '
            'ServiceTypes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(832, 347)
            Me.Controls.Add(Me.grp_ServiceEdit)
            Me.Controls.Add(Me.lbl_FormInfo)
            Me.Controls.Add(Me.dg_Item)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ServiceTypes"
            Me.Text = "Item List"
            CType(Me.dg_Item, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cm_ServiceEdit.ResumeLayout(False)
            CType(Me.ServiceTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ds_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grp_ServiceEdit.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dg_Item As System.Windows.Forms.DataGridView
        Friend WithEvents ds_Types As TrashCash.ds_Types
        Friend WithEvents ServiceTypesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ServiceTypesTableAdapter As TrashCash.ds_TypesTableAdapters.ServiceTypesTableAdapter
        Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceRateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceBillLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lbl_FormInfo As System.Windows.Forms.Label
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cm_ServiceEdit As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents EditItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents grp_ServiceEdit As System.Windows.Forms.GroupBox
        Friend WithEvents UC_ServiceTypesDetails1 As UC_ServiceTypesDetails
        Friend WithEvents NewItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    End Class
End Namespace