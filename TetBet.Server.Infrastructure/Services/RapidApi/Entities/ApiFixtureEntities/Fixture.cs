using System;
using System.Text.Json.Serialization;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities
{
    public class Fixture
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("status")]
        public Status Status { get; set; }
    }
}