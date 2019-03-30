Public Module mSubscribers

    Private _assemblies As System.Reflection.Assembly()

    Private Function GetAssemblies() As System.Reflection.Assembly()
        If IsEmpty(_assemblies) Then
            _assemblies = AppDomain.CurrentDomain.GetAssemblies()
        End If
        Return _assemblies
    End Function

    Private _bindType As New Dictionary(Of String, Type)
    Public Sub BindClass(Of T)(ByVal ClassType As Type)
        Dim instanceName As String = GetType(T).FullName
        If Not _bindType.ContainsKey(instanceName) Then
            _bindType.Add(instanceName, ClassType)
        Else
            _bindType(instanceName) = ClassType
        End If
    End Sub

    Public Function GetSubscribers(Of T)() As Type()

        Dim IType = GetType(T)
        Dim subscribers = GetAssemblies() _
                     .SelectMany(Function(x) x.GetTypes()) _
                     .Where(Function(x) iType.IsAssignableFrom(x)).ToArray()

        Return subscribers.Where(Function(x) Not x.IsAbstract).ToArray()

    End Function

    Public Function GetFirstSubscriber(Of T)() As Type

        Dim IType = GetType(T)
        If _bindType.ContainsKey(IType.FullName) Then
            Return _bindType(IType.FullName)
        End If

        Dim subscribers = GetAssemblies() _
                      .SelectMany(Function(x) x.GetTypes()) _
                      .Where(Function(x) IType.IsAssignableFrom(x)).ToArray()

        Dim oRetType As Type = subscribers.FirstOrDefault(Function(x) Not x.IsAbstract)
        BindClass(Of T)(oRetType)

        Return GetFirstSubscriber(Of T)()

    End Function

    Public Function CreateInstance(Of T)() As Object
        Return CreateInstance(GetFirstSubscriber(Of T))
    End Function

    Public Function CreateInstance(ByVal ClassType As Type) As Object
        Return Activator.CreateInstance(ClassType)
    End Function

End Module
