﻿Imports TrashCash.Payments
Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Admin.Payments
    Public Class MovePaymentForm
        ' event to let pay history form refresh
        Friend Event PaymentMoveComplete()

        Private ReadOnly _payTA As PaymentHistory_DBTableAdapter

        ' var for actual pay history row
        Private _payHisRow As ds_Payments.PaymentHistory_DBRow
        Private Property PaymentHistoryRow As ds_Payments.PaymentHistory_DBRow
            Get
                Return _payHisRow
            End Get
            Set(value As ds_Payments.PaymentHistory_DBRow)
                _payHisRow = value

                ' update controls on form
                cmb_CurrCustomer.SelectedValue = value.CustomerNumber
                tb_Amount.Text = FormatCurrency(value.Amount)
                dtp_RecDateTime.Value = value.DateReceived
                lbl_InputBy.Text = "Input By: " & value.InsertedByUser

                ' checking if its cash - if not set controls and make visible
                If (value.PaymentTypeID <> 1) Then
                    tb_RefNum.Text = value.RefNumber
                    dtp_DateOnChk.Value = value.DateOnCheck

                    ' making controls visible
                    lbl_RefNum.Visible = True
                    lbl_DateOnCk.Visible = True
                    tb_RefNum.Visible = True
                    dtp_DateOnChk.Visible = True
                End If

                ' set payObj field
                _payObj = New QBRecievePaymentObj
                With _payObj
                    .TxnID = value.PaymentTxnID
                End With
            End Set
        End Property
        ' payment object
        Private _payObj As QBRecievePaymentObj
        ' pay his row ref
        Private WriteOnly Property PaymentID As Integer
            Set(value As Integer)
                ' getting db row
                Using ta As New PaymentHistory_DBTableAdapter
                    PaymentHistoryRow = ta.GetData(value).Rows(0)
                End Using
            End Set
        End Property


        Public Sub New(ByVal paymentID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ' fill customer list table
            Customer_ListByActiveTableAdapter.Fill(Ds_Customer.Customer_ListByActive, False)

            ' set various vars qb will need in mod request
            Me.PaymentID = paymentID
            _payTA = New PaymentHistory_DBTableAdapter
        End Sub

        Private Sub btn_MovePay_Click(sender As Object, e As EventArgs) Handles btn_MovePay.Click
            If (cmb_MoveToCust.SelectedValue <> cmb_CurrCustomer.SelectedValue) Then
                ' prompting to confirm move
                Dim result As DialogResult = MessageBox.Show("Move payment for " & FormatCurrency(PaymentHistoryRow.Amount) & ", receieved on " & FormatDateTime(PaymentHistoryRow.DateReceived, DateFormat.GeneralDate) & " for " & _
                                                             "Customer: " & cmb_CurrCustomer.GetItemText(cmb_CurrCustomer.SelectedItem) & vbCrLf & "To Customer: " & cmb_MoveToCust.GetItemText(cmb_MoveToCust.SelectedItem) & "?", "Confirm moving payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If (result = DialogResult.Yes) Then
                    Try
                        '_homeForm.Procedures.Payment_MoveToCustomer(PaymentHistoryRow, cmb_MoveToCust.SelectedValue)
                        MoveToCustomer()
                        MessageBox.Show("Payment Move Complete", "Payment Move Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RaiseEvent PaymentMoveComplete()
                        Close()
                    Catch ex As Exception
                        MessageBox.Show("Error Moving Payment. Contact Premier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                ' same customer selected both times
                MessageBox.Show("Payment already on that Customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub MoveToCustomer()
            ' setting newCustomerNumberRef
            Dim newCustomer As Integer = cmb_MoveToCust.SelectedValue
            Dim origCustomer As Integer = PaymentHistoryRow.CustomerNumber
            ' list for unusedPayments and openInvoices
            Dim payList As New List(Of QBRecievePaymentObj)
            Dim invList As New List(Of QBInvoiceObj)
            ' reusable resp obj
            Dim resp As IResponse

            ' need to query payment and get its current edit sequence and linked txns
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
            resp = QBRequests.PaymentQuery(txnID:=PaymentHistoryRow.PaymentTxnID)
            s.Clear()
            ' getting payObj from query - will only be 1 item
            If (resp.StatusCode = 0) Then
                _payObj = QBMethods.ConvertToPayObjs(resp).Item(0)
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' startResetDate is the earliest txnDate this payment we are moving paid for. all invoices with a txn date after this one will 
            'have their payments unapplied as well
            Dim startResetDate As Date
            ' if applied list is nothing because this payment wasn't applied to anything, set startResetDate as date of payment
            If (s.Count > 0) Then
                startResetDate = QBMethods.Invoices_EarliestCreationDate(_payObj.AppliedInvList)
            Else
                startResetDate = PaymentHistoryRow.DateReceived
            End If

            ' modding payment to wipe anything applied and move to new customer
            _payObj.CustomerListID = GetCustomerListID(newCustomer)
            resp = QBRequests.PaymentMod(payObj:=_payObj, wipeAppList:=True)
            If (resp.StatusCode = 0) Then
                ' if response good, update and move payment
                Dim payRet As IReceivePaymentRet = resp.Detail
                _payObj.EditSequence = payRet.EditSequence.GetValue
                _payTA.MovePayToCust(PaymentHistoryRow.PaymentID, newCustomer, _payObj.EditSequence)
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' need to get list of payments made on new customer after this payment
            resp = QBRequests.PaymentQuery(listID:=GetCustomerListID(newCustomer), fromDate:=_payHisRow.DateReceived)
            If (resp.StatusCode = 0) Then
                payList = QBMethods.ConvertToPayObjs(resp)
                If (payList.Count > 0) Then
                    ' reset payments in this list
                    For Each o As QBRecievePaymentObj In payList
                        resp = QBRequests.PaymentMod(payObj:=o, wipeAppList:=True)
                        If (resp.StatusCode = 0) Then
                            Dim ret As IReceivePaymentRet = resp.Detail
                            Try
                                ' attempt top update history
                                _payTA.UpdateEditSeq(ret.TxnID.GetValue, ret.EditSequence.GetValue)
                            Catch ex As SqlException
                                MessageBox.Show(
                                    "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Else
                            QBMethods.ResponseErr_Misc(resp)
                        End If
                    Next
                    ' get list of open invoices
                    resp = QBRequests.InvoiceQuery(listID:=GetCustomerListID(newCustomer), paidStatus:=ENPaidStatus.psNotPaidOnly)
                    invList = QBMethods.ConvertToInvObjs(resp)
                End If
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' checking if new customer has unapplied payments and open invoices we can pay
            Dim finishOk As Boolean
            finishOk = QBMethods.UseOverpaymentsOnInvoices(payList, invList)
            If (Not finishOk) Then
                MsgBox("Error with overpay use on 1st part - exiting.")
                Exit Sub
            End If

            ' same but with old customer using the startResetDate from above (earliest paid inv date of moved payment, or moved payment date)
            ' first unapply
            resp = QBRequests.InvoiceQuery(listID:=GetCustomerListID(origCustomer), fromDate:=startResetDate, incLinkTxn:=True)
            If (resp.StatusCode = 0) Then
                ' putting inv query to it
                payList = QBMethods.ConvertToPayObjs(resp)
                If (payList.Count > 0) Then
                    ' reset payments in this list
                    For Each o As QBRecievePaymentObj In payList
                        resp = QBRequests.PaymentMod(payObj:=o, wipeAppList:=True)
                        If (resp.StatusCode = 0) Then
                            Dim ret As IReceivePaymentRet = resp.Detail
                            Try
                                ' attempt top update history
                                _payTA.UpdateEditSeq(ret.TxnID.GetValue, ret.EditSequence.GetValue)
                            Catch ex As SqlException
                                MessageBox.Show(
                                    "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Else
                            QBMethods.ResponseErr_Misc(resp)
                        End If
                    Next
                    ' get list of open invoices
                    resp = QBRequests.InvoiceQuery(listID:=GetCustomerListID(origCustomer), paidStatus:=ENPaidStatus.psNotPaidOnly)
                    invList = QBMethods.ConvertToInvObjs(resp)
                End If
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' checking if new customer has unapplied payments and open invoices we can pay
            finishOk = QBMethods.UseOverpaymentsOnInvoices(payList, invList)
            If (Not finishOk) Then
                MsgBox("Error with overpay use on 2nd part, orig customer - exiting.")
                Exit Sub
            End If
        End Sub
    End Class
End Namespace