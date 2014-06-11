Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_PaymentsReceived

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor
            Dim ta As New ReceivedPaymentsOnDayTableAdapter
            Report_DataSet.Clear()

            ' seeing if its batch id
            If (rdo_Batch.Checked = True) Then

                ' fill ds
                ta.FillByBatchID(Report_DataSet.ReceivedPaymentsOnDay, cmb_BatchHistory.SelectedValue)
                ' create header row for date range display
                Dim hRow As DS_Reports.ReportHeadersRow = Report_DataSet.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "For Batch: " & cmb_BatchHistory.GetItemText(cmb_BatchHistory.SelectedItem).ToString
                Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)
            End If

            If (rdo_BetweenDates.Checked = True) Then
                ' fill ds
                ta.FillByDateRec(Report_DataSet.ReceivedPaymentsOnDay, dtp_From.Value.Date, dtp_To.Value.Date)

                ' create header row for date range display
                Dim hRow As DS_Reports.ReportHeadersRow = Report_DataSet.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "Between: " & dtp_From.Value.Date & " and " & dtp_To.Value.Date
                Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)
            End If

            If (rdo_OnDate.Checked = True) Then
                ta.FillBySingleDate(Report_DataSet.ReceivedPaymentsOnDay, dtp_SingleDate.Value.Date)

                ' create header row for date range display
                Dim hRow As DS_Reports.ReportHeadersRow = Report_DataSet.ReportHeaders.NewReportHeadersRow
                hRow.HeaderText = "On Date: " & dtp_SingleDate.Value.Date
                Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)
            End If

            ' create report
            Dim report As New r_PaymentsReceived
            ' set ds
            report.SetDataSource(Report_DataSet)
            ' pass to viewer
            CrystalReportViewer.ReportSource = report
            CrystalReportViewer.Refresh()

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
            BatchPayments_ListTableAdapter.Fill(Report_DataSet.BatchPayments_List)

        End Sub
    End Class
End Namespace