'Imports TrashCash.QB_Queries
Imports System.Windows.Forms

Public Class ts_M_Customer
    Inherits ToolStrip

    ' properties
    Private _currentCustomer As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            If (_currentCustomer <> value) Then
                ' checking if combo box has items
                If (cmb_Customer.Items.Count = 0) Then
                    cmb_Customer.RefreshCustomerList(True)
                End If

                ' update combo box selection if not selected
                If (cmb_Customer.ComboBox.SelectedValue <> value) Then
                    cmb_Customer.ComboBox.SelectedValue = value
                End If
                _currentCustomer = value
                ' get balance
                GetCustomerBalance()
            End If
        End Set
    End Property

    Public ReadOnly Property CurrentCustomerName As String
        Get
            If (cmb_Customer.SelectedItem IsNot Nothing) Then
                Return cmb_Customer.ComboBox.GetItemText(cmb_Customer.SelectedItem)
            Else
                Return ""
            End If
        End Get
    End Property

    Private _homeForm As TrashCashHome
    Public Property HomeForm As TrashCashHome
        Get
            Return _homeForm
        End Get
        Set(value As TrashCashHome)
            _homeForm = value
        End Set
    End Property

    'event
    Public Event CustomerChanging(ByVal CustomerNumber As Integer)

    ' vars
    Private c_qta As New ds_CustomerTableAdapters.QueriesTableAdapter

    ' handles when cmb box selection changes
    Private Sub CustomerChanged(ByVal CustomerNumber As Integer, ByVal e As System.EventArgs) Handles cmb_Customer._SelectionChangeCommitted
        CurrentCustomer = CustomerNumber
        RaiseEvent CustomerChanging(CustomerNumber)
    End Sub
    ' handles when enter is pressed in the quick search tb
    Private Sub QuickSearchEnterKey() Handles tb_QuickSearch.EnterPressed
        If (cmb_Customer.ComboBox.Text <> "") Then
            'If (cmb_Customer.ComboBox.SelectedValue <> CurrentCustomer) Then
            CurrentCustomer = CInt(cmb_Customer.ComboBox.SelectedValue)
            RaiseEvent CustomerChanging(CurrentCustomer)
            'End If
        End If
    End Sub

    ' balance setting
    Friend Sub GetCustomerBalance()
        ' getting queue amount
        Dim QueueAmount As Double = c_qta.Customer_PaymentTotalInQueue(CurrentCustomer)

        ' getting quickbooks balance
        Dim QBBalance As Double = HomeForm.Queries.Customer_Balance(CurrentCustomer)

        ' set balance labels
        lbl_CustBalance.Text = FormatCurrency(QBBalance)
        lbl_QueueAmount.Text = FormatCurrency(QueueAmount)
        lbl_QueueAmount.ForeColor = Color.Green

        ' coloring balance label
        If (QBBalance <= 0) Then
            lbl_CustBalance.ForeColor = Color.Green
        Else
            lbl_CustBalance.ForeColor = Color.Red
        End If

        ' coloring and showing queue label
        If (QueueAmount > 0) Then
            ' show queue controls
            sep_QueueAmount.Visible = True
            lbl_QueueHeader.Visible = True
            lbl_QueueAmount.Visible = True
            ' show adjusted controls
            sep_AdjustedBal.Visible = True
            lbl_AdjustedBalHeader.Visible = True
            lbl_AdjustedBalAmount.Visible = True

            ' set queue amount
            lbl_QueueAmount.Text = FormatCurrency(QueueAmount)

            ' get adjusted amount
            Dim adjustedBalance As Double = QBBalance - QueueAmount
            lbl_AdjustedBalAmount.Text = FormatCurrency(adjustedBalance)

            ' coloring
            If (adjustedBalance <= 0) Then
                lbl_AdjustedBalAmount.ForeColor = Color.Green
            Else
                lbl_AdjustedBalAmount.ForeColor = Color.Red
            End If
        Else
            ' hide queue controls
            sep_QueueAmount.Visible = False
            lbl_QueueHeader.Visible = False
            lbl_QueueAmount.Visible = False
            ' hide adjusted controls
            sep_AdjustedBal.Visible = False
            lbl_AdjustedBalHeader.Visible = False
            lbl_AdjustedBalAmount.Visible = False
        End If
    End Sub

    Public Sub HideQuickSearch()
        ' hiding quick search tb, its label, and the left seperator
        lbl_Quicksearch.Visible = False
        sep_QuickSearch.Visible = False
        tb_QuickSearch.Visible = False
    End Sub

    Public Sub RefreshCustomerList()
        cmb_Customer.RefreshCustomerList()
    End Sub
    Public Sub SelectCustWithEvent(ByVal customerNumber As Integer)
        CurrentCustomer = customerNumber
        RaiseEvent CustomerChanging(customerNumber)
    End Sub

    ' ts controls that sit on this ts
    Friend WithEvents cmb_Customer As ts_cmb_Customer
    Friend WithEvents tb_QuickSearch As ts_tb_QuickSearch
    Friend WithEvents lbl_CustBalance As ToolStripLabel
    Friend WithEvents lbl_QueueAmount As ToolStripLabel

    ' adjusted amount label, header, and seperator
    Friend WithEvents lbl_AdjustedBalHeader As ToolStripLabel
    Friend WithEvents lbl_AdjustedBalAmount As ToolStripLabel
    Friend WithEvents sep_AdjustedBal As ToolStripSeparator

    ' controls i may want to hide
    ' label for quicksearch
    Friend WithEvents lbl_Quicksearch As ToolStripLabel
    Friend WithEvents lbl_QueueHeader As ToolStripLabel

    ' seperateor after quicksearch tb
    Private sep_QuickSearch As ToolStripSeparator
    Private sep_QueueAmount As ToolStripSeparator

    Public Sub New()
        MyBase.New()

        cmb_Customer = New ts_cmb_Customer
        tb_QuickSearch = New ts_tb_QuickSearch
        lbl_CustBalance = New ToolStripLabel
        sep_QuickSearch = New ToolStripSeparator

        ' adjusted balance items
        lbl_AdjustedBalHeader = New ToolStripLabel
        lbl_AdjustedBalHeader.Text = "Adjusted:"
        lbl_AdjustedBalAmount = New ToolStripLabel
        sep_AdjustedBal = New ToolStripSeparator

        ' in queue items
        lbl_QueueAmount = New ToolStripLabel
        lbl_QueueHeader = New ToolStripLabel
        lbl_QueueHeader.Text = "In Queue:"
        sep_QueueAmount = New ToolStripSeparator

        lbl_Quicksearch = New ToolStripLabel
        lbl_Quicksearch.Text = "QuickSearch:"
        ' balance label needs to align right
        Dim balanceHeader As New ToolStripLabel
        balanceHeader.Text = "Balance:"

        'set visuals
        Me.GripStyle = ToolStripGripStyle.Hidden
        'Me.Dock = DockStyle.Fill
        Me.Items.AddRange(New ToolStripItem() {cmb_Customer, New ToolStripSeparator, lbl_Quicksearch, tb_QuickSearch, sep_QuickSearch, balanceHeader, lbl_CustBalance, sep_QueueAmount, lbl_QueueHeader, lbl_QueueAmount, sep_AdjustedBal, lbl_AdjustedBalHeader, lbl_AdjustedBalAmount})

        ' resize cmb_Customer
        cmb_Customer.Size = New Size(275, 25)
    End Sub

    ' these subs catch search events from the tb
    Private Sub SearchByNumber(ByVal int As Integer) Handles tb_QuickSearch.NumberSearch
        cmb_Customer.Search_Number(int)
    End Sub
    Private Sub SearchByName(ByVal str As String) Handles tb_QuickSearch.NameSearch
        cmb_Customer.Search_CustName(str)
    End Sub
End Class

Friend Class ts_cmb_Customer
    Inherits System.Windows.Forms.ToolStripComboBox

    Protected _dv As DataView

    Protected dt As ds_Customer.Customer_ListByActiveDataTable
    Protected ta As ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter

    Friend Sub Search_CustName(ByVal sStr As String)
        Dim cString As String
        cString = "CustomerFullName LIKE '%" & sStr & "%'"
        _dv.RowFilter = cString
    End Sub

    Friend Sub Search_Number(ByVal number As Integer)
        Dim cString As String
        cString = "CustomerNumber = " & number
        _dv.RowFilter = cString
    End Sub

    Public Event _SelectionChangeCommitted(ByVal CustomerNumber As Integer, ByVal e As System.EventArgs)
    Protected Overrides Sub OnSelectionChangeCommitted(ByVal e As System.EventArgs)
        MyBase.OnSelectionChangeCommitted(e)
        RaiseEvent _SelectionChangeCommitted(CInt(Me.ComboBox.SelectedValue), e)
    End Sub

    Public Sub New()

        ' set key bind catches to quick select from list
        Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
        'Me.Width = 200

        ' instantiate dt and ta
        dt = New ds_Customer.Customer_ListByActiveDataTable
        ta = New ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter

        ' set dataview
        _dv = New DataView
        _dv.Table = dt

        ' fill dt
        ta.Fill(dt, False)

        ' bind
        'Me.ComboBox.DataBindings.Add("DisplayMember", _dv, "CustomerFullName")
        'Me.ComboBox.DataBindings.Add("ValueMember", _dv, "CustomerNumber")
        Me.ComboBox.DataSource = _dv
        Me.ComboBox.DisplayMember = "CustomerFullName"
        Me.ComboBox.ValueMember = "CustomerNumber"
    End Sub

    Friend Sub RefreshCustomerList(Optional ByVal Rebind As Boolean = False)
        If (Rebind = True) Then
            ' instantiate dt and ta
            dt = New ds_Customer.Customer_ListByActiveDataTable
            ta = New ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter

            ' set dataview
            _dv = New DataView
            _dv.Table = dt

            ' fill dt
            ta.Fill(dt, False)

            ' bind
            'Me.ComboBox.DataBindings.Add("DisplayMember", _dv, "CustomerFullName")
            'Me.ComboBox.DataBindings.Add("ValueMember", _dv, "CustomerNumber")
            Me.ComboBox.DataSource = _dv
            Me.ComboBox.DisplayMember = "CustomerFullName"
            Me.ComboBox.ValueMember = "CustomerNumber"
        Else
            ' fill dt
            ta.Fill(dt, False)
        End If
    End Sub
End Class

Friend Class ts_tb_QuickSearch
    'Inherits MaskedTextBox
    Inherits ToolStripTextBox

    Protected lastEventTime As DateTime
    Protected elapsedTime As Double

    Friend Event NameSearch(ByVal str As String)
    Friend Event NumberSearch(ByVal number As Integer)
    Friend Event EnterPressed()


    Public Sub New()
        lastEventTime = Now
        elapsedTime = 500
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub ts_tb_QuickSearch_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            RaiseEvent EnterPressed()
        End If
    End Sub

    Private Sub tb_QuickCustNumSearch_TextChanged(sender As Object, e As System.EventArgs) Handles Me.TextChanged
        If (Now > lastEventTime.AddMilliseconds(elapsedTime)) Then
            Dim int As Integer
            Dim isInt As Boolean = Integer.TryParse(Me.Text, int)
            If (isInt) Then
                RaiseEvent NumberSearch(int)
            Else
                RaiseEvent NameSearch(Me.Text)
            End If
        End If
    End Sub
End Class

