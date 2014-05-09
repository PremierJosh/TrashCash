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


    Public Sub New(ByRef _HomeForm As TrashCash_Home, ByRef _PaymentID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HomeForm = _HomeForm
        ' set various vars qb will need in mod request
        PaymentID = _PaymentID
    End Sub
End Class