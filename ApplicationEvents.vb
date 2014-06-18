

' ReSharper disable once CheckNamespace
Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication


        Private Sub MyApplication_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown
            If (GlobalConMgr IsNot Nothing) Then
                Dim closed As Boolean = GlobalConMgr.CloseCon()
                Dim forceClose As Date = DateAdd(DateInterval.Second, 5, Date.Now)
                While Not closed
                    closed = GlobalConMgr.CloseCon()
                    If (Date.Now > forceClose) Then
                        MessageBox.Show("force close fail")
                        Exit While
                    End If
                End While
            End If
        End Sub
    End Class


End Namespace

