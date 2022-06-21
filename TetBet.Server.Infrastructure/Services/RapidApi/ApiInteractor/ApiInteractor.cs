using System.Collections.Generic;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.UrlParams;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers;
using Unity;
using Unity.Resolution;

namespace TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor
{
    public class ApiInteractor : IApiInteractor
    {
        // fa metode cu calluri la fetchers si parsers, dupa in controller fa endpoint-uri care sa cheme metodele din
        // service-ul asta
        // call ApiInspector

        private readonly IMapper _mapper;
        private readonly IUnityContainer _unityContainer;

        public ApiInteractor(IMapper mapper)
        {
            _mapper = mapper;
            _unityContainer = IocConfig.GetConfiguredContainer();
        }

        public IEnumerable<SportEntity> GetTeams(long leagueId, int season)
        {
            TeamsApiFetcherUrlParams teamsApiFetcherUrlParams = new TeamsApiFetcherUrlParams
            {
                CompetitionId = leagueId,
                Season = season
            };

            BaseApiFetcher teamsApiFetcher = _unityContainer.Resolve<TeamsApiFetcher>(
                new ParameterOverride(typeof(Dictionary<string, object>),
                    teamsApiFetcherUrlParams.DictionaryUrlParams));

            string content = teamsApiFetcher.Fetch().Content;
            TeamsJsonParser teamsJsonParser = new TeamsJsonParser();

            return _mapper
                .Map<IEnumerable<SportEntity>>(teamsJsonParser.Parse(content));
        }

        public IEnumerable<SportEvent> GetSportEvents(long leagueId, int season)
        {
            FixturesApiFetcherUrlParams fixturesApiFetcherUrlParams = new FixturesApiFetcherUrlParams
            {
                CompetitionId = leagueId,
                Season = season
            };

            BaseApiFetcher fixturesApiFetcher = _unityContainer.Resolve<FixturesApiFetcher>(
                new ParameterOverride(typeof(Dictionary<string, object>),
                    fixturesApiFetcherUrlParams.DictionaryUrlParams));

            string content = fixturesApiFetcher.Fetch().Content;

            return _mapper
                .Map<IEnumerable<SportEvent>>(_unityContainer
                    .Resolve<FixturesJsonParser>()
                    .Parse(content));
        }

        public IEnumerable<SportEventBet> GetOddsForSportEvent(SportEvent sportEvent)
        {
            OddsApiFetcherUrlParams oddsApiFetcherUrlParams = new OddsApiFetcherUrlParams
            {
                RapidApiFixtureId = sportEvent.RapidApiId
            };

            BaseApiFetcher fixturesApiFetcher = _unityContainer.Resolve<OddsApiFetcher>(
                new ParameterOverride(typeof(Dictionary<string, object>),
                    oddsApiFetcherUrlParams.DictionaryUrlParams));

            string content = fixturesApiFetcher.Fetch().Content;

            return _mapper
                .Map<IEnumerable<SportEventBet>>(_unityContainer
                    .Resolve<FixtureOddsJsonParser>()
                    .Parse(content)
                );
        }
    }
}