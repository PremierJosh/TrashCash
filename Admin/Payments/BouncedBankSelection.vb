Imports TrashCash.Payments
Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Admin.Payments

    Public Class BouncedBankSelection

        Private _checkRow As ds_Payments.PaymentHistory_DBRow
        Private Property CheckRow As ds_Payments.PaymentHistory_DBRow
            Get
                Return _checkRow
            End Get
            Set(value As ds_Payments.PaymentHistory_DBRow)
                _checkRow = value
                ' set check amount and check ref number
                tb_RefNum.Text = value.RefNumber
                tb_CheckAmount.Text = FormatCurrency(value.Amount)
                ' set ts cmb and get balance
                CustomerToolstrip1.SelectCustomer(value.CustomerNumber)
            End Set
        End Property
        Private _bankRow As ds_Payments.BAD_CHECK_BANKSRow
        Private Property BankRow As ds_Payments.BAD_CHECK_BANKSRow
            Get
                Return _bankRow
            End Get
            Set(value As ds_Payments.BAD_CHECK_BANKSRow)
                _bankRow = value
                ' set fee
                tb_BankFee.Text = FormatCurrency(value.Bank_Fee)
            End Set
        End Property

        ' vars to hold refrence
        Private ReadOnly _appRow As ds_Application.APP_SETTINGSRow
        Public Sub New(ByVal payHistoryID As Integer)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Using ta As New ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter
                _appRow = ta.GetData().Rows(0)
                tb_CustFee.Text = FormatCurrency(_appRow.BAD_CHECK_CUST_FEE)
            End Using
            Using ta As New PaymentHistory_DBTableAdapter
                CheckRow = ta.GetData(payHistoryID).Rows(0)
            End Using
        End Sub

        Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
            Dim result As MsgBoxResult =
                    MsgBox(
                        "Confirm: Bouncing Check Ref Number: " & CheckRow.RefNumber & " - " &
                        FormatCurrency(CheckRow.Amount) & "." & vbCrLf _
                        & "Bank Fee: " & FormatCurrency(BankRow.Bank_Fee) & ". Our Fee: " &
                        FormatCurrency(tb_CustFee.Text) & ".", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then
                BounceCheck()
                MessageBox.Show("Check Bounce completed.", "Check Bounce completed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            End If
        End Sub


        Private Sub BouncedBankSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' fill banks list
            Bad_Check_BanksTableAdapter.Fill(Payments.Bad_Check_Banks)

            ' grabbing default bank selection
            If (cmb_Banks.SelectedValue IsNot Nothing) Then
                BankRow = DirectCast(cmb_Banks.SelectedItem, ds_Payments.Bad_Check_BanksRow)
            End If
            ' hiding locking customer toolstrip
            CustomerToolstrip1.Enabled = False
            CustomerToolstrip1.HideQuickSearch()
        End Sub

        Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
            Close()
        End Sub

        Private Sub Cmb_Banks_SelectionChangeCommitted(sender As ComboBox, e As EventArgs) Handles cmb_Banks.SelectionChangeCommitted
            If (cmb_Banks.SelectedValue IsNot Nothing) Then
                BankRow = DirectCast(cmb_Banks.SelectedItem, ds_Payments.Bad_Check_BanksRow)
            End If
        End Sub

        Private Sub BounceCheck()
            ' need to get invTxnId and checkAddTxnID for setting a check bounced
            Dim invTxnID As String

            ' make invoice
            Dim custInvObj As New QBInvoiceObj
            With custInvObj
                .CustomerListID = GetCustomerListID(CheckRow.CustomerNumber)
                ' default print these
                .IsToBePrinted = True
                .LineList = New List(Of QBLineItemObj)
            End With
            ' item attached to bank and amount of bounced check
            Dim badCheckLine As New QBLineItemObj
            With badCheckLine
                .ItemListID = BankRow.QB_Bank_Inv_Item_ListID
                .Rate = CheckRow.Amount
                .Quantity = 1
                .Desc = "Bounced Check #: " & CheckRow.RefNumber & ". Received on " & CheckRow.DateReceived.Date & " in the amount of " &
                        FormatCurrency(CheckRow.Amount) & "."
            End With
            ' customer fee line
            Dim feeLine As New QBLineItemObj
            With feeLine
                .ItemListID = _appRow.BAD_CHECK_CUSTITEM_LISTID
                .Rate = _appRow.BAD_CHECK_CUST_FEE
                .Quantity = 1
            End With
            ' add line items
            custInvObj.LineList.Add(badCheckLine)
            custInvObj.LineList.Add(feeLine)
            ' send invoice
            Dim invResp As Integer = QBRequests.InvoiceAdd(custInvObj)
            If (invResp = 0) Then
                ' get invTxnID
                invTxnID = custInvObj.TxnID
            Else
               MsgBox("CheckBounce Fail")
                Exit Sub
            End If

            ' doing checkadd to pay bank fee
            Dim checkObj As New QBCheckObj
            With checkObj
                .AccountListID = BankRow.QB_Bank_ListID
                .PayeeListID = BankRow.QB_Vendor_ListID
                .RefNumber = "ReturnCheck"
                .IsToBePrinted = False
                .LineList = New List(Of QBLineItemObj)
            End With
            ' create line for check
            Dim checkLine As New QBLineItemObj
            With checkLine
                .ItemListID = _appRow.BAD_CHECK_CHECKITEM_LISTID
                .Rate = BankRow.Bank_Fee
                .Quantity = 1
            End With
            checkObj.LineList.Add(checkLine)

            Dim checkResp As Integer = QBRequests.CheckAdd(checkObj)
            If (checkResp = 0) Then
                Try
                    'set payment bounced, using invTxnID and ret from checkAdd
                    Using ta As New PaymentHistory_DBTableAdapter
                        ta.SetBounced(CheckRow.PaymentID, CurrentUser.USER_NAME, invTxnID, checkObj.TxnID)
                    End Using
                    ' inserting note for customer that check bounced
                    Using ta As New ds_CustomerTableAdapters.CustomerNotesTableAdapter
                        ta.CustomerNotes_Insert(CheckRow.CustomerNumber, "Bounced Check Ref #: " & CheckRow.RefNumber & ". Bank Fee of " & FormatCurrency(BankRow.Bank_Fee) & ". Customer charged " & FormatCurrency(_appRow.BAD_CHECK_CUST_FEE) & ".")
                    End Using
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Check add fail")
            End If
        End Sub

    End Class
End Namespace