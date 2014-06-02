Imports QBFC12Lib
Imports TrashCash.QBStuff
Imports TrashCash.Classes

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
        Dim _cita As ds_ApplicationTableAdapters.Initial_CustomInvoiceTableAdapter
        Dim _cidt As ds_Application.Initial_CustomInvoiceDataTable
        Dim _cqta As ds_CustomerTableAdapters.QueriesTableAdapter
        Private _cta As ds_CustomerTableAdapters.CustomerTableAdapter


        Private Sub ImportWork_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            _qta = New DataSetTableAdapters.QueriesTableAdapter
            _cqta = New ds_CustomerTableAdapters.QueriesTableAdapter
            _cita = New ds_ApplicationTableAdapters.Initial_CustomInvoiceTableAdapter
            _cidt = _cita.GetData
            tb_CustInvCount.Text = _cidt.Rows.Count
            _cta = New ds_CustomerTableAdapters.CustomerTableAdapter

         ' update missing list id count
            MissingCustomerCount = _cqta.Customer_MissingListIDCount
            ' bind account cmb for adding items
            _homeForm.Queries.CMB_BindIncomeAccount(cmb_IncomeAcc)
         End Sub

        Private Sub btn_AddCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustomers.Click
            If (MissingCustomerCount > 0) Then
                ' set cursor to hourglass
                Cursor = Cursors.WaitCursor

                ' make pb visible
                pb_AllCustAdd.Visible = True
                lbl_AllCustAddCount.Visible = True
                pb_AllCustAdd.Maximum = MissingCustomerCount
                pb_AllCustAdd.Value = 0

                Dim dt As ds_Customer.CustomerDataTable = _cta.GetDataByMissingListID()
                For Each row As ds_Customer.CustomerRow In dt
                    Dim resp As IResponse = QBRequests.CustomerAdd(row)
                    If (resp.StatusCode = 0) Then

                        Dim customerRet As ICustomerRet = resp.Detail
                        ' updating the custRow with ListID and EditSeq
                        row.CustomerListID = customerRet.ListID.GetValue
                        row.CustomerEditSeq = customerRet.EditSequence.GetValue
                        Try
                            _cta.Update(row)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        ' move progress bar
                        pb_AllCustAdd.Value += 1
                        lbl_AllCustAddCount.Text = pb_AllCustAdd.Value & "/" & MissingCustomerCount
                    Else
                        QBMethods.ResponseErr_Misc(resp)
                        MsgBox("Add fail")
                        Exit Sub
                    End If
                Next
                Cursor = Cursors.Default

                ' hide pb
                pb_AllCustAdd.Visible = False
                lbl_AllCustAddCount.Visible = False
                MissingCustomerCount = _cqta.Customer_MissingListIDCount
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
            Dim itemID As String = ""

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
                            GlobalConMgr.ResponseErr_Misc(resp)
                            Exit Sub
                        Catch ex As Exception
                            MsgBox("Err_Invoice_Insert: " & ex.Message)
                        End Try

                    Else
                        Dim invRet As IInvoiceRet = resp.Detail

                        ' custom invoice history insert
                        Try
                            
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