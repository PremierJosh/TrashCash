Namespace Admin
    Public Class AdminInvoiceTypes

        Private Sub AdminInvoiceTypes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ' init fill
            CustomInvoice_LineTypesTableAdapter.Fill(Ds_Invoicing.CustomInvoice_LineTypes)

            ' bind account cmb for adding items
            _homeForm.Queries.CMB_BindIncomeAccount(cmb_QBAccount)

        End Sub

        Private ReadOnly _homeForm As TrashCashHome
        Public Sub New(ByRef homeForm As TrashCashHome)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _homeForm = homeForm
        End Sub
    End Class
End Namespace