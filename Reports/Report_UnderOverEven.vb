Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Reports
    ' ReSharper disable once InconsistentNaming
    Public Class Report_UnderOverEven

        Private Sub btn_BuildRpt_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuildRpt.Click
            Cursor = Cursors.WaitCursor

            Report_UnderOverEven()
            If (Ds_Reporting.UnderOverEven.Rows.Count > 0) Then
                CrystalReportViewer.Visible = True

                ' create report
                Dim report As New r_UnderOverEven
                ' set ds
                report.SetDataSource(Ds_Reporting)
                ' pass to viewer
                CrystalReportViewer.ReportSource = report
                CrystalReportViewer.Refresh()
            Else
                CrystalReportViewer.Visible = False
            End If
            
            ' reset cursor
            Cursor = Cursors.Default
        End Sub

        Private Sub Report_UnderOverEven()
            ' clear ds
            Ds_Reporting.Clear()

            ' get customer list depending on active state chosen
            Dim resp As IResponse
            If (ck_IncludeInactive.Checked) Then
                resp = QBRequests.CustomerQuery(activeOnly:=False)
            Else
                resp = QBRequests.CustomerQuery(activeOnly:=True)
            End If
            If (resp.StatusCode = 0) Then
                Dim retList As ICustomerRetList = resp.Detail
                For i = 0 To retList.Count - 1
                    Dim custRet As ICustomerRet = retList.GetAt(i)

                    ' making sure we control this customer
                    Dim skipCustomer As Boolean = True
                    Using ta As New ds_CustomerTableAdapters.CustomerTableAdapter
                        Dim number As Integer = ta.GetNumber(custRet.ListID.GetValue)
                        If (number <> 0) Then
                            skipCustomer = False
                        End If
                    End Using

                    If (Not skipCustomer) Then
                        ' create new row for cust balances
                        Dim custRow As ds_Reporting.UnderOverEvenRow = Ds_Reporting.UnderOverEven.NewUnderOverEvenRow
                        custRow.CustomerFullName = custRet.FullName.GetValue

                        ' balance stuff
                        custRow.Balance = custRet.TotalBalance.GetValue
                        ' setting balance group
                        If (custRet.TotalBalance.GetValue > 0) Then
                            custRow.BalanceGroup = "Customers with Balances"
                        ElseIf (custRet.TotalBalance.GetValue < 0) Then
                            custRow.BalanceGroup = "Customers with Credits"
                        ElseIf (custRet.TotalBalance.GetValue = 0) Then
                            custRow.BalanceGroup = "Customers Paid Up"
                        End If

                        custRow.Phone = custRet.Phone.GetValue
                        ' addr info
                        ' if addr1 is nothing, then we need to skip this customer
                        If (custRet.BillAddress.Addr1 IsNot Nothing) Then
                            custRow.Addr1 = custRet.BillAddress.Addr1.GetValue
                        End If
                        If (custRet.BillAddress.Addr2 IsNot Nothing) Then
                            custRow.Addr2 = custRet.BillAddress.Addr2.GetValue
                        End If
                        ' checking if addr 3 and 4 have values
                        If (custRet.BillAddress.Addr3 IsNot Nothing) Then
                            custRow.Addr3 = custRet.BillAddress.Addr3.GetValue
                        End If
                        If (custRet.BillAddress.Addr4 IsNot Nothing) Then
                            custRow.Addr4 = custRet.BillAddress.Addr4.GetValue
                        End If
                        custRow.City = custRet.BillAddress.City.GetValue
                        custRow.State = custRet.BillAddress.State.GetValue
                        custRow.Zip = custRet.BillAddress.PostalCode.GetValue

                        ' add row to ds
                        Ds_Reporting.UnderOverEven.AddUnderOverEvenRow(custRow)
                    End If
                Next
            Else
                QBMethods.ResponseErr_Misc(resp)
            End If


        End Sub

    End Class
End Namespace