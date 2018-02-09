Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class evaluations_2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.FinancialProducts", "ResultComments", Function(c) c.String(unicode := false, storeType := "text"))
            AddColumn("dbo.FinancialProducts", "Evaluation_ID", Function(c) c.Int())
            AlterColumn("dbo.Activities", "Name", Function(c) c.String(maxLength := 100))
            AlterColumn("dbo.Evaluations", "Name", Function(c) c.String(maxLength := 100))
            CreateIndex("dbo.FinancialProducts", "Evaluation_ID")
            AddForeignKey("dbo.FinancialProducts", "Evaluation_ID", "dbo.Evaluations", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.FinancialProducts", "Evaluation_ID", "dbo.Evaluations")
            DropIndex("dbo.FinancialProducts", New String() { "Evaluation_ID" })
            AlterColumn("dbo.Evaluations", "Name", Function(c) c.String())
            AlterColumn("dbo.Activities", "Name", Function(c) c.String())
            DropColumn("dbo.FinancialProducts", "Evaluation_ID")
            DropColumn("dbo.FinancialProducts", "ResultComments")
        End Sub
    End Class
End Namespace
