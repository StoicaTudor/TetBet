namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.UrlParams
{
    public class FixturesApiFetcherUrlParams : GenericUrlParams
    {
        public long CompetitionId
        {
            set => AddUrlParam("league", value);
        }

        public int Season
        {
            set => AddUrlParam("season", value);
        }
    }
}