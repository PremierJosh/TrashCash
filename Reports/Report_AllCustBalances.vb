Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_AllCustBalances

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor
            If (mtb_DaysPastDue.TextLength > 0) Then
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


        ' var to keep track of last clicked
        Private _lastCustClickedIndex As Integer
        Private Sub dg_Customers_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_Customers.CellClick
            If (_lastCustClickedIndex <> e.RowIndex) Then
                _lastCustClickedIndex = e.RowIndex

                ' TODO: fill other DG with assoc rows

            End If
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