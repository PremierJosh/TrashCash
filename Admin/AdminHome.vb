
Public Class AdminHome

    ' properties for user auth level
    Private _authLVL As Integer
    Public Property CurrentAuthLevel As Integer
        Get
            Return _authLVL
        End Get
        Set(value As Integer)
            _authLVL = value
        End Set
    End Property

    ' form refrences
    Friend WithEvents _serviceForm As ServiceTypes
    Friend WithEvents _invVoidForm As InvoiceVoid
    Friend WithEvents _payHisForm As PaymentHistory
    Friend WithEvents _bankMaintForm As BankMaint
    Friend WithEvents _appDefaults As App_Defaults

    ' events
    Friend Event AdminClosed()

    Private _homeForm As TrashCash_Home
    Friend Property TC_Home As TrashCash_Home
        Get
            Return _homeForm
        End Get
        Set(value As TrashCash_Home)
            _homeForm = value
        End Set
    End Property

    ' form global tas
    Dim cta As DataSetTableAdapters.CustomerTableAdapter
    Dim qta As DataSetTableAdapters.QueriesTableAdapter

    Private Sub AdminHome_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (_appDefaults IsNot Nothing) Then
            _appDefaults.Close()
            _appDefaults = Nothing
        End If
        If (_serviceForm IsNot Nothing) Then
            _serviceForm.Close()
            _serviceForm = Nothing
        End If
        If (_invVoidForm IsNot Nothing) Then
            _invVoidForm.Close()
            _invVoidForm = Nothing
        End If
        If (_payHisForm IsNot Nothing) Then
            _payHisForm.Close()
            _payHisForm = Nothing
        End If
        If (_bankMaintForm IsNot Nothing) Then
            _bankMaintForm.Close()
            _bankMaintForm = Nothing
        End If

        ' raise closed event
        RaiseEvent AdminClosed()
    End Sub


    Private Sub AdminHome_Load(sender As Object, e As System.EventArgs) Handles Me.Load


    End Sub



    Private Sub btn_ServiceTypeForm_Click(sender As System.Object, e As System.EventArgs) Handles btn_ServiceTypeForm.Click
        _serviceForm = New ServiceTypes(TC_Home)
        _serviceForm.MdiParent = TC_Home
        _serviceForm.Show()
    End Sub

    Private Sub btn_InvVoid_Click(sender As System.Object, e As System.EventArgs) Handles btn_InvVoid.Click
        _invVoidForm = New InvoiceVoid(TC_Home)

        _invVoidForm.Show()
    End Sub

    Private Sub btn_PayHistory_Click(sender As System.Object, e As System.EventArgs) Handles btn_PayHistory.Click
        _payHisForm = New PaymentHistory(TC_Home)

        _payHisForm.Show()
    End Sub

    Private Sub btn_BankAdmin_Click(sender As System.Object, e As System.EventArgs) Handles btn_BankAdmin.Click
        _bankMaintForm = New BankMaint(TC_Home)

        _bankMaintForm.Show()
    End Sub

    Private Sub btn_AppDefaults_Click(sender As System.Object, e As System.EventArgs) Handles btn_AppDefaults.Click
        _appDefaults = New App_Defaults(TC_Home)

        _appDefaults.Show()
    End Sub

    Public Sub New(ByRef HomeForm As TrashCash_Home, ByVal UserAuthLevel As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TC_Home = HomeForm
        CurrentAuthLevel = UserAuthLevel
    End Sub

    Private Sub Panel1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Panel1.DoubleClick
        Dim f As New ImportWork(TC_Home)
        f.ShowDialog()
    End Sub
End Class