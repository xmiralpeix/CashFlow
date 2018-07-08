Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M002
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropIndex("dbo.SubGroups", New String() { "AccessKey" })
            AlterColumn("dbo.SubGroups", "AccessKey", Function(c) c.String(maxLength := 25))
            CreateIndex("dbo.SubGroups", "AccessKey", unique := True)
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.SubGroups", New String() { "AccessKey" })
            AlterColumn("dbo.SubGroups", "AccessKey", Function(c) c.String(maxLength := 10))
            CreateIndex("dbo.SubGroups", "AccessKey", unique := True)
        End Sub
    End Class
End Namespace
