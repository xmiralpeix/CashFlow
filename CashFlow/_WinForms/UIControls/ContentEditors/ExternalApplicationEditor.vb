Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class ExternalApplicationEditor
    Implements IEditContent, IFindContent

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Aplicacions externes", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.ExternalApplications)
        End Get
    End Property

    Private ReadOnly Property FindBehaviour As IFindBehaviour Implements IEditContent.FindBehaviour
        Get
            Return New EntityIDsFinder(Me)
        End Get
    End Property

    'Public ReadOnly Property PrintBehaviour As IPrintBehaviour Implements IEditContent.PrintBehaviour
    '    Get
    '        Return New NoPrint()
    '    End Get
    'End Property

    Public Property EntitiesScopeCollection As IEnumerable(Of Object) Implements IFindContent.EntitiesScopeCollection

    Private _entry As ExternalApplication


    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From g1 In ctx.ExternalApplications
                              Where g1.ID = ID.Value).First()

                End Using

            Else
                _entry = New ExternalApplication()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtName.Text = _entry.Name
            Me.txtApplicationPath.Text = _entry.ApplicationPath
            Me.txtParentMenuId.Text = _entry.ParentMenuID

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtName.Select()
        End Try

    End Sub

    Private Function GetUI() As IContainerControl Implements IEditContent.GetUI
        Return Me
    End Function

    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.txtName) Then
            msgError = Locate("El nom de l'aplicació és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        If IsEmpty(Me.txtApplicationPath) Then
            msgError = Locate("L'aplicació és un camp obligatori", CAT)
            invalidControl = txtApplicationPath
            Return False
        End If

        If IsEmpty(Me.txtParentMenuId) Then
            msgError = Locate("El punt de menú és un camp obligatori", CAT)
            invalidControl = txtParentMenuId
            Return False
        End If

        Return True

    End Function

    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            '
            _entry.Name = Me.txtName.Text
            _entry.ApplicationPath = Me.txtApplicationPath.Text
            _entry.ParentMenuID = Me.txtParentMenuId.Text
            '
            If _entry.ID <> 0 Then

                Dim dbEntry = (From g1 In ctx.ExternalApplications
                               Where g1.ID = _entry.ID).First()

                ctx.Entry(dbEntry).CurrentValues.SetValues(_entry)

            Else

                ctx.ExternalApplications.Add(_entry)

            End If

            ctx.SaveChanges()

        End Using

        _entry = Nothing

    End Sub

    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal EntityIDs As IEnumerable(Of Integer)) As Boolean
        Return True

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.ExternalApplications.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of ExternalApplication)
        Using ctx As New CashFlow.CashFlowContext()
            If String.IsNullOrWhiteSpace(textSearch) Then
                entityCollection = (From oEntity In ctx.ExternalApplications
                                    Select oEntity).ToList()
            Else

                entityCollection = (From oEntity In ctx.ExternalApplications
                                    Where (oEntity.Name).Contains(textSearch)
                                    Select oEntity).ToList()
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
            .DataPropertyName = NameOf(ExternalApplication.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Nom", CAT)
            .DataPropertyName = NameOf(ExternalApplication.Name)
        End With


        Return col

    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Using dlg As New OpenFileDialog()
            If dlg.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            Me.txtApplicationPath.Text = dlg.FileName
        End Using
    End Sub
End Class
