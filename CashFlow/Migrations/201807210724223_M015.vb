Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M015
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ObjectFiles",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .TableName = c.String(maxLength := 100),
                        .PrimaryKey = c.Int(nullable := False),
                        .DBFileInfo_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.DBFileInfoes", Function(t) t.DBFileInfo_ID) _
                .Index(Function(t) t.DBFileInfo_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ObjectFiles", "DBFileInfo_ID", "dbo.DBFileInfoes")
            DropIndex("dbo.ObjectFiles", New String() { "DBFileInfo_ID" })
            DropTable("dbo.ObjectFiles")
        End Sub
    End Class
End Namespace
