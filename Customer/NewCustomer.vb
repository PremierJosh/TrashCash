Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Customer

    Public Class NewCustomer
        ' event to let customer form know we are done
        Friend NewCustomerNumber As Integer = 0


        ' LOAD EVENTS
    

        Private Sub createCustBtn_Click(sender As System.Object, e As System.EventArgs) Handles btn_CreateCust.Click
            If (TextCheck()) Then
                Dim custRow As ds_Customer.CustomerRow
                Dim newRow As Boolean = False
                If (Ds_Customer.Customer.Rows.Count = 1) Then
                    custRow = Ds_Customer.Customer.Rows(0)
                ElseIf (Ds_Customer.Customer.Rows.Count = 0) Then
                    custRow = Ds_Customer.Customer.NewCustomerRow
                    newRow = True
                Else
                    MessageBox.Show("Customer table has more than 1 row, contact Premier Innovisions. Exiting")
                    Exit Sub
                End If

                With custRow
                    .BeginEdit()

                    ' required fields
                    .CustomerPhone = PhoneFormat(tb_Phone.Text)
                    .CustomerBillingAddr1 = tb_Addr1.Text
                    .CustomerBillingAddr2 = tb_Addr2.Text
                    .CustomerBillingCity = tb_City.Text
                    .CustomerBillingState = tb_State.Text
                    .CustomerBillingZip = tb_Zip.Text
                    .CustomerStartDate = dtp_StartDate.Value.Date
                    .CustomerIsDeactive = False

                    ' check boxes
                    .CustomerBilledInAdvance = ck_BillInAdvance.Checked
                    .CustomerPrintInvoices = ck_PrintInv.Checked
                    If (ck_SingleInv.Checked) Then
                        .CustomerReceiveOneInvoice = True
                        .CustomerBillInterval = nud_BillInterval.Value
                    Else
                        .CustomerReceiveOneInvoice = False
                        .CustomerBillInterval = 1
                    End If


                    ' optional fields
                    If (Trim(tb_CompanyName.Text) <> "") Then
                        .CustomerCompanyName = tb_CompanyName.Text
                    End If
                    If (Trim(tb_FirstName.Text) <> "") Then
                        .CustomerFirstName = tb_FirstName.Text
                    End If
                    If (Trim(tb_LastName.Text) <> "") Then
                        .CustomerLastName = tb_LastName.Text
                    End If
                    If (Trim(tb_AltPhone.Text) <> "") Then
                        .CustomerAltPhone = PhoneFormat(tb_AltPhone.Text)
                    End If
                    If (Trim(tb_Contact.Text) <> "") Then
                        .CustomerContact = tb_Contact.Text
                    End If
                    If (Trim(tb_Addr3.Text) <> "") Then
                        .CustomerBillingAddr3 = tb_Addr3.Text
                    End If
                    If (Trim(tb_Addr4.Text) <> "") Then
                        .CustomerBillingAddr4 = tb_Addr4.Text
                    End If
                End With

                ' add to table
                If (newRow) Then
                    Ds_Customer.Customer.AddCustomerRow(custRow)
                End If
                custRow.EndEdit()

                Try
                    ' push to table so i have a customer number
                    CustomerTableAdapter.Update(custRow)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("New Customer Add Failed - Exiting Save", "contact Premier Innovisions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
                ' build full name now that i have number
                If (custRow.IsCustomerCompanyNameNull = False) Then
                    custRow.CustomerFullName = custRow.CustomerCompanyName & " - " & custRow.CustomerNumber
                Else
                    custRow.CustomerFullName = custRow.CustomerLastName & ", " & custRow.CustomerFirstName & " - " & custRow.CustomerNumber
                End If

                ' sending row to customer add function
                Dim resp As IResponse = QBRequests.CustomerAdd(custRow)
                If (resp.StatusCode = 0) Then
                    Dim customerRet As ICustomerRet = resp.Detail
                    ' updating the custRow with ListID and EditSeq
                    custRow.BeginEdit()
                    custRow.CustomerListID = customerRet.ListID.GetValue
                    custRow.CustomerEditSeq = customerRet.EditSequence.GetValue
                    custRow.EndEdit()
                    Try
                        CustomerTableAdapter.Update(custRow)
                        MessageBox.Show("Customer: '" & custRow.CustomerFullName & "' added successfully.", "Customer Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NewCustomerNumber = custRow.CustomerNumber
                        Close()
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                ElseIf (resp.StatusCode = 3100) Then
                    ' customer already exists with that name
                    MessageBox.Show("A Customer already exists with the Name " & custRow.CustomerFullName & ". Please chose a different name.", "Name already taken", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Dim input As String = InputBox("A Customer already exists with the Name " & CustRow.CustomerFullName & ". Please chose a different name.")
                    'If (input.Length > 0) Then
                    '    CustRow.CustomerFullName = input
                    '    Try
                    '        CustomerTableAdapter.Update(CustRow)
                    '    Catch ex As SqlException
                    '        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                    '                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    End Try
                    'End If
                Else
                    ' error logging
                    QBMethods.ResponseErr_Misc(resp)
                    MessageBox.Show("Customer Add failed. contact Premier Innovisions.")
                    ' delete row
                    Using qta As New ds_CustomerTableAdapters.QueriesTableAdapter
                        qta.Customer_DeleteByNum(custRow.CustomerNumber)
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
                    ' dont check and hide bill interval
                    ck_SingleInv.Checked = False
                    lbl_BillInterval.Visible = False
                    nud_BillInterval.Visible = False
                Else
                    ' check and show bill interval
                    ck_SingleInv.Checked = True
                    lbl_BillInterval.Visible = True
                    nud_BillInterval.Visible = True
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
            ' phone number check
            If (tb_Phone.Text.Length = 0) Then
                errorCount += 1
                tb_Phone.BackColor = AppColors.TextBoxErr
            Else
                tb_Phone.BackColor = AppColors.TextBoxDef
            End If

            If (tb_Addr1.Text.Length = 0) Then
                errorCount += 1
                tb_Addr1.BackColor = AppColors.TextBoxErr
            Else
                tb_Addr1.BackColor = AppColors.TextBoxDef
            End If
            If (tb_Addr2.Text.Length = 0) Then
                errorCount += 1
                tb_Addr2.BackColor = AppColors.TextBoxErr
            Else
                tb_Addr2.BackColor = AppColors.TextBoxDef
            End If
            If (tb_City.Text.Length = 0) Then
                errorCount += 1
                tb_City.BackColor = AppColors.TextBoxErr
            Else
                tb_City.BackColor = AppColors.TextBoxDef
            End If
            If (tb_State.Text.Length = 0) Then
                errorCount += 1
                tb_State.BackColor = AppColors.TextBoxErr
            Else
                tb_State.BackColor = AppColors.TextBoxDef
            End If
            If (tb_Zip.Text.Length = 0) Then
                errorCount += 1
                tb_Zip.BackColor = AppColors.TextBoxErr
            Else
                tb_Zip.BackColor = AppColors.TextBoxDef
            End If

            ' single invoice check
            If (ck_SingleInv.Checked) Then
                If (nud_BillInterval.Value < 1) Then
                    errorCount += 1
                    nud_BillInterval.BackColor = AppColors.TextBoxErr
                Else
                    nud_BillInterval.BackColor = AppColors.TextBoxDef
                End If
            End If


            If (errorCount = 0) Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Sub box_CustBillAddr1_Enter(sender As System.Object, e As System.EventArgs) Handles tb_Addr1.Enter
            ' when addr1 is entered, if company name exists, put it as addr1
            ' if last and first is present, add2 becomes first last
            ' if no company name, add1 becomes last, first
            If (tb_Addr1.TextLength < 1) Then
                If (tb_CompanyName.TextLength > 1) Then
                    tb_Addr1.Text = tb_CompanyName.Text
                    If (tb_FirstName.TextLength > 1 And tb_LastName.TextLength > 1) Then
                        tb_Addr2.Text = tb_FirstName.Text & " " & tb_LastName.Text
                    End If
                ElseIf (tb_FirstName.TextLength > 1 And tb_LastName.TextLength > 1) Then
                    tb_Addr1.Text = tb_LastName.Text & ", " & tb_FirstName.Text
                End If
            End If
        End Sub

      
    End Class
End Namespace