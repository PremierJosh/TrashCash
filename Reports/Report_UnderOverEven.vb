Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_UnderOverEven

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor

            Report_DataSet = _home.Reporting.Report_UnderOverEven(ck_IncludeInactive.Checked)
            ' create report
            Dim report As New r_UnderOverEven
            ' set ds
            report.SetDataSource(Report_DataSet)
            ' pass to viewer
            CrystalReportViewer.ReportSource = report
            CrystalReportViewer.Refresh()

            ' reset cursor
            Cursor = Cursors.Default
        End Sub

        Private ReadOnly _home As TrashCashHome
        Public Sub New(ByRef homeForm As TrashCashHome)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _home = HomeForm
        End Sub
    End Class
End Namespace