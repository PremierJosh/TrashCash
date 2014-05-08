Public Class Invoicing
    ' home form ref
    Private _home As TrashCash_Home

    Private _custNum As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _custNum
        End Get
        Set(value As Integer)
            If (_custNum <> value) Then
                _custNum = value

                ' do stuff when cust changes here
                Ts_M_Customer.CurrentCustomer = value
                UC_InvoiceDetails.CurrentCustomer = value
                UC_CustomerNotes.CurrentCustomer = value
                UC_CustomerInfoBoxes.CurrentCustomer = value
                ' update window title
                Me.Text = Ts_M_Customer.ToString
            End If
        End Set
    End Property

    Private Sub Ts_M_Customer_CustomerChanging(CustomerNumber As Integer) Handles Ts_M_Customer.CustomerChanging
        Me.CurrentCustomer = CustomerNumber
        Ts_M_Customer.lbl_CustBalance.SetBalance(_home.Queries.Customer_Balance(CustomerNumber))
    End Sub

    Private Sub InvoiceAddComplete() Handles UC_InvoiceDetails.InvoiceComplete

    End Sub

    Private Sub Invoicing_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' stoping close and hiding instead
        If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub Invoicing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' set uc info boxes to display only
        UC_CustomerInfoBoxes.AllowUpdate(False)
        ' checking if customer set
        If (CurrentCustomer = 0) Then
            If (Ts_M_Customer.cmb_Customer.ComboBox.SelectedValue IsNot Nothing) Then
                Me.CurrentCustomer = Ts_M_Customer.cmb_Customer.ComboBox.SelectedValue
            End If
        End If

        Ts_M_Customer.CurrentCustomer = Me.CurrentCustomer
        ' init balance set
        Ts_M_Customer.lbl_CustBalance.SetBalance(_home.Queries.Customer_Balance(Me.CurrentCustomer))
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home, Optional ByVal _customerNumber As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' set class ref vars
        _home = HomeForm
        UC_InvoiceDetails.HomeForm = HomeForm

        ' if cust num is passed, set and lock the ts_customer
        If (_customerNumber <> 0) Then
            ' lock ts
            Ts_M_Customer.Enabled = False
            Ts_M_Customer.HideQuickSearch()
            Me.CurrentCustomer = _customerNumber
        End If
    End Sub

End Class