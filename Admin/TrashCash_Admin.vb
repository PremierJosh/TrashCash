Imports System.Windows.Forms

Public Class TrashCash_Admin
    ' home form ref
    Friend HomeForm As TrashCashHome

    ' user row
    Private _userRow As ds_Program.USERSRow
    Friend Property UserRow As ds_Program.USERSRow
        Get
            Return _userRow
        End Get
        Set(value As ds_Program.USERSRow)
            _userRow = value

            ' update lbl
            lbl_AdminUser.Text = "Current Admin User: " & value.USER_NAME
            AuthLevel = value.USER_AUTHLVL
        End Set
    End Property

    Public Sub New(ByRef p_HomeForm As TrashCashHome, ByVal p_UserRow As ds_Program.USERSRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HomeForm = p_HomeForm
        UserRow = p_UserRow
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
                Me.Close()
            Else
                MessageBox.Show("AUTH LEVEL UNKNOWKN")
                Me.Close()
            End If
        End Set
    End Property

    ' form refs
    Friend WithEvents f_UserSelection As UserSelection
    Friend WithEvents f_AdminPay As AdminPayments
    Friend WithEvents f_AdminServiceTypes As AdminServiceTypes
    Friend WithEvents f_AdminBanks As AdminBanks
    Friend WithEvents f_AdminDefaults As AdminDefaults
    Friend WithEvents f_AdminExportImport As AdminExportImport

    Private Sub btn_AdminPay_Click(sender As System.Object, e As System.EventArgs) Handles btn_AdminPay.Click
        If (f_AdminPay IsNot Nothing) Then
            f_AdminPay.BringToFront()
            f_AdminPay.Show()
        Else
            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                f_UserSelection = New UserSelection("Administration Login")
                f_UserSelection.ShowDialog()
                If (f_UserSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                f_UserSelection = Nothing
            End If

            If (open) Then
                f_AdminPay = New AdminPayments(HomeForm)
                f_AdminPay.MdiParent = Me
                f_AdminPay.Show()
            End If
        End If
    End Sub

    Private Sub btn_ServiceTypes_Click(sender As System.Object, e As System.EventArgs) Handles btn_ServiceTypes.Click
        If (f_AdminServiceTypes IsNot Nothing) Then
            f_AdminServiceTypes.BringToFront()
            f_AdminServiceTypes.Show()
        Else
            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                f_UserSelection = New UserSelection("Administration Login")
                f_UserSelection.ShowDialog()
                If (f_UserSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                f_UserSelection = Nothing
            End If

            If (open) Then
                f_AdminServiceTypes = New AdminServiceTypes(HomeForm)
                f_AdminServiceTypes.MdiParent = Me
                f_AdminServiceTypes.Show()
            End If
        End If
    End Sub

    Private Sub btn_Banks_Click(sender As System.Object, e As System.EventArgs) Handles btn_Banks.Click
        If (f_AdminBanks IsNot Nothing) Then
            f_AdminBanks.BringToFront()
            f_AdminBanks.Show()
        Else
            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                f_UserSelection = New UserSelection("Administration Login")
                f_UserSelection.ShowDialog()
                If (f_UserSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                f_UserSelection = Nothing
            End If

            If (open) Then
                f_AdminBanks = New AdminBanks(HomeForm)
                f_AdminBanks.MdiParent = Me
                f_AdminBanks.Show()
            End If
        End If
    End Sub

    Private Sub btn_Defaults_Click(sender As System.Object, e As System.EventArgs) Handles btn_Defaults.Click
        If (f_AdminDefaults IsNot Nothing) Then
            f_AdminDefaults.BringToFront()
            f_AdminDefaults.Show()
        Else
            Dim open As Boolean = False

            ' checking if auth level can bypass logins
            If (_bypassLogin) Then
                open = True
            Else
                f_UserSelection = New UserSelection("Administration Login")
                f_UserSelection.ShowDialog()
                If (f_UserSelection.AuthUserRow IsNot Nothing) Then
                    open = True
                End If
                f_UserSelection = Nothing
            End If

            If (open) Then
                f_AdminDefaults = New AdminDefaults(HomeForm)
                f_AdminDefaults.MdiParent = Me
                f_AdminDefaults.Show()
            End If
        End If
    End Sub

    Private Sub btn_ExportImport_Click(sender As System.Object, e As System.EventArgs) Handles btn_ExportImport.Click
        If (f_AdminExportImport IsNot Nothing) Then
            f_AdminExportImport.BringToFront()
            f_AdminExportImport.Show()
        Else
            ' checking if auth level can bypass logins
            If (UserRow.USER_AUTHLVL = 1) Then
                f_AdminExportImport = New AdminExportImport(HomeForm)
                f_AdminExportImport.MdiParent = Me
                f_AdminExportImport.Show()
            End If
        End If
    End Sub
End Class
