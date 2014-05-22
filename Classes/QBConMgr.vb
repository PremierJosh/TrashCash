Imports QBFC12Lib
Imports System.ServiceProcess

Namespace Classes
    Public Class QBConMgr

        ' qb items
        Public Shared SessionManager As QBSessionManager
        Public Shared MessageSetRequest As IMsgSetRequest

        ' useful vars all forms will use
        Public Shared CurrentUser As ds_Program.USERSRow

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

        Public Shared Function CustomerListID(ByVal customerNumber As Integer)
            Using ta As New ds_CustomerTableAdapters.CustomerTableAdapter
                Dim s As String = ta.GetListID(customerNumber)
                Return s
            End Using
        End Function

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

        ' enumerated item status from database
        Enum ENItemStatus As Int32
            Ready = 5
            Err = 6
            Complete = 7
            Submitted = 8
        End Enum
    End Class
End Namespace