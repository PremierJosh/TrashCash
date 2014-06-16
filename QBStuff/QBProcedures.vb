Imports TrashCash.Customer
Imports TrashCash.Payments
Imports QBFC12Lib


Namespace QBStuff
    Friend Class QBRequests

        ' misc
        Public Shared Function TxnVoid(ByVal txnID As String, ByVal voidType As ENTxnVoidType, Optional ByRef qbConMgr As QBConMgr = Nothing) As Integer
            Dim txnVoidRq As ITxnVoid = ConCheck(qbConMgr).MessageSetRequest.AppendTxnVoidRq
            With txnVoidRq
                .TxnID.SetValue(txnID)
                .TxnVoidType.SetValue(voidType)
            End With

            Return ConCheck(qbConMgr).GetRespList.GetAt(0).StatusCode
        End Function

        ' check add
        Public Shared Function CheckAdd(ByRef checkObj As QBCheckObj, Optional ByRef message As String = Nothing) As Integer
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
            Dim resp As IResponse = GlobalConMgr.GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                checkObj.TxnID = CType(resp.Detail, ICheckRet).TxnID.GetValue
            Else

            End If
            'checking if response message is requested
            If (message IsNot Nothing) Then
                message = resp.StatusMessage
            End If
            
            Return resp.StatusCode
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

        Public Shared Function Customer_GetEditSequence(ByVal custListID As String) As String
            Dim custQuery As ICustomerQuery = GlobalConMgr.MessageSetRequest.AppendCustomerQueryRq
            custQuery.ORCustomerListQuery.ListIDList.Add(custListID)
            custQuery.IncludeRetElementList.Add("EditSequence")

            Dim respList As IResponseList = GlobalConMgr.GetRespList
            Dim response As IResponse = respList.GetAt(0)
            If (response.StatusCode = 0) Then
                If (response.Detail IsNot Nothing) Then
                    Dim custRetList As ICustomerRetList = response.Detail
                    For j = 0 To custRetList.Count - 1
                        Dim custRet As ICustomerRet = custRetList.GetAt(j)
                        Return custRet.EditSequence.GetValue()
                    Next j
                End If
            Else
                ' error logging
                QBMethods.ResponseErr_Misc(response)
            End If
            Return Nothing
        End Function

        ' invoicing
        Public Overloads Shared Function InvoiceAdd(ByRef invObj As QBInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                                    Optional ByRef message As String = Nothing) As Integer
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

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                invObj = QBMethods.ConvertToInvObjs(resp).Item(0)
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' checking if message is passed
            If (message IsNot Nothing) Then
                message = resp.StatusMessage
            End If

            Return resp.StatusCode
        End Function

        ' crediting
        Public Shared Function CreditMemoAdd(ByRef creditObj As QBCreditObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As Integer
            Dim credAdd As ICreditMemoAdd = ConCheck(qbConMgr).MessageSetRequest.AppendCreditMemoAddRq
            With credAdd
                .CustomerRef.ListID.SetValue(creditObj.CustomerListID)
                .IsToBePrinted.SetValue(creditObj.IsToBePrinted)
                If (creditObj.DateOfCredit <> Nothing) Then
                    .TxnDate.SetValue(creditObj.DateOfCredit)
                End If
            End With

            Dim creditLine As IORCreditMemoLineAdd = credAdd.ORCreditMemoLineAddList.Append
            With creditLine.CreditMemoLineAdd
                .ItemRef.ListID.SetValue(creditObj.ItemListID)
                .ORRatePriceLevel.Rate.SetValue(creditObj.TotalAmount)
            End With

            Dim descLine As IORCreditMemoLineAdd = credAdd.ORCreditMemoLineAddList.Append
            With descLine.CreditMemoLineAdd
                .Desc.SetValue(creditObj.Desc)
                .ItemRef.ListID.Unset()
                .ItemRef.FullName.Unset()
                .Amount.Unset()
                .Quantity.Unset()
            End With
            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                creditObj = QBMethods.ConvertToCreditObjs(resp).Item(0)
                creditObj.EditSequence = CType(resp.Detail, ICreditMemoRet).EditSequence.GetValue
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function

        ' payments
        Public Overloads Shared Function PaymentAdd(ByRef payObj As QBRecievePaymentObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                          Optional ByVal autoApply As Boolean = True, Optional ByRef message As String = Nothing) As Integer
            Dim payAdd As IReceivePaymentAdd = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentAddRq
            With payAdd
                .CustomerRef.ListID.SetValue(payObj.CustomerListID)
                If (payObj.TotalAmount <> Nothing) Then
                    .TotalAmount.SetValue(payObj.TotalAmount)
                End If
                If (payObj.PayTypeName IsNot Nothing) Then
                    .PaymentMethodRef.FullName.SetValue(payObj.PayTypeName)
                End If
                If (payObj.TxnDate <> Nothing) Then
                    .TxnDate.SetValue(payObj.TxnDate)
                End If
                .ORApplyPayment.IsAutoApply.SetValue(autoApply)
                ' optional check number
                If (payObj.RefNumber IsNot Nothing) Then
                    .RefNumber.SetValue(payObj.RefNumber)
                End If
                ' checking if appTxnList isnot nothing
                If (payObj.AppliedInvList IsNot Nothing) Then
                    ' unset auto apply
                    .ORApplyPayment.IsAutoApply.Unset()
                    Dim appTxnList As IAppliedToTxnAddList = .ORApplyPayment.AppliedToTxnAddList
                    For Each invObj As QBInvoiceObj In payObj.AppliedInvList
                        Dim appTxn As IAppliedToTxnAdd = appTxnList.Append
                        appTxn.TxnID.SetValue(invObj.TxnID)
                        ' checking if there is an applied amount
                        If (invObj.AppliedAmount <> Nothing) Then
                            appTxn.PaymentAmount.SetValue(invObj.AppliedAmount)
                        End If
                        ' checking if credit list is applied
                        If (invObj.LinkedCreditList IsNot Nothing) Then
                            Dim setCreditList As ISetCreditList = appTxn.SetCreditList
                            For Each creditObj As QBCreditObj In invObj.LinkedCreditList
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

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                payObj = QBMethods.ConvertToPayObjs(resp).Item(0)
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' checking if response is requestd
            If (message IsNot Nothing) Then
                message = resp.StatusMessage
            End If

            Return resp.StatusCode
        End Function

        Public Overloads Shared Function PaymentMod(ByRef payObj As QBRecievePaymentObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                                     Optional ByVal wipeAppList As Boolean = False) As Integer
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
                    If (invObj.AppliedAmount <> Nothing) Then
                        appTxn.PaymentAmount.SetValue(invObj.AppliedAmount)
                    End If
                    ' checking if credit list is applied
                    If (invObj.LinkedCreditList IsNot Nothing) Then
                        Dim setCreditList As ISetCreditList = appTxn.SetCreditList
                        For Each creditObj As QBCreditObj In invObj.LinkedCreditList
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

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                payObj = QBMethods.ConvertToPayObjs(resp).Item(0)
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function

        ' queries
        Public Overloads Shared Function InvoiceQuery(ByRef invObjList As List(Of QBInvoiceObj), Optional ByVal customerListID As String = Nothing,
                                            Optional ByVal fromDate As Date = Nothing, Optional ByVal toDate As Date = Nothing,
                                            Optional ByVal paidStatus As ENPaidStatus = Nothing, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                            Optional ByVal responseLimit As Integer = 100, Optional ByVal retEleList As List(Of String) = Nothing,
                                            Optional ByVal incLinkTxn As Boolean = False, Optional ByVal incLineItems As Boolean = False) As Integer

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
                If (customerListID IsNot Nothing) Then
                    .InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
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

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            ' if response is good
            If (resp.StatusCode = 0) Then
                invObjList = QBMethods.ConvertToInvObjs(resp)
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function

        Public Overloads Shared Function InvoiceQuery(ByRef invObj As QBInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                    Optional ByVal retEleList As List(Of String) = Nothing, Optional ByVal incLinkTxn As Boolean = False,
                                    Optional ByVal incLineItems As Boolean = False) As Integer

            Dim query As IInvoiceQuery = ConCheck(qbConMgr).MessageSetRequest.AppendInvoiceQueryRq()
            ' setting linked txn and linked line items filter
            With query
                .ORInvoiceQuery.TxnIDList.Add(invObj.TxnID)
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

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                Dim list As List(Of QBInvoiceObj) = QBMethods.ConvertToInvObjs(resp)
                ' list will only have 1 item
                invObj = list.Item(0)
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function

        Public Shared Function PaymentQuery(ByRef payObjList As List(Of QBRecievePaymentObj), Optional ByVal customerListID As String = Nothing, Optional ByVal fromDate As Date = Nothing, Optional ByVal toDate As Date = Nothing,
                                            Optional ByRef qbConMgr As QBConMgr = Nothing, Optional ByVal responseLimit As Integer = 100,
                                            Optional ByVal retEleList As List(Of String) = Nothing, Optional ByVal incLineItems As Boolean = False) As Integer
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
                If (customerListID IsNot Nothing) Then
                    .TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
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

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                payObjList = QBMethods.ConvertToPayObjs(resp)
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function
        Public Shared Function PaymentQuery(ByRef payObj As QBRecievePaymentObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                            Optional ByVal retEleList As List(Of String) = Nothing, Optional ByVal incLineItems As Boolean = False) As Integer
            Dim query As IReceivePaymentQuery = ConCheck(qbConMgr).MessageSetRequest.AppendReceivePaymentQueryRq
            ' setting high level filters
            With query
                ' single payment query from passed object
                .ORTxnQuery.TxnIDList.Add(payObj.TxnID)
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
            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                ' going to come back as ret list but is going to contain only 1 response
                Dim ret As IReceivePaymentRet = CType(resp.Detail, IReceivePaymentRetList).GetAt(0)
                payObj = QBMethods.ConvertToPayObjs(ret).Item(0)
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function

        Public Shared Function CreditMemoQuery(ByRef creditObjList As List(Of QBCreditObj), Optional ByVal customerListID As String = Nothing,
                                               Optional ByRef fromDate As Date = Nothing, Optional ByRef toDate As Date = Nothing,
                                               Optional ByRef qbConMgr As QBConMgr = Nothing, Optional ByVal responseLimit As Integer = 100,
                                               Optional ByRef retEleList As List(Of String) = Nothing) As Integer
            Dim creditQuery As ICreditMemoQuery = ConCheck(qbConMgr).MessageSetRequest.AppendCreditMemoQueryRq
            ' setting filter
            With creditQuery.ORTxnQuery
                ' checking for customer id or txnid filter
                If (customerListID IsNot Nothing) Then
                    .TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(customerListID)
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
            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                creditObjList = QBMethods.ConvertToCreditObjs(resp)
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
        End Function
        Public Shared Function CreditMemoQuery(ByRef creditObj As QBCreditObj, Optional ByRef qbConMgr As QBConMgr = Nothing,
                                              Optional ByRef retEleList As List(Of String) = Nothing) As Integer
            Dim creditQuery As ICreditMemoQuery = ConCheck(qbConMgr).MessageSetRequest.AppendCreditMemoQueryRq
            ' setting filter
            With creditQuery.ORTxnQuery
                ' checking for customer id or txnid filter
                .TxnIDList.Add(creditObj.TxnID)
                ' checking for ret element list
                For Each s As String In retEleList
                    creditQuery.IncludeRetElementList.Add(s)
                Next
            End With
            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                Dim list As List(Of QBCreditObj) = QBMethods.ConvertToCreditObjs(resp)
                ' only going to have 1 item in list
                creditObj = list.Item(0)
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return resp.StatusCode
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

        Public Shared Function OtherChargeItemQuery(Optional ByVal listID As String = Nothing, Optional ByRef retEleList As List(Of String) = Nothing) As IItemOtherChargeRetList
            Dim itemQuery As IItemOtherChargeQuery = GlobalConMgr.MessageSetRequest.AppendItemOtherChargeQueryRq
            ' active items only
            itemQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)
            ' limit response for combo box
            itemQuery.IncludeRetElementList.Add("ListID")
            itemQuery.IncludeRetElementList.Add("FullName")

            Dim respList As IResponseList = GlobalConMgr.GetRespList
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i) '
                If (resp.StatusCode = 0) Then
                    Return resp.Detail
                Else
                    GlobalConMgr.ResponseErr_Misc(resp)
                End If
            Next

            Return Nothing
        End Function

        Public Shared Function VendorQuery(Optional ByVal listID As String = Nothing, Optional ByRef retEleList As List(Of String) = Nothing, Optional ByRef qbConMgr As QBConMgr = Nothing) As IVendorRetList
            Dim vendQ As IVendorQuery = ConCheck(qbConMgr).MessageSetRequest.AppendVendorQueryRq
            If (listID IsNot Nothing) Then
                vendQ.ORVendorListQuery.ListIDList.Add(listID)
            End If
            If (retEleList IsNot Nothing) Then
                For Each s As String In retEleList
                    vendQ.IncludeRetElementList.Add(s)
                Next
            End If
            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                Return resp.Detail
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return Nothing
        End Function

        Public Shared Function AccountQuery(ByVal accType As ENAccountType, Optional ByRef qbConMgr As QBConMgr = Nothing) As IAccountRetList
            Dim accQ As IAccountQuery = ConCheck(qbConMgr).MessageSetRequest.AppendAccountQueryRq
            accQ.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(accType)

            Dim resp As IResponse = ConCheck(qbConMgr).GetRespList.GetAt(0)
            If (resp.StatusCode = 0) Then
                Return resp.Detail
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return Nothing
        End Function
    End Class

    Friend Class QBMethods
        Friend Shared Function ConvertToInvObjs(ByRef resp As IResponse) As List(Of QBInvoiceObj)
            ' return list
            Dim invObjList As New List(Of QBInvoiceObj)
           

            ' making sure resp is invoice
            Select Case resp.Type.GetValue
                Case Is = ENResponseType.rtInvoiceQueryRs
                    Dim retList As IInvoiceRetList = resp.Detail
                    For i = 0 To retList.Count - 1
                        invObjList.Add(ConvertToInvObj(retList.GetAt(i)))
                    Next
                Case Is = ENResponseType.rtInvoiceAddRs
                    invObjList.Add(ConvertToInvObj(resp.Detail))
                Case Else
                    MessageBox.Show("UNKNOWN QUERY RECEIEVED - UNABLE TO PROCESS - FATAL ERROR")
                    Return invObjList
            End Select

            Return invObjList
        End Function

        Private Shared Function ConvertToInvObj(ByRef invRet As IInvoiceRet) As QBInvoiceObj
            Dim invObj As New QBInvoiceObj
            With invObj
                If (invRet.TxnID IsNot Nothing) Then
                    .TxnID = invRet.TxnID.GetValue
                End If
                If (invRet.TimeCreated IsNot Nothing) Then
                    .TimeCreated = invRet.TimeCreated.GetValue
                End If
                If (invRet.RefNumber IsNot Nothing) Then
                    .RefNumber = invRet.RefNumber.GetValue
                End If
                If (invRet.CustomerRef IsNot Nothing) Then
                    .CustomerListID = invRet.CustomerRef.ListID.GetValue
                End If
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
                If (invRet.CustomerRef IsNot Nothing) Then
                    .CustomerFullName = invRet.CustomerRef.FullName.GetValue
                End If
                If (invRet.Subtotal IsNot Nothing) Then
                    .Subtotal = invRet.Subtotal.GetValue
                End If
                If (invRet.ORInvoiceLineRetList IsNot Nothing) Then
                    For i = 0 To invRet.ORInvoiceLineRetList.Count - 1
                        Dim lineRet As IORInvoiceLineRet = invRet.ORInvoiceLineRetList.GetAt(i)
                        Dim line As New QBLineItemObj
                        With lineRet.InvoiceLineRet
                            If (.Desc IsNot Nothing) Then
                                line.Desc = .Desc.GetValue
                            End If
                            If (.ItemRef IsNot Nothing) Then
                                line.ItemListID = .ItemRef.ListID.GetValue
                            End If
                            If (.Quantity IsNot Nothing) Then
                                line.Quantity = .Quantity.GetValue
                            End If
                            If (.ORRate IsNot Nothing) Then
                                line.Rate = .ORRate.Rate.GetValue
                            End If
                            If (.TxnLineID IsNot Nothing) Then
                                line.TxnLineID = .TxnLineID.GetValue
                            End If
                            If (.Amount IsNot Nothing) Then
                                line.Amount = .Amount.GetValue
                            End If
                            If (.Other1 IsNot Nothing) Then
                                line.Other1 = .Other1.GetValue
                            End If
                            If (.Other2 IsNot Nothing) Then
                                line.Other2 = .Other2.GetValue
                            End If
                        End With
                        If (.LineList Is Nothing) Then
                            .LineList = New List(Of QBLineItemObj)
                        End If
                        ' add to invObj
                        .LineList.Add(line)
                    Next
                End If
                If (invRet.LinkedTxnList IsNot Nothing) Then
                    For i = 0 To invRet.LinkedTxnList.Count - 1
                        Dim linkRet As ILinkedTxn = invRet.LinkedTxnList.GetAt(i)
                        ' checking what type of linked txn it is
                        If (linkRet.TxnType.GetValue = ENTxnType.ttReceivePayment) Then
                            Dim payObj As New QBRecievePaymentObj
                            With payObj
                                If (linkRet.TxnID IsNot Nothing) Then
                                    .TxnID = linkRet.TxnID.GetValue
                                End If
                                If (linkRet.Amount IsNot Nothing) Then
                                    .LinkedTxnAmount = linkRet.Amount.GetValue
                                End If
                                If (linkRet.RefNumber IsNot Nothing) Then
                                    .RefNumber = linkRet.RefNumber.GetValue
                                End If
                            End With
                            ' checking if list for applied payments exists already
                            If (.LinkedPaymentList Is Nothing) Then
                                .LinkedPaymentList = New List(Of QBRecievePaymentObj)
                            End If
                            .LinkedPaymentList.Add(payObj)
                        ElseIf (linkRet.TxnType.GetValue = ENTxnType.ttCreditMemo) Then
                            Dim creditObj As New QBCreditObj
                            With creditObj
                                If (linkRet.TxnID IsNot Nothing) Then
                                    .TxnID = linkRet.TxnID.GetValue
                                End If
                                If (linkRet.Amount IsNot Nothing) Then
                                    .AppliedAmount = linkRet.Amount.GetValue
                                End If
                            End With
                            ' checking if list for credits exists
                            If (.LinkedCreditList Is Nothing) Then
                                .LinkedCreditList = New List(Of QBCreditObj)
                            End If
                            .LinkedCreditList.Add(creditObj)
                            'Else
                            'Dim linkTxn As New QBLinkedTxnObj
                            'With linkRet
                            '    linkTxn.TxnID = .TxnID.GetValue
                            '    linkTxn.TxnType = .TxnType.GetValue
                            '    linkTxn.RefNumber = .RefNumber.GetValue
                            '    linkTxn.Amount = .Amount.GetValue
                            'End With
                            '' check if linkedTxnList exists
                            'If (.LinkTxnList Is Nothing) Then
                            '    .LinkTxnList = New List(Of QBLinkedTxnObj)
                            'End If
                            '.LinkTxnList.Add(linkTxn)
                        End If

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
   ''' <returns>List (Of QBRecievePaymentObj)</returns>
        ''' <remarks></remarks>
        Friend Overloads Shared Function ConvertToPayObjs(ByRef resp As IResponse) As List(Of QBRecievePaymentObj)
            ' return list
            Dim payObjList As New List(Of QBRecievePaymentObj)
            ' reusable vars
            Dim payObj As QBRecievePaymentObj
            Dim retList As IReceivePaymentRetList
            Dim ret As IReceivePaymentRet

            ' checking what type response it is
            Select Case resp.Type.GetValue
                Case Is = ENResponseType.rtReceivePaymentQueryRs
                    retList = resp.Detail
                    For i = 0 To retList.Count - 1
                        ret = retList.GetAt(i)
                        payObj = ConvertToPayObj(ret)
                        payObjList.Add(payObj)
                    Next
                Case Is = ENResponseType.rtInvoiceQueryRs
                    retList = resp.Detail
                    For i = 0 To retList.Count - 1
                        Dim invRet As IInvoiceRet = retList.GetAt(i)
                        payObjList.AddRange(ConvertToPayObjs(invRet.LinkedTxnList))
                    Next
                Case Is = ENResponseType.rtReceivePaymentModRs, ENResponseType.rtReceivePaymentAddRs
                    ret = resp.Detail
                    payObj = ConvertToPayObj(ret)
                    payObjList.Add(payObj)
                Case Else
                    MessageBox.Show("UNKNOWN QUERY RECEIEVED - UNABLE TO PROCESS - FATAL ERROR")
                    Return payObjList
            End Select

            ' sort list by txn date, oldest to newest
            payObjList.Sort(Function(x, y) x.TxnDate.CompareTo(y.TxnDate))

            Return payObjList
        End Function

        Private Shared Function ConvertToPayObj(ByVal ret As IReceivePaymentRet) As QBRecievePaymentObj
            Dim payObj As New QBRecievePaymentObj
            With payObj
                If (ret.TxnID IsNot Nothing) Then
                    .TxnID = ret.TxnID.GetValue
                End If
                If (ret.TxnDate IsNot Nothing) Then
                    .TxnDate = ret.TxnDate.GetValue
                End If
                If (ret.EditSequence IsNot Nothing) Then
                    .EditSequence = ret.EditSequence.GetValue
                End If
                If (ret.CustomerRef IsNot Nothing) Then
                    .CustomerListID = ret.CustomerRef.ListID.GetValue
                End If
                If (ret.TotalAmount IsNot Nothing) Then
                    .TotalAmount = ret.TotalAmount.GetValue
                End If
                If (ret.UnusedPayment IsNot Nothing) Then
                    .UnusedPayment = ret.UnusedPayment.GetValue
                End If
                If (ret.PaymentMethodRef IsNot Nothing) Then
                    .PayTypeName = ret.PaymentMethodRef.FullName.GetValue
                End If
                If (ret.RefNumber IsNot Nothing) Then
                    .RefNumber = ret.RefNumber.GetValue
                End If
                ' checking for applied txns
                If (ret.AppliedToTxnRetList IsNot Nothing) Then
                    payObj.AppliedInvList = New List(Of QBInvoiceObj)
                    For l = 0 To ret.AppliedToTxnRetList.Count - 1
                        Dim appTxnRet As IAppliedToTxnRet = ret.AppliedToTxnRetList.GetAt(l)
                        ' only want invoices
                        If (appTxnRet.TxnType.GetValue = ENTxnType.ttInvoice) Then
                            Dim appInv As New QBInvoiceObj
                            If (appTxnRet.TxnID IsNot Nothing) Then
                                appInv.TxnID = appTxnRet.TxnID.GetValue
                            End If
                            If (appTxnRet.Amount IsNot Nothing) Then
                                appInv.AppliedAmount = appTxnRet.Amount.GetValue
                            End If
                            ' add to list
                            payObj.AppliedInvList.Add(appInv)
                        End If
                    Next
                End If
            End With

            Return payObj
        End Function

        Private Overloads Shared Function ConvertToPayObjs(ByVal linkTxnList As ILinkedTxnList) As List(Of QBRecievePaymentObj)
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
                .Add("PayMethodRef")
                .Add("UnusedPayment")
            End With

            For i = 0 To linkTxnList.Count - 1
                Dim linkTxn As ILinkedTxn = linkTxnList.GetAt(i)
                If (linkTxn.TxnType.GetValue = ENTxnType.ttReceivePayment) Then
                    Dim payObj As New QBRecievePaymentObj
                    payObj.TxnID = linkTxn.TxnID.GetValue
                    ' query to get full information
                    QBRequests.PaymentQuery(payObj, retEleList:=retEleList)
                    'add to list
                    payObjList.Add(payObj)
                End If
            Next

            ' sort list by txn date, oldest to newest
            payObjList.Sort(Function(x, y) x.TxnDate.CompareTo(y.TxnDate))
            Return payObjList
        End Function


        Friend Shared Function ConvertToCreditObjs(ByRef resp As IResponse) As List(Of QBCreditObj)
            ' return list
            Dim creditObjList As New List(Of QBCreditObj)

            Select Case resp.Type.GetValue
                Case Is = ENResponseType.rtCreditMemoQueryRs
                    Dim retList As ICreditMemoRetList = resp.Detail
                    For i = 0 To retList.Count - 1
                        creditObjList.Add(ConvertToCreditObj(retList.GetAt(i)))
                    Next
                Case Is = ENResponseType.rtCreditMemoAddRs
                    creditObjList.Add(ConvertToCreditObj(resp.Detail))
                Case Else
                    MessageBox.Show("UNKNOWN QUERY RECEIEVED - UNABLE TO PROCESS - FATAL ERROR")
                    Return creditObjList
            End Select
            
            Return creditObjList
        End Function

        Private Shared Function ConvertToCreditObj(ByRef creditRet As ICreditMemoRet) As QBCreditObj
            Dim creditObj As New QBCreditObj
            With creditObj
                If (creditRet.TxnID IsNot Nothing) Then
                    .TxnID = creditRet.TxnID.GetValue
                End If
                If (creditRet.TxnDate IsNot Nothing) Then
                    .TxnDate = creditRet.TxnDate.GetValue
                End If
                If (creditRet.EditSequence IsNot Nothing) Then
                    .EditSequence = creditRet.EditSequence.GetValue
                End If
                If (creditRet.TotalAmount IsNot Nothing) Then
                    .TotalAmount = creditRet.TotalAmount.GetValue
                End If
                If (creditRet.CreditRemaining IsNot Nothing) Then
                    .CreditRemaining = creditRet.CreditRemaining.GetValue
                End If
                If (creditRet.CustomerRef IsNot Nothing) Then
                    .CustomerListID = creditRet.CustomerRef.ListID.GetValue
                End If
            End With
            Return creditObj
        End Function

        Private Shared Function UseCredit(ByRef creditObj As QBCreditObj, ByRef invObj As QBInvoiceObj, Optional ByRef qbConMgr As QBConMgr = Nothing) As Integer
            ' creating payment to apply
            Dim payObj As New QBRecievePaymentObj
            ' setting to customer thats on the invoice
            payObj.CustomerListID = invObj.CustomerListID

            ' dont thiknk i need this anymore
           ' need to get a list of already applied credits
            ' QBRequests.InvoiceQuery(invObj, incLinkTxn:=True)
           
            ' checking how much we can apply from the passed credit obj
            If (creditObj.CreditRemaining >= invObj.BalanceRemaining) Then
                ' if remaining credit is greater than balance, apply balance
                creditObj.AppliedAmount = invObj.BalanceRemaining
                creditObj.CreditRemaining = invObj.BalanceRemaining
            Else
                creditObj.AppliedAmount = creditObj.CreditRemaining
                creditObj.CreditRemaining = 0
            End If

            ' creating credit list
            invObj.LinkedCreditList = New List(Of QBCreditObj)
            ' adding passed credit obj
            invObj.LinkedCreditList.Add(creditObj)

            ' adding invoice to payment object that is going to use the credits attached to it
            payObj.AppliedInvList = New List(Of QBInvoiceObj)
            payObj.AppliedInvList.Add(invObj)

            ' update remaining on invoiceObj
            invObj.BalanceRemaining = creditObj.AppliedAmount
            ' use payment
            Return QBRequests.PaymentAdd(payObj, qbConMgr:=ConCheck(qbConMgr))
        End Function

        Public Shared Function UseOverpaymentsOnInvoices(ByRef payObjList As List(Of QBRecievePaymentObj), ByRef invObjList As List(Of QBInvoiceObj),
                                                         Optional ByRef qbConMgr As QBConMgr = Nothing) As Boolean
            ' err counter
            Dim err As Integer = 0

            ' checking if new customer has unapplied payments and open invoices we can pay
            If (payObjList.Count > 0) Then
                If (invObjList.Count > 0) Then
                    For Each pay As QBRecievePaymentObj In payObjList
                        If (pay.UnusedPayment > 0) Then
                            For Each invObj As QBInvoiceObj In invObjList
                                If (invObj.BalanceRemaining > 0) Then
                                    ' checking if payment is being used on other invoices
                                    If (pay.AppliedInvList Is Nothing) Then
                                        pay.AppliedInvList = New List(Of QBInvoiceObj)
                                    End If
                                    ' going to use passed payObj as mod obj
                                    pay.AppliedInvList.Add(invObj)
                                    ' checking how much we can apply
                                    If (pay.UnusedPayment >= invObj.BalanceRemaining) Then
                                        invObj.AppliedAmount = invObj.BalanceRemaining
                                        ' update balances
                                        invObj.BalanceRemaining = 0
                                        pay.UnusedPayment = pay.UnusedPayment - invObj.BalanceRemaining
                                    Else
                                        invObj.AppliedAmount = pay.UnusedPayment
                                        ' update balances
                                        pay.UnusedPayment = 0
                                        invObj.BalanceRemaining = invObj.BalanceRemaining - pay.UnusedPayment
                                    End If
                                    ' send invoice
                                    Dim resp As Integer = QBRequests.PaymentMod(pay)
                                    If (resp = 0) Then
                                        Try
                                            ' attempting to update history edit seq
                                            Using ta As New PaymentHistory_DBTableAdapter
                                                ta.UpdateEditSeq(pay.TxnID, pay.EditSequence)
                                            End Using
                                        Catch ex As SqlException
                                            MessageBox.Show(
                                                "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End Try
                                    Else
                                        err += 1
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
        ''' <param name="qbConMgr">Alternate ConMgr for multi-thread use</param>
        ''' <remarks></remarks>
        ''' 
        Public Shared Sub PayInvoice(ByRef invObj As QBInvoiceObj, Optional ByVal newestCreditsFirst As Boolean = False,
                                     Optional ByVal newestPaymentsFirst As Boolean = False,
                                     Optional ByRef qbConMgr As QBConMgr = Nothing)
            ' get list of creditObjs avail for use
            Dim creditObjList As New List(Of QBCreditObj)
            QBRequests.CreditMemoQuery(creditObjList, customerListID:=invObj.CustomerListID, qbConMgr:=ConCheck(qbConMgr))
            ' checking if we want to use newest credits first
            If (newestCreditsFirst) Then
                creditObjList.Reverse()
            End If
            If (creditObjList.Count > 0) Then
                For Each credit As QBCreditObj In creditObjList
                    If (invObj.BalanceRemaining > 0) Then
                       If (credit.CreditRemaining > 0) Then
                            Dim resp As Integer = UseCredit(invObj:=invObj, creditObj:=credit, qbConMgr:=ConCheck(qbConMgr))
                            If (resp <> 0) Then
                                MessageBox.Show("Error with Credit use on PayInvoice sub")
                                Exit Sub
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
                ' getting list of payments on customer
                Dim payObjList As New List(Of QBRecievePaymentObj)
                QBRequests.PaymentQuery(payObjList, customerListID:=invObj.CustomerListID, retEleList:=s, qbConMgr:=ConCheck(qbConMgr))
                ' checking if we want to use newest payments first
                If (newestPaymentsFirst) Then
                    payObjList.Reverse()
                End If
                ' putting invoice into a list for overpayment sub instead of writing the same sub to handle 1 item
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
            Dim invObjList As New List(Of QBInvoiceObj)
            QBRequests.InvoiceQuery(invObjList, customerListID:=creditObj.CustomerListID, paidStatus:=ENPaidStatus.psNotPaidOnly, qbConMgr:=ConCheck(qbConMgr))
            ' checking if we want to pay newest invoices first
            If (newestInvsFirst) Then
                invObjList.Reverse()
            End If
            If (invObjList.Count > 0) Then
                For i = 0 To invObjList.Count - 1
                    If (creditObj.CreditRemaining > 0) Then
                        UseCredit(creditObj, invObjList.Item(i), ConCheck(qbConMgr))
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