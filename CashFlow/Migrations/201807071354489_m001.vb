Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class m001
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Activities",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .Name = c.String(maxLength:=100),
                        .RepeatPeriod = c.Int(nullable:=False),
                        .DayOfWeek = c.Int(nullable:=False),
                        .RepeatWeek = c.Int(nullable:=False),
                        .RepeatMonthDay = c.Int(),
                        .FromDate = c.DateTime(),
                        .ToDate = c.DateTime(),
                        .LinkedObjectName = c.String(),
                        .LinkedID = c.Int(),
                        .CancelDate = c.DateTime()
                    }) _
                .PrimaryKey(Function(t) t.ID)

            CreateTable(
                "dbo.JournalEntryTemplates",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .Name = c.String(),
                        .EntryDate = c.DateTime(),
                        .Concept = c.String(),
                        .Import = c.Double(nullable := False),
                        .Deposit_ID = c.Int(),
                        .SubGroup_ID = c.Int(),
                        .Activity_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.Deposit_ID) _
                .ForeignKey("dbo.SubGroups", Function(t) t.SubGroup_ID) _
                .ForeignKey("dbo.Activities", Function(t) t.Activity_ID) _
                .Index(Function(t) t.Deposit_ID) _
                .Index(Function(t) t.SubGroup_ID) _
                .Index(Function(t) t.Activity_ID)
            
            CreateTable(
                "dbo.Deposits",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .CreationDate = c.DateTime(nullable := False),
                        .CancelDate = c.DateTime(),
                        .IsCash = c.Boolean(nullable := False),
                        .FinancialEntity_ID = c.Int(),
                        .Owner_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.FinancialEntities", Function(t) t.FinancialEntity_ID) _
                .ForeignKey("dbo.Owners", Function(t) t.Owner_ID) _
                .Index(Function(t) t.FinancialEntity_ID) _
                .Index(Function(t) t.Owner_ID)
            
            CreateTable(
                "dbo.FinancialEntities",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .CancelDate = c.DateTime()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Owners",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.SubGroups",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .AccessKey = c.String(maxLength := 10),
                        .Name = c.String(maxLength := 100),
                        .CancelDate = c.DateTime(),
                        .Group_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Groups", Function(t) t.Group_ID) _
                .Index(Function(t) t.AccessKey, unique := True) _
                .Index(Function(t) t.Name, unique := True) _
                .Index(Function(t) t.Group_ID)
            
            CreateTable(
                "dbo.Groups",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .AccessKey = c.String(maxLength := 10),
                        .Name = c.String(maxLength := 100),
                        .CancelDate = c.DateTime()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .Index(Function(t) t.AccessKey, unique := True)
            
            CreateTable(
                "dbo.CashFlowEntries",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Concept = c.String(),
                        .CancelDate = c.DateTime(),
                        .FromDate = c.DateTime(),
                        .ToDate = c.DateTime(),
                        .IncomeImport = c.Double(nullable := False),
                        .ExpenseImport = c.Double(nullable := False),
                        .TotalAsset = c.Double(nullable := False),
                        .TotalLiability = c.Double(nullable := False),
                        .CashFlowGroup_ID = c.Int(),
                        .Owner_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.FinancialProductTypes", Function(t) t.CashFlowGroup_ID) _
                .ForeignKey("dbo.Owners", Function(t) t.Owner_ID) _
                .Index(Function(t) t.CashFlowGroup_ID) _
                .Index(Function(t) t.Owner_ID)
            
            CreateTable(
                "dbo.FinancialProductTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .SubGroup_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.SubGroups", Function(t) t.SubGroup_ID) _
                .Index(Function(t) t.SubGroup_ID)
            
            CreateTable(
                "dbo.CashFlowStatus",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .TotalIncome = c.Double(nullable := False),
                        .TotalExpenses = c.Double(nullable := False),
                        .PassiveIncome = c.Double(nullable := False),
                        .Cash = c.Double(nullable := False),
                        .PayDay = c.Double(nullable := False),
                        .StatusDate = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Evaluations",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .Points = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.ExternalApplications",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .ParentMenuID = c.String(maxLength := 30),
                        .ApplicationPath = c.String(maxLength := 254)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.FinancialProducts",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .Comments = c.String(unicode := false, storeType := "text"),
                        .CreationDate = c.DateTime(nullable := False),
                        .RegistrationDate = c.DateTime(),
                        .CancelDate = c.DateTime(),
                        .BaseImport = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .ResultComments = c.String(unicode := false, storeType := "text"),
                        .Status = c.Int(nullable := False),
                        .BaseDeposit_ID = c.Int(),
                        .CashFlowEntry_ID = c.Int(),
                        .Deposit_ID = c.Int(),
                        .Evaluation_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.BaseDeposit_ID) _
                .ForeignKey("dbo.CashFlowEntries", Function(t) t.CashFlowEntry_ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.Deposit_ID) _
                .ForeignKey("dbo.Evaluations", Function(t) t.Evaluation_ID) _
                .Index(Function(t) t.BaseDeposit_ID) _
                .Index(Function(t) t.CashFlowEntry_ID) _
                .Index(Function(t) t.Deposit_ID) _
                .Index(Function(t) t.Evaluation_ID)
            
            CreateTable(
                "dbo.JournalEntries",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .CreationDate = c.DateTime(nullable := False),
                        .EntryDate = c.DateTime(nullable := False),
                        .CancelDate = c.DateTime(),
                        .FiscalYear = c.Int(),
                        .Concept = c.String(),
                        .Import = c.Double(nullable := False),
                        .Validated = c.Boolean(nullable := False),
                        .Deposit_ID = c.Int(),
                        .FinancialProduct_ID = c.Int(),
                        .SubGroup_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.Deposit_ID) _
                .ForeignKey("dbo.FinancialProducts", Function(t) t.FinancialProduct_ID) _
                .ForeignKey("dbo.SubGroups", Function(t) t.SubGroup_ID) _
                .Index(Function(t) t.Deposit_ID) _
                .Index(Function(t) t.FinancialProduct_ID) _
                .Index(Function(t) t.SubGroup_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.JournalEntries", "SubGroup_ID", "dbo.SubGroups")
            DropForeignKey("dbo.JournalEntries", "FinancialProduct_ID", "dbo.FinancialProducts")
            DropForeignKey("dbo.JournalEntries", "Deposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.FinancialProducts", "Evaluation_ID", "dbo.Evaluations")
            DropForeignKey("dbo.FinancialProducts", "Deposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.FinancialProducts", "CashFlowEntry_ID", "dbo.CashFlowEntries")
            DropForeignKey("dbo.FinancialProducts", "BaseDeposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.CashFlowEntries", "Owner_ID", "dbo.Owners")
            DropForeignKey("dbo.CashFlowEntries", "CashFlowGroup_ID", "dbo.FinancialProductTypes")
            DropForeignKey("dbo.FinancialProductTypes", "SubGroup_ID", "dbo.SubGroups")
            DropForeignKey("dbo.JournalEntryTemplates", "Activity_ID", "dbo.Activities")
            DropForeignKey("dbo.JournalEntryTemplates", "SubGroup_ID", "dbo.SubGroups")
            DropForeignKey("dbo.SubGroups", "Group_ID", "dbo.Groups")
            DropForeignKey("dbo.JournalEntryTemplates", "Deposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.Deposits", "Owner_ID", "dbo.Owners")
            DropForeignKey("dbo.Deposits", "FinancialEntity_ID", "dbo.FinancialEntities")
            DropIndex("dbo.JournalEntries", New String() { "SubGroup_ID" })
            DropIndex("dbo.JournalEntries", New String() { "FinancialProduct_ID" })
            DropIndex("dbo.JournalEntries", New String() { "Deposit_ID" })
            DropIndex("dbo.FinancialProducts", New String() { "Evaluation_ID" })
            DropIndex("dbo.FinancialProducts", New String() { "Deposit_ID" })
            DropIndex("dbo.FinancialProducts", New String() { "CashFlowEntry_ID" })
            DropIndex("dbo.FinancialProducts", New String() { "BaseDeposit_ID" })
            DropIndex("dbo.FinancialProductTypes", New String() { "SubGroup_ID" })
            DropIndex("dbo.CashFlowEntries", New String() { "Owner_ID" })
            DropIndex("dbo.CashFlowEntries", New String() { "CashFlowGroup_ID" })
            DropIndex("dbo.Groups", New String() { "AccessKey" })
            DropIndex("dbo.SubGroups", New String() { "Group_ID" })
            DropIndex("dbo.SubGroups", New String() { "Name" })
            DropIndex("dbo.SubGroups", New String() { "AccessKey" })
            DropIndex("dbo.Deposits", New String() { "Owner_ID" })
            DropIndex("dbo.Deposits", New String() { "FinancialEntity_ID" })
            DropIndex("dbo.JournalEntryTemplates", New String() { "Activity_ID" })
            DropIndex("dbo.JournalEntryTemplates", New String() { "SubGroup_ID" })
            DropIndex("dbo.JournalEntryTemplates", New String() { "Deposit_ID" })
            DropTable("dbo.JournalEntries")
            DropTable("dbo.FinancialProducts")
            DropTable("dbo.ExternalApplications")
            DropTable("dbo.Evaluations")
            DropTable("dbo.CashFlowStatus")
            DropTable("dbo.FinancialProductTypes")
            DropTable("dbo.CashFlowEntries")
            DropTable("dbo.Groups")
            DropTable("dbo.SubGroups")
            DropTable("dbo.Owners")
            DropTable("dbo.FinancialEntities")
            DropTable("dbo.Deposits")
            DropTable("dbo.JournalEntryTemplates")
            DropTable("dbo.Activities")
        End Sub
    End Class
End Namespace
