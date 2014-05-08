﻿Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling

Public Class Reporting
    ' ds is refrenced easier here
    Protected ds As Report_DataSet
    Protected qta As Report_DataSetTableAdapters.QueriesTableAdapter

    ' connection status bool
    Protected connected As Boolean
    ' session status bool
    Protected inSession As Boolean

    Protected _msgSetReq As IMsgSetRequest
    Private ReadOnly Property MsgSetRequest As IMsgSetRequest
        Get
            If (_msgSetReq IsNot Nothing) Then
                Return _msgSetReq
            Else
                _msgSetReq = SessionManager.CreateMsgSetRequest("US", 11, 0)
                Return _msgSetReq
            End If
        End Get
    End Property
    Protected _sessMgr As QBSessionManager
    Private ReadOnly Property SessionManager As QBSessionManager
        Get
            If (_sessMgr IsNot Nothing) Then
                Return _sessMgr
            Else
                _sessMgr = New QBSessionManager
                Return _sessMgr
            End If
        End Get
    End Property

    Public Sub New()
        If (Not connected) Then
            SessionManager.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
            connected = True
        End If
        If (Not inSession) Then
            SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)
            inSession = True
        End If

        ' init 
        qta = New Report_DataSetTableAdapters.QueriesTableAdapter
    End Sub

    Public Function Report_AllCustomerBalances(ByVal MinDaysPastDue As Integer, ByRef IncludeInactive As Boolean) As Report_DataSet
        ' clear
        ds = New Report_DataSet
        ' fill ds
        GetAllCustomerBalances(MinDaysPastDue, IncludeInactive)
        ' TODO: if customer has no invoices that match timeframe, remove from table
        'RemoveNoInvCustomer()

        Return ds
    End Function
    Private Sub GetAllCustomerBalances(ByVal MinDaysPastDue As Integer, ByRef IncludeInactive As Boolean)
        Dim custQuery As ICustomerQuery = MsgSetRequest.AppendCustomerQueryRq
        Dim bad_qta As New DataSetTableAdapters.QueriesTableAdapter

        'checking for includeinactive
        If (IncludeInactive = True) Then
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
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim responseList As IResponseList = msgSetResp.ResponseList

        ' clear msg set req
        MsgSetRequest.ClearRequests()

        For r = 0 To responseList.Count - 1
            Dim response As IResponse = responseList.GetAt(r)
            If (response.StatusCode = 0) Then
                Dim custRetList As ICustomerRetList = response.Detail
                For c = 0 To custRetList.Count - 1
                    Dim custRet As ICustomerRet = custRetList.GetAt(c)

                    ' create new row for cust balances
                    Dim custRow As Report_DataSet.CustomerBalancesRow = ds.CustomerBalances.NewCustomerBalancesRow
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
                    custRow.CustomerNumber = bad_qta.Customer_GetNumberFromListID(custRet.ListID.GetValue)
                    ' TODO: check if balance is > than 50% of running service rate(s)
                    If (CBool(qta.Report_IsCustomerBalanceEnough(custRow.CustomerNumber, custRow.CustomerBalance)) = True) Then
                        ' add row to table
                        ds.CustomerBalances.AddCustomerBalancesRow(custRow)
                        ' get invoices for customer
                        QB_InvoiceQueryForReport(custRow, MinDaysPastDue)
                    End If

                Next c
            Else
                ResponseErr_Misc(response)
            End If
        Next r

    End Sub
    Private Sub QB_InvoiceQueryForReport(ByRef custRow As Report_DataSet.CustomerBalancesRow, ByVal MinDaysPastDue As Integer)
        Dim invoiceQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq

        ' getting cust listid from row
        invoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(custRow.ListID)
        ' getting not paid invoices only
        invoiceQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(ENPaidStatus.psNotPaidOnly)

        ' sending request
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim responseList As IResponseList = msgSetResp.ResponseList

        ' clear msg set req
        MsgSetRequest.ClearRequests()

        ' looping through response list
        For i = 0 To responseList.Count - 1
            Dim response As IResponse = responseList.GetAt(0)
            If (response.StatusCode = 0) Then
                Dim invoiceRetList As IInvoiceRetList = response.Detail
                ' looping through invoice ret list
                For j = 0 To invoiceRetList.Count - 1
                    Dim invRet As IInvoiceRet = invoiceRetList.GetAt(j)
                    ' create row
                    Dim invRow As Report_DataSet.InvoiceBalancesRow = ds.InvoiceBalances.NewInvoiceBalancesRow
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
                    If (invRow.DaysPastDue >= MinDaysPastDue) Then
                        ' add to table
                        ds.InvoiceBalances.AddInvoiceBalancesRow(invRow)
                    End If
                Next j
            Else
                ResponseErr_Misc(response)
            End If
        Next i
    End Sub
    Private Sub RemoveNoInvCustomer()
        For Each custRow As Report_DataSet.CustomerBalancesRow In ds.CustomerBalances
            Dim queryS As String = "CustomerListID = " & custRow.ListID.ToString
            Dim drArr As DataRow() = ds.InvoiceBalances.Select(queryS)

            If (drArr.Length <= 0) Then
                ds.CustomerBalances.RemoveCustomerBalancesRow(custRow)
            End If
        Next custRow
    End Sub


End Class
