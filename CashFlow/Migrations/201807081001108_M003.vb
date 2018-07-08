Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M003
        Inherits DbMigration

        Public Overrides Sub Up()

            DropForeignKey("dbo.FinancialProductTypes", "SubGroup_ID", "dbo.SubGroups")
            DropForeignKey("dbo.FinancialProducts", "CashFlowEntry_ID", "dbo.CashFlowEntries")
            DropIndex("dbo.FinancialProductTypes", New String() {"SubGroup_ID"})
            DropIndex("dbo.FinancialProducts", New String() {"CashFlowEntry_ID"})

            CreateTable(
                "dbo.CashFlowGroups",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .Name = c.String(maxLength:=100),
                        .QuarterZone = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.ID)

            AddColumn("dbo.CashFlowEntries", "Import", Function(c) c.Decimal(nullable:=False, precision:=18, scale:=2))
            AddColumn("dbo.CashFlowEntries", "FinancialProduct_ID", Function(c) c.Int())
            CreateIndex("dbo.CashFlowEntries", "FinancialProduct_ID")
            AddForeignKey("dbo.CashFlowEntries", "FinancialProduct_ID", "dbo.FinancialProducts", "ID")
            DropColumn("dbo.CashFlowEntries", "IncomeImport")
            DropColumn("dbo.CashFlowEntries", "ExpenseImport")
            DropColumn("dbo.CashFlowEntries", "TotalAsset")
            DropColumn("dbo.CashFlowEntries", "TotalLiability")
            DropColumn("dbo.FinancialProducts", "CashFlowEntry_ID")
            DropTable("dbo.FinancialProductTypes")
        End Sub

        Public Overrides Sub Down()
            CreateTable(
                "dbo.FinancialProductTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .SubGroup_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.FinancialProducts", "CashFlowEntry_ID", Function(c) c.Int())
            AddColumn("dbo.CashFlowEntries", "TotalLiability", Function(c) c.Double(nullable := False))
            AddColumn("dbo.CashFlowEntries", "TotalAsset", Function(c) c.Double(nullable := False))
            AddColumn("dbo.CashFlowEntries", "ExpenseImport", Function(c) c.Double(nullable := False))
            AddColumn("dbo.CashFlowEntries", "IncomeImport", Function(c) c.Double(nullable := False))
            DropForeignKey("dbo.CashFlowEntries", "FinancialProduct_ID", "dbo.FinancialProducts")
            DropIndex("dbo.CashFlowEntries", New String() { "FinancialProduct_ID" })
            DropColumn("dbo.CashFlowEntries", "FinancialProduct_ID")
            DropColumn("dbo.CashFlowEntries", "Import")
            DropTable("dbo.CashFlowGroups")
            CreateIndex("dbo.FinancialProducts", "CashFlowEntry_ID")
            CreateIndex("dbo.FinancialProductTypes", "SubGroup_ID")
            AddForeignKey("dbo.FinancialProducts", "CashFlowEntry_ID", "dbo.CashFlowEntries", "ID")
            AddForeignKey("dbo.FinancialProductTypes", "SubGroup_ID", "dbo.SubGroups", "ID")
        End Sub
    End Class
End Namespace
