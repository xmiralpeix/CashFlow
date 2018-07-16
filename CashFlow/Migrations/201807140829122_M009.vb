Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M009
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.CashFlowEntries", "Status", Function(c) c.Int(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.CashFlowEntries", "Status")
        End Sub
    End Class
End Namespace
