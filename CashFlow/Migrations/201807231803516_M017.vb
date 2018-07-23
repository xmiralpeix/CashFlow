Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M017
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropIndex("dbo.DBFileInfoes", New String() { "Name" })
        End Sub
        
        Public Overrides Sub Down()
            CreateIndex("dbo.DBFileInfoes", "Name", unique := True)
        End Sub
    End Class
End Namespace
