Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M018
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.JournalEntries", "FinancialProduct_ID", "dbo.FinancialProducts")
            DropIndex("dbo.JournalEntries", New String() { "FinancialProduct_ID" })
            CreateTable(
                "dbo.MontlyReceipts",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .CreationDate = c.DateTime(nullable := False),
                        .Status = c.Int(nullable := False),
                        .Import = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Comments = c.String(unicode := false, storeType := "text"),
                        .Deposit_ID = c.Int(),
                        .Owner_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.Deposit_ID) _
                .ForeignKey("dbo.Owners", Function(t) t.Owner_ID) _
                .Index(Function(t) t.Deposit_ID) _
                .Index(Function(t) t.Owner_ID)
            
            AddColumn("dbo.JournalEntries", "BaseObjectName", Function(c) c.String())
            AddColumn("dbo.JournalEntries", "BaseObjectID", Function(c) c.Int(nullable := False))
            DropColumn("dbo.JournalEntries", "FinancialProduct_ID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.JournalEntries", "FinancialProduct_ID", Function(c) c.Int())
            DropForeignKey("dbo.MontlyReceipts", "Owner_ID", "dbo.Owners")
            DropForeignKey("dbo.MontlyReceipts", "Deposit_ID", "dbo.Deposits")
            DropIndex("dbo.MontlyReceipts", New String() { "Owner_ID" })
            DropIndex("dbo.MontlyReceipts", New String() { "Deposit_ID" })
            DropColumn("dbo.JournalEntries", "BaseObjectID")
            DropColumn("dbo.JournalEntries", "BaseObjectName")
            DropTable("dbo.MontlyReceipts")
            CreateIndex("dbo.JournalEntries", "FinancialProduct_ID")
            AddForeignKey("dbo.JournalEntries", "FinancialProduct_ID", "dbo.FinancialProducts", "ID")
        End Sub
    End Class
End Namespace
