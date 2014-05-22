Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling

Public Class f_AllCustBalances

    Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
        Me.Cursor = Cursors.WaitCursor
        If (mtb_DaysPastDue.TextLength > 0) Then
            ' build ds
            Me.Report_DataSet = _home.Reporting.Report_AllCustomerBalances(mtb_DaysPastDue.Text, ck_IncludeInactive.Checked)
        End If
        ' create report
        Dim report As New r_AllCustBalances
        ' set ds
        report.SetDataSource(Me.Report_DataSet)
        ' pass to viewer
        CrystalReportViewer.ReportSource = report
        CrystalReportViewer.Refresh()

        Me.Cursor = Cursors.Default
    End Sub


    ' var to keep track of last clicked
    Private lastCustClickedIndex As Integer
    Private Sub dg_Customers_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_Customers.CellClick
        If (lastCustClickedIndex <> e.RowIndex) Then
            lastCustClickedIndex = e.RowIndex

            ' TODO: fill other DG with assoc rows

        End If
    End Sub

    Private _home As TrashCashHome
    Public Sub New(ByRef HomeForm As TrashCashHome)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _home = HomeForm
    End Sub
End Class