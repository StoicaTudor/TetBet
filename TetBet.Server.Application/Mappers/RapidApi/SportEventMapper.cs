using System.Linq;
using System.Text.Json;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;
using League = TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities.League;

namespace TetBet.Server.Application.Mappers.RapidApi
{
    public class SportEventMapper
    {
        private readonly IUnitOfWork _unitOfWork;

        public SportEventMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SportEvent ApiFixtureToSportEvent(ApiFixture apiFixture)
            => new()
            {
                Location = "",
                Date = apiFixture.Fixture.Date,
                RapidApiId = apiFixture.Fixture.Id,
                SportEventStatus = ApiFixtureStatusToSportEventStatus(apiFixture.Fixture.Status),
                Competition = ApiLeagueToCompetition(apiFixture.League),
                SportEventDetails = JsonSerializer.Serialize(ApiFixtureToFootballEvent(apiFixture))
            };
        
        private SportEventStatus ApiFixtureStatusToSportEventStatus(Status apiFixtureStatus)
        {
            switch (apiFixtureStatus.FullName)
            {
                case "Match Finished":
                    return SportEventStatus.Ended;

                case "Not Started":
                    return SportEventStatus.NotStarted;

                case "First Half":
                case "Second Half":
                    return SportEventStatus.InProgress;

                default: return SportEventStatus.InProgress;
            }
        }

        private Competition ApiLeagueToCompetition(League apiLeague)
            => new()
            {
                Country = new TetBet.Infrastructure.Entities.Country
                {
                    Name = apiLeague.Country
                },

                Name = apiLeague.Name,

                Sport = new Sport
                {
                    // TODO: this is hardcoded due to lack of time
                    Name = "Football"
                },

                RapidApiId = apiLeague.Id,

                Season = apiLeague.Season.ToString(),

                Id = _unitOfWork
                    .Competition
                    .Get(competition => competition.RapidApiId == apiLeague.Id)
                    .First()
                    .Id
            };

        private FootballEvent ApiFixtureToFootballEvent(ApiFixture apiFixture)
            => new()
            {
                HomeTeam = _unitOfWork
                    .SportEntity
                    .Get(sportEntity => sportEntity.RapidApiId == apiFixture.Teams.HomeTeam.Id)
                    .First(),

                AwayTeam = _unitOfWork
                    .SportEntity
                    .Get(sportEntity => sportEntity.RapidApiId == apiFixture.Teams.AwayTeam.Id)
                    .First(),

                HomeTeamGoals = apiFixture.Goals.HomeTeamGoals,

                AwayTeamGoals = apiFixture.Goals.AwayTeamGoals,

                HomeTeamFirstHalfGoals = apiFixture
                    .Score
                    .HalfTimeScore
                    .HomeTeamGoals,

                AwayTeamFirstHalfGoals = apiFixture
                    .Score
                    .HalfTimeScore
                    .AwayTeamGoals,

                HomeTeamSecondHalfGoals = apiFixture.Goals.HomeTeamGoals -
                                          apiFixture
                                              .Score
                                              .HalfTimeScore
                                              .HomeTeamGoals,

                AwayTeamSecondHalfGoals = apiFixture.Goals.AwayTeamGoals -
                                          apiFixture
                                              .Score
                                              .HalfTimeScore
                                              .AwayTeamGoals
            };
    }
}