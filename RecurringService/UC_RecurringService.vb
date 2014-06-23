Namespace RecurringService

    Public Class UC_RecurringService
        
        ' friend events
        Friend Event BalanceChanged(ByVal customerNumber As Integer)
        Friend Event ApprovalCountChange()

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

        Private Sub UC_RecurringService_Load(sender As Object, e As System.EventArgs) Handles Me.Load
           
        End Sub

        Private Sub ColorRow(ByRef dgvRow As DataGridViewRow)
            Dim row As ds_RecurringService.RecurringService_DisplayByCustomerIDRow = CType(dgvRow.DataBoundItem, DataRowView).Row
            With dgvRow.DefaultCellStyle
                ' checking end date for colorization
                If (row.IsRecurringServiceEndDateNull = False) Then
                    ' end date is NOT NULL
                    If (row.RecurringServiceEndDate < Date.Now.Date) Then
                        ' service has ended
                        .BackColor = AppColors.GridRed
                        .SelectionBackColor = AppColors.GridRedSel
                        ' need a default font
                        .SelectionForeColor = AppColors.GridDefTextSel
                    ElseIf (row.RecurringServiceEndDate >= Date.Now.Date) Then
                        ' service has end date but it hasnt passed yet
                        .BackColor = AppColors.GridYellow
                        .SelectionBackColor = AppColors.GridYellowSel
                        ' need a darker font
                        .SelectionForeColor = AppColors.GridDefText
                    End If
                ElseIf (row.Approved = False) Then
                    ' approval pending rows will be yellow
                    .BackColor = AppColors.GridYellow
                    .SelectionBackColor = AppColors.GridYellowSel
                    ' need a darker font
                    .SelectionForeColor = AppColors.GridDefText
                Else
                    ' end date is NULL
                    .BackColor = AppColors.GridGreen
                    .SelectionBackColor = AppColors.GridGreenSel
                    ' need a default font
                    .SelectionForeColor = AppColors.GridDefTextSel
                End If
            End With
        End Sub

      
        Friend WithEvents RecurringForm As RecurringServiceForm
        Private Sub dg_RecSrvc_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_RecSrvc.DoubleClick
            If (dg_RecSrvc.SelectedRows.Count = 1) Then
                Dim row As ds_RecurringService.RecurringService_DisplayByCustomerIDRow = CType(dg_RecSrvc.SelectedRows(0).DataBoundItem, DataRowView).Row
                RecurringForm = New RecurringServiceForm(_custName, CurrentCustomer, row.RecurringServiceID)
                RecurringForm.ShowDialog()
                ' get what has updated and refresh controls
                If (RecurringForm.BalanceChanged) Then
                    RaiseEvent BalanceChanged(CurrentCustomer)
                End If
                If (RecurringForm.ServiceUpdated) Then
                    RecurringService_DisplayByCustomerIDTableAdapter.FillByID(Ds_RecurringService.RecurringService_DisplayByCustomerID, CurrentCustomer)
                End If
            End If
        End Sub
        Private Sub ServiceApproved() Handles RecurringForm.ServiceApproved
            RaiseEvent ApprovalCountChange()
        End Sub
        
        Private Sub dg_Notes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_Notes.DoubleClick
            If (dg_RecSrvc.SelectedRows.Count = 1) Then
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
            End If
        End Sub


        Private Sub dg_RecSrvc_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg_RecSrvc.RowPrePaint
            ColorRow(dg_RecSrvc.Rows(e.RowIndex))
        End Sub

        Private Sub dg_RecSrvc_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dg_RecSrvc.SelectionChanged
            If (dg_RecSrvc.SelectedRows.Count = 1) Then
                    Dim dvRow As DataRowView = dg_RecSrvc.SelectedRows(0).DataBoundItem
                    ServiceNotesTableAdapter.FillByID(Ds_RecurringService.ServiceNotes, CType(dvRow.Row, ds_RecurringService.RecurringService_DisplayByCustomerIDRow).RecurringServiceID)
                End If
        End Sub
    End Class
End Namespace