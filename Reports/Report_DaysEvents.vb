Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_DaysEvents

        Private Sub btn_GenReport_Click(sender As System.Object, e As System.EventArgs) Handles btn_GenReport.Click
            Cursor = Cursors.WaitCursor

            
            ' create report
            Dim report As New r_DaysEvents
            ' fill ds
            Using ta As New ds_ReportingTableAdapters.Report_DaysEventsTableAdapter
                ta.Fill(Ds_Reporting.Report_DaysEvents, dtp_Date.Value.Date)
            End Using

            If (Ds_Reporting.Report_DaysEvents.Rows.Count > 0) Then
                tc_Report.Visible = True

                ' making header row
                Dim hRow As ds_Reporting.ReportHeadersRow = Ds_Reporting.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "Days Events for: " & dtp_Date.Value.Date
                Ds_Reporting.ReportHeaders.AddReportHeadersRow(hRow)

                ' set ds
                report.SetDataSource(Ds_Reporting)
                ' pass to viewer
                CrystalReportViewer.ReportSource = report
                CrystalReportViewer.Refresh()
            Else
                tc_Report.Visible = False
            End If
            
            Cursor = Cursors.Default
        End Sub
    End Class
End Namespace