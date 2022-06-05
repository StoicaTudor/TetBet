using Microsoft.EntityFrameworkCore;
using TetBet.Infrastructure.Persistence;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace TetBet.Infrastructure
{
    public class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterComponents()
        {
            // TODO: place connection string into a properties file and programatically extract it
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>().UseMySQL(
                "server = localhost; port = 3306; user = Citadin2; password = Aaladin2000-; database = TetBet").Options;

            Container.RegisterInstance(
                typeof(ApplicationContext),
                "ApplicationContext",
                new ApplicationContext(optionsBuilder),
                new SingletonLifetimeManager());

            Container.RegisterType<IUnitOfWork, UnitOfWork>(
                new InjectionConstructor(new ApplicationContext(optionsBuilder)));
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container;
        }
    }
}