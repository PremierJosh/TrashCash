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
            Me.lbl_Days = New System.Windows.Forms.Label()
            Me.btn_BuildRpt = New System.Windows.Forms.Button()
            Me.ck_ActiveOnly = New System.Windows.Forms.CheckBox()
            Me.nud_MindDays = New System.Windows.Forms.NumericUpDown()
            Me.Ds_Reporting = New TrashCash.ds_Reporting()
            Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lbl_RptInfo = New System.Windows.Forms.Label()
            CType(Me.nud_MindDays, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lbl_Days
            '
            Me.lbl_Days.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.lbl_Days.AutoSize = True
            Me.lbl_Days.Location = New System.Drawing.Point(278, 32)
            Me.lbl_Days.Name = "lbl_Days"
            Me.lbl_Days.Size = New System.Drawing.Size(214, 13)
            Me.lbl_Days.TabIndex = 2
            Me.lbl_Days.Text = "Minimum days past due on an open invoice:"
            '
            'btn_BuildRpt
            '
            Me.btn_BuildRpt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.btn_BuildRpt.Location = New System.Drawing.Point(475, 53)
            Me.btn_BuildRpt.Name = "btn_BuildRpt"
            Me.btn_BuildRpt.Size = New System.Drawing.Size(75, 23)
            Me.btn_BuildRpt.TabIndex = 5
            Me.btn_BuildRpt.Text = "Build Report"
            Me.btn_BuildRpt.UseVisualStyleBackColor = True
            '
            'ck_ActiveOnly
            '
            Me.ck_ActiveOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.ck_ActiveOnly.AutoSize = True
            Me.ck_ActiveOnly.Checked = True
            Me.ck_ActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ck_ActiveOnly.Location = New System.Drawing.Point(310, 57)
            Me.ck_ActiveOnly.Name = "ck_ActiveOnly"
            Me.ck_ActiveOnly.Size = New System.Drawing.Size(132, 17)
            Me.ck_ActiveOnly.TabIndex = 6
            Me.ck_ActiveOnly.Text = "Active Customers Only"
            Me.ck_ActiveOnly.UseVisualStyleBackColor = True
            '
            'nud_MindDays
            '
            Me.nud_MindDays.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.nud_MindDays.Location = New System.Drawing.Point(498, 30)
            Me.nud_MindDays.Name = "nud_MindDays"
            Me.nud_MindDays.Size = New System.Drawing.Size(52, 20)
            Me.nud_MindDays.TabIndex = 7
            Me.nud_MindDays.Value = New Decimal(New Integer() {1, 0, 0, 0})
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
            Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 91)
            Me.CrystalReportViewer.Name = "CrystalReportViewer"
            Me.CrystalReportViewer.Size = New System.Drawing.Size(892, 471)
            Me.CrystalReportViewer.TabIndex = 8
            Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.lbl_RptInfo)
            Me.Panel1.Controls.Add(Me.ck_ActiveOnly)
            Me.Panel1.Controls.Add(Me.lbl_Days)
            Me.Panel1.Controls.Add(Me.nud_MindDays)
            Me.Panel1.Controls.Add(Me.btn_BuildRpt)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(892, 91)
            Me.Panel1.TabIndex = 9
            '
            'lbl_RptInfo
            '
            Me.lbl_RptInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.lbl_RptInfo.Location = New System.Drawing.Point(0, 0)
            Me.lbl_RptInfo.Name = "lbl_RptInfo"
            Me.lbl_RptInfo.Size = New System.Drawing.Size(892, 23)
            Me.lbl_RptInfo.TabIndex = 8
            Me.lbl_RptInfo.Text = "This Report will generate a list of all Customers who have an outstanding balance" & _
        ", listing the Invoices that are still open."
            Me.lbl_RptInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Report_AllCustBalances
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(892, 562)
            Me.Controls.Add(Me.CrystalReportViewer)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "Report_AllCustBalances"
            Me.Text = "Report: All Customer Balances"
            CType(Me.nud_MindDays, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lbl_Days As System.Windows.Forms.Label
        Friend WithEvents btn_BuildRpt As System.Windows.Forms.Button
        Friend WithEvents ck_ActiveOnly As System.Windows.Forms.CheckBox
        Friend WithEvents nud_MindDays As System.Windows.Forms.NumericUpDown
        Friend WithEvents Ds_Reporting As TrashCash.ds_Reporting
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lbl_RptInfo As System.Windows.Forms.Label
    End Class
End Namespace