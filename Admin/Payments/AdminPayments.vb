Imports TrashCash.QBStuff


Namespace Admin.Payments
    Public Class AdminPayments

        ' move payment form ref
        Friend WithEvents MovePaymentForm As MovePaymentForm
        ' events
        Friend Event CustomerCheckBounce(ByVal customerNumber As Integer)
        Friend Event CustomerPaymentMoved(ByVal origCustomerNumber As Integer, ByVal newCustomerNumber As Integer)

        ' property to keep last selected customer
        Private _currentCustomer As Integer
        Public Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                If (_currentCustomer <> value) Then
                    _currentCustomer = value
                    Fetch_History()
                End If
            End Set
        End Property
        ' property to keep selected payment method
        Private _paymentType As Integer
        Public Property PaymentType
            Get
                Return _paymentType
            End Get
            Set(value)
                _paymentType = value

                ' set dv filter
                If (value <> 0) Then
                    Dim s As String = "PaymentTypeID = " & value
                    _dv.RowFilter = s
                Else
                    _dv.RowFilter = ""
                End If
            End Set
        End Property

        ' dataview
        Private _dv As DataView

        Private Sub ck_All_Click(sender As System.Object, e As System.EventArgs) Handles ck_All.CheckedChanged
            If (ck_All.Checked = True) Then
                ' disable payment types combo box
                cmb_PayTypes.Enabled = False
                ' reset payment type
                PaymentType = 0
            Else
                ' enable payment types combo box
                cmb_PayTypes.Enabled = True
                ' reset paymenttype
                PaymentType = cmb_PayTypes.SelectedValue
            End If
        End Sub

        Private Sub AdminPayments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Select Case e.CloseReason
                Case Is = CloseReason.ApplicationExitCall, CloseReason.MdiFormClosing
                    Dispose()
                Case Else
                    e.Cancel = True
                    Hide()
            End Select
        End Sub

        Private Sub PaymentHistory_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            PaymentTypesTableAdapter.Fill(Ds_Types.PaymentTypes)
            ' new stuff
            _dv = New DataView
            _dv.Table = Payments.PaymentHistory_Display
            _dv.Sort = "DateReceived DESC"
            dg_PaymentHistory.DataSource = _dv
            
            ' set date time picker values
            dtp_StartDate.Value = DateAdd(DateInterval.Day, -1, Date.Today)
            dtp_EndDate.Value = DateAdd(DateInterval.Month, 1, Date.Today)

            ' set payment type
            ck_All.Checked = True

            ' setting initial customer to screen isnt blank
            CurrentCustomer = CustomerToolstrip1.CurrentCustomer
            CustomerToolstrip1.GetCustomerBalance()
        End Sub

        Private Sub CustomerCatch(ByVal customerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
            CurrentCustomer = customerNumber
            CustomerToolstrip1.GetCustomerBalance()
        End Sub

        Public Sub Fetch_History() Handles dtp_EndDate.ValueChanged, dtp_StartDate.ValueChanged
            If (CurrentCustomer > 0) Then
                ' making sure we have a customer
                Try
                    PaymentHistory_DisplayTableAdapter.Fill(Payments.PaymentHistory_Display, CurrentCustomer, dtp_StartDate.Value.Date, dtp_EndDate.Value.Date)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Sub

        Private Sub cm_i_BouncedCheck_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_BounceCheck.Click
            If (dg_PaymentHistory.SelectedRows.Count = 1) Then
                ' easier refrence
                Dim row As ds_Payments.PaymentHistory_DisplayRow = CType(dg_PaymentHistory.SelectedRows(0).DataBoundItem, DataRowView).Row
                If (row.PaymentTypeID = 2) Then
                    If (Not row.Bounced) Then
                        Dim bounceForm As New BouncedBankSelection(row.PaymentID)
                        bounceForm.ShowDialog()
                        If (bounceForm.Bounced) Then
                            RaiseEvent CustomerCheckBounce(CurrentCustomer)
                            Fetch_History()
                        End If
                    Else
                        MsgBox("Check has already been set to bounced.")
                    End If
                Else
                    MsgBox("Selected Payment is not a Check.")
                End If
            Else
                MsgBox("Please select a Payment")
            End If
        End Sub

        Private Sub Cmb_PaymentTypes_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmb_PayTypes.SelectionChangeCommitted
            If (PaymentType <> sender.SelectedValue) Then
                PaymentType = sender.SelectedValue
            End If
        End Sub

        Private Sub cm_i_MovePayment_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_MovePayment.Click
            If (dg_PaymentHistory.SelectedRows.Count = 1) Then
                ' easier refrence
                Dim row As ds_Payments.PaymentHistory_DisplayRow = CType(dg_PaymentHistory.SelectedRows(0).DataBoundItem, DataRowView).Row
                ' result ref
                Dim result As DialogResult
                If (Not row.Bounced) Then
                    ' check if payment crosses year boundaries
                    If (row.DateReceived.Year = Date.Now.Year) Then
                        If (DateDiff(DateInterval.Day, row.DateReceived, Date.Now) < 90) Then
                            result = Windows.Forms.DialogResult.Yes
                        Else
                            result = MessageBox.Show("This Payment was receieved " & DateDiff(DateInterval.Day, row.DateReceived, Date.Now) & " days ago. Are you sure you want to move this payment?", "Targeted Pay > 90 Days ago", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        result = MessageBox.Show("This Payment was receieved in a different year than the current year. Are you sure you want to move this payment?", "Targeted Pay Outside Current Year", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("This payment has been marked as a bounced check.", "Unable to Move Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                If (result = Windows.Forms.DialogResult.Yes) Then
                    ' create move payment form
                    MovePaymentForm = New MovePaymentForm(row.PaymentID)
                    MovePaymentForm.ShowDialog()
                    If (MovePaymentForm.Moved) Then
                        RaiseEvent CustomerPaymentMoved(MovePaymentForm.OrigCustomerNumber, MovePaymentForm.NewCustomerNumber)
                        Fetch_History()
                    End If
                End If

            End If
        End Sub

       

        Private Sub dg_PaymentHistory_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg_PaymentHistory.RowPrePaint
            ' easier refrence
            Dim row As DataRowView = dg_PaymentHistory.Rows(e.RowIndex).DataBoundItem
            ' checking if bounced
            If (CBool(row.Item("Bounced")) = True) Then
                dg_PaymentHistory.Rows(e.RowIndex).DefaultCellStyle.BackColor = AppColors.GridRed
                dg_PaymentHistory.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = AppColors.GridRedSel
            End If
        End Sub

        Private Sub Panel1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
            If (e.Button = Windows.Forms.MouseButtons.Middle) Then
                Dim f As New UserSelection("Login for Payment Re-Sync")
                f.ShowDialog()
                If (f.AuthUserRow.USER_AUTHLVL = 1) Then
                    Cursor = Cursors.WaitCursor
                    ' get full payment history
                    Dim s As New List(Of String)
                    s.Add("AppliedToTxnRet")
                    s.Add("TxnID")
                    s.Add("EditSequence")
                    s.Add("CustomerRef")
                    s.Add("UnusedPayment")
                    Dim payObjList As New List(Of QBRecievePaymentObj)
                    QBRequests.PaymentQuery(payObjList, GetCustomerListID(CurrentCustomer), retEleList:=s)
                    ' wipe applied payments
                    For i = 0 To payObjList.Count - 1
                        If (payObjList.Item(i).AppliedInvList IsNot Nothing) Then
                            QBRequests.PaymentMod(payObjList.Item(i), wipeAppList:=True)
                        End If
                    Next
                    ' get list of open invoices
                    Dim invObjList As New List(Of QBInvoiceObj)
                    QBRequests.InvoiceQuery(invObjList, GetCustomerListID(CurrentCustomer), paidStatus:=2)
                    ' pay invoices with unapplied payments
                    QBMethods.UseOverpaymentsOnInvoices(payObjList, invObjList)
                    Cursor = Cursors.Default
                    MessageBox.Show("Payment Re-Sync completed", "Payment Re-Sync completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End Sub

        Private Sub btn_AlterCheckNum_Click(sender As System.Object, e As System.EventArgs) Handles btn_AlterCheckNum.Click
            If (dg_PaymentHistory.SelectedRows.Count = 1) Then
                ' easier refrence
                Dim row As ds_Payments.PaymentHistory_DisplayRow = CType(dg_PaymentHistory.SelectedRows(0).DataBoundItem, DataRowView).Row
                Dim aRow As ds_Payments.PaymentHistory_DBRow
                Dim ta As New ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter
                aRow = ta.GetData(row.PaymentID).Rows(0)
                If (aRow IsNot Nothing) Then
                    Select Case row.PaymentTypeID
                        Case 2, 3
                            Dim newRefNum As String = InputBox("Please enter the new Check #", "New Check #")
                            ' making sure we have a check number
                            If (newRefNum <> "") Then
                                ' trim new number and compare
                                Trim(newRefNum)
                                Replace(LTrim(Replace(newRefNum, "0", " ")), " ", "0")
                                If (newRefNum <> row.RefNumber) Then
                                    Dim payObj As New QBRecievePaymentObj
                                    With payObj
                                        .TxnID = aRow.PaymentTxnID
                                    End With
                                    ' reusable resp var
                                    Dim resp As Integer
                                    ' need current edit sequence
                                    resp = QBRequests.PaymentQuery(payObj)
                                    If (resp = 0) Then
                                        ' now alter check number
                                        payObj.RefNumber = newRefNum
                                        resp = QBRequests.PaymentMod(payObj)
                                        If (resp = 0) Then
                                            aRow.RefNumber = payObj.RefNumber
                                            ' update edit sequence and change check number
                                            Try
                                                ta.UpdateEditSeq(payObj.TxnID, payObj.EditSequence)
                                                ta.AlterRefNum(aRow.PaymentID, payObj.RefNumber)
                                                ' refil grid
                                                Fetch_History()
                                                MessageBox.Show("Check Number Changed to: " & newRefNum, "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Catch ex As SqlException
                                                MessageBox.Show(
                                                    "Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                MessageBoxIcon.Error)
                                            End Try
                                        End If
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("New Check # is the same as the previous Check #", "Check # Same", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Case Else
                            MessageBox.Show("Selected Payment is not a Check.", "Payment is Cash", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select
                Else
                    MessageBox.Show("No DB row found - Contact Premier")
                End If
            Else
                MessageBox.Show("Please select a Payment", "No Payment Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Sub

    End Class
End Namespace