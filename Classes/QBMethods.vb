Imports TrashCash.Modules
Imports QBFC12Lib

Namespace Classes
    Public Class QBMethods

        ' misc
        Public Shared Function TxnVoid(ByVal txnID As String, ByVal voidType As ENTxnVoidType, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim txnVoidRq As ITxnVoid = ConCheck(qbConMgr).MessageSetRequest.AppendTxnVoidRq
            With txnVoidRq
                .TxnID.SetValue(txnID)
                .TxnVoidType.SetValue(voidType)
            End With

            Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList()
            Return respList.GetAt(0)
        End Function


        ' invoicing
        Public Overloads Shared Function InvoiceAdd(ByRef invObj As QBInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
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

        Public Overloads Shared Function InvoiceAdd(ByRef invObjList As List(Of QBInvoiceObj), Optional ByRef qbConMgr As QBConMgr = Nothing) As List(Of IResponse)
            ' return list
            Dim retRespList As New List(Of IResponse)

            For Each invObj As QBInvoiceObj In invObjList
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

                ' invoice prepped, go
                Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList()
                retRespList.Add(respList.GetAt(0))
            Next invObj

            Return retRespList
        End Function

        ' crediting
        Public Shared Function CreditAdd(ByRef creditObj As QBAddCreditObj) As IResponse
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

        ' payments
        Public Overloads Shared Function PaymentAdd(ByRef payObj As QBRecievePaymentObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                          Optional ByVal autoApply As Boolean = True) As IResponse
            Dim payAdd As IReceivePaymentAdd = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentAddRq
            With payAdd
                .CustomerRef.ListID.SetValue(payObj.CustomerListID)
                .TotalAmount.SetValue(payObj.TotalAmount)
                .PaymentMethodRef.FullName.SetValue(payObj.PayTypeName)
                .TxnDate.SetValue(payObj.TxnDate)
                .ORApplyPayment.IsAutoApply.SetValue(autoApply)
                ' optional check number
                If (payObj.RefNumber IsNot Nothing) Then
                    .RefNumber.SetValue(payObj.RefNumber)
                End If
            End With

            Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList()
            Return respList.GetAt(0)
        End Function

        Public Overloads Shared Function PaymentAdd(ByRef payObjList As List(Of QBRecievePaymentObj), Optional ByRef qbConMgr As QBConMgr = Nothing,
                                          Optional ByVal autoApply As Boolean = True) As List(Of IResponse)
            ' return list of response
            Dim retRespList As New List(Of IResponse)

            For Each payObj As QBRecievePaymentObj In payObjList
                Dim payAdd As IReceivePaymentAdd = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentAddRq
                With payAdd
                    .CustomerRef.ListID.SetValue(payObj.CustomerListID)
                    .TotalAmount.SetValue(payObj.TotalAmount)
                    .PaymentMethodRef.FullName.SetValue(payObj.PayTypeName)
                    .TxnDate.SetValue(payObj.TxnDate)
                    .ORApplyPayment.IsAutoApply.SetValue(autoApply)
                    ' optional check number
                    If (payObj.RefNumber IsNot Nothing) Then
                        .RefNumber.SetValue(payObj.RefNumber)
                    End If
                End With

                Dim respList As IResponseList = ConCheck(qbConMgr).GetRespList()
                retRespList.Add(respList.GetAt(0))
            Next

            Return retRespList
        End Function

        Public Shared Function PaymentMod(ByRef payObj As QBRecievePaymentObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim rec
        End Function

        ' queries
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