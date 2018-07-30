Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports CashFlow.DocumentStatus
Imports CashFlow

Public Class CashFlowContext
    Inherits DbContext

    Public Property JournalEntries As DbSet(Of JournalEntry)
    <Obsolete("Utilitzar v2", True)>
    Public Property JournalEntryTemplates As DbSet(Of JournalEntryTemplate)
    Public Property JournalEntryTemplatesv2 As DbSet(Of JournalEntryTemplatev2)
    Public Property Groups As DbSet(Of Group)
    Public Property SubGroups As DbSet(Of SubGroup)
    Public Property Owners As DbSet(Of Owner)
    Public Property FinancialEntities As DbSet(Of FinancialEntity)
    Public Property Deposits As DbSet(Of Deposit)
    Public Property PurchaseInvoices As DbSet(Of PurchaseInvoice)
    Public Property FinancialProducts As DbSet(Of FinancialProduct)
    Public Property Evaluations As DbSet(Of Evaluation)
    '
    Public Property ExternalApplications As DbSet(Of ExternalApplication)
    '
    Public Property Activities As DbSet(Of Activity)
    '
    Public Property CashFlowStatus As DbSet(Of CashFlowStatus)
    Public Property CashFlowEntries As DbSet(Of CashFlowEntry)
    Public Property IPCs As DbSet(Of IPC)
    Public Property DBFileInfos As DbSet(Of DBFileInfo)
    Public Property DBFileContents As DbSet(Of DBFileContent)
    Public Property ObjectFiles As DbSet(Of ObjectFile)
    Public Property MontlyReceipts As DbSet(Of MontlyReceipt)


    Public Sub New()
        MyBase.New("CashFlowContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

    End Sub


End Class

Public Class PurchaseInvoice

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    Public Property CreationDate As Date
    Property Owner As Owner

    Property NumAtCard As String
    <MaxLength(100)>
    Property Concept As String

    Public Property DocDate As Date
    Public Property LicTradNum As String
    Public Property Import As Decimal
    Public Property SubGroup As SubGroup
    Public Property Deposit As Deposit
    Public Property Status As DocumentStatus.Status

    Public Sub New()
        CreationDate = Now
        Status = DocumentStatus.Status.Open
    End Sub

    Public Sub AddJournalEntry(ByRef ctx As CashFlowContext)

        If Me.ID = 0 Then
            Throw New Exception(Locate("Es requereix de codi de compra per crear el moviment contable.", CAT))
        End If

        ctx.Deposits.Attach(Me.Deposit)
        ctx.SubGroups.Attach(Me.SubGroup)

        Dim je As New JournalEntry
        je.BaseObjectID = Me.ID
        je.BaseObjectName = NameOf(PurchaseInvoice)
        je.Concept = Me.Concept
        je.CreationDate = Now
        je.Deposit = Me.Deposit
        je.EntryDate = Me.DocDate
        je.Import = Me.Import
        je.SubGroup = Me.SubGroup
        '
        ctx.JournalEntries.Add(je)

    End Sub

    Public Shared Function GetDBQuery(ByRef ctx As CashFlowContext) As System.Data.Entity.Infrastructure.DbQuery(Of PurchaseInvoice)
        Return ctx.PurchaseInvoices _
        .Include(NameOf(PurchaseInvoice.Owner)) _
        .Include(NameOf(PurchaseInvoice.Deposit)) _
        .Include(NameOf(PurchaseInvoice.SubGroup))
    End Function

End Class


Public Class MontlyReceipt

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <MaxLength(100)>
    Public Property Name As String
    Public Property Owner As Owner
    Public Property CreationDate As DateTime
    Public Property Status As DocumentStatus.Status
    Public Property Deposit As Deposit
    Public Property Import As Decimal
    <Column(TypeName:="text")>
    Public Property Comments As String


    Public Sub New()
        Me.CreationDate = Now
    End Sub

End Class


Public Class ObjectFile

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <MaxLength(100)>
    Public Property TableName As String
    Public Property PrimaryKey As Integer
    Public Property DBFileInfo As DBFileInfo

End Class

Public Class DBFileInfo

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <MaxLength(100)>
    Public Property Name As String

    Public Property CreationDate As DateTime

    <Column(TypeName:="text")>
    Public Property Comments As String

    <MaxLength(4)>
    Public Property Extension As String

    Public Property Content As DBFileContent

    Public Sub New()
        CreationDate = Now
    End Sub

End Class

Public Class DBFileContent

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    Public Property Content As Byte()

End Class



Public Class IPC

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    Public Property Value As Decimal
    Public Property FromDate As DateTime
    Public Property ToDate As DateTime?

End Class

Public Class ExternalApplication

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(100)>
    Public Property Name As String

    <MaxLength(254)>
    Public Property ParentMenuID As String

    <MaxLength(254)>
    Public Property ApplicationPath As String



End Class




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
End Class


' Templates of Journal Entries
Public Class JournalEntryTemplatev2
    Implements IJournalEntryTemplatev2

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer Implements IJournalEntryTemplatev2.ID

    <MaxLength(100)>
    Public Property Name As String Implements IJournalEntryTemplatev2.Name
    '
    Public Property EntryDate As System.DateTime? Implements IJournalEntryTemplatev2.EntryDate
    '
    Public Property SubGroup As SubGroup Implements IJournalEntryTemplatev2.SubGroup
    '
    Public Property FinancialProduct As FinancialProduct Implements IJournalEntryTemplatev2.FinancialProduct
    Public Property Deposit As Deposit Implements IJournalEntryTemplatev2.Deposit ' Cash / FinancialDeposit
    '
    Public Property Concept As System.String Implements IJournalEntryTemplatev2.Concept
    Public Property Import As System.Double Implements IJournalEntryTemplatev2.Import

End Class


' Templates of Journal Entries
<Obsolete("Utilitzar v2", False)>
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

    <Index(IsUnique:=True)>
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

    <Index(IsUnique:=True)>
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


'Public Class CashFlowGroup

'    <Key>
'    Public Property ID As Integer

'    <MaxLength(100)>
'    Public Property Name As System.String

'    Public Property QuarterZone As CashFlowQuarterZone


'End Class


Public Enum CashFlowQuarterZone
    Income = 0
    Expenses = 1
    Assets = 2
    Liabilities = 3
End Enum


Public Class CashFlowEntry

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer
    '
    Public Property Owner As Owner
    Public Property Concept As System.String

    '
    Public Property FinancialProduct As FinancialProduct
    '
    Public Property CancelDate As System.DateTime?
    Public Property FromDate As System.DateTime?
    Public Property ToDate As System.DateTime?
    '
    Public Property IncomeImport As Decimal
    Public Property ExpensesImport As Decimal
    Public Property AssetsImport As Decimal
    Public Property LiabilitiesImport As Decimal

    Public Property Status As Status

End Class


Public Class Group

    ' Ex: My house in Barcelona

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(10)>
    Public Property AccessKey As String

    <Index(IsUnique:=True)>
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
                oGroup.Name = Locate("OPERACIONS FINANCERES", CAT)
                oGroup.SubGroups = New List(Of SubGroup)()
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.TransferAccessKey,
                                                          .Name = Locate("TRASPÀS", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.CapitalAccessKey,
                                                          .Name = Locate("CAPITAL", CAT)})
                oGroup.SubGroups.Add(New SubGroup() With {.AccessKey = SubGroup.DividendAccessKey,
                                                          .Name = Locate("DIVIDENDS", CAT)})


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
    <MaxLength(25)>
    Public Property AccessKey As String

    <Index(IsUnique:=True)>
    <MaxLength(100)>
    Public Property Name As String

    Public Property CancelDate As System.DateTime?
    Public Property Group As Group

    Public Shared TransferAccessKey As String = "OF.TRA"
    Public Shared CapitalAccessKey As String = "OF.CAP"
    Public Shared DividendAccessKey As String = "OF.DIV"

End Class

Public Class Owner

    ' Ex: Me

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(100)>
    Public Property Name As String

End Class

Public Class FinancialEntity

    ' Ex: My Bank

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(100)>
    Public Property Name As String
    Public Property CancelDate As System.DateTime?

End Class







