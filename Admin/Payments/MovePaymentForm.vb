Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Admin.Payments
    Public Class MovePaymentForm

        ' fields for moving customer information
        Friend Moved As Boolean
        Friend OrigCustomerNumber As Integer
        Friend NewCustomerNumber As Integer

        Private ReadOnly _payTA As ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter

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
                ' update field for parent form ref
                OrigCustomerNumber = value.CustomerNumber
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
                Using ta As New ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter
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
            _payTA = New ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter
        End Sub

        Private Sub btn_MovePay_Click(sender As Object, e As EventArgs) Handles btn_MovePay.Click
            If (cmb_MoveToCust.SelectedValue IsNot Nothing) Then
                If (cmb_MoveToCust.SelectedValue <> cmb_CurrCustomer.SelectedValue) Then
                    ' prompting to confirm move
                    Dim result As DialogResult = MessageBox.Show("Move payment for " & FormatCurrency(PaymentHistoryRow.Amount) & ", receieved on " & FormatDateTime(PaymentHistoryRow.DateReceived, DateFormat.GeneralDate) & " for " & _
                                                                    "Customer: " & cmb_CurrCustomer.Text & vbCrLf & "To Customer: " & cmb_MoveToCust.Text & "?", "Confirm moving payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If (result = DialogResult.Yes) Then
                        '_homeForm.Procedures.Payment_MoveToCustomer(PaymentHistoryRow, cmb_MoveToCust.SelectedValue)
                        MoveToCustomer()
                        Close()
                     End If
                Else
                    ' same customer selected both times
                    MessageBox.Show("Payment already on that Customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Sub

        Private Sub MoveToCustomer()
            ' list for unusedPayments and openInvoices
            Dim payList As New List(Of QBRecievePaymentObj)
            Dim invList As New List(Of QBInvoiceObj)
            ' reusable resp obj
            Dim resp As Integer

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
            ' payment im moving
            Dim payObj As New QBRecievePaymentObj
            payObj.TxnID = PaymentHistoryRow.PaymentTxnID
            QBRequests.PaymentQuery(payObj)
            ' clear ret ele string for re-suse
            s.Clear()

            ' startResetDate is the earliest txnDate this payment we are moving paid for. all invoices with a txn date after this one will 
            'have their payments unapplied as well
            Dim startResetDate As Date
            ' if applied list is nothing because this payment wasn't applied to anything, set startResetDate as date of payment
            If (payObj.AppliedInvList IsNot Nothing) Then
                If (payObj.AppliedInvList.Count > 0) Then
                    startResetDate = QBMethods.Invoices_EarliestCreationDate(payObj.AppliedInvList)
                Else
                    startResetDate = PaymentHistoryRow.DateReceived
                End If
            Else
                startResetDate = PaymentHistoryRow.DateReceived
            End If

            ' modding payment to wipe anything applied and move to new customer
            payObj.CustomerListID = GetCustomerListID(NewCustomerNumber)
            resp = QBRequests.PaymentMod(payObj:=payObj, wipeAppList:=True)
            If (resp = 0) Then
                ' if response good, update and move payment
                Try
                    _payTA.MovePayToCust(PaymentHistoryRow.PaymentID, NewCustomerNumber, payObj.EditSequence)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                ' need to get list of payments made on new customer after this payment
                resp = QBRequests.PaymentQuery(payList, customerListID:=GetCustomerListID(NewCustomerNumber), fromDate:=_payHisRow.DateReceived)
                If (resp = 0) Then
                    If (payList.Count > 0) Then
                        ' reset payments in this list
                        For i = 0 To payList.Count - 1
                            resp = QBRequests.PaymentMod(payObj:=payList.Item(i), wipeAppList:=True)
                            If (resp = 0) Then
                                Try
                                    ' attempt top update history
                                    _payTA.UpdateEditSeq(payList.Item(i).TxnID, payList.Item(i).EditSequence)
                                Catch ex As SqlException
                                    MessageBox.Show(
                                        "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End If
                        Next
                        ' get list of open invoices
                        QBRequests.InvoiceQuery(invList, customerListID:=GetCustomerListID(NewCustomerNumber), paidStatus:=ENPaidStatus.psNotPaidOnly)
                    End If
                End If

                ' checking if new customer has unapplied payments and open invoices we can pay
                Dim finishOk As Boolean
                finishOk = QBMethods.UseOverpaymentsOnInvoices(payList, invList)
                If (Not finishOk) Then
                    MsgBox("Error with overpay use on 1st part - exiting.")
                    Exit Sub
                End If
                ' clear lists for orig customer
                invList.Clear()
                payList.Clear()

                ' same but with old customer using the startResetDate from above (earliest paid inv date of moved payment, or moved payment date)
                resp = QBRequests.InvoiceQuery(invList, customerListID:=GetCustomerListID(OrigCustomerNumber), fromDate:=startResetDate, incLinkTxn:=True)
                If (resp = 0) Then
                    If (payList.Count > 0) Then
                        ' reset payments in this list
                        For i = 0 To payList.Count - 1
                            resp = QBRequests.PaymentMod(payObj:=payList.Item(i), wipeAppList:=True)
                            If (resp = 0) Then
                                Try
                                    ' attempt top update history
                                    _payTA.UpdateEditSeq(payList.Item(i).TxnID, payList.Item(i).EditSequence)
                                Catch ex As SqlException
                                    MessageBox.Show(
                                        "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End If
                        Next
                        ' get list of open invoices
                        QBRequests.InvoiceQuery(invList, customerListID:=GetCustomerListID(OrigCustomerNumber), paidStatus:=ENPaidStatus.psNotPaidOnly)
                    End If
                End If

                ' checking if new customer has unapplied payments and open invoices we can pay
                finishOk = QBMethods.UseOverpaymentsOnInvoices(payList, invList)
                If (Not finishOk) Then
                    MsgBox("Error with overpay use on 2nd part, orig customer - exiting.")
                    Exit Sub
                End If

                MessageBox.Show("Payment Move Complete", "Payment Move Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Moved = True
            Else
                ' error on moving to new customer, exit now
                MessageBox.Show("Error Moving Payment. Contact Premier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Moved = False
            End If

        End Sub

        Private Sub cmb_MoveToCust_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmb_MoveToCust.SelectionChangeCommitted
            NewCustomerNumber = cmb_MoveToCust.SelectedValue
        End Sub

        Private Sub MovePaymentForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            If (cmb_MoveToCust.SelectedValue IsNot Nothing) Then
                NewCustomerNumber = cmb_MoveToCust.SelectedValue
            End If
        End Sub
    End Class
End Namespace