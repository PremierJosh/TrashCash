Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_AllCustBalances

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor
            If (nud_MindDays.Value > 0) Then
                ' build ds
                ReportFoo()
            End If

            ' checking if we have rows here
            If (Ds_Reporting.CustomerBalances.Rows.Count > 0) Then
                tc_Report.Visible = True

                ' create report
                Dim report As New r_AllCustBalances
                ' set ds
                report.SetDataSource(Ds_Reporting)
                ' pass to viewer
                CrystalReportViewer.ReportSource = report
                CrystalReportViewer.Refresh()
            Else
                MessageBox.Show("No Customers meet search criteria.", "Report Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tc_Report.Visible = False
            End If

            Cursor = Cursors.Default

        End Sub

        Private Sub ReportFoo()
            ' clear ds
            Ds_Reporting.Clear()

            Dim custQuery As ICustomerQuery = GlobalConMgr.MessageSetRequest.AppendCustomerQueryRq
            ' active or all
            If (ck_ActiveOnly.Checked) Then
                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)
            Else
                custQuery.ORCustomerListQuery.CustomerListFilter.ActiveStatus.SetValue(ENActiveStatus.asAll)
            End If
            ' default balance filter
            custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Amount.SetValue(0)
            custQuery.ORCustomerListQuery.CustomerListFilter.TotalBalanceFilter.Operator.SetValue(ENOperator.oGreaterThan)

            Dim resp As IResponse = GlobalConMgr.GetRespList.GetAt(0)
           If (resp.StatusCode = 0) Then
                Dim custRetList As ICustomerRetList = resp.Detail
                For c = 0 To custRetList.Count - 1
                    Dim cust As ICustomerRet = custRetList.GetAt(c)
                    ' grabbing customer number
                    Dim cta As New ds_CustomerTableAdapters.CustomerTableAdapter
                    Dim customerNumber As Integer = cta.GetNumber(cust.ListID.GetValue)

                    If (customerNumber <> 0) Then
                        ' create new row for cust balances
                        Dim custRow As ds_Reporting.CustomerBalancesRow = Ds_Reporting.CustomerBalances.NewCustomerBalancesRow
                        custRow.CustomerName = cust.FullName.GetValue
                        custRow.CustomerNumber = customerNumber
                        custRow.CustomerBalance = cust.TotalBalance.GetValue
                        custRow.ListID = cust.ListID.GetValue
                        custRow.CustomerPhone = cust.Phone.GetValue

                        ' addr info
                        If (cust.BillAddress.Addr1 IsNot Nothing) Then
                            custRow.Addr1 = cust.BillAddress.Addr1.GetValue
                        End If
                        If (cust.BillAddress.Addr2 IsNot Nothing) Then
                            custRow.Addr2 = cust.BillAddress.Addr2.GetValue
                        End If
                        ' checking if addr 3 and 4 have values
                        If (cust.BillAddress.Addr3 IsNot Nothing) Then
                            custRow.Addr3 = cust.BillAddress.Addr3.GetValue
                        End If
                        If (cust.BillAddress.Addr4 IsNot Nothing) Then
                            custRow.Addr4 = cust.BillAddress.Addr4.GetValue
                        End If
                        custRow.City = cust.BillAddress.City.GetValue
                        custRow.State = cust.BillAddress.State.GetValue
                        custRow.Zip = cust.BillAddress.PostalCode.GetValue

                        Ds_Reporting.CustomerBalances.AddCustomerBalancesRow(custRow)
                        ' get invoices for customer if balance greater than 0
                        If (custRow.CustomerBalance > 0) Then
                            InvoiceReport(custRow.ListID, custRow.CustomerNumber, nud_MindDays.Value)
                        End If
                    End If
                Next
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If
        End Sub

        Private Sub InvoiceReport(ByRef customerListID As String, ByVal customerNumber As integer,ByVal minDaysPastDue As Integer)

            Dim invObjList As New List(Of QBInvoiceObj)
            Dim resp As Integer = QBRequests.InvoiceQuery(invObjList:=invObjList, customerListID:=customerListID, paidStatus:=ENPaidStatus.psNotPaidOnly)

            If (resp = 0) Then
                For Each inv As QBInvoiceObj In invObjList
                    Dim daysPastDue As Integer = DateDiff(DateInterval.Day, inv.DueDate, Date.Now.Date)
                    If (daysPastDue >= minDaysPastDue) Then
                        Dim row As ds_Reporting.InvoiceBalancesRow = Ds_Reporting.InvoiceBalances.NewInvoiceBalancesRow
                        ' passing cust num here for relationship
                        row.CustomerListID = customerListID
                        row.CustomerNumber = customerNumber
                        row.Balance = FormatCurrency(inv.BalanceRemaining)
                        row.InvoiceTotal = FormatCurrency(inv.Subtotal)
                        row.InvoiceNumber = inv.RefNumber
                        row.DueDate = inv.DueDate
                        row.DaysPastDue = daysPastDue
                        ' add row to table
                        Ds_Reporting.InvoiceBalances.AddInvoiceBalancesRow(row)
                    End If
                Next
            End If

        End Sub



    End Class
End Namespace