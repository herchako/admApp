namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _170120b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino");
            DropPrimaryKey("dbo.Inquilino");
            AlterColumn("dbo.Inquilino", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Inquilino", "ID");
            AddForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino");
            DropPrimaryKey("dbo.Inquilino");
            AlterColumn("dbo.Inquilino", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Inquilino", "ID");
            AddForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino", "ID", cascadeDelete: true);
        }
    }
}
