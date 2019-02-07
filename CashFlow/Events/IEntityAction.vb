Imports CashFlow

Public Interface IEntityAction

    Property VisualIdx As Integer ' When conflict is changed
    ReadOnly Property VisualName As String
    Function CanExecuteAction(ByVal o As Object) As Boolean
    Function ExecuteAction(ByRef ResultMsg As String, ByVal o As Object) As Boolean

End Interface

Public Class CancelEntity
    Implements IEntityAction

    Private _visualIdx As Integer = 1
    Public Property VisualIdx As Integer Implements IEntityAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements IEntityAction.VisualName
        Get
            Return Locate("Cancel·lar", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(o As Object) As Boolean Implements IEntityAction.CanExecuteAction
        Return TypeOf o Is ICancelContent
    End Function

    Public Function ExecuteAction(ByRef ResultMsg As String, o As Object) As Boolean Implements IEntityAction.ExecuteAction

        If Not CanExecuteAction(o) Then
            ResultMsg = String.Concat(Locate("El tipo de objeto no es válido", CAT), ResultMsg)
            Return False
        End If

        Return DirectCast(o, ICancelContent).Cancel(ResultMsg)

    End Function

End Class