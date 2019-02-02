Imports CashFlow

Public Class ActionsMenuStrip
    Inherits ToolStripMenuItem
    Implements IActionsMenu

    Public Event DeleteObject() Implements IActionsMenu.DeleteObject
    Public Event DuplicateObject() Implements IActionsMenu.DuplicateObject
    Public Event CancelObject() Implements IActionsMenu.CancelObject

    Public WithEvents menuDelete As New ToolStripButton()
    Public WithEvents menuDuplicate As New ToolStripButton()
    Public WithEvents menuCancel As New ToolStripButton()

    Public Sub New()
        ConfigureControls()
    End Sub

    Private Sub ConfigureControls()

        '
        'DuplicarToolStripMenuItem
        '
        Me.menuDuplicate.Name = "DuplicarToolStripMenuItem"
        Me.menuDuplicate.Size = New System.Drawing.Size(152, 22)
        Me.menuDuplicate.Text = Locate("Duplicar", CAT)
        '
        AddHandler Me.menuDuplicate.Click, Sub() RaiseEvent DuplicateObject()

        '
        'EliminarToolStripMenuItem
        '
        Me.menuDelete.Name = "EliminarToolStripMenuItem"
        Me.menuDelete.Size = New System.Drawing.Size(152, 22)
        Me.menuDelete.Text = Locate("Eliminar", CAT)
        '
        AddHandler Me.menuDelete.Click, Sub() RaiseEvent DeleteObject()

        '
        'CancelarToolStripMenuItem
        '
        Me.menuCancel.Name = "EliminarToolStripMenuItem"
        Me.menuCancel.Size = New System.Drawing.Size(152, 22)
        Me.menuCancel.Text = Locate("Cancel·lar", CAT)
        '
        AddHandler Me.menuCancel.Click, Sub() RaiseEvent CancelObject()

        Me.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDuplicate, Me.menuDelete, menuCancel})
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
                Case NameOf(IActionsMenu.CancelObject) : menuCancel.Enabled = True
            End Select
        Next

    End Sub

    Private _toolStripButtonItems = From item In Me.DropDownItems
                                    Where item.GetType Is GetType(ToolStripButton)

    Public Sub DisableAll() Implements IActionsMenu.DisableAll

        For Each item As ToolStripButton In _toolStripButtonItems
            item.Enabled = False
        Next

    End Sub

End Class
