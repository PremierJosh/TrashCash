

Namespace Modules
    Public Module QBObjects

        Public Class QBAddCreditObj
            Public CustomerListID As String
            Public IsToBePrinted As Boolean
            Public ItemListID As String
            Public CreditAmount As Double
            Public Desc As String
        End Class

        Public Class QBCreditObj
            Public TxnID As String
            Public CreditRemaining As Double
            Public TxnDate As Date
            Public EditSequence As String
            Public TotalAmount As Double
        End Class

        Public Class QBInvoiceObj
            Public TxnID As String
            Public EditSequence As String
            Public CustomerListID As String
            Public TxnDate As Date
            Public DueDate As Date
            Public IsToBePrinted As Boolean
            Public BalanceRemaining As Double

            ' line items
            Public LineList As List(Of QBLineItemObj)

            ' optional text field
            Public Memo As String
            ' optional data field
            Public Other As String

            ' this is used for an applied txn for a payment
            Public AppliedPaymentAmount As Double
        End Class

        Public Class QBLineItemObj
            Public ItemListID As String
            Public Rate As Double
            Public Quantity As Integer = 1
            Public Desc As String

            ' optional data fields
            Public Other1 As String
            Public Other2 As String

            ' if a string is passed on new, this is a desc only line
            Public Sub New(Optional ByVal desc As String = Nothing)
                Quantity = 0
                If (desc IsNot Nothing) Then
                    Me.Desc = desc
                End If
            End Sub
        End Class

        Public Class QBRecievePaymentObj
            Public TxnID As String
            Public TxnDate As Date
            Public TotalAmount As Double
            Public PayTypeName As String
            Public CustomerListID As String
            Public EditSequence As String
            Public UnusedPayment As Double
            Public RefNumber As String

            ' optional list of invoices this payment is paying
            Public AppliedInvList As List(Of QBInvoiceObj)
        End Class
    End Module
End Namespace