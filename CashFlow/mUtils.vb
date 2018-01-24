﻿Public Module mUtils

    Public Const NOTUSEDCHAR As String = "•"

    'Public Function CreateItemFromRow(Of T As {Class, New})(ByVal row As DataRow) As T

    '    Dim item = New T()

    '    SetItemFromRow(item, row)

    '    Return item

    'End Function

    'Public Sub SetItemFromRow(Of T As {Class, New})(ByVal item As T, ByVal row As DataRow)

    '    For Each c In row.Table.Columns
    '        Dim p = item.GetType().GetProperty(c.ColumnName)
    '        If p IsNot Nothing AndAlso row(c) <> DBNull.Value Then
    '            p.SetValue(item, row(c), Nothing)
    '        End If
    '    Next

    'End Sub

    Public Function Qry(Of T)(ByVal sql As String) As List(Of T)

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.Database.SqlQuery(Of T)(sql).ToList
        End Using

    End Function

    Public Function QryValue(Of T)(ByVal sql As String) As T

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.Database.SqlQuery(Of T)(sql).First()
        End Using

    End Function

    Public Function Locate(ByVal text As String,
                            ByVal fromCulture As System.Globalization.CultureInfo) As String

        ' TODO IMplementar
        Return Locate(text, fromCulture, Application.CurrentCulture)

    End Function

    Public Function Locate(ByVal text As String,
                      ByVal fromCulture As System.Globalization.CultureInfo,
                      ByVal toCulture As System.Globalization.CultureInfo) As String

        ' TODO IMplementar
        Return text

    End Function

    Public CAT As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("ca-ES")

    Public Function PropertyValue(ByVal obj As Object, ByVal propertyName As String) As Object

        Try
            Dim pInfo = obj.GetType().GetProperty(propertyName)
            Return pInfo.GetValue(obj)
        Catch ex As Exception
            Throw New Exception(Locate(String.Format("No s'ha trobat la propietat {0} a objecte {1}.", propertyName, obj.GetType.FullName), CAT))
        End Try

    End Function


    Public Sub LoadChanges(ByRef deletedIDs As IEnumerable(Of Integer),
                                  ByRef modifiedRows As IEnumerable(Of DataRow),
                                  ByRef addedRows As IEnumerable(Of DataRow),
                                  ByVal dt As DataTable)

        Dim dtPart As DataTable

        ' DELETED
        dtPart = dt.GetChanges(DataRowState.Deleted)
        If dtPart IsNot Nothing Then
            deletedIDs = (From row As DataRow In dtPart.Rows
                          Select CInt(row("ID", DataRowVersion.Original))).AsEnumerable()
        End If

        ' MODIFIED
        dtPart = dt.GetChanges(DataRowState.Modified)
        If dtPart IsNot Nothing Then
            modifiedRows = (From row As DataRow In dtPart.Rows
                            Select row).AsEnumerable()
        End If

        ' ADDED
        dtPart = dt.GetChanges(DataRowState.Added)
        If dtPart IsNot Nothing Then
            addedRows = (From row As DataRow In dtPart.Rows
                         Select row).AsEnumerable()
        End If



    End Sub



    Public Sub Test()


    End Sub

    Public Sub TestOpenReport()

        Dim v As New FrmViewerReport()
        v.Show()

    End Sub




End Module