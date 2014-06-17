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
                    tb_MissingCount.BackColor = Color.MistyRose
                    btn_AddCustomers.Enabled = True
                Else
                    tb_MissingCount.BackColor = SystemColors.Window
                    btn_AddCustomers.Enabled = False
                End If
            End Set
        End Property

        ' form global tas
        Dim _cita As ds_ApplicationTableAdapters.Initial_CustomInvoiceTableAdapter
        Dim _cidt As ds_Application.Initial_CustomInvoiceDataTable
        Dim _cqta As ds_CustomerTableAdapters.QueriesTableAdapter
        Private _cta As ds_CustomerTableAdapters.CustomerTableAdapter


        Private Sub ImportWork_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ServiceTypesTableAdapter.Fill(Me.Ds_Types.ServiceTypes)
            _cqta = New ds_CustomerTableAdapters.QueriesTableAdapter
            _cita = New ds_ApplicationTableAdapters.Initial_CustomInvoiceTableAdapter
            _cidt = _cita.GetData()
            tb_CustInvCount.Text = _cidt.Rows.Count
            _cta = New ds_CustomerTableAdapters.CustomerTableAdapter

            ' update missing list id count
            MissingCustomerCount = _cqta.Customer_MissingListIDCount
            ' bind account cmb for adding items
            Dim incomes As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.AccountQuery(ENAccountType.atIncome))
            cmb_IncomeAcc.DisplayMember = "DisplayMember"
            cmb_IncomeAcc.ValueMember = "ValueMember"
            cmb_IncomeAcc.DataSource = incomes
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

   

        'Private Sub btn_AddCustInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustInv.Click
        '    ' getting custom inv item
        '    Dim itemID As String

        '    For Each row As ds_Application.Initial_CustomInvoiceRow In _cidt
        '        Dim invoiceAdd As IInvoiceAdd = GlobalConMgr.MessageSetRequest.AppendInvoiceAddRq

        '        ' build request
        '        invoiceAdd.CustomerRef.ListID.SetValue(row.CustomerListID)
        '        invoiceAdd.TxnDate.SetValue(row.PostAndDueDate)
        '        invoiceAdd.DueDate.SetValue(row.PostAndDueDate)
        '        invoiceAdd.IsToBePrinted.SetValue(False)

        '        ' line list
        '        Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
        '        ' line item to reuse
        '        Dim lineItem As IORInvoiceLineAdd


        '        lineItem = lineList.Append

        '        lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(itemID)
        '        lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(row.Total)
        '        lineItem.InvoiceLineAdd.Quantity.SetValue(1)

        '        Dim respList As IResponseList = GlobalConMgr.GetRespList

        '        For i = 0 To respList.Count - 1
        '            Dim resp As IResponse = respList.GetAt(i)
        '            If (resp.StatusCode <> 0) Then

        '                Try
        '                    GlobalConMgr.ResponseErr_Misc(resp)
        '                    Exit Sub
        '                Catch ex As Exception
        '                    MsgBox("Err_Invoice_Insert: " & ex.Message)
        '                End Try

        '            Else
        '                Dim invRet As IInvoiceRet = resp.Detail

        '                ' custom invoice history insert
        '                Try

        '                Catch ex As Exception
        '                    MsgBox(ex.Message)
        '                End Try

        '            End If

        '        Next i

        '    Next row

        '    MsgBox("Invoices added. Be sure to delete rows before next import.")
        'End Sub

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

        Private _importRow As ds_Application.BilledServicesRow
        Private _resetTbl As ds_Application.RecurringService_ResetInvoiceListDataTable
        Private _resetTA As ds_ApplicationTableAdapters.RecurringService_ResetInvoiceListTableAdapter
        Private _importTA As ds_ApplicationTableAdapters.BilledServicesTableAdapter
        Private Sub btn_FetchRecReset_Click(sender As System.Object, e As System.EventArgs) Handles btn_FetchRecReset.Click
            ' checking for previous invoices to delete
            If (_resetTA Is Nothing) Then
                _resetTA = New ds_ApplicationTableAdapters.RecurringService_ResetInvoiceListTableAdapter
            End If
            _resetTbl = _resetTA.GetData(tb_ResetRecID.Text)
            If (_resetTbl.Rows.Count > 0) Then
                ' enable deletion pf invoice history btn
                lbl_DeleteTotal.Text = "To be deleted: " & _resetTbl.Rows.Count
                lbl_DeleteTotal.Visible = True
                btn_DeleteHistory.Enabled = True
            Else
                btn_DeleteHistory.Enabled = False
                lbl_DeleteTotal.Visible = False
            End If

            ' checking if we already have a last bill thru row
            If (_importRow Is Nothing) Then
               If (Trim(tb_ResetRecID.Text) <> "") Then
                    ' instantiate ta
                    If (_importTA Is Nothing) Then
                        _importTA = New ds_ApplicationTableAdapters.BilledServicesTableAdapter
                    End If
                    _importRow = _importTA.GetData(tb_ResetRecID.Text).Rows(0)
                    ' check if row returned
                    If (_importRow IsNot Nothing) Then
                        ' show group
                        grp_ResetInvGrp.Visible = True
                        btn_LastBillThru.Text = "Update Row"
                        dtp_LastBillThru.Value = _importRow.EndBillingDate.Date
                        ' update text
                        btn_FetchRecReset.Text = "Reset Info"
                        tb_ResetRecID.Clear()
                    Else
                        ' no initial row is there
                        MessageBox.Show("No initial Billed Service row found. Setting a Last Bill Thru will create one.", "No Initial Row", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        grp_ResetInvGrp.Visible = True
                        ' change text on last bill thru btn
                        btn_LastBillThru.Text = "Create Row"
                    End If
                End If
            Else
                ResetForNewImportRow()
            End If
        End Sub
        Private Sub ResetForNewImportRow()
            ' we already have a row and need to reset
            _importRow = Nothing
            _resetTbl = Nothing
            grp_ResetInvGrp.Visible = False
            dtp_LastBillThru.Value = Date.Now
            ' update text
            btn_FetchRecReset.Text = "Fetch Info"
            tb_ResetRecID.Clear()
        End Sub

        Private Sub btn_LastBillThru_Click(sender As System.Object, e As System.EventArgs) Handles btn_LastBillThru.Click
            ' checking if row is there or not so this can be an insert or update
            If (_importRow IsNot Nothing) Then
                ' this is an update
                If (_importRow.EndBillingDate.Date <> dtp_LastBillThru.Value.Date) Then
                    Dim result As DialogResult = MessageBox.Show("Update Last Bill Thru from " & _importRow.EndBillingDate.Date & " to " & dtp_LastBillThru.Value.Date, "Confirm Change",
                                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (result = Windows.Forms.DialogResult.Yes) Then
                        _importRow.EndBillingDate = dtp_LastBillThru.Value.Date
                        _importRow.StartBillingDate = dtp_LastBillThru.Value.Date
                        _importRow.EndEdit()
                        Try
                            _importTA.Update(_importRow)
                            ResetForNewImportRow()
                        Catch ex as SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Else
                    MessageBox.Show("LastBillThru date didn't change", "Date didn't change", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Dim result As DialogResult = MessageBox.Show("Confirm creating Import row for RecurringServiceID: " & tb_ResetRecID.Text & ". With dates of: " & dtp_LastBillThru.Value.Date,
                                                             "Confirm ImportRow Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    ' import row doesn't exist so we need to make a new one
                    Try
                        _importTA.Insert(tb_ResetRecID.Text,
                                         dtp_LastBillThru.Value.Date,
                                         dtp_LastBillThru.Value.Date,
                                         0,
                                         0,
                                         0,
                                         False,
                                         Nothing,
                                         Nothing,
                                         99999,
                                         Nothing,
                                         0)
                        ResetForNewImportRow()
                    Catch ex as SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Sub

        Private Sub btn_DeleteHistory_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteHistory.Click
            ' concat string for modify needs
            Dim modNeed As Boolean = False
            Dim conS As New System.Text.StringBuilder
            If (_resetTbl IsNot Nothing) Then
                If (_resetTbl.Rows.Count > 0) Then
                    Dim result As DialogResult = MessageBox.Show("Do you wish to delete invoice history for this recurring service. Deleted count will be: " & _resetTbl.Rows.Count,
                                                                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If (result = Windows.Forms.DialogResult.Yes) Then
                        For Each row As ds_Application.RecurringService_ResetInvoiceListRow In _resetTbl.Rows
                            ' modify to remove line item
                            If (row.NeedModify) Then
                                ' for now im just going to return the invoice ref number for ease
                                Dim invObj As New QBInvoiceObj
                                invObj.TxnID = row.InvTxnID
                                ' only need ref number back for modify
                                Dim s As New List(Of String)
                                s.Add("RefNumber")
                                Dim resp As Integer = QBRequests.InvoiceQuery(invObj, retEleList:=s, incLineItems:=True)
                                If (resp = 0) Then
                                    modNeed = True
                                    conS.Append("Invoice Ref #: " & invObj.RefNumber & ". LineItemID: " & row.LineItemID).AppendLine()
                                End If
                            Else
                                ' delete invoices
                                Dim txnDel As ITxnDel = GlobalConMgr.MessageSetRequest.AppendTxnDelRq
                                txnDel.TxnDelType.SetValue(ENTxnDelType.tdtInvoice)
                                txnDel.TxnID.SetValue(row.InvTxnID)
                                Dim iresp As IResponse = GlobalConMgr.GetRespList.GetAt(0)
                                If (iresp.StatusCode <> 0) Then
                                    QBMethods.ResponseErr_Misc(iresp)
                                    Exit Sub
                                End If
                            End If
                        Next
                        MsgBox("Deletion finished, 2nd warning will mean manual intervention")
                        ResetForNewImportRow()
                    End If
                End If
            End If

            ' checking if need to display list for modify
            If (modNeed) Then
                MsgBox("Invoices need to be manually corrected: " & vbCrLf & conS.ToString)
            End If
        End Sub
    End Class
End Namespace