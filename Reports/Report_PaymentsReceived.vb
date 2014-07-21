Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_PaymentsReceived

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor
            Dim ta As New ds_ReportingTableAdapters.ReceivedPaymentsOnDayTableAdapter
            Ds_Reporting.ReceivedPaymentsOnDay.Clear()
            Ds_Reporting.ReportHeaders.Clear()

            ' seeing if its batch id
            If (rdo_Batch.Checked = True) Then

                ' fill ds
                ta.FillByBatchID(Ds_Reporting.ReceivedPaymentsOnDay, cmb_BatchHistory.SelectedValue)
                ' create header row for date range display
                Dim hRow As ds_Reporting.ReportHeadersRow = Ds_Reporting.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "For Batch: " & cmb_BatchHistory.Text
                Ds_Reporting.ReportHeaders.AddReportHeadersRow(hRow)
            End If

            If (rdo_BetweenDates.Checked = True) Then
                ' fill ds
                ta.FillByDateRec(Ds_Reporting.ReceivedPaymentsOnDay, dtp_From.Value.Date, dtp_To.Value.Date)

                ' create header row for date range display
                Dim hRow As ds_Reporting.ReportHeadersRow = Ds_Reporting.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "Between: " & dtp_From.Value.Date & " and " & dtp_To.Value.Date
                Ds_Reporting.ReportHeaders.AddReportHeadersRow(hRow)
            End If

            If (rdo_OnDate.Checked = True) Then
                ta.FillBySingleDate(Ds_Reporting.ReceivedPaymentsOnDay, dtp_SingleDate.Value.Date)

                ' create header row for date range display
                Dim hRow As ds_Reporting.ReportHeadersRow = Ds_Reporting.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "On Date: " & dtp_SingleDate.Value.Date
                Ds_Reporting.ReportHeaders.AddReportHeadersRow(hRow)
            End If

            If (Ds_Reporting.ReceivedPaymentsOnDay.Rows.Count > 0) Then
                tc_Report.Visible = True

                ' create report
                Dim report As New r_PaymentsReceived
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

        Private Sub rdo_Batch_Click(sender As System.Object, e As System.EventArgs) Handles rdo_OnDate.Click, rdo_Batch.Click, rdo_BetweenDates.Click
            If (rdo_Batch.Checked = True) Then
                cmb_BatchHistory.Enabled = True
            Else
                cmb_BatchHistory.Enabled = False
            End If

            If (rdo_BetweenDates.Checked = True) Then
                dtp_From.Enabled = True
                dtp_To.Enabled = True
            Else
                dtp_From.Enabled = False
                dtp_To.Enabled = False
            End If

            If (rdo_OnDate.Checked = True) Then
                dtp_SingleDate.Enabled = True
            Else
                dtp_SingleDate.Enabled = False
            End If
        End Sub

        Private Sub f_PaymentsReceived_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Using ta As New ds_ReportingTableAdapters.Batch_Payments_HistoryTableAdapter
                ta.Fill(Ds_Reporting.Batch_Payments_History)
            End Using
            
        End Sub
    End Class
End Namespace