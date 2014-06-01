Imports TrashCash.Classes


Module AppModule
    Public GlobalConMgr As QBConMgr
    ' useful vars all forms will use
    Public CurrentUser As ds_Application.USERSRow

    Public ReadOnly UserTA As New ds_ApplicationTableAdapters.USERSTableAdapter
    Public ReadOnly AppQTA As New ds_ApplicationTableAdapters.QueriesTableAdapter
    Public ReadOnly CustTA As New ds_CustomerTableAdapters.CustomerTableAdapter

    ''' <summary>
    ''' Takes a QBConMgr param passed and returns it if not nothing, else return GlobalQBConMgr
    ''' </summary>
    ''' <param name="paramConMgr"></param>
    ''' <returns>Valid QBConMgr</returns>
    ''' <remarks>
    ''' i felt like this was a necessary simple function that will easily allow me to
    ''' cut out this code every time and i can even append a . to access to result without
    ''' having to carry it
    ''' </remarks>
    Public Function ConCheck(ByRef paramConMgr As QBConMgr) As QBConMgr
        If (paramConMgr Is Nothing) Then
            Return GlobalConMgr
        End If
        Return paramConMgr
    End Function

    Public Function GetCustomerListID(ByVal customerNumber As Integer) As String
        Return CustTA.GetListID(customerNumber)
    End Function

    Public Function PhoneFormat(ByVal strPhoneNumber As String) As String
        ' Remove any style characters from the user input
        strPhoneNumber = Replace(strPhoneNumber, ")", "")
        strPhoneNumber = Replace(strPhoneNumber, "(", "")
        strPhoneNumber = Replace(strPhoneNumber, "-", "")
        strPhoneNumber = Replace(strPhoneNumber, ".", "")
        strPhoneNumber = Replace(strPhoneNumber, Space(1), "")

        Dim strFormatedNumber As String = CLng(strPhoneNumber).ToString("(###) ###-####")
        Return strFormatedNumber
    End Function

    ' enumerated item status from database
    Enum ENItemStatus As Int32
        Ready = 5
        Err = 6
        Complete = 7
        Submitted = 8
    End Enum

    ' global colors for app
    Public Class AppColors
        ' grid colors
        Public Shared ReadOnly Property GridRed As Color
            Get
                Return Color.Red
            End Get
        End Property
        Public Shared ReadOnly Property GridRedSel As Color
            Get
                Return Color.IndianRed
            End Get
        End Property
        Public Shared ReadOnly Property GridYellow As Color
            Get
                Return Color.Yellow
            End Get
        End Property
        Public Shared ReadOnly Property GridYellowSel As Color
            Get
                Return Color.Khaki
            End Get
        End Property
        Public Shared ReadOnly Property GridGreen As Color
            Get
                Return Color.SpringGreen
            End Get
        End Property
        Public Shared ReadOnly Property GridGreenSel As Color
            Get
                Return Color.MediumSeaGreen
            End Get
        End Property
        Public Shared ReadOnly Property GridDefText As Color
            Get
                Return Color.Black
            End Get
        End Property
        Public Shared ReadOnly Property GridDefTextSel As Color
            Get
                Return SystemColors.HighlightText
            End Get
        End Property

        ''' <summary>
        ''' This will take a DGV and color its rows when a boolean column value is true (green) or red (false).
        ''' </summary>
        ''' <param name="grid">DGV that a DataGrid is bound that that needs colored</param>
        ''' <param name="greenRedColName">Column that will turn the row green when true or red when false</param>
        ''' <param name="yellowColName">When this column is true, the row will turn yellow over any other color.</param>
        ''' <remarks></remarks>
        Public Shared Sub ColorGrid(ByRef grid As DataGridView, ByVal greenRedColName As String, Optional ByVal yellowColName As String = Nothing)
            Dim row As DataRow
            For i = 0 To grid.RowCount - 1
                With grid.Rows(i).DefaultCellStyle
                    row = CType(grid.Rows(i).DataBoundItem, DataRowView).Row
                    If (row.Item(greenRedColName) = True) Then
                        .BackColor = GridRed
                        .SelectionBackColor = GridRedSel
                        ' setting sel text color white
                        .SelectionForeColor = GridDefTextSel
                    ElseIf (row.Item(greenRedColName) = False) Then
                        .BackColor = GridGreen
                        .SelectionBackColor = GridGreenSel
                        ' setting sel text color white
                        .SelectionForeColor = GridDefTextSel
                    End If
                    If (yellowColName IsNot Nothing) Then
                        If (row.Item(yellowColName) = True) Then
                            .BackColor = GridYellow
                            .SelectionBackColor = GridYellowSel
                            ' setting sel text color to black
                            .SelectionForeColor = GridDefText
                        End If
                    End If
                End With
                ' checking yellow
            Next
        End Sub

        ' text box color and default
        Public Shared ReadOnly Property TextBoxErr As Color
            Get
                Return Color.MistyRose
            End Get
        End Property
        Public Shared ReadOnly Property TextBoxDef As Color
            Get
                Return SystemColors.Control
            End Get
        End Property
    End Class

    ' structure for background worker passing information back
    Public Structure ProgressObj
        Public Property MaximumValue As Integer
        Public Property CurrentValue As Integer
        Public Property CurrentCustomer As String
    End Structure

    ' structure for combo box pair
    Public Structure ComboBoxPair
        Public Property ValueMember
        Public Property DisplayMember
    End Structure



End Module