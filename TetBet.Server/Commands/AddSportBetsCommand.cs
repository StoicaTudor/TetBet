using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Services.BetsFetcher;
using Unity;

namespace TetBet.Server.Commands
{
    public class AddSportBetsCommand : ICommand
    {
        public bool CanExecute(string[] parameters)
            => true;

        public void Execute(string[] parameters)
        {
            var container = IocConfig.GetConfiguredContainer();
            IBetsFetcher betsFetcher = container.Resolve<IBetsFetcher>();
            IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();

            string sportName = parameters[0];

            long sportId = unitOfWork
                .Sport
                .Get(sport => sport.Name.Equals(sportName))
                .First()
                .Id;

            List<GenericBet> genericBets = GetGenericBets(betsFetcher, sportId);

            genericBets.ForEach(genericBet =>
            {
                unitOfWork
                    .GenericBet
                    .Insert(genericBet);

                // unitOfWork.Commit();
                //
                // genericBet
                //     .Bets
                //     .ToList()
                //     .ForEach(bet => unitOfWork.Bet.Insert(bet));
                //
                // unitOfWork.Commit();
            });
            
            unitOfWork.Commit();
        }

        private List<GenericBet> GetGenericBets(IBetsFetcher betsFetcher, long sportId)
            => betsFetcher
                .Fetch()
                .ToList();
    }
}