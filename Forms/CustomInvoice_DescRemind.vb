Imports QBFC12Lib
Imports TrashCash.TrashCash_Utils


Public Class CustomInvoice_DescRemind


    Protected _dueDate As Date
    Public WriteOnly Property DueDate As Date
        Set(value As Date)
            _dueDate = value

            ' set dtps
            dtp_DueDate.Value = value
            dtp_RemindDate.Value = value
        End Set
    End Property
    Protected _postDate As Date
    Public WriteOnly Property PostDate As Date
        Set(value As Date)
            _postDate = value

            'set dtp
            dtp_PostDate.Value = value
        End Set
    End Property

    Private _invTotal As Double
    Public WriteOnly Property InvoiceTotal As Double
        Set(value As Double)
            If (value > 0) Then
                _invTotal = value
                ' set total box
                tb_InvTotal.Text = FormatCurrency(_invTotal)
            End If
        End Set
    End Property
    Protected _custNum As Integer
    Public WriteOnly Property CustomerNumber As Integer
        Set(value As Integer)
            If (value <> 0) Then
                _custNum = value
                Ts_M_Customer1.CurrentCustomer = value
                Ts_M_Customer1.Enabled = False
                Ts_M_Customer1.HideQuickSearch()
                ' init balance set
                Ts_M_Customer1.lbl_CustBalance.SetBalance(_home.Queries.Customer_Balance(value))
            End If
        End Set
    End Property
    Protected _dt As DataSet.CustomInvoice_LineItemsDataTable
    Public WriteOnly Property LineItems As DataSet.CustomInvoice_LineItemsDataTable
        Set(value As DataSet.CustomInvoice_LineItemsDataTable)
            _dt = value
        End Set
    End Property
    Protected _toPrint As Boolean
    Public WriteOnly Property ToPrint As Boolean
        Set(value As Boolean)
            _toPrint = value
        End Set
    End Property

    ' home form ref var
    Private _home As TrashCash_Home

    Friend Event SubmitInvoice(ByVal Description As String)

    Protected Reminder As Boolean = False
    Protected OkToClose As Boolean = False

    Private Sub tb_InvDesc_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_InvDesc.TextChanged
        If (Len(tb_InvDesc.Text) < 4000) Then
            lbl_InvDescLen.Text = Len(tb_InvDesc.Text)
            lbl_InvDescLen.ForeColor = SystemColors.ControlText
        ElseIf (Len(tb_InvDesc.Text) = 4000) Then
            lbl_InvDescLen.Text = 4000
            lbl_InvDescLen.ForeColor = Color.Red
        End If
    End Sub

    Private Sub tb_RemindText_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_RemindText.TextChanged
        If (Len(tb_RemindText.Text) < 4000) Then
            lbl_RemindTextLen.Text = Len(tb_RemindText.Text)
            lbl_RemindTextLen.ForeColor = SystemColors.ControlText
        ElseIf (Len(tb_RemindText.Text) = 4000) Then
            lbl_RemindTextLen.Text = 4000
            lbl_RemindTextLen.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ck_CreateReminder_Click(sender As System.Object, e As System.EventArgs) Handles ck_CreateReminder.Click
        If (ck_CreateReminder.Checked = True) Then
            ' update reminder var
            Reminder = True
            ' make panel visable
            pnl_Bot.Visible = True
            tb_RemindText.Text = tb_InvDesc.Text
        Else
            ' update reminder var
            Reminder = False
            ' hide pnl
            pnl_Bot.Visible = False
        End If
    End Sub

    Private Function ValidateFields()
        Dim err As Integer = 0

        If (Len(tb_InvDesc.Text) = 0) Then
            err += 1
            MsgBox("You must provide a Description for this Invoice.")
        End If

        If (Reminder = True) Then
            If (Len(tb_RemindText.Text) < 1) Then
                err += 1
                MsgBox("You must provide text for the Reminder.")
            End If
        End If

        If (err = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btn_Submit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Submit.Click
        If (ValidateFields() = True) Then
            Try
                Dim cihID As Integer = _home.Procedures.Invoicing_Custom(_custNum, _postDate, _dueDate, _toPrint, tb_InvDesc.Text, _dt)

                If (Reminder = True) Then
                    ' create reminder
                    Dim rqta As New Report_DataSetTableAdapters.QueriesTableAdapter
                    rqta.Calendar_CustomInvoices_Insert(cihID, dtp_RemindDate.Value.Date, tb_RemindText.Text)
                End If

                RaiseEvent SubmitInvoice(tb_RemindText.Text)
                OkToClose = True
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub CustomInvoice_DescRemind_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (Not OkToClose) Then
            e.Cancel = True
            ' prompt that this will delete the invoice
            Dim result As MsgBoxResult = MsgBox("Are you sure you wish to cancel? This Invoice will not be created.", MsgBoxStyle.YesNo)
            If (result = MsgBoxResult.Yes) Then

                'RaiseEvent CancelInvoice()

                OkToClose = True
                e.Cancel = False
                Me.Close()
                Exit Sub
            End If

        End If
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _home = HomeForm
    End Sub

End Class