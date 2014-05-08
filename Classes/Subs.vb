Public Class Subs

    Public Shared Function TextBoxCheck(ByRef coll As Collection, _
                                        Optional ByRef lengthCheck As Boolean = False, _
                                        Optional ByRef intCheck As Boolean = False)
        Dim err As Integer = 0

        For Each box As TextBox In coll

            If (lengthCheck = True) Then
                If (box.TextLength = 0) Then
                    err = +1
                End If

            ElseIf (intCheck = True) Then

                Dim result As Decimal = 0.0
                Decimal.TryParse(box.Text, result)
                If (result <> 0.0) Then
                    err += 1
                End If

            End If

        Next box

        If err > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Sub ColorRows_RecurringService(ByRef grid As DataGridView)
        ' loop through all grid rows
        For i As Integer = 0 To grid.RowCount - 1
            Dim row As DataRowView = grid.Rows(i).DataBoundItem
            ' checking end date for colorization
            If (IsDBNull(row.Item("RecurringServiceEndDate")) = False) Then
                ' end date is NOT NULL
                If (row.Item("RecurringServiceEndDate") < Date.Now.Date) Then
                    ' service has ended
                    grid.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Maroon
                ElseIf (row.Item("RecurringServiceEndDate") >= Date.Now.Date) Then
                    ' service has end date but it hasnt passed yet
                    grid.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.DarkOrange
                End If
            Else
                ' end date is NULL
                grid.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.MediumAquamarine
            End If
        Next i
    End Sub

    Public Shared Sub ColorRows_QBInvoices(ByRef grid As DataGridView)
        ' loop through all grid rows
        For i As Integer = 0 To grid.RowCount - 1
            Dim row As DataRowView = grid.Rows(i).DataBoundItem
            If (row IsNot Nothing) Then
                ' checking if due date is before today
                If (row.Item("InvoiceDueDate") <= Date.Now.Date) Then
                    grid.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Maroon
                    'ElseIf (row.InvoiceDueDate >= Date.Now.Date) Then
                    '    grid.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                    '    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.MediumAquamarine
                End If
            End If
        Next i
    End Sub
End Class
