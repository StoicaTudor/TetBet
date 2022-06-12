using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TetBet.Server.Services.BetsFetcher.Entities
{
    public class ResourcesBetsConfiguration
    {
        [JsonPropertyName("Bets")]
        public IEnumerable<ResourcesBet> ApplicationGenericBets { get; set; }
        
        [JsonPropertyName("Sport")]
        public string Sport { get; set; }
    }
}