Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Admin

    Public Class AdminExportImport
        Private _missingCount As Integer
        Private Property MissingCustomerCount As Integer
            Get
                Return _missingCount
            End Get
            Set(value As Integer)
                _missingCount = value
                tb_MissingCount.Text = value

                ' color box red if value > 0
                If (value > 0) Then
                    tb_MissingCount.BackColor = AppColors.TextBoxErr
                    btn_AddCustomers.Enabled = True
                Else
                    tb_MissingCount.BackColor = AppColors.TextBoxDef
                    btn_AddCustomers.Enabled = False
                End If
            End Set
        End Property

        ' form global tas
        Dim _cqta As ds_CustomerTableAdapters.QueriesTableAdapter
        Private _cta As ds_CustomerTableAdapters.CustomerTableAdapter

        Private Sub AdminExportImport_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Select Case e.CloseReason
                Case Is = CloseReason.ApplicationExitCall, CloseReason.MdiFormClosing
                    Dispose()
                Case Else
                    e.Cancel = True
                    Hide()
            End Select
        End Sub


        Private Sub ImportWork_Load(sender As Object, e As System.EventArgs) Handles Me.Load
     CustomInvoice_LineTypesTableAdapter.Fill(Ds_Invoicing.CustomInvoice_LineTypes)
            ServiceTypesTableAdapter.Fill(Ds_Types.ServiceTypes)
            _cqta = New ds_CustomerTableAdapters.QueriesTableAdapter
            _cta = New ds_CustomerTableAdapters.CustomerTableAdapter

            ' update missing list id count
            MissingCustomerCount = _cqta.Customer_MissingListIDCount
            ' bind account cmb for adding items
            Dim incomes As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.AccountQuery(ENAccountType.atIncome))
            cmb_IncomeAcc.DisplayMember = "DisplayMember"
            cmb_IncomeAcc.ValueMember = "ValueMember"
            cmb_IncomeAcc.DataSource = incomes
            ' get bank accounts
            Dim banks As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.AccountQuery(ENAccountType.atBank))
            cmb_BankAccs.DisplayMember = "DisplayMember"
            cmb_BankAccs.ValueMember = "ValueMember"
            cmb_BankAccs.DataSource = banks
        End Sub

        Private Sub btn_AddCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustomers.Click
            If (MissingCustomerCount > 0) Then
                ' set cursor to hourglass
                Cursor = Cursors.WaitCursor

                ' make pb visible
                pb_AllCustAdd.Visible = True
                lbl_AllCustAddCount.Visible = True
                pb_AllCustAdd.Maximum = MissingCustomerCount
                pb_AllCustAdd.Value = 0

                Dim dt As ds_Customer.CustomerDataTable = _cta.GetDataByMissingListID()
                For Each row As ds_Customer.CustomerRow In dt
                    Dim resp As IResponse = QBRequests.CustomerAdd(row)
                    If (resp.StatusCode = 0) Then

                        Dim customerRet As ICustomerRet = resp.Detail
                        ' updating the custRow with ListID and EditSeq
                        row.CustomerListID = customerRet.ListID.GetValue
                        row.CustomerEditSeq = customerRet.EditSequence.GetValue
                        Try
                            _cta.Update(row)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        ' move progress bar
                        pb_AllCustAdd.Value += 1
                        lbl_AllCustAddCount.Text = pb_AllCustAdd.Value & "/" & MissingCustomerCount
                    Else
                        QBMethods.ResponseErr_Misc(resp)
                        MsgBox("Add fail")
                        Exit Sub
                    End If
                Next
                Cursor = Cursors.Default

                ' hide pb
                pb_AllCustAdd.Visible = False
                lbl_AllCustAddCount.Visible = False
                MissingCustomerCount = _cqta.Customer_MissingListIDCount
            End If
        End Sub

   
        Public Sub Items_ImportAllMissingListID(sender As System.Object, e As System.EventArgs) Handles btn_AddSrvcs.Click
            Dim result As MsgBoxResult = MsgBox("Please make sure the correct Account is selected above.", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                Dim dt As ds_Types.ServiceTypesDataTable = ServiceTypesTableAdapter.GetData
                For Each row As ds_Types.ServiceTypesRow In dt.Rows
                    If (row.IsServiceListIDNull = True) Then
                        Dim item As New QBItemObj
                        With item
                            .ItemName = row.ServiceName
                            .Price = row.ServiceRate
                            .Desc = row.ServiceDescription
                            .IncomeAccountListID = cmb_IncomeAcc.SelectedValue
                        End With

                        Dim resp As IResponse = QBRequests.ServiceItemAdd(item)
                        If (resp.StatusCode = 0) Then
                            Dim itemRet As IItemServiceRet = resp.Detail
                            ' update db information with edit sequence and list id
                            row.ServiceListID = itemRet.ListID.GetValue
                            row.ServiceEditSequence = itemRet.EditSequence.GetValue
                            Try
                                ' commit to db
                                ServiceTypesTableAdapter.Update(row)
                            Catch ex As SqlException
                                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                        Else
                            QBMethods.ResponseErr_Misc(resp)
                        End If
                    End If
                Next row
            End If
        End Sub

        Private Sub btn_AddSrvc_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddSrvc.Click
            Dim row As ds_Types.ServiceTypesRow = CType(cmb_ServiceTypes.SelectedItem, DataRowView).Row
            If (row.IsServiceListIDNull) Then
                Dim item As New QBItemObj
                With item
                    .ItemName = row.ServiceName
                    .Price = row.ServiceRate
                    .Desc = row.ServiceDescription
                    .IncomeAccountListID = cmb_IncomeAcc.SelectedValue
                End With
                Dim resp As IResponse = QBRequests.ServiceItemAdd(item)
                If (resp.StatusCode = 0) Then
                    Dim itemRet As IItemServiceRet = resp.Detail
                    ' update db information with edit sequence and list id
                    row.ServiceListID = itemRet.ListID.GetValue
                    row.ServiceEditSequence = itemRet.EditSequence.GetValue
                    Try
                        ' commit to db
                        ServiceTypesTableAdapter.Update(row)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    ServiceTypesBindingSource.ResetCurrentItem()
                Else
                    QBMethods.ResponseErr_Misc(resp)
                End If
            Else
                MessageBox.Show("Item already has ListID. Contact Premier to resolve.", "Contact Premier", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub
      
        Private Sub btn_AddCustInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustInv.Click
            Dim ds As New ds_Invoicing
          ' fill with all invoices missing a list id and all line items
            Invoicing.CiTA.FillMissingListID(ds.CustomInvoices)
            Invoicing.LiTA.FillWithAll(ds.CustomInvoice_LineItems)
            CustomInvoice_LineTypesTableAdapter.Fill(ds.CustomInvoice_LineTypes)
            If (ds.CustomInvoices.Rows.Count > 0) Then
                Dim result As MsgBoxResult = MsgBox("Add " & ds.CustomInvoices.Rows.Count & " Custom Invoices?", MsgBoxStyle.YesNo)
                If (result = MsgBoxResult.Yes) Then
                    Dim invObj As New QBInvoiceObj
                    Dim pass As Boolean = Invoicing.CustomInvoice_Create(invObj, ds, False)
                    If (pass) Then
                        MsgBox("Invoices Added")
                    Else
                        MsgBox("Invoice Add Fail")
                    End If
                End If
            End If
        End Sub

        Private Sub btn_AddInvType_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddInvType.Click
            Dim row As ds_Invoicing.CustomInvoice_LineTypesRow = CType(cmb_InvTypes.SelectedItem, DataRowView).Row
            If (row.IsQBListIDNull) Then
                Dim item As New QBItemObj
                With item
                    .ItemName = row.NAME
                    .Desc = row.Description
                    .IncomeAccountListID = cmb_IncomeAcc.SelectedValue
                End With

                Dim resp As IResponse = QBRequests.ServiceItemAdd(item)
                If (resp.StatusCode = 0) Then
                    Dim ret As IItemServiceRet = resp.Detail
                    Try
                        row.QBListID = ret.ListID.GetValue
                        row.QBEditSeq = ret.EditSequence.GetValue
                        row.EndEdit()
                        CustomInvoice_LineTypesTableAdapter.Update(row)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    MessageBox.Show("Item added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    QBMethods.ResponseErr_Misc(resp)
                End If
            Else
                MsgBox("Item already has listID")
            End If
        End Sub

       
        Private Sub btn_AddCheckBounce_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCheckBounce.Click
            If (cmb_BankAccs.SelectedValue IsNot Nothing) Then
                Dim row As ds_Application.APP_SETTINGSRow = AppTA.GetData.Rows(0)
                'Create 3 items:
                '1 - Bad Check Charge - "Customer charge for a bad check" (Other charge) - this is the item we charge customers for bouncing a check with us
                '2 - Bad Check Fee - "Fee from Bank for a bad check" (Other charge) - this is the item the bank charges us for
                '3 - Carl S. Bradley Bad Check - "Bad check amount" (Carl S. Bradley Account) - this is the item that goes on the inv for the bounced amount
                'Create vendor account:
                'Carl S. Bradley Fees

                '1 - Bad Check Charge - "Customer charge for a bad check" (Other charge) - this is the item we charge customers for bouncing a check with us
                Dim checkCharge As New QBItemObj
                With checkCharge
                    .ItemName = "Bad Check Charge"
                    .IncomeAccountListID = cmb_IncomeAcc.SelectedValue
                    .Desc = "Customer charge for bad check."
                End With
                QBRequests.OtherChargeItemAdd(checkCharge)
                row.BAD_CHECK_CUSTITEM_LISTID = checkCharge.ListID
                '2 - Bad Check Fee - "Fee from Bank for a bad check" (Other charge) - this is the item the bank charges us for
                Dim bankFee As New QBItemObj
                With bankFee
                    .ItemName = "Bad Check Fee"
                    .IncomeAccountListID = cmb_IncomeAcc.SelectedValue
                    .Desc = "Fee from Bank for a bad check."
                End With
                QBRequests.OtherChargeItemAdd(bankFee)
                row.BAD_CHECK_CHECKITEM_LISTID = cmb_IncomeAcc.SelectedValue
                '3 - Carl S. Bradley Bad Check - "Bad check amount" (Carl S. Bradley Account) - this is the item that goes on the inv for the bounced amount
                Dim bankItem As New QBItemObj
                With bankItem
                    .ItemName = cmb_BankAccs.GetItemText(cmb_BankAccs.SelectedItem) & " Bad Check"
                    .IncomeAccountListID = cmb_BankAccs.SelectedValue
                    .Desc = "Bad check amount"
                End With
                QBRequests.OtherChargeItemAdd(bankItem)
                ' this isn't set on any row, but will be used when setting up the bank
                ' now need to create the vendor thqts used to pay the fee from the bank via check
                Dim newVendor As IVendorAdd = GlobalConMgr.MessageSetRequest.AppendVendorAddRq
                newVendor.Name.SetValue(cmb_BankAccs.GetItemText(cmb_BankAccs.SelectedItem) & " Fees")
                newVendor.CompanyName.SetValue(cmb_BankAccs.GetItemText(cmb_BankAccs.SelectedItem))
                Dim resp As IResponse = GlobalConMgr.GetRespList.GetAt(0)
                If (resp.StatusCode <> 0) Then
                    QBMethods.ResponseErr_Misc(resp)
                    MsgBox("Vendor add fail: " & resp.StatusMessage)
                Else
                    MessageBox.Show("Items added for Bounced Checks.")
                End If
            
            End If
        End Sub

    End Class
End Namespace
