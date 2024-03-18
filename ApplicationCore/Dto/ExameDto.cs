using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Dto
{
    public class ExameDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [StringLength(1000, ErrorMessage = "O campo Observações não pode ter mais de 1000 caracteres.")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "O campo Id do tipo de exame é obrigatório.")]
        [Display(Name = "Tipo de Exame")]
        public int TipoExameId { get; set; }

        public string NomeTipoExame { get; set; }
    }
}
