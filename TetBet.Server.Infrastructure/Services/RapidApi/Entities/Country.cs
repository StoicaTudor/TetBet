using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities
{
    public class Country
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("code")] public string Code { get; set; }
    }
}