using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers.Exceptions;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Parsers
{
    public class FixturesJsonParser : IJsonResponseParser<ApiFixture>
    {
        public IEnumerable<ApiFixture> Parse(string response)
        {
            JToken dataResponseToken = JObject
                .Parse(response)
                .SelectToken("response");

            if (dataResponseToken == null)
                throw new DataResponseNotExistsException("dataResponseToken is null");

            return JsonSerializer.Deserialize<IEnumerable<ApiFixture>>(dataResponseToken.ToString());
        }
    }
}