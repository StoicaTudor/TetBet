
using System;
using TetBet.Infrastructure;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using Unity;

namespace TetBet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IocConfig.RegisterComponents();
            var container = IocConfig.GetConfiguredContainer();

            IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();
            var user = unitOfWork.User.Get();
            Console.WriteLine("aaa");
        }
    }
}