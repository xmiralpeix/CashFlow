Imports CashFlow

Public Interface IShowMsgBehaviour
    Sub Show(ByVal msg As String)
End Interface

Public Class ShowByConsole
    Implements IShowMsgBehaviour

    Public Sub Show(msg As String) Implements IShowMsgBehaviour.Show
        Console.WriteLine(msg)
    End Sub

End Class

Public Class ShowByFormDialog
    Implements IShowMsgBehaviour

    Public Sub Show(msg As String) Implements IShowMsgBehaviour.Show
        MsgBox(msg)
    End Sub

End Class

Public Interface IResultMsg
    Sub Push(value As String)
    Function FullMsg() As String
    Sub ShowMessage()
End Interface

Public Class StackMsg
    Implements IResultMsg, IDisposable

    Private _collection As Stack(Of String)
    Private _showBehaviour As IShowMsgBehaviour
    Public Sub New()
        _collection = New Stack(Of String)
        _showBehaviour = New ShowByFormDialog()
    End Sub

    Public Sub Push(value As String) Implements IResultMsg.Push
        _collection.Push(value)
    End Sub

    Public Function FullMsg() As String Implements IResultMsg.FullMsg
        Return String.Join(vbCrLf, _collection.ToArray())
    End Function

    Public Sub ShowMessage() Implements IResultMsg.ShowMessage
        _showBehaviour.Show(FullMsg)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If
            If _collection IsNot Nothing Then
                _collection.Clear()
                _collection = Nothing
            End If

            If _showBehaviour IsNot Nothing Then
                _showBehaviour = Nothing
            End If
            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub


#End Region
End Class
