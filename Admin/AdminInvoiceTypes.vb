Imports QBFC12Lib
Imports TrashCash.Modules
Imports TrashCash.Classes

Namespace Admin
    Public Class AdminInvoiceTypes

        Private Sub AdminInvoiceTypes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ' init fill
            CustomInvoice_LineTypesTableAdapter.Fill(Ds_Invoicing.CustomInvoice_LineTypes)

            ' bind account cmb for adding items
            BindComboBox()
        End Sub

        Private Sub BindComboBox()
            Dim resp As IResponse = QBRequests.AccountQuery(ENAccountType.atIncome)
            If (resp.StatusCode = 0) Then
                Dim retList As IAccountRetList = resp.Detail
                Dim ds As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(retList)
                ' binding
                cmb_QBAccount.DisplayMember = "DisplayMember"
                cmb_QBAccount.ValueMember = "ValueMember"
                cmb_QBAccount.DataSource = ds
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

        End Sub

      Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
           End Sub
    End Class
End Namespace