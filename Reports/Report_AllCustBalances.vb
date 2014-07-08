Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_AllCustBalances

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor
            If (nud_MindDays.Value > 0) Then
                ' build ds
                Report_DataSet = _home.Reporting.Report_AllCustomerBalances(mtb_DaysPastDue.Text, ck_IncludeInactive.Checked)
            End If
            ' create report
            Dim report As New r_AllCustBalances
            ' set ds
            report.SetDataSource(Report_DataSet)
            ' pass to viewer
            CrystalReportViewer.ReportSource = report
            CrystalReportViewer.Refresh()

            Cursor = Cursors.Default
        End Sub

        Private Sub ReportFoo()
            Dim resp As IResponse = QBRequests.CustomerQuery(activeOnly:=ck_ActiveOnly.Checked)
            If (resp.StatusCode = 0) Then
                Dim custRetList As ICustomerRetList = resp.Detail
                For c = 0 To custRetList.Count - 1
                    Dim cust As ICustomerRet = custRetList.GetAt(c)


                Next
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If
        End Sub

        ' var to keep track of last clicked
        Private _lastCustClickedIndex As Integer
        Private Sub dg_Customers_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_Customers.CellClick
            If (_lastCustClickedIndex <> e.RowIndex) Then
                _lastCustClickedIndex = e.RowIndex

                ' TODO: fill other DG with assoc rows

            End If
        End Sub



    End Class
End Namespace