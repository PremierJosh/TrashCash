Imports QBFC12Lib
Imports TrashCash.QBStuff

Namespace Customer

    Public Class UC_CustomerInfoBoxes
        Private _custRow As ds_Customer.CustomerRow
        Private ReadOnly _ta As ds_CustomerTableAdapters.CustomerTableAdapter


        ' writeonly property for batching status
        Private _batchInProgress As Boolean
        Public WriteOnly Property BatchInProgress As Boolean
            Set(value As Boolean)
                If (_batchInProgress <> value) Then
                    _batchInProgress = value
                End If
            End Set
        End Property

        ' writeonly property to hide context menu

        ' bool to keep update state
        Private _isUpdating As Boolean
        Public Property IsUpdating As Boolean
            Get
                Return _isUpdating
            End Get
            Set(value As Boolean)
                If (value = True) Then
                    LockBoxes(False)
                    ' hide update info btn and show save changes
                    btn_UpdateInfo.Visible = False
                    btn_SaveChanges.Visible = True
                Else
                    LockBoxes(True)
                    ' hide save changes and show update info
                    btn_UpdateInfo.Visible = True
                    btn_SaveChanges.Visible = False
                End If

                _isUpdating = value
                ' throw event
                RaiseEvent Updating(IsUpdating)
            End Set
        End Property
        ' events
        Public Event Updating(ByVal bool As Boolean)

        ' property refrence
        Private _currentCustomer As Integer
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
                        _ta.Fill(Ds_Customer.Customer, value)
                        _custRow = Ds_Customer.Customer.Rows(0)
                        ' checking if deactive
                        If (_custRow.CustomerIsDeactive) Then
                            chk_CustDeactive.Visible = True
                            End If
                    Else
                        UpdateCheck()
                    End If
                End If
            End Set
        End Property

        ' property for list id
        Public ReadOnly Property CustomerListID As String
            Get
                ' grabbing custListID
                Return _custRow.CustomerListID
            End Get
        End Property
        ' property for customer active state
        Friend ReadOnly Property CustomerDeactive As Boolean
            Get
                Return _custRow.CustomerIsDeactive
            End Get
        End Property

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            ' instantiate
            _ta = New ds_CustomerTableAdapters.CustomerTableAdapter
            isUpdating = False
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
                ' hide deactive if not checked
                If (Not chk_CustDeactive.Checked) Then
                    chk_CustDeactive.Visible = True
                End If

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
                ' always show deactive box on edit
                chk_CustDeactive.Visible = True

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

        Private Sub Customer_Update()
            _custRow.BeginEdit()
            ' building customer full name
            If (Trim(tb_CompanyName.Text) <> "") Then
                _custRow.CustomerFullName = _custRow.CustomerCompanyName & " - " & _custRow.CustomerNumber
            Else
                _custRow.CustomerFullName = _custRow.CustomerLastName & ", " & _custRow.CustomerFirstName & " - " & _custRow.CustomerNumber
            End If
            ' trim phone number
            _custRow.CustomerPhone = PhoneFormat(_custRow.CustomerPhone)
            If (Not _custRow.IsCustomerAltPhoneNull) Then
                _custRow.CustomerAltPhone = PhoneFormat(_custRow.CustomerAltPhone)
            End If
            ' update
            Dim resp As IResponse = QBRequests.CustomerMod(_custRow)
            If (resp.StatusCode = 0) Then
                Dim customerRet As ICustomerRet = resp.Detail
                ' updating EditSeq in the DB
                _custRow.CustomerEditSeq = customerRet.EditSequence.GetValue()
                _custRow.EndEdit()

                Try
                    ' update table
                    CustomerTableAdapter.Update(_custRow)
                    ' pass event and change property
                    IsUpdating = False
                    MessageBox.Show("Changes saved.", "Changes saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf (resp.StatusCode = 3200) Then
                MessageBox.Show("EditSequence missmatch - updating now... Any changed made in Quickbooks will be overwritten.")
                ' edit sequence missmatch
                _custRow.CustomerEditSeq = QBRequests.Customer_GetEditSequence(_custRow.CustomerListID)
                Try
                    CustomerTableAdapter.Update(_custRow)
                    ' re update
                    Customer_Update()
                Catch ex As SqlException
                    MessageBox.Show("Message: " & ex.Message & vbCrLf & "LineNumber: " & ex.LineNumber,
                                    "Sql Error: " & ex.Procedure, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                End Try

            Else
                QBMethods.ResponseErr_Misc(resp)
            End If

        End Sub

        Private Sub UpdateCheck(Optional ByVal suppress As Boolean = False)
            If (IsUpdating) Then
                If (_custRow IsNot Nothing) Then
                    CustomerBindingSource.EndEdit()
                    If (_custRow.RowState <> DataRowState.Unchanged) Then
                        If (suppress) Then
                            Customer_Update()
                        Else
                            Dim result As DialogResult = MessageBox.Show("Some information related to this Customer has been changed. Would you like to save these changes?",
                                                                         "Confirm changes.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If (result = DialogResult.Yes) Then
                                Customer_Update()
                            Else
                                ' if no then reject changes
                                Ds_Customer.Customer.Rows(0).RejectChanges()
                                ' reset all boxes
                                CustomerBindingSource.ResetCurrentItem()
                                ' pass event and change property
                                IsUpdating = False
                            End If
                        End If
                    End If
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
        Private _allowUpdate As Boolean
        Public Property AllowUpdate As Boolean
            Get
                Return _allowUpdate
            End Get
            Set(value As Boolean)
                _allowUpdate = value
                ' set visibility of context menu buttons
                cm_Update.Enabled = value
            End Set
        End Property

        Private Sub btn_UpdateUnlock_Click(sender As System.Object, e As System.EventArgs) Handles btn_UpdateInfo.Click
            If (Not _batchInProgress) Then
                IsUpdating = True
                btn_UpdateInfo.Visible = False
                btn_SaveChanges.Visible = True
                'custRow.BeginEdit()
            Else
                MsgBox("You cannot edit a Customers information while a batch is running.")
            End If
        End Sub

        Private Sub btn_SaveChanges_Click(sender As System.Object, e As System.EventArgs) Handles btn_SaveChanges.Click
            UpdateCheck(True)
        End Sub

        Private Sub chk_CustDeactive_Click(sender As System.Object, e As System.EventArgs) Handles chk_CustDeactive.Click
            ' checking for active services
            Dim count As Integer
            Using qta As New ds_CustomerTableAdapters.QueriesTableAdapter
                count = qta.Customer_RecSrvcActive(CurrentCustomer)
            End Using

            If (Not _custRow.CustomerIsDeactive) Then
                If (count > 0) Then
                    _custRow.CustomerIsDeactive = False
                    MessageBox.Show("You must first end ALL Recurring Services for this Customer before you mark them Inactive. There are currently " &
                                    count.ToString & " Recurring Services still running.", "Stop Running Services", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    _custRow.CustomerIsDeactive = True
                    ' update customer
                    Customer_Update()
                End If
            Else
                _custRow.CustomerIsDeactive = False
                ' update customer
                Customer_Update()
            End If
        End Sub

        Private Sub ck_SingleInv_Click(sender As System.Object, e As System.EventArgs) Handles ck_SingleInv.Click
            If (ck_SingleInv.Checked = True) Then
                Dim result As MsgBoxResult = MsgBox("Marking this Customer as Single Invoice will cause all Recurring Services to bill within that Customers bill interval - no matter the service." & vbCrLf & _
                                                    "For example, Toters will bill every 1 month if this Customers bill interval is set to 1. This change will also cause all Recurring Services to bill to the Customers start date day." & vbCrLf & _
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
                lbl_BillInterval.Visible = True
                nud_BillInterval.Visible = True
            Else
                lbl_BillInterval.Visible = False
                nud_BillInterval.Visible = False
            End If
        End Sub

        Private Sub UC_CustomerInfoBoxes_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        End Sub
    End Class
End Namespace