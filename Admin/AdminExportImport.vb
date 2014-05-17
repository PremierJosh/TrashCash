Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling

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

    Private _homeForm As TrashCash_Home
    Friend Property TC_Home As TrashCash_Home
        Get
            Return _homeForm
        End Get
        Set(value As TrashCash_Home)
            _homeForm = value
        End Set
    End Property

    ' form global tas
    Dim cta As DataSetTableAdapters.CustomerTableAdapter
    Dim qta As DataSetTableAdapters.QueriesTableAdapter
    Dim ata As ds_ProgramTableAdapters.APP_SETTINGS_TableAdapter
    Dim cita As ds_ProgramTableAdapters.Initial_CustomInvoiceTableAdapter
    Dim cidt As ds_Program.Initial_CustomInvoiceDataTable


    Private Sub ImportWork_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cta = New DataSetTableAdapters.CustomerTableAdapter
        qta = New DataSetTableAdapters.QueriesTableAdapter
        ata = New ds_ProgramTableAdapters.APP_SETTINGS_TableAdapter
        cita = New ds_ProgramTableAdapters.Initial_CustomInvoiceTableAdapter
        cidt = cita.GetData
        tb_CustInvCount.Text = cidt.Rows.Count

        Dim _customInvItem As String = Nothing
        ' setting custom inv item var value
        _customInvItem = qta.APP_GetCustomInvItem
        ' checking if already set
        If (_customInvItem IsNot Nothing) Then
            cmb_ItemList.SelectedValue = _customInvItem
        End If


        ' update missing list id count
        MissingCustomerCount = qta.Customer_MissingListIDCount
        ' bind account cmb for adding items
        TC_Home.Queries.CMB_BindIncomeAccount(cmb_IncomeAcc)
        ' binding cmb for picking custom inv item
        TC_Home.Queries.CMB_BindServiceItem(cmb_ItemList)
    End Sub

    Private Sub btn_AddCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustomers.Click
        If (MissingCustomerCount > 0) Then
            ' set cursor to hourglass
            Me.Cursor = Cursors.WaitCursor

            ' make pb visible
            pb_AllCustAdd.Visible = True
            lbl_AllCustAddCount.Visible = True

            TC_Home.Procedures.Customer_AddMissingListID(Me)
            Me.Cursor = Cursors.Default

            ' hide pb
            pb_AllCustAdd.Visible = False
            lbl_AllCustAddCount.Visible = False

            MissingCustomerCount = qta.Customer_MissingListIDCount
        End If
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TC_Home = HomeForm
    End Sub

    Private Sub btn_AddSrvcs_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddSrvcs.Click
        Dim result As MsgBoxResult = MsgBox("Please make sure the correct Account is selected above.", MsgBoxStyle.YesNo)
        If (result = MsgBoxResult.Yes) Then
            TC_Home.Procedures.Items_ImportAllMissingListID(cmb_IncomeAcc.SelectedValue)
        End If
    End Sub

    Private Sub btn_SetCustInvItem_Click(sender As System.Object, e As System.EventArgs) Handles btn_SetCustInvItem.Click
        ata.APP_SetCustomInvItem(cmb_ItemList.SelectedValue)
    End Sub

    Private Sub btn_AddCustInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddCustInv.Click
        ' getting custom inv item
        Dim itemID As String = qta.APP_GetCustomInvItem

        For Each row As ds_Program.Initial_CustomInvoiceRow In cidt
            Dim invoiceAdd As IInvoiceAdd = TC_Home.MsgSetRequest.AppendInvoiceAddRq

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

            Dim msgSetResp As IMsgSetResponse = TC_Home.SessionManager.DoRequests(TC_Home.MsgSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            TC_Home.MsgSetRequest.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode <> 0) Then

                    Try
                        ResponseErr_Misc(resp)
                        Exit Sub
                    Catch ex As Exception
                        MsgBox("Err_Invoice_Insert: " & ex.Message)
                    End Try

                Else
                    Dim invRet As IInvoiceRet = resp.Detail

                    ' custom invoice history insert
                    Try
                        Dim historyID As Integer
                        Dim hta As New Report_DataSetTableAdapters.CustomInvoiceHistoryTableAdapter
                        historyID = qta.CustomInvoiceHistory_Insert(row.CustomerNumber,
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