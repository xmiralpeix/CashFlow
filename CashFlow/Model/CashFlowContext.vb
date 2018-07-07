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
    Public Property FinancialProducts As DbSet(Of FinancialProduct)
    Public Property FinancialProductTypes As DbSet(Of FinancialProductType)
    Public Property Evaluations As DbSet(Of Evaluation)
    '
    Public Property Activities As DbSet(Of Activity)
    '
    Public Property CashFlowStatus As DbSet(Of CashFlowStatus)
    Public Property CashFlowEntries As DbSet(Of CashFlowEntry)


    Public Sub New()
        MyBase.New("CashFlowContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

    End Sub


End Class






Public Class JournalEntry
    Implements IJournalEntry

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer Implements IJournalEntry.ID
    '
    Public Property CreationDate As System.DateTime Implements IJournalEntry.CreationDate
    Public Property EntryDate As System.DateTime Implements IJournalEntry.EntryDate
    Public Property CancelDate As System.DateTime? Implements IJournalEntry.CancelDate
    '
    Public Property FiscalYear As Integer? Implements IJournalEntry.FiscalYear ' NULL in current period
    '
    Public Property FinancialProduct As FinancialProduct Implements IJournalEntry.FinancialProduct ' Optional Field
    Public Property Deposit As Deposit Implements IJournalEntry.Deposit ' Cash / FinancialDeposit
    '
    Public Property SubGroup As SubGroup Implements IJournalEntry.SubGroup
    '
    Public Property Concept As System.String Implements IJournalEntry.Concept
    Public Property Import As System.Double Implements IJournalEntry.Import
    Public Property Validated As System.Boolean Implements IJournalEntry.Validated

    Public Sub New()
        Me.CreationDate = Now
    End Sub
End Class



' Templates of Journal Entries
Public Class JournalEntryTemplate
    Implements IJournalEntryTemplate

    <Key>
    Public Property ID As String Implements IJournalEntryTemplate.ID
    Public Property Name As String Implements IJournalEntryTemplate.Name
    '
    Public Property EntryDate As System.DateTime? Implements IJournalEntryTemplate.EntryDate
    '
    Public Property SubGroup As SubGroup Implements IJournalEntryTemplate.SubGroup
    '
    Public Property Deposit As Deposit Implements IJournalEntryTemplate.Deposit ' Cash / FinancialDeposit
    '
    Public Property Concept As System.String Implements IJournalEntryTemplate.Concept
    Public Property Import As System.Double Implements IJournalEntryTemplate.Import

End Class

Public Enum Status
    Open = 0
    Close = 1
    Cancelled = 2
    Pending = 3
End Enum

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


Public Class Evaluation

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    <MaxLength(100)>
    Public Property Name As String
    Public Property Points As Integer

End Class

'Public Class GeneralParameters

'    <Key>
'    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
'    Public Property ID As Integer

'#Region "Financial Operations"
'    Public Property TransferSubGroup As SubGroup
'    Public Property DividendSubGroup As SubGroup
'    Public Property InterestSubGroup As SubGroup
'#End Region

'End Class


Public Class Activity

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    <MaxLength(100)>
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
    Public Property JournalEntryTemplates As ICollection(Of JournalEntryTemplate)
    '
    Public Property CancelDate As System.DateTime?

End Class



Public Class CashFlowStatus

    <Key>
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


Public Class FinancialProductType

    <Key>
    Public Property ID As Integer

    <MaxLength(100)>
    Public Property Name As System.String

    Public Property SubGroup As SubGroup


    Public Shared TransferID As Integer = 0
    Public Shared SalaryID As Integer = 1
    Public Shared InterestID As Integer = 2
    Public Shared DividendsID As Integer = 3
    Public Shared InvoiceID As Integer = 4 ' Ex: Watter invoice
    Public Shared DebtID As Integer = 5 ' Ex: House mortage payment,  


    Public Shared Sub AddDefaults()

        Using ctx As New CashFlowContext()

            Try

                Dim oGroup As New FinancialProductType()
                oGroup.ID = TransferID
                oGroup.Name = Locate("Traspàs", CAT)
                oGroup.SubGroup = ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.TransferAccessKey)
                ctx.FinancialProductTypes.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception
            End Try

            Try

                Dim oGroup As New FinancialProductType()
                oGroup.ID = SalaryID
                oGroup.Name = Locate("Salari", CAT)
                oGroup.SubGroup = ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.SalaryAccessKey)
                ctx.FinancialProductTypes.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception
            End Try

            Try

                Dim oGroup As New FinancialProductType()
                oGroup.ID = InterestID
                oGroup.Name = Locate("Interessos", CAT)
                oGroup.SubGroup = ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.InterestAccessKey)
                ctx.FinancialProductTypes.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception
            End Try

            Try

                Dim oGroup As New FinancialProductType()
                oGroup.ID = DividendsID
                oGroup.Name = Locate("Dividends", CAT)
                oGroup.SubGroup = ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.DividendAccessKey)
                ctx.FinancialProductTypes.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception
            End Try

            Try

                Dim oGroup As New FinancialProductType()
                oGroup.ID = InvoiceID
                oGroup.Name = Locate("Rebuts", CAT)
                oGroup.SubGroup = ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.InvoiceAccessKey)
                ctx.FinancialProductTypes.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception
            End Try

            Try

                Dim oGroup As New FinancialProductType()
                oGroup.ID = DebtID
                oGroup.Name = Locate("Deutes", CAT)
                oGroup.SubGroup = ctx.SubGroups.First(Function(x) x.AccessKey = SubGroup.DebtAccessKey)
                ctx.FinancialProductTypes.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception
            End Try

        End Using

    End Sub

End Class

Public Class CashFlowEntry

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    '
    Public Property Owner As Owner
    Public Property Concept As System.String
    Public Property CashFlowGroup As FinancialProductType
    '
    Public Property CancelDate As System.DateTime?
    Public Property FromDate As System.DateTime?
    Public Property ToDate As System.DateTime?
    '
    Public Property IncomeImport As Double ' Ex: Dividends --> 100$
    Public Property ExpenseImport As Double ' Ex: Car Loans --> 5.000$
    Public Property TotalAsset As Double  ' Ex: 250 Shares of MYT4U --> 5$
    Public Property TotalLiability As Double ' Ex: Car Loan Payment --> 100$

End Class


Public Class Group

    ' Ex: My house in Barcelona

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(10)>
    Public Property AccessKey As String

    <MaxLength(100)>
    Public Property Name As String

    Public Property SubGroups As ICollection(Of SubGroup)

    Public Property CancelDate As System.DateTime?


    Public Shared GroupFinancialOperationsAccessKey As String = "OF"


    Public Shared Sub AddDefaults()

        Using ctx As New CashFlowContext()

            Try

                Dim oGroup As New Group()
                oGroup.AccessKey = GroupFinancialOperationsAccessKey
                oGroup.Name = Locate("Operacions financeres", CAT)
                oGroup.SubGroups = New List(Of SubGroup)()
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.TransferAccessKey,
                                                          .Name = Locate("Traspàs", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.SalaryAccessKey,
                                                          .Name = Locate("Nòmina", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.InterestAccessKey,
                                                       .Name = Locate("Interessos", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.DividendAccessKey,
                                                       .Name = Locate("Dividends", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.InvoiceAccessKey,
                                                       .Name = Locate("Rebuts", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.DebtAccessKey,
                                                       .Name = Locate("Deutes", CAT)})

                ctx.Groups.Add(oGroup)
                ctx.SaveChanges()

            Catch ex As Exception

            End Try

        End Using


    End Sub

End Class

Public Class SubGroup

    ' Ex: Watter

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(10)>
    Public Property AccessKey As String

    <Index(IsUnique:=True)>
    <MaxLength(100)>
    Public Property Name As String

    Public Property CancelDate As System.DateTime?
    Public Property Group As Group


    Public Shared TransferAccessKey As String = "OFTRA"
    Public Shared SalaryAccessKey As String = "OFNOM"
    Public Shared InterestAccessKey As String = "OFINT"
    Public Shared DividendAccessKey As String = "OFDIV"
    Public Shared InvoiceAccessKey As String = "OFREB"
    Public Shared DebtAccessKey As String = "OFDEU"

End Class

Public Class Owner

    ' Ex: Me

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    <MaxLength(100)>
    Public Property Name As String

End Class

Public Class FinancialEntity

    ' Ex: My Bank

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    <MaxLength(100)>
    Public Property Name As String
    Public Property CancelDate As System.DateTime?

End Class

Public Class FinancialProduct

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    <MaxLength(100)>
    Public Property Name As String
    <Column(TypeName:="text")>
    Public Property Comments As String
    Public Property CreationDate As System.DateTime
    Public Property RegistrationDate As System.DateTime?
    Public Property CancelDate As System.DateTime?
    Public Property BaseDeposit As Deposit ' Ex: Current Account - ES000-00-0-00
    Public Property BaseImport As Decimal
    Public Property Deposit As Deposit ' Ex: Apple Stock - APPL
    Public Property Evaluation As Evaluation
    <Column(TypeName:="text")>
    Public Property ResultComments As String
    Public Property Status As Status
    Public Property CashFlowEntry As CashFlowEntry

    Public Sub New()
        CreationDate = Now
        Status = Status.Open
    End Sub

End Class


Public Class Deposit

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    <MaxLength(100)>
    Public Property Name As String
    Public Property CreationDate As System.DateTime
    Public Property CancelDate As System.DateTime?
    Public Property Owner As Owner
    Public Property FinancialEntity As FinancialEntity
    Public Property IsCash As Boolean

    Public Sub New()
        CreationDate = Now
    End Sub

End Class


