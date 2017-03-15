namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170315 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Ocupacion = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Direccion = c.String(),
                        Observaciones = c.String(),
                        FechaDeAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacto");
        }
    }
}
