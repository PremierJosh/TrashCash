Public Class ReportView

    Protected _reportObj
    Public WriteOnly Property ReportObj
        Set(value)
            _reportObj = value
            If (_reportObj IsNot Nothing) Then
                _reportObj.SetDataSource(_ds)
                CrystalReportViewer.ReportSource = _reportObj
                CrystalReportViewer.Refresh()
            End If
        End Set
    End Property

    Protected _ds As Report_DataSet
    Public WriteOnly Property ReportDS
        Set(value)
            _ds = value
        End Set
    End Property

    Protected scripts As ReportScripts

    Private Sub Cmb_ReportType_SelectionChangeCommitted(sender As ComboBox, e As System.EventArgs) Handles Cmb_ReportType.SelectionChangeCommitted
        If (sender.SelectedValue = 1) Then
            ' all customers with balances = both dtps disabled and labels hidden
            dtp_From.Visible = False
            lbl_From.Visible = False
            dtp_To.Visible = False
            lbl_To.Visible = False
        ElseIf (sender.SelectedValue = 2) Then
            ' all payments received on date = disable to dtp, enable from dtp, hide labels
            dtp_From.Visible = True
            lbl_From.Visible = False
            dtp_To.Visible = False
            lbl_To.Visible = False
        ElseIf (sender.SelectedValue = 3) Then
            ' payments received between dates = enable both dtps and show both labels
            dtp_From.Visible = True
            lbl_From.Visible = True
            dtp_To.Visible = True
            lbl_To.Visible = True
        End If
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

        ' first option in combobox is all customer balances so we will hide these controls by default
        dtp_From.Visible = False
        lbl_From.Visible = False
        dtp_To.Visible = False
        lbl_To.Visible = False
    End Sub


    Private Sub ReportView_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '_ds = New Report_DataSet
        scripts = New ReportScripts
    End Sub
End Class