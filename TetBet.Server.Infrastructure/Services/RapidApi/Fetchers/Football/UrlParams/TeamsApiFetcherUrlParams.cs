namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.UrlParams
{
    public class TeamsApiFetcherUrlParams : GenericUrlParams
    {
        public int LeagueId
        {
            set => AddUrlParam("league", value);
        }

        public int Season
        {
            set => AddUrlParam("season", value);
        }
    }
}