namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170206 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino");
            DropForeignKey("dbo.Propiedad", "LocadorID", "dbo.Locador");
            DropIndex("dbo.Propiedad", new[] { "LocadorID" });
            DropIndex("dbo.Propiedad", new[] { "InquilinoID" });
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LocadorID = c.Int(nullable: false),
                        InquilinoID = c.Int(nullable: false),
                        Referencia = c.String(),
                        GarantiaNombre = c.String(),
                        GarantiaTelefono = c.String(),
                        Vencimiento = c.DateTime(nullable: false),
                        Propiedad_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Propiedad", t => t.Propiedad_ID)
                .Index(t => t.Propiedad_ID);
            
            CreateTable(
                "dbo.Pendiente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Referencia = c.String(),
                        Monto = c.String(),
                        FechaEmision = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        Inquilino_ID = c.Int(),
                        Locador_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inquilino", t => t.Inquilino_ID)
                .ForeignKey("dbo.Locador", t => t.Locador_ID)
                .Index(t => t.Inquilino_ID)
                .Index(t => t.Locador_ID);
            
            CreateTable(
                "dbo.PeriodoContrato",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Referencia = c.String(),
                        Monto = c.String(),
                        FechaComienzo = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Contrato_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contrato", t => t.Contrato_ID)
                .Index(t => t.Contrato_ID);
            
            CreateTable(
                "dbo.InquilinoContrato",
                c => new
                    {
                        Inquilino_ID = c.Int(nullable: false),
                        Contrato_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inquilino_ID, t.Contrato_ID })
                .ForeignKey("dbo.Inquilino", t => t.Inquilino_ID, cascadeDelete: true)
                .ForeignKey("dbo.Contrato", t => t.Contrato_ID, cascadeDelete: true)
                .Index(t => t.Inquilino_ID)
                .Index(t => t.Contrato_ID);
            
            CreateTable(
                "dbo.PropiedadLocador",
                c => new
                    {
                        Propiedad_ID = c.Int(nullable: false),
                        Locador_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Propiedad_ID, t.Locador_ID })
                .ForeignKey("dbo.Propiedad", t => t.Propiedad_ID, cascadeDelete: true)
                .ForeignKey("dbo.Locador", t => t.Locador_ID, cascadeDelete: true)
                .Index(t => t.Propiedad_ID)
                .Index(t => t.Locador_ID);
            
            AddColumn("dbo.Propiedad", "Observaciones", c => c.String());
            AddColumn("dbo.Locador", "Contrato_ID", c => c.Int());
            CreateIndex("dbo.Locador", "Contrato_ID");
            AddForeignKey("dbo.Locador", "Contrato_ID", "dbo.Contrato", "ID");
            DropColumn("dbo.Propiedad", "InquilinoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Propiedad", "InquilinoID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PeriodoContrato", "Contrato_ID", "dbo.Contrato");
            DropForeignKey("dbo.Locador", "Contrato_ID", "dbo.Contrato");
            DropForeignKey("dbo.PropiedadLocador", "Locador_ID", "dbo.Locador");
            DropForeignKey("dbo.PropiedadLocador", "Propiedad_ID", "dbo.Propiedad");
            DropForeignKey("dbo.Contrato", "Propiedad_ID", "dbo.Propiedad");
            DropForeignKey("dbo.Pendiente", "Locador_ID", "dbo.Locador");
            DropForeignKey("dbo.Pendiente", "Inquilino_ID", "dbo.Inquilino");
            DropForeignKey("dbo.InquilinoContrato", "Contrato_ID", "dbo.Contrato");
            DropForeignKey("dbo.InquilinoContrato", "Inquilino_ID", "dbo.Inquilino");
            DropIndex("dbo.PropiedadLocador", new[] { "Locador_ID" });
            DropIndex("dbo.PropiedadLocador", new[] { "Propiedad_ID" });
            DropIndex("dbo.InquilinoContrato", new[] { "Contrato_ID" });
            DropIndex("dbo.InquilinoContrato", new[] { "Inquilino_ID" });
            DropIndex("dbo.PeriodoContrato", new[] { "Contrato_ID" });
            DropIndex("dbo.Locador", new[] { "Contrato_ID" });
            DropIndex("dbo.Pendiente", new[] { "Locador_ID" });
            DropIndex("dbo.Pendiente", new[] { "Inquilino_ID" });
            DropIndex("dbo.Contrato", new[] { "Propiedad_ID" });
            DropColumn("dbo.Locador", "Contrato_ID");
            DropColumn("dbo.Propiedad", "Observaciones");
            DropTable("dbo.PropiedadLocador");
            DropTable("dbo.InquilinoContrato");
            DropTable("dbo.PeriodoContrato");
            DropTable("dbo.Pendiente");
            DropTable("dbo.Contrato");
            CreateIndex("dbo.Propiedad", "InquilinoID");
            CreateIndex("dbo.Propiedad", "LocadorID");
            AddForeignKey("dbo.Propiedad", "LocadorID", "dbo.Locador", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Propiedad", "InquilinoID", "dbo.Inquilino", "ID", cascadeDelete: true);
        }
    }
}
