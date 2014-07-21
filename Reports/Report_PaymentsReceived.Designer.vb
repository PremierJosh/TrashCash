Namespace Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Report_PaymentsReceived
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
            Me.lbl_RptInfo = New System.Windows.Forms.Label()
            Me.lbl_To = New System.Windows.Forms.Label()
            Me.lbl_From = New System.Windows.Forms.Label()
            Me.dtp_To = New System.Windows.Forms.DateTimePicker()
            Me.dtp_From = New System.Windows.Forms.DateTimePicker()
            Me.btn_BuildRpt = New System.Windows.Forms.Button()
            Me.tc_Report = New System.Windows.Forms.TabControl()
            Me.tp_RepView = New System.Windows.Forms.TabPage()
            Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.rdo_BetweenDates = New System.Windows.Forms.RadioButton()
            Me.rdo_OnDate = New System.Windows.Forms.RadioButton()
            Me.dtp_SingleDate = New System.Windows.Forms.DateTimePicker()
            Me.rdo_Batch = New System.Windows.Forms.RadioButton()
            Me.cmb_BatchHistory = New System.Windows.Forms.ComboBox()
            Me.Ds_Reporting = New TrashCash.ds_Reporting()
            Me.tc_Report.SuspendLayout()
            Me.tp_RepView.SuspendLayout()
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lbl_RptInfo
            '
            Me.lbl_RptInfo.AutoSize = True
            Me.lbl_RptInfo.Location = New System.Drawing.Point(198, 9)
            Me.lbl_RptInfo.Name = "lbl_RptInfo"
            Me.lbl_RptInfo.Size = New System.Drawing.Size(395, 13)
            Me.lbl_RptInfo.TabIndex = 0
            Me.lbl_RptInfo.Text = "This Report will show all payments received from all Customers using various filt" & _
        "ers."
            '
            'lbl_To
            '
            Me.lbl_To.AutoSize = True
            Me.lbl_To.Location = New System.Drawing.Point(31, 87)
            Me.lbl_To.Name = "lbl_To"
            Me.lbl_To.Size = New System.Drawing.Size(23, 13)
            Me.lbl_To.TabIndex = 12
            Me.lbl_To.Text = "To:"
            '
            'lbl_From
            '
            Me.lbl_From.AutoSize = True
            Me.lbl_From.Location = New System.Drawing.Point(21, 60)
            Me.lbl_From.Name = "lbl_From"
            Me.lbl_From.Size = New System.Drawing.Size(33, 13)
            Me.lbl_From.TabIndex = 11
            Me.lbl_From.Text = "From:"
            '
            'dtp_To
            '
            Me.dtp_To.Enabled = False
            Me.dtp_To.Location = New System.Drawing.Point(60, 83)
            Me.dtp_To.Name = "dtp_To"
            Me.dtp_To.Size = New System.Drawing.Size(200, 20)
            Me.dtp_To.TabIndex = 10
            '
            'dtp_From
            '
            Me.dtp_From.Enabled = False
            Me.dtp_From.Location = New System.Drawing.Point(60, 57)
            Me.dtp_From.Name = "dtp_From"
            Me.dtp_From.Size = New System.Drawing.Size(200, 20)
            Me.dtp_From.TabIndex = 9
            '
            'btn_BuildRpt
            '
            Me.btn_BuildRpt.Location = New System.Drawing.Point(362, 87)
            Me.btn_BuildRpt.Name = "btn_BuildRpt"
            Me.btn_BuildRpt.Size = New System.Drawing.Size(75, 23)
            Me.btn_BuildRpt.TabIndex = 13
            Me.btn_BuildRpt.Text = "Build Report"
            Me.btn_BuildRpt.UseVisualStyleBackColor = True
            '
            'tc_Report
            '
            Me.tc_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tc_Report.Controls.Add(Me.tp_RepView)
            Me.tc_Report.Location = New System.Drawing.Point(0, 116)
            Me.tc_Report.Name = "tc_Report"
            Me.tc_Report.SelectedIndex = 0
            Me.tc_Report.Size = New System.Drawing.Size(831, 484)
            Me.tc_Report.TabIndex = 14
            Me.tc_Report.Visible = False
            '
            'tp_RepView
            '
            Me.tp_RepView.AccessibleName = ""
            Me.tp_RepView.Controls.Add(Me.CrystalReportViewer)
            Me.tp_RepView.Location = New System.Drawing.Point(4, 22)
            Me.tp_RepView.Name = "tp_RepView"
            Me.tp_RepView.Padding = New System.Windows.Forms.Padding(3)
            Me.tp_RepView.Size = New System.Drawing.Size(823, 458)
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
            Me.CrystalReportViewer.Size = New System.Drawing.Size(817, 452)
            Me.CrystalReportViewer.TabIndex = 0
            '
            'rdo_BetweenDates
            '
            Me.rdo_BetweenDates.AutoSize = True
            Me.rdo_BetweenDates.Location = New System.Drawing.Point(99, 35)
            Me.rdo_BetweenDates.Name = "rdo_BetweenDates"
            Me.rdo_BetweenDates.Size = New System.Drawing.Size(122, 17)
            Me.rdo_BetweenDates.TabIndex = 15
            Me.rdo_BetweenDates.TabStop = True
            Me.rdo_BetweenDates.Text = "Between Two Dates"
            Me.rdo_BetweenDates.UseVisualStyleBackColor = True
            '
            'rdo_OnDate
            '
            Me.rdo_OnDate.AutoSize = True
            Me.rdo_OnDate.Location = New System.Drawing.Point(362, 33)
            Me.rdo_OnDate.Name = "rdo_OnDate"
            Me.rdo_OnDate.Size = New System.Drawing.Size(65, 17)
            Me.rdo_OnDate.TabIndex = 16
            Me.rdo_OnDate.TabStop = True
            Me.rdo_OnDate.Text = "On Date"
            Me.rdo_OnDate.UseVisualStyleBackColor = True
            '
            'dtp_SingleDate
            '
            Me.dtp_SingleDate.Enabled = False
            Me.dtp_SingleDate.Location = New System.Drawing.Point(306, 56)
            Me.dtp_SingleDate.Name = "dtp_SingleDate"
            Me.dtp_SingleDate.Size = New System.Drawing.Size(200, 20)
            Me.dtp_SingleDate.TabIndex = 17
            '
            'rdo_Batch
            '
            Me.rdo_Batch.AutoSize = True
            Me.rdo_Batch.Location = New System.Drawing.Point(645, 35)
            Me.rdo_Batch.Name = "rdo_Batch"
            Me.rdo_Batch.Size = New System.Drawing.Size(68, 17)
            Me.rdo_Batch.TabIndex = 18
            Me.rdo_Batch.TabStop = True
            Me.rdo_Batch.Text = "By Batch"
            Me.rdo_Batch.UseVisualStyleBackColor = True
            '
            'cmb_BatchHistory
            '
            Me.cmb_BatchHistory.DataSource = Me.Ds_Reporting
            Me.cmb_BatchHistory.DisplayMember = "Batch_Payments_History.DisplayMember"
            Me.cmb_BatchHistory.Enabled = False
            Me.cmb_BatchHistory.FormattingEnabled = True
            Me.cmb_BatchHistory.Location = New System.Drawing.Point(556, 56)
            Me.cmb_BatchHistory.Name = "cmb_BatchHistory"
            Me.cmb_BatchHistory.Size = New System.Drawing.Size(236, 21)
            Me.cmb_BatchHistory.TabIndex = 19
            Me.cmb_BatchHistory.ValueMember = "Batch_Payments_History.ValueMember"
            '
            'Ds_Reporting
            '
            Me.Ds_Reporting.DataSetName = "ds_Reporting"
            Me.Ds_Reporting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Report_PaymentsReceived
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(831, 600)
            Me.Controls.Add(Me.cmb_BatchHistory)
            Me.Controls.Add(Me.rdo_Batch)
            Me.Controls.Add(Me.dtp_SingleDate)
            Me.Controls.Add(Me.rdo_OnDate)
            Me.Controls.Add(Me.rdo_BetweenDates)
            Me.Controls.Add(Me.tc_Report)
            Me.Controls.Add(Me.btn_BuildRpt)
            Me.Controls.Add(Me.lbl_To)
            Me.Controls.Add(Me.lbl_From)
            Me.Controls.Add(Me.dtp_To)
            Me.Controls.Add(Me.dtp_From)
            Me.Controls.Add(Me.lbl_RptInfo)
            Me.Name = "Report_PaymentsReceived"
            Me.Text = "Reports: Payments Received"
            Me.tc_Report.ResumeLayout(False)
            Me.tp_RepView.ResumeLayout(False)
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
        Friend WithEvents lbl_To As System.Windows.Forms.Label
        Friend WithEvents lbl_From As System.Windows.Forms.Label
        Friend WithEvents dtp_To As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtp_From As System.Windows.Forms.DateTimePicker
        Friend WithEvents btn_BuildRpt As System.Windows.Forms.Button
        Friend WithEvents tc_Report As System.Windows.Forms.TabControl
        Friend WithEvents tp_RepView As System.Windows.Forms.TabPage
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents rdo_BetweenDates As System.Windows.Forms.RadioButton
        Friend WithEvents rdo_OnDate As System.Windows.Forms.RadioButton
        Friend WithEvents dtp_SingleDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents rdo_Batch As System.Windows.Forms.RadioButton
        Friend WithEvents cmb_BatchHistory As System.Windows.Forms.ComboBox
        Friend WithEvents Ds_Reporting As TrashCash.ds_Reporting
    End Class
End Namespace