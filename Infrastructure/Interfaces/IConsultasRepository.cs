using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IConsultasRepository : IBaseRepository<Consulta>
    {
        bool ExisteConflitoDeHorarios(Consulta consulta);
    }
}
