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
            throw new System.NotImplementedException();
        }
    }
}
