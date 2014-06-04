Namespace Payments
    Public Class PaymentsForm
       Private _custNum As Integer
        Public Property CurrentCustomer
            Get
                Return _custNum
            End Get
            Set(value)
                If (_custNum <> value) Then
                    _custNum = value
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

        Private Sub PaymentAdded(ByVal rowID As Integer)
       WorkingPaymentsTableAdapter.FillByID(ds_Payments.WorkingPayments, rowID)
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

            ' checking if in debug mode
            If (_debug) Then
                ck_Override.Checked = False
                dtp_Override.Visible = False
                dtp_Override.Value = Date.Now
            End If
        End Sub

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
            Else
                CurrentCustomer = CustomerToolstrip1.CurrentCustomer
            End If
        End Sub

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
            'TODO: This line of code loads data into the 'Ds_Types.PaymentTypes' table. You can move, or remove it, as needed.
            Me.PaymentTypesTableAdapter.Fill(Me.Ds_Types.PaymentTypes)
            ' setting uc info boxes to display only
            UC_CustomerInfoBoxes.AllowUpdate(False)
        End Sub
    End Class
End Namespace