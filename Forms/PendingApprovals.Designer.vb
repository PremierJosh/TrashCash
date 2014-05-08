<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingApprovals
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PendingApprovals))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.lbl_Header = New System.Windows.Forms.Label()
        Me.dg_PendingApprovals = New System.Windows.Forms.DataGridView()
        Me.CustomerFullNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Approved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RecurringServiceIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecurringServicePendingApprovalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_Display = New TrashCash.ds_Display()
        Me.pnl_SaveChanges = New System.Windows.Forms.Panel()
        Me.lbl_UnApproved = New System.Windows.Forms.Label()
        Me.lbl_Approved = New System.Windows.Forms.Label()
        Me.btn_SaveApprovals = New System.Windows.Forms.Button()
        Me.lbl_Save = New System.Windows.Forms.Label()
        Me.RecurringService_PendingApprovalsTableAdapter = New TrashCash.ds_DisplayTableAdapters.RecurringService_PendingApprovalsTableAdapter()
        Me.pnl_Top.SuspendLayout()
        CType(Me.dg_PendingApprovals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecurringServicePendingApprovalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_SaveChanges.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Top
        '
        Me.pnl_Top.Controls.Add(Me.lbl_Header)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.pnl_Top.Size = New System.Drawing.Size(919, 57)
        Me.pnl_Top.TabIndex = 0
        '
        'lbl_Header
        '
        Me.lbl_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_Header.Location = New System.Drawing.Point(0, 5)
        Me.lbl_Header.Name = "lbl_Header"
        Me.lbl_Header.Size = New System.Drawing.Size(919, 64)
        Me.lbl_Header.TabIndex = 0
        Me.lbl_Header.Text = resources.GetString("lbl_Header.Text")
        Me.lbl_Header.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dg_PendingApprovals
        '
        Me.dg_PendingApprovals.AllowUserToAddRows = False
        Me.dg_PendingApprovals.AllowUserToDeleteRows = False
        Me.dg_PendingApprovals.AutoGenerateColumns = False
        Me.dg_PendingApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_PendingApprovals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerFullNameDataGridViewTextBoxColumn, Me.ServiceNameDataGridViewTextBoxColumn, Me.RecurringServiceStartDateDataGridViewTextBoxColumn, Me.Approved, Me.RecurringServiceIDDataGridViewTextBoxColumn})
        Me.dg_PendingApprovals.DataSource = Me.RecurringServicePendingApprovalsBindingSource
        Me.dg_PendingApprovals.Location = New System.Drawing.Point(12, 72)
        Me.dg_PendingApprovals.MultiSelect = False
        Me.dg_PendingApprovals.Name = "dg_PendingApprovals"
        Me.dg_PendingApprovals.RowHeadersVisible = False
        Me.dg_PendingApprovals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_PendingApprovals.Size = New System.Drawing.Size(568, 369)
        Me.dg_PendingApprovals.TabIndex = 1
        '
        'CustomerFullNameDataGridViewTextBoxColumn
        '
        Me.CustomerFullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CustomerFullNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerFullName"
        Me.CustomerFullNameDataGridViewTextBoxColumn.HeaderText = "Customer"
        Me.CustomerFullNameDataGridViewTextBoxColumn.Name = "CustomerFullNameDataGridViewTextBoxColumn"
        Me.CustomerFullNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ServiceNameDataGridViewTextBoxColumn
        '
        Me.ServiceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
        Me.ServiceNameDataGridViewTextBoxColumn.HeaderText = "Service"
        Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
        Me.ServiceNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.ServiceNameDataGridViewTextBoxColumn.Width = 68
        '
        'RecurringServiceStartDateDataGridViewTextBoxColumn
        '
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceStartDate"
        DataGridViewCellStyle3.Format = "d"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.HeaderText = "Start Date"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.Name = "RecurringServiceStartDateDataGridViewTextBoxColumn"
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceStartDateDataGridViewTextBoxColumn.Width = 80
        '
        'Approved
        '
        Me.Approved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Approved.DataPropertyName = "Approved"
        Me.Approved.HeaderText = "Approved"
        Me.Approved.Name = "Approved"
        Me.Approved.Width = 59
        '
        'RecurringServiceIDDataGridViewTextBoxColumn
        '
        Me.RecurringServiceIDDataGridViewTextBoxColumn.DataPropertyName = "RecurringServiceID"
        Me.RecurringServiceIDDataGridViewTextBoxColumn.HeaderText = "RecurringServiceID"
        Me.RecurringServiceIDDataGridViewTextBoxColumn.Name = "RecurringServiceIDDataGridViewTextBoxColumn"
        Me.RecurringServiceIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.RecurringServiceIDDataGridViewTextBoxColumn.Visible = False
        '
        'RecurringServicePendingApprovalsBindingSource
        '
        Me.RecurringServicePendingApprovalsBindingSource.DataMember = "RecurringService_PendingApprovals"
        Me.RecurringServicePendingApprovalsBindingSource.DataSource = Me.Ds_Display
        '
        'Ds_Display
        '
        Me.Ds_Display.DataSetName = "ds_Display"
        Me.Ds_Display.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnl_SaveChanges
        '
        Me.pnl_SaveChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_SaveChanges.Controls.Add(Me.lbl_UnApproved)
        Me.pnl_SaveChanges.Controls.Add(Me.lbl_Approved)
        Me.pnl_SaveChanges.Controls.Add(Me.btn_SaveApprovals)
        Me.pnl_SaveChanges.Controls.Add(Me.lbl_Save)
        Me.pnl_SaveChanges.Location = New System.Drawing.Point(624, 137)
        Me.pnl_SaveChanges.Name = "pnl_SaveChanges"
        Me.pnl_SaveChanges.Size = New System.Drawing.Size(259, 188)
        Me.pnl_SaveChanges.TabIndex = 2
        '
        'lbl_UnApproved
        '
        Me.lbl_UnApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_UnApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_UnApproved.ForeColor = System.Drawing.Color.Crimson
        Me.lbl_UnApproved.Location = New System.Drawing.Point(131, 92)
        Me.lbl_UnApproved.Name = "lbl_UnApproved"
        Me.lbl_UnApproved.Size = New System.Drawing.Size(115, 20)
        Me.lbl_UnApproved.TabIndex = 3
        Me.lbl_UnApproved.Text = "Unapproved: 100"
        Me.lbl_UnApproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Approved
        '
        Me.lbl_Approved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Approved.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Approved.ForeColor = System.Drawing.Color.Green
        Me.lbl_Approved.Location = New System.Drawing.Point(11, 92)
        Me.lbl_Approved.Name = "lbl_Approved"
        Me.lbl_Approved.Size = New System.Drawing.Size(115, 20)
        Me.lbl_Approved.TabIndex = 2
        Me.lbl_Approved.Text = "Approved: 100"
        Me.lbl_Approved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Approved.Visible = False
        '
        'btn_SaveApprovals
        '
        Me.btn_SaveApprovals.Location = New System.Drawing.Point(41, 149)
        Me.btn_SaveApprovals.Name = "btn_SaveApprovals"
        Me.btn_SaveApprovals.Size = New System.Drawing.Size(174, 23)
        Me.btn_SaveApprovals.TabIndex = 1
        Me.btn_SaveApprovals.Text = "Approve Recurring Services"
        Me.btn_SaveApprovals.UseVisualStyleBackColor = True
        '
        'lbl_Save
        '
        Me.lbl_Save.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_Save.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Save.Name = "lbl_Save"
        Me.lbl_Save.Size = New System.Drawing.Size(257, 66)
        Me.lbl_Save.TabIndex = 0
        Me.lbl_Save.Text = "When you are finished marking Recurring Services for approval to bill, click the " & _
    "button below"
        Me.lbl_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RecurringService_PendingApprovalsTableAdapter
        '
        Me.RecurringService_PendingApprovalsTableAdapter.ClearBeforeFill = True
        '
        'PendingApprovals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 453)
        Me.Controls.Add(Me.pnl_SaveChanges)
        Me.Controls.Add(Me.dg_PendingApprovals)
        Me.Controls.Add(Me.pnl_Top)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PendingApprovals"
        Me.Text = "Pending Approvals"
        Me.pnl_Top.ResumeLayout(False)
        CType(Me.dg_PendingApprovals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecurringServicePendingApprovalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_SaveChanges.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
    Friend WithEvents lbl_Header As System.Windows.Forms.Label
    Friend WithEvents dg_PendingApprovals As System.Windows.Forms.DataGridView
    Friend WithEvents Ds_Display As TrashCash.ds_Display
    Friend WithEvents RecurringServicePendingApprovalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecurringService_PendingApprovalsTableAdapter As TrashCash.ds_DisplayTableAdapters.RecurringService_PendingApprovalsTableAdapter
    Friend WithEvents pnl_SaveChanges As System.Windows.Forms.Panel
    Friend WithEvents btn_SaveApprovals As System.Windows.Forms.Button
    Friend WithEvents lbl_Save As System.Windows.Forms.Label
    Friend WithEvents lbl_UnApproved As System.Windows.Forms.Label
    Friend WithEvents lbl_Approved As System.Windows.Forms.Label
    Friend WithEvents CustomerFullNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringServiceStartDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RecurringServiceIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
