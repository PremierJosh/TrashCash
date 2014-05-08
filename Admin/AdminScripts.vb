Imports QBFC12Lib
Imports TrashCash.AdminScripts
Imports TrashCash.TrashCash_Utils.Err_Handling




Public Class AdminScripts
    ' all requests run through sessMgr on the master form - used for simpler refrence here



    'Public Function QB_GetAccountList(Optional ByRef Income As Boolean = False, _
    '                                         Optional ByRef Bank As Boolean = False)
    '    ' return array for data binding
    '    Dim accountList As New List(Of QBAccountItem)

    '    Dim msgSetReq As IMsgSetRequest = sessMgr.CreateMsgSetRequest("US", 11, 0)
    '    Dim accountQuery As IAccountQuery = msgSetReq.AppendAccountQueryRq

    '    ' getting only requested accounts
    '    If (Income = True) Then
    '        accountQuery.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(ENAccountType.atIncome)
    '    End If
    '    If (Bank = True) Then
    '        accountQuery.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(ENAccountType.atBank)
    '    End If

    '    Dim msgSetResp As IMsgSetResponse = sessMgr.DoRequests(msgSetReq)
    '    Dim respList As IResponseList = msgSetResp.ResponseList

    '    For i = 0 To respList.Count - 1
    '        Dim response As IResponse = respList.GetAt(i)

    '        ' making sure we have responses
    '        If (response.StatusCode = 0) Then
    '            If (response.Detail IsNot Nothing) Then

    '                Dim accountRetList As IAccountRetList = response.Detail

    '                For l = 0 To accountRetList.Count - 1
    '                    Dim accountRet As IAccountRet = accountRetList.GetAt(l)

    '                    'creating list item
    '                    Dim item As New QBAccountItem
    '                    item.displayName = accountRet.Name.GetValue.ToString
    '                    item.listID = accountRet.ListID.GetValue.ToString

    '                    'adding to list
    '                    accountList.Add(item)
    '                Next l
    '            End If
    '        Else
    '            ResponseErr_Misc(response)
    '        End If
    '    Next i

    '    Return accountList
    'End Function

    
End Class



