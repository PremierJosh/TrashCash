

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
            Public EditSequence As String
            Public TotalAmount As Double
            
            Public Sub New(Optional ByVal txnID As String = Nothing, Optional ByVal creditRemaining As Double = Nothing, Optional ByVal txnDate As Date = Nothing,
                           Optional ByVal editSequence As String = Nothing, Optional ByVal totalAmount As Double = Nothing)
                If (txnID IsNot Nothing) Then
                    Me.TxnID = txnID
                End IF
                If (creditRemaining <> Nothing) Then
                    Me.CreditRemaining = creditRemaining
                End If
                If (txnDate <> Nothing) Then
                    Me.TxnDate = txnDate
                End If
                If (totalAmount <> Nothing) Then
                    Me.TotalAmount = totalAmount
                End If
                If (editSequence IsNot Nothing) Then
                    Me.EditSequence = editSequence
                End If
            End Sub
        End Class

        Public Class QBInvoiceObj
            ' all params are optional
            Public TxnID As String
            Public CustomerListID As String
            Public TxnDate As Date
            Public EditSequence As String
            Public BalanceRemaining As Double

            ' optional fields can be used to enhance the obj for other queries
            ' this is used for an applied txn for a payment
            Public AppliedPaymentAmount As Double

            Public Sub New(Optional ByVal txnID As String = Nothing, Optional ByVal customerListID As String = Nothing, Optional ByVal txnDate As Date = Nothing,
                           Optional ByVal editSequence As String = Nothing, Optional ByVal balanceRemaining As Double = Nothing)
                ' all params are optional
                If (txnID IsNot Nothing) Then
                    Me.TxnID = txnID
                End If
                If (customerListID IsNot Nothing) Then
                    Me.CustomerListID = customerListID
                End If
                If (txnDate <> Nothing) Then
                    Me.TxnDate = txnDate
                End If
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
            Public PayTypeName As String
            ' optional fields for new
            Public CustomerListID As String
            Public EditSequence As String
            Public UnusedPayment As Double
            Public RefNumber As String
            ' optional list of applied invoices
            Public AppliedInvList As List(Of QBInvoiceObj)

            Public Sub new(Optional ByVal txnID As String = nothing, optByVal txnDate As Date, ByVal totalAmount As Double, byval payTypeName As String, Optional ByVal refNumber As String = Nothing,
                           Optional ByVal editSequence As String = Nothing,Optional byval customerListID As String  = nothing,
                           Optional byval unusedPayment As Double = Nothing,Optional ByVal appliedInvList As List(Of QBInvoiceObj))
                Me.TxnID = txnID
                Me.TxnDate = TxnDate
                Me.TotalAmount = TotalAmount
                Me.PayTypeName = PayTypeName
                ' optional params
                If (CustomerListID IsNot Nothing) Then
                    Me.CustomerListID = CustomerListID
                End If
                If (EditSequence IsNot Nothing) Then
                    Me.EditSequence = EditSequence
                End If
                If (UnusedPayment <> Nothing) Then
                    Me.UnusedPayment = UnusedPayment
                End If
                If (RefNumber IsNot Nothing) Then
                    Me.RefNumber = RefNumber
                End If
                If (AppliedInvList IsNot Nothing) Then
                    Me.AppliedInvList = AppliedInvList
                End If
                End
            End Sub
        End Class
    End Module
End Namespace