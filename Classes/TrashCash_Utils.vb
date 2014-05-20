Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils.Err_Handling
'Imports System.Windows.Forms.ToolStripComboBox

Public Class TrashCash_Utils
    ' can be used by any where this class is included
    Public Shared qta_util As DataSetTableAdapters.QueriesTableAdapter

    Public Class ProgressObj
        Public Property MaximumValue As Integer
        Public Property CurrentValue As Integer
        Public Property CurrentCustomer As String
    End Class

    Public Class _Functions
        Public Shared Function FormExists(ByVal formName As String,
                                   Optional ByRef _form As Form = Nothing,
                                   Optional ByVal bringToFront As Boolean = False) As Boolean
            ' return var
            Dim exists As Boolean

            ' checking if form exists by name
            Dim forms As FormCollection = Application.OpenForms
            For i = 0 To forms.Count - 1
                If (forms.Item(i).ToString = formName) Then
                    exists = True
                    ' if bringToBringTrue...
                    If (bringToFront) Then
                        forms.Item(i).BringToFront()
                    End If

                    ' if form ref needs passed back
                    If (_form IsNot Nothing) Then
                        _form = forms.Item(i)
                    End If
                End If
            Next i

            Return exists
        End Function
    End Class
    Public Class Err_Handling
        'Protected qta As DataSetTableAdapters.QueriesTableAdapter

        Public Shared Sub ResponseErr_Misc(ByVal resp As IResponse)
            If (resp.StatusCode = 1) Then
                MsgBox("No matching results from Quickbooks")
            Else
                If (qta_util Is Nothing) Then
                    qta_util = New DataSetTableAdapters.QueriesTableAdapter
                End If
                Try
                    qta_util.ERR_MISC_Insert(resp.Type.GetValue.ToString,
                                        resp.StatusCode.ToString,
                                        resp.StatusMessage,
                                        Date.Now)
                    MsgBox("Error Encounterd with Quickbooks. Contact Premier.", MsgBoxStyle.Critical)
                Catch ex As Exception
                    MsgBox("ERR_MISC_Insert: " & ex.Message)
                End Try
            End If
            
        End Sub
    End Class
End Class

Namespace Database_ComboBoxes

    Public Class ComboBoxPair
        Public Property ValueMember
        Public Property DisplayMember
    End Class

    Public Class ts_cmb_BadCheckBanks
        Inherits Windows.Forms.ToolStripComboBox

        Private dt As DataSet.BanksListDataTable
        Private ta As DataSetTableAdapters.BanksListTableAdapter

        Public Sub New()
            dt = New DataSet.BanksListDataTable
            ta = New DataSetTableAdapters.BanksListTableAdapter

            ta.ClearBeforeFill = True
            ta.Fill(dt)

            ' bind
            Me.ComboBox.DataSource = dt
            Me.ComboBox.DisplayMember = "BANK_NAME"
            Me.ComboBox.ValueMember = "BC_BANK_ID"

            ' resizing
            Me.Size = New Size(200, 25)
        End Sub

        Public Sub RefreshForChanges()
            ta.Fill(dt)
        End Sub
    End Class

    Public Class cmb_PaymentTypes
        Inherits ComboBox

        Private dt As ds_Types.PaymentTypesDataTable
        Private ta As ds_TypesTableAdapters.PaymentTypesTableAdapter

        Public Sub New()
            ta = New ds_TypesTableAdapters.PaymentTypesTableAdapter
            dt = New ds_Types.PaymentTypesDataTable
            ta.Fill(dt)

            Me.DataSource = dt
            Me.DisplayMember = "PaymentTypeName"
            Me.ValueMember = "PaymentTypeID"
        End Sub
    End Class

    Public Class cmb_ServiceTypes
        Inherits ComboBox

        ' events
        Public Event ServiceChanged(ByVal ServiceID As Integer, ByVal Rate As Double, ByVal BillLength As Integer)

        ' property
        Private rate As Decimal
        Private length As Integer
        ReadOnly Property SelectedServiceRate As Decimal
            Get
                If (rate = Nothing) Then
                    GetRate()
                End If
                Return rate
            End Get
        End Property
        ReadOnly Property SelectedServiceLength As Integer
            Get
                If (length = Nothing) Then
                    GetLength()
                End If
                Return length
            End Get
        End Property

        ' custList dt and ta
        Private dt As ds_Types.ServiceTypesListDataTable
        Private ta As ds_TypesTableAdapters.ServiceTypesListTableAdapter

        Public Sub New()
            MyBase.New()
            dt = New ds_Types.ServiceTypesListDataTable
            ta = New ds_TypesTableAdapters.ServiceTypesListTableAdapter
            ' fill table
            ta.Fill(dt)

            ' bind
            Me.DisplayMember = "ServiceName"
            Me.ValueMember = "ServiceTypeID"
            Me.DataSource = dt
        End Sub

        Private Sub GetRate()
            If (Me.SelectedValue IsNot Nothing) Then
                Dim row As DataRowView = DirectCast(Me.SelectedItem, DataRowView)
                rate = row.Item("ServiceRate")
            End If
        End Sub

        Private Sub GetLength()
            If (Me.SelectedValue IsNot Nothing) Then
                Dim row As DataRowView = DirectCast(Me.SelectedItem, DataRowView)
                length = row.Item("ServiceBillLength")
            End If
        End Sub

        Public Sub RefreshList(Optional ByVal Rebind As Boolean = False)
            dt = New ds_Types.ServiceTypesListDataTable
            ta = New ds_TypesTableAdapters.ServiceTypesListTableAdapter
            ' fill table
            ta.Fill(dt)

            If (Rebind = True) Then
                ' bind
                'Me.DataSource = dt
                Me.DisplayMember = "ServiceName"
                Me.ValueMember = "ServiceTypeID"
            End If
        End Sub

        ' NEED TO SEE IF ABOVE SUB FIRES THIS SO I DONT NEED TO RAISE THE EVENT THERE
        Private Sub ChangeCommited() Handles Me.SelectionChangeCommitted
            GetRate()
            GetLength()
            RaiseEvent ServiceChanged(CInt(Me.SelectedValue), rate, length)
        End Sub
    End Class

    Public Class cmb_BadCheckBanks
        Inherits ComboBox

        Dim dt As DataSet.BanksListDataTable
        Dim ta As DataSetTableAdapters.BanksListTableAdapter

        Public Sub New()
            dt = New DataSet.BanksListDataTable
            ta = New DataSetTableAdapters.BanksListTableAdapter

            ta.Fill(dt)

            ' bind
            Me.DataSource = dt
            Me.DisplayMember = "BANK_NAME"
            Me.ValueMember = "BC_BANK_ID"
        End Sub
    End Class

    Public Class cmb_Users
        Inherits ComboBox

        Private dt As ds_Program.USERSDataTable
        Private ta As ds_ProgramTableAdapters.USERSTableAdapter

        Public Sub New()
            ta = New ds_ProgramTableAdapters.USERSTableAdapter
            dt = ta.GetUsersList

            Me.DisplayMember = "USER_NAME"
            Me.ValueMember = "USER_UD"
            Me.DataSource = dt
        End Sub

        Private _authLevel As Integer
        Public ReadOnly Property AuthLevel
            Get
                GetAuthLevel()
                Return _authLevel
            End Get
        End Property

        Private Sub GetAuthLevel()
            If (Me.SelectedValue IsNot Nothing) Then
                Dim row As DataRowView = DirectCast(Me.SelectedItem, DataRowView)
                _authLevel = CType(row.Row, ds_Program.USERSRow).USER_AUTHLVL
            End If
        End Sub
    End Class

    Public Class cmb_BatchPaymentHistory
        Inherits ComboBox

        Dim dt As Report_DataSet.BatchPayments_ListDataTable
        Dim ta As Report_DataSetTableAdapters.BatchPayments_ListTableAdapter

        Public Sub New()
            dt = New Report_DataSet.BatchPayments_ListDataTable
            ta = New Report_DataSetTableAdapters.BatchPayments_ListTableAdapter

            ta.Fill(dt)

            Me.DataSource = dt
            Me.DisplayMember = "BatchPaymentInfoText"
            Me.ValueMember = "BATCH_PAY_ID"
        End Sub
    End Class
End Namespace

Public Class Currency_TextBox
    Inherits TextBox

    Private Sub Currency_TextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        If (sender.textlength > 0) Then
            If Not Decimal.TryParse(Me.Text, _
                              Globalization.NumberStyles.Currency) Then
                'Don't let the user leave the field if the value is invalid.
                With Me
                    .HideSelection = False
                    .SelectAll()

                    MessageBox.Show("Please enter a valid currency amount.", _
                                    "Invalid Value", _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Error)

                    .HideSelection = True
                End With

                e.Cancel = True
            End If
        End If
    End Sub
End Class

'Public Sub QB_GetAllItems(ByRef dt As DataSet.ServiceTypesDataTable)
'    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
'    Dim itemQuery As IItemQuery = msgSetReq.AppendItemQueryRq

'    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
'    Dim respList As IResponseList = msgSetResp.ResponseList

'    For i = 0 To respList.Count - 1
'        Dim response As IResponse = respList.GetAt(i)
'        Dim itemRetList As IORItemRetList = response.Detail


'        For j = 0 To itemRetList.Count - 1
'            Dim itemRet As IORItemRet = itemRetList.GetAt(j)

'            If (itemRet.ItemServiceRet IsNot Nothing) Then
'                Dim row As DataSet.ServiceTypesRow = dt.NewServiceTypesRow

'                row.ServiceName = itemRet.ItemServiceRet.Name.GetValue
'                row.ServiceRate = itemRet.ItemServiceRet.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.GetValue
'                row.ServiceDescription = itemRet.ItemServiceRet.ORSalesPurchase.SalesOrPurchase.Desc.GetValue
'                row.ServiceListID = itemRet.ItemServiceRet.ListID.GetValue
'                row.ServiceEditSequence = itemRet.ItemServiceRet.EditSequence.GetValue
'                row.ServiceBillLength = "1"

'                If (row.ServiceRate > 0) Then
'                    dt.AddServiceTypesRow(row)
'                End If
'            End If


'        Next
'    Next
'End Sub