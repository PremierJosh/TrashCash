Namespace RecurringService

    Public Class PendingApprovals

        ' home form var
        Private ReadOnly _homeForm As TrashCashHome

        ' property for tracking unapproved and approved counts
        Private _approvedCount As Integer = 0
        Private Property ApprovedCount As Integer
            Get
                Return _approvedCount
            End Get
            Set(value As Integer)
                ' forcing value to never be less than zero
                If (value < 0) Then
                    value = 0
                End If

                _approvedCount = value

                ' hiding if value is zero
                If (value = 0) Then
                    lbl_Approved.Visible = False
                Else
                    ' update lbl
                    lbl_Approved.Visible = True
                    lbl_Approved.Text = "Approved: " & value
                End If

            End Set
        End Property

        Private _unapprovedCount As Integer = 0
        Private Property UnapprovedCount As Integer
            Get
                Return _unapprovedCount
            End Get
            Set(value As Integer)
                ' forcing value to never be less than zero
                If (value < 0) Then
                    value = 0
                End If

                _unapprovedCount = value

                ' hiding if value is zero
                If (value = 0) Then
                    lbl_UnApproved.Visible = False
                Else
                    ' update lbl
                    lbl_UnApproved.Visible = True
                    lbl_UnApproved.Text = "Unapproved: " & value
                End If

            End Set
        End Property

        ' event to let home form know the count
        Friend Event RemainingApprovals(ByVal c As Integer)

        Private Sub PendingApprovals_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub PendingApprovals_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ' fill initial grid
            RecurringService_PendingApprovalsTableAdapter.Fill(Ds_RecurringService.RecurringService_PendingApprovals)
            ' set unapproved count lbl
            UnapprovedCount = Ds_RecurringService.RecurringService_PendingApprovals.Rows.Count
        End Sub

        Private Sub btn_SaveApprovals_Click(sender As System.Object, e As System.EventArgs) Handles btn_SaveApprovals.Click
            Dim result As DialogResult = MessageBox.Show("Confirm marking " & ApprovedCount & " Recurring Services for approval?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.Yes) Then
                WalkRows()
                MessageBox.Show(ApprovedCount & " Recurring Services Approved for Billing. Be sure to generate Recurring Service Invoices from the Batch Work screen.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' throw event incase some services are unapproved
                RaiseEvent RemainingApprovals(UnapprovedCount)
                ' tell customer form to refresh
                _HomeForm.RefreshCustomerForm()
                'close form
                Close()
            End If
        End Sub

        Private Sub dg_PendingApprovals_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_PendingApprovals.CellContentClick
            If (e.ColumnIndex = 3) Then
                ' checking if column is checked or unchecked now
                If (dg_PendingApprovals.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue = True) Then
                    ' marked for approval, increment approval count and decrement unapproved count
                    ApprovedCount = ApprovedCount + 1
                    UnapprovedCount = UnapprovedCount - 1
                Else
                    ' not checked, going to decrement approved count and increment unapproved count
                    ApprovedCount = ApprovedCount - 1
                    UnapprovedCount = UnapprovedCount + 1
                End If
            End If
        End Sub

        Private Sub WalkRows()
            ' looping through rows
            Cursor = Cursors.WaitCursor

            Try
                For Each row As ds_RecurringService.RecurringService_PendingApprovalsRow In Ds_RecurringService.RecurringService_PendingApprovals.Rows
                    If (row.Approved = True) Then
                        RecurringService_PendingApprovalsTableAdapter.RecurringService_Approve(row.RecurringServiceID)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Error Upating for Approval:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Cursor = Cursors.Default
        End Sub


        Public Sub New(ByRef homeForm As TrashCashHome)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _HomeForm = HomeForm
        End Sub

        Private WithEvents _recurringServiceForm As RecurringServiceForm

        Private Sub dg_PendingApprovals_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_PendingApprovals.DoubleClick
            If (dg_PendingApprovals.SelectedRows.Count = 1) Then
                Dim dvRow As DataRowView = dg_PendingApprovals.SelectedRows(0).DataBoundItem
                Dim row As ds_RecurringService.RecurringService_PendingApprovalsRow = dvRow.Row

                ' set and open rec form for selected service
                _recurringServiceForm = New RecurringServiceForm(row.CustomerFullName, row.CustomerNumber, row.RecurringServiceID)
                _recurringServiceForm.ShowDialog()
            End If
        End Sub

        ' handling approval
        Friend Sub RefreshApprovalList() Handles _recurringServiceForm.ServiceApproved
            RecurringService_PendingApprovalsTableAdapter.Fill(Ds_RecurringService.RecurringService_PendingApprovals)
            ' reset counts lbl
            UnapprovedCount = Ds_RecurringService.RecurringService_PendingApprovals.Rows.Count
            ApprovedCount = 0
        End Sub

      
    End Class
End Namespace