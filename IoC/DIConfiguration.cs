using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Unity;

namespace IoC
{
    public class DIConfiguration
    {
        public static void RegistrarRepositorios(IUnityContainer container)
        {
            container.RegisterType<IPacienteRepository, PacienteRepository>();
        }

        public static void RegistrarServicos(IUnityContainer container)
        {
            container.RegisterType<IPacienteService, PacienteService>();
        }
    }
}
