Imports TrashCash.Classes
Imports QBFC12Lib


Namespace QBStuff
    Friend Class QBRequests

        ' misc
        Public Shared Function TxnVoid(ByVal txnID As String, ByVal voidType As ENTxnVoidType, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim txnVoidRq As ITxnVoid = ConCheck(qbConMgr).MessageSetRequest.AppendTxnVoidRq
            With txnVoidRq
                .TxnID.SetValue(txnID)
                .TxnVoidType.SetValue(voidType)
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        ' service item
        Public Shared Function ServiceItemAdd(ByRef item As QBObjects.QBItemObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim newItem As IItemServiceAdd = ConCheck(qbConMgr).MessageSetRequest.AppendItemServiceAddRq
            newItem.Name.SetValue(item.ItemName)
            With newItem.ORSalesPurchase.SalesOrPurchase
                .AccountRef.ListID.SetValue(item.IncomeAccountListID)
                .Desc.SetValue(item.Desc)
                If (item.Price <> Nothing) Then
                    .ORPrice.Price.SetValue(item.Price)
                End If
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function ServiceItemMod(ByRef item As QBItemObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim itemMod As IItemServiceMod = ConCheck(qbConMgr).MessageSetRequest.AppendItemServiceModRq
            ' setting item
            itemMod.ListID.SetValue(item.ListID)
            itemMod.EditSequence.SetValue(item.EditSequence)
            ' checking for passed value changes
            If (item.ItemName IsNot Nothing) Then
                itemMod.Name.SetValue(item.ItemName)
            End If
            With itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod
                .AccountRef.ListID.SetValue(item.IncomeAccountListID)
                .ORPrice.Price.SetValue(item.Price)
                .Desc.SetValue(item.Desc)
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function
        ' customer
        Public Shared Function CustomerAdd(ByRef custRow As ds_Customer.CustomerRow, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim custAdd As ICustomerAdd = ConCheck(qbConMgr).MessageSetRequest.AppendCustomerAddRq
            With custAdd
                .Name.SetValue(custRow.CustomerFullName)
                If (custRow.IsCustomerCompanyNameNull = False) Then
                    .CompanyName.SetValue(custRow.CustomerCompanyName)
                End If
                If (custRow.IsCustomerFirstNameNull = False) Then
                    .FirstName.SetValue(custRow.CustomerFirstName)
                End If
                If (custRow.IsCustomerLastNameNull = False) Then
                    .LastName.SetValue(custRow.CustomerLastName)
                End If
                .Phone.SetValue(custRow.CustomerPhone)

                If (custRow.IsCustomerAltPhoneNull = False) Then
                    .AltPhone.SetValue(custRow.CustomerAltPhone)
                End If
                If (custRow.IsCustomerContactNull = False) Then
                    .Contact.SetValue(custRow.CustomerContact)
                End If

                ' Billing Address Information
                .BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
                If (custRow.IsCustomerBillingAddr2Null = False) Then
                    .BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
                End If
                If (custRow.IsCustomerBillingAddr3Null = False) Then
                    .BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
                End If
                If (custRow.IsCustomerBillingAddr4Null = False) Then
                    .BillAddress.Addr4.SetValue(custRow.CustomerBillingAddr4)
                End If
                .BillAddress.City.SetValue(custRow.CustomerBillingCity)
                .BillAddress.State.SetValue(custRow.CustomerBillingState)
                .BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function CustomerMod(ByRef custRow As ds_Customer.CustomerRow, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim custMod As ICustomerMod = ConCheck(qbConMgr).MessageSetRequest.AppendCustomerModRq
            With custMod
                .ListID.SetValue(custRow.CustomerListID)
                .EditSequence.SetValue(custRow.CustomerEditSeq)

                '''' customer information ''''
                .Name.SetValue(custRow.CustomerFullName)
                If (custRow.IsCustomerCompanyNameNull = False) Then
                    .CompanyName.SetValue(custRow.CustomerCompanyName)
                End If
                If (custRow.IsCustomerFirstNameNull = False) Then
                    .FirstName.SetValue(custRow.CustomerFirstName)
                End If
                If (custRow.IsCustomerLastNameNull = False) Then
                    .LastName.SetValue(custRow.CustomerLastName)
                End If
                .Phone.SetValue(custRow.CustomerPhone)

                ' checking possibly blank alt phone
                If (custRow.IsCustomerAltPhoneNull = False) Then
                    .AltPhone.SetValue(custRow.CustomerAltPhone)
                End If
                ' checking possibly blank contact field
                If (custRow.IsCustomerContactNull = False) Then
                    .Contact.SetValue(custRow.CustomerContact)
                End If

                '''' billing information ''''
                ' required billAddr1
                .BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
                ' checking billAddr2
                If (custRow.IsCustomerBillingAddr2Null = False) Then
                    .BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
                End If
                ' checking billAddr3
                If (custRow.IsCustomerBillingAddr3Null = False) Then
                    .BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
                End If
                .BillAddress.City.SetValue(custRow.CustomerBillingCity)
                .BillAddress.State.SetValue(custRow.CustomerBillingState)
                .BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

                ' if cell = true, then customer is deactive
                If (custRow.CustomerIsDeactive = True) Then
                    .IsActive.SetValue(False)
                Else
                    .IsActive.SetValue(True)
                End If
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
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
                    If (lineObj.Rate <> 0) Then
                        .ORRatePriceLevel.Rate.SetValue(lineObj.Rate)
                    Else
                        .ORRatePriceLevel.Rate.Unset()
                    End If
                    If (lineObj.Quantity <> 0) Then
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

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        ' crediting
        Public Shared Function CreditMemoAdd(ByRef creditObj As QBAddCreditObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim credAdd As ICreditMemoAdd = ConCheck(qbConMgr).MessageSetRequest.AppendCreditMemoAddRq
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

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
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
                ' checking if appTxnList isnot nothing
                If (payObj.AppliedInvList IsNot Nothing) Then
                    Dim appTxnList As IAppliedToTxnAddList = .ORApplyPayment.AppliedToTxnAddList
                    For Each invObj As QBInvoiceObj In payObj.AppliedInvList
                        Dim appTxn As IAppliedToTxnMod = appTxnList.Append
                        appTxn.TxnID.SetValue(invObj.TxnID)
                        ' checking if there is an applied amount
                        If (invObj.AppliedPaymentAmount <> Nothing) Then
                            appTxn.PaymentAmount.SetValue(invObj.AppliedPaymentAmount)
                        End If
                        ' checking if credit list is applied
                        If (invObj.SetCreditList IsNot Nothing) Then
                            Dim setCreditList As ISetCreditList = appTxn.SetCreditList
                            For Each creditObj As QBCreditObj In invObj.SetCreditList
                                Dim setCredit As ISetCredit = setCreditList.Append
                                With setCredit
                                    .CreditTxnID.SetValue(creditObj.TxnID)
                                    .AppliedAmount.SetValue(creditObj.AppliedAmount)
                                End With
                            Next
                        End If
                    Next
                End If
            End With


            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Overloads Shared Function PaymentMod(ByRef payObj As QBRecievePaymentObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                                     Optional ByVal wipeAppList As Boolean = False) As IResponse
            Dim payMod As IReceivePaymentMod = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentModRq
            ' set fields
            With payMod
                .TxnID.SetValue(payObj.TxnID)
                .EditSequence.SetValue(payObj.EditSequence)
            End With

            ' set applied to txns if not nothing
            If (payObj.AppliedInvList IsNot Nothing) Then
                Dim appTxnList As IAppliedToTxnModList = payMod.AppliedToTxnModList
                For Each invObj As QBInvoiceObj In payObj.AppliedInvList
                    Dim appTxn As IAppliedToTxnMod = appTxnList.Append
                    appTxn.TxnID.SetValue(invObj.TxnID)
                    ' checking if there is an applied amount
                    If (invObj.AppliedPaymentAmount <> Nothing) Then
                        appTxn.PaymentAmount.SetValue(invObj.AppliedPaymentAmount)
                    End If
                    ' checking if credit list is applied
                    If (invObj.SetCreditList IsNot Nothing) Then
                        Dim setCreditList As ISetCreditList = appTxn.SetCreditList
                        For Each creditObj As QBCreditObj In invObj.SetCreditList
                            Dim setCredit As ISetCredit = setCreditList.Append
                            With setCredit
                                .CreditTxnID.SetValue(creditObj.TxnID)
                                .AppliedAmount.SetValue(creditObj.AppliedAmount)
                            End With
                        Next
                    End If
                Next
            Else
                ' checking if optional param to wipe applied list is set to true
                If (wipeAppList) Then
                    ' ReSharper disable once UnusedVariable
                    Dim appTxnList As IAppliedToTxnModList = payMod.AppliedToTxnModList
                End If
            End If

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        ' queries
        Public Shared Function InvoiceQuery(Optional ByVal listID As String = Nothing, Optional ByVal txnID As String = Nothing,
                                            Optional ByVal fromDate As Date = Nothing, Optional ByVal toDate As Date = Nothing,
                                            Optional ByVal paidStatus As ENPaidStatus = Nothing, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                            Optional ByVal responseLimit As Integer = 100, Optional ByVal retEleList As List(Of String) = Nothing,
                                            Optional ByVal incLinkTxn As Boolean = False, Optional ByVal incLineItems As Boolean = False) As IResponse

            Dim query As IInvoiceQuery = ConCheck(qbConMgr).MessageSetRequest.AppendInvoiceQueryRq()
            ' setting linked txn and linked line items filter
            With query
                If (incLinkTxn) Then
                    .IncludeLinkedTxns.SetValue(incLinkTxn)
                End If
                If (incLineItems) Then
                    .IncludeLineItems.SetValue(incLineItems)
                End If
                ' checking for ret element list
                If (retEleList IsNot Nothing) Then
                    For Each s As String In retEleList
                        .IncludeRetElementList.Add(s)
                    Next
                End If
            End With

            ' setting inv level filters
            With query.ORInvoiceQuery
                ' checking for customer id or txn id
                If (listID IsNot Nothing) Then
                    .InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(listID)
                ElseIf (txnID IsNot Nothing) Then
                    .TxnIDList.Add(txnID)
                End If

                ' checking optional params
                With .InvoiceFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter
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
                        .InvoiceFilter.MaxReturned.SetValue(responseLimit)
                    Case Is <> 100
                        .InvoiceFilter.MaxReturned.SetValue(responseLimit)
                End Select

                .InvoiceFilter.PaidStatus.SetValue(paidStatus)
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function PaymentQuery(Optional ByVal listID As String = Nothing, Optional ByVal txnID As String = Nothing,
                                            Optional ByVal fromDate As Date = Nothing, Optional ByVal toDate As Date = Nothing,
                                            Optional ByRef qbConMgr As QBConMgr = Nothing, Optional ByVal responseLimit As Integer = 100,
                                            Optional ByVal retEleList As List(Of String) = Nothing, Optional ByVal incLinkTxn As Boolean = False,
                                            Optional ByVal incLineItems As Boolean = False) As IResponse
            Dim query As IReceivePaymentQuery = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentQueryRq
            ' setting high level filters
            With query
                If (incLineItems) Then
                    .IncludeLineItems.SetValue(incLineItems)
                End If
                ' checking for ret element list
                If (retEleList IsNot Nothing) Then
                    For Each s As String In retEleList
                        .IncludeRetElementList.Add(s)
                    Next
                End If
            End With
            ' setting filter
            With query.ORTxnQuery
                ' checking for customer id or txnid filter
                If (listID IsNot Nothing) Then
                    .TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(listID)
                ElseIf (txnID IsNot Nothing) Then
                    .TxnIDList.Add(txnID)
                End If
                ' checking dates
                With .TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter
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
                        .TxnFilter.MaxReturned.SetValue(responseLimit)
                    Case Is <> 100
                        .TxnFilter.MaxReturned.SetValue(responseLimit)
                End Select
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function CreditMemoQuery(Optional ByVal listID As String = Nothing, Optional ByVal txnID As String = Nothing,
                                            Optional ByRef fromDate As Date = Nothing, Optional ByRef toDate As Date = Nothing,
                                            Optional ByRef qbConMgr As QBConMgr = Nothing, Optional ByVal responseLimit As Integer = 100,
                                            Optional ByRef retEleList As List(Of String) = Nothing) As IResponse
            Dim creditQuery As ICreditMemoQuery = ConCheck(qbConMgr).MessageSetRequest.AppendCreditMemoQueryRq
            ' setting filter
            With creditQuery.ORTxnQuery
                ' checking for customer id or txnid filter
                If (listID IsNot Nothing) Then
                    .TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(listID)
                ElseIf (txnID IsNot Nothing) Then
                    .TxnIDList.Add(txnID)
                End If
                ' checking for ret element list
                For Each s As String In retEleList
                    creditQuery.IncludeRetElementList.Add(s)
                Next

                ' checking dates
                With .TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter
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
                        .TxnFilter.MaxReturned.SetValue(responseLimit)
                    Case Is <> 100
                        .TxnFilter.MaxReturned.SetValue(responseLimit)
                End Select
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function CustomerQuery(Optional ByVal listID As String = Nothing, Optional ByVal retEleList As List(Of String) = Nothing,
                                             Optional ByVal balanceFilter As ITotalBalanceFilter = Nothing, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim custQuery As ICustomerQuery = ConCheck(qbConMgr).MessageSetRequest.AppendCustomerQueryRq
            If (listID IsNot Nothing) Then
                custQuery.ORCustomerListQuery.ListIDList.Add(listID)
            End If
            ' checking if balance filter transfered
            If (balanceFilter IsNot Nothing) Then
                custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Operator.SetValue(balanceFilter.Operator.GetValue)
                custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Amount.SetValue(balanceFilter.Amount.GetValue)
            End If
            ' checking for ret element list
            For Each s As String In retEleList
                custQuery.IncludeRetElementList.Add(s)
            Next

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function


        Public Shared Function ItemQuery(Optional ByVal listID As String = Nothing, Optional ByRef retEleList As List(Of String) = Nothing,
                                         Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim iQuery As IItemQuery = ConCheck(qbConMgr).MessageSetRequest.AppendItemQueryRq

            If (listID IsNot Nothing) Then
                iQuery.ORListQuery.ListIDList.Add(listID)
            End If
            If (retEleList IsNot Nothing) Then
                For Each s As String In retEleList
                    iQuery.IncludeRetElementList.Add(s)
                Next
            End If
            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function VendorQuery(Optional ByVal listID As String = Nothing, Optional ByRef retEleList As List(Of String) = Nothing, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim vendQ As IVendorQuery = ConCheck(qbConMgr).MessageSetRequest.AppendVendorQueryRq
            If (listID IsNot Nothing) Then
                vendQ.ORVendorListQuery.ListIDList.Add(listID)
            End If
            If (retEleList IsNot Nothing) Then
                For Each s As String In retEleList
                    vendQ.IncludeRetElementList.Add(s)
                Next
            End If

            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function

        Public Shared Function AccountQuery(ByVal accType As ENAccountType, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim accQ As IAccountQuery = ConCheck(qbConMgr).MessageSetRequest.AppendAccountQueryRq
            accQ.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(accType)


            Return ConCheck(qbConMgr).GetRespList.GetAt(0)
        End Function
    End Class

    Friend Class QBMethods

        Public Shared Function ConvertToInvObjs(ByRef resp As IResponse, Optional ByVal newestFirst As Boolean = False) As List(Of QBInvoiceObj)
            ' return list
            Dim invObjList As New List(Of QBInvoiceObj)
            ' making sure resp is invoice
            If (resp.Type.GetValue = ENResponseType.rtInvoiceQueryRs) Then
                Dim invRetList As IInvoiceRetList = resp.Detail
                For i = 0 To invRetList.Count - 1
                    Dim invRet As IInvoiceRet = invRetList.GetAt(i)
                    Dim invObj As New QBInvoiceObj
                    invObj.TxnID = invRet.TxnID.GetValue
                    If (invRet.BalanceRemaining IsNot Nothing) Then
                        invObj.BalanceRemaining = invRet.BalanceRemaining.GetValue
                    End If
                    If (invRet.DueDate IsNot Nothing) Then
                        invObj.DueDate = invRet.DueDate.GetValue
                    End If
                    If (invRet.TxnDate IsNot Nothing) Then
                        invObj.TxnDate = invRet.TxnDate.GetValue
                    End If
                    If (invRet.EditSequence IsNot Nothing) Then
                        invObj.EditSequence = invRet.EditSequence.GetValue
                    End If
                    If (invRet.Other IsNot Nothing) Then
                        invObj.Other = invRet.Other.GetValue
                    End If
                    ' checking for line items
                    If (invRet.ORInvoiceLineRetList IsNot Nothing) Then
                        For i2 = 0 To invRet.ORInvoiceLineRetList.Count - 1
                            Dim lineRet As IORInvoiceLineRet = invRet.ORInvoiceLineRetList.GetAt(i2)
                            Dim line As New QBLineItemObj
                            With lineRet.InvoiceLineRet
                                line.Desc = lineRet.InvoiceLineRet.Desc.GetValue
                                line.ItemListID = .ItemRef.ListID.GetValue
                                line.Quantity = .Quantity.GetValue
                                line.Rate = .ORRate.Rate.GetValue
                                If (.Other1 IsNot Nothing) Then
                                    line.Other1 = .Other1.GetValue
                                End If
                                If (.Other2 IsNot Nothing) Then
                                    line.Other2 = .Other2.GetValue
                                End If
                            End With
                            ' add to invObj
                            invObj.LineList.Add(line)
                        Next
                    End If
                    ' checking for linked txns
                    If (invRet.LinkedTxnList IsNot Nothing) Then
                        For i2 = 0 To invRet.LinkedTxnList.Count - 1
                            Dim linkRet As ILinkedTxn = invRet.LinkedTxnList.GetAt(i2)
                            Dim linkTxn As New QBLinkedTxnObj
                            With linkRet
                                linkTxn.TxnID = .TxnID.GetValue
                                linkTxn.TxnType = .TxnType.GetValue
                                linkTxn.RefNumber = .RefNumber.GetValue
                                linkTxn.Amount = .Amount.GetValue
                            End With
                            ' add to invOBj
                            invObj.LinkTxnList.Add(linkTxn)
                        Next
                    End If
                    ' adding to return list
                    invObjList.Add(invObj)
                Next
            End If

            ' checking if order needs to be flipped
            If (newestFirst) Then
                invObjList.Reverse()
            End If
            Return invObjList
        End Function

        ''' <summary>
        ''' Function takes a RecievePaymentQueryRs or an InvoiceQueryRs and 
        ''' its LinkedTxn's that are Payments (using other methods to get complete data) and returns a List (Of QBRecievePaymentObj)
        ''' </summary>
        ''' <param name="resp">RecievePaymentQueryRs or InvoiceQueryRs</param>
        ''' <param name="newestFirst">List comes out oldest (by TxnDate) Payment first by default.</param>
        ''' <returns>List (Of QBRecievePaymentObj)</returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertToPayObjs(ByRef resp As IResponse, Optional ByVal newestFirst As Boolean = False) As List(Of QBRecievePaymentObj)
            ' return list
            Dim payObjList As New List(Of QBRecievePaymentObj)

            ' checking what response it is
            If (resp.Type.GetValue = ENResponseType.rtReceivePaymentQueryRs) Then
                Dim payRetList As IReceivePaymentRetList = resp.Detail
                For i = 0 To payRetList.Count - 1
                    Dim payRet As IReceivePaymentRet = payRetList.GetAt(i)
                    Dim payObj As New QBRecievePaymentObj
                    With payObj
                        .TxnID = payRet.TxnID.GetValue
                        .TxnDate = payRet.TxnDate.GetValue
                        .EditSequence = payRet.EditSequence.GetValue
                        .TotalAmount = payRet.TotalAmount.GetValue
                        .RefNumber = payRet.RefNumber.GetValue
                        .CustomerListID = payRet.CustomerRef.ListID.GetValue
                        .PayTypeName = payRet.PaymentMethodRef.FullName.GetValue
                        .UnusedPayment = payRet.UnusedPayment.GetValue
                    End With
                Next
            ElseIf (resp.Type.GetValue = ENResponseType.rtInvoiceQueryRs) Then
                ' get linked txns from query rs
                Dim linkObjList As List(Of QBLinkedTxnObj) = ConvertToLinkedTxnObjs(resp)
                ' now get objList
                payObjList = ConvertToPayObjs(linkObjList, newestFirst)
            Else
                MessageBox.Show("UNKNOWN QUERY RECEIEVED - UNABLE TO PROCESS - FATAL ERROR")
                Return payObjList
            End If

            ' sort list by txn date, oldest to newest
            payObjList.Sort(Function(x, y) x.TxnDate.CompareTo(y.TxnDate))
            If (newestFirst) Then
                payObjList.Reverse()
            End If
            Return payObjList
        End Function

        Private Shared Function ConvertToPayObjs(ByVal linkObjList As List(Of QBLinkedTxnObj), Optional ByVal newestFirst As Boolean = False) As List(Of QBRecievePaymentObj)
            ' return list
            Dim payObjList As New List(Of QBRecievePaymentObj)

            ' only need a couple of fields for returning this info so going to limit here
            Dim retEleList As New List(Of String)
            With retEleList
                .Add("TxnID")
                .Add("TxnDate")
                .Add("EditSequence")
                .Add("TotalAmount")
                .Add("RefNumber")
                .Add("listID")
                .Add("PayMethodRef")
                .Add("UnusedPayment")
            End With

            For Each linkObj As QBLinkedTxnObj In linkObjList
                Dim resp As IResponse = QBRequests.PaymentQuery(txnID:=linkObj.TxnID, retEleList:=retEleList)
                Dim payRetList As IReceivePaymentRetList = resp.Detail
                For i = 0 To payRetList.Count - 1
                    Dim payRet As IReceivePaymentRet = payRetList.GetAt(i)
                    Dim payObj As New QBRecievePaymentObj
                    With payObj
                        .TxnID = payRet.TxnID.GetValue
                        .TxnDate = payRet.TxnDate.GetValue
                        .EditSequence = payRet.EditSequence.GetValue
                        .TotalAmount = payRet.TotalAmount.GetValue
                        .RefNumber = payRet.RefNumber.GetValue
                        .CustomerListID = payRet.CustomerRef.ListID.GetValue
                        .PayTypeName = payRet.PaymentMethodRef.FullName.GetValue
                        .UnusedPayment = payRet.UnusedPayment.GetValue
                    End With
                Next
            Next

            ' sort list by txn date, oldest to newest
            payObjList.Sort(Function(x, y) x.TxnDate.CompareTo(y.TxnDate))
            If (newestFirst) Then
                payObjList.Reverse()
            End If
            Return payObjList
        End Function

        Public Shared Function ConvertToLinkedTxnObjs(ByRef resp As IResponse) As List(Of QBLinkedTxnObj)
            ' return list
            Dim linkObjList As New List(Of QBLinkedTxnObj)

            Dim invRetList As IInvoiceRetList = resp.Detail
            For i = 0 To invRetList.Count - 1
                Dim invRet As IInvoiceRet = invRetList.GetAt(i)
                If (invRet.LinkedTxnList IsNot Nothing) Then
                    For i2 = 0 To invRet.LinkedTxnList.Count - 1
                        Dim linkTxn As ILinkedTxn = invRet.LinkedTxnList.GetAt(i2)
                        ' creating linkObj
                        Dim linkObj As New QBLinkedTxnObj
                        With linkObj
                            .TxnID = linkTxn.TxnType.GetValue
                            .TxnID = linkTxn.TxnID.GetValue
                            .TxnDate = linkTxn.TxnDate.GetValue
                            .RefNumber = linkTxn.RefNumber.GetValue
                            .Amount = linkTxn.Amount.GetValue
                        End With
                        ' adding to return list
                        linkObjList.Add(linkObj)
                    Next
                End If
            Next
            
            Return linkObjList
        End Function

        Public Shared Function ConvertToCreditObjs(ByRef resp As IResponse, Optional ByVal newestFirst As Boolean = False) As List(Of QBCreditObj)
            ' return list
            Dim creditObjList As New List(Of QBCreditObj)

            Dim creditRetList As ICreditMemoRetList = resp.Detail
            For i = 0 To creditRetList.Count - 1
                Dim creditRet As ICreditMemoRet = creditRetList.GetAt(i)
                Dim creditObj As New QBCreditObj
                With creditObj
                    .TxnID = creditRet.TxnID.GetValue
                    .EditSequence = creditRet.EditSequence.GetValue
                    .TotalAmount = creditRet.TotalAmount.GetValue
                    .CreditRemaining = creditRet.CreditRemaining.GetValue
                End With
                ' add to ret list
                creditObjList.Add(creditObj)
            Next

            If (newestFirst) Then
                creditObjList.Reverse()
            End If
            Return creditObjList
        End Function

        Public Shared Function UseCredit(ByRef invObj As QBInvoiceObj, ByRef creditObj As QBCreditObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            ' creating payment to apply
            Dim payObj As New QBRecievePaymentObj
            ' setting to customer thats on the invoice
            payObj.CustomerListID = invObj.CustomerListID
            ' adding applied txn
            Dim appInv As New QBInvoiceObj
            appInv.TxnID = invObj.TxnID

            ' creating applied inv item from the row
            Dim appCredit As QBCreditObj = New QBCreditObj
            appCredit.TxnID = creditObj.TxnID
            If (creditObj.CreditRemaining >= invObj.BalanceRemaining) Then
                ' if remaining credit is greater than balance, apply balance
                appCredit.AppliedAmount = invObj.BalanceRemaining
                creditObj.CreditRemaining = invObj.BalanceRemaining
            Else
                appCredit.AppliedAmount = creditObj.CreditRemaining
                creditObj.CreditRemaining = 0
            End If

            ' adding credit and applied invoice
            appInv.SetCreditList.Add(appCredit)
            payObj.AppliedInvList.Add(appInv)

            ' update remaining on invoiceObj
            invObj.BalanceRemaining = appCredit.AppliedAmount
            Return QBRequests.PaymentAdd(payObj, qbConMgr:=ConCheck(qbConMgr), autoApply:=False)
        End Function

        Public Shared Function UseOverpayment(ByRef payObj As QBRecievePaymentObj, ByRef invObj As QBInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            ' going to use passed payObj as mod obj
            payObj.AppliedInvList.Add(invObj)
            ' checking how much we can apply
            If (payObj.UnusedPayment >= invObj.BalanceRemaining) Then
                invObj.AppliedPaymentAmount = invObj.BalanceRemaining
                ' update balances
                invObj.BalanceRemaining = 0
                payObj.UnusedPayment = payObj.UnusedPayment - invObj.BalanceRemaining
            Else
                invObj.AppliedPaymentAmount = payObj.UnusedPayment
                ' update balances
                payObj.UnusedPayment = 0
                invObj.BalanceRemaining = invObj.BalanceRemaining - payObj.UnusedPayment
            End If

            Return QBRequests.PaymentMod(payObj, qbConMgr:=ConCheck(qbConMgr))
        End Function


        ' these will take a query and turn it into a combo box pair of name/listid
        Public Overloads Shared Function GetComboBoxPair(ByRef retList As IItemServiceRetList) As List(Of ComboBoxPair)
            Dim pairList As New List(Of ComboBoxPair)
            For i = 0 To retList.Count - 1
                Dim ret As IItemServiceRet = retList.GetAt(i)
                Dim pair As New ComboBoxPair
                pair.DisplayMember = ret.FullName.GetValue
                pair.ValueMember = ret.ListID.GetValue
                pairList.Add(pair)
            Next

            Return pairList
        End Function
        Public Overloads Shared Function GetComboBoxPair(ByRef retList As IItemOtherChargeRetList) As List(Of ComboBoxPair)
            Dim pairList As New List(Of ComboBoxPair)
            For i = 0 To retList.Count - 1
                Dim ret As IItemOtherChargeRet = retList.GetAt(i)
                Dim pair As New ComboBoxPair
                pair.DisplayMember = ret.FullName.GetValue
                pair.ValueMember = ret.ListID.GetValue
                pairList.Add(pair)
            Next

            Return pairList
        End Function
        Public Overloads Shared Function GetComboBoxPair(ByRef retList As IVendorRetList) As List(Of ComboBoxPair)
            Dim pairList As New List(Of ComboBoxPair)
            For i = 0 To retList.Count - 1
                Dim ret As IVendorRet = retList.GetAt(i)
                Dim pair As New ComboBoxPair
                pair.DisplayMember = ret.Name.GetValue
                pair.ValueMember = ret.ListID.GetValue
                pairList.Add(pair)
            Next

            Return pairList
        End Function
        Public Overloads Shared Function GetComboBoxPair(ByRef retList As IAccountRetList) As List(Of ComboBoxPair)
            Dim pairList As New List(Of ComboBoxPair)
            For i = 0 To retList.Count - 1
                Dim ret As IAccountRet = retList.GetAt(i)
                Dim pair As New ComboBoxPair
                pair.DisplayMember = ret.Name.GetValue
                pair.ValueMember = ret.ListID.GetValue
                pairList.Add(pair)
            Next

            Return pairList
        End Function





        Public Shared Sub ResponseErr_Misc(ByVal resp As IResponse)
            If (resp.StatusCode = 1) Then
                MsgBox("No matching results from Quickbooks")
            Else
                Try
                    AppQTA.ERR_MISC_Insert(resp.Type.GetValue.ToString,
                                           resp.StatusCode.ToString,
                                           resp.StatusMessage,
                                           Date.Now)


                    MsgBox("Error Encounterd with Quickbooks. Contact Premier.", MsgBoxStyle.Critical)
                Catch ex As Exception
                    MsgBox("ERR_MISC_Insert: " & ex.Message)
                End Try
            End If
        End Sub
    End Class
End Namespace