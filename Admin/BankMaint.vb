Public Class BankMaint
    Private _Home As TrashCash_Home

    Private Sub BankMaint_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'If (ts_cb_BankList.Items.Count > 0) Then
        '    UC_BankMaint.BankID = ts_cb_BankList.ComboBox.SelectedValue
        'End If

    End Sub

    Private Sub btn_ModBank_Click(sender As System.Object, e As System.EventArgs) Handles btn_ModBank.Click
        If (Ts_cmb_BadCheckBanks.ComboBox.SelectedValue IsNot Nothing) Then
            UC_BankMaint.CurrentBankID = Ts_cmb_BadCheckBanks.ComboBox.SelectedValue

            ' hide modify button and show save changes button
            btn_ModBank.Visible = False
            btn_SaveChanges.Visible = True
            btn_DeleteBank.Visible = True

            ' disable bank changing and adding
            Ts_cmb_BadCheckBanks.Enabled = False
            btn_AddBank.Enabled = False
        End If
    End Sub

    Private Sub btn_SaveChanges_Click(sender As System.Object, e As System.EventArgs) Handles btn_SaveChanges.Click
        UC_BankMaint.SaveBank()
    End Sub
    Private Sub BankSaved() Handles UC_BankMaint.BankSaved
        ' show modify button and hide save changes button
        btn_ModBank.Visible = True
        btn_SaveChanges.Visible = False
        btn_DeleteBank.Visible = False

        ' enable bank changing and adding
        Ts_cmb_BadCheckBanks.Enabled = True
        btn_AddBank.Enabled = True

        ' refresh list
        Ts_cmb_BadCheckBanks.RefreshForChanges()
    End Sub

    Private Sub btn_DeleteBank_Click(sender As System.Object, e As System.EventArgs) Handles btn_DeleteBank.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to mark this Bank setting deleted? All accounts and items will still remain in Quickbooks.", MsgBoxStyle.YesNo)
        If (result = MsgBoxResult.Yes) Then
            UC_BankMaint.DeleteBank()
        End If
    End Sub
    Private Sub BankDeleted() Handles UC_BankMaint.BankDeleted
        ' show modify button and hide save changes button
        btn_ModBank.Visible = True
        btn_SaveChanges.Visible = False
        btn_DeleteBank.Visible = False

        ' enable bank changing and adding
        Ts_cmb_BadCheckBanks.Enabled = True
        btn_AddBank.Enabled = True

        ' refresh list
        Ts_cmb_BadCheckBanks.RefreshForChanges()
    End Sub

    Private Sub btn_AddBank_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddBank.Click
        UC_BankMaint.NewBank()

        ' hide modify button and show save changes button
        btn_ModBank.Visible = False
        btn_SaveChanges.Visible = True
        btn_DeleteBank.Visible = True

        ' disable bank changing and adding
        Ts_cmb_BadCheckBanks.Enabled = False
        btn_AddBank.Enabled = False
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Home = HomeForm
        UC_BankMaint.HomeForm = HomeForm
    End Sub
End Class