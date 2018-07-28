Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M019
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.PurchaseInvoices",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .CreationDate = c.DateTime(nullable := False),
                        .NumAtCard = c.String(),
                        .Concept = c.String(maxLength := 100),
                        .DocDate = c.DateTime(nullable := False),
                        .LicTradNum = c.String(),
                        .Import = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Status = c.Int(nullable := False),
                        .Deposit_ID = c.Int(),
                        .Owner_ID = c.Int(),
                        .SubGroup_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.Deposit_ID) _
                .ForeignKey("dbo.Owners", Function(t) t.Owner_ID) _
                .ForeignKey("dbo.SubGroups", Function(t) t.SubGroup_ID) _
                .Index(Function(t) t.Deposit_ID) _
                .Index(Function(t) t.Owner_ID) _
                .Index(Function(t) t.SubGroup_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.PurchaseInvoices", "SubGroup_ID", "dbo.SubGroups")
            DropForeignKey("dbo.PurchaseInvoices", "Owner_ID", "dbo.Owners")
            DropForeignKey("dbo.PurchaseInvoices", "Deposit_ID", "dbo.Deposits")
            DropIndex("dbo.PurchaseInvoices", New String() { "SubGroup_ID" })
            DropIndex("dbo.PurchaseInvoices", New String() { "Owner_ID" })
            DropIndex("dbo.PurchaseInvoices", New String() { "Deposit_ID" })
            DropTable("dbo.PurchaseInvoices")
        End Sub
    End Class
End Namespace
