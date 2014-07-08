Namespace Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Report_AllCustBalances
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
            Me.tc_Report = New System.Windows.Forms.TabControl()
            Me.tp_RepView = New System.Windows.Forms.TabPage()
            Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.tp_GridView = New System.Windows.Forms.TabPage()
            Me.dg_Invoices = New System.Windows.Forms.DataGridView()
            Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DaysPastDueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InvoiceBalancesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Report_DataSet = New TrashCash.Reports.DS_Reports()
            Me.dg_Customers = New System.Windows.Forms.DataGridView()
            Me.CustomerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CustomerBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CustomerPhoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CustomerBalancesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.pnl_TopSpacer = New System.Windows.Forms.Panel()
            Me.lbl_Cust = New System.Windows.Forms.Label()
            Me.lbl_Invoices = New System.Windows.Forms.Label()
            Me.lbl_Days = New System.Windows.Forms.Label()
            Me.lbl_RptInfo = New System.Windows.Forms.Label()
            Me.btn_BuildRpt = New System.Windows.Forms.Button()
            Me.ck_ActiveOnly = New System.Windows.Forms.CheckBox()
            Me.nud_MindDays = New System.Windows.Forms.NumericUpDown()
            Me.tc_Report.SuspendLayout()
            Me.tp_RepView.SuspendLayout()
            Me.tp_GridView.SuspendLayout()
            CType(Me.dg_Invoices, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.InvoiceBalancesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dg_Customers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CustomerBalancesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnl_TopSpacer.SuspendLayout()
            CType(Me.nud_MindDays, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tc_Report
            '
            Me.tc_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tc_Report.Controls.Add(Me.tp_RepView)
            Me.tc_Report.Controls.Add(Me.tp_GridView)
            Me.tc_Report.Location = New System.Drawing.Point(0, 78)
            Me.tc_Report.Multiline = True
            Me.tc_Report.Name = "tc_Report"
            Me.tc_Report.SelectedIndex = 0
            Me.tc_Report.Size = New System.Drawing.Size(893, 484)
            Me.tc_Report.TabIndex = 1
            '
            'tp_RepView
            '
            Me.tp_RepView.AccessibleName = ""
            Me.tp_RepView.Controls.Add(Me.CrystalReportViewer)
            Me.tp_RepView.Location = New System.Drawing.Point(4, 22)
            Me.tp_RepView.Name = "tp_RepView"
            Me.tp_RepView.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_RepView.Size = New System.Drawing.Size(885, 458)
            Me.tp_RepView.TabIndex = 0
            Me.tp_RepView.Text = "Report View"
            Me.tp_RepView.UseVisualStyleBackColor = True
            '
            'CrystalReportViewer
            '
            Me.CrystalReportViewer.ActiveViewIndex = -1
            Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
            Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CrystalReportViewer.Location = New System.Drawing.Point(3, 3)
            Me.CrystalReportViewer.Name = "CrystalReportViewer"
            Me.CrystalReportViewer.Size = New System.Drawing.Size(879, 452)
            Me.CrystalReportViewer.TabIndex = 0
            '
            'tp_GridView
            '
            Me.tp_GridView.Controls.Add(Me.dg_Invoices)
            Me.tp_GridView.Controls.Add(Me.dg_Customers)
            Me.tp_GridView.Controls.Add(Me.pnl_TopSpacer)
            Me.tp_GridView.Location = New System.Drawing.Point(4, 22)
            Me.tp_GridView.Name = "tp_GridView"
            Me.tp_GridView.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_GridView.Size = New System.Drawing.Size(885, 458)
            Me.tp_GridView.TabIndex = 1
            Me.tp_GridView.Text = "Grid View"
            Me.tp_GridView.UseVisualStyleBackColor = True
            '
            'dg_Invoices
            '
            Me.dg_Invoices.AllowUserToAddRows = False
            Me.dg_Invoices.AllowUserToDeleteRows = False
            Me.dg_Invoices.AutoGenerateColumns = False
            Me.dg_Invoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_Invoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn, Me.DueDateDataGridViewTextBoxColumn, Me.DaysPastDueDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn, Me.BalanceDataGridViewTextBoxColumn})
            Me.dg_Invoices.DataSource = Me.InvoiceBalancesBindingSource
            Me.dg_Invoices.Dock = System.Windows.Forms.DockStyle.Right
            Me.dg_Invoices.Location = New System.Drawing.Point(376, 34)
            Me.dg_Invoices.MultiSelect = False
            Me.dg_Invoices.Name = "dg_Invoices"
            Me.dg_Invoices.ReadOnly = True
            Me.dg_Invoices.RowHeadersVisible = False
            Me.dg_Invoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_Invoices.Size = New System.Drawing.Size(506, 421)
            Me.dg_Invoices.TabIndex = 3
            Me.dg_Invoices.Visible = False
            '
            'InvoiceNumberDataGridViewTextBoxColumn
            '
            Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
            Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "InvoiceNumber"
            Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
            Me.InvoiceNumberDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DueDateDataGridViewTextBoxColumn
            '
            Me.DueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate"
            Me.DueDateDataGridViewTextBoxColumn.HeaderText = "DueDate"
            Me.DueDateDataGridViewTextBoxColumn.Name = "DueDateDataGridViewTextBoxColumn"
            Me.DueDateDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DaysPastDueDataGridViewTextBoxColumn
            '
            Me.DaysPastDueDataGridViewTextBoxColumn.DataPropertyName = "DaysPastDue"
            Me.DaysPastDueDataGridViewTextBoxColumn.HeaderText = "DaysPastDue"
            Me.DaysPastDueDataGridViewTextBoxColumn.Name = "DaysPastDueDataGridViewTextBoxColumn"
            Me.DaysPastDueDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoiceTotalDataGridViewTextBoxColumn
            '
            Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
            Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "InvoiceTotal"
            Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
            Me.InvoiceTotalDataGridViewTextBoxColumn.ReadOnly = True
            '
            'BalanceDataGridViewTextBoxColumn
            '
            Me.BalanceDataGridViewTextBoxColumn.DataPropertyName = "Balance"
            Me.BalanceDataGridViewTextBoxColumn.HeaderText = "Balance"
            Me.BalanceDataGridViewTextBoxColumn.Name = "BalanceDataGridViewTextBoxColumn"
            Me.BalanceDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InvoiceBalancesBindingSource
            '
            Me.InvoiceBalancesBindingSource.DataMember = "InvoiceBalances"
            Me.InvoiceBalancesBindingSource.DataSource = Me.Report_DataSet
            '
            'Report_DataSet
            '
            Me.Report_DataSet.DataSetName = "Report_DataSet"
            Me.Report_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'dg_Customers
            '
            Me.dg_Customers.AllowUserToAddRows = False
            Me.dg_Customers.AllowUserToDeleteRows = False
            Me.dg_Customers.AutoGenerateColumns = False
            Me.dg_Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg_Customers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerNameDataGridViewTextBoxColumn, Me.CustomerBalanceDataGridViewTextBoxColumn, Me.CustomerPhoneDataGridViewTextBoxColumn})
            Me.dg_Customers.DataSource = Me.CustomerBalancesBindingSource
            Me.dg_Customers.Dock = System.Windows.Forms.DockStyle.Left
            Me.dg_Customers.Location = New System.Drawing.Point(3, 34)
            Me.dg_Customers.MultiSelect = False
            Me.dg_Customers.Name = "dg_Customers"
            Me.dg_Customers.ReadOnly = True
            Me.dg_Customers.RowHeadersVisible = False
            Me.dg_Customers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dg_Customers.Size = New System.Drawing.Size(306, 421)
            Me.dg_Customers.TabIndex = 2
            Me.dg_Customers.Visible = False
            '
            'CustomerNameDataGridViewTextBoxColumn
            '
            Me.CustomerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName"
            Me.CustomerNameDataGridViewTextBoxColumn.HeaderText = "CustomerName"
            Me.CustomerNameDataGridViewTextBoxColumn.Name = "CustomerNameDataGridViewTextBoxColumn"
            Me.CustomerNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CustomerBalanceDataGridViewTextBoxColumn
            '
            Me.CustomerBalanceDataGridViewTextBoxColumn.DataPropertyName = "CustomerBalance"
            Me.CustomerBalanceDataGridViewTextBoxColumn.HeaderText = "CustomerBalance"
            Me.CustomerBalanceDataGridViewTextBoxColumn.Name = "CustomerBalanceDataGridViewTextBoxColumn"
            Me.CustomerBalanceDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CustomerPhoneDataGridViewTextBoxColumn
            '
            Me.CustomerPhoneDataGridViewTextBoxColumn.DataPropertyName = "CustomerPhone"
            Me.CustomerPhoneDataGridViewTextBoxColumn.HeaderText = "CustomerPhone"
            Me.CustomerPhoneDataGridViewTextBoxColumn.Name = "CustomerPhoneDataGridViewTextBoxColumn"
            Me.CustomerPhoneDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CustomerBalancesBindingSource
            '
            Me.CustomerBalancesBindingSource.DataMember = "CustomerBalances"
            Me.CustomerBalancesBindingSource.DataSource = Me.Report_DataSet
            '
            'pnl_TopSpacer
            '
            Me.pnl_TopSpacer.Controls.Add(Me.lbl_Cust)
            Me.pnl_TopSpacer.Controls.Add(Me.lbl_Invoices)
            Me.pnl_TopSpacer.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnl_TopSpacer.Location = New System.Drawing.Point(3, 3)
            Me.pnl_TopSpacer.Name = "pnl_TopSpacer"
            Me.pnl_TopSpacer.Size = New System.Drawing.Size(879, 31)
            Me.pnl_TopSpacer.TabIndex = 4
            Me.pnl_TopSpacer.Visible = False
            '
            'lbl_Cust
            '
            Me.lbl_Cust.AutoSize = True
            Me.lbl_Cust.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl_Cust.Location = New System.Drawing.Point(5, 8)
            Me.lbl_Cust.Name = "lbl_Cust"
            Me.lbl_Cust.Size = New System.Drawing.Size(95, 20)
            Me.lbl_Cust.TabIndex = 0
            Me.lbl_Cust.Text = "Customers"
            '
            'lbl_Invoices
            '
            Me.lbl_Invoices.AutoSize = True
            Me.lbl_Invoices.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl_Invoices.Location = New System.Drawing.Point(368, 8)
            Me.lbl_Invoices.Name = "lbl_Invoices"
            Me.lbl_Invoices.Size = New System.Drawing.Size(75, 20)
            Me.lbl_Invoices.TabIndex = 1
            Me.lbl_Invoices.Text = "Invoices"
            '
            'lbl_Days
            '
            Me.lbl_Days.AutoSize = True
            Me.lbl_Days.Location = New System.Drawing.Point(233, 28)
            Me.lbl_Days.Name = "lbl_Days"
            Me.lbl_Days.Size = New System.Drawing.Size(214, 13)
            Me.lbl_Days.TabIndex = 2
            Me.lbl_Days.Text = "Minimum days past due on an open invoice:"
            '
            'lbl_RptInfo
            '
            Me.lbl_RptInfo.AutoSize = True
            Me.lbl_RptInfo.Location = New System.Drawing.Point(79, 9)
            Me.lbl_RptInfo.Name = "lbl_RptInfo"
            Me.lbl_RptInfo.Size = New System.Drawing.Size(568, 13)
            Me.lbl_RptInfo.TabIndex = 3
            Me.lbl_RptInfo.Text = "This Report will generate a list of all Customers who have an outstanding balance" & _
        ", listing the Invoices that are still open."
            '
            'btn_BuildRpt
            '
            Me.btn_BuildRpt.Location = New System.Drawing.Point(430, 49)
            Me.btn_BuildRpt.Name = "btn_BuildRpt"
            Me.btn_BuildRpt.Size = New System.Drawing.Size(75, 23)
            Me.btn_BuildRpt.TabIndex = 5
            Me.btn_BuildRpt.Text = "Build Report"
            Me.btn_BuildRpt.UseVisualStyleBackColor = True
            '
            'ck_ActiveOnly
            '
            Me.ck_ActiveOnly.AutoSize = True
            Me.ck_ActiveOnly.Checked = True
            Me.ck_ActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ck_ActiveOnly.Location = New System.Drawing.Point(259, 53)
            Me.ck_ActiveOnly.Name = "ck_ActiveOnly"
            Me.ck_ActiveOnly.Size = New System.Drawing.Size(132, 17)
            Me.ck_ActiveOnly.TabIndex = 6
            Me.ck_ActiveOnly.Text = "Active Customers Only"
            Me.ck_ActiveOnly.UseVisualStyleBackColor = True
            '
            'nud_MindDays
            '
            Me.nud_MindDays.Location = New System.Drawing.Point(453, 26)
            Me.nud_MindDays.Name = "nud_MindDays"
            Me.nud_MindDays.Size = New System.Drawing.Size(52, 20)
            Me.nud_MindDays.TabIndex = 7
            Me.nud_MindDays.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'Report_AllCustBalances
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(892, 562)
            Me.Controls.Add(Me.nud_MindDays)
            Me.Controls.Add(Me.ck_ActiveOnly)
            Me.Controls.Add(Me.btn_BuildRpt)
            Me.Controls.Add(Me.lbl_RptInfo)
            Me.Controls.Add(Me.lbl_Days)
            Me.Controls.Add(Me.tc_Report)
            Me.Name = "Report_AllCustBalances"
            Me.Text = "Report: All Customer Balances"
            Me.tc_Report.ResumeLayout(False)
            Me.tp_RepView.ResumeLayout(False)
            Me.tp_GridView.ResumeLayout(False)
            CType(Me.dg_Invoices, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.InvoiceBalancesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dg_Customers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CustomerBalancesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnl_TopSpacer.ResumeLayout(False)
            Me.pnl_TopSpacer.PerformLayout()
            CType(Me.nud_MindDays, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tc_Report As System.Windows.Forms.TabControl
        Friend WithEvents tp_RepView As System.Windows.Forms.TabPage
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents tp_GridView As System.Windows.Forms.TabPage
        Friend WithEvents lbl_Days As System.Windows.Forms.Label
        Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
        Friend WithEvents btn_BuildRpt As System.Windows.Forms.Button
        Friend WithEvents Report_DataSet As DS_Reports
        Friend WithEvents lbl_Invoices As System.Windows.Forms.Label
        Friend WithEvents lbl_Cust As System.Windows.Forms.Label
        Friend WithEvents dg_Invoices As System.Windows.Forms.DataGridView
        Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DaysPastDueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InvoiceBalancesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents dg_Customers As System.Windows.Forms.DataGridView
        Friend WithEvents CustomerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CustomerBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CustomerPhoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CustomerBalancesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents pnl_TopSpacer As System.Windows.Forms.Panel
        Friend WithEvents ck_ActiveOnly As System.Windows.Forms.CheckBox
        Friend WithEvents nud_MindDays As System.Windows.Forms.NumericUpDown
    End Class
End Namespace