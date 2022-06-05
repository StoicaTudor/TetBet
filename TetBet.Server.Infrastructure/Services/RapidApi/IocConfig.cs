using AutoMapper;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;
using TetBet.Server.Infrastructure.Services.RapidApi.KeySelector;
using TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;
using Unity;
using Unity.Injection;

namespace TetBet.Server.Infrastructure.Services.RapidApi
{
    public static class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterComponents()
        {
            Container.RegisterType<IApiInspector, ApiInspector.ApiInspector>();
            Container.RegisterType<IKeySelector, KeySelector.KeySelector>();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IApiInteractor, ApiInteractor.ApiInteractor>();
            Container.RegisterType<IRequestService, RequestService.RequestService>();

            Container.RegisterType<IMapper, Mapper>(
                new InjectionConstructor(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(
                        new TeamsProfile(Container.Resolve<IUnitOfWork>()));
                }))
            );
        }

        public static IUnityContainer GetConfiguredContainer()
            => Container;
    }
}