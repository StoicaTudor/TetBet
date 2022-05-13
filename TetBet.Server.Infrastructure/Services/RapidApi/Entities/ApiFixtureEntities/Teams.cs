using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities
{
    public class Teams
    {
        [JsonPropertyName("home")]
        public Team HomeTeam { get; set; }
        
        [JsonPropertyName("away")]
        public Team AwayTeam { get; set; }
    }
}