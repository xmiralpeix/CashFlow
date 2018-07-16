Public Interface IFindContent
    Function GetContent(ByVal textSearch As String) As Object
    Function GetColumns() As IEnumerable(Of DataGridViewColumn)
    Function GetQuantity() As Integer
    Property EntitiesScopeCollection As IEnumerable(Of Object)
End Interface