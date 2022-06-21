using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers.Exceptions;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Parsers
{
    public class FixtureOddsJsonParser : IJsonResponseParser<FixtureOdds>
    {
        public IEnumerable<FixtureOdds> Parse(string response)
        {
            JToken dataResponseToken = JObject
                .Parse(response)
                .SelectToken("response");

            if (dataResponseToken == null)
                throw new DataResponseNotExistsException("dataResponseToken is null");

            try
            {
                return JsonSerializer.Deserialize<IEnumerable<FixtureOdds>>(dataResponseToken.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}