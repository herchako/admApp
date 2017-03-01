namespace AdmApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170215 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeriodoContrato", "Contrato_ID", "dbo.Contrato");
            DropForeignKey("dbo.Contrato", "Propiedad_ID", "dbo.Propiedad");
            DropIndex("dbo.Contrato", new[] { "Propiedad_ID" });
            DropIndex("dbo.PeriodoContrato", new[] { "Contrato_ID" });
            RenameColumn(table: "dbo.PeriodoContrato", name: "Contrato_ID", newName: "ContratoID");
            RenameColumn(table: "dbo.Contrato", name: "Propiedad_ID", newName: "PropiedadID");
            AlterColumn("dbo.Contrato", "PropiedadID", c => c.Int(nullable: false, defaultValue: 1));
            AlterColumn("dbo.PeriodoContrato", "ContratoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contrato", "PropiedadID");
            CreateIndex("dbo.PeriodoContrato", "ContratoID");
            AddForeignKey("dbo.PeriodoContrato", "ContratoID", "dbo.Contrato", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Contrato", "PropiedadID", "dbo.Propiedad", "ID", cascadeDelete: true);
        }

        
        public override void Down()
        {
            DropForeignKey("dbo.Contrato", "PropiedadID", "dbo.Propiedad");
            DropForeignKey("dbo.PeriodoContrato", "ContratoID", "dbo.Contrato");
            DropIndex("dbo.PeriodoContrato", new[] { "ContratoID" });
            DropIndex("dbo.Contrato", new[] { "PropiedadID" });
            AlterColumn("dbo.PeriodoContrato", "ContratoID", c => c.Int());
            AlterColumn("dbo.Contrato", "PropiedadID", c => c.Int());
            RenameColumn(table: "dbo.Contrato", name: "PropiedadID", newName: "Propiedad_ID");
            RenameColumn(table: "dbo.PeriodoContrato", name: "ContratoID", newName: "Contrato_ID");
            CreateIndex("dbo.PeriodoContrato", "Contrato_ID");
            CreateIndex("dbo.Contrato", "Propiedad_ID");
            AddForeignKey("dbo.Contrato", "Propiedad_ID", "dbo.Propiedad", "ID");
            AddForeignKey("dbo.PeriodoContrato", "Contrato_ID", "dbo.Contrato", "ID");
            AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1)); 
        }
    }
}
