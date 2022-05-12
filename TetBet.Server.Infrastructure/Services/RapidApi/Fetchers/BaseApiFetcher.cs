using System.Collections.Generic;
using RestSharp;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers
{
    public abstract class BaseApiFetcher
    {
        private readonly IRequestService _requestService;
        private readonly UrlBuilder _urlBuilder;
        private readonly Dictionary<string, object> _urlParams;

        protected BaseApiFetcher(IRequestService requestService, Dictionary<string, object> urlParams)
        {
            _requestService = requestService;
            _urlParams = urlParams;
            _urlBuilder = new UrlBuilder(_requestService.GetRapidApiRootUrl());
        }

        protected abstract UrlBuilder ConfigureUrl(UrlBuilder url);

        public IRestResponse Fetch()
            => new RestClient(
                    ConfigureUrl(_urlBuilder)
                        .SetQueryParams(_urlParams)
                        .ToString())
                .Execute(GetRequest());

        private IRestRequest GetRequest()
        {
            return new RestRequest(Method.GET)
                .AddHeader(_requestService.GetRapidApiHostHeaderName(), _requestService.GetRapidApiHost())
                .AddHeader(_requestService.GetRapidApiKeyHeaderName(), _requestService.GetRapidApiKey());
        }
    }
}