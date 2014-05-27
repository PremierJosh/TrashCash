Imports QBFC12Lib
Imports System.ServiceProcess

Namespace Classes
    Public Class QBConMgr

        Public SessionManager As QBSessionManager
        Public MessageSetRequest As IMsgSetRequest

       Public Sub InitCon()
            SessionManager = New QBSessionManager()
            Try
                ' attempt to start qbfc services
                StartQBFCServices()
                ' get connection
                With SessionManager
                    .OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
                    .BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)
                End With
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & ex.InnerException.Message)
                Application.Exit()
            End Try

            MessageSetRequest = SessionManager.CreateMsgSetRequest("US", 11, 0)
        End Sub

        Public Sub New()
            _ta = New ds_CustomerTableAdapters.CustomerTableAdapter
         End Sub

        Private Sub StartQBFCServices()
            Dim s As New List(Of String)
            s.Add("QBCFMonitorService")
            s.Add("QBIDPService")
            s.Add("QuickbooksDB23")

            For Each service As String In s
                Dim sc As New ServiceController(service)
                If (sc.Status <> ServiceControllerStatus.Running) Then
                    Try
                        sc.Start()
                    Catch ex As Exception
                        MsgBox("Failed to start Service: " & service & ". EX: " & ex.Message)
                    End Try
                End If
            Next
        End Sub

        Public Function GetRespList() As IResponseList
            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MessageSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MessageSetRequest.ClearRequests()

            Return respList
        End Function

        Public Sub CloseCon()
            Try
                SessionManager.EndSession()
                SessionManager.CloseConnection()
            Catch ex As Exception
                MsgBox("Close connection error: " & ex.Message)
            End Try
        End Sub

        Private ReadOnly _ta As ds_CustomerTableAdapters.CustomerTableAdapter
        Public Function CustomerListID(ByVal customerNumber As Integer) As String
            Return _ta.GetListID(customerNumber)
        End Function

       ' going to put customer balance sub here for quick access
        Public Function GetCustomerBalance(ByVal customerListID As String) As Double
            ' return var
            Dim b As Double

            ' only need balance returned
            Dim s As New List(Of String)
            s.Add("TotalBalance")
            Dim resp As IResponse = QBRequests.CustomerQuery(listID:=customerListID, retEleList:=s, qbConMgr:=Me)
            If (resp.StatusCode = 0) Then
                Dim retList As ICustomerRetList = resp.Detail
                Dim ret As ICustomerRet = retList.GetAt(0)
                b = ret.TotalBalance.GetValue
            Else
                ResponseErr_Misc(resp)
            End If

            Return b
        End Function
        ' copy kept here
        Public Shared Sub ResponseErr_Misc(ByVal resp As IResponse)
            If (resp.StatusCode = 1) Then
                MsgBox("No matching results from Quickbooks")
            Else
                Try
                    Using ta As New ds_ProgramTableAdapters.QueriesTableAdapter
                        ta.ERR_MISC_Insert(resp.Type.GetValue.ToString,
                                           resp.StatusCode.ToString,
                                           resp.StatusMessage,
                                           Date.Now)
                    End Using

                    MsgBox("Error Encounterd with Quickbooks. Contact Premier.", MsgBoxStyle.Critical)
                Catch ex As Exception
                    MsgBox("ERR_MISC_Insert: " & ex.Message)
                End Try
            End If
        End Sub
        

        '    Private Sub KillQBProcess()
        '        ' QBW32.exe killing
        '        For Each p As Process In Process.GetProcessesByName("QBW32.exe")
        '            p.CloseMainWindow()
        '            p.WaitForExit(20000)
        '            If (p.HasExited = False) Then
        '                p.Kill()
        '            End If
        '        Next
        '
        '        ' QBW32Pro.exe killing
        '        For Each p As Process In Process.GetProcessesByName("QBW32Pro.exe")
        '            p.CloseMainWindow()
        '            p.WaitForExit(20000)
        '            If (p.HasExited = False) Then
        '                p.Kill()
        '            End If
        '        Next
        '
        '        Try
        '            app_SessMgr.CloseConnection()
        '            app_SessMgr.OpenConnection2("V1", "TrashCash", ENConnectionType.ctLocalQBD)
        '            app_SessMgr.BeginSession(My.Settings.QB_FILE_LOCATION.ToString, ENOpenMode.omSingleUser)
        '
        '            ' new msg set
        '            app_MsgSetReq = app_SessMgr.CreateMsgSetRequest("US", 11, 0)
        '        Catch ex As Exception
        '            MsgBox("Retry failed and Kill Process failed. Please try restarting TrashCash.")
        '            Application.Exit()
        '        End Try
        '
        '    End Sub
    End Class
End Namespace