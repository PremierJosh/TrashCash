
Namespace Classes
    Public Class CurrencyTextBox
        Inherits TextBox

        Private Sub Currency_TextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
            If (sender.textlength > 0) Then
                If Not Decimal.TryParse(Text, _
                                        Globalization.NumberStyles.Currency) Then
                    'Don't let the user leave the field if the value is invalid.
                    With Me
                        .HideSelection = False
                        .SelectAll()

                        MessageBox.Show("Please enter a valid currency amount.", _
                                        "Invalid Value", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Error)

                        .HideSelection = True
                    End With

                    e.Cancel = True
                End If
            End If
        End Sub
    End Class
End Namespace