Public Class MovePayment
    ' home form ref var
    Private HomeForm As TrashCash_Home

    ' vars i need to track
    Private _editSeq As String
    Private _txnId As String



    ' pay his row ref
    Private _payRow As DataSet.PaymentHistoryRow
    Private Property PaymentRow As DataSet.PaymentHistoryRow
        Get
            Return _payRow
        End Get
        Set(value As DataSet.PaymentHistoryRow)
            _payRow = value

            ' TODO: fetch actual row

        End Set
    End Property

    Public Sub New(ByRef _HomeForm As TrashCash_Home, ByRef _PaymentHistoryRow As DataSet.PaymentHistoryRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HomeForm = _HomeForm
        ' set various vars qb will need in mod request
        PaymentRow = _PaymentHistoryRow
    End Sub
End Class