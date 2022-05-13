using System;
using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities
{
    public class Fixture
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("date")] public DateTime Date { get; set; }
    }
}