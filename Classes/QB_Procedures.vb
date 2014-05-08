Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils
Imports TrashCash.TrashCash_Utils.Err_Handling

Public MustInherit Class QB_Procedures
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

    ' all sub classes can use this
    Protected qta As DataSetTableAdapters.QueriesTableAdapter

    Protected Function VoidTransactionByTxnID(ByVal TxnID As String, ByVal VoidType As ENTxnVoidType) As Boolean
        ' return bool
        Dim voided As Boolean

        Dim txnVoid As ITxnVoid = MsgSetRequest.AppendTxnVoidRq

        ' setting txn we are talking about
        txnVoid.TxnVoidType.SetValue(VoidType)
        txnVoid.TxnID.SetValue(TxnID)


        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        Dim respList As IResponseList = msgSetResp.ResponseList

        For i = 0 To respList.Count - 1
            Dim resp As IResponse = respList.GetAt(i)
            If (resp.StatusCode <> 0) Then
                ResponseErr_Misc(resp)
            Else
                voided = True
            End If
        Next i

        Return voided
    End Function
    Public Class Customer
        Inherits QB_Procedures

        Protected wta As DataSetTableAdapters.QueriesTableAdapter
        Protected cta As DataSetTableAdapters.CustomerTableAdapter

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
                SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omDontCare)
                inSession = True
            End If

            ' tas
            cta = New DataSetTableAdapters.CustomerTableAdapter
            qta = New DataSetTableAdapters.QueriesTableAdapter
        End Sub

        Public Sub AddAllMissingListID(ByRef form As AdminHome)
            Dim missingCount As Integer = qta.Customer_MissingListIDCount

            ' fill table
            If (missingCount > 0) Then
                Dim dt As DataSet.CustomerDataTable
                dt = cta.GetAllWithMissingListID

                ' pb init stuff
                Dim progCounter As Integer = 0
                Form.pb_AllCustAdd.Maximum = dt.Rows.Count
                Form.lbl_AllCustAddCount.Text = progCounter & "/" & dt.Rows.Count

                ' loop through table
                For Each custRow As DataSet.CustomerRow In dt

                    ' pb update stuff
                    progCounter += 1
                    Form.pb_AllCustAdd.Value = progCounter
                    Form.lbl_AllCustAddCount.Text = progCounter & "/" & dt.Rows.Count

                    Dim customerAdd As ICustomerAdd = MsgSetRequest.AppendCustomerAddRq

                    ' General Customer Information
                    customerAdd.Name.SetValue(custRow.CustomerFullName)
                    If (custRow.IsCustomerCompanyNameNull = False) Then
                        customerAdd.CompanyName.SetValue(custRow.CustomerCompanyName)
                    End If
                    If (custRow.IsCustomerFirstNameNull = False) Then
                        customerAdd.FirstName.SetValue(custRow.CustomerFirstName)
                    End If
                    If (custRow.IsCustomerLastNameNull = False) Then
                        customerAdd.LastName.SetValue(custRow.CustomerLastName)
                    End If
                    customerAdd.Phone.SetValue(custRow.CustomerPhone)
                    If (custRow.IsCustomerAltPhoneNull = False) Then
                        customerAdd.AltPhone.SetValue(custRow.CustomerAltPhone)
                    End If
                    If (custRow.IsCustomerContactNull = False) Then
                        customerAdd.Contact.SetValue(custRow.CustomerContact)
                    End If
                    ' setting active status
                    If (custRow.CustomerIsDeactive = True) Then
                        customerAdd.IsActive.SetValue(False)
                    Else
                        customerAdd.IsActive.SetValue(True)
                    End If

                    ' Billing Address Information
                    ' addr1 is first name + last name if first name is present, otherwise company name
                    customerAdd.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
                    If (custRow.IsCustomerBillingAddr2Null = False) Then
                        customerAdd.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
                    End If
                    If (custRow.IsCustomerBillingAddr3Null = False) Then
                        customerAdd.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
                    End If
                    If (custRow.IsCustomerBillingAddr4Null = False) Then
                        customerAdd.BillAddress.Addr4.SetValue(custRow.CustomerBillingAddr4)
                    End If
                    customerAdd.BillAddress.City.SetValue(custRow.CustomerBillingCity)
                    customerAdd.BillAddress.State.SetValue(custRow.CustomerBillingState)
                    customerAdd.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

                    ' sending request
                    Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                    Dim responseList As IResponseList = msgSetResp.ResponseList

                    'clear msgSetREq
                    MsgSetRequest.ClearRequests()

                    ' looping through response with error checking
                    For i = 0 To responseList.Count - 1
                        Dim response As IResponse = responseList.GetAt(i)
                        If (response.StatusCode = 0) Then
                            Dim responseType As ENResponseType
                            responseType = CType(response.Type.GetValue(), ENResponseType)
                            If (responseType = QBFC12Lib.ENResponseType.rtCustomerAddRs) Then
                                Dim customerRet As ICustomerRet = response.Detail
                                ' updating the custRow with ListID and EditSeq
                                custRow.CustomerListID = customerRet.ListID.GetValue
                                custRow.CustomerEditSeq = customerRet.EditSequence.GetValue

                                Try
                                    ' commiting to DB
                                    cta.Update(custRow)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            End If

                        ElseIf (response.StatusCode = 3100) Then
                            ' customer name already exists
                            Dim input As String = InputBox("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.")
                            If (input.Length > 0) Then
                                custRow.CustomerFullName = input

                                Try
                                    ' commiting to DB
                                    cta.Update(custRow)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                                ' moving to next customer
                                GoTo skipCustomer
                            End If
                        Else
                            ' error logging
                            ResponseErr_Misc(response)

                            ' bail out
                            Exit Sub

                        End If

                    Next i

                    ' Customer Number
                    'Dim customerNumber As IDataExtMod = MsgSetRequest.AppendDataExtModRq
                    'customerNumber.OwnerID.SetValue("0")
                    'customerNumber.DataExtName.SetValue("Customer Number")
                    'customerNumber.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
                    'customerNumber.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(custRow.CustomerListID)
                    'customerNumber.DataExtValue.SetValue(custRow.CustomerNumber)

                    '' sending request then clearing to prep for Start Date DataExt
                    'SessionManager.DoRequests(MsgSetRequest)
                    'MsgSetRequest.ClearRequests()

                    '' Customer Start Date
                    'Dim customerStartDate As IDataExtMod = MsgSetRequest.AppendDataExtModRq
                    'customerStartDate.OwnerID.SetValue("0")
                    'customerStartDate.DataExtName.SetValue("Start Date")
                    'customerStartDate.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
                    'customerStartDate.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(custRow.CustomerListID)
                    'customerStartDate.DataExtValue.SetValue(custRow.CustomerStartDate)

                    ''sending request
                    'SessionManager.DoRequests(MsgSetRequest)
                    'MsgSetRequest.ClearRequests()


skipCustomer:
                Next custRow

                ' checking if customers still missing listids. most likely from having to rename
                missingCount = qta.Customer_MissingListIDCount
                If (missingCount > 0) Then
                    AddAllMissingListID(form)
                End If

            End If
            MsgBox("All Customers Added. If this is the initially load, be sure to import services!")
        End Sub


        Public Function CreateNewCustomer(ByRef custRow As DataSet.CustomerRow) As Boolean
            ' return bool for success
            Dim addOK As Boolean

            Dim customerAdd As ICustomerAdd

            ' build full name
            If (custRow.IsCustomerCompanyNameNull = False) Then
                custRow.CustomerFullName = custRow.CustomerCompanyName & " - " & custRow.CustomerNumber
            Else
                custRow.CustomerFullName = custRow.CustomerLastName & ", " & custRow.CustomerFirstName & " - " & custRow.CustomerNumber
            End If


            If (inSession) Then
retry:
                customerAdd = MsgSetRequest.AppendCustomerAddRq

                ' General Customer Information
                customerAdd.Name.SetValue(custRow.CustomerFullName)
                If (custRow.IsCustomerCompanyNameNull = False) Then
                    customerAdd.CompanyName.SetValue(custRow.CustomerCompanyName)
                End If
                If (custRow.IsCustomerFirstNameNull = False) Then
                    customerAdd.FirstName.SetValue(custRow.CustomerFirstName)
                End If
                If (custRow.IsCustomerLastNameNull = False) Then
                    customerAdd.LastName.SetValue(custRow.CustomerLastName)
                End If
                customerAdd.Phone.SetValue(custRow.CustomerPhone)

                If (custRow.IsCustomerAltPhoneNull = False) Then
                    customerAdd.AltPhone.SetValue(custRow.CustomerAltPhone)
                End If
                If (custRow.IsCustomerContactNull = False) Then
                    customerAdd.Contact.SetValue(custRow.CustomerContact)
                End If

                ' Billing Address Information
                customerAdd.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
                If (custRow.IsCustomerBillingAddr2Null = False) Then
                    customerAdd.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
                End If
                If (custRow.IsCustomerBillingAddr3Null = False) Then
                    customerAdd.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
                End If
                If (custRow.IsCustomerBillingAddr4Null = False) Then
                    customerAdd.BillAddress.Addr4.SetValue(custRow.CustomerBillingAddr4)
                End If
                customerAdd.BillAddress.City.SetValue(custRow.CustomerBillingCity)
                customerAdd.BillAddress.State.SetValue(custRow.CustomerBillingState)
                customerAdd.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

                ' sending request
                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList

                ' clear requests
                MsgSetRequest.ClearRequests()

                ' looping through response with error checking
                For i = 0 To respList.Count - 1
                    Dim resp As IResponse = respList.GetAt(i)
                    If (resp.StatusCode = 0) Then
                        ' updating return var
                        addOK = True

                        Dim customerRet As ICustomerRet = resp.Detail
                        ' updating the custRow with ListID and EditSeq
                        custRow.CustomerListID = customerRet.ListID.GetValue
                        custRow.CustomerEditSeq = customerRet.EditSequence.GetValue

                        Try
                            ' commiting to DB
                            cta.Update(custRow)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    ElseIf (resp.StatusCode = 3100) Then

                        ' customer already exists with that name
                        Dim input As String = InputBox("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.")
                        If (input.Length > 0) Then
                            custRow.CustomerFullName = input

                            Try
                                ' commiting to DB
                                cta.Update(custRow)
                                GoTo retry
                                'Exit Function
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        End If
                    Else
                        ' updating return var
                        addOK = False

                        ' error logging
                        ResponseErr_Misc(resp)

                        ' delete row
                        Dim qta As New DataSetTableAdapters.QueriesTableAdapter
                        qta.Customer_DeleteByNum(custRow.CustomerNumber)

                        ' bail out
                        Return addOK
                    End If
                Next i

                '' Customer Number
                'Dim customerNumber As IDataExtMod = MsgSetRequest.AppendDataExtModRq
                'customerNumber.OwnerID.SetValue("0")
                'customerNumber.DataExtName.SetValue("Customer Number")
                'customerNumber.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
                'customerNumber.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(custRow.CustomerListID)
                'customerNumber.DataExtValue.SetValue(custRow.CustomerNumber)

                '' sending request then clearing to prep for Start Date DataExt
                'SessionManager.DoRequests(MsgSetRequest)
                'MsgSetRequest.ClearRequests()

                '' Customer Start Date
                'Dim customerStartDate As IDataExtMod = MsgSetRequest.AppendDataExtModRq
                'customerStartDate.OwnerID.SetValue("0")
                'customerStartDate.DataExtName.SetValue("Start Date")
                'customerStartDate.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
                'customerStartDate.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(custRow.CustomerListID)
                'customerStartDate.DataExtValue.SetValue(custRow.CustomerStartDate)

                'sending request
                'TEST: seeing if i can do both at once
                SessionManager.DoRequests(MsgSetRequest)

                MsgBox("Customer: '" & custRow.CustomerFullName & "' added successfully.")

                MsgSetRequest.ClearRequests()
            End If

            Return addOK
        End Function
        Public Sub Update(ByRef custRow As DataSet.CustomerRow)
            Dim customerMod As ICustomerMod
            If (inSession) Then
retry:
                customerMod = MsgSetRequest.AppendCustomerModRq

                customerMod.ListID.SetValue(custRow.CustomerListID)
                customerMod.EditSequence.SetValue(custRow.CustomerEditSeq)

                '''' customer information ''''
                customerMod.Name.SetValue(custRow.CustomerFullName)
                If (custRow.IsCustomerCompanyNameNull = False) Then
                    customerMod.CompanyName.SetValue(custRow.CustomerCompanyName)
                End If
                If (custRow.IsCustomerFirstNameNull = False) Then
                    customerMod.FirstName.SetValue(custRow.CustomerFirstName)
                End If
                If (custRow.IsCustomerLastNameNull = False) Then
                    customerMod.LastName.SetValue(custRow.CustomerLastName)
                End If
                customerMod.Phone.SetValue(custRow.CustomerPhone)

                ' checking possibly blank alt phone
                If (custRow.IsCustomerAltPhoneNull = False) Then
                    customerMod.AltPhone.SetValue(custRow.CustomerAltPhone)
                End If
                ' checking possibly blank contact field
                If (custRow.IsCustomerContactNull = False) Then
                    customerMod.Contact.SetValue(custRow.CustomerContact)
                End If

                '''' billing information ''''
                ' required billAddr1
                customerMod.BillAddress.Addr1.SetValue(custRow.CustomerBillingAddr1)
                ' checking billAddr2
                If (custRow.IsCustomerBillingAddr2Null = False) Then
                    customerMod.BillAddress.Addr2.SetValue(custRow.CustomerBillingAddr2)
                End If
                ' checking billAddr3
                If (custRow.IsCustomerBillingAddr3Null = False) Then
                    customerMod.BillAddress.Addr3.SetValue(custRow.CustomerBillingAddr3)
                End If
                customerMod.BillAddress.City.SetValue(custRow.CustomerBillingCity)
                customerMod.BillAddress.State.SetValue(custRow.CustomerBillingState)
                customerMod.BillAddress.PostalCode.SetValue(custRow.CustomerBillingZip)

                ' if cell = true, then customer is deactive
                If (custRow.CustomerIsDeactive = True) Then
                    customerMod.IsActive.SetValue(False)
                Else
                    customerMod.IsActive.SetValue(True)
                End If

                ' doing request and catching in msgSetResp
                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList

                ' clear requests
                MsgSetRequest.ClearRequests()

                ' looping through response for errors and writing to error log
                For i = 0 To respList.Count - 1
                    Dim resp As IResponse = respList.GetAt(i)
                    If (resp.StatusCode = 0) Then
                        Dim customerRet As ICustomerRet = resp.Detail

                        ' updating EditSeq in the DB
                        custRow.BeginEdit()
                        custRow.CustomerEditSeq = customerRet.EditSequence.GetValue()
                        custRow.EndEdit()

                        Try
                            ' update table
                            cta.Update(custRow)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        MsgBox("Changes Complete")
                    ElseIf (resp.StatusCode = 3200) Then
                        ' edit sequence missmatch
                        Dim q As New QB_Queries.Customer
                        custRow.BeginEdit()
                        custRow.CustomerEditSeq = q.EditSequence(custRow.CustomerListID)
                        custRow.EndEdit()

                        Try
                            ' update table then retry
                            cta.Update(custRow)
                            GoTo retry
                            Exit Sub
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    Else
                        custRow.RejectChanges()
                        Err_Handling.ResponseErr_Misc(resp)
                    End If
                Next i
            End If
        End Sub
        Public Sub CreateCreditMemoFromRecService(ByRef recSrvcRow As DataSet.RecurringServiceRow, ByVal creditAmount As Double,
                                    ByVal oldEndDate As Date, ByVal newEndDate As Date)

            Dim ta As New DataSetTableAdapters.RecurringServiceTableAdapter

            If (inSession) Then
                Dim row As DataSet.RecurringServiceRow = recSrvcRow

                Dim creditMemoAdd As ICreditMemoAdd = MsgSetRequest.AppendCreditMemoAddRq

                ' passing listid
                creditMemoAdd.CustomerRef.ListID.SetValue(qta.Customer_GetListID(row.CustomerNumber))
                creditMemoAdd.IsToBePrinted.SetValue(False)

                Dim creditLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
                ' credit line info
                creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(qta.ServiceTypes_GetListIDByTypeID(row.ServiceTypeID))
                creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(creditAmount)

                ' description line
                Dim descLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
                descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
                descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
                descLine.CreditMemoLineAdd.Desc.SetValue("This service has been Invoiced upto " & qta.RecurringService_LastInvDate(row.RecurringServiceID) & ". The new End Date overlaps this Invoiced period. | Previous End Date: " & oldEndDate.Date & " | New End Date: " & newEndDate.Date)
                descLine.CreditMemoLineAdd.Amount.Unset()
                descLine.CreditMemoLineAdd.Quantity.Unset()

                ' send request
                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList

                For i = 0 To respList.Count - 1
                    Dim resp As IResponse = respList.GetAt(i)
                    If (resp.StatusCode = 0) Then
                        ' update row
                        row.RecurringServiceEndDate = newEndDate.Date
                        row.Credited = True

                        ' commit
                        Try
                            ta.Update(row)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        ResponseErr_Misc(resp)
                    End If
                Next i
            End If
        End Sub
        Public Function BounceCheck(ByVal CheckRow As DataSet.PaymentHistoryRow, ByVal BankRow As ds_Program.BAD_CHECK_BANKS_Row, ByVal Fee As Double) As Boolean
            ' return bool
            Dim bounced As Boolean

            ' need to do 2 things:
            ' 1. invoice customer for bounced check amount and our fee
            ' 2. checkadd for bank

            ' 1. invoice first
            Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq

            ' going to need app defaults row for items
            Dim app_row As ds_Program.APP_SETTINGS_Row
            Dim app_ta As New ds_ProgramTableAdapters.APP_SETTINGS_TableAdapter
            app_row = app_ta.GetData().Rows(0)
            ' discarding ta
            app_ta = Nothing

            invoiceAdd.CustomerRef.ListID.SetValue(qta.Customer_GetListID(CheckRow.CustomerNumber))
            invoiceAdd.IsToBePrinted.SetValue(True)

            ' var to hold line items
            Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList

            ' first line item will be for the bounced check amount
            Dim checkLine As IORInvoiceLineAdd = lineList.Append
            checkLine.InvoiceLineAdd.ItemRef.ListID.SetValue(BankRow.QB_BANK_INV_ITEM_LISTID)
            checkLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(CheckRow.Amount)
            checkLine.InvoiceLineAdd.Quantity.SetValue(1)
            ' setting description
            checkLine.InvoiceLineAdd.Desc.SetValue("Bounced Check #: " & CheckRow.RefNumber & ". Received on " & CheckRow.DateReceived.Date & " in the amount of " & FormatCurrency(CheckRow.Amount) & ".")

            ' 2nd line till be for the fee we are charging the customer
            Dim feeLine As IORInvoiceLineAdd = lineList.Append
            feeLine.InvoiceLineAdd.ItemRef.ListID.SetValue(app_row.BAD_CHECK_CUSTITEM_LISTID)
            feeLine.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(Fee)
            feeLine.InvoiceLineAdd.Quantity.SetValue(1)

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetRequest.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    ' update pay history table and set assoc row to bounced
                    Try
                        Dim ta As New DataSetTableAdapters.PaymentHistoryTableAdapter
                        ta.SetBounced(CheckRow.PaymentID)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    ResponseErr_Misc(resp)
                    Return bounced
                End If
            Next

            ' doing checkadd to pay bank fee
            Dim checkAdd As ICheckAdd = MsgSetRequest.AppendCheckAddRq

            'account ref is bank paying from
            checkAdd.AccountRef.ListID.SetValue(BankRow.QB_BANK_LISTID)
            ' payee is vendor
            checkAdd.PayeeEntityRef.ListID.SetValue(BankRow.QB_VENDOR_LISTID)
            ' ref number is returncheck
            checkAdd.RefNumber.SetValue("ReturnCheck")
            ' not printing
            checkAdd.IsToBePrinted.SetValue(False)

            Dim bankFeeLineList As IORItemLineAddList = checkAdd.ORItemLineAddList

            ' this is the check item from app defaults
            Dim bankFeeLine As IORItemLineAdd = bankFeeLineList.Append
            bankFeeLine.ItemLineAdd.ItemRef.ListID.SetValue(app_row.BAD_CHECK_CHECKITEM_LISTID)
            bankFeeLine.ItemLineAdd.Amount.SetValue(BankRow.BANK_FEE_DEFAULT)
            bankFeeLine.ItemLineAdd.Quantity.SetValue(1)

            msgSetResp = SessionManager.DoRequests(MsgSetRequest)
            respList = msgSetResp.ResponseList

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    bounced = True
                Else
                    ResponseErr_Misc(resp)
                End If
            Next

            ' inserting note for customer that check bounced
            Try
                qta.CustomerNotes_Insert(CheckRow.CustomerNumber, "Bounced Check Ref #: " & CheckRow.RefNumber & ". Bank Fee of " & FormatCurrency(BankRow.BANK_FEE_DEFAULT) & ". Customer charged " & FormatCurrency(Fee) & ".")
            Catch ex As Exception
                MsgBox("NoteInsert Err: " & ex.Message)
            End Try

            Return bounced
        End Function
        Protected Overrides Sub Finalize()
            cta = Nothing
            MyBase.Finalize()
        End Sub
    End Class

    Public Class Invoicing
        Inherits QB_Procedures


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
                SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omDontCare)
                inSession = True
            End If

            ' instantiate
            wta = New DataSetTableAdapters.Batch_WorkingInvoiceTableAdapter
            lita = New DataSetTableAdapters.BATCH_LineItemsTableAdapter
            lidt = New DataSet.BATCH_LineItemsDataTable
            qta = New DataSetTableAdapters.QueriesTableAdapter
        End Sub

        Public Class NewInvObj
            Public CustomerListID
            Public TxnID
            Public BalanceRemaining
        End Class

        Protected wta As DataSetTableAdapters.Batch_WorkingInvoiceTableAdapter
        Protected lidt As DataSet.BATCH_LineItemsDataTable
        Protected lita As DataSetTableAdapters.BATCH_LineItemsTableAdapter

        Public Function CustomInvoice(ByRef CustomerNumber As Integer, ByRef PostDate As Date, ByRef DueDate As Date, ByRef Print As Boolean,
                                      ByVal InvDesc As String, ByRef lineItems As DataSet.CustomInvoice_LineItemsDataTable) As Integer
            Dim historyID As Integer

            If (inSession) Then

                ' checking balance of customer
                Dim customer As New QB_Queries.Customer(SessionManager, MsgSetRequest)
                Dim custListID As String = qta.Customer_GetListID(CustomerNumber)
                Dim custBalance As Double = customer.Balance(custListID)
                customer = Nothing


                ' interfaces needed for invoicing and line items
                Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq
                ' limiting response
                invoiceAdd.IncludeRetElementList.Add("TxnID")
                invoiceAdd.IncludeRetElementList.Add("RefNumber")
                invoiceAdd.IncludeRetElementList.Add("BalanceRemaining")
                invoiceAdd.IncludeRetElementList.Add("TimeCreated")
                invoiceAdd.IncludeRetElementList.Add("Subtotal")

                ' build request
                invoiceAdd.CustomerRef.ListID.SetValue(custListID)
                invoiceAdd.TxnDate.SetValue(PostDate)
                invoiceAdd.DueDate.SetValue(DueDate)
                invoiceAdd.IsToBePrinted.SetValue(Print)

                ' line list
                Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
                ' line item to reuse
                Dim lineItem As IORInvoiceLineAdd
                ' this is default item for custom invoices
                Dim itemListID As String = qta.APP_GetCustomInvItem()


                ' loop through line items
                For Each lineRow As DataSet.CustomInvoice_LineItemsRow In lineItems.Rows
                    lineItem = lineList.Append

                    lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(itemListID)
                    lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineRow.Rate)
                    lineItem.InvoiceLineAdd.Quantity.SetValue(1)
                    lineItem.InvoiceLineAdd.Desc.SetValue(lineRow.Description)
                Next

                ' description line
                Dim descLine As IORInvoiceLineAdd = lineList.Append
                descLine.InvoiceLineAdd.ItemRef.ListID.Unset()
                descLine.InvoiceLineAdd.ItemRef.FullName.Unset()
                descLine.InvoiceLineAdd.Desc.SetValue(InvDesc)
                descLine.InvoiceLineAdd.Amount.Unset()
                descLine.InvoiceLineAdd.Quantity.Unset()

                Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList

                MsgSetRequest.ClearRequests()

                For i = 0 To respList.Count - 1
                    Dim resp As IResponse = respList.GetAt(i)
                    If (resp.StatusCode <> 0) Then

                        Try
                            ResponseErr_Misc(resp)
                        Catch ex As Exception
                            MsgBox("Err_Invoice_Insert: " & ex.Message)
                        End Try

                    Else
                        Dim invRet As IInvoiceRet = resp.Detail


                        ' custom invoice history inser
                        Try

                            Dim hta As New Report_DataSetTableAdapters.CustomInvoiceHistoryTableAdapter
                            historyID = qta.CustomInvoiceHistory_Insert(CustomerNumber,
                                        invRet.TxnID.GetValue,
                                        invRet.RefNumber.GetValue,
                                        invRet.TimeCreated.GetValue,
                                        DueDate,
                                        invRet.Subtotal.GetValue)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        ' checking for overpayment usage
                        If (invRet.BalanceRemaining.GetValue > 0) Then
                            ' class to keep track of this
                            Dim invObj As New NewInvObj
                            invObj.CustomerListID = custListID
                            invObj.TxnID = invRet.TxnID.GetValue
                            invObj.BalanceRemaining = invRet.BalanceRemaining

                            If (custBalance < 0) Then
                                ' check for credits
                                CheckCredits(invObj)
                                If (invObj.BalanceRemaining > 0) Then
                                    ' if balance remain after credits, check for overpayments
                                    CheckOverpayments(invObj)
                                End If
                            End If
                        End If
                    End If

                Next i

            End If


            Return historyID
        End Function
        Public Function VoidInvoice(ByVal TxnID As String) As Boolean
            ' return bool
            Dim voided As Boolean
            voided = VoidTransactionByTxnID(TxnID, ENTxnVoidType.tvtInvoice)
            Return voided
        End Function

        Public Sub CheckOverpayments(ByRef newInv As NewInvObj)
            Dim recievePayQuery As IReceivePaymentQuery = MsgSetRequest.AppendReceivePaymentQueryRq

            ' only things i want back
            recievePayQuery.IncludeRetElementList.Add("UnusedPayment")
            recievePayQuery.IncludeRetElementList.Add("TxnID")
            recievePayQuery.IncludeRetElementList.Add("EditSequence")
            recievePayQuery.IncludeRetElementList.Add("AppliedToTxnRet")

            ' passing param here
            recievePayQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(newInv.CustomerListID)
            ' limiting results to last 30 payments
            recievePayQuery.ORTxnQuery.TxnFilter.MaxReturned.SetValue(30)

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clearMsgSetReq
            MsgSetRequest.ClearRequests()

            ' looping through responseList
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    If (resp.Detail IsNot Nothing) Then
                        Dim recievePayRetList As IReceivePaymentRetList = resp.Detail
                        For l = 0 To recievePayRetList.Count - 1
                            Dim recievePayRet As IReceivePaymentRet = recievePayRetList.GetAt(l)
                            If (recievePayRet IsNot Nothing) Then

                                ' making sure invoice still has balance
                                If (newInv.BalanceRemaining > 0) Then
                                    ' checking if UnusedPayment > 0
                                    If (recievePayRet.UnusedPayment.GetValue > 0) Then

                                        ' reading through applied to txn ret for upcoming mod
                                        Dim appliedTxnList As IAppliedToTxnRetList = recievePayRet.AppliedToTxnRetList

                                        ' mod the payment for the new invoice
                                        ' need to catch return bool if its paid off
                                        Dim paidOff As Boolean =
                                            UseOverpayment(recievePayRet.TxnID.GetValue,
                                                       recievePayRet.EditSequence.GetValue,
                                                       recievePayRet.UnusedPayment.GetValue,
                                                       appliedTxnList,
                                                       newInv)

                                        ' exiting if paid off
                                        If (paidOff) Then
                                            Exit For
                                        End If
                                    End If
                                End If
                            End If
                        Next l
                    End If
                ElseIf (resp.StatusCode = 1) Then
                    ' no payments = exit sub
                    MsgSetRequest.ClearRequests()
                    Exit Sub
                ElseIf (resp.StatusCode > 1) Then
                    ResponseErr_Misc(resp)
                End If
            Next i

            MsgSetRequest.ClearRequests()
        End Sub
        Private Function UseOverpayment(ByVal OverpayTxnID As String,
                                   ByVal OverpayEditSeq As String,
                                   ByVal OverpayRemain As Double,
                                   ByRef AttachedTxns As IAppliedToTxnRetList,
                                   ByRef newInv As NewInvObj) As Boolean
            ' this var will be returned after every overpayment to let the calling sub know if it needs to use another
            Dim paidOff As Boolean

            Dim recievePayMod As IReceivePaymentMod = MsgSetRequest.AppendReceivePaymentModRq

            recievePayMod.TxnID.SetValue(OverpayTxnID)
            recievePayMod.EditSequence.SetValue(OverpayEditSeq)

            Dim appliedTxnList As IAppliedToTxnModList = recievePayMod.AppliedToTxnModList
            Dim appliedTxn As IAppliedToTxnMod

            ' readding existing attached txns
            If (AttachedTxns IsNot Nothing) Then
                For i = 0 To AttachedTxns.Count - 1
                    appliedTxn = appliedTxnList.Append()
                    appliedTxn.TxnID.SetValue(AttachedTxns.GetAt(i).TxnID.GetValue)
                    appliedTxn.PaymentAmount.SetValue(AttachedTxns.GetAt(i).Amount.GetValue)
                Next i
            End If

            ' adding newly created inv
            Dim newTxn As IAppliedToTxnMod
            newTxn = appliedTxnList.Append()
            newTxn.TxnID.SetValue(newInv.TxnID)

            ' match to see how much we are applying
            If ((newInv.BalanceRemaining - OverpayRemain) <= 0) Then
                ' overpayment can cover the balance, so applied amount will be balance remaining
                newTxn.PaymentAmount.SetValue(newInv.BalanceRemaining)

                ' updating balance
                newInv.BalanceRemaining = 0
                ' updating return var
                paidOff = True
            Else
                ' balance will remain, so applied amount is the same as remaining overpayment
                newTxn.PaymentAmount.SetValue(OverpayRemain)

                ' updating balance
                newInv.BalanceRemaining = Math.Round((newInv.BalanceRemaining - OverpayRemain), 2)
                ' updating return var
                paidOff = False
            End If


            ' request is fully built, time to send and do response work
            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' looping through responseList
            For i = 0 To responseList.Count - 1
                Dim resp As IResponse = responseList.GetAt(i)
                If (resp.StatusCode > 0) Then
                    ResponseErr_Misc(resp)
                End If
            Next i

            MsgSetRequest.ClearRequests()
            Return paidOff
        End Function
        Public Sub CheckCredits(ByRef newInv As NewInvObj)
            Dim creditMemoQuery As ICreditMemoQuery = MsgSetRequest.AppendCreditMemoQueryRq

            ' only want these 2 things back
            creditMemoQuery.IncludeRetElementList.Add("CreditRemaining")
            creditMemoQuery.IncludeRetElementList.Add("TxnID")

            ' passing paramater here
            creditMemoQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(newInv.CustomerListID)

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetRequest.ClearRequests()

            ' looping through responseList
            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    If (resp.Detail IsNot Nothing) Then
                        Dim creditMemoRetList As ICreditMemoRetList = resp.Detail
                        For l = 0 To creditMemoRetList.Count - 1
                            ' making sure we still need to apply credits before exiting sub
                            If (newInv.BalanceRemaining > 0) Then
                                Dim creditMemoRet As ICreditMemoRet = creditMemoRetList.GetAt(l)
                                ' checking if CreditRemaining > 0
                                If (creditMemoRet.CreditRemaining.GetValue > 0) Then
                                    ' catching return bool if balance remains so can exit for loop
                                    Dim paidOff As Boolean =
                                    UseCredit(creditMemoRet.TxnID.GetValue, creditMemoRet.CreditRemaining.GetValue,
                                              newInv)

                                    ' exit loop
                                    If (paidOff) Then
                                        Exit For
                                    End If
                                End If
                            End If
                        Next l
                    End If
                ElseIf (resp.StatusCode = 1) Then
                    'no credits = exit sub
                    MsgSetRequest.ClearRequests()
                    Exit Sub
                ElseIf (resp.StatusCode > 1) Then
                    ResponseErr_Misc(resp)
                End If
            Next i

        End Sub
        Private Function UseCredit(ByVal CreditTxnID As String, ByVal CreditRemain As Double, ByRef newInv As NewInvObj) As Boolean
            Dim paidOff As Boolean

            ' create interface
            Dim recievePayAdd As IReceivePaymentAdd = MsgSetRequest.AppendReceivePaymentAddRq

            ' set attached cust
            recievePayAdd.CustomerRef.ListID.SetValue(newInv.CustomerListID)

            ' new invoice
            Dim newAttached As IAppliedToTxnAdd = recievePayAdd.ORApplyPayment.AppliedToTxnAddList.Append()
            newAttached.TxnID.SetValue(newInv.TxnID)

            Dim setCredit As ISetCredit = newAttached.SetCreditList.Append()
            setCredit.CreditTxnID.SetValue(CreditTxnID)

            If (newInv.BalanceRemaining > 0) Then
                ' checking how much i can apply
                If ((newInv.BalanceRemaining - CreditRemain) <= 0) Then
                    ' credit can cover the balance, so applied amount is the same as balance
                    setCredit.AppliedAmount.SetValue(newInv.BalanceRemaining)

                    ' updating balance
                    newInv.BalanceRemaining = 0
                Else
                    ' balance will remain, so applied amount is the same as remaining credit
                    setCredit.AppliedAmount.SetValue(CreditRemain)

                    ' updating balance
                    newInv.BalanceRemaining = Math.Round((newInv.BalanceRemaining - CreditRemain), 2)
                End If
            End If

            ' request is fully built, time to send and do response work
            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim responseList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetRequest.ClearRequests()

            ' looping through responseList
            For i = 0 To responseList.Count - 1
                Dim resp As IResponse = responseList.GetAt(i)
                If (resp.StatusCode > 0) Then
                    ResponseErr_Misc(resp)
                End If
            Next i

            Return paidOff
        End Function

        '''' old inv sub

        'Public Function Invoice(ByRef workingInvoiceID As Integer) As Integer
        '    Dim custInvID As Integer

        '    Dim invRow As DataSet.Batch_WorkingInvoiceRow = wta.GetDataByID(workingInvoiceID).Rows(0)
        '    If (inSession) Then
        '        ' fill line table
        '        lidt = lita.GetData(invRow.WorkingInvoiceID)

        '        ' checking balance of customer
        '        Dim customer As New QB_Queries.Customer(SessionManager, MsgSetRequest)
        '        Dim custBalance As Double = customer.Balance(invRow.CustomerListID)
        '        customer = Nothing


        '        ' interfaces needed for invoicing and line items
        '        Dim invoiceAdd As IInvoiceAdd = MsgSetRequest.AppendInvoiceAddRq
        '        ' limiting response
        '        invoiceAdd.IncludeRetElementList.Add("TxnID")
        '        invoiceAdd.IncludeRetElementList.Add("RefNumber")
        '        invoiceAdd.IncludeRetElementList.Add("BalanceRemaining")
        '        invoiceAdd.IncludeRetElementList.Add("TimeCreated")
        '        invoiceAdd.IncludeRetElementList.Add("Subtotal")

        '        ' build request
        '        invoiceAdd.CustomerRef.ListID.SetValue(invRow.CustomerListID)
        '        invoiceAdd.TxnDate.SetValue(invRow.InvoicePostDate)
        '        invoiceAdd.DueDate.SetValue(invRow.InvoiceDueDate)
        '        invoiceAdd.IsToBePrinted.SetValue(invRow.InvoiceToBePrinted)

        '        ' checking if memo provided
        '        If (invRow.IsInvoiceMemoNull = False) Then
        '            invoiceAdd.Memo.SetValue(invRow.InvoiceMemo)
        '        End If

        '        ' line list
        '        Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
        '        ' line item to reuse
        '        Dim lineItem As IORInvoiceLineAdd

        '        ' loop through line items
        '        For Each lineRow As DataSet.BATCH_LineItemsRow In lidt.Rows
        '            lineItem = lineList.Append

        '            lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(lineRow.ServiceListID)
        '            lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(lineRow.LineItemRate)
        '            lineItem.InvoiceLineAdd.Quantity.SetValue(lineRow.LineItemQuantity)
        '            lineItem.InvoiceLineAdd.Desc.SetValue(lineRow.Description)
        '        Next

        '        Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
        '        Dim respList As IResponseList = msgSetResp.ResponseList

        '        MsgSetRequest.ClearRequests()

        '        For i = 0 To respList.Count - 1
        '            Dim resp As IResponse = respList.GetAt(i)
        '            If (resp.StatusCode <> 0) Then
        '                invRow.InvoiceStatus = 6

        '                Try
        '                    ' insert err row
        '                    wta.ERR_INVOICE_Insert(invRow.WorkingInvoiceID,
        '                                            resp.StatusCode,
        '                                            resp.StatusMessage)
        '                Catch ex As Exception
        '                    MsgBox("Err_Invoice_Insert: " & ex.Message)
        '                End Try

        '            Else
        '                ' delay update till billed services written
        '                invRow.InvoiceStatus = 7

        '                Dim invRet As IInvoiceRet = resp.Detail

        '                ' updating row
        '                invRow.TxnID = invRet.TxnID.GetValue
        '                invRow.TxnNumber = invRet.RefNumber.GetValue
        '                invRow.InvoiceBalance = invRet.BalanceRemaining.GetValue

        '                ' update workingInvoice row
        '                Try
        '                    wta.Update(invRow)
        '                Catch ex As Exception
        '                    MsgBox(ex.Message)
        '                End Try

        '                ' custom invoice history inser
        '                Try
        '                    Dim hta As New Report_DataSetTableAdapters.CustomInvoiceHistoryTableAdapter
        '                    custInvID = hta.Insert(invRow.CustomerNumber,
        '                                invRow.TxnID,
        '                                invRow.TxnNumber,
        '                                invRet.TimeCreated.GetValue,
        '                                invRow.InvoiceDueDate,
        '                                invRet.Subtotal.GetValue)
        '                Catch ex As Exception
        '                    MsgBox(ex.Message)
        '                End Try

        '                ' checking for overpayment usage
        '                If (invRow.InvoiceBalance > 0) Then
        '                    If (custBalance < 0) Then
        '                        ' check for credits
        '                        CheckCredits(invRow)
        '                        If (invRow.InvoiceBalance > 0) Then
        '                            ' if balance remain after credits, check for overpayments
        '                            CheckOverpayments(invRow)
        '                        End If
        '                    End If
        '                End If
        '            End If

        '        Next i

        '    End If
        '    Try
        '        wta.DeleteComplete()
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        '    Return custInvID
        'End Function

        ' ^ old inv sub

        Protected Overrides Sub Finalize()
            wta = Nothing
            lidt = Nothing
            lita = Nothing
            MyBase.Finalize()
        End Sub
    End Class

    Public Class Items
        Inherits QB_Procedures

        Protected ta As DataSetTableAdapters.ServiceTypesTableAdapter
        Protected row As DataSet.ServiceTypesRow

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
                SessionManager.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omDontCare)
                inSession = True
            End If

            ' instantiate
            ta = New DataSetTableAdapters.ServiceTypesTableAdapter
            qta = New DataSetTableAdapters.QueriesTableAdapter
        End Sub

        Public Sub CreateNewServiceItem(ByVal serviceTypeID As Integer, ByVal QBAccountListID As String)
            row = ta.GetDataByID(serviceTypeID).Rows(0)

            Dim itemAdd As IItemServiceAdd = MsgSetRequest.AppendItemServiceAddRq

            ' setting item stuff
            itemAdd.Name.SetValue(row.ServiceName)
            itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(row.ServiceDescription)
            itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(row.ServiceRate)
            ' passing attached account
            itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(QBAccountListID)

            ' checking active state
            If (row.ServiceActive = False) Then
                itemAdd.IsActive.SetValue(False)
            Else
                itemAdd.IsActive.SetValue(True)
            End If

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetREq
            MsgSetRequest.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    Dim itemRet As IItemServiceRet = resp.Detail

                    ' update db information with edit sequence and list id
                    row.ServiceListID = itemRet.ListID.GetValue
                    row.ServiceEditSequence = itemRet.EditSequence.GetValue

                    ' commit to db
                    Try
                        ta.Update(row)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    ResponseErr_Misc(resp)
                    ta.DeleteByID(serviceTypeID)
                End If
            Next i
        End Sub

        Public Sub UpdateServiceItem(ByVal ServiceTypeID As Decimal)
            row = ta.GetDataByID(ServiceTypeID).Rows(0)

            Dim itemMod As IItemServiceMod = MsgSetRequest.AppendItemServiceModRq

            ' setting item we are talking about
            itemMod.ListID.SetValue(row.ServiceListID)
            itemMod.EditSequence.SetValue(row.ServiceEditSequence)

            ' update rate
            itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.ORPrice.Price.SetValue(row.ServiceRate)
            ' update description
            itemMod.ORSalesPurchaseMod.SalesOrPurchaseMod.Desc.SetValue(row.ServiceDescription)
            ' update active state
            If (row.ServiceActive = False) Then
                itemMod.IsActive.SetValue(False)
            Else
                itemMod.IsActive.SetValue(True)
            End If

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgSetReq
            MsgSetRequest.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then
                    Dim itemRet As IItemServiceRet = resp.Detail

                    ' update srvc row edit sequence
                    row.ServiceEditSequence = itemRet.EditSequence.GetValue
                    Try
                        ta.Update(row)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                ElseIf (resp.StatusCode = 3200) Then
                    ' update edit sequence in db
                    UpdateItemEditSeq(ServiceTypeID)
                Else
                    ResponseErr_Misc(resp)
                End If
            Next i
        End Sub

        Private Sub UpdateItemEditSeq(ByVal serviceTypeID As Integer)
            Dim itemQuery As IItemQuery = MsgSetRequest.AppendItemQueryRq

            ' setting listid
            itemQuery.ORListQuery.ListIDList.Add(qta.ServiceTypes_GetListIDByTypeID(serviceTypeID))

            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            'clear msgSetReq
            MsgSetRequest.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                Dim itemRetList As IORItemRetList = resp.Detail

                For j = 0 To itemRetList.Count - 1
                    Dim itemRet As IORItemRet = itemRetList.GetAt(j)

                    If (itemRet.ItemServiceRet IsNot Nothing) Then
                        ' update edit sequence
                        qta.ServiceTypes_UpdateEditSeq(serviceTypeID, itemRet.ItemServiceRet.EditSequence.GetValue)
                        ' redo update
                        UpdateServiceItem(serviceTypeID)
                        Exit Sub
                    End If
                Next
            Next
        End Sub

        Public Sub ImportAllServices(ByVal QBAccount As String)
            Dim dt As New DataSet.ServiceTypesDataTable
            Dim ta As New DataSetTableAdapters.ServiceTypesTableAdapter

            ' fill dt
            ta.FillWithAll(dt)

            For Each row As DataSet.ServiceTypesRow In dt.Rows
                If (row.IsServiceListIDNull = True) Then
                    Dim itemAdd As IItemServiceAdd = MsgSetRequest.AppendItemServiceAddRq

                    ' setting item stuff
                    itemAdd.Name.SetValue(row.ServiceName)
                    itemAdd.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(row.ServiceDescription)
                    itemAdd.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(row.ServiceRate)
                    ' passing attached account
                    itemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.ListID.SetValue(QBAccount)

                    ' checking active state
                    If (row.ServiceActive = False) Then
                        itemAdd.IsActive.SetValue(False)
                    Else
                        itemAdd.IsActive.SetValue(True)
                    End If

                    Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MsgSetRequest)
                    Dim respList As IResponseList = msgSetResp.ResponseList

                    ' clear msgSetREq
                    MsgSetRequest.ClearRequests()

                    For i = 0 To respList.Count - 1
                        Dim resp As IResponse = respList.GetAt(i)
                        If (resp.StatusCode = 0) Then
                            Dim itemRet As IItemServiceRet = resp.Detail

                            ' update db information with edit sequence and list id
                            row.ServiceListID = itemRet.ListID.GetValue
                            row.ServiceEditSequence = itemRet.EditSequence.GetValue

                            ' commit to db
                            Try
                                ta.Update(row)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        Else
                            ResponseErr_Misc(resp)
                            ta.DeleteByID(row.ServiceTypeID)
                        End If
                    Next i
                End If
            Next row

        End Sub
    End Class

    Protected Overrides Sub Finalize()
        If (connected) Then
            If (inSession) Then
                SessionManager.EndSession()
            End If
            SessionManager.CloseConnection()
        End If

        'clear vars
        _sessMgr = Nothing
        _msgSetReq = Nothing
        connected = Nothing
        inSession = Nothing
        qta = Nothing

        MyBase.Finalize()
    End Sub
End Class
