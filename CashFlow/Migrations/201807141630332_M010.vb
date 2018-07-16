Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M010
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.FinancialProducts", "Owner_ID", Function(c) c.Int())
            CreateIndex("dbo.FinancialProducts", "Owner_ID")
            AddForeignKey("dbo.FinancialProducts", "Owner_ID", "dbo.Owners", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.FinancialProducts", "Owner_ID", "dbo.Owners")
            DropIndex("dbo.FinancialProducts", New String() { "Owner_ID" })
            DropColumn("dbo.FinancialProducts", "Owner_ID")
        End Sub
    End Class
End Namespace
