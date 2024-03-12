namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntelectahDbV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        ExameId = c.Int(nullable: false),
                        NumeroProtocolo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exames", t => t.ExameId, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId)
                .Index(t => t.ExameId);
            
            CreateTable(
                "dbo.Exames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Observacoes = c.String(),
                        TipoExameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TiposExame", t => t.TipoExameId, cascadeDelete: true)
                .Index(t => t.TipoExameId);
            
            CreateTable(
                "dbo.TiposExame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cpf, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Exames", "TipoExameId", "dbo.TiposExame");
            DropForeignKey("dbo.Consultas", "ExameId", "dbo.Exames");
            DropIndex("dbo.Pacientes", new[] { "Cpf" });
            DropIndex("dbo.Exames", new[] { "TipoExameId" });
            DropIndex("dbo.Consultas", new[] { "ExameId" });
            DropIndex("dbo.Consultas", new[] { "PacienteId" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.TiposExame");
            DropTable("dbo.Exames");
            DropTable("dbo.Consultas");
        }
    }
}
