using System.Collections.Generic;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football
{
    public class FixturesApiFetcher : BaseApiFetcher
    {
        public FixturesApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams) : base(
            requestService, urlParams)
        {
        }

        /*
         * TODO: implement Get, by using RapidApiConfigData.FixturesPathSegment
         */
        protected override UrlBuilder ConfigureUrl(UrlBuilder url) =>
            url.AddPathSegment("fixtures");
    }
}