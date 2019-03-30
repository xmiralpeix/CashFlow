Imports CashFlow

Public Class NavigateToolStrip
    Inherits ToolStrip
    Implements INavigateMenu

    Public Sub New()
        MyBase.New()
        '
        ConfigureControls()
    End Sub


    Public Sub ConfigureControls()

        ' Actions
        Dim actionsCollection As New List(Of INavigationAction)()
        For Each oAction As Type In GetSubscribers(Of INavigationAction)()
            Dim oNavigationAction = CreateInstance(oAction)
            actionsCollection.Add(oNavigationAction)
            '
            ApplicationEvents.NavigationCollection.Add(New NavigationAppEvent(oNavigationAction, Me))
        Next

        Dim qry = From item In actionsCollection
                  Where item.Enable
                  Order By item.VisualIdx Ascending
                  Select New ToolStripButton(
                      item.VisualName,
                      Nothing,
                      Sub() ApplicationEvents.NavigationCollection.First(Function(x) x.NavigationAction.VisualName = item.VisualName).Notify(),
                      item.VisualName)

        Me.Items.AddRange(qry.ToArray())

        DisableAll()

    End Sub

    Public Sub PerformAvailable(ByVal actions As IEnumerable(Of INavigationAction)) Implements INavigateMenu.PerformAvailable

        For Each item As ToolStripButton In _toolStripButtonItems
            item.Enabled = actions.Any(Function(x) x.VisualName = item.Text)
        Next

    End Sub

    Private _toolStripButtonItems = From item In Me.Items
                                    Where item.GetType Is GetType(ToolStripButton)

    Public Sub DisableAll() Implements INavigateMenu.DisableAll

        For Each item As ToolStripButton In _toolStripButtonItems
            item.Enabled = False
        Next

    End Sub


End Class
