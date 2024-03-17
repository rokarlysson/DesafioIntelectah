using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Infrastructure.Entities;
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
            var entidade = _repositoy.GetById(id);
            return new TipoExameDto
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Descricao = entidade.Descricao
            };
        }

        public void ManterTipoExame(TipoExameDto tipoExame)
        {
            var entidade = new TipoExame
            {
                Nome = tipoExame.Nome,
                Descricao = tipoExame.Descricao,
            };

            if (tipoExame.Id.HasValue)
            {
                entidade.Id = tipoExame.Id.Value;
                _repositoy.Update(entidade);
                _repositoy.Commit();
                return;
            }

            _repositoy.Insert(entidade);
            _repositoy.Commit();
        }

        public void ExcluirTipoExame(int id)
        {
            var entidade = _repositoy.GetById(id);
            _repositoy.Delete(entidade);
        }
    }
}
