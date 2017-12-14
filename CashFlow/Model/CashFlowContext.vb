Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CashFlowContext
    Inherits DbContext

    Public Property JournalEntries As DbSet(Of JournalEntry)
    Public Property JournalEntryTemplates As DbSet(Of JournalEntryTemplate)
    Public Property Groups As DbSet(Of Group)
    Public Property SubGroups As DbSet(Of SubGroup)
    Public Property Owners As DbSet(Of Owner)
    Public Property FinancialEntities As DbSet(Of FinancialEntity)
    Public Property Deposits As DbSet(Of Deposit)
    '
    Public Property Activities As DbSet(Of Activity)
    '
    Public Property CashFlowStatus As DbSet(Of CashFlowStatus)
    Public Property CashFlowIncomes As DbSet(Of CashFlowIncome)
    Public Property CashFlowExpenses As DbSet(Of CashFlowExpense)
    Public Property CashFlowAssets As DbSet(Of CashFlowAsset)
    Public Property CashFlowLiabilities As DbSet(Of CashFlowLiability)

    Public Sub New()
        MyBase.New("CashFlowContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

    End Sub


End Class


Public Class JournalEntry
    Implements IJournalEntry

    <Required>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer Implements IJournalEntry.ID
    '
    Public Property CreationDate As System.DateTime Implements IJournalEntry.CreationDate
    Public Property EntryDate As System.DateTime Implements IJournalEntry.EntryDate
    Public Property DocDate As System.DateTime? Implements IJournalEntry.DocDate ' Date in document

    Public Property ExtractDate As System.DateTime? Implements IJournalEntry.ExtractDate ' Date from financial document (financial extract)

    Public Property CancelDate As System.DateTime? Implements IJournalEntry.CancelDate
    '
    Public Property FiscalYear As Integer? Implements IJournalEntry.FiscalYear ' NULL in current period

    '
    Public Property SubGroup As SubGroup Implements IJournalEntry.SubGroup
    '
    Public Property Deposit As Deposit Implements IJournalEntry.Deposit ' Cash / FinancialDeposit
    '
    Public Property Concept As System.String Implements IJournalEntry.Concept
    Public Property Import As System.Double Implements IJournalEntry.Import
    Public Property Validated As System.Boolean Implements IJournalEntry.Validated
End Class



' Templates of Journal Entries
Public Class JournalEntryTemplate
    Implements IJournalEntryTemplate

    <Required>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer Implements IJournalEntryTemplate.ID
    Public Property Name As String Implements IJournalEntryTemplate.Name
    Public Property AccessKey As String Implements IJournalEntryTemplate.AccessKey
    '
    Public Property EntryDate As System.DateTime? Implements IJournalEntryTemplate.EntryDate
    Public Property DocDate As System.DateTime? Implements IJournalEntryTemplate.DocDate ' Date in document

    Public Property ExtractDate As System.DateTime? Implements IJournalEntryTemplate.ExtractDate ' Date from financial document (financial extract)
    '
    Public Property SubGroup As SubGroup Implements IJournalEntryTemplate.SubGroup
    '
    Public Property Deposit As Deposit Implements IJournalEntryTemplate.Deposit ' Cash / FinancialDeposit
    '
    Public Property Concept As System.String Implements IJournalEntryTemplate.Concept
    Public Property Import As System.Double Implements IJournalEntryTemplate.Import

End Class

Public Enum RepeatPeriod
    Never = 0
    EveryDay = 1
    EveryWeek = 2
    EveryMonthy = 3
    EveryYear = 4
End Enum

Public Enum RepeatWeek
    Never = 0
    FirstWeek = 1
    SecondWeek = 2
    ThirdWeek = 3
    FourthWeek = 4
    LastWeek = 5
End Enum


Public Class Activity

    <Required>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Name As String
    '
    Public Property RepeatPeriod As RepeatPeriod
    Public Property DayOfWeek As DayOfWeek
    Public Property RepeatWeek As RepeatWeek
    Public Property RepeatMonthDay As Integer?
    ' Period
    Public Property FromDate As System.DateTime?
    Public Property ToDate As System.DateTime?
    ' Linked Object
    Public Property LinkedObjectName As String
    Public Property LinkedID As Integer?
    '
    Public Property CancelDate As System.DateTime?

End Class



Public Class CashFlowStatus

    <Required>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    '
    Public Property TotalIncome As System.Double
    Public Property TotalExpenses As System.Double
    Public Property PassiveIncome As System.Double
    Public Property Cash As System.Double
    Public Property PayDay As System.Double
    Public Property StatusDate As System.DateTime

End Class



Public Class CashFlowEntry

    <Required>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    '
    Public Property Owner As Owner
    Public Property Concept As System.String
    '
    Public Property CancelDate As System.DateTime?
    Public Property FromDate As System.DateTime?
    Public Property ToDate As System.DateTime?
    '
    Public Property Import As Double

End Class


Public Class CashFlowAsset
    Inherits CashFlowEntry

    ' Ex: 250 Shares of MYT4U --> 5$

End Class

Public Class CashFlowLiability
    Inherits CashFlowEntry

    ' Ex: Car Loan Payment --> 100$

End Class

Public Class CashFlowExpense
    Inherits CashFlowEntry

    ' Ex: Car Loans --> 5.000$

End Class

Public Class CashFlowIncome
    Inherits CashFlowEntry

    ' Ex: Police Officer Salary --> 3.000$

End Class


Public Class Group

    ' Ex: My house in Barcelona

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Name As String
    Public Property AccessKey As String
    Public Property SubGroups As ICollection(Of SubGroup)
    Public Property CancelDate As System.DateTime?

End Class

Public Class SubGroup

    ' Ex: Watter

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Name As String
    Public Property AccessKey As String
    Public Property CancelDate As System.DateTime?
    Public Property Group As Group

End Class

Public Class Owner

    ' Ex: Me

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Name As String
    Public Property AccessKey As String

End Class

Public Class FinancialEntity

    ' Ex: My Bank

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Name As String
    Public Property AccessKey As String
    Public Property CancelDate As System.DateTime?

End Class


Public Class Deposit

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Name As String
    Public Property AccessKey As String
    Public Property CreationDate As System.DateTime
    Public Property CancelDate As System.DateTime?
    Public Property Owner As Owner
    Public Property FinancialEntity As FinancialEntity
    Public Property IsCash As Boolean

End Class


