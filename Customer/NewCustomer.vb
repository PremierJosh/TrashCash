Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Customer

    Public Class NewCustomer
        ' event to let customer form know we are done
        Friend Event NewCustomerAdded(ByVal customerNumber As Integer)

        Private _custRow As ds_Customer.CustomerRow
        ' LOAD EVENTS
        Private Sub CustomerForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            _custRow = Ds_Customer.Customer.NewCustomerRow
            Ds_Customer.Customer.AddCustomerRow(_custRow)
        End Sub

        Private Sub createCustBtn_Click(sender As System.Object, e As System.EventArgs) Handles createCustBtn.Click
            If (TextCheck()) Then
                ' start date and one invoice info
                _custRow.CustomerReceiveOneInvoice = ck_SingleInv.Checked
                ' customer is active obviously
                _custRow.CustomerIsDeactive = False
                ' setting BilledInAdvance
                _custRow.CustomerBilledInAdvance = billedAdvanceChkBox.Checked
                ' setting Print Invoices
                _custRow.CustomerPrintInvoices = printInvoicesChkBox.Checked
                ' setting bill interval
                _custRow.CustomerBillInterval = nud_BillInterval.Value
                _custRow.CustomerStartDate = startDatePicker.Value
                
                ' trim phone number
                _custRow.CustomerPhone = PhoneFormat(_custRow.CustomerPhone)
                If (Not _custRow.IsCustomerAltPhoneNull) Then
                    _custRow.CustomerAltPhone = PhoneFormat(_custRow.CustomerAltPhone)
                End If

                _custRow.EndEdit()
                Try
                    ' push to table so i have a customer number
                    CustomerTableAdapter.Update(_custRow)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' build full name now that i have number
                If (_custRow.IsCustomerCompanyNameNull = False) Then
                    _custRow.CustomerFullName = _custRow.CustomerCompanyName & " - " & _custRow.CustomerNumber
                Else
                    _custRow.CustomerFullName = _custRow.CustomerLastName & ", " & _custRow.CustomerFirstName & " - " & _custRow.CustomerNumber
                End If

                ' sending row to customer add function
                Dim resp As IResponse = QBRequests.CustomerAdd(_custRow)
                If (resp.StatusCode = 0) Then
                    Dim customerRet As ICustomerRet = resp.Detail
                    ' updating the custRow with ListID and EditSeq
                    _custRow.BeginEdit()
                    _custRow.CustomerListID = customerRet.ListID.GetValue
                    _custRow.CustomerEditSeq = customerRet.EditSequence.GetValue
                    _custRow.EndEdit()
                    Try
                        CustomerTableAdapter.Update(_custRow)
                        MessageBox.Show("Customer: '" & _custRow.CustomerFullName & "' added successfully.", "Customer Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RaiseEvent NewCustomerAdded(_custRow.CustomerNumber)
                        Close()
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                ElseIf (resp.StatusCode = 3100) Then
                    ' customer already exists with that name
                    Dim input As String = InputBox("A Customer already exists with the Name " & _custRow.CustomerFullName & ". Please chose a different name.")
                    If (input.Length > 0) Then
                        _custRow.CustomerFullName = input
                        Try
                            CustomerTableAdapter.Update(_custRow)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Else
                    ' error logging
                    GlobalConMgr.ResponseErr_Misc(resp)
                    MessageBox.Show("Customer Add failed. Contact Premier.")
                    ' delete row
                    Using qta As New ds_CustomerTableAdapters.QueriesTableAdapter
                        qta.Customer_DeleteByNum(_custRow.CustomerNumber)
                    End Using
                End If
            Else
                MsgBox("Missing required fields.")
            End If

        End Sub
        Private Sub ck_SingleInv_Click(sender As System.Object, e As System.EventArgs) Handles ck_SingleInv.Click
            If (ck_SingleInv.Checked = True) Then
                Dim result As DialogResult = MessageBox.Show("Marking this Customer as Single Invoice will cause all Recurring Services to bill within that Customers Bill Interval - no matter the service." & vbCrLf & _
                                                    "For example, Toters will bill every 1 month if this Customers Bill Interval is set to 1. This change will also cause all Recurring Services to bill to " & vbCrLf & _
                                                    "the same day as the Customers Start Date day." & vbCrLf & _
                                                    "Do you wish to change this Customer to Single Invoice?", "Confirm Single Invoice Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If (result = Windows.Forms.DialogResult.No) Then
                    ck_SingleInv.Checked = False
                Else
                    ck_SingleInv.Checked = True
                End If

            End If
        End Sub
        Private Function NamesOk() As Boolean
            If (Trim(tb_FirstName.Text) = "" And Trim(tb_LastName.Text) = "") Then
                If (Trim(tb_CompanyName.Text) = "") Then
                    Return False
                Else
                    Return True
                End If
            ElseIf (Trim(tb_FirstName.Text) <> "" And Trim(tb_LastName.Text) <> "") Then
                Return True
            Else
                Return False
            End If
        End Function
        Private Function TextCheck() As Boolean
            Dim errorCount As Integer = 0
           If (Not NamesOk()) Then
                errorCount += 1
                MsgBox("Either a Company name is required, or both a First and Last name is required.")
            End If

            If (box_CustBillAddr1.Text.Length = 0) Then
                errorCount += 1
                box_CustBillAddr1.BackColor = AppColors.TextBoxErr
            Else
                box_CustBillAddr1.BackColor = AppColors.TextBoxDef
            End If
            If (box_CustBillAddr2.Text.Length = 0) Then
                errorCount += 1
                box_CustBillAddr2.BackColor = AppColors.TextBoxErr
            Else
                box_CustBillAddr2.BackColor = AppColors.TextBoxDef
            End If
            If (box_CustBillCity.Text.Length = 0) Then
                errorCount += 1
                box_CustBillCity.BackColor = AppColors.TextBoxErr
            Else
                box_CustBillCity.BackColor = AppColors.TextBoxDef
            End If
            If (box_CustBillState.Text.Length = 0) Then
                errorCount += 1
                box_CustBillState.BackColor = AppColors.TextBoxErr
            Else
                box_CustBillState.BackColor = AppColors.TextBoxDef
            End If
            If (box_CustBillZip.Text.Length = 0) Then
                errorCount += 1
                box_CustBillZip.BackColor = AppColors.TextBoxErr
            Else
                box_CustBillZip.BackColor = AppColors.TextBoxDef
            End If
            If (nud_BillInterval.Value < 1) Then
                errorCount += 1
                nud_BillInterval.BackColor = AppColors.TextBoxErr
            Else
                nud_BillInterval.BackColor = AppColors.TextBoxDef
            End If

            If (errorCount = 0) Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Sub box_CustBillAddr1_Enter(sender As System.Object, e As System.EventArgs) Handles box_CustBillAddr1.Enter
            ' when addr1 is entered, if company name exists, put it as addr1
            ' if last and first is present, add2 becomes first last
            ' if no company name, add1 becomes last, first
            If (box_CustBillAddr1.TextLength < 1) Then
                If (tb_CompanyName.TextLength > 1) Then
                    box_CustBillAddr1.Text = tb_CompanyName.Text
                    If (tb_FirstName.TextLength > 1 And tb_LastName.TextLength > 1) Then
                        box_CustBillAddr2.Text = tb_FirstName.Text & " " & tb_LastName.Text
                    End If
                ElseIf (tb_FirstName.TextLength > 1 And tb_LastName.TextLength > 1) Then
                    box_CustBillAddr1.Text = tb_LastName.Text & ", " & tb_FirstName.Text
                End If
            End If
        End Sub

        Private Sub ck_SingleInv_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ck_SingleInv.CheckedChanged
            If (ck_SingleInv.Checked = True) Then
                lbl_BillInterval.Visible = True
                nud_BillInterval.Visible = True
                nud_BillInterval.Value = 1
            Else
                lbl_BillInterval.Visible = False
                nud_BillInterval.Visible = False
            End If
        End Sub
    End Class
End Namespace