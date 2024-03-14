using ApplicationCore.Dto;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IExamesService
    {
        IEnumerable<ExameDto> ListarExamesPeloTipo(int tipoExameId);
        IEnumerable<ExameDto> ListarExames();
        ExameDto BuscarExame(int id);
        void ManterExame(ExameDto exame);
        void ExcluirExame(int id);
    }
}
