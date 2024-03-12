using Infrastructure.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations
{

    internal class PacienteConfiguration : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            ToTable("Pacientes")
                .HasIndex(p => p.Cpf)
                .IsUnique();
            
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            Property(p => p.DataNascimento)
                .IsRequired();

            Property(p => p.Sexo)
                .IsRequired();

            Property(p => p.Telefone)
                .IsOptional();

            Property(p => p.Email)
                .IsOptional();
        }
    }
}
