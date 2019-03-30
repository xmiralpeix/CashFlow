Imports CashFlow

'Public Class NavigationMenuStrip
'    Inherits ToolStripMenuItem
'    Implements IActionShooter

'    Public Sub New()
'        MyBase.New()
'        ConfigureControls()
'    End Sub

'    Private Sub ConfigureControls()

'        Dim entityActionsCollection As New List(Of IEntityAction)()
'        For Each entityAction As Type In GetSubscribers(Of IEntityAction)()
'            Dim oEntityAction = CreateInstance(entityAction)
'            entityActionsCollection.Add(oEntityAction)
'            '
'            ApplicationEvents.EntityActionCollection.Add(New EntityActionAppEvent(oEntityAction, Me))
'        Next


'        Dim qry = From item In entityActionsCollection
'                  Where item.Enable
'                  Order By item.VisualIdx Ascending
'                  Select New ToolStripButton(
'                      item.VisualName,
'                      Nothing,
'                      Sub() ApplicationEvents.EntityActionCollection.First(Function(x) x.EntityAction.VisualName = item.VisualName).Notify(),
'                      item.VisualName)

'        Me.DropDownItems.AddRange(qry.ToArray())
'        'Me.Text = Locate("Dades", CAT)

'        DisableAll()

'    End Sub


'    Public Sub PerformAvailable(ByVal actions As IEnumerable(Of IEntityAction)) Implements IActionShooter.PerformAvailable

'        For Each item As ToolStripButton In ToolStripButtonItems
'            item.Enabled = actions.Any(Function(x) x.VisualName = item.Text)
'        Next

'    End Sub

'    ReadOnly Property ToolStripButtonItems() As List(Of ToolStripButton)
'        Get
'            Return (From item In Me.DropDownItems
'                    Where item.GetType Is GetType(ToolStripButton)
'                    Select DirectCast(item, ToolStripButton)).ToList()
'        End Get
'    End Property

'    Public Sub DisableAll() Implements IActionShooter.DisableAll

'        For Each item As ToolStripButton In ToolStripButtonItems
'            item.Enabled = False
'        Next

'    End Sub

'End Class


Public Class ActionsMenuStrip
    Inherits ToolStripMenuItem
    Implements IActionMenu

    Public Sub New()
        MyBase.New()
        ConfigureControls()
    End Sub

    Private Sub ConfigureControls()

        ' Entity Action
        Dim entityActionsCollection As New List(Of IEntityAction)()
        For Each entityAction As Type In GetSubscribers(Of IEntityAction)()
            Dim oEntityAction = CreateInstance(entityAction)
            entityActionsCollection.Add(oEntityAction)
            '
            ApplicationEvents.EntityActionCollection.Add(New EntityActionAppEvent(oEntityAction, Me))
        Next

        Dim qry = From item In entityActionsCollection
                  Where item.Enable
                  Order By item.VisualIdx Ascending
                  Select New ToolStripButton(
                      item.VisualName,
                      Nothing,
                      Sub() ApplicationEvents.EntityActionCollection.First(Function(x) x.EntityAction.VisualName = item.VisualName).Notify(),
                      item.VisualName)

        Me.DropDownItems.AddRange(qry.ToArray())
        'Me.Text = Locate("Dades", CAT)

        DisableAll()

    End Sub


    Public Sub PerformAvailable(ByVal actions As IEnumerable(Of IEntityAction)) Implements IActionMenu.PerformAvailable

        For Each item As ToolStripButton In ToolStripButtonItems
            item.Enabled = actions.Any(Function(x) x.VisualName = item.Text)
        Next

    End Sub

    ReadOnly Property ToolStripButtonItems() As List(Of ToolStripButton)
        Get
            Return (From item In Me.DropDownItems
                    Where item.GetType Is GetType(ToolStripButton)
                    Select DirectCast(item, ToolStripButton)).ToList()
        End Get
    End Property

    Public Sub DisableAll() Implements IActionMenu.DisableAll

        For Each item As ToolStripButton In ToolStripButtonItems
            item.Enabled = False
        Next

    End Sub

End Class
