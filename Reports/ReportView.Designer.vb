<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportView))
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pnl_Btm = New System.Windows.Forms.Panel()
        Me.lbl_ReportType = New System.Windows.Forms.Label()
        Me.btn_BuildReport = New System.Windows.Forms.Button()
        Me.dtp_From = New System.Windows.Forms.DateTimePicker()
        Me.dtp_To = New System.Windows.Forms.DateTimePicker()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.Cmb_ReportType = New TrashCash.cmb_ReportType()
        Me.pnl_TopSpacer = New System.Windows.Forms.Panel()
        Me.pnl_Top = New System.Windows.Forms.Panel()
        Me.pnl_Btm.SuspendLayout()
        Me.pnl_TopSpacer.SuspendLayout()
        Me.pnl_Top.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.Size = New System.Drawing.Size(1009, 484)
        Me.CrystalReportViewer.TabIndex = 0
        '
        'pnl_Btm
        '
        Me.pnl_Btm.Controls.Add(Me.CrystalReportViewer)
        Me.pnl_Btm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Btm.Location = New System.Drawing.Point(0, 92)
        Me.pnl_Btm.Name = "pnl_Btm"
        Me.pnl_Btm.Size = New System.Drawing.Size(1009, 484)
        Me.pnl_Btm.TabIndex = 1
        '
        'lbl_ReportType
        '
        Me.lbl_ReportType.AutoSize = True
        Me.lbl_ReportType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ReportType.Location = New System.Drawing.Point(50, 16)
        Me.lbl_ReportType.Name = "lbl_ReportType"
        Me.lbl_ReportType.Size = New System.Drawing.Size(47, 15)
        Me.lbl_ReportType.TabIndex = 3
        Me.lbl_ReportType.Text = "Report:"
        '
        'btn_BuildReport
        '
        Me.btn_BuildReport.AutoSize = True
        Me.btn_BuildReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_BuildReport.Location = New System.Drawing.Point(375, 13)
        Me.btn_BuildReport.Name = "btn_BuildReport"
        Me.btn_BuildReport.Size = New System.Drawing.Size(75, 23)
        Me.btn_BuildReport.TabIndex = 4
        Me.btn_BuildReport.Text = "Build Report"
        Me.btn_BuildReport.UseVisualStyleBackColor = True
        '
        'dtp_From
        '
        Me.dtp_From.Location = New System.Drawing.Point(765, 10)
        Me.dtp_From.Name = "dtp_From"
        Me.dtp_From.Size = New System.Drawing.Size(200, 20)
        Me.dtp_From.TabIndex = 5
        '
        'dtp_To
        '
        Me.dtp_To.Location = New System.Drawing.Point(765, 36)
        Me.dtp_To.Name = "dtp_To"
        Me.dtp_To.Size = New System.Drawing.Size(200, 20)
        Me.dtp_To.TabIndex = 6
        '
        'lbl_From
        '
        Me.lbl_From.AutoSize = True
        Me.lbl_From.Location = New System.Drawing.Point(726, 13)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(33, 13)
        Me.lbl_From.TabIndex = 7
        Me.lbl_From.Text = "From:"
        '
        'lbl_To
        '
        Me.lbl_To.AutoSize = True
        Me.lbl_To.Location = New System.Drawing.Point(736, 40)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(23, 13)
        Me.lbl_To.TabIndex = 8
        Me.lbl_To.Text = "To:"
        '
        'Cmb_ReportType
        '
        Me.Cmb_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cmb_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cmb_ReportType.DisplayMember = "ReportName"
        Me.Cmb_ReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ReportType.FormattingEnabled = True
        Me.Cmb_ReportType.Location = New System.Drawing.Point(98, 13)
        Me.Cmb_ReportType.Name = "Cmb_ReportType"
        Me.Cmb_ReportType.Size = New System.Drawing.Size(258, 21)
        Me.Cmb_ReportType.TabIndex = 2
        Me.Cmb_ReportType.ValueMember = "ReportID"
        '
        'pnl_TopSpacer
        '
        Me.pnl_TopSpacer.Controls.Add(Me.pnl_Top)
        Me.pnl_TopSpacer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_TopSpacer.Location = New System.Drawing.Point(0, 0)
        Me.pnl_TopSpacer.Name = "pnl_TopSpacer"
        Me.pnl_TopSpacer.Padding = New System.Windows.Forms.Padding(15)
        Me.pnl_TopSpacer.Size = New System.Drawing.Size(1009, 92)
        Me.pnl_TopSpacer.TabIndex = 9
        '
        'pnl_Top
        '
        Me.pnl_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Top.Controls.Add(Me.lbl_To)
        Me.pnl_Top.Controls.Add(Me.Cmb_ReportType)
        Me.pnl_Top.Controls.Add(Me.lbl_From)
        Me.pnl_Top.Controls.Add(Me.lbl_ReportType)
        Me.pnl_Top.Controls.Add(Me.dtp_To)
        Me.pnl_Top.Controls.Add(Me.btn_BuildReport)
        Me.pnl_Top.Controls.Add(Me.dtp_From)
        Me.pnl_Top.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Top.Location = New System.Drawing.Point(15, 15)
        Me.pnl_Top.Name = "pnl_Top"
        Me.pnl_Top.Size = New System.Drawing.Size(979, 62)
        Me.pnl_Top.TabIndex = 0
        '
        'ReportView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 576)
        Me.Controls.Add(Me.pnl_TopSpacer)
        Me.Controls.Add(Me.pnl_Btm)
        Me.Name = "ReportView"
        Me.Text = "ReportView"
        Me.pnl_Btm.ResumeLayout(False)
        Me.pnl_TopSpacer.ResumeLayout(False)
        Me.pnl_Top.ResumeLayout(False)
        Me.pnl_Top.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents pnl_Btm As System.Windows.Forms.Panel
    Friend WithEvents Cmb_ReportType As TrashCash.cmb_ReportType
    Friend WithEvents lbl_ReportType As System.Windows.Forms.Label
    Friend WithEvents btn_BuildReport As System.Windows.Forms.Button
    Friend WithEvents dtp_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_From As System.Windows.Forms.Label
    Friend WithEvents lbl_To As System.Windows.Forms.Label
    Friend WithEvents pnl_TopSpacer As System.Windows.Forms.Panel
    Friend WithEvents pnl_Top As System.Windows.Forms.Panel
End Class
