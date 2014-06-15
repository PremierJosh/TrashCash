
Namespace RecurringService
    Public Class RecurringServiceForm

        ' dataview for checking if new end date will overlap with existing credits
        ReadOnly _dvEndDateOverlap As DataView
        Private WriteOnly Property DvRowFilter As Date
            Set(value As Date)
                ' making sure this is a time value not double
                If (IsDate(value)) Then
                    If (_dvEndDateOverlap IsNot Nothing) Then
                        _dvEndDateOverlap.RowFilter = "Voided = 0 AND DateOfCredit >= '" & value & "'"
                        ' update status text if rows filter
                        CreditOverlapDisplayCheck()
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
        Private _custRow As ds_Customer.CustomerRow
        Friend Property CustomerNumber As Integer
            Get
                Return _custNum
            End Get
            Set(value As Integer)
                _custNum = value

                ' fetching customer row
                Using ta As New ds_CustomerTableAdapters.CustomerTableAdapter
                    _custRow = ta.GetData(CustomerNumber).Rows(0)
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
                    RsTA.FillByID(Ds_RecurringService.RecurringService, value)
                    ' update row reference
                    If (Ds_RecurringService.RecurringService.Rows.Count = 1) Then
                        RecurringServiceRow = Ds_RecurringService.RecurringService.Rows(0)
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
                    HistoryTA.FillByRecurringID(Ds_RecurringService.RecurringService_BillHistory, value.RecurringServiceID)
                    ' fill service notes display
                    NotesTA.FillByID(Ds_RecurringService.ServiceNotes, value.RecurringServiceID)
                    ' fill credit history
                    RsCreditTA.FillByRecID(Ds_RecurringService.RecurringService_Credits, value.RecurringServiceID)

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
                    If (Ds_RecurringService.RecurringService_BillHistory.Rows.Count > 0) Then
                        Invoiced = True
                    End If
                Else
                    ' creating new row with dummy values
                    Dim row As ds_RecurringService.RecurringServiceRow = Ds_RecurringService.RecurringService.NewRecurringServiceRow
                    row.CustomerNumber = CustomerNumber
                    row.ServiceTypeID = cmb_ServiceTypes.SelectedValue
                    row.RecurringServiceRate = DirectCast(cmb_ServiceTypes.SelectedItem, ds_Types.ServiceTypesRow).ServiceRate
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
                    Ds_RecurringService.RecurringService.AddRecurringServiceRow(row)
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
        Friend Event ServiceApproved()

        ' bool property for service approval
        Private WriteOnly Property Approved As Boolean
            Set(value As Boolean)
                If (value = False) Then
                    btn_Approve.Visible = True
                    ' update status text
                    StatusText = "This Recurring Service has not been Approved for Invoicing. You can still change anything related to this service."
                Else
                    btn_Approve.Visible = False
                End If
            End Set
        End Property

        ' bool property for whether or not service has been invoiced
        Private _billThruDate As Date = Nothing
        Private WriteOnly Property Invoiced As Boolean
            Set(value As Boolean)

                ' if true, lock controls and display billed thru
                If (value = True) Then

                    ' getting last bill thru date
                    _billThruDate = HistoryTA.MaxEndBillingDate(RecurringServiceID)

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
        Private ReadOnly _homeForm As TrashCashHome

        Private Sub CreditOverlapDisplayCheck()
            Dim s As String = Nothing

            ' making sure we have rows first
            If (_dvEndDateOverlap.Count > 0) Then
                ' keeping track of total and count
                Dim voidTotal As Double = 0.0
                Dim c As Integer = 0

                For i = 0 To _dvEndDateOverlap.Count - 1
                    Dim row As ds_RecurringService.RecurringService_CreditsRow = CType(_dvEndDateOverlap.Item(i).Row, ds_RecurringService.RecurringService_CreditsRow)
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

        Private Function CreditVoidCheck() As Boolean
            If (_dvEndDateOverlap.Count > 0) Then
                Dim overlapPrompt As DialogResult = MessageBox.Show("Keeping this End Date will Void " & _dvEndDateOverlap.Count & " Credit(s) for a total of " &
                                                                    FormatCurrency(_dvEndDateOverlap.Table.Compute("SUM(CreditAmount)", "Voided = 0 AND DateOfCredit >= '" & dtp_EndDate.Value.Date & "'")) &
                                                                    ". Do you wish to keep this End Date?", "Void " & _dvEndDateOverlap.Count & " Credit(s)",
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

                If (overlapPrompt = Windows.Forms.DialogResult.Yes) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End Function


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
        Private _balanceChanged As Boolean = False
        Friend Event RefreshBalance(ByVal uCustomerNumber As Integer)
        Private _serviceUpdated As Boolean = False
        Friend Event RefreshService(ByVal uCustomerNumber As Integer, ByVal uRecurringServiceID As Integer)


        Public Sub New(ByVal homeForm As TrashCashHome, ByVal customerName As String, ByVal customerNumber As Integer, Optional ByVal recurringServiceID As Integer = 0)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            ' property refs
            _homeForm = homeForm
            Me.CustomerNumber = customerNumber
            ' fill service table
            ServiceTypesTableAdapter.Fill(Ds_Types.ServiceTypes)
            Me.RecurringServiceID = RecurringServiceID
            Me.CustomerName = customerName

            ' creating dv for credit overlap checking
            _dvEndDateOverlap = New DataView(Ds_RecurringService.RecurringService_Credits, "Voided = 0", "", DataViewRowState.CurrentRows)
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
            If (VaidForEntry()) Then
                ' bool to keep tack of needing to void old enddate credit
                Dim voidOldCreditReason As String = Nothing
                ' result var from 3 different credit outcomes
                Dim creditResult As DialogResult
                ' bool to determine if credits needs to be voided
                Dim voidCredits As Boolean?
              
                ' bring over end date
                If (ck_EndDate.Checked = True) Then
                   ' first checking if something needs to be voided
                    voidCredits = CreditVoidCheck()
                    If (voidCredits) Then
                        ' checking if end date will cause a credit
                        If (Crediting > 0) Then
                            ' checking if old credit needs voided for new one
                            If (EndDateCreditRow IsNot Nothing) Then
                                If (EndDateCreditRow.Voided = False) Then
                                    creditResult = MessageBox.Show("Changing the Service End Date will cause the previous credit of " & FormatCurrency(EndDateCreditRow.CreditAmount) & " to be voided, and a new one of " & FormatCurrency(Crediting) & " to be issued." & vbCrLf & _
                                                                    "Do you want to save these changes?", "Void old Credit and create new.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                    ' updating void vars to be used to update the row
                                    voidOldCreditReason = "Service End Date changed from " & RecurringServiceRow.RecurringServiceEndDate.Date & " to " & dtp_EndDate.Value.Date & "."
                                Else
                                    creditResult = MessageBox.Show("Keeping this Service End Date will cause a credit to be issued for " & FormatCurrency(Crediting) & "." & vbCrLf & _
                                                                    "Do you want to issue this credit?", "Crediting Customer for End Date Overlap", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                End If
                            Else
                                creditResult = MessageBox.Show("Keeping this Service End Date will cause a credit to be issued for " & FormatCurrency(Crediting) & "." & vbCrLf & _
                                                                "Do you want to issue this credit?", "Crediting Customer for End Date Overlap", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            End If
                        Else
                            ' set end date on row
                            RecurringServiceRow.RecurringServiceEndDate = dtp_EndDate.Value.Date
                        End If
                    Else
                        MessageBox.Show("Save Changes canceled. You must pick a Service End Date that doesn't overlap with a credit or void the credits first.",
                                        "Save Changes Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else
                    ' wipe end date
                    RecurringServiceRow.SetRecurringServiceEndDateNull()
                    ' checking if credit was issued for this
                    If (EndDateCreditRow IsNot Nothing) Then
                        ' was it voided?
                        If (EndDateCreditRow.Voided = False) Then
                            Dim voidCreditResult As DialogResult = MessageBox.Show("There was a Credit issued because the Service End Date overlapped with an already invoiced period. Removing this Service End Date will void this Credit." & vbCrLf & _
                                                                                    "Do you wish to Void this Credit and resume the billing?", "Void Exisiting End Date Credit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            ' if yes, then set end date null and set credit row voided
                            If (voidCreditResult = Windows.Forms.DialogResult.Yes) Then
                                RecurringServiceRow.SetRecurringServiceEndDateNull()
                                ' updating void vars to be used to update the row
                                voidOldCreditReason = "Service continuation."
                            Else
                                MessageBox.Show("Save Changes canceled. You must pick a Service End Date that doesn't overlap with a credit or void the credits first.",
                                       "Save Changes Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                ' checking if we need to void overlapping credits
                If (voidCredits IsNot Nothing) Then
                    For i = 0 To _dvEndDateOverlap.Count - 1
                        Dim row As ds_RecurringService.RecurringService_CreditsRow = CType(_dvEndDateOverlap.Item(i).Row, ds_RecurringService.RecurringService_CreditsRow)
                        RecurringService_Credit_Void(row, "Credit for Date overlaped with End Date. New End Date: " & dtp_EndDate.Value.Date & " | Billed Through: " & _billThruDate.Date)
                    Next
                End If

                ' check if voiding old end date credit
                If (voidOldCreditReason IsNot Nothing) Then
                    If (EndDateCreditRow.Voided = False) Then
                        RecurringService_EndDateCredit_Void(EndDateCreditRow, voidOldCreditReason)
                        _balanceChanged = True
                    End If
                End If

                ' checking if new credit needs to be issued
                If (creditResult = Windows.Forms.DialogResult.Yes) Then
                    ' getting service item listid
                    Dim srvcRow As ds_Types.ServiceTypesRow = CType(CType(cmb_ServiceTypes.SelectedItem, DataRowView).Row, ds_Types.ServiceTypesRow)
                    RecurringService_EndDateCredit(RecurringServiceRow, srvcRow.ServiceListID, Crediting, dtp_EndDate.Value.Date, _billThruDate)
                    ' setting balance change
                    _balanceChanged = True
                    _serviceUpdated = True
                Else
                    RecurringServiceRow.SetRecurringServiceEndDateNull()
                End If

                RecurringServiceRow.EndEdit()

                ' checking if anything changed
                If (RecurringServiceRow.RowState <> DataRowState.Unchanged) Then
                    _serviceUpdated = True
                End If

                Cursor = Cursors.WaitCursor
                Try
                    RsTA.Update(RecurringServiceRow)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' checking if service is new to refresh pending approval count on home form
                If (IsNew) Then
                    _homeForm.RefreshApprovCount()
                End If
                Cursor = Cursors.Default
                Close()
            End If

        End Sub

        Private Function VaidForEntry() As Boolean
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
                            control.BackColor = AppColors.TextBoxErr
                        Else
                            ' reset color
                            control.BackColor = AppColors.TextBoxDef
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
            Dim c As Integer = grp_PickupDay.Controls.OfType(Of CheckBox)().Count(Function(control) (control.Checked = True))

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
                ' checking for null values for addr2-4
                If (_custRow.IsCustomerBillingAddr2Null = False) Then
                    ' tb_SrvcAddr1.Text = custRow.CustomerBillingAddr1
                    RecurringServiceRow.RecurringServiceAddr1 = _custRow.CustomerBillingAddr2
                End If
                If (_custRow.IsCustomerBillingAddr3Null = False) Then
                    'tb_SrvcAddr2.Text = custRow.CustomerBillingAddr2
                    RecurringServiceRow.RecurringServiceAddr2 = _custRow.CustomerBillingAddr3
                End If
                If (_custRow.IsCustomerBillingAddr4Null = False) Then
                    'tb_SrvcAddr3.Text = custRow.CustomerBillingAddr3
                    RecurringServiceRow.RecurringServiceAddr3 = _custRow.CustomerBillingAddr4
                End If

                'tb_SrvcCity.Text = custRow.CustomerBillingCity
                RecurringServiceRow.RecurringServiceCity = _custRow.CustomerBillingCity
                'tb_SrvcState.Text = custRow.CustomerBillingState
                RecurringServiceRow.RecurringServiceState = _custRow.CustomerBillingState
                'tb_SrvcZip.Text = custRow.CustomerBillingZip
                RecurringServiceRow.RecurringServiceZip = _custRow.CustomerBillingZip

                ' refresh binding source to tbs have new text
                RecurringServiceBindingSource.ResetCurrentItem()

            End If
        End Sub

        Private Sub RecurringService_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            ' update recid outside property
            _recID = RecurringServiceRow.RecurringServiceID
            ' checking for updates so can throw events
            If (_balanceChanged = True) Then
                RaiseEvent RefreshBalance(CustomerNumber)
            End If
            If (_serviceUpdated = True) Then
                RaiseEvent RefreshService(CustomerNumber, RecurringServiceID)
            End If
        End Sub

      

        Private Sub btn_Approve_Click(sender As System.Object, e As System.EventArgs) Handles btn_Approve.Click
            Dim result As DialogResult = MessageBox.Show("Confirm the following details are accurate to Approve this Recurring Service for billing:" & vbCrLf & vbCrLf & _
                                                         "Rate: " & FormatCurrency(RecurringServiceRow.RecurringServiceRate) & " x " & RecurringServiceRow.RecurringServiceQuantity & " billed every " & RecurringServiceRow.RecurringServiceBillLength & " month(s)." & vbCrLf & _
                                                         "The first invoice will be for " & RecurringServiceRow.RecurringServiceStartDate.Date & " through " & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, RecurringServiceRow.RecurringServiceBillLength, RecurringServiceRow.RecurringServiceStartDate)) & " for " & FormatCurrency(RecurringServiceRow.RecurringServiceRate * RecurringServiceRow.RecurringServiceQuantity) & vbCrLf, "Confirm Details for Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If (result = Windows.Forms.DialogResult.Yes) Then
                Cursor = Cursors.WaitCursor
                Try
                    RecurringServiceRow.Approved = True
                    RecurringServiceRow.EndEdit()
                    RsTA.Update(RecurringServiceRow)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' raise approval event so approval form can refresh
                RaiseEvent ServiceApproved()
                _ServiceUpdated = True
                Close()
            End If
        End Sub

        ' this is the minimum date we can move the end date back. this will either be the service start, or the batch id of 99999 end billing date
        Private _minEndDate As Date
        Private Sub dtp_EndDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtp_EndDate.ValueChanged
            If (ck_EndDate.Checked = True) Then
                ' checking if its a valid date
                If (_minEndDate <= dtp_EndDate.Value.Date) Then
                    ' checking if this will overlap with a credit
                    DvRowFilter = dtp_EndDate.Value.Date

                    ' checking if service bill thru date is greater than the new end date
                    If (_billThruDate > dtp_EndDate.Value.Date) Then
                        ' display estimated credit
                        Dim creditAmount As Decimal = CDec(RsEndCreditTA.EndDateCredit_Calc(RecurringServiceRow.RecurringServiceID, dtp_EndDate.Value.Date))

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
                    Else
                        Crediting = 0
                    End If
                Else
                    MessageBox.Show("End Date cannot be before " & _minEndDate.Date & ".", "Invalid End Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtp_EndDate.Value = _minEndDate
                End If
            Else
                Crediting = 0
            End If
        End Sub

        Private Sub RecurringService_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      ' throwing message if customer is single inv
            If (_custRow.CustomerReceiveOneInvoice = True) Then
                MessageBox.Show("This Customer is marked to receive 1 invoice. All Recurring Services for this Customer will go onto a single invoice, with a due day date of " & DatePart(DateInterval.Day, _custRow.CustomerStartDate) & ", " & vbCrLf & _
                                "and they will be billed every " & _custRow.CustomerBillInterval & " month(s) - REGARDLESS of the Bill Length set for their Recurring Services.", "Single Invoice Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            ' getting min end date we can have, either service end date or batch inv id 99999 end billing date
            _minEndDate = HistoryTA.MinStartBillingDate(RecurringServiceID)
            MsgBox(_minEndDate)
        End Sub

        Private Sub dg_ServiceNotes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dg_ServiceNotes.DoubleClick
            Dim noteText As String = InputBox("Note:", "Quick Add Service Note")
            If (Trim(noteText) <> "") Then
                Try
                    NotesTA.ServiceNotes_Insert(RecurringServiceID, noteText)
                    ' refill grid
                    NotesTA.FillByID(Ds_RecurringService.ServiceNotes, RecurringServiceID)
                Catch ex as SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' updating bool so home uc is refreshed to pickup new note
                _ServiceUpdated = True
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
                            RecurringService_Credit_Void(row, reason)
                            MessageBox.Show("Credit Memo Voided", "Credit Memo Voided", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ' customer balance has changed now
                            _BalanceChanged = True
                            ' refresh credit history grid
                            RsCreditTA.FillByRecID(Ds_RecurringService.RecurringService_Credits, RecurringServiceRow.RecurringServiceID)
                        End If
                    End If
                Else
                    MessageBox.Show("This Credit has already been voided. It was voided by " & row.VoidUser & " on " & row.VoidTime & ". Reason: " & row.Reason & ".", "Credit already Voided", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        End Sub

   
        Private Sub btn_CreateCredit_Click(sender As System.Object, e As System.EventArgs) Handles btn_CreateCredit.Click
            ' making sure we have valid information here
            If (_minEndDate <= dtp_CreditForDate.Value.Date) Then
                If (Trim(tb_CreditAmount.Text) <> "") Then
                    tb_CreditAmount.BackColor = AppColors.TextBoxDef
                    If (Trim(tb_CreditReason.Text) <> "") Then
                        ' refs
                        Dim creditForDate As Date = dtp_CreditForDate.Value.Date
                        Dim creditAlreadyOnDate As Boolean = RsCreditTA.Credit_OnDate(RecurringServiceID, creditForDate)
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
                            Dim srvcRow As ds_Types.ServiceTypesRow = CType(CType(cmb_ServiceTypes.SelectedItem, DataRowView).Row, ds_Types.ServiceTypesRow)
                            RecurringService_Credit(RecurringServiceRow, srvcRow.ServiceListID, tb_CreditAmount.Text, creditForDate, ck_PrintCredit.Checked, tb_CreditReason.Text)
                            ' balance has changed now
                            _balanceChanged = True
                            ' refresh grid
                            Try
                                RsCreditTA.FillByRecID(Ds_RecurringService.RecurringService_Credits, RecurringServiceID)
                            Catch ex As SqlException
                                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                            ' reset controls
                            dtp_CreditForDate.Value = Date.Now
                            tb_CreditAmount.Text = ""
                            tb_CreditReason.Text = ""
                        End If
                    Else
                        MessageBox.Show("You must provide a reason to issue a credit.", "Invalid Credit Reason", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Invalid Credit amount.", "Invalid Credit Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tb_CreditAmount.BackColor = AppColors.TextBoxErr
                End If
                Else
                    MessageBox.Show("Credit Date cannot be before " & _minEndDate.Date & ".", "Invalid Credit Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dtp_CreditForDate.Value = _minEndDate

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
                        dg_CreditHistory.Rows(i).DefaultCellStyle.BackColor = AppColors.GridRed
                        dg_CreditHistory.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridRedSel
                    Else
                        dg_CreditHistory.Rows(i).DefaultCellStyle.BackColor = AppColors.GridGreen
                        dg_CreditHistory.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridGreenSel
                    End If
                Next
            End If
        End Sub

        Private Sub dg_CreditHistory_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_CreditHistory.CellMouseDown
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                For Each row As DataGridViewRow In dg_CreditHistory.SelectedRows
                    row.Selected = False
                Next
                dg_CreditHistory.Rows(e.RowIndex).Selected = True
            End If
        End Sub

        Private Sub cmb_ServiceTypes_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmb_ServiceTypes.SelectionChangeCommitted
            ' getting row
            Dim row As ds_Types.ServiceTypesRow = DirectCast(cmb_ServiceTypes.SelectedItem, ds_Types.ServiceTypesRow)
            ' update default price lbl
            lbl_DefPriceValue.Text = FormatCurrency(row.ServiceRate)
            ' adjust rate box to default
            tb_Rate.Text = CDec(row.ServiceRate)
            ' update bill length
            RecurringServiceRow.RecurringServiceBillLength = row.ServiceBillLength
            ' also going to reset quantity to 1
            RecurringServiceRow.RecurringServiceQuantity = 1
        End Sub

        Private Sub dg_CreditHistory_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg_CreditHistory.RowPrePaint
            ColorCreditHistoryRows()
        End Sub
    End Class
End Namespace