using System.Collections.Generic;
using Se.Url;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers
{
    public class TeamsApiFetcher : BaseApiFetcher
    {
        public TeamsApiFetcher(Dictionary<string, object> urlParams) : base(urlParams)
        {
        }

        protected override UrlBuilder ConfigureUrl(UrlBuilder url)
            => url.AddPathSegment("teams");
    }
}