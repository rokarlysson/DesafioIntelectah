using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services
{
    public class ExamesService : IExamesService
    {
        private readonly IExamesRepository _repository;

        public ExamesService(IExamesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ExameDto> ListarExamesPeloTipo(int tipoExameId)
        {
            return _repository.ListarExamesPorTipo(tipoExameId)
                              .Select(x => new ExameDto
                              {
                                  Id = x.Id,
                                  Nome = x.Nome,
                                  Observacoes = x.Observacoes,
                                  TipoExameId = x.TipoExameId,
                                  NomeTipoExame = x.TipoExame?.Nome
                              }).AsEnumerable();
        }

        public IEnumerable<ExameDto> ListarExames()
        {
            return _repository.GetAll()
                              .Select(x => new ExameDto
                              {
                                  Id = x.Id,
                                  Nome = x.Nome,
                                  Observacoes = x.Observacoes,
                                  TipoExameId = x.TipoExameId,
                                  NomeTipoExame = x.TipoExame?.Nome
                              });
        }

        public ExameDto BuscarExame(int id)
        {
            var entidade = _repository.GetById(id);

            return new ExameDto
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Observacoes = entidade.Observacoes,
                TipoExameId = entidade.TipoExameId,
                NomeTipoExame = entidade.TipoExame?.Nome
            };
        }

        public void ManterExame(ExameDto exame)
        {
            var entidade = new Exame
            {
                Nome = exame.Nome,
                Observacoes = exame.Observacoes,
                TipoExameId = exame.TipoExameId
            };

            if (exame.Id.HasValue)
            {
                entidade.Id = exame.Id.Value;
                _repository.Update(entidade);
                _repository.Commit();

                return;
            }

            _repository.Insert(entidade);
            _repository.Commit();
        }

        public void ExcluirExame(int id)
        {
            var entidade = _repository.GetById(id);
            _repository.Delete(entidade);
            _repository.Commit();
        }
    }
}
