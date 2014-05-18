Public Class CustomerCredit
    Private _homeForm As TrashCash_Home

    Private _currentCustomer As Integer
    Private Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            _currentCustomer = value

        End Set
    End Property

    Public Sub New(ByRef HomeForm As TrashCash_Home, ByVal CustomerNumber As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' set customer
        Ts_M_Customer.CurrentCustomer = CustomerNumber
        CurrentCustomer = CustomerNumber
        ' get balance
        _homeForm = HomeForm
        Ts_M_Customer.lbl_CustBalance.SetBalance(_homeForm.Queries.Customer_Balance(CustomerNumber))

        ' hide toolstrip stuff and lock to customer
        Ts_M_Customer.Enabled = False
        Ts_M_Customer.HideQuickSearch()
    End Sub

    Private _rightClickRowIndex As Integer
    Private Sub dg_Credits_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dg_Credits.MouseClick
        ' catching right clicking
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            _rightClickRowIndex = dg_Credits.HitTest(e.Location.X, e.Location.Y).RowIndex
            ' testing setting tag on context menu item
            btn_VoidCredit.Tag = _rightClickRowIndex
        End If
    End Sub

    Private Sub btn_VoidCredit_Click(sender As System.Object, e As System.EventArgs) Handles btn_VoidCredit.Click
        If (sender.tag IsNot Nothing) Then
            Dim row As ds_Customer.Customer_CreditsRow = CType(dg_Credits.Rows(sender.tag).DataBoundItem, DataRowView).Row
            If (Not row.Voided) Then

            Else
                MessageBox.Show("This Credit was voided on " & row.VoidTime.Date & " by user " & row.VoidUser & ".", "Already voided", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class