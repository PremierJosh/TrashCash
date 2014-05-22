Namespace Admin
    ' ReSharper disable once InconsistentNaming
    Public Class UC_BankMaint
        ' property to hold home form ref
        Private _home As TrashCashHome
        Friend Property HomeForm As TrashCashHome
            Get
                Return _home
            End Get
            Set(value As TrashCashHome)
                _home = value
            End Set
        End Property

        ' dt that holds all the banks avail for bouncing checks
        Private Property Dt2 As ds_Program.BAD_CHECK_BANKS_DataTable

        ' tas
        Private Property Ta2 As ds_ProgramTableAdapters.BAD_CHECK_BANKS_TableAdapter

        ' row refrence so we know what our current bankID row info is
        Private Property Row2 As ds_Program.BAD_CHECK_BANKS_Row

        ' public properties
        Private _currentBankID As Integer
        Public Property CurrentBankID As Integer
            Get
                Return _currentBankID
            End Get
            Set(value As Integer)
                If (value <> 0) Then
                    _currentBankID = value

                    ' do stuff here
                    ' show controls regardless of new number - could modify same bank twice
                    Visible = True
                    ' refresh table
                    Ta2.Fill(Dt2)
                    ' update row refrence
                    Row2 = Dt2.FindByBC_BANK_ID(value)
                    ' move all combo boxes to correct qb accounts/items
                    UpdateControls()
                End If
            End Set
        End Property
        Private Sub UpdateControls()
            ' these are unique to the bank
            tb_BankName.Text = Row2.BANK_NAME
            cmb_BankAccs.SelectedValue = Row2.QB_BANK_LISTID
            cmb_BanksInvItem.SelectedValue = Row2.QB_BANK_INV_ITEM_LISTID
            cmb_VendorAcc.SelectedValue = Row2.QB_VENDOR_LISTID
            tb_BankFee.Text = FormatCurrency(Row2.BANK_FEE_DEFAULT)
        End Sub

        Friend Event BankSaved()
        Public Sub SaveBank()
            Row2.BANK_NAME = tb_BankName.Text
            Row2.QB_BANK_LISTID = cmb_BankAccs.SelectedValue
            Row2.QB_BANK_INV_ITEM_LISTID = cmb_BanksInvItem.SelectedValue
            Row2.QB_VENDOR_LISTID = cmb_VendorAcc.SelectedValue
            Row2.BANK_FEE_DEFAULT = tb_BankFee.Text

            Try
                Ta2.Update(Dt2)
                MsgBox(Row2.BC_BANK_ID)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                ' hide at end of update
                Visible = False
                ' throw event for parent form to catch
                RaiseEvent BankSaved()
                ClearControls()
            End Try
        End Sub

        Friend Event BankDeleted()
        Public Sub DeleteBank()
            Try
                Ta2.MarkDeleted(CurrentBankID)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                ' hide at end of marking
                Visible = False
                RaiseEvent BankDeleted()
                ClearControls()
            End Try
        End Sub
        Private Sub ClearControls()
            ' clear tbs
            tb_BankName.Text = ""
            tb_BankFee.Text = ""
            ' reset all cmb indexes
            cmb_BankAccs.SelectedIndex = 0
            cmb_BanksInvItem.SelectedIndex = 0
            cmb_VendorAcc.SelectedIndex = 0
            ' refil dt
            Ta2.Fill(Dt2)
        End Sub

        Public Sub NewBank()
            ' show control
            Visible = True

            ' create new row
            Row2 = Dt2.NewBAD_CHECK_BANKS_Row
            Dt2.AddBAD_CHECK_BANKS_Row(Row2)
        End Sub
        Private Sub UC_BankMaint_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            BindCmbs()
        End Sub

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' new stuff
            Dt2 = Ds_Program.BAD_CHECK_BANKS_
            Ta2 = BAD_CHECK_BANKS_TableAdapter
        End Sub

        Private Sub BindCmbs()
            HomeForm.Queries.CMB_BindBankAccount(cmb_BankAccs)
            HomeForm.Queries.CMB_BindOtherChargeItems(cmb_BanksInvItem)
            HomeForm.Queries.CMB_BindVendorAccount(cmb_VendorAcc)
        End Sub

        'Private Sub SetUCBoxes()
        '    If (row IsNot Nothing) Then
        '        ' set selected quickbooks bank by listid
        '        cmb_BankAccs.SelectedValue = row.BankAccountListID
        '        ' set quickbooks item related to this bank
        '        cmb_BanksInvItem.SelectedValue = row.BanksInvoiceItemListID
        '        ' set quickbooks vendor for bank
        '        cmb_VendorAcc.SelectedValue = row.VendorAccountListID
        '        ' set bank fee
        '        tb_BankFee.Text = FormatCurrency(row.BankBounceFee)

        '    End If
        'End Sub



        'Public Function SaveChanges()
        '    ' var to return if save is good
        '    Dim saved As Boolean = False

        '    If (FeesValid() = True) Then
        '        ' set all fields in row and then commit

        '        ' bank account name and listid
        '        row.BankAccountName = cmb_BankAccs.Text
        '        row.BankAccountListID = cmb_BankAccs.SelectedValue
        '        ' vendor account name and listid
        '        row.VendorAccountName = cmb_VendorAcc.Text
        '        row.VendorAccountListID = cmb_VendorAcc.SelectedValue
        '        ' checkadd item name and listid
        '        row.BouncedCheckItemName = cmb_CheckItem.Text
        '        row.BouncedCheckItemListID = cmb_CheckItem.SelectedValue
        '        ' banks item name, listid, and fee
        '        row.BanksInvoiceItemName = cmb_BanksInvItem.Text
        '        row.BanksInvoiceItemListID = cmb_BanksInvItem.SelectedValue
        '        row.BankBounceFee = CDbl(tb_BankFee.Text)

        '        ' out customer fee item name, listid and rate
        '        row.CustomerChargeItemName = cmb_CustInvItem.Text
        '        row.CustomerChargeItemListID = cmb_CustInvItem.SelectedValue
        '        row.CustomerChargeRate = CDbl(tb_CustFee.Text)

        '        ' end edit and commit
        '        If (BankID = 0) Then
        '            dt.AddBanksRow(row)
        '        End If

        '        row.EndEdit()
        '        If (row.RowState <> DataRowState.Unchanged) Then
        '            Try

        '                ta.Update(row)
        '                saved = True
        '            Catch ex As SqlClient.SqlException
        '                If (ex.ErrorCode = -2146232060) Then
        '                    MsgBox("This Bank has already been set up. Please select it from the list and Modify or Delete it first.")
        '                End If
        '            End Try
        '        End If
        '    End If

        '    ' if saved then reset form
        '    If (saved = True) Then
        '        tb_BankFee.Text = String.Empty
        '        tb_CustFee.Text = String.Empty
        '        dt.Clear()
        '    End If

        '    Return saved
        'End Function

        ''Private Function NewRow()
        ''    ' returning a fresh row
        ''    Dim returnRow As DataSet.BanksRow = DataSet.Banks.NewBanksRow

        ''    ' set all fields in row and then commit

        ''    ' bank account name and listid
        ''    returnRow.BankAccountName = cb_QBBankList.FullName
        ''    returnRow.BankAccountListID = cb_QBBankList.ListID
        ''    ' vendor account name and listid
        ''    returnRow.VendorAccountName = cb_QBVendorList.FullName
        ''    returnRow.VendorAccountListID = cb_QBVendorList.ListID
        ''    ' checkadd item name and listid
        ''    returnRow.BouncedCheckItemName = cb_QBCheckItem.FullName
        ''    returnRow.BouncedCheckItemListID = cb_QBCheckItem.ListID
        ''    ' banks item name, listid, and fee
        ''    returnRow.BanksInvoiceItemName = cb_BankInvoiceItem.FullName
        ''    returnRow.BanksInvoiceItemListID = cb_BankInvoiceItem.ListID
        ''    returnRow.BankBounceFee = CDbl(tb_BankFee.Text)
        ''    ' out customer fee item name, listid and rate
        ''    returnRow.CustomerChargeItemName = cb_CustInvItem.FullName
        ''    returnRow.CustomerChargeItemListID = cb_CustInvItem.ListID
        ''    returnRow.CustomerChargeRate = CDbl(tb_CustFee.Text)


        ''    Return returnRow
        ''End Function
        'Private Function FeesValid()
        '    ' err count var
        '    Dim err As Integer = 0
        '    Dim defaultColor = SystemColors.Window
        '    Dim errorColor = Color.MistyRose

        '    If (IsNumeric(tb_CustFee.Text) = True) Then
        '        If (tb_CustFee.Text <= 0) Then
        '            tb_CustFee.BackColor = errorColor
        '            err += 1
        '        Else
        '            tb_CustFee.BackColor = defaultColor
        '        End If
        '    Else
        '        err += 1
        '        tb_CustFee.BackColor = errorColor
        '    End If

        '    If (IsNumeric(tb_BankFee.Text) = True) Then
        '        If (tb_BankFee.Text <= 0) Then
        '            tb_BankFee.BackColor = errorColor
        '            err += 1
        '        Else
        '            tb_BankFee.BackColor = defaultColor
        '        End If
        '    Else
        '        err += 1
        '        tb_BankFee.BackColor = errorColor
        '    End If

        '    If (err = 0) Then
        '        Return True
        '    Else
        '        Return False
        '    End If
        'End Function
    End Class
End Namespace