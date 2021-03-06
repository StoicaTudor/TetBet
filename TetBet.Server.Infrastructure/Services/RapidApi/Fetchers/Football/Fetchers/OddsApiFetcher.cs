using System.Collections.Generic;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers
{
    public class OddsApiFetcher : BaseApiFetcher
    {
        public OddsApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams) : base(urlParams)
        {
        }

        protected override UrlBuilder ConfigureUrl(UrlBuilder url)
            => url.AddPathSegment("odds");
    }
}