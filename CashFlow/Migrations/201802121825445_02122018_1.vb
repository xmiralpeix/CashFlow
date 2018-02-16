Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class _02122018_1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.FinancialProducts", "SubGroup_ID", Function(c) c.Int())
            CreateIndex("dbo.FinancialProducts", "SubGroup_ID")
            AddForeignKey("dbo.FinancialProducts", "SubGroup_ID", "dbo.SubGroups", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.FinancialProducts", "SubGroup_ID", "dbo.SubGroups")
            DropIndex("dbo.FinancialProducts", New String() { "SubGroup_ID" })
            DropColumn("dbo.FinancialProducts", "SubGroup_ID")
        End Sub
    End Class
End Namespace
