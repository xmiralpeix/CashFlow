Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M005
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.JournalEntries", "ExternalID", Function(c) c.String(maxLength:=100))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.JournalEntries", "ExternalID")
        End Sub
    End Class
End Namespace
