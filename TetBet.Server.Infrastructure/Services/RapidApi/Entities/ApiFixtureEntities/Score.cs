using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities
{
    public class Score
    {
        [JsonPropertyName("halftime")]
        public RoundScore HalfTimeScore { get; set; }
        
        [JsonPropertyName("halftime")]
        public RoundScore FullTimeScore { get; set; }
    }
}