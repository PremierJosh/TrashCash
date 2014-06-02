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

        ' check add
        Public Shared Function CheckAdd(ByRef checkObj As QBCheckAddObj) As IResponse
            Dim addRq As ICheckAdd = GlobalConMgr.MessageSetRequest.AppendCheckAddRq
            'account ref is bank paying from
            addRq.AccountRef.ListID.SetValue(checkObj.AccountListID)
            ' payee is vendor
            addRq.PayeeEntityRef.ListID.SetValue(checkObj.PayeeListID)
            ' ref number is returncheck
            addRq.RefNumber.SetValue(checkObj.RefNumber)
            ' not printing
            addRq.IsToBePrinted.SetValue(checkObj.IsToBePrinted)
            For Each item As QBLineItemObj In checkObj.LineList
                Dim line As IORItemLineAdd = addRq.ORItemLineAddList.Append
                line.ItemLineAdd.ItemRef.ListID.SetValue(item.ItemListID)
                line.ItemLineAdd.Amount.SetValue(item.Rate)
                line.ItemLineAdd.Quantity.SetValue(1)
            Next

            Return GlobalConMgr.GetRespList.GetAt(0)
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
        Public Shared Function CreditMemoAdd(ByRef creditAddObj As QBAddCreditObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
            Dim credAdd As ICreditMemoAdd = ConCheck(qbConMgr).MessageSetRequest.AppendCreditMemoAddRq
            With credAdd
                .CustomerRef.ListID.SetValue(creditAddObj.CustomerListID)
                .IsToBePrinted.SetValue(creditAddObj.IsToBePrinted)
            End With

            Dim creditLine As IORCreditMemoLineAdd = credAdd.ORCreditMemoLineAddList.Append
            With creditLine.CreditMemoLineAdd
                .ItemRef.ListID.SetValue(creditAddObj.ItemListID)
                .ORRatePriceLevel.Rate.SetValue(creditAddObj.CreditAmount)
            End With

            Dim descLine As IORCreditMemoLineAdd = credAdd.ORCreditMemoLineAddList.Append
            With descLine.CreditMemoLineAdd
                .Desc.SetValue(creditAddObj.Desc)
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
                .CustomerRef.ListID.SetValue(payObj.CustomerListID)
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
                                            Optional ByVal retEleList As List(Of String) = Nothing, Optional ByVal incLineItems As Boolean = False) As IResponse
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


        Public Shared Function ServiceItemQuery(Optional ByVal listID As String = Nothing, Optional ByRef retEleList As List(Of String) = Nothing,
                                         Optional ByRef qbConMgr As QBConMgr = Nothing) As IItemServiceRetList
            Dim iQuery As IItemServiceQuery = ConCheck(qbConMgr).MessageSetRequest.AppendItemServiceQueryRq

            If (listID IsNot Nothing) Then
                iQuery.ORListQueryWithOwnerIDAndClass.ListIDList.Add(listID)
            End If
            If (retEleList IsNot Nothing) Then
                For Each s As String In retEleList
                    iQuery.IncludeRetElementList.Add(s)
                Next
            End If
            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                Return resp.Detail
            Else
                QBMethods.ResponseErr_Misc(resp)
                Return Nothing
            End If
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
                    Dim invObj As QBInvoiceObj = ConvertToInvObj(invRetList.GetAt(i))
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

        Public Shared Function ConvertToInvObj(ByRef invRet As IInvoiceRet) As QBInvoiceObj
            Dim invObj As New QBInvoiceObj
            With invObj
                .TxnID = invRet.TxnID.GetValue
                If (invRet.BalanceRemaining IsNot Nothing) Then
                    .BalanceRemaining = invRet.BalanceRemaining.GetValue
                End If
                If (invRet.DueDate IsNot Nothing) Then
                    .DueDate = invRet.DueDate.GetValue
                End If
                If (invRet.TxnDate IsNot Nothing) Then
                    .TxnDate = invRet.TxnDate.GetValue
                End If
                If (invRet.EditSequence IsNot Nothing) Then
                    .EditSequence = invRet.EditSequence.GetValue
                End If
                If (invRet.Other IsNot Nothing) Then
                    .Other = invRet.Other.GetValue
                End If
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
                        .LineList.Add(line)
                    Next
                End If
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
                        .LinkTxnList.Add(linkTxn)
                    Next
                End If
            End With

            Return invObj
        End Function

        ''' <summary>
        ''' Function takes a RecievePaymentQueryRs or an InvoiceQueryRs and 
        ''' its LinkedTxn's that are Payments (using other methods to get complete data) and returns a List (Of QBRecievePaymentObj)
        ''' </summary>
        ''' <param name="resp">RecievePaymentQueryRs or InvoiceQueryRs</param>
        ''' <param name="newestFirst">List comes out oldest (by TxnDate) Payment first by default.</param>
        ''' <returns>List (Of QBRecievePaymentObj)</returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function ConvertToPayObjs(ByRef resp As IResponse, Optional ByVal newestFirst As Boolean = False) As List(Of QBRecievePaymentObj)
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
                    If (payRet.AppliedToTxnRetList IsNot Nothing) Then
                        payObj.AppliedInvList = New List(Of QBInvoiceObj)
                        For l = 0 To payRet.AppliedToTxnRetList.Count - 1
                            Dim appTxnRet As IAppliedToTxnRet = payRet.AppliedToTxnRetList.GetAt(l)
                            ' only want invoices
                            If (appTxnRet.TxnType.GetValue = ENTxnType.ttInvoice) Then
                                Dim appInv As New QBInvoiceObj
                                appInv.TxnID = appTxnRet.TxnID.GetValue
                                appInv.AppliedPaymentAmount = appTxnRet.Amount.GetValue

                                ' add to list
                                payObj.AppliedInvList.Add(appInv)
                            End If
                        Next
                    End If
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

        Public Overloads Shared Function ConvertToPayObjs(ByVal linkObjList As List(Of QBLinkedTxnObj), Optional ByVal newestFirst As Boolean = False) As List(Of QBRecievePaymentObj)
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
                If (linkObj.TxnType = ENTxnType.ttReceivePayment) Then
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
                        'add to list
                        payObjList.Add(payObj)
                    Next
                End If
            Next

            ' sort list by txn date, oldest to newest
            payObjList.Sort(Function(x, y) x.TxnDate.CompareTo(y.TxnDate))
            If (newestFirst) Then
                payObjList.Reverse()
            End If
            Return payObjList
        End Function

        Private Shared Function ConvertToLinkedTxnObjs(ByRef resp As IResponse) As List(Of QBLinkedTxnObj)
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

        Private Shared Function ConvertToCreditObjs(ByRef resp As IResponse, Optional ByVal newestFirst As Boolean = False) As List(Of QBCreditObj)
            ' return list
            Dim creditObjList As New List(Of QBCreditObj)
            If (resp.Type.GetValue = ENResponseType.rtCreditMemoQueryRs) Then
                Dim creditRetList As ICreditMemoRetList = resp.Detail
                For i = 0 To creditRetList.Count - 1
                    ' add to ret list
                    creditObjList.Add(ConvertToCreditObj(creditRetList.GetAt(i)))
                Next
            ElseIf (resp.Type.GetValue = ENResponseType.rtCreditMemoAddRs) Then
                ' add to ret list
                creditObjList.Add(ConvertToCreditObj(resp.Detail))
            End If

            If (newestFirst) Then
                creditObjList.Reverse()
            End If
            Return creditObjList
        End Function

        Public Shared Function ConvertToCreditObj(ByRef creditRet As ICreditMemoRet) As QBCreditObj
            Dim creditObj As New QBCreditObj
            With creditObj
                .TxnID = creditRet.TxnID.GetValue
                .TxnDate = creditRet.TxnDate.GetValue
                .EditSequence = creditRet.EditSequence.GetValue
                .TotalAmount = creditRet.TotalAmount.GetValue
                .CreditRemaining = creditRet.CreditRemaining.GetValue
                .CustomerListID = creditRet.CustomerRef.ListID.GetValue
            End With
            Return creditObj
        End Function

        Private Shared Function UseCredit(ByRef creditObj As QBCreditObj, ByRef invObj As QBInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As IResponse
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

        Public Shared Function UseOverpaymentsOnInvoices(ByRef payObjList As List(Of QBRecievePaymentObj), ByRef invObjList As List(Of QBInvoiceObj), Optional ByRef qbConMgr As QBConMgr = Nothing) As Boolean
            ' err counter
            Dim err As Integer = 0

            ' checking if new customer has unapplied payments and open invoices we can pay
            If (payObjList.Count > 0) Then
                If (invObjList.Count > 0) Then
                    For Each pay As QBRecievePaymentObj In payObjList
                        If (pay.UnusedPayment > 0) Then
                            For Each invObj As QBInvoiceObj In invObjList
                                If (invObj.BalanceRemaining > 0) Then
                                    If (pay.AppliedInvList Is Nothing) Then
                                        pay.AppliedInvList = New List(Of QBInvoiceObj)
                                    End If
                                    ' going to use passed payObj as mod obj
                                    pay.AppliedInvList.Add(invObj)
                                    ' checking how much we can apply
                                    If (pay.UnusedPayment >= invObj.BalanceRemaining) Then
                                        invObj.AppliedPaymentAmount = invObj.BalanceRemaining
                                        ' update balances
                                        invObj.BalanceRemaining = 0
                                        pay.UnusedPayment = pay.UnusedPayment - invObj.BalanceRemaining
                                    Else
                                        invObj.AppliedPaymentAmount = pay.UnusedPayment
                                        ' update balances
                                        pay.UnusedPayment = 0
                                        invObj.BalanceRemaining = invObj.BalanceRemaining - pay.UnusedPayment
                                    End If
                                    ' send invoice
                                    Dim resp As IResponse = QBRequests.PaymentMod(pay)
                                    If (resp.StatusCode = 0) Then
                                        Dim ret As IReceivePaymentRet = resp.Detail
                                        Try
                                            ' attempting to update history edit seq
                                            Using ta As New ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter
                                                ta.UpdateEditSeq(ret.TxnID.GetValue, ret.EditSequence.GetValue)
                                            End Using
                                        Catch ex As SqlException
                                            MessageBox.Show(
                                                "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End Try
                                    Else
                                        err += 1
                                        ResponseErr_Misc(resp)
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            End If

            If (err = 0) Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' This sub will take a QBInvoiceObj and attempt to pay it using unused credits first, and then unused payments and will update the passed invObj
        ''' </summary>
        ''' <param name="invObj">QB Invoice that needs to be paid by the attached Customer</param>
        ''' <param name="newestFundsFirst">Use oldest Credit Memos and Payments first</param>
        ''' <param name="qbConMgr">Alternate ConMgr for multi-thread use</param>
        ''' <remarks></remarks>
        ''' 
        Public Shared Sub PayInvoice(ByRef invObj As QBInvoiceObj, Optional ByVal newestFundsFirst As Boolean = False, Optional ByRef qbConMgr As QBConMgr = Nothing)
            ' get list of creditObjs avail for use
            Dim creditResp As IResponse = QBRequests.CreditMemoQuery(listID:=invObj.CustomerListID, qbConMgr:=ConCheck(qbConMgr))
            Dim creditObjList As List(Of QBCreditObj) = ConvertToCreditObjs(creditResp, newestFirst:=newestFundsFirst)
            If (creditObjList.Count > 0) Then
                For i = 0 To creditObjList.Count - 1
                    If (invObj.BalanceRemaining > 0) Then
                        Dim credit As QBCreditObj = creditObjList(i)
                        If (credit.CreditRemaining > 0) Then
                            Dim resp As IResponse = UseCredit(invObj:=invObj, creditObj:=credit, qbConMgr:=ConCheck(qbConMgr))
                            If (resp.StatusCode <> 0) Then
                                ResponseErr_Misc(resp)
                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If
            ' checking for overpayments if invoice has balance
            If (invObj.BalanceRemaining > 0) Then
                ' make sure i get already attached txns
                Dim s As New List(Of String)
                With s
                    .Add("TxnID")
                    .Add("TxnDate")
                    .Add("EditSequence")
                    .Add("TotalAmount")
                    .Add("RefNumber")
                    .Add("CustomerRef")
                    .Add("PaymentMethodRef")
                    .Add("UnusedPayment")
                    .Add("AppliedToTxnRetList")
                End With
                Dim payResp As IResponse = QBRequests.PaymentQuery(listID:=invObj.CustomerListID, retEleList:=s, qbConMgr:=ConCheck(qbConMgr))
                Dim payObjList As List(Of QBRecievePaymentObj) = ConvertToPayObjs(payResp, newestFirst:=newestFundsFirst)
                ' putting invoice into a list for overpayment sub
                Dim invList As New List(Of QBInvoiceObj)
                invList.Add(invObj)
                Dim pass As Boolean = UseOverpaymentsOnInvoices(payObjList:=payObjList, invObjList:=invList, qbConMgr:=ConCheck(qbConMgr))
                If (Not pass) Then
                    MsgBox("Overpayment use fail on PayInvoice sub. Contact premier.")
                End If
            End If
        End Sub

        ''' <summary>
        ''' This sub will take a QBCreditObj and attempt to use it to pay exisiting invoices and will update the passed creditAddObj
        ''' </summary>
        ''' <param name="creditObj">Newly created QB Credit Memo thats going to pay attached Customers open Invoices</param>
        ''' <param name="newestInvsFirst">Pay oldest Invoices first</param>
        ''' <param name="qbConMgr">Alternate ConMgr for multi-thread use</param>
        ''' <remarks></remarks>
        Public Shared Sub UseNewCredit(ByRef creditObj As QBCreditObj, Optional ByVal newestInvsFirst As Boolean = False, Optional ByRef qbConMgr As QBConMgr = Nothing)
            ' getting list of unpaid invoices
            Dim qResp As IResponse = QBRequests.InvoiceQuery(listID:=creditObj.CustomerListID, paidStatus:=ENPaidStatus.psNotPaidOnly, qbConMgr:=ConCheck(qbConMgr))
            Dim invObjList As List(Of QBInvoiceObj) = ConvertToInvObjs(qResp, newestFirst:=newestInvsFirst)
            If (invObjList.Count > 0) Then
                For i = 0 To invObjList.Count - 1
                    If (creditObj.CreditRemaining > 0) Then
                        Dim resp As IResponse = UseCredit(creditObj, invObjList.Item(i), ConCheck(qbConMgr))
                        If (resp.StatusCode <> 0) Then
                            ResponseErr_Misc(resp)
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If
        End Sub



        ' useful function to take a set of invoicews and return the earliest creation date
        Public Shared Function Invoices_EarliestCreationDate(ByRef invList As List(Of QBInvoiceObj)) As Date
            ' return date var
            Dim earliestDate As Date = Nothing
            For Each inv As QBInvoiceObj In invList
                Dim invQuery As IInvoiceQuery = GlobalConMgr.MessageSetRequest.AppendInvoiceQueryRq
                invQuery.ORInvoiceQuery.TxnIDList.Add(inv.TxnID)
                ' only need creation date back
                invQuery.IncludeRetElementList.Add("TxnDate")
                Dim resp As IResponse = GlobalConMgr.GetRespList.GetAt(0)
                Dim invRet As IInvoiceRet = resp.Detail
                ' checking if this create date is before the earliest we have so far
                If (invRet.TimeCreated.GetValue < earliestDate) Then
                    earliestDate = invRet.TimeCreated.GetValue
                End If
            Next
            Return earliestDate
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