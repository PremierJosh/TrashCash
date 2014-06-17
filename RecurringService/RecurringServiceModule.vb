
Imports TrashCash.QBStuff

Namespace RecurringService
    Friend Module RecurringServiceModule
        Friend HistoryTA As New ds_RecurringServiceTableAdapters.RecurringService_BillHistoryTableAdapter
        Friend NotesTA As New ds_RecurringServiceTableAdapters.ServiceNotesTableAdapter
        Friend RsTA As New ds_RecurringServiceTableAdapters.RecurringServiceTableAdapter
        Friend RsCreditTA As New ds_RecurringServiceTableAdapters.RecurringService_CreditsTableAdapter
        Friend RsEndCreditTA As New ds_RecurringServiceTableAdapters.RecurringService_EndDateCreditsTableAdapter
       
   
        Friend Sub RecurringService_EndDateCredit(ByRef row As ds_RecurringService.RecurringServiceRow, ByVal itemListID As String, ByVal creditAmount As Double,
                                                  ByVal newEndDate As Date, ByVal billThruDate As Date)             'return credit
           ' create new credit obj
            Dim creditObj As New QBCreditObj
            With creditObj
                .CustomerListID = GetCustomerListID(row.CustomerNumber)
                .IsToBePrinted = False
                .ItemListID = itemListID
                .TotalAmount = creditAmount
                .Desc = "This service has been Invoiced upto " & billThruDate & ". The new End Date overlaps this Invoiced period. | New End Date: " & newEndDate.Date
            End With
            ' capturing previous end date
            Dim prevEndDate As Date
            If (Not row.IsRecurringServiceEndDateNull) Then
                prevEndDate = row.RecurringServiceEndDate
            End If

            Dim resp As Integer = QBRequests.CreditMemoAdd(creditObj)
            If (resp = 0) Then
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
                    If (prevEndDate = Nothing) Then
                        RsEndCreditTA.EndDateCredits_Insert(row.RecurringServiceID, Nothing, newEndDate, creditAmount,
                                                            creditObj.TxnID, creditObj.TxnDate, CurrentUser.USER_NAME)
                    Else
                        RsEndCreditTA.EndDateCredits_Insert(row.RecurringServiceID, prevEndDate, newEndDate, creditAmount,
                                                            creditObj.TxnID, creditObj.TxnDate, CurrentUser.USER_NAME)
                    End If
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                ' use credit
                QBMethods.UseNewCredit(creditObj)
        End If

        End Sub

        Friend Sub RecurringService_EndDateCredit_Void(ByRef row As ds_RecurringService.RecurringService_EndDateCreditsRow, ByVal voidReason As String)
            ' credit memo void type is 8
            Dim resp As Integer = QBRequests.TxnVoid(row.CreditMemoTxnID, "Credit")
            If (resp = 0) Then
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
            End If
        End Sub

        Friend Sub RecurringService_Credit(ByRef row As ds_RecurringService.RecurringServiceRow, ByVal itemListID As String, ByVal creditAmount As Double,
                                            ByVal dateOfCredit As Date, ByVal print As Boolean, ByVal reason As String)
            Dim creditObj As New QBCreditObj
            With creditObj
                .CustomerListID = GetCustomerListID(row.CustomerNumber)
                .IsToBePrinted = print
                .ItemListID = itemListID
                .TotalAmount = creditAmount
                .DateOfCredit = dateOfCredit
                .Desc = "Credit Issued for Service on " & dateOfCredit & ". Reason: " & reason
            End With

            Dim resp As Integer = QBRequests.CreditMemoAdd(creditObj)
            If (resp = 0) Then
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
        End If
        End Sub

        Friend Sub RecurringService_Credit_Void(ByRef row As ds_RecurringService.RecurringService_CreditsRow, ByVal voidReason As String)
            Dim resp As Integer = QBRequests.TxnVoid(row.CreditMemoTxnID, "Credit")
            If (resp = 0) Then
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
            End If
        End Sub
    End Module
End Namespace