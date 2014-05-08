Public Class UC_RecSrvcDetails

    ' Recurring Service ID
    Private _isNew As Boolean = False
    Private _lastInvDate As Date = Nothing

    ' easier access to row we are working with
    Protected row As DataSet.RecurringServiceRow
    ' event to let parent know im done
    Friend Event CommitComplete()

    Private _recSrvcID As Integer
    Public Property RecurringServiceID As Integer
        Get
            Return _recSrvcID
        End Get
        Set(value As Integer)
            _recSrvcID = value
            If (value <> 0) Then
                ' recSrvcID was passed
                ModifyForm()
            End If
        End Set
    End Property

    ' home form property
    Private _home As TrashCash_Home
    Friend Property _HomeForm As TrashCash_Home
        Get
            Return _home
        End Get
        Set(value As TrashCash_Home)
            _home = value
        End Set
    End Property

    ' current customer property. nothing happens on set or get, just used for refrence
    Private _currentCustomer As Integer
    Private Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            _currentCustomer = value
        End Set
    End Property

    Public Sub NewService(ByVal CustomerNumber As Integer)
        ' set reference property
        CurrentCustomer = CustomerNumber

        row = Me.DataSet.RecurringService.NewRecurringServiceRow
        ' setting cust num
        row.CustomerNumber = CustomerNumber
        ' default 1 quantity
        row.RecurringServiceQuantity = 1
        ' setting start date
        row.RecurringServiceStartDate = dtp_StartDate.Value
        ' allow end date setting
        dtp_EndDate.Visible = True
        ' set index to address tab (1)
        tc_RecSrvc.SelectedIndex = 1
        ' setting service type id
        row.ServiceTypeID = 0
        ' setting bill length
        row.RecurringServiceBillLength = 0
        ' update isnew var
        _isNew = True

        ' adding to table
        Me.DataSet.EnforceConstraints = False
        Me.DataSet.RecurringService.AddRecurringServiceRow(row)
        'Me.DataSet.EnforceConstraints = True
    End Sub

    Private Sub ModifyForm()
        Me.RecurringServiceTableAdapter.Fill(Me.DataSet.RecurringService, "TblID", _recSrvcID, "All")
        'Me.ServiceNotesTableAdapter.Fill(Me.DataSet.ServiceNotes, _recSrvcID, Date.MinValue, Date.MaxValue)

        If (Me.DataSet.RecurringService.Rows.Count = 1) Then
            ' easier access to row
            row = CType(Me.DataSet.RecurringService.Rows(0), DataSet.RecurringServiceRow)
            ' queries ta
            Dim qta As New DataSetTableAdapters.QueriesTableAdapter

            ' update this so end date changing doesnt throw error
            dtp_StartDate.Value = row.RecurringServiceStartDate

            ' updating currentcustomer property
            CurrentCustomer = row.CustomerNumber

            ' var to mod message
            Dim lockMessage As Integer = 0

            ' END DATE ENABLE/DISABLE CHECKING
            _lastInvDate = qta.RecurringService_LastInvDate(RecurringServiceID)
            If (_lastInvDate <> Nothing) Then
                ' lock details
                LockDetails()
                ' update and show last inv date header
                lbl_LastInvDate.Visible = True
                lbl_LastInvHeader.Visible = True
                lbl_LastInvDate.Text = _lastInvDate

                ' need to prompt all locked - minus end date
                lockMessage = 1
            End If

            ' checking if end date is set
            If (row.IsRecurringServiceEndDateNull = False) Then
                ' lock details
                LockDetails()
                ' end date IS SET 
                ck_EndDate.Checked = True
                dtp_EndDate.Value = row.RecurringServiceEndDate

                ' if End Date has passed
                If (row.RecurringServiceEndDate.Date < Date.Now.Date) Then
                    grp_EndDate.Enabled = False
                    btn_Commit.Enabled = False

                    ' prompt saying while form locked and why
                    lockMessage = 2
                End If


                'need to check if credit has been issued
                ' if service has been credited - disable end date changing
                ' if it hasnt been credited yet, they can change the date
                If (row.IsCreditedNull) Then
                    ' updating this to not be null anymore
                    row.Credited = False
                    If (row.Credited = True) Then
                        grp_EndDate.Enabled = False
                        btn_Commit.Enabled = False

                        ' prompt saying whole form locked and why
                        lockMessage = 3
                    End If
                End If
            End If

            ' change btn_Commit text
            btn_Commit.Text = "Save Changes"

            ' display message
            If (lockMessage = 1) Then
                ' invoiced
                'MsgBox("This Recurring Service has already been Invoiced. You can only change its End Date.")
            ElseIf (lockMessage = 2) Then
                'MsgBox("The End Date for this Recurring Service has passed. You will not be able to change anything.")
            ElseIf (lockMessage = 3) Then
                'Invoiced and credited
                'MsgBox("This Recurring Service has already been Invoiced and Credited. You will only be able to view the notes or details of this Recurring Service.")
            End If
        End If

    End Sub
    Private Sub LockDetails()
        ' service HAS been invoice, so need to disable controls
        Cmb_ServiceTypes.Enabled = False
        tb_Rate.Enabled = False
        nud_BillLength.Enabled = False
        dtp_StartDate.Enabled = False
        grp_PickupDay.Enabled = False
    End Sub

    Private Sub btn_Commit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Commit.Click
        If (Me.DataSet.RecurringService.Rows.Count = 1) Then
            If (requiredFieldsCheck() = True) Then
                ' update service selection
                row.ServiceTypeID = Cmb_ServiceTypes.SelectedValue
                If (_isNew = True) Then
                    ' *New* Recurring Service
                    CommitNew()
                Else
                    ' *Modify* Recurring Service Commit
                    CommitModify()
                End If
            End If
        End If

    End Sub

    Private Sub CommitNew()

        Dim msgResult As MsgBoxResult = MsgBox("Service: " & Cmb_ServiceTypes.GetItemText(Cmb_ServiceTypes.SelectedItem).ToString & vbCrLf & _
                                                   "Rate: " & FormatCurrency(tb_Rate.Text) & vbCrLf & _
                                                   "Starting on " & dtp_StartDate.Value.Date & "." & vbCrLf & vbCrLf & _
                                                   "Are you sure you want to set up this Recurring Service?", vbYesNo)
        If (msgResult = MsgBoxResult.Yes) Then
            'checking if end date is set and prompting
            ' setting service type id
            row.ServiceTypeID = Cmb_ServiceTypes.SelectedValue

            If (ck_EndDate.Checked = True) Then
                Dim promptResult As MsgBoxResult = MsgBox("There is an End Date set of " & dtp_EndDate.Value.Date & ". When this date passes " & _
                                                          "you will not be able to extend it, you will have to create a New Recurring Service. " & vbCrLf & _
                                                          "End Date's are NOT required for setting up a Recurring Service." & vbCrLf & vbCrLf & _
                                                          "If you want to keep this End Date click Yes." & vbCrLf & _
                                                          "If you want to Remove this End Date for now, and save this Service, Click No." & vbCrLf & _
                                                          "If you want to Cancel out of this, click Cancel.", vbYesNoCancel)

                If (promptResult = MsgBoxResult.Cancel) Then
                    ' bail out
                    Exit Sub
                ElseIf (promptResult = MsgBoxResult.Yes) Then
                    ' commit the end date
                    row.RecurringServiceEndDate = dtp_EndDate.Value.Date
                End If
            End If
            ' lets commit 
            Try
                row.EndEdit()
                Me.RecurringServiceTableAdapter.Update(Me.DataSet.RecurringService)
                RaiseEvent CommitComplete()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub CommitModify()
        ' checking if end date set
  
        If (ck_EndDate.Checked = True) Then
            ' prompt they are about to set an end date
            Dim promptResult As MsgBoxResult = MsgBox("There is an End Date set of " & dtp_EndDate.Value.Date & ". When this date passes " & _
                                                    "you will not be able to extend it, you will have to create a New Recurring Service. " & vbCrLf & _
                                                    "End Date's are NOT required for Recurring Services." & vbCrLf & vbCrLf & _
                                                    "If you want to keep this End Date click Yes." & vbCrLf & _
                                                    "If you want to Remove this End Date for now, and save this Service, Click No." & vbCrLf & _
                                                    "If you want to Cancel out of this, click Cancel.", vbYesNoCancel)
            If (promptResult = MsgBoxResult.Cancel) Then
                ' bail out
                Exit Sub
            ElseIf (promptResult = MsgBoxResult.Yes) Then

                Dim oldEndDate As Date
                ' var to hold previous end date
                If (row.IsRecurringServiceEndDateNull = False) Then
                    oldEndDate = row.RecurringServiceEndDate.Date
                End If

                ' setting end date
                row.RecurringServiceEndDate = dtp_EndDate.Value.Date

                If (row.IsCreditedNull) Then
                    row.Credited = False
                End If

                ' if it hasnt been credited yet, they can change the date
                If (row.Credited = False) Then

                    ' checking week day count between new end date and last inv date
                    If (_lastInvDate <> Nothing) Then
                        Dim qta As New ds_ProgramTableAdapters.QueriesTableAdapter
                        Dim creditAmount As Decimal = CDec(qta.RecurringService_Credit(row.RecurringServiceID, DateAdd(DateInterval.Day, 1, dtp_EndDate.Value.Date)))

                        ' checking if a credit is needed
                        If (creditAmount > 0) Then
                            ' need to run a check here against the db and see if we need to create an credit.
                            '   if yes create credit, then run credit script
                            '   if no, exit and set dtp_EndDate to focus

                            Dim creditPromptResult As MsgBoxResult = MsgBox("Keeping this End Date will cause a credit to be issued for " & FormatCurrency(creditAmount) & "." & vbCrLf & _
                                                                            "This credit will automatically be used to pay future Invoices. Do you wish to keep this End Date?", vbYesNo)
                            If (creditPromptResult = MsgBoxResult.No) Then
                                ' bail out and focus dtp_EndDate
                                Me.DataSet.RecurringService.Rows(0).Item("RecurringServiceEndDate") = DBNull.Value
                                dtp_EndDate.Focus()
                                SendKeys.Send("{F4}")
                                Exit Sub
                            Else
                                ' set credited to 1
                                ' TEST: test this
                                _HomeForm.Procedures.Customer_CreditMemoForRecService(row, creditAmount, dtp_EndDate.Value.Date)
                            End If
                        Else
                            ' set date
                            row.RecurringServiceEndDate = dtp_EndDate.Value.Date
                        End If
                    End If
                    'Else
                    'Me.DataSet.RecurringService.Rows(0).Item("RecurringServiceEndDate") = DBNull.Value
                End If
                Else
                    row.SetRecurringServiceEndDateNull()
                End If
        Else
            row.SetRecurringServiceEndDateNull()
        End If

        ' lets commit
        Try
            row.EndEdit()
            Me.RecurringServiceTableAdapter.Update(row)
            RaiseEvent CommitComplete()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function requiredFieldsCheck()
        'vars for refrence and error tracking
        Dim err As Integer = 0
        Dim defaultColor = SystemColors.Window
        Dim errorColor = Color.MistyRose

        ' switching tab to init tbs
        ' tc_RecSrvc.SelectedIndex = 1
        AddrInfo.PerformLayout()

        ' bill length checking
        If (nud_BillLength.Value <= 0) Then
            nud_BillLength.BackColor = errorColor
            err += 1
        Else
            nud_BillLength.BackColor = defaultColor
        End If

        ' making sure rate has a value
        If (tb_Rate.TextLength < 1) Then
            err += 1
            tb_Rate.BackColor = errorColor
        Else
            tb_Rate.BackColor = defaultColor
        End If

        ' switching tab real quick to load all ded
        tc_RecSrvc.SelectedIndex = 1

        ' adding requirement for service address
        If (Trim(tb_SrvcAddr1.Text) = "") Then
            tb_SrvcAddr1.BackColor = errorColor
            err = +1
            ' set index to address tab (1)
            tc_RecSrvc.SelectedIndex = 1
        Else
            tb_SrvcAddr1.BackColor = defaultColor
        End If

        If (Trim(tb_SrvcCity.Text) = "") Then
            tb_SrvcCity.BackColor = errorColor
            err = +1
            ' set index to address tab (1)
            tc_RecSrvc.SelectedIndex = 1
        Else
            tb_SrvcCity.BackColor = defaultColor
        End If

        If (Trim(tb_SrvcState.Text) = "") Then
            tb_SrvcState.BackColor = errorColor
            err += 1
            ' set index to address tab (1)
            tc_RecSrvc.SelectedIndex = 1
        Else
            tb_SrvcState.BackColor = defaultColor
        End If

        If (Trim(tb_SrvcZip.Text) = "") Then
            tb_SrvcZip.BackColor = errorColor
            err += 1
            ' set index to address tab (1)
            tc_RecSrvc.SelectedIndex = 1
        Else
            tb_SrvcZip.BackColor = defaultColor
        End If

        ' making sure we have a day selected
        If (Not DaySelected()) Then
            err += 1
            MsgBox("You must select at least 1 pickup day.")
        End If

        If (err = 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function DaySelected()
        Dim dayOK As Boolean
        ' loop through all checkboxes in pickup day grp box
        For Each ck As CheckBox In grp_PickupDay.Controls
            If (ck.Checked = True) Then
                dayOK = True
            End If
        Next

        Return dayOK
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' binding dtp_EndDate to ck_EndDate so i dont have to handle the events
        dtp_EndDate.DataBindings.Add("Visible", Me.ck_EndDate, "Checked")
    End Sub
    Private Sub UC_RecSrvcDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' initial default price and bill length
        If (Cmb_ServiceTypes.Items.Count > 0) Then
            If (row.ServiceTypeID <> 0) Then
                Cmb_ServiceTypes.SelectedValue = row.ServiceTypeID
            End If

            lbl_DefPriceValue.Text = FormatCurrency(Cmb_ServiceTypes.SelectedServiceRate)
            If (row.RecurringServiceBillLength = 0) Then
                nud_BillLength.Value = Cmb_ServiceTypes.SelectedServiceLength
                row.RecurringServiceBillLength = nud_BillLength.Value
            End If
        End If
    End Sub


    Private Sub ServiceTypesComboBox1_ServiceChanged(ByVal ServiceID As Decimal, ByVal Rate As Double, ByVal BillLength As Integer) Handles Cmb_ServiceTypes.ServiceChanged
        ' update lbl
        lbl_DefPriceValue.Text = FormatCurrency(Rate)
        nud_BillLength.Value = BillLength
        ' updating row
        row.RecurringServiceBillLength = BillLength
    End Sub

    Private Sub cm_i_NewNote_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_NewNote.Click
        If (RecurringServiceID <> 0) Then
            Dim newNote As New RecSrvcNote
            newNote.srvcRow = Me.DataSet.RecurringService.Rows(0)
            newNote.ShowDialog()
        End If
    End Sub

    Private Sub dtp_EndDate_ValueChanged(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles dtp_EndDate.Validating
        If (dtp_EndDate.Value.Date < dtp_StartDate.Value.Date) Then
            MsgBox("Recurring Service End Date cannot be before its Start Date.")
            e.Cancel = True
        End If
    End Sub

    Private Sub dtp_StartDate_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles dtp_StartDate.Validating
        If (ck_EndDate.Checked = True) Then
            If (dtp_StartDate.Value.Date > dtp_EndDate.Value.Date) Then
                MsgBox("Recurring Service Start Date cannot be after its End Date.")
                e.Cancel = True
            End If
        End If
    End Sub

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
            Dim ta As New DataSetTableAdapters.CustomerTableAdapter
            Dim custRow As DataSet.CustomerRow = ta.GetDataByCustomerNumber(CurrentCustomer).Rows(0)

            ' updating addr tbs
            ' checking for null values for addr1-3
            If (custRow.IsCustomerBillingAddr1Null = False) Then
                ' tb_SrvcAddr1.Text = custRow.CustomerBillingAddr1
                row.RecurringServiceAddr1 = custRow.CustomerBillingAddr1
            End If
            If (custRow.IsCustomerBillingAddr2Null = False) Then
                'tb_SrvcAddr2.Text = custRow.CustomerBillingAddr2
                row.RecurringServiceAddr2 = custRow.CustomerBillingAddr2
            End If
            If (custRow.IsCustomerBillingAddr3Null = False) Then
                'tb_SrvcAddr3.Text = custRow.CustomerBillingAddr3
                row.RecurringServiceAddr3 = custRow.CustomerBillingAddr3
            End If

            'tb_SrvcCity.Text = custRow.CustomerBillingCity
            row.RecurringServiceCity = custRow.CustomerBillingCity
            'tb_SrvcState.Text = custRow.CustomerBillingState
            row.RecurringServiceState = custRow.CustomerBillingState
            'tb_SrvcZip.Text = custRow.CustomerBillingZip
            row.RecurringServiceZip = custRow.CustomerBillingZip

            ' refresh binding source to tbs have new text
            RecurringServiceBindingSource.ResetCurrentItem()

            ' getting rid of references
            ta = Nothing
            custRow = Nothing
        End If
    End Sub

    Private Sub ServiceTypesComboBox1_ServiceChanged(ServiceID As System.Int32, Rate As System.Double, BillLength As System.Int32) Handles Cmb_ServiceTypes.ServiceChanged

    End Sub
End Class
