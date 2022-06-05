using Microsoft.EntityFrameworkCore;
using TetBet.Infrastructure.Persistence;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;
using Unity;
using Unity.Injection;

namespace TetBet.Server.Infrastructure.Tests.ServiceTests.RapidApiTests
{
    public class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterComponents()
        {
            // TODO: place connection string into a properties file and programatically extract it
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>().UseMySQL(
                "server = localhost; port = 3306; user = Citadin2; password = Aaladin2000-; database = TetBet");
            Container.RegisterType<ApplicationContext>(new InjectionConstructor(optionsBuilder));

            Container.RegisterType<BaseApiFetcher, CountriesApiFetcher>();
            Container.RegisterType<IRequestService, RequestService>();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container;
        }
    }
}