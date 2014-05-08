Public Class InvoicingForm
    ' property
    Private _currentCustomer As Integer
    Public Property CurrentCustomer
        Get
            Return _currentCustomer
        End Get
        Set(value)
            If (_currentCustomer <> value) Then
                _currentCustomer = value
                If (value > 0) Then
                    UC_CustomerInfoBoxes.CurrentCustomer = value
                    UC_CustomerNotes.CurrentCustomer = value
                    CustomerComboBox.SelectCustomer(CurrentCustomer)
                End If
            End If
            'Else
            'MsgBox("You must finish Modifying this Invoice first.")
        End Set
    End Property
    'Private _wrkInvID As Decimal
    'Public Property WorkingInvoiceID
    '    Get
    '        Return _wrkInvID
    '    End Get
    '    Set(value)
    '        If (Not IsModing) Then
    '            _wrkInvID = CDec(value)
    '            If (value > 0) Then
    '                ' UC_InvoiceDetails.WorkingInvoiceID = value

    '                ' lock the grid and show tooltip
    '                'dg_PrepInv.Enabled = False
    '                'tt_Locked.Active = True

    '                ' show delete button
    '                btn_DeleteInv.Visible = True

    '                CustomerComboBox.Enabled = False
    '                ck_ActiveCustOnly.Enabled = False

    '                ' lock cust info uc
    '                tc_Master.Enabled = False

    '                ' update property
    '                _IsModing = True
    '            Else
    '                CustomerComboBox.Enabled = True
    '                ck_ActiveCustOnly.Enabled = True

    '                ' unlock grid and hide tooltips
    '                'dg_PrepInv.Enabled = True
    '                'tt_Locked.Active = False

    '                ' hiding delete button
    '                btn_DeleteInv.Visible = False

    '                ' unlock cust info uc
    '                tc_Master.Enabled = True

    '                If (_currentCustomer > 0) Then
    '                    UC_InvoiceDetails.CurrentCustomer = _currentCustomer
    '                End If

    '                Me.WorkingInvoiceTableAdapter.FillByID(Me.DataSet.WorkingInvoice, "All", "All")

    '                'update property
    '                _IsModing = False
    '            End If
    '        Else
    '            MsgBox("You must finish Modifying this Invoice first.")
    '        End If
    '    End Set
    'End Property

    '' vars
    'Private _IsModing As Boolean = False
    'Public ReadOnly Property IsModing As Boolean
    '    Get
    '        Return _IsModing
    '    End Get
    'End Property
    Private LastCustomerChanged As Integer = 0

    Private Sub UpdateCatch(ByVal CustomerNumber As Decimal) Handles UC_CustomerInfoBoxes.UpdateComplete
        CustomerComboBox.SelectCustomer(CustomerNumber)
    End Sub

    Private Sub CustomerChanged(ByVal custNum As Decimal) Handles CustomerComboBox.CustomerChanged
        CurrentCustomer = custNum
        'WorkingInvoiceID = 0
        ' send listid to uc_inv
        'UC_InvoiceDetails.CustomerListID = UC_CustomerInfoBoxes.CustomerListID
    End Sub

    Private Sub ck_ActiveCustOnly_Click(sender As System.Object, e As System.EventArgs) Handles ck_ActiveCustOnly.Click
        If (ck_ActiveCustOnly.Checked = True) Then
            CustomerComboBox.CheckBox_ActiveOnly()
        Else
            CustomerComboBox.CheckBox_AllCustomers()
        End If
    End Sub

    Private Sub InvoicingForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (LastCustomerChanged <> 0) Then
            Master.ChildClosing(LastCustomerChanged, "An Invoice has been updated for Customer # " & LastCustomerChanged & ".  Would you like to switch to this Customer?")
        Else
            Master.PrepItemRefresh()
        End If
    End Sub

    Private Sub InvoicingForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WorkingInvoiceTableAdapter.FillByID(Me.DataSet.WorkingInvoice, "All", "All")

    End Sub

    'Private Sub cm_i_ModInv_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_ModInv.Click
    '    If (dg_PrepInv.SelectedRows.Count = 1) Then
    '        Dim row As DataRowView = dg_PrepInv.SelectedRows(0).DataBoundItem
    '        CurrentCustomer = row.Item("CustomerNumber")
    '        WorkingInvoiceID = row.Item("WorkingInvoiceID")
    '    Else
    '        MsgBox("Please select a Payment to Modify")
    '    End If
    'End Sub

    Private Sub LockAll(ByVal bool As Boolean) Handles UC_CustomerInfoBoxes.Updating
        If (bool = True) Then
            CustomerComboBox.Enabled = False
            ck_ActiveCustOnly.Enabled = False

            ts_Top.Enabled = False
            UC_InvoiceDetails.Enabled = False
            'dg_PrepInv.Enabled = False

        Else
            CustomerComboBox.Enabled = True
            ck_ActiveCustOnly.Enabled = True

            ts_Top.Enabled = True
            UC_InvoiceDetails.Enabled = True
            'dg_PrepInv.Enabled = True

        End If
    End Sub

    Private Sub btn_DeleteInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteInv.Click
        'UC_InvoiceDetails.DeleteInvoice()
    End Sub

    'Private Sub dg_PrepInv_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If (e.ColumnIndex = 5) Then
    '        Try
    '            Dim row As DataRowView = dg_PrepInv.Rows(dg_PrepInv.SelectedRows(0).Index).DataBoundItem
    '            Dim actualRow As DataSet.WorkingInvoiceRow = row.Row

    '            If (dg_PrepInv.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue = True) Then
    '                Me.WorkingInvoiceTableAdapter.UpdatePrint(actualRow.WorkingInvoiceID, "True")
    '            Else
    '                Me.WorkingInvoiceTableAdapter.UpdatePrint(actualRow.WorkingInvoiceID, "False")
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    'End Sub

    Private Sub ts_b_SearchNum_Click(sender As System.Object, e As System.EventArgs) Handles ts_b_SearchNum.Click
        Dim input As String = InputBox("Please type a Customer Number below to Search for a matching Customer.", "Customer Search: By Number")
        If (IsNumeric(input) = True) Then
            CustomerComboBox.SearchByNumber(input)
            ck_ActiveCustOnly.Checked = False
        Else
            MsgBox("You must provide a full Customer Number.")
        End If
    End Sub

    Private Sub ts_b_SearchName_Click(sender As System.Object, e As System.EventArgs) Handles ts_b_SearchName.Click
        Dim input As String = InputBox("Please type a Customer Name or part of a Customer Name to Search for a matching Customer.", "Customer Search: By Name")
        CustomerComboBox.SearchbyName(input)
        ck_ActiveCustOnly.Checked = False
    End Sub

    Private Sub ts_b_SearchAddr_Click(sender As System.Object, e As System.EventArgs) Handles ts_b_SearchAddr.Click
        Dim input As String = InputBox("Please type a Billing or Service Street Address or part of one to Search for a matching Customer.", "Customer Search: By Address")
        CustomerComboBox.SearchByAddress(input)
        ck_ActiveCustOnly.Checked = False
    End Sub

    Private Sub ActiveStateChange(ByVal ActiveOnly As Boolean) Handles CustomerComboBox.ListActiveStateChange
        If (ActiveOnly = True) Then
            ck_ActiveCustOnly.Checked = True
        Else
            ck_ActiveCustOnly.Checked = False
        End If
    End Sub
End Class