using System.Collections.Generic;
using ApplicationCore.Dto;

namespace ApplicationCore.Interfaces
{
    public interface IConsultasService
    {
        bool VerificarConflitoDeHorarios(ConsultaDto consulta);
        void ManterConsulta(ConsultaDto consulta);
        void ExcluirConsulta(int idConsulta);
        ConsultaDto BuscarConsulta(int idConsulta);
        IEnumerable<ConsultaDto> ListarConsultas();
    }
}
