Imports QBFC12Lib

Namespace Invoicing
    Module QBMethods
        ' sess msg obj for qb method usage
        Public QBCon As Classes.QBConMgr

        ' internal var for msgSet Req
        Friend MsgSetReq As IMsgSetRequest = QBCon.MessageSetRequest

        ' enum status for db items
        Enum ItemStatus As Int32
            Ready = 5
            Err = 6
            Complete = 7
        End Enum



    End Module

End Namespace