using TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector;
using TetBet.Server.Infrastructure.Services.RapidApi.KeySelector;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;
using Unity;

namespace TetBet.Server.Infrastructure.Services.RapidApi
{
    public static class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterComponents()
        {
            Container.RegisterType<IApiInspector, ApiInspector.ApiInspector>();
            Container.RegisterType<IKeySelector, KeySelector.KeySelector>();
            Container.RegisterType<IRequestService, RequestService.RequestService>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container;
        }
    }
}