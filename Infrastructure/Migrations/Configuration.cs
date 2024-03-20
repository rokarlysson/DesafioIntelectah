namespace Infrastructure.Migrations
{
    using Infrastructure.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.TiposExame.AddOrUpdate(x => x.Id,
                new TipoExame { Id = 1, Nome = "Exames de Sangue", Descricao = "Indicativos de glóbulos vermelho e branco, plaquetas, perfil lipídico e etc." },
                new TipoExame { Id = 2, Nome = "Exames de Imagem", Descricao = "Ultrassom, Raio-X, Tomografia e etc." });

            context.Exames.AddOrUpdate(x => x.Id,
                new Exame { Id = 1, Nome = "Hemograma", Observacoes = "Realizar Hemoglobina Glicada", TipoExameId = 1 },
                new Exame { Id = 2, Nome = "Tomografia Computadorizada", Observacoes = "Tomografia geral do abdômen", TipoExameId = 2 });

            context.Pacientes.AddOrUpdate(x => x.Id,
                new Paciente { Id = 1, Nome = "Pedro Souza", Cpf = "85727099404", DataNascimento = new DateTime(1985, 11, 7), Sexo = "M", Telefone = "83998554633", Email = "pedro.souza@intelectah.com" });

            context.Consultas.AddOrUpdate(x => x.Id, 
                new Consulta{Id = 1, PacienteId = 1, DataHora = new DateTime(2024,05,12,12,00,00), ExameId = 1, NumeroProtocolo = "EE267E8D" },
                new Consulta { Id = 2, PacienteId = 1, DataHora = new DateTime(2024, 05, 19, 13, 20, 00), ExameId = 2, NumeroProtocolo = "10B3E5DD" });

        }
    }
}
