using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class PacientesRepository : BaseRepository<Paciente>, IPacientesRepository
    {
        public PacientesRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
