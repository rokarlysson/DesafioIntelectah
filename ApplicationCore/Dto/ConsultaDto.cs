using Infrastructure.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Dto
{
    public class ConsultaDto
    {
        public int? Id { get; set; }

        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }

        public string NomePaciente { get; set; }
        
        [Display(Name = "Horário")]
        [Required(ErrorMessage = "O campo Data e Hora é obrigatório.")]
        public DateTime DataHora { get; set; }

        [Display(Name = "Exame")]
        public int ExameId { get; set; }

        [Display(Name = "Tipos de Exame")]
        public int TipoExameId { get; set; }

        public string NomeExame { get; set; }

        [Display(Name = "Protocolo")]
        public string NumeroProtocolo { get; set; }
    }
}
