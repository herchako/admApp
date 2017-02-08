namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170206b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contrato", "Observaciones", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contrato", "Observaciones");
        }
    }
}
