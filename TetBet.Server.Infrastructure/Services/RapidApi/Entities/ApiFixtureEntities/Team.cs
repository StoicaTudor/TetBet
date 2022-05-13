using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities
{
    public class Team
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("winner")]
        public bool? IsWinner { get; set; }
    }
}