

Namespace QBStuff
    Public Module QBObjects

        Public Structure QBAddCreditObj
            Public CustomerListID As String
            Public IsToBePrinted As Boolean
            Public ItemListID As String
            Public CreditAmount As Double
            Public Desc As String

            ' internal reference
            Public DateOfCredit As Date
        End Structure

        Public Structure QBCreditObj
            Public TxnID As String
            Public CreditRemaining As Double
            Public TxnDate As Date
            Public EditSequence As String
            Public TotalAmount As Double
            Public CustomerListID As String

            ' this is used when a credit is applied through ISetCredit
            Public AppliedAmount As Double
        End Structure

        Public Structure QBInvoiceObj
            Public TxnID As String
            Public EditSequence As String
            Public CustomerListID As String
            Public TxnDate As Date
            Public DueDate As Date
            Public IsToBePrinted As Boolean
            Public RefNumber As String

            ' this can be used to track balance after applying credits or payments
            Public BalanceRemaining As Double

            ' line items
            Public LineList As List(Of QBLineItemObj)

            ' linked txns
            Public LinkTxnList As List(Of QBLinkedTxnObj)

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
        End Structure

        Public Structure QBLineItemObj
            Public ItemListID As String
            Public Rate As Double
            Public Quantity As Integer
            Public Desc As String

            ' optional data fields
            Public Other1 As String
            Public Other2 As String
        End Structure

        Public Structure QBLinkedTxnObj
            Public TxnID As String
            Public RefNumber As String
            Public Amount As Double

            ' this is the date of the link, not the date of the txn that is linked
            Public TxnDate As Date

            ' these are enumerated on the return and will need to be ctyped to be read
            Public TxnType As Integer
        End Structure

        Public Structure QBRecievePaymentObj
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

            ' this is used for a linked txn amount
            Public LinkedTxnAmount As Double
        End Structure

        Public Structure QBItemObj
            Public ItemName As String
            Public ListID As String
            Public EditSequence As String
            Public Price As Double
            Public Desc As String

            Public IncomeAccountListID As String
        End Structure

        ' this is only used for bounced checks
        Public Structure QBCheckAddObj
            Public AccountListID As String
            Public PayeeListID As String
            Public RefNumber As String
            Public IsToBePrinted As Boolean

            ' line items list that goes onto this check
            ' (qb item that comes from the account that matches the bank)
            Dim LineList As List(Of QBLineItemObj)
        End Structure

    End Module

End Namespace