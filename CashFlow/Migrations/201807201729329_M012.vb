Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class M012
        Inherits DbMigration
    
        Public Overrides Sub Up()
            ' DropIndex("dbo.JournalEntryTemplates", New String() { "Name" })
            ' DropPrimaryKey("dbo.JournalEntryTemplates")
            CreateTable(
                "dbo.JournalEntryTemplatev2",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 100),
                        .EntryDate = c.DateTime(),
                        .Concept = c.String(),
                        .Import = c.Double(nullable := False),
                        .Deposit_ID = c.Int(),
                        .SubGroup_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Deposits", Function(t) t.Deposit_ID) _
                .ForeignKey("dbo.SubGroups", Function(t) t.SubGroup_ID) _
                .Index(Function(t) t.Deposit_ID) _
                .Index(Function(t) t.SubGroup_ID)

            ' AlterColumn("dbo.JournalEntryTemplates", "ID", Function(c) c.String(nullable := False, maxLength := 128))
            ' AlterColumn("dbo.JournalEntryTemplates", "Name", Function(c) c.String())
            'AddPrimaryKey("dbo.JournalEntryTemplates", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.JournalEntryTemplatev2", "SubGroup_ID", "dbo.SubGroups")
            DropForeignKey("dbo.JournalEntryTemplatev2", "Deposit_ID", "dbo.Deposits")
            DropIndex("dbo.JournalEntryTemplatev2", New String() { "SubGroup_ID" })
            DropIndex("dbo.JournalEntryTemplatev2", New String() { "Deposit_ID" })
            DropPrimaryKey("dbo.JournalEntryTemplates")
            AlterColumn("dbo.JournalEntryTemplates", "Name", Function(c) c.String(maxLength := 100))
            AlterColumn("dbo.JournalEntryTemplates", "ID", Function(c) c.Int(nullable := False, identity := True))
            DropTable("dbo.JournalEntryTemplatev2")
            AddPrimaryKey("dbo.JournalEntryTemplates", "ID")
            CreateIndex("dbo.JournalEntryTemplates", "Name", unique := True)
        End Sub
    End Class
End Namespace
