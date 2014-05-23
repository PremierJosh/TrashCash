Imports TrashCash.Classes

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
    End Module
End Namespace