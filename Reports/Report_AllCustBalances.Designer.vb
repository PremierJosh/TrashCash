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
            Me.InvoiceBalancesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.Report_DataSet = New TrashCash.Reports.DS_Reports()
            Me.CustomerBalancesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.lbl_Days = New System.Windows.Forms.Label()
            Me.lbl_RptInfo = New System.Windows.Forms.Label()
            Me.btn_BuildRpt = New System.Windows.Forms.Button()
            Me.ck_ActiveOnly = New System.Windows.Forms.CheckBox()
            Me.nud_MindDays = New System.Windows.Forms.NumericUpDown()
            Me.tc_Report.SuspendLayout()
            Me.tp_RepView.SuspendLayout()
            CType(Me.InvoiceBalancesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CustomerBalancesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nud_MindDays, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tc_Report
            '
            Me.tc_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tc_Report.Controls.Add(Me.tp_RepView)
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
            'CustomerBalancesBindingSource
            '
            Me.CustomerBalancesBindingSource.DataMember = "CustomerBalances"
            Me.CustomerBalancesBindingSource.DataSource = Me.Report_DataSet
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
            CType(Me.InvoiceBalancesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CustomerBalancesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nud_MindDays, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tc_Report As System.Windows.Forms.TabControl
        Friend WithEvents tp_RepView As System.Windows.Forms.TabPage
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents lbl_Days As System.Windows.Forms.Label
        Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
        Friend WithEvents btn_BuildRpt As System.Windows.Forms.Button
        Friend WithEvents Report_DataSet As DS_Reports
        Friend WithEvents InvoiceBalancesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents CustomerBalancesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ck_ActiveOnly As System.Windows.Forms.CheckBox
        Friend WithEvents nud_MindDays As System.Windows.Forms.NumericUpDown
    End Class
End Namespace