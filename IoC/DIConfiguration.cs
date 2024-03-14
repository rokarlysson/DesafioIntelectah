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
            container.RegisterType<IPacientesRepository, PacientesRepository>();
            container.RegisterType<IExamesRepository, ExamesRepository>();
            container.RegisterType<ITiposExameRepository, TiposExameRepository>();
            container.RegisterType<IConsultasRepository, ConsultasRepository>();
        }

        public static void RegistrarServicos(IUnityContainer container)
        {
            container.RegisterType<IPacientesService, PacientesService>();
            container.RegisterType<IExamesService, ExamesService>();
            container.RegisterType<ITiposExameService, TiposExameService>();
            container.RegisterType<IConsultasService, ConsultasService>();
        }
    }
}
