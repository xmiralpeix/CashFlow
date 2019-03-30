Public Module mUtils




    Public Const NOTUSEDCHAR As String = "•"

    Public Function IsEmpty(ByVal value As Object) As Boolean

        If value Is Nothing Then
            Return True
        End If

        If value Is DBNull.Value Then
            Return True
        End If

        Select Case True
            Case TypeOf value Is IEnumerable
                Dim x = DirectCast(value, IEnumerable)
                Return Not x.GetEnumerator().MoveNext()

            Case TypeOf value Is TextEditor
                Dim castValue As TextEditor = DirectCast(value, TextEditor)
                Return Not castValue.HasValue()

            Case TypeOf value Is ListBox
                Dim castValue As ListBox = DirectCast(value, ListBox)
                Return Not castValue.HasValue()

            Case TypeOf value Is TextBox
                Dim castValue As TextBox = DirectCast(value, TextBox)
                Return IsEmpty(castValue.Text)

            Case TypeOf value Is String
                Dim castValue As String = DirectCast(value, String)
                Return castValue.Trim().Length = 0

            Case TypeOf value Is DataTable
                Dim castValue As DataTable = DirectCast(value, DataTable)
                Return castValue.Rows.Count = 0

            Case TypeOf value Is DateTime
                Dim castValue As DateTime = DirectCast(value, DateTime)
                Return castValue = DateTime.MinValue

            Case TypeOf value Is Integer
                Dim castValue As Integer = DirectCast(value, Integer)
                Return castValue = 0

        End Select

        Return False

    End Function


    Public Sub ChangeReadOnly(ByVal ReadOnlyYN As Boolean,
                              ByVal Collection As System.Windows.Forms.Control.ControlCollection)

        If IsEmpty(Collection) Then
            Return
        End If

        For Each controlIdx As Windows.Forms.Control In Collection
            If TypeOf controlIdx Is TextBox Then
                Dim oTextBox As TextBox = controlIdx
                oTextBox.ReadOnly = ReadOnlyYN
                '
                Continue For
            End If

            If TypeOf controlIdx Is System.Windows.Forms.DataGridView Then
                Dim oDataGrid As System.Windows.Forms.DataGridView = controlIdx
                oDataGrid.ReadOnly = ReadOnlyYN
                '
                Continue For
            End If

            ChangeReadOnly(ReadOnlyYN, controlIdx.Controls)

        Next

    End Sub




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

    Public Function PropertyValue(ByVal Obj As Object,
                                  ByVal PropertyPath As String) As Object

        If Not (PropertyPath.Contains(".")) Then
            Return pPropertyValue(Obj, PropertyPath)
        Else
            Return pPropertyValue(Obj, 0, PropertyPath.Split("."))
        End If

    End Function

    Private Function pPropertyValue(ByVal obj As Object,
                                  ByVal propertyIdx As Integer,
                                  ByVal propertyNames() As String) As Object

        Dim data As Object
        Try
            data = mUtils.PropertyValue(obj, propertyNames(propertyIdx))
        Catch ex As Exception
            data = Nothing
        End Try

        If IsEmpty(data) Then
            Return data
        End If

        If propertyIdx >= propertyNames.Length - 1 Then
            Return data
        End If

        propertyIdx += 1
        Return pPropertyValue(data, propertyIdx, propertyNames)

    End Function


    Private Function pPropertyValue(ByVal Obj As Object,
                                    ByVal Propertyname As String) As Object

        Try


            Dim pInfo = Obj.GetType().GetProperty(Propertyname)
            Return pInfo.GetValue(Obj)
        Catch ex As Exception
            Throw New Exception(Locate(String.Format("No s'ha trobat la propietat {0} a objecte {1}.", Propertyname, Obj.GetType.FullName), CAT))
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

    'Public Sub TestOpenReport()

    '    Dim v As New FrmViewerReport()
    '    v.Show()

    'End Sub




End Module




