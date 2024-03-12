using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public string Cpf { get; set; }
       
        public DateTime DataNascimento { get; set; }
        
        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
