Imports CashFlow

Public Interface IEditContent

    Function AppEvents() As IEnumerable(Of String)
    Function GetUI() As IContainerControl
    ReadOnly Property Text As String
    ReadOnly Property Table As String
    ReadOnly Property FindBehaviour() As IFindBehaviour
    ReadOnly Property PrintBehaviour() As IPrintBehaviour
    '
    Sub LoadFormByID(ByVal ID? As Integer)
    Function IsValidContent(ByRef msgError As String,
                            ByRef invalidControl As Control) As Boolean
    Sub SaveEntry()

End Interface

Public Interface IFindBehaviour
    Function Find() As IEnumerable(Of Integer)
End Interface

Public Class NoFinder
    Implements IFindBehaviour

    Public Function Find() As IEnumerable(Of Integer) Implements IFindBehaviour.Find
        Return Nothing
    End Function

End Class


Public Class EntityIDsFinder
    Implements IFindBehaviour


    Private _findContent As IFindContent
    Public Sub New(ByVal findContent As IFindContent)
        _findContent = findContent
    End Sub


    Private Function Find() As IEnumerable(Of Integer) Implements IFindBehaviour.Find
        Using frm As New FrmFindEntityIDs()
            frm.FindContent = _findContent
            If frm.ShowDialog() <> DialogResult.OK Then
                Return Nothing
            End If
            Return frm.SelectedIDs
        End Using
    End Function

End Class