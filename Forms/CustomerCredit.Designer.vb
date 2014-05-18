<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerCredit
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnl_TopContent = New System.Windows.Forms.Panel()
        Me.Ts_M_Customer = New TrashCash.ts_M_Customer()
        Me.pnl_Left = New System.Windows.Forms.Panel()
        Me.lbl_CreditHis = New System.Windows.Forms.Label()
        Me.dg_Credits = New System.Windows.Forms.DataGridView()
        Me.Ds_Customer = New TrashCash.ds_Customer()
        Me.CustomerCreditsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Customer_CreditsTableAdapter = New TrashCash.ds_CustomerTableAdapters.Customer_CreditsTableAdapter()
        Me.CreditAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReasonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedUserDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_TopContent.SuspendLayout()
        Me.pnl_Left.SuspendLayout()
        CType(Me.dg_Credits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerCreditsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnl_TopContent)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.Panel1.Size = New System.Drawing.Size(716, 53)
        Me.Panel1.TabIndex = 97
        '
        'pnl_TopContent
        '
        Me.pnl_TopContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_TopContent.Controls.Add(Me.Ts_M_Customer)
        Me.pnl_TopContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_TopContent.Location = New System.Drawing.Point(20, 10)
        Me.pnl_TopContent.Name = "pnl_TopContent"
        Me.pnl_TopContent.Size = New System.Drawing.Size(676, 33)
        Me.pnl_TopContent.TabIndex = 2
        '
        'Ts_M_Customer
        '
        Me.Ts_M_Customer.CurrentCustomer = 0
        Me.Ts_M_Customer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ts_M_Customer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Ts_M_Customer.Location = New System.Drawing.Point(0, 0)
        Me.Ts_M_Customer.Name = "Ts_M_Customer"
        Me.Ts_M_Customer.Size = New System.Drawing.Size(674, 31)
        Me.Ts_M_Customer.TabIndex = 2
        Me.Ts_M_Customer.Text = "Ts_M_Customer1"
        '
        'pnl_Left
        '
        Me.pnl_Left.Controls.Add(Me.dg_Credits)
        Me.pnl_Left.Controls.Add(Me.lbl_CreditHis)
        Me.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_Left.Location = New System.Drawing.Point(0, 53)
        Me.pnl_Left.Name = "pnl_Left"
        Me.pnl_Left.Size = New System.Drawing.Size(430, 300)
        Me.pnl_Left.TabIndex = 98
        '
        'lbl_CreditHis
        '
        Me.lbl_CreditHis.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_CreditHis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CreditHis.Location = New System.Drawing.Point(0, 0)
        Me.lbl_CreditHis.Name = "lbl_CreditHis"
        Me.lbl_CreditHis.Size = New System.Drawing.Size(430, 23)
        Me.lbl_CreditHis.TabIndex = 0
        Me.lbl_CreditHis.Text = "Credit History"
        Me.lbl_CreditHis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dg_Credits
        '
        Me.dg_Credits.AllowUserToAddRows = False
        Me.dg_Credits.AllowUserToDeleteRows = False
        Me.dg_Credits.AutoGenerateColumns = False
        Me.dg_Credits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Credits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CreditAmountDataGridViewTextBoxColumn, Me.TimeCreatedDataGridViewTextBoxColumn, Me.ReasonDataGridViewTextBoxColumn, Me.CreatedUserDataGridViewTextBoxColumn})
        Me.dg_Credits.DataSource = Me.CustomerCreditsBindingSource
        Me.dg_Credits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_Credits.Location = New System.Drawing.Point(0, 23)
        Me.dg_Credits.MultiSelect = False
        Me.dg_Credits.Name = "dg_Credits"
        Me.dg_Credits.ReadOnly = True
        Me.dg_Credits.RowHeadersVisible = False
        Me.dg_Credits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_Credits.Size = New System.Drawing.Size(430, 277)
        Me.dg_Credits.TabIndex = 1
        '
        'Ds_Customer
        '
        Me.Ds_Customer.DataSetName = "ds_Customer"
        Me.Ds_Customer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomerCreditsBindingSource
        '
        Me.CustomerCreditsBindingSource.DataMember = "Customer_Credits"
        Me.CustomerCreditsBindingSource.DataSource = Me.Ds_Customer
        '
        'Customer_CreditsTableAdapter
        '
        Me.Customer_CreditsTableAdapter.ClearBeforeFill = True
        '
        'CreditAmountDataGridViewTextBoxColumn
        '
        Me.CreditAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CreditAmountDataGridViewTextBoxColumn.DataPropertyName = "CreditAmount"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CreditAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CreditAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.CreditAmountDataGridViewTextBoxColumn.Name = "CreditAmountDataGridViewTextBoxColumn"
        Me.CreditAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreditAmountDataGridViewTextBoxColumn.Width = 68
        '
        'TimeCreatedDataGridViewTextBoxColumn
        '
        Me.TimeCreatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TimeCreatedDataGridViewTextBoxColumn.DataPropertyName = "TimeCreated"
        DataGridViewCellStyle2.Format = "g"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TimeCreatedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TimeCreatedDataGridViewTextBoxColumn.HeaderText = "Time Created"
        Me.TimeCreatedDataGridViewTextBoxColumn.Name = "TimeCreatedDataGridViewTextBoxColumn"
        Me.TimeCreatedDataGridViewTextBoxColumn.ReadOnly = True
        Me.TimeCreatedDataGridViewTextBoxColumn.Width = 95
        '
        'ReasonDataGridViewTextBoxColumn
        '
        Me.ReasonDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ReasonDataGridViewTextBoxColumn.DataPropertyName = "Reason"
        Me.ReasonDataGridViewTextBoxColumn.HeaderText = "Reason"
        Me.ReasonDataGridViewTextBoxColumn.Name = "ReasonDataGridViewTextBoxColumn"
        Me.ReasonDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreatedUserDataGridViewTextBoxColumn
        '
        Me.CreatedUserDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CreatedUserDataGridViewTextBoxColumn.DataPropertyName = "CreatedUser"
        Me.CreatedUserDataGridViewTextBoxColumn.HeaderText = "User"
        Me.CreatedUserDataGridViewTextBoxColumn.Name = "CreatedUserDataGridViewTextBoxColumn"
        Me.CreatedUserDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreatedUserDataGridViewTextBoxColumn.Width = 54
        '
        'CustomerCredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 353)
        Me.Controls.Add(Me.pnl_Left)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomerCredit"
        Me.Text = "Customer Credit"
        Me.Panel1.ResumeLayout(False)
        Me.pnl_TopContent.ResumeLayout(False)
        Me.pnl_TopContent.PerformLayout()
        Me.pnl_Left.ResumeLayout(False)
        CType(Me.dg_Credits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_Customer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerCreditsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnl_TopContent As System.Windows.Forms.Panel
    Friend WithEvents Ts_M_Customer As TrashCash.ts_M_Customer
    Friend WithEvents pnl_Left As System.Windows.Forms.Panel
    Friend WithEvents dg_Credits As System.Windows.Forms.DataGridView
    Friend WithEvents CreditAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeCreatedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedUserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerCreditsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Ds_Customer As TrashCash.ds_Customer
    Friend WithEvents lbl_CreditHis As System.Windows.Forms.Label
    Friend WithEvents Customer_CreditsTableAdapter As TrashCash.ds_CustomerTableAdapters.Customer_CreditsTableAdapter
End Class
