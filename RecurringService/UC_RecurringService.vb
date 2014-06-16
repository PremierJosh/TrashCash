Namespace RecurringService

    Public Class UC_RecurringService
        
        ' friend events
        Friend Event RefreshBalance(ByVal customerNumber As Integer)

        ' property refrence
        Private _custNum As Decimal

        ' properties
        Public Property CurrentCustomer As Decimal
            Get
                Return _custNum
            End Get
            Set(ByVal value As Decimal)
                If (value > 0) Then
                    ' refrence
                    _custNum = value

                    If (value > 0) Then
                        RecurringService_DisplayByCustomerIDTableAdapter.FillByID(Ds_RecurringService.RecurringService_DisplayByCustomerID, value)
                        ColorRows()
                    End If
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

        Private _homeForm As TrashCashHome
        Friend Property HomeForm As TrashCashHome
            Get
                Return _homeForm
            End Get
            Set(value As TrashCashHome)
                _homeForm = value
            End Set
        End Property
        ' data view property that the rec srvc dg is bound to
        Private _dv As DataView

    Private Sub UC_RecurringService_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            _dv = New DataView
            _dv.Table = Ds_RecurringService.RecurringService_DisplayByCustomerID
            dg_RecSrvc.DataSource = _dv
        End Sub

        Private Sub dg_RecSrvc_Click(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dg_RecSrvc.Click
            If (e.Button = Windows.Forms.MouseButtons.Left) Then
                If (dg_RecSrvc.SelectedRows.Count = 1) Then
                    Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
                    ServiceNotesTableAdapter.FillByID(Ds_RecurringService.ServiceNotes, CType(dvRow.Row, ds_RecurringService.RecurringService_DisplayByCustomerIDRow).RecurringServiceID)
                End If
            End If
        End Sub


        Private Sub ColorRows()

            'loop through all grid rows
            Dim grid = dg_RecSrvc
            For i As Integer = 0 To grid.RowCount - 1
                Dim dvRow As DataRowView = grid.Rows(i).DataBoundItem
                Dim row As ds_RecurringService.RecurringService_DisplayByCustomerIDRow = dvRow.Row
                ' checking end date for colorization
                If (row.IsRecurringServiceEndDateNull = False) Then
                    ' end date is NOT NULL
                    If (row.RecurringServiceEndDate < Date.Now.Date) Then
                        ' service has ended
                        grid.Rows(i).DefaultCellStyle.BackColor = AppColors.GridRed
                        grid.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridRedSel
                        ' need a default font
                        grid.Rows(i).DefaultCellStyle.SelectionForeColor = AppColors.GridDefTextSel
                    ElseIf (row.RecurringServiceEndDate >= Date.Now.Date) Then
                        ' service has end date but it hasnt passed yet
                        grid.Rows(i).DefaultCellStyle.BackColor = AppColors.GridYellow
                        grid.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridYellowSel
                        ' need a darker font
                        grid.Rows(i).DefaultCellStyle.SelectionForeColor = AppColors.GridDefText
                    End If
                ElseIf (row.Approved = False) Then
                    ' approval pending rows will be yellow
                    grid.Rows(i).DefaultCellStyle.BackColor = AppColors.GridYellow
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridYellowSel
                    ' need a darker font
                    grid.Rows(i).DefaultCellStyle.SelectionForeColor = AppColors.GridDefText
                Else
                    ' end date is NULL
                    grid.Rows(i).DefaultCellStyle.BackColor = AppColors.GridGreen
                    grid.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridGreenSel
                    ' need a default font
                    grid.Rows(i).DefaultCellStyle.SelectionForeColor = AppColors.GridDefTextSel
                End If
            Next i
        End Sub

        Private Sub rdo_EndedSrvc_Click(sender As System.Object, e As System.EventArgs) Handles rdo_EndedSrvc.Click, rdo_AllSrvc.Click, rdo_CurrentSrvc.Click
            FilterGrid()
        End Sub
        Private Sub FilterGrid()
            Dim s As String
            If (rdo_CurrentSrvc.Checked = True) Then
                s = "RecurringServiceEndDate > '" & Date.Now.Date & "' OR RecurringServiceEndDate IS NULL"
            ElseIf (rdo_EndedSrvc.Checked = True) Then
                s = "RecurringServiceEndDate < '" & Date.Now.Date & "' AND RecurringServiceEndDate IS NOT NULL"
            Else
                s = ""
            End If
            _dv.RowFilter = s
        End Sub

        

        Private Sub dg_RecSrvc_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_RecSrvc.DoubleClick
            If (dg_RecSrvc.SelectedRows.Count = 1) Then
                Dim row As ds_RecurringService.RecurringService_DisplayByCustomerIDRow = CType(dg_RecSrvc.SelectedRows(0).DataBoundItem, DataRowView).Row
                Dim f As New RecurringServiceForm(_custName, CurrentCustomer, row.RecurringServiceID)
                f.ShowDialog()
                ' get what has updated and refresh controls
                If (f.BalanceChanged) Then
                    RaiseEvent RefreshBalance(CurrentCustomer)
                End If
                If (f.ServiceUpdated) Then
                    RecurringService_DisplayByCustomerIDTableAdapter.FillByID(Ds_RecurringService.RecurringService_DisplayByCustomerID, CurrentCustomer)
                    ServiceNotesTableAdapter.FillByID(Ds_RecurringService.ServiceNotes, f.RecurringServiceID)
                End If
            End If
        End Sub

        Private Sub dg_Notes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_Notes.DoubleClick
            Dim noteText As String = InputBox("Note:", "Quick Add Service Note")
            If (Trim(noteText) <> "") Then
                Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
                Try
                    ServiceNotesTableAdapter.ServiceNotes_Insert(CType(dvRow.Row, ds_RecurringService.RecurringService_DisplayByCustomerIDRow).RecurringServiceID, noteText)
                    ' refill grid
                    ServiceNotesTableAdapter.FillByID(Ds_RecurringService.ServiceNotes, CType(dvRow.Row, ds_RecurringService.RecurringService_DisplayByCustomerIDRow).RecurringServiceID)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Sub

        Private Sub btn_NewSrvc_Click(sender As System.Object, e As System.EventArgs) Handles btn_NewSrvc.Click
            Dim f As New RecurringServiceForm(_custName, CurrentCustomer)
            f.ShowDialog()
            RecurringService_DisplayByCustomerIDTableAdapter.FillByID(Ds_RecurringService.RecurringService_DisplayByCustomerID, CurrentCustomer)
        End Sub

        Private Sub dg_RecSrvc_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg_RecSrvc.RowPrePaint
            ColorRows()
        End Sub

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
    End Class
End Namespace