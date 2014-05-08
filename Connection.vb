Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class Connection

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btn_FindQBFile.Click
        Using ofd As New OpenFileDialog
            ofd.ValidateNames = False
            ofd.InitialDirectory = "C:\"

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                tb_QBFileLoc.Text = ofd.FileName
            End If
        End Using
    End Sub


    Private Shared Sub getSqlServers(ByVal sqlCombo As ComboBox)
        Dim servers As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources()

        For Each dr As DataRow In servers.Rows
            sqlCombo.Items.Add(dr.Item(0).ToString & "\" & dr.Item(1).ToString)
        Next
    End Sub

    Private Sub Connection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim con(,) As String
        con = GetAllSettings(My.Application.Info.AssemblyName, "Connection")

        If (con IsNot Nothing) Then
            ' update app settings
            My.Settings.SQLSERVER = GetSetting(My.Application.Info.AssemblyName, "Connection", "Server")
            My.Settings.DATABASENAME = GetSetting(My.Application.Info.AssemblyName, "Connection", "Database")
            My.Settings.Item("QBDBConnectionString") = "Data Source=" & My.Settings.SQLSERVER & ";Initial Catalog=" & My.Settings.DATABASENAME & ";Integrated Security=True;MultipleActiveResultSets=False"
            Dim login As New Login(Me)
            login.Show()

        End If
    End Sub
    Private Sub cmb_Server_Click(sender As System.Object, e As System.EventArgs) Handles cmb_Server.Click
        Me.Cursor = Cursors.WaitCursor

        ' Check if datatable is empty
        If tableServers.Rows.Count = 0 Then

            ' Get a datatable with info about SQL Server 2000 and 2005 instances
            tableServers = servers.GetDataSources()

            ' List that will be combobox’s datasource   
            Dim listServers As List(Of String) = New List(Of String)

            ' For each element in the datatable add a new element in the list
            For Each rowServer As DataRow In tableServers.Rows

                ' SQL Server instance could have instace name or only server name,
                ' check this for show the name
                If String.IsNullOrEmpty(rowServer("InstanceName").ToString()) Then
                    listServers.Add(rowServer("ServerName").ToString())
                Else
                    listServers.Add(rowServer("ServerName") & "\" & rowServer("InstanceName"))
                End If
            Next

            'Set servers list to combobox’s datasource
            Me.cmb_Server.DataSource = listServers
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private servers As SqlDataSourceEnumerator
    Private tableServers As DataTable
    Private server As String

    Public Sub New()
        InitializeComponent()

        servers = SqlDataSourceEnumerator.Instance
        tableServers = New DataTable()


    End Sub

    Private Sub cmb_DB_Click(sender As System.Object, e As System.EventArgs) Handles cmb_DB.Click
        Dim listDataBases As List(Of String) = New List(Of String)
        Dim connectString As String
        Dim selectSQL As String

        ' Check if user was selected a server to connect
        If Me.cmb_Server.Text = "" Then
            MsgBox("Must select a server")
            Return
        End If

        server = Me.cmb_Server.Text

        'Set connection string with selected server and integrated security
        connectString = "Data Source=" & server & " ;Integrated Security=True;Initial Catalog=master"

        Using con As New SqlConnection(connectString)
            ' Open connection
            con.Open()

            'Get databases names in server in a datareader
            selectSQL = "select name from sys.databases;"

            Dim com As SqlCommand = New SqlCommand(selectSQL, con)
            Dim dr As SqlDataReader = com.ExecuteReader()

            While (dr.Read())
                listDataBases.Add(dr(0).ToString())
            End While

            'Set databases list as combobox’s datasource
            Me.cmb_DB.DataSource = listDataBases

            con.Close()
            com = Nothing
            dr = Nothing
            'con = Nothing

        End Using
    End Sub

    Private Sub btn_Submit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Submit.Click
        Dim err As Integer = 0

        If (cmb_Server.Text = "") Then
            err += 1
        End If
        If (cmb_DB.Text = "") Then
            err += 1
        End If
        If (My.Computer.FileSystem.FileExists(tb_QBFileLoc.Text) = False) Then
            err += 1
        End If

        If (err = 0) Then
            ' registry entry
            SaveSetting(My.Application.Info.AssemblyName, "Connection", "Server", cmb_Server.Text)
            SaveSetting(My.Application.Info.AssemblyName, "Connection", "Database", cmb_DB.Text)

            ' application settings
            My.Settings.SQLSERVER = cmb_Server.Text
            My.Settings.DATABASENAME = cmb_DB.Text
            My.Settings.QB_FILE_LOCATION = tb_QBFileLoc.Text

            ' set db con string
            My.Settings.Item("QBDBConnectionString") = "Data Source=" & My.Settings.SQLSERVER & ";Initial Catalog=" & My.Settings.DATABASENAME & ";Integrated Security=True;MultipleActiveResultSets=False"

            'con
            Dim con As New SqlConnection
            con.ConnectionString = My.Settings.QBDBConnectionString

            ' command
            Dim cmd As New SqlCommand("APP_SetQBFileLoc", con)
            cmd.CommandType = CommandType.StoredProcedure

            ' param
            Dim param As New SqlParameter
            param.DbType = SqlDbType.VarChar
            param.Direction = ParameterDirection.Input
            param.ParameterName = "@QBFileLoc"
            param.Value = My.Settings.QB_FILE_LOCATION

            cmd.Parameters.Add(param)

            Try
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Application.Exit()
            End Try

            Dim login As New Login(Me)
            login.Show()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        server = Nothing
        servers = Nothing

    End Sub
End Class