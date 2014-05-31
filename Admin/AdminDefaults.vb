Namespace Admin
    Public Class AdminDefaults
        Private ReadOnly _home As TrashCashHome

        ' tas
        Private ReadOnly _ta As ds_AppTableAdapters.APP_SETTINGS_TableAdapter

        ' refrences
        Private _dt As ds_App.APP_SETTINGS_DataTable
        Private _row As ds_App.APP_SETTINGS_Row


        Public Sub New(ByRef homeForm As TrashCashHome)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ta = APP_SETTINGS_TableAdapter
            _home = homeForm
        End Sub
        Private Sub App_Defaults_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            _home.Queries.CMB_BindServiceItem(cmb_CustomInvItem)
            _home.Queries.CMB_BindOtherChargeItems(cmb_BadCheckCustInvItem)
            _home.Queries.CMB_BindOtherChargeItems(cmb_BadCheckItem)

            ' fill table
            _dt = _ta.GetData
            _row = _dt.Rows(0)

            SetControls()

        End Sub

        Private Sub SetControls()
            ' InvoicingForm
            cmb_CustomInvItem.SelectedValue = _row.DEFAULT_INV_ITEM_LISTID

            ' bad check
            cmb_BadCheckCustInvItem.SelectedValue = _row.BAD_CHECK_CUSTITEM_LISTID
            cmb_BadCheckItem.SelectedValue = _row.BAD_CHECK_CHECKITEM_LISTID
            tb_BadCheckCustFee.Text = _row.BAD_CHECK_CUST_FEE

        End Sub

        Private Sub btn_Save_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
            ' InvoicingForm
            _row.DEFAULT_INV_ITEM_LISTID = cmb_CustomInvItem.SelectedValue

            ' bad check
            _row.BAD_CHECK_CUSTITEM_LISTID = cmb_BadCheckCustInvItem.SelectedValue
            _row.BAD_CHECK_CHECKITEM_LISTID = cmb_BadCheckItem.SelectedValue
            _row.BAD_CHECK_CUST_FEE = tb_BadCheckCustFee.Text

            _row.EndEdit()
            If (_row.RowState = DataRowState.Modified) Then
                Try
                    _ta.Update(_row)
                    MsgBox("Settings Saved.")
                    Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End Sub
    End Class
End Namespace