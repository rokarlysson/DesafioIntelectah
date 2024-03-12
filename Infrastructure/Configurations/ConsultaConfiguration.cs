using Infrastructure.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations
{
    internal class ConsultaConfiguration : EntityTypeConfiguration<Consulta>
    {
        public ConsultaConfiguration()
        {
            ToTable("Exames");

            HasKey(p => p.Id);

            Property(p => p.DataHora)
                .IsRequired();

            Property(p => p.NumeroProtocolo)
                .IsRequired();

            HasRequired(e => e.Exame)
                .WithMany(t => t.Consultas)
                .HasForeignKey(e => e.ExameId);

            HasRequired(e => e.Paciente)
                .WithMany(t => t.Consultas)
                .HasForeignKey(e => e.PacienteId);
        }
    }
}
