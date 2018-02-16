Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _021318_001
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.JournalEntryTemplates", "Activity_ID", Function(c) c.Int())
            CreateIndex("dbo.JournalEntryTemplates", "Activity_ID")
            AddForeignKey("dbo.JournalEntryTemplates", "Activity_ID", "dbo.Activities", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.JournalEntryTemplates", "Activity_ID", "dbo.Activities")
            DropIndex("dbo.JournalEntryTemplates", New String() { "Activity_ID" })
            DropColumn("dbo.JournalEntryTemplates", "Activity_ID")
        End Sub
    End Class
End Namespace
