﻿Imports System.Globalization
Imports CashFlow
Imports Microsoft.Reporting.WinForms

Public Class CashFlowEntryEditor
    Implements IEditContent, IFindContent

    Public Property FinancialProductScope As FinancialProduct

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Registre CashFlow", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.CashFlowEntries)
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

    Private _entry As CashFlowEntry


    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    Dim qry = (From entity In ctx.CashFlowEntries.Include(NameOf(CashFlowEntry.FinancialProduct)).Include(NameOf(CashFlowEntry.Owner))
                               Where entity.ID = ID.Value)

                    If Not IsEmpty(EntitiesScopeCollection) Then
                        For Each eScope In EntitiesScopeCollection
                            If TypeOf eScope Is FinancialProduct Then
                                Dim fpScope As FinancialProduct = eScope
                                qry = qry.Where(Function(x) x.FinancialProduct.ID = fpScope.ID)
                                Continue For
                            End If
                        Next
                    End If

                    _entry = qry.First

                End Using

            Else
                _entry = New CashFlowEntry()
            End If

            FillForm()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtConcept.Select()
        End Try

    End Sub

    Private Sub FillForm()

        Me.txtID.Text = _entry.ID
        Me.txtConcept.Text = _entry.Concept
        '
        Me.txtAssetsImport.Text = _entry.AssetsImport
        Me.txtExpenses.Text = _entry.ExpensesImport
        Me.txtIncome.Text = _entry.IncomeImport
        Me.txtLiabilities.Text = _entry.LiabilitiesImport
        Me.txtFromDate.AssignValue(_entry.FromDate)
        Me.txtToDate.AssignValue(_entry.ToDate)
        '
        If IsEmpty(_entry.Owner) Then
            Me.ListBox_Owner1.AssignValue(String.Empty)
        Else
            Me.ListBox_Owner1.AssignValue(_entry.Owner.ID)
        End If

        If IsEmpty(_entry.FinancialProduct) Then
            Me.ListBox_FinancialProduct1.AssignValue(String.Empty)
        Else
            Me.ListBox_FinancialProduct1.AssignValue(_entry.FinancialProduct.ID)
        End If

        Me.cbDocStatus.SelectedValue = _entry.Status
        Me.cbDocStatus.Enabled = False

    End Sub

    Private Function GetUI() As IContainerControl Implements IEditContent.GetUI
        DocumentStatus.ConfigureCombo(Me.cbDocStatus)
        Return Me
    End Function

    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.txtConcept) Then
            invalidControl = Me.txtConcept
            msgError = Locate("El concepte, és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.txtFromDate) Then
            invalidControl = Me.txtFromDate
            msgError = Locate("La data inici del periode és un camp obligatori", CAT)
            Return False
        End If

        If IsEmpty(Me.ListBox_Owner1) Then
            invalidControl = Me.ListBox_Owner1
            msgError = Locate("El propietari és un camp obligatori", CAT)
            Return False
        End If

        If Not IsEmpty(Me.FinancialProductScope) AndAlso ListBox_FinancialProduct1.Entity.ID <> FinancialProductScope.ID Then
            invalidControl = Me.ListBox_FinancialProduct1
            msgError = Locate("Només s'admenten entrades del producte financer ", CAT) & FinancialProductScope.Name
            Return False
        End If

        Return True

    End Function

    Private Sub FillEntry(ByVal ctx As CashFlowContext)

        _entry.Concept = Me.txtConcept.Text
        '
        _entry.AssetsImport = Me.txtAssetsImport.Text
        _entry.ExpensesImport = Me.txtExpenses.Text
        _entry.IncomeImport = Me.txtIncome.Text
        _entry.LiabilitiesImport = Me.txtLiabilities.Text
        '
        _entry.Owner = ctx.Owners.Where(Function(x) x.ID = Me.ListBox_Owner1.Entity.ID).FirstOrDefault
        If Me.ListBox_FinancialProduct1.HasValue Then
            _entry.FinancialProduct = ctx.FinancialProducts.Where(Function(x) x.ID = Me.ListBox_FinancialProduct1.Entity.ID).FirstOrDefault
        End If
        '
        If Me.txtFromDate.HasValue Then
            _entry.FromDate = Me.txtFromDate.Value
        Else
            _entry.FromDate = Nothing
        End If

        If Me.txtToDate.HasValue Then
            _entry.ToDate = Me.txtToDate.Value
        Else
            _entry.ToDate = Nothing
        End If

    End Sub

    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            If _entry.ID <> 0 Then
                ' UPDATE
                _entry = (From entity In ctx.CashFlowEntries.Include(NameOf(CashFlowEntry.Owner)).Include(NameOf(CashFlowEntry.FinancialProduct))
                          Where entity.ID = _entry.ID).First()

                FillEntry(ctx)
                '
                ctx.SaveChanges()
            Else
                ' ADD
                FillEntry(ctx)
                ctx.CashFlowEntries.Add(_entry)
                '
                ctx.SaveChanges()
            End If

        End Using

        _entry = Nothing

    End Sub


    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal OwnerIDs As IEnumerable(Of Integer)) As Boolean

        Return False

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.CashFlowEntries.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of CashFlowEntry)
        Using ctx As New CashFlow.CashFlowContext()

            Dim qry = (From oEntity In ctx.CashFlowEntries
                       Select oEntity)
            If Not IsEmpty(textSearch) Then
                qry = qry.Where(Function(x) x.Concept.Contains(textSearch))
            End If


            If Not IsEmpty(EntitiesScopeCollection) Then
                For Each eScope In EntitiesScopeCollection
                    If TypeOf eScope Is FinancialProduct Then
                        Dim fpScope As FinancialProduct = eScope
                        Qry = Qry.Where(Function(x) x.FinancialProduct.ID = fpScope.ID)
                        Continue For
                    End If
                Next
            End If

            entityCollection = Qry.tolist


        End Using

        Return entityCollection

    End Function

    Public Function GetColumns() As IEnumerable(Of DataGridViewColumn) Implements IFindContent.GetColumns

        Dim col As New List(Of DataGridViewColumn)()
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = "ID"
            .DataPropertyName = NameOf(CashFlowEntry.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Concepte", CAT)
            .DataPropertyName = NameOf(CashFlowEntry.Concept)
        End With

        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Inici", CAT)
            .DataPropertyName = NameOf(CashFlowEntry.FromDate)
        End With

        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Fi", CAT)
            .DataPropertyName = NameOf(CashFlowEntry.ToDate)
        End With

        Return col

    End Function


End Class
