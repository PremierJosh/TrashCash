
Namespace QBStuff

    Public Class UC_Quickbooks
     
        ' list of retEles for queries
        Private ReadOnly _invRetEle As List(Of String)
        Private ReadOnly _payRetEle As List(Of String)

        ' these will limit excessive payment fetching
        Private _lastFetchTime As DateTime

        Friend Event BalanceChanged(ByVal customerNumber As Integer)
        Friend Event ServiceUpdated(ByVal customerNumber As Integer)

        ' need invoicing form here for event catching
        Friend WithEvents InvoicingForm As Invoicing.CustomInvoicingForm

        ' custListID property
        Private _custListID As String
        Public Property CustomerListID As String
            Get
                Return _custListID
            End Get
            Set(value As String)
                If (value IsNot Nothing) Then
                    _custListID = value

                    ' fill with all invoices and all payments
                    FetchInvoices(0)
                    FetchPayments()
                End If
            End Set
        End Property
        Public Property CustomerName As String


        ' field for refrence
        Friend CurrentCustomer As Decimal

        Friend Sub FetchInvoices(ByVal paidStatus As Integer)
            ' clear table
            Ds_Display.QB_InvoiceDisplay.Clear()
            ' vars
            Dim resp As Integer
            Dim invObjList As New List(Of QBInvoiceObj)
            If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, toDate:=dtp_ItemTo.Value.Date, retEleList:=_invRetEle, incLineItems:=True)
            ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, fromDate:=dtp_ItemFrom.Value.Date, retEleList:=_invRetEle, incLineItems:=True)
            ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, fromDate:=dtp_ItemFrom.Value.Date, toDate:=dtp_ItemTo.Value.Date, retEleList:=_invRetEle, incLineItems:=True)
            Else
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, incLineItems:=True)
            End If

            If (resp = 0) Then
                ' looping through invoices to build display rows
                For Each inv As QBInvoiceObj In invObjList
                    ' building new row
                    Dim newRow As ds_Display.QB_InvoiceDisplayRow = Ds_Display.QB_InvoiceDisplay.NewQB_InvoiceDisplayRow
                    With newRow
                        .InvoiceRefNumber = inv.RefNumber
                        .InvoicePostDate = inv.TxnDate
                        .InvoiceCreationDate = inv.TimeCreated
                        .InvoiceTotal = inv.Subtotal
                        .InvoiceBalance = inv.BalanceRemaining
                        .InvoiceDueDate = inv.DueDate
                    End With
                    ' checking type of inv this is
                    If (inv.Other IsNot Nothing) Then
                        If (inv.Other = "Custom") Then
                            newRow.CustomInvoice = True
                        End If
                    ElseIf (inv.LineList IsNot Nothing) Then
                        ' more than 1 line?
                        If (inv.LineList.Count = 1) Then
                            If (inv.LineList.Item(0).Other1 IsNot Nothing) Then
                                newRow.LineItemID = inv.LineList.Item(0).Other1
                            End If
                        Else
                            newRow.MultiServiceInv = True
                        End If
                    End If
                    ' adding
                    Ds_Display.QB_InvoiceDisplay.AddQB_InvoiceDisplayRow(newRow)
                Next
            End If
        End Sub

        Friend Sub FetchPayments()
            ' clear table
            Ds_Display.QB_PaymentsDisplay.Clear()
            'vars
            Dim resp As Integer
            Dim payObjList As New List(Of QBRecievePaymentObj)
            If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
                resp = QBRequests.PaymentQuery(payObjList, customerListID:=CustomerListID, toDate:=dtp_ItemTo.Value.Date, retEleList:=_payRetEle)
            ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.PaymentQuery(payObjList, customerListID:=CustomerListID, fromDate:=dtp_ItemFrom.Value.Date, retEleList:=_payRetEle)
            ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.PaymentQuery(payObjList, customerListID:=CustomerListID, fromDate:=dtp_ItemFrom.Value.Date, toDate:=dtp_ItemTo.Value.Date, retEleList:=_payRetEle)
            Else
                resp = QBRequests.PaymentQuery(payObjList, customerListID:=CustomerListID, retEleList:=_payRetEle)
            End If

            If (resp = 0) Then
                For Each pay As QBRecievePaymentObj In payObjList
                    ' building new paymentList row
                    Dim newRow As ds_Display.QB_PaymentsDisplayRow = Ds_Display.QB_PaymentsDisplay.NewQB_PaymentsDisplayRow
                    With newRow
                        .PaymentDate = pay.TxnDate
                        .PaymentAmount = pay.TotalAmount
                        .PaymentMethod = pay.PayTypeName
                        If (pay.RefNumber IsNot Nothing) Then
                            .PaymentCheckNum = pay.RefNumber
                        End If
                    End With
                    ' adding
                    Ds_Display.QB_PaymentsDisplay.AddQB_PaymentsDisplayRow(newRow)
                Next
            End If
            ' updating last fetch time
            _lastFetchTime = Date.Now
        End Sub

        Private Sub chk_ItemTo_Click(sender As System.Object, e As System.EventArgs) Handles chk_ItemTo.Click, chk_ItemFrom.Click
            ' filter To
            If (chk_ItemFrom.Checked = True) Then
                dtp_ItemFrom.Enabled = True
            Else
                dtp_ItemFrom.Enabled = False
            End If

            ' filter From
            If (chk_ItemTo.Checked = True) Then
                dtp_ItemTo.Enabled = True
            Else
                dtp_ItemTo.Enabled = False
            End If
        End Sub

        Private Sub ColorRows_QBInvoices(ByRef dgvRow As DataGridViewRow)
            Dim dbRow As ds_Display.QB_InvoiceDisplayRow = CType(dgvRow.DataBoundItem, DataRowView).Row
            ' checking for balance
            With dgvRow.DefaultCellStyle
                If (dbRow.InvoiceBalance > 0) Then
                    ' checking if its past due
                    If (dbRow.InvoiceDueDate <= Date.Now.Date) Then
                        ' due date has passed
                        If (dbRow.InvoiceBalance > 0) Then
                            ' inv has balance and is past due
                            .BackColor = AppColors.GridRed
                            .SelectionBackColor = AppColors.GridRedSel
                            ' change selected color to white
                            .SelectionForeColor = AppColors.GridDefTextSel
                        End If
                    Else
                        ' due date HAS not passed
                        If (dbRow.InvoiceBalance <> dbRow.InvoiceTotal) Then
                            ' invoice is partially paid
                            .BackColor = AppColors.GridYellow
                            .SelectionBackColor = AppColors.GridYellowSel
                            ' change selected color to black
                            .SelectionForeColor = AppColors.GridDefText
                        End If
                    End If
                Else
                    ' balance is 0
                    .BackColor = AppColors.GridGreen
                    .SelectionBackColor = AppColors.GridGreenSel
                    ' change selected color to white
                    .SelectionForeColor = AppColors.GridDefTextSel
                End If
            End With
             
        End Sub

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            _invRetEle = New List(Of String)
            _payRetEle = New List(Of String)
            ' limiting response for invoice query
            With _invRetEle
                .Add("RefNumber")
                .Add("TxnDate")
                .Add("TimeCreated")
                .Add("Subtotal")
                .Add("BalanceRemaining")
                .Add("DueDate")
                .Add("Other")
                .Add("OR")
            End With
            ' limiting response for pay query
            With _payRetEle
                .Add("TxnDate")
                .Add("TotalAmount")
                .Add("RefNumber")
                .Add("PaymentMethodRef")
            End With
        End Sub

        Private Sub btn_ViewAllInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewAllInv.Click
            ' 0 is all
            FetchInvoices(0)
            tc_Quickbooks.SelectedIndex = 0
        End Sub

        Private Sub btn_ViewAllOpenInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewUnpaidInv.Click
            ' 2 is not paid only
            FetchInvoices(2)
            tc_Quickbooks.SelectedIndex = 0
        End Sub

        Private Sub btn_ViewPayments_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewPayments.Click
            If (Now > _lastFetchTime.AddMinutes(1)) Then
                FetchPayments()
            End If
            tc_Quickbooks.SelectedIndex = 1
        End Sub

        Private Sub dg_Invoices_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg_Invoices.RowPrePaint
            ColorRows_QBInvoices(dg_Invoices.Rows(e.RowIndex))
        End Sub

        Private Sub UC_Quickbooks_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        End Sub

        Private Sub btn_ViewInvDetail_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewInvDetail.Click
            If (dg_Invoices.SelectedRows.Count = 1) Then
                Dim recurringServiceID As Integer = 0
                Dim row As ds_Display.QB_InvoiceDisplayRow = CType(dg_Invoices.SelectedRows(0).DataBoundItem, DataRowView).Row
                If (Not row.IsLineItemIDNull) Then
                    Using ta As New ds_RecurringServiceTableAdapters.RecurringService_BillHistoryTableAdapter
                        recurringServiceID = ta.GetRecurringIDFromLineItemID(CType(CType(dg_Invoices.SelectedRows(0).DataBoundItem, DataRowView).Row, ds_Display.QB_InvoiceDisplayRow).LineItemID)
                    End Using
                ElseIf (row.CustomInvoice) Then
                    InvoicingForm = New Invoicing.CustomInvoicingForm(CurrentCustomer, historyFocus:=True)
                    InvoicingForm.ShowDialog()
                End If

                If (recurringServiceID <> 0) Then
                    Dim recurringForm As New RecurringService.RecurringServiceForm(CustomerName, CurrentCustomer, recurringServiceID)
                    recurringForm.ShowDialog()
                    ' get what has updated and refresh controls
                    If (recurringForm.BalanceChanged) Then
                        RaiseEvent BalanceChanged(CurrentCustomer)
                    End If
                    If (recurringForm.ServiceUpdated) Then
                        RaiseEvent ServiceUpdated(CurrentCustomer)
                    End If
                End If

            End If
        End Sub

        Private Sub InvoiceAddHandle(ByVal customerNumber As Integer) Handles InvoicingForm.CustomerInvoiceAdded
            RaiseEvent BalanceChanged(customerNumber)
        End Sub

    End Class
End Namespace