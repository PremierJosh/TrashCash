Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling

Public Class ReportScripts
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

    ' connection status bool
    Protected connected As Boolean
    ' session status bool
    Protected inSession As Boolean
    ' queries ta
    Protected qta As DataSetTableAdapters.QueriesTableAdapter

    Public Sub New(Optional ByRef app_SessMgr As QBSessionManager = Nothing, Optional ByRef app_MsgSetReq As IMsgSetRequest = Nothing)
        If (app_SessMgr IsNot Nothing) Then
            _sessMgr = app_SessMgr
            connected = True
            inSession = True
        End If

        If (app_MsgSetReq IsNot Nothing) Then
            _msgSetReq = app_MsgSetReq
        End If

        If (Not connected) Then
            SessionManager.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
            connected = True
        End If
        If (Not inSession) Then
            SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION, ENOpenMode.omSingleUser)
            inSession = True
        End If

        ' instantiate qta
        qta = New DataSetTableAdapters.QueriesTableAdapter
    End Sub
   
    Private ds As New Report_DataSet



    Public Function Report_AllCustomerBalances()
        ' init clear
        ds.Clear()
        ' fill ds
        QB_AllCustomerBalances()

        Return ds
    End Function

    Private Sub QB_AllCustomerBalances()
        Dim custQuery As ICustomerQuery = MsgSetRequest.AppendCustomerQueryRq

        ' only getting customers with a balance
        custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Operator.SetValue(ENOperator.oGreaterThan)
        custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Amount.SetValue(0)
        ' only getting back items i want
        custQuery.IncludeRetElementList.Add("ListID")
        custQuery.IncludeRetElementList.Add("TotalBalance")
        custQuery.IncludeRetElementList.Add("FullName")
        custQuery.IncludeRetElementList.Add("Phone")
        ' getting data ext for cust num
        custQuery.IncludeRetElementList.Add("DataExtRet")
        custQuery.OwnerIDList.Add(0)

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

                    ' looping through data ext ret
                    If (custRet.DataExtRetList IsNot Nothing) Then
                        For d = 0 To custRet.DataExtRetList.Count - 1
                            Dim dataExtRet As IDataExtRet = custRet.DataExtRetList.GetAt(d)
                            If (dataExtRet.DataExtName.GetValue = "Customer Number") Then
                                custRow.CustomerNumber = dataExtRet.DataExtValue.GetValue
                            End If
                        Next

                        ' add row to table
                        ds.CustomerBalances.AddCustomerBalancesRow(custRow)

                        ' get invoices for customer
                        QB_InvoiceQueryForReport(custRow)
                    End If
                Next c
            Else
                ResponseErr_Misc(response)
            End If
        Next r

    End Sub

    Private Sub QB_InvoiceQueryForReport(ByRef custRow As Report_DataSet.CustomerBalancesRow)
        Dim invoiceQuery As IInvoiceQuery = MsgSetRequest.AppendInvoiceQueryRq

        ' getting cust listid from row
        invoiceQuery.ORInvoiceQuery.InvoiceFilter.EntityFilter.OREntityFilter.ListIDList.Add(custRow.ListID)
        ' getting not paid invoices only
        invoiceQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(ENPaidStatus.psNotPaidOnly)

        ' sending request
        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim responseList As IResponseList = msgSetResp.ResponseList
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
                    invRow.CustomerNumber = custRow.CustomerNumber
                    invRow.Balance = FormatCurrency(invRet.BalanceRemaining.GetValue)
                    invRow.InvoiceTotal = FormatCurrency(invRet.Subtotal.GetValue)
                    invRow.InvoiceNumber = invRet.TxnNumber.GetValue
                    invRow.DueDate = invRet.DueDate.GetValue

                    ' calc days past due
                    invRow.DaysPastDue = DateDiff(DateInterval.Day, invRet.DueDate.GetValue, Date.Now.Date)

                    ' add to table
                    ds.InvoiceBalances.AddInvoiceBalancesRow(invRow)
                Next j
            Else
                ResponseErr_Misc(response)
            End If
        Next i
    End Sub
End Class
