using ApplicationCore.Dto;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IPacientesService
    {
        IEnumerable<PacienteDto> ListarPacientes();
        PacienteDto BuscarPaciente(int id);
        void ManterPaciente(PacienteDto paciente);
        void ExcluirPaciente(int id);
    }
}
