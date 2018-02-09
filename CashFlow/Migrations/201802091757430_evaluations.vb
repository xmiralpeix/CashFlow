Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class evaluations
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Evaluations",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Points = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Evaluations")
        End Sub
    End Class
End Namespace
