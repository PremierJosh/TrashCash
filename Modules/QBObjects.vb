

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

            ' this is used when a credit is applied through ISetCredit
            Public AppliedAmount As Double
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
            
            ' this is used to carry an invoices applied credits
            ''' chose to put this here since the way you apply a credit to an invoice
            ''' is to recieve a payment with no amount, apply payment to invoice by id
            ''' and set the credit txn id and amount used to pay it
            Public SetCreditList As List(Of QBCreditObj)

            Public Sub New(Optional ByVal txnID As String = Nothing)
                SetCreditList = New List(Of QBCreditObj)
                LineList = New List(Of QBLineItemObj)
                If (txnID IsNot Nothing) Then
                    Me.TxnID = txnID
                End If
            End Sub
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

            Public Sub New()
                AppliedInvList = New List(Of QBInvoiceObj)
            End Sub
            End Class
    End Module
End Namespace