using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ApplicationCore.Attributes;

namespace ApplicationCore.Dto
{
    public class PacienteDto
    {
        private static readonly Regex TelefoneRegex = new Regex("[^0-9]", RegexOptions.Compiled);
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [ValidarCpf(ErrorMessage = "CPF inválido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        public string Sexo { get; set; }

        public string SexoDescrito => Sexo != "N" ? (Sexo == "M" ? "Masculino" : "Feminino") : "Não-declarado";

        [RegularExpression(@"^\(\d{2}\)\s?\d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public string TelefoneNumerico()
        {
            return string.IsNullOrEmpty(Telefone) ? string.Empty : TelefoneRegex.Replace(Telefone, string.Empty);
        }
    }
}
