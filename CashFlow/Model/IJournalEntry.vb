Imports CashFlow

Public Interface IJournalEntry
    Property CancelDate As Date?
    Property Concept As String
    Property CreationDate As Date
    Property Deposit As Deposit
    Property EntryDate As Date
    Property FiscalYear As Integer?
    Property ID As Integer
    Property Import As Double
    Property SubGroup As SubGroup
    Property FinancialProduct As FinancialProduct
    Property Validated As Boolean
End Interface

Public Interface IJournalEntryTemplate

    Property ID As String
    Property Name As String
    Property Concept As String
    Property Deposit As Deposit
    Property EntryDate As Date?
    Property Import As Double
    Property SubGroup As SubGroup

End Interface

Public Interface IJournalEntryTemplatev2

    Property ID As Integer
    Property Name As String
    Property Concept As String
    Property Deposit As Deposit
    Property EntryDate As Date?
    Property Import As Double
    Property SubGroup As SubGroup
    Property FinancialProduct As FinancialProduct

End Interface
