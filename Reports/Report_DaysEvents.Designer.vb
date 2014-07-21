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
            Me.dtp_Date = New System.Windows.Forms.DateTimePicker()
            Me.btn_GenReport = New System.Windows.Forms.Button()
            Me.Ds_Reporting = New TrashCash.ds_Reporting()
            Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lbl_RptInfo = New System.Windows.Forms.Label()
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dtp_Date
            '
            Me.dtp_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.dtp_Date.Location = New System.Drawing.Point(366, 26)
            Me.dtp_Date.Name = "dtp_Date"
            Me.dtp_Date.Size = New System.Drawing.Size(200, 20)
            Me.dtp_Date.TabIndex = 4
            '
            'btn_GenReport
            '
            Me.btn_GenReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.btn_GenReport.Location = New System.Drawing.Point(419, 52)
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
            'CrystalReportViewer
            '
            Me.CrystalReportViewer.ActiveViewIndex = -1
            Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
            Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 100)
            Me.CrystalReportViewer.Name = "CrystalReportViewer"
            Me.CrystalReportViewer.Size = New System.Drawing.Size(939, 474)
            Me.CrystalReportViewer.TabIndex = 6
            Me.CrystalReportViewer.Visible = False
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.lbl_RptInfo)
            Me.Panel1.Controls.Add(Me.dtp_Date)
            Me.Panel1.Controls.Add(Me.btn_GenReport)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(939, 100)
            Me.Panel1.TabIndex = 7
            '
            'lbl_RptInfo
            '
            Me.lbl_RptInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_RptInfo.Location = New System.Drawing.Point(0, 0)
            Me.lbl_RptInfo.Name = "lbl_RptInfo"
            Me.lbl_RptInfo.Size = New System.Drawing.Size(939, 23)
            Me.lbl_RptInfo.TabIndex = 6
            Me.lbl_RptInfo.Text = "This report shows all upcoming new Recurring Services and special pickups for the" & _
        " chosen day."
            Me.lbl_RptInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Report_DaysEvents
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(939, 574)
            Me.Controls.Add(Me.CrystalReportViewer)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "Report_DaysEvents"
            Me.Text = "Report: Days Events"
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dtp_Date As System.Windows.Forms.DateTimePicker
        Friend WithEvents btn_GenReport As System.Windows.Forms.Button
        Friend WithEvents Ds_Reporting As TrashCash.ds_Reporting
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
    End Class
End Namespace