Public Class UC_RecurringService
    ' details form ref so can handle vents
    Friend WithEvents _RecurringServiceForm As RecurringService

    ' friend events
    Friend Event RefreshBalance(ByVal CustomerNumber As Integer)

    ' property refrence
    Private custNum As Decimal

    ' properties
    Public Property CurrentCustomer As Decimal
        Get
            Return custNum
        End Get
        Set(ByVal value As Decimal)
            ' refrence
            custNum = value

            If (value > 0) Then
                Me.RecurringService_DisplayTableAdapter.FillByID(Me.Ds_Display.RecurringService_Display, value)
                ColorRows()
            End If
        End Set
    End Property

    ' name property
    Private _custName As String
    Public WriteOnly Property CustomerName As String
        Set(value As String)
            _custName = value
        End Set
    End Property

    Private _homeForm As TrashCash_Home
    Friend Property HomeForm As TrashCash_Home
        Get
            Return _homeForm
        End Get
        Set(value As TrashCash_Home)
            _homeForm = value
        End Set
    End Property
    ' data view property that the rec srvc dg is bound to
    Private _dv As DataView

    Private _srvcState As String
    Private Property RecurringServiceState As String
        Get
            Return _srvcState
        End Get
        Set(value As String)
            Dim s As String
            If (value = "Current") Then
                s = "RecurringServiceEndDate < " & Date.Now.Date & " OR RecurringServiceEndDate IS NULL"
            ElseIf (value = "Ended") Then
                s = "RecurringServiceEndDate > " & Date.Now.Date & " AND RecurringServiceEndDate IS NOT NULL"
            Else
                s = ""
            End If

            _dv.RowFilter = s
        End Set
    End Property


    Private Sub UC_RecurringService_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        _dv = New DataView
        _dv.Table = Me.Ds_Display.RecurringService_Display
        dg_RecSrvc.DataSource = _dv
        dg_RecSrvc.Columns(0).Visible = False
    End Sub

    Private Sub dg_RecSrvc_Click(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dg_RecSrvc.Click
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            If (dg_RecSrvc.SelectedRows.Count = 1) Then
                Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
                Me.ServiceNotesTableAdapter.FillByID(Me.Ds_Display.ServiceNotes, CType(dvRow.Row, ds_Display.RecurringService_DisplayRow).RecurringServiceID)
            End If
        End If
    End Sub


    Private Sub ColorRows()
        'loop through all grid rows
        Dim grid = dg_RecSrvc
        For i As Integer = 0 To grid.RowCount - 1
            Dim dvRow As DataRowView = grid.Rows(i).DataBoundItem
            Dim row As ds_Display.RecurringService_DisplayRow = dvRow.Row
            ' checking end date for colorization
            If (row.IsRecurringServiceEndDateNull = False) Then
                ' end date is NOT NULL
                If (row.RecurringServiceEndDate < Date.Now.Date) Then
                    ' service has ended
                    grid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
                ElseIf (row.RecurringServiceEndDate >= Date.Now.Date) Then
                    ' service has end date but it hasnt passed yet
                    grid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
                End If
            ElseIf (row.Approved = False) Then
                ' approval pending rows will be yellow
                grid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
            Else
                ' end date is NULL
                grid.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                grid.Rows(i).DefaultCellStyle.SelectionBackColor = Color.Gray
                'grid.Rows(i).DefaultCellStyle.SelectionForeColor = Color.Black
            End If
        Next i
    End Sub

    Private Sub rdo_EndedSrvc_Click(sender As System.Object, e As System.EventArgs) Handles rdo_EndedSrvc.Click, rdo_CurrentSrvc.Click, rdo_AllSrvc.Click
        Dim s As String
        If (rdo_CurrentSrvc.Checked = True) Then
            s = "Current"
        ElseIf (rdo_EndedSrvc.Checked = True) Then
            s = "Ended"
        Else
            s = ""
        End If

        RecurringServiceState = s
    End Sub

    ' event handle to refresh balance of customer
    Private Sub _RefreshBalance(ByVal CustomerNumber As Integer) Handles _RecurringServiceForm.RefreshBalance
        RaiseEvent RefreshBalance(CustomerNumber)
    End Sub

    ' event handle to refresh service and notes
    Private Sub _RefreshService(ByVal CustomerNumber As Integer, ByVal RecurringServiceID As Integer) Handles _RecurringServiceForm.RefreshService
        Me.RecurringService_DisplayTableAdapter.FillByID(Me.Ds_Display.RecurringService_Display, CustomerNumber)

        ' checking if selected service matches service that threw event so we can refresh notes
        If (dg_RecSrvc.SelectedRows.Count = 1) Then
            Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
            If (RecurringServiceID = CType(dvRow.Row, ds_Display.RecurringService_DisplayRow).RecurringServiceID) Then
                Me.ServiceNotesTableAdapter.FillByID(Me.Ds_Display.ServiceNotes, RecurringServiceID)
            End If
        End If

    End Sub

    Private Sub dg_RecSrvc_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_RecSrvc.DoubleClick
        If (dg_RecSrvc.SelectedRows.Count = 1) Then
            Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
            _RecurringServiceForm = New RecurringService(HomeForm, _custName, CurrentCustomer, CType(dvRow.Row, ds_Display.RecurringService_DisplayRow).RecurringServiceID)
            _RecurringServiceForm.ShowDialog()
        End If
    End Sub

    Private Sub dg_Notes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_Notes.DoubleClick
        Dim noteText As String = InputBox("Note:", "Quick Add Service Note")
        If (Trim(noteText) <> "") Then
            Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
            Try
                Me.ServiceNotesTableAdapter.ServiceNotes_Insert(CType(dvRow.Row, ds_Display.RecurringService_DisplayRow).RecurringServiceID, noteText)
                ' refill grid
                Me.ServiceNotesTableAdapter.FillByID(Me.Ds_Display.ServiceNotes, CType(dvRow.Row, ds_Display.RecurringService_DisplayRow).RecurringServiceID)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btn_NewSrvc_Click(sender As System.Object, e As System.EventArgs) Handles btn_NewSrvc.Click
        '_serviceDetails = New RecurringServicesForm(CurrentCustomer, _custName, HomeForm)
        '_serviceDetails.ShowDialog()
        _RecurringServiceForm = New RecurringService(HomeForm, _custName, CurrentCustomer)
        _RecurringServiceForm.ShowDialog()
    End Sub

    Private Sub dg_RecSrvc_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_RecSrvc.RowsAdded
        ColorRows()
    End Sub

    Private Sub dg_RecSrvc_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg_RecSrvc.RowsRemoved
        ColorRows()
    End Sub
End Class
