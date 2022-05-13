using System.Text.Json.Serialization;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities
{
    public class Team
    {
        public long Id;
        public string Name;
        public string StadiumName;
        public string ManagerName;
        public long LeagueId;
    }
}