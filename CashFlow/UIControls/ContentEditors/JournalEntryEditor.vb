Imports CashFlow

Public Class JournalEntryEditor
    Implements IEditContent, IFindContent

    Private ReadOnly Property IEditContent_Text As String Implements IEditContent.Text
        Get
            Return Locate("Moviments financers", CAT)
        End Get
    End Property

    Private ReadOnly Property Table As String Implements IEditContent.Table
        Get
            Return NameOf(CashFlow.CashFlowContext.JournalEntries)
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

    Public Property EntitiesScopeCollection As IEnumerable(Of Object) Implements IFindContent.EntitiesScopeCollection

    Private _entry As JournalEntry

    Public Sub LoadFormByID(ID? As Integer) Implements IEditContent.LoadFormByID

        Try

            If ID.HasValue Then

                Using ctx As New CashFlow.CashFlowContext()

                    _entry = (From g1 In ctx.JournalEntries.Include(NameOf(JournalEntry.SubGroup)).Include(NameOf(JournalEntry.Deposit))
                              Where g1.ID = ID.Value).First()

                End Using

            Else
                _entry = New JournalEntry()
            End If

            Me.txtID.Text = _entry.ID
            Me.txtConcept.Text = _entry.Concept
            Me.ListBox_Deposit1.AssignValue(_entry.Deposit)
            AddHandler ListBox_Deposit1.OnEntityChanged, Sub() LoadBalance()
            '
            Me.txtEntryDate.AssignValue(If(IsEmpty(_entry.EntryDate), DirectCast(Nothing, DateTime?), _entry.EntryDate))
            'Me.ListBox_FinancialProduct1.AssignValue(_entry.FinancialProduct)
            Me.txtImport.Text = Me._entry.Import
            Me.ListBox_SubGroup1.AssignValue(_entry.SubGroup)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.txtEntryDate.Select()
        End Try

    End Sub

    Private Sub LoadBalance()

        Dim msgIncomes As String = Locate("Ingressos {0:n2}", CAT)
        Dim msgExpenses As String = Locate("Despeses {0:n2}", CAT)
        Dim msgBalance As String = Locate("Saldo {0:n2}", CAT)
        Dim incomes As Decimal = 0
        Dim expenses As Decimal = 0
        Dim balance As Decimal = 0

        If ListBox_Deposit1.HasValue Then
            Deposit.LoadBalance(ListBox_Deposit1.Entity.ID, incomes, expenses, balance)
        End If

        ' Values
        Me.lblIncomes.Text = String.Format(msgIncomes, incomes)
        Me.lblExpenses.Text = String.Format(msgExpenses, expenses)
        Me.lblBalance.Text = String.Format(msgBalance, balance)
        '
        Me.lblBalance.ForeColor = If(balance >= 0, Drawing.Color.Green, Drawing.Color.Red)

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

        ' Configure controls
        Return Me

    End Function

    Public Function IsValidContent(ByRef msgError As String,
                                   ByRef invalidControl As Control) As Boolean Implements IEditContent.IsValidContent

        msgError = ""
        invalidControl = Nothing

        If IsEmpty(Me.txtEntryDate) Then
            msgError = Locate("La data és un camp obligatori", CAT)
            invalidControl = txtEntryDate
            Return False
        End If

        If IsEmpty(Me.txtConcept) Then
            msgError = Locate("El concepte és un camp obligatori", CAT)
            invalidControl = txtConcept
            Return False
        End If

        If IsEmpty(Me.txtImport) Then
            msgError = Locate("L'import és un camp obligatori", CAT)
            invalidControl = txtImport
            Return False
        End If

        If Not Me.ListBox_Deposit1.HasValue Then
            msgError = Locate("El dipòsit és un camp obligatori", CAT)
            invalidControl = ListBox_Deposit1
            Return False
        End If

        Return True

    End Function

    Private Sub FillEntry(ByVal ctx As CashFlowContext)

        _entry.Concept = Me.txtConcept.Text
        _entry.Deposit = ctx.Deposits.Where(Function(x) x.ID = Me.ListBox_Deposit1.Entity.ID).FirstOrDefault()
        _entry.EntryDate = Me.txtEntryDate.Value

        If Me.ListBox_SubGroup1.HasValue Then
            _entry.SubGroup = ctx.SubGroups.Where(Function(x) x.ID = Me.ListBox_SubGroup1.Entity.ID).FirstOrDefault()
        Else
            _entry.SubGroup = Nothing
        End If

        Me._entry.Import = Me.txtImport.Text

    End Sub


    Public Sub SaveEntry() Implements IEditContent.SaveEntry

        Using ctx As New CashFlowContext()

            If _entry.ID <> 0 Then
                ' UPDATE
                _entry = ctx.JournalEntries.Where(Function(x) x.ID = _entry.ID).FirstOrDefault()
                FillEntry(ctx)
                ctx.SaveChanges()
            Else
                ' ADD
                FillEntry(ctx)
                ctx.JournalEntries.Add(_entry)
                '
                ctx.SaveChanges()
            End If

        End Using

        _entry = Nothing

    End Sub

    Public Function CanDelete(ByVal ctx As CashFlow.CashFlowContext,
                              ByRef msgError As String,
                              ByVal IDs As IEnumerable(Of Integer)) As Boolean

        msgError = Locate("No es poden eliminar moviments financers. Valora la possibilitat d'anul·lar-lo", CAT)
        Return False

    End Function


    Public Function GetQuantity() As Integer Implements IFindContent.GetQuantity

        Using ctx As New CashFlow.CashFlowContext()
            Return ctx.JournalEntries.Count
        End Using

    End Function

    Public Function GetContent(ByVal textSearch As String) As Object Implements IFindContent.GetContent

        Dim entityCollection As List(Of JournalEntry)
        Using ctx As New CashFlow.CashFlowContext()
            If String.IsNullOrWhiteSpace(textSearch) Then
                entityCollection = (From oEntity In ctx.JournalEntries
                                    Select oEntity).ToList()
            Else

                entityCollection = (From oEntity In ctx.JournalEntries
                                    Where (oEntity.Concept).Contains(textSearch)
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
            .DataPropertyName = NameOf(JournalEntry.ID)
            .Visible = False
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Data", CAT)
            .DataPropertyName = NameOf(JournalEntry.EntryDate)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Concepte", CAT)
            .DataPropertyName = NameOf(JournalEntry.Concept)
        End With
        '
        col.Add(New DataGridViewTextBoxColumn())
        With col(col.Count - 1)
            .HeaderText = Locate("Creació", CAT)
            .DataPropertyName = NameOf(JournalEntry.CreationDate)
        End With

        Return col

    End Function
End Class
