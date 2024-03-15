using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services
{
    public class ConsultasService : IConsultasService
    {
        private readonly IConsultasRepository _repository;

        public ConsultasService(IConsultasRepository repository)
        {
            _repository = repository;
        }

        public bool VerificarConflitoDeHorarios(ConsultaDto consulta)
        {
            var entidade = new Consulta
            {
                DataHora = consulta.DataHora,
                NumeroProtocolo = consulta.NumeroProtocolo,
                ExameId = consulta.ExameId,
                PacienteId = consulta.PacienteId
            };

            if (consulta.Id.HasValue)
            {
                entidade.Id = consulta.Id.Value;
            }

            return _repository.ExisteConflitoDeHorarios(entidade);
        }

        public void ManterConsulta(ConsultaDto consulta)
        {
            var entidade = new Consulta
            {
                DataHora = consulta.DataHora,
                NumeroProtocolo = consulta.NumeroProtocolo,
                ExameId = consulta.ExameId,
                PacienteId = consulta.PacienteId
            };

            if (consulta.Id.HasValue)
            {
                entidade.Id = consulta.Id.Value;
                _repository.Update(entidade);
                _repository.Commit();
                return;
            }

            _repository.Insert(entidade);
            _repository.Commit();
        }

        public void ExcluirConsulta(int idConsulta)
        {
            var entidade = _repository.GetById(idConsulta);
            _repository.Delete(entidade);
            _repository.Commit();
        }

        public ConsultaDto BuscarConsulta(int idConsulta)
        {
            var entidade = _repository.GetById(idConsulta);
            return new ConsultaDto
            {
                Id = entidade.Id,
                DataHora = entidade.DataHora,
                TipoExameId = entidade.Exame?.TipoExameId ?? default,
                ExameId = entidade.ExameId,
                NomeExame = entidade.Exame?.Nome,
                NumeroProtocolo = entidade.NumeroProtocolo,
                PacienteId = entidade.PacienteId,
                NomePaciente = entidade.Paciente?.Nome
            };

        }

        public IEnumerable<ConsultaDto> ListarConsultas()
        {
            return _repository.GetAll()
                              .Select(x => new ConsultaDto
                              {
                                  Id = x.Id,
                                  DataHora = x.DataHora,
                                  TipoExameId = x.Exame?.TipoExameId ?? default,
                                  ExameId = x.ExameId,
                                  NomeExame = x.Exame?.Nome,
                                  NumeroProtocolo = x.NumeroProtocolo,
                                  PacienteId = x.PacienteId,
                                  NomePaciente = x.Paciente?.Nome
                              });
        }
    }
}
