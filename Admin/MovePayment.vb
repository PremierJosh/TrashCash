Public Class MovePayment
    ' home form ref var
    Private HomeForm As TrashCash_Home

    ' vars i need to track
    Private _editSeq As String
    Private _txnId As String


    ' pay his row ref
    Private _payRow As DataSet.PaymentHistoryRow
    Private Property PaymentRow As DataSet.PaymentHistoryRow

    Public Sub New(ByRef _HomeForm As TrashCash_Home, ByRef _PaymentHistoryRow As DataSet.PaymentHistoryRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class