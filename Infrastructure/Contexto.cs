using System.Data.Entity;
using Infrastructure.Configurations;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Migrations;

namespace Infrastructure
{
    public class Contexto : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoExame> TiposExame { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        public Contexto()
        : base("IntelectahConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contexto, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PacienteConfiguration());
            modelBuilder.Configurations.Add(new TipoExameConfiguration());
        }
    }
}
