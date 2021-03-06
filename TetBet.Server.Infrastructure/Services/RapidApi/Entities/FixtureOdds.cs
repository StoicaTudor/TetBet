using System.Collections.Generic;
using System.Text.Json.Serialization;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities
{
    public class FixtureOdds
    {
        [JsonPropertyName("league")] public League League { get; set; }
        [JsonPropertyName("fixture")] public Fixture Fixture { get; set; }
        [JsonPropertyName("bookmakers")] public IEnumerable<Bookmaker> Bookmakers { get; set; }
    }
}
