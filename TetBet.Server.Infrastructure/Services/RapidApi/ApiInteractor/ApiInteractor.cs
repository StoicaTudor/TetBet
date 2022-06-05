using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.UrlParams;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers;

namespace TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor
{
    public class ApiInteractor : IApiInteractor
    {
        // fa metode cu calluri la fetchers si parsers, dupa in controller fa endpoint-uri care sa cheme metodele din
        // service-ul asta
        // call ApiInspector

        private readonly IMapper _mapper;

        public ApiInteractor(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<SportEntity> GetTeams(int leagueId, int season)
        {
            TeamsApiFetcherUrlParams teamsApiFetcherUrlParams = new TeamsApiFetcherUrlParams();
            teamsApiFetcherUrlParams.LeagueId = leagueId;
            teamsApiFetcherUrlParams.Season = season;

            TeamsApiFetcher teamsApiFetcher = new TeamsApiFetcher(teamsApiFetcherUrlParams.DictionaryUrlParams);

            TeamsJsonParser teamsJsonParser = new TeamsJsonParser();
            string content = teamsApiFetcher.Fetch().Content;
            IEnumerable<Team> teams = teamsJsonParser.Parse(content);

            return _mapper.Map<IEnumerable<SportEntity>>(teams);
        }
    }
}