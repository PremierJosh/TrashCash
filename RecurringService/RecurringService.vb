﻿Imports TrashCash.Modules
Imports TrashCash.Classes
Imports QBFC12Lib

Namespace RecurringService
    Friend Module RecurringService

        Private Function GetUnpaidTable(ByVal customerListID As String) As ds_Display.QBUnpaidInvoicesDataTable
            ' return table of open invoices and their info
            Dim openInvDT As New ds_Display.QBUnpaidInvoicesDataTable

            ' building retEleList so my query only returns stuff I need
            Dim retEleList As New List(Of String)

            ' only need a couple values back
            retEleList.Add("TxnID")
            retEleList.Add("TxnDate")
            retEleList.Add("BalanceRemaining")

            Dim resp As IResponse = QBRequests.InvoiceQuery(customerListID:=customerListID, paidStatus:=ENPaidStatus.psNotPaidOnly, retEleList:=retEleList)

            ' status check
            If (resp.StatusCode = 0) Then
                Dim invRetList As IInvoiceRetList = resp.Detail

                For l = 0 To invRetList.Count - 1
                    Dim invRet As IInvoiceRet = invRetList.GetAt(l)

                    ' adding to table
                    openInvDT.AddQBUnpaidInvoicesRow(invRet.TxnID.GetValue, invRet.TxnDate.GetValue, invRet.BalanceRemaining.GetValue,
                                                             invRet.BalanceRemaining.GetValue)
                    openInvDT.AcceptChanges()
                Next
            ElseIf (resp.StatusCode <> 1) Then
                QBMethods.ResponseErr_Misc(resp)
            End If

            Return openInvDT
        End Function

        Private Function UseCredit(ByVal customerListID As String, ByRef unpaidDT As ds_Display.QBUnpaidInvoicesDataTable, ByVal creditObj As QBCreditObj)
            While creditObj.CreditRemaining > 0
                For Each row As ds_Display.QBUnpaidInvoicesRow In unpaidDT
                    ' creating applied inv item from the row
                    Dim invObj As New QBInvoiceObj(row.Inv_TxnID)
                    invObj.BalanceRemaining = row.Remaining
                    Dim appCredit As QBCreditObj = New QBCreditObj(creditObj.TxnID)

                With creditObj.TxnID = 
                        Dim payObj As New QBRecievePaymentObj
                        With payObj
                            .CustomerListID = customerListID
                            .AppliedInvList()
                        End With
            Next
            End While
            




        End Function

        Public Sub RecurringService_EndDateCredit(ByRef row As ds_RecurringService.RecurringServiceRow, ByVal creditAmount As Double,
                                                  ByVal newEndDate As Date, ByVal billThruDate As Date)
            ' getting customer listid
            Dim customerListID As String = _cta.GetListID(row.CustomerNumber)


            ' getting service listid
            Dim serviceRow As ds_Types.ServiceTypesRow
            Dim ta As New ds_TypesTableAdapters.ServiceTypesTableAdapter
            serviceRow = ta.GetDataByID(row.ServiceTypeID).Rows(0)

            Dim creditMemoAdd As ICreditMemoAdd = MsgSetReq.AppendCreditMemoAddRq

            ' passing listid
            creditMemoAdd.CustomerRef.ListID.SetValue(customerListID)
            creditMemoAdd.IsToBePrinted.SetValue(False)

            Dim creditLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
            ' credit line info
            creditLine.CreditMemoLineAdd.ItemRef.ListID.SetValue(serviceRow.ServiceListID)
            creditLine.CreditMemoLineAdd.ORRatePriceLevel.Rate.SetValue(creditAmount)

            ' description line
            Dim descLine As IORCreditMemoLineAdd = creditMemoAdd.ORCreditMemoLineAddList.Append()
            descLine.CreditMemoLineAdd.ItemRef.ListID.Unset()
            descLine.CreditMemoLineAdd.ItemRef.FullName.Unset()
            descLine.CreditMemoLineAdd.Desc.SetValue("This service has been Invoiced upto " & billThruDate & ". The new End Date overlaps this Invoiced period. | New End Date: " & newEndDate.Date)
            descLine.CreditMemoLineAdd.Amount.Unset()
            descLine.CreditMemoLineAdd.Quantity.Unset()

            ' send request
            Dim msgSetResp As IMsgSetResponse = SessMgr.DoRequests(MsgSetReq)
            Dim respList As IResponseList = msgSetResp.ResponseList

            ' clear msgsetreq
            MsgSetReq.ClearRequests()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then

                    ' insert record
                    Dim creditMemoRet As ICreditMemoRet = resp.Detail
                    Try
                        Using qta As New ds_RecurringServiceTableAdapters.QueriesTableAdapter
                            If (row.IsRecurringServiceEndDateNull) Then
                                qta.RecurringService_EndDateCredit_Insert(row.RecurringServiceID, Nothing, newEndDate, creditAmount, creditMemoRet.TxnID.GetValue)
                            Else
                                qta.RecurringService_EndDateCredit_Insert(row.RecurringServiceID, row.RecurringServiceEndDate, newEndDate, creditAmount, creditMemoRet.TxnID.GetValue)
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error inserting Credit History: " & ex.Message, "Error Credit Record Insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    ' update row
                    row.RecurringServiceEndDate = newEndDate.Date
                    row.Credited = True
                    ' commit
                    Try
                        _rsta.Update(row)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    ' get table of unpaid invoices
                    Dim openInvDt As ds_Display.QBUnpaidInvoicesDataTable = Invoicing_GetUnpaidTable(customerListID)

                    ' use new credit to pay newest invoices first
                    Credits_PayOpenInvoices(customerListID, creditMemoRet.TxnID.GetValue, creditMemoRet.CreditRemaining.GetValue, openInvDt, "Desc")
                Else
                    Utilities.ErrHandling.ResponseErr_Misc(resp)
                End If
            Next i
        End Sub
    End Module
End Namespace