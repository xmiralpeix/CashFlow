#Region "Observer Pattern"

Public Class ApplicationEvents

    Public Shared ChangeToSearch As New SearchAppEvent()
    Public Shared ChangeToNew As New NewAppEvent()
    Public Shared ChangeToFirst As New FirstAppEvent()
    Public Shared ChangeToPrevious As New PreviousAppEvent()
    Public Shared ChangeToNext As New NextAppEvent()
    Public Shared ChangeToLast As New LastAppEvent()
    Public Shared ChangeToPrint As New PrintAppEvent()
    Public Shared ChangeToImportExport As New ImportExportAppEvent()
    Public Shared ChangeToDelete As New DeleteAppEvent()
    Public Shared ChangeToDuplicate As New DuplicateAppEvent()

    Private Shared WithEvents _menu As INavigateMenu
    Private Shared WithEvents _actionsMenu As IActionsMenu

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
        AddHandler _menu.ImportExport, Sub() ChangeToImportExport.Notify()

    End Sub

    Public Shared Sub RegisterEvents(actionsMenu As IActionsMenu)

        _actionsMenu = actionsMenu
        '
        AddHandler _actionsMenu.DeleteObject, Sub() ChangeToDelete.Notify()
        AddHandler _actionsMenu.DuplicateObject, Sub() ChangeToDuplicate.Notify()

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
        If ChangeToPrint.Contains(listener) Then appEventNames.Add(NameOf(INavigateMenu.ImportExport))
        If ChangeToDelete.Contains(listener) Then appEventNames.Add(NameOf(IActionsMenu.DeleteObject))
        If ChangeToDuplicate.Contains(listener) Then appEventNames.Add(NameOf(IActionsMenu.DuplicateObject))
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

Public Class MoveToIDAppEvent
    Inherits AppEvent

    Property ID As Integer?

    Public Sub New()
        MyBase.New(NameOf(MoveToIDAppEvent))
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


Public Class ImportExportAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(ImportExportAppEvent))
    End Sub
End Class


Public Class DeleteAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(DeleteAppEvent))
    End Sub
End Class

Public Class DuplicateAppEvent
    Inherits AppEvent

    Public Sub New()
        MyBase.New(NameOf(DuplicateAppEvent))
    End Sub
End Class


Public Interface IAppEventListener
    Sub PerformEvent(appEvent As AppEvent)
End Interface

#End Region
