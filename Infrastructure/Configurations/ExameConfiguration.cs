using Infrastructure.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations
{
    internal class ExameConfiguration : EntityTypeConfiguration<Exame>
    {
        public ExameConfiguration()
        {
            ToTable("Exames");

            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Observacoes)
                .IsOptional();

            HasRequired(e => e.TipoExame)
                .WithMany(t => t.Exames)
                .HasForeignKey(e => e.TipoExameId);
        }
    }
}
