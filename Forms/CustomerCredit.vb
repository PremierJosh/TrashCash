Public Class CustomerCredit
    ' home form ref
    Private _homeForm As TrashCashHome
    ' dt vars for service type binding
    Private c_dt As ds_Customer.Customer_RecurringServiceTypesDataTable
    Private s_dt As ds_Types.ServiceTypesDataTable

    ' event if balance changing but only if bool is true to prevent excessive error throwing
    Dim balanceChanged As Boolean = False
    Friend Event e_BalanceChanged(ByVal CustomerNumber As Integer)

    Private _currentCustomer As Integer
    Private Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            _currentCustomer = value

            ' set combo box
            Ts_M_Customer.CurrentCustomer = value

            ' getting service table
            If (value > 0) Then
                Using ta As New ds_CustomerTableAdapters.Customer_RecurringServiceTypesTableAdapter
                    c_dt = ta.GetData(value)
                End Using

                ' checking if rows came back
                If (c_dt.Rows.Count > 0) Then
                    cmb_Types.DataSource = c_dt
                    cmb_Types.DisplayMember = c_dt.ServiceNameColumn.ColumnName
                    cmb_Types.ValueMember = c_dt.ServiceListIDColumn.ColumnName
                Else
                    ' no services for customer
                    Using ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
                        s_dt = ta.GetData()
                    End Using

                    ' binding combo box
                    cmb_Types.DataSource = s_dt
                    cmb_Types.DisplayMember = s_dt.ServiceNameColumn.ColumnName
                    cmb_Types.ValueMember = s_dt.ServiceListIDColumn.ColumnName
                End If
            End If

        End Set
    End Property

    Public Sub New(ByRef HomeForm As TrashCashHome, ByVal CustomerNumber As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _homeForm = HomeForm
        Ts_M_Customer.HomeForm = HomeForm

        ' set customer
        CurrentCustomer = CustomerNumber

        ' hide toolstrip stuff and lock to customer
        Ts_M_Customer.Enabled = False
        Ts_M_Customer.HideQuickSearch()
    End Sub

    Private _rightClickRowIndex As Integer

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
                        _homeForm.Procedures.Customer_Credit_Void(row, reason)
                        balanceChanged = True
                        ' reload history table
                        Me.Customer_CreditsTableAdapter.FillByCustomerID(Me.Ds_Customer.Customer_Credits, CurrentCustomer)
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
                Dim confirmPrompt As DialogResult = MessageBox.Show("Create Credit for " & Ts_M_Customer.CurrentCustomerName & " - " & FormatCurrency(tb_Amount.Text) & vbCrLf & "Reason:" & vbCrLf & tb_Reason.Text,
                                                                    "Confirm Credit for Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If (confirmPrompt = Windows.Forms.DialogResult.Yes) Then
                    ' get apply order
                    Dim s As String
                    If (rb_Newest.Checked = True) Then
                        s = "Desc"
                    Else
                        s = "Asc"
                    End If

                    _homeForm.Procedures.Customer_Credit(CurrentCustomer, tb_Amount.Text, tb_Reason.Text, cmb_Types.SelectedValue, ck_Print.Checked, ck_AutoApply.Checked, s)
                    balanceChanged = True
                    ' reload history table
                    Me.Customer_CreditsTableAdapter.FillByCustomerID(Me.Ds_Customer.Customer_Credits, CurrentCustomer)

                    ' reset form controls to default
                    cmb_Types.SelectedIndex = 0
                    tb_Amount.Text = ""
                    tb_Reason.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub CustomerCredit_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (balanceChanged) Then
            RaiseEvent e_BalanceChanged(CurrentCustomer)
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
        Me.Customer_CreditsTableAdapter.FillByCustomerID(Me.Ds_Customer.Customer_Credits, CurrentCustomer)
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