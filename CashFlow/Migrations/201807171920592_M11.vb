Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M11
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateIndex("dbo.Activities", "Name", unique := True)
            CreateIndex("dbo.Deposits", "Name", unique := True)
            CreateIndex("dbo.FinancialEntities", "Name", unique := True)
            CreateIndex("dbo.Owners", "Name", unique := True)
            CreateIndex("dbo.Groups", "Name", unique := True)
            CreateIndex("dbo.FinancialProducts", "Name", unique := True)
            CreateIndex("dbo.Evaluations", "Name", unique := True)
            CreateIndex("dbo.ExternalApplications", "Name", unique := True)
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.ExternalApplications", New String() { "Name" })
            DropIndex("dbo.Evaluations", New String() { "Name" })
            DropIndex("dbo.FinancialProducts", New String() { "Name" })
            DropIndex("dbo.Groups", New String() { "Name" })
            DropIndex("dbo.Owners", New String() { "Name" })
            DropIndex("dbo.FinancialEntities", New String() { "Name" })
            DropIndex("dbo.Deposits", New String() { "Name" })
            DropIndex("dbo.Activities", New String() { "Name" })
        End Sub
    End Class
End Namespace
