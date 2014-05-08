Imports QBFC12Lib
Imports TrashCash.CustomerComboBox


Public Class Testing



    Private Sub sendToQBBtn_Click(sender As System.Object, e As System.EventArgs) Handles sendToQBBtn.Click

        Dim TA As New QBDataSetTableAdapters.CustomerTableAdapter

        TA.FillByEmptyListID(QBDataSet.Customer)

        ' checking if i even get any results
        If (QBDataSet.Customer.Rows.Count < 1) Then
            MessageBox.Show("No new Customers in the DB")
            Exit Sub
        End If

        Dim sessMgr As New QBSessionManager
        ' Opening Connection
        sessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
        ' Beginging Session
        sessMgr.BeginSession("C:\Users\Public\Documents\Intuit\QuickBooks\Company Files\Test.QBW", 2)

        Dim msgSetReq As IMsgSetRequest
        msgSetReq = sessMgr.CreateMsgSetRequest("US", 11, 0)
        Dim msgSetResp As IMsgSetResponse
        Dim responseList As IResponseList

        For i = 0 To QBDataSet.Customer.Rows.Count - 1
            ' clearing requests
            msgSetReq.ClearRequests()

            ' creating cust add interface
            ' will have to process the request and response each time through the loop
            Dim custInfo As ICustomerAdd
            custInfo = msgSetReq.AppendCustomerAddRq

            '''' customer information ''''
            custInfo.Name.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerFullName"))
            ' checking possibly blank phone
            If (QBDataSet.Customer.Rows(i).Item("CustomerPhone").ToString.Length > 0) Then
                custInfo.Phone.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerPhone"))
            End If
            ' checking possibly blank alt phone
            If (QBDataSet.Customer.Rows(i).Item("CustomerAltPhone").ToString.Length > 0) Then
                custInfo.AltPhone.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerAltPhone"))
            End If
            ' checking possibly blank contact field
            If (QBDataSet.Customer.Rows(i).Item("CustomerContact").ToString.Length > 0) Then
                custInfo.Contact.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerContact"))
            End If
            ' checking possibly blank pickup day number and storing in note fild
            If (QBDataSet.Customer.Rows(i).Item("CustomerPickupDay").ToString.Length > 0) Then
                custInfo.Notes.SetValue("Customer Pickup Day - " & QBDataSet.Customer.Rows(i).Item("CustomerPickupDay"))
            End If

            '''' billing information ''''
            ' required billAddr1
            custInfo.BillAddress.Addr1.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerBillingAddr1"))
            ' checking billAddr2
            If (QBDataSet.Customer.Rows(i).Item("CustomerBillingAddr2").ToString.Length > 0) Then
                custInfo.BillAddress.Addr2.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerBillingAddr2"))
            End If
            ' checking billAddr3
            If (QBDataSet.Customer.Rows(i).Item("CustomerBillingAddr3").ToString.Length > 0) Then
                custInfo.BillAddress.Addr3.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerBillingAddr3"))
            End If
            custInfo.BillAddress.City.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerBillingCity"))
            custInfo.BillAddress.State.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerBillingState"))
            custInfo.BillAddress.PostalCode.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerBillingZip"))

            '''' shipping information ''''
            ' required shipAddr1
            custInfo.ShipAddress.Addr1.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerShipAddr1"))
            ' checking shipAddr2
            If (QBDataSet.Customer.Rows(i).Item("CustomerShipAddr2").ToString.Length > 0) Then
                custInfo.ShipAddress.Addr2.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerShipAddr2"))
            End If
            ' checking shipAddr3
            If (QBDataSet.Customer.Rows(i).Item("CustomerShipAddr3").ToString.Length > 0) Then
                custInfo.ShipAddress.Addr3.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerShipAddr3"))
            End If
            custInfo.ShipAddress.City.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerShipCity"))
            custInfo.ShipAddress.State.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerShipState"))
            custInfo.ShipAddress.PostalCode.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerShipZip"))

            ' if the cell has anything in it, set active to false
            If (QBDataSet.Customer.Rows(i).Item("CustomerIsDeactive") = True) Then
                custInfo.IsActive.SetValue(False)
                ' if the field is empty, don't append to customerAddRq (default = active)
            ElseIf (QBDataSet.Customer.Rows(i).Item("CustomerIsDeactive") = False) Then
            End If

            ' process customerAddReq
            msgSetResp = sessMgr.DoRequests(msgSetReq)
            responseList = msgSetResp.ResponseList

            ' looping through response list
            If (responseList.Count = 1) Then
                For l = 0 To responseList.Count - 1
                    Dim response As IResponse = responseList.GetAt(l)
                    If (response.StatusCode = 0) Then
                        Dim customerRet As ICustomerRet = response.Detail
                        ' adding ListID and EditSeq to the QBDataSet
                        QBDataSet.Customer.Rows(i).BeginEdit()
                        QBDataSet.Customer.Rows(i).Item("CustomerListID") = customerRet.ListID.GetValue()
                        QBDataSet.Customer.Rows(i).Item("CustomerEditSeq") = customerRet.EditSequence.GetValue()
                        QBDataSet.Customer.Rows(i).EndEdit()
                        Try
                            ' updating SqlDB with ListID and EditSeq of newly added customer
                            TA.Update(QBDataSet.Customer)
                        Catch ex As Exception
                            MessageBox.Show("Update failed")
                            Exit Sub
                        End Try

                    Else
                        MessageBox.Show("Error with Response Status Code of " & response.StatusCode.ToString, response.StatusMessage.ToString)
                        Exit Sub
                    End If
                Next l
            ElseIf (responseList.Count > 1) Then
                MessageBox.Show("Error Adding Customer", "Response count should be 1, but it is " & responseList.Count.ToString)
                Exit Sub
            End If


            ''''''' custom field requests '''''''
            ' clear msgSetReq
            msgSetReq.ClearRequests()

            '''' Customer Number ''''
            If (QBDataSet.Customer.Rows(i).Item("CustomerNumber").ToString.Length > 0) Then
                ' setting new msgSetReq
                Dim customerNumber As IDataExtMod
                customerNumber = msgSetReq.AppendDataExtModRq
                ' next 3 are static to this field
                customerNumber.OwnerID.SetValue("0")
                customerNumber.DataExtName.SetValue("Customer Number")
                customerNumber.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
                ' talking about customer with ListID of row i
                customerNumber.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerListID").ToString)
                customerNumber.DataExtValue.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerNumber").ToString)

                ' doing requests
                sessMgr.DoRequests(msgSetReq)
                msgSetReq.ClearRequests()
            End If

            '''' Start Date ''''
            If (QBDataSet.Customer.Rows(i).Item("CustomerStartDate").ToString.Length > 0) Then
                ' setting new msgSetReq
                Dim customerStartDate As IDataExtMod
                customerStartDate = msgSetReq.AppendDataExtModRq
                ' next 3 are static to this field
                customerStartDate.OwnerID.SetValue("0")
                customerStartDate.DataExtName.SetValue("Start Date")
                customerStartDate.ORListTxn.ListDataExt.ListDataExtType.SetValue(ENListDataExtType.ldetCustomer)
                ' talking about customer with ListID of row i
                customerStartDate.ORListTxn.ListDataExt.ListObjRef.ListID.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerListID").ToString)
                customerStartDate.DataExtValue.SetValue(QBDataSet.Customer.Rows(i).Item("CustomerStartDate").ToString)

                ' doing requests
                sessMgr.DoRequests(msgSetReq)
                msgSetReq.ClearRequests()
            End If

            ' next row
        Next i
        'MessageBox.Show("Successfull")
        DataGridView2.Refresh()
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles queryCustomer.Click
        'Dim DT As New DataTable
        'DT.Columns.Add("CustomerName")
        'DT.Columns.Add("CustomerListID")
        'DT.Columns.Add("CustomerEditSeq")
        'Dim QBDataSet As QBDataSet = Customer.QBDataSet
        'customerQueryGrid.DataSource = DT

        'Dim sessMgr As QBSessionManager = Home.sessMgr
        'Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
        'Dim customerQuery As ICustomerQuery = msgSetReq.AppendCustomerQueryRq
        'customerQuery.ORCustomerListQuery.ListIDList.Add(QBDataSet.Customer.Rows(0).Item("CustomerListID"))
        ''sessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
        'sessMgr.BeginSession("C:\Users\Public\Documents\Intuit\QuickBooks\Company Files\Test.QBW", ENOpenMode.omDontCare)
        'Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
        'Dim responseList As IResponseList = msgSetResp.ResponseList
        'Dim response As IResponse = responseList.GetAt(0)
        'Dim customerRetList As ICustomerRetList = response.Detail
        'Dim customerRet As ICustomerRet = customerRetList.GetAt(0)
        'Dim newRow As DataRow
        'newRow = DT.NewRow()
        'newRow.Item(0) = customerRet.Name.GetValue
        'newRow.Item(1) = customerRet.ListID.GetValue
        'newRow.Item(2) = customerRet.EditSequence.GetValue
        'DT.Rows.Add(newRow)
        'customerQueryGrid.Refresh()
        'sessMgr.EndSession()
        QB_BatchRecievePayment()





    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles queryItem.Click
        Dim DT As New DataTable
        DT.Columns.Add("MethodName")
        DT.Columns.Add("MethodListID")
        DT.Columns.Add("MethodType")
        itemGrid.DataSource = DT

        Dim sessMgr As QBSessionManager = Home.sessMgr
        sessMgr.BeginSession("C:\Users\Public\Documents\Intuit\QuickBooks\Company Files\Test.QBW", ENOpenMode.omDontCare)
        Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
        Dim payMethQuery As IPaymentMethodQuery = msgSetReq.AppendPaymentMethodQueryRq
        payMethQuery.IncludeRetElementList.Add("ListID")
        payMethQuery.IncludeRetElementList.Add("Name")
        payMethQuery.IncludeRetElementList.Add("PaymentMethodType")

        Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
        Dim responseList As IResponseList = msgSetResp.ResponseList
        For i = 0 To responseList.Count - 1
            Dim Response As IResponse = responseList.GetAt(i)
            Dim methodRetList As IPaymentMethodRetList = Response.Detail
            For l = 0 To methodRetList.Count - 1
                Dim methodRet As IPaymentMethodRet = methodRetList.GetAt(l)
                Dim NewRow As DataRow
                NewRow = DT.NewRow()
                NewRow.Item(0) = methodRet.Name.GetValue
                NewRow.Item(1) = methodRet.ListID.GetValue
                NewRow.Item(2) = methodRet.PaymentMethodType.GetValue
                DT.Rows.Add(NewRow)
            Next

        Next i
        itemGrid.Refresh()

    End Sub


    Private Sub Testing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.WorkingInvoiceTableAdapter.Fill(Me.QBDataSet.WorkingInvoice)

        Me.WorkingInvoiceTableAdapter.Fill(Me.QBDataSet.WorkingInvoice)

        Me.LineItemTableAdapter.Fill(Me.QBDataSet.LineItem)

        Me.AttachedTxnsTableAdapter.Fill(Me.QBDataSet.AttachedTxns)

    End Sub

    Private Sub testBtn_Click(sender As System.Object, e As System.EventArgs) Handles testBtn.Click
        testGrid1.DataSource = Me.QBDataSet.Overpayments
        testGrid2.DataSource = Me.QBDataSet.AttachedTxns
        CustomerTableAdapter.FillByCustNum(Me.QBDataSet.Customer, 1000)
        Dim sessMgr As QBSessionManager = Home.sessMgr
        sessMgr.BeginSession("C:\Users\Public\Documents\Intuit\QuickBooks\Company Files\Test.QBW", ENOpenMode.omDontCare)
        Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
        Dim recievePaymentQuery As IReceivePaymentQuery = msgSetReq.AppendReceivePaymentQueryRq

        ' specifiying what customer i want recieve payments for
        recievePaymentQuery.ORTxnQuery.TxnFilter.EntityFilter.OREntityFilter.ListIDList.Add(Me.QBDataSet.Customer.Rows(0).Item("CustomerNumber"))
        ' getting txnID's
        recievePaymentQuery.IncludeRetElementList.Add("TxnID")
        ' edit sequence so we can modify the payment
        recievePaymentQuery.IncludeRetElementList.Add("EditSequence")
        ' list of applied txns on this payment
        recievePaymentQuery.IncludeRetElementList.Add("AppliedToTxnRet")
        ' unused payment include
        recievePaymentQuery.IncludeRetElementList.Add("UnusedPayment")

        Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
        Dim responseList As IResponseList = msgSetResp.ResponseList
        For i = 0 To responseList.Count - 1
            Dim response As IResponse = responseList.GetAt(i)
            ' error checking
            If (response.StatusCode = 1) Then
                Dim queryRetList As IReceivePaymentRetList = response.Detail
                For j = 0 To queryRetList.Count - 1
                    Dim queryRet As IReceivePaymentRet = queryRetList.GetAt(j)
                    ' new Overpayment table row creation
                    Dim newOverpaymentRow As QBDataSet.OverpaymentsRow = Me.QBDataSet.Overpayments.NewOverpaymentsRow
                    newOverpaymentRow.Item("CustomerNumber") = Me.QBDataSet.Customer.Rows(0).Item("CustomerNumber")
                    newOverpaymentRow.Item("OverpaymentRemaining") = queryRet.UnusedPayment.GetValue
                    newOverpaymentRow.Item("OverpaymentTxnID") = queryRet.TxnID.GetValue
                    newOverpaymentRow.Item("OverpaymentTxnEditSeq") = queryRet.EditSequence.GetValue
                    newOverpaymentRow.Item("OverpaymentCreatedDate") = queryRet.TimeCreated.GetValue
                    newOverpaymentRow.Item("OverpaymentModifiedDate") = queryRet.TimeModified.GetValue
                    Me.QBDataSet.Overpayments.AddOverpaymentsRow(newOverpaymentRow)
                    ' TEMP: uncomment this for actual Db changes
                    'Dim overpaymentTA As New QBDataSetTableAdapters.OverpaymentsTableAdapter
                    'overpaymentTA.Update(newOverpaymentRow)
                    If (queryRet.UnusedPayment.GetValue > 0) Then
                        Dim txnRetList As IAppliedToTxnRetList = queryRet.AppliedToTxnRetList
                        For l = 0 To txnRetList.Count - 1
                            Dim txnRet As IAppliedToTxnRet = txnRetList.GetAt(l)
                            Dim newAttachedTxnRow As QBDataSet.AttachedTxnsRow = Me.QBDataSet.AttachedTxns.NewAttachedTxnsRow
                            newAttachedTxnRow.Item("OverpaymentID") = newOverpaymentRow.Item("OverpaymentID")
                            newAttachedTxnRow.Item("AttachedInvoiceTxnID") = txnRet.TxnID.GetValue
                            newAttachedTxnRow.Item("AttachedAppliedAmount") = txnRet.Amount.GetValue
                            Me.QBDataSet.AttachedTxns.AddAttachedTxnsRow(newAttachedTxnRow)
                            ' TEMP: uncomment this for actual DB changes
                            'Dim attachedTxnTA As New QBDataSetTableAdapters.AttachedTxnsTableAdapter
                            'attachedTxnTA.Update(newAttachedTxnRow)
                        Next l
                    End If
                Next j
            Else
                ResponseErrorLoging(response)
            End If
        Next i
    End Sub

End Class