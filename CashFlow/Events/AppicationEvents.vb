#Region "Observer Pattern"

Public Class ApplicationEvents

    Public Shared ChangeToSearch As New SearchAppEvent()
    Public Shared ChangeToNew As New NewAppEvent()
    Public Shared ChangeToFirst As New FirstAppEvent()
    Public Shared ChangeToPrevious As New PreviousAppEvent()
    Public Shared ChangeToNext As New NextAppEvent()
    Public Shared ChangeToLast As New LastAppEvent()
    Public Shared ChangeToPrint As New PrintAppEvent()

    Private Shared WithEvents _menu As INavigateMenu

    Public Shared Sub RegisterEvents(menu As INavigateMenu)

        _menu = menu
        '
        AddHandler _menu.SearchObject, Sub() ChangeToSearch.Notify()
        AddHandler _menu.NewObject, Sub() ChangeToNew.Notify()
        AddHandler _menu.FirstObject, Sub() ChangeToFirst.Notify()
        AddHandler _menu.PreviousObject, Sub() ChangeToPrevious.Notify()
        AddHandler _menu.NextObject, Sub() ChangeToNext.Notify()
        AddHandler _menu.LastObject, Sub() ChangeToLast.Notify()
        AddHandler _menu.Print, Sub() ChangeToPrint.Notify()

    End Sub

    Public Shared Sub RefreshStatus(ByVal listener As IAppEventListener)

        Dim appEventNames As New List(Of String)()
        '
        If ChangeToSearch.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.SearchObject))
        If ChangeToNew.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.NewObject))
        If ChangeToFirst.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.FirstObject))
        If ChangeToPrevious.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.PreviousObject))
        If ChangeToNext.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.NextObject))
        If ChangeToLast.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.LastObject))
        If ChangeToPrint.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.Print))
        '
        _menu.PerformAvailable(appEventNames.ToArray())

    End Sub

End Class

Public MustInherit Class AppEvent

    Property Name As String
    Private _listeners As New List(Of IAppEventListener)
    '
    Public Function Contains(listener As IAppEventListener) As Boolean
        Return _listeners.Contains(listener)
    End Function
    '
    Public Sub New(ByVal name As String)
        _Name = name
    End Sub

    Public Sub Attach(item As IAppEventListener)
        _listeners.Add(item)
    End Sub

    Public Sub Detach(item As IAppEventListener)
        _listeners.Remove(item)
    End Sub

    Public Sub Notify()
        For Each listener In _listeners
            listener.PerformEvent(Me)
        Next
    End Sub

End Class

Public Class SearchAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(SearchAppEvent))
    End Sub

End Class

Public Class NewAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(NewAppEvent))
    End Sub

End Class

Public Class FirstAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(FirstAppEvent))
    End Sub

End Class

Public Class PreviousAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(PreviousAppEvent))
    End Sub

End Class

Public Class NextAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(NextAppEvent))
    End Sub

End Class

Public Class LastAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(LastAppEvent))
    End Sub

End Class

Public Class PrintAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(PrintAppEvent))
    End Sub

End Class



Public Interface IAppEventListener
    Sub PerformEvent(appEvent As AppEvent)
End Interface

#End Region
