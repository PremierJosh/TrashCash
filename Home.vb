'Imports QBFC12Lib
'Imports System
'Imports System.Data

' '''''' DataExtRef Info: '''''''''''
''   DataExtName  |   DataExtType  '
'' Customer Number|	detSTR255TYPE '
'' Service Type   |  detSTR255TYPE '
'' Start Date	 |  detSTR255TYPE '
' '''''''''''''''''''''''''''''''''''
' '''''''' Item List Refrence ''''''''''''''''''''''''''''
' ''''''''Name''''''''''''''''''''ListID'''''''''''''''''Rate/Price
''Trash Collection	            80000001-1380224729	    0
''Trash Collection:2yd Dumpster	80000004-1380225095	    50
''Trash Collection:3yd Dumpster	80000005-1380225112	    65
''Trash Collection:4yd Dumpster	80000006-1380225126	    80
''Trash Collection:Curbside	    80000002-1380224754	    20
''Trash Collection:Toters	    80000003-1380224840	    70
' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' '''''''''''''''''''' Payment Method Refrence''''''''''''''''
''Cash	            80000001-1379431236	    pmtCash
''Check	            80000002-1379431236	    pmtCheck
''American Express	80000003-1379431254	    pmtAmericanExpress
''Discover	        80000004-1379431254	    pmtDiscover
''MasterCard	        80000005-1379431254	    pmtMasterCard
''Visa	            80000006-1379431254	    pmtVisa
''Debit Card	        80000007-1379431254	    pmtDebitCard
''Gift Card	        80000008-1379431254	    pmtGiftCard
''E-Check	        80000009-1379431254	    pmtECheck
' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'Public Class Home
'    ' global events
'    Public Event RefreshForm(ByVal formName As String)

'    ' this is the sessMgr all requests go through
'    Friend sessMgr As New QBSessionManager

'    ' these TA's are used to pass necessary tables for batching, and for refreshing the prepared batch counts
'    Dim workingInvoiceTA As New QBDataSetTableAdapters.WorkingInvoiceTableAdapter
'    Dim workingPaymentsTA As New QBDataSetTableAdapters.WorkingPaymentsTableAdapter

'    ' LOAD EVENTS
'    Public Sub HomeForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
'        ' setting the Home forms spawn location to match the Splash screens location
'        Me.Location = LoadSplash.Location

'        ' these are the ONLY OpenConnection and BeginSession calls in this application
'        sessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
'        'TODO: this needs better handeling - Keith mentioned a registry refrence
'        sessMgr.BeginSession("C:\Users\Public\Documents\Intuit\QuickBooks\Company Files\Test.QBW", ENOpenMode.omDontCare)

'        ' initial batch check to fire on load
'        refreshBatch()
'        LoadSplash.Close()
'    End Sub

'    ' CLOSING EVENTS
'    Private Sub HomeForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'        sessMgr.EndSession()
'        sessMgr.CloseConnection()
'    End Sub

'    ' VIEW {FORM} CLICKS
'    Private Sub customersBtn_Click(sender As System.Object, e As System.EventArgs) Handles customersBtn.Click
'        Customer.Show()
'    End Sub
'    Private Sub invoicingBtn_Click(sender As System.Object, e As System.EventArgs) Handles invoicingBtn.Click
'        Invoicing.Show()
'    End Sub
'    Private Sub paymentsBtn_Click(sender As System.Object, e As System.EventArgs) Handles paymentsBtn.Click
'        Payments.Show()
'    End Sub

'    ' REFRESH BATCH SUBROUTINE
'    ''' <summary>
'    ''' Query DB for row counts in the WorkingInvoice table
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Sub refreshBatch()
'        ' checking for Custom invoices to be batched
'        workingInvoiceTA.FillForCount(Me.QBDataSet.WorkingInvoice, "Custom")
'        If (Me.QBDataSet.WorkingInvoice.Rows.Count > 0) Then
'            Dim count As Integer = Me.QBDataSet.WorkingInvoice.Rows.Count
'            custInvRadioBtn.Enabled = True
'            custInvCountLbl.Text = count
'            custInvCountLbl.Visible = True
'        Else
'            custInvRadioBtn.Checked = False
'            custInvRadioBtn.Enabled = False
'            custInvCountLbl.Visible = False
'        End If

'        ' checking for Automatic invoices to be batched
'        workingInvoiceTA.FillForCount(Me.QBDataSet.WorkingInvoice, "Auto")
'        If (Me.QBDataSet.WorkingInvoice.Rows.Count > 0) Then
'            Dim count As Integer = Me.QBDataSet.WorkingInvoice.Rows.Count
'            autoInvRadioBtn.Enabled = True
'            autoInvCountLbl.Text = count
'            autoInvCountLbl.Visible = True
'        Else
'            autoInvRadioBtn.Checked = False
'            autoInvRadioBtn.Enabled = False
'            autoInvCountLbl.Visible = False
'        End If

'        ' checking for Payments to be batched
'        workingPaymentsTA.FillForCount(Me.QBDataSet.WorkingPayments)
'        If (Me.QBDataSet.WorkingPayments.Rows.Count > 0) Then
'            Dim count As Integer = Me.QBDataSet.WorkingPayments.Rows.Count
'            paymentRadioBtn.Enabled = True
'            paymentCountLbl.Text = count
'            paymentCountLbl.Visible = True
'        Else
'            paymentRadioBtn.Checked = False
'            paymentRadioBtn.Enabled = False
'            paymentCountLbl.Visible = False
'        End If

'        ' clearing for memory
'        Me.QBDataSet.Clear()
'    End Sub

'    ' TICKER TO REFRESH PREPARED BATCH COUNT - (10 SECOND INTERVAL)
'    Private Sub batchRefreshTimer_Tick(sender As System.Object, e As System.EventArgs) Handles batchRefreshTimer.Tick
'        refreshBatch()
'    End Sub

'    'TEMP: the testing form needs to be removed before publish
'    Private Sub testFormBtn_Click(sender As System.Object, e As System.EventArgs) Handles testFormBtn.Click
'        Testing.Show()
'    End Sub

'    Private Sub batchRadioBtn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles paymentRadioBtn.CheckedChanged, custInvRadioBtn.CheckedChanged, autoInvRadioBtn.CheckedChanged
'        ' this will enable to Batch button when theres something to batch and its selected
'        If (sender.enabled = True) Then
'            If (sender.checked = True) Then
'                batchBtn.Enabled = True
'            Else
'                batchBtn.Enabled = False
'            End If
'        End If
'    End Sub

'    Private Sub batchBtn_Click(sender As System.Object, e As System.EventArgs) Handles batchBtn.Click
'        If (custInvRadioBtn.Checked = True) Then
'            'Custom Invoice Batching
'            QB_BatchInvoice("Custom")
'        ElseIf (autoInvRadioBtn.Checked = True) Then
'            'Automatic Invoice Batching
'            QB_BatchInvoice("Auto")
'        ElseIf (paymentRadioBtn.Checked = True) Then
'            'Payment Batching
'            QB_BatchRecievePayment()
'        End If
'        refreshBatch()
'    End Sub

'    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles refreshBtn.Click
'        refreshBatch()
'    End Sub

'    Private Sub autoView_Click(sender As System.Object, e As System.EventArgs)
'        'RecurringServices.Show()
'    End Sub
'End Class
