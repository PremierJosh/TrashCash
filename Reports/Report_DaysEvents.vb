Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_DaysEvents

        Private Sub btn_GenReport_Click(sender As System.Object, e As System.EventArgs) Handles btn_GenReport.Click
            UseWaitCursor = True

            ' create report
            Dim report As New r_DaysEvents
            ' fill ds
            Report_DaysEventsTableAdapter.Fill(Report_DataSet.Report_DaysEvents, dtp_Date.Value.Date)

            ' making header row
            Dim hRow As DS_Reports.ReportHeadersRow = Report_DataSet.ReportHeaders.NewReportHeadersRow
            hRow.HeaderText = "Days Events for: " & dtp_Date.Value.Date
            Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)

            ' set ds
            report.SetDataSource(Report_DataSet)
            ' pass to viewer
            CrystalReportViewer.ReportSource = report
            CrystalReportViewer.Refresh()

            UseWaitCursor = False
        End Sub
    End Class
End Namespace