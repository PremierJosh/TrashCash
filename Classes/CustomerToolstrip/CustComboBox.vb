Namespace Classes.CustomerToolstrip
    Friend Class CustComboBox
        Inherits Windows.Forms.ToolStripComboBox

        Private ReadOnly _dv As DataView

        Private ReadOnly _dt As ds_Customer.Customer_ListByActiveDataTable
        Private ReadOnly _ta As ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter

        Friend Property SelectedValue As Integer
            Get
                Return ComboBox.SelectedValue
            End Get
            Set(value As Integer)
                ' clear dv filter
                _dv.RowFilter = ""
                ComboBox.SelectedValue = value
            End Set
        End Property

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

        Friend Event SelectionChangeCommitted(ByVal customerNumber As Integer, ByVal e As EventArgs)
        Protected Overrides Sub OnSelectionChangeCommitted(ByVal e As EventArgs)
           RaiseEvent SelectionChangeCommitted(CInt(ComboBox.SelectedValue), e)
        End Sub

        Public Overrides Function ToString() As String
            Return ComboBox.GetItemText(SelectedItem)
        End Function

        Public Sub New()
            
            ' set key bind catches to quick select from list
            AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
            AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
           
            ' instantiate dt and ta
            _dt = New ds_Customer.Customer_ListByActiveDataTable
            _ta = New ds_CustomerTableAdapters.Customer_ListByActiveTableAdapter

            ' set dataview
            _dv = New DataView
            _dv.Table = _dt

            ' fill dt
            _ta.Fill(_dt, False)

            ' bind
            ComboBox.DataSource = _dv
            ComboBox.DisplayMember = "CustomerFullName"
            ComboBox.ValueMember = "CustomerNumber"
        End Sub

        Friend Sub RefreshCustomerList()
           _ta.Fill(_dt, False)
        End Sub
    End Class
End Namespace