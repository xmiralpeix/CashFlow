﻿Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class EvaluationEditor
    Implements IEditContent, IFindContent

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Valoracions", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.Evaluations)
        End Get
    End Property

    Private ReadOnly Property FindBehaviour As IFindBehaviour Implements IEditContent.FindBehaviour
        Get
            Return New EntityIDsFinder(Me)
        End Get
    End Property

    Public ReadOnly Property PrintBehaviour As IPrintBehaviour Implements IEditContent.PrintBehaviour
        Get
            Return New NoPrint()
        End Get
    End Property

    Private _entry As Evaluation

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From g1 In ctx.Evaluations
                              Where g1.ID = ID.Value).First()

                End Using

            Else
                _entry = New Evaluation()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtName.Text = _entry.Name
            Me.txtPoints.Text = _entry.Points

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtName.Select()
        End Try

    End Sub

    Private Function AppEvents() As IEnumerable(Of String) Implements IEditContent.AppEvents
        Return {
            NameOf(SearchAppEvent),
            NameOf(NewAppEvent),
            NameOf(FirstAppEvent),
            NameOf(PreviousAppEvent),
            NameOf(NextAppEvent),
            NameOf(LastAppEvent)}

    End Function

    Private Function GetUI() As IContainerControl Implements IEditContent.GetUI
        Return Me
    End Function

    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.txtName) Then
            msgError = Locate("El nom de la valoració és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        If IsEmpty(Me.txtPoints) Then
            msgError = Locate("Els punts de la valoració és un camp obligatori", CAT)
            invalidControl = txtName
            Return False
        End If

        Return True

    End Function

    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            '
            _entry.Name = Me.txtName.Text
            _entry.Points = Me.txtPoints.Text

            '
            If _entry.ID <> 0 Then

                Dim dbEntry = (From g1 In ctx.Evaluations
                               Where g1.ID = _entry.ID).First()

                ctx.Entry(dbEntry).CurrentValues.SetValues(_entry)

            Else

                ctx.Evaluations.Add(_entry)

            End If

            ctx.SaveChanges()

        End Using

        _entry = Nothing

    End Sub

    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal IDs As IEnumerable(Of Integer)) As Boolean

        If IDs Is Nothing OrElse Not IDs.Any Then
            Return True
        End If

        msgError = Locate("No es poden eliminar valoracions. Valora la possiblitat d'anular-la", CAT)


        Return False

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.Evaluations.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of Evaluation)
        Using ctx As New CashFlow.CashFlowContext()
            If String.IsNullOrWhiteSpace(textSearch) Then
                entityCollection = (From oEntity In ctx.Evaluations
                                    Select oEntity).ToList()
            Else

                entityCollection = (From oEntity In ctx.Evaluations
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
            .DataPropertyName = NameOf(Evaluation.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Nom", CAT)
            .DataPropertyName = NameOf(Evaluation.Name)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Punts", CAT)
            .DataPropertyName = NameOf(Evaluation.Points)
        End With


        Return col

    End Function


End Class
