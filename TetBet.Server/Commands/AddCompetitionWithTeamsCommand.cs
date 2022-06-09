using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Commands.Exceptions;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;
using Unity;

namespace TetBet.Server.Commands
{
    public class AddCompetitionWithTeamsCommand : ICommand
    {
        public bool CanExecute() // check is competition and teams are already in DB
            => true;

        public void Execute(string[] parameters)
        {
            string sportName = parameters[0];
            int competitionId = int.Parse(parameters[1]);
            string competitionName = parameters[2];
            int season = int.Parse(parameters[3]);

            var container = IocConfig.GetConfiguredContainer();

            IApiInteractor apiInteractor = container.Resolve<IApiInteractor>();
            IUnitOfWork unitOfWork = container.Resolve<IUnitOfWork>();

            List<SportEntity> sportEntities = apiInteractor
                .GetTeams(competitionId, season)
                .ToList();

            sportEntities
                .ToList()
                .ForEach(entity =>
                {
                    // TODO: this is not a good practice, but I do not know how to deal with it (EF insert nested objects)
                    entity.CountryId = entity.Country.Id;
                    entity.Country = null;
                });

            long sportId = unitOfWork
                .Sport
                .Get(sport => sport.Name.Equals("Football"))
                .First()
                .Id;

            if (sportEntities == null || !sportEntities.Any())
                throw new NoTeamsFetchedException();

            Competition competition = new Competition
            {
                CountryId = sportEntities.First().CountryId,
                Season = season,
                SportId = sportId,
                RapidApiId = competitionId,
                Name = competitionName
            };

            unitOfWork
                .Competition
                .Insert(competition);

            sportEntities.ForEach(sportEntity =>
            {
                sportEntity.Competitions = new List<Competition>();
                sportEntity.Competitions.ToList().Add(competition);
            });

            for (var i = 0; i < sportEntities.Count; i++)
            {
                sportEntities[i].Competitions = new List<Competition>();
                sportEntities[i].Competitions.Add(competition);
            }

            unitOfWork.SportEntity.InsertBulk(sportEntities);

            unitOfWork.Commit();
        }
    }
}