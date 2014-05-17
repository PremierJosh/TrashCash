Imports QBFC12Lib
Imports System
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class UC_Quickbooks
    Implements INotifyPropertyChanged

    ' home form ref property
    Private _home As TrashCash_Home
    Friend Property _HomeForm As TrashCash_Home
        Get
            Return _home
        End Get
        Set(value As TrashCash_Home)
            _home = value
        End Set
    End Property

    ' events
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private paidStatus As ENPaidStatus

    ' fetch possible property
    Private fetchPoss As Boolean
    Public Property FetchPossible As Boolean
        Get
            Return fetchPoss
        End Get
        Set(value As Boolean)
            If (fetchPoss <> value) Then
                fetchPoss = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(""))

                ' unchedk all radio btns if value = false
                If (value = False) Then
                    rdo_All.Checked = False
                    rdo_Balance.Checked = False
                    rdo_Paid.Checked = False
                End If
            End If
        End Set
    End Property

    ' custListID property
    Private custListID As String
    Public Property CustomerListID As String
        Get
            Return custListID
        End Get
        Set(value As String)
            If (custListID <> value) Then
                custListID = value

                ' fill with open invoices and all payments
                _HomeForm.Queries.Invoice_ForDisplay(ENPaidStatus.psNotPaidOnly, Me.Ds_Display.QB_InvoiceDisplay, custListID:=value)
                _HomeForm.Queries.Payments_ForDisplay(Me.Ds_Display.QB_PaymentsDisplay, custListID:=value)

                ' color invoice rows based on due date
                ColorRows_QBInvoices(dg_QBInvoices)
            End If
        End Set
    End Property

    ' property refrence
    Private custNum As Decimal
    ' properties
    Public Property CurrentCustomer As Decimal
        Get
            Return custNum
        End Get
        Set(ByVal value As Decimal)
            If (custNum <> value) Then
                ' refrence
                custNum = value

                'clear dts
                Me.Ds_Display.Clear()
            End If
        End Set
    End Property


    Private Sub UC_Billing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' bind fetch button to form property
        btn_QBFetch.DataBindings.Add("Enabled", Me, "FetchPossible")
    End Sub

    Private Sub FetchInvoices()
        If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
            _HomeForm.Queries.Invoice_ForDisplay(paidStatus, Me.Ds_Display.QB_InvoiceDisplay, custListID:=custListID, toDate:=dtp_ItemTo.Value.Date)
        ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
            _HomeForm.Queries.Invoice_ForDisplay(paidStatus, Me.Ds_Display.QB_InvoiceDisplay, custListID:=custListID, fromDate:=dtp_ItemFrom.Value.Date)
        ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
            _HomeForm.Queries.Invoice_ForDisplay(paidStatus, Me.Ds_Display.QB_InvoiceDisplay, custListID:=custListID, toDate:=dtp_ItemTo.Value.Date, fromDate:=dtp_ItemFrom.Value.Date)
        Else
            _HomeForm.Queries.Invoice_ForDisplay(paidStatus, Me.Ds_Display.QB_InvoiceDisplay, custListID:=custListID)
        End If

        ' color rows based on due date
        ColorRows_QBInvoices(dg_QBInvoices)
    End Sub

    Private Sub FetchPayments()
        If (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = False) Then
            _HomeForm.Queries.Payments_ForDisplay(Me.Ds_Display.QB_PaymentsDisplay, custListID:=custListID, toDate:=dtp_ItemTo.Value.Date)
        ElseIf (chk_ItemTo.Checked = False And chk_ItemFrom.Checked = True) Then
            _HomeForm.Queries.Payments_ForDisplay(Me.Ds_Display.QB_PaymentsDisplay, custListID:=custListID, fromDate:=dtp_ItemFrom.Value.Date)
        ElseIf (chk_ItemTo.Checked = True And chk_ItemFrom.Checked = True) Then
            _HomeForm.Queries.Payments_ForDisplay(Me.Ds_Display.QB_PaymentsDisplay, custListID:=custListID, fromDate:=dtp_ItemFrom.Value.Date, toDate:=dtp_ItemTo.Value.Date)
        Else
            _HomeForm.Queries.Payments_ForDisplay(Me.Ds_Display.QB_PaymentsDisplay, custListID:=custListID)
        End If
    End Sub

    Private Sub tc_Quickbooks_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tc_Quickbooks.SelectedIndexChanged
        ' index 0 = invoices, index 1 = payments
        If (tc_Quickbooks.SelectedIndex = 0) Then
            grp_InvStatus.Enabled = True
            ' uncheck all rdo buttons and disable fetching
            FetchPossible = False
        Else
            grp_InvStatus.Enabled = False
            ' uncheck all rdo buttons and disable fetching
            FetchPossible = True
        End If
    End Sub

    Private Sub rdo_All_Click(sender As System.Object, e As System.EventArgs) Handles rdo_All.Click, rdo_Balance.Click, rdo_Paid.Click
        If (rdo_Paid.Checked = True) Then
            paidStatus = ENPaidStatus.psPaidOnly
            FetchPossible = True
        ElseIf (rdo_Balance.Checked = True) Then
            paidStatus = ENPaidStatus.psNotPaidOnly
            FetchPossible = True
        ElseIf (rdo_All.Checked = True) Then
            paidStatus = ENPaidStatus.psAll
            FetchPossible = True
        End If
    End Sub

    Private Sub btn_QBFetch_Click(sender As System.Object, e As System.EventArgs) Handles btn_QBFetch.Click
        If (tc_Quickbooks.SelectedIndex = 0) Then
            FetchInvoices()
        Else
            FetchPayments()
        End If

        ' reset fetching
        FetchPossible = False
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

    Private Sub dtp_ItemFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtp_ItemFrom.ValueChanged, dtp_ItemTo.ValueChanged
        If (tc_Quickbooks.SelectedIndex = 0) Then
            ' looking at invoices, need to make sure a status type is checked
            If ((rdo_All.Checked = True) Or (rdo_Balance.Checked = True) Or (rdo_Paid.Checked = True)) Then
                FetchPossible = True
            Else
                FetchPossible = False
            End If
        Else
            FetchPossible = True
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
                If (dbRow.InvoiceBalance > 0) Then
                    ' checking if its past due
                    If (dbRow.InvoiceDueDate <= Date.Now.Date) Then
                        ' due date has passed
                        If (dbRow.InvoiceBalance > 0) Then
                            ' inv has balance and is past due
                            grid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
                        End If
                    Else
                        ' due date HAS not passed
                        If (dbRow.InvoiceBalance <> dbRow.InvoiceTotal) Then
                            ' invoice is partially paid
                            grid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                            grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
                        End If
                    End If
                Else
                    ' balance is 0
                    grid.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
                End If
            End If
        Next i
    End Sub

    Private Sub btn_ViewAllOpenInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_ViewAllOpenInv.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to view all currently Unpaid invoices in Quickbooks? This could might take a few minutes if there are a lot of invoices.", MsgBoxStyle.YesNo)
        If (result = MsgBoxResult.Yes) Then
            _HomeForm.Queries.Invoice_ForDisplay(ENPaidStatus.psNotPaidOnly, Me.Ds_Display.QB_InvoiceDisplay)
            FetchPossible = False
        End If
    End Sub
End Class
