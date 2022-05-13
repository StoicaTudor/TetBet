using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities
{
    public class Bookmaker
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("bets")] public IEnumerable<Bet> Bets { get; set; }
    }
}