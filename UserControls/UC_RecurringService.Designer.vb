<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_RecurringService
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.sc_Master = New System.Windows.Forms.SplitContainer()
        Me.dg_RecSrvc = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_NewSrvc = New System.Windows.Forms.Button()
        Me.grp_SrvcState = New System.Windows.Forms.GroupBox()
        Me.rdo_AllSrvc = New System.Windows.Forms.RadioButton()
        Me.rdo_CurrentSrvc = New System.Windows.Forms.RadioButton()
        Me.rdo_EndedSrvc = New System.Windows.Forms.RadioButton()
        Me.dg_Notes = New System.Windows.Forms.DataGridView()
        Me.RecurringServiceIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceRateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaxEndBillingDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceDisplayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Display = New TrashCash.ds_Display()
        Me.ServiceNotesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ServiceNotesTableAdapter = New TrashCash.ds_DisplayTableAdapters.ServiceNotesTableAdapter()
        Me.RecurringService_DisplayTableAdapter = New TrashCash.ds_DisplayTableAdapters.RecurringService_DisplayTableAdapter()
        Me.ServiceNoteTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsertedByUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNoteDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.sc_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sc_Master.Panel1.SuspendLayout()
        Me.sc_Master.Panel2.SuspendLayout()
        Me.sc_Master.SuspendLayout()
        CType(Me.dg_RecSrvc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grp_SrvcState.SuspendLayout()
        CType(Me.dg_Notes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecurringServiceDisplayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServiceNotesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sc_Master
        '
        Me.sc_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sc_Master.Location = New System.Drawing.Point(0, 0)
        Me.sc_Master.Name = "sc_Master"
        Me.sc_Master.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'sc_Master.Panel1
        '
        Me.sc_Master.Panel1.Controls.Add(Me.dg_RecSrvc)
        Me.sc_Master.Panel1.Controls.Add(Me.Panel1)
        '
        'sc_Master.Panel2
        '
        Me.sc_Master.Panel2.Controls.Add(Me.dg_Notes)
        Me.sc_Master.Size = New System.Drawing.Size(900, 296)
        Me.sc_Master.SplitterDistance = 170
        Me.sc_Master.TabIndex = 93
        '
        'dg_RecSrvc
        '
        Me.dg_RecSrvc.AllowUserToAddRows = False
        Me.dg_RecSrvc.AllowUserToDeleteRows = False
        Me.dg_RecSrvc.AllowUserToResizeRows = False
        Me.dg_RecSrvc.AutoGenerateColumns = False
        Me.dg_RecSrvc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_RecSrvc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RecurringServiceIDDataGridViewTextBoxColumn, Me.ServiceNameDataGridViewTextBoxColumn, Me.RecurringServiceRateDataGridViewTextBoxColumn, Me.RecurringServiceQuantityDataGridViewTextBoxColumn, Me.RecurringServiceBillLengthDataGridViewTextBoxColumn, Me.RecurringServiceStartDateDataGridViewTextBoxColumn, Me.RecurringServiceEndDateDataGridViewTextBoxColumn, Me.MaxEndBillingDateDataGridViewTextBoxColumn, Me.ApprovedDataGridViewCheckBoxColumn})
        Me.dg_RecSrvc.DataSource = Me.RecurringServiceDisplayBindingSource
        Me.dg_RecSrvc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_RecSrvc.Location = New System.Drawing.Point(0, 0)
        Me.dg_RecSrvc.MultiSelect = False
        Me.dg_RecSrvc.Name = "dg_RecSrvc"
        Me.dg_RecSrvc.ReadOnly = True
        Me.dg_RecSrvc.RowHeadersVisible = False
        Me.dg_RecSrvc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_RecSrvc.Size = New System.Drawing.Size(804, 170)
        Me.dg_RecSrvc.TabIndex = 55
        Me.dg_RecSrvc.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_NewSrvc)
        Me.Panel1.Controls.Add(Me.grp_SrvcState)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(804, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 170)
        Me.Panel1.TabIndex = 0
        '
        'btn_NewSrvc
        '
        Me.btn_NewSrvc.AutoSize = True
        Me.btn_NewSrvc.Location = New System.Drawing.Point(9, 97)
        Me.btn_NewSrvc.Name = "btn_NewSrvc"
        Me.btn_NewSrvc.Size = New System.Drawing.Size(78, 23)
        Me.btn_NewSrvc.TabIndex = 58
        Me.btn_NewSrvc.Text = "New Service"
        Me.btn_NewSrvc.UseVisualStyleBackColor = True
        '
        'grp_SrvcState
        '
        Me.grp_SrvcState.Controls.Add(Me.rdo_AllSrvc)
        Me.grp_SrvcState.Controls.Add(Me.rdo_CurrentSrvc)
        Me.grp_SrvcState.Controls.Add(Me.rdo_EndedSrvc)
        Me.grp_SrvcState.Location = New System.Drawing.Point(3, 3)
        Me.grp_SrvcState.Name = "grp_SrvcState"
        Me.grp_SrvcState.Size = New System.Drawing.Size(88, 88)
        Me.grp_SrvcState.TabIndex = 57
        Me.grp_SrvcState.TabStop = False
        Me.grp_SrvcState.Text = "Service State"
        '
        'rdo_AllSrvc
        '
        Me.rdo_AllSrvc.AutoSize = True
        Me.rdo_AllSrvc.Location = New System.Drawing.Point(6, 62)
        Me.rdo_AllSrvc.Name = "rdo_AllSrvc"
        Me.rdo_AllSrvc.Size = New System.Drawing.Size(36, 17)
        Me.rdo_AllSrvc.TabIndex = 2
        Me.rdo_AllSrvc.TabStop = True
        Me.rdo_AllSrvc.Text = "All"
        Me.rdo_AllSrvc.UseVisualStyleBackColor = True
        '
        'rdo_CurrentSrvc
        '
        Me.rdo_CurrentSrvc.AutoSize = True
        Me.rdo_CurrentSrvc.Checked = True
        Me.rdo_CurrentSrvc.Location = New System.Drawing.Point(6, 16)
        Me.rdo_CurrentSrvc.Name = "rdo_CurrentSrvc"
        Me.rdo_CurrentSrvc.Size = New System.Drawing.Size(59, 17)
        Me.rdo_CurrentSrvc.TabIndex = 1
        Me.rdo_CurrentSrvc.TabStop = True
        Me.rdo_CurrentSrvc.Text = "Current"
        Me.rdo_CurrentSrvc.UseVisualStyleBackColor = True
        '
        'rdo_EndedSrvc
        '
        Me.rdo_EndedSrvc.AutoSize = True
        Me.rdo_EndedSrvc.Location = New System.Drawing.Point(6, 39)
        Me.rdo_EndedSrvc.Name = "rdo_EndedSrvc"
        Me.rdo_EndedSrvc.Size = New System.Drawing.Size(56, 17)
        Me.rdo_EndedSrvc.TabIndex = 0
        Me.rdo_EndedSrvc.Text = "Ended"
        Me.rdo_EndedSrvc.UseVisualStyleBackColor = True
        '
        'dg_Notes
        '
        Me.dg_Notes.AllowUserToAddRows = False
        Me.dg_Notes.AllowUserToDeleteRows = False
        Me.dg_Notes.AllowUserToResizeRows = False
        Me.dg_Notes.AutoGenerateColumns = False
        Me.dg_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Notes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceNoteTextDataGridViewTextBoxColumn, Me.InsertedByUser, Me.ServiceNoteDateDataGridViewTextBoxColumn})
        Me.dg_Notes.DataSource = Me.ServiceNotesBindingSource
        Me.dg_Notes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_Notes.Location = New System.Drawing.Point(0, 0)
        Me.dg_Notes.Name = "dg_Notes"
        Me.dg_Notes.ReadOnly = True
        Me.dg_Notes.RowHeadersVisible = False
        Me.dg_Notes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_Notes.Size = New System.Drawing.Size(900, 122)
        Me.dg_Notes.TabIndex = 93
        '
        'RecurringServiceIDDataGridViewTextBoxColumn
        '
        Me.RecurringServiceIDDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceID"
        Me.RecurringServiceIDDataGridViewTextBoxColumn.HeaderText = "RecurringServiceID"
        Me.RecurringServiceIDDataGridViewTextBoxColumn.Name = "RecurringServiceIDDataGridViewTextBoxColumn"
        Me.RecurringServiceIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceIDDataGridViewTextBoxColumn.Visible = False
        '
        'ServiceNameDataGridViewTextBoxColumn
        '
        Me.ServiceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
        Me.ServiceNameDataGridViewTextBoxColumn.HeaderText = "Service"
        Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
        Me.ServiceNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RecurringServiceRateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceRateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RecurringServiceRateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceRate"
        DataGridViewCellStyle1.Format = "C2"
        Me.RecurringServiceRateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.RecurringServiceRateDataGridViewTextBoxColumn.HeaderText = "Rate"
        Me.RecurringServiceRateDataGridViewTextBoxColumn.Name = "RecurringServiceRateDataGridViewTextBoxColumn"
        Me.RecurringServiceRateDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceRateDataGridViewTextBoxColumn.Width = 55
        '
        'RecurringServiceQuantityDataGridViewTextBoxColumn
        '
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceQuantity"
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.Name = "RecurringServiceQuantityDataGridViewTextBoxColumn"
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceQuantityDataGridViewTextBoxColumn.Width = 71
        '
        'RecurringServiceBillLengthDataGridViewTextBoxColumn
        '
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceBillLength"
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn.HeaderText = "Bill Length"
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn.Name = "RecurringServiceBillLengthDataGridViewTextBoxColumn"
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceBillLengthDataGridViewTextBoxColumn.Width = 81
        '
        'RecurringServiceStartDateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceStartDate"
        DataGridViewCellStyle2.Format = "d"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.Name = "RecurringServiceStartDateDataGridViewTextBoxColumn"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.Width = 80
        '
        'RecurringServiceEndDateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceEndDate"
        DataGridViewCellStyle3.Format = "d"
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.HeaderText = "End Date"
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.Name = "RecurringServiceEndDateDataGridViewTextBoxColumn"
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceEndDateDataGridViewTextBoxColumn.Width = 77
        '
        'MaxEndBillingDateDataGridViewTextBoxColumn
        '
        Me.MaxEndBillingDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.MaxEndBillingDateDataGridViewTextBoxColumn.DataPropertyName = "MaxEndBillingDate"
        DataGridViewCellStyle4.Format = "d"
        Me.MaxEndBillingDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.MaxEndBillingDateDataGridViewTextBoxColumn.HeaderText = "Billed Through"
        Me.MaxEndBillingDateDataGridViewTextBoxColumn.Name = "MaxEndBillingDateDataGridViewTextBoxColumn"
        Me.MaxEndBillingDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ApprovedDataGridViewCheckBoxColumn
        '
        Me.ApprovedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ApprovedDataGridViewCheckBoxColumn.DataPropertyName = "Approved"
        Me.ApprovedDataGridViewCheckBoxColumn.HeaderText = "Approved"
        Me.ApprovedDataGridViewCheckBoxColumn.Name = "ApprovedDataGridViewCheckBoxColumn"
        Me.ApprovedDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ApprovedDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApprovedDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ApprovedDataGridViewCheckBoxColumn.Width = 59
        '
        'RecurringServiceDisplayBindingSource
        '
        Me.RecurringServiceDisplayBindingSource.DataMember = "RecurringService_Display"
        Me.RecurringServiceDisplayBindingSource.DataSource = Me.Ds_Display
        '
        'Ds_Display
        '
        Me.Ds_Display.DataSetName = "ds_Display"
        Me.Ds_Display.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ServiceNotesBindingSource
        '
        Me.ServiceNotesBindingSource.DataMember = "ServiceNotes"
        Me.ServiceNotesBindingSource.DataSource = Me.Ds_Display
        '
        'ServiceNotesTableAdapter
        '
        Me.ServiceNotesTableAdapter.ClearBeforeFill = True
        '
        'RecurringService_DisplayTableAdapter
        '
        Me.RecurringService_DisplayTableAdapter.ClearBeforeFill = True
        '
        'ServiceNoteTextDataGridViewTextBoxColumn
        '
        Me.ServiceNoteTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ServiceNoteTextDataGridViewTextBoxColumn.DataPropertyName = "ServiceNoteText"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.HeaderText = "Service Note"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.Name = "ServiceNoteTextDataGridViewTextBoxColumn"
        Me.ServiceNoteTextDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InsertedByUser
        '
        Me.InsertedByUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.InsertedByUser.DataPropertyName = "InsertedByUser"
        Me.InsertedByUser.HeaderText = "User"
        Me.InsertedByUser.Name = "InsertedByUser"
        Me.InsertedByUser.ReadOnly = True
        Me.InsertedByUser.Width = 54
        '
        'ServiceNoteDateDataGridViewTextBoxColumn
        '
        Me.ServiceNoteDateDataGridViewTextBoxColumn.DataPropertyName = "ServiceNoteDate"
        DataGridViewCellStyle5.Format = "d"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ServiceNoteDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.Name = "ServiceNoteDateDataGridViewTextBoxColumn"
        Me.ServiceNoteDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UC_RecurringService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sc_Master)
        Me.Name = "UC_RecurringService"
        Me.Size = New System.Drawing.Size(900, 296)
        Me.sc_Master.Panel1.ResumeLayout(False)
        Me.sc_Master.Panel2.ResumeLayout(False)
        CType(Me.sc_Master, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sc_Master.ResumeLayout(False)
        CType(Me.dg_RecSrvc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grp_SrvcState.ResumeLayout(False)
        Me.grp_SrvcState.PerformLayout()
        CType(Me.dg_Notes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecurringServiceDisplayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServiceNotesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sc_Master As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grp_SrvcState As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_AllSrvc As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_CurrentSrvc As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_EndedSrvc As System.Windows.Forms.RadioButton
    Friend WithEvents dg_Notes As System.Windows.Forms.DataGridView
    Public WithEvents dg_RecSrvc As System.Windows.Forms.DataGridView
    Friend WithEvents RecurringServicePickupDayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ds_Display As TrashCash.ds_Display
    Friend WithEvents ServiceNotesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServiceNotesTableAdapter As TrashCash.ds_DisplayTableAdapters.ServiceNotesTableAdapter
    Friend WithEvents btn_NewSrvc As System.Windows.Forms.Button
    Friend WithEvents RecurringServiceIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceRateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceBillLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceStartDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceEndDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxEndBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceDisplayBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecurringService_DisplayTableAdapter As TrashCash.ds_DisplayTableAdapters.RecurringService_DisplayTableAdapter
    Friend WithEvents ServiceNoteTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertedByUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNoteDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
