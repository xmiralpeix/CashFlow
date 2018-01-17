Public Class RptGroupsRow
    Implements IRptGroupsRow

    Public Property GroupAccessKey As String Implements IRptGroupsRow.GroupAccessKey
    Public Property GroupName As String Implements IRptGroupsRow.GroupName
    Public Property SubGroupAccessKey As String Implements IRptGroupsRow.SubGroupAccessKey
    Public Property SubGroupName As String Implements IRptGroupsRow.SubGroupName

    Public Shared Function LoadData() As List(Of RptGroupsRow)

        Dim sql As String
        sql = $"SELECT T0.""AccessKey"" AS {NameOf(GroupAccessKey)}
                , T0.""Name"" AS {NameOf(GroupName)}
                , T1.""AccessKey"" AS {NameOf(SubGroupAccessKey)}
                , T1.""Name"" AS {NameOf(SubGroupName)}
                FROM ""Groups"" T0 
                INNER JOIN ""SubGroups"" T1 
                ON T1.""Group_ID"" = T0.""ID""   
                WHERE COALESCE(T0.""CancelDate"", T1.""CancelDate"") IS NULL                               
              "

        Return Qry(Of RptGroupsRow)(sql)

    End Function

End Class