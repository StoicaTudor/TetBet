using TetBet.Server.Services.FetchNewSportEvents;
using TetBet.Server.Services.UpdateOdds;
using Unity;

namespace TetBet.Server.Commands
{
    public class RoutineCommand : ICommand
    {
        public bool CanExecute(string[] parameters)
            => true;

        public void Execute(string[] parameters)
        {
            var container = IocConfig.GetConfiguredContainer();
            container.Resolve<ISportEventsApiProcessor>().Process(parameters[0]);
            container.Resolve<ISportEventsOddsApiProcessor>().Process(parameters[0]);
            // JobScheduler.
        }
    }
}