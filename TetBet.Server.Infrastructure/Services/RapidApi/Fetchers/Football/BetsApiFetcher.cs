using System.Collections.Generic;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football
{
    public class BetsApiFetcher : BaseApiFetcher
    {
        private readonly IRequestService _requestService;
        private readonly Dictionary<string, object> _urlParams;

        public BetsApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams) : base(
            requestService, urlParams)
        {
            _requestService = requestService;
            _urlParams = urlParams;
        }

        protected override UrlBuilder ConfigureUrl(UrlBuilder url)
            => url.AddPathSegment("what should I write here???");
    }
}