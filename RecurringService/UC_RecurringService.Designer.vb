Namespace RecurringService
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
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.RecurringServiceDisplayByCustomerIDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Ds_RecurringService = New TrashCash.ds_RecurringService()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ServiceNotesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.RecurringService_DisplayByCustomerIDTableAdapter = New TrashCash.ds_RecurringServiceTableAdapters.RecurringService_DisplayByCustomerIDTableAdapter()
            Me.ServiceNotesTableAdapter = New TrashCash.ds_RecurringServiceTableAdapters.ServiceNotesTableAdapter()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.sc_Master, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.sc_Master.Panel1.SuspendLayout()
            Me.sc_Master.Panel2.SuspendLayout()
            Me.sc_Master.SuspendLayout()
            CType(Me.dg_RecSrvc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.grp_SrvcState.SuspendLayout()
            CType(Me.dg_Notes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RecurringServiceDisplayByCustomerIDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_RecurringService, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.dg_RecSrvc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn1})
            Me.dg_RecSrvc.DataSource = Me.RecurringServiceDisplayByCustomerIDBindingSource
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
            Me.rdo_AllSrvc.Checked = True
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
            Me.rdo_CurrentSrvc.Location = New System.Drawing.Point(6, 16)
            Me.rdo_CurrentSrvc.Name = "rdo_CurrentSrvc"
            Me.rdo_CurrentSrvc.Size = New System.Drawing.Size(59, 17)
            Me.rdo_CurrentSrvc.TabIndex = 1
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
            Me.dg_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dg_Notes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
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
            'RecurringServiceDisplayByCustomerIDBindingSource
            '
            Me.RecurringServiceDisplayByCustomerIDBindingSource.DataMember = "RecurringService_DisplayByCustomerID"
            Me.RecurringServiceDisplayByCustomerIDBindingSource.DataSource = Me.Ds_RecurringService
            '
            'Ds_RecurringService
            '
            Me.Ds_RecurringService.DataSetName = "ds_RecurringService"
            Me.Ds_RecurringService.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "ServiceNoteText"
            Me.DataGridViewTextBoxColumn8.HeaderText = "Service Note Text"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "ServiceNoteDate"
            DataGridViewCellStyle6.Format = "g"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewTextBoxColumn9.HeaderText = "Note Date"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Width = 81
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "InsertedByUser"
            Me.DataGridViewTextBoxColumn10.HeaderText = "User"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            Me.DataGridViewTextBoxColumn10.Width = 54
            '
            'ServiceNotesBindingSource
            '
            Me.ServiceNotesBindingSource.DataMember = "ServiceNotes"
            Me.ServiceNotesBindingSource.DataSource = Me.Ds_RecurringService
            '
            'RecurringService_DisplayByCustomerIDTableAdapter
            '
            Me.RecurringService_DisplayByCustomerIDTableAdapter.ClearBeforeFill = True
            '
            'ServiceNotesTableAdapter
            '
            Me.ServiceNotesTableAdapter.ClearBeforeFill = True
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "ServiceName"
            Me.DataGridViewTextBoxColumn1.HeaderText = "Service"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "RecurringServiceRate"
            DataGridViewCellStyle1.Format = "C2"
            Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewTextBoxColumn2.HeaderText = "Rate"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Width = 55
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "RecurringServiceQuantity"
            Me.DataGridViewTextBoxColumn6.HeaderText = "Quantity"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Width = 71
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "RecurringServiceBillLength"
            Me.DataGridViewTextBoxColumn7.HeaderText = "Bill Length"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            Me.DataGridViewTextBoxColumn7.Width = 81
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "RecurringServiceStartDate"
            DataGridViewCellStyle2.Format = "d"
            Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewTextBoxColumn3.HeaderText = "Start Date"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Width = 80
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "RecurringServiceEndDate"
            DataGridViewCellStyle3.Format = "d"
            Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewTextBoxColumn4.HeaderText = "End Date"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Width = 77
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "MaxEndBillingDate"
            DataGridViewCellStyle4.Format = "d"
            Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
            Me.DataGridViewTextBoxColumn5.HeaderText = "Billed Through"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewCheckBoxColumn1
            '
            Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Approved"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.DataGridViewCheckBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewCheckBoxColumn1.HeaderText = "Approved"
            Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
            Me.DataGridViewCheckBoxColumn1.ReadOnly = True
            Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.DataGridViewCheckBoxColumn1.Width = 59
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
            CType(Me.RecurringServiceDisplayByCustomerIDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_RecurringService, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents btn_NewSrvc As System.Windows.Forms.Button
        Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecurringServiceRateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecurringServiceQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecurringServiceBillLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecurringServiceStartDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecurringServiceEndDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MaxEndBillingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ApprovedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecurringServiceDisplayBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Ds_RecurringService As TrashCash.ds_RecurringService
        Friend WithEvents ServiceNoteTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceNoteDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InsertedByUserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ServiceNotesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents RecurringService_DisplayByCustomerIDTableAdapter As TrashCash.ds_RecurringServiceTableAdapters.RecurringService_DisplayByCustomerIDTableAdapter
        Friend WithEvents ServiceNotesTableAdapter As TrashCash.ds_RecurringServiceTableAdapters.ServiceNotesTableAdapter
        Friend WithEvents RecurringServiceDisplayByCustomerIDBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn


    End Class
End Namespace