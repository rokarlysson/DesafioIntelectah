using Infrastructure.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations
{
    internal class TipoExameConfiguration : EntityTypeConfiguration<TipoExame>
    {
        public TipoExameConfiguration()
        {
            ToTable("TiposExame");

            HasKey(e => e.Id);

            Property(e => e.Nome)
                .IsRequired();

            Property(e => e.Descricao)
                .IsOptional();
        }
    }
}
