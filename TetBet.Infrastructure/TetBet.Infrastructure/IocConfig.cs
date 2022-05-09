using TetBet.Infrastructure.Persistence.Repositories;
using Unity;

namespace TetBet.Infrastructure
{
    public class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterComponents()
        {
            // Container.RegisterType<IUserRepository, UserRepository>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container;
        }
    }
}