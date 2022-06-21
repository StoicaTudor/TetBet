namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.UrlParams
{
    public class OddsApiFetcherUrlParams : GenericUrlParams
    {
        public long RapidApiFixtureId
        {
            set => AddUrlParam("fixture", value);
        }
    }
}