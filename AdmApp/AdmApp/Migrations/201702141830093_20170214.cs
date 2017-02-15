namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170214 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pendiente", "Inquilino_ID", "dbo.Inquilino");
            DropForeignKey("dbo.Pendiente", "Locador_ID", "dbo.Locador");
            DropIndex("dbo.Pendiente", new[] { "Inquilino_ID" });
            DropIndex("dbo.Pendiente", new[] { "Locador_ID" });
            RenameColumn(table: "dbo.Pendiente", name: "Inquilino_ID", newName: "InquilinoID");
            RenameColumn(table: "dbo.Pendiente", name: "Locador_ID", newName: "LocadorID");
            AlterColumn("dbo.Pendiente", "InquilinoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pendiente", "LocadorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pendiente", "LocadorID");
            CreateIndex("dbo.Pendiente", "InquilinoID");
            AddForeignKey("dbo.Pendiente", "InquilinoID", "dbo.Inquilino", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Pendiente", "LocadorID", "dbo.Locador", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pendiente", "LocadorID", "dbo.Locador");
            DropForeignKey("dbo.Pendiente", "InquilinoID", "dbo.Inquilino");
            DropIndex("dbo.Pendiente", new[] { "InquilinoID" });
            DropIndex("dbo.Pendiente", new[] { "LocadorID" });
            AlterColumn("dbo.Pendiente", "LocadorID", c => c.Int());
            AlterColumn("dbo.Pendiente", "InquilinoID", c => c.Int());
            RenameColumn(table: "dbo.Pendiente", name: "LocadorID", newName: "Locador_ID");
            RenameColumn(table: "dbo.Pendiente", name: "InquilinoID", newName: "Inquilino_ID");
            CreateIndex("dbo.Pendiente", "Locador_ID");
            CreateIndex("dbo.Pendiente", "Inquilino_ID");
            AddForeignKey("dbo.Pendiente", "Locador_ID", "dbo.Locador", "ID");
            AddForeignKey("dbo.Pendiente", "Inquilino_ID", "dbo.Inquilino", "ID");
        }
    }
}
