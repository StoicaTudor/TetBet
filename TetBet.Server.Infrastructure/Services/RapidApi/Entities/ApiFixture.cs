using System.Text.Json.Serialization;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities
{
    public class ApiFixture
    {
        [JsonPropertyName("fixture")]
        public Fixture Fixture { get; set; }
        
        [JsonPropertyName("league")]
        public League League { get; set; }
        
        [JsonPropertyName("teams")]
        public Teams Teams { get; set; }
        
        [JsonPropertyName("goals")]
        public Goals Goals { get; set; }
        
        [JsonPropertyName("score")]
        public Score Score { get; set; }
    }
}