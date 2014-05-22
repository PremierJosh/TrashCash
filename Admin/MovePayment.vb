Imports TrashCash.ds_PaymentsTableAdapters

Namespace Admin
    Public Class MovePayment
        ' home form ref var
        Private ReadOnly _homeForm As TrashCashHome

        ' event to let pay history form refresh
        Friend Event PaymentMoveComplete()

        ' var for actual pay history row
        Private _payHisRow As ds_Payments.PaymentHistory_DBRow
        Private Property PaymentHistoryRow As ds_Payments.PaymentHistory_DBRow
            Get
                Return _payHisRow
            End Get
            Set(value As ds_Payments.PaymentHistory_DBRow)
                _payHisRow = value

                ' update controls on form
                cmb_CurrCustomer.SelectedValue = value.CustomerNumber
                tb_Amount.Text = FormatCurrency(value.Amount)
                dtp_RecDateTime.Value = value.DateReceived
                lbl_InputBy.Text = "Input By: " & value.InsertedByUser

                ' checking if its cash - if not set controls and make visible
                If (value.PaymentTypeID <> 1) Then
                    tb_RefNum.Text = value.RefNumber
                    dtp_DateOnChk.Value = value.DateOnCheck

                    ' making controls visible
                    lbl_RefNum.Visible = True
                    lbl_DateOnCk.Visible = True
                    tb_RefNum.Visible = True
                    dtp_DateOnChk.Visible = True
                End If

            End Set
        End Property

        ' pay his row ref
        Private WriteOnly Property PaymentID As Integer
            Set(value As Integer)
                ' getting db row
                Using ta As New PaymentHistory_DBTableAdapter
                    PaymentHistoryRow = ta.GetData(value).Rows(0)
                End Using
            End Set
        End Property


        Public Sub New(ByRef homeForm As TrashCashHome, ByVal paymentID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _homeForm = homeForm

            ' fill customer list table
            Customer_ListByActiveTableAdapter.Fill(Ds_Customer.Customer_ListByActive, False)

            ' set various vars qb will need in mod request
            Me.PaymentID = paymentID
        End Sub

        Private Sub btn_MovePay_Click(sender As Object, e As EventArgs) Handles btn_MovePay.Click
            If (cmb_MoveToCust.SelectedValue <> cmb_CurrCustomer.SelectedValue) Then
                ' prompting to confirm move
                Dim result As DialogResult = MessageBox.Show("Move payment for " & FormatCurrency(PaymentHistoryRow.Amount) & ", receieved on " & FormatDateTime(PaymentHistoryRow.DateReceived, DateFormat.GeneralDate) & " for " & _
                                                             "Customer: " & cmb_CurrCustomer.GetItemText(cmb_CurrCustomer.SelectedItem) & vbCrLf & "To Customer: " & cmb_MoveToCust.GetItemText(cmb_MoveToCust.SelectedItem) & "?", "Confirm moving payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If (result = DialogResult.Yes) Then
                    Try
                        _homeForm.Procedures.Payment_MoveToCustomer(PaymentHistoryRow, cmb_MoveToCust.SelectedValue)
                        MessageBox.Show("Payment Move Complete", "Payment Move Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RaiseEvent PaymentMoveComplete()
                        Close()
                    Catch ex As Exception
                        MessageBox.Show("Error Moving Payment. Contact Premier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                ' same customer selected both times
                MessageBox.Show("Payment already on that Customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub
    End Class
End Namespace