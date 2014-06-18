﻿Imports TrashCash.QBStuff

Namespace Admin
    Public Class AdminDefaults
        Private ReadOnly _ta As ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter

        ' refrences
        Private _dt As ds_Application.APP_SETTINGSDataTable
        Private _row As ds_Application.APP_SETTINGSRow


        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ta = New ds_ApplicationTableAdapters.APP_SETTINGSTableAdapter
        End Sub

        Private Sub AdminDefaults_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If (e.CloseReason <> CloseReason.ApplicationExitCall) Then
                e.Cancel = True
                Hide()
            End If
        End Sub
        Private Sub App_Defaults_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            ' both combo boxes for items are other charge items and can use the same DS
            Dim list As List(Of ComboBoxPair) = QBMethods.GetComboBoxPair(QBRequests.OtherChargeItemQuery)
            ' bind cmb for invoice item representing the check
            cmb_BadCheckCustInvItem.DisplayMember = "DisplayMember"
            cmb_BadCheckCustInvItem.ValueMember = "ValueMember"
            cmb_BadCheckCustInvItem.DataSource = list
            ' bind cmb for inv item representing our fee
            cmb_BadCheckItem.DisplayMember = "DisplayMember"
            cmb_BadCheckItem.ValueMember = "ValueMember"
            cmb_BadCheckItem.DataSource = list

            ' fill table
            _dt = _ta.GetData
            _row = _dt.Rows(0)

            SetControls()
            End Sub

        Private Sub SetControls()
            ' set bad check defaults
            cmb_BadCheckCustInvItem.SelectedValue = _row.BAD_CHECK_CUSTITEM_LISTID
            cmb_BadCheckItem.SelectedValue = _row.BAD_CHECK_CHECKITEM_LISTID
            tb_BadCheckCustFee.Text = _row.BAD_CHECK_CUST_FEE

        End Sub

        Private Sub btn_Save_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
            ' bad check updating defaults
            _row.BAD_CHECK_CUSTITEM_LISTID = cmb_BadCheckCustInvItem.SelectedValue
            _row.BAD_CHECK_CHECKITEM_LISTID = cmb_BadCheckItem.SelectedValue
            _row.BAD_CHECK_CUST_FEE = tb_BadCheckCustFee.Text
            _row.EndEdit()
            If (_row.RowState = DataRowState.Modified) Then
                Try
                    _ta.Update(_row)
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