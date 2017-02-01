namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inquilino",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Direccion = c.String(),
                        Observaciones = c.String(),
                        FechaDeAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Propiedad",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LocadorID = c.Int(nullable: false),
                        InquilinoID = c.Int(nullable: false),
                        Calle = c.String(),
                        Altura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inquilino", t => t.InquilinoID, cascadeDelete: true)
                .ForeignKey("dbo.Locador", t => t.LocadorID, cascadeDelete: true)
                .Index(t => t.LocadorID)
                .Index(t => t.InquilinoID);
            
            CreateTable(
                "dbo.Locador",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
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
            DropForeignKey("dbo.Propiedad", "LocadorID", "dbo.Locador");
            DropForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino");
            DropIndex("dbo.Propiedad", new[] { "InquilinoID" });
            DropIndex("dbo.Propiedad", new[] { "LocadorID" });
            DropTable("dbo.Locador");
            DropTable("dbo.Propiedad");
            DropTable("dbo.Inquilino");
        }
    }
}
