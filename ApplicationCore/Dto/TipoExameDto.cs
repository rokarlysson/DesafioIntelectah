using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Dto
{
    public class TipoExameDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [StringLength(256, ErrorMessage = "O campo Descrição não pode ter mais de 256 caracteres.")]
        public string Descricao { get; set; }

        public IEnumerable<ExameDto> Exames { get; set; }
    }
}
