using System.Linq;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class ConsultasRepository : BaseRepository<Consulta>, IConsultasRepository
    {
        public ConsultasRepository(Contexto contexto)
            : base(contexto)
        {
        }

        public bool ExisteConflitoDeHorarios(Consulta consulta)
        {
            return !Query(c => c.DataHora == consulta.DataHora &&
                                           c.PacienteId == consulta.PacienteId &&
                                           c.Id != consulta.Id).Any();
        }
    }
}
