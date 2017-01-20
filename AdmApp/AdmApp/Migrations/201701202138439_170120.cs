namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _170120 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inquilino", "Email", c => c.String());
            AddColumn("dbo.Inquilino", "Telefono", c => c.String());
            AddColumn("dbo.Inquilino", "Celular", c => c.String());
            AddColumn("dbo.Inquilino", "Direccion", c => c.String());
            AddColumn("dbo.Inquilino", "Observaciones", c => c.String());
            AddColumn("dbo.Locador", "Direccion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locador", "Direccion");
            DropColumn("dbo.Inquilino", "Observaciones");
            DropColumn("dbo.Inquilino", "Direccion");
            DropColumn("dbo.Inquilino", "Celular");
            DropColumn("dbo.Inquilino", "Telefono");
            DropColumn("dbo.Inquilino", "Email");
        }
    }
}
