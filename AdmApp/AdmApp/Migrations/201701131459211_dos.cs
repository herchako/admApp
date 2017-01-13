namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locador", "Telefono2", c => c.String());
            AddColumn("dbo.Locador", "Celular", c => c.String());
            AddColumn("dbo.Locador", "Observaciones", c => c.String());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locador", "Telefono2", c => c.String());
            AddColumn("dbo.Locador", "Celular", c => c.String());
            AddColumn("dbo.Locador", "Observaciones", c => c.String());
        }
    }
}
