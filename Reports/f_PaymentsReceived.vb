Public Class f_PaymentsReceived

    Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ta As New Report_DataSetTableAdapters.ReceivedPaymentsOnDayTableAdapter
        Me.Report_DataSet.Clear()

        ' seeing if its batch id
        If (rdo_Batch.Checked = True) Then

            ' fill ds
            ta.FillByBatchID(Me.Report_DataSet.ReceivedPaymentsOnDay, Cmb_BatchPaymentHistory.SelectedValue)
            ' create header row for date range display
            Dim hRow As Report_DataSet.ReportHeadersRow = Me.Report_DataSet.ReportHeaders.NewReportHeadersRow
            hRow.HeaderText = "For Batch: " & Cmb_BatchPaymentHistory.GetItemText(Cmb_BatchPaymentHistory.SelectedItem).ToString
            Me.Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)
        End If

        If (rdo_BetweenDates.Checked = True) Then
            ' fill ds
            ta.FillByDateRec(Me.Report_DataSet.ReceivedPaymentsOnDay, dtp_From.Value.Date, dtp_To.Value.Date)

            ' create header row for date range display
            Dim hRow As Report_DataSet.ReportHeadersRow = Me.Report_DataSet.ReportHeaders.NewReportHeadersRow
            hRow.HeaderText = "Between: " & dtp_From.Value.Date & " and " & dtp_To.Value.Date
            Me.Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)
        End If

        If (rdo_OnDate.Checked = True) Then
            ta.FillBySingleDate(Me.Report_DataSet.ReceivedPaymentsOnDay, dtp_SingleDate.Value.Date)

            ' create header row for date range display
            Dim hRow As Report_DataSet.ReportHeadersRow = Me.Report_DataSet.ReportHeaders.NewReportHeadersRow
            hRow.HeaderText = "On Date: " & dtp_SingleDate.Value.Date
            Me.Report_DataSet.ReportHeaders.AddReportHeadersRow(hRow)
        End If

        ' create report
        Dim report As New r_PaymentsReceived
        ' set ds
        report.SetDataSource(Me.Report_DataSet)
        ' pass to viewer
        CrystalReportViewer.ReportSource = report
        CrystalReportViewer.Refresh()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rdo_Batch_Click(sender As System.Object, e As System.EventArgs) Handles rdo_OnDate.Click, rdo_Batch.Click, rdo_BetweenDates.Click
        If (rdo_Batch.Checked = True) Then
            Cmb_BatchPaymentHistory.Enabled = True
        Else
            Cmb_BatchPaymentHistory.Enabled = False
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
End Class