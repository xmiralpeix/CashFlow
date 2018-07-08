Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M006
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.FinancialProducts", "ProductDeposit_ID", Function(c) c.Int())
            CreateIndex("dbo.FinancialProducts", "ProductDeposit_ID")
            AddForeignKey("dbo.FinancialProducts", "ProductDeposit_ID", "dbo.Deposits", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.FinancialProducts", "ProductDeposit_ID", "dbo.Deposits")
            DropIndex("dbo.FinancialProducts", New String() { "ProductDeposit_ID" })
            DropColumn("dbo.FinancialProducts", "ProductDeposit_ID")
        End Sub
    End Class
End Namespace
