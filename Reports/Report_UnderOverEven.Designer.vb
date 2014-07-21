Namespace Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Report_UnderOverEven
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btn_BuildRpt = New System.Windows.Forms.Button()
            Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
            Me.ck_IncludeInactive = New System.Windows.Forms.CheckBox()
            Me.Ds_Reporting = New TrashCash.ds_Reporting()
            Me.Panel1 = New System.Windows.Forms.Panel()
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(912, 26)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "This report is a list of all Customers, grouped by those that owe money, have a c" & _
        "redit, have a zero balance."
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btn_BuildRpt
            '
            Me.btn_BuildRpt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.btn_BuildRpt.Location = New System.Drawing.Point(507, 29)
            Me.btn_BuildRpt.Name = "btn_BuildRpt"
            Me.btn_BuildRpt.Size = New System.Drawing.Size(75, 23)
            Me.btn_BuildRpt.TabIndex = 1
            Me.btn_BuildRpt.Text = "Build Report"
            Me.btn_BuildRpt.UseVisualStyleBackColor = True
            '
            'CrystalReportViewer
            '
            Me.CrystalReportViewer.ActiveViewIndex = -1
            Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
            Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 70)
            Me.CrystalReportViewer.Name = "CrystalReportViewer"
            Me.CrystalReportViewer.Size = New System.Drawing.Size(912, 492)
            Me.CrystalReportViewer.TabIndex = 2
            Me.CrystalReportViewer.Visible = False
            '
            'ck_IncludeInactive
            '
            Me.ck_IncludeInactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
            Me.ck_IncludeInactive.AutoSize = True
            Me.ck_IncludeInactive.Location = New System.Drawing.Point(336, 33)
            Me.ck_IncludeInactive.Name = "ck_IncludeInactive"
            Me.ck_IncludeInactive.Size = New System.Drawing.Size(154, 17)
            Me.ck_IncludeInactive.TabIndex = 7
            Me.ck_IncludeInactive.Text = "Include Inactive Customers"
            Me.ck_IncludeInactive.UseVisualStyleBackColor = True
            '
            'Ds_Reporting
            '
            Me.Ds_Reporting.DataSetName = "ds_Reporting"
            Me.Ds_Reporting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.ck_IncludeInactive)
            Me.Panel1.Controls.Add(Me.btn_BuildRpt)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(912, 70)
            Me.Panel1.TabIndex = 8
            '
            'Report_UnderOverEven
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(912, 562)
            Me.Controls.Add(Me.CrystalReportViewer)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "Report_UnderOverEven"
            Me.Text = "Under/Over/Even Report"
            CType(Me.Ds_Reporting, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btn_BuildRpt As System.Windows.Forms.Button
        Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents ck_IncludeInactive As System.Windows.Forms.CheckBox
        Friend WithEvents Ds_Reporting As TrashCash.ds_Reporting
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
    End Class
End Namespace