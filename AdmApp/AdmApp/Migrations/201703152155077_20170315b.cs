namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170315b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pendiente", "Estado", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pendiente", "Estado");
        }
    }
}
