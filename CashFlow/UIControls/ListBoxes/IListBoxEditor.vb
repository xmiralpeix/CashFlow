Public Interface IListBoxData

    ReadOnly Property VisualValue As String
    ReadOnly Property VisualText As String
    Property Value As Object
    Sub AssignValue(ByVal InputValue As String)
    Property EntitiesScopeCollection As IEnumerable(Of Object)
    ' Function IsEmpty() As Boolean

End Interface
