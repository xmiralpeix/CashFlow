Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class DeleteFields
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.FinancialProducts", "RegistrationDate", Function(c) c.DateTime())
            DropColumn("dbo.JournalEntries", "DocDate")
            DropColumn("dbo.JournalEntries", "ExtractDate")
            DropColumn("dbo.JournalEntryTemplates", "DocDate")
            DropColumn("dbo.JournalEntryTemplates", "ExtractDate")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.JournalEntryTemplates", "ExtractDate", Function(c) c.DateTime())
            AddColumn("dbo.JournalEntryTemplates", "DocDate", Function(c) c.DateTime())
            AddColumn("dbo.JournalEntries", "ExtractDate", Function(c) c.DateTime())
            AddColumn("dbo.JournalEntries", "DocDate", Function(c) c.DateTime())
            DropColumn("dbo.FinancialProducts", "RegistrationDate")
        End Sub
    End Class
End Namespace
