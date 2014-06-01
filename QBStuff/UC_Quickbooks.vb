Imports TrashCash.Classes
Imports QBFC12Lib

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
                    FetchInvoices(ENPaidStatus.psAll)
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
                    Ds_Display.Clear()
                End If
            End Set
        End Property


        Private Sub UC_Billing_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        End Sub

        Private Sub FetchInvoices(ByVal paidStatus As ENPaidStatus)
            Dim resp As IResponse
            If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
                resp = QBRequests.InvoiceQuery(listID:=CustomerListID, paidStatus:=paidStatus, toDate:=dtp_ItemTo.Value.Date, retEleList:=_invRetEle)
            ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.InvoiceQuery(listID:=CustomerListID, paidStatus:=paidStatus, fromDate:=dtp_ItemFrom.Value.Date, retEleList:=_invRetEle)
            ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.InvoiceQuery(listID:=CustomerListID, paidStatus:=paidStatus, fromDate:=dtp_ItemFrom.Value.Date, toDate:=dtp_ItemTo.Value.Date, retEleList:=_invRetEle)
            Else
                resp = QBRequests.InvoiceQuery(listID:=CustomerListID, paidStatus:=paidStatus, retEleList:=_invRetEle)
            End If

            If (resp.StatusCode = 0) Then
                Dim invRetList As IInvoiceRetList = resp.Detail
                ' looping through invoice ret list
                For i = 0 To invRetList.Count - 1
                    Dim invRet As IInvoiceRet = invRetList.GetAt(i)
                    ' building new row
                    Dim newRow As ds_Display.QB_InvoiceDisplayRow = Ds_Display.QB_InvoiceDisplay.NewQB_InvoiceDisplayRow
                    With newRow
                        .InvoiceNumber = invRet.RefNumber.GetValue
                        .InvoicePostDate = invRet.TxnDate.GetValue.Date
                        .InvoiceCreationDate = invRet.TimeCreated.GetValue.Date
                        .CustomerName = invRet.CustomerRef.FullName.GetValue
                        .InvoiceTotal = invRet.Subtotal.GetValue
                        .InvoiceBalance = invRet.BalanceRemaining.GetValue
                        .InvoiceDueDate = invRet.DueDate.GetValue.Date
                    End With
                    ' adding
                    Ds_Display.QB_InvoiceDisplay.AddQB_InvoiceDisplayRow(newRow)
                Next i
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            ' color rows based on due date
            ColorRows_QBInvoices(dg_QBInvoices)
        End Sub

        Private Sub FetchPayments()
            Dim resp As IResponse
            If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
                resp = QBRequests.PaymentQuery(listID:=CustomerListID, toDate:=dtp_ItemTo.Value.Date, retEleList:=_payRetEle)
            ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.PaymentQuery(listID:=CustomerListID, fromDate:=dtp_ItemFrom.Value.Date, retEleList:=_payRetEle)
            ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
                resp = QBRequests.PaymentQuery(listID:=CustomerListID, fromDate:=dtp_ItemFrom.Value.Date, toDate:=dtp_ItemTo.Value.Date, retEleList:=_payRetEle)
            Else
                resp = QBRequests.PaymentQuery(listID:=CustomerListID, retEleList:=_payRetEle)
            End If

            If (resp.StatusCode = 0) Then
                Dim paymentRetList As IReceivePaymentRetList = resp.Detail
                For i = 0 To paymentRetList.Count - 1
                    Dim paymentRet As IReceivePaymentRet = paymentRetList.GetAt(i)
                    ' building new paymentList row
                    Dim newRow As ds_Display.QB_PaymentsDisplayRow = Ds_Display.QB_PaymentsDisplay.NewQB_PaymentsDisplayRow
                    With newRow
                        .PaymentTxnNumber = paymentRet.TxnNumber.GetValue
                        .PaymentDate = paymentRet.TxnDate.GetValue
                        .PaymentAmount = paymentRet.TotalAmount.GetValue
                        .PaymentMethod = paymentRet.PaymentMethodRef.FullName.GetValue
                        If (paymentRet.RefNumber IsNot Nothing) Then
                            .PaymentCheckNum = paymentRet.RefNumber.GetValue
                        End If
                    End With
                    ' adding
                    Ds_Display.QB_PaymentsDisplay.AddQB_PaymentsDisplayRow(newRow)
                Next i
            ElseIf (resp.StatusCode > 1) Then
                QBMethods.ResponseErr_Misc(resp)
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
            FetchInvoices(ENPaidStatus.psAll)
            tc_Quickbooks.SelectedIndex = 0
        End Sub

        Private Sub btn_ViewAllOpenInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewUnpaidInv.Click
            FetchInvoices(ENPaidStatus.psNotPaidOnly)
            tc_Quickbooks.SelectedIndex = 0
        End Sub

        Private Sub btn_ViewPayments_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewPayments.Click
            If (Now > _lastFetchTime.AddMinutes(1)) Then
                FetchPayments()
            End If
            tc_Quickbooks.SelectedIndex = 1
        End Sub

        'Private Sub tc_Quickbooks_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tc_Quickbooks.SelectedIndexChanged
        '    'If (tc_Quickbooks.SelectedIndex = 0) Then
        '    '    ' invoices tab
        '    'Else
        '    '    ' payments tab
        '    'End If
        'End Sub
    End Class
End Namespace