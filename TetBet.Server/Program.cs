using System;
using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;
using Unity;
using IocConfig = TetBet.Server.Infrastructure.Services.RapidApi.IocConfig;

namespace TetBet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private void TestGetUser()
        {
            // IocConfig.RegisterComponents();
            // IUnityContainer container = IocConfig.GetConfiguredContainer();
            //
            // IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();
            //
            // var sus = unitOfWork
            //     .User
            //     .Get(user => user.Id == 1, unitOfWork.UserIncludes.IncludeEntities);
            // Console.WriteLine("aaa");
        }

        private void InsertPremierLeagueTeams()
        {
            IocConfig.RegisterComponents();
            var container =
                IocConfig.GetConfiguredContainer();

            IApiInteractor apiInteractor = container.Resolve<IApiInteractor>();
            IEnumerable<SportEntity> teams = apiInteractor.GetTeams(39, 2021);

            IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();

            unitOfWork.SportEntity.InsertBulk(teams);
        }
    }
}