Public Class UC_CustomerInfoBoxes
    Protected custRow As DataSet.CustomerRow
    Protected ta As DataSetTableAdapters.CustomerTableAdapter

    ' writeonly property for batching status
    Private _batchInProgress As Boolean
    Public WriteOnly Property BatchInProgress As Boolean
        Set(value As Boolean)
            If (_batchInProgress <> value) Then
                _batchInProgress = value
            End If
        End Set
    End Property

    ' property for home form ref
    Private _home As TrashCash_Home
    Friend Property HomeForm As TrashCash_Home
        Get
            Return _home
        End Get
        Set(value As TrashCash_Home)
            _home = value
        End Set
    End Property


    ' bool to keep update state
    Protected _isUpdating As Boolean
    Public Property isUpdating As Boolean
        Get
            Return _isUpdating
        End Get
        Set(value As Boolean)
            If (value = True) Then
                _isUpdating = True
                LockBoxes(False)
            Else
                _isUpdating = False
                LockBoxes(True)
            End If

            ' throw event
            RaiseEvent Updating(isUpdating)
        End Set
    End Property
    ' events
    Public Event Updating(ByVal bool As Boolean)
    Public Event UpdateComplete(ByVal CustomerNumber As Decimal)

    ' property refrence
    Protected _currentCustomer As Integer
    ' property
    Public Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            If (value > 0) Then
                If (Not isUpdating) Then
                    ' refrence
                    _currentCustomer = value

                    ' filling customer table
                    ta.FillByCustomerNumber(Me.DataSet.Customer, value)
                    custRow = Me.DataSet.Customer.Rows(0)
                Else
                    UpdateCheck()
                End If
            End If
        End Set
    End Property

    ' property
    Public ReadOnly Property CustomerListID As String
        Get
            ' grabbing custListID
            Return custRow.CustomerListID
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' instantiate
        ta = New DataSetTableAdapters.CustomerTableAdapter
        isUpdating = False
        ' bind single inv check box to bill interval
        nud_BillInterval.DataBindings.Add("Visible", Me.ck_SingleInv, "Checked")
    End Sub

    Private Sub LockBoxes(ByVal bool As Boolean)
        If (bool = True) Then
            ' General Information Grp Box
            box_CustPhone.ReadOnly = True
            box_CustAltPhone.ReadOnly = True
            box_CustContact.ReadOnly = True
            chk_CustBillAdvance.Enabled = False

            ' lock name stuff
            tb_CompanyName.ReadOnly = True
            tb_FirstName.ReadOnly = True
            tb_LastName.ReadOnly = True

            ' lock deactivate check box
            chk_CustDeactive.Enabled = False

            ' Service and Invoice Information Grp Box
            ck_SingleInv.Enabled = False
            nud_BillInterval.Enabled = False
            chk_CustBillAdvance.Enabled = False
            chk_CustPrintInv.Enabled = False

            ' Billing Address Tab
            box_CustBillAddr1.ReadOnly = True
            box_CustBillAddr2.ReadOnly = True
            box_CustBillAddr3.ReadOnly = True
            tb_BillAddr4.ReadOnly = True
            box_CustBillCity.ReadOnly = True
            box_CustBillState.ReadOnly = True
            box_CustBillZip.ReadOnly = True

        Else
            ' General Information Grp Box
            box_CustPhone.ReadOnly = False
            box_CustAltPhone.ReadOnly = False
            chk_CustBillAdvance.Enabled = True
            box_CustContact.ReadOnly = False

            ' unlock name stuff
            tb_CompanyName.ReadOnly = False
            tb_FirstName.ReadOnly = False
            tb_LastName.ReadOnly = False

            ' unlock deactivate check box
            chk_CustDeactive.Enabled = True

            ' Service and Invoice Information Grp Box
            ck_SingleInv.Enabled = True
            nud_BillInterval.Enabled = True
            chk_CustBillAdvance.Enabled = True
            chk_CustPrintInv.Enabled = True

            ' Billing Address Tab
            box_CustBillAddr1.ReadOnly = False
            box_CustBillAddr2.ReadOnly = False
            box_CustBillAddr3.ReadOnly = False
            tb_BillAddr4.ReadOnly = False
            box_CustBillCity.ReadOnly = False
            box_CustBillState.ReadOnly = False
            box_CustBillZip.ReadOnly = False

        End If
    End Sub


    Private Sub UpdateCheck(Optional suppress As Boolean = False)
        If (isUpdating) Then
            If (custRow IsNot Nothing) Then
                'Me.DataSet.Customer.Rows(0).EndEdit()
                'custRow.EndEdit()
                CustomerBindingSource.EndEdit()
                If (custRow.RowState <> DataRowState.Unchanged) Then
                    Dim result As MsgBoxResult = MsgBox("Some information related to this Customer has been changed. Would you like to save these changes?", vbYesNo)

                    If (result = MsgBoxResult.Yes) Then
                        ' if yes then commit

                        custRow.BeginEdit()
                        ' building customer full name
                        If (Trim(tb_CompanyName.Text) <> "") Then
                            custRow.CustomerFullName = custRow.CustomerCompanyName & " - " & custRow.CustomerNumber
                        Else
                            custRow.CustomerFullName = custRow.CustomerLastName & ", " & custRow.CustomerFirstName & " - " & custRow.CustomerNumber
                        End If

                        ' end edit again to grab name changes
                        custRow.EndEdit()

                        Try
                            HomeForm.Procedures.Customer_Update(custRow)

                            ' pass event and change property
                            RaiseEvent UpdateComplete(CurrentCustomer)
                            isUpdating = False
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    ElseIf (result = MsgBoxResult.No) Then
                        ' if no then reject changes
                        Me.DataSet.Customer.Rows(0).RejectChanges()
                        ' reset all boxes
                        Me.CustomerBindingSource.ResetCurrentItem()
                        ' pass event and change property
                        RaiseEvent UpdateComplete(CurrentCustomer)
                        isUpdating = False
                    End If
                Else
                    isUpdating = False
                End If
                ' and hide the save changes button if its visible
                cm_i_SaveChanges.Visible = False
                cm_i_UpdateUnlock.Visible = True
            End If
        Else
            MsgBox("Must begin Edit first.")
        End If
    End Sub

    Private Sub box_KeyDown(sender As TextBox, e As System.Windows.Forms.KeyEventArgs) Handles box_CustPhone.KeyDown, box_CustFullName.KeyDown, box_CustContact.KeyDown, box_CustBillZip.KeyDown, box_CustBillState.KeyDown, _
        box_CustBillCity.KeyDown, box_CustBillAddr3.KeyDown, box_CustBillAddr2.KeyDown, box_CustBillAddr1.KeyDown, box_CustAltPhone.KeyDown

        If (isUpdating) Then
            If (e.KeyCode = Keys.Enter) Then
                UpdateCheck()
            End If
        End If
    End Sub
    ' public sub to disable updating for other forms
    Public Sub AllowUpdate(ByVal bool As Boolean)
        cm_Update.Enabled = bool
        cm_Update.Visible = bool
    End Sub
    Private Sub cm_i_UpdateUnlock_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_UpdateUnlock.Click
        If (Not _batchInProgress) Then
            isUpdating = True
            cm_i_UpdateUnlock.Visible = False
            cm_i_SaveChanges.Visible = True
            'custRow.BeginEdit()
        Else
            MsgBox("You cannot edit a Customers information while a batch is running.")
        End If
    End Sub

    Private Sub cm_i_SaveChanges_Click(sender As System.Object, e As System.EventArgs) Handles cm_i_SaveChanges.Click
        UpdateCheck()
    End Sub

    Private Sub chk_CustDeactive_Click(sender As System.Object, e As System.EventArgs) Handles chk_CustDeactive.Click
        ' checking for active services
        Dim qta As New DataSetTableAdapters.QueriesTableAdapter
        Dim count As Integer = qta.Customer_RecSrvcActive(CurrentCustomer)

        If (count > 0) Then
            chk_CustDeactive.Checked = False
            MsgBox("You must first end ALL Recurring Services for this Customer before you mark them Inactive. There are currently " & count.ToString & " Recurring Services still running.")
        Else
            chk_CustDeactive.Checked = True
        End If
    End Sub

    Private Function PhoneFormat(ByVal strPhoneNumber As String) As String

        ' Remove any style characters from the user input
        strPhoneNumber = Replace(strPhoneNumber, ")", "")
        strPhoneNumber = Replace(strPhoneNumber, "(", "")
        strPhoneNumber = Replace(strPhoneNumber, "-", "")
        strPhoneNumber = Replace(strPhoneNumber, ".", "")
        strPhoneNumber = Replace(strPhoneNumber, Space(1), "")

        Dim strFormatedNumber As String = CLng(strPhoneNumber).ToString("(###) ###-####")
        Return strFormatedNumber
    End Function

    Private Sub UC_CustomerInfoBoxes_Load(sender As Object, e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub grp_GenInfo_Enter(sender As System.Object, e As System.EventArgs) Handles grp_GenInfo.Enter

    End Sub

    Private Sub box_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles box_CustPhone.KeyDown, box_CustFullName.KeyDown, box_CustContact.KeyDown, box_CustBillZip.KeyDown, box_CustBillState.KeyDown, box_CustBillCity.KeyDown, box_CustBillAddr3.KeyDown, box_CustBillAddr2.KeyDown, box_CustBillAddr1.KeyDown, box_CustAltPhone.KeyDown

    End Sub

    Private Sub ck_SingleInv_Click(sender As System.Object, e As System.EventArgs) Handles ck_SingleInv.Click
        If (ck_SingleInv.Checked = True) Then
            Dim result As MsgBoxResult = MsgBox("Marking this Customer as Single Invoice will cause all Recurring Services to bill within that Customers bill interval - no matter the service." & vbCrLf & _
                                                "For example, Toters will bill every 1 month if this Customers bill interval is set to 1." & vbCrLf & _
                                                "Do you wish to change this Customer to Single Invoice?")
            If (result = MsgBoxResult.No) Then
                ck_SingleInv.Checked = False
            Else
                ck_SingleInv.Checked = True
            End If

        End If
    End Sub

    Private Sub ck_SingleInv_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ck_SingleInv.CheckedChanged
        If (ck_SingleInv.Checked = True) Then
            nud_BillInterval.Visible = True
        Else
            nud_BillInterval.Visible = False
        End If
    End Sub
End Class
