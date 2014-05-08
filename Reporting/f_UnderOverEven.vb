Public Class f_UnderOverEven

    Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
        Me.Cursor = Cursors.WaitCursor

        Me.Report_DataSet = _home.Reporting.Report_UnderOverEven(ck_IncludeInactive.Checked)
        ' create report
        Dim report As New r_UnderOverEven
        ' set ds
        report.SetDataSource(Me.Report_DataSet)
        ' pass to viewer
        CrystalReportViewer.ReportSource = report
        CrystalReportViewer.Refresh()

        ' reset cursor
        Me.Cursor = Cursors.Default
    End Sub

    Private _home As TrashCash_Home
    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _home = HomeForm
    End Sub
End Class