using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities
{
    public class Score
    {
        [JsonPropertyName("halftime")]
        public RoundScore HalfTimeScore { get; set; }
        
        [JsonPropertyName("fulltime")]
        public RoundScore FullTimeScore { get; set; }
        
        [JsonPropertyName("extratime")]
        public RoundScore ExtraTimeScore { get; set; }
        
        [JsonPropertyName("penalty")]
        public RoundScore PenaltyScore { get; set; }
    }
}