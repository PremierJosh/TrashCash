Namespace Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Report_DaysEvents
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
            Me.lbl_RptInfo = New System.Windows.Forms.Label()
            Me.dtp_Date = New System.Windows.Forms.DateTimePicker()
            Me.btn_GenReport = New System.Windows.Forms.Button()
            Me.Ds_Reporting = New TrashCash.ds_Reporting()
            Me.tc_Report.SuspendLayout()
            Me.tp_RepView.SuspendLayout()
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tc_Report
            '
            Me.tc_Report.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tc_Report.Controls.Add(Me.tp_RepView)
            Me.tc_Report.Location = New System.Drawing.Point(0, 90)
            Me.tc_Report.Multiline = True
            Me.tc_Report.Name = "tc_Report"
            Me.tc_Report.SelectedIndex = 0
            Me.tc_Report.Size = New System.Drawing.Size(939, 484)
            Me.tc_Report.TabIndex = 2
            Me.tc_Report.Visible = False
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
            'Ds_Reporting
            '
            Me.Ds_Reporting.DataSetName = "ds_Reporting"
            Me.Ds_Reporting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Report_DaysEvents
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(939, 574)
            Me.Controls.Add(Me.btn_GenReport)
            Me.Controls.Add(Me.dtp_Date)
            Me.Controls.Add(Me.lbl_RptInfo)
            Me.Controls.Add(Me.tc_Report)
            Me.Name = "Report_DaysEvents"
            Me.Text = "Report: Days Events"
            Me.tc_Report.ResumeLayout(False)
            Me.tp_RepView.ResumeLayout(False)
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tc_Report As System.Windows.Forms.TabControl
        Friend WithEvents tp_RepView As System.Windows.Forms.TabPage
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
        Friend WithEvents dtp_Date As System.Windows.Forms.DateTimePicker
        Friend WithEvents btn_GenReport As System.Windows.Forms.Button
        Friend WithEvents Ds_Reporting As TrashCash.ds_Reporting
    End Class
End Namespace