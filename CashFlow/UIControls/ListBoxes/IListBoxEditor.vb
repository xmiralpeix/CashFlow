Public Interface IListBoxData

    ReadOnly Property VisualValue As String
    ReadOnly Property VisualText As String
    Property Value As Object
    Sub AssignValue(ByVal InputValue As String)
    ' Function IsEmpty() As Boolean

End Interface
