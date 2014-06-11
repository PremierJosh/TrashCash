Imports QBFC12Lib

Namespace Reports

    Public Class Reporting
        ' ds is refrenced easier here
        Protected DS As DS_Reports
        Protected Qta As QueriesTableAdapter

        Protected MsgSetReq As IMsgSetRequest
        Protected SessMgr As QBSessionManager

        Public Sub New(ByRef sessionManager As QBSessionManager, ByRef msgSetRequest As IMsgSetRequest)
            ' setting sess mgr and msgsetreq
            SessMgr = sessionManager
            MsgSetReq = msgSetRequest

            ' init 
            Qta = New QueriesTableAdapter
        End Sub

        Public Function Report_AllCustomerBalances(ByVal minDaysPastDue As Integer, ByRef includeInactive As Boolean) As DS_Reports
            ' clear
            DS = New DS_Reports
            ' fill ds
            GetAllCustomerBalances(minDaysPastDue, includeInactive)

            Return DS
        End Function
        Private Sub GetAllCustomerBalances(ByVal minDaysPastDue As Integer, ByRef includeInactive As Boolean)
            Dim custQuery As ICustomerQuery = MsgSetReq.AppendCustomerQueryRq
            Dim badQta As New ds_CustomerTableAdapters.CustomerTableAdapter

            'checking for includeinactive
            If (includeInactive = True) Then
                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll)
            Else
                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)
            End If

            'only getting customers with a balance
            custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Operator.SetValue(ENOperator.oGreaterThan)
            custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Amount.SetValue(0.0)

            'only getting back items i want
            custQuery.IncludeRetElementList.Add("ListID")
            custQuery.IncludeRetElementList.Add("TotalBalance")
            custQuery.IncludeRetElementList.Add("FullName")
            custQuery.IncludeRetElementList.Add("Phone")
            'getting addr info
            custQuery.IncludeRetElementList.Add("BillAddress")

            ' getting data ext for cust num
            custQuery.IncludeRetElementList.Add("DataExtRetList")
            custQuery.OwnerIDList.Add(0)

            ' limit response so i can view report quickly for testing
            'custQuery.ORCustomerListQuery.CustomerListFilter.MaxReturned.SetValue(10)

            ' sending request
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' clear msg set req
            MsgSetReq.ClearRequests()

            For r = 0 To responseList.Count - 1
                Dim response As IResponse = responseList.GetAt(r)
                If (response.StatusCode = 0) Then
                    Dim custRetList As ICustomerRetList = response.Detail
                    For c = 0 To custRetList.Count - 1
                        Dim custRet As ICustomerRet = custRetList.GetAt(c)

                        ' create new row for cust balances
                        Dim custRow As DS_Reports.CustomerBalancesRow = DS.CustomerBalances.NewCustomerBalancesRow
                        custRow.CustomerName = custRet.FullName.GetValue
                        custRow.CustomerBalance = FormatCurrency(custRet.TotalBalance.GetValue)
                        custRow.ListID = custRet.ListID.GetValue
                        custRow.CustomerPhone = custRet.Phone.GetValue
                        ' addr info
                        custRow.Addr1 = custRet.BillAddress.Addr1.GetValue
                        custRow.Addr2 = custRet.BillAddress.Addr2.GetValue
                        ' checking if addr 3 and 4 have values
                        If (custRet.BillAddress.Addr3 IsNot Nothing) Then
                            custRow.Addr3 = custRet.BillAddress.Addr3.GetValue
                        End If
                        If (custRet.BillAddress.Addr4 IsNot Nothing) Then
                            custRow.Addr4 = custRet.BillAddress.Addr4.GetValue
                        End If
                        custRow.City = custRet.BillAddress.City.GetValue
                        custRow.State = custRet.BillAddress.State.GetValue
                        custRow.Zip = custRet.BillAddress.PostalCode.GetValue

                        ' grabbing customer number
                        custRow.CustomerNumber = badQta.GetNumber(custRet.ListID.GetValue)
                        ' TODO: check if balance is > than 50% of running service rate(s)
                        'If (CBool(qta.Report_IsCustomerBalanceEnough(custRow.CustomerNumber, custRow.CustomerBalance)) = True) Then
                        ' add row to table
                        DS.CustomerBalances.AddCustomerBalancesRow(custRow)
                        ' get invoices for customer
                        QB_InvoiceQueryForReport(custRow, minDaysPastDue)
                        'End If

                    Next c
                Else
                    GlobalConMgr.ResponseErr_Misc(response)
                End If
            Next r

        End Sub
        Private Sub QB_InvoiceQueryForReport(ByRef custRow As DS_Reports.CustomerBalancesRow, ByVal minDaysPastDue As Integer)
            Dim invoiceQuery As IInvoiceQuery = MsgSetReq.AppendInvoiceQueryRq

            ' getting cust listid from row
            invoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(custRow.ListID)
            ' getting not paid invoices only
            invoiceQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(ENPaidStatus.psNotPaidOnly)

            ' sending request
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' clear msg set req
            MsgSetReq.ClearRequests()

            ' looping through response list
            For i = 0 To responseList.Count - 1
                Dim response As IResponse = responseList.GetAt(i)
                If (response.StatusCode = 0) Then
                    Dim invoiceRetList As IInvoiceRetList = response.Detail
                    ' looping through invoice ret list
                    For j = 0 To invoiceRetList.Count - 1
                        Dim invRet As IInvoiceRet = invoiceRetList.GetAt(j)
                        ' create row
                        Dim invRow As DS_Reports.InvoiceBalancesRow = DS.InvoiceBalances.NewInvoiceBalancesRow
                        ' passing cust num here for relationship
                        invRow.CustomerListID = custRow.ListID
                        invRow.CustomerNumber = custRow.CustomerNumber
                        invRow.Balance = FormatCurrency(invRet.BalanceRemaining.GetValue)
                        invRow.InvoiceTotal = FormatCurrency(invRet.Subtotal.GetValue)
                        invRow.InvoiceNumber = invRet.TxnNumber.GetValue
                        invRow.DueDate = invRet.DueDate.GetValue

                        ' calc days past due
                        invRow.DaysPastDue = DateDiff(DateInterval.Day, invRet.DueDate.GetValue, Date.Now.Date)

                        ' checking if days are enough to add to ds
                        If (invRow.DaysPastDue >= minDaysPastDue) Then
                            ' add to table
                            DS.InvoiceBalances.AddInvoiceBalancesRow(invRow)
                        End If
                    Next j
                Else
                    GlobalConMgr.ResponseErr_Misc(response)
                End If
            Next i
        End Sub

        Public Function Report_UnderOverEven(ByRef includeInactive As Boolean) As DS_Reports
            ' clear ds
            DS = New DS_Reports
            ' fill ds
            Dim custQuery As ICustomerQuery = MsgSetReq.AppendCustomerQueryRq

            'checking for includeinactive
            If (includeInactive = True) Then
                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll)
            Else
                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)
            End If

            'only getting customers with a balance
            'custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Operator.SetValue(ENOperator.oGreaterThan)
            'custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Amount.SetValue(0.0)

            'only getting back items i want
            custQuery.IncludeRetElementList.Add("TotalBalance")
            custQuery.IncludeRetElementList.Add("FullName")
            custQuery.IncludeRetElementList.Add("Phone")
            'getting addr info
            custQuery.IncludeRetElementList.Add("BillAddress")

            ' getting data ext for cust num
            custQuery.IncludeRetElementList.Add("DataExtRetList")
            custQuery.OwnerIDList.Add(0)

            ' limit response so i can view report quickly for testing
            'custQuery.ORCustomerListQuery.CustomerListFilter.MaxReturned.SetValue(10)

            ' sending request
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' clear msg set req
            MsgSetReq.ClearRequests()

            For r = 0 To responseList.Count - 1
                Dim response As IResponse = responseList.GetAt(r)
                If (response.StatusCode = 0) Then
                    Dim custRetList As ICustomerRetList = response.Detail
                    For c = 0 To custRetList.Count - 1
                        Dim custRet As ICustomerRet = custRetList.GetAt(c)

                        ' create new row for cust balances
                        Dim custRow As DS_Reports.UnderOverEvenRow = DS.UnderOverEven.NewUnderOverEvenRow
                        custRow.CustomerFullName = custRet.FullName.GetValue

                        ' balance stuff
                        custRow.Balance = custRet.TotalBalance.GetValue
                        ' setting balance group
                        If (custRet.TotalBalance.GetValue > 0) Then
                            custRow.BalanceGroup = "Customers with Balances"
                        ElseIf (custRet.TotalBalance.GetValue < 0) Then
                            custRow.BalanceGroup = "Customers with Credits"
                            ' ReSharper disable once CompareOfFloatsByEqualityOperator
                        ElseIf (custRet.TotalBalance.GetValue = 0) Then
                            custRow.BalanceGroup = "Customers Paid Up"
                        End If

                        custRow.Phone = custRet.Phone.GetValue
                        ' addr info
                        ' if addr1 is nothing, then we need to skip this customer
                        If (custRet.BillAddress.Addr1 IsNot Nothing) Then
                            custRow.Addr1 = custRet.BillAddress.Addr1.GetValue
                        Else
                            GoTo skip
                        End If
                        custRow.Addr2 = custRet.BillAddress.Addr2.GetValue

                        ' checking if addr 3 and 4 have values
                        If (custRet.BillAddress.Addr3 IsNot Nothing) Then
                            custRow.Addr3 = custRet.BillAddress.Addr3.GetValue
                        End If
                        If (custRet.BillAddress.Addr4 IsNot Nothing) Then
                            custRow.Addr4 = custRet.BillAddress.Addr4.GetValue
                        End If
                        custRow.City = custRet.BillAddress.City.GetValue
                        custRow.State = custRet.BillAddress.State.GetValue
                        custRow.Zip = custRet.BillAddress.PostalCode.GetValue

                        ' add row to ds
                        DS.UnderOverEven.AddUnderOverEvenRow(custRow)
skip:
                    Next c
                Else
                    GlobalConMgr.ResponseErr_Misc(response)
                End If
            Next r

            Return DS
        End Function


    End Class
End Namespace