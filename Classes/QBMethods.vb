Imports TrashCash.Modules
Imports QBFC12Lib

Namespace Classes
    Public Class QBMethods

        Public Shared Function InvoiceAdd(ByVal invObj As QBAddInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            ' ref for msgSetReq incase one is passed for doing this through a different thread
            Dim conMgr As QBConMgr
            If (qbConMgr IsNot Nothing) Then
                conMgr = qbConMgr
            Else
                conMgr = GlobalConMgr
            End If

            Dim invAdd As IInvoiceAdd = conMgr.MessageSetRequest.AppendInvoiceAddRq

            ' set fields
            With invAdd
                .CustomerRef.ListID.SetValue(invObj.CustomerListID)
                .TxnDate.SetValue(invObj.TxnDate)
                .DueDate.SetValue(invObj.DueDate)
                .IsToBePrinted.SetValue(invObj.IsToBePrinted)
                ' optional fields
                If (invObj.Memo IsNot Nothing) Then
                    .Memo.SetValue(invObj.Memo)
                End If
                If (invObj.Other IsNot Nothing) Then
                    .Other.SetValue(invObj.Other)
                End If
            End With

            ' set line items
            For Each lineObj As QBLineItemObj In invObj.LineList
                Dim lineAdd As IORInvoiceLineAdd = invAdd.ORInvoiceLineAddList.Append

                ' set fields
                With lineAdd
                    If (lineObj.ItemListID IsNot Nothing) Then
                        .InvoiceLineAdd.ItemRef.ListID.SetValue(lineObj.ItemListID)
                    Else
                        .InvoiceLineAdd.ItemRef.ListID.Unset()
                    End If
                    If (lineObj.Rate = 0) Then
                        .InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineObj.Rate)
                    Else
                        .InvoiceLineAdd.ORRatePriceLevel.Rate.Unset()
                    End If
                    If (lineObj.Quantity = 0) Then
                        .InvoiceLineAdd.Quantity.SetValue(lineObj.Quantity)
                    Else
                        .InvoiceLineAdd.Quantity.Unset()
                    End If
                    If (lineObj.Desc IsNot Nothing) Then
                        .InvoiceLineAdd.Desc.SetValue(lineObj.Desc)
                    End If
                    ' other fields
                    If (lineObj.Other1 IsNot Nothing) Then
                        .InvoiceLineAdd.Other1.SetValue(lineObj.Other1)
                    End If
                    If (lineObj.Other2 IsNot Nothing) Then
                        .InvoiceLineAdd.Other2.SetValue(lineObj.Other2)
                    End If
                End With
            Next lineObj

            Dim respList As IResponseList = conMgr.GetRespList
            Return respList.GetAt(0)

        End Function

        Public Shared Function InvoiceAdd(ByVal invObjList As List(Of QBAddInvoiceObj), Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponseList
            ' ref for msgSetReq incase one is passed for doing this through a different thread
            Dim conMgr As QBConMgr
            If (qbConMgr IsNot Nothing) Then
                conMgr = qbConMgr
            Else
                conMgr = GlobalConMgr
            End If

            For Each invObj As QBAddInvoiceObj In invObjList
                Dim invAdd As IInvoiceAdd = conMgr.MessageSetRequest.AppendInvoiceAddRq

                ' set fields
                With invAdd
                    .CustomerRef.ListID.SetValue(invObj.CustomerListID)
                    .TxnDate.SetValue(invObj.TxnDate)
                    .DueDate.SetValue(invObj.DueDate)
                    .IsToBePrinted.SetValue(invObj.IsToBePrinted)
                    ' optional fields
                    If (invObj.Memo IsNot Nothing) Then
                        .Memo.SetValue(invObj.Memo)
                    End If
                    If (invObj.Other IsNot Nothing) Then
                        .Other.SetValue(invObj.Other)
                    End If
                End With

                ' set line items
                For Each lineObj As QBLineItemObj In invObj.LineList
                    Dim lineAdd As IORInvoiceLineAdd = invAdd.ORInvoiceLineAddList.Append

                    ' set fields
                    With lineAdd
                        If (lineObj.ItemListID IsNot Nothing) Then
                            .InvoiceLineAdd.ItemRef.ListID.SetValue(lineObj.ItemListID)
                        Else
                            .InvoiceLineAdd.ItemRef.ListID.Unset()
                        End If
                        If (lineObj.Rate = 0) Then
                            .InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineObj.Rate)
                        Else
                            .InvoiceLineAdd.ORRatePriceLevel.Rate.Unset()
                        End If
                        If (lineObj.Quantity = 0) Then
                            .InvoiceLineAdd.Quantity.SetValue(lineObj.Quantity)
                        Else
                            .InvoiceLineAdd.Quantity.Unset()
                        End If
                        If (lineObj.Desc IsNot Nothing) Then
                            .InvoiceLineAdd.Desc.SetValue(lineObj.Desc)
                        End If
                        ' other fields
                        If (lineObj.Other1 IsNot Nothing) Then
                            .InvoiceLineAdd.Other1.SetValue(lineObj.Other1)
                        End If
                        If (lineObj.Other2 IsNot Nothing) Then
                            .InvoiceLineAdd.Other2.SetValue(lineObj.Other2)
                        End If
                    End With
                Next lineObj
            Next invObj

            ' all invoices preped, go
            Return conMgr.GetRespList()
        End Function

    End Class
End Namespace