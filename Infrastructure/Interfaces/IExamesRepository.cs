using Infrastructure.Entities;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IExamesRepository : IBaseRepository<Exame>
    {
        IEnumerable<Exame> ListarExamesPorTipo(int tipoExameId);
    }
}
