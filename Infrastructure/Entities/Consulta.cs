using System;

namespace Infrastructure.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public DateTime DataHora { get; set; }
        public int ExameId { get; set; }
        public virtual Exame Exame { get; set; }
        public string NumeroProtocolo { get; set; }
    }
}
