Public Class cmb_ReportType
    Inherits ComboBox

    Protected dt As DataTable

    Public Sub New()
        ' drop down list style has no text entry
        'Me.DropDownStyle = ComboBoxStyle.DropDownList
        Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems

        ' new dt
        dt = BuildDT()

        ' bind
        Me.DataSource = dt
        Me.DisplayMember = "ReportName"
        Me.ValueMember = "ReportID"
    End Sub

    Private Function BuildDT()
        Dim _dt As New DataTable

        ' set columns
        _dt.Columns.Add("ReportName", GetType(String))
        _dt.Columns.Add("ReportID", GetType(Integer))

        ' add row1 for all customers with balance
        Dim row1 As DataRow = _dt.NewRow
        row1.Item("ReportName") = "Customers with Balance"
        row1.Item("ReportID") = 1
        _dt.Rows.Add(row1)

        'add row2 for payments on a date
        Dim row2 As DataRow = _dt.NewRow
        row2.Item("ReportName") = "Payments Received on Date"
        row2.Item("ReportID") = 2
        _dt.Rows.Add(row2)

        'add row3 for payments between 2 dates
        Dim row3 As DataRow = _dt.NewRow
        row3.Item("ReportName") = "Payments Received between Dates"
        row3.Item("ReportID") = 3
        _dt.Rows.Add(row3)

        _dt.AcceptChanges()

        Return _dt
    End Function

End Class
