using ApplicationCore.Dto;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IPacienteService
    {
        IEnumerable<PacienteDto> BuscarPacientes();
        PacienteDto GetPaciente(int id);
        void ManterPaciente(PacienteDto paciente);
    }
}
