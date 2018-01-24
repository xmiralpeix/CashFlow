Imports CashFlow

Public Class ActionsMenuStrip
    Inherits ToolStripMenuItem
    Implements IActionsMenu

    Public Event DeleteObject() Implements IActionsMenu.DeleteObject
    Public Event DuplicateObject() Implements IActionsMenu.DuplicateObject

    Private WithEvents DuplicarToolStripMenuItem As New System.Windows.Forms.ToolStripMenuItem()
    Private WithEvents EliminarToolStripMenuItem As New System.Windows.Forms.ToolStripMenuItem()

    Public WithEvents menuDelete As New ToolStripButton()
    Public WithEvents menuDuplicate As New ToolStripButton()

    Public Sub New()
        ConfigureControls()
    End Sub

    Private Sub ConfigureControls()

        '
        'DuplicarToolStripMenuItem
        '
        Me.DuplicarToolStripMenuItem.Name = "DuplicarToolStripMenuItem"
        Me.DuplicarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DuplicarToolStripMenuItem.Text = "Duplicar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"

        Me.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuplicarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.Text = Locate("Dades", CAT)

        DisableAll()

    End Sub



    Public Sub PerformAvailable(ParamArray appEventNames() As String) Implements IActionsMenu.PerformAvailable

        DisableAll()
        '
        For Each appEventName In appEventNames
            Select Case appEventName
                Case NameOf(IActionsMenu.DeleteObject) : menuDelete.Enabled = True
                Case NameOf(IActionsMenu.DuplicateObject) : menuDuplicate.Enabled = True
            End Select
        Next

    End Sub

    Private _toolStripButtonItems = From item In Me.DropDownItems
                                    Where item.GetType Is GetType(ToolStripMenuItem)

    Public Sub DisableAll() Implements IActionsMenu.DisableAll

        For Each item As ToolStripMenuItem In _toolStripButtonItems
            item.Enabled = False
        Next

    End Sub

End Class
