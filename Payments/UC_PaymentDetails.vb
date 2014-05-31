Public Class UC_PaymentDetails
    ' event to add new working row to grid
    Public Event PaymentAdded(ByVal rowID As Integer)

    ' dt going to spawn rows from
    Protected dt As DataSet.WorkingPaymentsDataTable
    ' ta i can use
    Protected ta As DataSetTableAdapters.WorkingPaymentsTableAdapter
    Protected qta As DataSetTableAdapters.QueriesTableAdapter
    
    ' var to track debug mode
    Private _debugMode As Boolean
    Private Property DebugMode As Boolean
        Get
            Return _debugMode
        End Get
        Set(value As Boolean)
            _debugMode = value
            ck_Override.Visible = True
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dt = New DataSet.WorkingPaymentsDataTable
        ta = New DataSetTableAdapters.WorkingPaymentsTableAdapter
        qta = New DataSetTableAdapters.QueriesTableAdapter


    End Sub

    Private _currentCustomer As Integer
    Public Property CurrentCustomer As Integer
        Get
            Return _currentCustomer
        End Get
        Set(value As Integer)
            If (_currentCustomer <> value) Then
                _currentCustomer = value
                dt.Clear()
            End If
        End Set
    End Property


    Private Sub ResetForm()
        ' reset tbs on form
        tb_Amount.Text = String.Empty
        tb_RefNum.Text = String.Empty
        tb_RefNum.Visible = False
        lbl_RefNumber.Visible = False

        ' reset date on check value
        dtp_DateOnCheck.Value = Date.Now
        dtp_DateOnCheck.Visible = False
        lbl_DateOnCheck.Visible = False

        ' reseting payment type selection to first option
        Cmb_PaymentTypes.SelectedIndex = 0

        ' checking if in debug mode
        If (DebugMode) Then
            ck_Override.Checked = False
            dtp_Override.Visible = False
            dtp_Override.Value = Date.Now
        End If
    End Sub


    Private Function OkToCommit()
        Dim err As Integer = 0
        Dim defaultColor = SystemColors.Window
        Dim errorColor = Color.MistyRose

        If (Cmb_PaymentTypes.SelectedValue <> 1) Then
            If (tb_RefNum.TextLength <= 0) Then
                err += 1
                tb_RefNum.BackColor = errorColor
            Else
                tb_RefNum.BackColor = defaultColor
            End If
        End If

        If (err = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btn_Commit_Click(sender As System.Object, e As System.EventArgs) Handles btn_AddPayment.Click
        If (OkToCommit()) Then
            Try
                Dim newID As Integer

                ' trimming checknum
                Dim checkRefNum As String = Trim(tb_RefNum.Text)

                ' checking if override checked
                If (ck_Override.Checked) Then
                    ' inserting override date chosen as time inserted
                    ' insert with current time and check if dateoncheck is nothing (cash payment)
                    If (Cmb_PaymentTypes.SelectedValue = 1) Then
                        newID = ta.WorkingPayments_Insert(CurrentCustomer, tb_Amount.Text, Cmb_PaymentTypes.SelectedValue, checkRefNum,
                          5, dtp_Override.Value.Date, Nothing)
                    Else
                        newID = ta.WorkingPayments_Insert(CurrentCustomer, tb_Amount.Text, Cmb_PaymentTypes.SelectedValue, checkRefNum,
                       5, dtp_Override.Value.Date, dtp_DateOnCheck.Value.Date)
                    End If
                Else
                    ' insert with current time and check if dateoncheck is nothing (cash payment)
                    If (Cmb_PaymentTypes.SelectedValue = 1) Then
                        newID = ta.WorkingPayments_Insert(CurrentCustomer, tb_Amount.Text, Cmb_PaymentTypes.SelectedValue, checkRefNum,
                          5, Date.Now, Nothing)
                    Else
                        newID = ta.WorkingPayments_Insert(CurrentCustomer, tb_Amount.Text, Cmb_PaymentTypes.SelectedValue, checkRefNum,
                       5, Date.Now, dtp_DateOnCheck.Value.Date)
                    End If

                End If


                RaiseEvent PaymentAdded(newID)
                ' prep for new row
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                ResetForm()
            End Try
        Else
            MsgBox("Please correct the required fields.")
        End If
    End Sub

    Private Sub Cmb_PaymentTypes_SelectionChangeCommitted(sender As ComboBox, e As System.EventArgs) Handles Cmb_PaymentTypes.SelectionChangeCommitted
        If (sender.SelectedValue = 1) Then
            ' hide check number lbl and box
            tb_RefNum.Visible = False
            lbl_RefNumber.Visible = False
            lbl_DateOnCheck.Visible = False
            dtp_DateOnCheck.Visible = False
        Else
            ' show check number lbl and box
            tb_RefNum.Visible = True
            lbl_RefNumber.Visible = True
            dtp_DateOnCheck.Visible = True
            lbl_DateOnCheck.Visible = True
        End If
    End Sub

    Private Sub UC_PaymentDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If (CBool(AppQTA.APP_GetDebugMode) = True) Then
            DebugMode = True
        End If
    End Sub

    Private Sub ck_Override_Click(sender As System.Object, e As System.EventArgs) Handles ck_Override.Click
        If (ck_Override.Checked = True) Then
            dtp_Override.Visible = True
        Else
            dtp_Override.Visible = False
        End If
    End Sub

    Private Sub Cmb_PaymentTypes_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles Cmb_PaymentTypes.SelectionChangeCommitted

    End Sub
End Class
