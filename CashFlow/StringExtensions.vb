
Imports System.Runtime.CompilerServices

    Module StringExtensions

    <Extension()>
    Public Function IsNumeric(ByVal value As String) As Boolean
        Return Not value.Any(Function(x) x < "0" AndAlso x > "9")
    End Function


End Module

