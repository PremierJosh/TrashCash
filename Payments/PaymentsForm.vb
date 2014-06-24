Namespace Payments
    Public Class PaymentsForm
        ' field to update if item added to queue
        Friend PaymentAdded As Boolean
        ' events for home form notification
        Friend Event CustomerPaymentAdded(ByVal customerNumber As Integer)
        
        Private _currentCustomer As Integer
        Public Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                If (_currentCustomer <> value) Then
                    _currentCustomer = value
                    ' do stuff when cust changes here
                    UC_CustomerNotes.CurrentCustomer = value
                    UC_CustomerInfoBoxes.CurrentCustomer = value
                    ' update window title text
                    Text = CustomerToolstrip1.ToString
                End If
            End Set
        End Property

        Private Sub CustomerToolstrip1_CustomerChanging(customerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
            CurrentCustomer = customerNumber
        End Sub

        Private ReadOnly _debug As Boolean
        Private Sub ResetPayment()
            ' reset tbs on form
            tb_Amount.Text = String.Empty
            tb_RefNum.Text = String.Empty
            tb_RefNum.Visible = False
            lbl_RefNumber.Visible = False

            ' reset date on check value
            dtp_DateOnCheck.Value = Date.Now
            dtp_DateOnCheck.Visible = False
            lbl_DateOnCheck.Visible = False

            ' reseting payment type selection to first option
            cmb_PayTypes.SelectedIndex = 0
            tb_Amount.Select()

            ' checking if in debug mode
            If (_debug) Then
                ck_Override.Checked = False
                dtp_Override.Visible = False
                dtp_Override.Value = Date.Now
            End If
        End Sub

        ' if customer number is passed at new, this is locked form and should be disposed when closed
        Private ReadOnly _dispose As Boolean

        Public Sub New(ByRef debug As Boolean, Optional ByVal customerNumber As Integer = 0)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _debug = debug

            ' if number is passed, lock ts
            If (customerNumber <> 0) Then
                CustomerToolstrip1.Enabled = False
                CustomerToolstrip1.HideQuickSearch()
                CurrentCustomer = customerNumber
                CustomerToolstrip1.SelectCustomer(customerNumber)
                ' mark for disposal at close
                _dispose = True
            Else
                CurrentCustomer = CustomerToolstrip1.CurrentCustomer
                CustomerToolstrip1.GetCustomerBalance()
                ' keep open after
                _dispose = False
            End If
        End Sub

        Private Sub Payments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            ' stop closing and hide form
            If (Not _dispose) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub Payments_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            BATCH_WorkingPaymentsTableAdapter.Fill(Ds_Batching.BATCH_WorkingPayments)
            PaymentTypesTableAdapter.Fill(Ds_Types.PaymentTypes)
            ' setting uc info boxes to display only
            UC_CustomerInfoBoxes.AllowUpdate = False
        End Sub

        Private Sub cmb_PayTypes_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmb_PayTypes.SelectedValueChanged
            If (cmb_PayTypes.SelectedValue = 1) Then
                ' ref number
                tb_RefNum.Visible = False
                lbl_RefNumber.Visible = False
                ' date on check
                dtp_DateOnCheck.Visible = False
                lbl_DateOnCheck.Visible = False
            Else
                ' ref number
                tb_RefNum.Visible = True
                lbl_RefNumber.Visible = True
                ' date on check
                dtp_DateOnCheck.Visible = True
                lbl_DateOnCheck.Visible = True
            End If
        End Sub
        Private Function OkToCommit()
            If (Trim(tb_Amount.Text) <> "") Then
                tb_Amount.BackColor = AppColors.TextBoxDef
                If (cmb_PayTypes.SelectedValue <> 1) Then
                    If (Trim(tb_RefNum.Text) = "") Then
                        tb_RefNum.BackColor = AppColors.TextBoxErr
                        Return False
                    Else
                        tb_RefNum.BackColor = AppColors.TextBoxDef
                        Return True
                    End If
                Else
                    Return True
                End If
            Else
                tb_Amount.BackColor = AppColors.TextBoxErr
                Return False
            End If
        End Function

        Private Sub btn_AddPayment_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddPayment.Click
            If (OkToCommit()) Then
                ' remove all spaces from begining and end
                Dim checkRefNum As String = Trim(tb_RefNum.Text)
                ' replace all zeros by spaces, and then, left-trim that result, ie, remove starting spaces. 
                'The external Replace replaces the spaces left in the string to their initial 0 character.
                Replace(LTrim(Replace(checkRefNum, "0", " ")), " ", "0")

                Try
                    ' checking if override checked
                    If (ck_Override.Checked) Then
                        ' inserting override date chosen as time inserted
                        ' insert with current time and check if dateoncheck is nothing (cash payment)
                        If (cmb_PayTypes.SelectedValue = 1) Then
                            BATCH_WorkingPaymentsTableAdapter.WorkingPayments_Insert_ReturnID(CurrentCustomer, tb_Amount.Text, cmb_PayTypes.SelectedValue, Nothing,
                            TC_ENItemStatus.Ready, dtp_Override.Value.Date, Nothing, CurrentUser.USER_NAME)
                        Else
                            BATCH_WorkingPaymentsTableAdapter.WorkingPayments_Insert_ReturnID(CurrentCustomer, tb_Amount.Text, cmb_PayTypes.SelectedValue, checkRefNum,
                              TC_ENItemStatus.Ready, dtp_Override.Value.Date, dtp_DateOnCheck.Value.Date, CurrentUser.USER_NAME)
                        End If
                    Else
                        ' insert with current time and check if dateoncheck is nothing (cash payment)
                        If (cmb_PayTypes.SelectedValue = 1) Then
                            BATCH_WorkingPaymentsTableAdapter.WorkingPayments_Insert_ReturnID(CurrentCustomer, tb_Amount.Text, cmb_PayTypes.SelectedValue, Nothing,
                             TC_ENItemStatus.Ready, Date.Now, Nothing, CurrentUser.USER_NAME)
                        Else
                            BATCH_WorkingPaymentsTableAdapter.WorkingPayments_Insert_ReturnID(CurrentCustomer, tb_Amount.Text, cmb_PayTypes.SelectedValue, checkRefNum,
                             TC_ENItemStatus.Ready, Date.Now, dtp_DateOnCheck.Value.Date, CurrentUser.USER_NAME)
                        End If
                    End If
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                RaiseEvent CustomerPaymentAdded(CurrentCustomer)
                ResetPayment()
                ' fill table
                BATCH_WorkingPaymentsTableAdapter.Fill(Ds_Batching.BATCH_WorkingPayments)
            Else
                MessageBox.Show("Please correct the required fields.", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btn_DeletePay_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeletePay.Click
            ' making sure only 1 row is selected
            If (dg_PrepPay.SelectedRows.Count = 1) Then
                Dim row As ds_Batching.BATCH_WorkingPaymentsRow = CType(dg_PrepPay.SelectedRows(0).DataBoundItem, DataRowView).Row
                Try
                    BATCH_WorkingPaymentsTableAdapter.DeleteByID(row.WorkingPaymentsID)
                Catch ex as SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub
    End Class
End Namespace