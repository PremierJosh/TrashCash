﻿Imports System.Text
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
                ' recent addr fill and select nothing
                _raTA.Fill(Ds_Invoicing.Customer_RecentAddrs, CurrentCustomer)
                ' fill history tables
                _ciTA.Fill(Ds_HistoryInv.CustomInvoices, CurrentCustomer)
            End Set
        End Property

        ' invoice row for easier refrence
        Private _invRow As ds_Invoicing.CustomInvoicesRow

        Private Sub CustomInvoicingForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ' line type fill
            _ltTA.Fill(Ds_Invoicing.CustomInvoice_LineTypes)
            If (CurrentCustomer = Nothing) Then
                CurrentCustomer = CustomerToolstrip1.CurrentCustomer
            End If
        End Sub

        Private Sub CustomerChanged(ByVal customerNumber As Integer) Handles CustomerToolstrip1.CustomerChanging
            CurrentCustomer = customerNumber
            ResetInvoice()
        End Sub

        Private Sub dtp_PostDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtp_PostDate.ValueChanged
            dtp_DueDate.Value = dtp_PostDate.Value
        End Sub

        Private Sub btn_AddLine_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddLine.Click
            ' on first line creation, create invoice row for it and lock customer selection
            If (LineValidation()) Then
                ' disable customer changing
                CustomerToolstrip1.Enabled = False
                ' build inv row
                _invRow = Ds_Invoicing.CustomInvoices.NewCustomInvoicesRow
                With _invRow
                    .CustomerNumber = CurrentCustomer
                    .StatusID = ENItemStatus.Ready
                    .InsertedUser = CurrentUser.USER_NAME
                    .Time_Inserted = Date.Now
                    .DueDate = dtp_DueDate.Value
                    .PostDate = dtp_PostDate.Value
                    .Voided = False
                End With
                Ds_Invoicing.CustomInvoices.AddCustomInvoicesRow(_invRow)

                ' build line row
                Dim line As ds_Invoicing.CustomInvoice_LineItemsRow = Ds_Invoicing.CustomInvoice_LineItems.NewCustomInvoice_LineItemsRow
                ' getting reference to type row
                Dim type As ds_Invoicing.CustomInvoice_LineTypesRow = CType(DirectCast(cmb_LineTypes.SelectedItem, DataRowView).Row, ds_Invoicing.CustomInvoice_LineTypesRow)
                With line
                    .CI_ID = _invRow.CI_ID
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
                    .STATE = tb_State.Text
                    .Zip = tb_Zip.Text
                    .CompiledDescText = CompileLineDesc()
                    ' reminder check
                    If (ck_Reminder.Checked) Then
                        .Reminder = True
                    End If
                End With
                Ds_Invoicing.CustomInvoice_LineItems.AddCustomInvoice_LineItemsRow(line)

                ' setting pnl3 visible
                pnl_3.Visible = True
                ResetLinePnl()
            End If
        End Sub
        Private Function CompileLineDesc() As String
            ' return concat string
            Dim s As New StringBuilder
            s.Append("Charge for: " & tb_DescText.Text)
            s.Append(". At location: " & tb_Addr1.Text & ", " & tb_City.Text & ", " & tb_State.Text & ", " & tb_Zip.Text)
            s.Append(". On date of: " & FormatDateTime(dtp_DateOfSrvc.Value, DateFormat.LongDate))
            Return s.ToString
        End Function

        Private Sub ResetLinePnl()
            cmb_LineTypes.SelectedIndex = 0
            tb_Rate.Text = ""
            tb_DescText.Text = ""
            dtp_DateOfSrvc.Value = Date.Now
            ck_Reminder.Checked = False

            ' address
            For Each control As Control In grp_Address.Controls
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
                s.Append(" - Rate must be greater than 0").AppendLine()
            End If

            If (Trim(tb_DescText.Text).Length = 0) Then
                err += 1
                s.Append(" - Description of service missing").AppendLine()
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
                            s.Append(" - Address section error").AppendLine()
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

        Private Function InvoiceValidation() As Boolean
            If (dtp_PostDate.Value.Date <= dtp_DueDate.Value.Date) Then
                Return True
            Else
                MessageBox.Show("Due Date cannot be before Post Date", "Error with Post/Due Dates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Function
        Private Sub btn_CancelInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_CancelInv.Click
            Dim prompt As DialogResult = MessageBox.Show("Cancel creation of Custom Invoice?", "Confirm cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If (prompt = Windows.Forms.DialogResult.Yes) Then
                ResetInvoice()
            End If
        End Sub

        Private Sub ResetInvoice()
            ' clear dataset
            Ds_Invoicing.CustomInvoice_LineItems.Clear()
            Ds_Invoicing.CustomInvoices.Clear()
            ' reset post date
            dtp_PostDate.Value = Date.Now
            ck_Print.Checked = True
            ResetLinePnl()
            ' hide bottom panel
            pnl_3.Visible = False
        End Sub

        Private Sub btn_CreateInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_CreateInv.Click
            If (InvoiceValidation()) Then
                ' update time inserted
                _invRow.Time_Inserted = Date.Now
                ' submit invoice and line items
                Try
                    _ciTA.Update(Ds_Invoicing.CustomInvoices)
                    _liTA.Update(Ds_Invoicing.CustomInvoice_LineItems)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                ' send to QB
                Dim succeed As Boolean = CustomInvoice_Create(Ds_Invoicing, ck_Print.Checked)
                If (Not succeed) Then
                    MessageBox.Show("Error - Invoice not created.", "QB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ' creating reminders
                    For Each row As ds_Invoicing.CustomInvoice_LineItemsRow In Ds_Invoicing.CustomInvoice_LineItems
                        If (row.Reminder) Then
                            _liTA.Reminder_CustomInvoice_Insert(row.CI_ID, row.RenderedOnDate, row.CompiledDescText, CurrentUser.USER_NAME)
                        End If
                    Next

                    ' refill history grid
                    Ds_HistoryInv.Clear()
                    _ciTA.Fill(Ds_HistoryInv.CustomInvoices, CurrentCustomer)
                    MessageBox.Show("Invoice Added.")
                    ResetInvoice()
                End If
            End If
        End Sub

        Private Sub dg_InvHistory_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_InvHistory.CellMouseDown
            ' left click = fill line table with history
            If (e.Button = Windows.Forms.MouseButtons.Left) Then
                _liTA.Fill(Ds_HistoryInv.CustomInvoice_LineItems,
                                                         CType(CType(dg_InvHistory.SelectedRows(0).DataBoundItem, DataRowView).Row, ds_Invoicing.CustomInvoicesRow).CI_ID)
            End If
        End Sub

        Private Sub btn_DeleteLine_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteLine.Click
            Dim row As DataRow = CType(dg_LineItems.SelectedRows(0).DataBoundItem, DataRowView).Row
            row.Delete()
        End Sub

        Private Sub btn_VoidInv_Click(sender As System.Object, e As System.EventArgs) Handles btn_VoidInv.Click
            If (Trim(tb_VoidReason.Text) <> "") Then
                ' get row reference
                Dim row As ds_Invoicing.CustomInvoicesRow = CType(dg_InvHistory.SelectedRows(0).DataBoundItem, DataRowView).Row
                ' checking if row is voided
                If (Not row.Voided) Then
                    ' getting total of invoice
                    Dim total As Double = CDbl(Ds_HistoryInv.CustomInvoice_LineItems.Compute("Sum(Rate)", ""))
                    Dim prompt As DialogResult = MessageBox.Show("Void Invoice in the amount of " & FormatCurrency(total) & " created on " & row.Time_Created, "Confirm Void", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (prompt = Windows.Forms.DialogResult.Yes) Then
                        Dim succeed As Boolean = CustomInvoice_Void(row, tb_VoidReason.Text)
                        If (Not succeed) Then
                            MessageBox.Show("Error - Invoice not voided.", "QB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show("Invoice Voided.")
                            Ds_HistoryInv.Clear()
                            tb_VoidReason.Text = ""
                            _ciTA.Fill(Ds_HistoryInv.CustomInvoices, CurrentCustomer)
                        End If
                    End If
                Else
                    MessageBox.Show("This invoice was already voided on " & row.VoidTime & " by user" & row.VoidUser & ". Reason given: " & vbCrLf & row.VoidReason,
                                    "Already Voided", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            Else
                MsgBox("Must provide a reason.")
            End If
        End Sub

        Private Sub ColorHistoryForVoids()
            If (dg_InvHistory.RowCount > 0) Then
                For i = 0 To dg_InvHistory.RowCount - 1
                    Dim row As ds_Invoicing.CustomInvoicesRow = CType(dg_InvHistory.Rows(i).DataBoundItem, DataRowView).Row
                    If (row.Voided) Then
                        ' credit is voided
                        dg_InvHistory.Rows(i).DefaultCellStyle.BackColor = AppColors.GridRed
                        dg_InvHistory.Rows(i).DefaultCellStyle.SelectionBackColor = AppColors.GridRedSel
                    Else
                        dg_InvHistory.Rows(i).DefaultCellStyle.BackColor = Color.SpringGreen
                        dg_InvHistory.Rows(i).DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen
                    End If
                Next
            End If
        End Sub

        Public Sub New(Optional ByVal customerNumber As Integer = Nothing)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            If (customerNumber <> Nothing) Then
                CurrentCustomer = customerNumber
                ' lock customer bar
                CustomerToolstrip1.Enabled = False
                ' testing tooltip for info as to why they cant change
                ToolTip1.Active = True
            Else
                ToolTip1.Active = False
                CustomerToolstrip1.GetCustomerBalance()
            End If
        End Sub

        Private Sub cmb_RecentAddr_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmb_RecentAddr.SelectionChangeCommitted
            ' get row
            If (cmb_RecentAddr.SelectedValue IsNot Nothing) Then
                Dim row As ds_Invoicing.Customer_RecentAddrsRow = CType(DirectCast(cmb_RecentAddr.SelectedItem, DataRowView).Row, ds_Invoicing.Customer_RecentAddrsRow)
                tb_Addr1.Text = row.Addr1
                If (Not row.IsAddr2Null) Then
                    tb_Addr2.Text = row.Addr2
                End If
                If (Not row.IsAddr3Null) Then
                    tb_Addr3.Text = row.Addr3
                End If
                tb_City.Text = row.City
                tb_State.Text = row.State
                tb_Zip.Text = row.Zip
            End If
        End Sub

        Private Sub dg_InvHistory_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg_InvHistory.RowsAdded
            ColorHistoryForVoids()
        End Sub
    End Class
End Namespace