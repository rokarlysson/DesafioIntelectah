using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services
{
    public class TiposExameService : ITiposExameService
    {
        private readonly ITiposExameRepository _repositoy;

        public TiposExameService(ITiposExameRepository repositoy)
        {
            _repositoy = repositoy;
        }

        public IEnumerable<TipoExameDto> ListarTiposExame()
        {
            return _repositoy.GetAll()
                             .Select(x => new TipoExameDto
                             {
                                 Id = x.Id,
                                 Nome = x.Nome,
                                 Descricao = x.Descricao
                             });
        }

        public TipoExameDto BuscarTipoExame(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ManterTipoExame(TipoExameDto tipoExame)
        {
            throw new System.NotImplementedException();
        }

        public void ExcluirTipoExame(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
