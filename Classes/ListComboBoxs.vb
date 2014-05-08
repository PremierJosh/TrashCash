Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel.Component

Public Class CustomerComboBox
    Inherits ComboBox

    ' events
    Public Event Message(ByVal message As String)
    Public Event CustomerChanged(ByVal SelectedValue As Decimal)
    Public Event ListActiveStateChange(ByVal ActiveOnly As Boolean)

    ' custList dt and ta
    Private dt As DataSet.CustomerListDataTable
    Private ta As DataSetTableAdapters.CustomerListTableAdapter

    Public Sub New()
        dt = New DataSet.CustomerListDataTable
        ta = New DataSetTableAdapters.CustomerListTableAdapter

        ' init
        'MyBase.new()
        ta.ClearBeforeFill = True

        ' drop down list style has no text entry
        'Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems

        ' itinital fill
        'ActiveOnly()

        ' bind
        Me.DataSource = dt
        Me.DisplayMember = "CustomerFullName"
        Me.ValueMember = "CustomerNumber"
    End Sub

    ''' <summary>
    ''' Fills the comboBox with Active Customers
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActiveOnly()
        ' get active customers
        ta.FillByActive(dt)
        RaiseEvent ListActiveStateChange(True)
    End Sub
    ' throws a customer change event as well
    Public Sub CheckBox_ActiveOnly()
        ' get active customers
        ta.FillByActive(dt)
        RaiseEvent ListActiveStateChange(True)
        RaiseEvent CustomerChanged(Me.SelectedValue)
    End Sub

    ''' <summary>
    ''' Fills the comboBox with All Customers
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllCustomers()
        ' get all customers
        ta.FillWithAll(dt)
        RaiseEvent ListActiveStateChange(False)
    End Sub
    ' throws a customer change event as well
    Public Sub CheckBox_AllCustomers()
        ' get active customers
        ta.FillWithAll(dt)
        RaiseEvent ListActiveStateChange(True)
        RaiseEvent CustomerChanged(Me.SelectedValue)
    End Sub

    ''' <summary>
    ''' Fills the comboBox with all Customers whos FullName 'LIKE' value
    ''' </summary>
    ''' <param name="search"></param>
    ''' <remarks></remarks>
    Public Sub SearchbyName(ByVal search As String)
        ta.FillBySearchedCustName(dt, search, False)
        RaiseEvent Message(SearchResultMessage(dt, "Customer"))
        If (dt.Rows.Count > 0) Then
            RaiseEvent CustomerChanged(Me.SelectedValue)
        End If
    End Sub

    ''' <summary>
    ''' Fills the comboBox with all Customers whos BillAddr1 'LIKE' value
    ''' </summary>
    ''' <param name="search"></param>
    ''' <remarks></remarks>
    Public Sub SearchByAddress(ByVal search As String)
        ta.FillBySearchedAddress(dt, search, False)
        RaiseEvent Message(SearchResultMessage(dt, "Customer"))
        If (dt.Rows.Count > 0) Then
            RaiseEvent CustomerChanged(Me.SelectedValue)
        End If
    End Sub

    ''' <summary>
    ''' Fills the comboBox with all Customers whos CustomerNumber = '%' value '%'
    '''  and will throw an erorr if value doesn't contain a decimal
    ''' </summary>
    ''' <param name="search"></param>
    ''' <remarks></remarks>
    Public Sub SearchByNumber(ByVal search As String)
        Dim number As Decimal

        If (Decimal.TryParse(search, number) = True) Then
            ta.FillBySearchedCustNum(dt, number, False)
            RaiseEvent Message(SearchResultMessage(dt, "Customer"))
            If (dt.Rows.Count > 0) Then
                RaiseEvent CustomerChanged(Me.SelectedValue)
            End If
        Else
            RaiseEvent Message("You must search for a Customer Number")
        End If
    End Sub

    ''' <summary>
    ''' Sets the SelectedValue to custNum, and if they are not in the list,
    '''  it will load All Customers and then select it
    ''' </summary>
    ''' <param name="custNum"></param>
    ''' <remarks></remarks>
    Public Sub SelectCustomer(ByVal custNum As Decimal)
        If (dt.Rows.Count = 0) Then
            ActiveOnly()
        End If
        Me.SelectedValue = custNum

        If (Me.SelectedIndex = -1) Then
            AllCustomers()
            Me.SelectedValue = custNum
        End If
    End Sub

    Private Sub ValueChanged() Handles Me.SelectionChangeCommitted
        RaiseEvent CustomerChanged(Me.SelectedValue)
    End Sub

    Private Function SearchResultMessage(ByRef dt As DataTable, ByVal item As String) As String
        Dim resultString As String
        If (dt.Rows.Count > 1) Then
            resultString = dt.Rows.Count.ToString & item & "s found."
        ElseIf (dt.Rows.Count = 1) Then
            resultString = "1 " & item & " found."
        Else
            resultString = "No " & item & "s found."
        End If

        Return resultString
    End Function

End Class




Public Class ServiceTypesComboBox
    Inherits ComboBox

    ' events
    Public Event ServiceChanged(ByVal ServiceID As Decimal, ByVal Rate As Double, ByVal BillLength As Integer)

    ' property
    Private rate As New Decimal
    Private length As Integer
    ReadOnly Property SelectedServiceRate
        Get
            GetRate()
            Return rate
        End Get
    End Property
    ReadOnly Property SelectedServiceLength
        Get
            GetLength()
            Return length
        End Get
    End Property

    ' custList dt and ta
    Private dt As New DataSet.ServiceTypesListDataTable
    Private ta As New DataSetTableAdapters.ServiceTypesListTableAdapter

    Public Sub New()
        ' init
        'MyBase.new()
        ta.ClearBeforeFill = True

        ' drop down list style has no text entry
        Me.DropDownStyle = ComboBoxStyle.DropDownList

        ' fill table
        ta.Fill(dt)

        ' bind
        Me.DataSource = dt
        Me.DisplayMember = "ServiceName"
        Me.ValueMember = "ServiceTypeID"
    End Sub

    ''' <summary>
    ''' This will select the item with a ValueMember of srvcID
    ''' </summary>
    ''' <param name="srvcID"></param>
    ''' <remarks></remarks>
    Public Sub SelectService(ByVal srvcID As Integer)
        Me.SelectedValue = srvcID
        'RaiseEvent ServiceChanged(Me.SelectedValue, dt.FindByServiceTypeID(srvcID).ServiceRate)
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
    ' NEED TO SEE IF ABOVE SUB FIRES THIS SO I DONT NEED TO RAISE THE EVENT THERE
    Private Sub ChangeCommited() Handles Me.SelectionChangeCommitted
        GetRate()
        GetLength()
        RaiseEvent ServiceChanged(Me.SelectedValue, rate, length)
    End Sub

End Class

Public Class PaymentTypesComboBox
    Inherits ComboBox

    Dim dt As New DataSet.PaymentTypesDataTable
    Dim ta As New DataSetTableAdapters.PaymentTypesTableAdapter

    Public Sub New()
        ta.Fill(dt)

        ' drop down list style has no text entry
        Me.DropDownStyle = ComboBoxStyle.DropDownList

        ' bind
        Me.DataSource = dt
        Me.DisplayMember = "PaymentTypeName"
        Me.ValueMember = "PaymentTypeID"
    End Sub

End Class

Public Class BankListComboBox
    'Inherits ToolStripComboBox
    Inherits ComboBox

    Dim dt As DataSet.BanksListDataTable
    Dim ta As DataSetTableAdapters.BanksListTableAdapter

    Public Sub New()
        dt = New DataSet.BanksListDataTable
        ta = New DataSetTableAdapters.BanksListTableAdapter

        ta.Fill(dt)

        ' drop down style
        Me.DropDownStyle = ComboBoxStyle.DropDownList

        ' bind
        Me.DataSource = dt
        Me.DisplayMember = "BANK_NAME"
        Me.ValueMember = "BC_BANK_ID"
    End Sub
End Class

Public Class BankListToolstripComboBox
    Inherits ToolStripComboBox
    'Inherits ComboBox

    Dim dt As DataSet.BanksListDataTable
    Dim ta As DataSetTableAdapters.BanksListTableAdapter

    Public Sub New()
        dt = New DataSet.BanksListDataTable
        ta = New DataSetTableAdapters.BanksListTableAdapter

        ta.ClearBeforeFill = True
        ta.Fill(dt)

        ' drop down style
        Me.DropDownStyle = ComboBoxStyle.DropDownList

        ' bind
        Me.ComboBox.DataSource = dt
        Me.ComboBox.DisplayMember = "BANK_NAME"
        Me.ComboBox.ValueMember = "BC_BANK_ID"
    End Sub

    Public Sub Refresh()
        ta.Fill(dt)
    End Sub
End Class




'Public Class QBAccountItem
'    Private _displayName As String
'    Private _listID As String

'    Public Property listID
'        Get
'            Return _listID.ToString
'        End Get
'        Set(value)
'            _listID = value
'        End Set
'    End Property

'    Public Property displayName
'        Get
'            Return _displayName.ToString
'        End Get
'        Set(value)
'            _displayName = value
'        End Set
'    End Property
'End Class
