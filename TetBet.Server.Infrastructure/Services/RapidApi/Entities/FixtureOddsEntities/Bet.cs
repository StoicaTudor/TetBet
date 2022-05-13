using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities
{
    public class Bet
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("values")] public IEnumerable<Odd> Odds { get; set; }
    }
}