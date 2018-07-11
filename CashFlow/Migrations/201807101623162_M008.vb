Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M008
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.CashFlowEntries", "CashFlowGroup_ID", "dbo.CashFlowGroups")
            DropIndex("dbo.CashFlowEntries", New String() { "CashFlowGroup_ID" })
            AddColumn("dbo.CashFlowEntries", "IncomeImport", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.CashFlowEntries", "ExpensesImport", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.CashFlowEntries", "AssetsImport", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.CashFlowEntries", "LiabilitiesImport", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            DropColumn("dbo.CashFlowEntries", "Import")
            ' DropColumn("dbo.CashFlowEntries", "CashFlowGroup_ID")
            DropTable("dbo.CashFlowGroups")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.CashFlowGroups",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .QuarterZone = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.CashFlowEntries", "CashFlowGroup_ID", Function(c) c.Int())
            AddColumn("dbo.CashFlowEntries", "Import", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            DropColumn("dbo.CashFlowEntries", "LiabilitiesImport")
            DropColumn("dbo.CashFlowEntries", "AssetsImport")
            DropColumn("dbo.CashFlowEntries", "ExpensesImport")
            DropColumn("dbo.CashFlowEntries", "IncomeImport")
            CreateIndex("dbo.CashFlowEntries", "CashFlowGroup_ID")
            AddForeignKey("dbo.CashFlowEntries", "CashFlowGroup_ID", "dbo.CashFlowGroups", "ID")
        End Sub
    End Class
End Namespace
