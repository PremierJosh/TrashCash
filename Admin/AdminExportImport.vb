Imports QBFC12Lib

Namespace Admin

    Public Class AdminExportImport
        Private _missingCount As Integer
        Private Property MissingCustomerCount As Integer
            Get
                Return _missingCount
            End Get
            Set(value As Integer)
                _missingCount = value
                tb_MissingCount.Text = value

                ' color box red if value > 0
                If (value > 0) Then
                    tb_MissingCount.BackColor = Color.MistyRose
                    btn_AddCustomers.Enabled = True
                Else
                    tb_MissingCount.BackColor = SystemColors.Window
                    btn_AddCustomers.Enabled = False
                End If
            End Set
        End Property

        Private ReadOnly _homeForm As TrashCashHome

        ' form global tas
        Dim _qta As DataSetTableAdapters.QueriesTableAdapter
        Dim _ata As ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter
        Dim _cita As ds_ApplicationTableAdapters.Initial_CustomInvoiceTableAdapter
        Dim _cidt As ds_Application.Initial_CustomInvoiceDataTable


        Private Sub ImportWork_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            _qta = New DataSetTableAdapters.QueriesTableAdapter
            _ata = New ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter
            _cita = New ds_ApplicationTableAdapters.Initial_CustomInvoiceTableAdapter
            _cidt = _cita.GetData
            tb_CustInvCount.Text = _cidt.Rows.Count

            Dim customInvItem As String
            ' setting custom inv item var value
            customInvItem = _qta.APP_GetCustomInvItem
            ' checking if already set
            If (customInvItem IsNot Nothing) Then
                cmb_ItemList.SelectedValue = customInvItem
            End If


            ' update missing list id count
            MissingCustomerCount = _qta.Customer_MissingListIDCount
            ' bind account cmb for adding items
            _homeForm.Queries.CMB_BindIncomeAccount(cmb_IncomeAcc)
            ' binding cmb for picking custom inv item
            _homeForm.Queries.CMB_BindServiceItem(cmb_ItemList)
        End Sub

        Private Sub btn_AddCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustomers.Click
            If (MissingCustomerCount > 0) Then
                ' set cursor to hourglass
                Cursor = Cursors.WaitCursor

                ' make pb visible
                pb_AllCustAdd.Visible = True
                lbl_AllCustAddCount.Visible = True

                _homeForm.Procedures.Customer_AddMissingListID(Me)
                Cursor = Cursors.Default

                ' hide pb
                pb_AllCustAdd.Visible = False
                lbl_AllCustAddCount.Visible = False

                MissingCustomerCount = _qta.Customer_MissingListIDCount
            End If
        End Sub

        Public Sub New(ByRef homeForm As TrashCashHome)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _homeForm = HomeForm
        End Sub

        Private Sub btn_AddSrvcs_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddSrvcs.Click
            Dim result As MsgBoxResult = MsgBox("Please make sure the correct Account is selected above.", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                _homeForm.Procedures.Items_ImportAllMissingListID(cmb_IncomeAcc.SelectedValue)
            End If
        End Sub

      
        Private Sub btn_AddCustInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustInv.Click
            ' getting custom inv item
            Dim itemID As String = _qta.APP_GetCustomInvItem

            For Each row As ds_Application.Initial_CustomInvoiceRow In _cidt
                Dim invoiceAdd As IInvoiceAdd = _homeForm.MsgSetRequest.AppendInvoiceAddRq

                ' build request
                invoiceAdd.CustomerRef.ListID.SetValue(row.CustomerListID)
                invoiceAdd.TxnDate.SetValue(row.PostAndDueDate)
                invoiceAdd.DueDate.SetValue(row.PostAndDueDate)
                invoiceAdd.IsToBePrinted.SetValue(False)

                ' line list
                Dim lineList As IORInvoiceLineAddList = invoiceAdd.ORInvoiceLineAddList
                ' line item to reuse
                Dim lineItem As IORInvoiceLineAdd


                lineItem = lineList.Append

                lineItem.InvoiceLineAdd.ItemRef.ListID.SetValue(itemID)
                lineItem.InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(row.Total)
                lineItem.InvoiceLineAdd.Quantity.SetValue(1)

                Dim msgSetResp As IMsgSetResponse = _homeForm.SessionManager.DoRequests(_homeForm.MsgSetRequest)
                Dim respList As IResponseList = msgSetResp.ResponseList

                _homeForm.MsgSetRequest.ClearRequests()

                For i = 0 To respList.Count - 1
                    Dim resp As IResponse = respList.GetAt(i)
                    If (resp.StatusCode <> 0) Then

                        Try
                            Utilities.ErrHandling.ResponseErr_Misc(resp)
                            Exit Sub
                        Catch ex As Exception
                            MsgBox("Err_Invoice_Insert: " & ex.Message)
                        End Try

                    Else
                        Dim invRet As IInvoiceRet = resp.Detail

                        ' custom invoice history insert
                        Try
                            _qta.CustomInvoiceHistory_Insert(row.CustomerNumber,
                                                             invRet.TxnID.GetValue,
                                                             invRet.RefNumber.GetValue,
                                                             invRet.TimeCreated.GetValue,
                                                             row.PostAndDueDate,
                                                             invRet.Subtotal.GetValue)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If

                Next i

            Next row

            MsgBox("Invoices added. Be sure to delete rows before next import.")
        End Sub

    End Class
End Namespace