﻿Namespace Admin

    Public Class BouncedBankSelection
        ' home form refrence
        Private ReadOnly _home As TrashCashHome

        ' passing id from pay history table
        Private _payHistoryId As Integer

        Public Property PayHistoryId As Integer
            Get
                Return _payHistoryId
            End Get
            Set(value As Integer)
                If (value > 0) Then
                    _payHistoryId = value
                    ' query for row and set refrence
                    Dim ta As New ds_PaymentsTableAdapters.PaymentHistory_DBTableAdapter
                    CheckRow = ta.GetData(value).Rows(0)
                End If
            End Set
        End Property

        Private _checkRow As ds_Payments.PaymentHistory_DBRow

        Private Property CheckRow As ds_Payments.PaymentHistory_DBRow
            Get
                Return _checkRow
            End Get
            Set(value As ds_Payments.PaymentHistory_DBRow)
                _checkRow = value

                ' set check amount and check ref number
                tb_RefNum.Text = value.RefNumber
                tb_CheckAmount.Text = FormatCurrency(value.Amount)
                ' set ts cmb and get balance
                'Ts_M_Customer1.CurrentCustomer = value.CustomerNumber
            End Set
        End Property

        Private _bankRow As ds_Payments.BAD_CHECK_BANKSRow

        Private Property BankRow As ds_Payments.BAD_CHECK_BANKSRow
            Get
                Return _bankRow
            End Get
            Set(value As ds_Payments.BAD_CHECK_BANKSRow)
                _bankRow = value

                ' set fee
                tb_BankFee.Text = FormatCurrency(value.BANK_FEE_DEFAULT)
            End Set
        End Property

        ' vars to hold refrence
        ReadOnly _banks As ds_Payments.BAD_CHECK_BANKSDataTable
        ReadOnly _bta As ds_PaymentsTableAdapters.BAD_CHECK_BANKSTableAdapter

        Private ReadOnly _payHisForm As AdminPayments

        Public Sub New(ByRef homeForm As TrashCashHome, ByRef payHistoryForm As AdminPayments)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _banks = New ds_Payments.BAD_CHECK_BANKSDataTable
            _bta = New ds_PaymentsTableAdapters.BAD_CHECK_BANKSTableAdapter
            _home = homeForm
            _payHisForm = payHistoryForm
        End Sub


        Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
            Dim result As MsgBoxResult =
                    MsgBox(
                        "Confirm: Bouncing Check Ref Number: " & CheckRow.RefNumber & " - " &
                        FormatCurrency(CheckRow.Amount) & "." & vbCrLf _
                        & "Bank Fee: " & FormatCurrency(BankRow.BANK_FEE_DEFAULT) & ". Our Fee: " &
                        FormatCurrency(tb_CustFee.Text) & ".", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                Dim bounceOk As Boolean
                bounceOk = _home.Procedures.Customer_BounceCheck(CheckRow, BankRow, tb_CustFee.Text)
                If (bounceOk) Then
                    MsgBox("Check Bounce Completed.")
                    Close()
                End If
            End If
        End Sub

        Private Sub BouncedBankSelection_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
            _payHisForm.Fetch_History()
        End Sub

        Private Sub BouncedBankSelection_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' filling dt with possible bad check banks
            _bta.Fill(_banks)

            ' grabbing default fee here and then disposing of ta
            Dim ta As New ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter
            Dim dr As ds_Application.APP_SETTINGSRow = ta.GetData().Rows(0)
            tb_CustFee.Text = dr.BAD_CHECK_CUST_FEE

            ' grabbing default bank selection
            If (Cmb_BadCheckBanks.SelectedValue IsNot Nothing) Then
                BankRow = _banks.FindByBC_BANK_ID(Cmb_BadCheckBanks.SelectedValue)
            End If

            ' hiding ts_m controls
            CustomerToolstrip1.HideQuickSearch()
        End Sub

        Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
            Close()
        End Sub

        Private Sub Cmb_BadCheckBanks_SelectionChangeCommitted(sender As ComboBox, e As EventArgs) _
            Handles Cmb_BadCheckBanks.SelectionChangeCommitted
            BankRow = _banks.FindByBC_BANK_ID(sender.SelectedValue)
        End Sub
    End Class
End Namespace