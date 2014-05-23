

Namespace Modules
    Public Module QBObjects

        Public Class QBAddInvoiceObj
            Public CustomerListID As String
            Public TxnDate As Date
            Public DueDate As Date
            Public IsToBePrinted As Boolean

            ' optional text field
            Public Memo As String
            ' optional data field
            Public Other As String

            ' line items
            Public LineList As List(Of QBLineItemObj)

            Public Sub New(ByVal customerListID As String, ByVal txnDate As Date, ByVal dueDate As Date, ByVal lineList As List(Of QBLineItemObj),
                           Optional ByVal isToBePrinted As Boolean = False, Optional memo As String = Nothing, Optional other As String = Nothing)
                Me.CustomerListID = customerListID
                Me.TxnDate = txnDate
                Me.DueDate = dueDate
                Me.IsToBePrinted = isToBePrinted
                Me.LineList = lineList

                If (memo IsNot Nothing) Then
                    Me.Memo = memo
                End If
                If (other IsNot Nothing) Then
                    Me.Other = other
                End If
            End Sub
            Public Sub New(ByVal customerNumber As Integer, ByVal txnDate As Date, ByVal dueDate As Date, ByVal lineList As List(Of QBLineItemObj),
                          Optional ByVal isToBePrinted As Boolean = False, Optional memo As String = Nothing, Optional other As String = Nothing)
                CustomerListID = GlobalConMgr.CustomerListID(customerNumber)
                Me.TxnDate = txnDate
                Me.DueDate = dueDate
                Me.IsToBePrinted = isToBePrinted
                Me.LineList = lineList

                If (memo IsNot Nothing) Then
                    Me.Memo = memo
                End If
                If (other IsNot Nothing) Then
                    Me.Other = other
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

            Public Sub New(Optional ByVal description As string)
                Quantity = 0
                If (description IsNot Nothing) Then
                    Desc = description
                End If
            End Sub
            Public Sub New(ByVal itemListID As String, ByVal rate As Double, Optional ByVal quantity As Integer = 1, Optional ByVal desc As String = Nothing,
                           Optional ByVal other1 As String = Nothing, Optional ByVal other2 As String = Nothing)
                Me.ItemListID = itemListID
                Me.Rate = rate

                If (quantity <> 1) Then
                    Me.Quantity = quantity
                End If
                If (desc IsNot Nothing) Then
                    Me.Desc = desc
                End If
                If (other1 IsNot Nothing) Then
                    Me.Other1 = other1
                End If
                If (other2 IsNot Nothing) Then
                    Me.Other2 = other2
                End If
            End Sub
        End Class

        Public Class QBAddCreditObj
            Public CustomerListID As String
            Public IsToBePrinted As Boolean
            Public ItemListID As String
            Public CreditAmount As Double
            Public Desc As String

            Public Sub New(ByVal customerListID As String, ByVal isToBePrinted As Boolean, ByVal itemListID As String, ByVal creditAmount As Double, ByVal desc As String)
                Me.CustomerListID = customerListID
                Me.IsToBePrinted = isToBePrinted
                Me.ItemListID = itemListID
                Me.CreditAmount = creditAmount
                Me.Desc = desc
            End Sub
        End Class

        Public Class QBCreditObj
            Public TxnID As String
            Public CreditRemaining As Double
            Public TxnDate As Date
            ' optional fields on new
            Public EditSequence As String
            Public TotalAmount As Double
            
            Public Sub New(ByVal txnID As String, ByVal creditRemaining As Double, ByVal txnDate As Date, Optional ByVal editSequence As String = Nothing,
                           Optional ByVal totalAmount As Double = Nothing)
                Me.TxnID = txnID
                Me.CreditRemaining = creditRemaining
                Me.TxnDate = txnDate
                ' optional params
                If (totalAmount <> Nothing) Then
                    Me.TotalAmount = totalAmount
                End If
                If (editSequence IsNot Nothing) Then
                    Me.EditSequence = editSequence
                End If
            End Sub
        End Class

        Public Class QBInvoiceObj
            Public TxnID As String
            Public CustomerListID As String
            Public TxnDate As Date
            ' optional fields on new
            Public EditSequence As String
            Public BalanceRemaining As Double

            ' optional fields can be used to enhance the obj for other queries
            ' this is used for an applied txn for a payment
            Public AppliedPaymentAmount As Double

            Public Sub New(ByVal txnID As String, ByVal customerListID As String, ByVal txnDate As Date, Optional ByVal editSequence As String = Nothing,
                           Optional ByVal balanceRemaining As Double = Nothing)
                Me.TxnID = txnID
                Me.CustomerListID = customerListID
                Me.TxnDate = txnDate
                ' optional params
                If (editSequence IsNot Nothing) Then
                    Me.EditSequence = editSequence
                End If
                If (balanceRemaining <> Nothing) Then
                    Me.BalanceRemaining = balanceRemaining
                End If
            End Sub
        End Class

        Public Class QBRecievePaymentObj
            Public TxnID As String
            Public TxnDate As Date
            Public TotalAmount As Double
            ' optional fields for new
            Public EditSequence As String
            Public UnusedPayment As Double
            ' optional list of applied invoices
            Public AppliedInvList As List(Of QBInvoiceObj)

            Public Sub new(ByVal txnID As String, ByVal txnDate As Date, ByVal totalAmount As Double, Optional ByVal editSequence As String = Nothing,
                            Optional byval unusedPayment As Double = Nothing, Optional ByVal appliedInvList As List(Of QBInvoiceObj))
                Me.TxnID = txnID
                Me.TxnDate = txnDate
                Me.TotalAmount = totalAmount
                ' optional params
                If (editSequence IsNot Nothing) Then
                    Me.EditSequence = editSequence
                End If
                If (unusedPayment <> Nothing) Then
                    Me.UnusedPayment = unusedPayment
                End If
                If (appliedInvList IsNot Nothing) Then
                    Me.AppliedInvList = appliedInvList
                End If
                End
            End Sub
        End Class
    End Module
End Namespace