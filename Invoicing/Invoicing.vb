
Imports TrashCash.QBStuff
Imports TrashCash.Classes
Imports QBFC12Lib

Namespace Invoicing
    Friend Module Invoicing

        Friend ReadOnly _ciTA As New ds_InvoicingTableAdapters.CustomInvoicesTableAdapter
        Friend ReadOnly _liTA As New ds_InvoicingTableAdapters.CustomInvoice_LineItemsTableAdapter
        Friend ReadOnly _ltTA As New ds_InvoicingTableAdapters.CustomInvoice_LineTypesTableAdapter
        Friend ReadOnly _raTA As New ds_InvoicingTableAdapters.Customer_RecentAddrsTableAdapter

        Public Function CustomInvoice_Create(ByRef ds As ds_Invoicing, ByVal print As Boolean) As Boolean
            ' return succeed or fail
            Dim pass As Boolean = False

            ' table refs
            Dim invRow As ds_Invoicing.CustomInvoicesRow = ds.CustomInvoices.Rows(0)
            Dim lineDT As ds_Invoicing.CustomInvoice_LineItemsDataTable = ds.CustomInvoice_LineItems
            Dim typeDT As ds_Invoicing.CustomInvoice_LineTypesDataTable = ds.CustomInvoice_LineTypes

            ' creating invObj
            Dim invObj As New QBInvoiceObj
            With invObj
                .CustomerListID = GlobalConMgr.GetCustomerListID(invRow.CustomerNumber)
                .DueDate = invRow.DueDate
                .TxnDate = invRow.PostDate
                .IsToBePrinted = print
            End With

            ' getting line items
            For Each row As ds_Invoicing.CustomInvoice_LineItemsRow In lineDT
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
            Next
            ' submit and update row for submited
            invRow.Time_Submitted = Date.Now
            invRow.StatusID = ENItemStatus.Submitted
            Try
                _ciTA.Update(invRow)
            Catch ex As SqlException
                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim resp As IResponse = QBRequests.InvoiceAdd(invObj)
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
                    _ciTA.Update(invRow)
                    pass = True
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                ' log and update row
                QBMethods.ResponseErr_Misc(resp)
                invRow.StatusID = ENItemStatus.Err

                Try
                    _ciTA.Update(invRow)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            Return pass
        End Function

        Public Function CustomInvoice_Void(ByRef row As ds_Invoicing.CustomInvoicesRow, ByVal reason As String) As Boolean
            ' return for succeed or fail
            Dim pass As Boolean = False

            Const voidType As ENTxnVoidType = ENTxnVoidType.tvtInvoice

            Dim resp As IResponse = QBRequests.TxnVoid(row.InvoiceListID, voidType)
            If (resp.StatusCode = 0) Then

                ' update db
                With row
                    .Voided = True
                    .VoidReason = reason
                    .VoidTime = Date.Now
                    .VoidUser = CurrentUser.USER_NAME
                End With

                Try
                    _ciTA.Update(row)
                    pass = True
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber, "Sql Error: " & ex.Procedure,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If
            Return pass
        End Function
    End Module

End Namespace