Imports QBFC12Lib
Imports System.ServiceProcess

Namespace Classes
    Public Class QBConMgr

        Public Shared SessionManager As QBSessionManager
        Public Shared MessageSetRequest As IMsgSetRequest

        Public Shared Sub InitCon()
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
                MsgBox(ex.Message)
                Application.Exit()
            End Try

            MessageSetRequest = SessionManager.CreateMsgSetRequest("US", 11, 0)
        End Sub

        Private Shared Sub StartQBFCServices()
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

        Public Shared Function GetRespList() As IResponseList
            Dim msgSetResp As IMsgSetResponse = SessionManager.DoRequests(MessageSetRequest)
            Dim respList As IResponseList = msgSetResp.ResponseList

            MessageSetRequest.ClearRequests()

            Return respList
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()

            Try
                SessionManager.CloseConnection
            Catch ex As Exception
                MsgBox(ex.Message)
                Application.Exit()
            End Try
        End Sub
    End Class
End Namespace