using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Exame
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Observacoes { get; set; }
        
        public int TipoExameId { get; set; }

        public virtual TipoExame TipoExame { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
