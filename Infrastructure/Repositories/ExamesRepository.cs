using System.Collections.Generic;
using System.Linq;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class ExamesRepository : BaseRepository<Exame>, IExamesRepository
    {
        public ExamesRepository(Contexto contexto) 
            : base(contexto)
        {

        }

        public IEnumerable<Exame> ListarExamesPorTipo(int tipoExameId)
        {
            return Query(x => x.TipoExameId == tipoExameId).AsEnumerable();
        }
    }
}
