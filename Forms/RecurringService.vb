
Public Class RecurringService
    ' need recurring service queries ta
    Dim qta As ds_RecurringServiceTableAdapters.QueriesTableAdapter

    ' dataview for checking if new end date will overlap with existing credits
    Dim dv_EndDateOverlap As DataView
    Private WriteOnly Property dv_RowFilter As Date
        Set(value As Date)
            ' making sure this is a time value not double
            If (IsDate(value)) Then
                If (dv_EndDateOverlap IsNot Nothing) Then
                    dv_EndDateOverlap.RowFilter = "Voided = 0 AND DateOfCredit >= '" & value & "'"
                    ' update status text if rows filter
                    CreditOverlapCheck(value)
                End If
            End If
        End Set
    End Property


    ' customer name propety to display at top
    Private _custName As String
    Friend Property CustomerName As String
        Get
            Return _custName
        End Get
        Set(value As String)
            _custName = value

            ' set header lbl
            lbl_CustName.Text = value
        End Set
    End Property

    ' customer number property
    Private _custNum As Integer
    Private custRow As ds_Customer.CustomerRow
    Friend Property CustomerNumber As Integer
        Get
            Return _custNum
        End Get
        Set(value As Integer)
            _custNum = value

            ' fetching customer row
            Using ta As New ds_CustomerTableAdapters.CustomerTableAdapter
                custRow = ta.GetData(CustomerNumber).Rows(0)
            End Using
        End Set
    End Property

    ' status of invoice text property
    Private _statusText As String
    Friend Property StatusText As String
        Get
            Return _statusText
        End Get
        Set(value As String)
            _statusText = value

            ' set text at bottom of form
            lbl_RecStatus.Text = value
        End Set
    End Property

    ' recurring service id property
    Private _recID As Integer
    Friend Property RecurringServiceID As Integer
        Get
            Return _recID
        End Get
        Set(value As Integer)
            If (value <> 0) Then
                _recID = value

                ' fetch row
                Me.RecurringServiceTableAdapter.FillByID(Me.Ds_RecurringService.RecurringService, value)
                ' update row reference
                If (Me.Ds_RecurringService.RecurringService.Rows.Count = 1) Then
                    RecurringServiceRow = Me.Ds_RecurringService.RecurringService.Rows(0)
                    ' set isNew to false
                    IsNew = False
                Else
                    MessageBox.Show("Error: No recurring row retieved on initial fetch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' 0 passed, new service
                IsNew = True
            End If
        End Set
    End Property

    ' row that controls are bound to
    Private _recRow As ds_RecurringService.RecurringServiceRow = Nothing
    Private Property RecurringServiceRow As ds_RecurringService.RecurringServiceRow
        Get
            Return _recRow
        End Get
        Set(value As ds_RecurringService.RecurringServiceRow)
            ' bool to see if we can set the new row
            Dim okToSet As Boolean = False
            If (_recRow IsNot Nothing) Then
                If (_recRow.RecurringServiceID <> value.RecurringServiceID) Then
                    okToSet = True
                End If
            Else
                okToSet = True
            End If

            If (okToSet) Then
                _recRow = value

                ' fill billed services display
                Me.RecurringService_BillHistoryTableAdapter.FillByRecurringID(Me.Ds_RecurringService.RecurringService_BillHistory, value.RecurringServiceID)
                ' fill service notes display
                Me.ServiceNotesTableAdapter.FillByID(Me.Ds_RecurringService.ServiceNotes, value.RecurringServiceID)
                ' fill credit history
                Me.RecurringService_CreditsTableAdapter.FillByRecID(Me.Ds_RecurringService.RecurringService_Credits, value.RecurringServiceID)

                ' checking if service is approved
                Approved = value.Approved

                ' checking if an end date is set
                If (value.IsRecurringServiceEndDateNull = False) Then
                    dtp_EndDate.Visible = True
                    dtp_EndDate.Value = value.RecurringServiceEndDate
                    ck_EndDate.Checked = True

                    ' checking if credited due to this end date
                    If (value.Credited = True) Then
                        ' set property
                        Using ta As New ds_RecurringServiceTableAdapters.RecurringService_EndDateCreditsTableAdapter
                            EndDateCreditRow = ta.GetDataByRecID(value.RecurringServiceID).Rows(0)
                        End Using
                    End If

                Else
                    ck_EndDate.Checked = False
                    dtp_EndDate.Visible = False
                End If
            End If
        End Set
    End Property

    ' bool property for whether or not service is new
    Private _isNew As Boolean = True
    Private Property IsNew As Boolean
        Get
            Return _isNew
        End Get
        Set(value As Boolean)
            _isNew = value
            If (value = False) Then
                ' check if service has been invoiced
                If (Me.Ds_RecurringService.RecurringService_BillHistory.Rows.Count > 0) Then
                    Invoiced = True
                End If
            Else
                ' creating new row with dummy values
                Dim row As ds_RecurringService.RecurringServiceRow = Me.Ds_RecurringService.RecurringService.NewRecurringServiceRow
                row.CustomerNumber = CustomerNumber
                ' test: resumelayout of cmb service types
                Me.Cmb_ServiceTypes.ResumeLayout()
                row.ServiceTypeID = Cmb_ServiceTypes.SelectedValue
                row.RecurringServiceRate = Cmb_ServiceTypes.SelectedServiceRate
                row.RecurringServiceQuantity = 1
                row.RecurringServiceStartDate = Date.Now
                row.RecurringServiceBillLength = 1
                row.RecurringServiceAddr1 = ""
                row.RecurringServiceCity = ""
                row.RecurringServiceState = ""
                row.RecurringServiceZip = ""
                row.Approved = False
                row.Credited = False

                ' add dummy row
                Me.Ds_RecurringService.RecurringService.AddRecurringServiceRow(row)
                RecurringServiceRow = row

                ' hide status text
                lbl_RecStatus.Visible = False
                ' hiding approved button for new services
                btn_Approve.Visible = False

                ' hiding credit and bill history tabs
                tp_BillHist.Hide()
                tp_Credits.Hide()
                tp_Notes.Hide()

            End If
        End Set
    End Property

    ' event for approval
    Friend Event e_Approved()

    ' bool property for service approval
    Private _approved As Boolean = False
    Private Property Approved As Boolean
        Get
            Return _approved
        End Get
        Set(value As Boolean)
            _approved = value
            If (value = False) Then
                btn_Approve.Visible = True
                ' update status text
                StatusText = "This Recurring Service has not been Approved for invoicing. You can still change anything related to this service."
            Else
                btn_Approve.Visible = False
            End If
        End Set
    End Property

    ' bool property for whether or not service has been invoiced
    Private _invoiced As Boolean = False
    Private _billThruDate As Date = Nothing
    Private Property Invoiced As Boolean
        Get
            Return _invoiced
        End Get
        Set(value As Boolean)
            _invoiced = value

            ' if true, lock controls and display billed thru
            If (value = True) Then

                ' getting last bill thru date
                _billThruDate = qta.RecurringService_MaxEndBillingDate(RecurringServiceID)

                ' display billed through
                lbl_BillThru.Visible = True
                lbl_BillThru.Text = "Billed Through:" & vbCrLf & FormatDateTime(_billThruDate, DateFormat.ShortDate)
                LockDetails(True)

                ' update statys text
                StatusText = "This Recurring Service has already been invoiced. The only thing you can change is its Last Day of Service."
            Else
                StatusText = "This Recurring Service has not been invoiced yet. You can still change anything related to this service."
                LockDetails(False)
            End If
        End Set
    End Property

    ' property for last end date credit row
    Private _endDateCreditRow As ds_RecurringService.RecurringService_EndDateCreditsRow
    Private Property EndDateCreditRow As ds_RecurringService.RecurringService_EndDateCreditsRow
        Get
            Return _endDateCreditRow
        End Get
        Set(value As ds_RecurringService.RecurringService_EndDateCreditsRow)
            _endDateCreditRow = value

            If (value.Voided = False) Then
                ' update status text
                StatusText = "The Last Day of Service caused a credit to be issued on " & value.TimeCreated.Date & " in the amount of " & FormatCurrency(value.CreditAmount) & "."
            End If
        End Set
    End Property

    ' crediting property so on commit we can generate a credit
    Private _crediting As Double
    Private Property Crediting As Double
        Get
            Return _crediting
        End Get
        Set(value As Double)
            _crediting = value

            If (value > 0) Then
                lbl_CreditMsg.Visible = True
                lbl_CreditMsg.Text = "Saving this Last Date of Service will cause a Credit to be issued for: " & FormatCurrency(value)
            Else
                lbl_CreditMsg.Visible = False
            End If

        End Set
    End Property
    ' home form ref var
    Private HomeForm As TrashCash_Home

    Private Sub CreditOverlapCheck(ByVal newDate As Date)
        Dim s As String = Nothing

        ' making sure we have rows first
        If (dv_EndDateOverlap.Count > 0) Then
            ' keeping track of total and count
            Dim voidTotal As Double = 0.0
            Dim c As Integer = 0

            For Each row As ds_RecurringService.RecurringService_CreditsRow In dv_EndDateOverlap.Table.Rows
                voidTotal = voidTotal + row.CreditAmount
                c = c + 1
            Next

            ' compiling string
            s = "Keeping this End Date will also Void " & c & " Recurring Service Credit(s) for a total of " & FormatCurrency(voidTotal) & "."
        End If

        If (s IsNot Nothing) Then
            lbl_OverlapVoid.Visible = True
            lbl_OverlapVoid.Text = s
        Else
            lbl_OverlapVoid.Visible = False
        End If

    End Sub


    Private Sub LockDetails(ByVal bool As Boolean)
        If (bool = True) Then
            grp_BasicInfo.Enabled = False
            dtp_StartDate.Enabled = False
            grp_PickupDay.Enabled = False
            grp_SrvcAddr.Enabled = False
        Else
            grp_BasicInfo.Enabled = True
            dtp_StartDate.Enabled = True
            grp_PickupDay.Enabled = True
            grp_SrvcAddr.Enabled = True
        End If
    End Sub

    ' form bool vars to track whats been updated so parent form can refresh where needed
    Private _BalanceChanged As Boolean = False
    Friend Event RefreshBalance(ByVal CustomerNumber As Integer)
    Private _ServiceUpdated As Boolean = False
    Friend Event RefreshService(ByVal CustomerNumber As Integer, ByVal RecurringServiceID As Integer)


    Public Sub New(ByVal _HomeForm As TrashCash_Home, ByVal _CustomerName As String, ByVal _CustomerNumber As Integer, Optional ByVal _RecurringServiceID As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' tas
        qta = New ds_RecurringServiceTableAdapters.QueriesTableAdapter

        ' property refs
        HomeForm = _HomeForm
        CustomerNumber = _CustomerNumber
        RecurringServiceID = _RecurringServiceID
        CustomerName = _CustomerName

        ' creating dv for credit overlap checking
        dv_EndDateOverlap = New DataView(Me.Ds_RecurringService.RecurringService_Credits, "Voided = 0", "", DataViewRowState.CurrentRows)
    End Sub

    Private Sub ck_EndDate_Click(sender As System.Object, e As System.EventArgs) Handles ck_EndDate.Click
        If (ck_EndDate.Checked = True) Then
            dtp_EndDate.Visible = True
        Else
            ' unchecked now
            ' checking if credit has been issued due to end date
            If (EndDateCreditRow IsNot Nothing) Then
                If (EndDateCreditRow.Voided = False) Then
                    Dim result As DialogResult = MessageBox.Show("There was a Credit issued because this Last Date of Service overlapped with an already invoiced period. Removing this last date of service will void this Credit." & vbCrLf & _
                                                                 "Do you wish to Void this Credit and resume the billing?", "Void Exisiting End Date Credit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    ' only need to catch no here, otherwise uncheck and on submit it will wipe the end date
                    If (result = Windows.Forms.DialogResult.No) Then
                        ck_EndDate.Checked = True
                        Exit Sub
                    End If
                End If
            End If
            ' not going to credit if we dont have an end date
            Crediting = 0
            dtp_EndDate.Visible = False
        End If
    End Sub

    Private Sub btn_Save_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
        If (TBsValidated()) Then

            ' bool to keep ack of needing to void old enddate credit
            Dim voidOldCreditReason As String = Nothing
            ' result var from 3 different credit outcomes
            Dim creditResult As DialogResult

            ' bring over end date
            If (ck_EndDate.Checked = True) Then
                ' checking if end date before start date
                If (dtp_EndDate.Value.Date > RecurringServiceRow.RecurringServiceStartDate) Then

                    ' first checking if something needs to be voided
                    If (dv_EndDateOverlap.Count > 0) Then
                        Dim overlapPrompt As DialogResult = MessageBox.Show("Keeping this End Date will Void " & dv_EndDateOverlap.Count & " Credit(s) for a total of " &
                                                                            FormatCurrency(dv_EndDateOverlap.Table.Compute("SUM(CreditAmount)", "")) &
                                                                            ". Do you wish to keep this End Date?", "Void " & dv_EndDateOverlap.Count & " Credit(s)",
                                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

                        If (overlapPrompt = Windows.Forms.DialogResult.Yes) Then
                            ' void all credits in table
                            For Each row As ds_RecurringService.RecurringService_CreditsRow In dv_EndDateOverlap.Table.Rows
                                HomeForm.Procedures.RecurringService_Credit_Void(row.RecurringServiceCreditID, "Credit for Date overlaped with End Date. New End Date: " & dtp_EndDate.Value.Date & " | Billed Through: " & _billThruDate.Date)
                            Next
                        Else
                            Exit Sub
                        End If

                    End If

                    ' warning if a credit is going to be made
                    If (Crediting > 0) Then


                        ' checking if old credit needs voided for new one
                        If (EndDateCreditRow IsNot Nothing) Then
                            If (EndDateCreditRow.Voided = False) Then
                                creditResult = MessageBox.Show("Changing the Last Date of Service will cause the previous credit of " & FormatCurrency(EndDateCreditRow.CreditAmount) & " to be voided, and a new one of " & FormatCurrency(Crediting) & " to be issued." & vbCrLf & _
                                                                "Do you want to save these changes?", "Void old Credit and create new.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                ' updating void vars to be used to update the row
                                voidOldCreditReason = "Last Date of Service changed from " & RecurringServiceRow.RecurringServiceEndDate.Date & " to " & dtp_EndDate.Value.Date & "."
                            Else
                                creditResult = MessageBox.Show("Keeping this Last Date of Service will cause a credit to be issued for " & FormatCurrency(Crediting) & "." & vbCrLf & _
                                                                        "Do you want to issue this credit?", "Crediting Customer for End Date Overlap", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            End If
                        Else
                            creditResult = MessageBox.Show("Keeping this Last Date of Service will cause a credit to be issued for " & FormatCurrency(Crediting) & "." & vbCrLf & _
                                                                        "Do you want to issue this credit?", "Crediting Customer for End Date Overlap", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        End If
                    Else
                        ' set end date on row
                        RecurringServiceRow.RecurringServiceEndDate = dtp_EndDate.Value.Date
                    End If
                Else
                    ' warn that end date cannot be before start date and open the dtp
                    MessageBox.Show("Service End Date cannot be before its Start Date", "Invalid End Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtp_EndDate.Select()
                    SendKeys.Send("%{DOWN}")
                    Exit Sub
                End If
            Else
                ' wipe end date
                RecurringServiceRow.SetRecurringServiceEndDateNull()
                ' checking if credit was issued for this
                If (EndDateCreditRow IsNot Nothing) Then
                    ' was it voided?
                    If (EndDateCreditRow.Voided = False) Then
                        Dim voidCreditResult As DialogResult = MessageBox.Show("There was a Credit issued because the Last Date of Service overlapped with an already invoiced period. Removing this last date of service will void this Credit." & vbCrLf & _
                                                                     "Do you wish to Void this Credit and resume the billing?", "Void Exisiting End Date Credit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        ' if yes, then set end date null and set credit row voided
                        If (voidCreditResult = Windows.Forms.DialogResult.Yes) Then
                            RecurringServiceRow.SetRecurringServiceEndDateNull()
                            ' updating void vars to be used to update the row
                            voidOldCreditReason = "Service continuation."
                        End If
                    End If
                End If
            End If


            ' check if voiding old end date credit
            If (voidOldCreditReason IsNot Nothing) Then
                If (EndDateCreditRow.Voided = False) Then
                    HomeForm.Procedures.RecurringService_EndDateCredit_Void(EndDateCreditRow, voidOldCreditReason)
                    _BalanceChanged = True
                End If
            End If

            ' checking if new credit needs to be issued
            If (creditResult = Windows.Forms.DialogResult.Yes) Then

                HomeForm.Procedures.RecurringService_EndDateCredit(RecurringServiceRow, Crediting, dtp_EndDate.Value.Date, _billThruDate)
                ' setting balance change
                _BalanceChanged = True
                _ServiceUpdated = True
            Else
                RecurringServiceRow.SetRecurringServiceEndDateNull()
            End If

            RecurringServiceRow.EndEdit()

            ' checking if anything changed
            If (RecurringServiceRow.RowState <> DataRowState.Unchanged) Then
                _ServiceUpdated = True
            End If

            ' testing submit
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.RecurringServiceTableAdapter.Update(RecurringServiceRow)

                ' checking if service is new to refresh pending approval count on home form
                If (IsNew) Then
                    HomeForm.RefreshApprovCount()
                End If
            Catch ex As Exception
                MessageBox.Show("Error updating Recurring Service row: " & ex.Message, "Sql Update RecurringServiceRow Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.Cursor = Cursors.Default
            Me.Close()
        End If

    End Sub

    ' validation sub


    Private Function TBsValidated() As Boolean
        ' return var
        Dim validated As Boolean = True

        ' address validation
        For Each control As Control In grp_SrvcAddr.Controls
            Dim skip As Boolean = False
            If (TypeOf control Is TextBox) Then
                If (control.Name = tb_SrvcAddr2.Name) Then
                    skip = True
                ElseIf (control.Name = tb_SrvcAddr3.Name) Then
                    skip = True
                End If

                If (Not skip) Then
                    If (Trim(control.Text) = "") Then
                        validated = False
                        ' adjust back color
                        control.BackColor = Color.MistyRose
                    Else
                        ' reset color
                        control.BackColor = SystemColors.Window
                    End If
                End If
            End If
        Next

        ' rate validation
        If (tb_Rate.Text < 1) Then
            MessageBox.Show("Rate must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            validated = False
        End If

        ' quantity
        If (nud_Quantity.Value < 1) Then
            MessageBox.Show("Quantity must be at least 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            validated = False
        End If

        ' bill length
        If (nud_BillLength.Value < 1) Then
            MessageBox.Show("Bill Length must be at least 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            validated = False
        End If

        ' pickup day
        Dim c As Integer = 0
        For Each control As Control In grp_PickupDay.Controls
            If (TypeOf control Is CheckBox) Then
                If (CType(control, CheckBox).Checked = True) Then
                    c += 1
                End If
            End If
        Next

        If (c = 0) Then
            validated = False
            MessageBox.Show("At least 1 Pickup Day must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return validated
    End Function

    Private Sub btn_CopyAddr_Click(sender As System.Object, e As System.EventArgs) Handles btn_CopyAddr.Click
        ' bool to catch if confirm for copy
        Dim confirm As Boolean = True

        ' checking if data in addr1 so we can prompt to overwrite
        If (Trim(tb_SrvcAddr1.Text) <> "") Then
            Dim prompt As MsgBoxResult = MsgBox("This will overwrite any information currently set for the Service Address. Confirm?")
            If (prompt = MsgBoxResult.No) Then
                confirm = False
            End If
        End If

        If (confirm = True) Then

            ' updating addr tbs
            ' checking for null values for addr1-3
            If (custRow.IsCustomerBillingAddr1Null = False) Then
                ' tb_SrvcAddr1.Text = custRow.CustomerBillingAddr1
                RecurringServiceRow.RecurringServiceAddr1 = custRow.CustomerBillingAddr1
            End If
            If (custRow.IsCustomerBillingAddr2Null = False) Then
                'tb_SrvcAddr2.Text = custRow.CustomerBillingAddr2
                RecurringServiceRow.RecurringServiceAddr2 = custRow.CustomerBillingAddr2
            End If
            If (custRow.IsCustomerBillingAddr3Null = False) Then
                'tb_SrvcAddr3.Text = custRow.CustomerBillingAddr3
                RecurringServiceRow.RecurringServiceAddr3 = custRow.CustomerBillingAddr3
            End If

            'tb_SrvcCity.Text = custRow.CustomerBillingCity
            RecurringServiceRow.RecurringServiceCity = custRow.CustomerBillingCity
            'tb_SrvcState.Text = custRow.CustomerBillingState
            RecurringServiceRow.RecurringServiceState = custRow.CustomerBillingState
            'tb_SrvcZip.Text = custRow.CustomerBillingZip
            RecurringServiceRow.RecurringServiceZip = custRow.CustomerBillingZip

            ' refresh binding source to tbs have new text
            RecurringServiceBindingSource.ResetCurrentItem()

        End If
    End Sub

    Private Sub RecurringService_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' update recid outside property
        _recID = RecurringServiceRow.RecurringServiceID
        ' checking for updates so can throw events
        If (_BalanceChanged = True) Then
            RaiseEvent RefreshBalance(CustomerNumber)
        End If
        If (_ServiceUpdated = True) Then
            RaiseEvent RefreshService(CustomerNumber, RecurringServiceID)
        End If
    End Sub

    Private Sub Cmb_ServiceTypes_ServiceChanged(ServiceID As System.Int32, Rate As System.Double, BillLength As System.Int32) Handles Cmb_ServiceTypes.ServiceChanged
        ' update default price lbl
        lbl_DefPriceValue.Text = FormatCurrency(Rate)
        ' adjust rate box to default
        tb_Rate.Text = CDec(Rate)
        ' update bill length
        RecurringServiceRow.RecurringServiceBillLength = BillLength
        ' update row service id
        RecurringServiceRow.ServiceTypeID = ServiceID
        ' also going to reset quantity to 1
        RecurringServiceRow.RecurringServiceQuantity = 1
    End Sub

    Private Sub btn_Approve_Click(sender As System.Object, e As System.EventArgs) Handles btn_Approve.Click
        Dim result As DialogResult = MessageBox.Show("Confirm the following details are accurate to Approve this Recurring Service for billing:" & vbCrLf & vbCrLf & _
                        "Rate: " & FormatCurrency(RecurringServiceRow.RecurringServiceRate) & " x " & RecurringServiceRow.RecurringServiceQuantity & " billed every " & RecurringServiceRow.RecurringServiceBillLength & " month(s)." & vbCrLf & _
                        "The first invoice will be for " & RecurringServiceRow.RecurringServiceStartDate.Date & " through " & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, RecurringServiceRow.RecurringServiceBillLength, RecurringServiceRow.RecurringServiceStartDate)) & " for " & FormatCurrency(RecurringServiceRow.RecurringServiceRate * RecurringServiceRow.RecurringServiceQuantity) & vbCrLf, "Confirm Details for Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (result = Windows.Forms.DialogResult.Yes) Then
            RecurringServiceRow.Approved = True
            RecurringServiceRow.EndEdit()
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.RecurringServiceTableAdapter.Update(RecurringServiceRow)

                ' raise approval event so approval form can refresh
                RaiseEvent e_Approved()
                _ServiceUpdated = True

                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Error Updating for Approval: " & ex.Message, "Error Updating for Approval", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub


    Private Sub dtp_EndDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtp_EndDate.ValueChanged
        If (ck_EndDate.Checked = True) Then
            ' checking if this will overlap with a credit
            dv_RowFilter = dtp_EndDate.Value.Date

            ' checking if service bill thru date is greater than the new end date
            If (_billThruDate > dtp_EndDate.Value.Date) Then
                ' display estimated credit
                'Dim creditAmount As Decimal = CDec(qta.RecurringService_EndDateCreditCalc(RecurringServiceRow.RecurringServiceID, DateAdd(DateInterval.Day, 1, dtp_EndDate.Value.Date)))
                Dim creditAmount As Decimal = CDec(qta.RecurringService_EndDateCreditCalc(RecurringServiceRow.RecurringServiceID, dtp_EndDate.Value.Date))

                If (creditAmount > 0) Then
                    ' update crediting property
                    Crediting = creditAmount
                    ' checking if previous credit exists and if it was voided
                    If (EndDateCreditRow IsNot Nothing) Then
                        If (Not EndDateCreditRow.Voided) Then
                            lbl_CreditMsg.Text += vbCrLf & "This will also void the previous credit of " & FormatCurrency(EndDateCreditRow.CreditAmount) & "."
                        End If
                    End If
                Else
                    Crediting = 0
                End If
            End If
        End If
    End Sub

    Private Sub RecurringService_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'going to reset service id based on cmb selected value since trying to get selected value on new returns -1
        RecurringServiceRow.ServiceTypeID = Cmb_ServiceTypes.SelectedValue
        ' throwing message if customer is single inv
        If (custRow.CustomerReceiveOneInvoice = True) Then
            MessageBox.Show("This Customer is marked to receive 1 invoice. All Recurring Services for this Customer will go onto a single invoice, with a due day date of " & DatePart(DateInterval.Day, custRow.CustomerStartDate) & ", " & vbCrLf & _
                            "and they will be billed every " & custRow.CustomerBillInterval & " month(s) - REGARDLESS of the Bill Length set for their Recurring Services.", "Single Invoice Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub dg_ServiceNotes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_ServiceNotes.DoubleClick
        Dim noteText As String = InputBox("Note:", "Quick Add Service Note")
        If (Trim(noteText) <> "") Then
            Try
                Me.ServiceNotesTableAdapter.ServiceNotes_Insert(RecurringServiceID, noteText)
                ' refill grid
                Me.ServiceNotesTableAdapter.FillByID(Me.Ds_RecurringService.ServiceNotes, RecurringServiceID)
                ' updating bool so home uc is refreshed to pickup new note
                _ServiceUpdated = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cm_i_VoidCredit_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_VoidCredit.Click
        If (dg_CreditHistory.SelectedRows.Count = 1) Then
            ' get row reference
            Dim dvRow As DataRowView = dg_CreditHistory.SelectedRows(0).DataBoundItem
            Dim row As ds_RecurringService.RecurringService_CreditsRow = dvRow.Row

            ' checking if row voided
            If (Not row.Voided) Then
                Dim result As DialogResult = MessageBox.Show("Void credit for " & FormatCurrency(row.CreditAmount) & ", issued on " & row.TimeCreated & " for Service on Date: " & row.DateOfCredit & "?", "Confirm Credit Void", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                ' upon confirm, grab reason through input box
                If (result = Windows.Forms.DialogResult.Yes) Then
                    Dim reason As String = InputBox("Reason for Voiding Credit Memo", "Reason for Voiding Credit Memo")
                    If (Trim(reason).Length > 0) Then
                        HomeForm.Procedures.RecurringService_Credit_Void(row.RecurringServiceCreditID, reason)
                        MessageBox.Show("Credit Memo Voided", "Credit Memo Voided", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' customer balance has changed now
                        _BalanceChanged = True

                        ' refresh credit history grid
                        Me.RecurringService_BillHistoryTableAdapter.FillByRecurringID(Me.Ds_RecurringService.RecurringService_BillHistory, RecurringServiceRow.RecurringServiceID)
                    End If
                End If
            Else
                MessageBox.Show("This Credit has already been voided. It was voided by " & row.VoidUser & " on " & row.VoidTime & ". Reason: " & row.Reason & ".", "Credit already Voided", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub btn_CreateCredit_Click(sender As System.Object, e As System.EventArgs) Handles btn_CreateCredit.Click
        ' refs
        Dim creditForDate As Date = dtp_CreditForDate.Value.Date
        Dim creditAlreadyOnDate As Boolean = Me.RecurringService_CreditsTableAdapter.Credit_OnDate(RecurringServiceID, creditForDate)
        Dim okToCredit As Boolean = False

        If (Not creditAlreadyOnDate) Then
            ' making sure date is not before start of service
            If (creditForDate > RecurringServiceRow.RecurringServiceStartDate) Then

                ' checking for end date..
                If (RecurringServiceRow.IsRecurringServiceEndDateNull = False) Then
                    ' end date set
                    If (creditForDate < RecurringServiceRow.RecurringServiceEndDate) Then
                        okToCredit = True
                    Else
                        MessageBox.Show("Credit cannot be after the Recurring Service end date.")
                    End If

                Else
                    ' no end date set
                    okToCredit = True
                End If
            Else
                MessageBox.Show("Credit Date cannot be before Recurring Service start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("There is a Credit issued for this Date already.", "Error - Credit Already on Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' creating credit if good
        If (okToCredit) Then
            HomeForm.Procedures.RecurringService_Credit(RecurringServiceRow.RecurringServiceID, tb_CreditAmount.Text, creditForDate, tb_CreditReason.Text)
            ' balance has changed now
            _BalanceChanged = True
            ' refresh grid
            Try
                Me.RecurringService_CreditsTableAdapter.FillByRecID(Me.Ds_RecurringService.RecurringService_Credits, RecurringServiceID)
            Catch ex As Exception
                MsgBox(ex.Message & " - " & ex.InnerException.ToString)
            End Try

            ' reset controls
            dtp_CreditForDate.Value = Date.Now
            tb_CreditAmount.Text = ""
            tb_CreditReason.Text = ""
        End If
    End Sub

    Private Sub ColorCreditHistoryRows()
        If (dg_CreditHistory.Rows.Count > 0) Then
            ' color voided rows red
            For i = 0 To dg_CreditHistory.Rows.Count - 1

                ' row reference
                Dim dvRow As DataRowView = dg_CreditHistory.Rows(i).DataBoundItem
                Dim row As ds_RecurringService.RecurringService_CreditsRow = dvRow.Row

                If (row.Voided) Then
                    ' credit is voided
                    dg_CreditHistory.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    dg_CreditHistory.Rows(i).DefaultCellStyle.SelectionBackColor = Color.IndianRed
                Else
                    dg_CreditHistory.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                    dg_CreditHistory.Rows(i).DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen
                End If
            Next
        End If
    End Sub

    Private Sub dg_CreditHistory_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_CreditHistory.RowsAdded
        ColorCreditHistoryRows()
    End Sub

    Private Sub dg_CreditHistory_RowsRemoved(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dg_CreditHistory.RowsRemoved
        ColorCreditHistoryRows()
    End Sub

    Private Sub dtp_EndDate_Validated(sender As System.Object, e As System.EventArgs) Handles dtp_EndDate.Validated
        ' when validated, check if credit has been issued for an end date
        ' if it has, prompt that this will void that credit and create a new one

    End Sub

    Private Sub dg_CreditHistory_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            For Each row As DataGridViewRow In dg_CreditHistory.SelectedRows
                row.Selected = False
            Next
            dg_CreditHistory.Rows(e.RowIndex).Selected = True
        End If
    End Sub
End Class