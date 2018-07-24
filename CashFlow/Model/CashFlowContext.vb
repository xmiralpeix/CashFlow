Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

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


    Public Sub New()
        MyBase.New("CashFlowContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

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

Public Class FinancialProduct

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(100)>
    Public Property Name As String
    <Column(TypeName:="text")>
    Public Property Comments As String
    Public Property CreationDate As System.DateTime
    Public Property RegistrationDate As System.DateTime?
    Public Property CancelDate As System.DateTime?
    Public Property Owner As Owner
    Public Property BaseDeposit As Deposit ' Optional Ex: Current Account - ES000-00-0-00
    Public Property BaseImport As Decimal
    Public Property Deposit As Deposit ' Ex: Broker Account
    Public Property CashFlowEntries As IEnumerable(Of CashFlowEntry)

    Public Property ProductDeposit As Deposit ' Ex: Apple Stock - APPL (Automátic creation by Financial Product Name when open product)

    Public Property Evaluation As Evaluation
    <Column(TypeName:="text")>
    Public Property ResultComments As String
    Public Property Status As Status

    Public Sub New()
        CreationDate = Now
        Status = Status.Pending
    End Sub

    Public Shared Function GetDBQuery(ByRef ctx As CashFlowContext) As System.Data.Entity.Infrastructure.DbQuery(Of FinancialProduct)

        Return ctx.FinancialProducts _
            .Include(NameOf(FinancialProduct.Owner)) _
            .Include(NameOf(FinancialProduct.ProductDeposit)) _
            .Include(NameOf(FinancialProduct.Evaluation)) _
            .Include(NameOf(FinancialProduct.Deposit)) _
            .Include(NameOf(FinancialProduct.BaseDeposit))

    End Function


    Public Shared Sub OpenProduct(ByVal ID As Integer)

        Using ctx As New CashFlowContext()

            Dim fp = GetDBQuery(ctx).Where(Function(x) x.ID = ID).First()
            If fp.Status <> Status.Pending Then
                Throw New Exception(Locate("Només es poden obrir productes en estat pendent.", CAT))
            End If

            fp.Status = Status.Open

            If IsEmpty(fp.ProductDeposit) Then

                ' Owner
                ctx.Owners.Attach(fp.Owner)

                ' Financial Entity
                Dim depositRef As Deposit = ctx.Deposits.Include(NameOf(Deposit.FinancialEntity)).First(Function(d) d.ID = fp.Deposit.ID)
                Dim fe As FinancialEntity = depositRef.FinancialEntity
                ctx.FinancialEntities.Attach(fe)

                ' Product Deposit
                Dim dep As New Deposit()
                dep.FinancialEntity = depositRef.FinancialEntity
                dep.Owner = fp.Owner
                dep.Name = Locate("DIPÒSIT", CAT) & " " & fp.Name
                ctx.Deposits.Add(dep)
                '
                fp.ProductDeposit = dep
            Else
                ctx.Deposits.Attach(fp.ProductDeposit)
            End If

            If Not IsEmpty(fp.BaseDeposit) Then
                ctx.Deposits.Attach(fp.BaseDeposit)
            End If
            ctx.Deposits.Attach(fp.Deposit)

            Dim transferSubGrup = ctx.SubGroups.Where(Function(x) x.AccessKey = SubGroup.TransferAccessKey).First()
            ctx.SubGroups.Attach(transferSubGrup)

            '
            ' 1. Find existing financial move
            If fp.RegistrationDate.HasValue AndAlso fp.RegistrationDate.Value.Year = Today.Year Then
                If Not ctx.JournalEntries.Any(Function(x) x.FinancialProduct.ID = fp.ID) Then
                    ' Add journal entries
                    ' 1/2 - Move base to deposit
                    If Not IsEmpty(fp.BaseDeposit) Then
                        ' Out qtty
                        Dim jeOUT12 As New JournalEntry()
                        jeOUT12.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.BaseDeposit.Name, fp.Deposit.Name)
                        jeOUT12.EntryDate = fp.RegistrationDate.Value
                        jeOUT12.FinancialProduct = fp
                        jeOUT12.Import = -fp.BaseImport
                        jeOUT12.SubGroup = transferSubGrup
                        jeOUT12.Deposit = fp.BaseDeposit
                        '
                        ctx.JournalEntries.Add(jeOUT12)

                        ' In qtty
                        Dim jeIN12 As New JournalEntry()
                        jeIN12.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.BaseDeposit.Name, fp.Deposit.Name)
                        jeIN12.EntryDate = fp.RegistrationDate.Value
                        jeIN12.FinancialProduct = fp
                        jeIN12.Import = fp.BaseImport
                        jeIN12.SubGroup = transferSubGrup
                        jeIN12.Deposit = fp.Deposit
                        '
                        ctx.JournalEntries.Add(jeIN12)
                    End If

                    ' 2/2 - Move deposit to product deposit

                    ' Out qtty
                    Dim jeOUT22 As New JournalEntry()
                    jeOUT22.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.Deposit.Name, fp.ProductDeposit.Name)
                    jeOUT22.EntryDate = fp.RegistrationDate.Value
                    jeOUT22.FinancialProduct = fp
                    jeOUT22.Import = -fp.BaseImport
                    jeOUT22.SubGroup = transferSubGrup
                    jeOUT22.Deposit = fp.Deposit
                    '
                    ctx.JournalEntries.Add(jeOUT22)

                    ' In qtty
                    Dim jeIN22 As New JournalEntry()
                    jeIN22.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.Deposit.Name, fp.ProductDeposit.Name)
                    jeIN22.EntryDate = fp.RegistrationDate.Value
                    jeIN22.FinancialProduct = fp
                    jeIN22.Import = fp.BaseImport
                    jeIN22.SubGroup = transferSubGrup
                    jeIN22.Deposit = fp.ProductDeposit
                    '
                    ctx.JournalEntries.Add(jeIN22)

                End If

            End If

            ctx.SaveChanges()

        End Using

    End Sub

End Class


Public Class Deposit

    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property ID As Integer

    <Index(IsUnique:=True)>
    <MaxLength(150)>
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


