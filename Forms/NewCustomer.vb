Imports QBFC12Lib
Imports System

Public Class NewCustomer
    ' event to let customer form know we are done
    Friend Event NewCustomerAdded(ByVal CustomerNumber As Integer)

    ' home form ref var
    Private _home As TrashCash_Home

    Private custRow As DataSet.CustomerRow
    ' LOAD EVENTS
    Private Sub CustomerForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        custRow = Me.DataSet.Customer.NewCustomerRow
        Me.DataSet.Customer.AddCustomerRow(custRow)
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _home = HomeForm
        ' bind bill interval visible to single invoice schedule
        nud_BillInterval.DataBindings.Add("Visible", Me.ck_SingleInv, "Checked")
    End Sub
    Private Sub createCustBtn_Click(sender As System.Object, e As System.EventArgs) Handles createCustBtn.Click
        If (textCheck() = True) Then
            ' start date and one invoice info
            custRow.CustomerReceiveOneInvoice = ck_SingleInv.Checked

            ' customer is active obviously
            custRow.CustomerIsDeactive = 0

            ' setting BilledInAdvance
            custRow.CustomerBilledInAdvance = billedAdvanceChkBox.Checked

            ' setting Print Invoices
            custRow.CustomerPrintInvoices = printInvoicesChkBox.Checked

            ' setting bill interval
            custRow.CustomerBillInterval = nud_BillInterval.Value
            custRow.CustomerStartDate = startDatePicker.Value

            ' push to table so i have a customer number
            custRow.EndEdit()
            Me.CustomerTableAdapter.Update(custRow)

            ' sending row to customer add function
            Dim addOK As Boolean = _home.Procedures.Customer_New(custRow)

            If (addOK) Then
                'Dim result As MsgBoxResult = MsgBox("Would you like to set up Recurring Services for this Customer now?" & vbCrLf & _
                '                                    "Recurring Services can be added at any time.", vbYesNo)
                'If (result = MsgBoxResult.Yes) Then
                '    Dim newForm As New RecurringServicesForm
                '    newForm.CurrentCustomer = custRow.CustomerNumber
                '    newForm.RecurringServiceID = 0
                '    newForm.ShowDialog()
                'End If
                RaiseEvent NewCustomerAdded(custRow.CustomerNumber)
                Me.Close()
            End If
        Else
            MsgBox("Missing required fields.")
        End If

    End Sub
    Private Sub ck_SingleInv_Click(sender As System.Object, e As System.EventArgs) Handles ck_SingleInv.Click
        If (ck_SingleInv.Checked = True) Then
            Dim result As MsgBoxResult = MsgBox("Marking this Customer as Single Invoice will cause all Recurring Services to bill within that Customers bill interval - no matter the service." & vbCrLf & _
                                                "For example, Toters will bill every 1 month if this Customers bill interval is set to 1. It is good practice to make sure this interval matches their Recurring Service bill lengths." & vbCrLf & _
                                                "Do you wish to change this Customer to Single Invoice?")
            If (result = MsgBoxResult.No) Then
                ck_SingleInv.Checked = False
            Else
                ck_SingleInv.Checked = True
            End If

        End If
    End Sub
    Private Function NamesOK()
        If (Trim(tb_FirstName.Text) = "" And Trim(tb_LastName.Text) = "") Then
            If (Trim(tb_CompanyName.Text) = "") Then
                Return False
            Else
                Return True
            End If
        ElseIf (Trim(tb_FirstName.Text) <> "" And Trim(tb_LastName.Text) <> "") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function textCheck()
        Dim errorCount As Integer = 0
        Dim defaultColor = SystemColors.Window

        If (Not NamesOK()) Then
            errorCount += 1
            MsgBox("Either a Company name is required, or both a First and Last name is required.")
        End If

        If (box_CustBillAddr1.Text.Length = 0) Then
            errorCount += 1
            box_CustBillAddr1.BackColor = Color.MistyRose
        Else
            box_CustBillAddr1.BackColor = defaultColor
        End If

        If (box_CustBillCity.Text.Length = 0) Then
            errorCount += 1
            box_CustBillCity.BackColor = Color.MistyRose
        Else
            box_CustBillCity.BackColor = defaultColor
        End If

        If (box_CustBillState.Text.Length = 0) Then
            errorCount += 1
            box_CustBillState.BackColor = Color.MistyRose
        Else
            box_CustBillState.BackColor = defaultColor
        End If

        If (box_CustBillZip.Text.Length = 0) Then
            errorCount += 1
            box_CustBillZip.BackColor = Color.MistyRose
        Else
            box_CustBillZip.BackColor = defaultColor
        End If

        If (nud_BillInterval.Value < 1) Then
            errorCount += 1
            nud_BillInterval.BackColor = Color.MistyRose
        Else
            nud_BillInterval.BackColor = defaultColor
        End If

        If (errorCount = 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub box_CustBillAddr1_Enter(sender As System.Object, e As System.EventArgs) Handles box_CustBillAddr1.Enter
        ' when addr1 is entered, if company name exists, put it as addr1
        ' if last and first is present, add2 becomes first last
        ' if no company name, add1 becomes last, first
        If (box_CustBillAddr1.TextLength < 1) Then
            If (tb_CompanyName.TextLength > 1) Then
                box_CustBillAddr1.Text = tb_CompanyName.Text
                If (tb_FirstName.TextLength > 1 And tb_LastName.TextLength > 1) Then
                    box_CustBillAddr2.Text = tb_FirstName.Text & " " & tb_LastName.Text
                End If
            ElseIf (tb_FirstName.TextLength > 1 And tb_LastName.TextLength > 1) Then
                box_CustBillAddr1.Text = tb_LastName.Text & ", " & tb_FirstName.Text
            End If
        End If
    End Sub
End Class