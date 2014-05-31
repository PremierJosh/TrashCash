Public Class PaymentsForm
    ' easier refrence
    Protected ta As ds_PaymentsTableAdapters.WorkingPaymentsTableAdapter

    ' home form ref var
    Private _home As TrashCashHome

    Private _custNum As Integer
    Public Property CurrentCustomer
        Get
            Return _custNum
        End Get
        Set(value)
            If (_custNum <> value) Then
                _custNum = value


                ' do stuff when cust changes here
                UC_PaymentDetails.CurrentCustomer = value
                UC_CustomerNotes.CurrentCustomer = value
                UC_CustomerInfoBoxes.CurrentCustomer = value
                ' update window title text
                Text = CustomerToolstrip1.ToString
            End If
        End Set
    End Property

    ' override show function to also wipe recently added payments
    Public Overloads Sub Show()
        MyBase.Show()
        If (Me.ds_Payments.WorkingPayments.Rows.Count > 0) Then
            Me.ds_Payments.WorkingPayments.Clear()
        End If

    End Sub

    Private Sub CustomerToolstrip1_CustomerChanging(CustomerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
        Me.CurrentCustomer = CustomerNumber
    End Sub

    Private Sub PaymentAdded(ByVal rowID As Integer) Handles UC_PaymentDetails.PaymentAdded
        ta.ClearBeforeFill = False
        ta.FillByID(ds_Payments.WorkingPayments, rowID)

    End Sub

    Public Sub New(ByRef HomeForm As TrashCashHome, Optional ByVal _customerNumber As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ta = Me.WorkingPaymentsTableAdapter
        _home = HomeForm

        ' if number is passed, lock ts
        If (_customerNumber <> 0) Then
            CustomerToolstrip1.Enabled = False
            CustomerToolstrip1.HideQuickSearch()
            CurrentCustomer = _customerNumber
            CustomerToolstrip1.SelectCustomer(_customerNumber)
        Else
            CurrentCustomer = CustomerToolstrip1.CurrentCustomer
        End If
    End Sub
    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If (dg_WorkPay.SelectedRows.Count = 1) Then
            Dim drv As DataRowView = dg_WorkPay.SelectedRows.Item(0).DataBoundItem
            Dim row As ds_Payments.WorkingPaymentsRow = drv.Row
            Dim result As MsgBoxResult = MsgBox("Delete this Prepared Payment?", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                ta.DeleteByID(row.WorkingPaymentsID)
                dg_WorkPay.Rows.RemoveAt(dg_WorkPay.SelectedRows.Item(0).Index)
            End If
        Else
            MsgBox("Please select a Payment First.")
        End If
    End Sub

    Private Sub Payments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' stop closing and hide form
        If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub Payments_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' setting uc info boxes to display only
        UC_CustomerInfoBoxes.AllowUpdate(False)
       End Sub
End Class