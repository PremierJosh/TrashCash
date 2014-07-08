

Namespace QBStuff
    Public Module QBObjects

     Public Class QBCreditObj
            Public TxnID As String
            Public CreditRemaining As Double
            Public TxnDate As Date
            Public EditSequence As String
            Public TotalAmount As Double
            Public CustomerListID As String

            ' this is used when a credit is applied through ISetCredit
            Public AppliedAmount As Double

            ' used when  a new credit is going in
            Public IsToBePrinted As Boolean
            Public ItemListID As String
            Public Desc As String
            ' internal reference
            Public DateOfCredit As Date
        End Class

        Public Class QBInvoiceObj
            Public TxnID As String
            Public EditSequence As String
            Public CustomerListID As String
            Public TxnDate As Date
            Public DueDate As Date
            Public IsToBePrinted As Boolean
            Public RefNumber As String
            Public TimeCreated As Date
            Public Subtotal As Double

            ' this can be used to track balance after applying credits or payments
            Public BalanceRemaining As Double

            ' line items
            Public LineList As List(Of QBLineItemObj)

            'used for display
            Public CustomerFullName As String

            ' optional text field
            Public Memo As String
            ' optional data field
            Public Other As String

            ' this is used when a payment is going in and i want it on a specific invoice
            Public AppliedAmount As Integer

            ' this is a list of applied payments on this invoice
            Public LinkedPaymentList As List(Of QBRecievePaymentObj)

            ' this is used to carry an invoices applied credits
            ''' chose to put this here since the way you apply a credit to an invoice
            ''' is to recieve a payment with no amount, apply payment to invoice by id
            ''' and set the credit txn id and amount used to pay it
            Public LinkedCreditList As List(Of QBCreditObj)
        End Class

        Public Class QBLineItemObj
            Public ItemListID As String
            Public Rate As Double
            Public Quantity As Integer
            Public Desc As String
            Public TxnLineID As String
            Public Amount As Double

            ' optional data fields
            Public Other1 As String
            Public Other2 As String
        End Class

        'Public Class QBLinkedTxnObj
        '    Public TxnID As String
        '    Public RefNumber As String
        '    Public Amount As Double

        '    ' this is the date of the link, not the date of the txn that is linked
        '    Public TxnDate As Date

        '    ' these are enumerated on the return and will need to be ctyped to be read
        '    Public TxnType As Integer
        'End Class

        Public Class QBRecievePaymentObj
            Public TxnID As String
            Public TxnDate As Date
            Public TotalAmount As Double
            Public PayTypeName As String
            Public CustomerListID As String
            Public EditSequence As String
            Public UnusedPayment As Double
            Public RefNumber As String
            Public Memo As String

            ' optional list of invoices this payment is paying
            Public AppliedInvList As List(Of QBInvoiceObj)

            ' this is used for a linked txn amount
            Public LinkedTxnAmount As Double
        End Class

        Public Class QBItemObj
            Public ItemName As String
            Public ListID As String
            Public EditSequence As String
            Public Price As Double
            Public Desc As String

            Public IncomeAccountListID As String
        End Class

        ' this is only used for bounced checks
        Public Class QBCheckObj
            Public AccountListID As String
            Public PayeeListID As String
            Public RefNumber As String
            Public IsToBePrinted As Boolean
            Public TxnDate As Date
            ' dont do many checks so just going to carry id here after add
            Public TxnID As String

            ' line items list that goes onto this check
            ' (qb item that comes from the account that matches the bank)
            Public LineList As List(Of QBLineItemObj)
        End Class

    End Module

End Namespace