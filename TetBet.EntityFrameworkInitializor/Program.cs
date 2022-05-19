using System;
using Microsoft.Extensions.Hosting;
using TetBet.Infrastructure;
using TetBet.Infrastructure.Persistence;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using Unity;
using Unity.Injection;

namespace TetBet.EntityFrameworkInitializor
{
    class Program
    {
        static void Main(string[] args)
        {
            IocConfig.RegisterComponents();
            var container = IocConfig.GetConfiguredContainer();

            IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();
            unitOfWork.User.Get();
        }
        //
        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureAppConfiguration(builder => builder.Add())
    }
}