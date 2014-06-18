Imports TrashCash.Payments
Imports TrashCash.QBStuff

Namespace Admin.Payments
    Public Class AdminBanks

        ' property for row we are working with
        Private _bankRow As ds_Payments.Bad_Check_BanksRow
        Private Property BankRow As ds_Payments.Bad_Check_BanksRow
            Get
                Return _bankRow
            End Get
            Set(value As ds_Payments.Bad_Check_BanksRow)
                _bankRow = value
                If (value IsNot Nothing) Then
                    ' make bottom panel visible
                    pnl_Bottom.Visible = True
                    ' hide modify button and show save changes button
                    btn_ModBank.Visible = False
                    btn_SaveChanges.Visible = True
                    ' disable bank changing and adding
                    cmb_BankList.Enabled = False
                    btn_AddBank.Enabled = False
                    '' check if this is a new row
                    'If (value.RowState = DataRowState.Detached) Then

                Else
                    ' hide bottom panel
                    pnl_Bottom.Visible = False
                  ' show modify button and hide save changes button
                    btn_ModBank.Visible = True
                    btn_SaveChanges.Visible = False
                    ' enable bank changing and adding
                    cmb_BankList.Enabled = True
                    btn_AddBank.Enabled = True
                    ' refresh list
                    Bad_Check_BanksTableAdapter.Fill(Payments.Bad_Check_Banks)
                End If
            End Set
        End Property
        
        Private Sub AdminBanks_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub

        Private Sub BankMaint_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
            ' bind combo boxes to qb items
            BindCmbs()
            ' bind banks list on toolstrip
            Bad_Check_BanksTableAdapter.Fill(Payments.Bad_Check_Banks)
           cmb_BankList.ComboBox.DisplayMember = "Bank_Name"
            cmb_BankList.ComboBox.ValueMember = "Bank_ID"
            cmb_BankList.ComboBox.DataSource = (Payments.Bad_Check_Banks)
            ' hide bottom panel
            pnl_Bottom.Visible = False
        End Sub

        Private Sub BindCmbs()
            Dim banks As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.AccountQuery(QBFC12Lib.ENAccountType.atBank))
            cmb_BankAccs.DisplayMember = "DisplayMember"
            cmb_BankAccs.ValueMember = "ValueMember"
            cmb_BankAccs.DataSource = banks

            Dim other As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.OtherChargeItemQuery)
            cmb_BanksInvItem.DisplayMember = "DisplayMember"
            cmb_BanksInvItem.ValueMember = "ValueMember"
            cmb_BanksInvItem.DataSource = other

            Dim vendors As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.VendorQuery)
            cmb_VendorAcc.DisplayMember = "DisplayMember"
            cmb_VendorAcc.ValueMember = "ValueMember"
            cmb_VendorAcc.DataSource = vendors
        End Sub

        Private Sub btn_ModBank_Click(sender As System.Object, e As EventArgs) Handles btn_ModBank.Click
            If (cmb_BankList.ComboBox.SelectedValue IsNot Nothing) Then
                BankRow = CType(cmb_BankList.ComboBox.SelectedItem, DataRowView).Row
                ' set row
                cmb_BankAccs.SelectedValue = BankRow.QB_Bank_ListID
                cmb_BanksInvItem.SelectedValue = BankRow.QB_Bank_Inv_Item_ListID
                cmb_VendorAcc.SelectedValue = BankRow.QB_Vendor_ListID
                tb_BankFee.Text = BankRow.Bank_Fee
                tb_BankName.Text = BankRow.Bank_Name
                ' update nulls
                If (BankRow.IsDeactiveNull) Then
                    BankRow.Deactive = 0
                End If
                ck_Deactive.Checked = BankRow.Deactive
            End If
        End Sub
      
    
        Private Sub btn_SaveChanges_Click(sender As System.Object, e As System.EventArgs) Handles btn_SaveChanges.Click
            If (ValidForEntry()) Then
                If (BankRow IsNot Nothing) Then
                  ' update row
                    With BankRow
                        .Bank_Name = tb_BankName.Text
                        .QB_Bank_ListID = cmb_BankAccs.SelectedValue
                        .QB_Bank_Inv_Item_ListID = cmb_BanksInvItem.SelectedValue
                        .QB_Vendor_ListID = cmb_VendorAcc.SelectedValue
                        .Bank_Fee = tb_BankFee.Text
                        .Deactive = ck_Deactive.Checked
                    End With
                    ' adding bank if its new
                    If (BankRow.RowState = DataRowState.Detached) Then
                        Payments.Bad_Check_Banks.AddBad_Check_BanksRow(BankRow)
                    End If
                    Try
                        ' save to db
                        Bad_Check_BanksTableAdapter.Update(Payments.Bad_Check_Banks)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    ' reset form through property
                    BankRow = Nothing
                End If
            End If
        End Sub

        Private Sub btn_AddBank_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddBank.Click
            BankRow = Payments.Bad_Check_Banks.NewBad_Check_BanksRow
        End Sub

        Private Function ValidForEntry() As Boolean
            Dim err As Integer = 0
            Dim s As New System.Text.StringBuilder

            ' checking name
            If (Trim(tb_BankName.Text) = "") Then
                err += 1
                s.Append(" -BankName is blank").AppendLine()
                tb_BankName.BackColor = AppColors.TextBoxErr
            Else
                tb_BankName.BackColor = AppColors.TextBoxDef
            End If

            'combo boxes
            If (cmb_BankAccs.SelectedValue Is Nothing) Then
                err += 1
            End If
            If (cmb_BanksInvItem.SelectedValue Is Nothing) Then
                err += 1
            End If
            If (cmb_VendorAcc.SelectedValue Is Nothing) Then
                err += 1
            End If

            ' default fee
            If (Trim(tb_BankFee.Text) = "") Then
                err += 1
                s.Append(" -BankFee is invalid")
                tb_BankFee.BackColor = AppColors.TextBoxErr
            Else
                tb_BankFee.BackColor = AppColors.TextBoxDef
            End If

            If (err = 0) Then
                Return True
            Else
                MessageBox.Show("Errors: " & vbCrLf & s.ToString, "Errors with Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Function
    End Class
End Namespace