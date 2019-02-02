Public Class JournalEntry
    Implements IJournalEntry

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer Implements IJournalEntry.ID

    <MaxLength(100)>
    Public Property ExternalID As String

    '
    Public Property CreationDate As System.DateTime Implements IJournalEntry.CreationDate
    Public Property EntryDate As System.DateTime Implements IJournalEntry.EntryDate
    Public Property CancelDate As System.DateTime? Implements IJournalEntry.CancelDate
    '
    Public Property FiscalYear As Integer? Implements IJournalEntry.FiscalYear ' NULL in current period
    '
    'Public Property FinancialProduct As FinancialProduct Implements IJournalEntry.FinancialProduct ' Optional Field
    Public Property Deposit As Deposit Implements IJournalEntry.Deposit ' Cash / FinancialDeposit
    '
    Public Property SubGroup As SubGroup Implements IJournalEntry.SubGroup
    '
    Public Property Concept As System.String Implements IJournalEntry.Concept
    Public Property Import As System.Double Implements IJournalEntry.Import
    Public Property Validated As System.Boolean Implements IJournalEntry.Validated

    Public Property BaseObjectName As String Implements IJournalEntry.BaseObjectName
    Public Property BaseObjectID As Integer Implements IJournalEntry.BaseObjectID


    Public Sub New()
        Me.CreationDate = Now
    End Sub

    Public Shared Sub Cancel(ID As Integer)

        If IsEmpty(ID) Then
            Throw New Exception(Locate("S'ha d'informar del codi de l'assentament.", CAT))
        End If

        Using ctx As New CashFlowContext()

            Dim je = ctx.JournalEntries.Find(ID)
            If IsEmpty(je) Then
                Throw New Exception(Locate("No existeix cap assentament amb el codi ", CAT) & ID)
            End If

            If Not IsEmpty(je.BaseObjectID) Then
                Throw New Exception(Locate("No es pot cancel·lar un assentament amb orígen.", CAT))
            End If

            If Not je.CancelDate.HasValue Then
                je.CancelDate = Now
                ctx.SaveChanges()
            End If

        End Using

    End Sub
End Class