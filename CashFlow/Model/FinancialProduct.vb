Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports CashFlow.DocumentStatus

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


    ''' <summary>
    ''' 1. Change status to OPEN
    ''' 2. Create product deposit
    ''' 3. Add imports transfers between deposits until product deposit
    ''' 4. Change status of cashflow entries to OPEN
    ''' </summary>
    ''' <param name="ID"></param>
    Public Shared Sub OpenProduct(ByVal ID As Integer)

        Using ctx As New CashFlowContext()

            Dim fp = GetDBQuery(ctx).Where(Function(x) x.ID = ID).First()
            If fp.Status <> Status.Pending Then
                Throw New Exception(Locate("Només es poden obrir productes en estat pendent.", CAT))
            End If

            ' 1. Change status to OPEN
            fp.Status = Status.Open

            ' 2. Create product deposit
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

            ' 3. Add import transfers between deposits until product deposit
            Dim transferSubGrup = ctx.SubGroups.Where(Function(x) x.AccessKey = SubGroup.TransferAccessKey).First()
            ctx.SubGroups.Attach(transferSubGrup)

            ' Find existing financial move
            If fp.RegistrationDate.HasValue AndAlso fp.RegistrationDate.Value.Year = Today.Year Then
                If Not ctx.JournalEntries.Any(Function(x) x.BaseObjectName = NameOf(FinancialProduct) AndAlso x.BaseObjectID = fp.ID) Then
                    ' Add journal entries
                    ' 1/2 - Move base to deposit
                    If Not IsEmpty(fp.BaseDeposit) Then
                        ' Out qtty
                        Dim jeOUT12 As New JournalEntry()
                        jeOUT12.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.BaseDeposit.Name, fp.Deposit.Name)
                        jeOUT12.EntryDate = fp.RegistrationDate.Value
                        jeOUT12.BaseObjectName = NameOf(FinancialProduct)
                        jeOUT12.BaseObjectID = fp.ID
                        jeOUT12.Import = -fp.BaseImport
                        jeOUT12.SubGroup = transferSubGrup
                        jeOUT12.Deposit = fp.BaseDeposit
                        '
                        ctx.JournalEntries.Add(jeOUT12)

                        ' In qtty
                        Dim jeIN12 As New JournalEntry()
                        jeIN12.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.BaseDeposit.Name, fp.Deposit.Name)
                        jeIN12.EntryDate = fp.RegistrationDate.Value
                        jeIN12.BaseObjectName = NameOf(FinancialProduct)
                        jeIN12.BaseObjectID = fp.ID
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
                    jeOUT22.BaseObjectName = NameOf(FinancialProduct)
                    jeOUT22.BaseObjectID = fp.ID
                    jeOUT22.Import = -fp.BaseImport
                    jeOUT22.SubGroup = transferSubGrup
                    jeOUT22.Deposit = fp.Deposit
                    '
                    ctx.JournalEntries.Add(jeOUT22)

                    ' In qtty
                    Dim jeIN22 As New JournalEntry()
                    jeIN22.Concept = String.Format(Locate("{0}. Traspàs del dipòsit {1} al dipòsit {2}.", CAT), fp.Name, fp.Deposit.Name, fp.ProductDeposit.Name)
                    jeIN22.EntryDate = fp.RegistrationDate.Value
                    jeIN22.BaseObjectName = NameOf(FinancialProduct)
                    jeIN22.BaseObjectID = fp.ID
                    jeIN22.Import = fp.BaseImport
                    jeIN22.SubGroup = transferSubGrup
                    jeIN22.Deposit = fp.ProductDeposit
                    '
                    ctx.JournalEntries.Add(jeIN22)

                End If

            End If

            ' 4. Change status of cashflow entries to OPEN

            For Each entry As CashFlowEntry In From xentry As CashFlowEntry In ctx.CashFlowEntries
                                               Where xentry.Status = Status.Pending
                entry.Status = Status.Open
            Next

            ctx.SaveChanges()

        End Using

    End Sub

    ''' <summary>
    ''' 1. Change status to cancel
    ''' 2. Cancel journal entries
    ''' 3. Change cashflow entries to cancel
    ''' </summary>
    ''' <param name="ID"></param>
    Public Shared Sub CancelProduct(ID As Integer)

        Using ctx As New CashFlowContext()

            Dim fp = GetDBQuery(ctx).Where(Function(x) x.ID = ID).First()

            '  1. Change status to cancel
            If fp.Status <> Status.Open Then
                Throw New Exception(Locate("Només es poden cancel·lar productes en estat obert.", CAT))
            End If
            '
            fp.Status = Status.Cancelled

            ' 2. Cancel journal entries
            ' Check if exists any journal entry out of current fiscal year
            Dim existsJE = From entry In ctx.JournalEntries
                           Where entry.CancelDate IsNot Nothing _
                           AndAlso entry.BaseObjectID = fp.ID _
                           AndAlso entry.BaseObjectName = NameOf(FinancialProduct) _
                           AndAlso entry.FiscalYear IsNot Nothing

            If existsJE.Any() Then
                Throw New Exception(Locate("No es poden cancel·lar productes amb assentaments fora de l'exercici actual.", CAT))
            End If

            For Each entry As JournalEntry In From xEntry In ctx.JournalEntries
                                              Where 1 = 1 AndAlso
                                                  xEntry.CancelDate IsNot Nothing AndAlso
                                                  xEntry.BaseObjectID = fp.ID AndAlso
                                                  xEntry.BaseObjectName = NameOf(FinancialProduct)
                entry.CancelDate = Now
            Next

            ' 3. Change cashflow entries to cancel
            For Each entry As CashFlowEntry In From xEntry In ctx.CashFlowEntries
                                               Where 1 = 1 AndAlso
                                                   xEntry.FinancialProduct.ID = fp.ID AndAlso
                                                   xEntry.Status <> Status.Cancelled
                entry.Status = Status.Cancelled
                entry.CancelDate = Now
            Next


            ctx.SaveChanges()

        End Using

    End Sub

    ''' <summary>
    ''' 1. Change status to close
    ''' 3. Change cashflow entries to close
    ''' </summary>
    ''' <param name="ID"></param>
    Public Shared Sub CloseProduct(ID As Integer)

        Using ctx As New CashFlowContext()

            Dim fp = GetDBQuery(ctx).Where(Function(x) x.ID = ID).First()

            '  1. Change status to cancel
            If fp.Status <> Status.Open Then
                Throw New Exception(Locate("Només es poden tancar productes en estat obert.", CAT))
            End If
            '
            fp.Status = Status.Close

            ' 2. Change cashflow entries to close
            For Each entry As CashFlowEntry In From xEntry In ctx.CashFlowEntries
                                               Where 1 = 1 AndAlso
                                                   xEntry.FinancialProduct.ID = fp.ID AndAlso
                                                   xEntry.Status <> Status.Close AndAlso
                                                   xEntry.Status <> Status.Cancelled

                If entry.Status = Status.Open Then
                    If IsEmpty(entry.ToDate) Then
                        entry.ToDate = Now
                    End If
                    entry.Status = Status.Close
                Else
                    entry.Status = Status.Cancelled
                    entry.CancelDate = Now
                End If

            Next


            ctx.SaveChanges()

        End Using

    End Sub

End Class