using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TetBet.Server.Services.BetsFetcher.Entities
{
    public class ResourcesBet
    {
        [JsonPropertyName("GenericBetName")]
        public string GenericBetName { get; set; }
        [JsonPropertyName("Bets")]
        public IEnumerable<string> BetsList { get; set; }
    }
}