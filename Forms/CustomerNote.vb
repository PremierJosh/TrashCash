Public Class CustomerNote

    ' form properties
    Private _currentCustomer As Integer
    ' event to refresh notes
    Friend Event NoteAdded()
  
    Public WriteOnly Property CustomerName As String
        Set(value As String)
            lbl_CustName.Text = value
        End Set
    End Property
    Public Sub New(ByVal CustomerNumber As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If (CustomerNumber <> 0) Then
            _currentCustomer = CustomerNumber
        End If
    End Sub

    ' LOAD EVENTS
    Private Sub NewCustNote_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub NoteTextTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles noteTextBox.TextChanged
        If (Len(noteTextBox.Text) < 500) Then
            countLbl.Text = Len(noteTextBox.Text)
            countLbl.ForeColor = SystemColors.ControlText
        ElseIf (Len(noteTextBox.Text) = 500) Then
            countLbl.Text = 500
            countLbl.ForeColor = Color.Red
        End If
    End Sub

    Private Sub addNoteBtn_Click(sender As System.Object, e As System.EventArgs) Handles addNoteBtn.Click
        If (noteTextBox.TextLength > 0) Then
            Dim qta As New DataSetTableAdapters.QueriesTableAdapter
            Try
                qta.CustomerNotes_Insert(_currentCustomer, noteTextBox.Text)
                RaiseEvent NoteAdded()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Me.Close()
    End Sub
End Class