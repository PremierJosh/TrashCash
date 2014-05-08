Public Class RecurringServicesForm
    ' event to lat cust form know to refresh rec srvc tab
    Friend Event ServiceUpdated()

    ' Property
    Private _currentCustomer As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            If (value > 0) Then
                _currentCustomer = value
                ' set ucs
                UC_CustomerInfoBoxes.CurrentCustomer = _currentCustomer
                UC_CustomerNotes.CurrentCustomer = _currentCustomer
                'UC_RecSrvcDetails.CurrentCustomer = _currentCustomer
            End If
        End Set
    End Property

    Private Sub ServiceUpdateComplete() Handles UC_RecSrvcDetails.CommitComplete
        MsgBox("Changes Saved")
        RaiseEvent ServiceUpdated()
        Me.Close()
    End Sub


    Public Sub New(ByVal CustomerNumber As Integer, ByVal CustomerName As String, ByRef HomeForm As TrashCash_Home, Optional ByVal RecurringServiceID As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        CurrentCustomer = CustomerNumber
        ' setting form title
        Me.Text = CustomerName

        ' checking if a service was passed, otherwise its new
        If (RecurringServiceID <> 0) Then
            UC_RecSrvcDetails.RecurringServiceID = RecurringServiceID
        Else
            ' new service
            UC_RecSrvcDetails.NewService(CustomerNumber)
        End If

        ' telling uc rec srv details what home form is
        UC_RecSrvcDetails._HomeForm = HomeForm
    End Sub

    Private Sub RecurringServicesForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' turning off info box updating
        UC_CustomerInfoBoxes.AllowUpdate(False)
    End Sub
End Class