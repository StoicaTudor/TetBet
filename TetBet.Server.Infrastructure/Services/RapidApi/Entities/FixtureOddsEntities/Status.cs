using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities
{
    public class Status
    {
        [JsonPropertyName("long")]
        public string FullName { get; set; }
        
        [JsonPropertyName("short")]
        public string ShortName { get; set; }
        
        [JsonPropertyName("elapsed")]
        public int? MinutesElapsed { get; set; }
    }
}