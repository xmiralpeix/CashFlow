Imports CashFlow

Public Interface INavigationAction

    ReadOnly Property Enable As Boolean
    Property VisualIdx As Integer
    ReadOnly Property VisualName As String
    Function CanExecuteAction(ByVal oObject As Object) As Boolean
    Function ExecuteAction(ByVal ResultMsg As IResultMsg, ByVal oObject As Object) As Boolean

End Interface

Public Class ProcessSearchBehaviourAppEvent
    Implements INavigationAction

    Public ReadOnly Property Enable As Boolean Implements INavigationAction.Enable
        Get
            Return True
        End Get
    End Property
    Private _visualIdx As Integer = 1
    Public Property VisualIdx As Integer Implements INavigationAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements INavigationAction.VisualName
        Get
            Return Locate("Buscar", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements INavigationAction.CanExecuteAction
        Return TypeOf oObject Is IProcessSearchBehaviour
    End Function

    Public Function ExecuteAction(ResultMsg As IResultMsg, oObject As Object) As Boolean Implements INavigationAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        DirectCast(oObject, IProcessSearchBehaviour).ProcessSearchBehaviour()

        Return True

    End Function

End Class

Public Class MoveToNewAppEvent
    Implements INavigationAction

    Public ReadOnly Property Enable As Boolean Implements INavigationAction.Enable
        Get
            Return True
        End Get
    End Property
    Private _visualIdx As Integer = 2
    Public Property VisualIdx As Integer Implements INavigationAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements INavigationAction.VisualName
        Get
            Return Locate("Nou", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements INavigationAction.CanExecuteAction
        Return TypeOf oObject Is INewID
    End Function

    Public Function ExecuteAction(ResultMsg As IResultMsg, oObject As Object) As Boolean Implements INavigationAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        DirectCast(oObject, INewID).MoveToNew()

        Return True

    End Function

End Class

Public Class MoveToFirst
    Implements INavigationAction

    Public ReadOnly Property Enable As Boolean Implements INavigationAction.Enable
        Get
            Return True
        End Get
    End Property
    Private _visualIdx As Integer = 3
    Public Property VisualIdx As Integer Implements INavigationAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements INavigationAction.VisualName
        Get
            Return Locate("Primer", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements INavigationAction.CanExecuteAction
        Return TypeOf oObject Is IMoveToFirstID
    End Function

    Public Function ExecuteAction(ResultMsg As IResultMsg, oObject As Object) As Boolean Implements INavigationAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        DirectCast(oObject, IMoveToFirstID).MoveToFirst()

        Return True

    End Function

End Class


Public Class MoveToPrevious
    Implements INavigationAction

    Public ReadOnly Property Enable As Boolean Implements INavigationAction.Enable
        Get
            Return True
        End Get
    End Property
    Private _visualIdx As Integer = 4
    Public Property VisualIdx As Integer Implements INavigationAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements INavigationAction.VisualName
        Get
            Return Locate("Anterior", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements INavigationAction.CanExecuteAction
        Return TypeOf oObject Is IMoveToPreviousID
    End Function

    Public Function ExecuteAction(ResultMsg As IResultMsg, oObject As Object) As Boolean Implements INavigationAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        DirectCast(oObject, IMoveToPreviousID).MoveToPrevious()

        Return True

    End Function

End Class

Public Class MoveToNext
    Implements INavigationAction

    Public ReadOnly Property Enable As Boolean Implements INavigationAction.Enable
        Get
            Return True
        End Get
    End Property
    Private _visualIdx As Integer = 5
    Public Property VisualIdx As Integer Implements INavigationAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements INavigationAction.VisualName
        Get
            Return Locate("Següent", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements INavigationAction.CanExecuteAction
        Return TypeOf oObject Is IMoveToNextID
    End Function

    Public Function ExecuteAction(ResultMsg As IResultMsg, oObject As Object) As Boolean Implements INavigationAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        DirectCast(oObject, IMoveToNextID).MoveToNext()

        Return True

    End Function

End Class

Public Class MoveToLast
    Implements INavigationAction

    Public ReadOnly Property Enable As Boolean Implements INavigationAction.Enable
        Get
            Return True
        End Get
    End Property
    Private _visualIdx As Integer = 6
    Public Property VisualIdx As Integer Implements INavigationAction.VisualIdx
        Get
            Return _visualIdx
        End Get
        Set(value As Integer)
            _visualIdx = value
        End Set
    End Property

    Public ReadOnly Property VisualName As String Implements INavigationAction.VisualName
        Get
            Return Locate("Últim", CAT)
        End Get
    End Property

    Public Function CanExecuteAction(oObject As Object) As Boolean Implements INavigationAction.CanExecuteAction
        Return TypeOf oObject Is IMoveToLastID
    End Function

    Public Function ExecuteAction(ResultMsg As IResultMsg, oObject As Object) As Boolean Implements INavigationAction.ExecuteAction

        If Not CanExecuteAction(oObject) Then
            ResultMsg.Push(Locate("El tipus d'objeto no és vàlid", CAT))
            Return False
        End If

        DirectCast(oObject, IMoveToLastID).MoveToLast()

        Return True

    End Function

End Class