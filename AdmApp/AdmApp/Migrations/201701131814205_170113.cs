namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _170113 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locador", "Telefono2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locador", "Telefono2", c => c.String());
        }
    }
}
