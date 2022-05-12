using System.Collections.Generic;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football
{
    public class OddsApiFetcher : BaseApiFetcher
    {
        public OddsApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams) : base(
            requestService, urlParams)
        {
        }

        protected override UrlBuilder ConfigureUrl(UrlBuilder url)
            => url;
    }
}