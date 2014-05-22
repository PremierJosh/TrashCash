Public Class AdminDefaults
    Private ReadOnly _home As TrashCashHome

    ' tas
    Private ReadOnly _ta As ds_ProgramTableAdapters.APP_SETTINGS_TableAdapter

    ' refrences
    Private dt As ds_Program.APP_SETTINGS_DataTable
    Private row As ds_Program.APP_SETTINGS_Row

    ' previous values
    Private _defaultInvItem

    Public Sub New(ByRef HomeForm As TrashCashHome)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _ta = Me.APP_SETTINGS_TableAdapter
        _home = HomeForm
    End Sub
    Private Sub App_Defaults_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        _home.Queries.CMB_BindServiceItem(cmb_CustomInvItem)
        _home.Queries.CMB_BindOtherChargeItems(cmb_BadCheckCustInvItem)
        _home.Queries.CMB_BindOtherChargeItems(cmb_BadCheckItem)

        ' fill table
        dt = _ta.GetData
        row = dt.Rows(0)

        SetControls()

    End Sub

    Private Sub SetControls()
        ' invoicing
        cmb_CustomInvItem.SelectedValue = row.DEFAULT_INV_ITEM_LISTID

        ' bad check
        cmb_BadCheckCustInvItem.SelectedValue = row.BAD_CHECK_CUSTITEM_LISTID
        cmb_BadCheckItem.SelectedValue = row.BAD_CHECK_CHECKITEM_LISTID
        tb_BadCheckCustFee.Text = row.BAD_CHECK_CUST_FEE

    End Sub

    Private Sub btn_Save_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
        ' invoicing
        row.DEFAULT_INV_ITEM_LISTID = cmb_CustomInvItem.SelectedValue

        ' bad check
        row.BAD_CHECK_CUSTITEM_LISTID = cmb_BadCheckCustInvItem.SelectedValue
        row.BAD_CHECK_CHECKITEM_LISTID = cmb_BadCheckItem.SelectedValue
        row.BAD_CHECK_CUST_FEE = tb_BadCheckCustFee.Text

        row.EndEdit()
        If (row.RowState = DataRowState.Modified) Then
            Try
                _ta.Update(row)
                MsgBox("Settings Saved.")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class