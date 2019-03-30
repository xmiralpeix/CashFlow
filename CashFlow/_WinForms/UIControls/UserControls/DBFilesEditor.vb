Public Class DBFilesEditor

    Private _ObjectTable As String
    Public Property ObjectTable As String
        Get
            Return _ObjectTable
        End Get
        Set(value As String)
            _ObjectTable = value
            ConfigureControls()
        End Set
    End Property

    Private _ObjectID As Integer
    Public Property ObjectID As Integer
        Get
            Return _ObjectID
        End Get
        Set(value As Integer)
            _ObjectID = value
            ConfigureControls()
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Private Sub ConfigureControls()
        Me.btnAddFiles.Enabled = (Not IsEmpty(Me.ObjectTable) AndAlso Not IsEmpty(Me.ObjectID))
        If Me.btnAddFiles.Enabled Then
            '
            LoadData()
            '
            If IsEmpty(gridDocuments.DataSource) Then
                Return
            End If

            Me.gridDocuments.AutoGenerateColumns = False
            Me.gridDocuments.Columns.Clear()
            Me.gridDocuments.Columns.AddRange(GetColumns().ToArray())

        End If



    End Sub

    Private Function GetColumns() As List(Of DataGridViewColumn)

        Dim col As New List(Of DataGridViewColumn)()
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = "ID"
            .DataPropertyName = NameOf(ObjectFile.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Nom", CAT)
            .DataPropertyName = String.Join(".", {NameOf(ObjectFile.DBFileInfo), NameOf(DBFileInfo.Name)})
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Tipus", CAT)
            .DataPropertyName = String.Join(".", {NameOf(ObjectFile.DBFileInfo), NameOf(DBFileInfo.Extension)})
        End With
        '
        'col.Add(New DataGridViewTextBoxColumn())
        'With col(col.Count - 1)
        '    .HeaderText = Locate("Contingut", CAT)
        '    .DataPropertyName = String.Join(".", {NameOf(ObjectFile.DBFileInfo), NameOf(DBFileInfo.Comments)})
        'End With

        Return col

    End Function


    Private Sub btnAddFiles_Click(sender As Object, e As EventArgs) Handles btnAddFiles.Click

        Try

            Dim fileNames() As String
            Using dFile As New OpenFileDialog()
                dFile.Multiselect = True
                Dim dResult = dFile.ShowDialog()
                If dResult <> DialogResult.OK Then
                    Return
                End If
                fileNames = dFile.FileNames
            End Using

            Dim ids As New List(Of Integer)()

            Using ctx As New CashFlowContext

                For Each fileName In fileNames

                    Dim oFileContent As New DBFileContent()
                    oFileContent.Content = System.IO.File.ReadAllBytes(fileName)
                    '
                    Dim oNewFileInfo As New DBFileInfo()
                    oNewFileInfo.Content = oFileContent
                    oNewFileInfo.Extension = IO.Path.GetExtension(fileName)
                    oNewFileInfo.Name = IO.Path.GetFileNameWithoutExtension(fileName)
                    '
                    Dim oFiles As New ObjectFile()
                    oFiles.DBFileInfo = oNewFileInfo
                    oFiles.TableName = ObjectTable
                    oFiles.PrimaryKey = ObjectID
                    '
                    ctx.ObjectFiles.Add(oFiles)
                    ctx.SaveChanges()
                    '
                    ids.Add(oFiles.ID)
                Next

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            LoadData()
        End Try

    End Sub

    Public Sub LoadData()

        Using ctx As New CashFlowContext()

            Dim objectFiles = From file In ctx.ObjectFiles.Include(NameOf(ObjectFile.DBFileInfo))
                              Where file.TableName = Me.ObjectTable _
                              AndAlso file.PrimaryKey = Me.ObjectID
                              Order By file.DBFileInfo.Name

            Me.gridDocuments.DataSource = objectFiles.ToList()


        End Using

    End Sub

    Private Sub gridDocuments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDocuments.CellFormatting

        Try
            Dim column As DataGridViewColumn = gridDocuments.Columns(e.ColumnIndex)
            If Not column.DataPropertyName.Contains(".") Then
                Return
            End If
            Dim obj As Object = gridDocuments.Rows(e.RowIndex).DataBoundItem
            Dim data As Object = mUtils.PropertyValue(obj, column.DataPropertyName)
            gridDocuments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = data
        Catch ex As Exception
        End Try

    End Sub

    Private Sub gridDocuments_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridDocuments.CellMouseDoubleClick


        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

                Dim tempFile As String
                Dim selectedRow As DataGridViewRow = gridDocuments.Rows(e.RowIndex)
                Dim FileInfoID As Integer = DirectCast(selectedRow.DataBoundItem, ObjectFile).DBFileInfo.ID
                Using ctx As New CashFlowContext()

                    Dim qry = From fInfo In ctx.DBFileInfos.Include(NameOf(DBFileInfo.Content))
                              Where fInfo.ID = FileInfoID

                    Dim fileInfo = qry.First()
                    Dim fContent As Byte() = fileInfo.Content.Content

                    tempFile = String.Concat(IO.Path.GetTempPath(), String.Concat(Guid.NewGuid.ToString(), fileInfo.Extension))
                    If IO.File.Exists(tempFile) Then
                        IO.File.Delete(tempFile)
                    End If
                    '
                    IO.File.WriteAllBytes(tempFile, fContent)

                End Using

                System.Diagnostics.Process.Start(tempFile)


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class
