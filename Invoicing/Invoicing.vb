Imports TrashCash.QBStuff

Namespace Invoicing
    Friend Module Invoicing

        Friend ReadOnly CiTA As New ds_InvoicingTableAdapters.CustomInvoicesTableAdapter
        Friend ReadOnly LiTA As New ds_InvoicingTableAdapters.CustomInvoice_LineItemsTableAdapter
        Friend ReadOnly LtTA As New ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter
        Friend ReadOnly RaTA As New ds_InvoicingTableAdapters.Customer_RecentAddrsTableAdapter

        Public Function CustomInvoice_Create(ByRef invObj As QBInvoiceObj, ByRef ds As ds_Invoicing, ByVal print As Boolean) As Boolean
            ' return succeed or fail
            Dim pass As Boolean = False

            ' table refs
            Dim invTbl As ds_Invoicing.CustomInvoicesDataTable = ds.CustomInvoices
            For Each invRow As ds_Invoicing.CustomInvoicesRow In invTbl
                ' making surw row status is ready
                If (invRow.StatusID = TC_ENItemStatus.Ready) Then
                    Dim lineDT As ds_Invoicing.CustomInvoice_LineItemsDataTable = ds.CustomInvoice_LineItems
                    Dim typeDT As ds_Invoicing.CustomInvoice_LineTypesDataTable = ds.CustomInvoice_LineTypes

                    ' creating invObj
                    With invObj
                        .CustomerListID = GetCustomerListID(invRow.CustomerNumber)
                        .DueDate = invRow.DueDate
                        .TxnDate = invRow.PostDate
                        .IsToBePrinted = print
                    End With

                    ' getting line items
                    For Each row As ds_Invoicing.CustomInvoice_LineItemsRow In lineDT
                        ' checking if id matches
                        If (row.CI_ID = invRow.CI_ID) Then
                            ' getting line type row
                            Dim typeRow() As ds_Invoicing.CustomInvoice_LineTypesRow = typeDT.Select("CI_TypeID = " & row.CI_TypeID)

                            ' building itemLine
                            Dim itemLine As New QBLineItemObj
                            With itemLine
                                .ItemListID = typeRow(0).QBListID
                                .Rate = row.Rate
                                .Desc = row.DefaultDesc
                                ' quantity always 1
                                .Quantity = 1
                            End With
                            ' building desc line
                            Dim descLine As New QBLineItemObj
                            descLine.Desc = row.CompiledDescText

                            ' add line items
                            invObj.LineList = New List(Of QBLineItemObj)
                            invObj.LineList.Add(itemLine)
                            invObj.LineList.Add(descLine)
                        End If
                    Next
                    ' submit and update row for submited
                    invRow.Time_Submitted = Date.Now
                    invRow.StatusID = TC_ENItemStatus.Submitted
                    Try
                        CiTA.Update(invRow)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Dim resp As Integer = QBRequests.InvoiceAdd(invObj)
                    If (resp = 0) Then
                        ' update row
                        With invRow
                            .StatusID = TC_ENItemStatus.Complete
                            .InvoiceListID = invObj.TxnID
                            .InvoiceRefNum = invObj.RefNumber
                            .Time_Created = Date.Now
                        End With
                        Try
                            CiTA.Update(invRow)
                            pass = True
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Else
                        ' log and update row
                        invRow.StatusID = TC_ENItemStatus.Err
                        Try
                            CiTA.Update(invRow)
                        Catch ex As SqlException
                            MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                            "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        Return False
                    End If
                End If
            Next


            Return pass
        End Function

        Public Function CustomInvoice_Void(ByRef row As ds_Invoicing.CustomInvoicesRow, ByVal reason As String) As Boolean
            ' return for succeed or fail
            Dim pass As Boolean = False

            Const voidType As String = "Invoice"

            Dim resp As Integer = QBRequests.TxnVoid(row.InvoiceListID, voidType)
            If (resp = 0) Then

                ' update db
                With row
                    .Voided = True
                    .VoidReason = reason
                    .VoidTime = Date.Now
                    .VoidUser = CurrentUser.USER_NAME
                End With

                Try
                    CiTA.Update(row)
                    pass = True
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber, "Sql Error: " & ex.Procedure,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
       End If
            Return pass
        End Function
    End Module

End Namespace