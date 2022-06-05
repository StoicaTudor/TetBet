using AutoMapper;
using NUnit.Framework.Constraints;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;
using TetBet.Server.Infrastructure.Services.RapidApi.KeySelector;
using TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;
using Unity;
using Unity.Injection;

namespace TetBet.Server
{
    public static class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();
        private static bool _containerIsRegistered = false;

        private static void RegisterComponents()
        {
            Container.RegisterType<IApiInspector, ApiInspector>();
            Container.RegisterType<IKeySelector, KeySelector>();
            Container.RegisterSingleton<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IApiInteractor, ApiInteractor>();
            Container.RegisterType<IRequestService, RequestService>();

            Container.RegisterType<IMapper, Mapper>(
                new InjectionConstructor(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(
                        new TeamsProfile(Container.Resolve<IUnitOfWork>()));
                }))
            );
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            if (!_containerIsRegistered)
                RegisterComponents();

            return Container;
        }
    }
}