Imports QBFC12Lib
Imports System.ComponentModel

'Imports System.Windows.Forms.ToolStripComboBox

Public Class Utilities
    ' can be used by any where this class is included
    Public Shared QtaUtil As DataSetTableAdapters.QueriesTableAdapter

    Public Class ProgressObj
        Public Property MaximumValue As Integer
        Public Property CurrentValue As Integer
        Public Property CurrentCustomer As String
    End Class

    Public Class Functions
        Public Shared Function FormExists(ByVal formName As String,
                                   Optional ByRef form As Form = Nothing,
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
                    If (Form IsNot Nothing) Then
                        Form = forms.Item(i)
                    End If
                End If
            Next i

            Return exists
        End Function
    End Class
    Public Class ErrHandling
        'Protected qta As DataSetTableAdapters.QueriesTableAdapter

        Public Shared Sub ResponseErr_Misc(ByVal resp As IResponse)
            If (resp.StatusCode = 1) Then
                MsgBox("No matching results from Quickbooks")
            Else
                If (QtaUtil Is Nothing) Then
                    QtaUtil = New DataSetTableAdapters.QueriesTableAdapter
                End If
                Try
                    QtaUtil.ERR_MISC_Insert(resp.Type.GetValue.ToString,
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

        Private ReadOnly _dt As DataSet.BanksListDataTable
        Private ReadOnly _ta As DataSetTableAdapters.BanksListTableAdapter

        Public Sub New()
            _dt = New DataSet.BanksListDataTable
            _ta = New DataSetTableAdapters.BanksListTableAdapter

            _ta.ClearBeforeFill = True
            _ta.Fill(_dt)

            ' bind
            Me.ComboBox.DataSource = _dt
            Me.ComboBox.DisplayMember = "BANK_NAME"
            Me.ComboBox.ValueMember = "BC_BANK_ID"

            ' resizing
            Me.Size = New Size(200, 25)
        End Sub


        Public Sub RefreshForChanges()
            _ta.Fill(_dt)
        End Sub
    End Class

    Public Class cmb_PaymentTypes
        Inherits ComboBox

        Private ReadOnly _dt As ds_Types.PaymentTypesDataTable
        Private ReadOnly _ta As ds_TypesTableAdapters.PaymentTypesTableAdapter

        Public Sub New()
            _ta = New ds_TypesTableAdapters.PaymentTypesTableAdapter
            _dt = New ds_Types.PaymentTypesDataTable
            _ta.Fill(_dt)

            Me.DataSource = _dt
            Me.DisplayMember = "PaymentTypeName"
            Me.ValueMember = "PaymentTypeID"
        End Sub
    End Class

    Public Class cmb_ServiceTypes
        Inherits ComboBox

        ' events
        Public Event ServiceChanged(ByVal serviceID As Integer, ByVal Rate As Double, ByVal billLength As Integer)

        ' property
        Private _rate As Decimal
        Private _length As Integer
        ReadOnly Property SelectedServiceRate As Decimal
            Get
                If (_rate = Nothing) Then
                    GetRate()
                End If
                Return _rate
            End Get
        End Property
        ReadOnly Property SelectedServiceLength As Integer
            Get
                If (_length = Nothing) Then
                    GetLength()
                End If
                Return _length
            End Get
        End Property

        ' custList dt and ta
        Public DT As ds_Types.ServiceTypesListDataTable
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property DataTable As ds_Types.ServiceTypesListDataTable
            Get
                Return DT
            End Get
            Set(value As ds_Types.ServiceTypesListDataTable)
                DT = value
            End Set
        End Property

        Public TA As ds_TypesTableAdapters.ServiceTypesListTableAdapter
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property TableAdapater As ds_TypesTableAdapters.ServiceTypesListTableAdapter
            Get
                Return TA
            End Get
            Set(value As ds_TypesTableAdapters.ServiceTypesListTableAdapter)
                TA = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            DataTable = New ds_Types.ServiceTypesListDataTable
            TableAdapater = New ds_TypesTableAdapters.ServiceTypesListTableAdapter
            ' fill table
            TableAdapater.Fill(DataTable)

            ' bind
            Me.DisplayMember = "ServiceName"
            Me.ValueMember = "ServiceTypeID"
            Me.DataSource = DataTable
        End Sub

        Private Sub GetRate()
            If (Me.SelectedValue IsNot Nothing) Then
                Dim row As DataRowView = DirectCast(Me.SelectedItem, DataRowView)
                _rate = row.Item("ServiceRate")
            End If
        End Sub

        Private Sub GetLength()
            If (Me.SelectedValue IsNot Nothing) Then
                Dim row As DataRowView = DirectCast(Me.SelectedItem, DataRowView)
                _length = row.Item("ServiceBillLength")
            End If
        End Sub

        Public Sub RefreshList(Optional ByVal rebind As Boolean = False)
            DataTable = New ds_Types.ServiceTypesListDataTable
            TableAdapater = New ds_TypesTableAdapters.ServiceTypesListTableAdapter
            ' fill table
            TableAdapater.Fill(DataTable)

            If (rebind = True) Then
                ' bind
                Me.DataSource = DataTable
                Me.DisplayMember = "ServiceName"
                Me.ValueMember = "ServiceTypeID"
            End If
        End Sub

        ' NEED TO SEE IF ABOVE SUB FIRES THIS SO I DONT NEED TO RAISE THE EVENT THERE
        Private Sub ChangeCommited() Handles Me.SelectionChangeCommitted
            GetRate()
            GetLength()
            RaiseEvent ServiceChanged(CInt(Me.SelectedValue), _rate, _length)
        End Sub
    End Class

    Public Class cmb_BadCheckBanks
        Inherits ComboBox

        ReadOnly _dt As DataSet.BanksListDataTable
        ReadOnly _ta As DataSetTableAdapters.BanksListTableAdapter

        Public Sub New()
            _dt = New DataSet.BanksListDataTable
            _ta = New DataSetTableAdapters.BanksListTableAdapter

            _ta.Fill(_dt)

            ' bind
            Me.DataSource = _dt
            Me.DisplayMember = "BANK_NAME"
            Me.ValueMember = "BC_BANK_ID"
        End Sub
    End Class

    Public Class cmb_Users
        Inherits ComboBox

        Private ReadOnly _dt As ds_Program.USERSDataTable
        Private ReadOnly _ta As ds_ProgramTableAdapters.USERSTableAdapter

        Public Sub New()
            _ta = New ds_ProgramTableAdapters.USERSTableAdapter
            _dt = _ta.GetUsersList

            Me.DisplayMember = "USER_NAME"
            Me.ValueMember = "USER_UD"
            Me.DataSource = _dt
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

        ReadOnly _dt As Report_DataSet.BatchPayments_ListDataTable
        ReadOnly _ta As Report_DataSetTableAdapters.BatchPayments_ListTableAdapter

        Public Sub New()
            _dt = New Report_DataSet.BatchPayments_ListDataTable
            _ta = New Report_DataSetTableAdapters.BatchPayments_ListTableAdapter

            _ta.Fill(_dt)

            Me.DataSource = _dt
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