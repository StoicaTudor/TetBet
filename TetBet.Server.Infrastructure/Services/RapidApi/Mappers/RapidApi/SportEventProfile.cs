using System.Linq;
using System.Text.Json;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;
using League = TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities.League;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi
{
    public class SportEventProfile : Profile
    {
        private readonly IUnitOfWork _unitOfWork;

        public SportEventProfile(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CreateMap<ApiFixture, SportEvent>()
                .ForMember(sportEvent => sportEvent.Date,
                    option =>
                        option.MapFrom(apiFixture => apiFixture.Fixture.Date))
                .ForMember(sportEvent => sportEvent.Competition,
                    option =>
                        option.MapFrom(apiFixture => ApiLeagueToCompetition(apiFixture.League)))
                .ForMember(sportEvent => sportEvent.Location,
                    option =>
                        option.Ignore())
                .ForMember(sportEvent => sportEvent.Status,
                    option =>
                        option.MapFrom(apiFixture =>
                            ApiFixtureStatusToSportEventStatus(apiFixture.Fixture.Status)))
                .ForMember(sportEvent => sportEvent.SportEventDetails,
                    option =>
                        option.MapFrom(apiFixture =>
                            JsonSerializer.Serialize(ApiFixtureToFootballEvent(apiFixture), null)))
                .ForMember(sportEvent => sportEvent.RapidApiId,
                    option =>
                        option.MapFrom(apiFixture =>
                            apiFixture.Fixture.Id));
        }

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

                default: return SportEventStatus.NotStarted;
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

                Season = apiLeague.Season,

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