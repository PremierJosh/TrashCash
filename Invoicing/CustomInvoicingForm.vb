Imports System.Text
Imports TrashCash.Modules

Namespace Invoicing
    Public Class CustomInvoicingForm

        ' current customer property
        Private _currentCustomer As Integer
        Public Property CurrentCustomer As Integer
            Get
                Return _currentCustomer
            End Get
            Set(value As Integer)
                _currentCustomer = value
            End Set
        End Property

        ' invoice row for easier refrence
        Private invRow As ds_Invoicing.CustomInvoicesRow

        Private Sub CustomInvoicingForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ' line type fill
            CustomInvoice_LineTypesTableAdapter.Fill(Ds_Invoicing.CustomInvoice_LineTypes)
            ' recent addr fill
            Customer_RecentAddrsTableAdapter.Fill(Ds_Invoicing.Customer_RecentAddrs, 
        End Sub

        Private Sub dtp_PostDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtp_PostDate.ValueChanged
            dtp_DueDate.Value = dtp_PostDate.Value
        End Sub

        Private Sub btn_AddLine_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddLine.Click
            ' on first line creation, create invoice row for it and lock customer selection
            If (LineValidation()) Then
                ' disable customer changing
                Ts_M_Customer.Enabled = False
                ' build inv row
                invRow = Ds_Invoicing.CustomInvoices.NewCustomInvoicesRow
                With invRow
                    .CustomerNumber = CurrentCustomer
                    .StatusID = ENItemStatus.Ready
                    .InsertedUser = CurrentUser.USER_NAME
                    .Time_Inserted = Date.Now
                    .DueDate = dtp_DueDate.Value
                    .PostDate = dtp_PostDate.Value
                    .Voided = False
                End With
                Ds_Invoicing.CustomInvoices.AddCustomInvoicesRow(invRow)

                ' build line row
                Dim line As ds_Invoicing.CustomInvoice_LineItemsRow = Ds_Invoicing.CustomInvoice_LineItems.NewCustomInvoice_LineItemsRow
                ' getting reference to type row
                Dim type As ds_Invoicing.CustomInvoice_LineTypesRow = CType(DirectCast(cmb_LineTypes.SelectedItem, DataRowView).Row, ds_Invoicing.CustomInvoice_LineTypesRow)
                With line
                    .CI_ID = invRow.CI_ID
                    .CI_TypeID = cmb_LineTypes.SelectedValue
                    .Rate = tb_Rate.Text
                    .DefaultDesc = type.Description
                    .RenderedOnDate = dtp_DateOfSrvc.Value.Date
                    .DescText = tb_DescText.Text
                    .Addr1 = tb_Addr1.Text
                    If (Trim(tb_Addr2.Text) <> "") Then
                        .Addr2 = tb_Addr2.Text
                    End If
                    If (Trim(tb_Addr3.Text) <> "") Then
                        .Addr3 = tb_Addr3.Text
                    End If
                    .City = tb_City.Text
                    .State = tb_State.Text
                    .Zip = tb_Zip.Text
                    .CompiledDescText = CompileLineDesc()
                End With
                Ds_Invoicing.CustomInvoice_LineItems.AddCustomInvoice_LineItemsRow(line)

                ' setting pnl3 visible
                pnl_3.Visible = True
                ResetLinePnl()
            End If
        End Sub
        Private Function CompileLineDesc() As String
            ' return concat string
            Dim s As String
            s = "Charge for: " & tb_DescText.Text
            s += ". At location: " & tb_Addr1.Text & ", " & tb_City.Text & ", " & tb_State.Text & ", " & tb_Zip.Text
            s += ". On date of: " & FormatDateTime(dtp_DateOfSrvc.Value, DateFormat.LongDate)
            Return s
        End Function

        Private Sub ResetLinePnl()
            cmb_LineTypes.SelectedIndex = 0
            tb_Rate.Text = ""
            tb_DescText.Text = ""
            dtp_DateOfSrvc.Value = Date.Now
            ck_Reminder.Checked = False

            ' address
            For Each control As Control In grp_Address
                If (TypeOf control Is TextBox) Then
                    control.Text = ""
                End If
            Next
            cmb_RecentAddr.SelectedIndex = 0
        End Sub

        Private Function LineValidation() As Boolean
            'err counter
            Dim err As Integer = 0
            Dim s As New StringBuilder

            If (Trim(tb_Rate.Text).Length = 0) Then
                err += 1
                s.Append(" - Rate must be greater than 0")
            End If

            If (Trim(tb_DescText.Text).Length = 0) Then
                err += 1
                s.Append(" - Description of service missing")
            End If

            ' address validation
            For Each control As Control In grp_Address.Controls
                Dim skip As Boolean = False
                If (TypeOf control Is TextBox) Then
                    If (control.Name = tb_Addr2.Name) Then
                        skip = True
                    ElseIf (control.Name = tb_Addr3.Name) Then
                        skip = True
                    End If

                    If (Not skip) Then
                        If (Trim(control.Text) = "") Then
                            err += 1
                            s.Append(" - Address section error")
                            ' adjust back color
                            control.BackColor = Color.MistyRose
                        Else
                            ' reset color
                            control.BackColor = SystemColors.Window
                        End If
                    End If
                End If
            Next

            If (err > 0) Then
                MessageBox.Show("Error:" & vbCrLf & s.ToString)
                Return False
            Else
                Return True
            End If
        End Function

        Private Sub btn_CancelInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_CancelInv.Click
            Dim prompt As DialogResult = MessageBox.Show("Cancel creation of Custom Invoice?", "Confirm cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If (prompt = Windows.Forms.DialogResult.Yes) Then
                ' clear dataset
                Ds_Invoicing.CustomInvoice_LineItems.Clear()
                Ds_Invoicing.CustomInvoices.Clear()
                ' reset post date
                dtp_PostDate.Value = Date.Now
                ck_Print.Checked = True
                ResetLinePnl()
                ' hide bottom panel
                pnl_3.Visible = False
            End If
        End Sub
    End Class
End Namespace