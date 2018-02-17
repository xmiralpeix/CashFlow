Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class GroupEditor
    Implements IEditContent, IFindContent, IPrintContent


    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Grups", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.Groups)
        End Get
    End Property

    Private ReadOnly Property FindBehaviour As IFindBehaviour Implements IEditContent.FindBehaviour
        Get
            Return New EntityIDsFinder(Me)
        End Get
    End Property

    Public ReadOnly Property PrintBehaviour As IPrintBehaviour Implements IEditContent.PrintBehaviour
        Get
            Return New EntityIDsPrinter(Me)
        End Get
    End Property

    Public ReadOnly Property ReportEmbeddedResource As String Implements IPrintContent.ReportEmbeddedResource
        Get
            Return "CashFlow.RptGroups.rdlc"
        End Get
    End Property


    Private _entry As Group

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From g1 In ctx.Groups
                              Where g1.ID = ID.Value).First()

                    ctx.Entry(_entry).Collection(Function(x) x.SubGroups).Load()

                End Using

            Else
                _entry = New [Group]()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtAccessKey.Text = _entry.AccessKey
            Me.txtName.Text = _entry.Name
            Me.chkActive.Enabled = Not _entry.CancelDate.HasValue
            '


            Dim dt As New DataTable()
            dt.Columns.Add("ID", GetType(Integer)).AllowDBNull = True
            dt.Columns.Add("AccessKey", GetType(String))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Active", GetType(Boolean)).DefaultValue = True
            '
            If _entry.SubGroups IsNot Nothing Then
                For Each sg In _entry.SubGroups
                    dt.Rows.Add(sg.ID, sg.AccessKey, sg.Name, Not sg.CancelDate.HasValue)
                Next
            End If
            '
            dt.AcceptChanges()
            Me.grid.DataSource = dt

            With Me.grid.Columns()
                With .Item("ID")
                    .Visible = False
                End With
                '
                With .Item("AccessKey")
                    .HeaderText = Locate("Codi", CAT)
                End With
                '
                With .Item("Name")
                    .HeaderText = Locate("Nom", CAT)
                End With
                '
                With .Item("Active")
                    .HeaderText = Locate("Actiu", CAT)
                End With

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtAccessKey.Select()
        End Try


    End Sub

    Private Function AppEvents() As IEnumerable(Of String) Implements IEditContent.AppEvents
        Return {
            NameOf(SearchAppEvent),
            NameOf(NewAppEvent),
            NameOf(FirstAppEvent),
            NameOf(PreviousAppEvent),
            NameOf(NextAppEvent),
            NameOf(LastAppEvent),
            NameOf(PrintAppEvent),
            NameOf(DeleteAppEvent)}
    End Function

    Private Function GetUI() As IContainerControl Implements IEditContent.GetUI
        Return Me
    End Function

    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.txtAccessKey) Then
            msgError = Locate("El codi del grup és un camp obligatori", CAT)
            invalidControl = txtAccessKey
            Return False
        End If

        If IsEmpty(Me.txtName) Then
            msgError = Locate("El nom del grup és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        Return True

    End Function

    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            '
            _entry.Name = Me.txtName.Text
            _entry.AccessKey = Me.txtAccessKey.Text
            _entry.CancelDate = If(Me.chkActive.Checked, DirectCast(Nothing, DateTime?), Now)

            '
            If _entry.ID <> 0 Then

                Dim dbGroup = (From g1 In ctx.Groups
                               Where g1.ID = _entry.ID).First()
                ctx.Entry(dbGroup).Collection(Function(x) x.SubGroups).Load()
                '
                ctx.Entry(dbGroup).CurrentValues.SetValues(_entry)
                SaveSubGroups(ctx, dbGroup, DirectCast(Me.grid.DataSource, DataTable))

            Else

                ctx.Groups.Add(_entry)
                SaveSubGroups(ctx, _entry, DirectCast(Me.grid.DataSource, DataTable))

            End If

            ctx.SaveChanges()

        End Using

        _entry = Nothing

    End Sub

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
                Dim ID = row("ID")
                Dim oSubGroup = (From sg In g.SubGroups
                                 Where sg.ID = ID).First

                oSubGroup.AccessKey = row("AccessKey")
                oSubGroup.Name = row("Name")
                oSubGroup.CancelDate = If(row("Active"), DirectCast(Nothing, DateTime?), Today)
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


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.Groups.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of Group)
        Using ctx As New CashFlow.CashFlowContext()
            If String.IsNullOrWhiteSpace(textSearch) Then
                entityCollection = (From oGroup In ctx.Groups
                                    Select oGroup).ToList()
            Else

                entityCollection = (From oGroup In ctx.Groups
                                    Where (oGroup.AccessKey & NOTUSEDCHAR & oGroup.Name).Contains(textSearch)
                                    Select oGroup).ToList()
            End If

        End Using

        Return entityCollection

    End Function

    Public Function GetColumns() As IEnumerable(Of DataGridViewColumn) Implements IFindContent.GetColumns

        Dim col As New List(Of DataGridViewColumn)()
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = "ID"
            .DataPropertyName = NameOf(Group.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Codi", CAT)
            .DataPropertyName = NameOf(Group.AccessKey)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Nom", CAT)
            .DataPropertyName = NameOf(Group.Name)
        End With


        Return col

    End Function


    Private _printCulture As CultureInfo
    Public Property Culture As CultureInfo Implements IPrintContent.Culture
        Get
            Return _printCulture
        End Get
        Set(value As CultureInfo)
            value = _printCulture
        End Set
    End Property


    Private _printFromID, _printToID As Integer
    Public Sub SetIDRange(FromID As Integer, ToID As Integer) Implements IPrintContent.SetIDRange
        _printFromID = FromID
        _printToID = ToID
    End Sub

    Public Function ReportDataSource() As ReportDataSource Implements IPrintContent.ReportDataSource
        Dim rds As Microsoft.Reporting.WinForms.ReportDataSource
        rds = New Microsoft.Reporting.WinForms.ReportDataSource("RptData", RptGroupsRow.LoadData(_printFromID, _printToID, _printCulture))
        Return rds
    End Function

End Class
