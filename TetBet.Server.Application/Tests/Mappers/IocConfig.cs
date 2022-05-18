using AutoMapper;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Application.Mappers.RapidApi;
using Unity;
using Unity.Injection;

namespace TetBet.Server.Application.Tests.Mappers
{
    public class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void RegisterComponents()
        {
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType(typeof(SportEventMapper));

            Container.RegisterType<IMapper, Mapper>(
                new InjectionConstructor(new MapperConfiguration(cfg =>
                {
                    // I do not know how to resolve nested mapper dependencies here
                }))
            );
        }

        public static IUnityContainer GetConfiguredContainer()
            => Container;
    }
}