using AutoMapper;
using Microsoft.AspNetCore.Http;
using TetBet.Client.Services.LoginService;
using TetBet.Client.Services.SessionService;
using TetBet.Client.Services.UserService;
using TetBet.Core.Mappers;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using Unity;
using Unity.Injection;

namespace TetBet.Client
{
    public class IocConfig
    {
        private static readonly IUnityContainer Container = new UnityContainer();
        private static bool _containerIsRegistered = false;

        private static void RegisterComponents()
        {
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<ISessionService, SessionService>();
            Container.RegisterType<ILoginService, LoginService>();
            
            Container.RegisterType<IMapper, Mapper>(
                new InjectionConstructor(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new UserProfile());
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