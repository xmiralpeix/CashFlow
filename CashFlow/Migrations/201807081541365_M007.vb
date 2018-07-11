Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M007
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Deposits", "Name", Function(c) c.String(maxLength := 150))
        End Sub
        
        Public Overrides Sub Down()
            'AlterColumn("dbo.Deposits", "Name", Function(c) c.String(maxLength:=150))
        End Sub
    End Class
End Namespace
