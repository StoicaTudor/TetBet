using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities
{
    public class Odd
    {
        [JsonPropertyName("value")] public string Name { get; set; }
        [JsonPropertyName("odd")] public string OddValue { get; set; }
    }
}