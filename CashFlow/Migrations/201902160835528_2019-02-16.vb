Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _20190216
        Inherits DbMigration
    
        Public Overrides Sub Up()
            'DropForeignKey("dbo.JournalEntryTemplates", "Deposit_ID", "dbo.Deposits")
            'DropForeignKey("dbo.JournalEntryTemplates", "SubGroup_ID", "dbo.SubGroups")
            'DropForeignKey("dbo.JournalEntryTemplates", "Activity_ID", "dbo.Activities")
            DropForeignKey("dbo.JournalEntryTemplatev2", "Deposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.JournalEntryTemplatev2", "FinancialProduct_ID", "dbo.FinancialProducts")
            DropForeignKey("dbo.JournalEntryTemplatev2", "SubGroup_ID", "dbo.SubGroups")
            'DropIndex("dbo.JournalEntryTemplates", New String() { "Deposit_ID" })
            'DropIndex("dbo.JournalEntryTemplates", New String() { "SubGroup_ID" })
            'DropIndex("dbo.JournalEntryTemplates", New String() { "Activity_ID" })
            DropIndex("dbo.JournalEntryTemplatev2", New String() { "Deposit_ID" })
            DropIndex("dbo.JournalEntryTemplatev2", New String() { "FinancialProduct_ID" })
            DropIndex("dbo.JournalEntryTemplatev2", New String() { "SubGroup_ID" })
            ' DropTable("dbo.JournalEntryTemplates")
            DropTable("dbo.JournalEntryTemplatev2")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.JournalEntryTemplatev2",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .EntryDate = c.DateTime(),
                        .Concept = c.String(),
                        .Import = c.Double(nullable := False),
                        .Deposit_ID = c.Int(),
                        .FinancialProduct_ID = c.Int(),
                        .SubGroup_ID = c.Int()
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
                .PrimaryKey(Function(t) t.ID)
            
            CreateIndex("dbo.JournalEntryTemplatev2", "SubGroup_ID")
            CreateIndex("dbo.JournalEntryTemplatev2", "FinancialProduct_ID")
            CreateIndex("dbo.JournalEntryTemplatev2", "Deposit_ID")
            CreateIndex("dbo.JournalEntryTemplates", "Activity_ID")
            CreateIndex("dbo.JournalEntryTemplates", "SubGroup_ID")
            CreateIndex("dbo.JournalEntryTemplates", "Deposit_ID")
            AddForeignKey("dbo.JournalEntryTemplatev2", "SubGroup_ID", "dbo.SubGroups", "ID")
            AddForeignKey("dbo.JournalEntryTemplatev2", "FinancialProduct_ID", "dbo.FinancialProducts", "ID")
            AddForeignKey("dbo.JournalEntryTemplatev2", "Deposit_ID", "dbo.Deposits", "ID")
            AddForeignKey("dbo.JournalEntryTemplates", "Activity_ID", "dbo.Activities", "ID")
            AddForeignKey("dbo.JournalEntryTemplates", "SubGroup_ID", "dbo.SubGroups", "ID")
            AddForeignKey("dbo.JournalEntryTemplates", "Deposit_ID", "dbo.Deposits", "ID")
        End Sub
    End Class
End Namespace
