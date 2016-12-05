using AdmApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AdmApp.DAL
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext() : base("InmobiliariaContext")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}