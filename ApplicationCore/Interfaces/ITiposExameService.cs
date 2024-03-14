using ApplicationCore.Dto;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface ITiposExameService
    {
        IEnumerable<TipoExameDto> ListarTiposExame();
        TipoExameDto BuscarTipoExame(int id);
        void ManterTipoExame(TipoExameDto tipoExame);
        void ExcluirTipoExame(int id);
    }
}
