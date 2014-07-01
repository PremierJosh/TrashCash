Namespace Classes.CustomerToolstrip
    Friend Class QuickSearch
        Inherits ToolStripTextBox

        Private _lastEventTime As DateTime
    
        Friend Event NameSearch(ByVal str As String)
        Friend Event NumberSearch(ByVal number As Integer)
        Friend Event ClearSearch()
        Friend Event EnterPressed()
        
        Public Sub New()
            _lastEventTime = Now
            BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        End Sub

        Private Sub ts_tb_QuickSearch_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
            If (e.KeyCode = Keys.Enter) Then
                RaiseEvent EnterPressed()
            End If
        End Sub

        Private Sub tb_QuickCustNumSearch_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
            If (Trim(Text) <> "") Then
                If (Now > _lastEventTime.AddMilliseconds(500)) Then
                    Dim int As Integer
                    Dim isInt As Boolean = Integer.TryParse(Text, int)
                    If (isInt) Then
                        RaiseEvent NumberSearch(int)
                    Else
                        RaiseEvent NameSearch(Text)
                    End If
                End If
            Else
                RaiseEvent ClearSearch()
            End If
        End Sub

    End Class
End Namespace