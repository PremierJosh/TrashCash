Imports TrashCash.QBStuff

Namespace Admin
    Public Class AdminDefaults
        ' refrences
        Private _dt As ds_Application.APP_SETTINGSDataTable
        Private _row As ds_Application.APP_SETTINGSRow


        Private Sub AdminDefaults_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Select Case e.CloseReason
                Case Is = CloseReason.ApplicationExitCall, CloseReason.MdiFormClosing
                    Dispose()
                Case Else
                    e.Cancel = True
                    Hide()
            End Select
        End Sub
        Private Sub App_Defaults_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ' both combo boxes for items are other charge items and can use the same DS
            Dim list As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.OtherChargeItemQuery)
            ' bind cmb for invoice item representing the check
            cmb_BadCheckCustInvItem.DisplayMember = "DisplayMember"
            cmb_BadCheckCustInvItem.ValueMember = "ValueMember"
            cmb_BadCheckCustInvItem.DataSource = list
            ' bind cmb for inv item representing our fee
            Dim list2 As New List(Of ComboBoxPair)
            list2.AddRange(list)
            cmb_BadCheckItem.DisplayMember = "DisplayMember"
            cmb_BadCheckItem.ValueMember = "ValueMember"
            cmb_BadCheckItem.DataSource = list2

            ' fill table
            _dt = AppTA.GetData
            _row = _dt.Rows(0)

            ' set company closed date
            dtp_CurrClosedDate.Value = CompanyClosingDate
            ' setting inv post date info
            nud_InvAdvLimit.Value = _row.InvPost_MaxAdvDays
            nud_InvArrLimit.Value = _row.InvPost_MaxArrDays
            
            SetControls()
            End Sub

        Private Sub SetControls()
            ' set bad check defaults
            If (Not _row.IsBAD_CHECK_CUSTITEM_LISTIDNull) Then
                cmb_BadCheckCustInvItem.SelectedValue = _row.BAD_CHECK_CUSTITEM_LISTID
            End If
            If (Not _row.IsBAD_CHECK_CHECKITEM_LISTIDNull) Then
                cmb_BadCheckItem.SelectedValue = _row.BAD_CHECK_CHECKITEM_LISTID
            End If
            If (Not _row.IsBAD_CHECK_CUST_FEENull) Then
                tb_BadCheckCustFee.Text = _row.BAD_CHECK_CUST_FEE
            End If
        End Sub

        Private Sub btn_Save_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
            ' bad check updating defaults
            _row.BAD_CHECK_CUSTITEM_LISTID = cmb_BadCheckCustInvItem.SelectedValue
            _row.BAD_CHECK_CHECKITEM_LISTID = cmb_BadCheckItem.SelectedValue
            _row.BAD_CHECK_CUST_FEE = tb_BadCheckCustFee.Text
            _row.EndEdit()
            If (_row.RowState = DataRowState.Modified) Then
                Try
                    AppTA.Update(_row)
                Catch ex as SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                MsgBox("Settings Saved.")
                Close()
            End If
        End Sub
    End Class
End Namespace