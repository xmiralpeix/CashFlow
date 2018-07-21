Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M014
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.DBFileContents",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Content = c.Binary()
                    }) _
                .PrimaryKey(Function(t) t.ID)

            CreateTable(
                "dbo.DBFileInfoes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .Name = c.String(maxLength:=100),
                        .CreationDate = c.DateTime(nullable:=False),
                        .Comments = c.String(unicode:=False, storeType:="text"),
                        .Extension = c.String(maxLength:=3),
                        .Content_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.DBFileContents", Function(t) t.Content_ID) _
                .Index(Function(t) t.Name, unique:=True) _
                .Index(Function(t) t.Content_ID)

            CreateTable(
                "dbo.IPCs",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Value = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .FromDate = c.DateTime(nullable := False),
                        .ToDate = c.DateTime()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.DBFileInfoes", "Content_ID", "dbo.DBFileContents")
            DropIndex("dbo.DBFileInfoes", New String() { "Content_ID" })
            DropIndex("dbo.DBFileInfoes", New String() { "Name" })
            DropTable("dbo.IPCs")
            DropTable("dbo.DBFileInfoes")
            DropTable("dbo.DBFileContents")
        End Sub
    End Class
End Namespace
