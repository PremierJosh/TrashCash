Public Class CustomerSearch

    ' event to let customer form to switch
    Friend Event CustomerSwitch(ByVal customerNumber As Integer)

    Private Sub btn_Search_Click(sender As System.Object, e As System.EventArgs) Handles btn_Search.Click
        Dim searchString As String = Trim(tb_Search.Text)

        If (searchString <> "") Then
            CustomerSearch_AddressTableAdapter.Fill(Ds_Customer.CustomerSearch_Address, searchString)
        End If
    End Sub

    Private Sub dg_SearchRet_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_SearchRet.CellDoubleClick
        ' if selected rows is more than 1, deselect all and select the one double clicked
        If (dg_SearchRet.SelectedRows.Count > 1) Then
            For Each row As DataGridViewRow In dg_SearchRet.SelectedRows
                row.Selected = False
            Next
            dg_SearchRet.Rows(e.RowIndex).Selected = True
        End If

        Dim dvRow As ds_Customer.CustomerSearch_AddressRow = CType(dg_SearchRet.SelectedRows(0).DataBoundItem, DataRowView).Row
        RaiseEvent CustomerSwitch(dvRow.CustomerNumber)
    End Sub

  End Class