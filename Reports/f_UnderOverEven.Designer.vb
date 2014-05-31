<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_UnderOverEven
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
        Me.Report_DataSet = New TrashCash.Report_DataSet()
        CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(116, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(450, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This report is a list of all Customers, grouped by those that owe, have a credit," & _
    " or zero balance."
        '
        'btn_BuildRpt
        '
        Me.btn_BuildRpt.Location = New System.Drawing.Point(354, 25)
        Me.btn_BuildRpt.Name = "btn_BuildRpt"
        Me.btn_BuildRpt.Size = New System.Drawing.Size(75, 23)
        Me.btn_BuildRpt.TabIndex = 1
        Me.btn_BuildRpt.Text = "Build Report"
        Me.btn_BuildRpt.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 70)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.Size = New System.Drawing.Size(760, 430)
        Me.CrystalReportViewer.TabIndex = 2
        '
        'ck_IncludeInactive
        '
        Me.ck_IncludeInactive.AutoSize = True
        Me.ck_IncludeInactive.Location = New System.Drawing.Point(183, 29)
        Me.ck_IncludeInactive.Name = "ck_IncludeInactive"
        Me.ck_IncludeInactive.Size = New System.Drawing.Size(154, 17)
        Me.ck_IncludeInactive.TabIndex = 7
        Me.ck_IncludeInactive.Text = "Include Inactive Customers"
        Me.ck_IncludeInactive.UseVisualStyleBackColor = True
        '
        'Report_DataSet
        '
        Me.Report_DataSet.DataSetName = "Report_DataSet"
        Me.Report_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'f_UnderOverEven
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 500)
        Me.Controls.Add(Me.ck_IncludeInactive)
        Me.Controls.Add(Me.CrystalReportViewer)
        Me.Controls.Add(Me.btn_BuildRpt)
        Me.Controls.Add(Me.Label1)
        Me.Name = "f_UnderOverEven"
        Me.Text = "Under/Over/Even Report"
        CType(Me.Report_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_BuildRpt As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ck_IncludeInactive As System.Windows.Forms.CheckBox
    Friend WithEvents Report_DataSet As TrashCash.Report_DataSet
End Class
