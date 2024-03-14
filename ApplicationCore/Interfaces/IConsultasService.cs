using ApplicationCore.Dto;

namespace ApplicationCore.Interfaces
{
    public interface IConsultasService
    {
        bool VerificarConflitoDeHorarios(ConsultaDto consulta);
        void ManterConsulta(ConsultaDto consulta);
    }
}
