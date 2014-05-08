Imports QBFC12Lib
Imports TrashCash.QB_Queries2
Imports TrashCash.TrashCash_Utils.Err_Handling

Public Class InvoiceVoid
    ' home form ref for getting to classes
    Private _home As TrashCash_Home

    Private _rec_InvTxnID As String
    Private Property Rec_InvTxnID As String
        Get
            Return _rec_InvTxnID
        End Get
        Set(value As String)
            If (_rec_InvTxnID <> value) Then
                _rec_InvTxnID = value
                InvoiceObject = _home.Queries.Invoice_GetBalance(_rec_InvTxnID)
            End If
        End Set
    End Property
    Private WriteOnly Property InvoiceObject As InvoiceTotalBalance
        Set(value As InvoiceTotalBalance)
            tb_Balance.Text = FormatCurrency(value.Balance)
            tb_Total.Text = FormatCurrency(value.Subtotal)
        End Set
    End Property
    Private _startBillingPeriod As Date
    Private Property StartBillingPeriod As Date
        Get
            Return _startBillingPeriod
        End Get
        Set(value As Date)
            If (_startBillingPeriod <> value) Then
                _startBillingPeriod = value
                dtp_StartBill.Value = value
            End If
        End Set
    End Property
    Private _endBillingPeriod As Date
    Private Property EndBillingPeriod As Date
        Get
            Return _endBillingPeriod
        End Get
        Set(value As Date)
            If (_endBillingPeriod <> value) Then
                _endBillingPeriod = value
                dtp_EndBilling.Value = value
            End If
        End Set
    End Property


    ' creating dt and ta
    Dim ta As DataSetTableAdapters.BilledServicesTableAdapter
    Dim dt As DataSet.BilledServicesDataTable
    Dim qta As DataSetTableAdapters.QueriesTableAdapter

    Private Sub btn_Fetch_Click(sender As System.Object, e As System.EventArgs) Handles btn_RecFetch.Click
        ' vars to tell weather inv has been deleted or not
        Dim voided As Boolean = False
        Dim voidDate As New Date
        Dim voidReason As String = String.Empty

        ' holding invoice number var
        Dim InvRefNumber As String = tb_InvNum.Text
        ' getting last inv ref number
        Dim lastInvRefNumber As String
        lastInvRefNumber = qta.BilledServices_GetLastInvByRefNumber(InvRefNumber)

        ' checking for void real quick
        ' filling dt
        dt.Clear()
        ta.FillByInvRefNum(dt, InvRefNumber)

        If (dt.Rows.Count > 0) Then
            For Each row As DataSet.BilledServicesRow In dt.Rows
                If (row.Voided = True) Then
                    voided = True
                    voidDate = row.VoidDate
                    voidReason = row.VoidReason
                    GoTo goto_Voided
                End If
            Next row
        End If

        ' if inv ref num queried for is not the last invoice for that rec service
        ' switch to that invoice and let user know
        If (lastInvRefNumber = Nothing) Then
            MsgBox("No Invoice found with that Ref Number.")
            Exit Sub
        ElseIf (InvRefNumber <> lastInvRefNumber) Then
            MsgBox("The Recurring Service used to generate the Invoice you were looking for, has a later Invoice." & vbCrLf & _
                   "You have been redirected to the details of that Invoice.")
            ' change var to furthest inv ref number
            InvRefNumber = lastInvRefNumber
            tb_InvNum.Text = lastInvRefNumber
        End If

        ' filling dt
        dt.Clear()
        ta.FillByInvRefNum(dt, InvRefNumber)

        ' clearing recurring services table
        Me.DataSet.RecurringService.Clear()

        ' making sure we have rows
        If (dt.Rows.Count > 0) Then
            For Each row As DataSet.BilledServicesRow In dt.Rows
                ' update property to query for total and balance
                ' multi query prevented in property logic
                Rec_InvTxnID = row.InvTxnID

                ' TODO: this will work for now but will get reset if more than 1 service is billed
                ' and they have different periods they are billing for
                StartBillingPeriod = row.StartBillingDate
                EndBillingPeriod = row.EndBillingDate

                ' adding attached recurring service to dt
                RecurringServiceTableAdapter.Fill(Me.DataSet.RecurringService, "TblID", row.RecurringServiceID, "All")
            Next
        Else
            MsgBox("No Invoice found. Note that this will only work for Invoices created from Recurring Services.")
            LockInput(False)
            Exit Sub
        End If

goto_Voided:
        ' checking deleted var
        If (voided = True) Then
            MsgBox("This Invoice has already been voided. It was voided on " & FormatDateTime(voidDate, DateFormat.GeneralDate) & ". The reason provided when it was voided was:" & vbCrLf & voidReason)
            LockInput(False)
        Else
            LockInput(True)
        End If
    End Sub

    Private Sub LockInput(ByVal bool As Boolean)
        If (bool = True) Then
            ' disable/hide inv num box and fetch
            tb_InvNum.Enabled = False
            btn_RecFetch.Visible = False
            ' enable/show reset and grp
            btn_RecReset.Visible = True
            grp_InvInfo.Visible = True
            pnl_RecBtm.Visible = True
        Else
            ' enable/show inv num box and fetch
            tb_InvNum.Enabled = True
            btn_RecFetch.Visible = True
            ' disable/hide reset and grp
            btn_RecReset.Visible = False
            grp_InvInfo.Visible = False
            pnl_RecBtm.Visible = False

            ' clear ivn num box
            tb_InvNum.Text = String.Empty
        End If
    End Sub

    Private Sub btn_Reset_Click(sender As System.Object, e As System.EventArgs) Handles btn_RecReset.Click
        LockInput(False)
        Me.DataSet.RecurringService.Clear()
        dt.Clear()
        _rec_InvTxnID = 0
    End Sub

    Private Sub btn_RecVoid_Click(sender As System.Object, e As System.EventArgs) Handles btn_RecVoid.Click
        Dim promptResult As MsgBoxResult = MsgBox("Are you sure you want to void this Invoice in Quickbooks?", MsgBoxStyle.YesNo)
        If (promptResult = MsgBoxResult.Yes) Then
            Dim input As String = InputBox("If you are absolutely sure you want to void this Invoice, please type the word ""Void"" in the box below.")
            If (input = "Void") Then
                Dim reason As String = InputBox("Please provide a reason for voiding this Invoice.")

                ' making sure they put a reason in
                If (reason.Length > 1) Then

                    ' void invoice

                    _home.Procedures.Invoicing_Void(_rec_InvTxnID)

                    ' looping through dt
                    For Each row As DataSet.BilledServicesRow In dt
                        ta.SetVoidedByRefNum(row.InvRefNumber, reason)
                    Next

                    btn_RecReset.PerformClick()
                Else
                    MsgBox("You must provide a reason when voiding an Invoice.")
                End If
            Else
                MsgBox("You must type ""Void"" with a capital V and without the quotation marks. You typed """ & input & """.")
            End If
        End If
    End Sub



    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ta = New DataSetTableAdapters.BilledServicesTableAdapter
        dt = New DataSet.BilledServicesDataTable
        qta = New DataSetTableAdapters.QueriesTableAdapter
        _home = HomeForm
    End Sub
End Class