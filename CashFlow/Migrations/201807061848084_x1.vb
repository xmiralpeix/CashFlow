Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class x1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.JournalEntries", "FinancialProduct_ID", Function(c) c.Int())
            CreateIndex("dbo.JournalEntries", "FinancialProduct_ID")
            AddForeignKey("dbo.JournalEntries", "FinancialProduct_ID", "dbo.FinancialProducts", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.JournalEntries", "FinancialProduct_ID", "dbo.FinancialProducts")
            DropIndex("dbo.JournalEntries", New String() { "FinancialProduct_ID" })
            DropColumn("dbo.JournalEntries", "FinancialProduct_ID")
        End Sub
    End Class
End Namespace
