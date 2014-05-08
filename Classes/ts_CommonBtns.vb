Imports System.Windows.Forms
Imports TrashCash.TrashCash_Utils._Functions


Public Class ts_btn_Invoicing
    Inherits ToolStripButton

    ' relationships for event handles
    Friend WithEvents _batchForm As BatchingPrep
    Friend WithEvents _invForm As Invoicing

    Protected _custNum As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _custNum
        End Get
        Set(value As Integer)
            If (_custNum <> value) Then
                _custNum = value
            End If
        End Set
    End Property

    Public WriteOnly Property BatchForm As BatchingPrep
        Set(value As BatchingPrep)
            _batchForm = value
        End Set
    End Property
    Private _batching As Boolean
    Private Property Batching As Boolean
        Get
            Return _batching
        End Get
        Set(value As Boolean)
            If (_batching <> value) Then
                _batching = value

                ' checking if true so we can close inv window
                If (value = True) Then
                    If (_invForm IsNot Nothing) Then
                        _invForm.Close()
                    End If
                End If
            End If
        End Set
    End Property
    ' event handle will only fire if i set this property
    Private Sub BatchStatus(ByVal running As Boolean) Handles _batchForm.BatchRunning
        Batching = running
    End Sub


    Public Sub New()
        Me.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Image = Global.TrashCash.My.Resources.Resources.invoicingIcon
        Me.Text = "Invoicing"
    End Sub

    Private Sub ts_btn_Invoicing_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        If (Not Batching) Then
            Dim exists As Boolean
            'exists = FormExists(Invoicing.ToString, bringToFront:=True, _form:=_invForm)

            If (Not exists) Then
                _invForm = New Invoicing
                ' setting cust
                If (CurrentCustomer <> 0) Then
                    _invForm.CurrentCustomer = CurrentCustomer
                Else
                    Dim qta As New DataSetTableAdapters.QueriesTableAdapter
                    _invForm.CurrentCustomer = qta.Customer_GetFirstActiveCustNum
                    qta = Nothing
                End If

                _invForm.Show()
            End If
        Else
            MsgBox("You cannot open the Invoicing window while a Batch is currently running.")
        End If
    End Sub
End Class

Public Class ts_btn_Payments
    Inherits ToolStripButton

    ' relationships for event handles
    Friend WithEvents _batchForm As BatchingPrep
    Friend WithEvents _payForm As Payments

    Protected _custNum As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _custNum
        End Get
        Set(value As Integer)
            If (_custNum <> value) Then
                _custNum = value
            End If
        End Set
    End Property
    Public WriteOnly Property BatchForm As BatchingPrep
        Set(value As BatchingPrep)
            _batchForm = value
        End Set
    End Property
    Private _batching As Boolean
    Private Property Batching As Boolean
        Get
            Return _batching
        End Get
        Set(value As Boolean)
            If (_batching <> value) Then
                _batching = value

                ' checking if true so we can close payments form
                If (value = True) Then
                    If (_payForm IsNot Nothing) Then
                        _payForm.Close()
                    End If
                End If

            End If
        End Set
    End Property
    ' event handle will only fire if i set this property
    Private Sub BatchStatus(ByVal running As Boolean) Handles _batchForm.BatchRunning
        Batching = running
    End Sub


    Public Sub New()
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Image = Global.TrashCash.My.Resources.Resources.Payments_icon
        Me.Text = "Payments"
    End Sub

    Private Sub ts_btn_Payments_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        If (Not Batching) Then
            Dim exists As Boolean
            exists = FormExists(Payments.ToString, bringToFront:=True, _form:=_payForm)

            If (Not exists) Then
                _payForm = New Payments
                ' setting cust
                If (CurrentCustomer <> 0) Then
                    _payForm.CurrentCustomer = CurrentCustomer
                Else
                    Dim qta As New DataSetTableAdapters.QueriesTableAdapter
                    _payForm.CurrentCustomer = qta.Customer_GetFirstActiveCustNum
                    qta = Nothing
                End If

                _payForm.Show()
            End If
        Else
            MsgBox("You cannot open the Payments window while a Batch is currently running.")
        End If
    End Sub
End Class
