Imports QBFC12Lib
Imports TrashCash.QBStuff


Namespace Types
    Public Class AdminServiceTypes

        Private Sub AdminServiceTypes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub
        Private Sub ServiceTypes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ' fill grid
            ServiceTypesTableAdapter.Fill(ds_Types.ServiceTypes)
            ' bind combo box
            Dim list As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.ServiceItemQuery)
            cmb_QBAcc.DisplayMember = "DisplayMember"
            cmb_QBAcc.ValueMember = "ValueMember"
            cmb_QBAcc.DataSource = list
        End Sub

        Private Function ValidForEntry() As Boolean
            Dim err As Integer = 0
            Dim s As New System.Text.StringBuilder

            ' check name
            If (Trim(tb_Name.Text) = "") Then
                err += 1
                tb_Name.BackColor = AppColors.TextBoxErr
                s.Append(" -Name invalid").AppendLine()
            Else
                tb_Name.BackColor = AppColors.TextBoxDef
            End If

            ' check qb acc
            If (cmb_QBAcc.SelectedValue Is Nothing) Then
                err += 1
                s.Append(" -QB Account is nothing").AppendLine()
            End If

            'check rate
            If (Trim(tb_Rate.Text) = "") Then
                err += 1
                tb_Rate.BackColor = AppColors.TextBoxErr
                s.Append(" -Rate is invalid").AppendLine()
            Else
                tb_Rate.BackColor = AppColors.TextBoxDef
            End If

            ' make sure bill length isnt 0
            If (nud_BillLen.Value <= 0) Then
                err += 1
                s.Append(" -Bill Length must be greater than 0")
            End If

            ' check desc
            If (Trim(tb_Desc.Text) = "") Then
                err += 1
                tb_Desc.BackColor = AppColors.TextBoxErr
                s.Append(" -Desc is blank")
            Else
                tb_Desc.BackColor = AppColors.TextBoxDef
            End If

            If (err = 0) Then
                Return True
            Else
                MessageBox.Show("Field errors: " & vbCrLf & s.ToString)
                Return False
            End If
        End Function

        Private Sub btn_AddItem_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddItem.Click
            If (ValidForEntry()) Then
                Dim item As New QBItemObj
                With item
                    .ItemName = tb_Name.Text
                    .Price = tb_Rate.Text
                    .Desc = tb_Desc.Text
                    .IncomeAccountListID = cmb_QBAcc.SelectedValue
                End With
                Dim resp As IResponse = QBRequests.ServiceItemAdd(item)
                If (resp.StatusCode = 0) Then
                    Dim ret As IItemServiceRet = resp.Detail
                    With item
                        .ListID = ret.ListID.GetValue
                        .EditSequence = ret.EditSequence.GetValue
                    End With
                    Try
                        ' insert into db
                        ServiceTypesTableAdapter.Insert(item.ItemName, item.ListID, item.EditSequence, item.Price, item.Desc, nud_BillLen.Value, True)
                    Catch ex As SqlException
                        MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                        "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    MessageBox.Show(item.ItemName & " added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' reset form
                    tb_Name.Clear()
                    tb_Rate.Clear()
                    cmb_QBAcc.SelectedIndex = 0
                    tb_Desc.Clear()
                    nud_BillLen.Value = 1
                    ' refil grid
                    ServiceTypesTableAdapter.Fill(ds_Types.ServiceTypes)
                Else
                    QBMethods.ResponseErr_Misc(resp)
                End If
            End If
        End Sub
    End Class
End Namespace