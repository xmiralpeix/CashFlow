﻿Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class DepositEditor
    Implements IEditContent, IFindContent

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Dipòsits", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.Deposits)
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

    Private _entry As Deposit

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From entity In ctx.Deposits
                              Where entity.ID = ID.Value).First()

                End Using

            Else
                _entry = New Deposit()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtName.Text = _entry.Name

        Catch ex As Exception
            MsgBox(ex.Message)
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

    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            '
            _entry.Name = Me.txtName.Text
            _entry.IsCash = Me.chkIsCash.Checked

            '
            If _entry.ID <> 0 Then

                Dim dbEntry = (From entity In ctx.Deposits
                               Where entity.ID = _entry.ID).First()

                ctx.Entry(dbEntry).CurrentValues.SetValues(_entry)

            Else

                ctx.Deposits.Add(_entry)

            End If

            ctx.SaveChanges()

        End Using

        _entry = Nothing

    End Sub

    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal OwnerIDs As IEnumerable(Of Integer)) As Boolean

        If OwnerIDs Is Nothing OrElse Not OwnerIDs.Any Then
            Return True
        End If

        ' 1. Check if exists any object linked to this owner
        Dim entries = (From j In ctx.JournalEntries
                       Where OwnerIDs.Contains(j.Deposit.ID)
                       Select j).Take(1)

        If entries.Any Then
            msgError = Locate("Existeixen asentaments que utilitzen el producte financer a eliminar. Valora la possibilitat de marcar-lo com a inactiu.", CAT)
            Return False
        End If

        Return True

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.Deposits.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of Deposit)
        Using ctx As New CashFlow.CashFlowContext()
            If String.IsNullOrWhiteSpace(textSearch) Then
                entityCollection = (From oEntity In ctx.Deposits
                                    Select oEntity).ToList()
            Else

                entityCollection = (From oEntity In ctx.Deposits
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
            .DataPropertyName = NameOf(Deposit.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Nom", CAT)
            .DataPropertyName = NameOf(Deposit.Name)
        End With
        '
        col.Add(New DataGridViewCheckBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Efectiu", CAT)
            .DataPropertyName = NameOf(Deposit.IsCash)
        End With


        Return col

    End Function

End Class
