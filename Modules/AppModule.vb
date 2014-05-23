Imports TrashCash.Classes

Namespace Modules

    Module AppModule
        Public GlobalConMgr As QBConMgr
        ' useful vars all forms will use
        Public CurrentUser As ds_Program.USERSRow

        ''' <summary>
        ''' Takes a QBConMgr param passed and returns it if not nothing, else return GlobalQBConMgr
        ''' </summary>
        ''' <param name="paramConMgr"></param>
        ''' <returns>Valid QBConMgr</returns>
        ''' <remarks>
        ''' i felt like this was a necessary simple function that will easily allow me to
        ''' cut out this code every time and i can even append a . to access to result without
        ''' having to carry it
        ''' </remarks>
        Public Function ConCheck(ByRef paramConMgr As QBConMgr) As QBConMgr
            If (paramConMgr Is Nothing) Then
                Return GlobalConMgr
            End If
            Return paramConMgr
        End Function
      
    End Module


End Namespace