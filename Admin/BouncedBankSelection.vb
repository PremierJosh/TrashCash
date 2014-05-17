Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling

Public Class BouncedBankSelection
    ' home form refrence
    Private _home As TrashCash_Home

    ' passing id from pay history table
    Private _PayHistoryID As Integer
    Public Property PayHistoryID As Integer
        Get
            Return _PayHistoryID
        End Get
        Set(value As Integer)
            If (value > 0) Then
                _PayHistoryID = value
                ' query for row and set refrence
                Dim ta As New DataSetTableAdapters.PaymentHistoryTableAdapter
                CheckRow = ta.GetByID(value).Rows(0)
                ta = Nothing
            End If
        End Set
    End Property

    Private _checkRow As DataSet.PaymentHistoryRow
    Private Property CheckRow As DataSet.PaymentHistoryRow
        Get
            Return _checkRow
        End Get
        Set(value As DataSet.PaymentHistoryRow)
            _checkRow = value

            ' set check amount and check ref number
            tb_RefNum.Text = value.RefNumber
            tb_CheckAmount.Text = FormatCurrency(value.Amount)
            ' set ts cmb and get balance
            'Ts_M_Customer1.CurrentCustomer = value.CustomerNumber

        End Set
    End Property

    Private _bankRow As ds_Program.BAD_CHECK_BANKS_Row
    Private Property BankRow As ds_Program.BAD_CHECK_BANKS_Row
        Get
            Return _bankRow
        End Get
        Set(value As ds_Program.BAD_CHECK_BANKS_Row)
            _bankRow = value

            ' set fee
            tb_BankFee.Text = FormatCurrency(value.BANK_FEE_DEFAULT)
        End Set
    End Property

    ' vars to hold refrence
    Dim banks As ds_Program.BAD_CHECK_BANKS_DataTable
    Dim bta As ds_ProgramTableAdapters.BAD_CHECK_BANKS_TableAdapter

    Private _payHisForm As AdminPayments
    Public Sub New(ByRef HomeForm As TrashCash_Home, ByRef PayHistoryForm As AdminPayments)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        banks = New ds_Program.BAD_CHECK_BANKS_DataTable
        bta = New ds_ProgramTableAdapters.BAD_CHECK_BANKS_TableAdapter
        _home = HomeForm
        _payHisForm = PayHistoryForm
    End Sub


    Private Sub btn_Submit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Submit.Click
        Dim result As MsgBoxResult = MsgBox("Confirm: Bouncing Check Ref Number: " & CheckRow.RefNumber & " - " & FormatCurrency(CheckRow.Amount) & "." & vbCrLf _
                                            & "Bank Fee: " & FormatCurrency(BankRow.BANK_FEE_DEFAULT) & ". Our Fee: " & FormatCurrency(tb_CustFee.Text) & ".", MsgBoxStyle.YesNo)
        If (result = MsgBoxResult.Yes) Then
            Dim bounceOk As Boolean
            bounceOk = _home.Procedures.Customer_BounceCheck(CheckRow, BankRow, tb_CustFee.Text)
            If (bounceOk) Then
                MsgBox("Check Bounce Completed.")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BouncedBankSelection_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _payHisForm.Fetch_History()
    End Sub

    Private Sub BouncedBankSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' filling dt with possible bad check banks
        bta.Fill(banks)

        ' grabbing default fee here and then disposing of ta
        Dim _ta As New ds_ProgramTableAdapters.APP_SETTINGS_TableAdapter
        Dim _dr As ds_Program.APP_SETTINGS_Row = _ta.GetData().Rows(0)
        tb_CustFee.Text = _dr.BAD_CHECK_CUST_FEE
        _ta = Nothing
        _dr = Nothing

        ' grabbing default bank selection
        If (Cmb_BadCheckBanks.SelectedValue IsNot Nothing) Then
            BankRow = banks.FindByBC_BANK_ID(Cmb_BadCheckBanks.SelectedValue)
        End If

        ' hiding ts_m controls
        Ts_M_Customer1.HideQuickSearch()
    End Sub

    Private Sub btn_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub Cmb_BadCheckBanks_SelectionChangeCommitted(sender As Database_ComboBoxes.cmb_BadCheckBanks, e As System.EventArgs) Handles Cmb_BadCheckBanks.SelectionChangeCommitted
        BankRow = banks.FindByBC_BANK_ID(sender.SelectedValue)
    End Sub


End Class