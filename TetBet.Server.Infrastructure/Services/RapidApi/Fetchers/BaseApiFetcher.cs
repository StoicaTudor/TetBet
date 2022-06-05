using System.Collections.Generic;
using RestSharp;
using Se.Url;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector;
using TetBet.Server.Infrastructure.Services.RapidApi.KeySelector;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;
using Unity;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers
{
    public abstract class BaseApiFetcher
    {
        private readonly IRequestService _requestService;
        private readonly UrlBuilder _urlBuilder;
        private readonly Dictionary<string, object> _urlParams;
        private readonly IApiInspector _apiInspector;

        protected BaseApiFetcher(Dictionary<string, object> urlParams)
        {
            IUnityContainer container = IocConfig.GetConfiguredContainer();

            _requestService = container.Resolve<IRequestService>();

            _urlParams = urlParams;
            _urlBuilder = new UrlBuilder(_requestService.GetRapidApiRootUrl());
            _apiInspector = container.Resolve<IApiInspector>();
        }

        protected abstract UrlBuilder ConfigureUrl(UrlBuilder url);

        public IRestResponse Fetch()
        {
            IRestResponse response = new RestClient(
                    ConfigureUrl(_urlBuilder)
                        .SetQueryParams(_urlParams)
                        .ToString())
                .Execute(GetRequest());

            _apiInspector.Inspect(response);

            return response;
        }

        private IRestRequest GetRequest()
            => new RestRequest(Method.GET)
                .AddHeader(_requestService.GetRapidApiHostHeaderName(), _requestService.GetRapidApiHost())
                .AddHeader(_requestService.GetRapidApiKeyHeaderName(), _requestService.GetRapidApiKey());
    }
}