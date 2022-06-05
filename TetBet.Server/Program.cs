using System;
using System.Collections.Generic;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Commands;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;
using Unity;

namespace TetBet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = IocConfig.GetConfiguredContainer();

            ICommand command = null;

            ListCommands();

            while (true)
            {
                var inputCommand = Console.ReadLine();

                if (inputCommand == null)
                {
                    Console.WriteLine("Input is null. Please try again");
                    continue;
                }

                var inputParam = Console.ReadLine();

                if (inputParam == null)
                {
                    Console.WriteLine("Input parameters is null. Please try again");
                    continue;
                }

                int commandIndex = int.Parse(inputCommand);

                switch (commandIndex)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        command = container.Resolve<AddCompetitionWithTeamsCommand>();
                        break;
                }

                if (command == null || !command.CanExecute())
                {
                    Console.WriteLine("Command is null or can't be executed");
                    continue;
                }

                command.Execute(inputParam.Split(','));

                Console.WriteLine("Command executed successfully");
            }
        }

        private static void ListCommands()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine(
                "1. Add Competition With RapidApiCompetitionId and Teams in Competition. \n" +
                "Params: SportName(string),RapidApiCompetitionId(int),RapidApiCompetitionName(string),Season(int)");
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
    }
}