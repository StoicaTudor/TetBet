using System.Collections.Generic;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers
{
    public class CountriesApiFetcher : BaseApiFetcher
    {
        public CountriesApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams) : base(urlParams)
        {
        }

        protected override UrlBuilder ConfigureUrl(UrlBuilder url)
            => url.AddPathSegment("countries");
    }
}