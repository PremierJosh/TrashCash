Public Class PaymentModifyForm

    Private _row As ds_Batching.BATCH_WorkingPaymentsRow
    Private Property Row As ds_Batching.BATCH_WorkingPaymentsRow
        Get
            Return _row
        End Get
        Set(value As ds_Batching.BATCH_WorkingPaymentsRow)
            _row = value
            ' set form controls for this row
            If (cmb_PayTypes.Items.Count > 0) Then
                cmb_PayTypes.SelectedValue = value.WorkingPaymentsType
            End If
            tb_Amount.Text = value.WorkingPaymentsAmount
            If (Not value.IsWorkingPaymentsCheckNumNull) Then
                tb_RefNum.Text = value.WorkingPaymentsCheckNum
            End If
            If (Not value.IsDATE_ON_CHECKNull) Then
                dtp_DateOnCheck.Value = value.DATE_ON_CHECK
            End If

            ' set customer name
            lbl_CustName.Text = value.CustomerFullName
        End Set
    End Property
    Private _ta As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter


    Public Sub New(ByRef paymentRow As ds_Batching.BATCH_WorkingPaymentsRow, ByRef payTA As ds_BatchingTableAdapters.BATCH_WorkingPaymentsTableAdapter, ByRef payTypeTbl As ds_Types.PaymentTypesDataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        
        ' bind row for pay type cmb
        cmb_PayTypes.DataSource = payTypeTbl
        cmb_PayTypes.ValueMember = payTypeTbl.PaymentTypeIDColumn.ToString
        cmb_PayTypes.DisplayMember = payTypeTbl.PaymentTypeNameColumn.ToString

        ' set row through property and use the same ta
        Row = paymentRow
        _ta = payTA
    End Sub

    Private Sub cmb_PayTypes_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmb_PayTypes.SelectedValueChanged
        If (cmb_PayTypes.SelectedValue <> TC_ENPaymentTypes.Cash) Then
            lbl_RefNumber.Visible = True
            tb_RefNum.Visible = True
            lbl_DateOnCheck.Visible = True
            dtp_DateOnCheck.Visible = True
        Else
            lbl_RefNumber.Visible = False
            tb_RefNum.Visible = False
            lbl_DateOnCheck.Visible = False
            dtp_DateOnCheck.Visible = False
            ' wipe check num and reset date on check
            tb_RefNum.Clear()
            dtp_DateOnCheck.Value = Date.Now
        End If
    End Sub
    Private Function OkToCommit()
        If (Trim(tb_Amount.Text) <> "") Then
            tb_Amount.BackColor = AppColors.TextBoxDef
            If (cmb_PayTypes.SelectedValue <> TC_ENPaymentTypes.Cash) Then
                If (Trim(tb_RefNum.Text) = "") Then
                    tb_RefNum.BackColor = AppColors.TextBoxErr
                    Return False
                Else
                    tb_RefNum.BackColor = AppColors.TextBoxDef
                End If
            End If
        Else
            tb_Amount.BackColor = AppColors.TextBoxErr
            Return False
        End If
        
        Return True
    End Function

    Private Sub btn_SavePayment_Click(sender As System.Object, e As System.EventArgs) Handles btn_SavePayment.Click
        Dim checkRefNum As String = ""
        Dim dateOnCheck As Date?


        If (OkToCommit()) Then
            ' check number verify
            If (cmb_PayTypes.SelectedValue <> TC_ENPaymentTypes.Cash) Then
                ' get date
                dateOnCheck = dtp_DateOnCheck.Value.Date

                ' remove all spaces from begining and end
                checkRefNum = Trim(tb_RefNum.Text)
                ' replace all zeros by spaces, and then, left-trim that result, ie, remove starting spaces. 
                'The external Replace replaces the spaces left in the string to their initial 0 character.
                Replace(LTrim(Replace(checkRefNum, "0", " ")), " ", "0")

                ' having them confirm check number
                If (checkRefNum <> "") Then
                    ' hide current ref number
                    tb_RefNum.Visible = False
                    Dim reEntry As String = InputBox("Please enter the check number again:", "Confirm Check #")
                    ' show ref number after input
                    tb_RefNum.Visible = True
                    ' trim entry number and compare
                    Trim(reEntry)
                    Replace(LTrim(Replace(reEntry, "0", " ")), " ", "0")
                    ' do these match
                    If (reEntry <> checkRefNum) Then
                        MessageBox.Show("Check numbers do not match. Please re-enter the check number and double check information.", "Check # Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        tb_RefNum.Clear()
                        Exit Sub
                    End If
                End If
            End If

            ' submit changes
            With Row
                .WorkingPaymentsType = cmb_PayTypes.SelectedValue
                .WorkingPaymentsAmount = tb_Amount.Text
                If (checkRefNum <> "") Then
                    .WorkingPaymentsCheckNum = checkRefNum
                Else
                    .SetWorkingPaymentsCheckNumNull()
                End If
                If (dateOnCheck IsNot Nothing) Then
                    .DATE_ON_CHECK = dateOnCheck
                Else
                    .SetDATE_ON_CHECKNull()
                End If
            End With

            ' save row
            Try
                Row.EndEdit()
                _ta.Update(Row)
                Close()
            Catch ex As SqlException
                MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        

    End Sub
End Class