using AutoMapper;
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
            Container.RegisterType(typeof(SportEventBetProfile));
            
            Container.RegisterType<IMapper, Mapper>(
                new InjectionConstructor(new MapperConfiguration(cfg =>
                {
                    // I do not know how to resolve nested mapper dependencies here
                }))
            );
        }
    }
}