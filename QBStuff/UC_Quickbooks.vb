Imports TrashCash._DataSets

Namespace QBStuff

    Public Class UC_Quickbooks
     
        ' list of retEles for queries
        Private ReadOnly _invRetEle As List(Of String)
        Private ReadOnly _payRetEle As List(Of String)

        ' these will limit excessive payment fetching
        Private _lastFetchTime As DateTime

        ' custListID property
        Private _custListID As String
        Public Property CustomerListID As String
            Get
                Return _custListID
            End Get
            Set(value As String)
                If (_custListID <> value) Then
                    _custListID = value

                    ' fill with open invoices and all payments
                    FetchInvoices(0)
                    FetchPayments()
                End If
            End Set
        End Property

        ' property refrence
        Private _currentCustomer As Decimal
        ' properties
        Public Property CurrentCustomer As Decimal
            Get
                Return _currentCustomer
            End Get
            Set(ByVal value As Decimal)
                If (_currentCustomer <> value) Then
                    ' refrence
                    _currentCustomer = value
                    'clear dts
                    Display.Clear()
                End If
            End Set
        End Property

        Private Sub FetchInvoices(ByVal paidStatus As Integer)
            Dim resp As Integer
            Dim invObjList As New List(Of QBInvoiceObj)
            If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, toDate:=dtp_ItemTo.Value.Date, retEleList:=_invRetEle)
            ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, fromDate:=dtp_ItemFrom.Value.Date, retEleList:=_invRetEle)
            ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, fromDate:=dtp_ItemFrom.Value.Date, toDate:=dtp_ItemTo.Value.Date, retEleList:=_invRetEle)
            Else
                resp = QBRequests.InvoiceQuery(invObjList, customerListID:=CustomerListID, paidStatus:=paidStatus, retEleList:=_invRetEle)
            End If

            If (resp = 0) Then
                ' looping through invoices to build display rows
                For Each inv As QBInvoiceObj In invObjList
                    ' building new row
                    Dim newRow As ds_Display.QB_InvoiceDisplayRow = Display.QB_InvoiceDisplay.NewQB_InvoiceDisplayRow
                    With newRow
                        .InvoiceRefNumber = inv.RefNumber
                        .InvoicePostDate = inv.TxnDate
                        .InvoiceCreationDate = inv.TimeCreated
                        .CustomerName = inv.CustomerFullName
                        .InvoiceTotal = inv.Subtotal
                        .InvoiceBalance = inv.BalanceRemaining
                        .InvoiceDueDate = inv.DueDate
                    End With
                    ' adding
                    Display.QB_InvoiceDisplay.AddQB_InvoiceDisplayRow(newRow)
                Next
            End If
        End Sub

        Private Sub FetchPayments()
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
                    Dim newRow As DS_Display.QB_PaymentsDisplayRow = Display.QB_PaymentsDisplay.NewQB_PaymentsDisplayRow
                    With newRow
                        .PaymentDate = pay.TxnDate
                        .PaymentAmount = pay.TotalAmount
                        .PaymentMethod = pay.PayTypeName
                        If (pay.RefNumber IsNot Nothing) Then
                            .PaymentCheckNum = pay.RefNumber
                        End If
                    End With
                    ' adding
                    Display.QB_PaymentsDisplay.AddQB_PaymentsDisplayRow(newRow)
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

        Private Sub ColorRows_QBInvoices(ByRef grid As DataGridView)
            ' loop through all grid rows
            For i As Integer = 0 To grid.RowCount - 1
                Dim row As DataRowView = grid.Rows(i).DataBoundItem
                If (row IsNot Nothing) Then
                    ' easier to refrence here
                    Dim dbRow As ds_Display.QB_InvoiceDisplayRow = row.Row
                    ' checking for balance
                    With grid.Rows(i).DefaultCellStyle
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
                End If
            Next i
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
                .Add("CustomerRef")
                .Add("Subtotal")
                .Add("BalanceRemaining")
                .Add("DueDate")
            End With
            ' limiting response for pay query
            With _payRetEle
                .Add("TxnNumber")
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

        Private Sub dg_QBInvoices_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg_QBInvoices.RowPrePaint
            ColorRows_QBInvoices(dg_QBInvoices)
        End Sub
    End Class
End Namespace