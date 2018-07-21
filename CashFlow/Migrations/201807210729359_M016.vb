Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M016
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.DBFileInfoes", "Extension", Function(c) c.String(maxLength := 4))
        End Sub
        
        Public Overrides Sub Down()
            'AlterColumn("dbo.DBFileInfoes", "Extension", Function(c) c.String(maxLength := 3))
        End Sub
    End Class
End Namespace
