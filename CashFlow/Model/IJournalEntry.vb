Imports CashFlow

Public Interface IJournalEntry
    Property CancelDate As Date?
    Property Concept As String
    Property CreationDate As Date
    Property Deposit As Deposit
    Property DocDate As Date?
    Property EntryDate As Date
    Property ExtractDate As Date?
    Property FiscalYear As Integer?
    Property ID As Integer
    Property Import As Double
    Property SubGroup As SubGroup
    Property Validated As Boolean
End Interface

Public Interface IJournalEntryTemplate

    Property Name As String
    Property AccessKey As String
    Property Concept As String
    Property Deposit As Deposit
    Property DocDate As Date?
    Property EntryDate As Date?
    Property ExtractDate As Date?
    Property ID As Integer
    Property Import As Double
    Property SubGroup As SubGroup

End Interface

