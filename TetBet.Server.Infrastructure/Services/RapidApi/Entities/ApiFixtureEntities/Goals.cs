using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities
{
    public class Goals
    {
        [JsonPropertyName("home")]
        public int? HomeTeamGoals { get; set; }
        
        [JsonPropertyName("away")]
        public int? AwayTeamGoals { get; set; }
    }
}