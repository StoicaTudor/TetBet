using TetBet.Infrastructure.Persistence;

namespace TetBet.Infrastructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IocConfig.RegisterComponents();
            var container = IocConfig.GetConfiguredContainer();

            var applicationContext = container.Resolve(typeof(ApplicationContext), "ApplicationContext");
        }
    }
}