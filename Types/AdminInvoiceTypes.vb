Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Types
    Public Class AdminInvoiceTypes

        Private Sub AdminInvoiceTypes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub AdminInvoiceTypes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ' init fill
            CustomInvoice_LineTypesTableAdapter.Fill(Invoicing.CustomInvoice_LineTypes)

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
        Private Function ValidateItem() As Boolean
            Dim err As Integer = 0

            If (cmb_QBAccount.SelectedValue = Nothing) Then
                err += 1
            End If
            If (Trim(tb_Name.Text) = "") Then
                err += 1
            End If
            If (Trim(tb_Desc.Text) = "") Then
                err += 1
            End If

            If (err = 0) Then
                Return True
            Else
                Return False
            End If
        End Function
        Private Sub btn_AddItem_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddItem.Click
            If (ValidateItem()) Then
                Dim item As New QBItemObj
                With item
                    .ItemName = tb_Name.Text
                    .Desc = tb_Desc.Text
                    .IncomeAccountListID = cmb_QBAccount.SelectedValue
                End With

                Dim resp As IResponse = QBRequests.ServiceItemAdd(item)
                If (resp.StatusCode = 0) Then
                    Dim ret As IItemServiceRet = resp.Detail
                    Try
                        CustomInvoice_LineTypesTableAdapter.Insert(ret.Name.GetValue, ret.ListID.GetValue, ret.EditSequence.GetValue, tb_Desc.Text, False)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    MessageBox.Show("Item added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' refil table
                    CustomInvoice_LineTypesTableAdapter.Fill(Invoicing.CustomInvoice_LineTypes)

                Else
                    QBMethods.ResponseErr_Misc(resp)
                End If
            End If
        End Sub
    End Class
End Namespace