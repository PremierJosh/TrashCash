Public Class RecSrvcNote

    ' form properties
    Public Property srvcRow As DataSet.RecurringServiceRow

    ' CLOSED EVENTS
    Private Sub NewSrvcNote_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    ' LOAD EVENTS
    Private Sub NewCustNote_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' setting the display boxes for refrence for the person adding the note
        custNameBox.Text = srvcRow.CustomerFullName & " - " & srvcRow.CustomerNumber
        srvcNameBox.Text = srvcRow.ServiceName
        srvcTotalBox.Text = FormatCurrency(srvcRow.RecurringServiceRate * srvcRow.RecurringServiceQuantity)
        srvcStartDatePicker.Value = srvcRow.RecurringServiceStartDate
        ' if end date is null, display nothing
        If (srvcRow.IsRecurringServiceEndDateNull = False) Then
            srvcEndDatePicker.Value = srvcRow.RecurringServiceEndDate
        Else
            srvcEndDatePicker.CustomFormat = " "
        End If

    End Sub

    Private Sub NoteTextTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles noteTextBox.TextChanged
        If (Len(noteTextBox.Text) < 500) Then
            countLbl.Text = Len(noteTextBox.Text)
            countLbl.ForeColor = SystemColors.ControlText
        ElseIf (Len(noteTextBox.Text) = 500) Then
            countLbl.Text = 500
            countLbl.ForeColor = Color.Red
        End If
    End Sub

    Private Sub addNoteBtn_Click(sender As System.Object, e As System.EventArgs) Handles addNoteBtn.Click
        If (noteTextBox.TextLength > 0) Then
            Dim qta As New DataSetTableAdapters.QueriesTableAdapter
            Try
                qta.ServiceNotes_Insert(srvcRow.RecurringServiceID, noteTextBox.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Me.Close()
        End If
    End Sub

End Class