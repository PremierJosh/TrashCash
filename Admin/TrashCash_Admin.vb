Imports System.Windows.Forms
Imports TrashCash.Admin.Payments
Imports TrashCash.Types

Namespace Admin

    Public Class TrashCashAdmin
        ' home form ref
 ' user row
        Private _userRow As ds_Application.USERSRow
        Friend Property UserRow As ds_Application.USERSRow
            Get
                Return _userRow
            End Get
            Set(value As ds_Application.USERSRow)
                _userRow = value

                ' update lbl
                lbl_AdminUser.Text = "Current Admin User: " & value.USER_NAME
                AuthLevel = value.USER_AUTHLVL
            End Set
        End Property

        Public Sub New(ByVal userRow As ds_Application.USERSRow)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.UserRow = userRow
        End Sub
        ' this is sub to handle events for balance changing and payments being added to queues
        Friend Sub CustomerBalancingChanged(ByVal customerNumber As Integer)
            If (AdminPay IsNot Nothing) Then

            End If
        End Sub
        Friend Sub CustomerPaymentAdded(ByVal customerNumber As Integer)

        End Sub
        ' public auth level property for easier access and event raising
        Private _authLevel As Integer
        ' vars for quick menu checking
        Private _bypassLogin As Boolean = False
        Public Property AuthLevel As Integer
            Get
                Return _authLevel
            End Get
            Set(value As Integer)
                _authLevel = value

                ' current as of 5/16/14
                ' ID---NAME---AUTHLVL
                ' 1	  Premier	1
                ' 2	  Phyllis	1
                ' 3	  Pam		2
                ' 4	  Nicole	3

                ' auth level 1 is super admin, no login prompts
                If (value = 1) Then
                    _bypassLogin = True
                ElseIf (value = 2) Then
                    ' level 2 = login prompts, no import work
                    btn_ExportImport.Enabled = False
                ElseIf (value = 3) Then
                    ' disable admin
                    Close()
                Else
                    MessageBox.Show("AUTH LEVEL UNKNOWKN")
                    Close()
                End If
            End Set
        End Property

        ' form refs
        Private WithEvents _userSelection As UserSelection
        Friend WithEvents AdminPay As AdminPayments
        Private WithEvents _adminServiceTypes As AdminServiceTypes
        Private WithEvents _adminBanks As AdminBanks
        Private WithEvents _adminDefaults As AdminDefaults
        Private WithEvents _adminExportImport As AdminExportImport
        Private WithEvents _adminInvoiceTypes As AdminInvoiceTypes

        Private Sub btn_AdminPay_Click(sender As System.Object, e As System.EventArgs) Handles btn_AdminPay.Click
            If (AdminPay Is Nothing) Then
                AdminPay = New AdminPayments()
                AddHandler AdminPay.CustomerCheckBounce, AddressOf HomeForm.CustomerCheckBounced
                AddHandler AdminPay.CustomerPaymentMoved, AddressOf HomeForm.CustomerPaymentMoved
                AdminPay.MdiParent = Me
            End If
            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                _userSelection = New UserSelection("Administration Login")
                _userSelection.ShowDialog()
                If (_userSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                _userSelection = Nothing
            End If

            If (open) Then
                AdminPay.BringToFront()
                AdminPay.Show()
            End If

        End Sub
       
        Private Sub btn_ServiceTypes_Click(sender As System.Object, e As System.EventArgs) Handles btn_ServiceTypes.Click
            If (_adminServiceTypes Is Nothing) Then
                _adminServiceTypes = New AdminServiceTypes()
                _adminServiceTypes.MdiParent = Me
            End If
            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                _userSelection = New UserSelection("Administration Login")
                _userSelection.ShowDialog()
                If (_userSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                _userSelection = Nothing
            End If

            If (open) Then
                _adminServiceTypes.BringToFront()
                _adminServiceTypes.Show()
            End If

        End Sub

        Private Sub btn_Banks_Click(sender As System.Object, e As System.EventArgs) Handles btn_Banks.Click
            If (_adminBanks Is Nothing) Then
                _adminBanks = New AdminBanks
                _adminBanks.MdiParent = Me
            End If
            Dim open As Boolean = False
            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                _userSelection = New UserSelection("Administration Login")
                _userSelection.ShowDialog()
                If (_userSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                _userSelection = Nothing
            End If
            If (open) Then
                _adminBanks.BringToFront()
                _adminBanks.Show()
            End If

        End Sub

        Private Sub btn_Defaults_Click(sender As System.Object, e As System.EventArgs) Handles btn_Defaults.Click
            If (_adminDefaults Is Nothing) Then
                _adminDefaults = New AdminDefaults
                _adminDefaults.MdiParent = Me
            End If
            Dim open As Boolean = False
            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                _userSelection = New UserSelection("Administration Login")
                _userSelection.ShowDialog()
                If (_userSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                _userSelection = Nothing
            End If

            If (open) Then
                _adminDefaults.BringToFront()
                _adminDefaults.Show()
            End If

        End Sub

        Private Sub btn_ExportImport_Click(sender As System.Object, e As System.EventArgs) Handles btn_ExportImport.Click
            ' checking if auth level can bypass logins
            If (UserRow.USER_AUTHLVL = 1) Then
                If (_adminExportImport Is Nothing) Then
                    _adminExportImport = New AdminExportImport()
                End If
                _adminExportImport.MdiParent = Me
                _adminExportImport.Show()
            End If
        End Sub

        Private Sub btn_InvTypes_Click(sender As System.Object, e As System.EventArgs) Handles btn_InvTypes.Click
            If (_adminInvoiceTypes Is Nothing) Then
                _adminInvoiceTypes = New AdminInvoiceTypes
                _adminInvoiceTypes.MdiParent = Me
            End If

            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                _userSelection = New UserSelection("Administration Login")
                _userSelection.ShowDialog()
                If (_userSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                _userSelection = Nothing
            End If

            If (open) Then
                _adminInvoiceTypes.BringToFront()
                _adminInvoiceTypes.Show()
            End If
        End Sub
    End Class
End Namespace