Public Class UC_InvoiceDetails
    ' events
    Friend WithEvents RemindForm As CustomInvoice_DescRemind

    ' event to let form know inv added
    Friend Event InvoiceComplete()

    ' property to hold class
    Private _home As TrashCash_Home
    Friend Property HomeForm As TrashCash_Home
        Get
            Return _home
        End Get
        Set(value As TrashCash_Home)
            _home = value
        End Set
    End Property

    Private _currentCustomer As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            If (_currentCustomer <> value) Then
                _currentCustomer = value
                'wipe dt
                Me.DataSet.Clear()
            End If
        End Set
    End Property

    Private Sub UC_InvoiceDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub SubmitInvoice(ByVal Description As String) Handles RemindForm.SubmitInvoice
        ' this is thrown when reminder and description is set
        Me.DataSet.CustomInvoice_LineItems.Clear()
        dtp_DueDate.Value = Date.Now
        dtp_PostDate.Value = Date.Now
        MsgBox("Invoice Added.")
    End Sub

    Private Sub btn_Commit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Commit.Click

        If (Me.DataSet.CustomInvoice_LineItems.Rows.Count > 0) Then
            RemindForm = New CustomInvoice_DescRemind(HomeForm)
            RemindForm.CustomerNumber = CurrentCustomer
            RemindForm.InvoiceTotal = tb_Total.Text
            RemindForm.DueDate = dtp_DueDate.Value
            RemindForm.PostDate = dtp_PostDate.Value
            RemindForm.LineItems = Me.DataSet.CustomInvoice_LineItems
            RemindForm.ShowDialog()
        Else
            MsgBox("You must have at least 1 line item.")
        End If

    End Sub

   
    Private Sub UpdateTotal()
        If (Me.DataSet.CustomInvoice_LineItems.Rows.Count > 0) Then
            tb_Total.Text = FormatCurrency(Me.DataSet.CustomInvoice_LineItems.Compute("Sum (Rate)", ""))
        Else
            tb_Total.Text = FormatCurrency("0")
        End If
    End Sub


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btn_AddLine_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddLine.Click
        If (tb_Desc.TextLength > 0) Then
            If (tb_Rate.TextLength > 0) Then
                Dim row As DataSet.CustomInvoice_LineItemsRow = Me.DataSet.CustomInvoice_LineItems.NewCustomInvoice_LineItemsRow
                row.Description = tb_Desc.Text
                row.Rate = tb_Rate.Text

                Me.DataSet.CustomInvoice_LineItems.AddCustomInvoice_LineItemsRow(row)

                ' clear tbs for new row
                tb_Desc.Text = ""
                tb_Rate.Text = ""
            Else
                MsgBox("Line items must have a Rate. A Descriptive line item will be added after you click Submit.")
            End If
        Else
            MsgBox("You must include a description for a line item.")
        End If
    End Sub

    Private Sub dg_LineItem_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_LineItem.RowsAdded
        UpdateTotal()
    End Sub

    Private Sub dg_LineItem_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg_LineItem.RowsRemoved
        UpdateTotal()
    End Sub
End Class
