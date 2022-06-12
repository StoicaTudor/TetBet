﻿using System;
using TetBet.Server.Commands;
using TetBet.Server.Services.FetchNewSportEvents;
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
                // container.Resolve<ISportEventsApiProcessor>().Process("Football");
                // Environment.Exit(0);

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
                    case 2:
                        command = container.Resolve<AddSportBetsCommand>();
                        break;
                }

                string[] commandParams = inputParam.Split(',');

                if (command == null || !command.CanExecute(commandParams))
                {
                    Console.WriteLine("Comm and is null or can't be executed");
                    continue;
                }

                command.Execute(commandParams);

                Console.WriteLine("Command executed successfully");
            }
        }

        private static void ListCommands()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine(
                "1. Add Competition With RapidApiCompetitionId and Teams in Competition. \n" +
                "Params: SportName(string),RapidApiCompetitionId(int),RapidApiCompetitionName(string),Season(int)");
            Console.WriteLine("2. Add Bets (this should only be done once, this is only for setup) \n" +
                              "Params: SportName(string)");
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