﻿Imports QBFC12Lib
Imports TrashCash.Classes.QBConMgr

Namespace Invoicing
    Module QBMethods

        Public Function CustomInvoice_Create(ByRef ds As ds_Invoicing, ByVal print As Boolean) As Boolean
            ' return succeed or fail
            Dim pass As Boolean = False

            ' ta needed
            Dim ta As New ds_InvoicingTableAdapters.CustomInvoicesTableAdapter

            ' table refs
            Dim invRow As ds_Invoicing.CustomInvoicesRow = ds.CustomInvoices.Rows(0)
            Dim lineDT As ds_Invoicing.CustomInvoice_LineItemsDataTable = ds.CustomInvoice_LineItems
            Dim typeDT As ds_Invoicing.CustomInvoice_LineTypesDataTable = ds.CustomInvoice_LineTypes

            ' setting inv params
            Dim invAdd As IInvoiceAdd = MessageSetRequest.AppendInvoiceAddRq()
            With invAdd
                .CustomerRef.ListID.SetValue(CustomerListID(invRow.CustomerNumber))
                .DueDate.SetValue(invRow.DueDate)
                .TxnDate.SetValue(invRow.PostDate)
                .IsToBePrinted.SetValue(print)
            End With

            ' line list var
            Dim lineList As IORInvoiceLineAddList = invAdd.ORInvoiceLineAddList

            ' getting line items
            For Each row As ds_Invoicing.CustomInvoice_LineItemsRow In lineDT
                ' getting line type row
                Dim typeRow() As ds_Invoicing.CustomInvoice_LineTypesRow = typeDT.Select("CI_TypeID = " & row.CI_TypeID)

                ' set line item
                Dim line As IORInvoiceLineAdd = lineList.Append
                With line
                    .InvoiceLineAdd.ItemRef.ListID.SetValue(typeRow(0).CI_TypeID)
                    .InvoiceLineAdd.ORRatePriceLevel.Rate.SetValue(row.Rate)
                    .InvoiceLineAdd.Quantity.SetValue(1)
                End With
            Next

            ' submit and update row for submited
            invRow.Time_Submitted = Date.Now
            invRow.StatusID = ENItemStatus.Submitted
            
            Try
                ta.Update(invRow)
            Catch ex as SqlException
                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim respList As IResponseList = GetRespList()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)

                If (resp.StatusCode = 0) Then
                    Dim invRet As IInvoiceRet = resp.Detail

                    ' update row
                    With invRow
                        .StatusID = ENItemStatus.Complete
                        .InvoiceListID = invRet.TxnID.GetValue
                        .InvoiceRefNum = invRet.RefNumber.GetValue
                        .Time_Created = invRet.TimeCreated.GetValue
                    End With

                    Try
                        ta.Update(invRow)
                        pass = True
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else
                    ' log and update row
                    ResponseErr_Misc(resp)
                    invRow.StatusID = ENItemStatus.Err

                    Try
                        ta.Update(invRow)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next

            Return pass
        End Function

        Public Function CustomInvoice_Void(ByVal id As Integer, ByVal reason As String) As Boolean
            ' return for succeed or fail
            Dim pass As Boolean = False

            ' ta needed
            Dim ta As New ds_InvoicingTableAdapters.CustomInvoicesTableAdapter
            Dim row As ds_Invoicing.CustomInvoicesRow = ta.GetDataByID(id).Rows(0)

            Dim void As ITxnVoid = MessageSetRequest.AppendTxnVoidRq
            void.TxnVoidType.SetValue(ENTxnVoidType.tvtInvoice)
            void.TxnID.SetValue(row.InvoiceListID)

            Dim respList As IResponseList = GetRespList()

            For i = 0 To respList.Count - 1
                Dim resp As IResponse = respList.GetAt(i)
                If (resp.StatusCode = 0) Then

                    ' update db
                    With row
                        .Voided = True
                        .VoidReason = reason
                        .VoidTime = Date.Now
                        .VoidUser = CurrentUser.USER_NAME
                    End With

                    Try
                        ta.Update(row)
                        pass = True
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber, "Sql Error: " & ex.Procedure,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    ResponseErr_Misc(resp)
                End If
            Next

            Return pass
        End Function
    End Module

End Namespace