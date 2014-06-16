Namespace Customer
    Public Class UC_CustomerNotes
        ' property refrence
        Private _custNum As Decimal
        ' properties
        Public Property CurrentCustomer As Decimal
            Get
                Return _custNum
            End Get
            Set(ByVal value As Decimal)
                If (value > 0) Then
                    ' refrence
                    _custNum = value

                    ' fill Note grid
                    CustomerNotesTableAdapter.Fill(Ds_Customer.CustomerNotes, value)
                End If
            End Set
        End Property

        Private Sub dg_CustNotes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_CustNotes.DoubleClick
            Dim noteText As String = InputBox("Note:", "Quick Add Customer Note")
            If (Trim(noteText) <> "") Then
                Try
                    CustomerNotesTableAdapter.CustomerNotes_Insert(CurrentCustomer, noteText)
                    ' refill grid
                    CustomerNotesTableAdapter.Fill(Ds_Customer.CustomerNotes, CurrentCustomer)
                Catch ex As Exception
                    MessageBox.Show("Error inserting New Customer Note", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub UC_CustomerNotes_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        End Sub
    End Class
End Namespace