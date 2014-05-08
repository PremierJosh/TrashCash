Public Class UC_CustomerNotes
    ' property refrence
    Private custNum As Decimal
    ' note form ref
    Friend WithEvents _Note As CustomerNote
    ' properties
    Public Property CurrentCustomer As Decimal
        Get
            Return custNum
        End Get
        Set(ByVal value As Decimal)
            If (value > 0) Then
                ' refrence
                custNum = value

                ' fill Note grid
                Me.CustomerNotesTableAdapter.Fill(Me.Ds_Display.CustomerNotes, value)
            End If
        End Set
    End Property

    Private Sub dg_CustNotes_DoubleClick(sender As System.Object, e As System.EventArgs)
        Dim noteText As String = InputBox("Note:", "Quick Add Customer Note")
        If (Trim(noteText) <> "") Then
            Try
                Me.CustomerNotesTableAdapter.CustomerNotes_Insert(CurrentCustomer, noteText)
                ' refill grid
                Me.CustomerNotesTableAdapter.Fill(Me.Ds_Display.CustomerNotes, CurrentCustomer)
            Catch ex As Exception
                MessageBox.Show("Error inserting New Customer Note", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
