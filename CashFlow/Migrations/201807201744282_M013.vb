Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M013
        Inherits DbMigration
    
        Public Overrides Sub Up()
            'AddColumn("dbo.JournalEntryTemplatev2", "FinancialProduct_ID", Function(c) c.Int())
            'CreateIndex("dbo.JournalEntryTemplatev2", "FinancialProduct_ID")
            'AddForeignKey("dbo.JournalEntryTemplatev2", "FinancialProduct_ID", "dbo.FinancialProducts", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.JournalEntryTemplatev2", "FinancialProduct_ID", "dbo.FinancialProducts")
            DropIndex("dbo.JournalEntryTemplatev2", New String() { "FinancialProduct_ID" })
            DropColumn("dbo.JournalEntryTemplatev2", "FinancialProduct_ID")
        End Sub
    End Class
End Namespace
