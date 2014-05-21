Public Class UC_PreparedItems

    ' property refrence
    Private custNum As Decimal
    ' properties
    Public Property CurrentCustomer() As Decimal
        Get
            Return custNum
        End Get
        Set(ByVal value As Decimal)
            If (value > 0) Then
                ' refrence
                custNum = value
                ' fill Working tables
                ' Me.WorkingPaymentsTableAdapter.FillByID(Me.DataSet.WorkingPayments, "Number", custNum)
            End If
        End Set
    End Property

    Private Sub dg_PrepInvoices_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_PrepInvoices.CellContentClick
        If (e.ColumnIndex = 3) Then
            Try
                Dim row As DataRowView = dg_PrepInvoices.Rows(dg_PrepInvoices.SelectedRows(0).Index).DataBoundItem
                'Dim actualRow As DataSet.WorkingInvoiceRow = row.Row

                If (dg_PrepInvoices.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue = True) Then
                    ' Me.WorkingInvoiceTableAdapter.UpdatePrint(actualRow.WorkingInvoiceID, "True")
                Else
                    'Me.WorkingInvoiceTableAdapter.UpdatePrint(actualRow.WorkingInvoiceID, "False")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

End Class
