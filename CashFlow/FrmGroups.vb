Public Class FrmGroups


    Public _group As Group = Nothing

    Public Sub LoadData()

        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer)).AllowDBNull = True
        dt.Columns.Add("AccessKey", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Active", GetType(Boolean)).DefaultValue = True
        '
        If _group IsNot Nothing Then
            Me.txtID.Text = _group.ID
            Me.txtAccessKey.Text = _group.AccessKey
            Me.txtName.Text = _group.Name
            '
            For Each sg In _group.SubGroups
                dt.Rows.Add(sg.ID, sg.AccessKey, sg.Name, Not sg.CancelDate.HasValue)
            Next

        End If
        '
        Me.grid.DataSource = dt
        '

        With Me.grid.Columns()
            With .Item("ID")
                .Visible = False
            End With
            '
            With .Item("AccessKey")
                .HeaderText = "Codi" ' TODO Translate
            End With
            '
            With .Item("Name")
                .HeaderText = "Nom" ' TODO Translate
            End With
            '
            With .Item("Active")
                .HeaderText = "Actiu" ' TODO Translate
            End With

        End With

    End Sub

    Private Sub FrmGroups_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub CreateGroup()

        Using ctx As New CashFlowContext()

            Dim g As [Group] = New [Group]()
            '
            g.Name = Me.txtName.Text
            g.AccessKey = Me.txtAccessKey.Text
            g.CancelDate = If(Me.chkActive.Checked, DirectCast(Nothing, DateTime?), Now)
            '
            ctx.Groups.Add(g)
            '
            SaveSubGroups(ctx, g, DirectCast(Me.grid.DataSource, DataTable))
            ctx.SaveChanges()

        End Using

    End Sub



    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal SubGroupIDs As IEnumerable(Of Integer)) As Boolean

        If SubGroupIDs Is Nothing OrElse Not SubGroupIDs.Any Then
            Return True
        End If

        ' 1. Check if exists any object linked to this sugroup
        Dim entries = (From j In ctx.JournalEntries
                       Where SubGroupIDs.Contains(j.SubGroup.ID)
                       Select j).Take(1)

        If entries.Any Then
            msgError = "Existeixen asentaments que utilitza algun del subgrups a eliminar. Valora la possibilitat de marcar-los com a inactius." ' TODO TRANSLATE
            Return False
        End If

        Return True

    End Function



    Public Sub SaveSubGroups(ctx As CashFlow.CashFlowContext, ByVal g As Group, ByVal dt As DataTable)

        Dim msgError As String = ""
        '
        Dim deletedIDs As IEnumerable(Of Integer) = Nothing
        Dim modifiedRows As IEnumerable(Of DataRow) = Nothing
        Dim addedRows As IEnumerable(Of DataRow) = Nothing
        '
        LoadChanges(deletedIDs, modifiedRows, addedRows, dt)

        ' DELETE
        If deletedIDs IsNot Nothing Then
            If Not CanDelete(ctx, msgError, deletedIDs) Then
                Throw New Exception(msgError)
            End If
            '
            Dim subgroupsToDelete = (g.SubGroups.Where(Function(x) deletedIDs.Contains(x.ID))).ToList()
            For Each oSubGroup In subgroupsToDelete
                'ctx.SubGroups.Remove(oSubGroup) ' Take out from Group List and database
                ctx.Entry(oSubGroup).State = Entity.EntityState.Deleted
            Next
        End If

        ' UPDATE
        If modifiedRows IsNot Nothing Then
            For Each row In modifiedRows
                '
                Dim oSubGroup = ctx.SubGroups.First()
                oSubGroup.Name = row("Name")
                oSubGroup.CancelDate = If(row("Enable"), DirectCast(Nothing, DateTime?), Today)
                '
                ctx.Entry(oSubGroup).State = Entity.EntityState.Modified
                '
            Next
        End If

        ' ADD
        If addedRows IsNot Nothing Then
            If g.SubGroups Is Nothing Then
                g.SubGroups = New List(Of SubGroup)()
            End If
            For Each row In addedRows
                g.SubGroups.Add(New SubGroup() With {.AccessKey = row("AccessKey"), .Name = row("Name")})
            Next
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Try
            CreateGroup()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Shared Sub LoadChanges(ByRef deletedIDs As IEnumerable(Of Integer),
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


End Class