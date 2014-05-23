Imports TrashCash.Modules
Imports QBFC12Lib

Namespace Classes
    Public Class QBMethods

        Public Shared Function TxnVoid(ByVal txnID As String, ByVal voidType As ENTxnVoidType, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim txnVoidRq As ITxnVoid = ConCheck(qbConMgr).MessageSetRequest.AppendTxnVoidRq
            With txnVoidRq
                .TxnID.SetValue(txnID)
                .TxnVoidType.SetValue(voidType)
            End With

            Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList()
            Return respList.GetAt(0)
        End Function

        Public Overloads Shared Function InvoiceAdd(ByVal invObj As QBAddInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            ' ref for msgSetReq incase one is passed for doing this through a different thread
            Dim invAdd As IInvoiceAdd = ConCheck(qbConMgr).MessageSetRequest.AppendInvoiceAddRq

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
                With lineAdd.InvoiceLineAdd
                    If (lineObj.ItemListID IsNot Nothing) Then
                        .ItemRef.ListID.SetValue(lineObj.ItemListID)
                    Else
                        .ItemRef.ListID.Unset()
                    End If
                    If (lineObj.Rate = 0) Then
                        .ORRatePriceLevel.Rate.SetValue(lineObj.Rate)
                    Else
                        .ORRatePriceLevel.Rate.Unset()
                    End If
                    If (lineObj.Quantity = 0) Then
                        .Quantity.SetValue(lineObj.Quantity)
                    Else
                        .Quantity.Unset()
                    End If
                    If (lineObj.Desc IsNot Nothing) Then
                        .Desc.SetValue(lineObj.Desc)
                    End If
                    ' other fields
                    If (lineObj.Other1 IsNot Nothing) Then
                        .Other1.SetValue(lineObj.Other1)
                    End If
                    If (lineObj.Other2 IsNot Nothing) Then
                        .Other2.SetValue(lineObj.Other2)
                    End If
                End With
            Next lineObj

            Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList
            Return respList.GetAt(0)

        End Function

        Public Overloads Shared Function InvoiceAdd(ByVal invObjList As List(Of QBAddInvoiceObj), Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponseList
            ' ref for msgSetReq incase one is passed for doing this through a different thread
            Dim conMgr As QBConMgr = ConCheck(qbConMgr)

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
                    With lineAdd.InvoiceLineAdd
                        If (lineObj.ItemListID IsNot Nothing) Then
                            .ItemRef.ListID.SetValue(lineObj.ItemListID)
                        Else
                            .ItemRef.ListID.Unset()
                        End If
                        If (lineObj.Rate = 0) Then
                            .ORRatePriceLevel.Rate.SetValue(lineObj.Rate)
                        Else
                            .ORRatePriceLevel.Rate.Unset()
                        End If
                        If (lineObj.Quantity = 0) Then
                            .Quantity.SetValue(lineObj.Quantity)
                        Else
                            .Quantity.Unset()
                        End If
                        If (lineObj.Desc IsNot Nothing) Then
                            .Desc.SetValue(lineObj.Desc)
                        End If
                        ' other fields
                        If (lineObj.Other1 IsNot Nothing) Then
                            .Other1.SetValue(lineObj.Other1)
                        End If
                        If (lineObj.Other2 IsNot Nothing) Then
                            .Other2.SetValue(lineObj.Other2)
                        End If
                    End With
                Next lineObj
            Next invObj

            ' all invoices preped, go
            Return conMgr.GetRespList()
        End Function

        Public Shared Function CreditAdd(ByVal creditObj As QBAddCreditObj) As IResponse
            Dim credAdd As ICreditMemoAdd = GlobalConMgr.MessageSetRequest.AppendCreditMemoAddRq
            With credAdd
                .CustomerRef.ListID.SetValue(creditObj.CustomerListID)
                .IsToBePrinted.SetValue(creditObj.IsToBePrinted)
            End With

            Dim creditLine As IORCreditMemoLineAdd = credAdd.ORCreditMemoLineAddList.Append
            With creditLine.CreditMemoLineAdd
                .ItemRef.ListID.SetValue(creditObj.ItemListID)
                .ORRatePriceLevel.Rate.SetValue(creditObj.CreditAmount)
            End With

            Dim descLine As IORCreditMemoLineAdd = credAdd.ORCreditMemoLineAddList.Append
            With descLine.CreditMemoLineAdd
                .Desc.SetValue(creditObj.Desc)
                .ItemRef.ListID.Unset()
                .ItemRef.FullName.Unset()
                .Amount.Unset()
                .Quantity.Unset()
            End With

            Dim respList As IResponseList = GlobalConMgr.GetRespList()
            Return respList.GetAt(0)
        End Function

        Public Shared Function InvoiceQuery(ByVal customerListID As String, Optional ByVal fromDate As Date = Nothing, Optional ByVal toDate As Date = Nothing,
                                            Optional ByVal paidStatus As ENPaidStatus = Nothing, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                            Optional ByVal responseLimit As Integer = 100) As IResponse

            Dim invQuery As IInvoiceQuery = ConCheck(qbConMgr).MessageSetRequest.AppendInvoiceQueryRq()
            ' setting filters
            With invQuery.ORInvoiceQuery.InvoiceFilter
                .EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
                ' checking optional params
                With .ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter
                    If (fromDate <> Nothing) Then
                        .FromTxnDate.SetValue(fromDate)
                    End If
                    If (toDate <> Nothing) Then
                        .ToTxnDate.SetValue(toDate)
                    End If
                End With
                ' checking if no dates set to limit response, or of responseLimit was passed
                Select Case responseLimit
                    Case toDate = Nothing And fromDate = Nothing
                        .MaxReturned.SetValue(responseLimit)
                    Case Is <> 100
                        .MaxReturned.SetValue(responseLimit)
                End Select

                .PaidStatus.SetValue(paidStatus)
            End With

            Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList
            Return respList.GetAt(0)
        End Function

        Public Shared Function PaymentQuery(ByVal customerListID As String, Optional ByRef fromDate As Date = Nothing, Optional ByRef toDate As Date = Nothing,
                                            Optional ByRef qbConMgr As QBConMgr = Nothing, Optional ByVal responseLimit As Integer = 100) As IResponse
            ' ref for msgSetReq incase one is passed for doing this through a different thread
            Dim payQuery As IReceivePaymentQuery = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentQueryRq
            ' setting filter
            With payQuery.ORTxnQuery.TxnFilter
                .EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
                ' checking dates
                With .ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter
                    If (fromDate <> Nothing) Then
                        .FromTxnDate.SetValue(fromDate)
                    End If
                    If (toDate <> Nothing) Then
                        .ToTxnDate.SetValue(toDate)
                    End If
                End With
                ' checking if no dates set to limit response, or of responseLimit was passed
                Select Case responseLimit
                    Case toDate = Nothing And fromDate = Nothing
                        .MaxReturned.SetValue(responseLimit)
                    Case Is <> 100
                        .MaxReturned.SetValue(responseLimit)
                End Select
            End With

            Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList
            Return respList.GetAt(0)
        End Function

    End Class
End Namespace