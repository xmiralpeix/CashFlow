#Region "Observer Pattern"

Imports CashFlow

Public Interface IAppEventListener
    Sub PerformEvent(appEvent As AppEvent)
End Interface

Public Class ApplicationEvents

    Public Shared NavigationCollection As New List(Of NavigationAppEvent)()
    Public Shared EntityActionCollection As New List(Of EntityActionAppEvent)()

    Public Shared Sub AttachAction(ByVal oListener As IAppEventListener,
                                   ByVal oActionsExecuter As Object)



        Dim actionsFilter = (From x In EntityActionCollection
                             Where x.EntityAction.CanExecuteAction(oActionsExecuter)).ToList()

        actionsFilter.ForEach(Sub(x) x.Attach(oListener))


        Dim navigationFilter = (From x In NavigationCollection
                                Where x.NavigationAction.CanExecuteAction(oActionsExecuter)).ToList()

        navigationFilter.ForEach(Sub(x) x.Attach(oListener))

    End Sub

    Public Shared Sub DettachAction(ByVal oListener As IAppEventListener,
                                   ByVal oActionsExecuter As Object)

        Dim actionsFilter = (From x In EntityActionCollection
                             Where x.EntityAction.CanExecuteAction(oActionsExecuter)).ToList()

        actionsFilter.ForEach(Sub(x) x.Detach(oListener))


        Dim navigationFilter = (From x In NavigationCollection
                                Where x.NavigationAction.CanExecuteAction(oActionsExecuter)).ToList()

        navigationFilter.ForEach(Sub(x) x.Detach(oListener))

    End Sub

    Public Shared Sub RefreshStatus(ByVal listener As IAppEventListener)

        ' actions Menu
        Dim actionsAppEvents = From oAppEvent As EntityActionAppEvent In EntityActionCollection
                               Where oAppEvent.Contains(listener)
                               Group By Shooter = oAppEvent.ActionMenu
                                 Into ActionsByShooter = Group
                               Select New With {
                                     .Shooter = Shooter,
                                     .Actions = (From abs In ActionsByShooter Select abs.EntityAction)}

        ' Clear action events
        For Each oAppEvent As EntityActionAppEvent In EntityActionCollection
            oAppEvent.ActionMenu.DisableAll()
        Next

        For Each oAppEvent In actionsAppEvents
            oAppEvent.Shooter.PerformAvailable(oAppEvent.Actions)
        Next

        ' Nav Menu
        Dim navigationAppEvents = From oAppEvent As NavigationAppEvent In NavigationCollection
                                  Where oAppEvent.Contains(listener)
                                  Group By Shooter = oAppEvent.ActionMenu
                                 Into ActionsByShooter = Group
                                  Select New With {
                                     .Shooter = Shooter,
                                     .Actions = (From abs In ActionsByShooter Select abs.NavigationAction)}

        ' Clear navigation events
        For Each oAppEvent As NavigationAppEvent In NavigationCollection
            oAppEvent.ActionMenu.DisableAll()
        Next
        For Each oAppEvent In navigationAppEvents
            oAppEvent.Shooter.PerformAvailable(oAppEvent.Actions)
        Next

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

Public Class NavigationAppEvent
    Inherits AppEvent

    ReadOnly Property NavigationAction As INavigationAction
    ReadOnly Property ActionMenu As INavigateMenu

    Public Sub New(ByVal oAction As INavigationAction,
                   ByVal oActionMenu As INavigateMenu)
        MyBase.New(oAction.VisualName)
        '
        _NavigationAction = oAction
        _ActionMenu = oActionMenu
    End Sub

End Class

Public Class EntityActionAppEvent
    Inherits AppEvent

    ReadOnly Property EntityAction As IEntityAction
    ReadOnly Property ActionMenu As IActionMenu

    Public Sub New(ByVal oAction As IEntityAction,
                   ByVal oActionMenu As IActionMenu)
        MyBase.New(oAction.VisualName)
        '
        _EntityAction = oAction
        _ActionMenu = oActionMenu
    End Sub

End Class

#End Region
