﻿
Namespace Admin.Payments
    Public Class AdminPayments

        ' move payment form ref
        Friend WithEvents MovePaymentForm As MovePaymentForm

        ' property to keep last selected customer
        Private _currentCustomer As Integer
        Public Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                If (_currentCustomer <> value) Then
                    _currentCustomer = value
                    Fetch_History()
                End If
            End Set
        End Property
        ' property to keep selected payment method
        Private _paymentType As Integer
        Public Property PaymentType
            Get
                Return _paymentType
            End Get
            Set(value)
                _paymentType = value

                ' set dv filter
                If (value <> 0) Then
                    Dim s As String = "PaymentTypeID = " & value
                    _dv.RowFilter = s
                Else
                    _dv.RowFilter = ""
                End If

                ' if check type then color rows for bounced
                If (value = 2) Then
                    ColorRows()
                End If
            End Set
        End Property

        ' dataview
        Private _dv As DataView

        Private Sub ck_All_Click(sender As System.Object, e As System.EventArgs) Handles ck_All.CheckedChanged
            If (ck_All.Checked = True) Then
                ' disable payment types combo box
                cmb_PayTypes.Enabled = False
                ' reset payment type
                PaymentType = 0
            Else
                ' enable payment types combo box
                cmb_PayTypes.Enabled = True
                ' reset paymenttype
                PaymentType = cmb_PayTypes.SelectedValue
            End If
        End Sub

        Private Sub AdminPayments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub PaymentHistory_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            PaymentTypesTableAdapter.Fill(Ds_Types.PaymentTypes)
            ' new stuff
            _dv = New DataView
            _dv.Table = Payments.PaymentHistory_Display
            _dv.Sort = "DateReceived DESC"
            dg_PaymentHistory.DataSource = _dv
            
            ' set date time picker values
            dtp_StartDate.Value = DateAdd(DateInterval.Day, -1, Date.Today)
            dtp_EndDate.Value = DateAdd(DateInterval.Month, 1, Date.Today)

            ' set payment type
            ck_All.Checked = True

            ' setting initial customer to screen isnt blank
            CurrentCustomer = CustomerToolstrip1.CurrentCustomer
            CustomerToolstrip1.GetCustomerBalance()
        End Sub

        Private Sub CustomerCatch(ByVal customerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
            CurrentCustomer = customerNumber
            CustomerToolstrip1.GetCustomerBalance()
        End Sub

        Public Sub Fetch_History() Handles dtp_EndDate.ValueChanged, dtp_StartDate.ValueChanged
            If (CurrentCustomer > 0) Then
                ' making sure we have a customer
                Try
                    PaymentHistory_DisplayTableAdapter.Fill(Payments.PaymentHistory_Display, CurrentCustomer, dtp_StartDate.Value.Date, dtp_EndDate.Value.Date)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Sub

        Private Sub ColorRows()
            Dim grid As DataGridView = dg_PaymentHistory
            ' loop through rows
            For i As Integer = 0 To grid.RowCount - 1
                ' easier refrence
                Dim row As DataRowView = grid.Rows(i).DataBoundItem
                ' checking if bounced
                If (CBool(row.Item("Bounced")) = True) Then
                    grid.Rows(i).DefaultCellStyle.BackColor = AppColors.GridRed
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridRedSel
                End If
            Next
        End Sub

        Private Sub cm_i_BouncedCheck_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_BounceCheck.Click
            If (dg_PaymentHistory.SelectedRows.Count = 1) Then
                ' easier refrence
                Dim row As ds_Payments.PaymentHistory_DisplayRow = CType(dg_PaymentHistory.SelectedRows(0).DataBoundItem, DataRowView).Row
                If (row.PaymentTypeID = 2) Then
                    If (Not row.Bounced) Then
                        Dim bounceForm As New BouncedBankSelection(row.PaymentID)
                        bounceForm.ShowDialog()
                        Fetch_History()
                    Else
                        MsgBox("Check has already been set to bounced.")
                    End If
                Else
                    MsgBox("Selected Payment is not a Check.")
                End If
            Else
                MsgBox("Please select a Payment")
            End If
        End Sub

        Private Sub Cmb_PaymentTypes_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmb_PayTypes.SelectionChangeCommitted
            If (PaymentType <> sender.SelectedValue) Then
                PaymentType = sender.SelectedValue
            End If
        End Sub

        Private Sub cm_i_MovePayment_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_MovePayment.Click
            If (dg_PaymentHistory.SelectedRows.Count = 1) Then
                ' easier refrence
                Dim row As ds_Payments.PaymentHistory_DisplayRow = CType(dg_PaymentHistory.SelectedRows(0).DataBoundItem, DataRowView).Row
                ' result ref
                Dim result As DialogResult
                If (Not row.Bounced) Then
                    ' check if payment crosses year boundaries
                    If (row.DateReceived.Year = Date.Now.Year) Then
                        If (DateDiff(DateInterval.Day, row.DateReceived, Date.Now) < 90) Then
                            result = Windows.Forms.DialogResult.Yes
                        Else
                            result = MessageBox.Show("This Payment was receieved " & DateDiff(DateInterval.Day, row.DateReceived, Date.Now) & " days ago. Are you sure you want to move this payment?", "Targeted Pay > 90 Days ago", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        result = MessageBox.Show("This Payment was receieved in a different year than the current year. Are you sure you want to move this payment?", "Targeted Pay Outside Current Year", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("This payment has been marked as a bounced check.", "Unable to Move Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                If (result = Windows.Forms.DialogResult.Yes) Then
                    ' create move payment form
                    MovePaymentForm = New MovePaymentForm(row.PaymentID)
                    MovePaymentForm.ShowDialog()
                End If

            End If
        End Sub

        Private Sub PaymentMoveCompleted() Handles MovePaymentForm.PaymentMoveComplete
            Fetch_History()
        End Sub
    End Class
End Namespace