
Imports TrashCash.QBStuff
Imports QBFC12Lib
Imports TrashCash._DataSets

Namespace RecurringService
    Friend Module RecurringServiceModule
        Friend HistoryTA As New ds_RecurringServiceTableAdapters.RecurringService_BillHistoryTableAdapter
        Friend NotesTA As New ds_RecurringServiceTableAdapters.ServiceNotesTableAdapter
        Friend RsTA As New ds_RecurringServiceTableAdapters.RecurringServiceTableAdapter
        Friend RsCreditTA As New ds_RecurringServiceTableAdapters.RecurringService_CreditsTableAdapter
        Friend RsEndCreditTA As New ds_RecurringServiceTableAdapters.RecurringService_EndDateCreditsTableAdapter
       
        '        Private Function GetUnpaidTable(ByVal customerListID As String) As ds_Display.QBUnpaidInvoicesDataTable
        '            ' return table of open invoices and their info
        '            Dim openInvDT As New ds_Display.QBUnpaidInvoicesDataTable
        '
        '            ' building retEleList so my query only returns stuff I need
        '            Dim retEleList As New List(Of String)
        '
        '            ' only need a couple values back
        '            retEleList.Add("TxnID")
        '            retEleList.Add("TxnDate")
        '            retEleList.Add("BalanceRemaining")
        '
        '            Dim resp As IResponse = QBRequests.InvoiceQuery(listID:=customerListID, paidStatus:=ENPaidStatus.psNotPaidOnly, retEleList:=retEleList)
        '
        '            ' status check
        '            If (resp.StatusCode = 0) Then
        '                Dim invRetList As IInvoiceRetList = resp.Detail
        '
        '                For l = 0 To invRetList.Count - 1
        '                    Dim invRet As IInvoiceRet = invRetList.GetAt(l)
        '
        '                    ' adding to table
        '                    openInvDT.AddQBUnpaidInvoicesRow(invRet.TxnID.GetValue, invRet.TxnDate.GetValue, invRet.BalanceRemaining.GetValue,
        '                                                             invRet.BalanceRemaining.GetValue)
        '                    openInvDT.AcceptChanges()
        '                Next
        '            ElseIf (resp.StatusCode <> 1) Then
        '                QBMethods.ResponseErr_Misc(resp)
        '            End If
        '
        '            Return openInvDT
        '        End Function

        Friend Sub RecurringService_EndDateCredit(ByRef row As ds_RecurringService.RecurringServiceRow, ByVal itemListID As String, ByVal creditAmount As Double,
                                                  ByVal newEndDate As Date, ByVal billThruDate As Date)             'return credit
           ' create new credit obj
            Dim creditAddObj As New QBAddCreditObj
            With creditAddObj
                .CustomerListID = GetCustomerListID(row.CustomerNumber)
                .IsToBePrinted = False
                .ItemListID = itemListID
                .CreditAmount = creditAmount
                .Desc = "This service has been Invoiced upto " & billThruDate & ". The new End Date overlaps this Invoiced period. | New End Date: " & newEndDate.Date
            End With

            Dim resp As IResponse = QBRequests.CreditMemoAdd(creditAddObj)
            If (resp.StatusCode = 0) Then
                Dim creditObj As QBCreditObj = QBMethods.ConvertToCreditObj(resp.Detail)
                ' update row
                Try
                    row.RecurringServiceEndDate = newEndDate.Date
                    row.Credited = True
                    RsTA.Update(row)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Try
                    ' insert history
                    If (row.IsRecurringServiceEndDateNull) Then
                        RsEndCreditTA.EndDateCredits_Insert(row.RecurringServiceID, Nothing, newEndDate, creditAmount,
                                                            creditObj.TxnID, creditObj.TxnDate, CurrentUser.USER_NAME)
                    Else
                        RsEndCreditTA.EndDateCredits_Insert(row.RecurringServiceID, row.RecurringServiceEndDate, newEndDate, creditAmount,
                                                            creditObj.TxnID, creditObj.TxnDate, CurrentUser.USER_NAME)
                    End If
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

            End Sub

        Friend Sub RecurringService_EndDateCredit_Void(ByRef row As ds_RecurringService.RecurringService_EndDateCreditsRow, ByVal voidReason As String)
            Dim resp As IResponse = QBRequests.TxnVoid(row.CreditMemoTxnID, ENTxnVoidType.tvtCreditMemo)
            If (resp.StatusCode = 0) Then
                Try
                    ' updating row
                    row.Voided = True
                    row.VoidDateTime = Date.Now
                    row.VoidReason = voidReason
                    row.VoidUser = CurrentUser.USER_NAME
                    RsEndCreditTA.Update(row)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

        End Sub

        Friend Sub RecurringService_Credit(ByRef row As ds_RecurringService.RecurringServiceRow, ByVal itemListID As String, ByVal creditAmount As Double,
                                            ByVal dateOfCredit As Date, ByVal print As Boolean, ByVal reason As String)
            Dim creditAddObj As New QBAddCreditObj
            With creditAddObj
                .CustomerListID = GetCustomerListID(row.CustomerNumber)
                .IsToBePrinted = print
                .ItemListID = itemListID
                .CreditAmount = creditAmount
                .Desc = "Credit Issued for Service on " & dateOfCredit & ". Reason: " & reason
            End With

            Dim resp As IResponse = QBRequests.CreditMemoAdd(creditAddObj)
            If (resp.StatusCode = 0) Then
                Dim creditObj As QBCreditObj = QBMethods.ConvertToCreditObj(resp.Detail)
                Try
                    ' insert record
                    RsCreditTA.Insert(row.RecurringServiceID,
                                            creditObj.TxnID,
                                            dateOfCredit,
                                            creditObj.TotalAmount,
                                            creditObj.TxnDate,
                                            reason,
                                            CurrentUser.USER_NAME,
                                            False,
                                            Nothing,
                                            Nothing,
                                            Nothing)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' use credit
                QBMethods.UseNewCredit(creditObj)
            Else
                GlobalConMgr.ResponseErr_Misc(resp)
            End If
        End Sub

        Friend Sub RecurringService_Credit_Void(ByRef row As ds_RecurringService.RecurringService_CreditsRow, ByVal voidReason As String)
            Dim resp As IResponse = QBRequests.TxnVoid(row.CreditMemoTxnID, ENTxnVoidType.tvtCreditMemo)
            If (resp.StatusCode = 0) Then
                Try
                    ' credit voided: update row
                    row.Voided = True
                    row.VoidReason = voidReason
                    row.VoidTime = Date.Now
                    row.VoidUser = CurrentUser.USER_NAME
                    RsCreditTA.Update(row)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If
        End Sub
    End Module
End Namespace