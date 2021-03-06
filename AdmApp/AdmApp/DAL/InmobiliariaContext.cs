﻿using AdmApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AdmApp.DAL
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext() : base("InmobiliariaContext")
        {
        }

        public DbSet<Locador> Locadores { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<AdmApp.Models.Contrato> Contratos { get; set; }
        public System.Data.Entity.DbSet<AdmApp.Models.Pendiente> Pendientes { get; set; }
        public System.Data.Entity.DbSet<AdmApp.Models.PeriodoContrato> PeriodoContratos { get; set; }

        public System.Data.Entity.DbSet<AdmApp.Models.Contacto> Contactoes { get; set; }
    }
}