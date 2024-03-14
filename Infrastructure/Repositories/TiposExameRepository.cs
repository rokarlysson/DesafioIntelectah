using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class TiposExameRepository : BaseRepository<TipoExame>, ITiposExameRepository
    {
        public TiposExameRepository(Contexto contexto) 
            : base(contexto)
        {
        }
    }
}
