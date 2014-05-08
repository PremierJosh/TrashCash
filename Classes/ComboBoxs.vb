Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel.Component

Public Class CustomerComboBox
    Inherits ComboBox

    ' events
    Public Event Message(ByVal message As String)
    Public Event CustomerChanged(ByVal SelectedValue As Decimal)

    ' custList dt and ta
    Private dt As New DataSet.CustomerListDataTable
    Private ta As New DataSetTableAdapters.CustomerListTableAdapter

    Public Sub New()
        ' init
        MyBase.new()
        ta.ClearBeforeFill = True

        ' drop down list style has no text entry
        Me.DropDownStyle = ComboBoxStyle.DropDownList

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
    End Sub

    ''' <summary>
    ''' Fills the comboBox with All Customers
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllCustomers()
        ' get all customers
        ta.FillWithAll(dt)
    End Sub

    ''' <summary>
    ''' Fills the comboBox with all Customers whos FullName 'LIKE' value
    ''' </summary>
    ''' <param name="search"></param>
    ''' <remarks></remarks>
    Public Sub SearchbyName(ByVal search As String)
        ta.FillBySearchedCustName(dt, search, False)
        RaiseEvent Message(SearchResultMessage(dt, "Customer"))
    End Sub

    ''' <summary>
    ''' Fills the comboBox with all Customers whos BillAddr1 'LIKE' value
    ''' </summary>
    ''' <param name="search"></param>
    ''' <remarks></remarks>
    Public Sub SearchByAddress(ByVal search As String)
        ta.FillBySearchedAddress(dt, search, False)
        RaiseEvent Message(SearchResultMessage(dt, "Customer"))
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
        Else
            RaiseEvent Message("Make sure your search is just a number.")
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
    Public Event ServiceChanged(ByVal ServiceID As Decimal, ByVal Rate As Double)

    ' property
    Private rate As New Decimal
    ReadOnly Property SelectedServiceRate
        Get
            GetRate()
            Return rate
        End Get
    End Property

    ' custList dt and ta
    Private dt As New DataSet.ServiceTypesListDataTable
    Private ta As New DataSetTableAdapters.ServiceTypesListTableAdapter

    Public Sub New()
        ' init
        MyBase.new()
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
    ' NEED TO SEE IF ABOVE SUB FIRES THIS SO I DONT NEED TO RAISE THE EVENT THERE
    Private Sub ChangeCommited() Handles Me.SelectionChangeCommitted
        GetRate()
        RaiseEvent ServiceChanged(Me.SelectedValue, rate)
    End Sub

End Class




Public Class RecurringServiceComboBox
    Inherits ComboBox

    ' events
    Public Event RecSrvcChanged(ByVal SelectedValue As Decimal)

    ' custList dt and ta
    Private dt As New DataSet.RecurringServiceListDataTable
    Private ta As New DataSetTableAdapters.RecurringServiceListTableAdapter

    Public Sub New()
        ' init
        MyBase.new()
        ta.ClearBeforeFill = True

        ' drop down list style has no text entry
        Me.DropDownStyle = ComboBoxStyle.DropDownList

        ' bind
        Me.DataSource = dt
        Me.DisplayMember = "Service"
        Me.ValueMember = "RecurringServiceID"
    End Sub

    Public Sub Load(ByVal custNum As Integer, ByVal srvcState As String)
        ta.Fill(dt, custNum, srvcState)
        If (dt.Rows.Count = 0) Then
            Me.Enabled = False
        End If
    End Sub

    Private Sub ChangeCommited() Handles Me.SelectedValueChanged
        RaiseEvent RecSrvcChanged(Me.SelectedValue)
    End Sub

End Class
