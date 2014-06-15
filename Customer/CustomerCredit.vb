Imports TrashCash.QBStuff



Namespace Customer
    Public Class CustomerCredit
        ' home form ref
        'Private _homeForm As TrashCashHome
        ' dt vars for service type binding
        Private _cDT As ds_Customer.Customer_RecurringServiceTypesDataTable
        Private _sDT As ds_Types.ServiceTypesDataTable

        ' event if balance changing but only if bool is true to prevent excessive error throwing
        Private _balanceChanged As Boolean = False
        Friend Event BalanceChanged(ByVal customerNumber As Integer)

        Private _currentCustomer As Integer
        Private Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                _currentCustomer = value
                ' getting service table
                If (value > 0) Then
                    Using ta As New ds_CustomerTableAdapters.Customer_RecurringServiceTypesTableAdapter
                        _cDT = ta.GetData(value)
                    End Using

                    ' checking if rows came back
                    If (_cDT.Rows.Count > 0) Then
                        cmb_Types.DataSource = _cDT
                        cmb_Types.DisplayMember = _cDT.ServiceNameColumn.ColumnName
                        cmb_Types.ValueMember = _cDT.ServiceListIDColumn.ColumnName
                    Else
                        ' no services for customer
                        Using ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
                            _sDT = ta.GetData()
                        End Using

                        ' binding combo box
                        cmb_Types.DataSource = _sDT
                        cmb_Types.DisplayMember = _sDT.ServiceNameColumn.ColumnName
                        cmb_Types.ValueMember = _sDT.ServiceListIDColumn.ColumnName
                    End If
                End If

            End Set
        End Property

        Public Sub New(ByVal customerNumber As Integer)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ' set customer
            CurrentCustomer = customerNumber
            ' hide toolstrip stuff and lock to customer
            CustomerToolstrip1.SelectCustomer(customerNumber)
            CustomerToolstrip1.Enabled = False
            CustomerToolstrip1.HideQuickSearch()
        End Sub

        Private Sub btn_VoidCredit_Click(sender As System.Object, e As System.EventArgs) Handles btn_VoidCredit.Click
            If (dg_Credits.SelectedRows.Count = 1) Then
                Dim row As ds_Customer.Customer_CreditsRow = CType(dg_Credits.SelectedRows(0).DataBoundItem, DataRowView).Row
                If (Not row.Voided) Then
                    ' prompt for reason
                    Dim prompt As DialogResult = MessageBox.Show("Void this Credit for " & FormatCurrency(row.CreditAmount) & ", created on " & row.TimeCreated, "Void Credit Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (prompt = Windows.Forms.DialogResult.Yes) Then
                        ' get reason
                        Dim reason As String = InputBox("Void Reason", "Void Reason")
                        If (Trim(reason).Length > 0) Then
                            ' void credit using its txnID

                            Dim resp As Integer = QBRequests.TxnVoid(row.CreditTxnID, 8)
                            If (resp = 0) Then
                                ' update row
                                row.Voided = True
                                row.VoidReason = reason
                                row.VoidTime = Date.Now
                                row.VoidUser = CurrentUser.USER_NAME
                                Try
                                    Customer_CreditsTableAdapter.Update(row)
                                Catch ex As SqlException
                                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error)
                                End Try
                    End If
                            _balanceChanged = True
                            ' reload history table
                            Customer_CreditsTableAdapter.FillByCustomerID(Ds_Customer.Customer_Credits, CurrentCustomer)
                        End If
                    End If

                Else
                    MessageBox.Show("This Credit was voided on " & row.VoidTime.Date & " by user " & row.VoidUser & ".", "Already voided", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Sub

        Private Sub btn_Create_Click(sender As System.Object, e As System.EventArgs) Handles btn_Create.Click
            ' making sure we have an amouint
            If (Trim(tb_Amount.Text).Length > 0) Then
                ' making sure we have a reason
                If (Trim(tb_Reason.Text).Length > 0) Then
                    Dim confirmPrompt As DialogResult = MessageBox.Show("Create Credit for " & CustomerToolstrip1.ToString & " - " & FormatCurrency(tb_Amount.Text) & vbCrLf & _
                                                                        "Reason:" & vbCrLf & tb_Reason.Text, "Confirm Credit for Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (confirmPrompt = Windows.Forms.DialogResult.Yes) Then
                        ' create creditObj
                        Dim creditObj As New QBCreditObj
                        With creditObj
                            .CustomerListID = GetCustomerListID(CurrentCustomer)
                            .ItemListID = cmb_Types.SelectedValue
                            .TotalAmount = tb_Amount.Text
                            .Desc = tb_Reason.Text
                            .IsToBePrinted = ck_Print.Checked
                        End With
                        Dim resp As Integer = QBRequests.CreditMemoAdd(creditObj)
                        If (resp = 0) Then
                            QBMethods.UseNewCredit(creditObj, rb_Newest.Checked)
                        Else
                            MessageBox.Show("Error adding credit memo")
                        End If
                       _balanceChanged = True
                        ' reload history table
                        Customer_CreditsTableAdapter.FillByCustomerID(Ds_Customer.Customer_Credits, CurrentCustomer)
                        ' reset form controls to default
                        cmb_Types.SelectedIndex = 0
                        tb_Amount.Text = ""
                        tb_Reason.Text = ""
                    End If
                End If
            End If
        End Sub

        Private Sub CustomerCredit_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            If (_balanceChanged) Then
                RaiseEvent BalanceChanged(CurrentCustomer)
            End If
        End Sub

        Private Sub ColorHistoryForVoids()
            If (dg_Credits.RowCount > 0) Then
                For i = 0 To dg_Credits.RowCount - 1
                    Dim row As ds_Customer.Customer_CreditsRow = CType(dg_Credits.Rows(i).DataBoundItem, DataRowView).Row
                    If (row.Voided) Then
                        ' credit is voided
                        dg_Credits.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        dg_Credits.Rows(i).DefaultCellStyle.SelectionBackColor = Color.IndianRed
                    Else
                        dg_Credits.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                        dg_Credits.Rows(i).DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen
                    End If
                Next
            End If
        End Sub

        Private Sub dg_Credits_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_Credits.RowsAdded
            ColorHistoryForVoids()
        End Sub

        Private Sub dg_Credits_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg_Credits.RowsRemoved
            ColorHistoryForVoids()
        End Sub

        Private Sub CustomerCredit_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ' fill history grid on load
            Customer_CreditsTableAdapter.FillByCustomerID(Ds_Customer.Customer_Credits, CurrentCustomer)
        End Sub

        Private Sub dg_Credits_MouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_Credits.CellMouseDown
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                For Each row As DataGridViewRow In dg_Credits.SelectedRows
                    row.Selected = False
                Next
                dg_Credits.Rows(e.RowIndex).Selected = True
            End If
        End Sub
    End Class
End Namespace