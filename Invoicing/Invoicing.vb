Imports TrashCash.Modules
Imports TrashCash.Classes
Imports QBFC12Lib

Namespace Invoicing
    Friend Module Invoicing

        Public Function CustomInvoice_Create(ByRef ds As ds_Invoicing, ByVal print As Boolean) As Boolean
            ' return succeed or fail
            Dim pass As Boolean = False

            ' ta needed
            Dim ta As New ds_InvoicingTableAdapters.CustomInvoicesTableAdapter

            ' table refs
            Dim invRow As ds_Invoicing.CustomInvoicesRow = ds.CustomInvoices.Rows(0)
            Dim lineDT As ds_Invoicing.CustomInvoice_LineItemsDataTable = ds.CustomInvoice_LineItems
            Dim typeDT As ds_Invoicing.CustomInvoice_LineTypesDataTable = ds.CustomInvoice_LineTypes

            ' creating invObj
            Dim invObj As New QBInvoiceObj
            With invObj
                .CustomerListID = invRow.InvoiceListID
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
                End With
                ' building desc line
                Dim descLine As New QBLineItemObj(row.DescText)

                ' add line items
                invObj.LineList.Add(itemLine)
                invObj.LineList.Add(descLine)
            Next
            ' submit and update row for submited
            invRow.Time_Submitted = Date.Now
            invRow.StatusID = ENItemStatus.Submitted
            Try
                ta.Update(invRow)
            Catch ex As SqlException
                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim resp As IResponse = QBMethods.InvoiceAdd(invObj)
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
                QBMethods.ResponseErr_Misc(resp)
                invRow.StatusID = ENItemStatus.Err

                Try
                    ta.Update(invRow)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            Return pass
        End Function

        Public Function CustomInvoice_Void(ByVal id As Integer, ByVal reason As String) As Boolean
            ' return for succeed or fail
            Dim pass As Boolean = False

            ' ta needed
            Dim ta As New ds_InvoicingTableAdapters.CustomInvoicesTableAdapter
            Dim row As ds_Invoicing.CustomInvoicesRow = ta.GetDataByID(id).Rows(0)

            Const voidType As ENTxnVoidType = ENTxnVoidType.tvtInvoice

            Dim resp As IResponse = QBMethods.TxnVoid(row.InvoiceListID, voidType)
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
                QBMethods.ResponseErr_Misc(resp)
            End If
            Return pass
        End Function
    End Module

End Namespace