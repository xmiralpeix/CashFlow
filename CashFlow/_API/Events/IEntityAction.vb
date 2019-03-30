Imports CashFlow

Public Interface IEntityAction

    ReadOnly Property Enable As Boolean
    Property VisualIdx As Integer
    ReadOnly Property VisualName As String
    Function CanExecuteAction(ByVal oObject As Object) As Boolean
    Function ExecuteAction(ByVal ResultMsg As IResultMsg, ByVal oObject As Object) As Boolean

End Interface

Public Class DuplicateEntity
    Implements IEntityAction

    Private _visualIdx As Integer = 1

    Public ReadOnly Property Enable As Boolean Implements IEntityAction.Enable
        Get
            Return True
        End Get
    End Property

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
            Return Locate("Duplicar", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements IEntityAction.CanExecuteAction
        Return TypeOf oObject Is IDuplicateContent
    End Function

    Public Function ExecuteAction(ByVal ResultMsg As IResultMsg,
                                  ByVal oObject As Object) As Boolean Implements IEntityAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        Return DirectCast(oObject, IDuplicateContent).Duplicate(ResultMsg)

    End Function

End Class

Public Class CancelEntity
    Implements IEntityAction

    Private _visualIdx As Integer = 2

    Public ReadOnly Property Enable As Boolean Implements IEntityAction.Enable
        Get
            Return True
        End Get
    End Property

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

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements IEntityAction.CanExecuteAction
        Return TypeOf oObject Is ICancelContent
    End Function

    Public Function ExecuteAction(ByVal ResultMsg As IResultMsg, ByVal oObject As Object) As Boolean Implements IEntityAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipo de objeto no es válido", CAT))
            Return False
        End If

        Return DirectCast(oObject, ICancelContent).Cancel(ResultMsg)

    End Function

End Class

Public Class DeleteEntity
    Implements IEntityAction

    Private _visualIdx As Integer = 3

    Public ReadOnly Property Enable As Boolean Implements IEntityAction.Enable
        Get
            Return True
        End Get
    End Property

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
            Return Locate("Eliminar", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements IEntityAction.CanExecuteAction
        Return TypeOf oObject Is IDeleteContent
    End Function

    Public Function ExecuteAction(ByVal ResultMsg As IResultMsg, ByVal oObject As Object) As Boolean Implements IEntityAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipo de objeto no es válido", CAT))
            Return False
        End If

        Return DirectCast(oObject, IDeleteContent).Delete(ResultMsg)

    End Function

End Class