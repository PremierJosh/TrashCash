Public Class MovePayment
    ' home form ref var
    Private HomeForm As TrashCash_Home

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
    Private _payID As Integer
    Private WriteOnly Property PaymentID As Integer
        Set(value As Integer)
            _payID = value

            ' getting db row
            Using ta As New ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter
                PaymentHistoryRow = ta.GetData(value).Rows(0)
            End Using
        End Set
    End Property


    Public Sub New(ByRef _HomeForm As TrashCash_Home, ByVal _PaymentID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HomeForm = _HomeForm

        ' fill customer list table
        Me.Customer_ListByActiveTableAdapter.Fill(Me.Ds_Customer.Customer_ListByActive, False)

        ' set various vars qb will need in mod request
        PaymentID = _PaymentID
    End Sub

    Private Sub btn_MovePay_Click(sender As System.Object, e As System.EventArgs) Handles btn_MovePay.Click
        If (cmb_MoveToCust.SelectedValue <> cmb_CurrCustomer.SelectedValue) Then
            ' prompting to confirm move
            Dim result As DialogResult = MessageBox.Show("Move payment for " & FormatCurrency(PaymentHistoryRow.Amount) & ", receieved on " & FormatDateTime(PaymentHistoryRow.DateReceived, DateFormat.GeneralDate) & " for " & _
                                                         "Customer: " & cmb_CurrCustomer.GetItemText(cmb_CurrCustomer.SelectedItem) & " to Customer: " & cmb_MoveToCust.GetItemText(cmb_MoveToCust.SelectedItem) & "?", "Confirm moving payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If (result = Windows.Forms.DialogResult.Yes) Then
                HomeForm.Procedures.Payment_MoveToCustomer(PaymentHistoryRow, cmb_MoveToCust.SelectedValue)
            End If
        Else
            ' same customer selected both times
            MessageBox.Show("Payment already on that Customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class