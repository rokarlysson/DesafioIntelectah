using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Dto
{
    public class ConsultaDto
    {
        public int? Id { get; set; }

        public int PacienteId { get; set; }
        public PacienteDto Paciente { get; set; }

        [Required(ErrorMessage = "O campo Data e Hora é obrigatório.")]
        [DataType(DataType.DateTime)]
        public DateTime DataHora { get; set; }

        public int ExameId { get; set; }
        public ExameDto Exame { get; set; }

        [Required(ErrorMessage = "O campo Número de Protocolo é obrigatório.")]
        public string NumeroProtocolo { get; set; }
    }
}
