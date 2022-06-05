using System.Collections.Generic;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers
{
    public class BetsTypeApiFetcher : BaseApiFetcher
    {
        public BetsTypeApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams) : base(urlParams)
        {
        }

        protected override UrlBuilder ConfigureUrl(UrlBuilder url)
            => url.AddPathSegment("odds")
                .AddPathSegment("bets");
    }
}