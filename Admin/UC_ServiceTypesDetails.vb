
Public Class UC_ServiceTypesDetails
    ' property for home form ref
    Private _home As TrashCash_Home
    Friend Property _HomeForm As TrashCash_Home
        Get
            Return _home
        End Get
        Set(value As TrashCash_Home)
            _home = value
        End Set
    End Property

    Private Property _IsNew As Boolean

    Public Event UpdateComplete(ByVal Message As String)


    Public Sub Prep(ByVal ServiceTypeID As Decimal)
        Me.DataSet.Clear()
        Me.ServiceTypesTableAdapter.FillByID(Me.DataSet.ServiceTypes, ServiceTypeID)

        ' hide account selection
        lbl_Account.Visible = False

        _IsNew = False
    End Sub

    Public Sub PrepNew()
        Me.DataSet.Clear()

        Dim row As DataSet.ServiceTypesRow = Me.DataSet.ServiceTypes.NewServiceTypesRow

        row.ServiceName = "ItemName"
        row.ServiceRate = "0.00"
        row.ServiceDescription = "Description required"
        row.ServiceBillLength = "1"
        row.ServiceActive = True

        Me.DataSet.ServiceTypes.AddServiceTypesRow(row)

        ' show account selection
        lbl_Account.Visible = True

        _IsNew = True
    End Sub

    Private Sub btn_SaveChanges_Click(sender As System.Object, e As System.EventArgs) Handles btn_SaveChanges.Click
        If (ValidateTBs() = True) Then
            Me.DataSet.ServiceTypes.Rows(0).EndEdit()
            If (Me.DataSet.ServiceTypes.Rows(0).RowState <> DataRowState.Unchanged) Then
                ' check for marking inactive
                If (ServiceActiveCheckBox.Checked = False) Then
                    Dim prompt As MsgBoxResult = MsgBox("This Item is marked as inactive. You will be unable to use this item on future invoices with this set. Do you want to keep this Item Inactive?", MsgBoxStyle.YesNo)
                    If (prompt = MsgBoxResult.No) Then
                        Exit Sub
                    End If
                End If

                Try
                    Me.ServiceTypesTableAdapter.Update(Me.DataSet.ServiceTypes)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try

                If (_IsNew = True) Then
                    _HomeForm.Procedures.Items_NewServiceItem(Me.DataSet.ServiceTypes.Rows(0).Item("ServiceTypeID"), cmb_IncomeAcc.SelectedValue)
                    RaiseEvent UpdateComplete("Service Item Added")
                Else
                    _HomeForm.Procedures.Items_UpdateServiceItem(Me.DataSet.ServiceTypes.Rows(0).Item("ServiceTypeID"))
                    RaiseEvent UpdateComplete("Service Item Updated")
                End If

            End If
        Else
            MsgBox("Please correct the highlighted fields.")
        End If
    End Sub

    Private Function ValidateTBs()
        Dim err As Integer = 0
        Dim defaultColor = SystemColors.Window
        Dim errorColor = Color.MistyRose

        ' checking name
        If (tb_ServiceName.Text.Length = 0 Or tb_ServiceName.Text = "ItemName") Then
            err += 1
            tb_ServiceName.BackColor = errorColor
        Else
            tb_ServiceName.BackColor = defaultColor
        End If

        'checking description
        If (tb_ServiceDescription.Text.Length = 0 Or tb_ServiceDescription.Text = "Description required") Then
            err += 1
            tb_ServiceDescription.BackColor = errorColor
        Else
            tb_ServiceDescription.BackColor = defaultColor
        End If

        ' checking rate box
        If (IsNumeric(tb_ServiceRate.Text) = True) Then
            If (tb_ServiceRate.Text <= 0) Then
                tb_ServiceRate.BackColor = errorColor
                err += 1
            Else
                tb_ServiceRate.BackColor = defaultColor
            End If
        Else
            tb_ServiceRate.BackColor = errorColor
            err += 1
        End If

        ' checking bill length
        If (IsNumeric(tb_ServiceBillLength.Text) = True) Then
            If (tb_ServiceBillLength.Text <= 0) Then
                tb_ServiceBillLength.BackColor = errorColor
                err += 1
            Else
                tb_ServiceBillLength.BackColor = defaultColor
            End If
        Else
            tb_ServiceBillLength.BackColor = errorColor
            err += 1
        End If

        If (err = 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
      
    End Sub

    Private Sub UC_ServiceTypesDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' bind account box
        _HomeForm.Queries.CMB_BindIncomeAccount(cmb_IncomeAcc)
    End Sub

    'Private Sub Label1_Click(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.Click
    '    If (e.Button = Windows.Forms.MouseButtons.Right) Then
    '        Dim input As String = InputBox("Password to add all Items to quickbooks initially.")
    '        If (input = "baTman11") Then
    '            Dim result As MsgBoxResult = MsgBox("Please make sure the correct Account is selected above.", MsgBoxStyle.YesNo)
    '            If (result = MsgBoxResult.Yes) Then
    '                _HomeForm.Procedures.Items_ImportAllMissingListID(cmb_IncomeAcc.SelectedValue)
    '            End If
    '        End If
    '    End If
    'End Sub
End Class
