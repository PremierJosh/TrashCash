
Namespace Classes.CustomerToolstrip
    Public Class CustomerToolstrip
        Inherits ToolStrip

        ' properties
        Public ReadOnly Property CurrentCustomer As Integer
            Get
                Return CustComboBox.ComboBox.SelectedValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return CustComboBox.ToString()
        End Function

        'event
        Friend Event CustomerChanging(ByVal customerNumber As Integer)

        ' sub to change customer
        Friend Sub SelectCustomer(ByVal customerNumber As Integer, Optional ByVal wEvent As Boolean = False)
            CustComboBox.SelectedValue = customerNumber
            ' clear quicksearch text
            QuickSearch.Text = ""
            If (wEvent) Then
                RaiseEvent CustomerChanging(CurrentCustomer)
            End If
            ' get new balance
            GetCustomerBalance()
        End Sub

        ' handles when cmb box selection changes
        Private Sub CustomerChanged(ByVal customerNumber As Integer, ByVal e As EventArgs) Handles CustComboBox.SelectionChangeCommitted
            RaiseEvent CustomerChanging(customerNumber)
            GetCustomerBalance()
        End Sub
        ' handles when enter is pressed in the quick search tb
        Private Sub QuickSearchEnterKey() Handles QuickSearch.EnterPressed
            GetCustomerBalance(CurrentCustomer)
            RaiseEvent CustomerChanging(CurrentCustomer)
        End Sub

        ' balance setting
        Private ReadOnly _ta As ds_CustomerTableAdapters.QueriesTableAdapter
        Private _lastFetchedBalance As Double
        Friend Sub GetCustomerBalance(Optional ByRef returnVal As Double = Nothing)
            ' getting queue amount
            Dim queueAmount As Double = _ta.Customer_PaymentTotalInQueue(CurrentCustomer)

            ' getting quickbooks balance
            Dim qbBalance As Double = GlobalConMgr.GetCustomerBalance(GetCustomerListID(CurrentCustomer))
            _lastFetchedBalance = qbBalance
            If (returnVal <> Nothing) Then
                returnVal = qbBalance
            End If

            ' set balance labels
            _lblCustBalanceAmount.Text = FormatCurrency(qbBalance)

            ' coloring balance label
            If (qbBalance <= 0) Then
                _lblCustBalanceAmount.ForeColor = Color.Green
            Else
                _lblCustBalanceAmount.ForeColor = Color.Red
            End If

            ' coloring and showing queue label
            If (queueAmount > 0) Then
                ' show queue controls
                _sepQueue.Visible = True
                _lblQueueHeader.Visible = True
                _lblQueueAmount.Visible = True
                ' show adjusted controls
                _sepAdjustedBal.Visible = True
                _lblAdjustedBalHeader.Visible = True
                _lblAdjustedBalAmount.Visible = True

                ' set queue amount
                _lblQueueAmount.Text = FormatCurrency(queueAmount)

                ' get adjusted amount
                Dim adjustedBalance As Double = qbBalance - queueAmount
                _lblAdjustedBalAmount.Text = FormatCurrency(adjustedBalance)

                ' coloring
                If (adjustedBalance <= 0) Then
                    _lblAdjustedBalAmount.ForeColor = Color.Green
                Else
                    _lblAdjustedBalAmount.ForeColor = Color.Red
                End If

                ' shrink cmb_Customer
                CustComboBox.Size = New Size(275, 25)
            Else
                ' hide queue controls
                _sepQueue.Visible = False
                _lblQueueHeader.Visible = False
                _lblQueueAmount.Visible = False
                ' hide adjusted controls
                _sepAdjustedBal.Visible = False
                _lblAdjustedBalHeader.Visible = False
                _lblAdjustedBalAmount.Visible = False

                ' grow cmb_Customer
                CustComboBox.Size = New Size(350, 25)
            End If
        End Sub

        Friend Sub GetQueueAmount(Optional ByRef returnVal As Double = Nothing)
            ' getting queue amount
            Dim queueAmount As Double = _ta.Customer_PaymentTotalInQueue(CurrentCustomer)

            ' coloring and showing queue label
            If (queueAmount > 0) Then
                ' show queue controls
                _sepQueue.Visible = True
                _lblQueueHeader.Visible = True
                _lblQueueAmount.Visible = True
                ' show adjusted controls
                _sepAdjustedBal.Visible = True
                _lblAdjustedBalHeader.Visible = True
                _lblAdjustedBalAmount.Visible = True

                ' set queue amount
                _lblQueueAmount.Text = FormatCurrency(queueAmount)

                ' get adjusted amount
                Dim adjustedBalance As Double = _lastFetchedBalance - queueAmount
                _lblAdjustedBalAmount.Text = FormatCurrency(adjustedBalance)

                ' coloring
                If (adjustedBalance <= 0) Then
                    _lblAdjustedBalAmount.ForeColor = Color.Green
                Else
                    _lblAdjustedBalAmount.ForeColor = Color.Red
                End If

                ' shrink cmb_Customer
                CustComboBox.Size = New Size(275, 25)
            Else
                ' hide queue controls
                _sepQueue.Visible = False
                _lblQueueHeader.Visible = False
                _lblQueueAmount.Visible = False
                ' hide adjusted controls
                _sepAdjustedBal.Visible = False
                _lblAdjustedBalHeader.Visible = False
                _lblAdjustedBalAmount.Visible = False

                ' grow cmb_Customer
                CustComboBox.Size = New Size(350, 25)
            End If
        End Sub

        Public Sub HideQuickSearch(Optional ByVal unHide As Boolean = False)
            ' hiding quick search tb, its label, and the left seperator
            _lblQuickSearch.Visible = unHide
            _sepQuickSearch.Visible = unHide
            QuickSearch.Visible = unHide
        End Sub

        Public Sub RefreshCustomerList()
            CustComboBox.RefreshCustomerList()
        End Sub

        ' customer combo box and seperator
        Friend WithEvents CustComboBox As CustComboBox

        ' quicksearch label, box, and seperator
        Private ReadOnly _sepQuickSearch As New ToolStripSeparator
        Private ReadOnly _lblQuickSearch As New ToolStripLabel
        Friend WithEvents QuickSearch As QuickSearch

        ' customer balance header, amount, and seperator
        Private ReadOnly _sepCustBalance As New ToolStripSeparator
        Private ReadOnly _lblCustBalanceHeader As New ToolStripLabel
        Private ReadOnly _lblCustBalanceAmount As New ToolStripLabel

        ' payments in queue header, amount, and seperator
        Private ReadOnly _sepQueue As New ToolStripSeparator
        Private ReadOnly _lblQueueHeader As New ToolStripLabel
        Private ReadOnly _lblQueueAmount As New ToolStripLabel

        ' adjusted balance header and amount - no seperator (end of toolstrip)
        Private ReadOnly _sepAdjustedBal As New ToolStripSeparator
        Private ReadOnly _lblAdjustedBalHeader As New ToolStripLabel
        Private ReadOnly _lblAdjustedBalAmount As New ToolStripLabel

        Public Sub New()
            MyBase.New()
            _ta = New ds_CustomerTableAdapters.QueriesTableAdapter

            ' customer combo box and seperator
            CustComboBox = New CustComboBox
            Items.Add(CustComboBox)
            
            ' quicksearch label, box, and seperator
            Items.Add(_sepQuickSearch)
            _lblQuickSearch.Text = "QuickSearch:"
            Items.Add(_lblQuickSearch)
            QuickSearch = New QuickSearch
            Items.Add(QuickSearch)

            ' cust balance header, amount, and seperator
            Items.Add(_sepCustBalance)
            _lblCustBalanceHeader.Text = "Balance:"
            Items.Add(_lblCustBalanceHeader)
            Items.Add(_lblCustBalanceAmount)

            ' in queue header, amount, and seperator
            Items.Add(_sepQueue)
            _lblQueueHeader.Text = "In Queue:"
            Items.Add(_lblQueueHeader)
            _lblQueueAmount.ForeColor = Color.Green
            Items.Add(_lblQueueAmount)

            ' adjusted balance header, amount, and seperator
            Items.Add(_sepAdjustedBal)
            _lblAdjustedBalHeader.Text = "Adjusted:"
            Items.Add(_lblAdjustedBalHeader)
            Items.Add(_lblAdjustedBalAmount)

            'set visuals
            GripStyle = ToolStripGripStyle.Hidden
            Dock = DockStyle.Fill
            CustComboBox.SelectedText = Nothing

        End Sub

        ' these subs catch search events from the tb
        Private Sub SearchByNumber(ByVal int As Integer) Handles QuickSearch.NumberSearch
            CustComboBox.Search_Number(int)
        End Sub
        Private Sub SearchByName(ByVal str As String) Handles QuickSearch.NameSearch
            CustComboBox.Search_CustName(str)
        End Sub
    End Class
End Namespace