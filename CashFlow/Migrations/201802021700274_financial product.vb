Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class financialproduct
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.FinancialProducts", "Comments", Function(c) c.String(unicode := false, storeType := "text"))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.FinancialProducts", "Comments", Function(c) c.String())
        End Sub
    End Class
End Namespace
