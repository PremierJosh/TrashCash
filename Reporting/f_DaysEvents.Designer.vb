<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_DaysEvents
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
        Me.tc_Report = New System.Windows.Forms.TabControl()
        Me.tp_RepView = New System.Windows.Forms.TabPage()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.tp_GridView = New System.Windows.Forms.TabPage()
        Me.dg_Invoices = New System.Windows.Forms.DataGridView()
        Me.dg_Customers = New System.Windows.Forms.DataGridView()
        Me.pnl_TopSpacer = New System.Windows.Forms.Panel()
        Me.lbl_Cust = New System.Windows.Forms.Label()
        Me.lbl_Invoices = New System.Windows.Forms.Label()
        Me.lbl_RptInfo = New System.Windows.Forms.Label()
        Me.dtp_Date = New System.Windows.Forms.DateTimePicker()
        Me.btn_GenReport = New System.Windows.Forms.Button()
        Me.Report_DataSet = New TrashCash.Report_DataSet()
        Me.Report_DaysEventsTableAdapter = New TrashCash.Report_DataSetTableAdapters.Report_DaysEventsTableAdapter()
        Me.tc_Report.SuspendLayout()
        Me.tp_RepView.SuspendLayout()
        Me.tp_GridView.SuspendLayout()
        CType(Me.dg_Invoices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Customers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_TopSpacer.SuspendLayout()
        CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tc_Report
        '
        Me.tc_Report.Controls.Add(Me.tp_RepView)
        Me.tc_Report.Controls.Add(Me.tp_GridView)
        Me.tc_Report.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tc_Report.Location = New System.Drawing.Point(0, 90)
        Me.tc_Report.Multiline = True
        Me.tc_Report.Name = "tc_Report"
        Me.tc_Report.SelectedIndex = 0
        Me.tc_Report.Size = New System.Drawing.Size(939, 484)
        Me.tc_Report.TabIndex = 2
        '
        'tp_RepView
        '
        Me.tp_RepView.AccessibleName = ""
        Me.tp_RepView.Controls.Add(Me.CrystalReportViewer)
        Me.tp_RepView.Location = New System.Drawing.Point(4, 22)
        Me.tp_RepView.Name = "tp_RepView"
        Me.tp_RepView.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_RepView.Size = New System.Drawing.Size(931, 458)
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
        Me.CrystalReportViewer.Size = New System.Drawing.Size(925, 452)
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
        Me.dg_Invoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Invoices.Dock = System.Windows.Forms.DockStyle.Right
        Me.dg_Invoices.Location = New System.Drawing.Point(376, 34)
        Me.dg_Invoices.MultiSelect = False
        Me.dg_Invoices.Name = "dg_Invoices"
        Me.dg_Invoices.ReadOnly = True
        Me.dg_Invoices.RowHeadersVisible = False
        Me.dg_Invoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_Invoices.Size = New System.Drawing.Size(506, 421)
        Me.dg_Invoices.TabIndex = 3
        '
        'dg_Customers
        '
        Me.dg_Customers.AllowUserToAddRows = False
        Me.dg_Customers.AllowUserToDeleteRows = False
        Me.dg_Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Customers.Dock = System.Windows.Forms.DockStyle.Left
        Me.dg_Customers.Location = New System.Drawing.Point(3, 34)
        Me.dg_Customers.MultiSelect = False
        Me.dg_Customers.Name = "dg_Customers"
        Me.dg_Customers.ReadOnly = True
        Me.dg_Customers.RowHeadersVisible = False
        Me.dg_Customers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_Customers.Size = New System.Drawing.Size(306, 421)
        Me.dg_Customers.TabIndex = 2
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
        'lbl_RptInfo
        '
        Me.lbl_RptInfo.AutoSize = True
        Me.lbl_RptInfo.Location = New System.Drawing.Point(250, 20)
        Me.lbl_RptInfo.Name = "lbl_RptInfo"
        Me.lbl_RptInfo.Size = New System.Drawing.Size(459, 13)
        Me.lbl_RptInfo.TabIndex = 3
        Me.lbl_RptInfo.Text = "This report shows all upcoming new Recurring Services and special pickups for the" & _
    " chosen day."
        '
        'dtp_Date
        '
        Me.dtp_Date.Location = New System.Drawing.Point(372, 40)
        Me.dtp_Date.Name = "dtp_Date"
        Me.dtp_Date.Size = New System.Drawing.Size(200, 20)
        Me.dtp_Date.TabIndex = 4
        '
        'btn_GenReport
        '
        Me.btn_GenReport.Location = New System.Drawing.Point(425, 66)
        Me.btn_GenReport.Name = "btn_GenReport"
        Me.btn_GenReport.Size = New System.Drawing.Size(75, 23)
        Me.btn_GenReport.TabIndex = 5
        Me.btn_GenReport.Text = "Build Report"
        Me.btn_GenReport.UseVisualStyleBackColor = True
        '
        'Report_DataSet
        '
        Me.Report_DataSet.DataSetName = "Report_DataSet"
        Me.Report_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Report_DaysEventsTableAdapter
        '
        Me.Report_DaysEventsTableAdapter.ClearBeforeFill = True
        '
        'f_DaysEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 574)
        Me.Controls.Add(Me.btn_GenReport)
        Me.Controls.Add(Me.dtp_Date)
        Me.Controls.Add(Me.lbl_RptInfo)
        Me.Controls.Add(Me.tc_Report)
        Me.Name = "f_DaysEvents"
        Me.Text = "Report: Days Events"
        Me.tc_Report.ResumeLayout(False)
        Me.tp_RepView.ResumeLayout(False)
        Me.tp_GridView.ResumeLayout(False)
        CType(Me.dg_Invoices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Customers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_TopSpacer.ResumeLayout(False)
        Me.pnl_TopSpacer.PerformLayout()
        CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tc_Report As System.Windows.Forms.TabControl
    Friend WithEvents tp_RepView As System.Windows.Forms.TabPage
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents tp_GridView As System.Windows.Forms.TabPage
    Friend WithEvents dg_Invoices As System.Windows.Forms.DataGridView
    Friend WithEvents dg_Customers As System.Windows.Forms.DataGridView
    Friend WithEvents pnl_TopSpacer As System.Windows.Forms.Panel
    Friend WithEvents lbl_Cust As System.Windows.Forms.Label
    Friend WithEvents lbl_Invoices As System.Windows.Forms.Label
    Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
    Friend WithEvents dtp_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_GenReport As System.Windows.Forms.Button
    Friend WithEvents Report_DataSet As TrashCash.Report_DataSet
    Friend WithEvents Report_DaysEventsTableAdapter As TrashCash.Report_DataSetTableAdapters.Report_DaysEventsTableAdapter
End Class
