using System;
using TetBet.Infrastructure;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using Unity;


namespace TetBet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IocConfig.RegisterComponents();
            IUnityContainer container = IocConfig.GetConfiguredContainer();

            IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();

            var sus = unitOfWork
                .User
                .Get(user => user.Id == 1, unitOfWork.UserIncludes.IncludeEntities);
            Console.WriteLine("aaa");
        }
    }
}