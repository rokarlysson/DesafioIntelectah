using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class TipoExame
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Exame> Exames { get; set; }
    }
}
